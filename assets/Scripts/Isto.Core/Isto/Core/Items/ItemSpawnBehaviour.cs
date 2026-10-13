using System.Collections;
using FMODUnity;
using Isto.Core.Audio;
using Isto.Core.Automation;
using Isto.Core.Beings;
using Isto.Core.Pooling;
using UnityEngine;
using Zenject;

namespace Isto.Core.Items;

public class ItemSpawnBehaviour : MonoBehaviour, IActionOnRecycle
{
	public bool randomizeForce = true;

	[EventRef]
	public string pickupSoundRef = "event:/SFX/Atrio SFX_Pick up-St";

	[SerializeField]
	private ItemController _itemController;

	private Rigidbody _rigidBody;

	private SphereCollider _collider;

	private bool _startDelay = true;

	private float _startForce = -1f;

	private bool _autoCollect;

	private bool _collectionRunning;

	private PlayerInventory _inventory;

	private Transform _playerTrans;

	private ItemCollectionParameters _collectionParams;

	private IGameSounds _sounds;

	private CoreItemDropParameters _dropParams;

	[Inject]
	public void Inject(PlayerInventory playerInv, ItemCollectionParameters collectParams, IGameSounds gameSounds, CoreItemDropParameters dropParams)
	{
		_inventory = playerInv;
		_playerTrans = playerInv.transform;
		_collectionParams = collectParams;
		_sounds = gameSounds;
		_dropParams = dropParams;
	}

	private void Awake()
	{
		_rigidBody = GetComponent<Rigidbody>();
		if (_itemController == null)
		{
			_itemController = GetComponent<ItemController>();
		}
	}

	private void Start()
	{
		if (!_startDelay)
		{
			base.enabled = false;
		}
	}

	public void Update()
	{
		if (!_startDelay && _rigidBody != null && _rigidBody.linearVelocity.y == 0f && !_collectionRunning)
		{
			CompleteBounce();
		}
	}

	public void SetStartForce(float force)
	{
		_startForce = force;
	}

	public void StartItemBounce(bool playerCollectAfterBounce)
	{
		float x;
		float z;
		if (playerCollectAfterBounce)
		{
			x = Random.Range(0.1f, 0.4f);
			z = Random.Range(-0.4f, -0.1f);
		}
		else
		{
			z = (x = Random.Range(-0.15f, 0.15f));
		}
		Vector3 launchDirection = (randomizeForce ? new Vector3(x, 1.25f, z) : Vector3.up);
		StartItemBounce(playerCollectAfterBounce, launchDirection);
	}

	public void StartItemBounce(bool playerCollectAfterBounce, Vector3 launchDirection)
	{
		randomizeForce = playerCollectAfterBounce;
		_autoCollect = playerCollectAfterBounce;
		base.gameObject.SetChildLayers(Layers.PROJECTILE);
		if (_collider == null)
		{
			_collider = base.gameObject.AddComponent<SphereCollider>();
			_collider.radius = 0.4f;
			_collider.center = new Vector3(-0.5f, 0.4f, 0.5f);
		}
		if (TryGetComponent<IInteractable>(out var component))
		{
			component.SetInteractive(state: false);
		}
		if (_rigidBody == null)
		{
			_rigidBody = base.gameObject.AddComponent<Rigidbody>();
			_rigidBody.freezeRotation = true;
			_rigidBody.linearDamping = 0.1f;
		}
		_rigidBody.isKinematic = false;
		_rigidBody.useGravity = true;
		float num = ((_startForce == -1f) ? _dropParams.defaultStartForce : _startForce);
		_rigidBody.AddForce(launchDirection * num, ForceMode.Impulse);
		Invoke("AllowPickupInvoked", 0.1f);
	}

	private void AllowPickupInvoked()
	{
		_startDelay = false;
		if (!_autoCollect)
		{
			base.gameObject.SetChildLayers(Layers.COLLECTABLE);
			if (TryGetComponent<IInteractable>(out var component))
			{
				component.SetInteractive(state: true);
			}
		}
	}

	public void CompleteBounce()
	{
		int num = 0;
		bool flag = true;
		if (_autoCollect && PlayerHasSpaceForItem())
		{
			_sounds.PlayOneShot(pickupSoundRef, base.transform.position);
			num = AddItemToPlayerInventory();
			if (_itemController.itemPile.count == num)
			{
				flag = false;
			}
		}
		if (_autoCollect & flag)
		{
			AutomationCoreItemRegister component = base.gameObject.GetComponent<AutomationCoreItemRegister>();
			if (component != null)
			{
				component.SetupInAutomation();
			}
		}
		if (num > 0)
		{
			_itemController.ReduceCount(num);
		}
		if (flag)
		{
			Object.Destroy(_rigidBody);
			_rigidBody = null;
			base.gameObject.SetChildLayers(Layers.COLLECTABLE);
			if (TryGetComponent<IInteractable>(out var component2))
			{
				component2.SetInteractive(state: true);
			}
			Object.Destroy(_collider);
			base.enabled = false;
		}
		else
		{
			StartCoroutine(ShowCollectByPlayer());
		}
	}

	private bool PlayerHasSpaceForItem()
	{
		if ((bool)_itemController)
		{
			return _inventory.GetSpaceAvailable(_itemController.itemPile.item) > 0;
		}
		return false;
	}

	private IEnumerator ShowCollectByPlayer()
	{
		_collectionRunning = true;
		float timer = 0f;
		Vector3 startPosition = base.transform.position;
		while (timer < _collectionParams.moveTime)
		{
			Vector3 position = Vector3.Lerp(startPosition, _playerTrans.position, _collectionParams.movementCurve.Evaluate(timer / _collectionParams.moveTime));
			base.transform.position = position;
			timer += Time.deltaTime;
			yield return null;
		}
		_itemController.DoPickupAction();
	}

	private int AddItemToPlayerInventory()
	{
		if ((bool)_itemController)
		{
			return _inventory.Add(_itemController.itemPile.item, _itemController.itemPile.count);
		}
		return 0;
	}

	public void OnRecycle()
	{
		base.gameObject.SetActive(value: false);
		_autoCollect = false;
		_collectionRunning = false;
		_startDelay = true;
		if (_rigidBody != null)
		{
			Object.Destroy(_rigidBody);
			_rigidBody = null;
		}
		base.gameObject.SetChildLayers(Layers.COLLECTABLE);
		if (TryGetComponent<IInteractable>(out var component))
		{
			component.SetInteractive(state: true);
		}
		if (_collider != null)
		{
			Object.Destroy(_collider);
		}
		base.enabled = true;
	}
}
