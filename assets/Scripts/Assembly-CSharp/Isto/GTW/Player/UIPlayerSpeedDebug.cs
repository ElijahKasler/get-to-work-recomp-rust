using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Isto.GTW.Player;

public class UIPlayerSpeedDebug : MonoBehaviour
{
	[Tooltip("Manually determined - drive around and figure it out")]
	[SerializeField]
	private float _playersMaxSpeedKPH;

	[SerializeField]
	private Slider _slider;

	private PlayerController _playerController;

	[Inject]
	public void Inject(PlayerController playerController)
	{
		_playerController = playerController;
	}

	private void Awake()
	{
		_slider.maxValue = _playersMaxSpeedKPH;
	}

	private void Update()
	{
		float currentSpeedKPH = _playerController.CurrentSpeedKPH;
		_slider.value = currentSpeedKPH;
	}
}
