using System;
using System.Collections.Generic;
using Isto.Core.Inputs;
using UnityEngine;
using Zenject;

namespace Isto.Core.Items;

[RequireComponent(typeof(InteractableItem))]
public class ItemPlacement : MonoBehaviour, IActivatable
{
	public Transform arrowTransform;

	public Transform bodyTransform;

	public Transform dropTransform;

	public Material[] transparentMaterials;

	public Renderer[] objectRenderers;

	public bool rotateObject;

	[Header("Placement Checks")]
	[Tooltip("Layers that the object cannot be placed over.")]
	public LayerMask collisionLayers;

	public Color invalidPlaceColor;

	private InteractableItem _itemController;

	private IControls _controls;

	private float _spamTimer;

	private Material[] _startMaterials;

	private bool _canDrop;

	private Vector3 _halfExtends;

	protected Vector3 _forward;

	private List<IDirectionalItem> _directionalScripts;

	private Color _startMaterialColor;

	public Vector3 Forward => _forward;

	public bool CanDrop => _canDrop;

	[Inject]
	public void Inject(IControls controls)
	{
		_controls = controls;
	}

	private void Awake()
	{
		_itemController = GetComponent<InteractableItem>();
		_directionalScripts = new List<IDirectionalItem>();
		_halfExtends = default;
		_forward = Vector3.forward;
		SetStartMaterials();
	}

	private void OnEnable()
	{
		_itemController.enabled = false;
		_spamTimer = 0f;
		if (transparentMaterials.Length != 0)
		{
			if (transparentMaterials[0].HasProperty("_Color"))
			{
				_startMaterialColor = transparentMaterials[0].color;
			}
			else if (transparentMaterials[0].HasProperty("_Tint"))
			{
				_startMaterialColor = transparentMaterials[0].GetColor("_Tint");
			}
			SetMaterialForObject(transparentMaterials);
		}
		_directionalScripts.AddRange(GetComponents<IDirectionalItem>());
	}

	private void OnDisable()
	{
		if (arrowTransform != null)
		{
			arrowTransform.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		_spamTimer += Time.deltaTime;
		if (_spamTimer > Constants.BUTTON_SPAM_DELAY)
		{
			HandleRotationInput();
		}
		_canDrop = AtValidDropPosition();
	}

	private void HandleRotationInput()
	{
		if (_controls.GetButton(UserActions.ROTATELEFT))
		{
			Rotate(-1);
			_spamTimer = 0f;
		}
		else if (_controls.GetButton(UserActions.ROTATERIGHT))
		{
			Rotate(1);
			_spamTimer = 0f;
		}
	}

	protected virtual void Rotate(int direction)
	{
		if (arrowTransform != null)
		{
			arrowTransform.Rotate(Vector3.up, (float)direction * 90f, Space.World);
		}
		if (rotateObject)
		{
			CoreItem item = _itemController.itemPile.item;
			float num;
			if (item.GetType() == typeof(AdvancedItem))
			{
				AdvancedItem advancedItem = item as AdvancedItem;
				num = Mathf.Max(advancedItem.width, advancedItem.depth);
			}
			else
			{
				num = 1f;
			}
			Vector3 point = base.transform.position + new Vector3((0f - num) / 2f, 0f, num / 2f);
			bodyTransform.RotateAround(point, Vector3.up, (float)direction * 90f);
		}
		Quaternion quaternion = Quaternion.AngleAxis((float)direction * 90f, Vector3.up);
		_forward = quaternion * _forward;
		UpdateForwardInScripts(_forward);
		if (dropTransform != null)
		{
			Vector3 localPosition = dropTransform.localPosition;
			Vector3 localPosition2 = quaternion * localPosition;
			dropTransform.localPosition = localPosition2;
		}
	}

	private void SetMaterialForObject(Material[] materials)
	{
		if (objectRenderers.Length != materials.Length)
		{
			Debug.LogError("Length of Material arrays don't match. This should not happen");
			return;
		}
		for (int i = 0; i < objectRenderers.Length; i++)
		{
			objectRenderers[i].material = materials[i];
		}
	}

	private void SetStartMaterials()
	{
		_startMaterials = new Material[objectRenderers.Length];
		for (int i = 0; i < _startMaterials.Length; i++)
		{
			_startMaterials[i] = objectRenderers[i].material;
		}
	}

	private bool AtValidDropPosition()
	{
		AdvancedItem advancedItem = _itemController.itemPile.item as AdvancedItem;
		if (advancedItem != null)
		{
			float num = Mathf.Max(advancedItem.depth, advancedItem.width) / 2f;
			_halfExtends.Set(num, 0.5f, num);
			Vector3 position = base.transform.position;
			position.x -= num;
			position.z += num;
			if (Physics.OverlapBox(position, _halfExtends, Quaternion.identity, collisionLayers).Length != 0)
			{
				SetSpriteColor(invalidPlaceColor);
				return false;
			}
			SetSpriteColor(_startMaterialColor);
			return true;
		}
		return true;
	}

	private void SetSpriteColor(Color color)
	{
		for (int i = 0; i < objectRenderers.Length; i++)
		{
			Material material = objectRenderers[i].material;
			if (material.HasProperty("_Color"))
			{
				material.color = color;
			}
			else if (material.HasProperty("_Tint"))
			{
				material.SetColor("_Tint", color);
			}
			objectRenderers[i].material.color = color;
		}
	}

	protected void UpdateForwardInScripts(Vector3 forward)
	{
		for (int i = 0; i < _directionalScripts.Count; i++)
		{
			_directionalScripts[i].SetForwardDirection(forward);
		}
	}

	public void Activate()
	{
		SetMaterialForObject(_startMaterials);
		base.enabled = false;
	}

	public void SetStartRotation(float angle)
	{
		if (angle % 90f != 0f)
		{
			Debug.LogError("Angle passed to set start rotation should be a multiple of 90. Angle: " + angle);
			return;
		}
		int num = Math.Abs((int)(angle / 90f));
		if (_directionalScripts == null || _directionalScripts.Count == 0)
		{
			_directionalScripts.AddRange(GetComponents<IDirectionalItem>());
		}
		for (int i = 0; i < num; i++)
		{
			Rotate(-1 * Math.Sign(angle));
		}
	}
}
