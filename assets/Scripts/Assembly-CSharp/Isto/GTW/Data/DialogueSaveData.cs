using System;
using System.Xml.Serialization;

namespace Isto.GTW.Data;

[Serializable]
[XmlRoot("DialogueData")]
public class DialogueSaveData
{
	public string dialogueData;

	public bool ContentEquals(DialogueSaveData other)
	{
		if (other == null)
		{
			return false;
		}
		if (dialogueData != other.dialogueData)
		{
			return false;
		}
		return true;
	}
}
