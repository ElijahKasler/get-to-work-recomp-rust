using System;
using System.Collections.Generic;
using Isto.Core.Enums;
using Isto.Core.Game;
using UnityEngine;
using Zenject;

namespace Isto.Core.Configuration;

public class BuildTypeDependent : MonoBehaviour
{
	[Serializable]
	public class BuildTypeData
	{
		[EnumDropdown(typeof(BuildTypeEnum))]
		public int enumValue;

		public BuildTypeEnum GetEnum()
		{
			return ExpandableEnum<Int32Enum<BuildTypeEnum>, int>.GetFromValue(enumValue) as BuildTypeEnum;
		}
	}

	public List<BuildTypeData> compatibleBuildTypes;

	[Header("Testing utilities")]
	[Tooltip("Incompatible object will destroy itself at injection stage as if current game mode was not in compatible list")]
	public bool forceIncompatible;

	[Inject]
	public void Inject(GameState gameState)
	{
		if (!forceIncompatible && (compatibleBuildTypes == null || compatibleBuildTypes.Count == 0))
		{
			Debug.LogWarning("Build Type Dependent object \"" + base.gameObject.name + "\" exists by default because compatibleBuildTypes is empty", this);
		}
		else if (forceIncompatible || IsCompatibleWithCurrentBuildType())
		{
			if (forceIncompatible)
			{
				Debug.LogWarning("Build Type Dependent object \"" + base.gameObject.name + "\" forced to not exist");
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private bool IsCompatibleWithCurrentBuildType()
	{
		bool result = true;
		if (forceIncompatible)
		{
			return result;
		}
		BuildTypeEnum type = VersionInfo.LoadFromResources().Type;
		for (int i = 0; i < compatibleBuildTypes.Count; i++)
		{
			BuildTypeData buildTypeData = compatibleBuildTypes[i];
			if (buildTypeData != null && !(buildTypeData.GetEnum() == BuildTypeEnum.UNKNOWN) && type == buildTypeData.GetEnum())
			{
				result = false;
				break;
			}
		}
		return result;
	}
}
