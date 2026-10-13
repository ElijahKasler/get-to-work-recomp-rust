using System.Collections;
using Isto.Core.Inputs;
using UnityEngine;
using UnityEngine.UI;

namespace Isto.Core.UI;

public class CoreUIMenu : MonoBehaviour
{
	[Tooltip("Optional assignation that will attempt to tell the controller where the selection should land when this menu is shown")]
	[SerializeField]
	private Selectable _defaultSelection;

	private Animator _anim;

	public void Awake()
	{
		_anim = GetComponent<Animator>();
	}

	public void OnPointerEnter()
	{
		BroadcastMessage("MenuActive", true, SendMessageOptions.DontRequireReceiver);
	}

	public void OnPointerExit()
	{
		BroadcastMessage("MenuActive", false, SendMessageOptions.DontRequireReceiver);
	}

	public void Setup(bool online)
	{
		BroadcastMessage("MenuOnline", online, SendMessageOptions.DontRequireReceiver);
	}

	public bool TryToHideMenu(bool hide)
	{
		CanvasGroup component = GetComponent<CanvasGroup>();
		if (component == null)
		{
			return false;
		}
		if (hide)
		{
			StartCoroutine(UIUtils.SetCanvasAlpha(component, 0f, 0f, interactable: false));
		}
		else
		{
			StartCoroutine(UIUtils.SetCanvasAlpha(component, 1f, 0f, interactable: true, _defaultSelection));
		}
		return true;
	}

	public IEnumerator FadeIn()
	{
		if (base.gameObject.activeInHierarchy)
		{
			_anim = GetComponent<Animator>();
			_anim.SetTrigger("fadeIn");
			yield return 0;
			if (_defaultSelection != null && Controls.UsingController)
			{
				_defaultSelection.Select();
			}
		}
	}

	public void FadeOut()
	{
		_anim.SetTrigger("fadeOut");
	}
}
