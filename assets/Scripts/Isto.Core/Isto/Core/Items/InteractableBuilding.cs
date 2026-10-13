using System;
using Cinemachine;
using Isto.Core.Data;
using UnityEngine;

namespace Isto.Core.Items;

public abstract class InteractableBuilding : InteractableItem, IDataLoadCompleteHandler
{
	public EventHandler<EventArgs> BuildingTurnedOn;

	[Header("Interactable Building Base Properties")]
	public GameObject moduleOutline;

	public int enabledInLevel;

	[Tooltip("Used when showing building when in menu")]
	public CinemachineVirtualCamera focusCamera;

	[Tooltip("Used when showing building in tutorial")]
	public CinemachineVirtualCamera overviewCamera;

	public Sprite warningSymbol;

	public Sprite stopSymbol;

	[Header("Dialogue")]
	[SerializeField]
	protected BuildingDialogue _buildingDialogue;

	protected Color _onlineTextColor = Constants.ATRIO_PINK_LIGHT;

	protected Color _offlineTextColor = Constants.ATRIO_DISABLED_GREY2;

	protected bool _buildingOn;

	private bool _tempHideAlert;

	public bool IsOn => _buildingOn;

	public override void ShowTooltip()
	{
		_buildingDialogue.ShowToolTipDialogue(_buildingOn);
		if (_buildingDialogue.IsMessageActive())
		{
			_tempHideAlert = true;
			_buildingDialogue.HideAlertMessage();
		}
		moduleOutline.SetActive(value: true);
	}

	public override void SetInactive()
	{
		moduleOutline.SetActive(value: false);
		_buildingDialogue.HideToolTipDialogue();
		if (_tempHideAlert)
		{
			_tempHideAlert = false;
			_buildingDialogue.UnHideAlertMessage();
		}
	}

	public virtual void OnDataLoadComplete()
	{
		if (enabledInLevel > 0)
		{
			Debug.LogWarning("InteractableBuilding.OnDataLoadComplete: " + base.gameObject.name + " expected to be " + $"enabled at level #{enabledInLevel} but not validated in current flow", base.gameObject);
		}
	}
}
