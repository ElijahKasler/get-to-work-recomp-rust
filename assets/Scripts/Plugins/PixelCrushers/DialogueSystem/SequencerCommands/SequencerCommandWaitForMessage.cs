using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands;

[AddComponentMenu("")]
public class SequencerCommandWaitForMessage : SequencerCommand
{
	private string requiredMessage;

	public void Start()
	{
		requiredMessage = GetParameter(0);
		if (DialogueDebug.logInfo)
		{
			Debug.Log(string.Format("{0}: Sequencer: WaitForMessage({1})", new object[2] { "Dialogue System", requiredMessage }));
		}
	}

	public void OnSequencerMessage(string message)
	{
		if (string.Equals(message, requiredMessage))
		{
			if (DialogueDebug.logInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: WaitForMessage({1}) received message", new object[2] { "Dialogue System", requiredMessage }));
			}
			Stop();
		}
	}
}
