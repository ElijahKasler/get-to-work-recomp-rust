using System.Collections;
using UnityEngine;

namespace PixelCrushers;

[AddComponentMenu("")]
public class UILocalizationManager : MonoBehaviour
{
	[Tooltip("The PlayerPrefs key to store the player's selected language code.")]
	[SerializeField]
	private string m_currentLanguagePlayerPrefsKey = "Language";

	[Tooltip("Overrides the global text table.")]
	[SerializeField]
	private TextTable m_textTable;

	[Tooltip("When starting, set current language to value saved in PlayerPrefs.")]
	[SerializeField]
	private bool m_saveLanguageInPlayerPrefs = true;

	private string m_currentLanguage = string.Empty;

	private static UILocalizationManager m_instance;

	public static UILocalizationManager instance
	{
		get
		{
			if (m_instance == null)
			{
				m_instance = Object.FindObjectOfType<UILocalizationManager>();
				if (m_instance == null)
				{
					GlobalTextTable globalTextTable = Object.FindObjectOfType<GlobalTextTable>();
					m_instance = ((globalTextTable != null) ? globalTextTable.gameObject.AddComponent<UILocalizationManager>() : new GameObject("UILocalizationManager").AddComponent<UILocalizationManager>());
				}
			}
			return m_instance;
		}
		set
		{
			m_instance = value;
		}
	}

	public TextTable textTable
	{
		get
		{
			if (!(instance.m_textTable != null))
			{
				return GlobalTextTable.textTable;
			}
			return instance.m_textTable;
		}
		set
		{
			instance.m_textTable = value;
		}
	}

	public string currentLanguage
	{
		get
		{
			return instance.m_currentLanguage;
		}
		set
		{
			instance.m_currentLanguage = value;
			instance.UpdateUIs(value);
		}
	}

	public string currentLanguagePlayerPrefsKey
	{
		get
		{
			return m_currentLanguagePlayerPrefsKey;
		}
		set
		{
			m_currentLanguagePlayerPrefsKey = value;
		}
	}

	public bool saveLanguageInPlayerPrefs
	{
		get
		{
			return m_saveLanguageInPlayerPrefs;
		}
		set
		{
			m_saveLanguageInPlayerPrefs = value;
		}
	}

	private void Awake()
	{
		if (m_instance == null)
		{
			m_instance = this;
		}
		if (saveLanguageInPlayerPrefs && !string.IsNullOrEmpty(currentLanguagePlayerPrefsKey) && PlayerPrefs.HasKey(currentLanguagePlayerPrefsKey))
		{
			m_currentLanguage = PlayerPrefs.GetString(currentLanguagePlayerPrefsKey);
		}
	}

	private IEnumerator Start()
	{
		yield return new WaitForEndOfFrame();
		UpdateUIs(currentLanguage);
	}

	public void UpdateUIs(string language)
	{
		m_currentLanguage = language;
		if (saveLanguageInPlayerPrefs && !string.IsNullOrEmpty(currentLanguagePlayerPrefsKey))
		{
			PlayerPrefs.SetString(currentLanguagePlayerPrefsKey, language);
		}
		LocalizeUI[] array = Object.FindObjectsOfType<LocalizeUI>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].UpdateText();
		}
	}
}
