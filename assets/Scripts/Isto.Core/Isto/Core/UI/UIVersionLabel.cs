using Isto.Core.Configuration;
using Isto.Core.Game;
using TMPro;
using UnityEngine;
using Zenject;

namespace Isto.Core.UI;

public class UIVersionLabel : MonoBehaviour
{
	[SerializeField]
	private TMP_Text label;

	[SerializeField]
	private string title;

	[SerializeField]
	private bool detailed;

	[SerializeField]
	private bool multiline;

	[SerializeField]
	private VersionInfo _infoOverride;

	private GameState _gameState;

	[Inject]
	public void Inject(GameState gameState)
	{
		_gameState = gameState;
	}

	private void Awake()
	{
		VersionInfo.VersionData versionData = ((_infoOverride != null) ? _infoOverride.ActiveVersion : _gameState.version.ActiveVersion);
		if (detailed)
		{
			if (multiline)
			{
				label.text = title + "\n" + versionData.longDate + "\n(v" + versionData.FullVersionText + ")";
			}
			else
			{
				label.text = title + " " + versionData.FullVersionText;
			}
		}
		else
		{
			label.text = versionData.shortDate;
		}
	}
}
