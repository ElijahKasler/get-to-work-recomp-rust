using I2.Loc;
using Isto.Core.Localization;
using Isto.Core.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Isto.Core.Items;

public class BuildingDialogue : MonoBehaviour
{
	private bool _messageActive;

	[SerializeField]
	private Animator _dialogueAnimator;

	[SerializeField]
	private TextMeshProUGUI _buildingNameTextbox;

	[SerializeField]
	private TextMeshProUGUI _buildingStatusTextbox;

	[SerializeField]
	private GameObject _buildingMessageText;

	[SerializeField]
	private TextMeshProUGUI _messageText1;

	[SerializeField]
	private GameObject _buildingMessageTextAndSymbol;

	[SerializeField]
	private TextMeshProUGUI _messageText2;

	[SerializeField]
	private Image _messageSymbol1;

	[SerializeField]
	private GameObject _buildingMessageSymbol;

	[SerializeField]
	private Image _messageSymbol2;

	[SerializeField]
	private CanvasGroup _controlDisplayGroup;

	[SerializeField]
	private LocalizedString _offlineText;

	private void Awake()
	{
		UIUtils.SetCameraForCanvas(base.gameObject);
	}

	public void ShowToolTipDialogue(bool buildingOnline)
	{
		_dialogueAnimator.SetBool("ShowToolTip", value: true);
		if (buildingOnline)
		{
			_controlDisplayGroup.alpha = 1f;
			_buildingStatusTextbox.text = "";
		}
		else
		{
			_controlDisplayGroup.alpha = 0f;
			Loc.SetTMPro(_buildingStatusTextbox, _offlineText);
		}
		_buildingStatusTextbox.color = Color.white;
		_buildingNameTextbox.color = Color.white;
	}

	public void HideToolTipDialogue()
	{
		_dialogueAnimator.SetBool("ShowToolTip", value: false);
	}

	public void ShowDialogueText(string localizedMessage)
	{
		Loc.SetTMProLocalized(_messageText1, localizedMessage);
		_dialogueAnimator.SetBool("ShowMessage", value: true);
	}

	public void ShowAlertMessage(string localizedText = "", Sprite image = null)
	{
		_buildingMessageTextAndSymbol.SetActive(value: false);
		_buildingMessageText.SetActive(value: false);
		_buildingMessageSymbol.SetActive(value: false);
		if (localizedText == "")
		{
			_buildingMessageTextAndSymbol.SetActive(value: true);
			UpdateSymbol(image);
		}
		else if (image == null)
		{
			_buildingMessageText.SetActive(value: true);
			UpdateAlertMessageText(localizedText);
		}
		else
		{
			_buildingMessageTextAndSymbol.SetActive(value: true);
			UpdateSymbol(image);
			UpdateAlertMessageText(localizedText);
		}
		_dialogueAnimator.SetBool("ShowMessage", value: true);
		_messageActive = true;
	}

	public void UnHideAlertMessage()
	{
		_dialogueAnimator.SetBool("ShowMessage", value: true);
		_messageActive = true;
	}

	public void HideAlertMessage()
	{
		_dialogueAnimator.SetBool("ShowMessage", value: false);
		_messageActive = false;
	}

	public void UpdateSymbol(Sprite image)
	{
		_messageSymbol1.sprite = image;
		_messageSymbol2.sprite = image;
	}

	public void UpdateAlertMessageText(string localizedMessage)
	{
		Loc.SetTMProLocalized(_messageText1, localizedMessage);
		Loc.SetTMProLocalized(_messageText2, localizedMessage);
	}

	public bool IsMessageActive()
	{
		return _messageActive;
	}
}
