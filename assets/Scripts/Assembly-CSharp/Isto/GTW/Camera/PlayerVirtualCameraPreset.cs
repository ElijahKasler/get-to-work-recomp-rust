using UnityEngine;
using UnityEngine.Serialization;

namespace Isto.GTW.Camera;

[CreateAssetMenu(fileName = "PlayerCameraPreset", menuName = "Scriptables/GTW/Camera Preset")]
public class PlayerVirtualCameraPreset : ScriptableObject
{
	[Header("Player Input")]
	[FormerlySerializedAs("inputRotateSpeed")]
	[Tooltip("A multiplier on the input that increases how fast the camera rotates around the player.")]
	public float inputRotateSpeedMultiplier = 200f;

	[Tooltip("A multiplier on the Unity Mouse Input (ex. Input.GetAxis(\"Mouse X\") that sets a base level sensitivity.")]
	public float mouseSensitivity = 0.01f;

	[FormerlySerializedAs("autoRotate")]
	[Header("Auto Rotate")]
	[Tooltip("When the player manually moves the camera, the autorotate will bring the camera back to its default position.")]
	public bool autoRotateEnabled = true;

	[FormerlySerializedAs("autoRotateDuringGrab")]
	public bool autoRotateEnabledDuringGrab;

	[Header("Auto Rotate - Camera Speeds")]
	[FormerlySerializedAs("horizontalAutoRotateSpeedSetting")]
	[Tooltip("Increases or decreases how fast the autorotate moves in the horizontal direction.\n\n0 means the camera won't move, 1 means the camera moves is fastest.")]
	[Range(0f, 1f)]
	public float horizontalAutoRotateSpeedMultiplier = 1f;

	[FormerlySerializedAs("verticalAutoRotateSpeedSetting")]
	[Tooltip("Increases or decreases how fast the autorotate moves in the vertical direction.\n\n0 means the camera won't move, 1 means the camera moves is fastest.")]
	[Range(0f, 1f)]
	public float verticalAutoRotateSpeedMultiplier = 0.5f;

	[FormerlySerializedAs("reactionSpeed")]
	[Tooltip("The base value that determines how fast the camera rotates back to the default position when the player is rolling on the ground.")]
	public float baseAutoRotateGroundSpeed = 1000f;

	[FormerlySerializedAs("reactionSpeedAir")]
	[Tooltip("The base value that determines how fast the camera rotates back to the default position when the player is mid-air.")]
	public float baseAutoRotateAirSpeed = 300f;

	[FormerlySerializedAs("reactionSpeedCurve")]
	[Tooltip("A multiplier on BaseAutoRotateSpeed (both ground and air) based on how fast the player is going.\n\nx value is km/hr, y is a multiplier on the base speed. 0 is no autorotate, 1 would result in the default BaseAutoRotateSpeed.")]
	public AnimationCurve autoRotatePlayerSpeedCurve = AnimationCurve.Linear(0f, 1f, 1f, 1f);

	[FormerlySerializedAs("dampingSpeedCurve")]
	[Tooltip("Forces the cameras position to lag behind its target position, which creates a smoothing effect on cameras autorotate, especially when player makes a sharp change in direction.\n\nx is in km/hr, y is the multiplier (y=0 means no damping, y=1 is full damping)\ny=1 means it multiplies the damping value on the virtual camera prefab on the player")]
	public AnimationCurve autoRotateDampingPlayerSpeedCurve = AnimationCurve.Linear(0f, 1f, 1f, 1f);

	[Tooltip("Changes how much the vertical speed of the player influences where the camera looks at vertically.\n\nX is players vertical speed in km/hr. y is multiplier between 0 and 1.\nY = 0 means autorotate behaves the same way as if you're rolling on flat ground.\nY = 1 means players vertical velocity fully affects the vertical autorotation.\n\nFor example, when y =1, if the player hits a quarter pipe the camera will look more up, and when falling, the camera will look more down.")]
	public AnimationCurve verticalSpeedWeightCurve = AnimationCurve.Linear(0f, 1f, 1f, 1f);

	[FormerlySerializedAs("verticalEndDampingDegrees")]
	[Tooltip("Adds damping when the camera is within <X> degrees of its default vertical rotation.\nCreates and \"ease out\" effect that smooths the camera back to a rest position.\nLarger degrees has a smoother effect, but takes longer to return (and the camera will feel slow).\nSmaller degrees will make the camera \"snap\" to its default vertical rotation.\n")]
	public float dampingVerticalReturnThreshold = 10f;

	[Header("Auto Rotate - Timings")]
	[FormerlySerializedAs("dampingMultiplierSmoothTime")]
	[Tooltip("The time (in seconds) to turn the damping back on (on the virtual camera).\nNumbers are based on feel. if its too slow or too fast, it will cause gameplay issues.\nIf its 0, the camera will feel less smooth when returning to its normal behaviour.")]
	public float timeToTurnDampingBackOn = 1f;

	[Tooltip("The time it takes to initiate the autorotate after the user has manually rotated the camera around the player.\nNote that if the player is completely stationary, or grabbing, the autorotate will not initiate.\nNote that if the player is grabbing, the autorotate will not initiate.")]
	public float mouseAutoRotateResetDelay = 1f;

	[Tooltip("The time it takes to initiate the autorotate after the user has manually rotated the camera around the player.\nNote that if the player is completely stationary, or grabbing, the autorotate will not initiate.\nNote that if the player is grabbing, the autorotate will not initiate.")]
	public float controllerAutoRotateResetDelay = 0.05f;

	[FormerlySerializedAs("autoRotateResetDuration")]
	[Tooltip("The time it takes to transition back to the autoRotate's target speed.")]
	public float autoRotateEnableTransitionTime = 0.5f;

	[Header("Camera settings")]
	[Tooltip("How far down the camera can rotate (in degrees).\nPrevents the camera from flipping upside down (ex. when the player manually rotates, or when riding down steep ramps).")]
	public float minVerticalAngleLimit = -70f;

	[Tooltip("How far up the camera can rotate (in degrees).\nPrevents the camera from flipping upside down (ex. when the player manually rotates, or when riding down steep ramps).")]
	public float maxVerticalAngleLimit = 70f;

	[Tooltip("Field of View: How wide the camera is (set on the CineMachine virtual camera)")]
	public float fov = 60f;

	[Tooltip("The camera's distance from the player (in meters).")]
	public float distance = 0.5f;

	[Tooltip("How high above the player the camera looks (in meters).")]
	public float aimTargetHeight = 0.5f;

	[Tooltip("How high above the player the camera sits (in meters).")]
	public float followCamHeight = 0.5f;

	[Tooltip("Tilt based on acceleration - we've removed this as its caused nausea.")]
	public float horizontaltiltAngle;

	[Tooltip("Tilt based on acceleration - we've removed this as its caused nausea.")]
	public float verticaltiltAngle;

	[Tooltip("Speed of the tilt - we've removed this as its caused nausea.")]
	public float tiltResponsiveness = 1f;

	[Header("Rag doll")]
	[Tooltip("When hanging on to an edge, adds a horizontal offset to the camera when the user is swinging the player (in meters).")]
	public float edgeGrabCameraOffset = 0.1f;

	[Tooltip("Time it takes for the camera to reach the full offset (in seconds).")]
	public float timeToReachEdgeGrabOffset = 0.1f;
}
