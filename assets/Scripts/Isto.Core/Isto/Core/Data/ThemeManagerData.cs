using System;

namespace Isto.Core.Data;

[Serializable]
public class ThemeManagerData
{
	public string themeInternalName;

	public string playerSetInternalName;

	public string playerHatInternalName;

	public string playerBodyInternalName;

	public string miniDeerInternalName;

	public string pushbackInternalName;

	public string itemGroupInternalName;

	public override bool Equals(object obj)
	{
		if (!(obj is ThemeManagerData themeManagerData))
		{
			return false;
		}
		if (!themeInternalName.IsEqualWithNullsAsEmpty(themeManagerData.themeInternalName))
		{
			return false;
		}
		if (!playerSetInternalName.IsEqualWithNullsAsEmpty(themeManagerData.playerSetInternalName))
		{
			return false;
		}
		if (!playerHatInternalName.IsEqualWithNullsAsEmpty(themeManagerData.playerHatInternalName))
		{
			return false;
		}
		if (!playerBodyInternalName.IsEqualWithNullsAsEmpty(themeManagerData.playerBodyInternalName))
		{
			return false;
		}
		if (!miniDeerInternalName.IsEqualWithNullsAsEmpty(themeManagerData.miniDeerInternalName))
		{
			return false;
		}
		if (!pushbackInternalName.IsEqualWithNullsAsEmpty(themeManagerData.pushbackInternalName))
		{
			return false;
		}
		return itemGroupInternalName.IsEqualWithNullsAsEmpty(themeManagerData.itemGroupInternalName);
	}

	public override int GetHashCode()
	{
		return (themeInternalName, playerSetInternalName, playerHatInternalName, playerBodyInternalName, miniDeerInternalName, pushbackInternalName, itemGroupInternalName).GetHashCode();
	}
}
