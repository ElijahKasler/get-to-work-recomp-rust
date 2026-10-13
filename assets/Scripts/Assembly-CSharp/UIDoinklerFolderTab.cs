using Isto.Core.UI;
using Isto.GTW.UI;
using UnityEngine;
using UnityEngine.UI;

public class UIDoinklerFolderTab : MonoBehaviour
{
	[SerializeField]
	protected GameObject shadowImage;

	[SerializeField]
	private Image folderTabImage;

	[SerializeField]
	private Color _activeColor = Color.white;

	[SerializeField]
	private Color _inactiveColor = new Color(0.92f, 0.92f, 0.92f);

	private int _folderTabNumber;

	private bool _isActive;

	private CoreButtonRectPosition _corebuttonRect;

	private UIDoinklerPortfolio _parentMenu;

	public void Setup(UIDoinklerPortfolio parentMenu, int folderTabNum)
	{
		_parentMenu = parentMenu;
		_folderTabNumber = folderTabNum;
		_corebuttonRect = GetComponent<CoreButtonRectPosition>();
	}

	public void NewTabActive(int activeTabNumber)
	{
		Vector3 position = base.transform.position;
		if (activeTabNumber == _folderTabNumber)
		{
			if (!_isActive)
			{
				_isActive = true;
				base.transform.position = position;
			}
			folderTabImage.color = _activeColor;
			shadowImage.SetActive(value: false);
			_corebuttonRect.enabled = false;
		}
		else
		{
			folderTabImage.color = _inactiveColor;
			if (_isActive)
			{
				_isActive = false;
				base.transform.position = position;
			}
			shadowImage.SetActive(value: true);
			_corebuttonRect.enabled = true;
		}
	}

	public void FolderTab_OnClick()
	{
		_parentMenu.FolderTab_OnClick(_folderTabNumber);
	}
}
