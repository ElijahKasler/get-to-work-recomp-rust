using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Elevator : MonoBehaviour
{
	private bool inTrigger;

	private Rigidbody Player;

	private Transform PlayerCam;

	[Tooltip("Type your Player's tag here.")]
	public string PlayerTag = "Player";

	private Animation DoorsAnim;

	[Tooltip("Speed multiplier of the doors opening and closing. 1 is default speed.")]
	public float DoorsAnimSpeed = 1f;

	[Tooltip("How fast the elevator 'passes' one floor. The time in seconds.")]
	public float OneFloorTime = 1.5f;

	private float OpenDelay = 1f;

	[Tooltip("How long the doors are open. The time in seconds.")]
	public float CloseDelay = 4f;

	private bool isOpen;

	private string AnimName = "ElevatorDoorsAnim_open";

	private string InputFloor = "";

	private int TargetFloor;

	[Tooltip("The floor, where this elevator is placed. Set an unique value for each elevator.")]
	public int CurrentFloor;

	private int FloorCount;

	[HideInInspector]
	public int ElevatorFloor;

	private List<GameObject> Elevators = new List<GameObject>();

	private Elevator[] ElevatorsScripts;

	private Animation TargetElvAnim;

	private TextMesh TargetElvTextInside;

	private TextMesh TargetElvTextOutside;

	public TextMesh TextOutside;

	public TextMesh TextInside;

	[Tooltip("If set to true, the Reflection Probe inside the elevator will be updated every frame, when the player near or inside the elevator. Can impact performance.")]
	public bool UpdateReflectionEveryFrame;

	private bool isReflectionProbe = true;

	private MeshRenderer ElevatorOpenButton;

	private MeshRenderer ElevatorGoBtn;

	private List<MeshRenderer> ElevatorNumericButtons = new List<MeshRenderer>();

	private AudioSource SoundFX;

	private AudioSource TargetSoundFX;

	private bool SpeedUp;

	private bool SlowDown;

	private static bool Moving;

	private bool isPlayer;

	private float PlayerHeight;

	private bool isRigidbodyCharacter;

	private ReflectionProbe probe;

	[Header("Sound Effects settings")]
	public AudioClip Bell;

	[Range(0f, 1f)]
	public float BellVolume = 1f;

	public AudioClip DoorsOpen;

	[Range(0f, 1f)]
	public float DoorsOpenVolume = 1f;

	public AudioClip DoorsClose;

	[Range(0f, 1f)]
	public float DoorsCloseVolume = 1f;

	public AudioClip ElevatorMove;

	[Range(0f, 1f)]
	public float ElevatorMoveVolume = 1f;

	public AudioClip ElevatorBtn;

	[Range(0f, 1f)]
	public float ElevatorBtnVolume = 1f;

	public AudioClip ElevatorError;

	[Range(0f, 1f)]
	public float ElevatorErrorVolume = 1f;

	private AudioSource BtnSoundFX;

	private bool ElvFound;

	private ElevatorManager _elevatorManager;

	private GameObject ElevatorsParent;

	private void Awake()
	{
		if ((bool)GetComponentInChildren<ReflectionProbe>())
		{
			probe = GetComponentInChildren<ReflectionProbe>();
			probe.refreshMode = ReflectionProbeRefreshMode.OnAwake;
			isReflectionProbe = true;
		}
		else
		{
			isReflectionProbe = false;
		}
		isPlayer = false;
		Moving = false;
		BtnSoundFX = GetComponent<AudioSource>();
		if (base.transform.parent != null)
		{
			ElevatorsParent = base.transform.parent.gameObject;
			if ((bool)ElevatorsParent.GetComponent<ElevatorManager>())
			{
				_elevatorManager = ElevatorsParent.GetComponent<ElevatorManager>();
			}
		}
		SoundFX = new GameObject().AddComponent<AudioSource>();
		SoundFX.transform.parent = base.gameObject.transform;
		SoundFX.transform.position = new Vector3(base.gameObject.transform.position.x, base.gameObject.transform.position.y + 2.2f, base.gameObject.transform.position.z);
		SoundFX.gameObject.name = "SoundFX";
		SoundFX.playOnAwake = false;
		SoundFX.spatialBlend = 1f;
		SoundFX.minDistance = 0.1f;
		SoundFX.maxDistance = 10f;
		SoundFX.rolloffMode = AudioRolloffMode.Linear;
		SoundFX.priority = 256;
		DoorsAnim = base.gameObject.GetComponent<Animation>();
		AnimName = DoorsAnim.clip.name;
		if ((bool)GameObject.FindGameObjectWithTag(PlayerTag))
		{
			Player = GameObject.FindGameObjectWithTag(PlayerTag).GetComponent<Rigidbody>();
			if ((bool)Player.gameObject.GetComponent<CapsuleCollider>())
			{
				PlayerHeight = Player.gameObject.GetComponent<CapsuleCollider>().height / 2f;
				isRigidbodyCharacter = true;
				isPlayer = true;
			}
			else if ((bool)Player.gameObject.GetComponent<CharacterController>())
			{
				PlayerHeight = Player.gameObject.GetComponent<CharacterController>().height / 2f + Player.gameObject.GetComponent<CharacterController>().skinWidth;
				isRigidbodyCharacter = false;
				isPlayer = true;
			}
		}
		else
		{
			Debug.LogWarning("Elevator: Can't find Player. Please, check that your Player object has 'Player' tag.");
			base.enabled = false;
			isPlayer = false;
		}
		if (isPlayer)
		{
			if ((bool)Player.GetComponentInChildren<Camera>().transform)
			{
				PlayerCam = Player.GetComponentInChildren<Camera>().transform;
			}
			else
			{
				Debug.LogWarning("Elevator: Can't find Player's camera. Please, check that your Player have a camera parented to it.");
				base.enabled = false;
			}
		}
		GameObject[] array = GameObject.FindGameObjectsWithTag("Elevator");
		foreach (GameObject gameObject in array)
		{
			if (gameObject.transform.parent == base.gameObject.transform.parent && gameObject != base.gameObject)
			{
				Elevators.Add(gameObject);
			}
		}
		if ((bool)_elevatorManager)
		{
			ElevatorManager elevatorManager = _elevatorManager;
			elevatorManager.WasStarted = (UnityAction)Delegate.Combine(elevatorManager.WasStarted, new UnityAction(RandomInit));
		}
		else
		{
			Debug.LogWarning("Elevator: To use more than one elevator shaft, please create an empty gameobject in your scene, add the ElevatorManager.cs script on it and make elevators of one elevator shaft as child to this object. Repeate this for every different elevators shafts.");
		}
	}

	private void RandomInit()
	{
		if ((bool)_elevatorManager)
		{
			ElevatorFloor = _elevatorManager.InitialFloor;
		}
		else
		{
			ElevatorFloor = 1;
		}
		TextOutside.text = ElevatorFloor.ToString();
		TextInside.text = ElevatorFloor.ToString();
	}

	private void Update()
	{
		if (!inTrigger)
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			RaycastHit[] array = Physics.RaycastAll(PlayerCam.position, PlayerCam.forward, 3f);
			for (int i = 0; i < array.Length; i++)
			{
				RaycastHit raycastHit = array[i];
				if (raycastHit.transform.tag == "ElevatorButtonOpen" && !isOpen)
				{
					BtnSoundFX.clip = ElevatorBtn;
					BtnSoundFX.volume = ElevatorBtnVolume;
					BtnSoundFX.Play();
					ElevatorOpenButton = raycastHit.transform.GetComponent<MeshRenderer>();
					ElevatorOpenButton.enabled = true;
					isOpen = true;
					Invoke("DoorsOpening", OneFloorTime * (float)Mathf.Abs(CurrentFloor - ElevatorFloor) + OpenDelay);
					FloorCount = ElevatorFloor;
					ElevatorFloor = CurrentFloor;
					foreach (GameObject elevator2 in Elevators)
					{
						((Elevator)elevator2.GetComponent(typeof(Elevator))).ElevatorFloor = CurrentFloor;
					}
					StartCoroutine("FloorsCounter");
				}
				if (raycastHit.transform.tag == "ElevatorNumericButton" && !Moving)
				{
					InputFloor += raycastHit.transform.name;
					raycastHit.transform.GetComponent<MeshRenderer>().enabled = true;
					ElevatorNumericButtons.Add(raycastHit.transform.GetComponent<MeshRenderer>());
					BtnSoundFX.clip = ElevatorBtn;
					BtnSoundFX.volume = ElevatorBtnVolume;
					BtnSoundFX.Play();
				}
				if (!(raycastHit.transform.tag == "ElevatorGoButton") || Moving)
				{
					continue;
				}
				if (InputFloor != "" && InputFloor.Length < 4)
				{
					if (InputFloor == "0-1")
					{
						InputFloor = "-99";
					}
					TargetFloor = int.Parse(InputFloor);
					foreach (GameObject elevator3 in Elevators)
					{
						Elevator elevator = (Elevator)elevator3.GetComponent(typeof(Elevator));
						if (elevator.CurrentFloor != TargetFloor)
						{
							continue;
						}
						ElvFound = true;
						TargetElvAnim = elevator3.GetComponent<Animation>();
						TargetElvTextInside = elevator3.GetComponent<Elevator>().TextInside;
						TargetElvTextOutside = elevator3.GetComponent<Elevator>().TextOutside;
						BtnSoundFX.clip = ElevatorBtn;
						BtnSoundFX.volume = ElevatorBtnVolume;
						BtnSoundFX.Play();
						ElevatorFloor = TargetFloor;
						elevator.ElevatorFloor = TargetFloor;
						FloorCount = CurrentFloor;
						if (CurrentFloor != ElevatorFloor)
						{
							if (elevator.isReflectionProbe && elevator.UpdateReflectionEveryFrame)
							{
								elevator.probe.RenderProbe();
							}
							Invoke("ElevatorGO", 1f);
							ElevatorGoBtn = raycastHit.transform.GetComponent<MeshRenderer>();
							ElevatorGoBtn.enabled = true;
							Moving = true;
						}
						else
						{
							DoorsOpening();
						}
						InputFloor = "";
					}
				}
				else
				{
					ButtonsReset();
					InputFloor = "";
					BtnSoundFX.clip = ElevatorError;
					BtnSoundFX.volume = ElevatorErrorVolume;
					BtnSoundFX.Play();
				}
				if (!ElvFound)
				{
					ButtonsReset();
					InputFloor = "";
					BtnSoundFX.clip = ElevatorError;
					BtnSoundFX.volume = ElevatorErrorVolume;
					BtnSoundFX.Play();
				}
				if (TargetFloor != CurrentFloor)
				{
					DoorsClosing();
				}
				else if (!isOpen)
				{
					DoorsOpening();
				}
			}
		}
		if (SpeedUp)
		{
			if (SoundFX.volume < ElevatorMoveVolume)
			{
				SoundFX.volume += 0.9f * Time.deltaTime;
			}
			else
			{
				SpeedUp = false;
			}
			if (SoundFX.pitch < 1f)
			{
				SoundFX.pitch += 0.9f * Time.deltaTime;
			}
		}
		if (SlowDown)
		{
			if (SoundFX.volume > 0f)
			{
				SoundFX.volume -= 0.9f * Time.deltaTime;
			}
			else
			{
				SlowDown = false;
			}
			if (SoundFX.pitch > 0f)
			{
				SoundFX.pitch -= 0.9f * Time.deltaTime;
			}
		}
	}

	private void ElevatorGO()
	{
		ElvFound = false;
		StartCoroutine("FloorsCounterInside");
		SoundFX.clip = ElevatorMove;
		SoundFX.loop = true;
		SoundFX.volume = 0f;
		SoundFX.pitch = 0.5f;
		SpeedUp = true;
		SoundFX.Play();
	}

	private void SlowDownStart()
	{
		SlowDown = true;
	}

	private IEnumerator FloorsCounterInside()
	{
		while (true)
		{
			TextOutside.text = FloorCount.ToString();
			TextInside.text = FloorCount.ToString();
			if (TargetFloor - FloorCount == 1)
			{
				Invoke("SlowDownStart", OneFloorTime / 2f);
			}
			if (FloorCount - TargetFloor == 1)
			{
				Invoke("SlowDownStart", OneFloorTime / 2f);
			}
			if (TargetFloor == FloorCount)
			{
				break;
			}
			yield return new WaitForSeconds(OneFloorTime);
			if (CurrentFloor < TargetFloor)
			{
				FloorCount++;
			}
			if (CurrentFloor > TargetFloor)
			{
				FloorCount--;
			}
			if (FloorCount == TargetFloor)
			{
				SoundFX.Stop();
				TargetBellSoundPlay();
				if (!isRigidbodyCharacter)
				{
					Player.isKinematic = false;
				}
				Player.transform.position = new Vector3(Player.transform.position.x, TargetElvAnim.transform.position.y + PlayerHeight, Player.transform.position.z);
				if (isReflectionProbe && UpdateReflectionEveryFrame)
				{
					probe.refreshMode = ReflectionProbeRefreshMode.OnAwake;
					probe.RenderProbe();
				}
				if (!isRigidbodyCharacter)
				{
					Player.isKinematic = true;
				}
				Invoke("TargetElvOpening", OpenDelay);
			}
		}
	}

	private IEnumerator FloorsCounter()
	{
		while (true)
		{
			TextOutside.text = FloorCount.ToString();
			TextInside.text = FloorCount.ToString();
			if (CurrentFloor == FloorCount)
			{
				break;
			}
			yield return new WaitForSeconds(OneFloorTime);
			if (CurrentFloor < FloorCount)
			{
				FloorCount--;
			}
			if (CurrentFloor > FloorCount)
			{
				FloorCount++;
			}
		}
		BellSoundPlay();
	}

	private void DoorsClosingSoundPlay()
	{
		if (DoorsAnim[AnimName].speed < 0f)
		{
			SoundFX.clip = DoorsClose;
			SoundFX.loop = false;
			SoundFX.volume = DoorsCloseVolume;
			SoundFX.pitch = 1f;
			SoundFX.Play();
		}
	}

	private void DoorsOpeningSoundPlay()
	{
		if (DoorsAnim[AnimName].speed > 0f)
		{
			SoundFX.clip = DoorsOpen;
			SoundFX.volume = DoorsOpenVolume;
			SoundFX.pitch = 1f;
			SoundFX.Play();
		}
	}

	private void TargetBellSoundPlay()
	{
		foreach (GameObject elevator in Elevators)
		{
			if (elevator.GetComponent<Elevator>().CurrentFloor == TargetFloor)
			{
				TargetSoundFX = elevator.GetComponent<Elevator>().SoundFX;
				TargetSoundFX.clip = Bell;
				TargetSoundFX.loop = false;
				TargetSoundFX.volume = BellVolume;
				TargetSoundFX.pitch = 1f;
				SoundFX.pitch = 1f;
				TargetSoundFX.Play();
				TextsUpdate();
			}
		}
	}

	private void BellSoundPlay()
	{
		SoundFX.clip = Bell;
		SoundFX.loop = false;
		SoundFX.volume = BellVolume;
		SoundFX.pitch = 1f;
		SoundFX.Play();
	}

	private void TextsUpdate()
	{
		foreach (GameObject elevator in Elevators)
		{
			TargetElvTextInside = elevator.GetComponent<Elevator>().TextInside;
			TargetElvTextOutside = elevator.GetComponent<Elevator>().TextOutside;
			TargetElvTextInside.text = ElevatorFloor.ToString();
			TargetElvTextOutside.text = ElevatorFloor.ToString();
		}
	}

	private void ButtonsReset()
	{
		foreach (MeshRenderer elevatorNumericButton in ElevatorNumericButtons)
		{
			elevatorNumericButton.enabled = false;
		}
		if (ElevatorGoBtn != null)
		{
			ElevatorGoBtn.enabled = false;
		}
	}

	private void TargetElvOpening()
	{
		TextsUpdate();
		TargetElvAnim[AnimName].normalizedTime = 0f;
		TargetElvAnim[AnimName].speed = DoorsAnimSpeed;
		TargetElvAnim.Play();
		ButtonsReset();
	}

	private void DoorsOpening()
	{
		TargetFloor = 0;
		TextsUpdate();
		DoorsAnim[AnimName].normalizedTime = 0f;
		DoorsAnim[AnimName].speed = DoorsAnimSpeed;
		DoorsAnim.Play();
		ButtonsReset();
	}

	private void DoorsClosingTimer()
	{
		if (DoorsAnim[AnimName].speed > 0f)
		{
			Invoke("DoorsClosing", CloseDelay);
			isOpen = true;
			Moving = false;
		}
	}

	private void DoorsClosing()
	{
		if (isOpen)
		{
			DoorsAnim[AnimName].normalizedTime = 1f;
			DoorsAnim[AnimName].speed = 0f - DoorsAnimSpeed;
			DoorsAnim.Play();
			isOpen = false;
			if (ElevatorOpenButton != null)
			{
				ElevatorOpenButton.enabled = false;
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == Player.gameObject)
		{
			inTrigger = true;
			if (isReflectionProbe && UpdateReflectionEveryFrame)
			{
				probe.refreshMode = ReflectionProbeRefreshMode.EveryFrame;
				probe.RenderProbe();
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject == Player.gameObject)
		{
			inTrigger = false;
			if (isReflectionProbe && UpdateReflectionEveryFrame)
			{
				probe.refreshMode = ReflectionProbeRefreshMode.OnAwake;
				probe.RenderProbe();
			}
		}
	}
}
