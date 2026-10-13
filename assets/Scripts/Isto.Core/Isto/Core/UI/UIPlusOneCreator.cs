using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Isto.Core.UI;

public class UIPlusOneCreator : MonoBehaviour
{
	[SerializeField]
	protected GameObject plusOnePrefab;

	[SerializeField]
	protected GameObject plusOneParent;

	[HideInInspector]
	public GameObject plusOne;

	[HideInInspector]
	public TextMeshProUGUI plusOneText;

	private Tweener tween;

	private Tweener tween2;

	private bool Instantiate()
	{
		if (plusOne == null)
		{
			plusOne = Object.Instantiate(plusOnePrefab, plusOneParent.transform);
			plusOneText = plusOne.GetComponent<TextMeshProUGUI>();
		}
		return true;
	}

	public void Destroy()
	{
		if (plusOne != null)
		{
			Object.Destroy(plusOne);
		}
		if (tween != null)
		{
			tween.Kill();
			tween = null;
		}
	}

	public void ShowPlusOne()
	{
		ShowAnimatedText("+1");
	}

	public void ShowFull()
	{
		ShowAnimatedText("FULL");
	}

	private void ShowAnimatedText(string text)
	{
		Instantiate();
		plusOneText.text = text;
		if (tween != null && tween2 != null)
		{
			if (tween.IsPlaying())
			{
				tween.Restart();
				tween2.Restart();
			}
		}
		else
		{
			tween = plusOne.transform.DOLocalMoveY(60f, 2f).SetEase(Ease.OutQuint).SetLoops(1)
				.OnComplete(PlusOneComplete);
			TextMeshProUGUI component = plusOne.GetComponent<TextMeshProUGUI>();
			tween2 = component.DOFade(0f, 2f);
		}
	}

	private void PlusOneComplete()
	{
		Destroy();
	}
}
