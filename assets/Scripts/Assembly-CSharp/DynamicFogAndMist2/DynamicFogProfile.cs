using System;
using UnityEngine;

namespace DynamicFogAndMist2;

[CreateAssetMenu(menuName = "Dynamic Fog \u008b& Mist/Fog Profile", fileName = "DynamicFogProfile", order = 1001)]
public class DynamicFogProfile : ScriptableObject
{
	[Header("Appearance")]
	public float baseAltitude;

	[Tooltip("If true, the 3D distance will be used to compute fog accumulation. If false, only X/Z plane distance will be used.")]
	public bool useXYZDistance = true;

	public float densityLinear = 0.55f;

	public float densityExponential = 0.94f;

	public float maxHeight = 10000f;

	public float distanceMax = 100000f;

	public Color tintColor = new Color32(195, 195, 200, byte.MaxValue);

	public bool useVerticalGradient = true;

	[GradientUsage(true, ColorSpace.Linear)]
	public Gradient verticalGradient;

	public bool boxProjection;

	[Tooltip("Hides fog behing opaque objects")]
	public bool depthClip;

	[Header("Noise")]
	[Range(0f, 1f)]
	public float noiseColorBlend = 0.1f;

	public Color noiseColor = new Color32(175, 180, 182, byte.MaxValue);

	[Tooltip("Horizontal scale of the noise/turbulences")]
	public float scale = 50f;

	[Tooltip("Noise shift")]
	[Range(-1f, 1f)]
	public float shift;

	[Tooltip("Attenuates noise with distance")]
	[Range(0f, 1f)]
	public float noiseDistanceAtten = 1f;

	[Header("Wind")]
	public float turbulence = 10f;

	public float speed = 0.73f;

	[Tooltip("Wind direction")]
	public Vector3 direction = new Vector3(0.02f, 0f, 0f);

	[Header("Directional Light")]
	[Range(0f, 128f)]
	public float lightDiffusionPower = 32f;

	[Range(0f, 1f)]
	public float lightDiffusionIntensity = 0.4f;

	public float brightness = 1f;

	[Tooltip("If enabled, the fog color will be tinted with the directional light color.")]
	public bool useSunColor = true;

	[Header("Rendering")]
	[Range(0f, 2f)]
	public float dithering = 1f;

	[Tooltip("The render queue for this renderer. By default, all transparent objects use a render queue of 3000+. Use a lower value to render before all transparent objects.")]
	public int renderQueue = 3099;

	[Tooltip("Optional sorting layer Id (number) for this renderer. By default 0. Usually used to control the order with other transparent renderers, like Sprite Renderer.")]
	public int sortingLayerID;

	[Tooltip("Optional sorting order for this renderer. Used to control the order with other transparent renderers, like Sprite Renderer.")]
	public int sortingOrder;

	[NonSerialized]
	public Color[] gradientColors;

	public const int GRADIENT_TEXTURE_WIDTH = 256;

	public event OnSettingsChanged onSettingsChanged;

	private void OnEnable()
	{
		ValidateSettings();
	}

	private void OnValidate()
	{
		ValidateSettings();
		if (onSettingsChanged != null)
		{
			onSettingsChanged();
		}
	}

	public void ValidateSettings()
	{
		if (verticalGradient == null)
		{
			verticalGradient = new Gradient();
			GradientColorKey[] array = new GradientColorKey[2];
			array[0].color = tintColor;
			array[0].time = 0f;
			array[1].color = tintColor;
			array[1].time = 0f;
			verticalGradient.colorKeys = array;
		}
		if (gradientColors == null || gradientColors.Length != 256)
		{
			gradientColors = new Color[256];
		}
		if (useVerticalGradient)
		{
			for (int i = 0; i < 256; i++)
			{
				float time = (float)i / 256f;
				gradientColors[i] = verticalGradient.Evaluate(time);
			}
		}
		else
		{
			Color white = Color.white;
			for (int j = 0; j < 256; j++)
			{
				gradientColors[j] = white;
			}
		}
		densityLinear = Mathf.Max(0f, densityLinear);
		densityExponential = Mathf.Max(0f, densityExponential);
		maxHeight = Mathf.Max(0f, maxHeight);
		distanceMax = Mathf.Max(0f, distanceMax);
		scale = Mathf.Max(0f, scale);
		turbulence = Mathf.Max(0f, turbulence);
		speed = Mathf.Max(0f, speed);
		lightDiffusionPower = Mathf.Max(0.1f, lightDiffusionPower);
		lightDiffusionIntensity = Mathf.Max(0f, lightDiffusionIntensity);
		brightness = Mathf.Max(0f, brightness);
	}

	public void Lerp(DynamicFogProfile p1, DynamicFogProfile p2, float t)
	{
		float num = 1f - t;
		baseAltitude = p1.baseAltitude * num + p2.baseAltitude * t;
		densityLinear = p1.densityLinear * num + p2.densityLinear * t;
		densityExponential = p1.densityExponential * num + p2.densityExponential * t;
		maxHeight = p1.maxHeight * num + p2.maxHeight * t;
		distanceMax = p1.distanceMax * num + p2.distanceMax * t;
		tintColor = p1.tintColor * num + p2.tintColor * t;
		verticalGradient = p1.verticalGradient;
		if (p1.gradientColors != null && p2.gradientColors != null && p1.gradientColors.Length == 256 && p2.gradientColors.Length == 256)
		{
			for (int i = 0; i < 256; i++)
			{
				gradientColors[i] = p1.gradientColors[i] * num + p2.gradientColors[i] * t;
			}
		}
		boxProjection = ((t < 0.5f) ? p1.boxProjection : p2.boxProjection);
		noiseColorBlend = p1.noiseColorBlend * num + p2.noiseColorBlend * t;
		noiseColor = p1.noiseColor * num + p2.noiseColor * t;
		scale = p1.scale * num + p2.scale * t;
		shift = p1.shift * num + p2.shift * t;
		turbulence = p1.turbulence * num + p2.turbulence * t;
		speed = p1.speed * num + p2.speed * t;
		direction = Vector3.Lerp(p1.direction, p2.direction, t);
		lightDiffusionPower = p1.lightDiffusionPower * num + p2.lightDiffusionPower * t;
		lightDiffusionIntensity = p1.lightDiffusionIntensity * num + p2.lightDiffusionIntensity * t;
		brightness = p1.brightness * num + p2.brightness * t;
		dithering = p1.dithering * num + p2.dithering * t;
		renderQueue = ((t < 0.5f) ? p1.renderQueue : p2.renderQueue);
		sortingLayerID = ((t < 0.5f) ? p1.sortingLayerID : p2.sortingLayerID);
		sortingOrder = ((t < 0.5f) ? p1.sortingOrder : p2.sortingOrder);
	}
}
