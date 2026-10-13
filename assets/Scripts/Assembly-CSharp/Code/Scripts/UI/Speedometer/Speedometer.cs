using I2.Loc;
using Isto.Core.Localization;
using Isto.GTW.Player;
using Isto.GTW.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scripts.UI.Speedometer;

public class Speedometer : MonoBehaviour
{
	public enum SpeedMetricEnum
	{
		KPH = 0,
		MPH = 1,
		MACH = 2
	}

	[SerializeField]
	private TextMeshProUGUI _speedTxt;

	[SerializeField]
	private TextMeshProUGUI _speedMetricText;

	[SerializeField]
	private Slider _rpmSlider;

	[Space]
	[SerializeField]
	private float _speedMultiplier = 2f;

	[SerializeField]
	private float _maxSpeed = 100f;

	[SerializeField]
	[Range(0f, 1f)]
	private float _rpgStepSize = 0.05f;

	[SerializeField]
	private SpeedMetricEnum _speedMetric;

	[SerializeField]
	private Color _zeroDigitColor = Color.gray;

	[Header("Unit Localization")]
	[SerializeField]
	private LocalizedString _unitKph;

	[SerializeField]
	private LocalizedString _unitMph;

	[SerializeField]
	private LocalizedString _unitMach;

	public static readonly string KPH = "KM/H";

	public static readonly string MPH = "MPH";

	public static readonly string MACH = "Mach";

	public PlayerController PlayerController => PlayerController.CurrentPlayer;

	public float SpeedMultiplier => _speedMultiplier;

	public SpeedMetricEnum SpeedMetric
	{
		get
		{
			return _speedMetric;
		}
		set
		{
			_speedMetric = value;
		}
	}

	private void Start()
	{
		int speedMetric = PlayerPrefs.GetInt(GTWUISettingsGameplaySubState.SPEED_UNIT_PLAYER_PREFS_KEY, GTWUISettingsGameplaySubState.DEFAULT_SPEED_UNIT);
		SpeedMetric = (SpeedMetricEnum)speedMetric;
	}

	private void Update()
	{
		UpdateUI();
	}

	private void UpdateUI()
	{
		float num = (PlayerController.IsRagdollState ? PlayerController.BodySpeedKPH : PlayerController.CurrentSpeedKPH);
		num *= _speedMultiplier;
		SpeedMetric = (SpeedMetricEnum)PlayerPrefs.GetInt(GTWUISettingsGameplaySubState.SPEED_UNIT_PLAYER_PREFS_KEY, GTWUISettingsGameplaySubState.DEFAULT_SPEED_UNIT);
		float num2 = num;
		switch (SpeedMetric)
		{
		case SpeedMetricEnum.MPH:
			num2 *= 0.621371f;
			break;
		case SpeedMetricEnum.MACH:
			num2 *= 0.00081f;
			break;
		}
		_speedTxt.text = GetSpeedText(num2);
		switch (SpeedMetric)
		{
		case SpeedMetricEnum.KPH:
			_speedMetricText.text = Loc.Get(_unitKph);
			break;
		case SpeedMetricEnum.MPH:
			_speedMetricText.text = Loc.Get(_unitMph);
			break;
		case SpeedMetricEnum.MACH:
			_speedMetricText.text = Loc.Get(_unitMach);
			break;
		}
		float num3 = Mathf.Clamp01(num / _maxSpeed);
		if (_rpgStepSize > 0f)
		{
			num3 = Mathf.Round(num3 / _rpgStepSize) * _rpgStepSize;
		}
		_rpmSlider.value = num3;
	}

	private string GetSpeedText(float speed)
	{
		if (_speedMetric == SpeedMetricEnum.MACH)
		{
			speed *= 1000f;
		}
		string text = Mathf.Clamp((int)speed, 0, 999).ToString("D3");
		string text2 = "";
		bool flag = true;
		for (int i = 0; i < text.Length; i++)
		{
			if (flag && text[i] == '0')
			{
				text2 = text2 + "<color=#" + ColorUtility.ToHtmlStringRGB(_zeroDigitColor) + ">" + text[i] + "</color>";
			}
			else
			{
				flag = false;
				text2 += text[i];
			}
		}
		if (_speedMetric == SpeedMetricEnum.MACH)
		{
			text2 = "<color=#" + ColorUtility.ToHtmlStringRGB(_zeroDigitColor) + ">.</color>" + text2;
		}
		return text2;
	}
}
