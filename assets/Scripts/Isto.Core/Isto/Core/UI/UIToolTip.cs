using System.Collections.Generic;
using Isto.Core.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class UIToolTip : MonoBehaviour
{
	public class Pool : MonoMemoryPool<string, UIToolTip>
	{
		protected override void Reinitialize(string itemName, UIToolTip item)
		{
			if (itemName == null)
			{
				Debug.LogError("Attempting to Reinitialize UIToolTip with a null itemName, is there still a localization issue?");
			}
			else
			{
				Loc.SetTMProLocalized(item.nameText, itemName.ToUpper());
			}
		}

		protected override void OnDespawned(UIToolTip item)
		{
			item.DespawnRows();
			base.OnDespawned(item);
		}
	}

	public VerticalLayoutGroup vertGroup;

	public TextMeshProUGUI nameText;

	private Canvas _parentCanvas;

	private UIToolTipRow.Pool _rowPool;

	private List<UIToolTipRow> _currentRows;

	public Canvas Canvas => _parentCanvas;

	[Inject]
	public void Construct(UIToolTipRow.Pool pool)
	{
		_rowPool = pool;
		_parentCanvas = base.transform.GetComponentInParent<Canvas>();
	}

	private void Awake()
	{
		_currentRows = new List<UIToolTipRow>();
	}

	public void AddRow(Sprite icon, string toolTip, Sprite secondaryIcon = null)
	{
		UIToolTipRow uIToolTipRow = _rowPool.Spawn(icon, toolTip, secondaryIcon);
		uIToolTipRow.transform.SetParent(vertGroup.transform, worldPositionStays: true);
		_currentRows.Add(uIToolTipRow);
	}

	public void DespawnRows()
	{
		for (int num = _currentRows.Count; num > 0; num--)
		{
			_rowPool.Despawn(_currentRows[num - 1]);
		}
		_currentRows.Clear();
	}
}
