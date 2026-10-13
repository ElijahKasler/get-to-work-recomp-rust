using System;

namespace Rewired;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
internal struct HardwareControllerMapIdentifier(Guid P_0, InputSource P_1, InputPlatform P_2, int P_3)
{
	public readonly Guid guid = P_0;

	public readonly InputSource inputSource = P_1;

	public readonly InputPlatform actualInputPlatform = P_2;

	public readonly int variantIndex = P_3;

	public static bool Matches(HardwareControllerMapIdentifier a, HardwareControllerMapIdentifier b)
	{
		if (a.guid == b.guid && a.inputSource == b.inputSource && a.actualInputPlatform == b.actualInputPlatform)
		{
			return a.variantIndex == b.variantIndex;
		}
		return false;
	}
}
