using System.Collections;
using FMODUnity;
using Isto.Core.Audio;
using Isto.Core.Beings;
using Isto.Core.Data;
using Isto.Core.UI;
using UnityEngine;
using Zenject;

namespace Isto.Core.Items;

public class Torch : EquippableItemController, ISliderDisplay
{
	public AnimationCurve lightFadeCurve;

	public AnimationCurve lightRangeCurve;

	public float lifetime = 30f;

	public Light torchLight;

	public GameObject torchSprite;

	private float _lifeTimer;

	private float _startIntensity;

	private float _startRange;

	[SerializeField]
	[EventRef]
	private string _lightOnSoundRef = "";

	[SerializeField]
	[EventRef]
	private string _lightFlickerSoundRef = "";

	private IGameSounds _gameSounds;

	private PlayerUpgrades _playerUpgrades;

	private bool _lightFalling;

	[Inject]
	public void Inject(IGameSounds gameSounds, PlayerUpgrades playerUpgrades)
	{
		_gameSounds = gameSounds;
		_playerUpgrades = playerUpgrades;
	}

	public override void ItemUnequipped()
	{
		OnItemUnequipped();
	}

	public override void OnItemEquipped()
	{
		lifetime += _playerUpgrades.TorchDurationIncrease * lifetime;
		base.transform.parent = _player.Hand;
		base.transform.localPosition = Vector3.zero;
		_startIntensity = torchLight.intensity;
		_startRange = torchLight.range;
		IActivatable[] componentsInChildren = GetComponentsInChildren<IActivatable>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].Activate();
		}
		_gameSounds.PlayOneShot(_lightOnSoundRef, base.transform.position);
		_player.itemInHand = this;
	}

	public override void OnItemUnequipped()
	{
		if (_player.itemInHand == this)
		{
			_player.itemInHand = null;
		}
		if (lifetime - _lifeTimer < 1f)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		base.transform.parent = null;
		StartCoroutine(DropTorchCoroutine());
	}

	public override void OnActiveUpdate()
	{
		_lifeTimer += Time.deltaTime;
		if (_lifeTimer > lifetime)
		{
			ItemUnequipped();
			return;
		}
		float num = lightFadeCurve.Evaluate(_lifeTimer / lifetime) * _startIntensity;
		if (num < torchLight.intensity - 0.05f && !_lightFalling)
		{
			_gameSounds.PlayOneShot(_lightFlickerSoundRef, base.transform.position);
			_lightFalling = true;
		}
		else if (num >= torchLight.intensity)
		{
			_lightFalling = false;
		}
		torchLight.intensity = num;
		torchLight.range = lightRangeCurve.Evaluate(_lifeTimer / lifetime) * _startRange;
	}

	public override void DeactivateItem()
	{
		base.DeactivateItem();
		torchLight.intensity = 0f;
		torchLight.range = 0f;
	}

	public float GetCurrentPercent()
	{
		if (_lifeTimer >= lifetime)
		{
			return 0f;
		}
		return 1f - _lifeTimer / lifetime;
	}

	private IEnumerator DropTorchCoroutine()
	{
		torchSprite.SetActive(value: true);
		Rigidbody rigidBody = GetComponent<Rigidbody>();
		SphereCollider collider = GetComponent<SphereCollider>();
		if (collider == null)
		{
			collider = base.gameObject.AddComponent<SphereCollider>();
			collider.radius = 0.4f;
			collider.center = new Vector3(-0.5f, 0.4f, 0.5f);
		}
		rigidBody.isKinematic = false;
		rigidBody.useGravity = true;
		rigidBody.AddForce(Vector3.up * 4.5f, ForceMode.Impulse);
		while (!rigidBody.IsSleeping())
		{
			yield return null;
		}
		Object.Destroy(collider);
		rigidBody.isKinematic = true;
		rigidBody.useGravity = false;
	}

	public override EquippableItemData GetSaveData()
	{
		return new TorchItemData(item.itemID, lifetime - _lifeTimer);
	}

	public override void LoadData(EquippableItemData data)
	{
		TorchItemData torchItemData = data as TorchItemData;
		_lifeTimer = lifetime - torchItemData.lifeRemaining;
	}
}
