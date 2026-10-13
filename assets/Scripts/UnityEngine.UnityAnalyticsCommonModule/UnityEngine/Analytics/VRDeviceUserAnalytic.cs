using System;
using System.Runtime.InteropServices;
using UnityEngine.Internal;
using UnityEngine.Scripting;

namespace UnityEngine.Analytics;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[ExcludeFromDocs]
[RequiredByNativeCode(GenerateProxy = true)]
public class VRDeviceUserAnalytic : VRDeviceAnalyticBase
{
	public int vr_user_presence;

	[RequiredByNativeCode]
	internal static VRDeviceUserAnalytic CreateVRDeviceUserAnalytic()
	{
		return new VRDeviceUserAnalytic();
	}
}
