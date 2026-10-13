using Isto.GTW.Player;
using UnityEngine;

namespace Isto.GTW.LevelFeatures.Wearables;

[CreateAssetMenu(fileName = "New Character Wearable Data", menuName = "Scriptables/Wearables/Character Wearable Data")]
public class CharacterWearableData : ScriptableObject
{
	public PlayerWearableController.BodyPart BodyPart;

	public GameObject WearableModel;

	public Vector3 PositionOffset;

	public Vector3 RotationOffset;

	public Vector3 ScaleOffset = Vector3.one;
}
