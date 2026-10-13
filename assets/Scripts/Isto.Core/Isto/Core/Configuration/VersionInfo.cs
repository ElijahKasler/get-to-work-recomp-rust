using System;
using System.Collections.Generic;
using System.Linq;
using Isto.Core.Enums;
using UnityEngine;
using UnityEngine.Serialization;

namespace Isto.Core.Configuration;

[CreateAssetMenu(fileName = "GameVersionInfo", menuName = "Scriptables/New Game Version Info")]
public class VersionInfo : ScriptableObject
{
	[Serializable]
	public class VersionData : IComparable
	{
		public string Tag;

		public int majorRevision;

		public int minorRevision;

		public int patchNo;

		public int buildNo;

		public string versionSuffix;

		[EnumDropdown(typeof(TargetStoreEnum))]
		public int targetStore;

		[EnumDropdown(typeof(BuildTypeEnum))]
		public int buildType;

		[Tooltip("UTC")]
		public string timeOfDay;

		public string shortDate;

		public string longDate;

		public string FullVersionText => VersionText + SEPARATOR + BuildText;

		public string VersionText => ShortVersionText + SEPARATOR + patchNo;

		public string ShortVersionText => majorRevision + SEPARATOR + minorRevision;

		public string BuildText => buildNo + versionSuffix;

		public VersionData VersionUpdate(bool major)
		{
			if (major)
			{
				majorRevision++;
				minorRevision = 0;
			}
			else
			{
				minorRevision++;
			}
			patchNo = 0;
			buildNo = 0;
			return this;
		}

		public VersionData PatchUpdate()
		{
			patchNo++;
			buildNo = 0;
			return this;
		}

		public VersionData BuildUpdate()
		{
			buildNo++;
			return this;
		}

		public VersionData SetCode(string suffix)
		{
			versionSuffix = suffix;
			return this;
		}

		public VersionData ClearCode()
		{
			versionSuffix = "-";
			return this;
		}

		public VersionData SetCurrentTime()
		{
			timeOfDay = DateTime.Now.ToUniversalTime().TimeOfDay.ToString();
			shortDate = DateTime.Today.ToShortDateString();
			longDate = DateTime.Today.ToLongDateString();
			return this;
		}

		public VersionData ClearTime()
		{
			timeOfDay = "-";
			shortDate = "-";
			longDate = "-";
			return this;
		}

		public VersionData SetTag(string tag)
		{
			Tag = tag;
			return this;
		}

		public VersionData TagBuild()
		{
			Tag = "build " + FullVersionText;
			return this;
		}

		public VersionData TagPatch()
		{
			Tag = "patch " + FullVersionText;
			return this;
		}

		public VersionData TagUpdate()
		{
			Tag = "update " + FullVersionText;
			return this;
		}

		public VersionData TagRelease()
		{
			Tag = "major update " + FullVersionText;
			return this;
		}

		public VersionData OverrideSuffix(string suffix)
		{
			versionSuffix = suffix;
			Tag = "variant " + FullVersionText;
			timeOfDay = DateTime.Now.ToUniversalTime().TimeOfDay.ToString();
			shortDate = DateTime.Today.ToShortDateString();
			longDate = DateTime.Today.ToLongDateString();
			return this;
		}

		public int CompareTo(object obj)
		{
			if (!(obj is VersionData versionData))
			{
				return FullVersionText.CompareTo(obj);
			}
			if (majorRevision != versionData.majorRevision)
			{
				return majorRevision.CompareTo(versionData.majorRevision);
			}
			if (minorRevision != versionData.minorRevision)
			{
				return minorRevision.CompareTo(versionData.minorRevision);
			}
			if (patchNo != versionData.patchNo)
			{
				return patchNo.CompareTo(versionData.patchNo);
			}
			if (buildNo != versionData.buildNo)
			{
				return buildNo.CompareTo(versionData.buildNo);
			}
			if (shortDate != versionData.shortDate)
			{
				return shortDate.CompareTo(versionData.shortDate);
			}
			if (timeOfDay != versionData.timeOfDay)
			{
				return timeOfDay.CompareTo(versionData.timeOfDay);
			}
			return 0;
		}

		public VersionData Clone()
		{
			return new VersionData
			{
				Tag = Tag,
				majorRevision = majorRevision,
				minorRevision = minorRevision,
				patchNo = patchNo,
				buildNo = buildNo,
				targetStore = targetStore,
				buildType = buildType,
				versionSuffix = versionSuffix,
				timeOfDay = timeOfDay,
				shortDate = shortDate,
				longDate = longDate
			};
		}
	}

	[FormerlySerializedAs("_current")]
	[SerializeField]
	private VersionData _activeVersion;

	[NonReorderable]
	[Tooltip("Always has to be in order of when they were created, most recent build being last")]
	public List<VersionData> versionHistory;

	private const string ASSET_NAME = "GameVersionInfo";

	private static readonly string ASSET_PATH = "Assets/Resources/GameVersionInfo.asset";

	private static readonly string SEPARATOR = ".";

	public VersionData LastBuild => versionHistory?.LastOrDefault() ?? new VersionData();

	public VersionData ActiveVersion => _activeVersion;

	public string TargetStoreCode
	{
		get
		{
			string result = "";
			TargetStoreEnum targetStoreEnum = ExpandableEnum<Int32Enum<TargetStoreEnum>, int>.GetFromValue(ActiveVersion.targetStore) as TargetStoreEnum;
			if (targetStoreEnum == TargetStoreEnum.STEAM)
			{
				result = "SP";
			}
			else if (targetStoreEnum == TargetStoreEnum.EPIC)
			{
				result = "EP";
			}
			else if (targetStoreEnum == TargetStoreEnum.MICROSOFT)
			{
				result = "MP";
			}
			else if (targetStoreEnum == TargetStoreEnum.XBOX)
			{
				result = "XD";
			}
			return result;
		}
	}

	public BuildTypeEnum Type
	{
		get
		{
			return ExpandableEnum<Int32Enum<BuildTypeEnum>, int>.GetFromValue(ActiveVersion.buildType) as BuildTypeEnum;
		}
		set
		{
			ActiveVersion.buildType = value.Value;
		}
	}

	public TargetStoreEnum Store
	{
		get
		{
			return ExpandableEnum<Int32Enum<TargetStoreEnum>, int>.GetFromValue(ActiveVersion.targetStore) as TargetStoreEnum;
		}
		set
		{
			ActiveVersion.targetStore = value.Value;
		}
	}

	private void OnValidate()
	{
		ResetCurrentTimePunch();
	}

	private void ResetCurrentTimePunch()
	{
		_activeVersion.ClearTime().ClearCode().SetTag("Current WIP Version");
	}

	[ContextMenu("MajorUpdate")]
	public void MajorUpdate()
	{
		ActiveVersion.VersionUpdate(major: true);
	}

	[ContextMenu("MinorUpdate")]
	public void MinorUpdate()
	{
		ActiveVersion.VersionUpdate(major: false);
	}

	[ContextMenu("PatchUpdate")]
	public void PatchUpdate()
	{
		ActiveVersion.PatchUpdate();
	}

	[ContextMenu("AutoIncrementBuild")]
	public void AutoIncrementBuild()
	{
		bool num = ActiveVersion.majorRevision > LastBuild.majorRevision;
		bool flag = ActiveVersion.minorRevision > LastBuild.minorRevision;
		bool flag2 = ActiveVersion.patchNo > LastBuild.patchNo;
		versionHistory.Add(_activeVersion.Clone().SetCurrentTime().SetCode(TargetStoreCode));
		if (num)
		{
			LastBuild.TagRelease();
		}
		else if (flag)
		{
			LastBuild.TagUpdate();
		}
		else if (flag2)
		{
			LastBuild.TagPatch();
		}
		else
		{
			LastBuild.TagBuild();
		}
		_activeVersion.BuildUpdate();
		Debug.Log("Archiving version " + LastBuild.FullVersionText);
		Debug.Log("Incrementing next build version to " + ActiveVersion.FullVersionText);
	}

	[ContextMenu("ResetToLastBuild")]
	public void ResetToLastBuild()
	{
		_activeVersion = LastBuild.Clone().BuildUpdate();
		ResetCurrentTimePunch();
	}

	[ContextMenu("PrintCurrentVersion")]
	public void PrintCurrentVersion()
	{
		Debug.Log("Current version is " + ActiveVersion.FullVersionText + " (" + ActiveVersion.Tag + ")");
	}

	public static VersionInfo LoadFromResources()
	{
		VersionInfo versionInfo = Resources.Load<VersionInfo>("GameVersionInfo");
		if (versionInfo == null)
		{
			Debug.LogError("Could not find VersionInfo file in the project");
		}
		return versionInfo;
	}
}
