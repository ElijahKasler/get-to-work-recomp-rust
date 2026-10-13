using System;
using System.Collections;
using System.Collections.Generic;
using Isto.Core.Inputs;
using UnityEngine;
using UnityEngine.UI;

namespace Isto.Core.UI;

public static class UIUtils
{
	public enum NavigationDirection
	{
		Up = 0,
		Down = 1,
		Left = 2,
		Right = 3
	}

	private static readonly float FULL_OPACITY = 1f;

	private static readonly float NO_OPACITY = 0f;

	private static readonly bool INTERACTABLE = true;

	private static readonly bool NON_INTERACTABLE = false;

	public static IEnumerator SetCanvasAlpha(CanvasGroup group, float targetAlpha, float fadeTime, bool interactable, Selectable selection = null)
	{
		group.interactable = interactable;
		group.blocksRaycasts = interactable;
		float timer = 0f;
		float startAlpha = group.alpha;
		while (timer < fadeTime)
		{
			group.alpha = Mathf.Lerp(startAlpha, targetAlpha, timer / fadeTime);
			timer += Time.unscaledDeltaTime;
			yield return null;
		}
		group.alpha = targetAlpha;
		if (selection != null && Controls.UsingController)
		{
			selection.Select();
		}
	}

	public static IEnumerator FadeOutAndDisableCanvas(CanvasGroup group, float fadeTime, Canvas canvas, Action callback = null)
	{
		yield return SetCanvasAlpha(group, NO_OPACITY, fadeTime, NON_INTERACTABLE);
		if ((bool)canvas)
		{
			canvas.enabled = false;
		}
		callback?.Invoke();
	}

	public static IEnumerator EnableAndShowCanvas(CanvasGroup group, float fadeTime, bool interactable, Canvas canvas, Selectable selection = null)
	{
		yield return SetCanvasAlpha(group, FULL_OPACITY, fadeTime, interactable, selection);
		if ((bool)canvas)
		{
			canvas.enabled = true;
		}
	}

	public static IEnumerator FadeOutAndDeactivateObject(CanvasGroup group, float fadeTime, GameObject gameObject)
	{
		yield return SetCanvasAlpha(group, NO_OPACITY, fadeTime, NON_INTERACTABLE);
		gameObject.SetActive(value: false);
	}

	public static IEnumerator FadeInAndEnableCanvasGroup(CanvasGroup group, float fadeTime)
	{
		yield return SetCanvasAlpha(group, FULL_OPACITY, fadeTime, INTERACTABLE);
	}

	public static void SetCameraForCanvas(GameObject source)
	{
		if (source.TryGetComponent<Canvas>(out var component))
		{
			component.worldCamera = Camera.main;
		}
	}

	public static void SetNavigation(Selectable selectable, Selectable down, Selectable left, Selectable right, Selectable up)
	{
		Navigation navigation = selectable.navigation;
		navigation.selectOnDown = down;
		navigation.selectOnLeft = left;
		navigation.selectOnRight = right;
		navigation.selectOnUp = up;
		navigation.mode = Navigation.Mode.Explicit;
		selectable.navigation = navigation;
	}

	public static void SetNavigation(Selectable selectable, NavigationDirection direction, Selectable target)
	{
		Navigation navigation = selectable.navigation;
		switch (direction)
		{
		case NavigationDirection.Up:
			navigation.selectOnUp = target;
			break;
		case NavigationDirection.Down:
			navigation.selectOnDown = target;
			break;
		case NavigationDirection.Left:
			navigation.selectOnLeft = target;
			break;
		case NavigationDirection.Right:
			navigation.selectOnRight = target;
			break;
		}
		selectable.navigation = navigation;
	}

	public static void SetupVerticalButtonsNavigation(List<Selectable> navigationElements)
	{
		Selectable selectable = null;
		Selectable selectable2 = null;
		for (int i = 0; i < navigationElements.Count; i++)
		{
			selectable = ((i > 0) ? navigationElements[i - 1] : null);
			Selectable selectable3 = navigationElements[i];
			selectable2 = ((i + 1 < navigationElements.Count) ? navigationElements[i + 1] : null);
			SetNavigation(selectable3, NavigationDirection.Up, selectable);
			SetNavigation(selectable3, NavigationDirection.Down, selectable2);
		}
	}

	public static void SetupGridNavigationForButton(Selectable button)
	{
		GridLayoutGroup componentInParent = button.GetComponentInParent<GridLayoutGroup>();
		if (componentInParent == null)
		{
			Debug.LogWarning("No GridLayoutGroup for button trying to use SetupGridNavigationForButton.  This method should not be called for this button: " + button.name);
			return;
		}
		int constraintCount = componentInParent.constraintCount;
		int siblingIndex = button.transform.GetSiblingIndex();
		int childCount = button.transform.parent.childCount;
		Navigation navigation = button.navigation;
		if (siblingIndex > 0 && navigation.selectOnLeft == null)
		{
			navigation.selectOnLeft = button.transform.parent.GetChild(siblingIndex - 1).GetComponent<Selectable>();
		}
		if (siblingIndex < childCount - 1 && siblingIndex + 1 % constraintCount != 0)
		{
			navigation.selectOnRight = button.transform.parent.GetChild(siblingIndex + 1).GetComponent<Selectable>();
		}
		if (siblingIndex - constraintCount >= 0)
		{
			navigation.selectOnUp = button.transform.parent.GetChild(siblingIndex - constraintCount).GetComponent<Selectable>();
		}
		if (siblingIndex + constraintCount < childCount)
		{
			navigation.selectOnDown = button.transform.parent.GetChild(siblingIndex + constraintCount).GetComponent<Selectable>();
		}
		button.navigation = navigation;
	}

	public static bool IsInRightColumn(Selectable button)
	{
		if (!button.gameObject.activeSelf)
		{
			return false;
		}
		int siblingIndex = button.transform.GetSiblingIndex();
		int childCount = button.transform.parent.childCount;
		List<Transform> list = new List<Transform>();
		foreach (Transform item in button.transform.parent)
		{
			if (item.gameObject.activeSelf)
			{
				list.Add(item);
				continue;
			}
			break;
		}
		if (list.Count == 1 || list.Count - 1 == siblingIndex)
		{
			return true;
		}
		if (childCount - 1 == siblingIndex)
		{
			return true;
		}
		GridLayoutGroup componentInParent = button.GetComponentInParent<GridLayoutGroup>();
		if (componentInParent == null)
		{
			Debug.LogWarning("No GridLayoutGroup for button trying to use UIUtils.IsInRightColumn(...).  This method should not be called for this button: " + button.name);
			return false;
		}
		int constraintCount = componentInParent.constraintCount;
		bool flag = (siblingIndex + 1) % constraintCount == 0;
		bool flag2 = (list.Count - 1) / constraintCount == siblingIndex / constraintCount;
		if (!flag && flag2 && !button.transform.parent.GetChild(siblingIndex + 1).gameObject.activeSelf)
		{
			flag = true;
		}
		return flag;
	}

	public static bool IsInBottomRow(Selectable button)
	{
		if (!button.gameObject.activeSelf)
		{
			return false;
		}
		int siblingIndex = button.transform.GetSiblingIndex();
		List<Transform> list = new List<Transform>();
		foreach (Transform item in button.transform.parent)
		{
			if (item.gameObject.activeSelf)
			{
				list.Add(item);
				continue;
			}
			break;
		}
		GridLayoutGroup componentInParent = button.GetComponentInParent<GridLayoutGroup>();
		if (componentInParent == null)
		{
			Debug.LogWarning("No GridLayoutGroup for button trying to use UIUtils.IsInBottomRow(...).  This method should not be called for this button: " + button.name);
			return false;
		}
		int constraintCount = componentInParent.constraintCount;
		return siblingIndex + constraintCount >= list.Count;
	}

	public static string ConvertSecondsToMinutes(float time)
	{
		int num = (int)time % 60;
		return (int)time / 60 + "m:" + num + "s";
	}

	public static float GetClosestLayoutPosToMakeChildFullyVisible(RectTransform layoutTransform, RectTransform childTransform, Func<Vector2, float> getDimension, UIScrollListSelectableItem.ScrollListAdjustmentDriver adjustmentDriver, bool tempFix)
	{
		Mask componentInParent = layoutTransform.GetComponentInParent<Mask>();
		Vector2 anchoredPosition = layoutTransform.anchoredPosition;
		float num = getDimension(anchoredPosition);
		float num2 = getDimension(childTransform.sizeDelta);
		float num3 = getDimension(componentInParent.rectTransform.sizeDelta);
		float num4 = (float)childTransform.GetSiblingIndex() * num2;
		if (adjustmentDriver == UIScrollListSelectableItem.ScrollListAdjustmentDriver.PositionDriven)
		{
			num4 = getDimension(childTransform.anchoredPosition);
		}
		if (tempFix)
		{
			num4 -= num2;
			if (num4 < 0f)
			{
				num4 = 0f;
			}
		}
		float num5 = num4 + num2;
		float num6 = num;
		float num7 = num6 + num3;
		float num8 = 0f;
		if (num4 < num6)
		{
			num8 = num4 - num2 * 1.5f - num6;
		}
		else if (num5 > num7)
		{
			num8 = num5 + num2 * 1.5f - num7;
		}
		return num + num8;
	}

	private static float GetX(Vector2 v)
	{
		return v.x;
	}

	private static float GetY(Vector2 v)
	{
		return v.y;
	}

	public static float GetClosestHorizontalLayoutPosToMakeChildFullyVisible(RectTransform layoutTransform, RectTransform elementTransform, UIScrollListSelectableItem.ScrollListAdjustmentDriver adjustmentDriver, bool tempFix)
	{
		return GetClosestLayoutPosToMakeChildFullyVisible(layoutTransform, elementTransform, GetX, adjustmentDriver, tempFix);
	}

	public static float GetClosestVerticalLayoutPosToMakeChildFullyVisible(RectTransform layoutTransform, RectTransform elementTransform, UIScrollListSelectableItem.ScrollListAdjustmentDriver adjustmentDriver, bool tempFix)
	{
		return GetClosestLayoutPosToMakeChildFullyVisible(layoutTransform, elementTransform, GetY, adjustmentDriver, tempFix);
	}

	public static void EnsureChildIsVisibleHorizontally(this RectTransform layoutGroup, RectTransform child, UIScrollListSelectableItem.ScrollListAdjustmentDriver adjustmentDriver, bool tempFix = false)
	{
		Vector2 anchoredPosition = layoutGroup.anchoredPosition;
		anchoredPosition.x = 0f - GetClosestHorizontalLayoutPosToMakeChildFullyVisible(layoutGroup, child, adjustmentDriver, tempFix);
		layoutGroup.anchoredPosition = anchoredPosition;
	}

	public static void EnsureChildIsVisibleVertically(this RectTransform layoutGroup, RectTransform child, UIScrollListSelectableItem.ScrollListAdjustmentDriver adjustmentDriver, bool tempFix = false)
	{
		Vector2 anchoredPosition = layoutGroup.anchoredPosition;
		anchoredPosition.y = GetClosestVerticalLayoutPosToMakeChildFullyVisible(layoutGroup, child, adjustmentDriver, tempFix);
		layoutGroup.anchoredPosition = anchoredPosition;
	}
}
