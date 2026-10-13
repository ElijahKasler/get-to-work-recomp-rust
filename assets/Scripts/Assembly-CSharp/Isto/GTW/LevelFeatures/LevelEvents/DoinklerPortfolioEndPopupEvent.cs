using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Isto.GTW.LevelFeatures.LevelEvents;

public class DoinklerPortfolioEndPopupEvent : LevelTransitionPopupEvent
{
	private Coroutine _levelCompletedCoroutine;

	[SerializeField]
	private Animator _endSceneAnimator;

	protected override void ModalPopup_OnPlayerRespawn()
	{
		base.ModalPopup_OnPlayerRespawn();
		_levelEventTrigger.wasTriggered = false;
		_endSceneAnimator.gameObject.SetActive(value: false);
		DialogueManager.StopConversation();
		_sounds.StopAllEventInstances();
	}
}
