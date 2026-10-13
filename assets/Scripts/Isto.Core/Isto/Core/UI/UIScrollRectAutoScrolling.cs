using Isto.Core.Inputs;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Isto.Core.UI;

public class UIScrollRectAutoScrolling : MonoBehaviour
{
	[SerializeField]
	private RectTransform _contentPanel;

	[SerializeField]
	private RectTransform _scrollRectTransform;

	[SerializeField]
	private int _scrollPadding;

	private IControls _controls;

	private GameObject _lastSelected;

	[Inject]
	public void Inject(IControls controls)
	{
		_controls = controls;
	}

	private void Update()
	{
		if (!_controls.UsingJoystick())
		{
			return;
		}
		GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
		if (!(currentSelectedGameObject == null) && currentSelectedGameObject.transform.IsChildOf(_contentPanel.transform) && !(currentSelectedGameObject == _lastSelected))
		{
			RectTransform component = currentSelectedGameObject.GetComponent<RectTransform>();
			float num = Mathf.Abs(component.anchoredPosition.y) + component.rect.height;
			float y = _contentPanel.anchoredPosition.y;
			float num2 = _contentPanel.anchoredPosition.y + _scrollRectTransform.rect.height;
			if (num > num2 - (float)_scrollPadding)
			{
				float y2 = num - _scrollRectTransform.rect.height + (float)_scrollPadding;
				_contentPanel.anchoredPosition = new Vector2(_contentPanel.anchoredPosition.x, y2);
			}
			else if (Mathf.Abs(component.anchoredPosition.y) < y + (float)_scrollPadding)
			{
				_contentPanel.anchoredPosition = new Vector2(_contentPanel.anchoredPosition.x, Mathf.Abs(component.anchoredPosition.y) - (float)_scrollPadding);
			}
			_lastSelected = currentSelectedGameObject;
		}
	}
}
