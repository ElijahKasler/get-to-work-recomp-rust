using Isto.GTW.LevelEvents.LevelEvents;
using UnityEngine;

namespace Isto.GTW.LevelFeatures.LevelEvents;

[RequireComponent(typeof(DialogueEvent))]
public class DialogueEventTriggerSerializer : LevelEventTriggerSerializer
{
	private DialogueEvent _dialogueEvent;

	public DialogueEvent DialogueEvent
	{
		get
		{
			if (_dialogueEvent == null)
			{
				_dialogueEvent = GetComponent<DialogueEvent>();
			}
			return _dialogueEvent;
		}
	}

	protected override void Reset()
	{
		SetSerializerId();
	}

	private void OnDrawGizmosSelected()
	{
		if (!Application.isPlaying)
		{
			SetSerializerId();
		}
	}

	private void SetSerializerId()
	{
		if (!string.IsNullOrEmpty(DialogueEvent.UniqueID) && _id != DialogueEvent.UniqueID)
		{
			_id = DialogueEvent.UniqueID;
			SetDirty();
		}
	}
}
