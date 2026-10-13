using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

public static class UserStatistics
{
	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
	public unsafe static extern int XblUserStatisticsAddStatisticChangedHandler(IntPtr xblContextHandle, XblStatisticChangedHandler handler, void* handlerContext);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
	public static extern void XblUserStatisticsRemoveStatisticChangedHandler(IntPtr xblContextHandle, int context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
	public unsafe static extern int XblUserStatisticsTrackStatistics(IntPtr xblContextHandle, ulong* xboxUserIds, UIntPtr xboxUserIdsCount, sbyte* serviceConfigurationId, sbyte** statisticNames, UIntPtr statisticNamesCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
	public unsafe static extern int XblUserStatisticsStopTrackingStatistics(IntPtr xblContextHandle, ulong* xboxUserIds, UIntPtr xboxUserIdsCount, sbyte* serviceConfigurationId, sbyte** statisticNames, UIntPtr statisticNamesCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall, ExactSpelling = true)]
	public unsafe static extern int XblUserStatisticsStopTrackingUsers(IntPtr xblContextHandle, ulong* xboxUserIds, UIntPtr xboxUserIdsCount);
}
