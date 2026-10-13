using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using AOT;
using Unity.XGamingRuntime.Interop;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class SDK
{
	public class XBL
	{
		public delegate void XblAchievementsResultGetNextResult(int hresult, XblAchievementsResultHandle result);

		public delegate void XblAchievementsGetAchievementsForTitleIdResult(int hresult, XblAchievementsResultHandle result);

		public delegate void XblAchievementsUpdateAchievementResult(int hresult);

		public delegate void XblAchievementsUpdateAchievementForTitleIdResult(int hresult);

		public delegate void XblAchievementsGetAchievementResult(int hresult, XblAchievementsResultHandle result);

		public delegate void XblAchievementsProgressChangeHandlerResult(int hresult, XblAchievementProgressChangeEventArgs eventArgs, IntPtr context);

		public delegate void XblMatchmakingCreateMatchTicketHandleResult(int hresult, XblCreateMatchTicketResponse handle);

		public delegate void XblMatchmakingDeleteMatchTicketHandleResult(int hresult);

		public delegate void XblMatchmakingGetMatchTicketDetailsHandleResult(int hresult, XblMatchTicketDetailsResponse result);

		public delegate void XblMatchmakingGetHopperStatisticsHandleResult(int hresult, XblHopperStatisticsResponse result);

		public delegate void XblMultiplayerWriteSessionHandleResult(int hresult, XblMultiplayerSessionHandle handle);

		public delegate void XblMultiplayerGetSessionHandleResult(int hresult, XblMultiplayerSessionHandle handle);

		public delegate void XblMultiplayerSessionQueryHandleResult(int hresult, XblMultiplayerSessionQueryResult[] sessions);

		public delegate void XblMultiplayerSetActivityHandleResult(int hresult);

		public delegate void XblMultiplayerCreateSearchHandleResult(int hresult, XblMultiplayerSearchHandle handle);

		public delegate void XblMultiplayerSetTransferHandleResult(int hresult, XblMultiplayerSessionHandleId handle);

		public delegate void XblMultiplayerDeleteSearchHandleResult(int hresult);

		public delegate void XblMultiplayerClearActivityHandleResult(int hresult);

		public delegate void XblMultiplayerGetSearchHandlesResult(int hresult, XblMultiplayerSearchHandle[] searchHandles);

		public delegate void XblMultiplayerSessionChangedHandler(XblMultiplayerSessionChangeEventArgs args);

		public delegate void XblMultiplayerSessionSubscriptionLostHandler();

		public delegate void XblMultiplayerConnectionIdChangedHandler();

		public delegate void XblMultiplayerSendInvitesResult(int hresult, XblMultiplayerInviteHandle[] handles);

		public delegate void XblMultiplayerGetActivitiesResult(int hresult, XblMultiplayerActivityDetails[] activities);

		public delegate void XblMultiplayerActivityAsyncOperationCompleted(int hresult);

		public delegate void XblMultiplayerGetActivityAsyncOperationCompleted(int hresult, XblMultiplayerActivityInfo[] results);

		private class ConnectionStateChangeCallbackManager : InteropCallbackManager<XblConnectionStateChangeCallback>
		{
			[MonoPInvokeCallback]
			internal static void InteropPInvokeCallback(IntPtr context, Unity.XGamingRuntime.Interop.XblRealTimeActivityConnectionState newConnectionState)
			{
				if (_connectionStateChangeCallbackManager._contextToFunctionId.ContainsKey(context))
				{
					int functionId = _connectionStateChangeCallbackManager._contextToFunctionId[context];
					_connectionStateChangeCallbackManager.IssueEventCallback(functionId, (XblRealTimeActivityConnectionState)newConnectionState);
				}
			}

			private void IssueEventCallback(int functionId, XblRealTimeActivityConnectionState newConnectionState)
			{
				if (_functionIdToHandler.ContainsKey(functionId))
				{
					HandlerContext handlerContext = _functionIdToHandler[functionId];
					if (handlerContext.Callback != null)
					{
						handlerContext.Callback(newConnectionState);
					}
				}
			}
		}

		private class ConnectionResyncCallbackManager : InteropCallbackManager<XblConnectionResyncCallback>
		{
			[MonoPInvokeCallback]
			internal static void InteropPInvokeCallback(IntPtr context)
			{
				if (_connectionResyncCallbackManager._contextToFunctionId.ContainsKey(context))
				{
					int functionId = _connectionResyncCallbackManager._contextToFunctionId[context];
					_connectionResyncCallbackManager.IssueEventCallback(functionId);
				}
			}

			private void IssueEventCallback(int functionId)
			{
				if (_functionIdToHandler.ContainsKey(functionId))
				{
					HandlerContext handlerContext = _functionIdToHandler[functionId];
					if (handlerContext.Callback != null)
					{
						handlerContext.Callback();
					}
				}
			}
		}

		private class SocialRelationshipChangeCallbackManager : InteropCallbackManager<XblSocialRelationshipChangedCallback>
		{
			[MonoPInvokeCallback]
			internal unsafe static void InteropPInvokeCallback(Unity.XGamingRuntime.Interop.XblSocialRelationshipChangeEventArgs* eventArgs, IntPtr context)
			{
				if (_socialRelationshipChangeCallbackManager._contextToFunctionId.ContainsKey(context))
				{
					int functionId = _socialRelationshipChangeCallbackManager._contextToFunctionId[context];
					_socialRelationshipChangeCallbackManager.IssueEventCallback(functionId, eventArgs);
				}
			}

			private unsafe void IssueEventCallback(int functionId, Unity.XGamingRuntime.Interop.XblSocialRelationshipChangeEventArgs* eventArgs)
			{
				if (_functionIdToHandler.ContainsKey(functionId))
				{
					HandlerContext handlerContext = _functionIdToHandler[functionId];
					XblSocialRelationshipChangeEventArgs eventArgs2 = new XblSocialRelationshipChangeEventArgs
					{
						callerXboxUserId = eventArgs->callerXboxUserId,
						socialNotification = eventArgs->socialNotification,
						xboxUserIds = new ulong[eventArgs->xboxUserIdsCount.ToInt32()]
					};
					ulong* ptr = eventArgs->xboxUserIds;
					for (int i = 0; i < eventArgs->xboxUserIdsCount.ToInt32(); i++)
					{
						eventArgs2.xboxUserIds[i] = *ptr;
						ptr++;
					}
					if (handlerContext.Callback != null)
					{
						handlerContext.Callback(eventArgs2);
					}
				}
			}
		}

		public delegate void XblUserStatisticsStatisticChangedHandler(XblStatisticChangeEventArgs args);

		private class UserStatisticsChangeCallbackManager : InteropCallbackManager<XblStatisticChangedCallback>
		{
			[MonoPInvokeCallback]
			internal unsafe static void InteropPInvokeCallback(Unity.XGamingRuntime.Interop.XblStatisticChangeEventArgs eventArgs, void* context)
			{
				if (_userStatisticsChangeCallbackManager._contextToFunctionId.ContainsKey(new IntPtr(context)))
				{
					int functionId = _userStatisticsChangeCallbackManager._contextToFunctionId[new IntPtr(context)];
					_userStatisticsChangeCallbackManager.IssueEventCallback(functionId, eventArgs);
				}
			}

			private unsafe void IssueEventCallback(int functionId, Unity.XGamingRuntime.Interop.XblStatisticChangeEventArgs eventArgs)
			{
				if (_functionIdToHandler.ContainsKey(functionId))
				{
					HandlerContext handlerContext = _functionIdToHandler[functionId];
					XblStatisticChangeEventArgs statisticChangeEventArgs = new XblStatisticChangeEventArgs
					{
						latestStatistic = new XblStatistic(eventArgs.latestStatistic),
						serviceConfigurationId = Converters.NullTerminatedBytePointerToString((byte*)eventArgs.serviceConfigurationId),
						xboxUserId = eventArgs.xboxUserId
					};
					if (handlerContext.Callback != null)
					{
						handlerContext.Callback(statisticChangeEventArgs);
					}
				}
			}
		}

		public delegate void XblCleanupResult(int hresult);

		private static ConnectionStateChangeCallbackManager _connectionStateChangeCallbackManager = new ConnectionStateChangeCallbackManager();

		private static ConnectionResyncCallbackManager _connectionResyncCallbackManager = new ConnectionResyncCallbackManager();

		private static SocialRelationshipChangeCallbackManager _socialRelationshipChangeCallbackManager = new SocialRelationshipChangeCallbackManager();

		private static UserStatisticsChangeCallbackManager _userStatisticsChangeCallbackManager = new UserStatisticsChangeCallbackManager();

		public const int StandardScidLength = 36;

		internal static bool IsXblInitialized = false;

		public static int XblAchievementsResultGetAchievements(XblAchievementsResultHandle resultHandle, out XblAchievement[] achievements)
		{
			if (resultHandle == null)
			{
				achievements = null;
				return -2147024809;
			}
			int num = XblInterop.XblAchievementsResultGetAchievements(resultHandle.Handle, out var achievements2, out var achievementsCount);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				achievements = null;
				return num;
			}
			achievements = Converters.PtrToClassArray(achievements2, achievementsCount, (Unity.XGamingRuntime.Interop.XblAchievement a) => new XblAchievement(a));
			return num;
		}

		public static int XblAchievementsResultHasNext(XblAchievementsResultHandle resultHandle, out bool hasNext)
		{
			if (resultHandle == null)
			{
				hasNext = false;
				return -2147024809;
			}
			return XblInterop.XblAchievementsResultHasNext(resultHandle.Handle, out hasNext);
		}

		public static void XblAchievementsResultGetNextAsync(XblAchievementsResultHandle resultHandle, uint maxItems, XblAchievementsResultGetNextResult completionRoutine)
		{
			if (resultHandle == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblAchievementsResultGetNextResult(block, out var resultHandle2);
				if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num2))
				{
					completionRoutine(num2, new XblAchievementsResultHandle(resultHandle2));
				}
				else
				{
					completionRoutine(num2, null);
				}
			});
			int num = XblInterop.XblAchievementsResultGetNextAsync(resultHandle.Handle, maxItems, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static void XblAchievementsGetAchievementsForTitleIdAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, uint titleId, XblAchievementType type, bool unlockedOnly, XblAchievementOrderBy orderBy, uint skipItems, uint maxItems, XblAchievementsGetAchievementsForTitleIdResult completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblAchievementsGetAchievementsForTitleIdResult(block, out var result);
				if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num2))
				{
					completionRoutine(num2, new XblAchievementsResultHandle(result));
				}
				else
				{
					completionRoutine(num2, null);
				}
			});
			int num = XblInterop.XblAchievementsGetAchievementsForTitleIdAsync(xboxLiveContext.Handle, xboxUserId, titleId, type, unlockedOnly, orderBy, skipItems, maxItems, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static void XblAchievementsUpdateAchievementAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, string achievementId, uint percentComplete, XblAchievementsUpdateAchievementResult completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int hresult = NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false);
				completionRoutine(hresult);
			});
			int num = XblInterop.XblAchievementsUpdateAchievementAsync(xboxLiveContext.Handle, xboxUserId, Converters.StringToNullTerminatedUTF8ByteArray(achievementId), percentComplete, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num);
			}
		}

		public static void XblAchievementsUpdateAchievementAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, uint titleId, string serviceConfigurationId, string achievementId, uint percentComplete, XblAchievementsUpdateAchievementForTitleIdResult completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int hresult = NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false);
				completionRoutine(hresult);
			});
			int num = XblInterop.XblAchievementsUpdateAchievementForTitleIdAsync(xboxLiveContext.Handle, xboxUserId, titleId, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(achievementId), percentComplete, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num);
			}
		}

		public static void XblAchievementsUpdateAchievementForTitleIdAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, uint titleId, string serviceConfigurationId, string achievementId, uint percentComplete, XblAchievementsUpdateAchievementForTitleIdResult completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int hresult = NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false);
				completionRoutine(hresult);
			});
			int num = XblInterop.XblAchievementsUpdateAchievementForTitleIdAsync(xboxLiveContext.Handle, xboxUserId, titleId, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(achievementId), percentComplete, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num);
			}
		}

		public static void XblAchievementsGetAchievementAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, string serviceConfigurationId, string achievementId, XblAchievementsGetAchievementResult completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblAchievementsGetAchievementResult(block, out var result);
				if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num2))
				{
					completionRoutine(num2, new XblAchievementsResultHandle(result));
				}
				else
				{
					completionRoutine(num2, null);
				}
			});
			int num = XblInterop.XblAchievementsGetAchievementAsync(xboxLiveContext.Handle, xboxUserId, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(achievementId), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static XblFunctionContext XblAchievementsAddAchievementProgressChangeHandler(XblContextHandle xboxLiveContext, XblAchievementsProgressChangeHandlerResult handler, IntPtr handlerContext)
		{
			if (xboxLiveContext == null)
			{
				handler(-2147024809, null, IntPtr.Zero);
				return default;
			}
			XblInterop.XblAchievementsProgressChangeHandler handler2 = (Unity.XGamingRuntime.Interop.XblAchievementProgressChangeEventArgs eventArgsInterop, IntPtr context) =>
			{
				XblAchievementProgressChangeEventArgs eventArgs = new XblAchievementProgressChangeEventArgs(eventArgsInterop);
				handler(0, eventArgs, context);
			};
			return XblInterop.XblAchievementsAddAchievementProgressChangeHandler(xboxLiveContext.Handle, handler2, handlerContext);
		}

		public static XblFunctionContext XblAchievementsAddAchievementProgressChangeHandler(XblContextHandle xboxLiveContext, XblAchievementsProgressChangeHandlerResult handler)
		{
			return XblAchievementsAddAchievementProgressChangeHandler(xboxLiveContext, handler, IntPtr.Zero);
		}

		public static void XblAchievementsRemoveAchievementProgressChangeHandler(XblContextHandle xblContextHandle, XblFunctionContext functionContext)
		{
			XblInterop.XblAchievementsRemoveAchievementProgressChangeHandler(xblContextHandle.Handle, functionContext);
		}

		public static int XblAchievementsResultDuplicateHandle(XblAchievementsResultHandle handle, out XblAchievementsResultHandle duplicatedHandle)
		{
			if (handle == null)
			{
				duplicatedHandle = null;
				return -2147024809;
			}
			int num = XblInterop.XblAchievementsResultDuplicateHandle(handle.Handle, out var duplicatedHandle2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				duplicatedHandle = new XblAchievementsResultHandle(duplicatedHandle2);
				return num;
			}
			duplicatedHandle = null;
			return num;
		}

		public static void XblAchievementsResultCloseHandle(XblAchievementsResultHandle handle)
		{
			if (!(handle == null))
			{
				handle.Close();
			}
		}

		public static int XblAchievementsManagerResultGetAchievements(XblAchievementsManagerResultHandle handle, out XblAchievement[] achievements)
		{
			if (handle == null)
			{
				achievements = null;
				return -2147024809;
			}
			int num = XblInterop.XblAchievementsManagerResultGetAchievements(handle.Handle, out var achievements2, out var achievementsCount);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num) || achievementsCount == 0L)
			{
				achievements = null;
				return num;
			}
			achievements = Converters.PtrToClassArray(achievements2, new SizeT(achievementsCount), (Unity.XGamingRuntime.Interop.XblAchievement x) => new XblAchievement(x));
			return num;
		}

		public static int XblAchievementsManagerResultDuplicateHandle(XblAchievementsManagerResultHandle handle, out XblAchievementsManagerResultHandle duplicatedHandle)
		{
			if (handle == null)
			{
				duplicatedHandle = null;
				return -2147024809;
			}
			Unity.XGamingRuntime.Interop.XblAchievementsManagerResultHandle duplicatedHandle2;
			return XblAchievementsManagerResultHandle.WrapAndReturnHResult(XblInterop.XblAchievementsManagerResultDuplicateHandle(handle.Handle, out duplicatedHandle2), duplicatedHandle2, out duplicatedHandle);
		}

		public static void XblAchievementsManagerResultCloseHandle(XblAchievementsManagerResultHandle handle)
		{
			if (!(handle == null))
			{
				handle.Close();
			}
		}

		public static int XblAchievementsManagerAddLocalUser(XUserHandle user)
		{
			if (user == null)
			{
				return -2147024809;
			}
			return XblInterop.XblAchievementsManagerAddLocalUser(user.Handle, defaultQueue);
		}

		public static int XblAchievementsManagerRemoveLocalUser(XUserHandle user)
		{
			if (user == null)
			{
				return -2147024809;
			}
			return XblInterop.XblAchievementsManagerRemoveLocalUser(user.Handle);
		}

		public static int XblAchievementsManagerIsUserInitialized(ulong xboxUserId)
		{
			return XblInterop.XblAchievementsManagerIsUserInitialized(xboxUserId);
		}

		public static int XblAchievementsManagerDoWork(out XblAchievementsManagerEvent[] events)
		{
			int num = XblInterop.XblAchievementsManagerDoWork(out var achievementsEvents, out var achievementsEventsCount);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num) || achievementsEventsCount.IsZero)
			{
				events = null;
				return num;
			}
			events = Converters.PtrToClassArray(achievementsEvents, achievementsEventsCount, (Unity.XGamingRuntime.Interop.XblAchievementsManagerEvent x) => new XblAchievementsManagerEvent(x));
			return num;
		}

		public static int XblAchievementsManagerGetAchievement(ulong xboxUserId, string achievementId, out XblAchievementsManagerResultHandle handle)
		{
			byte[] achievementId2 = Converters.StringToNullTerminatedUTF8ByteArray(achievementId);
			Unity.XGamingRuntime.Interop.XblAchievementsManagerResultHandle achievementResult;
			return XblAchievementsManagerResultHandle.WrapAndReturnHResult(XblInterop.XblAchievementsManagerGetAchievement(xboxUserId, achievementId2, out achievementResult), achievementResult, out handle);
		}

		public static int XblAchievementsManagerGetAchievements(ulong xboxUserId, XblAchievementOrderBy sortField, XblAchievementsManagerSortOrder sortOrder, out XblAchievementsManagerResultHandle handle)
		{
			Unity.XGamingRuntime.Interop.XblAchievementsManagerResultHandle achievementsResult;
			return XblAchievementsManagerResultHandle.WrapAndReturnHResult(XblInterop.XblAchievementsManagerGetAchievements(xboxUserId, sortField, sortOrder, out achievementsResult), achievementsResult, out handle);
		}

		public static int XblAchievementsManagerGetAchievementsByState(ulong xboxUserId, XblAchievementOrderBy sortField, XblAchievementsManagerSortOrder sortOrder, XblAchievementProgressState achievementState, out XblAchievementsManagerResultHandle handle)
		{
			Unity.XGamingRuntime.Interop.XblAchievementsManagerResultHandle achievementResult;
			return XblAchievementsManagerResultHandle.WrapAndReturnHResult(XblInterop.XblAchievementsManagerGetAchievementsByState(xboxUserId, sortField, sortOrder, achievementState, out achievementResult), achievementResult, out handle);
		}

		public static int XblAchievementsManagerUpdateAchievement(ulong xboxUserId, string achievementId, byte currentProgress)
		{
			byte[] achievementId2 = Converters.StringToNullTerminatedUTF8ByteArray(achievementId);
			return XblInterop.XblAchievementsManagerUpdateAchievement(xboxUserId, achievementId2, currentProgress);
		}

		public static XblErrorCondition XblGetErrorCondition(int hr)
		{
			return XblInterop.XblGetErrorCondition(hr);
		}

		public static XblHresult XblGetHRESULT(int hr)
		{
			XblHresult xblHresult = XblHresult.HRESULT_NOT_RECOGNIZED;
			try
			{
				return (XblHresult)Enum.GetValues(typeof(XblHresult)).GetValue(hr);
			}
			catch (IndexOutOfRangeException)
			{
				return XblHresult.HRESULT_NOT_RECOGNIZED;
			}
		}

		public static int XblEventsWriteInGameEvent(XblContextHandle xboxLiveContext, string eventName, string dimensionsJson, string measurementsJson)
		{
			if (xboxLiveContext == null)
			{
				return -2147024809;
			}
			return XblInterop.XblEventsWriteInGameEvent(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(eventName), Converters.StringToNullTerminatedUTF8ByteArray(dimensionsJson), Converters.StringToNullTerminatedUTF8ByteArray(measurementsJson));
		}

		public static int HCSettingsSetTraceLevel(HCTraceLevel traceLevel)
		{
			IsHttpClientApiSupported();
			return XblInterop.HCSettingsSetTraceLevel(traceLevel);
		}

		public static int HCSettingsGetTraceLevel(out HCTraceLevel traceLevel)
		{
			IsHttpClientApiSupported();
			return XblInterop.HCSettingsGetTraceLevel(out traceLevel);
		}

		public static void HCTraceSetTraceToDebugger(bool traceToDebugger)
		{
			IsHttpClientApiSupported();
			XblInterop.HCTraceSetTraceToDebugger(traceToDebugger);
		}

		public static int XblHttpCallRequestSetRequestBodyBytes(XblHttpCallHandle call, byte[] requestBodyBytes)
		{
			if (call == null || requestBodyBytes == null)
			{
				return -2147024809;
			}
			return XblInterop.XblHttpCallRequestSetRequestBodyBytes(call.Handle, requestBodyBytes, (uint)requestBodyBytes.Length);
		}

		public static int XblHttpCallGetNetworkErrorCode(XblHttpCallHandle call, out int networkErrorCode, out uint platformNetworkErrorCode)
		{
			if (call == null)
			{
				networkErrorCode = 0;
				platformNetworkErrorCode = 0u;
				return -2147024809;
			}
			return XblInterop.XblHttpCallGetNetworkErrorCode(call.Handle, out networkErrorCode, out platformNetworkErrorCode);
		}

		public static int XblHttpCallRequestSetLongHttpCall(XblHttpCallHandle call, bool longHttpCall)
		{
			if (call == null)
			{
				return -2147024809;
			}
			return XblInterop.XblHttpCallRequestSetLongHttpCall(call.Handle, new NativeBool(longHttpCall));
		}

		public static void XblHttpCallPerformAsync(XblHttpCallHandle call, XblHttpCallResponseBodyType type, XblHttpCallPerformCompleted completionRoutine)
		{
			if (call == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false));
			});
			int num = XblInterop.XblHttpCallPerformAsync(call.Handle, type, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num);
			}
		}

		public static int XblHttpCallSetTracing(XblHttpCallHandle call, bool traceCall)
		{
			if (call == null)
			{
				return -2147024809;
			}
			return XblInterop.XblHttpCallSetTracing(call.Handle, new NativeBool(traceCall));
		}

		public static int XblHttpCallCreate(XblContextHandle xblContext, string method, string url, out XblHttpCallHandle call)
		{
			if (xblContext == null)
			{
				call = null;
				return -2147024809;
			}
			Unity.XGamingRuntime.Interop.XblHttpCallHandle call2;
			return XblHttpCallHandle.WrapInteropHandleAndReturnHResult(XblInterop.XblHttpCallCreate(xblContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(method), Converters.StringToNullTerminatedUTF8ByteArray(url), out call2), call2, out call);
		}

		public static void XblHttpCallCloseHandle(XblHttpCallHandle call)
		{
			if (!(call == null))
			{
				XblInterop.XblHttpCallCloseHandle(call.Handle);
			}
		}

		public static int XblHttpCallRequestSetRequestBodyString(XblHttpCallHandle call, string requestBodyString)
		{
			if (call == null)
			{
				return -2147024809;
			}
			return XblInterop.XblHttpCallRequestSetRequestBodyString(call.Handle, Converters.StringToNullTerminatedUTF8ByteArray(requestBodyString));
		}

		public static int XblHttpCallGetResponseString(XblHttpCallHandle call, out string responseString)
		{
			responseString = null;
			if (call == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblHttpCallGetResponseString(call.Handle, out var responseString2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				responseString = responseString2.GetString();
			}
			return num;
		}

		public static int XblHttpCallGetHeaderAtIndex(XblHttpCallHandle call, uint headerIndex, out string headerName, out string headerValue)
		{
			headerName = null;
			headerValue = null;
			if (call == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblHttpCallGetHeaderAtIndex(call.Handle, headerIndex, out var headerName2, out var headerValue2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				headerName = headerName2.GetString();
				headerValue = headerValue2.GetString();
			}
			return num;
		}

		public static int XblHttpCallGetPlatformNetworkErrorMessage(XblHttpCallHandle call, out string platformNetworkErrorMessage)
		{
			platformNetworkErrorMessage = null;
			if (call == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblHttpCallGetPlatformNetworkErrorMessage(call.Handle, out var platformNetworkErrorMessage2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				platformNetworkErrorMessage = platformNetworkErrorMessage2.GetString();
			}
			return num;
		}

		public static int XblHttpCallGetResponseBodyBytes(XblHttpCallHandle call, out byte[] buffer)
		{
			buffer = null;
			if (call == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblHttpCallGetResponseBodyBytesSize(call.Handle, out var bufferSize);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				buffer = new byte[bufferSize.ToInt32()];
				SizeT bufferUsed;
				return XblInterop.XblHttpCallGetResponseBodyBytes(call.Handle, bufferSize, buffer, out bufferUsed);
			}
			return num;
		}

		public static int XblHttpCallRequestSetRetryAllowed(XblHttpCallHandle call, bool retryAllowed)
		{
			if (call == null)
			{
				return -2147024809;
			}
			return XblInterop.XblHttpCallRequestSetRetryAllowed(call.Handle, new NativeBool(retryAllowed));
		}

		public static int XblHttpCallRequestSetHeader(XblHttpCallHandle call, string headerName, string headerValue, bool allowTracing)
		{
			if (call == null)
			{
				return -2147024809;
			}
			return XblInterop.XblHttpCallRequestSetHeader(call.Handle, Converters.StringToNullTerminatedUTF8ByteArray(headerName), Converters.StringToNullTerminatedUTF8ByteArray(headerValue), new NativeBool(allowTracing));
		}

		public static int XblHttpCallDuplicateHandle(XblHttpCallHandle call, out XblHttpCallHandle duplicateHandle)
		{
			if (call == null)
			{
				duplicateHandle = null;
				return -2147024809;
			}
			Unity.XGamingRuntime.Interop.XblHttpCallHandle duplicateHandle2;
			return XblHttpCallHandle.WrapInteropHandleAndReturnHResult(XblInterop.XblHttpCallDuplicateHandle(call.Handle, out duplicateHandle2), duplicateHandle2, out duplicateHandle);
		}

		public static int XblHttpCallGetNumHeaders(XblHttpCallHandle call, out uint numHeaders)
		{
			if (call == null)
			{
				numHeaders = 0u;
				return -2147024809;
			}
			return XblInterop.XblHttpCallGetNumHeaders(call.Handle, out numHeaders);
		}

		public static int XblHttpCallGetStatusCode(XblHttpCallHandle call, out uint statusCode)
		{
			if (call == null)
			{
				statusCode = 0u;
				return -2147024809;
			}
			return XblInterop.XblHttpCallGetStatusCode(call.Handle, out statusCode);
		}

		public static int XblHttpCallGetHeader(XblHttpCallHandle call, string headerName, out string headerValue)
		{
			headerValue = null;
			if (call == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblHttpCallGetHeader(call.Handle, Converters.StringToNullTerminatedUTF8ByteArray(headerName), out var headerValue2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				headerValue = headerValue2.GetString();
			}
			return num;
		}

		public static int XblHttpCallGetRequestUrl(XblHttpCallHandle call, out string url)
		{
			url = null;
			if (call == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblHttpCallGetRequestUrl(call.Handle, out var url2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				url = url2.GetString();
			}
			return num;
		}

		public static int XblHttpCallRequestSetRetryCacheId(XblHttpCallHandle call, uint retryAfterCacheId)
		{
			if (call == null)
			{
				return -2147024809;
			}
			return XblInterop.XblHttpCallRequestSetRetryCacheId(call.Handle, retryAfterCacheId);
		}

		public static void XblLeaderboardGetLeaderboardAsync(XblContextHandle xboxLiveContext, XblLeaderboardQuery leaderboardQuery, XblLeaderboardGetLeaderboardCompleted completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblLeaderboardGetLeaderboardResultSize(block, out var resultSizeInBytes);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					Debug.Log($"XblLeaderboardGetLeaderboardResultSize() Failed with: 0x{num2:X8}");
					completionRoutine(num2, null);
					return;
				}
				using DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32());
				num2 = XblInterop.XblLeaderboardGetLeaderboardResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var ptrToBuffer, out var _);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					Debug.Log($"XblLeaderboardGetLeaderboardResult() Failed with: 0x{num2:X8}");
					completionRoutine(num2, null);
				}
				else
				{
					completionRoutine(num2, Converters.PtrToClass(ptrToBuffer, (Unity.XGamingRuntime.Interop.XblLeaderboardResult r) => new XblLeaderboardResult(r)));
				}
			});
			using DisposableCollection disposableCollection = new DisposableCollection();
			int num = XblInterop.XblLeaderboardGetLeaderboardAsync(xboxLiveContext.Handle, new Unity.XGamingRuntime.Interop.XblLeaderboardQuery(leaderboardQuery, disposableCollection), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				completionRoutine(num, null);
			}
		}

		public static void XblLeaderboardResultGetNextAsync(XblContextHandle xboxLiveContext, XblLeaderboardResult leaderboardResult, uint maxItems, XblLeaderboardGetNextCompleted completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblLeaderboardResultGetNextResultSize(block, out var resultSizeInBytes);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
					return;
				}
				using DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32());
				num2 = XblInterop.XblLeaderboardResultGetNextResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var ptrToBuffer, out var _);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					completionRoutine(num2, Converters.PtrToClass(ptrToBuffer, (Unity.XGamingRuntime.Interop.XblLeaderboardResult r) => new XblLeaderboardResult(r)));
				}
			});
			using DisposableCollection disposableCollection = new DisposableCollection();
			Unity.XGamingRuntime.Interop.XblLeaderboardResult leaderboardResult2 = new Unity.XGamingRuntime.Interop.XblLeaderboardResult(leaderboardResult, disposableCollection);
			int num = XblInterop.XblLeaderboardResultGetNextAsync(xboxLiveContext.Handle, ref leaderboardResult2, maxItems, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				completionRoutine(num, null);
			}
		}

		public static void XblMatchmakingCreateMatchTicketAsync(XblContextHandle xboxLiveContext, XblMultiplayerSessionReference ticketSessionReference, string matchmakingServiceConfigurationId, string hopperName, ulong ticketTimeout, XblPreserveSessionMode preserveSession, string ticketAttributesJson, XblMatchmakingCreateMatchTicketHandleResult completionRoutine)
		{
			if (xboxLiveContext == null || ticketSessionReference == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblMatchmakingCreateMatchTicketResult(block, out var resultPtr);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					completionRoutine(num2, new XblCreateMatchTicketResponse(resultPtr));
				}
			});
			int num = XblInterop.XblMatchmakingCreateMatchTicketAsync(xboxLiveContext.Handle, new Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference(ticketSessionReference), Converters.StringToNullTerminatedUTF8ByteArray(matchmakingServiceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(hopperName), ticketTimeout, preserveSession, Converters.StringToNullTerminatedUTF8ByteArray(ticketAttributesJson), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static void XblMatchmakingDeleteMatchTicketAsync(XblContextHandle xboxLiveContext, string serviceConfigurationId, string hopperName, string ticketId, XblMatchmakingDeleteMatchTicketHandleResult completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false));
			});
			int num = XblInterop.XblMatchmakingDeleteMatchTicketAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(hopperName), Converters.StringToNullTerminatedUTF8ByteArray(ticketId), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num);
			}
		}

		public static void XblMatchmakingGetMatchTicketDetailsAsync(XblContextHandle xboxLiveContext, string serviceConfigurationId, string hopperName, string ticketId, XblMatchmakingGetMatchTicketDetailsHandleResult completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblMatchmakingGetMatchTicketDetailsResultSize(block, out var resultSizeInBytes);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2) || resultSizeInBytes.IsZero)
				{
					completionRoutine(num2, null);
					return;
				}
				using DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32());
				num2 = XblInterop.XblMatchmakingGetMatchTicketDetailsResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var ptrToBuffer, out var _);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					XblMatchTicketDetailsResponse[] array = Converters.PtrToClassArray(ptrToBuffer, 1u, (Unity.XGamingRuntime.Interop.XblMatchTicketDetailsResponse r) => new XblMatchTicketDetailsResponse(r));
					completionRoutine(num2, array[0]);
				}
			});
			int num = XblInterop.XblMatchmakingGetMatchTicketDetailsAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(hopperName), Converters.StringToNullTerminatedUTF8ByteArray(ticketId), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static void XblMatchmakingGetHopperStatisticsAsync(XblContextHandle xboxLiveContext, string serviceConfigurationId, string hopperName, XblMatchmakingGetHopperStatisticsHandleResult completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblMatchmakingGetMatchTicketDetailsResultSize(block, out var resultSizeInBytes);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2) || resultSizeInBytes.IsZero)
				{
					completionRoutine(num2, null);
					return;
				}
				using DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32());
				num2 = XblInterop.XblMatchmakingGetMatchTicketDetailsResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var ptrToBuffer, out var _);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					XblHopperStatisticsResponse[] array = Converters.PtrToClassArray(ptrToBuffer, 1u, (Unity.XGamingRuntime.Interop.XblHopperStatisticsResponse r) => new XblHopperStatisticsResponse(r));
					completionRoutine(num2, array[0]);
				}
			});
			int num = XblInterop.XblMatchmakingGetHopperStatisticsAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(hopperName), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static XblMultiplayerSessionHandle XblMultiplayerSessionCreateHandle(ulong xboxUserId, XblMultiplayerSessionReference sessionRef, XblMultiplayerSessionInitArgs initArgs)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference sessionRef2 = new Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference(sessionRef);
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionInitArgs initArgs2 = new Unity.XGamingRuntime.Interop.XblMultiplayerSessionInitArgs(initArgs, disposableCollection);
			return new XblMultiplayerSessionHandle(XblInterop.XblMultiplayerSessionCreateHandle(xboxUserId, ref sessionRef2, ref initArgs2));
		}

		public static void XblMultiplayerSessionCloseHandle(XblMultiplayerSessionHandle handle)
		{
			if (handle != null)
			{
				handle.Close();
			}
		}

		public static DateTime XblMultiplayerSessionTimeOfSession(XblMultiplayerSessionHandle handle)
		{
			if (handle == null)
			{
				return default;
			}
			return XblInterop.XblMultiplayerSessionTimeOfSession(handle.Handle).DateTime;
		}

		public unsafe static XblMultiplayerSessionInitializationInfo XblMultiplayerSessionGetInitializationInfo(XblMultiplayerSessionHandle handle)
		{
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionInitializationInfo* ptr = null;
			if (handle != null)
			{
				ptr = XblInterop.XblMultiplayerSessionGetInitializationInfo(handle.Handle);
			}
			if (ptr == null)
			{
				return null;
			}
			return new XblMultiplayerSessionInitializationInfo(*ptr);
		}

		public static XblMultiplayerSessionChangeTypes XblMultiplayerSessionSubscribedChangeTypes(XblMultiplayerSessionHandle handle)
		{
			if (handle == null)
			{
				return XblMultiplayerSessionChangeTypes.None;
			}
			return XblInterop.XblMultiplayerSessionSubscribedChangeTypes(handle.Handle);
		}

		public static int XblMultiplayerSessionHostCandidates(XblMultiplayerSessionHandle handle, out XblDeviceToken[] deviceTokens)
		{
			deviceTokens = null;
			if (handle == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblMultiplayerSessionHostCandidates(handle.Handle, out var deviceTokens2, out var deviceTokensCount);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				deviceTokens = Converters.PtrToClassArray(deviceTokens2, deviceTokensCount, (Unity.XGamingRuntime.Interop.XblDeviceToken x) => new XblDeviceToken(x));
			}
			return num;
		}

		public unsafe static XblMultiplayerSessionReference XblMultiplayerSessionSessionReference(XblMultiplayerSessionHandle handle)
		{
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference* ptr = null;
			if (handle != null)
			{
				ptr = XblInterop.XblMultiplayerSessionSessionReference(handle.Handle);
			}
			if (ptr == null)
			{
				return null;
			}
			return new XblMultiplayerSessionReference(*ptr);
		}

		public unsafe static XblMultiplayerSessionConstants XblMultiplayerSessionSessionConstants(XblMultiplayerSessionHandle handle)
		{
			if (handle == null)
			{
				return null;
			}
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionConstants* ptr = XblInterop.XblMultiplayerSessionSessionConstants(handle.Handle);
			if (ptr == null)
			{
				return null;
			}
			return new XblMultiplayerSessionConstants(*ptr);
		}

		public static void XblMultiplayerSessionConstantsSetMaxMembersInSession(XblMultiplayerSessionHandle handle, uint maxMembersInSession)
		{
			if (handle != null)
			{
				XblInterop.XblMultiplayerSessionConstantsSetMaxMembersInSession(handle.Handle, maxMembersInSession);
			}
		}

		public static void XblMultiplayerSessionConstantsSetVisibility(XblMultiplayerSessionHandle handle, XblMultiplayerSessionVisibility visibility)
		{
			if (handle != null)
			{
				XblInterop.XblMultiplayerSessionConstantsSetVisibility(handle.Handle, visibility);
			}
		}

		public static int XblMultiplayerSessionConstantsSetTimeouts(XblMultiplayerSessionHandle handle, ulong memberReservedTimeout, ulong memberInactiveTimeout, ulong memberReadyTimeout, ulong sessionEmptyTimeout)
		{
			if (handle == null)
			{
				return -2147024809;
			}
			return XblInterop.XblMultiplayerSessionConstantsSetTimeouts(handle.Handle, memberReservedTimeout, memberInactiveTimeout, memberReadyTimeout, sessionEmptyTimeout);
		}

		public static int XblMultiplayerSessionConstantsSetQosConnectivityMetrics(XblMultiplayerSessionHandle handle, bool enableLatencyMetric, bool enableBandwidthDownMetric, bool enableBandwidthUpMetric, bool enableCustomMetric)
		{
			if (handle == null)
			{
				return -2147024809;
			}
			return XblInterop.XblMultiplayerSessionConstantsSetQosConnectivityMetrics(handle.Handle, new NativeBool(enableLatencyMetric), new NativeBool(enableBandwidthDownMetric), new NativeBool(enableBandwidthUpMetric), new NativeBool(enableCustomMetric));
		}

		public static int XblMultiplayerSessionConstantsSetMemberInitialization(XblMultiplayerSessionHandle handle, XblMultiplayerMemberInitialization memberInitialization)
		{
			if (handle == null)
			{
				return -2147024809;
			}
			return XblInterop.XblMultiplayerSessionConstantsSetMemberInitialization(handle.Handle, new Unity.XGamingRuntime.Interop.XblMultiplayerMemberInitialization(memberInitialization));
		}

		public static int XblMultiplayerSessionConstantsSetPeerToPeerRequirements(XblMultiplayerSessionHandle handle, XblMultiplayerPeerToPeerRequirements requirements)
		{
			if (handle == null)
			{
				return -2147024809;
			}
			return XblInterop.XblMultiplayerSessionConstantsSetPeerToPeerRequirements(handle.Handle, new Unity.XGamingRuntime.Interop.XblMultiplayerPeerToPeerRequirements(requirements));
		}

		public static int XblMultiplayerSessionConstantsSetMeasurementServerAddressesJson(XblMultiplayerSessionHandle handle, string measurementServerAddressesJson)
		{
			if (handle == null)
			{
				return -2147024809;
			}
			return XblInterop.XblMultiplayerSessionConstantsSetMeasurementServerAddressesJson(handle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(measurementServerAddressesJson));
		}

		public static int XblMultiplayerSessionConstantsSetCapabilities(XblMultiplayerSessionHandle handle, XblMultiplayerSessionCapabilities capabilities)
		{
			if (handle == null)
			{
				return -2147024809;
			}
			return XblInterop.XblMultiplayerSessionConstantsSetCapabilities(handle.Handle, (capabilities == null) ? default(Unity.XGamingRuntime.Interop.XblMultiplayerSessionCapabilities) : new Unity.XGamingRuntime.Interop.XblMultiplayerSessionCapabilities(capabilities));
		}

		public unsafe static XblMultiplayerSessionProperties XblMultiplayerSessionSessionProperties(XblMultiplayerSessionHandle handle)
		{
			if (handle == null)
			{
				return null;
			}
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionProperties* ptr = XblInterop.XblMultiplayerSessionSessionProperties(handle.Handle);
			if (ptr == null)
			{
				return null;
			}
			return new XblMultiplayerSessionProperties(*ptr);
		}

		public static int XblMultiplayerSessionPropertiesSetKeywords(XblMultiplayerSessionHandle handle, string[] keywords)
		{
			if (handle == null)
			{
				return -2147024809;
			}
			using DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(keywords);
			return XblInterop.XblMultiplayerSessionPropertiesSetKeywords(handle.Handle, disposableBuffer.IntPtr, new SizeT(keywords.Length));
		}

		public static void XblMultiplayerSessionPropertiesSetJoinRestriction(XblMultiplayerSessionHandle handle, XblMultiplayerSessionRestriction joinRestriction)
		{
			if (!(handle == null))
			{
				XblInterop.XblMultiplayerSessionPropertiesSetJoinRestriction(handle.Handle, joinRestriction);
			}
		}

		public static void XblMultiplayerSessionPropertiesSetReadRestriction(XblMultiplayerSessionHandle handle, XblMultiplayerSessionRestriction readRestriction)
		{
			if (!(handle == null))
			{
				XblInterop.XblMultiplayerSessionPropertiesSetReadRestriction(handle.Handle, readRestriction);
			}
		}

		public static int XblMultiplayerSessionPropertiesSetTurnCollection(XblMultiplayerSessionHandle handle, uint[] turnCollectionMemberIds)
		{
			if (handle != null)
			{
				return XblInterop.XblMultiplayerSessionPropertiesSetTurnCollection(handle.Handle, turnCollectionMemberIds, new SizeT(turnCollectionMemberIds.Length));
			}
			return -2147024809;
		}

		public static int XblMultiplayerSessionMembers(XblMultiplayerSessionHandle handle, out XblMultiplayerSessionMember[] members)
		{
			int num = XblInterop.XblMultiplayerSessionMembers(handle.Handle, out var members2, out var membersCount);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num) || membersCount.IsZero)
			{
				members = null;
				return num;
			}
			members = Converters.PtrToClassArray(members2, membersCount, (Unity.XGamingRuntime.Interop.XblMultiplayerSessionMember x) => new XblMultiplayerSessionMember(x));
			return num;
		}

		public unsafe static XblMultiplayerMatchmakingServer XblMultiplayerSessionMatchmakingServer(XblMultiplayerSessionHandle handle)
		{
			if (handle == null)
			{
				return null;
			}
			Unity.XGamingRuntime.Interop.XblMultiplayerMatchmakingServer* ptr = XblInterop.XblMultiplayerSessionMatchmakingServer(handle.Handle);
			if (ptr == null)
			{
				return null;
			}
			return new XblMultiplayerMatchmakingServer(*ptr);
		}

		public unsafe static XblMultiplayerSessionMember XblMultiplayerSessionCurrentUser(XblMultiplayerSessionHandle handle)
		{
			if (handle == null)
			{
				return null;
			}
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionMember* ptr = XblInterop.XblMultiplayerSessionCurrentUser(handle.Handle);
			if (ptr == null)
			{
				return null;
			}
			return new XblMultiplayerSessionMember(*ptr);
		}

		public static int XblMultiplayerSessionCurrentUserSetRoles(XblMultiplayerSessionHandle handle, XblMultiplayerSessionMemberRole[] roles)
		{
			if (handle == null)
			{
				return -2147024809;
			}
			DisposableCollection disposableCollection = new DisposableCollection();
			try
			{
				IntPtr roles2 = Converters.ClassArrayToPtr(roles, (XblMultiplayerSessionMemberRole role, DisposableCollection collection) => new Unity.XGamingRuntime.Interop.XblMultiplayerSessionMemberRole(role, disposableCollection), disposableCollection, out var arrayCount);
				return XblInterop.XblMultiplayerSessionCurrentUserSetRoles(handle.Handle, roles2, arrayCount);
			}
			finally
			{
				if (disposableCollection != null)
				{
					((IDisposable)disposableCollection).Dispose();
				}
			}
		}

		public static int XblMultiplayerSessionCurrentUserSetEncounters(XblMultiplayerSessionHandle handle, string[] encounters)
		{
			if (handle == null)
			{
				return -2147024809;
			}
			using DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(encounters);
			return XblInterop.XblMultiplayerSessionCurrentUserSetEncounters(handle.Handle, disposableBuffer.IntPtr, new SizeT(encounters.Length));
		}

		public static int XblMultiplayerSessionCurrentUserSetMembersInGroup(XblMultiplayerSessionHandle handle, uint[] memberIds)
		{
			if (handle == null)
			{
				return -2147024809;
			}
			return XblInterop.XblMultiplayerSessionCurrentUserSetMembersInGroup(handle.Handle, memberIds, new SizeT(memberIds.Length));
		}

		public static int XblMultiplayerSessionCurrentUserSetGroups(XblMultiplayerSessionHandle handle, string[] groups)
		{
			if (handle == null)
			{
				return -2147024809;
			}
			using DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(groups);
			return XblInterop.XblMultiplayerSessionCurrentUserSetGroups(handle.Handle, disposableBuffer.IntPtr, new SizeT(groups.Length));
		}

		public static int XblMultiplayerSessionCurrentUserSetCustomPropertyJson(XblMultiplayerSessionHandle handle, string name, string valueJson)
		{
			if (handle == null)
			{
				return -2147024809;
			}
			return XblInterop.XblMultiplayerSessionCurrentUserSetCustomPropertyJson(handle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson));
		}

		public static int XblMultiplayerSessionCurrentUserDeleteCustomPropertyJson(XblMultiplayerSessionHandle handle, string name)
		{
			if (handle == null)
			{
				return -2147024809;
			}
			return XblInterop.XblMultiplayerSessionCurrentUserDeleteCustomPropertyJson(handle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(name));
		}

		public static XblWriteSessionStatus XblMultiplayerSessionWriteStatus(XblMultiplayerSessionHandle handle)
		{
			return XblInterop.XblMultiplayerSessionWriteStatus(handle.Handle);
		}

		public static int XblMultiplayerSessionJoin(XblMultiplayerSessionHandle handle, string memberCustomConstantsJson, bool initializeRequested, bool joinWithActiveStatus)
		{
			return XblInterop.XblMultiplayerSessionJoin(handle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(memberCustomConstantsJson), initializeRequested, joinWithActiveStatus);
		}

		public static void XblMultiplayerSessionSetHostDeviceToken(XblMultiplayerSessionHandle handle, XblDeviceToken hostDeviceToken)
		{
			if (!(handle == null))
			{
				XblInterop.XblMultiplayerSessionSetHostDeviceToken(handle.Handle, new Unity.XGamingRuntime.Interop.XblDeviceToken(hostDeviceToken));
			}
		}

		public static void XblMultiplayerSessionSetClosed(XblMultiplayerSessionHandle handle, bool closed)
		{
			if (handle != null)
			{
				XblInterop.XblMultiplayerSessionSetClosed(handle.Handle, closed);
			}
		}

		public static int XblMultiplayerSessionSetSessionChangeSubscription(XblMultiplayerSessionHandle handle, XblMultiplayerSessionChangeTypes changeTypes)
		{
			if (handle != null)
			{
				return XblInterop.XblMultiplayerSessionSetSessionChangeSubscription(handle.Handle, changeTypes);
			}
			return -2147024809;
		}

		public static int XblMultiplayerSessionLeave(XblMultiplayerSessionHandle handle)
		{
			if (handle != null)
			{
				return XblInterop.XblMultiplayerSessionLeave(handle.Handle);
			}
			return -2147024809;
		}

		public static int XblMultiplayerSessionCurrentUserSetStatus(XblMultiplayerSessionHandle handle, XblMultiplayerSessionMemberStatus status)
		{
			if (handle != null)
			{
				return XblInterop.XblMultiplayerSessionCurrentUserSetStatus(handle.Handle, status);
			}
			return -2147024809;
		}

		public static int XblMultiplayerSessionCurrentUserSetSecureDeviceAddressBase64(XblMultiplayerSessionHandle handle, string value)
		{
			if (handle != null)
			{
				return XblInterop.XblMultiplayerSessionCurrentUserSetSecureDeviceAddressBase64(handle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(value));
			}
			return -2147024809;
		}

		public static int XblFormatSecureDeviceAddress(string deviceId, out string address)
		{
			if (deviceId != null)
			{
				int result = XblInterop.XblFormatSecureDeviceAddress(Converters.StringToNullTerminatedUTF8ByteArray(deviceId), out var address2);
				address = address2.GetValue();
				return result;
			}
			address = null;
			return -2147024809;
		}

		public static void XblMultiplayerSearchHandleCloseHandle(XblMultiplayerSearchHandle handle)
		{
			if (handle != null)
			{
				handle.Close();
			}
		}

		public static int XblMultiplayerSearchHandleGetSessionReference(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionReference sessionRef)
		{
			int num = XblInterop.XblMultiplayerSearchHandleGetSessionReference(handle.Handle, out var sessionRef2);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				sessionRef = null;
				return num;
			}
			sessionRef = new XblMultiplayerSessionReference(sessionRef2);
			return num;
		}

		public static int XblMultiplayerSearchHandleGetId(XblMultiplayerSearchHandle handle, out string id)
		{
			int num = XblInterop.XblMultiplayerSearchHandleGetId(handle.Handle, out var id2);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				id = null;
				return num;
			}
			id = id2.GetString();
			return num;
		}

		public static int XblMultiplayerSearchHandleGetSessionOwnerXuids(XblMultiplayerSearchHandle handle, out ulong[] xuids)
		{
			int num = XblInterop.XblMultiplayerSearchHandleGetSessionOwnerXuids(handle.Handle, out var xuids2, out var xuidsCount);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num) || xuidsCount.IsZero)
			{
				xuids = null;
				return num;
			}
			xuids = Converters.PtrToClassArray(xuids2, xuidsCount.ToUInt32(), (ulong x) => x);
			return num;
		}

		public static int XblMultiplayerSearchHandleGetTags(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionTag[] tags)
		{
			int num = XblInterop.XblMultiplayerSearchHandleGetTags(handle.Handle, out var tags2, out var tagsCount);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num) || tagsCount.IsZero)
			{
				tags = null;
				return num;
			}
			tags = Converters.PtrToClassArray(tags2, tagsCount, (Unity.XGamingRuntime.Interop.XblMultiplayerSessionTag x) => new XblMultiplayerSessionTag(x));
			return num;
		}

		public static int XblMultiplayerSearchHandleGetStringAttributes(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionStringAttribute[] attributes)
		{
			int num = XblInterop.XblMultiplayerSearchHandleGetStringAttributes(handle.Handle, out var attributes2, out var attributesCount);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num) || attributesCount.IsZero)
			{
				attributes = null;
				return num;
			}
			attributes = Converters.PtrToClassArray(attributes2, attributesCount, (Unity.XGamingRuntime.Interop.XblMultiplayerSessionStringAttribute x) => new XblMultiplayerSessionStringAttribute(x));
			return num;
		}

		public static int XblMultiplayerSearchHandleGetNumberAttributes(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionNumberAttribute[] attributes)
		{
			int num = XblInterop.XblMultiplayerSearchHandleGetNumberAttributes(handle.Handle, out var attributes2, out var attributesCount);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num) || attributesCount.IsZero)
			{
				attributes = null;
				return num;
			}
			attributes = Converters.PtrToClassArray(attributes2, attributesCount, (Unity.XGamingRuntime.Interop.XblMultiplayerSessionNumberAttribute x) => new XblMultiplayerSessionNumberAttribute(x));
			return num;
		}

		public static int XblMultiplayerSearchHandleGetVisibility(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionVisibility visibility)
		{
			return XblInterop.XblMultiplayerSearchHandleGetVisibility(handle.Handle, out visibility);
		}

		public static int XblMultiplayerSearchHandleGetJoinRestriction(XblMultiplayerSearchHandle handle, out XblMultiplayerSessionRestriction joinRestriction)
		{
			return XblInterop.XblMultiplayerSearchHandleGetJoinRestriction(handle.Handle, out joinRestriction);
		}

		public static int XblMultiplayerSearchHandleGetSessionClosed(XblMultiplayerSearchHandle handle, out bool closed)
		{
			return XblInterop.XblMultiplayerSearchHandleGetSessionClosed(handle.Handle, out closed);
		}

		public static int XblMultiplayerSearchHandleGetMemberCounts(XblMultiplayerSearchHandle handle, out uint maxMembers, out uint currentMembers)
		{
			maxMembers = 0u;
			currentMembers = 0u;
			if (handle == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblMultiplayerSearchHandleGetMemberCounts(handle.Handle, out var maxMembers2, out var currentMembers2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				maxMembers = maxMembers2.ToUInt32();
				currentMembers = currentMembers2.ToUInt32();
			}
			return num;
		}

		public static int XblMultiplayerSearchHandleGetCreationTime(XblMultiplayerSearchHandle handle, out DateTime creationTime)
		{
			creationTime = default;
			if (handle == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblMultiplayerSearchHandleGetCreationTime(handle.Handle, out var creationTime2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				creationTime = creationTime2.DateTime;
			}
			return num;
		}

		public static int XblMultiplayerSearchHandleGetCustomSessionPropertiesJson(XblMultiplayerSearchHandle handle, out string customPropertiesJson)
		{
			customPropertiesJson = null;
			if (handle == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblMultiplayerSearchHandleGetCustomSessionPropertiesJson(handle.Handle, out var customPropertiesJson2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				customPropertiesJson = customPropertiesJson2.GetString();
			}
			return num;
		}

		public static void XblMultiplayerWriteSessionAsync(XblContextHandle xblContext, XblMultiplayerSessionHandle handle, XblMultiplayerSessionWriteMode writeMode, XblMultiplayerWriteSessionHandleResult completionRoutine)
		{
			if (xblContext == null || handle == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblMultiplayerWriteSessionResult(block, out var handle2);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					completionRoutine(num2, new XblMultiplayerSessionHandle(handle2));
				}
			});
			int num = XblInterop.XblMultiplayerWriteSessionAsync(xblContext.Handle, handle.Handle, writeMode, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static void XblMultiplayerWriteSessionByHandleAsync(XblContextHandle xblContext, XblMultiplayerSessionHandle handle, XblMultiplayerSessionWriteMode writeMode, string handleId, XblMultiplayerWriteSessionHandleResult completionRoutine)
		{
			if (xblContext == null || handle == null || handleId == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblMultiplayerWriteSessionByHandleResult(block, out var handle2);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					completionRoutine(num2, new XblMultiplayerSessionHandle(handle2));
				}
			});
			int num = XblInterop.XblMultiplayerWriteSessionByHandleAsync(xblContext.Handle, handle.Handle, writeMode, Converters.StringToNullTerminatedUTF8ByteArray(handleId), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static void XblMultiplayerGetSessionAsync(XblContextHandle xblContext, XblMultiplayerSessionReference sessionRef, XblMultiplayerGetSessionHandleResult completionRoutine)
		{
			if (xblContext == null || sessionRef == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblMultiplayerGetSessionResult(block, out var handle);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					completionRoutine(num2, new XblMultiplayerSessionHandle(handle));
				}
			});
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference sessionRef2 = new Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference(sessionRef);
			int num = XblInterop.XblMultiplayerGetSessionAsync(xblContext.Handle, ref sessionRef2, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static void XblMultiplayerGetSessionByHandleAsync(XblContextHandle xblContext, string handleId, XblMultiplayerGetSessionHandleResult completionRoutine)
		{
			if (xblContext == null || handleId == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblMultiplayerGetSessionByHandleResult(block, out var handle);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					completionRoutine(num2, new XblMultiplayerSessionHandle(handle));
				}
			});
			int num = XblInterop.XblMultiplayerGetSessionByHandleAsync(xblContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(handleId), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static void XblMultiplayerQuerySessionsAsync(XblContextHandle xblContext, XblMultiplayerSessionQuery sessionQuery, XblMultiplayerSessionQueryHandleResult completionRoutine)
		{
			if (xblContext == null || sessionQuery == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num = XblInterop.XblMultiplayerQuerySessionsResultCount(block, out var sessionCount);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
				{
					completionRoutine(num, null);
				}
				else
				{
					Unity.XGamingRuntime.Interop.XblMultiplayerSessionQueryResult[] array = new Unity.XGamingRuntime.Interop.XblMultiplayerSessionQueryResult[sessionCount.ToInt32()];
					num = XblInterop.XblMultiplayerQuerySessionsResult(block, sessionCount, array);
					if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
					{
						completionRoutine(-2147024809, null);
					}
					else
					{
						completionRoutine(num, Array.ConvertAll(array, (Unity.XGamingRuntime.Interop.XblMultiplayerSessionQueryResult h) => new XblMultiplayerSessionQueryResult(h)));
					}
				}
			});
			using DisposableCollection disposableCollection = new DisposableCollection();
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionQuery sessionQuery2 = new Unity.XGamingRuntime.Interop.XblMultiplayerSessionQuery(sessionQuery, disposableCollection);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(XblInterop.XblMultiplayerQuerySessionsAsync(xblContext.Handle, ref sessionQuery2, xAsyncBlock)))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(-2147024809, null);
			}
		}

		public static void XblMultiplayerSetActivityAsync(XblContextHandle xblContext, XblMultiplayerSessionReference sessionReference, XblMultiplayerSetActivityHandleResult completionRoutine)
		{
			if (xblContext == null || sessionReference == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false));
			});
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference sessionReference2 = new Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference(sessionReference);
			int num = XblInterop.XblMultiplayerSetActivityAsync(xblContext.Handle, ref sessionReference2, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num);
			}
		}

		public static void XblMultiplayerClearActivityAsync(XblContextHandle xblContext, string scid, XblMultiplayerClearActivityHandleResult completionRoutine)
		{
			if (xblContext == null || scid == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false));
			});
			int num = XblInterop.XblMultiplayerClearActivityAsync(xblContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(scid), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num);
			}
		}

		public static void XblMultiplayerSetTransferHandleAsync(XblContextHandle xblContext, XblMultiplayerSessionReference targetSessionReference, XblMultiplayerSessionReference originSessionReference, XblMultiplayerSetTransferHandleResult completionRoutine)
		{
			if (xblContext == null || originSessionReference == null || targetSessionReference == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblMultiplayerSetTransferHandleResult(block, out var handle);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					completionRoutine(num2, new XblMultiplayerSessionHandleId(handle));
				}
			});
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference originSessionReference2 = new Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference(originSessionReference);
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference targetSessionReference2 = new Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference(targetSessionReference);
			int num = XblInterop.XblMultiplayerSetTransferHandleAsync(xblContext.Handle, ref targetSessionReference2, ref originSessionReference2, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static void XblMultiplayerCreateSearchHandleAsync(XblContextHandle xblContext, XblMultiplayerSessionReference sessionRef, XblMultiplayerSessionTag[] tags, XblMultiplayerSessionNumberAttribute[] numberAttributes, XblMultiplayerSessionStringAttribute[] stringAttributes, XblMultiplayerCreateSearchHandleResult completionRoutine)
		{
			if (xblContext == null || sessionRef == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblMultiplayerCreateSearchHandleResult(block, out var handle);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					completionRoutine(num2, new XblMultiplayerSearchHandle(handle));
				}
			});
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference sessionRef2 = new Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference(sessionRef);
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionTag[] array = Converters.ConvertArrayToFixedLength(tags, tags.Length, (XblMultiplayerSessionTag r) => new Unity.XGamingRuntime.Interop.XblMultiplayerSessionTag(r));
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionNumberAttribute[] array2 = Converters.ConvertArrayToFixedLength(numberAttributes, numberAttributes.Length, (XblMultiplayerSessionNumberAttribute r) => new Unity.XGamingRuntime.Interop.XblMultiplayerSessionNumberAttribute(r));
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionStringAttribute[] array3 = Converters.ConvertArrayToFixedLength(stringAttributes, stringAttributes.Length, (XblMultiplayerSessionStringAttribute r) => new Unity.XGamingRuntime.Interop.XblMultiplayerSessionStringAttribute(r));
			int num = XblInterop.XblMultiplayerCreateSearchHandleAsync(xblContext.Handle, ref sessionRef2, array, new SizeT(array.Length), array2, new SizeT(array2.Length), array3, new SizeT(array3.Length), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static void XblMultiplayerDeleteSearchHandleAsync(XblContextHandle xblContext, string handleId, XblMultiplayerDeleteSearchHandleResult completionRoutine)
		{
			if (xblContext == null || handleId == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false));
			});
			int num = XblInterop.XblMultiplayerDeleteSearchHandleAsync(xblContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(handleId), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num);
			}
		}

		public static void XblMultiplayerGetSearchHandlesAsync(XblContextHandle xboxLiveContext, string scid, string sessionTemplateName, string orderByAttribute, bool orderAscending, string searchFilter, string socialGroup, XblMultiplayerGetSearchHandlesResult completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809, new XblMultiplayerSearchHandle[0]);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblMultiplayerGetSearchHandlesResultCount(block, out var searchHandleCount);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2) || searchHandleCount.IsZero)
				{
					completionRoutine(num2, new XblMultiplayerSearchHandle[0]);
				}
				else
				{
					Unity.XGamingRuntime.Interop.XblMultiplayerSearchHandle[] array = new Unity.XGamingRuntime.Interop.XblMultiplayerSearchHandle[searchHandleCount.ToInt32()];
					int num3 = XblInterop.XblMultiplayerGetSearchHandlesResult(block, array, searchHandleCount);
					if (!Unity.XGamingRuntime.Interop.HR.FAILED(num3))
					{
						completionRoutine(num3, Array.ConvertAll(array, (Unity.XGamingRuntime.Interop.XblMultiplayerSearchHandle h) => new XblMultiplayerSearchHandle(h)));
					}
					else
					{
						completionRoutine(num3, new XblMultiplayerSearchHandle[0]);
					}
				}
			});
			int num = XblInterop.XblMultiplayerGetSearchHandlesAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(scid), Converters.StringToNullTerminatedUTF8ByteArray(sessionTemplateName), Converters.StringToNullTerminatedUTF8ByteArray(orderByAttribute), orderAscending, Converters.StringToNullTerminatedUTF8ByteArray(searchFilter), Converters.StringToNullTerminatedUTF8ByteArray(socialGroup), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, new XblMultiplayerSearchHandle[0]);
			}
		}

		public static void XblMultiplayerSendInvitesAsync(XblContextHandle xboxLiveContext, XblMultiplayerSessionReference sessionRef, ulong[] xboxUserIdList, uint titleId, string contextStringId, string customActivationContext, XblMultiplayerSendInvitesResult completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809, new XblMultiplayerInviteHandle[0]);
				return;
			}
			SizeT xuidsCount = new SizeT((xboxUserIdList != null) ? xboxUserIdList.Length : 0);
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				Unity.XGamingRuntime.Interop.XblMultiplayerInviteHandle[] array = new Unity.XGamingRuntime.Interop.XblMultiplayerInviteHandle[xuidsCount.ToInt32()];
				int num2 = XblInterop.XblMultiplayerSendInvitesResult(block, xuidsCount, array);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, new XblMultiplayerInviteHandle[0]);
				}
				else
				{
					completionRoutine(num2, Array.ConvertAll(array, (Unity.XGamingRuntime.Interop.XblMultiplayerInviteHandle h) => new XblMultiplayerInviteHandle(h)));
				}
			});
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference sessionRef2 = new Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference(sessionRef);
			int num = XblInterop.XblMultiplayerSendInvitesAsync(xboxLiveContext.Handle, ref sessionRef2, xboxUserIdList, xuidsCount, titleId, Converters.StringToNullTerminatedUTF8ByteArray(contextStringId), Converters.StringToNullTerminatedUTF8ByteArray(customActivationContext), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, new XblMultiplayerInviteHandle[0]);
			}
		}

		public static void XblMultiplayerGetActivitiesForSocialGroupAsync(XblContextHandle xboxLiveContext, string scid, ulong socialGroupOwnerXuid, string socialGroup, XblMultiplayerGetActivitiesResult completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809, new XblMultiplayerActivityDetails[0]);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblMultiplayerGetActivitiesForSocialGroupResultCount(block, out var activityCount);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2) || activityCount.IsZero)
				{
					completionRoutine(num2, new XblMultiplayerActivityDetails[0]);
				}
				else
				{
					Unity.XGamingRuntime.Interop.XblMultiplayerActivityDetails[] array = new Unity.XGamingRuntime.Interop.XblMultiplayerActivityDetails[activityCount.ToInt32()];
					int num3 = XblInterop.XblMultiplayerGetActivitiesForSocialGroupResult(block, activityCount, array);
					if (!Unity.XGamingRuntime.Interop.HR.FAILED(num3))
					{
						completionRoutine(num3, Array.ConvertAll(array, (Unity.XGamingRuntime.Interop.XblMultiplayerActivityDetails h) => new XblMultiplayerActivityDetails(h)));
					}
					else
					{
						completionRoutine(num3, new XblMultiplayerActivityDetails[0]);
					}
				}
			});
			int num = XblInterop.XblMultiplayerGetActivitiesForSocialGroupAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(scid), socialGroupOwnerXuid, Converters.StringToNullTerminatedUTF8ByteArray(socialGroup), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, new XblMultiplayerActivityDetails[0]);
			}
		}

		public static void XblMultiplayerGetActivitiesWithPropertiesForSocialGroupAsync(XblContextHandle xboxLiveContext, string scid, ulong socialGroupOwnerXuid, string socialGroup, XblMultiplayerGetActivitiesResult completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809, new XblMultiplayerActivityDetails[0]);
				return;
			}
			int hr;
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				hr = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForSocialGroupResultSize(block, out var resultSizeInBytes);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(hr) || resultSizeInBytes.IsZero)
				{
					completionRoutine(hr, new XblMultiplayerActivityDetails[0]);
					return;
				}
				using DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32());
				hr = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForSocialGroupResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var ptrToBuffer, out var ptrToBufferCount, out var _);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(hr))
				{
					completionRoutine(hr, null);
				}
				else
				{
					completionRoutine(hr, Converters.PtrToClassArray(ptrToBuffer, ptrToBufferCount, (Unity.XGamingRuntime.Interop.XblMultiplayerActivityDetails r) => new XblMultiplayerActivityDetails(r)));
				}
			});
			hr = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForSocialGroupAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(scid), socialGroupOwnerXuid, Converters.StringToNullTerminatedUTF8ByteArray(socialGroup), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(hr))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(hr, new XblMultiplayerActivityDetails[0]);
			}
		}

		public static void XblMultiplayerGetActivitiesForUsersAsync(XblContextHandle xboxLiveContext, string scid, ulong[] xuids, XblMultiplayerGetActivitiesResult completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809, new XblMultiplayerActivityDetails[0]);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblMultiplayerGetActivitiesForUsersResultCount(block, out var activityCount);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2) || activityCount.IsZero)
				{
					completionRoutine(num2, new XblMultiplayerActivityDetails[0]);
				}
				else
				{
					Unity.XGamingRuntime.Interop.XblMultiplayerActivityDetails[] array = new Unity.XGamingRuntime.Interop.XblMultiplayerActivityDetails[activityCount.ToInt32()];
					int num3 = XblInterop.XblMultiplayerGetActivitiesForUsersResult(block, activityCount, array);
					if (!Unity.XGamingRuntime.Interop.HR.FAILED(num3))
					{
						completionRoutine(num3, Array.ConvertAll(array, (Unity.XGamingRuntime.Interop.XblMultiplayerActivityDetails h) => new XblMultiplayerActivityDetails(h)));
					}
					else
					{
						completionRoutine(num3, new XblMultiplayerActivityDetails[0]);
					}
				}
			});
			int num = XblInterop.XblMultiplayerGetActivitiesForUsersAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(scid), xuids, new SizeT((xuids != null) ? xuids.Length : 0), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, new XblMultiplayerActivityDetails[0]);
			}
		}

		public static void XblMultiplayerGetActivitiesWithPropertiesForUsersAsync(XblContextHandle xboxLiveContext, string scid, ulong[] xuids, XblMultiplayerGetActivitiesResult completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809, new XblMultiplayerActivityDetails[0]);
				return;
			}
			int hr;
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				hr = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForUsersResultSize(block, out var resultSizeInBytes);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(hr))
				{
					completionRoutine(hr, new XblMultiplayerActivityDetails[0]);
					return;
				}
				using DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32());
				hr = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForUsersResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var ptrToBuffer, out var ptrToBufferCount, out var _);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(hr))
				{
					completionRoutine(hr, null);
				}
				else
				{
					completionRoutine(hr, Converters.PtrToClassArray(ptrToBuffer, ptrToBufferCount, (Unity.XGamingRuntime.Interop.XblMultiplayerActivityDetails r) => new XblMultiplayerActivityDetails(r)));
				}
			});
			hr = XblInterop.XblMultiplayerGetActivitiesWithPropertiesForUsersAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(scid), xuids, new SizeT((xuids != null) ? xuids.Length : 0), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(hr))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(hr, new XblMultiplayerActivityDetails[0]);
			}
		}

		public static int XblMultiplayerSetSubscriptionsEnabled(XblContextHandle xblContext, bool subscriptionsEnabled)
		{
			return XblInterop.XblMultiplayerSetSubscriptionsEnabled(xblContext.Handle, subscriptionsEnabled);
		}

		public static bool XblMultiplayerSubscriptionsEnabled(XblContextHandle xblHandle)
		{
			return XblInterop.XblMultiplayerSubscriptionsEnabled(xblHandle.Handle);
		}

		public static int XblMultiplayerSessionSetCustomPropertyJson(XblMultiplayerSessionHandle handle, string name, string valueJson)
		{
			return XblInterop.XblMultiplayerSessionSetCustomPropertyJson(handle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson));
		}

		public static int XblMultiplayerSessionDeleteCustomPropertyJson(XblMultiplayerSessionHandle handle, string name)
		{
			return XblInterop.XblMultiplayerSessionDeleteCustomPropertyJson(handle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(name));
		}

		public static XblMultiplayerSessionChangeTypes XblMultiplayerSessionCompare(XblMultiplayerSessionHandle currentSessionHandle, XblMultiplayerSessionHandle oldSessionHandle)
		{
			if (currentSessionHandle == null || oldSessionHandle == null)
			{
				return XblMultiplayerSessionChangeTypes.Everything;
			}
			return XblInterop.XblMultiplayerSessionCompare(currentSessionHandle.Handle, oldSessionHandle.Handle);
		}

		public static int XblMultiplayerActivityUpdateRecentPlayers(XblContextHandle xboxLiveContext, XblMultiplayerActivityRecentPlayerUpdate[] updates)
		{
			if (xboxLiveContext == null)
			{
				return -2147024809;
			}
			Unity.XGamingRuntime.Interop.XblMultiplayerActivityRecentPlayerUpdate[] updates2 = Converters.ConvertArrayToFixedLength(updates, updates.Length, (XblMultiplayerActivityRecentPlayerUpdate r) => new Unity.XGamingRuntime.Interop.XblMultiplayerActivityRecentPlayerUpdate(r));
			return XblInterop.XblMultiplayerActivityUpdateRecentPlayers(xboxLiveContext.Handle, updates2, new SizeT((updates != null) ? updates.Length : 0));
		}

		public static void XblMultiplayerActivityFlushRecentPlayersAsync(XblContextHandle xboxLiveContext, XblMultiplayerActivityAsyncOperationCompleted completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false));
			});
			int num = XblInterop.XblMultiplayerActivityFlushRecentPlayersAsync(xboxLiveContext.Handle, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num);
			}
		}

		public static void XblMultiplayerActivitySetActivityAsync(XblContextHandle xboxLiveContext, XblMultiplayerActivityInfo activityInfo, bool allowCrossPlatformJoin, XblMultiplayerActivityAsyncOperationCompleted completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false));
			});
			using DisposableCollection disposableCollection = new DisposableCollection();
			Unity.XGamingRuntime.Interop.XblMultiplayerActivityInfo activityInfo2 = new Unity.XGamingRuntime.Interop.XblMultiplayerActivityInfo(activityInfo, disposableCollection);
			int num = XblInterop.XblMultiplayerActivitySetActivityAsync(xboxLiveContext.Handle, ref activityInfo2, allowCrossPlatformJoin, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num);
			}
		}

		public static void XblMultiplayerActivityGetActivityAsync(XblContextHandle xboxLiveContext, ulong[] xboxUserIdList, XblMultiplayerGetActivityAsyncOperationCompleted completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			int hr;
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				hr = XblInterop.XblMultiplayerActivityGetActivityResultSize(block, out var resultSizeInBytes);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(hr))
				{
					completionRoutine(hr, null);
					return;
				}
				using DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32());
				hr = XblInterop.XblMultiplayerActivityGetActivityResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var ptrToBufferResults, out var resultCount, out var _);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(hr))
				{
					completionRoutine(hr, null);
				}
				else
				{
					completionRoutine(hr, Converters.PtrToClassArray(ptrToBufferResults, resultCount, (Unity.XGamingRuntime.Interop.XblMultiplayerActivityInfo r) => new XblMultiplayerActivityInfo(r)));
				}
			});
			hr = XblInterop.XblMultiplayerActivityGetActivityAsync(xboxLiveContext.Handle, xboxUserIdList, new SizeT((xboxUserIdList != null) ? xboxUserIdList.Length : 0), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(hr))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(hr, null);
			}
		}

		public static void XblMultiplayerActivityDeleteActivityAsync(XblContextHandle xboxLiveContext, XblMultiplayerActivityAsyncOperationCompleted completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false));
			});
			int num = XblInterop.XblMultiplayerActivityDeleteActivityAsync(xboxLiveContext.Handle, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num);
			}
		}

		public static void XblMultiplayerActivitySendInvitesAsync(XblContextHandle xboxLiveContext, ulong[] xboxUserIdList, bool allowCrossPlatformJoin, string connectionString, XblMultiplayerActivityAsyncOperationCompleted completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false));
			});
			int num = XblInterop.XblMultiplayerActivitySendInvitesAsync(xboxLiveContext.Handle, xboxUserIdList, new SizeT((xboxUserIdList != null) ? xboxUserIdList.Length : 0), allowCrossPlatformJoin, Converters.StringToNullTerminatedUTF8ByteArray(connectionString), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num);
			}
		}

		public static int XblMultiplayerManagerInitialize(string lobbySessionTemplateName)
		{
			return XblInterop.XblMultiplayerManagerInitialize(Converters.StringToNullTerminatedUTF8ByteArray(lobbySessionTemplateName), defaultQueue);
		}

		public static int XblMultiplayerManagerDoWork(out XblMultiplayerEvent[] events)
		{
			int num = XblInterop.XblMultiplayerManagerDoWork(out var multiplayerEvents, out var multiplayerEventsCount);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				events = null;
				return num;
			}
			events = Converters.PtrToClassArray(multiplayerEvents, multiplayerEventsCount, (Unity.XGamingRuntime.Interop.XblMultiplayerEvent x) => new XblMultiplayerEvent(x));
			return num;
		}

		public static XblMultiplayerSessionReference XblMultiplayerSessionReferenceCreate(string scid, string sessionTemplateName, string sessionName)
		{
			return new XblMultiplayerSessionReference(XblInterop.XblMultiplayerSessionReferenceCreate(Converters.StringToNullTerminatedUTF8ByteArray(scid), Converters.StringToNullTerminatedUTF8ByteArray(sessionTemplateName), Converters.StringToNullTerminatedUTF8ByteArray(sessionName)));
		}

		public static int XblMultiplayerManagerJoinLobby(string handleId, XUserHandle user)
		{
			if (user == null)
			{
				return -2147024809;
			}
			return XblInterop.XblMultiplayerManagerJoinLobby(Converters.StringToNullTerminatedUTF8ByteArray(handleId), user.Handle);
		}

		public static int XblMultiplayerManagerSetQosMeasurements(string measurementsJson)
		{
			return XblInterop.XblMultiplayerManagerSetQosMeasurements(Converters.StringToNullTerminatedUTF8ByteArray(measurementsJson));
		}

		public static int XblMultiplayerManagerSetJoinability(XblMultiplayerJoinability joinability, object context)
		{
			return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerSetJoinability(joinability, ctx), context);
		}

		public static int XblMultiplayerManagerJoinGameFromLobby(string sessionTemplateName)
		{
			return XblInterop.XblMultiplayerManagerJoinGameFromLobby(Converters.StringToNullTerminatedUTF8ByteArray(sessionTemplateName));
		}

		public static void XblMultiplayerManagerSetAutoFillMembersDuringMatchmaking(bool autoFillMembers)
		{
			XblInterop.XblMultiplayerManagerSetAutoFillMembersDuringMatchmaking(new NativeBool(autoFillMembers));
		}

		public static XblMultiplayerJoinability XblMultiplayerManagerJoinability()
		{
			return XblInterop.XblMultiplayerManagerJoinability();
		}

		public static void XblMultiplayerManagerCancelMatch()
		{
			XblInterop.XblMultiplayerManagerCancelMatch();
		}

		public static uint XblMultiplayerManagerEstimatedMatchWaitTime()
		{
			return XblInterop.XblMultiplayerManagerEstimatedMatchWaitTime();
		}

		public static bool XblMultiplayerManagerMemberAreMembersOnSameDevice(XblMultiplayerManagerMember first, XblMultiplayerManagerMember second)
		{
			using DisposableCollection disposableCollection = new DisposableCollection();
			Unity.XGamingRuntime.Interop.XblMultiplayerManagerMember first2 = new Unity.XGamingRuntime.Interop.XblMultiplayerManagerMember(first, disposableCollection);
			Unity.XGamingRuntime.Interop.XblMultiplayerManagerMember second2 = new Unity.XGamingRuntime.Interop.XblMultiplayerManagerMember(second, disposableCollection);
			return XblInterop.XblMultiplayerManagerMemberAreMembersOnSameDevice(ref first2, ref second2).Value;
		}

		public static int XblMultiplayerSessionReferenceParseFromUriPath(string path, out XblMultiplayerSessionReference sessionReference)
		{
			int num = XblInterop.XblMultiplayerSessionReferenceParseFromUriPath(Converters.StringToNullTerminatedUTF8ByteArray(path), out var sessionReference2);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				sessionReference = null;
				return num;
			}
			sessionReference = new XblMultiplayerSessionReference(sessionReference2);
			return num;
		}

		public static int XblMultiplayerSessionReferenceToUriPath(XblMultiplayerSessionReference sessionReference, out XblMultiplayerSessionReferenceUri sessionReferenceUri)
		{
			int num = XblInterop.XblMultiplayerSessionReferenceToUriPath(new Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference(sessionReference), out var sessionReferenceUri2);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				sessionReferenceUri = null;
				return num;
			}
			sessionReferenceUri = new XblMultiplayerSessionReferenceUri(sessionReferenceUri2);
			return num;
		}

		public static int XblMultiplayerManagerLeaveGame()
		{
			return XblInterop.XblMultiplayerManagerLeaveGame();
		}

		public static XblMultiplayerMatchStatus XblMultiplayerManagerMatchStatus()
		{
			return XblInterop.XblMultiplayerManagerMatchStatus();
		}

		public static bool XblMultiplayerManagerAutoFillMembersDuringMatchmaking()
		{
			return XblInterop.XblMultiplayerManagerAutoFillMembersDuringMatchmaking().Value;
		}

		public static int XblMultiplayerManagerFindMatch(string hopperName, string attributesJson, uint timeoutInSeconds)
		{
			return XblInterop.XblMultiplayerManagerFindMatch(Converters.StringToNullTerminatedUTF8ByteArray(hopperName), Converters.StringToNullTerminatedUTF8ByteArray(attributesJson), timeoutInSeconds);
		}

		public static bool XblMultiplayerSessionReferenceIsValid(XblMultiplayerSessionReference sessionReference)
		{
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference sessionReference2 = new Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference(sessionReference);
			return XblInterop.XblMultiplayerSessionReferenceIsValid(ref sessionReference2).Value;
		}

		public static int XblMultiplayerManagerJoinGame(string sessionName, string sessionTemplateName, ulong[] xuids)
		{
			return XblInterop.XblMultiplayerManagerJoinGame(Converters.StringToNullTerminatedUTF8ByteArray(sessionName), Converters.StringToNullTerminatedUTF8ByteArray(sessionTemplateName), xuids, new SizeT(xuids.Length));
		}

		public static int XblMultiplayerEventArgsTournamentRegistrationStateChanged(XblMultiplayerEventArgsHandle argsHandle, out XblTournamentRegistrationState registrationState, out XblTournamentRegistrationReason registrationReason)
		{
			if (argsHandle == null)
			{
				registrationState = XblTournamentRegistrationState.Unknown;
				registrationReason = XblTournamentRegistrationReason.Unknown;
				return -2147024809;
			}
			return XblInterop.XblMultiplayerEventArgsTournamentRegistrationStateChanged(argsHandle.Handle, out registrationState, out registrationReason);
		}

		public static int XblMultiplayerEventArgsFindMatchCompleted(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerMatchStatus matchStatus, out XblMultiplayerMeasurementFailure initializationFailureCause)
		{
			if (argsHandle == null)
			{
				matchStatus = XblMultiplayerMatchStatus.None;
				initializationFailureCause = XblMultiplayerMeasurementFailure.Unknown;
				return -2147024809;
			}
			return XblInterop.XblMultiplayerEventArgsFindMatchCompleted(argsHandle.Handle, out matchStatus, out initializationFailureCause);
		}

		public static int XblMultiplayerEventArgsPropertiesJson(XblMultiplayerEventArgsHandle argsHandle, out string properties)
		{
			properties = null;
			if (argsHandle == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblMultiplayerEventArgsPropertiesJson(argsHandle.Handle, out var properties2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				properties = properties2.GetString();
			}
			return num;
		}

		public static int XblMultiplayerEventArgsXuid(XblMultiplayerEventArgsHandle argsHandle, out ulong xuid)
		{
			xuid = 0uL;
			if (argsHandle == null)
			{
				return -2147024809;
			}
			return XblInterop.XblMultiplayerEventArgsXuid(argsHandle.Handle, out xuid);
		}

		public static int XblMultiplayerEventArgsTournamentGameSessionReady(XblMultiplayerEventArgsHandle argsHandle, out DateTime startTime)
		{
			startTime = default;
			if (argsHandle == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblMultiplayerEventArgsTournamentGameSessionReady(argsHandle.Handle, out var startTime2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				startTime = startTime2.DateTime;
			}
			return num;
		}

		public static int XblMultiplayerEventArgsMember(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerManagerMember member)
		{
			member = null;
			if (argsHandle == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblMultiplayerEventArgsMember(argsHandle.Handle, out var member2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				member = new XblMultiplayerManagerMember(member2);
			}
			return num;
		}

		public static int XblMultiplayerEventArgsMembers(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerManagerMember[] members)
		{
			members = null;
			if (argsHandle == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblMultiplayerEventArgsMembersCount(argsHandle.Handle, out var memberCount);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				return num;
			}
			Unity.XGamingRuntime.Interop.XblMultiplayerManagerMember[] array = new Unity.XGamingRuntime.Interop.XblMultiplayerManagerMember[memberCount.ToInt32()];
			num = XblInterop.XblMultiplayerEventArgsMembers(argsHandle.Handle, memberCount, array);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				members = Array.ConvertAll(array, (Unity.XGamingRuntime.Interop.XblMultiplayerManagerMember x) => new XblMultiplayerManagerMember(x));
			}
			return num;
		}

		public static int XblMultiplayerEventArgsPerformQoSMeasurements(XblMultiplayerEventArgsHandle argsHandle, out XblMultiplayerPerformQoSMeasurementsArgs performQoSMeasurementsArgs)
		{
			performQoSMeasurementsArgs = null;
			if (argsHandle == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblMultiplayerEventArgsPerformQoSMeasurements(argsHandle.Handle, out var performQoSMeasurementsArgs2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				performQoSMeasurementsArgs = new XblMultiplayerPerformQoSMeasurementsArgs(performQoSMeasurementsArgs2);
			}
			return num;
		}

		private static int SessionSetInternalWithMarshalledContext(Func<IntPtr, int> setterFunction, object context)
		{
			IntPtr intPtr = IntPtr.Zero;
			if (context != null)
			{
				intPtr = GCHandle.ToIntPtr(GCHandle.Alloc(context));
			}
			int num = setterFunction(intPtr);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num) && intPtr != IntPtr.Zero)
			{
				GCHandle.FromIntPtr(intPtr).Free();
			}
			return num;
		}

		public static bool XblMultiplayerManagerGameSessionIsHost(ulong xuid)
		{
			return XblInterop.XblMultiplayerManagerGameSessionIsHost(xuid).Value;
		}

		public static int XblMultiplayerManagerGameSessionHost(out XblMultiplayerManagerMember hostMember)
		{
			hostMember = null;
			int num = XblInterop.XblMultiplayerManagerGameSessionHost(out var hostMember2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				hostMember = new XblMultiplayerManagerMember(hostMember2);
			}
			return num;
		}

		public static int XblMultiplayerManagerLobbySessionSessionReference(out XblMultiplayerSessionReference sessionReference)
		{
			sessionReference = null;
			int num = XblInterop.XblMultiplayerManagerLobbySessionSessionReference(out var sessionReference2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				sessionReference = new XblMultiplayerSessionReference(sessionReference2);
			}
			return num;
		}

		public unsafe static XblMultiplayerSessionReference XblMultiplayerManagerGameSessionSessionReference()
		{
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionReference* ptr = XblInterop.XblMultiplayerManagerGameSessionSessionReference();
			if (ptr == null)
			{
				return null;
			}
			return new XblMultiplayerSessionReference(*ptr);
		}

		public static bool XblMultiplayerManagerGameSessionActive()
		{
			return XblInterop.XblMultiplayerManagerGameSessionActive().Value;
		}

		public static int XblMultiplayerManagerGameSessionSetProperties(string name, string valueJson, object context)
		{
			return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerGameSessionSetProperties(Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson), ctx), context);
		}

		public static int XblMultiplayerManagerGameSessionSetSynchronizedHost(string deviceToken, object context)
		{
			return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerGameSessionSetSynchronizedHost(Converters.StringToNullTerminatedUTF8ByteArray(deviceToken), ctx), context);
		}

		public static int XblMultiplayerManagerGameSessionSetSynchronizedProperties(string name, string valueJson, object context)
		{
			return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerGameSessionSetSynchronizedProperties(Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson), ctx), context);
		}

		public static string XblMultiplayerManagerGameSessionCorrelationId()
		{
			return XblInterop.XblMultiplayerManagerGameSessionCorrelationId().GetString();
		}

		public unsafe static XblMultiplayerSessionConstants XblMultiplayerManagerGameSessionConstants()
		{
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionConstants* ptr = XblInterop.XblMultiplayerManagerGameSessionConstants();
			if (ptr == null)
			{
				return null;
			}
			return new XblMultiplayerSessionConstants(*ptr);
		}

		public static int XblMultiplayerManagerGameSessionMembers(out XblMultiplayerManagerMember[] members)
		{
			members = null;
			SizeT membersCount = XblInterop.XblMultiplayerManagerGameSessionMembersCount();
			if (membersCount.IsZero)
			{
				return 0;
			}
			Unity.XGamingRuntime.Interop.XblMultiplayerManagerMember[] array = new Unity.XGamingRuntime.Interop.XblMultiplayerManagerMember[membersCount.ToInt32()];
			int num = XblInterop.XblMultiplayerManagerGameSessionMembers(membersCount, array);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				members = Array.ConvertAll(array, (Unity.XGamingRuntime.Interop.XblMultiplayerManagerMember x) => new XblMultiplayerManagerMember(x));
			}
			return num;
		}

		public static string XblMultiplayerManagerGameSessionPropertiesJson()
		{
			return XblInterop.XblMultiplayerManagerGameSessionPropertiesJson().GetString();
		}

		public static int XblMultiplayerManagerLobbySessionHost(out XblMultiplayerManagerMember hostMember)
		{
			hostMember = null;
			int num = XblInterop.XblMultiplayerManagerLobbySessionHost(out var hostMember2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				hostMember = new XblMultiplayerManagerMember(hostMember2);
			}
			return num;
		}

		public static int XblMultiplayerManagerLobbySessionInviteUsers(XUserHandle user, ulong[] xuids, string contextStringId, string customActivationContext)
		{
			if (user == null)
			{
				return -2147024809;
			}
			return XblInterop.XblMultiplayerManagerLobbySessionInviteUsers(user.Handle, xuids, new SizeT(xuids.Length), Converters.StringToNullTerminatedUTF8ByteArray(contextStringId), Converters.StringToNullTerminatedUTF8ByteArray(customActivationContext));
		}

		public static int XblMultiplayerManagerLobbySessionInviteFriends(XUserHandle requestingUser, string contextStringId, string customActivationContext)
		{
			if (requestingUser == null)
			{
				return -2147024809;
			}
			return XblInterop.XblMultiplayerManagerLobbySessionInviteFriends(requestingUser.Handle, Converters.StringToNullTerminatedUTF8ByteArray(contextStringId), Converters.StringToNullTerminatedUTF8ByteArray(customActivationContext));
		}

		public static int XblMultiplayerManagerLobbySessionAddLocalUser(XUserHandle user)
		{
			if (user == null)
			{
				return -2147024809;
			}
			return XblInterop.XblMultiplayerManagerLobbySessionAddLocalUser(user.Handle);
		}

		public static int XblMultiplayerManagerLobbySessionMembers(out XblMultiplayerManagerMember[] members)
		{
			members = null;
			SizeT membersCount = XblInterop.XblMultiplayerManagerLobbySessionMembersCount();
			if (membersCount.IsZero)
			{
				return 0;
			}
			Unity.XGamingRuntime.Interop.XblMultiplayerManagerMember[] array = new Unity.XGamingRuntime.Interop.XblMultiplayerManagerMember[membersCount.ToInt32()];
			int num = XblInterop.XblMultiplayerManagerLobbySessionMembers(membersCount, array);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				members = Array.ConvertAll(array, (Unity.XGamingRuntime.Interop.XblMultiplayerManagerMember x) => new XblMultiplayerManagerMember(x));
			}
			return num;
		}

		public static string XblMultiplayerManagerLobbySessionPropertiesJson()
		{
			return XblInterop.XblMultiplayerManagerLobbySessionPropertiesJson().GetString();
		}

		public unsafe static XblMultiplayerSessionConstants XblMultiplayerManagerLobbySessionConstants()
		{
			Unity.XGamingRuntime.Interop.XblMultiplayerSessionConstants* ptr = XblInterop.XblMultiplayerManagerLobbySessionConstants();
			if (ptr == null)
			{
				return null;
			}
			return new XblMultiplayerSessionConstants(*ptr);
		}

		public static int XblMultiplayerManagerLobbySessionLocalMembers(out XblMultiplayerManagerMember[] localMembers)
		{
			localMembers = null;
			SizeT localMembersCount = XblInterop.XblMultiplayerManagerLobbySessionLocalMembersCount();
			if (localMembersCount.IsZero)
			{
				return 0;
			}
			Unity.XGamingRuntime.Interop.XblMultiplayerManagerMember[] array = new Unity.XGamingRuntime.Interop.XblMultiplayerManagerMember[localMembersCount.ToInt32()];
			int num = XblInterop.XblMultiplayerManagerLobbySessionLocalMembers(localMembersCount, array);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				localMembers = Array.ConvertAll(array, (Unity.XGamingRuntime.Interop.XblMultiplayerManagerMember x) => new XblMultiplayerManagerMember(x));
			}
			return num;
		}

		public static int XblMultiplayerManagerLobbySessionRemoveLocalUser(XUserHandle user)
		{
			if (user == null)
			{
				return -2147024809;
			}
			return XblInterop.XblMultiplayerManagerLobbySessionRemoveLocalUser(user.Handle);
		}

		public unsafe static XblTournamentTeamResult XblMultiplayerManagerLobbySessionLastTournamentTeamResult()
		{
			Unity.XGamingRuntime.Interop.XblTournamentTeamResult* ptr = XblInterop.XblMultiplayerManagerLobbySessionLastTournamentTeamResult();
			if (ptr == null)
			{
				return null;
			}
			return new XblTournamentTeamResult(*ptr);
		}

		public static bool XblMultiplayerManagerLobbySessionIsHost(ulong xuid)
		{
			return XblInterop.XblMultiplayerManagerLobbySessionIsHost(xuid).Value;
		}

		public static int XblMultiplayerManagerLobbySessionCorrelationId(out XblGuid correlationId)
		{
			correlationId = null;
			int num = XblInterop.XblMultiplayerManagerLobbySessionCorrelationId(out var correlationId2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				correlationId = new XblGuid(correlationId2);
			}
			return num;
		}

		public static int XblMultiplayerManagerLobbySessionSetSynchronizedHost(string deviceToken, object context)
		{
			return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerLobbySessionSetSynchronizedHost(Converters.StringToNullTerminatedUTF8ByteArray(deviceToken), ctx), context);
		}

		public static int XblMultiplayerManagerLobbySessionSetProperties(string name, string valueJson, object context)
		{
			return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerLobbySessionSetProperties(Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson), ctx), context);
		}

		public static int XblMultiplayerManagerLobbySessionSetLocalMemberProperties(XUserHandle user, string name, string valueJson, object context)
		{
			if (user == null)
			{
				return -2147024809;
			}
			return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerLobbySessionSetLocalMemberProperties(user.Handle, Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson), ctx), context);
		}

		public static int XblMultiplayerManagerLobbySessionSetSynchronizedProperties(string name, string valueJson, object context)
		{
			return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerLobbySessionSetSynchronizedProperties(Converters.StringToNullTerminatedUTF8ByteArray(name), Converters.StringToNullTerminatedUTF8ByteArray(valueJson), ctx), context);
		}

		public static int XblMultiplayerManagerLobbySessionSetLocalMemberConnectionAddress(XUserHandle user, string connectionAddress, object context)
		{
			if (user == null)
			{
				return -2147024809;
			}
			return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerLobbySessionSetLocalMemberConnectionAddress(user.Handle, Converters.StringToNullTerminatedUTF8ByteArray(connectionAddress), ctx), context);
		}

		public static int XblMultiplayerManagerLobbySessionDeleteLocalMemberProperties(XUserHandle user, string name, object context)
		{
			if (user == null)
			{
				return -2147024809;
			}
			return SessionSetInternalWithMarshalledContext((IntPtr ctx) => XblInterop.XblMultiplayerManagerLobbySessionDeleteLocalMemberProperties(user.Handle, Converters.StringToNullTerminatedUTF8ByteArray(name), ctx), context);
		}

		public static int XblPresenceRecordGetXuid(XblPresenceRecordHandle handle, out ulong xuid)
		{
			if (handle == null)
			{
				xuid = 0uL;
				return -2147024809;
			}
			return XblInterop.XblPresenceRecordGetXuid(handle.Handle, out xuid);
		}

		public static int XblPresenceRecordGetUserState(XblPresenceRecordHandle handle, out XblPresenceUserState userState)
		{
			if (handle == null)
			{
				userState = XblPresenceUserState.Unknown;
				return -2147024809;
			}
			return XblInterop.XblPresenceRecordGetUserState(handle.Handle, out userState);
		}

		public static int XblPresenceRecordGetDeviceRecords(XblPresenceRecordHandle handle, out XblPresenceDeviceRecord[] deviceRecords)
		{
			if (handle == null)
			{
				deviceRecords = null;
				return -2147024809;
			}
			int num = XblInterop.XblPresenceRecordGetDeviceRecords(handle.Handle, out var deviceRecords2, out var deviceRecordsCount);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				deviceRecords = null;
				return num;
			}
			deviceRecords = Converters.PtrToClassArray(deviceRecords2, deviceRecordsCount, (Unity.XGamingRuntime.Interop.XblPresenceDeviceRecord dr) => new XblPresenceDeviceRecord(dr));
			return num;
		}

		public static int XblPresenceRecordDuplicateHandle(XblPresenceRecordHandle handle, out XblPresenceRecordHandle duplicatedHandle)
		{
			if (handle == null)
			{
				duplicatedHandle = null;
				return -2147024809;
			}
			Unity.XGamingRuntime.Interop.XblPresenceRecordHandle duplicatedHandle2;
			return XblPresenceRecordHandle.WrapInteropHandleAndReturnHResult(XblInterop.XblPresenceRecordDuplicateHandle(handle.Handle, out duplicatedHandle2), duplicatedHandle2, out duplicatedHandle);
		}

		public static void XblPresenceRecordCloseHandle(XblPresenceRecordHandle handle)
		{
			if (!(handle == null))
			{
				handle.Close();
			}
		}

		public static void XblPresenceSetPresenceAsync(XblContextHandle xblContextHandle, bool isUserActiveInTitle, XblPresenceRichPresenceIds richPresenceIds, XblPresenceSetPresenceCompleted completionRoutine)
		{
			if (xblContextHandle == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false));
			});
			using DisposableCollection disposableCollection = new DisposableCollection();
			int num = XblInterop.XblPresenceSetPresenceAsync(xblContextHandle.Handle, isUserActiveInTitle, (richPresenceIds == null) ? null : new XblPresenceRichPresenceIdsRef(richPresenceIds, disposableCollection), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num);
			}
		}

		public static void XblPresenceGetPresenceAsync(XblContextHandle xblContextHandle, ulong xuid, XblPresenceGetPresenceCompleted completionRoutine)
		{
			if (xblContextHandle == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int hresult = XblInterop.XblPresenceGetPresenceResult(block, out var presenceRecordHandle);
				XblPresenceRecordHandle.WrapInteropHandleAndReturnHResult(hresult, presenceRecordHandle, out var handle);
				completionRoutine(hresult, handle);
			});
			int num = XblInterop.XblPresenceGetPresenceAsync(xblContextHandle.Handle, xuid, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static void XblPresenceGetPresenceForMultipleUsersAsync(XblContextHandle xblContextHandle, ulong[] xuids, XblPresenceQueryFilters filters, XblPresenceGetPresenceForMultipleUsersCompleted completionRoutine)
		{
			if (xblContextHandle == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblPresenceGetPresenceForMultipleUsersResultCount(block, out var resultCount);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					Unity.XGamingRuntime.Interop.XblPresenceRecordHandle[] array = new Unity.XGamingRuntime.Interop.XblPresenceRecordHandle[resultCount.ToInt32()];
					num2 = XblInterop.XblPresenceGetPresenceForMultipleUsersResult(block, array, resultCount);
					if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
					{
						completionRoutine(num2, null);
					}
					else
					{
						completionRoutine(num2, Array.ConvertAll(array, (Unity.XGamingRuntime.Interop.XblPresenceRecordHandle h) => new XblPresenceRecordHandle(h)));
					}
				}
			});
			using DisposableCollection disposableCollection = new DisposableCollection();
			int num = XblInterop.XblPresenceGetPresenceForMultipleUsersAsync(xblContextHandle.Handle, xuids, new SizeT((xuids != null) ? xuids.Length : 0), (filters == null) ? null : new XblPresenceQueryFiltersRef(filters, disposableCollection), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static void XblPresenceGetPresenceForSocialGroupAsync(XblContextHandle xblContextHandle, string socialGroupName, ulong? socialGroupOwnerXuid, XblPresenceQueryFilters filters, XblPresenceGetPresenceForSocialGroupCompleted completionRoutine)
		{
			if (xblContextHandle == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblPresenceGetPresenceForSocialGroupResultCount(block, out var resultCount);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					Unity.XGamingRuntime.Interop.XblPresenceRecordHandle[] array = new Unity.XGamingRuntime.Interop.XblPresenceRecordHandle[resultCount.ToInt32()];
					num2 = XblInterop.XblPresenceGetPresenceForSocialGroupResult(block, array, resultCount);
					if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
					{
						completionRoutine(num2, null);
					}
					else
					{
						completionRoutine(num2, Array.ConvertAll(array, (Unity.XGamingRuntime.Interop.XblPresenceRecordHandle h) => new XblPresenceRecordHandle(h)));
					}
				}
			});
			using DisposableCollection disposableCollection = new DisposableCollection();
			int num = XblInterop.XblPresenceGetPresenceForSocialGroupAsync(xblContextHandle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(socialGroupName), (!socialGroupOwnerXuid.HasValue) ? null : new UInt64Ref(socialGroupOwnerXuid.Value), (filters == null) ? null : new XblPresenceQueryFiltersRef(filters, disposableCollection), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static void XblPrivacyGetAvoidListAsync(XblContextHandle xblContextHandle, XblPrivacyGetAvoidListCompleted completionRoutine)
		{
			if (xblContextHandle == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblPrivacyGetAvoidListResultCount(block, out var xuidCount);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					ulong[] xuids = new ulong[xuidCount.ToInt32()];
					num2 = XblInterop.XblPrivacyGetAvoidListResult(block, xuidCount, xuids);
					completionRoutine(num2, xuids);
				}
			});
			int num = XblInterop.XblPrivacyGetAvoidListAsync(xblContextHandle.Handle, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static void XblPrivacyGetMuteListAsync(XblContextHandle xblContextHandle, XblPrivacyGetMuteListCompleted completionRoutine)
		{
			if (xblContextHandle == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblPrivacyGetMuteListResultCount(block, out var xuidCount);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					ulong[] xuids = new ulong[xuidCount.ToInt32()];
					num2 = XblInterop.XblPrivacyGetMuteListResult(block, xuidCount, xuids);
					completionRoutine(num2, xuids);
				}
			});
			int num = XblInterop.XblPrivacyGetMuteListAsync(xblContextHandle.Handle, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static void XblPrivacyCheckPermissionAsync(XblContextHandle xblContextHandle, XblPermission permissionToCheck, ulong targetXuid, XblPrivacyCheckPermissionCompleted completionRoutine)
		{
			if (xblContextHandle == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblPrivacyCheckPermissionResultSize(block, out var resultSizeInBytes);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
					return;
				}
				using DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32());
				num2 = XblInterop.XblPrivacyCheckPermissionResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var result, out var _);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					completionRoutine(num2, Converters.PtrToClass(result, (Unity.XGamingRuntime.Interop.XblPermissionCheckResult r) => new XblPermissionCheckResult(r)));
				}
			});
			int num = XblInterop.XblPrivacyCheckPermissionAsync(xblContextHandle.Handle, permissionToCheck, targetXuid, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				completionRoutine(num, null);
			}
		}

		public static void XblPrivacyCheckPermissionForAnonymousUserAsync(XblContextHandle xblContextHandle, XblPermission permissionToCheck, XblAnonymousUserType userType, XblPrivacyCheckPermissionCompleted completionRoutine)
		{
			if (xblContextHandle == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlockPtr async = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblPrivacyCheckPermissionForAnonymousUserResultSize(block, out var resultSizeInBytes);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
					return;
				}
				using DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32());
				num2 = XblInterop.XblPrivacyCheckPermissionForAnonymousUserResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var ptrToBuffer, out var _);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					completionRoutine(num2, Converters.PtrToClass(ptrToBuffer, (Unity.XGamingRuntime.Interop.XblPermissionCheckResult r) => new XblPermissionCheckResult(r)));
				}
			});
			int num = XblInterop.XblPrivacyCheckPermissionForAnonymousUserAsync(xblContextHandle.Handle, permissionToCheck, userType, async);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				completionRoutine(num, null);
			}
		}

		public static void XblPrivacyBatchCheckPermissionAsync(XblContextHandle xblContextHandle, XblPermission[] permissionsToCheck, ulong[] targetXuids, XblAnonymousUserType[] targetAnonymousUserTypes, XblPrivacyBatchCheckPermissionCompleted completionRoutine)
		{
			if (xblContextHandle == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblPrivacyBatchCheckPermissionResultSize(block, out var resultSizeInBytes);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
					return;
				}
				using DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32());
				num2 = XblInterop.XblPrivacyBatchCheckPermissionResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var results, out var resultsCount, out var _);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					completionRoutine(num2, Converters.PtrToClassArray(results, resultsCount, (Unity.XGamingRuntime.Interop.XblPermissionCheckResult r) => new XblPermissionCheckResult(r)));
				}
			});
			int num = XblInterop.XblPrivacyBatchCheckPermissionAsync(xblContextHandle.Handle, permissionsToCheck, new SizeT((permissionsToCheck != null) ? permissionsToCheck.Length : 0), targetXuids, new SizeT((targetXuids != null) ? targetXuids.Length : 0), targetAnonymousUserTypes, new SizeT((targetAnonymousUserTypes != null) ? targetAnonymousUserTypes.Length : 0), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static void XblProfileGetUserProfileAsync(XblContextHandle xblContextHandle, ulong xboxUserId, XblProfileGetUserProfileCompleted completionRoutine)
		{
			if (xblContextHandle == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblProfileGetUserProfileResult(block, out var profile);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					completionRoutine(num2, new XblUserProfile(profile));
				}
			});
			int num = XblInterop.XblProfileGetUserProfileAsync(xblContextHandle.Handle, xboxUserId, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				completionRoutine(num, null);
			}
		}

		public static void XblProfileGetUserProfilesAsync(XblContextHandle xblContextHandle, ulong[] xboxUserIds, XblProfileGetUserProfilesCompleted completionRoutine)
		{
			if (xblContextHandle == null || xboxUserIds == null || xboxUserIds.Length == 0)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblProfileGetUserProfilesResultCount(block, out var profileCount);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					Unity.XGamingRuntime.Interop.XblUserProfile[] array = new Unity.XGamingRuntime.Interop.XblUserProfile[profileCount.ToInt32()];
					num2 = XblInterop.XblProfileGetUserProfilesResult(block, profileCount, array);
					if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
					{
						completionRoutine(num2, null);
					}
					else
					{
						completionRoutine(num2, Array.ConvertAll(array, (Unity.XGamingRuntime.Interop.XblUserProfile x) => new XblUserProfile(x)));
					}
				}
			});
			int num = XblInterop.XblProfileGetUserProfilesAsync(xblContextHandle.Handle, xboxUserIds, new SizeT(xboxUserIds.Length), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				completionRoutine(num, null);
			}
		}

		public static void XblProfileGetUserProfilesForSocialGroupAsync(XblContextHandle xblContextHandle, string socialGroup, XblProfileGetUserProfilesForSocialGroupCompleted completionRoutine)
		{
			if (xblContextHandle == null || socialGroup == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblProfileGetUserProfilesForSocialGroupResultCount(block, out var profileCount);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					Unity.XGamingRuntime.Interop.XblUserProfile[] array = new Unity.XGamingRuntime.Interop.XblUserProfile[profileCount.ToInt32()];
					num2 = XblInterop.XblProfileGetUserProfilesForSocialGroupResult(block, profileCount, array);
					if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
					{
						completionRoutine(num2, null);
					}
					else
					{
						completionRoutine(num2, Array.ConvertAll(array, (Unity.XGamingRuntime.Interop.XblUserProfile x) => new XblUserProfile(x)));
					}
				}
			});
			int num = XblInterop.XblProfileGetUserProfilesForSocialGroupAsync(xblContextHandle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(socialGroup), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				completionRoutine(num, null);
			}
		}

		public static XblRealTimeActivityCallbackToken XblRealTimeActivityAddConnectionStateChangeHandler(XblContextHandle xboxLiveContext, XblConnectionStateChangeCallback callback)
		{
			int num = 0;
			if (callback != null)
			{
				IntPtr uniqueContext = _connectionStateChangeCallbackManager.GetUniqueContext();
				num = RealTimeActivity.XblRealTimeActivityAddConnectionStateChangeHandler(xboxLiveContext.Handle, ConnectionStateChangeCallbackManager.InteropPInvokeCallback, uniqueContext);
				if (XblRealTimeActivityCallbackToken.IsValid(num))
				{
					_connectionStateChangeCallbackManager.AddCallbackForId(num, uniqueContext, callback);
				}
			}
			return new XblRealTimeActivityCallbackToken
			{
				InteropHandlerId = num
			};
		}

		public static int XblRealTimeActivityRemoveConnectionStateChangeHandler(XblContextHandle xboxLiveContext, ref XblRealTimeActivityCallbackToken connectionStateChangeCallbackToken)
		{
			int num = RealTimeActivity.XblRealTimeActivityRemoveConnectionStateChangeHandler(xboxLiveContext.Handle, connectionStateChangeCallbackToken.InteropHandlerId);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				_connectionStateChangeCallbackManager.RemoveCallbackForId(connectionStateChangeCallbackToken.InteropHandlerId);
				connectionStateChangeCallbackToken.Reset();
			}
			return num;
		}

		public static XblRealTimeActivityCallbackToken XblRealTimeActivityAddResyncHandler(XblContextHandle xboxLiveContext, XblConnectionResyncCallback callback)
		{
			int num = 0;
			if (callback != null)
			{
				IntPtr uniqueContext = _connectionResyncCallbackManager.GetUniqueContext();
				num = RealTimeActivity.XblRealTimeActivityAddResyncHandler(xboxLiveContext.Handle, ConnectionResyncCallbackManager.InteropPInvokeCallback, uniqueContext);
				if (XblRealTimeActivityCallbackToken.IsValid(num))
				{
					_connectionResyncCallbackManager.AddCallbackForId(num, uniqueContext, callback);
				}
			}
			return new XblRealTimeActivityCallbackToken
			{
				InteropHandlerId = num
			};
		}

		public static int XblRealTimeActivityRemoveResyncHandler(XblContextHandle xboxLiveContext, ref XblRealTimeActivityCallbackToken connectionResyncCallbackToken)
		{
			int num = RealTimeActivity.XblRealTimeActivityRemoveResyncHandler(xboxLiveContext.Handle, connectionResyncCallbackToken.InteropHandlerId);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				_connectionResyncCallbackManager.RemoveCallbackForId(connectionResyncCallbackToken.InteropHandlerId);
				connectionResyncCallbackToken.Reset();
			}
			return num;
		}

		public static void XblSocialGetSocialRelationshipsAsync(XblContextHandle xboxLiveContext, ulong xboxUserId, XblSocialRelationshipFilter socialRelationshipFilter, uint startIndex, uint maxItems, XblSocialGetSocialRelationshipsResult completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblSocialGetSocialRelationshipsResult(block, out var handle);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					completionRoutine(num2, new XblSocialRelationshipResult(handle));
				}
			});
			int num = XblInterop.XblSocialGetSocialRelationshipsAsync(xboxLiveContext.Handle, xboxUserId, socialRelationshipFilter, new SizeT(startIndex), new SizeT(maxItems), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static int XblSocialRelationshipResultGetRelationships(XblSocialRelationshipResult resultHandle, out XblSocialRelationship[] relationships)
		{
			if (resultHandle == null)
			{
				relationships = null;
				return -2147024809;
			}
			int num = XblInterop.XblSocialRelationshipResultGetRelationships(resultHandle.InteropHandle, out var relationships2, out var relationshipsCount);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				relationships = null;
				return num;
			}
			if (GetGdkEdition() >= 241000)
			{
				relationships = Converters.PtrToClassArray(relationships2, relationshipsCount, (XblSocialRelationship2 c) => new XblSocialRelationship(c));
			}
			else
			{
				relationships = Converters.PtrToClassArray(relationships2, relationshipsCount, (Unity.XGamingRuntime.Interop.XblSocialRelationship c) => new XblSocialRelationship(c));
			}
			return num;
		}

		public static int XblSocialRelationshipResultHasNext(XblSocialRelationshipResult result, out bool hasNext)
		{
			hasNext = false;
			if (result == null)
			{
				return -2147024809;
			}
			return XblInterop.XblSocialRelationshipResultHasNext(result.InteropHandle, out hasNext);
		}

		public static int XblSocialRelationshipResultGetTotalCount(XblSocialRelationshipResult result, out uint totalCount)
		{
			totalCount = 0u;
			if (result == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblSocialRelationshipResultGetTotalCount(result.InteropHandle, out var totalCount2);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				return num;
			}
			totalCount = totalCount2.ToUInt32();
			return num;
		}

		public static void XblSocialRelationshipResultGetNextAsync(XblContextHandle xboxLiveContext, XblSocialRelationshipResult result, uint maxItems, XblSocialRelationshipResultGetNextResult completionRoutine)
		{
			if (xboxLiveContext == null || result == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblSocialRelationshipResultGetNextResult(block, out var handle);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					completionRoutine(num2, new XblSocialRelationshipResult(handle));
				}
			});
			int num = XblInterop.XblSocialRelationshipResultGetNextAsync(xboxLiveContext.Handle, result.InteropHandle, new SizeT(maxItems), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static int XblSocialRelationshipResultDuplicateHandle(XblSocialRelationshipResult handle, out XblSocialRelationshipResult duplicatedHandle)
		{
			duplicatedHandle = null;
			if (handle == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblSocialRelationshipResultDuplicateHandle(handle.InteropHandle, out var duplicatedHandle2);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				return num;
			}
			duplicatedHandle = new XblSocialRelationshipResult(duplicatedHandle2);
			return num;
		}

		public static void XblSocialRelationshipResultCloseHandle(XblSocialRelationshipResult handle)
		{
			handle.Dispose();
		}

		public unsafe static int XblSocialAddSocialRelationshipChangedHandler(XblContextHandle xboxLiveContext, XblSocialRelationshipChangedCallback eventCallback)
		{
			IntPtr uniqueContext = _socialRelationshipChangeCallbackManager.GetUniqueContext();
			int num = XblInterop.XblSocialAddSocialRelationshipChangedHandler(xboxLiveContext.Handle, SocialRelationshipChangeCallbackManager.InteropPInvokeCallback, uniqueContext);
			if (num != 0)
			{
				_socialRelationshipChangeCallbackManager.AddCallbackForId(num, uniqueContext, eventCallback);
			}
			return num;
		}

		public static int XblSocialRemoveSocialRelationshipChangedHandler(XblContextHandle xboxLiveContext, int callbackFunctionId)
		{
			int num = XblInterop.XblSocialRemoveSocialRelationshipChangedHandler(xboxLiveContext.Handle, callbackFunctionId);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				_socialRelationshipChangeCallbackManager.RemoveCallbackForId(callbackFunctionId);
			}
			return num;
		}

		public static bool XblSocialManagerPresenceRecordIsUserPlayingTitle(XblSocialManagerPresenceRecord presenceRecord, uint titleId)
		{
			Unity.XGamingRuntime.Interop.XblSocialManagerPresenceRecord presenceRecord2 = new Unity.XGamingRuntime.Interop.XblSocialManagerPresenceRecord(presenceRecord);
			return XblInterop.XblSocialManagerPresenceRecordIsUserPlayingTitle(ref presenceRecord2, titleId);
		}

		public static int XblSocialManagerUserGroupGetUsers(XblSocialManagerUserGroupHandle group, out XblSocialManagerUser[] xboxSocialUsers)
		{
			xboxSocialUsers = null;
			if (group == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblSocialManagerUserGroupGetUsers(group.Handle, out var xboxSocialUsers2, out var usersCount);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				return num;
			}
			if (GetGdkEdition() >= 241000)
			{
				xboxSocialUsers = Converters.PtrToClassArray(xboxSocialUsers2, usersCount, (IntPtr intPtr) => Converters.PtrToClass(intPtr, (XblSocialManagerUser2 u) => new XblSocialManagerUser(u)));
			}
			else
			{
				xboxSocialUsers = Converters.PtrToClassArray(xboxSocialUsers2, usersCount, (IntPtr intPtr) => Converters.PtrToClass(intPtr, (Unity.XGamingRuntime.Interop.XblSocialManagerUser u) => new XblSocialManagerUser(u)));
			}
			return num;
		}

		public static int XblSocialManagerUserGroupGetUsersTrackedByGroup(XblSocialManagerUserGroupHandle group, out ulong[] trackedUsers)
		{
			trackedUsers = null;
			if (group == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblSocialManagerUserGroupGetUsersTrackedByGroup(group.Handle, out var trackedUsers2, out var trackedUsersCount);
			if (!Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				trackedUsers = Converters.PtrToClassArray(trackedUsers2, trackedUsersCount.ToUInt32(), (ulong x) => x);
			}
			return num;
		}

		public static int XblSocialManagerAddLocalUser(XUserHandle user, XblSocialManagerExtraDetailLevel extraLevelDetail)
		{
			if (user == null)
			{
				return -2147024809;
			}
			return XblInterop.XblSocialManagerAddLocalUser(user.Handle, extraLevelDetail, defaultQueue);
		}

		public static int XblSocialManagerRemoveLocalUser(XUserHandle user, XblSocialManagerExtraDetailLevel extraLevelDetail)
		{
			if (user == null)
			{
				return -2147024809;
			}
			return XblInterop.XblSocialManagerRemoveLocalUser(user.Handle);
		}

		public static int XblSocialManagerDoWork(out XblSocialManagerEvent[] socialEvents)
		{
			int num = XblInterop.XblSocialManagerDoWork(out var socialEvents2, out var socialEventsCount);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				socialEvents = null;
				return num;
			}
			if (socialEvents2 == IntPtr.Zero)
			{
				socialEvents = null;
			}
			else
			{
				socialEvents = Converters.PtrToClassArray(socialEvents2, socialEventsCount, (Unity.XGamingRuntime.Interop.XblSocialManagerEvent e) => new XblSocialManagerEvent(e));
			}
			return num;
		}

		public static int XblSocialManagerCreateSocialUserGroupFromFilters(XUserHandle user, XblPresenceFilter presenceDetailLevel, XblRelationshipFilter filter, out XblSocialManagerUserGroupHandle group)
		{
			if (user == null)
			{
				group = null;
				return -2147024809;
			}
			Unity.XGamingRuntime.Interop.XblSocialManagerUserGroupHandle group2;
			return XblSocialManagerUserGroupHandle.WrapAndReturnHResult(XblInterop.XblSocialManagerCreateSocialUserGroupFromFilters(user.Handle, presenceDetailLevel, filter, out group2), group2, out group);
		}

		public static int XblSocialManagerCreateSocialUserGroupFromList(XUserHandle user, ulong[] xboxUserIdList, out XblSocialManagerUserGroupHandle group)
		{
			if (user == null)
			{
				group = null;
				return -2147024809;
			}
			Unity.XGamingRuntime.Interop.XblSocialManagerUserGroupHandle group2;
			return XblSocialManagerUserGroupHandle.WrapAndReturnHResult(XblInterop.XblSocialManagerCreateSocialUserGroupFromList(user.Handle, xboxUserIdList, new SizeT((xboxUserIdList != null) ? xboxUserIdList.Length : 0), out group2), group2, out group);
		}

		public static int XblSocialManagerDestroySocialUserGroup(XblSocialManagerUserGroupHandle group)
		{
			if (group == null)
			{
				return -2147024809;
			}
			int result = XblInterop.XblSocialManagerDestroySocialUserGroup(group.Handle);
			group.Close();
			return result;
		}

		public static int XblSocialManagerGetLocalUsers(out XUserHandle[] users)
		{
			SizeT usersCount = XblInterop.XblSocialManagerGetLocalUserCount();
			IntPtr[] array = new IntPtr[usersCount.ToInt32()];
			int num = XblInterop.XblSocialManagerGetLocalUsers(usersCount, array);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				users = null;
				return num;
			}
			users = Array.ConvertAll(array, (IntPtr u) => new XUserHandle(u, ownsHandle: false));
			return num;
		}

		public static int XblSocialManagerUpdateSocialUserGroup(XblSocialManagerUserGroupHandle group, ulong[] users)
		{
			if (group == null)
			{
				return -2147024809;
			}
			return XblInterop.XblSocialManagerUpdateSocialUserGroup(group.Handle, users, new SizeT((users != null) ? users.Length : 0));
		}

		public static int XblSocialManagerSetRichPresencePollingStatus(XUserHandle user, bool shouldEnablePolling)
		{
			if (user == null)
			{
				return -2147024809;
			}
			return XblInterop.XblSocialManagerSetRichPresencePollingStatus(user.Handle, shouldEnablePolling);
		}

		public static int XblSocialManagerUserGroupGetType(XblSocialManagerUserGroupHandle group, out XblSocialUserGroupType type)
		{
			type = XblSocialUserGroupType.FilterType;
			if (group == null)
			{
				return -2147024809;
			}
			return XblInterop.XblSocialManagerUserGroupGetType(group.Handle, out type);
		}

		public static int XblSocialManagerUserGroupGetLocalUser(XblSocialManagerUserGroupHandle group, out XUserHandle localUser)
		{
			localUser = null;
			if (group == null)
			{
				return -2147024809;
			}
			int num = XblInterop.XblSocialManagerUserGroupGetLocalUser(group.Handle, out var localUser2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num) && localUser2 != IntPtr.Zero)
			{
				localUser = new XUserHandle(localUser2, ownsHandle: false);
				return num;
			}
			localUser = null;
			return num;
		}

		public static int XblSocialManagerUserGroupGetFilters(XblSocialManagerUserGroupHandle group, out XblPresenceFilter presenceFilter, out XblRelationshipFilter relationshipFilter)
		{
			presenceFilter = XblPresenceFilter.Unknown;
			relationshipFilter = XblRelationshipFilter.Unknown;
			if (group == null)
			{
				return -2147024809;
			}
			return XblInterop.XblSocialManagerUserGroupGetFilters(group.Handle, out presenceFilter, out relationshipFilter);
		}

		public static void XblStringVerifyStringAsync(XblContextHandle xblContextHandle, string stringToVerify, XblStringVerifyStringCompleted completionRoutine)
		{
			if (xblContextHandle == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblStringVerifyStringResultSize(block, out var resultSizeInBytes);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
					return;
				}
				using DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32());
				num2 = XblInterop.XblStringVerifyStringResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var ptrToBuffer, out var _);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					completionRoutine(num2, Converters.PtrToClass(ptrToBuffer, (Unity.XGamingRuntime.Interop.XblVerifyStringResult r) => new XblVerifyStringResult(r)));
				}
			});
			int num = XblInterop.XblStringVerifyStringAsync(xblContextHandle.Handle, Converters.StringToNullTerminatedUTF8ByteArray(stringToVerify), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				completionRoutine(num, null);
			}
		}

		public static void XblStringVerifyStringsAsync(XblContextHandle xblContextHandle, string[] stringsToVerify, XblStringVerifyStringsCompleted completionRoutine)
		{
			if (xblContextHandle == null || stringsToVerify == null || stringsToVerify.Length == 0)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblStringVerifyStringsResultSize(block, out var resultSizeInBytes);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
					return;
				}
				using DisposableBuffer disposableBuffer2 = new DisposableBuffer(resultSizeInBytes.ToInt32());
				num2 = XblInterop.XblStringVerifyStringsResult(block, resultSizeInBytes, disposableBuffer2.IntPtr, out var ptrToBufferStrings, out var stringsCount, out var _);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					completionRoutine(num2, Converters.PtrToClassArray(ptrToBufferStrings, stringsCount, (Unity.XGamingRuntime.Interop.XblVerifyStringResult r) => new XblVerifyStringResult(r)));
				}
			});
			using DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(stringsToVerify);
			int num = XblInterop.XblStringVerifyStringsAsync(xblContextHandle.Handle, disposableBuffer.IntPtr, Convert.ToUInt64(stringsToVerify.Length), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				completionRoutine(num, null);
			}
		}

		public static void XblTitleManagedStatsWriteAsync(XblContextHandle xblContextHandle, ulong xboxUserId, XblTitleManagedStatistic[] statistics, XblTitleManagedStatsOperationCompleted completionRoutine)
		{
			if (xblContextHandle == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int hresult = NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false);
				completionRoutine(hresult);
			});
			DisposableCollection disposableCollection = new DisposableCollection();
			try
			{
				Unity.XGamingRuntime.Interop.XblTitleManagedStatistic[] array = Array.ConvertAll(statistics, (XblTitleManagedStatistic s) => new Unity.XGamingRuntime.Interop.XblTitleManagedStatistic(s, disposableCollection));
				int num = XblInterop.XblTitleManagedStatsWriteAsync(xblContextHandle.Handle, xboxUserId, array, new SizeT(array.Length), xAsyncBlock);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
					completionRoutine(num);
				}
			}
			finally
			{
				if (disposableCollection != null)
				{
					((IDisposable)disposableCollection).Dispose();
				}
			}
		}

		public static void XblTitleManagedStatsUpdateStatsAsync(XblContextHandle xblContextHandle, XblTitleManagedStatistic[] statistics, XblTitleManagedStatsOperationCompleted completionRoutine)
		{
			if (xblContextHandle == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int hresult = NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false);
				completionRoutine(hresult);
			});
			DisposableCollection disposableCollection = new DisposableCollection();
			try
			{
				Unity.XGamingRuntime.Interop.XblTitleManagedStatistic[] array = Array.ConvertAll(statistics, (XblTitleManagedStatistic s) => new Unity.XGamingRuntime.Interop.XblTitleManagedStatistic(s, disposableCollection));
				int num = XblInterop.XblTitleManagedStatsUpdateStatsAsync(xblContextHandle.Handle, array, new SizeT(array.Length), xAsyncBlock);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
					completionRoutine(num);
				}
			}
			finally
			{
				if (disposableCollection != null)
				{
					((IDisposable)disposableCollection).Dispose();
				}
			}
		}

		public static void XblTitleManagedStatsDeleteStatsAsync(XblContextHandle xblContextHandle, string[] statisticNames, XblTitleManagedStatsOperationCompleted completionRoutine)
		{
			if (xblContextHandle == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int hresult = NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false);
				completionRoutine(hresult);
			});
			using DisposableCollection disposableCollection = new DisposableCollection();
			IntPtr statisticNames2 = Converters.StringArrayToUTF8StringArray(statisticNames, disposableCollection, out var count);
			int num = XblInterop.XblTitleManagedStatsDeleteStatsAsync(xblContextHandle.Handle, statisticNames2, count, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num);
			}
		}

		public static int XblTitleStorageBlobMetadataResultGetItems(XblTitleStorageBlobMetadataResultHandle resultHandle, out XblTitleStorageBlobMetadata[] items)
		{
			if (resultHandle == null)
			{
				items = null;
				return -2147024809;
			}
			int num = XblInterop.XblTitleStorageBlobMetadataResultGetItems(resultHandle.Handle, out var items2, out var itemsCount);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				items = null;
				return num;
			}
			items = Converters.PtrToClassArray(items2, itemsCount, (Unity.XGamingRuntime.Interop.XblTitleStorageBlobMetadata i) => new XblTitleStorageBlobMetadata(i));
			return num;
		}

		public static int XblTitleStorageBlobMetadataResultHasNext(XblTitleStorageBlobMetadataResultHandle result, out bool hasNext)
		{
			hasNext = false;
			if (result == null)
			{
				return -2147024809;
			}
			return XblInterop.XblTitleStorageBlobMetadataResultHasNext(result.Handle, out hasNext);
		}

		public static void XblTitleStorageBlobMetadataResultGetNextAsync(XblTitleStorageBlobMetadataResultHandle result, uint maxItems, XblTitleStorageBlobMetadataResultGetNextCompleted completionRoutine)
		{
			if (result == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblTitleStorageBlobMetadataResultGetNextResult(block, out var result2);
				if (num2 == 0)
				{
					completionRoutine(num2, new XblTitleStorageBlobMetadataResultHandle(result2));
				}
				else
				{
					completionRoutine(num2, null);
				}
			});
			int num = XblInterop.XblTitleStorageBlobMetadataResultGetNextAsync(result.Handle, maxItems, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static int XblTitleStorageBlobMetadataResultDuplicateHandle(XblTitleStorageBlobMetadataResultHandle handle, out XblTitleStorageBlobMetadataResultHandle duplicatedHandle)
		{
			if (handle == null)
			{
				duplicatedHandle = null;
				return -2147024809;
			}
			int num = XblInterop.XblTitleStorageBlobMetadataResultDuplicateHandle(handle.Handle, out var duplicatedHandle2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				duplicatedHandle = new XblTitleStorageBlobMetadataResultHandle(duplicatedHandle2);
				return num;
			}
			duplicatedHandle = null;
			return num;
		}

		public static void XblTitleStorageBlobMetadataResultCloseHandle(XblTitleStorageBlobMetadataResultHandle handle)
		{
			if (!(handle == null))
			{
				handle.Close();
			}
		}

		public static void XblTitleStorageGetQuotaAsync(XblContextHandle xboxLiveContext, string serviceConfigurationId, XblTitleStorageType storageType, XblTitleStorageGetQuotaCompleted completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809, 0uL, 0uL);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblTitleStorageGetQuotaResult(block, out var usedBytes, out var quotaBytes);
				if (num2 == 0)
				{
					completionRoutine(num2, usedBytes.ToUInt64(), quotaBytes.ToUInt64());
				}
				else
				{
					completionRoutine(num2, 0uL, 0uL);
				}
			});
			int num = XblInterop.XblTitleStorageGetQuotaAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), storageType, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, 0uL, 0uL);
			}
		}

		public static void XblTitleStorageGetBlobMetadataAsync(XblContextHandle xboxLiveContext, string serviceConfigurationId, XblTitleStorageType storageType, string blobPath, ulong xboxUserId, uint skipItems, uint maxItems, XblTitleStorageGetBlobMetadataCompleted completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblTitleStorageGetBlobMetadataResult(block, out var result);
				if (num2 == 0)
				{
					completionRoutine(num2, new XblTitleStorageBlobMetadataResultHandle(result));
				}
				else
				{
					completionRoutine(num2, null);
				}
			});
			int num = XblInterop.XblTitleStorageGetBlobMetadataAsync(xboxLiveContext.Handle, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), storageType, Converters.StringToNullTerminatedUTF8ByteArray(blobPath), xboxUserId, skipItems, maxItems, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null);
			}
		}

		public static void XblTitleStorageDeleteBlobAsync(XblContextHandle xboxLiveContext, XblTitleStorageBlobMetadata blobMetadata, bool deleteOnlyIfEtagMatches, XblTitleStorageDeleteBlobCompleted completionRoutine)
		{
			if (xboxLiveContext == null)
			{
				completionRoutine(-2147024809);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				completionRoutine(NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false));
			});
			int num = XblInterop.XblTitleStorageDeleteBlobAsync(xboxLiveContext.Handle, blobMetadata.interop, deleteOnlyIfEtagMatches, xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num);
			}
		}

		public static void XblTitleStorageDownloadBlobAsync(XblContextHandle xboxLiveContext, XblTitleStorageBlobMetadata blobMetadata, XblTitleStorageETagMatchCondition etagMatchCondition, string selectQuery, ulong preferredDownloadBlockSize, XblTitleStorageDownloadBlobCompleted completionRoutine)
		{
			if (xboxLiveContext == null || blobMetadata.Length == 0L)
			{
				completionRoutine(-2147024809, null, null);
			}
			int blobBufferCount = (int)blobMetadata.Length * Marshal.SizeOf((byte)0);
			IntPtr blobBuffer = Marshal.AllocHGlobal(blobBufferCount);
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblTitleStorageDownloadBlobResult(block, out var blobMetadata2);
				if (num2 == 0)
				{
					byte[] array = new byte[blobBufferCount];
					Marshal.Copy(blobBuffer, array, 0, array.Length);
					completionRoutine(num2, new XblTitleStorageBlobMetadata(blobMetadata2), array);
				}
				else
				{
					completionRoutine(num2, null, null);
				}
				Marshal.FreeHGlobal(blobBuffer);
			});
			int num = XblInterop.XblTitleStorageDownloadBlobAsync(xboxLiveContext.Handle, blobMetadata.interop, blobBuffer, new SizeT(blobBufferCount), etagMatchCondition, Converters.StringToNullTerminatedUTF8ByteArray(selectQuery), new SizeT(preferredDownloadBlockSize), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num, null, null);
			}
		}

		public static void XblTitleStorageUploadBlobAsync(XblContextHandle xboxLiveContext, XblTitleStorageBlobMetadata blobMetadata, byte[] blobBuffer, XblTitleStorageETagMatchCondition etagMatchCondition, ulong preferredDownloadBlockSize, XblTitleStorageUploadBlobCompleted completionRoutine)
		{
			if (xboxLiveContext == null || blobBuffer == null)
			{
				completionRoutine(-2147024809, null);
			}
			int num = blobBuffer.Length * Marshal.SizeOf((byte)0);
			IntPtr blobBufferPtr = Marshal.AllocHGlobal(num);
			Marshal.Copy(blobBuffer, 0, blobBufferPtr, num);
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num3 = XblInterop.XblTitleStorageUploadBlobResult(block, out var blobMetadata2);
				if (num3 == 0)
				{
					completionRoutine(num3, new XblTitleStorageBlobMetadata(blobMetadata2));
				}
				else
				{
					completionRoutine(num3, null);
				}
				Marshal.FreeHGlobal(blobBufferPtr);
			});
			int num2 = XblInterop.XblTitleStorageUploadBlobAsync(xboxLiveContext.Handle, blobMetadata.interop, blobBufferPtr, new SizeT(num), etagMatchCondition, new SizeT(preferredDownloadBlockSize), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				completionRoutine(num2, null);
			}
		}

		public static void XblUserStatisticsGetSingleUserStatisticAsync(XblContextHandle xblContextHandle, ulong xboxUserId, string serviceConfigurationId, string statisticName, XblUserStatisticsGetSingleUserStatisticCompleted completionRoutine)
		{
			if (xblContextHandle == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblUserStatisticsGetSingleUserStatisticResultSize(block, out var resultSizeInBytes);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
					return;
				}
				using DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32());
				num2 = XblInterop.XblUserStatisticsGetSingleUserStatisticResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var ptrToBuffer, out var _);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					XblUserStatisticsResult result = Converters.PtrToClass(ptrToBuffer, (XblUserStatisticsResultInternal r) => new XblUserStatisticsResult(r));
					completionRoutine(num2, result);
				}
			});
			int num = XblInterop.XblUserStatisticsGetSingleUserStatisticAsync(xblContextHandle.Handle, xboxUserId, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), Converters.StringToNullTerminatedUTF8ByteArray(statisticName), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				completionRoutine(num, null);
			}
		}

		public static void XblUserStatisticsGetSingleUserStatisticsAsync(XblContextHandle xblContextHandle, ulong xboxUserId, string serviceConfigurationId, string[] statisticNames, XblUserStatisticsGetSingleUserStatisticsCompleted completionRoutine)
		{
			if (xblContextHandle == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblUserStatisticsGetSingleUserStatisticsResultSize(block, out var resultSizeInBytes);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
					return;
				}
				using DisposableBuffer disposableBuffer2 = new DisposableBuffer(resultSizeInBytes.ToInt32());
				num2 = XblInterop.XblUserStatisticsGetSingleUserStatisticsResult(block, resultSizeInBytes, disposableBuffer2.IntPtr, out var ptrToBuffer, out var _);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					XblUserStatisticsResult result = Converters.PtrToClass(ptrToBuffer, (XblUserStatisticsResultInternal r) => new XblUserStatisticsResult(r));
					completionRoutine(num2, result);
				}
			});
			using DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(statisticNames);
			int num = XblInterop.XblUserStatisticsGetSingleUserStatisticsAsync(xblContextHandle.Handle, xboxUserId, Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), disposableBuffer.IntPtr, new SizeT(statisticNames.Length), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				completionRoutine(num, null);
			}
		}

		public static void XblUserStatisticsGetMultipleUserStatisticsAsync(XblContextHandle xblContextHandle, ulong[] xboxUserIds, string serviceConfigurationId, string[] statisticNames, XblUserStatisticsGetMultipleUserStatisticsCompleted completionRoutine)
		{
			if (xblContextHandle == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblUserStatisticsGetMultipleUserStatisticsResultSize(block, out var resultSizeInBytes);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
					return;
				}
				using DisposableBuffer disposableBuffer2 = new DisposableBuffer(resultSizeInBytes.ToInt32());
				num2 = XblInterop.XblUserStatisticsGetMultipleUserStatisticsResult(block, resultSizeInBytes, disposableBuffer2.IntPtr, out var ptrToBuffer, out var resultsCount, out var _);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					XblUserStatisticsResult[] results = Converters.PtrToClassArray(ptrToBuffer, resultsCount, (XblUserStatisticsResultInternal r) => new XblUserStatisticsResult(r));
					completionRoutine(num2, results);
				}
			});
			using DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(statisticNames);
			int num = XblInterop.XblUserStatisticsGetMultipleUserStatisticsAsync(xblContextHandle.Handle, xboxUserIds, new SizeT(xboxUserIds.Length), Converters.StringToNullTerminatedUTF8ByteArray(serviceConfigurationId), disposableBuffer.IntPtr, new SizeT(statisticNames.Length), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				completionRoutine(num, null);
			}
		}

		public static void XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsAsync(XblContextHandle xblContextHandle, ulong[] xboxUserIds, XblRequestedStatistics[] requestedServiceConfigurationStatisticsCollection, XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsCompleted completionRoutine)
		{
			if (xblContextHandle == null)
			{
				completionRoutine(-2147024809, null);
				return;
			}
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int num2 = XblInterop.XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsResultSize(block, out var resultSizeInBytes);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
					return;
				}
				using DisposableBuffer disposableBuffer = new DisposableBuffer(resultSizeInBytes.ToInt32());
				num2 = XblInterop.XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsResult(block, resultSizeInBytes, disposableBuffer.IntPtr, out var results, out var resultsCount, out var _);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					completionRoutine(num2, null);
				}
				else
				{
					XblUserStatisticsResult[] results2 = Converters.PtrToClassArray(results, resultsCount, (XblUserStatisticsResultInternal r) => new XblUserStatisticsResult(r));
					completionRoutine(num2, results2);
				}
			});
			using DisposableCollection disposableCollection = new DisposableCollection();
			IntPtr requestedServiceConfigurationStatisticsCollection2 = Converters.ClassArrayToPtr(requestedServiceConfigurationStatisticsCollection, (XblRequestedStatistics request, DisposableCollection disposables) => new XblRequestedStatisticsInternal(request, disposables), disposableCollection, out var arrayCount);
			int num = XblInterop.XblUserStatisticsGetMultipleUserStatisticsForMultipleServiceConfigurationsAsync(xblContextHandle.Handle, xboxUserIds, Convert.ToUInt32(xboxUserIds.Length), requestedServiceConfigurationStatisticsCollection2, arrayCount.ToUInt32(), xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				completionRoutine(num, null);
			}
		}

		public unsafe static int XblUserStatisticsAddStatisticChangedHandler(XblContextHandle xblContextHandle, XblStatisticChangedCallback eventCallback)
		{
			IntPtr uniqueContext = _userStatisticsChangeCallbackManager.GetUniqueContext();
			int num = UserStatistics.XblUserStatisticsAddStatisticChangedHandler(xblContextHandle.Handle, UserStatisticsChangeCallbackManager.InteropPInvokeCallback, uniqueContext.ToPointer());
			if (num != 0)
			{
				_userStatisticsChangeCallbackManager.AddCallbackForId(num, uniqueContext, eventCallback);
			}
			return num;
		}

		public static void XblUserStatisticsRemoveStatisticChangedHandler(XblContextHandle xblContextHandle, int callbackFunctionId)
		{
			UserStatistics.XblUserStatisticsRemoveStatisticChangedHandler(xblContextHandle.Handle, callbackFunctionId);
			_userStatisticsChangeCallbackManager.RemoveCallbackForId(callbackFunctionId);
		}

		public unsafe static void XblUserStatisticsTrackStatistics(XblContextHandle xblContextHandle, ulong[] xuids, string serviceConfigurationId, string[] statisticNames)
		{
			sbyte[] array = new sbyte[Converters.GetSizeRequiredToEncodeStringToUTF8(serviceConfigurationId)];
			fixed (ulong* xboxUserIds = &xuids[0])
			{
				fixed (sbyte* ptr = &array[0])
				{
					using DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(statisticNames);
					Converters.StringToNullTerminatedUTF8FixedPointer(serviceConfigurationId, (byte*)ptr, serviceConfigurationId.Length);
					UserStatistics.XblUserStatisticsTrackStatistics(xblContextHandle.Handle, xboxUserIds, new UIntPtr((uint)xuids.Length), ptr, (sbyte**)(void*)disposableBuffer.IntPtr, new UIntPtr((uint)statisticNames.Length));
				}
			}
		}

		public unsafe static void XblUserStatisticsStopTrackingStatistics(XblContextHandle xblContextHandle, ulong[] xuids, string serviceConfigurationId, string[] statisticNames)
		{
			sbyte[] array = new sbyte[Converters.GetSizeRequiredToEncodeStringToUTF8(serviceConfigurationId)];
			fixed (ulong* xboxUserIds = &xuids[0])
			{
				fixed (sbyte* ptr = &array[0])
				{
					using DisposableBuffer disposableBuffer = Converters.StringArrayToUTF8StringArray(statisticNames);
					Converters.StringToNullTerminatedUTF8FixedPointer(serviceConfigurationId, (byte*)ptr, serviceConfigurationId.Length);
					UserStatistics.XblUserStatisticsStopTrackingStatistics(xblContextHandle.Handle, xboxUserIds, new UIntPtr((uint)xuids.Length), ptr, (sbyte**)(void*)disposableBuffer.IntPtr, new UIntPtr((uint)statisticNames.Length));
				}
			}
		}

		public unsafe static void XblUserStatisticsStopTrackingUsers(XblContextHandle xblContextHandle, ulong[] xuids)
		{
			fixed (ulong* xboxUserIds = &xuids[0])
			{
				UserStatistics.XblUserStatisticsStopTrackingUsers(xblContextHandle.Handle, xboxUserIds, new UIntPtr((uint)xuids.Length));
			}
		}

		public static int XblInitialize(string scid)
		{
			IsXblInitialized = true;
			return XblInterop.XblWrapper_XblInitialize(Converters.StringToNullTerminatedUTF8ByteArray(scid), defaultQueue);
		}

		public static void XblCleanup(XblCleanupResult completionRoutine)
		{
			XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
			{
				int hresult = NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false);
				if (completionRoutine != null)
				{
					completionRoutine(hresult);
				}
			});
			int num = XblInterop.XblCleanupAsync(xAsyncBlock);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
			{
				AsyncHelpers.CleanupAsyncBlock(xAsyncBlock);
				if (completionRoutine != null)
				{
					completionRoutine(num);
				}
			}
			if (GetGdkEdition() >= 250400)
			{
				XAsyncBlock xAsyncBlock2 = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
				{
					int num2 = NativeMethods.XAsyncGetStatus(block.InteropPtr, wait: false);
					if (completionRoutine != null || num2 == 0)
					{
						completionRoutine(num2);
					}
				});
				num = XblInterop.XblWrapper_XblCleanupAsync(xAsyncBlock2);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
				{
					AsyncHelpers.CleanupAsyncBlock(xAsyncBlock2);
					if (completionRoutine != null)
					{
						completionRoutine(num);
					}
				}
			}
			IsXblInitialized = false;
		}

		public static int XblContextCreateHandle(XUserHandle user, out XblContextHandle context)
		{
			if (user == null)
			{
				context = null;
				return -2147024809;
			}
			int num = XblInterop.XblContextCreateHandle(user.Handle, out var context2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				context = new XblContextHandle(context2);
				context.m_gCHandle = GCHandle.Alloc(context, GCHandleType.Normal);
				return num;
			}
			context = null;
			return num;
		}

		public static void XblContextCloseHandle(XblContextHandle xboxLiveContextHandle)
		{
			xboxLiveContextHandle.Close();
		}

		public static int XblContextDuplicateHandle(XblContextHandle srcXboxLiveContextHandle, out XblContextHandle dstXboxLiveContextHandle)
		{
			Unity.XGamingRuntime.Interop.XblContextHandle interopHandle = default;
			int num = XboxLiveContext.XblContextDuplicateHandle(srcXboxLiveContextHandle.Handle, out interopHandle.handle);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				dstXboxLiveContextHandle = new XblContextHandle(interopHandle);
				return num;
			}
			dstXboxLiveContextHandle = null;
			return num;
		}

		public static int XblContextGetUser(XblContextHandle xboxLiveContextHandle, out XUserHandle dstUserHandle)
		{
			IntPtr user = default;
			int num = XboxLiveContext.XblContextGetUser(xboxLiveContextHandle.Handle, out user);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				dstUserHandle = new XUserHandle(user);
				return num;
			}
			dstUserHandle = null;
			return num;
		}

		public static int XblContextGetXboxUserId(XblContextHandle xboxLiveContextHandle, ref ulong dstXboxUserId)
		{
			ulong xboxUserId = 0uL;
			int num = XboxLiveContext.XblContextGetXboxUserId(xboxLiveContextHandle.Handle, out xboxUserId);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				dstXboxUserId = xboxUserId;
				return num;
			}
			dstXboxUserId = 0uL;
			return num;
		}

		public unsafe static int XblGetScid(ref string resultScid)
		{
			resultScid = string.Empty;
			sbyte* bytePointer = default;
			int num = XboxLiveGlobal.XblGetScid(&bytePointer);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				resultScid = Converters.BytePointerToString((byte*)bytePointer, 36);
			}
			return num;
		}
	}

	private static HCWebSocketRoutedHandler routedCallback;

	private static int hcRoutedHandlerId;

	private const string k_ResourcesFolderName = "GDKEditionAutoGen";

	private static int? s_CachedEditionNumber = null;

	private static Dictionary<IntPtr, CallbackWrapper<XAsyncWorkInterop>> asyncWorkCallbackDictionary = new Dictionary<IntPtr, CallbackWrapper<XAsyncWorkInterop>>();

	private static XTaskQueueHandle defaultQueue;

	private static bool canBreak = false;

	private static Thread m_DispatchJob;

	private static volatile bool isInitialized = false;

	private static volatile bool m_StopExecution;

	private const string obsoleteXPackageMountMsg = "XPackageMount(string, out XPackageMountHandle) has been removed. Please use XPackageMountWithUiAsync(string packageIdentifier, XPackageMountWithUiAsyncCompleted) instead.";

	private static CallbackWrapper<Unity.XGamingRuntime.Interop.XErrorCallback> errorCallbackWrapper;

	private const int XUserGamertagComponentClassicMaxBytes = 16;

	private const int XUserGamertagComponentModernMaxBytes = 97;

	private const int XUserGamertagComponentModernSuffixMaxBytes = 15;

	private const int XUserGamertagComponentUniqueModernMaxBytes = 101;

	private XGameStreamingClientId XGameStreamingNullClientId = new XGameStreamingClientId(0uL);

	private XGameStreamingClientId XGameStreamingAllClients = new XGameStreamingClientId(ulong.MaxValue);

	private const ulong ClientIPAddressMaxBytes = 65uL;

	private const ulong SessionIdMaxBytes = 256uL;

	public static readonly int XPACKAGE_IDENTIFIER_MAX_LENGTH = 33;

	public static readonly int LOCALE_NAME_MAX_LENGTH = 85;

	public static readonly ulong XSystemAppSpecificDeviceIdBytes = 45uL;

	public static readonly ulong XSystemConsoleIdBytes = 39uL;

	public static readonly ulong XSystemXboxLiveSandboxIdMaxBytes = 16uL;

	public static readonly ulong XUserAudioEndpointMaxUtf16Count = 56uL;

	public static event HCWebSocketRoutedHandler HCWebSocketRouted
	{
		add
		{
			if (routedCallback == null)
			{
				hcRoutedHandlerId = XGRInterop.HCAddWebSocketRoutedHandler(HCWebSocketRoutedCallback, IntPtr.Zero);
			}
			routedCallback = (HCWebSocketRoutedHandler)Delegate.Combine(routedCallback, value);
		}
		remove
		{
			routedCallback = (HCWebSocketRoutedHandler)Delegate.Remove(routedCallback, value);
			if (routedCallback == null)
			{
				XGRInterop.HCRemoveWebSocketRoutedHandler(hcRoutedHandlerId);
				hcRoutedHandlerId = 0;
			}
		}
	}

	[MonoPInvokeCallback]
	private unsafe static void HCWebSocketMessageCallback(IntPtr websocket, IntPtr incomingBodyString, IntPtr functionContext)
	{
		HCWebsocketHandle hCWebsocketHandle = GCHandle.FromIntPtr(functionContext).Target as HCWebsocketHandle;
		string incomingBodyString2 = null;
		if (incomingBodyString != IntPtr.Zero)
		{
			int i;
			for (i = 0; Marshal.ReadByte(incomingBodyString, i) != 0; i++)
			{
			}
			incomingBodyString2 = Encoding.UTF8.GetString((byte*)(void*)incomingBodyString, i);
		}
		hCWebsocketHandle.messageCallback?.Invoke(new HCWebsocketHandle(websocket, ownsHandle: false), incomingBodyString2);
	}

	[MonoPInvokeCallback]
	private static void HCWebSocketBinaryMessageCallback(IntPtr websocket, IntPtr payloadBytes, uint countOfBlobs, IntPtr functionContext)
	{
		HCWebsocketHandle obj = GCHandle.FromIntPtr(functionContext).Target as HCWebsocketHandle;
		byte[] array = null;
		if (payloadBytes != IntPtr.Zero && countOfBlobs != 0)
		{
			array = new byte[countOfBlobs];
			Marshal.Copy(payloadBytes, array, 0, array.Length);
		}
		obj.binaryMessageCallback?.Invoke(new HCWebsocketHandle(websocket, ownsHandle: false), array);
	}

	[MonoPInvokeCallback]
	private static void HCWebSocketCloseCallback(IntPtr websocket, HCWebSocketCloseStatus closeStatus, IntPtr functionContext)
	{
		GCHandle gCHandle = GCHandle.FromIntPtr(functionContext);
		(gCHandle.Target as HCWebsocketHandle).closeCallback?.Invoke(new HCWebsocketHandle(websocket, ownsHandle: false), closeStatus);
		if (gCHandle.IsAllocated)
		{
			gCHandle.Free();
		}
	}

	[MonoPInvokeCallback]
	private unsafe static void HCWebSocketRoutedCallback(IntPtr websocket, NativeBool receiving, IntPtr message, IntPtr payloadBytes, SizeT payloadSize, IntPtr conext)
	{
		XGRInterop.HCWebSocketGetEventFunctions(websocket, out var _, out var _, out var _, out var functionContext);
		_ = GCHandle.FromIntPtr(functionContext).Target;
		string message2 = null;
		if (message != IntPtr.Zero)
		{
			int i;
			for (i = 0; Marshal.ReadByte(message, i) != 0; i++)
			{
			}
			message2 = Encoding.UTF8.GetString((byte*)(void*)message, i);
		}
		byte[] array = null;
		if (payloadBytes != IntPtr.Zero && !payloadSize.IsZero)
		{
			array = new byte[payloadSize.ToInt32()];
			Marshal.Copy(payloadBytes, array, 0, array.Length);
		}
		routedCallback?.Invoke(new HCWebsocketHandle(websocket, ownsHandle: false), receiving.Value, message2, array);
	}

	public static int HCInitialize()
	{
		IsHttpClientApiSupported();
		return XGRInterop.HCInitialize(IntPtr.Zero);
	}

	public static int HCCleanupAsync(HCCleanupHandler completionRoutine)
	{
		IsHttpClientApiSupported();
		return XGRInterop.HCCleanupAsync(AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
		{
			completionRoutine?.Invoke();
		}));
	}

	public static int HCWebSocketCreate(out HCWebsocketHandle websocket, HCWebSocketMessageFunction messageFunc, HCWebSocketBinaryMessageFunction binaryMessageFunc, HCWebSocketCloseEventFunction closeFunc)
	{
		IsHttpClientApiSupported();
		HCWebsocketHandle hCWebsocketHandle = new HCWebsocketHandle((IntPtr)0)
		{
			messageFunc = HCWebSocketMessageCallback,
			binaryMessageFunc = HCWebSocketBinaryMessageCallback,
			closeFunc = HCWebSocketCloseCallback,
			messageCallback = messageFunc,
			binaryMessageCallback = binaryMessageFunc,
			closeCallback = closeFunc
		};
		GCHandle gCHandle = (hCWebsocketHandle.cbHandle = GCHandle.Alloc(hCWebsocketHandle));
		int num = XGRInterop.HCWebSocketCreate(out var websocket2, hCWebsocketHandle.messageFunc, hCWebsocketHandle.binaryMessageFunc, hCWebsocketHandle.closeFunc, GCHandle.ToIntPtr(gCHandle));
		if (num == 0 && websocket2 == IntPtr.Zero)
		{
			gCHandle.Free();
			websocket = null;
			return num;
		}
		return HCWebsocketHandle.WrapAndReturnHResult(num, websocket2, out websocket, gCHandle);
	}

	public static int HCWebSocketSetProxyUri(HCWebsocketHandle websocket, byte[] proxyUri)
	{
		IsHttpClientApiSupported();
		return XGRInterop.HCWebSocketSetProxyUri(websocket.Handle, proxyUri);
	}

	public static int HCWebSocketSetHeader(HCWebsocketHandle websocket, string headerName, string headerValue)
	{
		IsHttpClientApiSupported();
		byte[] headerName2 = Converters.StringToNullTerminatedUTF8ByteArray(headerName);
		byte[] headerValue2 = Converters.StringToNullTerminatedUTF8ByteArray(headerValue);
		return XGRInterop.HCWebSocketSetHeader(websocket.Handle, headerName2, headerValue2);
	}

	public static int HCWebSocketConnectAsync(string uri, string subProtocol, HCWebsocketHandle websocket, HCSocketCompletionResultFunction completionRoutine)
	{
		IsHttpClientApiSupported();
		XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
		{
			WebSocketCompletionResult result = default;
			int num = XGRInterop.HCGetWebSocketConnectResult(block, ref result);
			if (num == 0)
			{
				completionRoutine(websocket, result.errorCode, result.platformErrorCode);
			}
			else
			{
				completionRoutine(null, num, 0u);
			}
		});
		byte[] uri2 = Converters.StringToNullTerminatedUTF8ByteArray(uri);
		byte[] subProtocol2 = Converters.StringToNullTerminatedUTF8ByteArray(subProtocol);
		return XGRInterop.HCWebSocketConnectAsync(uri2, subProtocol2, websocket.Handle, xAsyncBlock);
	}

	public static int HCWebSocketSendMessageAsync(HCWebsocketHandle websocket, string message, HCSocketCompletionResultFunction completionRoutine)
	{
		IsHttpClientApiSupported();
		XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
		{
			WebSocketCompletionResult result = default;
			int num = XGRInterop.HCGetWebSocketSendMessageResult(block, ref result);
			if (num == 0)
			{
				completionRoutine(websocket, result.errorCode, result.platformErrorCode);
			}
			else
			{
				completionRoutine(null, num, 0u);
			}
		});
		byte[] message2 = Converters.StringToNullTerminatedUTF8ByteArray(message);
		return XGRInterop.HCWebSocketSendMessageAsync(websocket.Handle, message2, xAsyncBlock);
	}

	public static int HCWebSocketSendBinaryMessageAsync(HCWebsocketHandle websocket, byte[] data, uint payloadSize, HCSocketCompletionResultFunction completionRoutine)
	{
		IsHttpClientApiSupported();
		XAsyncBlock xAsyncBlock = AsyncHelpers.WrapAsyncBlock(defaultQueue, (XAsyncBlock block) =>
		{
			WebSocketCompletionResult result = default;
			int num = XGRInterop.HCGetWebSocketSendMessageResult(block, ref result);
			if (num == 0)
			{
				completionRoutine(websocket, result.errorCode, result.platformErrorCode);
			}
			else
			{
				completionRoutine(null, num, 0u);
			}
		});
		return XGRInterop.HCWebSocketSendBinaryMessageAsync(websocket.Handle, data, payloadSize, xAsyncBlock);
	}

	public static int HCWebSocketDisconnect(HCWebsocketHandle websocket)
	{
		IsHttpClientApiSupported();
		return XGRInterop.HCWebSocketDisconnect(websocket.Handle);
	}

	public static int HCWebSocketCloseHandle(HCWebsocketHandle websocket)
	{
		IsHttpClientApiSupported();
		return XGRInterop.HCWebSocketCloseHandle(websocket.Handle);
	}

	[Obsolete("This method is deprecated and will be removed. Use the HCWebSocketRouted event instead.", false)]
	public static int HCAddWebSocketRoutedHandler(HCWebSocketRoutedHandler handler)
	{
		if (routedCallback == null)
		{
			hcRoutedHandlerId = XGRInterop.HCAddWebSocketRoutedHandler(HCWebSocketRoutedCallback, IntPtr.Zero);
		}
		routedCallback = (HCWebSocketRoutedHandler)Delegate.Combine(routedCallback, handler);
		return hcRoutedHandlerId;
	}

	[Obsolete("This method is deprecated and will be removed. Use the HCWebSocketRouted event instead.", false)]
	public static void HCRemoveWebSocketRoutedHandler(int handlerId)
	{
		XGRInterop.HCRemoveWebSocketRoutedHandler(handlerId);
	}

	private static void IsHttpClientApiSupported()
	{
		if (GetGdkEdition() < 240600)
		{
			throw new NotImplementedException("HTTP Client API requires GDK edition 240600 or newer. " + $"Current edition: {GetGdkEdition()}");
		}
	}

	public static int GetGdkEdition()
	{
		if (s_CachedEditionNumber.HasValue)
		{
			return s_CachedEditionNumber.Value;
		}
		GdkEditionAsset[] array = Resources.LoadAll<GdkEditionAsset>("GDKEditionAutoGen");
		if (array == null || array.Length == 0)
		{
			Debug.Log("GetGdkEdition() requires an autogenerated GDK Edition asset. Please ensure the file is available in the resource folder.");
			return -1994129150;
		}
		if (array.Length != 1)
		{
			Debug.Log("GetGdkEdition(): Multiple GDK Edition assets detected. The first asset in the list has been selected as the default.");
		}
		s_CachedEditionNumber = ((array[0] != null) ? array[0].EditionNumber : (-1994129150));
		return s_CachedEditionNumber.Value;
	}

	public static int XClosedCaptionGetProperties(out XClosedCaptionProperties properties)
	{
		properties = null;
		Unity.XGamingRuntime.Interop.XClosedCaptionProperties properties2 = default;
		int num = NativeMethods.XClosedCaptionGetProperties(out properties2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			properties = new XClosedCaptionProperties(properties2);
		}
		return num;
	}

	public static int XClosedCaptionSetEnabled(bool enabled)
	{
		return NativeMethods.XClosedCaptionSetEnabled(enabled);
	}

	public static int XHighContrastGetMode(out XHighContrastMode mode)
	{
		return NativeMethods.XHighContrastGetMode(out mode);
	}

	public static int XSpeechToTextSetPositionHint(XSpeechToTextPositionHint position)
	{
		return NativeMethods.XSpeechToTextSetPositionHint(position);
	}

	public static int XSpeechToTextSendString(string speakerName, string content, XSpeechToTextType type)
	{
		return NativeMethods.XSpeechToTextSendString(speakerName, content, type);
	}

	public static int XSpeechToTextBeginHypothesisString(string speakerName, string content, XSpeechToTextType type, out uint hypothesisId)
	{
		return NativeMethods.XSpeechToTextBeginHypothesisString(speakerName, content, type, out hypothesisId);
	}

	public static int XSpeechToTextUpdateHypothesisString(uint hypothesisId, string content)
	{
		return NativeMethods.XSpeechToTextUpdateHypothesisString(hypothesisId, content);
	}

	public static int XSpeechToTextFinalizeHypothesisString(uint hypothesisId, string content)
	{
		return NativeMethods.XSpeechToTextFinalizeHypothesisString(hypothesisId, content);
	}

	public static int XSpeechToTextCancelHypothesisString(uint hypothesisId)
	{
		return NativeMethods.XSpeechToTextCancelHypothesisString(hypothesisId);
	}

	public static int XAppBroadcastGetStatus(XUserHandle requestingUser, out XAppBroadcastStatus appBroadcastStatus)
	{
		appBroadcastStatus = null;
		IntPtr requestingUser2 = ((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero);
		Unity.XGamingRuntime.Interop.XAppBroadcastStatus appBroadcastStatus2 = default;
		int result = NativeMethods.XAppBroadcastGetStatus(requestingUser2, out appBroadcastStatus2);
		appBroadcastStatus = new XAppBroadcastStatus(appBroadcastStatus2);
		return result;
	}

	public static bool XAppBroadcastIsAppBroadcasting()
	{
		return NativeMethods.XAppBroadcastIsAppBroadcasting();
	}

	public static int XAppBroadcastShowUI(XUserHandle requestingUser)
	{
		return NativeMethods.XAppBroadcastShowUI((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero);
	}

	public static int XAppBroadcastRegisterIsAppBroadcastingChanged(XTaskQueueHandle queue, IntPtr context, XAppBroadcastMonitorCallback appBroadcastMonitorCallback, out XIsAppBroadcastingChangedRegistrationToken token)
	{
		Unity.XGamingRuntime.Interop.XAppBroadcastMonitorCallback callback = (IntPtr context2) =>
		{
			appBroadcastMonitorCallback(context2);
		};
		token = new XIsAppBroadcastingChangedRegistrationToken(callback, context);
		int num = NativeMethods.XAppBroadcastRegisterIsAppBroadcastingChanged((queue != null) ? queue.Handle : IntPtr.Zero, token.interop.CallbackContext, token.interop.StaticCallback, out var token2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			token.interop.Token = token2;
			return num;
		}
		token.interop.Dispose();
		token = null;
		return num;
	}

	public static int XAppBroadcastRegisterIsAppBroadcastingChanged(XTaskQueueHandle queue, XAppBroadcastMonitorCallback appBroadcastMonitorCallback, out XIsAppBroadcastingChangedRegistrationToken token)
	{
		return XAppBroadcastRegisterIsAppBroadcastingChanged(queue, IntPtr.Zero, appBroadcastMonitorCallback, out token);
	}

	public static int XAppCaptureCloseLocalStream(XAppCaptureLocalStreamHandle handle)
	{
		handle.Close();
		return handle.CloseResult;
	}

	[Obsolete("Please use XAppCaptureCloseScreenshotStream(XAppCaptureScreenshotStreamHandle) instead.", false)]
	public static int XAppCaptureCloseScreenshotStream(IntPtr handle)
	{
		return NativeMethods.XAppCaptureCloseScreenshotStream(handle);
	}

	public static int XAppCaptureCloseScreenshotStream(XAppCaptureScreenshotStreamHandle handle)
	{
		handle.Close();
		return handle.CloseResult;
	}

	public static int XAppCaptureEnableRecord()
	{
		return NativeMethods.XAppCaptureEnableRecord();
	}

	public static int XAppCaptureDisableRecord()
	{
		return NativeMethods.XAppCaptureDisableRecord();
	}

	public static bool XAppBroadcastUnregisterIsAppBroadcastingChanged(XIsAppBroadcastingChangedRegistrationToken token, bool wait)
	{
		return token.Unregister(wait);
	}

	public static int XAppCaptureMetadataAddStringEvent(string name, string value, XAppCaptureMetadataPriority priority)
	{
		return NativeMethods.XAppCaptureMetadataAddStringEvent(name, value, priority);
	}

	public static int XAppCaptureMetadataAddInt32Event(string name, int value, XAppCaptureMetadataPriority priority)
	{
		return NativeMethods.XAppCaptureMetadataAddInt32Event(name, value, priority);
	}

	public static int XAppCaptureMetadataAddDoubleEvent(string name, double value, XAppCaptureMetadataPriority priority)
	{
		return NativeMethods.XAppCaptureMetadataAddDoubleEvent(name, value, priority);
	}

	public static int XAppCaptureMetadataStartStringState(string name, string value, XAppCaptureMetadataPriority priority)
	{
		return NativeMethods.XAppCaptureMetadataStartStringState(name, value, priority);
	}

	public static int XAppCaptureMetadataStartInt32State(string name, int value, XAppCaptureMetadataPriority priority)
	{
		return NativeMethods.XAppCaptureMetadataStartInt32State(name, value, priority);
	}

	public static int XAppCaptureMetadataStartDoubleState(string name, double value, XAppCaptureMetadataPriority priority)
	{
		return NativeMethods.XAppCaptureMetadataStartDoubleState(name, value, priority);
	}

	public static int XAppCaptureMetadataStopState(string name)
	{
		return NativeMethods.XAppCaptureMetadataStopState(name);
	}

	public static int XAppCaptureMetadataStopAllStates()
	{
		return NativeMethods.XAppCaptureMetadataStopAllStates();
	}

	public static int XAppCaptureMetadataRemainingStorageBytesAvailable(out ulong value)
	{
		return NativeMethods.XAppCaptureMetadataRemainingStorageBytesAvailable(out value);
	}

	[Obsolete("Use XAppCaptureOpenScreenshotStream(string localId, XAppCaptureScreenshotFormatFlag, out XAppCaptureScreenshotStreamHandle, out UInt64)", false)]
	public static int XAppCaptureOpenScreenshotStream(XAppScreenshotLocalId id, XAppCaptureScreenshotFormatFlag screenshotFormat, out IntPtr handle, out ulong totalBytes)
	{
		return NativeMethods.XAppCaptureOpenScreenshotStream(Encoding.UTF8.GetString(id.Value), screenshotFormat, out handle, out totalBytes);
	}

	public static int XAppCaptureOpenScreenshotStream(string localId, XAppCaptureScreenshotFormatFlag screenshotFormat, out XAppCaptureScreenshotStreamHandle handle, out ulong totalBytes)
	{
		int num = NativeMethods.XAppCaptureOpenScreenshotStream(localId, screenshotFormat, out var handle2, out totalBytes);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num) && handle2 == IntPtr.Zero)
		{
			handle = null;
			return num;
		}
		return XAppCaptureScreenshotStreamHandle.WrapAndReturnHResult(num, handle2, out handle);
	}

	[Obsolete("Use XAppCaptureReadScreenshotStream(XAppCaptureScreenshotStreamHandle, UInt64, UInt32, byte[], out UInt32)", false)]
	public static int XAppCaptureReadScreenshotStream(IntPtr handle, ulong startPosition, uint totalBytes, byte[] data, out int bytesWritten)
	{
		int result = NativeMethods.XAppCaptureReadScreenshotStream(handle, startPosition, totalBytes, data, out var bytesWritten2);
		bytesWritten = (int)bytesWritten2;
		return result;
	}

	public static int XAppCaptureReadScreenshotStream(XAppCaptureScreenshotStreamHandle handle, ulong startPosition, uint bytesToRead, byte[] buffer, out uint bytesWritten)
	{
		return NativeMethods.XAppCaptureReadScreenshotStream(handle.Handle, startPosition, bytesToRead, buffer, out bytesWritten);
	}

	public static int XAppCaptureRecordDiagnosticClip(long startTime, uint durationInMs, string filenamePrefix, out XAppCaptureRecordClipResult result)
	{
		result = null;
		Unity.XGamingRuntime.Interop.XAppCaptureRecordClipResult result2 = default;
		int num = NativeMethods.XAppCaptureRecordDiagnosticClip(startTime, durationInMs, filenamePrefix, out result2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			result = new XAppCaptureRecordClipResult(result2);
		}
		return num;
	}

	public static int XAppCaptureTakeDiagnosticScreenshot(bool gamescreenOnly, XAppCaptureScreenshotFormatFlag captureFlags, string filenamePrefix, out XAppCaptureDiagnosticScreenshotResult result)
	{
		result = null;
		Unity.XGamingRuntime.Interop.XAppCaptureDiagnosticScreenshotResult result2 = default;
		int num = NativeMethods.XAppCaptureTakeDiagnosticScreenshot(gamescreenOnly, captureFlags, filenamePrefix, out result2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			result = new XAppCaptureDiagnosticScreenshotResult(result2);
		}
		return num;
	}

	public static int XAppCaptureTakeScreenshot(XUserHandle requestingUser, out XAppCaptureTakeScreenshotResult result)
	{
		result = null;
		Unity.XGamingRuntime.Interop.XAppCaptureTakeScreenshotResult result2 = default;
		int num = NativeMethods.XAppCaptureTakeScreenshot((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero, out result2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			result = new XAppCaptureTakeScreenshotResult(result2);
		}
		return num;
	}

	public static int XAppCaptureRegisterMetadataPurged(XTaskQueueHandle queue, IntPtr context, XAppCaptureMetadataPurgedCallback callback, out XMetadataPurgedToken token)
	{
		Unity.XGamingRuntime.Interop.XAppCaptureMetadataPurgedCallback callback2 = (IntPtr context2) =>
		{
			callback(context2);
		};
		token = new XMetadataPurgedToken(callback2, context);
		int num = NativeMethods.XAppCaptureRegisterMetadataPurged((queue != null) ? queue.Handle : IntPtr.Zero, token.interop.CallbackContext, token.interop.StaticCallback, out var token2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			token.Token = token2;
			return num;
		}
		token.interop.Dispose();
		token = null;
		return num;
	}

	public static int XAppCaptureRegisterMetadataPurged(XTaskQueueHandle queue, XAppCaptureMetadataPurgedCallback callback, out XMetadataPurgedToken token)
	{
		return XAppCaptureRegisterMetadataPurged(queue, IntPtr.Zero, callback, out token);
	}

	public static bool XAppCaptureUnRegisterMetadataPurged(XMetadataPurgedToken token, bool wait)
	{
		return token.Unregister(wait);
	}

	public static int XAppCaptureReadLocalStream(XAppCaptureLocalStreamHandle handle, long startPosition, uint bytesToRead, ref byte[] buffer, out uint bytesWritten)
	{
		return NativeMethods.XAppCaptureReadLocalStream(handle.Handle, startPosition, bytesToRead, buffer, out bytesWritten);
	}

	public static int XAppCaptureRecordTimespan(SYSTEMTIME startTimestamp, ulong durationInMilliseconds, out XAppCaptureLocalResult result)
	{
		result = null;
		int num = 0;
		GCHandle gCHandle = GCHandle.Alloc(startTimestamp.interop, GCHandleType.Pinned);
		try
		{
			num = NativeMethods.XAppCaptureRecordTimespan(gCHandle.AddrOfPinnedObject(), durationInMilliseconds, out var result2);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				result = new XAppCaptureLocalResult(result2);
			}
		}
		catch (Exception ex)
		{
			num = ex.HResult;
		}
		finally
		{
			gCHandle.Free();
		}
		return num;
	}

	public static int XAppCaptureRecordTimespan(ulong durationInMilliseconds, out XAppCaptureLocalResult result)
	{
		result = null;
		int num = NativeMethods.XAppCaptureRecordTimespan(IntPtr.Zero, durationInMilliseconds, out var result2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			result = new XAppCaptureLocalResult(result2);
		}
		return num;
	}

	public static int XAppCaptureGetVideoCaptureSettings(out XAppCaptureVideoCaptureSettings userCaptureSettings)
	{
		Unity.XGamingRuntime.Interop.XAppCaptureVideoCaptureSettings userCaptureSettings2 = default;
		userCaptureSettings = null;
		int num = NativeMethods.XAppCaptureGetVideoCaptureSettings(out userCaptureSettings2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			userCaptureSettings = new XAppCaptureVideoCaptureSettings(userCaptureSettings2);
		}
		return num;
	}

	[AOT.MonoPInvokeCallback(typeof(XAsyncWorkInterop))]
	private static int OnAsyncWorkCallback(IntPtr asyncBlock)
	{
		if (!asyncWorkCallbackDictionary.TryGetValue(asyncBlock, out var value))
		{
			return -2147024809;
		}
		return (GCHandle.FromIntPtr(value.CallbackContext).Target as CallbackWrapper<XAsyncWorkInterop>).Callback(asyncBlock);
	}

	public static int XAsyncGetStatus(XAsyncBlock asyncBlock, bool wait)
	{
		return NativeMethods.XAsyncGetStatus(asyncBlock.InteropPtr, wait);
	}

	public static int XAsyncGetResultSize(XAsyncBlock asyncBlock, out ulong bufferSize)
	{
		return NativeMethods.XAsyncGetResultSize(asyncBlock.InteropPtr, out bufferSize);
	}

	public static void XAsyncCancel(XAsyncBlock asyncBlock)
	{
		if (!asyncBlock.IsCompleted)
		{
			if (asyncWorkCallbackDictionary.TryGetValue(asyncBlock.InteropPtr, out var value))
			{
				value.Dispose();
				value = null;
				asyncWorkCallbackDictionary.Remove(asyncBlock.InteropPtr);
			}
			NativeMethods.XAsyncCancel(asyncBlock.InteropPtr);
		}
	}

	public static int XAsyncRun(XAsyncBlock asyncBlock, XAsyncWork work)
	{
		if (asyncWorkCallbackDictionary.TryGetValue(asyncBlock.InteropPtr, out var value))
		{
			value.Dispose();
			value = null;
			asyncWorkCallbackDictionary.Remove(asyncBlock.InteropPtr);
		}
		CallbackWrapper<XAsyncWorkInterop> callbackWrapper = new CallbackWrapper<XAsyncWorkInterop>((IntPtr _asyncBlockInterop) => work(asyncBlock), asyncBlock.Context, OnAsyncWorkCallback);
		asyncWorkCallbackDictionary.Add(asyncBlock.InteropPtr, callbackWrapper);
		return NativeMethods.XAsyncRun(asyncBlock.InteropPtr, callbackWrapper.StaticCallback);
	}

	private static void DispatchGXDKTaskQueue()
	{
		while (!m_StopExecution)
		{
			XTaskQueueDispatch(defaultQueue, XTaskQueuePort.Work, 32u);
		}
		DispatchGXDKTaskDone();
	}

	private static void DispatchGXDKTaskDone()
	{
		isInitialized = false;
	}

	public static int CreateDefaultTaskQueue()
	{
		if (isInitialized)
		{
			return 0;
		}
		int num = XTaskQueueCreate(XTaskQueueDispatchMode.Manual, XTaskQueueDispatchMode.Manual, out defaultQueue);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			m_StopExecution = false;
			m_DispatchJob = new Thread(DispatchGXDKTaskQueue)
			{
				Name = "GXDK Task Queue Dispatch"
			};
			m_DispatchJob.Start();
			isInitialized = true;
		}
		return num;
	}

	public static void CloseDefaultXTaskQueue()
	{
		if (!isInitialized)
		{
			return;
		}
		if (!m_StopExecution)
		{
			canBreak = false;
			XTaskQueueTerminate(defaultQueue, wait: false, IntPtr.Zero, (IntPtr context) =>
			{
				canBreak = true;
			}, out var callbackHandle);
			while (!canBreak)
			{
				XTaskQueueDispatch(defaultQueue, XTaskQueuePort.Completion, 0u);
				Thread.Yield();
			}
			m_StopExecution = true;
			callbackHandle.Dispose();
		}
		defaultQueue.Close();
		m_DispatchJob.Join();
	}

	public static bool XTaskQueueDispatch(uint timeoutInMs)
	{
		return XTaskQueueDispatch(defaultQueue, XTaskQueuePort.Completion, timeoutInMs);
	}

	public static int XUserRegisterForChangeEvent(XUserChangeEventCallback callback, out XUserChangeRegistrationToken token)
	{
		return XUserRegisterForChangeEvent(defaultQueue, IntPtr.Zero, callback, out token);
	}

	[Obsolete("Please use XGameSaveCloseUpdate(XGameSaveUpdateHandle context) instead. (UnityUpgradable) -> XGameSaveCloseUpdate(*)", true)]
	public static void XGameSaveCloseUpdateHandle(XGameSaveUpdateHandle updateHandle)
	{
		XGameSaveCloseUpdate(updateHandle);
	}

	public static int XGameSaveDeleteContainerAsync(XGameSaveProviderHandle gameSaveProviderHandle, string containerName, XGameSaveDeleteContainerCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hr = XGameSaveDeleteContainerResult(_async);
			onCompleted(hr);
		}, IntPtr.Zero);
		int num = XGameSaveDeleteContainerAsync(gameSaveProviderHandle, containerName, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num);
		}
		return num;
	}

	public static int XGameSaveGetRemainingQuotaAsync(XGameSaveProviderHandle provider, XGameSaveGetRemainingQuotaCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hr = XGameSaveGetRemainingQuotaResult(_async, out var remainingQuota);
			onCompleted(hr, remainingQuota);
		}, IntPtr.Zero);
		int num = XGameSaveGetRemainingQuotaAsync(provider, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, 0L);
		}
		return num;
	}

	public static int XGameSaveInitializeProviderAsync(XUserHandle requestingUser, string configurationId, bool syncOnDemand, XGameSaveInitializeProviderCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XGameSaveInitializeProviderResult(_async, out var provider);
			onCompleted(hresult, provider);
		}, IntPtr.Zero);
		int num = XGameSaveInitializeProviderAsync(requestingUser, configurationId, syncOnDemand, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XGameSaveReadBlobDataAsync(XGameSaveContainerHandle container, string[] blobNames, XGameSaveReadBlobDataCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XAsyncGetResultSize(_async, out var bufferSize);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				num2 = XGameSaveReadBlobDataResult(_async, bufferSize, out var blobData);
				onCompleted(num2, blobData);
			}
		}, IntPtr.Zero);
		int num = XGameSaveReadBlobDataAsync(container, blobNames, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XGameSaveSubmitUpdateAsync(XGameSaveUpdateHandle updateContext, XGameSaveSubmitUpdateCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XGameSaveSubmitUpdateResult(_async);
			onCompleted(hresult);
		}, IntPtr.Zero);
		int num = XGameSaveSubmitUpdateAsync(updateContext, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num);
		}
		return num;
	}

	public static int XGameSaveFilesGetFolderWithUiAsync(XUserHandle requestingUser, string configurationId, XGameSaveFilesGetFolderWithUiCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			ulong folderSize = 261uL;
			int hresult = XGameSaveFilesGetFolderWithUiResult(_async, folderSize, out var folderResult);
			onCompleted(hresult, folderResult);
		}, IntPtr.Zero);
		int num = XGameSaveFilesGetFolderWithUiAsync(requestingUser, configurationId, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XGameUiShowAchievementsAsync(XUserHandle requestingUser, uint titleId, XGameUiShowAchievementsCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XGameUiShowAchievementsResult(_async);
			onCompleted(hresult);
		}, IntPtr.Zero);
		int num = XGameUiShowAchievementsAsync(xAsyncBlock, requestingUser, titleId);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num);
		}
		return num;
	}

	public static int XGameUiShowErrorDialogAsync(int errorCode, string context, XGameUiShowErrorDialogCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XGameUiShowErrorDialogResult(_async);
			onCompleted(hresult);
		}, IntPtr.Zero);
		int num = XGameUiShowErrorDialogAsync(xAsyncBlock, errorCode, context);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num);
		}
		return num;
	}

	public static int XGameUiShowMessageDialogAsync(string titleText, string contextText, string firstButtonText, string secondButtonText, string thirdButtonText, XGameUiMessageDialogButton defaultButton, XGameUiMessageDialogButton cancelButton, XGameUiShowMessageDialogCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XGameUiShowMessageDialogResult(_async, out var resultButton);
			onCompleted(hresult, resultButton);
		}, IntPtr.Zero);
		int num = XGameUiShowMessageDialogAsync(xAsyncBlock, titleText, contextText, firstButtonText, secondButtonText, thirdButtonText, defaultButton, cancelButton);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, XGameUiMessageDialogButton.First);
		}
		return num;
	}

	public static int XGameUiShowMultiplayerActivityGameInviteAsync(XUserHandle requestingUser, XGameUiShowMultiplayerActivityGameInviteCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XGameUiShowMultiplayerActivityGameInviteResult(_async);
			onCompleted(hresult);
		}, IntPtr.Zero);
		int num = XGameUiShowMultiplayerActivityGameInviteAsync(xAsyncBlock, requestingUser);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num);
		}
		return num;
	}

	public static int XGameUiShowPlayerPickerAsync(XUserHandle requestingUser, string promptText, ulong[] selectFromPlayers, ulong[] preSelectedPlayers, uint minSelectionCount, uint maxSelectionCount, XGameUiShowPlayerPickerCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XGameUiShowPlayerPickerResultCount(_async, out var resultPlayersCount);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				ulong[] resultPlayers = new ulong[resultPlayersCount];
				num2 = XGameUiShowPlayerPickerResult(_async, resultPlayers, out var _);
				onCompleted(num2, resultPlayers);
			}
		}, IntPtr.Zero);
		int num = XGameUiShowPlayerPickerAsync(xAsyncBlock, requestingUser, promptText, selectFromPlayers, preSelectedPlayers, minSelectionCount, maxSelectionCount);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XGameUiShowPlayerProfileCardAsync(XUserHandle requestingUser, ulong targetPlayer, XGameUiShowPlayerProfileCardCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XGameUiShowPlayerProfileCardResult(_async);
			onCompleted(hresult);
		}, IntPtr.Zero);
		int num = XGameUiShowPlayerProfileCardAsync(xAsyncBlock, requestingUser, targetPlayer);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num);
		}
		return num;
	}

	public static int XGameUiShowSendGameInviteAsync(XUserHandle requestingUser, string sessionConfigurationId, string sessionTemplateName, string sessionId, string invitationText, string customActivationContext, XGameUiShowSendGameInviteCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XGameUiShowSendGameInviteResult(_async);
			onCompleted(hresult);
		}, IntPtr.Zero);
		int num = XGameUiShowSendGameInviteAsync(xAsyncBlock, requestingUser, sessionConfigurationId, sessionTemplateName, sessionId, invitationText, customActivationContext);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num);
		}
		return num;
	}

	public static int XGameUiShowTextEntryAsync(string titleText, string descriptionText, string defaultText, XGameUiTextEntryInputScope inputScope, uint maxTextLength, XGameUiShowTextEntryCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XGameUiShowTextEntryResultSize(_async, out var resultTextBufferSize);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				num2 = XGameUiShowTextEntryResult(_async, resultTextBufferSize, out var resultTextBuffer);
				onCompleted(num2, resultTextBuffer);
			}
		}, IntPtr.Zero);
		int num = XGameUiShowTextEntryAsync(xAsyncBlock, titleText, descriptionText, defaultText, inputScope, maxTextLength);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XGameUiShowWebAuthenticationAsync(XUserHandle requestingUser, string requestUri, string completeUri, XGameUiShowWebAuthenticationAsyncCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XGameUiShowWebAuthenticationResultSize(_async, out var bufferSize);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				byte[] buffer = new byte[bufferSize];
				num2 = XGameUiShowWebAuthenticationResult(_async, buffer, out var result);
				onCompleted(num2, result);
			}
		}, IntPtr.Zero);
		int num = XGameUiShowWebAuthenticationAsync(xAsyncBlock, requestingUser, requestUri, completeUri);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XGameUiShowWebAuthenticationWithOptionsAsync(XUserHandle requestingUser, string requestUri, string completeUri, XGameUiWebAuthenticationOptions options, Action<int, XGameUiWebAuthenticationResultData> onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XGameUiShowWebAuthenticationResultSize(_async, out var bufferSize);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				byte[] buffer = new byte[bufferSize];
				num2 = XGameUiShowWebAuthenticationResult(_async, buffer, out var result);
				onCompleted(num2, result);
			}
		}, IntPtr.Zero);
		int num = XGameUiShowWebAuthenticationWithOptionsAsync(xAsyncBlock, requestingUser, requestUri, completeUri, options);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XNetworkingQueryPreferredLocalUdpMultiplayerPortAsync(XNetworkingQueryPreferredLocalUdpMultiplayerPortResultFunction onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int errorCode = XNetworkingQueryPreferredLocalUdpMultiplayerPortAsyncResult(_async, out var preferredLocalUdpMultiplayerPort);
			onCompleted(errorCode, preferredLocalUdpMultiplayerPort);
		}, IntPtr.Zero);
		int num = XNetworkingQueryPreferredLocalUdpMultiplayerPortAsync(xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, 0);
		}
		return num;
	}

	public static int XNetworkingQuerySecurityInformationForUrlAsync(string url, XNetworkingQuerySecurityInformationForUrlResultCallback onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XNetworkingQuerySecurityInformationForUrlAsyncResultSize(_async, out var securityInformationBufferByteCount);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				byte[] securityInformationBuffer = new byte[securityInformationBufferByteCount];
				num2 = XNetworkingQuerySecurityInformationForUrlAsyncResult(_async, securityInformationBuffer, out var _, out var securityInformation);
				onCompleted(num2, securityInformation);
			}
		}, IntPtr.Zero);
		int num = XNetworkingQuerySecurityInformationForUrlAsync(url, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XNetworkingQuerySecurityInformationForUrlUtf16Async(string url, XNetworkingQuerySecurityInformationForUrlResultCallback onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XNetworkingQuerySecurityInformationForUrlUtf16AsyncResultSize(_async, out var securityInformationBufferByteCount);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				byte[] securityInformationBuffer = new byte[securityInformationBufferByteCount];
				num2 = XNetworkingQuerySecurityInformationForUrlUtf16AsyncResult(_async, securityInformationBuffer, out var _, out var securityInformation);
				onCompleted(num2, securityInformation);
			}
		}, IntPtr.Zero);
		int num = XNetworkingQuerySecurityInformationForUrlUtf16Async(url, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XNetworkingRegisterConnectivityHintChanged(XNetworkingConnectivityHintChangedCallback callback, out XNetworkingRegisterConnectivityHintChangedCallbackToken token)
	{
		return XNetworkingRegisterConnectivityHintChanged(defaultQueue, IntPtr.Zero, callback, out token);
	}

	public static int XNetworkingRegisterPreferredLocalUdpMultiplayerPortChanged(XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback callback, out XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken token)
	{
		return XNetworkingRegisterPreferredLocalUdpMultiplayerPortChanged(defaultQueue, IntPtr.Zero, callback, out token);
	}

	public static bool XNetworkingUnregisterPreferredLocalUdpMultiplayerPortChanged(XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken token)
	{
		return XNetworkingUnregisterPreferredLocalUdpMultiplayerPortChanged(token, wait: true);
	}

	public static int XPackageCreateInstallationMonitor(string packageIdentifier, XPackageChunkSelector[] selectors, uint minimumUpdateIntervalMs, out XPackageInstallationMonitorHandle installationMonitor)
	{
		return XPackageCreateInstallationMonitor(packageIdentifier, selectors, minimumUpdateIntervalMs, defaultQueue, out installationMonitor);
	}

	public static int XPackageCreateInstallationMonitor(string packageIdentifier, uint minimumUpdateIntervalMs, out XPackageInstallationMonitorHandle installationMonitor)
	{
		return XPackageCreateInstallationMonitor(packageIdentifier, new XPackageChunkSelector[0], minimumUpdateIntervalMs, out installationMonitor);
	}

	public static int XPackageInstallChunksAsync(string packageIdentifier, XPackageChunkSelector[] selectors, uint minimumUpdateIntervalMs, bool suppressUserConfirmation, XPackageInstallChunksCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XPackageInstallChunksResult(_async, out var installationMonitor);
			onCompleted(hresult, installationMonitor);
		}, IntPtr.Zero);
		int num = XPackageInstallChunksAsync(packageIdentifier, selectors, minimumUpdateIntervalMs, suppressUserConfirmation, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	[Obsolete("XPackageMount(string, out XPackageMountHandle) has been removed. Please use XPackageMountWithUiAsync(string packageIdentifier, XPackageMountWithUiAsyncCompleted) instead.", true)]
	public static int XPackageMount(string packageIdentifier, out XPackageMountHandle mountHandle)
	{
		throw new NotSupportedException("XPackageMount(string, out XPackageMountHandle) has been removed. Please use XPackageMountWithUiAsync(string packageIdentifier, XPackageMountWithUiAsyncCompleted) instead.");
	}

	public static int XPackageMountWithUiAsync(string packageIdentifier, XPackageMountWithUiAsyncCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XPackageMountWithUiResult(_async, out var mount);
			onCompleted(hresult, mount);
		}, IntPtr.Zero);
		int num = XPackageMountWithUiAsync(packageIdentifier, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XPackageRegisterPackageInstalled(XPackageInstalledCallback callback, out XPackageRegisterPackageInstalledToken token)
	{
		return XPackageRegisterPackageInstalled(defaultQueue, IntPtr.Zero, callback, out token);
	}

	public static int XPackageRegisterInstallationProgressChanged(XPackageInstallationMonitorHandle installationMonitor, XPackageInstallationProgressCallback callback, out XPackageRegisterInstallationProgressChangedToken token)
	{
		return XPackageRegisterInstallationProgressChanged(installationMonitor, IntPtr.Zero, callback, out token);
	}

	public static int XPersistentLocalStoragePromptUserForSpaceAsync(ulong requestedBytes, XPersistentLocalStoragePromptUserForSpaceAsyncCallback onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XPersistentLocalStoragePromptUserForSpaceResult(_async);
			onCompleted(hresult);
		}, IntPtr.Zero);
		int num = XPersistentLocalStoragePromptUserForSpaceAsync(requestedBytes, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num);
		}
		return num;
	}

	public static int XStoreAcquireLicenseForDurablesAsync(XStoreContext context, string storeId, XStoreAcquireLicenseForDurablesCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XStoreAcquireLicenseForDurablesResult(_async, out var storeLicense);
			onCompleted(hresult, storeLicense);
		}, IntPtr.Zero);
		int num = XStoreAcquireLicenseForDurablesAsync(context, storeId, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreAcquireLicenseForPackageAsync(XStoreContext context, string packageIdentifier, XStoreAcquireLicenseForPackageCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XStoreAcquireLicenseForPackageResult(_async, out var storeLicenseHandle);
			onCompleted(hresult, storeLicenseHandle);
		}, IntPtr.Zero);
		int num = XStoreAcquireLicenseForPackageAsync(context, packageIdentifier, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreCanAcquireLicenseForPackageAsync(XStoreContext storeContextHandle, string packageIdentifier, XStoreCanAcquireLicenseForPackageCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XStoreCanAcquireLicenseForPackageResult(_async, out var storeCanAcquireLicenseResult);
			onCompleted(hresult, storeCanAcquireLicenseResult);
		}, IntPtr.Zero);
		int num = XStoreCanAcquireLicenseForPackageAsync(storeContextHandle, packageIdentifier, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreCanAcquireLicenseForStoreIdAsync(XStoreContext storeContextHandle, string storeProductId, XStoreCanAcquireLicenseForStoreIdCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XStoreCanAcquireLicenseForStoreIdResult(_async, out var storeCanAcquireLicenseResult);
			onCompleted(hresult, storeCanAcquireLicenseResult);
		}, IntPtr.Zero);
		int num = XStoreCanAcquireLicenseForStoreIdAsync(storeContextHandle, storeProductId, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreDownloadAndInstallPackagesAsync(XStoreContext storeContextHandle, string[] storeIds, XStoreDownloadAndInstallPackagesCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XStoreDownloadAndInstallPackagesResultCount(_async, out var count);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				num2 = XStoreDownloadAndInstallPackagesResult(_async, count, out var packageIdentifiers);
				onCompleted(num2, packageIdentifiers);
			}
		}, IntPtr.Zero);
		int num = XStoreDownloadAndInstallPackagesAsync(storeContextHandle, storeIds, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreDownloadAndInstallPackageUpdatesAsync(XStoreContext storeContextHandle, string[] packageIdentifiers, XStoreDownloadAndInstallPackageUpdatesCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XStoreDownloadAndInstallPackageUpdatesResult(_async);
			onCompleted(hresult);
		}, IntPtr.Zero);
		int num = XStoreDownloadAndInstallPackageUpdatesAsync(storeContextHandle, packageIdentifiers, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num);
		}
		return num;
	}

	public static int XStoreDownloadPackageUpdatesAsync(XStoreContext storeContextHandle, string[] packageIdentifiers, XStoreDownloadPackageUpdatesCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XStoreDownloadPackageUpdatesResult(_async);
			onCompleted(hresult);
		}, IntPtr.Zero);
		int num = XStoreDownloadPackageUpdatesAsync(storeContextHandle, packageIdentifiers, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num);
		}
		return num;
	}

	public static int XStoreGetUserCollectionsIdAsync(XStoreContext storeContextHandle, string serviceTicket, string publisherUserId, XStoreGetUserCollectionsIdCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XStoreGetUserCollectionsIdResultSize(_async, out var size);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				num2 = XStoreGetUserCollectionsIdResult(_async, size, out var result);
				onCompleted(num2, result);
			}
		}, IntPtr.Zero);
		int num = XStoreGetUserCollectionsIdAsync(storeContextHandle, serviceTicket, publisherUserId, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreGetUserPurchaseIdAsync(XStoreContext storeContextHandle, string serviceTicket, string publisherUserId, XStoreGetUserPurchaseIdCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XStoreGetUserPurchaseIdResultSize(_async, out var size);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				num2 = XStoreGetUserPurchaseIdResult(_async, size, out var result);
				onCompleted(num2, result);
			}
		}, IntPtr.Zero);
		int num = XStoreGetUserPurchaseIdAsync(storeContextHandle, serviceTicket, publisherUserId, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreProductsQueryNextPageAsync(XStoreProductQuery productQueryHandle, XStoreQueryComplete onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XStoreProductsQueryNextPageResult(_async, out var productQueryHandle2);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				num2 = XStoreEnumerateProductsQuery(productQueryHandle2, out var products);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					onCompleted(num2, null);
				}
				else
				{
					bool hasMorePages = XStoreProductsQueryHasMorePages(productQueryHandle2);
					XStoreQueryResult result = new XStoreQueryResult(productQueryHandle2, products, hasMorePages);
					onCompleted(num2, result);
				}
			}
		}, IntPtr.Zero);
		int num = XStoreProductsQueryNextPageAsync(productQueryHandle, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreProductsQueryNextPageAsync(XStoreQueryResult currentPage, XStoreQueryComplete completionRoutine)
	{
		return XStoreProductsQueryNextPageAsync(currentPage.QueryHandle, completionRoutine);
	}

	public static int XStoreQueryAssociatedProductsAsync(XStoreContext storeContextHandle, XStoreProductKind productKinds, uint maxItemsToRetrievePerPage, Action<int, XStoreProductQuery> onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int arg = XStoreQueryAssociatedProductsResult(_async, out var productQueryHandle);
			onCompleted(arg, productQueryHandle);
		}, IntPtr.Zero);
		int num = XStoreQueryAssociatedProductsAsync(storeContextHandle, productKinds, maxItemsToRetrievePerPage, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreQueryAssociatedProductsAsync(XStoreContext storeContextHandle, XStoreProductKind productKinds, uint maxItemsToRetrievePerPage, XStoreQueryComplete onCompleted)
	{
		return XStoreQueryAssociatedProductsAsync(storeContextHandle, productKinds, maxItemsToRetrievePerPage, (int hr, XStoreProductQuery queryResult) =>
		{
			if (Unity.XGamingRuntime.Interop.HR.FAILED(hr))
			{
				onCompleted(hr, null);
			}
			else
			{
				hr = XStoreEnumerateProductsQuery(queryResult, out var products);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(hr))
				{
					onCompleted(hr, null);
				}
				else
				{
					bool hasMorePages = XStoreProductsQueryHasMorePages(queryResult);
					XStoreQueryResult result = new XStoreQueryResult(queryResult, products, hasMorePages);
					onCompleted(hr, result);
				}
			}
		});
	}

	public static void XStoreCloseProductsQueryHandle(XStoreQueryResult result)
	{
		XStoreCloseProductsQueryHandle(result.QueryHandle);
	}

	public static int XStoreQueryAddOnLicensesAsync(XStoreContext storeContextHandle, XStoreQueryAddOnLicensesCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XStoreQueryAddOnLicensesResultCount(_async, out var count);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				XStoreAddonLicense[] array = new XStoreAddonLicense[count];
				num2 = XStoreQueryAddOnLicensesResult(_async, array);
				onCompleted(num2, array);
			}
		}, IntPtr.Zero);
		int num = XStoreQueryAddOnLicensesAsync(storeContextHandle, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreQueryConsumableBalanceRemainingAsync(XStoreContext storeContextHandle, string storeProductId, XStoreQueryConsumableBalanceRemainingCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XStoreQueryConsumableBalanceRemainingResult(_async, out var consumableResult);
			onCompleted(hresult, consumableResult);
		}, IntPtr.Zero);
		int num = XStoreQueryConsumableBalanceRemainingAsync(storeContextHandle, storeProductId, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreQueryEntitledProductsAsync(XStoreContext storeContextHandle, XStoreProductKind productKinds, uint maxItemsToRetrievePerPage, XStoreQueryComplete onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XStoreQueryEntitledProductsResult(_async, out var productQueryHandle);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				num2 = XStoreEnumerateProductsQuery(productQueryHandle, out var products);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					onCompleted(num2, null);
				}
				else
				{
					bool hasMorePages = XStoreProductsQueryHasMorePages(productQueryHandle);
					XStoreQueryResult result = new XStoreQueryResult(productQueryHandle, products, hasMorePages);
					onCompleted(num2, result);
				}
			}
		}, IntPtr.Zero);
		int num = XStoreQueryEntitledProductsAsync(storeContextHandle, productKinds, maxItemsToRetrievePerPage, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreQueryGameAndDlcPackageUpdatesAsync(XStoreContext storeContextHandle, XStoreQueryGameAndDlcPackageUpdatesCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XStoreQueryGameAndDlcPackageUpdatesResultCount(_async, out var count);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				XStorePackageUpdate[] packageUpdates = new XStorePackageUpdate[count];
				num2 = XStoreQueryGameAndDlcPackageUpdatesResult(_async, packageUpdates);
				onCompleted(num2, packageUpdates);
			}
		}, IntPtr.Zero);
		int num = XStoreQueryGameAndDlcPackageUpdatesAsync(storeContextHandle, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreQueryGameLicenseAsync(XStoreContext storeContextHandle, XStoreQueryGameLicenseCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XStoreQueryGameLicenseResult(_async, out var license);
			onCompleted(hresult, license);
		}, IntPtr.Zero);
		int num = XStoreQueryGameLicenseAsync(storeContextHandle, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreQueryLicenseTokenAsync(XStoreContext storeContextHandle, string[] productIds, string customDeveloperString, XStoreQueryLicenseTokenCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XStoreQueryLicenseTokenResultSize(_async, out var size);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				num2 = XStoreQueryLicenseTokenResult(_async, size, out var result);
				onCompleted(num2, result);
			}
		}, IntPtr.Zero);
		int num = XStoreQueryLicenseTokenAsync(storeContextHandle, productIds, customDeveloperString, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	[Obsolete("Please use XStoreQueryLicenseTokenAsync(XStoreContext, string[], string, XStoreQueryLicenseTokenCompleted) instead.", false)]
	public static void XStoreQueryLicenseTokenAsync(XStoreContext context, string[] productIds, uint productIdsCount, string customDeveloperString, XStoreQueryLicenseTokenCompleted completionRoutine)
	{
		XStoreQueryLicenseTokenAsync(context, productIds, customDeveloperString, completionRoutine);
	}

	public static int XStoreQueryProductForCurrentGameAsync(XStoreContext storeContextHandle, XStoreQueryComplete onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XStoreQueryProductForCurrentGameResult(_async, out var productQueryHandle);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				num2 = XStoreEnumerateProductsQuery(productQueryHandle, out var products);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					onCompleted(num2, null);
				}
				else
				{
					bool hasMorePages = XStoreProductsQueryHasMorePages(productQueryHandle);
					XStoreQueryResult result = new XStoreQueryResult(productQueryHandle, products, hasMorePages);
					onCompleted(num2, result);
				}
			}
		}, IntPtr.Zero);
		int num = XStoreQueryProductForCurrentGameAsync(storeContextHandle, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreQueryProductForPackageAsync(XStoreContext storeContextHandle, XStoreProductKind productKinds, string packageIdentifier, XStoreQueryComplete onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XStoreQueryProductForPackageResult(_async, out var productQueryHandle);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				num2 = XStoreEnumerateProductsQuery(productQueryHandle, out var products);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					onCompleted(num2, null);
				}
				else
				{
					bool hasMorePages = XStoreProductsQueryHasMorePages(productQueryHandle);
					XStoreQueryResult result = new XStoreQueryResult(productQueryHandle, products, hasMorePages);
					onCompleted(num2, result);
				}
			}
		}, IntPtr.Zero);
		int num = XStoreQueryProductForPackageAsync(storeContextHandle, productKinds, packageIdentifier, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreQueryProductsAsync(XStoreContext storeContextHandle, XStoreProductKind productKinds, string[] storeIds, string[] actionFilters, XStoreQueryComplete onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XStoreQueryProductsResult(_async, out var productQueryHandle);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				num2 = XStoreEnumerateProductsQuery(productQueryHandle, out var products);
				if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
				{
					onCompleted(num2, null);
				}
				else
				{
					bool hasMorePages = XStoreProductsQueryHasMorePages(productQueryHandle);
					XStoreQueryResult result = new XStoreQueryResult(productQueryHandle, products, hasMorePages);
					onCompleted(num2, result);
				}
			}
		}, IntPtr.Zero);
		int num = XStoreQueryProductsAsync(storeContextHandle, productKinds, storeIds, actionFilters, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreRegisterGameLicenseChanged(XStoreContext context, XStoreGameLicenseChangedCallback callback, out GameLicenseChangedCallbackToken token)
	{
		return XStoreRegisterGameLicenseChanged(context, defaultQueue, IntPtr.Zero, callback, out token);
	}

	public static void XStoreUnregisterGameLicenseChanged(XStoreContext context, GameLicenseChangedCallbackToken token)
	{
		token.Unregister(wait: true);
	}

	public static int XStoreRegisterPackageLicenseLost(XStoreLicense license, XStorePackageLicenseLostCallback callback, out PackageLicenseLostCallbackToken token)
	{
		return XStoreRegisterPackageLicenseLost(license, defaultQueue, IntPtr.Zero, callback, out token);
	}

	public static void XStoreUnregisterPackageLicenseLost(XStoreLicense license, PackageLicenseLostCallbackToken token)
	{
		token.Unregister(wait: true);
	}

	public static int XStoreReportConsumableFulfillmentAsync(XStoreContext storeContextHandle, string storeProductId, uint quantity, Guid trackingId, XStoreReportConsumableFulfillmentCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XStoreReportConsumableFulfillmentResult(_async, out var consumableResult);
			onCompleted(hresult, consumableResult);
		}, IntPtr.Zero);
		int num = XStoreReportConsumableFulfillmentAsync(storeContextHandle, storeProductId, quantity, trackingId, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreShowAssociatedProductsUIAsync(XStoreContext storeContextHandle, string storeId, XStoreProductKind productKinds, XStoreShowAssociatedProductsUICompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XStoreShowAssociatedProductsUIResult(_async);
			onCompleted(hresult);
		}, IntPtr.Zero);
		int num = XStoreShowAssociatedProductsUIAsync(storeContextHandle, storeId, productKinds, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num);
		}
		return num;
	}

	public static int XStoreShowProductPageUIAsync(XStoreContext storeContextHandle, string storeId, XStoreShowProductPageUICompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XStoreShowProductPageUIResult(_async);
			onCompleted(hresult);
		}, IntPtr.Zero);
		int num = XStoreShowProductPageUIAsync(storeContextHandle, storeId, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num);
		}
		return num;
	}

	public static int XStoreShowPurchaseUIAsync(XStoreContext storeContextHandle, string storeId, string name, string extendedJsonData, XStoreShowPurchaseUICompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XStoreShowPurchaseUIResult(_async);
			onCompleted(hresult);
		}, IntPtr.Zero);
		int num = XStoreShowPurchaseUIAsync(storeContextHandle, storeId, name, extendedJsonData, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num);
		}
		return num;
	}

	public static int XStoreShowRateAndReviewUIAsync(XStoreContext storeContextHandle, XStoreShowRateAndReviewUICompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XStoreShowRateAndReviewUIResult(_async, out var result);
			onCompleted(hresult, result);
		}, IntPtr.Zero);
		int num = XStoreShowRateAndReviewUIAsync(storeContextHandle, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XStoreShowRedeemTokenUIAsync(XStoreContext storeContextHandle, string token, string[] allowedStoreIds, bool disallowCsvRedemption, XStoreShowRedeemTokenUICompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XStoreShowRedeemTokenUIResult(_async);
			onCompleted(hresult);
		}, IntPtr.Zero);
		int num = XStoreShowRedeemTokenUIAsync(storeContextHandle, token, allowedStoreIds, disallowCsvRedemption, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num);
		}
		return num;
	}

	public static int XUserAddByIdWithUiAsync(ulong userId, XUserAddCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XUserAddByIdWithUiResult(_async, out var newUser);
			onCompleted(hresult, newUser);
		}, IntPtr.Zero);
		int num = XUserAddByIdWithUiAsync(userId, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XUserFindControllerForUserWithUiAsync(XUserHandle user, XUserFindControllerForUserWithUiResult onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XUserFindControllerForUserWithUiResult(_async, out var deviceId);
			onCompleted(hresult, deviceId);
		}, IntPtr.Zero);
		int num = XUserFindControllerForUserWithUiAsync(user, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XUserGetTokenAndSignatureUtf16Async(XUserHandle user, XUserGetTokenAndSignatureOptions options, string method, string url, XUserGetTokenAndSignatureUtf16HttpHeader[] headers, byte[] bodyBuffer, XUserGetTokenAndSignatureUtf16Result onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XUserGetTokenAndSignatureUtf16ResultSize(_async, out var bufferSize);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				byte[] buffer = new byte[bufferSize];
				num2 = XUserGetTokenAndSignatureUtf16Result(_async, buffer, out var result);
				onCompleted(num2, result);
			}
		}, IntPtr.Zero);
		int num = XUserGetTokenAndSignatureUtf16Async(user, options, method, url, headers, bodyBuffer, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XUserResolveIssueWithUiUtf16Async(XUserHandle user, string url, XUserResolveIssueWithUiUtf16Result onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XUserResolveIssueWithUiUtf16Result(_async);
			onCompleted(hresult);
		}, IntPtr.Zero);
		int num = XUserResolveIssueWithUiUtf16Async(user, url, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num);
		}
		return num;
	}

	public static int XUserResolvePrivilegeWithUiAsync(XUserHandle user, XUserPrivilegeOptions options, XUserPrivilege privilege, XUserResolvePrivilegeWithUiCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XUserResolvePrivilegeWithUiResult(_async);
			onCompleted(hresult);
		}, IntPtr.Zero);
		int num = XUserResolvePrivilegeWithUiAsync(user, options, privilege, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num);
		}
		return num;
	}

	public static int XUserGetGamerPictureAsync(XUserHandle user, XUserGamerPictureSize pictureSize, XUserGetGamerPictureCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int num2 = XUserGetGamerPictureResultSize(_async, out var bufferSize);
			if (Unity.XGamingRuntime.Interop.HR.FAILED(num2))
			{
				onCompleted(num2, null);
			}
			else
			{
				byte[] buffer = new byte[bufferSize];
				num2 = XUserGetGamerPictureResult(_async, buffer, out var _);
				onCompleted(num2, buffer);
			}
		}, IntPtr.Zero);
		int num = XUserGetGamerPictureAsync(user, pictureSize, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XUserAddAsync(XUserAddOptions options, XUserAddCompleted onCompleted)
	{
		XAsyncBlock xAsyncBlock = new XAsyncBlock(defaultQueue, (XAsyncBlock _async) =>
		{
			int hresult = XUserAddResult(_async, out var newUser);
			onCompleted(hresult, newUser);
		}, IntPtr.Zero);
		int num = XUserAddAsync(options, xAsyncBlock);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			xAsyncBlock.Dispose();
			onCompleted(num, null);
		}
		return num;
	}

	public static int XAppBroadcastRegisterIsAppBroadcastingChanged(XAppBroadcastMonitorCallback callback, out XIsAppBroadcastingChangedRegistrationToken token)
	{
		return XAppBroadcastRegisterIsAppBroadcastingChanged(defaultQueue, callback, out token);
	}

	public static bool XAppBroadcastUnregisterIsAppBroadcastingChanged(XIsAppBroadcastingChangedRegistrationToken token)
	{
		return XAppBroadcastUnregisterIsAppBroadcastingChanged(token, wait: true);
	}

	public static int XAppCaptureRegisterMetadataPurged(XAppCaptureMetadataPurgedCallback callback, out XMetadataPurgedToken token)
	{
		return XAppCaptureRegisterMetadataPurged(defaultQueue, callback, out token);
	}

	public static bool XAppCaptureUnRegisterMetadataPurged(XMetadataPurgedToken token)
	{
		return XAppCaptureUnRegisterMetadataPurged(token, wait: true);
	}

	public static int XGameInviteRegisterForEvent(XGameInviteEventCallback callback, out XGameInviteRegistrationToken token)
	{
		return XGameInviteRegisterForEvent(defaultQueue, callback, out token);
	}

	[AOT.MonoPInvokeCallback(typeof(XAsyncProviderInterop))]
	private static int OnAsyncProvider(XAsyncOp op, Unity.XGamingRuntime.Interop.XAsyncProviderData data)
	{
		return (GCHandle.FromIntPtr(data.context).Target as CallbackWrapper<XAsyncProviderInterop>).Callback(op, data);
	}

	public static int XAsyncBegin(XAsyncBlock asyncBlock, IntPtr context, IntPtr identity, string identityName, XAsyncProvider provider)
	{
		using CallbackWrapper<XAsyncProviderInterop> callbackWrapper = new CallbackWrapper<XAsyncProviderInterop>((XAsyncOp _op, Unity.XGamingRuntime.Interop.XAsyncProviderData _dataInterop) =>
		{
			XAsyncProviderData data = new XAsyncProviderData(_dataInterop, asyncBlock);
			return provider(_op, data);
		}, context, OnAsyncProvider);
		return NativeMethods.XAsyncBegin(asyncBlock.InteropPtr, callbackWrapper.CallbackContext, identity, identityName, callbackWrapper.StaticCallback);
	}

	public static int XAsyncSchedule(XAsyncBlock asyncBlock, uint delayInMs)
	{
		return NativeMethods.XAsyncSchedule(asyncBlock.InteropPtr, delayInMs);
	}

	public static void XAsyncComplete(XAsyncBlock asyncBlock, uint result, ulong requiredBufferSize)
	{
		NativeMethods.XAsyncComplete(asyncBlock.InteropPtr, result, requiredBufferSize);
	}

	public static int XAsyncGetResult(XAsyncBlock asyncBlock, IntPtr identity, byte[] buffer, out ulong bufferUsed)
	{
		return NativeMethods.XAsyncGetResult(asyncBlock.InteropPtr, identity, (uint)buffer.Length, buffer, out bufferUsed);
	}

	public static XDisplayHdrModeResult XDisplayTryEnableHdrMode(XDisplayHdrModePreference displayModePreference, out XDisplayHdrModeInfo displayHdrModeInfo)
	{
		Unity.XGamingRuntime.Interop.XDisplayHdrModeInfo displayHdrModeInfo2 = default;
		XDisplayHdrModeResult result = NativeMethods.XDisplayTryEnableHdrMode(displayModePreference, out displayHdrModeInfo2);
		displayHdrModeInfo = new XDisplayHdrModeInfo(displayHdrModeInfo2);
		return result;
	}

	public static int XDisplayAcquireTimeoutDeferral(out XDisplayTimeoutDeferralHandle handle)
	{
		handle = null;
		int num = NativeMethods.XDisplayAcquireTimeoutDeferral(out var handle2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			handle = new XDisplayTimeoutDeferralHandle(handle2);
		}
		return num;
	}

	public static void XDisplayCloseTimeoutDeferralHandle(XDisplayTimeoutDeferralHandle handle)
	{
		handle.Close();
	}

	[AOT.MonoPInvokeCallback(typeof(Unity.XGamingRuntime.Interop.XErrorCallback))]
	private static bool OnErrorCallback(int hr, string msg, IntPtr context)
	{
		CallbackWrapper<Unity.XGamingRuntime.Interop.XErrorCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<Unity.XGamingRuntime.Interop.XErrorCallback>;
		return callbackWrapper.Callback(hr, msg, callbackWrapper.Context);
	}

	public static void XErrorSetCallback(XErrorCallback callback, IntPtr context)
	{
		Unity.XGamingRuntime.Interop.XErrorCallback callback2 = (int hr, string msg, IntPtr context2) => callback(hr, msg, context2);
		if (errorCallbackWrapper != null)
		{
			errorCallbackWrapper.Dispose();
			errorCallbackWrapper = null;
		}
		if (callback != null)
		{
			errorCallbackWrapper = new CallbackWrapper<Unity.XGamingRuntime.Interop.XErrorCallback>(callback2, context, OnErrorCallback);
		}
		NativeMethods.XErrorSetCallback((errorCallbackWrapper != null) ? errorCallbackWrapper.StaticCallback : null, (errorCallbackWrapper != null) ? errorCallbackWrapper.CallbackContext : IntPtr.Zero);
	}

	public static void XErrorSetOptions(XErrorOptions optionsDebuggerPresent, XErrorOptions optionsDebuggerNotPresent)
	{
		NativeMethods.XErrorSetOptions(optionsDebuggerPresent, optionsDebuggerNotPresent);
	}

	public static int XGameSaveEnumerateBlobInfo(XGameSaveContainerHandle container, out XGameSaveBlobInfo[] blobInfos)
	{
		blobInfos = null;
		List<XGameSaveBlobInfo> results = new List<XGameSaveBlobInfo>();
		int num = XGameSaveEnumerateBlobInfo(container, IntPtr.Zero, (XGameSaveBlobInfo _blobInfo, IntPtr _context) =>
		{
			results.Add(_blobInfo);
			return true;
		});
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			blobInfos = results.ToArray();
		}
		return num;
	}

	public static int XGameSaveGetContainerInfo(XGameSaveProviderHandle provider, string containerName, out XGameSaveContainerInfo containerInfo)
	{
		containerInfo = null;
		XGameSaveContainerInfo info = null;
		int num = XGameSaveGetContainerInfo(provider, containerName, IntPtr.Zero, (XGameSaveContainerInfo _info, IntPtr _context) =>
		{
			info = _info;
			return true;
		});
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			containerInfo = info;
		}
		return num;
	}

	public static int XGameSaveEnumerateContainerInfo(XGameSaveProviderHandle provider, out XGameSaveContainerInfo[] localInfos)
	{
		localInfos = null;
		List<XGameSaveContainerInfo> results = new List<XGameSaveContainerInfo>();
		int num = XGameSaveEnumerateContainerInfo(provider, IntPtr.Zero, (XGameSaveContainerInfo _info, IntPtr _context) =>
		{
			results.Add(_info);
			return true;
		});
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			localInfos = results.ToArray();
		}
		return num;
	}

	public static int XGameSaveEnumerateContainerInfoByName(XGameSaveProviderHandle provider, string containerNamePrefix, out XGameSaveContainerInfo[] localInfos)
	{
		localInfos = null;
		List<XGameSaveContainerInfo> results = new List<XGameSaveContainerInfo>();
		int num = XGameSaveEnumerateContainerInfoByName(provider, containerNamePrefix, IntPtr.Zero, (XGameSaveContainerInfo _info, IntPtr _context) =>
		{
			results.Add(_info);
			return true;
		});
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			localInfos = results.ToArray();
		}
		return num;
	}

	public static int XGameSaveEnumerateBlobInfoByName(XGameSaveContainerHandle provider, string blobNamePrefix, out XGameSaveBlobInfo[] blobInfos)
	{
		blobInfos = null;
		List<XGameSaveBlobInfo> results = new List<XGameSaveBlobInfo>();
		int num = XGameSaveEnumerateBlobInfoByName(provider, blobNamePrefix, IntPtr.Zero, (XGameSaveBlobInfo _info, IntPtr _context) =>
		{
			results.Add(_info);
			return true;
		});
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			blobInfos = results.ToArray();
		}
		return num;
	}

	public static int XGameSaveReadBlobData(XGameSaveContainerHandle container, List<XGameSaveBlobInfo> blobInfos, out List<XGameSaveBlob> blobs)
	{
		blobs = null;
		int num = XGameSaveReadBlobData(container, blobInfos.ToArray(), out var blobData);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			blobs = new List<XGameSaveBlob>(blobData);
		}
		return num;
	}

	public static int XSpeechSynthesizerEnumerateInstalledVoices(out XSpeechSynthesizerVoiceInformation[] voiceInformation)
	{
		voiceInformation = null;
		List<XSpeechSynthesizerVoiceInformation> voices = new List<XSpeechSynthesizerVoiceInformation>();
		int num = XSpeechSynthesizerEnumerateInstalledVoices(IntPtr.Zero, VoiceCallback);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			voiceInformation = voices.ToArray();
		}
		return num;
		bool VoiceCallback(ref XSpeechSynthesizerVoiceInformation information, IntPtr context)
		{
			voices.Add(information);
			return true;
		}
	}

	public static int XSpeechSynthesizerGetStreamData(XSpeechSynthesizerStreamHandle speechSynthesisStream, out byte[] buffer)
	{
		buffer = null;
		int num = XSpeechSynthesizerGetStreamDataSize(speechSynthesisStream, out var bufferSize);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			return num;
		}
		buffer = new byte[bufferSize];
		ulong bufferUsed;
		return XSpeechSynthesizerGetStreamData(speechSynthesisStream, buffer, out bufferUsed);
	}

	public static int XStoreEnumerateProductsQuery(XStoreProductQuery productQueryHandle, out XStoreProduct[] products)
	{
		products = null;
		List<XStoreProduct> tmpProducts = new List<XStoreProduct>();
		int num = XStoreEnumerateProductsQuery(productQueryHandle, IntPtr.Zero, OnProduct);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			products = tmpProducts.ToArray();
		}
		return num;
		bool OnProduct(XStoreProduct product, IntPtr _)
		{
			tmpProducts.Add(product);
			return true;
		}
	}

	public static int XUserGetGamertag(XUserHandle user, XUserGamertagComponent gamertagComponent, out string gamertag)
	{
		gamertag = null;
		int num = 0;
		switch (gamertagComponent)
		{
		case XUserGamertagComponent.Classic:
			num = 16;
			break;
		case XUserGamertagComponent.Modern:
			num = 97;
			break;
		case XUserGamertagComponent.ModernSuffix:
			num = 15;
			break;
		case XUserGamertagComponent.UniqueModern:
			num = 101;
			break;
		default:
			return -2147024809;
		}
		StringBuilder stringBuilder = new StringBuilder(num);
		int num2 = XUserGetGamertag(user, gamertagComponent, stringBuilder, out var _);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num2))
		{
			gamertag = stringBuilder.ToString();
		}
		return num2;
	}

	public static int XAppCaptureRecordDiagnosticClip(DateTime startTime, uint durationInMS, string fileNamePrefix, out XAppCaptureRecordClipResult result)
	{
		if (startTime.Kind != DateTimeKind.Utc)
		{
			startTime = startTime.ToUniversalTime();
		}
		return XAppCaptureRecordDiagnosticClip(new TimeT(startTime).SecondsSinceUnixEpoch, durationInMS, fileNamePrefix, out result);
	}

	public static int XPackageGetMountPath(XPackageMountHandle mountHandle, out string path)
	{
		path = string.Empty;
		int num = XPackageGetMountPathSize(mountHandle, out var pathSize);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			return num;
		}
		return XPackageGetMountPath(mountHandle, pathSize, out path);
	}

	public static int XPackageEstimateDownloadSize(string packageIdentifier, out ulong downloadSize, out bool shouldPresentUserConfirmation)
	{
		return XPackageEstimateDownloadSize(packageIdentifier, new XPackageChunkSelector[0], out downloadSize, out shouldPresentUserConfirmation);
	}

	public static int XPackageEnumerateChunkAvailability(string packageIdentifier, XPackageChunkSelectorType type, XPackageChunkAvailabilityCallback callback)
	{
		return XPackageEnumerateChunkAvailability(packageIdentifier, type, IntPtr.Zero, callback);
	}

	public static int XPackageEnumeratePackages(XPackageKind kind, XPackageEnumerationScope scope, out XPackageDetails[] details)
	{
		details = null;
		List<XPackageDetails> results = new List<XPackageDetails>();
		int num = XPackageEnumeratePackages(kind, scope, IntPtr.Zero, (IntPtr context, XPackageDetails item) =>
		{
			results.Add(item);
			return true;
		});
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			details = results.ToArray();
		}
		return num;
	}

	public static int XPackageEnumerateFeatures(string packageIdentifier, out XPackageFeature[] features)
	{
		features = null;
		List<XPackageFeature> results = new List<XPackageFeature>();
		int num = XPackageEnumerateFeatures(packageIdentifier, IntPtr.Zero, (IntPtr context, XPackageFeature feature) =>
		{
			results.Add(feature);
			return true;
		});
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			features = results.ToArray();
		}
		return num;
	}

	public static int XSpeechSynthesizerSetCustomVoice(XSpeechSynthesizerHandle speechSynthesizer, XSpeechSynthesizerVoiceInformation voiceInformation)
	{
		return XSpeechSynthesizerSetCustomVoice(speechSynthesizer, voiceInformation.VoiceId);
	}

	public static int XGameGetXboxTitleId(out uint titleId)
	{
		return NativeMethods.XGameGetXboxTitleId(out titleId);
	}

	public static void XLaunchNewGame(string exePath, string args, XUserHandle defaultUser)
	{
		IntPtr defaultUser2 = ((defaultUser != null) ? defaultUser.Handle : IntPtr.Zero);
		NativeMethods.XLaunchNewGame(exePath, args, defaultUser2);
	}

	public static int XLaunchRestartOnCrash(string args, uint reserved)
	{
		return NativeMethods.XLaunchRestartOnCrash(args, reserved);
	}

	public static int XGameEventWrite(XUserHandle user, string serviceConfigId, string playSessionId, string eventName, string dimensionsJson, string measurementsJson)
	{
		return NativeMethods.XGameEventWrite((user != null) ? user.Handle : IntPtr.Zero, serviceConfigId, playSessionId, eventName, dimensionsJson, measurementsJson);
	}

	public static int XGameInviteRegisterForEvent(XTaskQueueHandle handle, XGameInviteEventCallback callback, IntPtr context, out XGameInviteRegistrationToken token)
	{
		Unity.XGamingRuntime.Interop.XGameInviteEventCallback callback2 = (IntPtr context2, string inviteUri) =>
		{
			callback(context2, inviteUri);
		};
		token = new XGameInviteRegistrationToken(callback2, context);
		int num = NativeMethods.XGameInviteRegisterForEvent((handle != null) ? handle.Handle : IntPtr.Zero, token.interop.CallbackContext, token.interop.StaticCallback, out var token2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num) && token2 != 0L)
		{
			token.Token = token2;
			return num;
		}
		token.interop.Dispose();
		token = null;
		return num;
	}

	public static int XGameInviteRegisterForEvent(XTaskQueueHandle handle, XGameInviteEventCallback callback, out XGameInviteRegistrationToken token)
	{
		return XGameInviteRegisterForEvent(handle, callback, IntPtr.Zero, out token);
	}

	public static bool XGameInviteUnregisterForEvent(XGameInviteRegistrationToken token, bool wait)
	{
		return token.Unregister(wait);
	}

	public static bool XGameInviteUnregisterForEvent(XGameInviteRegistrationToken token)
	{
		return XGameInviteUnregisterForEvent(token, wait: true);
	}

	public static int XGameProtocolRegisterForActivation(XTaskQueueHandle queue, IntPtr context, XGameProtocolActivationCallback callback, out XGameProtocolActivationToken token)
	{
		Unity.XGamingRuntime.Interop.XGameProtocolActivationCallback callback2 = (IntPtr context2, string protocolUri) =>
		{
			callback(context2, protocolUri);
		};
		token = new XGameProtocolActivationToken(callback2, context);
		int num = NativeMethods.XGameProtocolRegisterForActivation((queue != null) ? queue.Handle : IntPtr.Zero, token.interop.CallbackContext, token.interop.StaticCallback, out var token2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			token.Token = token2;
			return num;
		}
		token.interop.Dispose();
		token = null;
		return num;
	}

	public static bool XGameProtocolUnregisterForActivation(XGameProtocolActivationToken token, bool wait)
	{
		return token.Unregister(wait);
	}

	public static bool XGameRuntimeIsFeatureAvailable(XGameRuntimeFeature feature)
	{
		return NativeMethods.XGameRuntimeIsFeatureAvailable(feature);
	}

	public static int XGameRuntimeInitialize()
	{
		return NativeMethods.XGameRuntimeInitialize();
	}

	private static int XGameRuntimeInitializeWithOptions(XGameRuntimeOptions options)
	{
		return NativeMethods.XGameRuntimeInitializeWithOptions(options);
	}

	public static void XGameRuntimeUninitialize()
	{
		NativeMethods.XGameRuntimeUninitialize();
	}

	private static bool XVersionLessThan(XVersion version1, XVersion version2)
	{
		if (version1.Value == version2.Value)
		{
			return false;
		}
		if (version1.Major < version2.Major)
		{
			return false;
		}
		if (version1.Minor < version2.Minor)
		{
			return false;
		}
		if (version1.Build < version2.Build)
		{
			return false;
		}
		if (version1.Revision < version2.Revision)
		{
			return false;
		}
		return true;
	}

	public static void XGameSaveCloseContainer(XGameSaveContainerHandle context)
	{
		context.Close();
	}

	public static void XGameSaveCloseProvider(XGameSaveProviderHandle provider)
	{
		provider.Close();
	}

	public static void XGameSaveCloseUpdate(XGameSaveUpdateHandle context)
	{
		context.Close();
	}

	public static int XGameSaveInitializeProvider(XUserHandle requestingUser, string configurationId, bool syncOnDemand, out XGameSaveProviderHandle provider)
	{
		IntPtr provider2 = default;
		provider = null;
		int num = NativeMethods.XGameSaveInitializeProvider((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero, configurationId, syncOnDemand, out provider2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num) || (num == -2138898428 && provider2 != (IntPtr)0))
		{
			provider = new XGameSaveProviderHandle(provider2);
		}
		return num;
	}

	public static int XGameSaveInitializeProviderAsync(XUserHandle requestingUser, string configurationId, bool syncOnDemand, XAsyncBlock asyncBlock)
	{
		return NativeMethods.XGameSaveInitializeProviderAsync((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero, configurationId, syncOnDemand, asyncBlock.InteropPtr);
	}

	public static int XGameSaveInitializeProviderResult(XAsyncBlock asyncBlock, out XGameSaveProviderHandle provider)
	{
		IntPtr provider2 = default;
		provider = null;
		int num = NativeMethods.XGameSaveInitializeProviderResult(asyncBlock.InteropPtr, out provider2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num) || (num == -2138898428 && provider2 != (IntPtr)0))
		{
			provider = new XGameSaveProviderHandle(provider2);
		}
		return num;
	}

	public static int XGameSaveGetRemainingQuota(XGameSaveProviderHandle provider, out long remainingQuota)
	{
		return NativeMethods.XGameSaveGetRemainingQuota(provider.Handle, out remainingQuota);
	}

	public static int XGameSaveGetRemainingQuotaAsync(XGameSaveProviderHandle provider, XAsyncBlock asyncBlock)
	{
		return NativeMethods.XGameSaveGetRemainingQuotaAsync(provider.Handle, asyncBlock.InteropPtr);
	}

	public static int XGameSaveGetRemainingQuotaResult(XAsyncBlock async, out long remainingQuota)
	{
		return NativeMethods.XGameSaveGetRemainingQuotaResult(async.InteropPtr, out remainingQuota);
	}

	public static int XGameSaveDeleteContainer(XGameSaveProviderHandle provider, string containerName)
	{
		return NativeMethods.XGameSaveDeleteContainer(provider.Handle, containerName);
	}

	public static int XGameSaveDeleteContainerAsync(XGameSaveProviderHandle provider, string containerName, XAsyncBlock async)
	{
		return NativeMethods.XGameSaveDeleteContainerAsync(provider.Handle, containerName, async.InteropPtr);
	}

	public static int XGameSaveDeleteContainerResult(XAsyncBlock async)
	{
		return NativeMethods.XGameSaveDeleteContainerResult(async.InteropPtr);
	}

	[AOT.MonoPInvokeCallback(typeof(Unity.XGamingRuntime.Interop.XGameSaveContainerInfoCallback))]
	private static bool OnContainerInfo(Unity.XGamingRuntime.Interop.XGameSaveContainerInfo info, IntPtr context)
	{
		CallbackWrapper<Unity.XGamingRuntime.Interop.XGameSaveContainerInfoCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<Unity.XGamingRuntime.Interop.XGameSaveContainerInfoCallback>;
		return callbackWrapper.Callback(info, callbackWrapper.Context);
	}

	public static int XGameSaveGetContainerInfo(XGameSaveProviderHandle provider, string containerName, IntPtr context, XGameSaveContainerInfoCallback callback)
	{
		using CallbackWrapper<Unity.XGamingRuntime.Interop.XGameSaveContainerInfoCallback> callbackWrapper = new CallbackWrapper<Unity.XGamingRuntime.Interop.XGameSaveContainerInfoCallback>((Unity.XGamingRuntime.Interop.XGameSaveContainerInfo info, IntPtr callbackContext) => callback(new XGameSaveContainerInfo(info), callbackContext), context, OnContainerInfo);
		return NativeMethods.XGameSaveGetContainerInfo(provider.Handle, containerName, callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
	}

	public static int XGameSaveEnumerateContainerInfo(XGameSaveProviderHandle provider, IntPtr context, XGameSaveContainerInfoCallback callback)
	{
		using CallbackWrapper<Unity.XGamingRuntime.Interop.XGameSaveContainerInfoCallback> callbackWrapper = new CallbackWrapper<Unity.XGamingRuntime.Interop.XGameSaveContainerInfoCallback>((Unity.XGamingRuntime.Interop.XGameSaveContainerInfo info, IntPtr callbackContext) => callback(new XGameSaveContainerInfo(info), callbackContext), context, OnContainerInfo);
		return NativeMethods.XGameSaveEnumerateContainerInfo(provider.Handle, callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
	}

	public static int XGameSaveEnumerateContainerInfoByName(XGameSaveProviderHandle provider, string containerNamePrefix, IntPtr context, XGameSaveContainerInfoCallback callback)
	{
		using CallbackWrapper<Unity.XGamingRuntime.Interop.XGameSaveContainerInfoCallback> callbackWrapper = new CallbackWrapper<Unity.XGamingRuntime.Interop.XGameSaveContainerInfoCallback>((Unity.XGamingRuntime.Interop.XGameSaveContainerInfo info, IntPtr callbackContext) => callback(new XGameSaveContainerInfo(info), callbackContext), context, OnContainerInfo);
		return NativeMethods.XGameSaveEnumerateContainerInfoByName(provider.Handle, containerNamePrefix, callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
	}

	public static int XGameSaveReadBlobData(XGameSaveContainerHandle container, XGameSaveBlobInfo[] blobInfos, out XGameSaveBlob[] blobData)
	{
		blobData = null;
		int num = 0;
		string[] array = blobInfos.Select((XGameSaveBlobInfo x) => x.Name).ToArray();
		uint countOfBlobs = (uint)array.Length;
		ulong num2 = (ulong)blobInfos.Sum((XGameSaveBlobInfo x) => Marshal.SizeOf(typeof(XGameSaveBlobInterop)) + x.Name.Length + 1 + Convert.ToInt32(x.Size));
		IntPtr intPtr = Marshal.AllocHGlobal(Convert.ToInt32(num2));
		try
		{
			num = NativeMethods.XGameSaveReadBlobData(container.Handle, array, ref countOfBlobs, num2, intPtr);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				blobData = InteropHelpers.MarshalArray(intPtr, countOfBlobs, (XGameSaveBlobInterop blobDataInterop) => new XGameSaveBlob(blobDataInterop));
			}
		}
		catch (Exception ex)
		{
			num = ex.HResult;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
		return num;
	}

	public static int XGameSaveCreateContainer(XGameSaveProviderHandle provider, string containerName, out XGameSaveContainerHandle containerContext)
	{
		containerContext = null;
		int num = NativeMethods.XGameSaveCreateContainer(provider.Handle, containerName, out var containerContext2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			containerContext = new XGameSaveContainerHandle(containerContext2);
		}
		return num;
	}

	public static int XGameSaveReadBlobDataResult(XAsyncBlock async, ulong blobsSize, out XGameSaveBlob[] blobData)
	{
		blobData = null;
		int num = 0;
		IntPtr intPtr = Marshal.AllocHGlobal(Convert.ToInt32(blobsSize));
		try
		{
			num = NativeMethods.XGameSaveReadBlobDataResult(async.InteropPtr, blobsSize, intPtr, out var countOfBlobs);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				blobData = InteropHelpers.MarshalArray(intPtr, countOfBlobs, (XGameSaveBlobInterop blobDataInterop) => new XGameSaveBlob(blobDataInterop));
			}
		}
		catch (Exception ex)
		{
			num = ex.HResult;
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
		return num;
	}

	[AOT.MonoPInvokeCallback(typeof(Unity.XGamingRuntime.Interop.XGameSaveBlobInfoCallback))]
	private static bool OnBlobInfo(Unity.XGamingRuntime.Interop.XGameSaveBlobInfo info, IntPtr context)
	{
		CallbackWrapper<Unity.XGamingRuntime.Interop.XGameSaveBlobInfoCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<Unity.XGamingRuntime.Interop.XGameSaveBlobInfoCallback>;
		return callbackWrapper.Callback(info, callbackWrapper.Context);
	}

	public static int XGameSaveEnumerateBlobInfo(XGameSaveContainerHandle container, IntPtr context, XGameSaveBlobInfoCallback callback)
	{
		using CallbackWrapper<Unity.XGamingRuntime.Interop.XGameSaveBlobInfoCallback> callbackWrapper = new CallbackWrapper<Unity.XGamingRuntime.Interop.XGameSaveBlobInfoCallback>((Unity.XGamingRuntime.Interop.XGameSaveBlobInfo info, IntPtr callbackContext) => callback(new XGameSaveBlobInfo(info), callbackContext), context, OnBlobInfo);
		return NativeMethods.XGameSaveEnumerateBlobInfo(container.Handle, callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
	}

	public static int XGameSaveEnumerateBlobInfoByName(XGameSaveContainerHandle container, string blobNamePrefix, IntPtr context, XGameSaveBlobInfoCallback callback)
	{
		using CallbackWrapper<Unity.XGamingRuntime.Interop.XGameSaveBlobInfoCallback> callbackWrapper = new CallbackWrapper<Unity.XGamingRuntime.Interop.XGameSaveBlobInfoCallback>((Unity.XGamingRuntime.Interop.XGameSaveBlobInfo info, IntPtr callbackContext) => callback(new XGameSaveBlobInfo(info), callbackContext), context, OnBlobInfo);
		return NativeMethods.XGameSaveEnumerateBlobInfoByName(container.Handle, blobNamePrefix, callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
	}

	public static int XGameSaveReadBlobDataAsync(XGameSaveContainerHandle container, string[] blobNames, XAsyncBlock async)
	{
		return NativeMethods.XGameSaveReadBlobDataAsync(container.Handle, blobNames, (uint)blobNames.Length, async.InteropPtr);
	}

	public static int XGameSaveCreateUpdate(XGameSaveContainerHandle container, string containerDisplayName, out XGameSaveUpdateHandle updateContext)
	{
		updateContext = null;
		int num = NativeMethods.XGameSaveCreateUpdate(container.Handle, containerDisplayName, out var updateContext2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			updateContext = new XGameSaveUpdateHandle(updateContext2);
		}
		return num;
	}

	public static int XGameSaveSubmitBlobWrite(XGameSaveUpdateHandle updateContext, string blobName, byte[] data)
	{
		return NativeMethods.XGameSaveSubmitBlobWrite(updateContext.Handle, blobName, data, (uint)data.Length);
	}

	public static int XGameSaveSubmitBlobWrite(XGameSaveUpdateHandle updateContext, string blobName, byte[] data, uint length)
	{
		return NativeMethods.XGameSaveSubmitBlobWrite(updateContext.Handle, blobName, data, length);
	}

	public static int XGameSaveSubmitBlobDelete(XGameSaveUpdateHandle updateContext, string blobName)
	{
		return NativeMethods.XGameSaveSubmitBlobDelete(updateContext.Handle, blobName);
	}

	public static int XGameSaveSubmitUpdate(XGameSaveUpdateHandle updateContext)
	{
		return NativeMethods.XGameSaveSubmitUpdate(updateContext.Handle);
	}

	public static int XGameSaveSubmitUpdateAsync(XGameSaveUpdateHandle updateContext, XAsyncBlock async)
	{
		return NativeMethods.XGameSaveSubmitUpdateAsync(updateContext.Handle, async.InteropPtr);
	}

	public static int XGameSaveSubmitUpdateResult(XAsyncBlock async)
	{
		return NativeMethods.XGameSaveSubmitUpdateResult(async.InteropPtr);
	}

	public static int XGameSaveFilesGetFolderWithUiAsync(XUserHandle requestingUser, string configurationId, XAsyncBlock async)
	{
		return NativeMethods.XGameSaveFilesGetFolderWithUiAsync((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero, configurationId, async.InteropPtr);
	}

	public static int XGameSaveFilesGetFolderWithUiResult(XAsyncBlock async, ulong folderSize, out string folderResult)
	{
		folderResult = null;
		StringBuilder stringBuilder = new StringBuilder((int)folderSize);
		int num = NativeMethods.XGameSaveFilesGetFolderWithUiResult(async.InteropPtr, folderSize, stringBuilder);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			folderResult = stringBuilder.ToString();
		}
		return num;
	}

	[Obsolete("Please use XGameSaveFilesGetRemainingQuota(XUserHandle, string, out UInt64) instead", false)]
	public static int XGameSaveFilesGetRemainingQuota(XUserHandle userContext, string configurationId, out long remainingQuota)
	{
		int result = NativeMethods.XGameSaveFilesGetRemainingQuota(userContext.Handle, configurationId, out var remainingQuota2);
		remainingQuota = (long)remainingQuota2;
		return result;
	}

	public static int XGameSaveFilesGetRemainingQuota(XUserHandle userContext, string configurationId, out ulong remainingQuota)
	{
		return NativeMethods.XGameSaveFilesGetRemainingQuota((userContext != null) ? userContext.Handle : IntPtr.Zero, configurationId, out remainingQuota);
	}

	private static int ProcessTouchControlOperation(ref XGameStreamingTouchControlsStateOperation[] operations, out Unity.XGamingRuntime.Interop.XGameStreamingTouchControlsStateOperation[] nativeOperations, out List<IntPtr> stringsToFree)
	{
		nativeOperations = new Unity.XGamingRuntime.Interop.XGameStreamingTouchControlsStateOperation[operations.Length];
		stringsToFree = new List<IntPtr>();
		for (int i = 0; i < operations.Length; i++)
		{
			XGameStreamingTouchControlsStateOperation xGameStreamingTouchControlsStateOperation = operations[i];
			nativeOperations[i].path = xGameStreamingTouchControlsStateOperation.Path;
			nativeOperations[i].value.valueKind = xGameStreamingTouchControlsStateOperation.Value.ValueKind;
			switch (xGameStreamingTouchControlsStateOperation.Value.ValueKind)
			{
			case XGameStreamingTouchControlsStateValueKind.Boolean:
				nativeOperations[i].value.boolValue = xGameStreamingTouchControlsStateOperation.Value.BoolValue;
				break;
			case XGameStreamingTouchControlsStateValueKind.Integer:
				nativeOperations[i].value.integerValue = xGameStreamingTouchControlsStateOperation.Value.IntegerValue;
				break;
			case XGameStreamingTouchControlsStateValueKind.Double:
				nativeOperations[i].value.doubleValue = xGameStreamingTouchControlsStateOperation.Value.DoubleValue;
				break;
			case XGameStreamingTouchControlsStateValueKind.String:
				nativeOperations[i].value.stringValue = InteropHelpers.MarshalStringUtf8(xGameStreamingTouchControlsStateOperation.Value.StringValue);
				stringsToFree.Add(nativeOperations[i].value.stringValue);
				break;
			default:
				return -2147024809;
			}
		}
		return 0;
	}

	public static int XGameStreamingInitialize()
	{
		return NativeMethods.XGameStreamingInitialize();
	}

	public static void XGameStreamingUninitialize()
	{
		NativeMethods.XGameStreamingUninitialize();
	}

	public static bool XGameStreamingIsStreaming()
	{
		return NativeMethods.XGameStreamingIsStreaming();
	}

	public static uint XGameStreamingGetClientCount()
	{
		return NativeMethods.XGameStreamingGetClientCount();
	}

	public static int XGameStreamingGetClients(ref XGameStreamingClientId[] clients, out uint clientUsed)
	{
		Unity.XGamingRuntime.Interop.XGameStreamingClientId[] array = new Unity.XGamingRuntime.Interop.XGameStreamingClientId[clients.Length];
		int num = NativeMethods.XGameStreamingGetClients((uint)clients.Length, array, out clientUsed);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			clients = new XGameStreamingClientId[clientUsed];
			for (int i = 0; i < clientUsed; i++)
			{
				clients[i] = new XGameStreamingClientId(array[i]);
			}
		}
		return num;
	}

	public static XGameStreamingConnectionState XGameStreamingGetConnectionState(XGameStreamingClientId client)
	{
		return NativeMethods.XGameStreamingGetConnectionState(client.data);
	}

	public static int XGameStreamingRegisterConnectionStateChanged(XTaskQueueHandle queue, IntPtr context, XGameStreamingConnectionStateChangedCallback callback, out XGameStreamingConnectionStateChangedToken token)
	{
		Unity.XGamingRuntime.Interop.XGameStreamingConnectionStateChangedCallback callback2 = (IntPtr _context, Unity.XGamingRuntime.Interop.XGameStreamingClientId _client, XGameStreamingConnectionState _state) =>
		{
			callback(_context, new XGameStreamingClientId(_client), _state);
		};
		token = new XGameStreamingConnectionStateChangedToken(callback2, context);
		ulong token2 = 0uL;
		int num = NativeMethods.XGameStreamingRegisterConnectionStateChanged((queue != null) ? queue.Handle : IntPtr.Zero, token.interop.CallbackContext, token.interop.StaticCallback, out token2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num) && token2 != 0L)
		{
			token.Token = token2;
			return num;
		}
		token.interop.Dispose();
		token = null;
		return num;
	}

	public static bool XGameStreamingUnregisterConnectionStateChanged(XGameStreamingConnectionStateChangedToken token, bool wait)
	{
		return token.Unregister(wait);
	}

	public static void XGameStreamingHideTouchControls()
	{
		NativeMethods.XGameStreamingHideTouchControls();
	}

	public static void XGameStreamingHideTouchControlsOnClient(XGameStreamingClientId client)
	{
		NativeMethods.XGameStreamingHideTouchControlsOnClient(client.data);
	}

	public static void XGameStreamingShowTouchControlLayout(string layout)
	{
		NativeMethods.XGameStreamingShowTouchControlLayout(layout);
	}

	public static void XGameStreamingShowTouchControlLayoutOnClient(XGameStreamingClientId client, string layout)
	{
		NativeMethods.XGameStreamingShowTouchControlLayoutOnClient(client.data, layout);
	}

	public static int XGameStreamingRegisterClientPropertiesChanged(XGameStreamingClientId client, XTaskQueueHandle queue, IntPtr context, XGameStreamingClientPropertiesChangedCallback callback, out XGameStreamingRegisterClientPropertiesChangedToken token)
	{
		Unity.XGamingRuntime.Interop.XGameStreamingClientPropertiesChangedCallback callback2 = (IntPtr _context, Unity.XGamingRuntime.Interop.XGameStreamingClientId _clientId, uint _updatedPropertiesCount, XGameStreamingClientProperty[] _updatedProperties) =>
		{
			callback(_context, new XGameStreamingClientId(_clientId), _updatedProperties);
		};
		token = new XGameStreamingRegisterClientPropertiesChangedToken(client, callback2, context);
		ulong token2 = 0uL;
		int num = NativeMethods.XGameStreamingRegisterClientPropertiesChanged(client.data, queue.Handle, token.interop.CallbackContext, token.interop.StaticCallback, out token2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			token.Token = token2;
			return num;
		}
		token.interop.Dispose();
		token = null;
		return num;
	}

	public static bool XGameStreamingUnregisterClientPropertiesChanged(XGameStreamingClientId client, XGameStreamingRegisterClientPropertiesChangedToken token, bool wait)
	{
		return token.Unregister(client, wait);
	}

	public static int XGameStreamingGetStreamPhysicalDimensions(XGameStreamingClientId client, out uint horizontalMm, out uint verticalMm)
	{
		return NativeMethods.XGameStreamingGetStreamPhysicalDimensions(client.data, out horizontalMm, out verticalMm);
	}

	public static int XGameStreamingGetStreamAddedLatency(XGameStreamingClientId client, out uint averageInputLatencyUs, out uint averageOutputLatencyUs, out uint standardDeviationUs)
	{
		return NativeMethods.XGameStreamingGetStreamAddedLatency(client.data, out averageInputLatencyUs, out averageOutputLatencyUs, out standardDeviationUs);
	}

	public static ulong XGameStreamingGetServerLocationNameSize()
	{
		return NativeMethods.XGameStreamingGetServerLocationNameSize();
	}

	public static int XGameStreamingGetServerLocationName(ulong serverLocalNameSize, out string serverLocationName)
	{
		serverLocationName = null;
		StringBuilder stringBuilder = new StringBuilder((int)serverLocalNameSize);
		int num = NativeMethods.XGameStreamingGetServerLocationName(serverLocalNameSize, stringBuilder);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			serverLocationName = stringBuilder.ToString();
		}
		return num;
	}

	public static int XGameStreamingIsTouchInputEnabled(XGameStreamingClientId client, out bool touchInputEnabled)
	{
		return NativeMethods.XGameStreamingIsTouchInputEnabled(client.data, out touchInputEnabled);
	}

	public static int XGameStreamingGetLastFrameDisplayed(XGameStreamingClientId client, out D3D12XBOX_FRAME_PIPELINE_TOKEN framePipelineToken)
	{
		framePipelineToken = null;
		ulong framePipelineToken2 = 0uL;
		int num = NativeMethods.XGameStreamingGetLastFrameDisplayed(client.data, out framePipelineToken2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			framePipelineToken = new D3D12XBOX_FRAME_PIPELINE_TOKEN(framePipelineToken2);
		}
		return num;
	}

	public static int XGameStreamingUpdateTouchControlsState(XGameStreamingTouchControlsStateOperation[] operations)
	{
		int num = 0;
		if (operations != null)
		{
			List<IntPtr> stringsToFree = new List<IntPtr>();
			try
			{
				num = ProcessTouchControlOperation(ref operations, out var nativeOperations, out stringsToFree);
				if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
				{
					num = NativeMethods.XGameStreamingUpdateTouchControlsState((ulong)operations.Length, nativeOperations);
				}
			}
			finally
			{
				foreach (IntPtr item in stringsToFree)
				{
					Marshal.FreeCoTaskMem(item);
				}
			}
		}
		else
		{
			num = NativeMethods.XGameStreamingUpdateTouchControlsState(0uL, null);
		}
		return num;
	}

	public static int XGameStreamingUpdateTouchControlsStateOnClient(XGameStreamingClientId client, XGameStreamingTouchControlsStateOperation[] operations)
	{
		int num = 0;
		if (operations != null)
		{
			List<IntPtr> stringsToFree = new List<IntPtr>();
			try
			{
				Unity.XGamingRuntime.Interop.XGameStreamingTouchControlsStateOperation[] nativeOperations = null;
				num = ProcessTouchControlOperation(ref operations, out nativeOperations, out stringsToFree);
				if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
				{
					num = NativeMethods.XGameStreamingUpdateTouchControlsStateOnClient(client.data, (ulong)operations.Length, nativeOperations);
				}
			}
			finally
			{
				foreach (IntPtr item in stringsToFree)
				{
					Marshal.FreeCoTaskMem(item);
				}
			}
		}
		else
		{
			num = NativeMethods.XGameStreamingUpdateTouchControlsStateOnClient(client.data, 0uL, null);
		}
		return num;
	}

	public static int XGameStreamingShowTouchControlsWithStateUpdate(string layout, XGameStreamingTouchControlsStateOperation[] operations)
	{
		int num = 0;
		if (operations != null)
		{
			List<IntPtr> stringsToFree = new List<IntPtr>();
			try
			{
				num = ProcessTouchControlOperation(ref operations, out var nativeOperations, out stringsToFree);
				if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
				{
					num = NativeMethods.XGameStreamingShowTouchControlsWithStateUpdate(layout, (ulong)operations.Length, nativeOperations);
				}
			}
			finally
			{
				foreach (IntPtr item in stringsToFree)
				{
					Marshal.FreeCoTaskMem(item);
				}
			}
		}
		else
		{
			num = NativeMethods.XGameStreamingShowTouchControlsWithStateUpdate(layout, 0uL, null);
		}
		return num;
	}

	public static int XGameStreamingShowTouchControlsWithStateUpdateOnClient(XGameStreamingClientId client, string layout, XGameStreamingTouchControlsStateOperation[] operations)
	{
		int num = 0;
		List<IntPtr> stringsToFree = new List<IntPtr>();
		if (operations != null)
		{
			try
			{
				num = ProcessTouchControlOperation(ref operations, out var nativeOperations, out stringsToFree);
				if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
				{
					num = NativeMethods.XGameStreamingShowTouchControlsWithStateUpdateOnClient(client.data, layout, (ulong)operations.Length, nativeOperations);
				}
			}
			finally
			{
				foreach (IntPtr item in stringsToFree)
				{
					Marshal.FreeCoTaskMem(item);
				}
			}
		}
		else
		{
			num = NativeMethods.XGameStreamingShowTouchControlsWithStateUpdateOnClient(client.data, layout, 0uL, null);
		}
		return num;
	}

	public static ulong XGameStreamingGetTouchBundleVersionNameSize(XGameStreamingClientId client)
	{
		return NativeMethods.XGameStreamingGetTouchBundleVersionNameSize(client.data);
	}

	public static int XGameStreamingGetTouchBundleVersion(XGameStreamingClientId client, out XVersion version, ulong versionNameSize, out string versionName)
	{
		versionName = null;
		StringBuilder stringBuilder = new StringBuilder((int)versionNameSize);
		version = null;
		Unity.XGamingRuntime.Interop.XVersion version2 = default;
		int num = NativeMethods.XGameStreamingGetTouchBundleVersion(client.data, out version2, versionNameSize, stringBuilder);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			versionName = stringBuilder.ToString();
			version = new XVersion(version2);
		}
		return num;
	}

	public static int XGameStreamingGetClientIPAddress(XGameStreamingClientId client, out string ipAddress)
	{
		ipAddress = null;
		StringBuilder stringBuilder = new StringBuilder(65);
		int num = NativeMethods.XGameStreamingGetClientIPAddress(client.data, 65uL, stringBuilder);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			ipAddress = stringBuilder.ToString();
		}
		return num;
	}

	public static int XGameStreamingGetSessionId(XGameStreamingClientId client, out string sessionId)
	{
		sessionId = null;
		StringBuilder stringBuilder = new StringBuilder(256);
		ulong sessionIdUsed = 0uL;
		int num = NativeMethods.XGameStreamingGetSessionId(client.data, 256uL, stringBuilder, out sessionIdUsed);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			sessionId = stringBuilder.ToString();
		}
		return num;
	}

	public static int XGameStreamingGetDisplayDetails(XGameStreamingClientId clientId, uint maxSupportedPixels, float widestSupportedAspectRatio, float tallestSupportedAspectRatio, out XGameStreamingDisplayDetails displayDetails)
	{
		displayDetails = null;
		Unity.XGamingRuntime.Interop.XGameStreamingDisplayDetails displayDetails2 = default;
		int num = NativeMethods.XGameStreamingGetDisplayDetails(clientId.data, maxSupportedPixels, widestSupportedAspectRatio, tallestSupportedAspectRatio, out displayDetails2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			displayDetails = new XGameStreamingDisplayDetails(displayDetails2);
		}
		return num;
	}

	public static int XGameStreamingSetResolution(uint width, uint height)
	{
		return NativeMethods.XGameStreamingSetResolution(width, height);
	}

	public static int XGameUiShowMessageDialogAsync(XAsyncBlock async, string titleText, string contextText, string firstButtonText, string secondButtonText, string thirdButtonText, XGameUiMessageDialogButton defaultButton, XGameUiMessageDialogButton cancelButton)
	{
		return NativeMethods.XGameUiShowMessageDialogAsync(async.InteropPtr, titleText, contextText, firstButtonText, secondButtonText, thirdButtonText, defaultButton, cancelButton);
	}

	public static int XGameUiShowMessageDialogResult(XAsyncBlock async, out XGameUiMessageDialogButton resultButton)
	{
		return NativeMethods.XGameUiShowMessageDialogResult(async.InteropPtr, out resultButton);
	}

	public static int XGameUiShowSendGameInviteAsync(XAsyncBlock async, XUserHandle requestingUser, string sessionConfigurationId, string sessionTemplateName, string sessionId, string invitationText, string customActivationContext)
	{
		IntPtr requestingUser2 = ((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero);
		return NativeMethods.XGameUiShowSendGameInviteAsync(async.InteropPtr, requestingUser2, sessionConfigurationId, sessionTemplateName, sessionId, invitationText, customActivationContext);
	}

	public static int XGameUiShowSendGameInviteResult(XAsyncBlock async)
	{
		return NativeMethods.XGameUiShowSendGameInviteResult(async.InteropPtr);
	}

	public static int XGameUiShowMultiplayerActivityGameInviteAsync(XAsyncBlock async, XUserHandle requestingUser)
	{
		IntPtr requestingUser2 = ((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero);
		return NativeMethods.XGameUiShowMultiplayerActivityGameInviteAsync(async.InteropPtr, requestingUser2);
	}

	public static int XGameUiShowMultiplayerActivityGameInviteResult(XAsyncBlock async)
	{
		return NativeMethods.XGameUiShowMultiplayerActivityGameInviteResult(async.InteropPtr);
	}

	public static int XGameUiShowPlayerProfileCardAsync(XAsyncBlock async, XUserHandle requestingUser, ulong targetPlayer)
	{
		IntPtr requestingUser2 = ((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero);
		return NativeMethods.XGameUiShowPlayerProfileCardAsync(async.InteropPtr, requestingUser2, targetPlayer);
	}

	public static int XGameUiShowPlayerProfileCardResult(XAsyncBlock async)
	{
		return NativeMethods.XGameUiShowPlayerProfileCardResult(async.InteropPtr);
	}

	public static int XGameUiShowAchievementsAsync(XAsyncBlock async, XUserHandle requestingUser, uint titleId)
	{
		IntPtr requestingUser2 = ((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero);
		return NativeMethods.XGameUiShowAchievementsAsync(async.InteropPtr, requestingUser2, titleId);
	}

	public static int XGameUiShowAchievementsResult(XAsyncBlock async)
	{
		return NativeMethods.XGameUiShowAchievementsResult(async.InteropPtr);
	}

	public static int XGameUiShowPlayerPickerAsync(XAsyncBlock async, XUserHandle requestingUser, string promptText, ulong[] selectFromPlayers, ulong[] preSelectedPlayers, uint minSelectionCount, uint maxSelectionCount)
	{
		IntPtr requestingUser2 = ((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero);
		uint preSelectedPlayersCount = ((preSelectedPlayers != null) ? ((uint)preSelectedPlayers.Length) : 0u);
		return NativeMethods.XGameUiShowPlayerPickerAsync(async.InteropPtr, requestingUser2, promptText, (uint)selectFromPlayers.Length, selectFromPlayers, preSelectedPlayersCount, preSelectedPlayers, minSelectionCount, maxSelectionCount);
	}

	public static int XGameUiShowWebAuthenticationResult(XAsyncBlock async, byte[] buffer, out XGameUiWebAuthenticationResultData result)
	{
		result = null;
		int num = NativeMethods.XGameUiShowWebAuthenticationResult(async.InteropPtr, (ulong)buffer.Length, buffer, out var ptrToBuffer, out var _);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			result = new XGameUiWebAuthenticationResultData((Unity.XGamingRuntime.Interop.XGameUiWebAuthenticationResultData)Marshal.PtrToStructure(ptrToBuffer, typeof(Unity.XGamingRuntime.Interop.XGameUiWebAuthenticationResultData)));
		}
		return num;
	}

	public static int XGameUiShowPlayerPickerResultCount(XAsyncBlock async, out uint resultPlayersCount)
	{
		return NativeMethods.XGameUiShowPlayerPickerResultCount(async.InteropPtr, out resultPlayersCount);
	}

	public static int XGameUiShowPlayerPickerResult(XAsyncBlock async, ulong[] resultPlayers, out uint resultPlayerUsed)
	{
		return NativeMethods.XGameUiShowPlayerPickerResult(async.InteropPtr, (uint)resultPlayers.Length, resultPlayers, out resultPlayerUsed);
	}

	public static int XGameUiShowErrorDialogAsync(XAsyncBlock async, int errorCode, string context)
	{
		return NativeMethods.XGameUiShowErrorDialogAsync(async.InteropPtr, errorCode, context);
	}

	public static int XGameUiShowErrorDialogResult(XAsyncBlock async)
	{
		return NativeMethods.XGameUiShowErrorDialogResult(async.InteropPtr);
	}

	public static int XGameUiSetNotificationPositionHint(XGameUiNotificationPositionHint position)
	{
		return NativeMethods.XGameUiSetNotificationPositionHint(position);
	}

	public static int XGameUiShowTextEntryAsync(XAsyncBlock async, string titleText, string descriptionText, string defaultText, XGameUiTextEntryInputScope inputScope, uint maxTextLength)
	{
		return NativeMethods.XGameUiShowTextEntryAsync(async.InteropPtr, titleText, descriptionText, defaultText, inputScope, maxTextLength);
	}

	public static int XGameUiShowTextEntryResultSize(XAsyncBlock async, out uint resultTextBufferSize)
	{
		return NativeMethods.XGameUiShowTextEntryResultSize(async.InteropPtr, out resultTextBufferSize);
	}

	public static int XGameUiShowTextEntryResult(XAsyncBlock async, uint resultTextBufferSize, out string resultTextBuffer)
	{
		resultTextBuffer = null;
		StringBuilder stringBuilder = new StringBuilder((int)resultTextBufferSize);
		int num = NativeMethods.XGameUiShowTextEntryResult(async.InteropPtr, resultTextBufferSize, stringBuilder, out var _);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			resultTextBuffer = stringBuilder.ToString();
		}
		return num;
	}

	public static int XGameUiShowWebAuthenticationAsync(XAsyncBlock async, XUserHandle requestingUser, string requestUri, string completeUri)
	{
		IntPtr requestingUser2 = ((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero);
		return NativeMethods.XGameUiShowWebAuthenticationAsync(async.InteropPtr, requestingUser2, requestUri, completeUri);
	}

	public static int XGameUiShowWebAuthenticationWithOptionsAsync(XAsyncBlock async, XUserHandle requestingUser, string requestUri, string completionUri, XGameUiWebAuthenticationOptions options)
	{
		IntPtr requestingUser2 = ((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero);
		return NativeMethods.XGameUiShowWebAuthenticationWithOptionsAsync(async.InteropPtr, requestingUser2, requestUri, completionUri, options);
	}

	public static int XGameUiShowWebAuthenticationResultSize(XAsyncBlock async, out ulong bufferSize)
	{
		return NativeMethods.XGameUiShowWebAuthenticationResultSize(async.InteropPtr, out bufferSize);
	}

	public static void XGameUiTextEntryClose(XGameUiTextEntryHandle handle)
	{
		handle.Close();
	}

	public static int XGameUiTextEntryGetExtents(XGameUiTextEntryHandle handle, out XGameUiTextEntryExtents extents)
	{
		extents = null;
		Unity.XGamingRuntime.Interop.XGameUiTextEntryExtents extents2 = default;
		int num = NativeMethods.XGameUiTextEntryGetExtents(handle.Handle, out extents2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			extents = new XGameUiTextEntryExtents(extents2);
		}
		return num;
	}

	public static int XGameUiTextEntryOpen(XGameUiTextEntryOptions options, uint maxLength, string initialText, uint cursorIndex, out XGameUiTextEntryHandle handle)
	{
		handle = null;
		int num = NativeMethods.XGameUiTextEntryOpen(options.data, maxLength, initialText, cursorIndex, out var handle2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			handle = new XGameUiTextEntryHandle(handle2);
		}
		return num;
	}

	public static int XGameUiTextEntryGetState(XGameUiTextEntryHandle handle, out XGameUiTextEntryChangeTypeFlags changeType, out uint cursorIndex, out uint imeClauseStartIndex, out uint imeClauseEndIndex, uint bufferSize, out string buffer)
	{
		buffer = null;
		StringBuilder stringBuilder = new StringBuilder((int)bufferSize);
		int num = NativeMethods.XGameUiTextEntryGetState(handle.Handle, out changeType, out cursorIndex, out imeClauseStartIndex, out imeClauseEndIndex, bufferSize, stringBuilder);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			buffer = stringBuilder.ToString();
		}
		return num;
	}

	public static int XGameUiTextEntryUpdatePositionHint(XGameUiTextEntryHandle handle, XGameUiTextEntryPositionHint positionHint)
	{
		return NativeMethods.XGameUiTextEntryUpdatePositionHint(handle.Handle, positionHint);
	}

	public static int XGameUiTextEntryUpdateVisibility(XGameUiTextEntryHandle handle, XGameUiTextEntryVisibilityFlags visibilityFlags)
	{
		return NativeMethods.XGameUiTextEntryUpdateVisibility(handle.Handle, visibilityFlags);
	}

	public static int XLaunchUri(XUserHandle requestingUser, string uri)
	{
		return NativeMethods.XLaunchUri((requestingUser != null) ? requestingUser.Handle : IntPtr.Zero, uri);
	}

	public static int XNetworkingGetConnectivityHint(out XNetworkingConnectivityHint getConnectivityHint)
	{
		getConnectivityHint = null;
		int num = NativeMethods.XNetworkingGetConnectivityHint(out var connectivityHint);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			getConnectivityHint = new XNetworkingConnectivityHint(connectivityHint);
		}
		return num;
	}

	public static int XNetworkingQueryConfigurationSetting(XNetworkingConfigurationSetting getConfigurationSetting, out ulong value)
	{
		return NativeMethods.XNetworkingQueryConfigurationSetting(getConfigurationSetting, out value);
	}

	public static int XNetworkingQueryPreferredLocalUdpMultiplayerPort(out ushort value)
	{
		return NativeMethods.XNetworkingQueryPreferredLocalUdpMultiplayerPort(out value);
	}

	public static int XNetworkingQueryPreferredLocalUdpMultiplayerPortAsync(XAsyncBlock async)
	{
		return NativeMethods.XNetworkingQueryPreferredLocalUdpMultiplayerPortAsync(async.InteropPtr);
	}

	public static int XNetworkingQueryPreferredLocalUdpMultiplayerPortAsyncResult(XAsyncBlock async, out ushort preferredLocalUdpMultiplayerPort)
	{
		return NativeMethods.XNetworkingQueryPreferredLocalUdpMultiplayerPortAsyncResult(async.InteropPtr, out preferredLocalUdpMultiplayerPort);
	}

	public static int XNetworkingQuerySecurityInformationForUrlAsync(string url, XAsyncBlock async)
	{
		return NativeMethods.XNetworkingQuerySecurityInformationForUrlAsync(url, async.InteropPtr);
	}

	public static int XNetworkingQuerySecurityInformationForUrlAsyncResultSize(XAsyncBlock async, out ulong securityInformationBufferByteCount)
	{
		return NativeMethods.XNetworkingQuerySecurityInformationForUrlAsyncResultSize(async.InteropPtr, out securityInformationBufferByteCount);
	}

	public static int XNetworkingQuerySecurityInformationForUrlAsyncResult(XAsyncBlock async, byte[] securityInformationBuffer, out ulong securityInformationBufferByteCountUsed, out XNetworkingSecurityInformation securityInformation)
	{
		securityInformation = new XNetworkingSecurityInformation();
		int num = NativeMethods.XNetworkingQuerySecurityInformationForUrlAsyncResult(async.InteropPtr, (ulong)securityInformationBuffer.Length, out securityInformationBufferByteCountUsed, securityInformationBuffer, out var securityInformation2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			MarshalXNetworkingSecurityInformationInteropToManaged(securityInformation2, ref securityInformation);
		}
		return num;
	}

	public static int XNetworkingQuerySecurityInformationForUrlUtf16Async(string url, XAsyncBlock async)
	{
		return NativeMethods.XNetworkingQuerySecurityInformationForUrlUtf16Async(url, async.InteropPtr);
	}

	public static int XNetworkingQuerySecurityInformationForUrlUtf16AsyncResultSize(XAsyncBlock async, out ulong securityInformationBufferByteCount)
	{
		return NativeMethods.XNetworkingQuerySecurityInformationForUrlUtf16AsyncResultSize(async.InteropPtr, out securityInformationBufferByteCount);
	}

	public static int XNetworkingQuerySecurityInformationForUrlUtf16AsyncResult(XAsyncBlock async, byte[] securityInformationBuffer, out ulong securityInformationBufferByteCountUsed, out XNetworkingSecurityInformation securityInformation)
	{
		securityInformation = new XNetworkingSecurityInformation();
		int num = NativeMethods.XNetworkingQuerySecurityInformationForUrlUtf16AsyncResult(async.InteropPtr, (ulong)securityInformationBuffer.Length, out securityInformationBufferByteCountUsed, securityInformationBuffer, out var securityInformation2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			MarshalXNetworkingSecurityInformationInteropToManaged(securityInformation2, ref securityInformation);
		}
		return num;
	}

	public static int XNetworkingQueryStatistics(XNetworkingStatisticsType statisticsType, out XNetworkingStatisticsBuffer statisticsBuffer)
	{
		Unity.XGamingRuntime.Interop.XNetworkingStatisticsBuffer statisticsBuffer2 = default;
		statisticsBuffer = null;
		int num = NativeMethods.XNetworkingQueryStatistics(statisticsType, out statisticsBuffer2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			statisticsBuffer = new XNetworkingStatisticsBuffer(statisticsBuffer2);
		}
		return num;
	}

	public static int XNetworkingRegisterConnectivityHintChanged(XTaskQueueHandle queue, IntPtr context, XNetworkingConnectivityHintChangedCallback callback, out XNetworkingRegisterConnectivityHintChangedCallbackToken token)
	{
		Unity.XGamingRuntime.Interop.XNetworkingConnectivityHintChangedCallback callback2 = (IntPtr context2, Unity.XGamingRuntime.Interop.XNetworkingConnectivityHint connectivityHint) =>
		{
			callback(context2, new XNetworkingConnectivityHint(connectivityHint));
		};
		ulong registrationToken = 0uL;
		IntPtr taskQueueHandle = ((queue != null) ? queue.Handle : IntPtr.Zero);
		token = new XNetworkingRegisterConnectivityHintChangedCallbackToken(callback2, context);
		int num = NativeMethods.XNetworkingRegisterConnectivityHintChanged(taskQueueHandle, token.interop.CallbackContext, token.interop.StaticCallback, out registrationToken);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			token.Token = registrationToken;
			return num;
		}
		token.interop.Dispose();
		token = null;
		return num;
	}

	public static bool XNetworkingUnregisterConnectivityHintChanged(XNetworkingRegisterConnectivityHintChangedCallbackToken token, bool wait)
	{
		return token.Unregister(wait);
	}

	public static int XNetworkingRegisterPreferredLocalUdpMultiplayerPortChanged(XTaskQueueHandle queue, IntPtr context, XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback callback, out XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken token)
	{
		Unity.XGamingRuntime.Interop.XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback callback2 = (IntPtr context2, ushort preferredLocalUdpMultiplayerPort) =>
		{
			callback(context2, preferredLocalUdpMultiplayerPort);
		};
		ulong registrationToken = 0uL;
		token = new XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken(callback2, context);
		int num = NativeMethods.XNetworkingRegisterPreferredLocalUdpMultiplayerPortChanged((queue != null) ? queue.Handle : IntPtr.Zero, token.interop.CallbackContext, token.interop.StaticCallback, out registrationToken);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			token.Token = registrationToken;
			return num;
		}
		token.interop.Dispose();
		token = null;
		return num;
	}

	public static bool XNetworkingUnregisterPreferredLocalUdpMultiplayerPortChanged(XNetworkingPreferredLocalUdpMultiplayerPortChangedCallbackToken token, bool wait)
	{
		return token.Unregister(wait);
	}

	public static int XNetworkingVerifyServerCertificate(IntPtr requestHandle, XNetworkingSecurityInformation securityInformation)
	{
		MarshalXNetworkingSecurityInformationManagedToInterop(securityInformation, out var securityInformationInteropPtr);
		int result = NativeMethods.XNetworkingVerifyServerCertificate(requestHandle, securityInformationInteropPtr);
		if (securityInformationInteropPtr != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(securityInformationInteropPtr);
			securityInformationInteropPtr = IntPtr.Zero;
		}
		return result;
	}

	public static void MarshalXNetworkingSecurityInformationInteropToManaged(IntPtr securityInformationInteropPtr, ref XNetworkingSecurityInformation securityInformation)
	{
		Unity.XGamingRuntime.Interop.XNetworkingSecurityInformation xNetworkingSecurityInformation = (Unity.XGamingRuntime.Interop.XNetworkingSecurityInformation)Marshal.PtrToStructure(securityInformationInteropPtr, typeof(Unity.XGamingRuntime.Interop.XNetworkingSecurityInformation));
		int num = Convert.ToInt32(xNetworkingSecurityInformation.thumbprintCount);
		securityInformation.EnabledHttpSecurityProtocolFlags = xNetworkingSecurityInformation.enabledHttpSecurityProtocolFlags;
		securityInformation.Thumbprints = new XNetworkingThumbprint[num];
		long num2 = xNetworkingSecurityInformation.thumbprints.ToInt64();
		int num3 = Marshal.SizeOf(typeof(Unity.XGamingRuntime.Interop.XNetworkingThumbprint));
		for (int i = 0; i < num; i++)
		{
			Unity.XGamingRuntime.Interop.XNetworkingThumbprint xNetworkingThumbprint = (Unity.XGamingRuntime.Interop.XNetworkingThumbprint)Marshal.PtrToStructure(new IntPtr(num2 + i * num3), typeof(Unity.XGamingRuntime.Interop.XNetworkingThumbprint));
			securityInformation.Thumbprints[i] = new XNetworkingThumbprint();
			securityInformation.Thumbprints[i].ThumbprintType = xNetworkingThumbprint.thumbprintType;
			securityInformation.Thumbprints[i].ThumbprintBuffer = new byte[xNetworkingThumbprint.thumbprintBufferByteCount];
			Marshal.Copy(xNetworkingThumbprint.thumbprintBuffer, securityInformation.Thumbprints[i].ThumbprintBuffer, 0, securityInformation.Thumbprints[i].ThumbprintBuffer.Length);
		}
	}

	public static void MarshalXNetworkingSecurityInformationManagedToInterop(XNetworkingSecurityInformation securityInformation, out IntPtr securityInformationInteropPtr)
	{
		int num = Marshal.SizeOf(typeof(Unity.XGamingRuntime.Interop.XNetworkingSecurityInformation));
		IntPtr intPtr = new IntPtr(num);
		num += Marshal.SizeOf(typeof(Unity.XGamingRuntime.Interop.XNetworkingThumbprint)) * Convert.ToInt32(securityInformation.Thumbprints.Length);
		IntPtr intPtr2 = new IntPtr(num);
		XNetworkingThumbprint[] thumbprints = securityInformation.Thumbprints;
		foreach (XNetworkingThumbprint xNetworkingThumbprint in thumbprints)
		{
			num += Convert.ToInt32(xNetworkingThumbprint.ThumbprintBuffer.Length);
		}
		securityInformationInteropPtr = Marshal.AllocHGlobal(Convert.ToInt32(num));
		IntPtr ptr = securityInformationInteropPtr + intPtr.ToInt32();
		intPtr = securityInformationInteropPtr + intPtr.ToInt32();
		intPtr2 = securityInformationInteropPtr + intPtr2.ToInt32();
		Unity.XGamingRuntime.Interop.XNetworkingThumbprint structure = default;
		for (int j = 0; j < securityInformation.Thumbprints.Length; j++)
		{
			structure.thumbprintType = securityInformation.Thumbprints[j].ThumbprintType;
			structure.thumbprintBufferByteCount = Convert.ToUInt64(securityInformation.Thumbprints[j].ThumbprintBuffer.Length);
			structure.thumbprintBuffer = new IntPtr(intPtr2.ToInt64());
			Marshal.Copy(securityInformation.Thumbprints[j].ThumbprintBuffer, 0, structure.thumbprintBuffer, securityInformation.Thumbprints[j].ThumbprintBuffer.Length);
			Marshal.StructureToPtr(structure, ptr, fDeleteOld: false);
			ptr += Marshal.SizeOf(typeof(Unity.XGamingRuntime.Interop.XNetworkingThumbprint));
			intPtr2 += securityInformation.Thumbprints[j].ThumbprintBuffer.Length;
		}
		Marshal.StructureToPtr(new Unity.XGamingRuntime.Interop.XNetworkingSecurityInformation
		{
			enabledHttpSecurityProtocolFlags = securityInformation.EnabledHttpSecurityProtocolFlags,
			thumbprintCount = Convert.ToUInt64(securityInformation.Thumbprints.Length),
			thumbprints = new IntPtr(intPtr.ToInt64())
		}, securityInformationInteropPtr, fDeleteOld: false);
	}

	private static int ProcessChunkSelector(XPackageChunkSelector[] selectors, ref XPackageChunkSelectorInterop[] nativeSelectors, out List<IntPtr> stringsToFree)
	{
		stringsToFree = new List<IntPtr>();
		for (int i = 0; i < selectors.Length; i++)
		{
			XPackageChunkSelector xPackageChunkSelector = selectors[i];
			nativeSelectors[i].type = xPackageChunkSelector.Type;
			switch (xPackageChunkSelector.Type)
			{
			case XPackageChunkSelectorType.Chunk:
				nativeSelectors[i].chunkId = xPackageChunkSelector.ChunkId;
				break;
			case XPackageChunkSelectorType.Language:
			case XPackageChunkSelectorType.Tag:
			case XPackageChunkSelectorType.Feature:
				nativeSelectors[i].languageOrTagOrFeature = InteropHelpers.MarshalStringUtf8(xPackageChunkSelector.LanguageTagOrFeature);
				stringsToFree.Add(nativeSelectors[i].languageOrTagOrFeature);
				break;
			default:
				return -2147024809;
			}
		}
		return 0;
	}

	public static int XPackageCreateInstallationMonitor(string packageIdentifier, XPackageChunkSelector[] selectors, uint minimumUpdateIntervalMs, XTaskQueueHandle queue, out XPackageInstallationMonitorHandle installationMonitor)
	{
		int num = 0;
		installationMonitor = null;
		IntPtr queue2 = ((queue != null) ? queue.Handle : IntPtr.Zero);
		if (selectors != null)
		{
			XPackageChunkSelectorInterop[] nativeSelectors = new XPackageChunkSelectorInterop[selectors.Length];
			List<IntPtr> stringsToFree = new List<IntPtr>();
			try
			{
				num = ProcessChunkSelector(selectors, ref nativeSelectors, out stringsToFree);
				if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
				{
					num = NativeMethods.XPackageCreateInstallationMonitor(packageIdentifier, (uint)nativeSelectors.Length, nativeSelectors, minimumUpdateIntervalMs, queue2, out var installationMonitor2);
					if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
					{
						installationMonitor = new XPackageInstallationMonitorHandle(installationMonitor2);
					}
				}
			}
			finally
			{
				foreach (IntPtr item in stringsToFree)
				{
					Marshal.FreeCoTaskMem(item);
				}
			}
		}
		else
		{
			num = NativeMethods.XPackageCreateInstallationMonitor(packageIdentifier, 0u, null, minimumUpdateIntervalMs, queue2, out var installationMonitor3);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				installationMonitor = new XPackageInstallationMonitorHandle(installationMonitor3);
			}
		}
		return num;
	}

	public static void XPackageCloseInstallationMonitorHandle(XPackageInstallationMonitorHandle installationMonitor)
	{
		installationMonitor.Close();
	}

	public static int XPackageGetCurrentProcessPackageIdentifier(out string buffer)
	{
		buffer = null;
		StringBuilder stringBuilder = new StringBuilder(XPACKAGE_IDENTIFIER_MAX_LENGTH);
		int num = NativeMethods.XPackageGetCurrentProcessPackageIdentifier((ulong)XPACKAGE_IDENTIFIER_MAX_LENGTH, stringBuilder);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			buffer = stringBuilder.ToString();
		}
		return num;
	}

	public static bool XPackageIsPackagedProcess()
	{
		return NativeMethods.XPackageIsPackagedProcess();
	}

	public static void XPackageGetInstallationProgress(XPackageInstallationMonitorHandle installationMonitor, out XPackageInstallationProgress progress)
	{
		NativeMethods.XPackageGetInstallationProgress(installationMonitor.Handle, out var progress2);
		progress = new XPackageInstallationProgress(progress2);
	}

	public static void XPackageUpdateInstallationMonitor(XPackageInstallationMonitorHandle installationMonitor)
	{
		NativeMethods.XPackageUpdateInstallationMonitor(installationMonitor.Handle);
	}

	public static int XPackageGetUserLocale(out string locale)
	{
		locale = null;
		StringBuilder stringBuilder = new StringBuilder(LOCALE_NAME_MAX_LENGTH);
		int num = NativeMethods.XPackageGetUserLocale((ulong)LOCALE_NAME_MAX_LENGTH, stringBuilder);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			locale = stringBuilder.ToString();
		}
		return num;
	}

	public static int XPackageFindChunkAvailability(string packageIdentifier, XPackageChunkSelector[] selectors, out XPackageChunkAvailability availability)
	{
		availability = XPackageChunkAvailability.Ready;
		int num = 0;
		if (selectors != null)
		{
			List<IntPtr> stringsToFree = new List<IntPtr>();
			try
			{
				XPackageChunkSelectorInterop[] nativeSelectors = new XPackageChunkSelectorInterop[selectors.Length];
				num = ProcessChunkSelector(selectors, ref nativeSelectors, out stringsToFree);
				if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
				{
					num = NativeMethods.XPackageFindChunkAvailability(packageIdentifier, (uint)nativeSelectors.Length, nativeSelectors, out availability);
				}
			}
			finally
			{
				foreach (IntPtr item in stringsToFree)
				{
					Marshal.FreeCoTaskMem(item);
				}
			}
		}
		else
		{
			num = NativeMethods.XPackageFindChunkAvailability(packageIdentifier, 0u, null, out availability);
		}
		return num;
	}

	public static int XPackageChangeChunkInstallOrder(string packageIdentifier, XPackageChunkSelector[] selectors)
	{
		int num = 0;
		List<IntPtr> stringsToFree = new List<IntPtr>();
		try
		{
			XPackageChunkSelectorInterop[] nativeSelectors = new XPackageChunkSelectorInterop[selectors.Length];
			num = ProcessChunkSelector(selectors, ref nativeSelectors, out stringsToFree);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				num = NativeMethods.XPackageChangeChunkInstallOrder(packageIdentifier, (uint)nativeSelectors.Length, nativeSelectors);
			}
		}
		finally
		{
			foreach (IntPtr item in stringsToFree)
			{
				Marshal.FreeCoTaskMem(item);
			}
		}
		return num;
	}

	public static int XPackageInstallChunks(string packageIdentifier, XPackageChunkSelector[] selectors, uint minimumUpdateIntervalMs, bool suppressUserConfirmation, XTaskQueueHandle queue, out XPackageInstallationMonitorHandle installationMonitor)
	{
		List<IntPtr> stringsToFree = new List<IntPtr>();
		int num = 0;
		try
		{
			installationMonitor = null;
			XPackageChunkSelectorInterop[] nativeSelectors = new XPackageChunkSelectorInterop[selectors.Length];
			num = ProcessChunkSelector(selectors, ref nativeSelectors, out stringsToFree);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				IntPtr queue2 = ((queue != null) ? queue.Handle : IntPtr.Zero);
				num = NativeMethods.XPackageInstallChunks(packageIdentifier, (uint)nativeSelectors.Length, nativeSelectors, minimumUpdateIntervalMs, suppressUserConfirmation, queue2, out var installationMonitor2);
				if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
				{
					installationMonitor = new XPackageInstallationMonitorHandle(installationMonitor2);
				}
			}
		}
		finally
		{
			foreach (IntPtr item in stringsToFree)
			{
				Marshal.FreeCoTaskMem(item);
			}
		}
		return num;
	}

	public static int XPackageInstallChunksAsync(string packageIdentifier, XPackageChunkSelector[] selectors, uint minimumUpdateIntervalMs, bool suppressUserConfirmation, XAsyncBlock async)
	{
		XPackageChunkSelectorInterop[] nativeSelectors = new XPackageChunkSelectorInterop[selectors.Length];
		int num = 0;
		List<IntPtr> stringsToFree = new List<IntPtr>();
		try
		{
			num = ProcessChunkSelector(selectors, ref nativeSelectors, out stringsToFree);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				num = NativeMethods.XPackageInstallChunksAsync(packageIdentifier, (uint)nativeSelectors.Length, nativeSelectors, minimumUpdateIntervalMs, suppressUserConfirmation, async.InteropPtr);
			}
		}
		finally
		{
			foreach (IntPtr item in stringsToFree)
			{
				Marshal.FreeCoTaskMem(item);
			}
		}
		return num;
	}

	public static int XPackageInstallChunksResult(XAsyncBlock asyncBlock, out XPackageInstallationMonitorHandle installationMonitor)
	{
		installationMonitor = null;
		int num = NativeMethods.XPackageInstallChunksResult(asyncBlock.InteropPtr, out var installationMonitor2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			installationMonitor = new XPackageInstallationMonitorHandle(installationMonitor2);
		}
		return num;
	}

	public static int XPackageEstimateDownloadSize(string packageIdentifier, XPackageChunkSelector[] selectors, out ulong downloadSize, out bool shouldPresentUserConfirmation)
	{
		downloadSize = 0uL;
		shouldPresentUserConfirmation = false;
		int num = 0;
		List<IntPtr> stringsToFree = new List<IntPtr>();
		try
		{
			XPackageChunkSelectorInterop[] nativeSelectors = new XPackageChunkSelectorInterop[selectors.Length];
			num = ProcessChunkSelector(selectors, ref nativeSelectors, out stringsToFree);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				num = NativeMethods.XPackageEstimateDownloadSize(packageIdentifier, (uint)nativeSelectors.Length, nativeSelectors, out downloadSize, out shouldPresentUserConfirmation);
			}
		}
		finally
		{
			foreach (IntPtr item in stringsToFree)
			{
				Marshal.FreeCoTaskMem(item);
			}
		}
		return num;
	}

	public static int XPackageUninstallChunks(string packageIdentifier, XPackageChunkSelector[] selectors)
	{
		XPackageChunkSelectorInterop[] nativeSelectors = new XPackageChunkSelectorInterop[selectors.Length];
		int num = 0;
		List<IntPtr> stringsToFree = new List<IntPtr>();
		try
		{
			num = ProcessChunkSelector(selectors, ref nativeSelectors, out stringsToFree);
			if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
			{
				num = NativeMethods.XPackageUninstallChunks(packageIdentifier, (uint)nativeSelectors.Length, nativeSelectors);
			}
		}
		finally
		{
			foreach (IntPtr item in stringsToFree)
			{
				Marshal.FreeCoTaskMem(item);
			}
		}
		return num;
	}

	public static void XPackageCloseMountHandle(XPackageMountHandle mount)
	{
		mount.Close();
	}

	[AOT.MonoPInvokeCallback(typeof(Unity.XGamingRuntime.Interop.XPackageChunkAvailabilityCallback))]
	private static bool OnPackageChunkAvailability(IntPtr context, XPackageChunkSelectorInterop selector, XPackageChunkAvailability availability)
	{
		CallbackWrapper<Unity.XGamingRuntime.Interop.XPackageChunkAvailabilityCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<Unity.XGamingRuntime.Interop.XPackageChunkAvailabilityCallback>;
		return callbackWrapper.Callback(callbackWrapper.Context, selector, availability);
	}

	public static int XPackageEnumerateChunkAvailability(string packageIdentifier, XPackageChunkSelectorType type, IntPtr context, XPackageChunkAvailabilityCallback callback)
	{
		using CallbackWrapper<Unity.XGamingRuntime.Interop.XPackageChunkAvailabilityCallback> callbackWrapper = new CallbackWrapper<Unity.XGamingRuntime.Interop.XPackageChunkAvailabilityCallback>((IntPtr _context, XPackageChunkSelectorInterop _selector, XPackageChunkAvailability _availability) => callback(_context, new XPackageChunkSelector(_selector), _availability), context, OnPackageChunkAvailability);
		return NativeMethods.XPackageEnumerateChunkAvailability(packageIdentifier, type, callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
	}

	[AOT.MonoPInvokeCallback(typeof(XPackageFeatureEnumerationCallbackInterop))]
	private static bool OnXPackageFeature(IntPtr context, Unity.XGamingRuntime.Interop.XPackageFeature feature)
	{
		CallbackWrapper<XPackageFeatureEnumerationCallbackInterop> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XPackageFeatureEnumerationCallbackInterop>;
		return callbackWrapper.Callback(callbackWrapper.Context, feature);
	}

	public static int XPackageEnumerateFeatures(string packageIdentifier, IntPtr context, XPackageFeatureEnumerationCallback callback)
	{
		using CallbackWrapper<XPackageFeatureEnumerationCallbackInterop> callbackWrapper = new CallbackWrapper<XPackageFeatureEnumerationCallbackInterop>((IntPtr _context, Unity.XGamingRuntime.Interop.XPackageFeature _featureInterop) =>
		{
			XPackageFeature feature = new XPackageFeature(_featureInterop);
			return callback(_context, feature);
		}, context, OnXPackageFeature);
		return NativeMethods.XPackageEnumerateFeatures(packageIdentifier, callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
	}

	[AOT.MonoPInvokeCallback(typeof(Unity.XGamingRuntime.Interop.XPackageEnumerationCallback))]
	private static bool OnPackageEnumeration(IntPtr context, Unity.XGamingRuntime.Interop.XPackageDetails details)
	{
		CallbackWrapper<Unity.XGamingRuntime.Interop.XPackageEnumerationCallback> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<Unity.XGamingRuntime.Interop.XPackageEnumerationCallback>;
		return callbackWrapper.Callback(callbackWrapper.Context, details);
	}

	public static int XPackageEnumeratePackages(XPackageKind kind, XPackageEnumerationScope scope, IntPtr context, XPackageEnumerationCallback callback)
	{
		using CallbackWrapper<Unity.XGamingRuntime.Interop.XPackageEnumerationCallback> callbackWrapper = new CallbackWrapper<Unity.XGamingRuntime.Interop.XPackageEnumerationCallback>((IntPtr _context, Unity.XGamingRuntime.Interop.XPackageDetails _details) =>
		{
			XPackageDetails details = new XPackageDetails(_details);
			return callback(_context, details);
		}, context, OnPackageEnumeration);
		return NativeMethods.XPackageEnumeratePackages(kind, scope, callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
	}

	public static int XPackageGetMountPathSize(XPackageMountHandle mount, out ulong pathSize)
	{
		return NativeMethods.XPackageGetMountPathSize(mount.Handle, out pathSize);
	}

	public static int XPackageGetMountPath(XPackageMountHandle mount, ulong pathSize, out string path)
	{
		path = null;
		StringBuilder stringBuilder = new StringBuilder((int)pathSize);
		int num = NativeMethods.XPackageGetMountPath(mount.Handle, pathSize, stringBuilder);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			path = stringBuilder.ToString();
		}
		return num;
	}

	public static int XPackageGetWriteStats(out XPackageWriteStats writeStats)
	{
		writeStats = null;
		Unity.XGamingRuntime.Interop.XPackageWriteStats writeStats2 = default;
		int num = NativeMethods.XPackageGetWriteStats(out writeStats2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			writeStats = new XPackageWriteStats(writeStats2);
		}
		return num;
	}

	public static int XPackageMountWithUiAsync(string packageIdentifier, XAsyncBlock asyncBlock)
	{
		return NativeMethods.XPackageMountWithUiAsync(packageIdentifier, asyncBlock.InteropPtr);
	}

	public static int XPackageMountWithUiResult(XAsyncBlock async, out XPackageMountHandle mount)
	{
		mount = null;
		int num = NativeMethods.XPackageMountWithUiResult(async.InteropPtr, out var mount2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			mount = new XPackageMountHandle(mount2);
		}
		return num;
	}

	public static int XPackageRegisterInstallationProgressChanged(XPackageInstallationMonitorHandle installationMonitorHandle, IntPtr context, XPackageInstallationProgressCallback callback, out XPackageRegisterInstallationProgressChangedToken token)
	{
		Unity.XGamingRuntime.Interop.XPackageInstallationProgressCallback callback2 = (IntPtr _context, IntPtr _monitor) =>
		{
			callback(_context, installationMonitorHandle);
		};
		token = new XPackageRegisterInstallationProgressChangedToken(installationMonitorHandle, callback2, context);
		int num = NativeMethods.XPackageRegisterInstallationProgressChanged(installationMonitorHandle.Handle, token.interop.CallbackContext, token.interop.StaticCallback, out var token2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			token.Token = token2;
			return num;
		}
		token.Dispose();
		token = null;
		return num;
	}

	public static int XPackageRegisterPackageInstalled(XTaskQueueHandle queue, IntPtr context, XPackageInstalledCallback callback, out XPackageRegisterPackageInstalledToken token)
	{
		Unity.XGamingRuntime.Interop.XPackageInstalledCallback callback2 = (IntPtr _context, Unity.XGamingRuntime.Interop.XPackageDetails _details) =>
		{
			callback(_context, new XPackageDetails(_details));
		};
		token = new XPackageRegisterPackageInstalledToken(callback2, context);
		int num = NativeMethods.XPackageRegisterPackageInstalled(queue.Handle, token.interop.CallbackContext, token.interop.StaticCallback, out var token2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			token.Token = token2;
			return num;
		}
		token.Dispose();
		token = null;
		return num;
	}

	public static int XPackageUninstallUWPInstance(string packageName)
	{
		return NativeMethods.XPackageUninstallUWPInstance(packageName);
	}

	public static bool XPackageUninstallPackage(string packageIdentifier)
	{
		return NativeMethods.XPackageUninstallPackage(packageIdentifier);
	}

	public static bool XPackageUnregisterInstallationProgressChanged(XPackageInstallationMonitorHandle installationMonitor, XPackageRegisterInstallationProgressChangedToken token, bool wait)
	{
		return token.Unregister(installationMonitor, wait);
	}

	public static bool XPackageUnregisterInstallationProgressChanged(XPackageInstallationMonitorHandle installationMonitor, XPackageRegisterInstallationProgressChangedToken token)
	{
		return XPackageUnregisterInstallationProgressChanged(installationMonitor, token, wait: true);
	}

	public static bool XPackageUnregisterPackageInstalled(XPackageRegisterPackageInstalledToken token)
	{
		return XPackageUnregisterPackageInstalled(token, wait: true);
	}

	public static bool XPackageUnregisterPackageInstalled(XPackageRegisterPackageInstalledToken token, bool wait)
	{
		return token.Unregister(wait);
	}

	public static int XPersistentLocalStorageGetPathSize(out ulong pathSize)
	{
		return NativeMethods.XPersistentLocalStorageGetPathSize(out pathSize);
	}

	public static int XPersistentLocalStorageGetPath(ulong pathSize, out string path)
	{
		path = null;
		ulong pathUsed = 0uL;
		byte[] array = new byte[pathSize];
		int num = NativeMethods.XPersistentLocalStorageGetPath(pathSize, array, out pathUsed);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			path = Encoding.UTF8.GetString(array, 0, (int)pathUsed).TrimEnd('\0');
		}
		return num;
	}

	public static int XPersistentLocalStorageGetSpaceInfo(out XPersistentLocalStorageSpaceInfo spaceInfo)
	{
		spaceInfo = null;
		Unity.XGamingRuntime.Interop.XPersistentLocalStorageSpaceInfo spaceInfo2 = default;
		int num = NativeMethods.XPersistentLocalStorageGetSpaceInfo(out spaceInfo2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			spaceInfo = new XPersistentLocalStorageSpaceInfo(spaceInfo2);
		}
		return num;
	}

	public static int XPersistentLocalStoragePromptUserForSpaceAsync(ulong requestedBytes, XAsyncBlock asyncBlock)
	{
		return NativeMethods.XPersistentLocalStoragePromptUserForSpaceAsync(requestedBytes, asyncBlock.InteropPtr);
	}

	public static int XPersistentLocalStoragePromptUserForSpaceResult(XAsyncBlock asyncBlock)
	{
		return NativeMethods.XPersistentLocalStoragePromptUserForSpaceResult(asyncBlock.InteropPtr);
	}

	[AOT.MonoPInvokeCallback(typeof(Unity.XGamingRuntime.Interop.XSpeechSynthesizerInstalledVoicesCallback))]
	private static bool OnSpeechSynthesizerInstalledVoicesCallback(ref Unity.XGamingRuntime.Interop.XSpeechSynthesizerVoiceInformation information, IntPtr context)
	{
		return (GCHandle.FromIntPtr(context).Target as CallbackWrapper<Unity.XGamingRuntime.Interop.XSpeechSynthesizerInstalledVoicesCallback>).Callback(ref information, context);
	}

	public static int XSpeechSynthesizerEnumerateInstalledVoices(IntPtr context, XSpeechSynthesizerInstalledVoicesCallback callback)
	{
		using CallbackWrapper<Unity.XGamingRuntime.Interop.XSpeechSynthesizerInstalledVoicesCallback> callbackWrapper = new CallbackWrapper<Unity.XGamingRuntime.Interop.XSpeechSynthesizerInstalledVoicesCallback>(delegate(ref Unity.XGamingRuntime.Interop.XSpeechSynthesizerVoiceInformation _information, IntPtr _context)
		{
			XSpeechSynthesizerVoiceInformation information = new XSpeechSynthesizerVoiceInformation(_information);
			return callback(ref information, _context);
		}, context, OnSpeechSynthesizerInstalledVoicesCallback);
		return NativeMethods.XSpeechSynthesizerEnumerateInstalledVoices(callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
	}

	public static int XSpeechSynthesizerCreate(out XSpeechSynthesizerHandle speechSynthesizer)
	{
		speechSynthesizer = null;
		int num = NativeMethods.XSpeechSynthesizerCreate(out var speechSynthesizer2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			speechSynthesizer = new XSpeechSynthesizerHandle(speechSynthesizer2);
		}
		return num;
	}

	public static int XSpeechSynthesizerCloseHandle(XSpeechSynthesizerHandle speechSynthesizer)
	{
		speechSynthesizer.Close();
		return speechSynthesizer.CloseResult;
	}

	public static int XSpeechSynthesizerSetDefaultVoice(XSpeechSynthesizerHandle speechSynthesizer)
	{
		return NativeMethods.XSpeechSynthesizerSetDefaultVoice(speechSynthesizer.Handle);
	}

	public static int XSpeechSynthesizerSetCustomVoice(XSpeechSynthesizerHandle speechSynthesizer, string voiceId)
	{
		return NativeMethods.XSpeechSynthesizerSetCustomVoice(speechSynthesizer.Handle, voiceId);
	}

	public static int XSpeechSynthesizerCreateStreamFromText(XSpeechSynthesizerHandle speechSynthesizer, string text, out XSpeechSynthesizerStreamHandle speechSynthesisStream)
	{
		speechSynthesisStream = null;
		int num = NativeMethods.XSpeechSynthesizerCreateStreamFromText(speechSynthesizer.Handle, text, out var speechSynthesisStream2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			speechSynthesisStream = new XSpeechSynthesizerStreamHandle(speechSynthesisStream2);
		}
		return num;
	}

	public static int XSpeechSynthesizerCreateStreamFromSsml(XSpeechSynthesizerHandle speechSynthesizer, string ssml, out XSpeechSynthesizerStreamHandle speechSynthesisStream)
	{
		speechSynthesisStream = null;
		int num = NativeMethods.XSpeechSynthesizerCreateStreamFromSsml(speechSynthesizer.Handle, ssml, out var speechSynthesisStream2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			speechSynthesisStream = new XSpeechSynthesizerStreamHandle(speechSynthesisStream2);
		}
		return num;
	}

	public static int XSpeechSynthesizerCloseStreamHandle(XSpeechSynthesizerStreamHandle speechSynthesisStream)
	{
		speechSynthesisStream.Close();
		return speechSynthesisStream.CloseResult;
	}

	public static int XSpeechSynthesizerGetStreamDataSize(XSpeechSynthesizerStreamHandle speechSynthesisStream, out ulong bufferSize)
	{
		return NativeMethods.XSpeechSynthesizerGetStreamDataSize(speechSynthesisStream.Handle, out bufferSize);
	}

	public static int XSpeechSynthesizerGetStreamData(XSpeechSynthesizerStreamHandle speechSynthesisStream, byte[] buffer, out ulong bufferUsed)
	{
		return NativeMethods.XSpeechSynthesizerGetStreamData(speechSynthesisStream.Handle, (ulong)buffer.Length, buffer, out bufferUsed);
	}

	public static int XStoreCreateContext(XUserHandle user, out XStoreContext storeContext)
	{
		storeContext = null;
		IntPtr user2 = ((user != null) ? user.Handle : IntPtr.Zero);
		IntPtr storeContextHandle = IntPtr.Zero;
		int num = NativeMethods.XStoreCreateContext(user2, out storeContextHandle);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			storeContext = new XStoreContext(storeContextHandle);
		}
		return num;
	}

	public static int XStoreCreateContext(out XStoreContext storeContext)
	{
		return XStoreCreateContext(null, out storeContext);
	}

	public static void XStoreCloseContextHandle(XStoreContext storeContext)
	{
		storeContext.Close();
	}

	public static void XStoreCloseLicenseHandle(XStoreLicense storeLicense)
	{
		storeLicense.Close();
	}

	public static int XStoreAcquireLicenseForDurablesAsync(XStoreContext context, string storeId, XAsyncBlock async)
	{
		return NativeMethods.XStoreAcquireLicenseForDurablesAsync(context.Handle, storeId, async.InteropPtr);
	}

	public static int XStoreAcquireLicenseForDurablesResult(XAsyncBlock async, out XStoreLicense storeLicense)
	{
		storeLicense = null;
		int num = NativeMethods.XStoreAcquireLicenseForDurablesResult(async.InteropPtr, out var storeLicenseHandle);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			storeLicense = new XStoreLicense(storeLicenseHandle);
		}
		return num;
	}

	public static int XStoreAcquireLicenseForPackageAsync(XStoreContext context, string packageIdentifier, XAsyncBlock async)
	{
		return NativeMethods.XStoreAcquireLicenseForPackageAsync(context.Handle, packageIdentifier, async.InteropPtr);
	}

	public static int XStoreAcquireLicenseForPackageResult(XAsyncBlock async, out XStoreLicense storeLicenseHandle)
	{
		storeLicenseHandle = null;
		int num = NativeMethods.XStoreAcquireLicenseForPackageResult(async.InteropPtr, out var storeLicenseHandle2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			storeLicenseHandle = new XStoreLicense(storeLicenseHandle2);
		}
		return num;
	}

	public static int XStoreCanAcquireLicenseForStoreIdAsync(XStoreContext storeContext, string storeProductId, XAsyncBlock async)
	{
		return NativeMethods.XStoreCanAcquireLicenseForStoreIdAsync(storeContext.Handle, storeProductId, async.InteropPtr);
	}

	public static int XStoreCanAcquireLicenseForStoreIdResult(XAsyncBlock async, out XStoreCanAcquireLicenseResult storeCanAcquireLicenseResult)
	{
		storeCanAcquireLicenseResult = null;
		int num = NativeMethods.XStoreCanAcquireLicenseForStoreIdResult(async.InteropPtr, out var storeCanAcquireLicenseResult2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			storeCanAcquireLicenseResult = new XStoreCanAcquireLicenseResult(storeCanAcquireLicenseResult2);
		}
		return num;
	}

	public static int XStoreCanAcquireLicenseForPackageAsync(XStoreContext storeContext, string packageIdentifier, XAsyncBlock async)
	{
		return NativeMethods.XStoreCanAcquireLicenseForPackageAsync(storeContext.Handle, packageIdentifier, async.InteropPtr);
	}

	public static int XStoreCanAcquireLicenseForPackageResult(XAsyncBlock async, out XStoreCanAcquireLicenseResult storeCanAcquireLicenseResult)
	{
		storeCanAcquireLicenseResult = null;
		int num = NativeMethods.XStoreCanAcquireLicenseForPackageResult(async.InteropPtr, out var storeCanAcquireLicenseResult2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			storeCanAcquireLicenseResult = new XStoreCanAcquireLicenseResult(storeCanAcquireLicenseResult2);
		}
		return num;
	}

	public static int XStoreQueryProductForCurrentGameAsync(XStoreContext storeContext, XAsyncBlock async)
	{
		return NativeMethods.XStoreQueryProductForCurrentGameAsync(storeContext.Handle, async.InteropPtr);
	}

	public static int XStoreQueryProductForCurrentGameResult(XAsyncBlock async, out XStoreProductQuery productQueryHandle)
	{
		productQueryHandle = null;
		int num = NativeMethods.XStoreQueryProductForCurrentGameResult(async.InteropPtr, out var productQueryHandle2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			productQueryHandle = new XStoreProductQuery(productQueryHandle2);
		}
		return num;
	}

	[AOT.MonoPInvokeCallback(typeof(XStoreProductQueryCallbackInterop))]
	private static bool OnProductQueryCallback([In] ref XStoreProductInterop product, IntPtr context)
	{
		CallbackWrapper<XStoreProductQueryCallbackInterop> callbackWrapper = GCHandle.FromIntPtr(context).Target as CallbackWrapper<XStoreProductQueryCallbackInterop>;
		return callbackWrapper.Callback(ref product, callbackWrapper.Context);
	}

	public static int XStoreEnumerateProductsQuery(XStoreProductQuery productQueryHandle, IntPtr context, XStoreProductQueryCallback callback)
	{
		using CallbackWrapper<XStoreProductQueryCallbackInterop> callbackWrapper = new CallbackWrapper<XStoreProductQueryCallbackInterop>(delegate(ref XStoreProductInterop product, IntPtr context2)
		{
			return callback(new XStoreProduct(ref product), context2);
		}, context, OnProductQueryCallback);
		return NativeMethods.XStoreEnumerateProductsQuery(productQueryHandle.Handle, callbackWrapper.CallbackContext, callbackWrapper.StaticCallback);
	}

	public static void XStoreCloseProductsQueryHandle(XStoreProductQuery productQueryHandle)
	{
		productQueryHandle.Close();
	}

	public static int XStoreDownloadPackageUpdatesAsync(XStoreContext storeContext, string[] packageIdentifiers, XAsyncBlock async)
	{
		return NativeMethods.XStoreDownloadPackageUpdatesAsync(storeContext.Handle, packageIdentifiers, (ulong)packageIdentifiers.Length, async.InteropPtr);
	}

	public static int XStoreDownloadPackageUpdatesResult(XAsyncBlock async)
	{
		return NativeMethods.XStoreDownloadPackageUpdatesResult(async.InteropPtr);
	}

	public static int XStoreDownloadAndInstallPackageUpdatesAsync(XStoreContext storeContext, string[] packageIdentifiers, XAsyncBlock async)
	{
		return NativeMethods.XStoreDownloadAndInstallPackageUpdatesAsync(storeContext.Handle, packageIdentifiers, (ulong)packageIdentifiers.Length, async.InteropPtr);
	}

	public static int XStoreDownloadAndInstallPackageUpdatesResult(XAsyncBlock async)
	{
		return NativeMethods.XStoreDownloadAndInstallPackageUpdatesResult(async.InteropPtr);
	}

	public static int XStoreDownloadAndInstallPackagesAsync(XStoreContext storeContext, string[] storeIds, XAsyncBlock async)
	{
		return NativeMethods.XStoreDownloadAndInstallPackagesAsync(storeContext.Handle, storeIds, (ulong)storeIds.Length, async.InteropPtr);
	}

	public static int XStoreDownloadAndInstallPackagesResultCount(XAsyncBlock async, out uint count)
	{
		return NativeMethods.XStoreDownloadAndInstallPackagesResultCount(async.InteropPtr, out count);
	}

	public static int XStoreDownloadAndInstallPackagesResult(XAsyncBlock async, uint count, out string[] packageIdentifiers)
	{
		packageIdentifiers = null;
		XStorePackageIdentifierInterop[] array = new XStorePackageIdentifierInterop[count];
		int num = NativeMethods.XStoreDownloadAndInstallPackagesResult(async.InteropPtr, count, array);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			packageIdentifiers = new string[count];
			for (uint num2 = 0u; num2 < count; num2++)
			{
				packageIdentifiers[num2] = array[num2].Data;
			}
		}
		return num;
	}

	public static int XStoreGetUserCollectionsIdAsync(XStoreContext storeContext, string serviceTicket, string publisherUserId, XAsyncBlock async)
	{
		return NativeMethods.XStoreGetUserCollectionsIdAsync(storeContext.Handle, serviceTicket, publisherUserId, async.InteropPtr);
	}

	public static int XStoreGetUserCollectionsIdResultSize(XAsyncBlock async, out ulong size)
	{
		return NativeMethods.XStoreGetUserCollectionsIdResultSize(async.InteropPtr, out size);
	}

	public static int XStoreGetUserCollectionsIdResult(XAsyncBlock async, ulong size, out string result)
	{
		result = null;
		StringBuilder stringBuilder = new StringBuilder((int)size);
		int num = NativeMethods.XStoreGetUserCollectionsIdResult(async.InteropPtr, size, stringBuilder);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			result = stringBuilder.ToString();
		}
		return num;
	}

	public static int XStoreGetUserPurchaseIdAsync(XStoreContext storeContext, string serviceTicket, string publisherUserId, XAsyncBlock async)
	{
		return NativeMethods.XStoreGetUserPurchaseIdAsync(storeContext.Handle, serviceTicket, publisherUserId, async.InteropPtr);
	}

	public static int XStoreGetUserPurchaseIdResultSize(XAsyncBlock async, out ulong size)
	{
		return NativeMethods.XStoreGetUserPurchaseIdResultSize(async.InteropPtr, out size);
	}

	public static int XStoreGetUserPurchaseIdResult(XAsyncBlock async, ulong size, out string result)
	{
		result = null;
		StringBuilder stringBuilder = new StringBuilder((int)size);
		int num = NativeMethods.XStoreGetUserPurchaseIdResult(async.InteropPtr, size, stringBuilder);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			result = stringBuilder.ToString();
		}
		return num;
	}

	public static bool XStoreIsAvailabilityPurchasable(XStoreAvailability availability)
	{
		return NativeMethods.XStoreIsAvailabilityPurchasable(availability.interop);
	}

	public static bool XStoreIsLicenseValid(XStoreLicense license)
	{
		return NativeMethods.XStoreIsLicenseValid(license.Handle);
	}

	public static bool XStoreProductsQueryHasMorePages(XStoreProductQuery productQueryHandle)
	{
		return NativeMethods.XStoreProductsQueryHasMorePages(productQueryHandle.Handle);
	}

	public static int XStoreProductsQueryNextPageAsync(XStoreProductQuery productQueryHandle, XAsyncBlock async)
	{
		return NativeMethods.XStoreProductsQueryNextPageAsync(productQueryHandle.Handle, async.InteropPtr);
	}

	public static int XStoreProductsQueryNextPageResult(XAsyncBlock async, out XStoreProductQuery productQueryHandle)
	{
		productQueryHandle = null;
		int num = NativeMethods.XStoreProductsQueryNextPageResult(async.InteropPtr, out var productQueryHandle2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			productQueryHandle = new XStoreProductQuery(productQueryHandle2);
		}
		return num;
	}

	public static int XStoreQueryAddOnLicensesAsync(XStoreContext storeContext, XAsyncBlock async)
	{
		return NativeMethods.XStoreQueryAddOnLicensesAsync(storeContext.Handle, async.InteropPtr);
	}

	public static int XStoreQueryAddOnLicensesResultCount(XAsyncBlock async, out uint count)
	{
		return NativeMethods.XStoreQueryAddOnLicensesResultCount(async.InteropPtr, out count);
	}

	public static int XStoreQueryAddOnLicensesResult(XAsyncBlock async, XStoreAddonLicense[] addOnLicenses)
	{
		Unity.XGamingRuntime.Interop.XStoreAddonLicense[] array = new Unity.XGamingRuntime.Interop.XStoreAddonLicense[addOnLicenses.Length];
		int num = NativeMethods.XStoreQueryAddOnLicensesResult(async.InteropPtr, (uint)array.Length, array);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			for (int i = 0; i < addOnLicenses.Length; i++)
			{
				addOnLicenses[i] = new XStoreAddonLicense(array[i]);
			}
		}
		return num;
	}

	public static int XStoreQueryAssociatedProductsAsync(XStoreContext storeContext, XStoreProductKind productKinds, uint maxItemsToRetrievePerPage, XAsyncBlock async)
	{
		return NativeMethods.XStoreQueryAssociatedProductsAsync(storeContext.Handle, productKinds, maxItemsToRetrievePerPage, async.InteropPtr);
	}

	public static int XStoreQueryAssociatedProductsResult(XAsyncBlock async, out XStoreProductQuery productQueryHandle)
	{
		productQueryHandle = null;
		int num = NativeMethods.XStoreQueryAssociatedProductsResult(async.InteropPtr, out var productQueryHandle2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			productQueryHandle = new XStoreProductQuery(productQueryHandle2);
		}
		return num;
	}

	public static int XStoreQueryConsumableBalanceRemainingAsync(XStoreContext storeContext, string storeProductId, XAsyncBlock async)
	{
		return NativeMethods.XStoreQueryConsumableBalanceRemainingAsync(storeContext.Handle, storeProductId, async.InteropPtr);
	}

	public static int XStoreQueryConsumableBalanceRemainingResult(XAsyncBlock async, out XStoreConsumableResult consumableResult)
	{
		consumableResult = null;
		Unity.XGamingRuntime.Interop.XStoreConsumableResult consumableResult2 = default;
		int num = NativeMethods.XStoreQueryConsumableBalanceRemainingResult(async.InteropPtr, out consumableResult2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			consumableResult = new XStoreConsumableResult(consumableResult2);
		}
		return num;
	}

	public static int XStoreQueryEntitledProductsAsync(XStoreContext storeContext, XStoreProductKind productKinds, uint maxItemsToRetrievePerPage, XAsyncBlock async)
	{
		return NativeMethods.XStoreQueryEntitledProductsAsync(storeContext.Handle, productKinds, maxItemsToRetrievePerPage, async.InteropPtr);
	}

	public static int XStoreQueryEntitledProductsResult(XAsyncBlock async, out XStoreProductQuery productQueryHandle)
	{
		productQueryHandle = null;
		int num = NativeMethods.XStoreQueryEntitledProductsResult(async.InteropPtr, out var productQueryHandle2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			productQueryHandle = new XStoreProductQuery(productQueryHandle2);
		}
		return num;
	}

	public static int XStoreQueryGameAndDlcPackageUpdatesAsync(XStoreContext storeContext, XAsyncBlock async)
	{
		return NativeMethods.XStoreQueryGameAndDlcPackageUpdatesAsync(storeContext.Handle, async.InteropPtr);
	}

	public static int XStoreQueryGameAndDlcPackageUpdatesResultCount(XAsyncBlock async, out uint count)
	{
		return NativeMethods.XStoreQueryGameAndDlcPackageUpdatesResultCount(async.InteropPtr, out count);
	}

	public static int XStoreQueryGameAndDlcPackageUpdatesResult(XAsyncBlock async, XStorePackageUpdate[] packageUpdates)
	{
		Unity.XGamingRuntime.Interop.XStorePackageUpdate[] array = new Unity.XGamingRuntime.Interop.XStorePackageUpdate[packageUpdates.Length];
		int num = NativeMethods.XStoreQueryGameAndDlcPackageUpdatesResult(async.InteropPtr, (uint)array.Length, array);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			for (int i = 0; i < packageUpdates.Length; i++)
			{
				packageUpdates[i] = new XStorePackageUpdate(array[i]);
			}
		}
		return num;
	}

	public static int XStoreQueryGameLicenseAsync(XStoreContext storeContext, XAsyncBlock async)
	{
		return NativeMethods.XStoreQueryGameLicenseAsync(storeContext.Handle, async.InteropPtr);
	}

	public static int XStoreQueryGameLicenseResult(XAsyncBlock async, out XStoreGameLicense license)
	{
		license = null;
		Unity.XGamingRuntime.Interop.XStoreGameLicense license2 = default;
		int num = NativeMethods.XStoreQueryGameLicenseResult(async.InteropPtr, out license2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			license = new XStoreGameLicense(license2);
		}
		return num;
	}

	public static int XStoreQueryLicenseTokenAsync(XStoreContext storeContext, string[] productIds, string customDeveloperString, XAsyncBlock async)
	{
		return NativeMethods.XStoreQueryLicenseTokenAsync(storeContext.Handle, productIds, (ulong)productIds.Length, customDeveloperString, async.InteropPtr);
	}

	public static int XStoreQueryLicenseTokenResultSize(XAsyncBlock async, out ulong size)
	{
		return NativeMethods.XStoreQueryLicenseTokenResultSize(async.InteropPtr, out size);
	}

	public static int XStoreQueryLicenseTokenResult(XAsyncBlock async, ulong size, out string result)
	{
		result = null;
		StringBuilder stringBuilder = new StringBuilder((int)size);
		int num = NativeMethods.XStoreQueryLicenseTokenResult(async.InteropPtr, size, stringBuilder);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			result = stringBuilder.ToString();
		}
		return num;
	}

	public static int XStoreQueryPackageIdentifier(string storeId, ulong size, out string packageIdentifier)
	{
		packageIdentifier = null;
		StringBuilder stringBuilder = new StringBuilder((int)size);
		int num = NativeMethods.XStoreQueryPackageIdentifier(storeId, size, stringBuilder);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			packageIdentifier = stringBuilder.ToString();
		}
		return num;
	}

	public static int XStoreQueryPackageIdentifier(string storeId, out string packageIdentifier)
	{
		return XStoreQueryPackageIdentifier(storeId, (ulong)XPACKAGE_IDENTIFIER_MAX_LENGTH, out packageIdentifier);
	}

	public static int XStoreQueryProductForPackageAsync(XStoreContext storeContext, XStoreProductKind productKinds, string packageIdentifier, XAsyncBlock async)
	{
		return NativeMethods.XStoreQueryProductForPackageAsync(storeContext.Handle, productKinds, packageIdentifier, async.InteropPtr);
	}

	public static int XStoreQueryProductForPackageResult(XAsyncBlock async, out XStoreProductQuery productQueryHandle)
	{
		productQueryHandle = null;
		int num = NativeMethods.XStoreQueryProductForPackageResult(async.InteropPtr, out var productQueryHandle2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			productQueryHandle = new XStoreProductQuery(productQueryHandle2);
		}
		return num;
	}

	public static int XStoreQueryProductsAsync(XStoreContext storeContext, XStoreProductKind productKinds, string[] storeIds, string[] actionFilters, XAsyncBlock async)
	{
		ulong actionFiltersCount = (ulong)((actionFilters != null) ? actionFilters.Length : 0);
		return NativeMethods.XStoreQueryProductsAsync(storeContext.Handle, productKinds, storeIds, (ulong)storeIds.Length, actionFilters, actionFiltersCount, async.InteropPtr);
	}

	public static int XStoreQueryProductsResult(XAsyncBlock async, out XStoreProductQuery productQueryHandle)
	{
		productQueryHandle = null;
		int num = NativeMethods.XStoreQueryProductsResult(async.InteropPtr, out var productQueryHandle2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			productQueryHandle = new XStoreProductQuery(productQueryHandle2);
		}
		return num;
	}

	public static int XStoreRegisterGameLicenseChanged(XStoreContext storeContext, XTaskQueueHandle queue, IntPtr context, XStoreGameLicenseChangedCallback callback, out GameLicenseChangedCallbackToken token)
	{
		Unity.XGamingRuntime.Interop.XStoreGameLicenseChangedCallback callback2 = (IntPtr context2) =>
		{
			callback(context2);
		};
		token = new GameLicenseChangedCallbackToken(storeContext, callback2, context);
		int num = NativeMethods.XStoreRegisterGameLicenseChanged(storeContext.Handle, queue.Handle, token.interop.CallbackContext, token.interop.StaticCallback, out var token2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			token.Token = token2;
			return num;
		}
		token.Dispose();
		token = null;
		return num;
	}

	public static bool XStoreUnregisterGameLicenseChanged(GameLicenseChangedCallbackToken token, bool wait)
	{
		return token.Unregister(wait);
	}

	public static int XStoreRegisterPackageLicenseLost(XStoreLicense licenseHandle, XTaskQueueHandle queue, IntPtr context, XStorePackageLicenseLostCallback callback, out PackageLicenseLostCallbackToken token)
	{
		Unity.XGamingRuntime.Interop.XStorePackageLicenseLostCallback callback2 = (IntPtr context2) =>
		{
			callback(context2);
		};
		token = new PackageLicenseLostCallbackToken(licenseHandle, callback2, context);
		int num = NativeMethods.XStoreRegisterPackageLicenseLost(licenseHandle.Handle, queue.Handle, token.interop.CallbackContext, token.interop.StaticCallback, out var token2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			token.Token = token2;
			return num;
		}
		token.Dispose();
		token = null;
		return num;
	}

	public static bool XStoreUnregisterPackageLicenseLost(PackageLicenseLostCallbackToken token, bool wait)
	{
		return token.Unregister(wait);
	}

	public static bool XStoreUnregisterPackageLicenseLost(PackageLicenseLostCallbackToken token)
	{
		return XStoreUnregisterPackageLicenseLost(token, wait: true);
	}

	public static int XStoreReportConsumableFulfillmentAsync(XStoreContext storeContext, string storeProductId, uint quantity, Guid trackingId, XAsyncBlock async)
	{
		return NativeMethods.XStoreReportConsumableFulfillmentAsync(storeContext.Handle, storeProductId, quantity, trackingId, async.InteropPtr);
	}

	public static int XStoreReportConsumableFulfillmentResult(XAsyncBlock async, out XStoreConsumableResult consumableResult)
	{
		consumableResult = null;
		Unity.XGamingRuntime.Interop.XStoreConsumableResult consumableResult2 = default;
		int num = NativeMethods.XStoreReportConsumableFulfillmentResult(async.InteropPtr, out consumableResult2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			consumableResult = new XStoreConsumableResult(consumableResult2);
		}
		return num;
	}

	public static int XStoreShowAssociatedProductsUIAsync(XStoreContext storeContext, string storeId, XStoreProductKind productKinds, XAsyncBlock async)
	{
		return NativeMethods.XStoreShowAssociatedProductsUIAsync(storeContext.Handle, storeId, productKinds, async.InteropPtr);
	}

	public static int XStoreShowAssociatedProductsUIResult(XAsyncBlock async)
	{
		return NativeMethods.XStoreShowAssociatedProductsUIResult(async.InteropPtr);
	}

	public static int XStoreShowProductPageUIAsync(XStoreContext storeContext, string storeId, XAsyncBlock async)
	{
		return NativeMethods.XStoreShowProductPageUIAsync(storeContext.Handle, storeId, async.InteropPtr);
	}

	public static int XStoreShowProductPageUIResult(XAsyncBlock async)
	{
		return NativeMethods.XStoreShowProductPageUIResult(async.InteropPtr);
	}

	public static int XStoreShowPurchaseUIAsync(XStoreContext storeContext, string storeId, string name, string extendedJsonData, XAsyncBlock async)
	{
		return NativeMethods.XStoreShowPurchaseUIAsync(storeContext.Handle, storeId, name, extendedJsonData, async.InteropPtr);
	}

	public static int XStoreShowPurchaseUIResult(XAsyncBlock async)
	{
		return NativeMethods.XStoreShowPurchaseUIResult(async.InteropPtr);
	}

	public static int XStoreShowRateAndReviewUIAsync(XStoreContext storeContext, XAsyncBlock async)
	{
		return NativeMethods.XStoreShowRateAndReviewUIAsync(storeContext.Handle, async.InteropPtr);
	}

	public static int XStoreShowRateAndReviewUIResult(XAsyncBlock async, out XStoreRateAndReviewResult result)
	{
		result = null;
		Unity.XGamingRuntime.Interop.XStoreRateAndReviewResult result2 = default;
		int num = NativeMethods.XStoreShowRateAndReviewUIResult(async.InteropPtr, out result2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			result = new XStoreRateAndReviewResult(result2);
		}
		return num;
	}

	public static int XStoreShowRedeemTokenUIAsync(XStoreContext storeContext, string token, string[] allowedStoreIds, bool disallowCsvRedemption, XAsyncBlock async)
	{
		return NativeMethods.XStoreShowRedeemTokenUIAsync(storeContext.Handle, token, allowedStoreIds, (ulong)allowedStoreIds.Length, disallowCsvRedemption, async.InteropPtr);
	}

	public static int XStoreShowRedeemTokenUIResult(XAsyncBlock async)
	{
		return NativeMethods.XStoreShowRedeemTokenUIResult(async.InteropPtr);
	}

	public static XSystemAnalyticsInfo XSystemGetAnalyticsInfo()
	{
		Unity.XGamingRuntime.Interop.XSystemAnalyticsInfo info = default;
		NativeMethods.XSystemGetAnalyticsInfo(out info);
		return new XSystemAnalyticsInfo(info);
	}

	public static int XSystemGetAppSpecificDeviceId(out string appSpecificDeviceId)
	{
		appSpecificDeviceId = null;
		StringBuilder stringBuilder = new StringBuilder((int)XSystemAppSpecificDeviceIdBytes);
		int num = NativeMethods.XSystemGetAppSpecificDeviceId((ulong)stringBuilder.Capacity, stringBuilder, out var _);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			appSpecificDeviceId = stringBuilder.ToString();
		}
		return num;
	}

	public static int XSystemGetConsoleId(out string consoleId)
	{
		consoleId = null;
		StringBuilder stringBuilder = new StringBuilder((int)XSystemConsoleIdBytes);
		int num = NativeMethods.XSystemGetConsoleId((ulong)stringBuilder.Capacity, stringBuilder, out var _);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			consoleId = stringBuilder.ToString();
		}
		return num;
	}

	public static XSystemDeviceType XSystemGetDeviceType()
	{
		return NativeMethods.XSystemGetDeviceType();
	}

	public static int XSystemGetXboxLiveSandboxId(out string sandboxId)
	{
		sandboxId = null;
		StringBuilder stringBuilder = new StringBuilder((int)XSystemXboxLiveSandboxIdMaxBytes);
		int num = NativeMethods.XSystemGetXboxLiveSandboxId((ulong)stringBuilder.Capacity, stringBuilder, out var _);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			sandboxId = stringBuilder.ToString();
		}
		return num;
	}

	public static XSystemRuntimeInfo XSystemGetRuntimeInfo()
	{
		return new XSystemRuntimeInfo(NativeMethods.XSystemGetRuntimeInfo());
	}

	public static bool XSystemIsHandleValid(IntPtr handle)
	{
		return NativeMethods.XSystemIsHandleValid(handle);
	}

	public static int XSystemHandleTrack(XSystemHandleCallback callback, IntPtr context, out XSystemHandleCallbackHandle handle)
	{
		Unity.XGamingRuntime.Interop.XSystemHandleCallback callback2 = (IntPtr handlePtr, XSystemHandleType type, XSystemHandleCallbackReason reason, IntPtr callbackContext) =>
		{
			callback(handlePtr, type, reason, callbackContext);
		};
		handle = new XSystemHandleCallbackHandle(callback2, context);
		int num = NativeMethods.XSystemHandleTrack(handle.interop.StaticCallback, handle.interop.CallbackContext);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			handle.Dispose();
			handle = null;
		}
		return num;
	}

	public static void XTaskQueueCloseHandle(XTaskQueueHandle queue)
	{
		queue.Close();
	}

	public static int XTaskQueueCreate(XTaskQueueDispatchMode workDispatchMode, XTaskQueueDispatchMode completionDispatchMode, out XTaskQueueHandle handle)
	{
		handle = null;
		int num = NativeMethods.XTaskQueueCreate(workDispatchMode, completionDispatchMode, out var queue);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			handle = new XTaskQueueHandle(queue);
		}
		return num;
	}

	public static int XTaskQueueCreateComposite(XTaskQueuePortHandle workPort, XTaskQueuePortHandle completionPort, out XTaskQueueHandle queue)
	{
		queue = null;
		int num = NativeMethods.XTaskQueueCreateComposite(workPort.Handle, completionPort.Handle, out var queue2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			queue = new XTaskQueueHandle(queue2);
		}
		return num;
	}

	public static bool XTaskQueueDispatch(XTaskQueueHandle queue, XTaskQueuePort port, uint timeoutInMs)
	{
		return NativeMethods.XTaskQueueDispatch(queue.Handle, port, timeoutInMs);
	}

	public static int XTaskQueueDuplicateHandle(XTaskQueueHandle queue, out XTaskQueueHandle duplicatedHandle)
	{
		duplicatedHandle = null;
		int num = NativeMethods.XTaskQueueDuplicateHandle(queue.Handle, out var duplicatedHandle2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			duplicatedHandle = new XTaskQueueHandle(duplicatedHandle2);
		}
		return num;
	}

	public static bool XTaskQueueGetCurrentProcessTaskQueue(out XTaskQueueHandle queue)
	{
		bool flag = NativeMethods.XTaskQueueGetCurrentProcessTaskQueue(out var queue2);
		queue = (flag ? new XTaskQueueHandle(queue2) : null);
		return flag;
	}

	public static int XTaskQueueGetPort(XTaskQueueHandle queue, XTaskQueuePort port, out XTaskQueuePortHandle portHandle)
	{
		portHandle = null;
		int num = NativeMethods.XTaskQueueGetPort(queue.Handle, port, out var portHandle2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			portHandle = new XTaskQueuePortHandle(portHandle2);
		}
		return num;
	}

	public static int XTaskQueueRegisterMonitor(XTaskQueueHandle queue, IntPtr callbackContext, XTaskQueueMonitorCallback callback, out XTaskQueueMonitorCallbackHandle tokenHandle)
	{
		Unity.XGamingRuntime.Interop.XTaskQueueMonitorCallback callback2 = (IntPtr context, IntPtr queuePtr, XTaskQueuePort port) =>
		{
			callback(context, queuePtr, port);
		};
		tokenHandle = new XTaskQueueMonitorCallbackHandle(queue, callback2, callbackContext);
		int num = NativeMethods.XTaskQueueRegisterMonitor(queue.Handle, tokenHandle.interop.CallbackContext, tokenHandle.interop.StaticCallback, out var token);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			tokenHandle.Token = token;
			return num;
		}
		tokenHandle.Dispose();
		tokenHandle = null;
		return num;
	}

	public static int XTaskQueueRegisterWaiter(XTaskQueueHandle queue, XTaskQueuePort port, WaitHandle waitHandle, IntPtr callbackContext, XTaskQueueCallback callback, out XTaskQueueWaiterCallbackHandle tokenHandle)
	{
		Unity.XGamingRuntime.Interop.XTaskQueueCallback callback2 = (IntPtr context, bool canceled) =>
		{
			callback(context, canceled);
		};
		tokenHandle = new XTaskQueueWaiterCallbackHandle(queue, callback2, callbackContext);
		int num = NativeMethods.XTaskQueueRegisterWaiter(queue.Handle, port, waitHandle.SafeWaitHandle, tokenHandle.interop.CallbackContext, tokenHandle.interop.StaticCallback, out var token);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			tokenHandle.Token = token;
			return num;
		}
		tokenHandle.Dispose();
		tokenHandle = null;
		return num;
	}

	public static void XTaskQueueSetCurrentProcessTaskQueue(XTaskQueueHandle queue)
	{
		NativeMethods.XTaskQueueSetCurrentProcessTaskQueue(queue.Handle);
	}

	public static int XTaskQueueSubmitCallback(XTaskQueueHandle queue, XTaskQueuePort port, IntPtr callbackContext, XTaskQueueCallback callback, out XTaskQueueCallbackHandle callbackHandle)
	{
		Unity.XGamingRuntime.Interop.XTaskQueueCallback callback2 = (IntPtr context, bool canceled) =>
		{
			callback(context, canceled);
		};
		callbackHandle = new XTaskQueueCallbackHandle(callback2, callbackContext);
		int num = NativeMethods.XTaskQueueSubmitCallback(queue.Handle, port, callbackHandle.interop.CallbackContext, callbackHandle.interop.StaticCallback);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			callbackHandle.Dispose();
			callbackHandle = null;
		}
		return num;
	}

	public static int XTaskQueueSubmitDelayedCallback(XTaskQueueHandle queue, XTaskQueuePort port, uint delayMs, IntPtr callbackContext, XTaskQueueCallback callback, out XTaskQueueCallbackHandle callbackHandle)
	{
		Unity.XGamingRuntime.Interop.XTaskQueueCallback callback2 = (IntPtr context, bool canceled) =>
		{
			callback(context, canceled);
		};
		callbackHandle = new XTaskQueueCallbackHandle(callback2, callbackContext);
		int num = NativeMethods.XTaskQueueSubmitDelayedCallback(queue.Handle, port, delayMs, callbackHandle.interop.CallbackContext, callbackHandle.interop.StaticCallback);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			callbackHandle.Dispose();
			callbackHandle = null;
		}
		return num;
	}

	public static int XTaskQueueTerminate(XTaskQueueHandle queue, bool wait, IntPtr callbackContext, XTaskQueueTerminatedCallback callback, out XTaskQueueTerminateCallbackHandle callbackHandle)
	{
		Unity.XGamingRuntime.Interop.XTaskQueueTerminatedCallback callback2 = (IntPtr context) =>
		{
			callback(context);
		};
		callbackHandle = new XTaskQueueTerminateCallbackHandle(callback2, callbackContext);
		int num = NativeMethods.XTaskQueueTerminate(queue.Handle, wait, callbackHandle.interop.CallbackContext, callbackHandle.interop.StaticCallback);
		if (Unity.XGamingRuntime.Interop.HR.FAILED(num))
		{
			callbackHandle.Dispose();
			callbackHandle = null;
		}
		return num;
	}

	public static int XTaskQueueTerminate(XTaskQueueHandle queue, bool wait, IntPtr callbackContext)
	{
		return NativeMethods.XTaskQueueTerminate(queue.Handle, wait, callbackContext, null);
	}

	public static void XTaskQueueUnregisterMonitor(XTaskQueueHandle queue, XTaskQueueMonitorCallbackHandle token)
	{
		token.Unregister(queue);
	}

	public static void XTaskQueueUnregisterWaiter(XTaskQueueHandle queue, XTaskQueueWaiterCallbackHandle token)
	{
		token.Unregister(queue);
	}

	public static void XThreadAssertNotTimeSensitive()
	{
		NativeMethods.XThreadAssertNotTimeSensitive();
	}

	public static bool XThreadIsTimeSensitive()
	{
		return NativeMethods.XThreadIsTimeSensitive();
	}

	public static int XThreadSetTimeSensitive(bool isTimeSensitiveThread)
	{
		return NativeMethods.XThreadSetTimeSensitive(isTimeSensitiveThread);
	}

	public static int XUserAddAsync(XUserAddOptions options, XAsyncBlock async)
	{
		return NativeMethods.XUserAddAsync(options, async.InteropPtr);
	}

	public static int XUserAddResult(XAsyncBlock async, out XUserHandle newUser)
	{
		IntPtr newUser2;
		return XUserHandle.WrapAndReturnHResult(NativeMethods.XUserAddResult(async.InteropPtr, out newUser2), newUser2, out newUser);
	}

	public static int XUserAddByIdWithUiAsync(ulong userId, XAsyncBlock async)
	{
		return NativeMethods.XUserAddByIdWithUiAsync(userId, async.InteropPtr);
	}

	public static int XUserAddByIdWithUiResult(XAsyncBlock async, out XUserHandle newUser)
	{
		IntPtr newUser2;
		return XUserHandle.WrapAndReturnHResult(NativeMethods.XUserAddByIdWithUiResult(async.InteropPtr, out newUser2), newUser2, out newUser);
	}

	public static int XUserCheckPrivilege(XUserHandle user, XUserPrivilegeOptions options, XUserPrivilege privilege, out bool hasPrivilege, out XUserPrivilegeDenyReason reason)
	{
		return NativeMethods.XUserCheckPrivilege((user != null) ? user.Handle : IntPtr.Zero, options, privilege, out hasPrivilege, out reason);
	}

	public static void XUserCloseHandle(XUserHandle user)
	{
		if (!(user == null))
		{
			user.Close();
		}
	}

	public static int XUserCloseSignOutDeferralHandle(XUserSignOutDeferralHandle deferral)
	{
		deferral.Close();
		return 0;
	}

	public static int XUserCompare(XUserHandle user1, XUserHandle user2)
	{
		IntPtr user3 = ((user1 != null) ? user1.Handle : IntPtr.Zero);
		IntPtr user4 = ((user2 != null) ? user2.Handle : IntPtr.Zero);
		return NativeMethods.XUserCompare(user3, user4);
	}

	public static int XUserCompare(XUserHandle user1, XUserHandle user2, out int comparisonResult)
	{
		comparisonResult = XUserCompare(user1, user2);
		return 0;
	}

	public static int XUserDuplicateHandle(XUserHandle handle, out XUserHandle duplicatedHandle)
	{
		IntPtr duplicatedHandle2;
		return XUserHandle.WrapAndReturnHResult(NativeMethods.XUserDuplicateHandle((handle != null) ? handle.Handle : IntPtr.Zero, out duplicatedHandle2), duplicatedHandle2, out duplicatedHandle);
	}

	public static int XUserFindControllerForUserWithUiAsync(XUserHandle user, XAsyncBlock async)
	{
		return NativeMethods.XUserFindControllerForUserWithUiAsync((user != null) ? user.Handle : IntPtr.Zero, async.InteropPtr);
	}

	public static int XUserFindControllerForUserWithUiResult(XAsyncBlock async, out APP_LOCAL_DEVICE_ID deviceId)
	{
		deviceId = null;
		Unity.XGamingRuntime.Interop.APP_LOCAL_DEVICE_ID deviceId2 = default;
		int num = NativeMethods.XUserFindControllerForUserWithUiResult(async.InteropPtr, out deviceId2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			deviceId = new APP_LOCAL_DEVICE_ID(deviceId2);
		}
		return num;
	}

	public static int XUserFindForDevice(APP_LOCAL_DEVICE_ID deviceId, out XUserHandle handle)
	{
		IntPtr handle2;
		return XUserHandle.WrapAndReturnHResult(NativeMethods.XUserFindForDevice(ref deviceId.interop, out handle2), handle2, out handle);
	}

	public static int XUserFindUserById(ulong userId, out XUserHandle handle)
	{
		IntPtr handle2;
		return XUserHandle.WrapAndReturnHResult(NativeMethods.XUserFindUserById(userId, out handle2), handle2, out handle);
	}

	public static int XUserFindUserByLocalId(XUserLocalId userLocalId, out XUserHandle handle)
	{
		IntPtr handle2;
		return XUserHandle.WrapAndReturnHResult(NativeMethods.XUserFindUserByLocalId(userLocalId.interop, out handle2), handle2, out handle);
	}

	public static int XUserGetAgeGroup(XUserHandle user, out XUserAgeGroup ageGroup)
	{
		return NativeMethods.XUserGetAgeGroup((user != null) ? user.Handle : IntPtr.Zero, out ageGroup);
	}

	public static int XUserGetDefaultAudioEndpointUtf16(XUserLocalId user, XUserDefaultAudioEndpointKind defaultAudioEndpointKind, ulong endpointIdUtf16Count, char[] endpointIdUtf16, out ulong endpointIdUtf16Used)
	{
		return NativeMethods.XUserGetDefaultAudioEndpointUtf16(user.interop, defaultAudioEndpointKind, endpointIdUtf16Count, endpointIdUtf16, out endpointIdUtf16Used);
	}

	public static int XUserGetGamerPictureAsync(XUserHandle user, XUserGamerPictureSize pictureSize, XAsyncBlock async)
	{
		return NativeMethods.XUserGetGamerPictureAsync((user != null) ? user.Handle : IntPtr.Zero, pictureSize, async.InteropPtr);
	}

	public static int XUserGetGamerPictureResultSize(XAsyncBlock async, out ulong bufferSize)
	{
		return NativeMethods.XUserGetGamerPictureResultSize(async.InteropPtr, out bufferSize);
	}

	public static int XUserGetGamerPictureResult(XAsyncBlock async, byte[] buffer, out ulong bufferUsed)
	{
		return NativeMethods.XUserGetGamerPictureResult(async.InteropPtr, (ulong)buffer.Length, buffer, out bufferUsed);
	}

	public static int XUserGetGamertag(XUserHandle user, XUserGamertagComponent gamertagComponent, StringBuilder gamertag, out ulong gamertagUsed)
	{
		return NativeMethods.XUserGetGamertag((user != null) ? user.Handle : IntPtr.Zero, gamertagComponent, (ulong)gamertag.Capacity, gamertag, out gamertagUsed);
	}

	public static int XUserGetId(XUserHandle user, out ulong userId)
	{
		return NativeMethods.XUserGetId((user != null) ? user.Handle : IntPtr.Zero, out userId);
	}

	public static int XUserGetIsGuest(XUserHandle user, out bool isGuest)
	{
		return NativeMethods.XUserGetIsGuest((user != null) ? user.Handle : IntPtr.Zero, out isGuest);
	}

	public static int XUserGetLocalId(XUserHandle user, out XUserLocalId userLocalId)
	{
		userLocalId = null;
		Unity.XGamingRuntime.Interop.XUserLocalId userLocalId2 = default;
		int num = NativeMethods.XUserGetLocalId((user != null) ? user.Handle : IntPtr.Zero, out userLocalId2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			userLocalId = new XUserLocalId(userLocalId2);
		}
		return num;
	}

	public static int XUserGetMaxUsers(out uint maxUsers)
	{
		return NativeMethods.XUserGetMaxUsers(out maxUsers);
	}

	public static int XUserGetSignOutDeferral(out XUserSignOutDeferralHandle deferral)
	{
		deferral = null;
		int num = NativeMethods.XUserGetSignOutDeferral(out var deferral2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			deferral = new XUserSignOutDeferralHandle(deferral2);
		}
		return num;
	}

	public static int XUserGetState(XUserHandle user, out XUserState state)
	{
		return NativeMethods.XUserGetState((user != null) ? user.Handle : IntPtr.Zero, out state);
	}

	public static int XUserGetTokenAndSignatureAsync(XUserHandle user, XUserGetTokenAndSignatureOptions options, string method, string url, XUserGetTokenAndSignatureHttpHeader[] headers, byte[] bodyBuffer, XAsyncBlock async)
	{
		Unity.XGamingRuntime.Interop.XUserGetTokenAndSignatureHttpHeader[] array = null;
		if (headers != null)
		{
			array = new Unity.XGamingRuntime.Interop.XUserGetTokenAndSignatureHttpHeader[headers.Length];
			for (int i = 0; i < headers.Length; i++)
			{
				array[i] = headers[i].interop;
			}
		}
		IntPtr user2 = ((user != null) ? user.Handle : IntPtr.Zero);
		ulong headerCount = (ulong)((array != null) ? array.Length : 0);
		ulong bodySize = (ulong)((bodyBuffer != null) ? bodyBuffer.Length : 0);
		return NativeMethods.XUserGetTokenAndSignatureAsync(user2, options, method, url, headerCount, array, bodySize, bodyBuffer, async.InteropPtr);
	}

	public static int XUserGetTokenAndSignatureResultSize(XAsyncBlock async, out ulong bufferSize)
	{
		return NativeMethods.XUserGetTokenAndSignatureResultSize(async.InteropPtr, out bufferSize);
	}

	public static int XUserGetTokenAndSignatureResult(XAsyncBlock async, byte[] buffer, out XUserGetTokenAndSignatureData result)
	{
		result = null;
		Unity.XGamingRuntime.Interop.XUserGetTokenAndSignatureData xUserGetTokenAndSignatureData = default;
		int num = NativeMethods.XUserGetTokenAndSignatureResult(async.InteropPtr, (ulong)buffer.Length, buffer, out var ptrToBuffer, out var _);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			xUserGetTokenAndSignatureData = (Unity.XGamingRuntime.Interop.XUserGetTokenAndSignatureData)Marshal.PtrToStructure(ptrToBuffer, typeof(Unity.XGamingRuntime.Interop.XUserGetTokenAndSignatureData));
			result = new XUserGetTokenAndSignatureData(xUserGetTokenAndSignatureData);
		}
		return num;
	}

	public static int XUserGetTokenAndSignatureUtf16Async(XUserHandle user, XUserGetTokenAndSignatureOptions options, string method, string url, XUserGetTokenAndSignatureUtf16HttpHeader[] headers, byte[] bodyBuffer, XAsyncBlock async)
	{
		Unity.XGamingRuntime.Interop.XUserGetTokenAndSignatureUtf16HttpHeader[] array = null;
		if (headers != null)
		{
			array = new Unity.XGamingRuntime.Interop.XUserGetTokenAndSignatureUtf16HttpHeader[headers.Length];
			for (int i = 0; i < headers.Length; i++)
			{
				array[i] = headers[i].interop;
			}
		}
		IntPtr user2 = ((user != null) ? user.Handle : IntPtr.Zero);
		ulong headerCount = (ulong)((array != null) ? array.Length : 0);
		ulong bodySize = (ulong)((bodyBuffer != null) ? bodyBuffer.Length : 0);
		return NativeMethods.XUserGetTokenAndSignatureUtf16Async(user2, options, method, url, headerCount, array, bodySize, bodyBuffer, async.InteropPtr);
	}

	public static int XUserGetTokenAndSignatureUtf16ResultSize(XAsyncBlock async, out ulong bufferSize)
	{
		return NativeMethods.XUserGetTokenAndSignatureUtf16ResultSize(async.InteropPtr, out bufferSize);
	}

	public static int XUserGetTokenAndSignatureUtf16Result(XAsyncBlock async, byte[] buffer, out XUserGetTokenAndSignatureUtf16Data result)
	{
		result = null;
		Unity.XGamingRuntime.Interop.XUserGetTokenAndSignatureUtf16Data xUserGetTokenAndSignatureUtf16Data = default;
		int num = NativeMethods.XUserGetTokenAndSignatureUtf16Result(async.InteropPtr, (ulong)buffer.Length, buffer, out var ptrToBuffer, out var _);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			xUserGetTokenAndSignatureUtf16Data = (Unity.XGamingRuntime.Interop.XUserGetTokenAndSignatureUtf16Data)Marshal.PtrToStructure(ptrToBuffer, typeof(Unity.XGamingRuntime.Interop.XUserGetTokenAndSignatureUtf16Data));
			result = new XUserGetTokenAndSignatureUtf16Data(xUserGetTokenAndSignatureUtf16Data);
		}
		return num;
	}

	public static bool XUserIsStoreUser(XUserHandle user)
	{
		return NativeMethods.XUserIsStoreUser((user != null) ? user.Handle : IntPtr.Zero);
	}

	public static int XUserRegisterForChangeEvent(XTaskQueueHandle queue, IntPtr context, XUserChangeEventCallback callback, out XUserChangeRegistrationToken token)
	{
		Unity.XGamingRuntime.Interop.XUserChangeEventCallback callback2 = (IntPtr callbackContext, Unity.XGamingRuntime.Interop.XUserLocalId userLocalId, XUserChangeEvent changeEvent) =>
		{
			callback(callbackContext, new XUserLocalId(userLocalId), changeEvent);
		};
		token = new XUserChangeRegistrationToken(callback2, context);
		int num = NativeMethods.XUserRegisterForChangeEvent((queue != null) ? queue.Handle : IntPtr.Zero, token.interop.CallbackContext, token.interop.StaticCallback, out var token2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			token.Token = token2;
			return num;
		}
		token.Dispose();
		token = null;
		return num;
	}

	public static int XUserRegisterForDefaultAudioEndpointUtf16Changed(XTaskQueueHandle queue, IntPtr context, XUserDefaultAudioEndpointUtf16ChangedCallback callback, out XUserDefaultAudioEndpointUtf16RegistrationToken token)
	{
		Unity.XGamingRuntime.Interop.XUserDefaultAudioEndpointUtf16ChangedCallback callback2 = (IntPtr callbackContext, Unity.XGamingRuntime.Interop.XUserLocalId user, XUserDefaultAudioEndpointKind defaultAudioEndpointKind, string endpointIdUtf16) =>
		{
			callback(callbackContext, new XUserLocalId(user), defaultAudioEndpointKind, endpointIdUtf16);
		};
		token = new XUserDefaultAudioEndpointUtf16RegistrationToken(callback2, context);
		int num = NativeMethods.XUserRegisterForDefaultAudioEndpointUtf16Changed((queue != null) ? queue.Handle : IntPtr.Zero, token.interop.CallbackContext, token.interop.StaticCallback, out var token2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			token.Token = token2;
			return num;
		}
		token.Dispose();
		token = null;
		return num;
	}

	public static int XUserRegisterForDeviceAssociationChanged(XTaskQueueHandle queue, IntPtr context, XUserDeviceAssociationChangedCallback callback, out XUserDeviceAssociationChangedRegistrationToken token)
	{
		Unity.XGamingRuntime.Interop.XUserDeviceAssociationChangedCallback callback2 = delegate(IntPtr context2, ref Unity.XGamingRuntime.Interop.XUserDeviceAssociationChange change)
		{
			XUserDeviceAssociationChange change2 = new XUserDeviceAssociationChange(change);
			callback(context2, ref change2);
		};
		token = new XUserDeviceAssociationChangedRegistrationToken(callback2, context);
		int num = NativeMethods.XUserRegisterForDeviceAssociationChanged((queue != null) ? queue.Handle : IntPtr.Zero, token.interop.CallbackContext, token.interop.StaticCallback, out var token2);
		if (Unity.XGamingRuntime.Interop.HR.SUCCEEDED(num))
		{
			token.Token = token2;
			return num;
		}
		token.Dispose();
		token = null;
		return num;
	}

	public static int XUserResolveIssueWithUiAsync(XUserHandle user, string url, XAsyncBlock async)
	{
		return NativeMethods.XUserResolveIssueWithUiAsync((user != null) ? user.Handle : IntPtr.Zero, url, async.InteropPtr);
	}

	public static int XUserResolveIssueWithUiResult(XAsyncBlock async)
	{
		return NativeMethods.XUserResolveIssueWithUiResult(async.InteropPtr);
	}

	public static int XUserResolveIssueWithUiUtf16Async(XUserHandle user, string url, XAsyncBlock async)
	{
		return NativeMethods.XUserResolveIssueWithUiUtf16Async((user != null) ? user.Handle : IntPtr.Zero, url, async.InteropPtr);
	}

	public static int XUserResolveIssueWithUiUtf16Result(XAsyncBlock async)
	{
		return NativeMethods.XUserResolveIssueWithUiUtf16Result(async.InteropPtr);
	}

	public static int XUserResolvePrivilegeWithUiAsync(XUserHandle user, XUserPrivilegeOptions options, XUserPrivilege privilege, XAsyncBlock async)
	{
		return NativeMethods.XUserResolvePrivilegeWithUiAsync((user != null) ? user.Handle : IntPtr.Zero, options, privilege, async.InteropPtr);
	}

	public static int XUserResolvePrivilegeWithUiResult(XAsyncBlock async)
	{
		return NativeMethods.XUserResolvePrivilegeWithUiResult(async.InteropPtr);
	}

	public static bool XUserUnregisterForChangeEvent(XUserChangeRegistrationToken token, bool wait)
	{
		return token.Unregister(wait);
	}

	public static bool XUserUnregisterForChangeEvent(XUserChangeRegistrationToken token)
	{
		return XUserUnregisterForChangeEvent(token, wait: true);
	}

	public static bool XUserUnregisterForDefaultAudioEndpointUtf16Changed(XUserDefaultAudioEndpointUtf16RegistrationToken token, bool wait)
	{
		return token.Unregister(wait);
	}

	public static bool XUserUnregisterForDeviceAssociationChanged(XUserDeviceAssociationChangedRegistrationToken token, bool wait)
	{
		return token.Unregister(wait);
	}
}
