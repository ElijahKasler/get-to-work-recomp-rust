using System;
using System.Collections.Generic;
using Isto.Core.Audio;
using Isto.Core.Automation;
using Isto.Core.Beings;
using Isto.Core.Cameras;
using Isto.Core.Data;
using Isto.Core.Inputs;
using Isto.Core.Localization;
using Isto.Core.UI;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Isto.Core.Items;

[SelectionBase]
public class HarvestableController : PooledInteractableItem, IItemTopmostParent, IAutomationGridSpaceDisplay, IDataLoadCompleteHandler
{
	public HarvestableItem item;

	[Tooltip("Should the item be destroyed once harvested, or have animation set to harvested_idle?")]
	public bool destroyOnHarvest = true;

	[Tooltip("What is the radius of the circle from the pivot of the object where items are dropped?")]
	public float dropRange;

	[Tooltip("Offset added to drop position for items.  Use if items are dropping behind object or should go to specific position")]
	public Vector3 dropOffset;

	[Tooltip("Icon to update as the HP changes thresholds, if set")]
	public SpriteRenderer icon;

	[Header("")]
	[Tooltip("If false, only automatic harvesters can harvest this resource")]
	public bool playerHarvestable = true;

	[Tooltip("If not harvestable by player, this item is used to harvest it")]
	public AdvancedItem harvestedBy;

	[Tooltip("some items leave new objects once harvested - e.g. sapling")]
	[SerializeField]
	private GameObject _afterHarvestedPrefab;

	[SerializeField]
	private Transform _customSelectionHighlight;

	[SerializeField]
	private Animator _animator;

	[Header("Visual Culling")]
	public bool cullWhenOffScreen = true;

	[Tooltip("When the item is spawned by the display system if true will be placed locked to the grid, otherwise some with slight randomness in placement")]
	public bool lockToGrid = true;

	private IGameSounds _sounds;

	private IUIHarvestProgressDisplay _uiProgress;

	private ItemContainer _harvesterContainer;

	private CameraController _camController;

	private PlayerUpgrades _playerUpgrades;

	private AutomationSystem _autoSystem;

	private PlayerProgress _playerProgress;

	protected AutomationResource _autoResource;

	private Queue<AutomationCoreItem> _outputItemsQueue = new Queue<AutomationCoreItem>();

	private HashSet<int> _validAnimatorParameters = new HashSet<int>();

	private Health _externalHealth;

	private bool _isQuitting;

	public float HarvestHealth
	{
		get
		{
			if (_autoResource != null)
			{
				return _autoResource.Health;
			}
			return 1f;
		}
	}

	public float HarvestPercent
	{
		get
		{
			if (_autoResource != null)
			{
				return _autoResource.HarvestPercent;
			}
			return 0f;
		}
	}

	public bool IsGrowing
	{
		get
		{
			if (_autoResource != null)
			{
				return !_autoResource.IsFullyGrown;
			}
			return false;
		}
	}

	[Inject]
	public void Inject(IGameSounds sounds, IUIHarvestProgressDisplay harvestProgressDisplay, CameraController cameraController, PlayerUpgrades playerUpgrades, AutomationSystem automationSystem, PlayerProgress playerProgress)
	{
		_sounds = sounds;
		_uiProgress = harvestProgressDisplay;
		_camController = cameraController;
		_playerUpgrades = playerUpgrades;
		_autoSystem = automationSystem;
		_playerProgress = playerProgress;
	}

	protected override void Awake()
	{
		if (TryGetComponent<Health>(out var component))
		{
			_externalHealth = component;
		}
		base.Awake();
	}

	protected override void Start()
	{
		base.Start();
		if (item == null)
		{
			Debug.LogErrorFormat("No item set for Harvestable Controller.  Harvestable items need a scriptable object set for the item to control health and other parameters.  Item: {0}", base.gameObject.name);
		}
		if (_animator != null)
		{
			AnimatorControllerParameter[] parameters = _animator.parameters;
			for (int i = 0; i < parameters.Length; i++)
			{
				_validAnimatorParameters.Add(parameters[i].nameHash);
			}
		}
		if (_externalHealth != null)
		{
			_externalHealth.TookDamage += OnExternalHealthTookDamage;
		}
	}

	protected override void OnDestroy()
	{
		if (!_isQuitting)
		{
			base.OnDestroy();
			if (_autoResource != null)
			{
				_autoResource.Consumed -= OnConsumed;
				_autoResource.PullStart -= OnPullStart;
				_autoResource.PullEnd -= OnPullEnd;
			}
			if (_externalHealth != null)
			{
				_externalHealth.TookDamage -= OnExternalHealthTookDamage;
			}
		}
	}

	protected void OnApplicationQuit()
	{
		_isQuitting = true;
	}

	public override void OnDeallocate()
	{
		if (_autoResource != null)
		{
			_autoResource.Consumed -= OnConsumed;
			_autoResource.PullStart -= OnPullStart;
			_autoResource.PullEnd -= OnPullEnd;
		}
		if (_externalHealth != null)
		{
			_externalHealth.TookDamage -= OnExternalHealthTookDamage;
		}
		base.OnDeallocate();
	}

	public void OnDataLoadComplete()
	{
		SetupInAutomationSystem(spawnFullyGrown: true);
		if (cullWhenOffScreen && base.gameObject.activeInHierarchy)
		{
			_state = AllocationStates.None;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	public virtual void SetupInAutomationSystem(bool spawnFullyGrown)
	{
		if (base.gameObject.activeInHierarchy && _autoResource == null)
		{
			float growthPercent = (spawnFullyGrown ? 1f : 0f);
			if (_autoSystem.TryAddResource(base.transform.position, item, triggerEvent: false, cullWhenOffScreen, growthPercent))
			{
				AutomationGridSpace orCreateGridSpace = _autoSystem.GetOrCreateGridSpace(base.transform.position);
				_autoResource = orCreateGridSpace.Resource;
				_autoResource.Consumed += OnConsumed;
				_autoResource.PullStart += OnPullStart;
				_autoResource.PullEnd += OnPullEnd;
			}
			else
			{
				Debug.LogWarning("Harvestable " + item?.itemID + " from " + base.gameObject.name + " could not be set in automation" + $" system at pos {base.transform.position}.", base.gameObject);
			}
		}
	}

	private void OnConsumed(object sender, AutomationResourceEventArgs e)
	{
		if (e.eventType == AutomationResourceEventArgs.EventType.FullyHarvested)
		{
			HarvestComplete();
			return;
		}
		StopAudio();
		SetInactive();
		DestroyGameObject(0.05f);
	}

	private void OnPullStart(object sender, AutomationPullEventArgs e)
	{
		_animator.enabled = true;
		Vector3 directionOfPull = e.directionOfPull;
		_animator.SetBool("harvesting", value: true);
		if (directionOfPull.z == 1f)
		{
			_animator.SetTrigger("harvesting_r");
		}
		else if (directionOfPull.x == -1f)
		{
			_animator.SetTrigger("harvesting_l");
		}
		else if (directionOfPull.z == -1f)
		{
			_animator.SetTrigger("harvesting_l");
		}
		else if (directionOfPull.x == 1f)
		{
			_animator.SetTrigger("harvesting_r");
		}
	}

	private void OnPullEnd(object sender, EventArgs e)
	{
		_animator.SetBool("harvesting", value: false);
	}

	private void OnExternalHealthTookDamage(object sender, HealthEventArgs e)
	{
		TakeHarvestDamageFromPlayer(e.damage, AnimationController.CharacterDirections.back);
	}

	public virtual void SetGridSpace(AutomationGridSpace space)
	{
		bool flag = space.itemProcessor != null;
		if (!lockToGrid && !flag)
		{
			base.transform.position = base.transform.position + UnityUtils.RandomXZVector(0.8f);
		}
		_autoResource = space.Resource;
		_autoResource.Consumed += OnConsumed;
		_autoResource.PullStart += OnPullStart;
		_autoResource.PullEnd += OnPullEnd;
	}

	public override void PlayerInteraction(AutomationPlayerController player, UserActions action)
	{
		player.SetHarvestItem(base.gameObject);
	}

	public void TakeHarvestDamageFromPlayer(float damage, AnimationController.CharacterDirections playerFacingDir)
	{
		TakeHarvestDamage(damage, playerFacingDir, Health.DamageSourceEnum.PLAYER);
	}

	public void TakeHarvestDamage(float damage, AnimationController.CharacterDirections playerFacingDir, Health.DamageSourceEnum source)
	{
		if (_autoResource == null || (_autoResource != null && _autoResource.Health <= 0f))
		{
			return;
		}
		if (_animator != null && _validAnimatorParameters.Contains(Animator.StringToHash("harvesting")))
		{
			_animator.enabled = true;
			_animator.SetBool("harvesting", value: true);
		}
		CancelInvoke("HarvestingStopped");
		Invoke("HarvestingStopped", 0.5f);
		TriggerHarvestAnimation(playerFacingDir);
		if (!string.IsNullOrEmpty(item.harvestingSoundRef))
		{
			if (item.harvestSoundIsLooping)
			{
				_sounds.PlayLoop(item.harvestingSoundRef, base.transform.position);
			}
			else
			{
				_sounds.PlayOneShot(item.harvestingSoundRef, base.transform.position);
			}
		}
		if (_autoResource.TakeDamage(damage, ref _outputItemsQueue))
		{
			bool playerAutoCollect = source == Health.DamageSourceEnum.PLAYER && _playerUpgrades.AutoCollectEnabled;
			DropHarvestItems(playerAutoCollect);
			if (!string.IsNullOrEmpty(item.harvestDropItemSoundRef))
			{
				_sounds.PlayOneShot(item.harvestDropItemSoundRef, base.transform.position);
			}
		}
		if (_autoResource != null && _autoResource.Health > 0f)
		{
			HarvestHealthChange();
		}
	}

	public void TakeHarvesterDamage(float damage, ItemContainer harvesterContainer)
	{
		_harvesterContainer = harvesterContainer;
		TakeHarvestDamageFromPlayer(damage, AnimationController.CharacterDirections.right);
	}

	public void HarvestingStopped()
	{
		if (_animator != null && _validAnimatorParameters.Contains(Animator.StringToHash("harvesting")))
		{
			_animator.SetBool("harvesting", value: false);
		}
		StopAudio();
	}

	private void StopAudio()
	{
		if (!string.IsNullOrEmpty(item.harvestingSoundRef) && item.harvestSoundIsLooping)
		{
			_sounds.StopLoop(item.harvestingSoundRef);
		}
	}

	private void TriggerHarvestAnimation(AnimationController.CharacterDirections playerFacingDir)
	{
		if (!(_animator == null))
		{
			string text = "harvesting";
			switch (playerFacingDir)
			{
			case AnimationController.CharacterDirections.left:
			case AnimationController.CharacterDirections.down_left:
				text += "_r";
				break;
			case AnimationController.CharacterDirections.right:
			case AnimationController.CharacterDirections.down_right:
				text += "_l";
				break;
			case AnimationController.CharacterDirections.front:
			case AnimationController.CharacterDirections.back:
				text += "_r";
				break;
			default:
				Debug.LogWarning($"Direction {playerFacingDir} passed to TriggerHarvestAnimation has no handler, default direction used");
				text += "_r";
				break;
			}
			if (_validAnimatorParameters.Contains(Animator.StringToHash(text)))
			{
				_animator.enabled = true;
				_animator.SetTrigger(text);
			}
		}
	}

	public void HarvestHealthChange()
	{
		for (int i = 0; i < item.harvestHPVisualThresholds.Count; i++)
		{
			if (_autoResource.Health != 0f && item.harvestHPVisualThresholds[i] >= _autoResource.Health)
			{
				if (icon == null)
				{
					Debug.LogError("Icon property not set for item that has visual thresholds: " + base.gameObject.name);
				}
				else
				{
					icon.sprite = item.visualStates[i];
				}
			}
		}
		UpdateProgressDisplay(_autoResource.HarvestPercent);
	}

	private void HarvestComplete()
	{
		StopAudio();
		if (!string.IsNullOrEmpty(item.harvestDropItemSoundRef))
		{
			_sounds.PlayOneShot(item.harvestDropItemSoundRef, base.transform.position);
		}
		if (destroyOnHarvest || !_autoResource.IsFullyGrown)
		{
			SetInactive();
			DestroyGameObject(0.05f);
		}
		else
		{
			if (item.visualStates.Count != 0)
			{
				icon.sprite = item.visualStates[item.visualStates.Count - 1];
			}
			if (_animator != null)
			{
				_animator.enabled = true;
				_animator.SetTrigger("harvested_idle");
			}
			_interactive = false;
			DisableHarvestColliders();
		}
		_uiProgress.HideDisplay();
		_camController.AnimateCameraShake(CameraController.CameraShakeTriggers.shakeVeryLight);
		if (_afterHarvestedPrefab != null && _autoResource.IsFullyGrown)
		{
			UnityEngine.Object.Instantiate(_afterHarvestedPrefab, base.transform.position, Quaternion.identity);
		}
	}

	private void DisableHarvestColliders()
	{
		Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].gameObject.layer == Layers.HARVESTABLE)
			{
				componentsInChildren[i].enabled = false;
			}
		}
	}

	private void DropHarvestItems(bool playerAutoCollect)
	{
		while (_outputItemsQueue.Count > 0)
		{
			AutomationCoreItem automationCoreItem = _outputItemsQueue.Dequeue();
			automationCoreItem.position = base.transform.position;
			_autoSystem.TryAddCoreItemToSpace(base.transform.position, automationCoreItem, playerAutoCollect);
		}
	}

	public override void ShowTooltip()
	{
		base.ShowTooltip();
		if (_customSelectionHighlight != null)
		{
			if (!_selectionHighlightTransform.IsNullOrDestroyed())
			{
				_selectionHighlightTransform.gameObject.SetActive(value: false);
			}
			_customSelectionHighlight.gameObject.SetActive(value: true);
		}
	}

	public override void SetInactive()
	{
		base.SetInactive();
		if (_customSelectionHighlight != null)
		{
			_customSelectionHighlight.gameObject.SetActive(value: false);
		}
	}

	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	public override string GetItemName()
	{
		return item.itemName;
	}

	public override string GetToolTip(UserActions action)
	{
		if (action.Name == "INTERACT")
		{
			if (_autoResource != null && !_autoResource.IsFullyGrown)
			{
				return item.GetToolTip(true);
			}
			if (!playerHarvestable && harvestedBy != null)
			{
				return Loc.GetString(Constants.USER_ACTION_REQUIRES_X) + " " + harvestedBy.itemName;
			}
			bool playerCanInteract = _playerProgress.PlayerCanHarvest(item) || IsGrowing;
			return item.GetToolTip(playerCanInteract);
		}
		return "";
	}

	public override List<UserActions> GetValidActions()
	{
		_actionList.Clear();
		if (playerHarvestable && _autoResource != null && _autoResource.IsHarvestable)
		{
			_actionList.Add(UserActions.INTERACT);
		}
		return _actionList;
	}

	public override Vector3 GetInteractionPosition(Vector3 playerPosition)
	{
		Vector3 vector = ((UnityUtils.GetRelativeHorizontalDirection(playerPosition, base.transform.position) > 0f) ? Constants.HARVEST_BEAM_ALIGN_RIGHT : Constants.HARVEST_BEAM_ALIGN_LEFT);
		Vector3 vector2 = base.transform.position + vector;
		vector2.y = 0f;
		if (NavMesh.SamplePosition(vector2, out var hit, 0.25f, Layers.NAV_MESH_WALKABLE_AREA_LAYER_MASK))
		{
			return vector2;
		}
		vector2 = base.transform.position - vector;
		NavMesh.SamplePosition(vector2, out hit, 0.25f, Layers.NAV_MESH_WALKABLE_AREA_LAYER_MASK);
		return vector2;
	}

	public void DisableAnimator()
	{
		if (_animator != null)
		{
			_animator.enabled = false;
		}
	}

	private void UpdateProgressDisplay(float value)
	{
		if (_harvesterContainer == null && _uiProgress != null)
		{
			_uiProgress.SetProgress(value, base.transform);
		}
	}

	public void OnDrawGizmosSelected()
	{
		UnityUtils.DrawCircleRadius(base.transform.position + dropOffset, dropRange, Color.blue, new Color(0f, 0f, 0.5f, 0.1f), "Drop area", 0f);
	}
}
