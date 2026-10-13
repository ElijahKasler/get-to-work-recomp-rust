using System;
using System.Runtime.InteropServices;

namespace Unity.XGamingRuntime.Interop;

internal static class XblInterop
{
	internal delegate void XblAchievementsProgressChangeHandler(XblAchievementProgressChangeEventArgs eventArgs, IntPtr context);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XblMultiplayerSessionChangedHandler(IntPtr context, XblMultiplayerSessionChangeEventArgs args);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XblMultiplayerSessionSubscriptionLostHandler(IntPtr context);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XblMultiplayerConnectionIdChangedHandler(IntPtr context);

	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate void XblStatisticChangedHandler(XblStatisticChangeEventArgs statisticChangeEventArgs, IntPtr context);

	public const string XblThunkDllName = "Microsoft.Xbox.Services.GDK.C.Thunks";

	public const string HttpClientGdkDll = "libHttpClient.GDK";

	internal const int XBL_COLOR_CHAR_SIZE = 21;

	internal const int XBL_DISPLAY_NAME_CHAR_SIZE = 90;

	internal const int XBL_DISPLAY_PIC_URL_RAW_CHAR_SIZE = 675;

	internal const int XBL_GAMERSCORE_CHAR_SIZE = 48;

	internal const int XBL_GAMERTAG_CHAR_SIZE = 48;

	internal const int XBL_MODERN_GAMERTAG_CHAR_SIZE = 97;

	internal const int XBL_MODERN_GAMERTAG_SUFFIX_CHAR_SIZE = 15;

	internal const int XBL_UNIQUE_MODERN_GAMERTAG_CHAR_SIZE = 101;

	internal const int XBL_NUM_PRESENCE_RECORDS = 6;

	internal const int XBL_REAL_NAME_CHAR_SIZE = 765;

	internal const int XBL_RICH_PRESENCE_CHAR_SIZE = 300;

	internal const int XBL_TITLE_NAME_CHAR_SIZE = 300;

	internal const int XBL_XBOX_USER_ID_CHAR_SIZE = 63;

	internal const int XBL_GUID_LENGTH = 40;

	internal const int XBL_SCID_LENGTH = 40;

	internal const int XBL_SOCIAL_MANAGER_MAX_AFFECTED_USERS_PER_EVENT = 10;

	internal const int XBL_MULTIPLAYER_SESSION_TEMPLATE_NAME_MAX_LENGTH = 100;

	internal const int XBL_MULTIPLAYER_SESSION_NAME_MAX_LENGTH = 100;

	internal const int XBL_MULTIPLAYER_SESSION_REFERENCE_URI_MAX_LENGTH = 284;

	internal const int XBL_MULTIPLAYER_SEARCH_HANDLE_MAX_FIELD_LENGTH = 100;

	internal const int XBL_TITLE_STORAGE_MIN_UPLOAD_BLOCK_SIZE = 1024;

	internal const int XBL_TITLE_STORAGE_MAX_UPLOAD_BLOCK_SIZE = 4194304;

	internal const int XBL_TITLE_STORAGE_DEFAULT_UPLOAD_BLOCK_SIZE = 262144;

	internal const int XBL_TITLE_STORAGE_MIN_DOWNLOAD_BLOCK_SIZE = 1024;

	internal const int XBL_TITLE_STORAGE_DEFAULT_DOWNLOAD_BLOCK_SIZE = 1048576;

	internal const int XBL_TITLE_STORAGE_BLOB_PATH_MAX_LENGTH = 771;

	internal const int XBL_TITLE_STORAGE_BLOB_DISPLAY_NAME_MAX_LENGTH = 387;

	internal const int XBL_TITLE_STORAGE_BLOB_ETAG_MAX_LENGTH = 54;

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsResultGetAchievements(IntPtr resultHandle, out IntPtr achievements, out SizeT achievementsCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsResultHasNext(IntPtr resultHandle, [MarshalAs(UnmanagedType.U1)] out bool hasNext);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsResultGetNextAsync(IntPtr resultHandle, uint maxItems, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsResultGetNextResult(XAsyncBlockPtr asyncBlock, out XblAchievementsResultHandle resultHandle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsGetAchievementsForTitleIdAsync(IntPtr xboxLiveContext, ulong xboxUserId, uint titleId, XblAchievementType type, [MarshalAs(UnmanagedType.U1)] bool unlockedOnly, XblAchievementOrderBy orderBy, uint skipItems, uint maxItems, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsGetAchievementsForTitleIdResult(XAsyncBlockPtr asyncBlock, out XblAchievementsResultHandle result);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsUpdateAchievementAsync(IntPtr xboxLiveContext, ulong xboxUserId, byte[] achievementId, uint percentComplete, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsUpdateAchievementForTitleIdAsync(IntPtr xboxLiveContext, ulong xboxUserId, uint titleId, byte[] serviceConfigurationId, byte[] achievementId, uint percentComplete, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsGetAchievementAsync(IntPtr xboxLiveContext, ulong xboxUserId, byte[] serviceConfigurationId, byte[] achievementId, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsGetAchievementResult(XAsyncBlockPtr asyncBlock, out XblAchievementsResultHandle result);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern XblFunctionContext XblAchievementsAddAchievementProgressChangeHandler(IntPtr xblContext, XblAchievementsProgressChangeHandler handler, IntPtr handlerContext);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XblAchievementsRemoveAchievementProgressChangeHandler(IntPtr xblContextHandle, XblFunctionContext functionContext);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsResultDuplicateHandle(IntPtr handle, out XblAchievementsResultHandle duplicatedHandle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XblAchievementsResultCloseHandle(IntPtr handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsManagerResultGetAchievements(IntPtr resultHandle, out IntPtr achievements, out ulong achievementsCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsManagerResultDuplicateHandle(IntPtr handle, out XblAchievementsManagerResultHandle duplicatedHandle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XblAchievementsManagerResultCloseHandle(IntPtr handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsManagerAddLocalUser(IntPtr user, XTaskQueueHandle queue);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsManagerRemoveLocalUser(IntPtr user);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsManagerIsUserInitialized(ulong xboxUserId);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsManagerDoWork(out IntPtr achievementsEvents, out SizeT achievementsEventsCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsManagerGetAchievement(ulong xboxUserId, byte[] achievementId, out XblAchievementsManagerResultHandle achievementResult);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsManagerGetAchievements(ulong xboxUserId, XblAchievementOrderBy sortField, XblAchievementsManagerSortOrder sortOrder, out XblAchievementsManagerResultHandle achievementsResult);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsManagerGetAchievementsByState(ulong xboxUserId, XblAchievementOrderBy sortField, XblAchievementsManagerSortOrder sortOrder, XblAchievementProgressState achievementState, out XblAchievementsManagerResultHandle achievementResult);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblAchievementsManagerUpdateAchievement(ulong xboxUserId, byte[] achievementId, byte currentProgress);

	[DllImport("libHttpClient.GDK", CallingConvention = CallingConvention.StdCall)]
	internal static extern int HCSettingsSetTraceLevel(HCTraceLevel traceLevel);

	[DllImport("libHttpClient.GDK", CallingConvention = CallingConvention.StdCall)]
	internal static extern int HCSettingsGetTraceLevel(out HCTraceLevel traceLevel);

	[DllImport("libHttpClient.GDK", CallingConvention = CallingConvention.StdCall)]
	internal static extern void HCTraceSetClientCallback(HCTraceCallback callback);

	[DllImport("libHttpClient.GDK", CallingConvention = CallingConvention.StdCall)]
	internal static extern void HCTraceSetTraceToDebugger([MarshalAs(UnmanagedType.U1)] bool traceToDebugger);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallRequestSetRequestBodyBytes(IntPtr call, byte[] requestBodyBytes, uint requestBodySize);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallGetNetworkErrorCode(IntPtr call, out int networkErrorCode, out uint platformNetworkErrorCode);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallRequestSetLongHttpCall(IntPtr call, NativeBool longHttpCall);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallPerformAsync(IntPtr call, XblHttpCallResponseBodyType type, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallSetTracing(IntPtr call, NativeBool traceCall);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallCreate(IntPtr xblContext, byte[] method, byte[] url, out XblHttpCallHandle call);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XblHttpCallCloseHandle(IntPtr call);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallRequestSetRequestBodyString(IntPtr call, byte[] requestBodyString);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallGetResponseString(IntPtr call, out UTF8StringPtr responseString);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallGetHeaderAtIndex(IntPtr call, uint headerIndex, out UTF8StringPtr headerName, out UTF8StringPtr headerValue);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallGetResponseBodyBytesSize(IntPtr call, out SizeT bufferSize);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallGetPlatformNetworkErrorMessage(IntPtr call, out UTF8StringPtr platformNetworkErrorMessage);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallGetResponseBodyBytes(IntPtr call, SizeT bufferSize, [Out] byte[] buffer, out SizeT bufferUsed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallRequestSetRetryAllowed(IntPtr call, NativeBool retryAllowed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallRequestSetHeader(IntPtr call, byte[] headerName, byte[] headerValue, NativeBool allowTracing);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallDuplicateHandle(IntPtr call, out XblHttpCallHandle duplicateHandle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallGetNumHeaders(IntPtr call, out uint numHeaders);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallGetStatusCode(IntPtr call, out uint statusCode);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallGetHeader(IntPtr call, byte[] headerName, out UTF8StringPtr headerValue);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallGetRequestUrl(IntPtr call, out UTF8StringPtr url);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblHttpCallRequestSetRetryCacheId(IntPtr call, uint retryAfterCacheId);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblLeaderboardGetLeaderboardAsync(IntPtr xboxLiveContext, XblLeaderboardQuery leaderboardQuery, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblLeaderboardGetLeaderboardResultSize(XAsyncBlockPtr asyncBlockPtr, out SizeT resultSizeInBytes);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblLeaderboardGetLeaderboardResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblLeaderboardResultGetNextAsync(IntPtr xboxLiveContext, [In] ref XblLeaderboardResult leaderboardResult, uint maxItems, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblLeaderboardResultGetNextResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblLeaderboardResultGetNextResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMatchmakingCreateMatchTicketAsync(IntPtr xboxLiveContext, XblMultiplayerSessionReference ticketSessionReference, byte[] matchmakingServiceConfigurationId, byte[] hopperName, ulong ticketTimeout, XblPreserveSessionMode preserveSession, byte[] ticketAttributesJson, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMatchmakingCreateMatchTicketResult(XAsyncBlockPtr async, out XblCreateMatchTicketResponse resultPtr);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMatchmakingDeleteMatchTicketAsync(IntPtr xboxLiveContext, byte[] serviceConfigurationId, byte[] hopperName, byte[] ticketId, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMatchmakingGetMatchTicketDetailsAsync(IntPtr xboxLiveContext, byte[] serviceConfigurationId, byte[] hopperName, byte[] ticketId, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMatchmakingGetMatchTicketDetailsResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMatchmakingGetMatchTicketDetailsResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMatchmakingGetHopperStatisticsAsync(IntPtr xboxLiveContext, byte[] serviceConfigurationId, byte[] hopperName, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMatchmakingGetHopperStatisticsResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMatchmakingGetHopperStatisticsResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern XblMultiplayerSessionHandle XblMultiplayerSessionCreateHandle(ulong xboxUserId, [In] ref XblMultiplayerSessionReference sessionRef, [In] ref XblMultiplayerSessionInitArgs initArgs);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern void XblMultiplayerSessionCloseHandle(IntPtr handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern TimeT XblMultiplayerSessionTimeOfSession(IntPtr handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal unsafe static extern XblMultiplayerSessionInitializationInfo* XblMultiplayerSessionGetInitializationInfo(IntPtr handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern XblMultiplayerSessionChangeTypes XblMultiplayerSessionSubscribedChangeTypes(IntPtr handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSessionHostCandidates(IntPtr handle, out IntPtr deviceTokens, out SizeT deviceTokensCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal unsafe static extern XblMultiplayerSessionReference* XblMultiplayerSessionSessionReference(IntPtr handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal unsafe static extern XblMultiplayerSessionConstants* XblMultiplayerSessionSessionConstants(IntPtr handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern void XblMultiplayerSessionConstantsSetMaxMembersInSession(IntPtr handle, uint maxMembersInSession);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern void XblMultiplayerSessionConstantsSetVisibility(IntPtr handle, XblMultiplayerSessionVisibility visibility);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSessionConstantsSetTimeouts(IntPtr handle, ulong memberReservedTimeout, ulong memberInactiveTimeout, ulong memberReadyTimeout, ulong sessionEmptyTimeout);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSessionConstantsSetQosConnectivityMetrics(IntPtr handle, NativeBool enableLatencyMetric, NativeBool enableBandwidthDownMetric, NativeBool enableBandwidthUpMetric, NativeBool enableCustomMetric);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSessionConstantsSetMemberInitialization(IntPtr handle, XblMultiplayerMemberInitialization memberInitialization);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSessionConstantsSetPeerToPeerRequirements(IntPtr handle, XblMultiplayerPeerToPeerRequirements requirements);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSessionConstantsSetMeasurementServerAddressesJson(IntPtr handle, byte[] measurementServerAddressesJson);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerSessionConstantsSetCapabilities(IntPtr handle, XblMultiplayerSessionCapabilities capabilities);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal unsafe static extern XblMultiplayerSessionProperties* XblMultiplayerSessionSessionProperties(IntPtr handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerSessionPropertiesSetKeywords(IntPtr handle, IntPtr keywords, SizeT keywordsCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern void XblMultiplayerSessionPropertiesSetJoinRestriction(IntPtr handle, XblMultiplayerSessionRestriction joinRestriction);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern void XblMultiplayerSessionPropertiesSetReadRestriction(IntPtr handle, XblMultiplayerSessionRestriction readRestriction);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerSessionPropertiesSetTurnCollection(IntPtr handle, [In] uint[] turnCollectionMemberIds, SizeT turnCollectionMemberIdsCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerSessionMembers(IntPtr handle, out IntPtr members, out SizeT membersCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal unsafe static extern XblMultiplayerMatchmakingServer* XblMultiplayerSessionMatchmakingServer(IntPtr handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal unsafe static extern XblMultiplayerSessionMember* XblMultiplayerSessionCurrentUser(IntPtr handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern XblWriteSessionStatus XblMultiplayerSessionWriteStatus(IntPtr handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSessionJoin(IntPtr handle, byte[] memberCustomConstantsJson, [MarshalAs(UnmanagedType.U1)] bool initializeRequested, [MarshalAs(UnmanagedType.U1)] bool joinWithActiveStatus);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern void XblMultiplayerSessionSetHostDeviceToken(IntPtr handle, XblDeviceToken hostDeviceToken);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern void XblMultiplayerSessionSetClosed(IntPtr handle, [MarshalAs(UnmanagedType.U1)] bool closed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSessionSetSessionChangeSubscription(IntPtr handle, XblMultiplayerSessionChangeTypes changeTypes);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSessionLeave(IntPtr handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSessionCurrentUserSetRoles(IntPtr handle, IntPtr roles, SizeT rolesCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSessionCurrentUserSetEncounters(IntPtr handle, IntPtr encounters, SizeT encountersCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSessionCurrentUserSetMembersInGroup(IntPtr handle, uint[] memberIds, SizeT memberIdsCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSessionCurrentUserSetGroups(IntPtr handle, IntPtr groups, SizeT groupsCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSessionCurrentUserSetCustomPropertyJson(IntPtr handle, byte[] name, byte[] valueJson);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSessionCurrentUserDeleteCustomPropertyJson(IntPtr handle, byte[] name);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSessionCurrentUserSetStatus(IntPtr handle, XblMultiplayerSessionMemberStatus status);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSessionCurrentUserSetSecureDeviceAddressBase64(IntPtr handle, byte[] value);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblFormatSecureDeviceAddress(byte[] deviceId, out XblFormattedSecureDeviceAddress address);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSearchHandleDuplicateHandle([In] XblMultiplayerSearchHandle handle, out XblMultiplayerSearchHandle duplicatedHandle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern void XblMultiplayerSearchHandleCloseHandle(IntPtr handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSearchHandleGetSessionReference([In] IntPtr handle, out XblMultiplayerSessionReference sessionRef);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSearchHandleGetId([In] IntPtr handle, out UTF8StringPtr id);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSearchHandleGetSessionOwnerXuids([In] IntPtr handle, out IntPtr xuids, out SizeT xuidsCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSearchHandleGetTags([In] IntPtr handle, out IntPtr tags, out SizeT tagsCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSearchHandleGetStringAttributes([In] IntPtr handle, out IntPtr attributes, out SizeT attributesCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSearchHandleGetNumberAttributes([In] IntPtr handle, out IntPtr attributes, out SizeT attributesCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSearchHandleGetVisibility([In] IntPtr handle, out XblMultiplayerSessionVisibility visibility);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSearchHandleGetJoinRestriction([In] IntPtr handle, out XblMultiplayerSessionRestriction joinRestriction);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSearchHandleGetSessionClosed([In] IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool closed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSearchHandleGetMemberCounts([In] IntPtr handle, out SizeT maxMembers, out SizeT currentMembers);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSearchHandleGetCreationTime([In] IntPtr handle, out TimeT creationTime);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSearchHandleGetCustomSessionPropertiesJson([In] IntPtr handle, out UTF8StringPtr customPropertiesJson);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerWriteSessionAsync(IntPtr xblContext, IntPtr multiplayerSession, XblMultiplayerSessionWriteMode writeMode, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerWriteSessionResult(XAsyncBlockPtr async, out XblMultiplayerSessionHandle handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerWriteSessionByHandleAsync(IntPtr xblContext, IntPtr multiplayerSession, XblMultiplayerSessionWriteMode writeMode, byte[] handleId, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerWriteSessionByHandleResult(XAsyncBlockPtr async, out XblMultiplayerSessionHandle handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerGetSessionAsync(IntPtr xblContext, [In] ref XblMultiplayerSessionReference sessionRef, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerGetSessionResult(XAsyncBlockPtr async, out XblMultiplayerSessionHandle handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerGetSessionByHandleAsync(IntPtr xblContext, byte[] handleId, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerGetSessionByHandleResult(XAsyncBlockPtr async, out XblMultiplayerSessionHandle handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerQuerySessionsAsync(IntPtr xblContext, [In] ref XblMultiplayerSessionQuery sessionQuery, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerQuerySessionsResultCount(XAsyncBlockPtr async, out SizeT sessionCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerQuerySessionsResult(XAsyncBlockPtr async, SizeT sessionCount, [Out] XblMultiplayerSessionQueryResult[] sessions);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerSetActivityAsync(IntPtr xblContext, [In] ref XblMultiplayerSessionReference sessionReference, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerClearActivityAsync(IntPtr xblContext, byte[] scid, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerSetTransferHandleAsync(IntPtr xblContext, [In] ref XblMultiplayerSessionReference targetSessionReference, [In] ref XblMultiplayerSessionReference originSessionReference, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSetTransferHandleResult(XAsyncBlockPtr async, out XblMultiplayerSessionHandleId handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerCreateSearchHandleAsync(IntPtr xblContext, [In] ref XblMultiplayerSessionReference sessionRef, [Optional] XblMultiplayerSessionTag[] tags, SizeT tagsCount, [Optional] XblMultiplayerSessionNumberAttribute[] numberAttributes, SizeT numberAttributesCount, [Optional] XblMultiplayerSessionStringAttribute[] stringAttributes, SizeT stringAttributesCount, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerCreateSearchHandleResult(XAsyncBlockPtr async, out XblMultiplayerSearchHandle handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerDeleteSearchHandleAsync(IntPtr xblContext, byte[] handleId, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerGetSearchHandlesAsync(IntPtr xblContext, byte[] scid, byte[] sessionTemplateName, [Optional] byte[] orderByAttribute, [MarshalAs(UnmanagedType.U1)] bool orderAscending, [Optional] byte[] searchFilter, [Optional] byte[] socialGroup, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerGetSearchHandlesResultCount(XAsyncBlockPtr async, out SizeT searchHandleCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerGetSearchHandlesResult(XAsyncBlockPtr async, [Out] XblMultiplayerSearchHandle[] searchHandles, SizeT searchHandleCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSendInvitesAsync(IntPtr xblContext, [In] ref XblMultiplayerSessionReference sessionRef, [In] ulong[] xuids, SizeT xuidsCount, uint titleId, [Optional] byte[] contextStringId, [Optional] byte[] customActivationContext, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSendInvitesResult(XAsyncBlockPtr async, SizeT handlesCount, [Out] XblMultiplayerInviteHandle[] handles);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerGetActivitiesForSocialGroupAsync(IntPtr xboxLiveContext, byte[] scid, ulong socialGroupOwnerXuid, byte[] socialGroup, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerGetActivitiesWithPropertiesForSocialGroupAsync(IntPtr xboxLiveContext, byte[] scid, ulong socialGroupOwnerXuid, byte[] socialGroup, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerGetActivitiesForSocialGroupResultCount(XAsyncBlockPtr async, out SizeT activityCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerGetActivitiesForSocialGroupResult(XAsyncBlockPtr async, SizeT activityCount, [Out] XblMultiplayerActivityDetails[] activities);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerGetActivitiesWithPropertiesForSocialGroupResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerGetActivitiesWithPropertiesForSocialGroupResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT ptrToBufferCount, out SizeT bufferUsed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerGetActivitiesForUsersAsync(IntPtr xboxLiveContext, byte[] scid, [In] ulong[] xuids, SizeT xuidsCount, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerGetActivitiesWithPropertiesForUsersAsync(IntPtr xboxLiveContext, byte[] scid, [In] ulong[] xuids, SizeT xuidsCount, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerGetActivitiesForUsersResultCount(XAsyncBlockPtr async, out SizeT activityCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerGetActivitiesForUsersResult(XAsyncBlockPtr async, SizeT activityCount, [Out] XblMultiplayerActivityDetails[] activities);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerGetActivitiesWithPropertiesForUsersResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerGetActivitiesWithPropertiesForUsersResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT ptrToBufferCount, out SizeT bufferUsed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblMultiplayerSetSubscriptionsEnabled(IntPtr xblContext, [MarshalAs(UnmanagedType.U1)] bool subscriptionsEnabled);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool XblMultiplayerSubscriptionsEnabled(IntPtr xblHandle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern XblFunctionContext XblMultiplayerAddSessionChangedHandler(IntPtr xblContext, XblMultiplayerSessionChangedHandler handler, IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerRemoveSessionChangedHandler(IntPtr xblContext, XblFunctionContext token);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern XblFunctionContext XblMultiplayerAddSubscriptionLostHandler(IntPtr xblContext, XblMultiplayerSessionSubscriptionLostHandler handler, IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerRemoveSubscriptionLostHandler(IntPtr xblContext, XblFunctionContext token);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerSessionSetCustomPropertyJson(IntPtr handle, byte[] name, byte[] valueJson);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerSessionDeleteCustomPropertyJson(IntPtr handle, byte[] name);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern XblMultiplayerSessionChangeTypes XblMultiplayerSessionCompare(IntPtr currentSessionHandle, IntPtr oldSessionHandle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern XblFunctionContext XblMultiplayerAddConnectionIdChangedHandler(IntPtr xblContext, XblMultiplayerConnectionIdChangedHandler handler, IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerRemoveConnectionIdChangedHandler(IntPtr xblContext, XblFunctionContext token);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerActivityUpdateRecentPlayers(IntPtr xboxLiveContext, [Optional] XblMultiplayerActivityRecentPlayerUpdate[] updates, SizeT updatesCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerActivityFlushRecentPlayersAsync(IntPtr xboxLiveContext, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerActivitySetActivityAsync(IntPtr xboxLiveContext, [In] ref XblMultiplayerActivityInfo activityInfo, [MarshalAs(UnmanagedType.U1)] bool allowCrossPlatformJoin, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerActivityGetActivityAsync(IntPtr xboxLiveContext, [In] ulong[] xboxUserIdList, SizeT xboxUserIdListCount, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerActivityGetActivityResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerActivityGetActivityResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBufferResults, out SizeT resultCount, out SizeT bufferUsed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerActivityDeleteActivityAsync(IntPtr xboxLiveContext, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerActivitySendInvitesAsync(IntPtr xblContext, [In] ulong[] xboxUserIdList, SizeT xboxUserIdListCount, [MarshalAs(UnmanagedType.U1)] bool allowCrossPlatformJoin, byte[] connectionString, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerLobbySessionHost(out XblMultiplayerManagerMember hostMember);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerEventArgsTournamentRegistrationStateChanged(IntPtr argsHandle, out XblTournamentRegistrationState registrationState, out XblTournamentRegistrationReason registrationReason);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern XblMultiplayerSessionReference XblMultiplayerSessionReferenceCreate(byte[] scid, byte[] sessionTemplateName, byte[] sessionName);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerEventArgsFindMatchCompleted(IntPtr argsHandle, out XblMultiplayerMatchStatus matchStatus, out XblMultiplayerMeasurementFailure initializationFailureCause);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerLobbySessionInviteUsers(IntPtr user, [In] ulong[] xuids, SizeT xuidsCount, byte[] contextStringId, byte[] customActivationContext);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerJoinLobby(byte[] handleId, IntPtr user);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerLobbySessionInviteFriends(IntPtr requestingUser, byte[] contextStringId, byte[] customActivationContext);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerSetQosMeasurements(byte[] measurementsJson);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerSetJoinability(XblMultiplayerJoinability joinability, IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerLobbySessionAddLocalUser(IntPtr user);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerEventArgsMembersCount(IntPtr argsHandle, out SizeT memberCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerJoinGameFromLobby(byte[] sessionTemplateName);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern NativeBool XblMultiplayerManagerGameSessionIsHost(ulong xuid);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerEventArgsPropertiesJson(IntPtr argsHandle, out UTF8StringPtr properties);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerGameSessionHost(out XblMultiplayerManagerMember hostMember);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerLobbySessionSessionReference(out XblMultiplayerSessionReference sessionReference);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerLobbySessionSetProperties(byte[] name, byte[] valueJson, IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XblMultiplayerManagerSetAutoFillMembersDuringMatchmaking(NativeBool autoFillMembers);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerLobbySessionSetLocalMemberProperties(IntPtr user, byte[] name, byte[] valueJson, IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerLobbySessionSetSynchronizedProperties(byte[] name, byte[] valueJson, IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal unsafe static extern XblMultiplayerSessionReference* XblMultiplayerManagerGameSessionSessionReference();

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerEventArgsXuid(IntPtr argsHandle, out ulong xuid);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerGameSessionSetProperties(byte[] name, byte[] valueJson, IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerLobbySessionMembers(SizeT membersCount, [Out] XblMultiplayerManagerMember[] members);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern XblMultiplayerJoinability XblMultiplayerManagerJoinability();

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern UTF8StringPtr XblMultiplayerManagerLobbySessionPropertiesJson();

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XblMultiplayerManagerCancelMatch();

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern uint XblMultiplayerManagerEstimatedMatchWaitTime();

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal unsafe static extern XblMultiplayerSessionConstants* XblMultiplayerManagerLobbySessionConstants();

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerEventArgsTournamentGameSessionReady(IntPtr argsHandle, out TimeT startTime);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern SizeT XblMultiplayerManagerLobbySessionLocalMembersCount();

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern NativeBool XblMultiplayerManagerGameSessionActive();

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerInitialize(byte[] lobbySessionTemplateName, XTaskQueueHandle asyncQueue);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerLobbySessionRemoveLocalUser(IntPtr user);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerLobbySessionDeleteLocalMemberProperties(IntPtr user, byte[] name, IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerEventArgsMember(IntPtr argsHandle, out XblMultiplayerManagerMember member);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern NativeBool XblMultiplayerManagerMemberAreMembersOnSameDevice([In] ref XblMultiplayerManagerMember first, [In] ref XblMultiplayerManagerMember second);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerGameSessionSetSynchronizedHost(byte[] deviceToken, IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal unsafe static extern XblTournamentTeamResult* XblMultiplayerManagerLobbySessionLastTournamentTeamResult();

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerSessionReferenceParseFromUriPath(byte[] path, out XblMultiplayerSessionReference sessionReference);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerSessionReferenceToUriPath(XblMultiplayerSessionReference sessionReference, out XblMultiplayerSessionReferenceUri sessionReferenceUri);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerLeaveGame();

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerEventArgsMembers(IntPtr argsHandle, SizeT membersCount, [Out] XblMultiplayerManagerMember[] members);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern NativeBool XblMultiplayerManagerLobbySessionIsHost(ulong xuid);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerGameSessionSetSynchronizedProperties(byte[] name, byte[] valueJson, IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern UTF8StringPtr XblMultiplayerManagerGameSessionCorrelationId();

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal unsafe static extern XblMultiplayerSessionConstants* XblMultiplayerManagerGameSessionConstants();

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerLobbySessionLocalMembers(SizeT localMembersCount, [Out] XblMultiplayerManagerMember[] localMembers);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern XblMultiplayerMatchStatus XblMultiplayerManagerMatchStatus();

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerLobbySessionSetSynchronizedHost(byte[] deviceToken, IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern NativeBool XblMultiplayerManagerAutoFillMembersDuringMatchmaking();

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerLobbySessionCorrelationId(out XblGuid correlationId);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern SizeT XblMultiplayerManagerLobbySessionMembersCount();

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerFindMatch(byte[] hopperName, byte[] attributesJson, uint timeoutInSeconds);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerDoWork(out IntPtr multiplayerEvents, out SizeT multiplayerEventsCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern NativeBool XblMultiplayerSessionReferenceIsValid([In] ref XblMultiplayerSessionReference sessionReference);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerGameSessionMembers(SizeT membersCount, [Out] XblMultiplayerManagerMember[] members);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerLobbySessionSetLocalMemberConnectionAddress(IntPtr user, byte[] connectionAddress, IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerManagerJoinGame(byte[] sessionName, byte[] sessionTemplateName, [In] ulong[] xuids, SizeT xuidsCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern SizeT XblMultiplayerManagerGameSessionMembersCount();

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern UTF8StringPtr XblMultiplayerManagerGameSessionPropertiesJson();

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblMultiplayerEventArgsPerformQoSMeasurements(IntPtr argsHandle, out XblMultiplayerPerformQoSMeasurementsArgs performQoSMeasurementsArgs);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceRecordGetXuid(IntPtr handle, out ulong xuid);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceRecordGetUserState(IntPtr handle, out XblPresenceUserState userState);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceRecordGetDeviceRecords(IntPtr handle, out IntPtr deviceRecords, out SizeT deviceRecordsCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceRecordDuplicateHandle(IntPtr handle, out XblPresenceRecordHandle duplicatedHandle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XblPresenceRecordCloseHandle(IntPtr handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceSetPresenceAsync(IntPtr xblContextHandle, [MarshalAs(UnmanagedType.U1)] bool isUserActiveInTitle, [Optional] XblPresenceRichPresenceIdsRef richPresenceIds, XAsyncBlockPtr asyncBlockPtr);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceGetPresenceAsync(IntPtr xblContextHandle, ulong xuid, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceGetPresenceResult(XAsyncBlockPtr asyncBlock, out XblPresenceRecordHandle presenceRecordHandle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceGetPresenceForMultipleUsersAsync(IntPtr xblContextHandle, ulong[] xuids, SizeT xuidsCount, [Optional] XblPresenceQueryFiltersRef filters, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceGetPresenceForMultipleUsersResultCount(XAsyncBlockPtr asyncBlock, out SizeT resultCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceGetPresenceForMultipleUsersResult(XAsyncBlockPtr asyncBlock, [Out] XblPresenceRecordHandle[] presenceRecordHandles, SizeT presenceRecordHandlesCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceGetPresenceForSocialGroupAsync(IntPtr xblContextHandle, byte[] socialGroupName, [Optional] UInt64Ref socialGroupOwnerXuid, [Optional] XblPresenceQueryFiltersRef filters, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceGetPresenceForSocialGroupResultCount(XAsyncBlockPtr asyncBlock, out SizeT resultCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceGetPresenceForSocialGroupResult(XAsyncBlockPtr asyncBlock, [Out] XblPresenceRecordHandle[] presenceRecordHandles, SizeT presenceRecordHandlesCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceSubscribeToDevicePresenceChange(XblContextHandle xblContextHandle, ulong xuid, out XblRealTimeActivitySubscriptionHandle subscriptionHandle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceUnsubscribeFromDevicePresenceChange(XblContextHandle xblContextHandle, XblRealTimeActivitySubscriptionHandle subscriptionHandle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceSubscribeToTitlePresenceChange(XblContextHandle xblContextHandle, ulong xuid, uint titleId, out XblRealTimeActivitySubscriptionHandle subscriptionHandle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceUnsubscribeFromTitlePresenceChange(XblContextHandle xblContext, XblRealTimeActivitySubscriptionHandle subscriptionHandle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern XblFunctionContext XblPresenceAddDevicePresenceChangedHandler(XblContextHandle xblContextHandle, XblPresenceDevicePresenceChangedHandler handler, IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceRemoveDevicePresenceChangedHandler(XblContextHandle xblContextHandle, XblFunctionContext token);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern XblFunctionContext XblPresenceAddTitlePresenceChangedHandler(XblContextHandle xblContextHandle, XblPresenceTitlePresenceChangedHandler handler, IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPresenceRemoveTitlePresenceChangedHandler(XblContextHandle xblContextHandle, XblFunctionContext token);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPrivacyGetAvoidListAsync(IntPtr xblContextHandle, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPrivacyGetAvoidListResultCount(XAsyncBlockPtr async, out SizeT xuidCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPrivacyGetAvoidListResult(XAsyncBlockPtr async, SizeT xuidCount, [Out] ulong[] xuids);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPrivacyGetMuteListAsync(IntPtr xblContextHandle, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPrivacyGetMuteListResultCount(XAsyncBlockPtr async, out SizeT xuidCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPrivacyGetMuteListResult(XAsyncBlockPtr async, SizeT xuidCount, [Out] ulong[] xuids);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPrivacyCheckPermissionAsync(IntPtr xblContextHandle, XblPermission permissionToCheck, ulong targetXuid, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPrivacyCheckPermissionResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPrivacyCheckPermissionResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr result, out SizeT bufferUsed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPrivacyCheckPermissionForAnonymousUserAsync(IntPtr xblContextHandle, XblPermission permissionToCheck, XblAnonymousUserType userType, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPrivacyCheckPermissionForAnonymousUserResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPrivacyCheckPermissionForAnonymousUserResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPrivacyBatchCheckPermissionAsync(IntPtr xblContextHandle, [In] XblPermission[] permissionsToCheck, SizeT permissionsCount, [In] ulong[] targetXuids, SizeT xuidsCount, [In] XblAnonymousUserType[] targetAnonymousUserTypes, SizeT targetAnonymousUserTypesCount, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPrivacyBatchCheckPermissionResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblPrivacyBatchCheckPermissionResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr results, out SizeT resultsCount, out SizeT bufferUsed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblProfileGetUserProfileAsync(IntPtr xblContextHandle, ulong xboxUserId, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblProfileGetUserProfileResult(XAsyncBlockPtr async, out XblUserProfile profile);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblProfileGetUserProfilesAsync(IntPtr xblContextHandle, ulong[] xboxUserIds, SizeT xboxUserIdsCount, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblProfileGetUserProfilesResultCount(XAsyncBlockPtr async, out SizeT profileCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblProfileGetUserProfilesResult(XAsyncBlockPtr async, SizeT profilesCount, [Out] XblUserProfile[] profiles);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblProfileGetUserProfilesForSocialGroupAsync(IntPtr xblContextHandle, byte[] socialGroup, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblProfileGetUserProfilesForSocialGroupResultCount(XAsyncBlockPtr async, out SizeT profileCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblProfileGetUserProfilesForSocialGroupResult(XAsyncBlockPtr async, SizeT profilesCount, [Out] XblUserProfile[] profiles);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialGetSocialRelationshipsAsync(IntPtr xboxLiveContext, ulong xboxUserId, XblSocialRelationshipFilter socialRelationshipFilter, SizeT startIndex, SizeT maxItems, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialGetSocialRelationshipsResult(XAsyncBlockPtr async, out XblSocialRelationshipResultHandle handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialRelationshipResultGetRelationships(XblSocialRelationshipResultHandle resultHandle, out IntPtr relationships, out SizeT relationshipsCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialRelationshipResultHasNext(XblSocialRelationshipResultHandle resultHandle, [MarshalAs(UnmanagedType.U1)] out bool hasNext);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialRelationshipResultGetTotalCount(XblSocialRelationshipResultHandle resultHandle, out SizeT totalCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialRelationshipResultGetNextAsync(IntPtr xboxLiveContext, XblSocialRelationshipResultHandle resultHandle, SizeT maxItems, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialRelationshipResultGetNextResult(XAsyncBlockPtr async, out XblSocialRelationshipResultHandle handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialRelationshipResultDuplicateHandle(XblSocialRelationshipResultHandle handle, out XblSocialRelationshipResultHandle duplicatedHandle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XblSocialRelationshipResultCloseHandle(XblSocialRelationshipResultHandle handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	internal static extern int XblSocialAddSocialRelationshipChangedHandler(IntPtr xboxLiveContext, XblSocialRelationshipChangedHandler handler, IntPtr handlerContext);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
	internal static extern int XblSocialRemoveSocialRelationshipChangedHandler(IntPtr xboxLiveContext, int handlerFunctionContext);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.U1)]
	internal static extern bool XblSocialManagerPresenceRecordIsUserPlayingTitle([In] ref XblSocialManagerPresenceRecord presenceRecord, uint titleId);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialManagerUserGroupGetUsers(IntPtr group, out IntPtr xboxSocialUsers, out SizeT usersCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialManagerUserGroupGetUsersTrackedByGroup(IntPtr group, out IntPtr trackedUsers, out SizeT trackedUsersCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialManagerAddLocalUser(IntPtr user, XblSocialManagerExtraDetailLevel extraLevelDetail, XTaskQueueHandle queue);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialManagerRemoveLocalUser(IntPtr user);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialManagerDoWork(out IntPtr socialEvents, out SizeT socialEventsCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialManagerCreateSocialUserGroupFromFilters(IntPtr user, XblPresenceFilter presenceDetailLevel, XblRelationshipFilter filter, out XblSocialManagerUserGroupHandle group);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialManagerCreateSocialUserGroupFromList(IntPtr user, ulong[] xboxUserIdList, SizeT xboxUserIdListCount, out XblSocialManagerUserGroupHandle group);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialManagerDestroySocialUserGroup(IntPtr group);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern SizeT XblSocialManagerGetLocalUserCount();

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialManagerGetLocalUsers(SizeT usersCount, [Out] IntPtr[] users);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialManagerUpdateSocialUserGroup(IntPtr group, ulong[] users, SizeT usersCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialManagerSetRichPresencePollingStatus(IntPtr user, [MarshalAs(UnmanagedType.U1)] bool shouldEnablePolling);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialManagerUserGroupGetType(IntPtr group, out XblSocialUserGroupType type);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialManagerUserGroupGetLocalUser(IntPtr group, out IntPtr localUser);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblSocialManagerUserGroupGetFilters(IntPtr group, out XblPresenceFilter presenceFilter, out XblRelationshipFilter relationshipFilter);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblStringVerifyStringAsync(IntPtr xblContextHandle, byte[] stringToVerify, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblStringVerifyStringResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblStringVerifyStringResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblStringVerifyStringsAsync(IntPtr xblContextHandle, IntPtr stringsToVerify, ulong stringsCount, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblStringVerifyStringsResultSize(XAsyncBlockPtr async, out SizeT resultSizeInBytes);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblStringVerifyStringsResult(XAsyncBlockPtr async, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBufferStrings, out SizeT stringsCount, out SizeT bufferUsed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblTitleManagedStatsWriteAsync(IntPtr xblContextHandle, ulong xboxUserId, [In] XblTitleManagedStatistic[] statistics, SizeT statisticsCount, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblTitleManagedStatsUpdateStatsAsync(IntPtr xblContextHandle, [In] XblTitleManagedStatistic[] statistics, SizeT statisticsCount, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblTitleManagedStatsDeleteStatsAsync(IntPtr xblContextHandle, IntPtr statisticNames, SizeT statisticNamesCount, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblTitleStorageBlobMetadataResultGetItems([In] IntPtr resultHandle, out IntPtr items, out SizeT itemsCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblTitleStorageBlobMetadataResultHasNext([In] IntPtr resultHandle, [MarshalAs(UnmanagedType.U1)] out bool hasNext);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblTitleStorageBlobMetadataResultGetNextAsync([In] IntPtr resultHandle, uint maxItems, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblTitleStorageBlobMetadataResultGetNextResult(XAsyncBlockPtr async, out XblTitleStorageBlobMetadataResultHandle result);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblTitleStorageBlobMetadataResultDuplicateHandle([In] IntPtr handle, out XblTitleStorageBlobMetadataResultHandle duplicatedHandle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblTitleStorageBlobMetadataResultCloseHandle([In] IntPtr handle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblTitleStorageGetQuotaAsync(IntPtr xboxLiveContext, byte[] serviceConfigurationId, XblTitleStorageType storageType, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblTitleStorageGetQuotaResult(XAsyncBlockPtr async, out SizeT usedBytes, out SizeT quotaBytes);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblTitleStorageGetBlobMetadataAsync(IntPtr xboxLiveContext, byte[] serviceConfigurationId, XblTitleStorageType storageType, byte[] blobPath, ulong xboxUserId, uint skipItems, uint maxItems, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblTitleStorageGetBlobMetadataResult(XAsyncBlockPtr async, out XblTitleStorageBlobMetadataResultHandle result);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblTitleStorageDeleteBlobAsync(IntPtr xboxLiveContext, XblTitleStorageBlobMetadata blobMetadata, [MarshalAs(UnmanagedType.U1)] bool deleteOnlyIfEtagMatches, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblTitleStorageDownloadBlobAsync(IntPtr xboxLiveContext, XblTitleStorageBlobMetadata blobMetadata, IntPtr blobBuffer, SizeT blobBufferCount, XblTitleStorageETagMatchCondition etagMatchCondition, byte[] selectQuery, SizeT preferredDownloadBlockSize, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblTitleStorageDownloadBlobResult(XAsyncBlockPtr async, out XblTitleStorageBlobMetadata blobMetadata);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblTitleStorageUploadBlobAsync(IntPtr xboxLiveContext, XblTitleStorageBlobMetadata blobMetadata, IntPtr blobBuffer, SizeT blobBufferCount, XblTitleStorageETagMatchCondition etagMatchCondition, SizeT preferredUploadBlockSize, XAsyncBlockPtr async);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	public static extern int XblTitleStorageUploadBlobResult(XAsyncBlockPtr async, out XblTitleStorageBlobMetadata blobMetadata);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblUserStatisticsGetSingleUserStatisticAsync(IntPtr xblContextHandle, ulong xboxUserId, byte[] serviceConfigurationId, byte[] statisticName, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblUserStatisticsGetSingleUserStatisticResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblUserStatisticsGetSingleUserStatisticResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblUserStatisticsGetSingleUserStatisticsAsync(IntPtr xblContextHandle, ulong xboxUserId, byte[] serviceConfigurationId, IntPtr statisticNames, SizeT statisticNamesCount, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblUserStatisticsGetSingleUserStatisticsResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblUserStatisticsGetSingleUserStatisticsResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT bufferUsed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblUserStatisticsGetMultipleUserStatisticsAsync(IntPtr xblContextHandle, ulong[] xboxUserIds, SizeT xboxUserIdsCount, byte[] serviceConfigurationId, IntPtr statisticNames, SizeT statisticNamesCount, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblUserStatisticsGetMultipleUserStatisticsResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblUserStatisticsGetMultipleUserStatisticsResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr ptrToBuffer, out SizeT resultsCount, out SizeT bufferUsed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsAsync(IntPtr xblContextHandle, ulong[] xboxUserIds, uint xboxUserIdsCount, IntPtr requestedServiceConfigurationStatisticsCollection, uint requestedServiceConfigurationStatisticsCollectionCount, XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsResultSize(XAsyncBlockPtr asyncBlock, out SizeT resultSizeInBytes);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, out IntPtr results, out SizeT resultsCount, out SizeT bufferUsed);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern XblFunctionContext XblUserStatisticsAddStatisticChangedHandler(IntPtr xblContextHandle, XblStatisticChangedHandler handler, IntPtr handlerContext);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XblUserStatisticsRemoveStatisticChangedHandler(IntPtr xblContextHandle, IntPtr context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblUserStatisticsTrackStatistics(XblContextHandle xblContextHandle, ulong[] xboxUserIds, SizeT xboxUserIdsCount, byte[] serviceConfigurationId, IntPtr statisticNames, SizeT statisticNamesCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblUserStatisticsStopTrackingStatistics(XblContextHandle xblContextHandle, ulong[] xboxUserIds, SizeT xboxUserIdsCount, byte[] serviceConfigurationId, IntPtr statisticNames, SizeT statisticNamesCount);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblContextCreateHandle(IntPtr user, out XblContextHandle context);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XblContextCloseHandle(IntPtr xboxLiveContextHandle);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern XblErrorCondition XblGetErrorCondition(int hr);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblEventsWriteInGameEvent(IntPtr xboxLiveContext, byte[] eventName, [Optional] byte[] dimensionsJson, [Optional] byte[] measurementsJson);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblWrapper_XblInitialize(byte[] scid, XTaskQueueHandle internalWorkQueue);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblWrapper_XblCleanupAsync(XAsyncBlockPtr asyncBlock);

	[DllImport("Microsoft.Xbox.Services.GDK.C.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XblCleanupAsync(XAsyncBlockPtr asyncBlock);
}
