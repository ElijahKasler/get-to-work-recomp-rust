using System;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.Microsoft.GDK.Tools;

[Serializable]
public class LanguagePairs : ISerializationCallbackReceiver
{
	private Dictionary<string, bool> _dict = new Dictionary<string, bool>();

	[SerializeField]
	private List<string> keys = new List<string>();

	[SerializeField]
	private List<bool> values = new List<bool>();

	public void OnBeforeSerialize()
	{
		keys.Clear();
		values.Clear();
		foreach (KeyValuePair<string, bool> item in _dict)
		{
			keys.Add(item.Key);
			values.Add(item.Value);
		}
	}

	public void OnAfterDeserialize()
	{
		_dict.Clear();
		for (int i = 0; i < keys.Count; i++)
		{
			_dict[keys[i]] = values[i];
		}
	}

	public LanguagePairs()
	{
		Clear();
	}

	public void Clear()
	{
		_dict.Clear();
		foreach (GameConfigLanguages value in Enum.GetValues(typeof(GameConfigLanguages)))
		{
			_dict[Enum.GetName(typeof(GameConfigLanguages), value)] = false;
		}
	}

	public void SetLanguagePair(GameConfigLanguages lang, bool isActive)
	{
		SetLanguagePair(EnumName(lang), isActive);
	}

	public void SetLanguagePair(string langName, bool isActive)
	{
		if (_dict.ContainsKey(langName))
		{
			_dict[langName] = isActive;
		}
	}

	public bool IsLanguagePairSet(GameConfigLanguages lang)
	{
		return IsLanguagePairSet(EnumName(lang));
	}

	public bool IsLanguagePairSet(string langName)
	{
		if (_dict.TryGetValue(langName, out var value))
		{
			return value;
		}
		return false;
	}

	public void ImportFromXml(Game xmlGameConfig)
	{
		Clear();
		if (xmlGameConfig.Resources != null)
		{
			CT_ResourcesResource[] resources = xmlGameConfig.Resources;
			foreach (CT_ResourcesResource cT_ResourcesResource in resources)
			{
				SetLanguagePair(cT_ResourcesResource.Language.Replace("-", "_"), isActive: true);
			}
		}
	}

	public void ExportToXml(Game xmlGameConfig)
	{
		CT_ResourcesResource[] array = new CT_ResourcesResource[Enum.GetValues(typeof(GameConfigLanguages)).Length];
		int num = 0;
		foreach (GameConfigLanguages value in Enum.GetValues(typeof(GameConfigLanguages)))
		{
			if (IsLanguagePairSet(value))
			{
				CT_ResourcesResource cT_ResourcesResource = new CT_ResourcesResource
				{
					Language = Enum.GetName(typeof(GameConfigLanguages), value).Replace("_", "-")
				};
				array[num] = cT_ResourcesResource;
				num++;
			}
		}
		xmlGameConfig.Resources = ((num > 0) ? array : null);
	}

	private string EnumName(GameConfigLanguages lang)
	{
		return Enum.GetName(typeof(GameConfigLanguages), lang);
	}
}
