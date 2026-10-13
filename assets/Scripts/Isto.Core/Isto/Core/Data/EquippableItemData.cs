using System;
using System.Xml.Serialization;

namespace Isto.Core.Data;

[Serializable]
[XmlInclude(typeof(TorchItemData))]
public abstract class EquippableItemData
{
	[XmlAttribute("GUID")]
	public string guid;

	[XmlAttribute("Name")]
	public string itemName;

	public EquippableItemData()
	{
	}

	public EquippableItemData(string guid)
	{
		this.guid = guid;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is EquippableItemData equippableItemData))
		{
			return false;
		}
		return guid.IsEqualWithNullsAsEmpty(equippableItemData.guid);
	}

	public override int GetHashCode()
	{
		return (guid, itemName).GetHashCode();
	}
}
