using System.Collections;
using Isto.Core.Audio;
using Isto.Core.Items;
using UnityEngine;
using Zenject;

namespace Isto.Core.Power;

public class TetheredBuilding : MonoBehaviour
{
	[Header("Building")]
	[SerializeField]
	private InteractableBuilding _linkedBuilding;

	[Header("Event")]
	[SerializeField]
	private BuildingFirstConnectAction _firstConnect;

	[Header("Power")]
	public bool powered;

	[Header("Connected Lightbulb")]
	[SerializeField]
	private Vector3 _offset;

	[Header("Visuals")]
	[SerializeField]
	private GameObject _visualsOn;

	[SerializeField]
	private GameObject _visualsOff;

	private TetherSystem _tetherSystem;

	private IGameSounds _sounds;

	protected PowerTethered _connectedBulb;

	private bool _buildingActivated;

	private bool HasAlreadyBeenPowered
	{
		get
		{
			if (_firstConnect != null)
			{
				return _firstConnect.ActionCompleted;
			}
			return false;
		}
	}

	[Inject]
	public void Inject(TetherSystem tetherSystem, IGameSounds gameSounds)
	{
		_tetherSystem = tetherSystem;
		_sounds = gameSounds;
	}

	private void OnEnable()
	{
		_tetherSystem.TetherAdded += OnTetherAdded;
		_tetherSystem.TetherRemoved += OnTetherRemoved;
	}

	private void OnDisable()
	{
		_tetherSystem.TetherAdded -= OnTetherAdded;
		_tetherSystem.TetherRemoved -= OnTetherRemoved;
	}

	private void Update()
	{
		UpdatePoweredStatus();
		bool flag = _connectedBulb != null && _connectedBulb.Powered;
		if (flag != powered)
		{
			powered = flag;
			OnPowerStatusChanged();
		}
	}

	protected virtual void OnPowerStatusChanged()
	{
		if ((bool)_visualsOn)
		{
			_visualsOn.SetActive(powered);
		}
		if ((bool)_visualsOff)
		{
			_visualsOff.SetActive(!powered);
		}
	}

	protected virtual void OnTetherAdded(object sender, TetherEventArgs e)
	{
		if (e.tethered.transform.position.DistanceXZ(base.transform.position) < 0.5f)
		{
			ConnectToBulb(e.tethered);
		}
	}

	protected virtual void ConnectToBulb(PowerTethered bulb)
	{
		_connectedBulb = bulb;
		_connectedBulb.AddOffset(_offset);
	}

	protected virtual void OnTetherRemoved(object sender, TetherEventArgs e)
	{
		if (_connectedBulb != null && e.tethered == _connectedBulb)
		{
			DisconnectBulb();
		}
	}

	protected virtual void DisconnectBulb()
	{
		_connectedBulb = null;
	}

	private void UpdatePoweredStatus()
	{
		if (!_buildingActivated && LightBulbConnectedAndPowered())
		{
			float time = 0.4f;
			Invoke("TurnOnBuilding", time);
			_buildingActivated = true;
		}
		else if (_buildingActivated && !LightBulbConnectedAndPowered())
		{
			CancelInvoke("TurnOnBuilding");
			InstantOff();
			_buildingActivated = false;
		}
	}

	private bool LightBulbConnectedAndPowered()
	{
		if (_connectedBulb == null)
		{
			return false;
		}
		return _connectedBulb.Powered;
	}

	private void TurnOnBuilding()
	{
		if (!_linkedBuilding.IsNullOrDestroyed())
		{
			if (!HasAlreadyBeenPowered)
			{
				StartCoroutine(RunTurnOnAnimation());
			}
			else
			{
				InstantOn();
			}
		}
	}

	private IEnumerator RunTurnOnAnimation()
	{
		PrepareForTurnOn();
		yield return _firstConnect.BuildingTurnOnRoutine();
		InstantOn();
	}

	private void PrepareForTurnOn()
	{
		if (!_linkedBuilding.IsNullOrDestroyed() && _linkedBuilding is IPoweredBuilding poweredBuilding)
		{
			poweredBuilding.TurnOn();
		}
	}

	private void InstantOn()
	{
		if (!_linkedBuilding.IsNullOrDestroyed())
		{
			_linkedBuilding.SetInteractive(state: true);
			if (_linkedBuilding is IPoweredBuilding poweredBuilding)
			{
				poweredBuilding.TurnOn();
			}
		}
	}

	private void InstantOff()
	{
		if (!_linkedBuilding.IsNullOrDestroyed())
		{
			_linkedBuilding.SetInteractive(state: false);
			if (_linkedBuilding is IPoweredBuilding poweredBuilding)
			{
				poweredBuilding.TurnOff();
			}
		}
	}
}
