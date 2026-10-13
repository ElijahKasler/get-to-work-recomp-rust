using UnityEngine;

namespace Isto.Core.UI;

public abstract class CoreButtonTransitionBase : MonoBehaviour, ICoreButtonTransition
{
	private CoreButton _coreButton;

	public CoreButton CoreButton
	{
		get
		{
			if (_coreButton == null && this != null)
			{
				_coreButton = GetComponent<CoreButton>();
			}
			return _coreButton;
		}
	}

	protected virtual void Reset()
	{
		CoreButton.AddCoreButtonTransition(this);
	}

	protected virtual void OnDestroy()
	{
		CoreButton coreButton = CoreButton;
		if (coreButton != null)
		{
			coreButton.RemoveCoreButtonTransition(this);
		}
	}

	public abstract void DoTransition(CoreButton.CoreButtonSelectionState state, bool instant = true);
}
