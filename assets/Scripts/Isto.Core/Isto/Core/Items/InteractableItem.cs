using System.Collections.Generic;
using Isto.Core.Beings;
using Isto.Core.Inputs;
using Isto.Core.UI;
using UnityEngine;
using Zenject;

namespace Isto.Core.Items;

[SelectionBase]
public abstract class InteractableItem : MonoBehaviour, IInteractable
{
	public ItemPile itemPile;

	[Header("Item Outlines on mouse over")]
	public List<GameObject> outlines;

	protected UIToolTip.Pool _toolTipPool;

	protected UIToolTip _activeTooltip;

	protected IControls _controls;

	protected MasterItemList _masterItemList;

	protected Transform _selectionHighlightTransform;

	protected Vector3 _toolTipOffset = new Vector3(0f, 0f, 0f);

	protected List<UserActions> _actionList = new List<UserActions>();

	protected bool _interactive = true;

	protected bool _toolTipVisible;

	[Inject]
	public virtual void Inject(UIToolTip.Pool tooltipPool, IControls controls, MasterItemList masterItemList, [InjectOptional(Id = "SelectionHighlight")] Transform selectionHighlight)
	{
		_toolTipPool = tooltipPool;
		_controls = controls;
		_masterItemList = masterItemList;
		_selectionHighlightTransform = selectionHighlight;
	}

	protected virtual void Awake()
	{
		HideOutline();
	}

	protected virtual void Update()
	{
		MoveToolTip();
	}

	protected virtual void OnDestroy()
	{
		SetInactive();
	}

	public abstract string GetItemName();

	public abstract string GetToolTip(UserActions action);

	public abstract List<UserActions> GetValidActions();

	public virtual void ShowTooltip(float offset, bool showSelectionhighlight = true)
	{
		if (_interactive && !(_activeTooltip != null))
		{
			_activeTooltip = _toolTipPool.Spawn(GetItemName());
			_toolTipVisible = true;
			_toolTipOffset = new Vector3(0f, 0f, 0f);
			_toolTipOffset.y += offset;
			_activeTooltip.transform.position = UnityUtils.TransformWorldToCanvasPoint(base.transform.position + _toolTipOffset, _activeTooltip.Canvas);
			List<UserActions> validActions = GetValidActions();
			for (int i = 0; i < validActions.Count; i++)
			{
				UserActions action = validActions[i];
				string toolTip = GetToolTip(action);
				_activeTooltip.AddRow(_controls.GetIconForAction(action), toolTip);
			}
			if (showSelectionhighlight)
			{
				ShowOutline();
			}
		}
	}

	public virtual void ShowTooltip()
	{
		ShowTooltip(0f);
	}

	public virtual void SetInactive()
	{
		if (_activeTooltip != null)
		{
			_toolTipPool.Despawn(_activeTooltip);
			_activeTooltip = null;
			_toolTipVisible = false;
			if (!_selectionHighlightTransform.IsNullOrDestroyed())
			{
				_selectionHighlightTransform.gameObject.SetActive(value: false);
			}
		}
		HideOutline();
	}

	public virtual void SetInteractive(bool state)
	{
		_interactive = state;
		if (!state)
		{
			SetInactive();
		}
	}

	public virtual Vector3 GetInteractionPosition(Vector3 playerPosition)
	{
		Vector3 vector = ((UnityUtils.GetRelativeHorizontalDirection(playerPosition, base.transform.position) > 0f) ? Constants.HARVEST_BEAM_ALIGN_RIGHT : Constants.HARVEST_BEAM_ALIGN_LEFT);
		return base.transform.position + vector;
	}

	protected virtual void MoveToolTip()
	{
		if (_toolTipVisible)
		{
			_activeTooltip.transform.position = UnityUtils.TransformWorldToCanvasPoint(base.transform.position + _toolTipOffset, _activeTooltip.Canvas);
			if (!_selectionHighlightTransform.IsNullOrDestroyed() && _selectionHighlightTransform.gameObject.activeInHierarchy)
			{
				_selectionHighlightTransform.position = base.transform.position;
			}
		}
	}

	protected virtual void ShowOutline()
	{
		if (outlines.Count > 0)
		{
			for (int i = 0; i < outlines.Count; i++)
			{
				if (outlines[i] != null && outlines[i].transform.parent != null && outlines[i].transform.parent.gameObject.activeInHierarchy)
				{
					outlines[i].SetActive(value: true);
				}
			}
		}
		else if (!_selectionHighlightTransform.IsNullOrDestroyed())
		{
			_selectionHighlightTransform.gameObject.SetActive(value: true);
			_selectionHighlightTransform.position = base.transform.position;
		}
	}

	protected virtual void HideOutline()
	{
		if (outlines.Count <= 0)
		{
			return;
		}
		for (int i = 0; i < outlines.Count; i++)
		{
			if (outlines[i] != null)
			{
				outlines[i].SetActive(value: false);
			}
		}
	}

	public virtual void PlayerInteraction(AutomationPlayerController player, UserActions action)
	{
		player.SetPickupItem(this);
	}

	public virtual void ReduceCount(int amount)
	{
		itemPile.count -= amount;
	}
}
