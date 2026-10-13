#define UNITY_ASSERTIONS
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace UnityEngine.UIElements;

[AddComponentMenu("UI Toolkit/UI Document")]
[ExecuteAlways]
[DisallowMultipleComponent]
[DefaultExecutionOrder(-100)]
[HelpURL("UIE-get-started-with-runtime-ui")]
public sealed class UIDocument : MonoBehaviour
{
	internal enum WorldSpaceSizeMode
	{
		Dynamic = 0,
		Fixed = 1
	}

	internal const string k_RootStyleClassName = "unity-ui-document__root";

	internal const string k_VisualElementNameSuffix = "-container";

	private const int k_DefaultSortingOrder = 0;

	private static int s_CurrentUIDocumentCounter;

	internal readonly int m_UIDocumentCreationIndex;

	[SerializeField]
	private PanelSettings m_PanelSettings;

	private PanelSettings m_PreviousPanelSettings = null;

	[SerializeField]
	private UIDocument m_ParentUI;

	private UIDocumentList m_ChildrenContent = null;

	private List<UIDocument> m_ChildrenContentCopy = null;

	[SerializeField]
	private VisualTreeAsset sourceAsset;

	private VisualElement m_RootVisualElement;

	private RuntimePanel m_RuntimePanel;

	private int m_FirstChildInsertIndex;

	[SerializeField]
	private float m_SortingOrder = 0f;

	[SerializeField]
	private WorldSpaceSizeMode m_WorldSpaceSizeMode = WorldSpaceSizeMode.Fixed;

	[SerializeField]
	private float m_WorldSpaceWidth = 1920f;

	[SerializeField]
	private float m_WorldSpaceHeight = 1080f;

	private bool m_RootHasWorldTransform;

	public PanelSettings panelSettings
	{
		get
		{
			return m_PanelSettings;
		}
		set
		{
			if (parentUI == null)
			{
				if (m_PanelSettings == value)
				{
					m_PreviousPanelSettings = m_PanelSettings;
					return;
				}
				if (m_PanelSettings != null)
				{
					m_PanelSettings.DetachUIDocument(this);
				}
				m_PanelSettings = value;
				if (m_PanelSettings != null)
				{
					m_PanelSettings.AttachAndInsertUIDocumentToVisualTree(this);
				}
			}
			else
			{
				Assert.AreEqual(parentUI.m_PanelSettings, value);
				m_PanelSettings = parentUI.m_PanelSettings;
			}
			if (m_ChildrenContent != null)
			{
				foreach (UIDocument attachedUIDocument in m_ChildrenContent.m_AttachedUIDocuments)
				{
					attachedUIDocument.panelSettings = m_PanelSettings;
				}
			}
			m_PreviousPanelSettings = m_PanelSettings;
		}
	}

	public UIDocument parentUI
	{
		get
		{
			return m_ParentUI;
		}
		private set
		{
			m_ParentUI = value;
		}
	}

	public VisualTreeAsset visualTreeAsset
	{
		get
		{
			return sourceAsset;
		}
		set
		{
			sourceAsset = value;
			RecreateUI();
		}
	}

	public VisualElement rootVisualElement => m_RootVisualElement;

	internal int firstChildInserIndex => m_FirstChildInsertIndex;

	internal WorldSpaceSizeMode worldSpaceSizeMode => m_WorldSpaceSizeMode;

	public float sortingOrder
	{
		get
		{
			return m_SortingOrder;
		}
		set
		{
			if (m_SortingOrder != value)
			{
				m_SortingOrder = value;
				ApplySortingOrder();
			}
		}
	}

	public IRuntimePanel runtimePanel
	{
		get
		{
			ResolveRuntimePanel();
			return m_RuntimePanel;
		}
	}

	private float pixelsPerUnit => (m_RuntimePanel == null) ? 1f : m_RuntimePanel.pixelsPerUnit;

	internal void ApplySortingOrder()
	{
		AddRootVisualElementToTree();
	}

	private UIDocument()
	{
		m_UIDocumentCreationIndex = s_CurrentUIDocumentCounter++;
	}

	private void Awake()
	{
		SetupFromHierarchy();
	}

	private void OnEnable()
	{
		if (parentUI != null && m_PanelSettings == null)
		{
			m_PanelSettings = parentUI.m_PanelSettings;
		}
		if (m_RootVisualElement == null)
		{
			RecreateUI();
		}
		else
		{
			AddRootVisualElementToTree();
		}
		if (TryGetComponent<UIRenderer>(out var component))
		{
			component.enabled = true;
		}
		ResolveRuntimePanel();
	}

	private void ResolveRuntimePanel()
	{
		if (m_RuntimePanel == null)
		{
			m_RuntimePanel = rootVisualElement?.panel as RuntimePanel;
		}
	}

	private void LateUpdate()
	{
		if (m_RootVisualElement != null && !(panelSettings == null) && panelSettings.panel != null)
		{
			AddOrRemoveRendererComponent();
			if (!panelSettings.panel.isFlat)
			{
				ResolveRuntimePanel();
				SetTransform();
				UpdateRenderer();
			}
			else if (m_RootHasWorldTransform)
			{
				ClearTransform();
			}
		}
	}

	private void UpdateRenderer()
	{
		if (!TryGetComponent<UIRenderer>(out var component))
		{
			rootVisualElement.uiRenderer = null;
			UpdateCutRenderChainFlag();
			return;
		}
		rootVisualElement.uiRenderer = component;
		component.skipRendering = parentUI != null || pixelsPerUnit < Mathf.Epsilon;
		BaseRuntimePanel baseRuntimePanel = (BaseRuntimePanel)m_RootVisualElement.panel;
		if (baseRuntimePanel != null)
		{
			Debug.Assert(baseRuntimePanel.drawsInCameras);
			Bounds bounds = rootVisualElement.localBounds3D;
			VisualElement.TransformAlignedBounds(ref rootVisualElement.worldTransformRef, ref bounds);
			component.localBounds = SanitizeRendererBounds(bounds);
			UpdateCutRenderChainFlag();
		}
	}

	private Bounds SanitizeRendererBounds(Bounds b)
	{
		if (float.IsNaN(b.size.x) || float.IsNaN(b.size.y) || float.IsNaN(b.size.z))
		{
			return new Bounds(Vector3.zero, Vector3.zero);
		}
		return b;
	}

	private void AddOrRemoveRendererComponent()
	{
		TryGetComponent<UIRenderer>(out var component);
		if (m_PanelSettings != null)
		{
			BaseRuntimePanel panel = m_PanelSettings.panel;
			if (panel != null && panel.drawsInCameras)
			{
				if (component == null)
				{
					base.gameObject.AddComponent<UIRenderer>();
				}
				return;
			}
		}
		UIRUtility.Destroy(component);
	}

	private void UpdateCutRenderChainFlag()
	{
		bool flag = parentUI == null;
		if (rootVisualElement.shouldCutRenderChain != flag)
		{
			rootVisualElement.shouldCutRenderChain = flag;
			rootVisualElement.MarkDirtyRepaint();
		}
	}

	private void SetTransform()
	{
		ComputeTransform(base.transform, out var matrix);
		m_RootVisualElement.style.transformOrigin = new TransformOrigin(Vector3.zero);
		m_RootVisualElement.style.translate = new Translate(matrix.GetPosition());
		m_RootVisualElement.style.rotate = new Rotate(matrix.rotation);
		m_RootVisualElement.style.scale = new Scale(matrix.lossyScale);
		m_RootHasWorldTransform = true;
	}

	private void ClearTransform()
	{
		m_RootVisualElement.style.transformOrigin = StyleKeyword.Null;
		m_RootVisualElement.style.translate = StyleKeyword.Null;
		m_RootVisualElement.style.rotate = StyleKeyword.Null;
		m_RootVisualElement.style.scale = StyleKeyword.Null;
		m_RootHasWorldTransform = false;
	}

	private void ComputeTransform(Transform transform, out Matrix4x4 matrix)
	{
		float num = pixelsPerUnit;
		if (num < Mathf.Epsilon)
		{
			matrix = Matrix4x4.identity;
			return;
		}
		float num2 = 1f / num;
		Vector3 s = Vector3.one * num2;
		Quaternion q = Quaternion.AngleAxis(180f, Vector3.right);
		if (parentUI == null)
		{
			matrix = Matrix4x4.TRS(Vector3.zero, q, s);
			return;
		}
		Matrix4x4 matrix4x = Matrix4x4.TRS(Vector3.zero, q, s);
		Matrix4x4 inverse = matrix4x.inverse;
		Matrix4x4 localToWorldMatrix = transform.localToWorldMatrix;
		Matrix4x4 worldToLocalMatrix = parentUI.transform.worldToLocalMatrix;
		matrix = inverse * worldToLocalMatrix * localToWorldMatrix * matrix4x;
	}

	private static void SetNoTransform(VisualElement visualElement)
	{
		visualElement.style.translate = Translate.None();
		visualElement.style.rotate = Rotate.None();
		visualElement.style.scale = Scale.None();
	}

	private void SetupFromHierarchy()
	{
		if (parentUI != null)
		{
			parentUI.RemoveChild(this);
		}
		parentUI = FindUIDocumentParent();
	}

	private UIDocument FindUIDocumentParent()
	{
		Transform transform = base.transform;
		Transform parent = transform.parent;
		if (parent != null)
		{
			UIDocument[] componentsInParent = parent.GetComponentsInParent<UIDocument>(includeInactive: true);
			if (componentsInParent != null && componentsInParent.Length != 0)
			{
				return componentsInParent[0];
			}
		}
		return null;
	}

	internal void Reset()
	{
		if (parentUI == null)
		{
			m_PreviousPanelSettings?.DetachUIDocument(this);
			panelSettings = null;
		}
		SetupFromHierarchy();
		if (parentUI != null)
		{
			m_PanelSettings = parentUI.m_PanelSettings;
			AddRootVisualElementToTree();
		}
		else if (m_PanelSettings != null)
		{
			AddRootVisualElementToTree();
		}
	}

	private void AddChildAndInsertContentToVisualTree(UIDocument child)
	{
		if (m_ChildrenContent == null)
		{
			m_ChildrenContent = new UIDocumentList();
		}
		else
		{
			m_ChildrenContent.RemoveFromListAndFromVisualTree(child);
		}
		m_ChildrenContent.AddToListAndToVisualTree(child, m_RootVisualElement, m_FirstChildInsertIndex);
	}

	private void RemoveChild(UIDocument child)
	{
		m_ChildrenContent?.RemoveFromListAndFromVisualTree(child);
	}

	private void RecreateUI()
	{
		if (m_RootVisualElement != null)
		{
			RemoveFromHierarchy();
			m_RootVisualElement = null;
		}
		if (sourceAsset != null)
		{
			m_RootVisualElement = sourceAsset.Instantiate();
			if (m_RootVisualElement == null)
			{
				Debug.LogError("The UXML file set for the UIDocument could not be cloned.");
			}
		}
		if (m_RootVisualElement == null)
		{
			m_RootVisualElement = new TemplateContainer
			{
				name = base.gameObject.name + "-container"
			};
		}
		else
		{
			m_RootVisualElement.name = base.gameObject.name + "-container";
		}
		m_RootVisualElement.pickingMode = PickingMode.Ignore;
		if (base.isActiveAndEnabled)
		{
			AddRootVisualElementToTree();
		}
		m_FirstChildInsertIndex = m_RootVisualElement.childCount;
		if (m_ChildrenContent != null)
		{
			if (m_ChildrenContentCopy == null)
			{
				m_ChildrenContentCopy = new List<UIDocument>(m_ChildrenContent.m_AttachedUIDocuments);
			}
			else
			{
				m_ChildrenContentCopy.AddRange(m_ChildrenContent.m_AttachedUIDocuments);
			}
			foreach (UIDocument item in m_ChildrenContentCopy)
			{
				if (item.isActiveAndEnabled)
				{
					if (item.m_RootVisualElement == null)
					{
						item.RecreateUI();
					}
					else
					{
						AddChildAndInsertContentToVisualTree(item);
					}
				}
			}
			m_ChildrenContentCopy.Clear();
		}
		SetupRootClassList();
	}

	private void SetupRootClassList()
	{
		if (m_RootVisualElement != null)
		{
			if (panelSettings == null || panelSettings.renderMode != PanelRenderMode.WorldSpace)
			{
				m_RootVisualElement.EnableInClassList("unity-ui-document__root", parentUI == null);
			}
			else
			{
				UpdateWorldSpaceSize();
			}
		}
	}

	private void UpdateWorldSpaceSize()
	{
		if (m_RootVisualElement != null)
		{
			if (m_WorldSpaceSizeMode == WorldSpaceSizeMode.Fixed)
			{
				m_RootVisualElement.style.position = Position.Absolute;
				m_RootVisualElement.style.width = m_WorldSpaceWidth;
				m_RootVisualElement.style.height = m_WorldSpaceHeight;
			}
			else
			{
				m_RootVisualElement.style.position = Position.Absolute;
				m_RootVisualElement.style.width = StyleKeyword.Null;
				m_RootVisualElement.style.height = StyleKeyword.Null;
			}
		}
	}

	private void AddRootVisualElementToTree()
	{
		if (base.enabled)
		{
			if (parentUI != null)
			{
				parentUI.AddChildAndInsertContentToVisualTree(this);
			}
			else if (m_PanelSettings != null)
			{
				m_PanelSettings.AttachAndInsertUIDocumentToVisualTree(this);
			}
		}
	}

	private void RemoveFromHierarchy()
	{
		if (parentUI != null)
		{
			parentUI.RemoveChild(this);
		}
		else if (m_PanelSettings != null)
		{
			m_PanelSettings.DetachUIDocument(this);
		}
	}

	private void OnDisable()
	{
		if (m_RootVisualElement != null)
		{
			RemoveFromHierarchy();
			m_RootVisualElement = null;
		}
		if (TryGetComponent<UIRenderer>(out var component))
		{
			component.enabled = false;
		}
	}

	private void OnTransformChildrenChanged()
	{
		if (m_ChildrenContent == null)
		{
			return;
		}
		if (m_ChildrenContentCopy == null)
		{
			m_ChildrenContentCopy = new List<UIDocument>(m_ChildrenContent.m_AttachedUIDocuments);
		}
		else
		{
			m_ChildrenContentCopy.AddRange(m_ChildrenContent.m_AttachedUIDocuments);
		}
		foreach (UIDocument item in m_ChildrenContentCopy)
		{
			item.ReactToHierarchyChanged();
		}
		m_ChildrenContentCopy.Clear();
	}

	private void OnTransformParentChanged()
	{
		ReactToHierarchyChanged();
	}

	internal void ReactToHierarchyChanged()
	{
		SetupFromHierarchy();
		if (parentUI != null)
		{
			panelSettings = parentUI.m_PanelSettings;
		}
		m_RootVisualElement?.RemoveFromHierarchy();
		AddRootVisualElementToTree();
		SetupRootClassList();
	}
}
