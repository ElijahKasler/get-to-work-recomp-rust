using System.Collections.Generic;
using System.Linq;
using Isto.Core.StateMachine;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Isto.Core.Items;

public class ItemSetMaterialState : MonoState
{
	public MonoState nextState;

	public Material placementMaterial;

	[Tooltip("If set, will use the Colors below as the invalid placement tint, otherwise uses the on set via the AdvItemDropParameters")]
	public bool overrideDefaultInvalidColor;

	public Color invalidPlaceTint = new Color(1f, 0f, 0f, 0.35f);

	[ColorUsage(true, true)]
	public Color invalidPlaceEmission = new Color(1f, 0f, 0f, 0.35f);

	[SerializeField]
	private List<SpriteRenderer> _dropTargetRenderes;

	[Tooltip("Tells the item that its drop targets will be placed in a separate step, requiring two levels of color change")]
	public bool separateDropTargetColoring;

	[SerializeField]
	[FormerlySerializedAs("dropMaterial")]
	private Material _dropMaterial;

	public Color standbyTint = new Color(0f, 0f, 1f, 0.35f);

	[ColorUsage(true, true)]
	public Color standbyEmission = new Color(0f, 0f, 1f, 0.35f);

	[Header("Floating Direction Arrow")]
	public GameObject floatingDirectionArrow;

	[Tooltip("Typically used for landing zones on SpringBoards or other distance movers")]
	public GameObject secondaryFloatingArrow;

	private ItemPlacementController _controller;

	private SpriteRenderer[] _renderers;

	private Material[] _previousMaterials;

	private Material[] _previousDropMaterials;

	private Color _previousTint;

	private Color _previousEmission;

	private int _tintID;

	private int _emissionID;

	public Material DropMaterial => _dropMaterial;

	[Inject]
	public void Inject(AdvItemDropParameters dropParameters)
	{
		if (!overrideDefaultInvalidColor)
		{
			invalidPlaceTint = dropParameters.invalidPositionColorTint;
			invalidPlaceEmission = dropParameters.invalidPositionColorEmission;
		}
	}

	protected void Awake()
	{
		_tintID = Shader.PropertyToID("_Tint");
		_emissionID = Shader.PropertyToID("_EmissionColor");
	}

	protected void OnDisable()
	{
		RestoreMaterialTint();
	}

	public override void Enter(MonoStateMachine controller)
	{
		_controller = controller as ItemPlacementController;
		if (placementMaterial != null)
		{
			if (placementMaterial.HasProperty(_tintID))
			{
				_previousTint = placementMaterial.GetColor(_tintID);
			}
			if (_dropMaterial != null && _dropMaterial.HasProperty(_emissionID))
			{
				_previousEmission = _dropMaterial.GetColor(_emissionID);
			}
			LoadRenderers();
			SetMaterials(placementMaterial, _dropMaterial);
		}
		if (floatingDirectionArrow != null)
		{
			floatingDirectionArrow.SetActive(value: true);
		}
		if (secondaryFloatingArrow != null)
		{
			secondaryFloatingArrow.SetActive(value: true);
		}
	}

	public override void Exit(MonoStateMachine controller)
	{
		if (placementMaterial != null)
		{
			RestoreMaterials();
		}
	}

	public override void ReturnFromSubState(MonoStateMachine controller, MonoState previousState)
	{
		_controller.ExitSubState();
	}

	public override MonoState Run(MonoStateMachine controller)
	{
		_controller.EnterSubState(nextState);
		return this;
	}

	public void SetMaterialTint(Color tint, Color emission)
	{
		if (placementMaterial != null && _renderers != null)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			for (int i = 0; i < _renderers.Length; i++)
			{
				_renderers[i].GetPropertyBlock(materialPropertyBlock);
				materialPropertyBlock.SetColor(_tintID, tint);
				_renderers[i].SetPropertyBlock(materialPropertyBlock);
			}
			for (int j = 0; j < _dropTargetRenderes.Count; j++)
			{
				_dropTargetRenderes[j].GetPropertyBlock(materialPropertyBlock);
				materialPropertyBlock.SetColor(_tintID, tint);
				materialPropertyBlock.SetColor(_emissionID, emission);
				_dropTargetRenderes[j].SetPropertyBlock(materialPropertyBlock);
			}
		}
	}

	private void SetMainMaterialTint(Color tint)
	{
		if (!(placementMaterial == null) && _renderers != null)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			for (int i = 0; i < _renderers.Length; i++)
			{
				_renderers[i].GetPropertyBlock(materialPropertyBlock);
				materialPropertyBlock.SetColor(_tintID, tint);
				_renderers[i].SetPropertyBlock(materialPropertyBlock);
			}
		}
	}

	private void SetDropMaterialTint(Color tint, Color emission)
	{
		if (_dropTargetRenderes != null)
		{
			MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
			for (int i = 0; i < _dropTargetRenderes.Count; i++)
			{
				_dropTargetRenderes[i].GetPropertyBlock(materialPropertyBlock);
				materialPropertyBlock.SetColor(_tintID, tint);
				materialPropertyBlock.SetColor(_emissionID, emission);
				_dropTargetRenderes[i].SetPropertyBlock(materialPropertyBlock);
			}
		}
	}

	public void RestoreMaterialTint()
	{
		SetMaterialTint(_previousTint, _previousEmission);
	}

	public void SetMaterials(Material placementMaterial, Material dropMaterial)
	{
		SetMainMaterials(placementMaterial);
		SetDropMaterials(dropMaterial);
		if (separateDropTargetColoring)
		{
			SetDropMaterialTint(standbyTint, standbyEmission);
		}
	}

	private void SetMainMaterials(Material placementMaterial)
	{
		if (!(placementMaterial == null))
		{
			for (int i = 0; i < _renderers.Length; i++)
			{
				_renderers[i].material = placementMaterial;
			}
		}
	}

	private void SetDropMaterials(Material dropMaterial)
	{
		if (!(dropMaterial == null))
		{
			for (int i = 0; i < _dropTargetRenderes.Count; i++)
			{
				_dropTargetRenderes[i].material = dropMaterial;
			}
		}
	}

	public void LoadRenderers()
	{
		_renderers = (from x in GetComponentsInChildren<SpriteRenderer>(includeInactive: true)
			where x.GetComponent<ItemDontSetThisMaterial>() == null
			select x).ToArray();
		_previousMaterials = new Material[_renderers.Length - _dropTargetRenderes.Count];
		int num = 0;
		for (int num2 = 0; num2 < _renderers.Length; num2++)
		{
			if (!_dropTargetRenderes.Contains(_renderers[num2]))
			{
				_previousMaterials[num] = _renderers[num2].material;
				num++;
			}
		}
		_previousDropMaterials = new Material[_dropTargetRenderes.Count];
		for (int num3 = 0; num3 < _dropTargetRenderes.Count; num3++)
		{
			_previousDropMaterials[num3] = _dropTargetRenderes[num3].material;
		}
	}

	public void SetDropTargetColoring(bool activated)
	{
		if (separateDropTargetColoring)
		{
			if (activated)
			{
				SetMainMaterialTint(standbyTint);
				SetDropMaterialTint(_previousTint, _previousEmission);
			}
			else
			{
				SetMainMaterialTint(_previousTint);
				SetDropMaterialTint(standbyTint, standbyEmission);
			}
		}
	}

	public void RestoreMaterials()
	{
		if (_renderers == null)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < _renderers.Length; i++)
		{
			if (!_dropTargetRenderes.Contains(_renderers[i]))
			{
				_renderers[i].material = _previousMaterials[num];
				num++;
			}
			else
			{
				_dropTargetRenderes[num2].material = _previousDropMaterials[num2];
				num2++;
			}
		}
		CoreSpritePropertyBlockSet[] componentsInChildren = GetComponentsInChildren<CoreSpritePropertyBlockSet>();
		for (int j = 0; j < componentsInChildren.Length; j++)
		{
			componentsInChildren[j].SetPropertyBlock();
		}
	}
}
