using UnityEngine;

namespace Isto.GTW.Player;

[CreateAssetMenu(fileName = "PlayerPhysicsPreset", menuName = "Scriptables/GTW//Torque Physics Preset")]
public class TorquePlayerPhysicsPreset : ScriptableObject
{
	[Tooltip("Acceleration due to gravity.\nEarth's Gravity is 9.81 m/s^2")]
	public float gravity = 9.8f;

	[Tooltip("The max angle in any direction from default gravity (i.e. straight down).\nWhile mid-air, we give the player air control by rotating the direction of gravity.")]
	public float maxGravityAngle = 25f;

	[Tooltip("The maximum angular force applied to the player on ground (in Nm).\nIndirectly controls the players max speed on flat ground")]
	public float maxTorque = 60f;

	[Tooltip("Determines how fast the player speeds up.\nA bit of a magic number that feels good.")]
	public float acceleration = 200f;

	[Tooltip("The drag applied to the player's rigidbody.\nSlows down the player by this amount every frame.")]
	public float velocityDrag = 0.01f;

	[Tooltip("The drag applied to the player's rigidbody while grabbing.\nAffects how quickly the player will come to a stop while grabbing.")]
	public float grabAbilityDrag = 5f;

	[Tooltip("Drag added to the RigidBody based on the players speed.\nAs you approach max speed, drag increases so you don't suddenly hit max speed (which is jarring for the player).\n\nx is player speed (m/s)\ny is Drag\n")]
	public AnimationCurve dragSpeedCurve = AnimationCurve.Linear(0f, 0f, 200f, 0f);

	[Tooltip("Angular Drag added based on the players speed.\nAs you come to a stop, adding drag helps bring the player to a full stop (without this, the player wiggles in place)\n\nx is player speed (m/s)\ny is Angular Drag\n")]
	public AnimationCurve angularDragSpeedCurve = AnimationCurve.Linear(0f, 0.1f, 1f, 0.1f);

	[Tooltip("The size of the player physics ball (in m).\n\nAffects the collision, how the torque is applied.")]
	public float ballRadius = 0.25f;

	public AnimationCurve inputCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

	public AnimationCurve accelerationCurve = AnimationCurve.Linear(0f, 1f, 1f, 1f);

	public AnimationCurve airAccelerationCurve = AnimationCurve.Linear(0f, 1f, 1f, 1f);

	[Tooltip("Ball friction based on the ground angle.\n\nx is ground angle\ny is the ball friction (0 to 1)\n")]
	public AnimationCurve slopeFrictionCurve = AnimationCurve.Linear(20f, 1f, 45f, 0.5f);

	[Tooltip("How much the gravity rotation influences the player's controls (based on ground angle).\n\nx is ground angle\ny is how much gravity rotation influences the players control. (0 is no influence, 1 is full)")]
	public AnimationCurve slopeAirControlCurve = AnimationCurve.Linear(20f, 0f, 45f, 1f);

	[Tooltip("The bounciness on the \"Physics Material\". See Unity's Physics Material for more info on Bounciness.")]
	public float groundedBounciness = 0.3f;

	[Tooltip("The bounciness on the \"Physics Material\". See Unity's Physics Material for more info on Bounciness.")]
	public float airBounciness = 0.5f;
}
