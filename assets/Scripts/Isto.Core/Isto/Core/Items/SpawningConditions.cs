using UnityEngine;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "New Spawning Conditions", menuName = "Scriptables/Item/SpawningConditions")]
public class SpawningConditions : ScriptableObject
{
	public string internalName;

	[TextArea]
	public string description;

	public LayerMask invalidLayers = 0;

	[Tooltip("This is the radius of collision detection around the spawn attempt")]
	public float spawnPositionClearance = 0.5f;
}
