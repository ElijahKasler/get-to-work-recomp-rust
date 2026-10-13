using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace UnityEngine.Rendering;

[ExecuteAlways]
[AddComponentMenu("Miscellaneous/Volume")]
public class Volume : MonoBehaviour, IVolume
{
	[SerializeField]
	[FormerlySerializedAs("isGlobal")]
	private bool m_IsGlobal = true;

	[Delayed]
	public float priority;

	public float blendDistance;

	[Range(0f, 1f)]
	public float weight = 1f;

	public VolumeProfile sharedProfile;

	internal List<Collider> m_Colliders = new List<Collider>();

	private int m_PreviousLayer;

	private float m_PreviousPriority;

	private VolumeProfile m_InternalProfile;

	public bool isGlobal
	{
		get
		{
			return m_IsGlobal;
		}
		set
		{
			m_IsGlobal = value;
		}
	}

	public VolumeProfile profile
	{
		get
		{
			if (m_InternalProfile == null)
			{
				m_InternalProfile = ScriptableObject.CreateInstance<VolumeProfile>();
				if (sharedProfile != null)
				{
					m_InternalProfile.name = sharedProfile.name;
					foreach (VolumeComponent component in sharedProfile.components)
					{
						VolumeComponent item = Object.Instantiate(component);
						m_InternalProfile.components.Add(item);
					}
				}
			}
			return m_InternalProfile;
		}
		set
		{
			m_InternalProfile = value;
		}
	}

	public List<Collider> colliders => m_Colliders;

	internal VolumeProfile profileRef
	{
		get
		{
			if (!(m_InternalProfile == null))
			{
				return m_InternalProfile;
			}
			return sharedProfile;
		}
	}

	public bool HasInstantiatedProfile()
	{
		return m_InternalProfile != null;
	}

	private void OnEnable()
	{
		m_PreviousLayer = base.gameObject.layer;
		VolumeManager.instance.Register(this);
		GetComponents(m_Colliders);
	}

	private void OnDisable()
	{
		VolumeManager.instance.Unregister(this);
	}

	private void Update()
	{
		UpdateLayer();
		UpdatePriority();
	}

	internal void UpdateLayer()
	{
		int layer = base.gameObject.layer;
		if (layer != m_PreviousLayer)
		{
			VolumeManager.instance.UpdateVolumeLayer(this, m_PreviousLayer, layer);
			m_PreviousLayer = layer;
		}
	}

	internal void UpdatePriority()
	{
		if (Math.Abs(priority - m_PreviousPriority) > Mathf.Epsilon)
		{
			VolumeManager.instance.SetLayerDirty(base.gameObject.layer);
			m_PreviousPriority = priority;
		}
	}

	private void OnValidate()
	{
		blendDistance = Mathf.Max(blendDistance, 0f);
	}
}
