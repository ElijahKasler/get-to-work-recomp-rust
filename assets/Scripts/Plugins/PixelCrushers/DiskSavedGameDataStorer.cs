using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace PixelCrushers;

[AddComponentMenu("")]
public class DiskSavedGameDataStorer : SavedGameDataStorer
{
	private class SavedGameInfo
	{
		public string sceneName;

		public SavedGameInfo(string sceneName)
		{
			this.sceneName = sceneName;
		}
	}

	[Tooltip("Encrypt saved game files.")]
	public bool encrypt = true;

	[Tooltip("If encrypting, use this password.")]
	public string encryptionPassword = "My Password";

	[Tooltip("Log debug info.")]
	[SerializeField]
	private bool m_debug;

	private List<SavedGameInfo> m_savedGameInfo = new List<SavedGameInfo>();

	public bool debug
	{
		get
		{
			if (m_debug)
			{
				return Debug.isDebugBuild;
			}
			return false;
		}
		set
		{
			m_debug = value;
		}
	}

	public virtual void Start()
	{
		LoadSavedGameInfoFromFile();
	}

	public virtual string GetSaveGameFilename(int slotNumber)
	{
		return Application.persistentDataPath + "/save_" + slotNumber + ".dat";
	}

	public virtual string GetSavedGameInfoFilename()
	{
		return Application.persistentDataPath + "/saveinfo.dat";
	}

	public virtual void LoadSavedGameInfoFromFile()
	{
		string savedGameInfoFilename = GetSavedGameInfoFilename();
		if (string.IsNullOrEmpty(savedGameInfoFilename) || !File.Exists(savedGameInfoFilename))
		{
			return;
		}
		if (debug)
		{
			Debug.Log("Save System: DiskSavedGameDataStorer loading " + savedGameInfoFilename);
		}
		try
		{
			using StreamReader streamReader = new StreamReader(savedGameInfoFilename);
			m_savedGameInfo.Clear();
			int num = 0;
			while (!streamReader.EndOfStream && num < 999)
			{
				string sceneName = streamReader.ReadLine().Replace("<cr>", "\n");
				m_savedGameInfo.Add(new SavedGameInfo(sceneName));
				num++;
			}
		}
		catch (Exception)
		{
			Debug.Log("Save System: DiskSavedGameDataStorer - Error reading file: " + savedGameInfoFilename);
		}
	}

	public virtual void UpdateSavedGameInfoToFile(int slotNumber, SavedGameData savedGameData)
	{
		for (int i = m_savedGameInfo.Count; i <= slotNumber; i++)
		{
			m_savedGameInfo.Add(new SavedGameInfo(string.Empty));
		}
		m_savedGameInfo[slotNumber].sceneName = ((savedGameData != null) ? savedGameData.sceneName : string.Empty);
		string savedGameInfoFilename = GetSavedGameInfoFilename();
		if (debug)
		{
			Debug.Log("Save System: DiskSavedGameDataStorer updating " + savedGameInfoFilename);
		}
		try
		{
			using StreamWriter streamWriter = new StreamWriter(savedGameInfoFilename);
			for (int j = 0; j < m_savedGameInfo.Count; j++)
			{
				streamWriter.WriteLine(m_savedGameInfo[j].sceneName.Replace("\n", "<cr>"));
			}
		}
		catch (Exception)
		{
			Debug.LogError("Save System: DiskSavedGameDataStorer - Can't create file: " + savedGameInfoFilename);
		}
	}

	public override bool HasDataInSlot(int slotNumber)
	{
		if (0 <= slotNumber && slotNumber < m_savedGameInfo.Count)
		{
			return !string.IsNullOrEmpty(m_savedGameInfo[slotNumber].sceneName);
		}
		return false;
	}

	public override void StoreSavedGameData(int slotNumber, SavedGameData savedGameData)
	{
		string text = SaveSystem.Serialize(savedGameData);
		if (debug)
		{
			Debug.Log("Save System: DiskSavedGameDataStorer - Saving " + GetSaveGameFilename(slotNumber) + ": " + text);
		}
		WriteStringToFile(GetSaveGameFilename(slotNumber), encrypt ? EncryptionUtility.Encrypt(text, encryptionPassword) : text);
		UpdateSavedGameInfoToFile(slotNumber, savedGameData);
	}

	public override SavedGameData RetrieveSavedGameData(int slotNumber)
	{
		string text = ReadStringFromFile(GetSaveGameFilename(slotNumber));
		if (encrypt)
		{
			text = (EncryptionUtility.TryDecrypt(text, encryptionPassword, out var plainText) ? plainText : string.Empty);
		}
		if (debug)
		{
			Debug.Log("Save System: DiskSavedGameDataStorer - Loading " + GetSaveGameFilename(slotNumber) + ": " + text);
		}
		return SaveSystem.Deserialize<SavedGameData>(text);
	}

	public override void DeleteSavedGameData(int slotNumber)
	{
		try
		{
			string saveGameFilename = GetSaveGameFilename(slotNumber);
			if (File.Exists(saveGameFilename))
			{
				File.Delete(saveGameFilename);
			}
		}
		catch (Exception)
		{
		}
		UpdateSavedGameInfoToFile(slotNumber, null);
	}

	public static void WriteStringToFile(string filename, string data)
	{
		try
		{
			using StreamWriter streamWriter = new StreamWriter(filename);
			streamWriter.WriteLine(data);
		}
		catch (Exception)
		{
			Debug.LogError("Save System: Can't create file: " + filename);
		}
	}

	public static string ReadStringFromFile(string filename)
	{
		try
		{
			using StreamReader streamReader = new StreamReader(filename);
			return streamReader.ReadToEnd();
		}
		catch (Exception)
		{
			Debug.Log("Save System: Error reading file: " + filename);
			return string.Empty;
		}
	}
}
