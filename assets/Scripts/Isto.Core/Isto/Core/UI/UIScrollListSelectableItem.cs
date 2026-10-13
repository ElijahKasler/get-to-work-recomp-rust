using Isto.Core.Inputs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Isto.Core.UI;

public class UIScrollListSelectableItem : MonoBehaviour, ISelectHandler, IEventSystemHandler
{
	public enum ScrollListAdjustmentDriver
	{
		SiblingIndexDriven = 0,
		PositionDriven = 1
	}

	[SerializeField]
	private ScrollListAdjustmentDriver _adjustmentDriver;

	[SerializeField]
	private bool _horizontal;

	[SerializeField]
	private bool _vertical;

	[SerializeField]
	private bool _fixDropdownOffset;

	private bool _fixDisabledSiblings;

	private RectTransform _parent;

	private void Awake()
	{
		_parent = base.transform.parent as RectTransform;
	}

	void ISelectHandler.OnSelect(BaseEventData eventData)
	{
		if (!Controls.UsingController)
		{
			return;
		}
		if (_fixDisabledSiblings)
		{
			Transform parent = base.transform.parent;
			for (int num = parent.childCount - 1; num >= 0; num--)
			{
				GameObject gameObject = parent.GetChild(num).gameObject;
				if (!gameObject.activeSelf)
				{
					Object.Destroy(gameObject);
				}
			}
		}
		if (_horizontal)
		{
			(base.transform.parent as RectTransform).EnsureChildIsVisibleHorizontally(base.transform as RectTransform, _adjustmentDriver, _fixDropdownOffset);
		}
		if (_vertical)
		{
			(base.transform.parent as RectTransform).EnsureChildIsVisibleVertically(base.transform as RectTransform, _adjustmentDriver, _fixDropdownOffset);
		}
	}
}
