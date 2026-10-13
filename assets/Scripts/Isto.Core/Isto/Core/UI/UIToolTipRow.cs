using Isto.Core.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.UI;

public class UIToolTipRow : MonoBehaviour
{
	public class Pool : MonoMemoryPool<Sprite, string, Sprite, UIToolTipRow>
	{
		protected override void Reinitialize(Sprite icon, string toolTip, Sprite secondaryIcon, UIToolTipRow item)
		{
			item.SetRow(icon, toolTip, secondaryIcon);
		}
	}

	public Image controlImg;

	public Image secondaryImg;

	public TextMeshProUGUI toolTipText;

	public void SetRow(Sprite controlIcon, string toolTip, Sprite secondaryIcon = null)
	{
		controlImg.sprite = controlIcon;
		controlImg.gameObject.SetActive(controlIcon != null);
		if (secondaryIcon == null)
		{
			secondaryImg.gameObject.SetActive(value: false);
		}
		else
		{
			secondaryImg.gameObject.SetActive(value: true);
			secondaryImg.sprite = secondaryIcon;
		}
		Loc.SetTMProLocalized(toolTipText, toolTip?.ToUpper());
	}
}
