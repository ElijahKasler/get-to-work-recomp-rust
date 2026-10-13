using System.Collections.Generic;
using UnityEngine;

public class DecalManager
{
	private static Dictionary<DecalSpawner.InitData, DecalSpawner> spawners = new Dictionary<DecalSpawner.InitData, DecalSpawner>();

	private static Dictionary<string, DecalSpawner.InitData> typeNameToData = new Dictionary<string, DecalSpawner.InitData>();

	private static DecalUtils.Mode preferredMode = DecalUtils.Mode.CPU;

	private static bool preferredIndirect = false;

	private static int preferredShaderPass = 0;

	public static void Cleanup()
	{
		DecalSpawner.Cleanup();
		GPUDecalUtils.Cleanup();
		spawners = new Dictionary<DecalSpawner.InitData, DecalSpawner>();
		typeNameToData = new Dictionary<string, DecalSpawner.InitData>();
	}

	public static DecalSpawner GetSpawner(DecalSpawner.InitData initData, int maxTrisTotal, int maxTrisInDecal)
	{
		if (spawners.TryGetValue(initData, out var value))
		{
			return value;
		}
		value = new DecalSpawner();
		value.initData = initData;
		value.Init(maxTrisTotal, maxTrisInDecal, preferredMode, preferredIndirect, preferredShaderPass);
		spawners[initData] = value;
		return value;
	}

	public static DecalSpawner GetSpawner(string name, int maxTrisTotal, int maxTrisInDecal)
	{
		DecalSpawner.InitData value = null;
		if (!typeNameToData.TryGetValue(name, out value))
		{
			DecalType decalType = Resources.Load("DecalTypes/" + name, typeof(DecalType)) as DecalType;
			if (decalType == null)
			{
				Debug.LogError("Can't find Resources/DecalTypes/" + name);
				return null;
			}
			value = decalType.decalSettings;
			typeNameToData[name] = value;
		}
		return GetSpawner(value, maxTrisTotal, maxTrisInDecal);
	}

	public static void SetPreferredMode(DecalUtils.Mode mode, bool drawIndirect, int shaderPass)
	{
		preferredMode = mode;
		preferredIndirect = drawIndirect;
		preferredShaderPass = shaderPass;
	}

	public static DecalSpawner CreateUniqueSpawner(DecalSpawner.InitData initData, int maxTrisTotal, int maxTrisInDecal)
	{
		DecalSpawner decalSpawner = new DecalSpawner();
		decalSpawner.initData = initData;
		decalSpawner.Init(maxTrisTotal, maxTrisInDecal, preferredMode, preferredIndirect, preferredShaderPass);
		return decalSpawner;
	}

	public static DecalSpawner CreateUniqueSpawner(string name, int maxTrisTotal, int maxTrisInDecal)
	{
		DecalSpawner.InitData value = null;
		if (!typeNameToData.TryGetValue(name, out value))
		{
			DecalType decalType = Resources.Load("DecalTypes/" + name, typeof(DecalType)) as DecalType;
			if (decalType == null)
			{
				Debug.LogError("Can't find Resources/DecalTypes/" + name);
				return null;
			}
			value = decalType.decalSettings;
			typeNameToData[name] = value;
		}
		DecalSpawner decalSpawner = new DecalSpawner();
		decalSpawner.initData = value;
		decalSpawner.Init(maxTrisTotal, maxTrisInDecal, preferredMode, preferredIndirect, preferredShaderPass);
		return decalSpawner;
	}
}
