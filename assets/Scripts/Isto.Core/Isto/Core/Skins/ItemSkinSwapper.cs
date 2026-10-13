using System.Collections.Generic;
using Isto.Core.Themes;
using UnityEngine;
using Zenject;

namespace Isto.Core.Skins;

public class ItemSkinSwapper : MonoBehaviour
{
	[SerializeField]
	private int selectedSkin;

	[SerializeField]
	private List<ItemSkins> itemSkins;

	private ThemeManager _themeManager;

	[Inject]
	public void Inject(ThemeManager themeManager)
	{
		_themeManager = themeManager;
	}

	private void Start()
	{
		OnSkinChanged();
		Events.Subscribe("AdvancedItemsSkinChanged", OnSkinChanged);
	}

	private void OnDestroy()
	{
		Events.UnSubscribe("AdvancedItemsSkinChanged", OnSkinChanged);
	}

	private void OnSkinChanged()
	{
		ItemSkinGroup currentItemGroup = _themeManager.CurrentItemGroup;
		if (currentItemGroup == null)
		{
			return;
		}
		string skinGroupInternalName = currentItemGroup.skinGroupInternalName;
		if (string.IsNullOrEmpty(skinGroupInternalName))
		{
			return;
		}
		for (int i = 0; i < itemSkins.Count; i++)
		{
			if (itemSkins[i].itemGroup.skinGroupInternalName == skinGroupInternalName)
			{
				selectedSkin = i;
				SkinSwap();
				break;
			}
		}
	}

	[ContextMenu("Swap The Skins")]
	private void SkinSwap()
	{
		List<SpriteToSwap> spritesToSwap = itemSkins[selectedSkin].spritesToSwap;
		for (int i = 0; i < spritesToSwap.Count; i++)
		{
			spritesToSwap[i].spriteOnPrefab.sprite = spritesToSwap[i].newSprite;
		}
	}
}
