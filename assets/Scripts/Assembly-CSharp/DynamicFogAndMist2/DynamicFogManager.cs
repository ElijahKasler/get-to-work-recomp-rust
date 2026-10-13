using UnityEngine;

namespace DynamicFogAndMist2;

[ExecuteInEditMode]
public class DynamicFogManager : MonoBehaviour, IDynamicFogManager
{
	private static DynamicFogManager _instance;

	public Camera mainCamera;

	public Light sun;

	[Tooltip("Flip depth texture. Use only as a workaround to a bug in URP if the depth shows inverted in GameView. Alternatively you can enable MSAA or HDR instead of using this option.")]
	public bool flipDepthTexture;

	private const string SKW_FLIP_DEPTH_TEXTURE = "DF2_FLIP_DEPTH_TEXTURE";

	public string managerName => "Dynamic Fog Manager";

	public static DynamicFogManager instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Tools.CheckMainManager();
			}
			return _instance;
		}
	}

	private void OnEnable()
	{
		SetupCamera();
		SetupLights();
		SetupDepthPrePass();
	}

	private void OnValidate()
	{
		SetupDepthPrePass();
	}

	private void SetupCamera()
	{
		Tools.CheckCamera(ref mainCamera);
		if (mainCamera != null)
		{
			mainCamera.depthTextureMode |= DepthTextureMode.Depth;
		}
	}

	private void SetupLights()
	{
		Light[] array = Misc.FindObjectsOfType<Light>();
		foreach (Light light in array)
		{
			if (light.type == LightType.Directional)
			{
				if (sun == null)
				{
					sun = light;
				}
				break;
			}
		}
	}

	private void SetupDepthPrePass()
	{
		Shader.SetGlobalInt("DF2_FLIP_DEPTH_TEXTURE", flipDepthTexture ? 1 : 0);
	}

	public static GameObject CreateFogVolume(string name)
	{
		GameObject obj = Object.Instantiate(Resources.Load<GameObject>("DynamicFog/Prefabs/FogVolume2D"));
		obj.name = name;
		return obj;
	}

	public static GameObject CreateFogSubVolume(string name)
	{
		GameObject obj = Object.Instantiate(Resources.Load<GameObject>("DynamicFog/Prefabs/FogSubVolume"));
		obj.name = name;
		return obj;
	}
}
