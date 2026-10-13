using TMPro;
using UnityEngine;

namespace Isto.Core.UI;

public class UIPanelHeader : MonoBehaviour
{
	public Color activeColor;

	public Color nonActiveColor;

	public TextMeshProUGUI titleLeft;

	public TextMeshProUGUI titleRight;

	public TextMeshProUGUI titleMiddle;

	private void Awake()
	{
		ChangeColor(nonActiveColor);
	}

	public void SetTitleColors(Color activeColor, Color nonActiveColor)
	{
		this.activeColor = activeColor;
		this.nonActiveColor = nonActiveColor;
	}

	public void SetTitle(string title)
	{
		if (titleLeft != null)
		{
			titleLeft.text = title;
		}
		if (titleRight != null)
		{
			titleRight.text = title;
		}
		if (titleMiddle != null)
		{
			titleMiddle.text = title;
		}
	}

	public void MenuActive(bool active)
	{
		if (active)
		{
			ChangeColor(activeColor);
		}
		else
		{
			ChangeColor(nonActiveColor);
		}
	}

	private void ChangeColor(Color color)
	{
		if (titleLeft != null)
		{
			titleLeft.color = color;
		}
		if (titleRight != null)
		{
			titleRight.color = color;
		}
		if (titleMiddle != null)
		{
			titleMiddle.color = color;
		}
	}
}
