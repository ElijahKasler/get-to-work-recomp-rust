using Isto.Core.Items;
using UnityEngine;
using UnityEngine.Rendering;

namespace Isto.Core;

[RequireComponent(typeof(SpriteRenderer))]
public class CoreSpritePropertyBlockSet : MonoBehaviour, IActivatable
{
	public Color tint = Color.white;

	[Header("Lighting")]
	public Texture normalMap;

	[Header("Emission")]
	public Texture emissionMap;

	public float emissionFactor;

	public Color emissionTint = Color.white;

	public bool disableEmissionInDark = true;

	[Header("Reflections")]
	public Material reflectionMaterial;

	public bool RunEveryFrame;

	[SerializeField]
	private Transform _reflection;

	protected float _startEmission;

	private SpriteRenderer _renderer;

	private MaterialPropertyBlock _propBlock;

	protected void Awake()
	{
		TryGetComponent<SpriteRenderer>(out _renderer);
		_propBlock = new MaterialPropertyBlock();
		_startEmission = emissionFactor;
		SetPropertyBlock();
	}

	protected void Start()
	{
		base.enabled = RunEveryFrame;
	}

	protected void Update()
	{
		SetPropertyBlock();
	}

	public void SetPropertyBlock()
	{
		if (_renderer == null)
		{
			return;
		}
		_renderer.shadowCastingMode = ShadowCastingMode.TwoSided;
		_renderer.GetPropertyBlock(_propBlock);
		_propBlock.Clear();
		if (_renderer.sprite != null)
		{
			_propBlock.SetTexture("_MainTex", _renderer.sprite.texture);
		}
		_propBlock.SetColor("_Color", tint);
		if (normalMap != null)
		{
			_propBlock.SetTexture("_BumpMap", normalMap);
		}
		if (emissionMap != null)
		{
			_propBlock.SetTexture("_EmissionMap", emissionMap);
			if (_renderer.sharedMaterial.HasProperty("_EmissionColor"))
			{
				_propBlock.SetColor("_EmissionColor", emissionTint * emissionFactor);
			}
		}
		else if (_renderer != null && _renderer.sprite != null)
		{
			_propBlock.SetTexture("_EmissionMap", _renderer.sprite.texture);
			_propBlock.SetColor("_EmissionColor", Color.black);
		}
		_renderer.SetPropertyBlock(_propBlock);
	}

	public void SetPropertyBlockInEditor()
	{
		_renderer = GetComponent<SpriteRenderer>();
		_propBlock = new MaterialPropertyBlock();
		SetPropertyBlock();
	}

	public void AddReflection()
	{
		if (reflectionMaterial != null)
		{
			if (_reflection == null)
			{
				_reflection = new GameObject("Reflection", typeof(SpriteRenderer)).transform;
				_reflection.parent = base.transform;
				_reflection.localPosition = Vector3.zero;
				_reflection.localRotation = Quaternion.identity;
				_reflection.localScale = Vector3.one;
			}
			SpriteRenderer component = _reflection.GetComponent<SpriteRenderer>();
			component.sharedMaterial = reflectionMaterial;
			SpriteRenderer component2 = GetComponent<SpriteRenderer>();
			component.sprite = component2.sprite;
			component.color = component2.color;
		}
		else if (reflectionMaterial == null && _reflection != null)
		{
			Object.Destroy(_reflection.gameObject);
		}
	}

	public virtual void OnPowerOn()
	{
		if (disableEmissionInDark)
		{
			emissionFactor = _startEmission;
		}
		SetPropertyBlock();
	}

	public virtual void OnPowerOff()
	{
		if (disableEmissionInDark)
		{
			emissionFactor = 0f;
		}
		SetPropertyBlock();
	}

	public void Activate()
	{
		SetPropertyBlock();
	}
}
