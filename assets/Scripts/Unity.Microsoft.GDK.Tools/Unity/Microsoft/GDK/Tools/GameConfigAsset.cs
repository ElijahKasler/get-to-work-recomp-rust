using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

namespace Unity.Microsoft.GDK.Tools;

public class GameConfigAsset : ScriptableObject
{
	public const string k_FileExtension = "mgc";

	[SerializeField]
	[HideInInspector]
	internal string m_IdentityName = "";

	[SerializeField]
	[HideInInspector]
	internal string m_IdentityPublisher = "";

	[SerializeField]
	[HideInInspector]
	internal string m_IdentityVersion = "1.0.0.0";

	[SerializeField]
	[HideInInspector]
	internal string m_TitleId = "";

	[SerializeField]
	[HideInInspector]
	internal string m_SCID = "";

	[SerializeField]
	[HideInInspector]
	internal string m_MSAAppId = "";

	[SerializeField]
	[HideInInspector]
	internal string m_StoreId = "";

	[SerializeField]
	[HideInInspector]
	internal string m_ContentIdOverride = "";

	[SerializeField]
	[HideInInspector]
	internal string m_EKBIDOverride = "";

	[SerializeField]
	[HideInInspector]
	internal string[] m_Sandboxes = new string[0];

	[SerializeField]
	[HideInInspector]
	public LanguagePairs m_LanguagePairs = new LanguagePairs();

	public string IdentityName => m_IdentityName;

	public string IdentityPublisher => m_IdentityPublisher;

	public string IdentityVersion => m_IdentityVersion;

	public string TitleId
	{
		get
		{
			return m_TitleId;
		}
		[Obsolete("Please do not use. This will be removed in a future release. See package documentation 'Modify GDK settings with C# script'", false)]
		set
		{
			m_TitleId = value;
		}
	}

	public string SCID
	{
		get
		{
			return m_SCID;
		}
		[Obsolete("Please do not use. This will be removed in a future release. See package documentation 'Modify GDK settings with C# script'", false)]
		set
		{
			m_SCID = value;
		}
	}

	public string MSAAppId
	{
		get
		{
			return m_MSAAppId;
		}
		[Obsolete("Please do not use. This will be removed in a future release. See package documentation 'Modify GDK settings with C# script'", false)]
		set
		{
			m_MSAAppId = value;
		}
	}

	public string StoreId
	{
		get
		{
			return m_StoreId;
		}
		[Obsolete("Please do not use. This will be removed in a future release. See package documentation 'Modify GDK settings with C# script'", false)]
		set
		{
			m_StoreId = value;
		}
	}

	public string ContentIdOverride
	{
		get
		{
			return m_ContentIdOverride;
		}
		[Obsolete("Please do not use. This will be removed in a future release. See package documentation 'Modify GDK settings with C# script'", false)]
		set
		{
			m_ContentIdOverride = value;
		}
	}

	public string EKBIDOverride
	{
		get
		{
			return m_EKBIDOverride;
		}
		[Obsolete("Please do not use. This will be removed in a future release. See package documentation 'Modify GDK settings with C# script'", false)]
		set
		{
			m_EKBIDOverride = value;
		}
	}

	public string[] Sandboxes => m_Sandboxes;

	public LanguagePairs LanguagePairs => m_LanguagePairs;

	public static Game LoadAsXmlGameConfig(string xmlGameConfigPath)
	{
		try
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Game));
			using StreamReader textReader = new StreamReader(xmlGameConfigPath);
			return (Game)xmlSerializer.Deserialize(textReader);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public void LoadXmlGameConfig(string xmlGameConfigPath)
	{
		Game game = LoadAsXmlGameConfig(xmlGameConfigPath);
		if (game.Identity.Name != null)
		{
			m_IdentityName = game.Identity.Name;
		}
		if (game.Identity.Publisher != null)
		{
			m_IdentityPublisher = game.Identity.Publisher;
		}
		if (game.Identity.Version != null)
		{
			m_IdentityVersion = game.Identity.Version;
		}
		if (game.TitleId != null)
		{
			m_TitleId = game.TitleId;
		}
		if (game.MSAAppId != null)
		{
			m_MSAAppId = game.MSAAppId;
		}
		if (game.ExtendedAttributeList != null)
		{
			if (game.ExtendedAttributeList.ExtendedAttribute.Length != 0)
			{
				CT_ExtendedAttributeListExtendedAttribute cT_ExtendedAttributeListExtendedAttribute = game.ExtendedAttributeList.ExtendedAttribute.Where((CT_ExtendedAttributeListExtendedAttribute extendedAttribute) => extendedAttribute.Name == "Scid").First();
				m_SCID = cT_ExtendedAttributeListExtendedAttribute.Value ?? "";
				IEnumerable<CT_ExtendedAttributeListExtendedAttribute> enumerable = game.ExtendedAttributeList.ExtendedAttribute.Where((CT_ExtendedAttributeListExtendedAttribute extendedAttribute) => extendedAttribute.Name == "SandboxIds");
				if (enumerable != null && enumerable.Count() > 0)
				{
					CT_ExtendedAttributeListExtendedAttribute cT_ExtendedAttributeListExtendedAttribute2 = enumerable.First();
					m_Sandboxes = cT_ExtendedAttributeListExtendedAttribute2.Value.Split(",") ?? null;
				}
			}
			else
			{
				m_SCID = "";
				m_Sandboxes = new string[0];
			}
		}
		if (game.StoreId != null)
		{
			m_StoreId = game.StoreId;
		}
		m_LanguagePairs.ImportFromXml(game);
		if (game.DevelopmentOnly != null)
		{
			m_ContentIdOverride = game.DevelopmentOnly.ContentIdOverride;
			m_EKBIDOverride = game.DevelopmentOnly.EKBIDOverride;
		}
	}

	public static void SaveXmlGameConfig(string xmlGameConfigPath, Game xmlGameConfig)
	{
		try
		{
			string directoryName = Path.GetDirectoryName(xmlGameConfigPath);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			XmlWriterSettings settings = new XmlWriterSettings
			{
				Indent = true,
				NewLineOnAttributes = true
			};
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Game));
			using XmlWriter xmlWriter = XmlWriter.Create(xmlGameConfigPath, settings);
			xmlSerializer.Serialize(xmlWriter, xmlGameConfig);
		}
		catch (Exception ex)
		{
			Debug.LogError($"GameConfigAsset: Save FAILED - Could not write Microsoft Game Config file ({ex.GetType()}). Error: '{ex.Message}'");
		}
	}

	public void SaveXmlGameConfig(string xmlGameConfigPath)
	{
		Game game = LoadAsXmlGameConfig(xmlGameConfigPath);
		if (game == null)
		{
			game = new Game();
			game.configVersion = "1";
		}
		game.TitleId = (string.IsNullOrEmpty(m_TitleId) ? "FFFFFFFF" : m_TitleId);
		game.MSAAppId = (string.IsNullOrEmpty(m_MSAAppId) ? "PleaseChangeMe" : m_MSAAppId);
		game.StoreId = (string.IsNullOrEmpty(m_StoreId) ? null : m_StoreId);
		if (game.Identity == null)
		{
			game.Identity = new CT_Identity();
		}
		game.Identity.Name = (string.IsNullOrEmpty(m_IdentityName) ? "TitleName" : m_IdentityName);
		game.Identity.Version = (string.IsNullOrEmpty(m_IdentityVersion) ? "1.0.0.0" : m_IdentityVersion);
		game.Identity.Publisher = (string.IsNullOrEmpty(m_IdentityPublisher) ? "CN=A4954634-DF4B-47C7-AB70-D3215D246AF1" : m_IdentityPublisher);
		if (game.ExtendedAttributeList == null)
		{
			CT_ExtendedAttributeList cT_ExtendedAttributeList = new CT_ExtendedAttributeList();
			CT_ExtendedAttributeListExtendedAttribute cT_ExtendedAttributeListExtendedAttribute = new CT_ExtendedAttributeListExtendedAttribute();
			if (!string.IsNullOrEmpty(m_SCID))
			{
				cT_ExtendedAttributeListExtendedAttribute = new CT_ExtendedAttributeListExtendedAttribute
				{
					Name = "Scid",
					Value = m_SCID
				};
			}
			if (m_Sandboxes != null && m_Sandboxes.Length != 0)
			{
				CT_ExtendedAttributeListExtendedAttribute cT_ExtendedAttributeListExtendedAttribute2 = new CT_ExtendedAttributeListExtendedAttribute();
				cT_ExtendedAttributeListExtendedAttribute2 = new CT_ExtendedAttributeListExtendedAttribute
				{
					Name = "SandboxIds",
					Value = string.Join(",", m_Sandboxes)
				};
				cT_ExtendedAttributeList.ExtendedAttribute = new CT_ExtendedAttributeListExtendedAttribute[2] { cT_ExtendedAttributeListExtendedAttribute, cT_ExtendedAttributeListExtendedAttribute2 };
			}
			else
			{
				cT_ExtendedAttributeList.ExtendedAttribute = new CT_ExtendedAttributeListExtendedAttribute[1] { cT_ExtendedAttributeListExtendedAttribute };
			}
			game.ExtendedAttributeList = cT_ExtendedAttributeList;
		}
		else
		{
			CT_ExtendedAttributeListExtendedAttribute[] array = new CT_ExtendedAttributeListExtendedAttribute[game.ExtendedAttributeList.ExtendedAttribute.Length + 2];
			for (int i = 0; i < game.ExtendedAttributeList.ExtendedAttribute.Length; i++)
			{
				if (!(game.ExtendedAttributeList.ExtendedAttribute[i].Name.ToUpper() == "SCID") && !(game.ExtendedAttributeList.ExtendedAttribute[i].Name.ToUpper() == "SANDBOXIDS"))
				{
					array[i] = game.ExtendedAttributeList.ExtendedAttribute[i];
				}
			}
			CT_ExtendedAttributeListExtendedAttribute cT_ExtendedAttributeListExtendedAttribute3 = new CT_ExtendedAttributeListExtendedAttribute
			{
				Name = "Scid",
				Value = (string.IsNullOrEmpty(m_SCID) ? null : m_SCID)
			};
			array[^2] = cT_ExtendedAttributeListExtendedAttribute3;
			if (m_Sandboxes.Length != 0)
			{
				CT_ExtendedAttributeListExtendedAttribute cT_ExtendedAttributeListExtendedAttribute4 = new CT_ExtendedAttributeListExtendedAttribute
				{
					Name = "SandboxIds",
					Value = ((m_Sandboxes != null) ? string.Join(",", m_Sandboxes) : null)
				};
				array[^1] = cT_ExtendedAttributeListExtendedAttribute4;
			}
			game.ExtendedAttributeList.ExtendedAttribute = array;
		}
		m_LanguagePairs.ExportToXml(game);
		if (game.DevelopmentOnly != null)
		{
			game.DevelopmentOnly.ContentIdOverride = (string.IsNullOrEmpty(m_ContentIdOverride) ? null : m_ContentIdOverride);
			game.DevelopmentOnly.EKBIDOverride = (string.IsNullOrEmpty(m_EKBIDOverride) ? null : m_EKBIDOverride);
		}
		else
		{
			CT_DevelopmentOnly developmentOnly = new CT_DevelopmentOnly();
			game.DevelopmentOnly = developmentOnly;
			game.DevelopmentOnly.ContentIdOverride = (string.IsNullOrEmpty(m_ContentIdOverride) ? null : m_ContentIdOverride);
			game.DevelopmentOnly.EKBIDOverride = (string.IsNullOrEmpty(m_EKBIDOverride) ? null : m_EKBIDOverride);
		}
		SaveXmlGameConfig(xmlGameConfigPath, game);
	}

	public static string GameConfigToString(Game xmlGameConfig)
	{
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(Game));
		XmlWriterSettings settings = new XmlWriterSettings
		{
			Indent = true,
			IndentChars = "      ",
			NewLineChars = "\r\n",
			OmitXmlDeclaration = true,
			NewLineOnAttributes = true
		};
		using StringWriter stringWriter = new StringWriter();
		using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
		{
			xmlSerializer.Serialize(xmlWriter, xmlGameConfig);
		}
		return stringWriter.ToString();
	}

	public void SetLanguagePair(GameConfigLanguages language, bool isActive)
	{
		m_LanguagePairs.SetLanguagePair(language, isActive);
	}

	public bool IsLanguagePairSet(GameConfigLanguages language)
	{
		return m_LanguagePairs.IsLanguagePairSet(language);
	}

	public bool HasLanguagePairSet()
	{
		foreach (GameConfigLanguages value in Enum.GetValues(typeof(GameConfigLanguages)))
		{
			if (IsLanguagePairSet(value))
			{
				return true;
			}
		}
		return false;
	}
}
