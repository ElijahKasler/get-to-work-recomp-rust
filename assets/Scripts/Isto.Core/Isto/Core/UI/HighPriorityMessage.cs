using UnityEngine;

namespace Isto.Core.UI;

[CreateAssetMenu(fileName = "HiPriMessage", menuName = "Scriptables/UI/HighPriorityMessage")]
public class HighPriorityMessage : ScriptableObject
{
	public enum MessageType
	{
		warning = 0,
		success = 1,
		error = 2
	}

	public MessageType type;

	public Sprite icon;

	public Color color;
}
