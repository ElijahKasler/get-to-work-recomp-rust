using Isto.Core.Audio;
using Isto.Core.StateMachine;
using Isto.Core.UI;
using Isto.GTW.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Isto.GTW;

public class TitleMenu : UISimpleTitleMenuState
{
	[Header("Doinkler Special")]
	public UIDoinklerSpecial doinklerSpecialSubState;

	[Header("Extra URLs")]
	public string howWeMadeUrl;

	public string speedrunUrl;

	[Header("GTW Menu Buttons")]
	[SerializeField]
	private Selectable _doinklerPortfolioButton;

	[SerializeField]
	private Selectable _doinklerSpecialButton;

	[SerializeField]
	private Selectable _howWeMadeTheGameButton;

	[SerializeField]
	private LoadButton _loadButtonController;

	private IGameMusic _music;

	[Inject]
	private void Inject(IGameMusic music)
	{
		_music = music;
	}

	private void OnDisable()
	{
		_music.StopMusic();
	}

	public override void Enter(MonoStateMachine controller)
	{
		base.Enter(controller);
		_music.PlayMusic(MusicTrack.Title);
	}

	public void DoinklerPortfolioButton_OnButtonClicked()
	{
		_previousSelection = _doinklerPortfolioButton;
		CloseAllStatesAndEnterNewState(gameModeSubstate);
	}

	public void DoinklerSpecialButton_OnButtonClicked()
	{
		_previousSelection = _doinklerSpecialButton;
		CloseAllStatesAndEnterNewState(doinklerSpecialSubState);
	}

	public void WatchHowWeMadeButton_OnButtonClicked()
	{
		_previousSelection = _howWeMadeTheGameButton;
		Application.OpenURL(howWeMadeUrl);
	}

	public void SpeedrunCompetitionButton_OnButtonClicked()
	{
		Application.OpenURL(speedrunUrl);
	}

	protected override void SetupLoadButton()
	{
		SetLoadButton(interactable: false);
		int slotNumber = 0;
		_gameData.HasSaveData(slotNumber, (bool dataExists) =>
		{
			SetLoadButton(dataExists);
		});
	}

	protected override void SetLoadButton(bool interactable)
	{
		_loadButtonController.MakeInteractable(interactable);
	}
}
