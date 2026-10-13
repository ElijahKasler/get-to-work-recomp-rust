using UnityEngine.UI;

namespace Isto.Core.UI;

public static class NavigationExtensions
{
	public static void Copy(this Navigation nav, Navigation otherNav, bool copyOnlyIfNull = false)
	{
		if (!copyOnlyIfNull || nav.selectOnUp == null)
		{
			nav.selectOnUp = otherNav.selectOnUp;
		}
		if (!copyOnlyIfNull || nav.selectOnDown == null)
		{
			nav.selectOnDown = otherNav.selectOnDown;
		}
		if (!copyOnlyIfNull || nav.selectOnLeft == null)
		{
			nav.selectOnLeft = otherNav.selectOnLeft;
		}
		if (!copyOnlyIfNull || nav.selectOnRight == null)
		{
			nav.selectOnRight = otherNav.selectOnRight;
		}
	}

	public static void RemoveUninteractableDestinations(this Navigation nav)
	{
		if (nav.selectOnUp != null)
		{
			nav.selectOnUp = (nav.selectOnUp.interactable ? nav.selectOnUp : null);
		}
		if (nav.selectOnDown != null)
		{
			nav.selectOnDown = (nav.selectOnDown.interactable ? nav.selectOnDown : null);
		}
		if (nav.selectOnLeft != null)
		{
			nav.selectOnLeft = (nav.selectOnLeft.interactable ? nav.selectOnLeft : null);
		}
		if (nav.selectOnRight != null)
		{
			nav.selectOnRight = (nav.selectOnRight.interactable ? nav.selectOnRight : null);
		}
	}

	public static void SetUp(this Navigation nav, IDynamicSelectableProvider selectableProvider)
	{
		if (selectableProvider != null)
		{
			Selectable selectable = selectableProvider.GetSelectable();
			if (selectable != null)
			{
				nav.selectOnUp = selectable;
			}
		}
	}

	public static void SetDown(this Navigation nav, IDynamicSelectableProvider selectableProvider)
	{
		if (selectableProvider != null)
		{
			Selectable selectable = selectableProvider.GetSelectable();
			if (selectable != null)
			{
				nav.selectOnDown = selectable;
			}
		}
	}

	public static void SetLeft(this Navigation nav, IDynamicSelectableProvider selectableProvider)
	{
		if (selectableProvider != null)
		{
			Selectable selectable = selectableProvider.GetSelectable();
			if (selectable != null)
			{
				nav.selectOnLeft = selectable;
			}
		}
	}

	public static void SetRight(this Navigation nav, IDynamicSelectableProvider selectableProvider)
	{
		if (selectableProvider != null)
		{
			Selectable selectable = selectableProvider.GetSelectable();
			if (selectable != null)
			{
				nav.selectOnRight = selectable;
			}
		}
	}
}
