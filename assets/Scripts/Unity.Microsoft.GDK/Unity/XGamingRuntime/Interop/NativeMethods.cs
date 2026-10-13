using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace Unity.XGamingRuntime.Interop;

internal class NativeMethods
{
	internal const int MAX_PATH = 260;

	internal const int APPCAPTURE_MAX_CAPTURE_FILES = 10;

	internal const int APPCAPTURE_MAX_LOCALID_LENGTH = 250;

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XClosedCaptionGetProperties(out XClosedCaptionProperties properties);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XClosedCaptionSetEnabled([MarshalAs(UnmanagedType.I1)] bool enabled);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XHighContrastGetMode(out XHighContrastMode mode);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSpeechToTextSetPositionHint(XSpeechToTextPositionHint position);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSpeechToTextSendString([MarshalAs(UnmanagedType.LPStr)] string speakerName, [MarshalAs(UnmanagedType.LPStr)] string content, XSpeechToTextType type);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSpeechToTextBeginHypothesisString([MarshalAs(UnmanagedType.LPStr)] string speakerName, [MarshalAs(UnmanagedType.LPStr)] string content, XSpeechToTextType type, out uint hypothesisId);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSpeechToTextUpdateHypothesisString(uint hypothesisId, [MarshalAs(UnmanagedType.LPStr)] string content);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSpeechToTextFinalizeHypothesisString(uint hypothesisId, [MarshalAs(UnmanagedType.LPStr)] string content);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSpeechToTextCancelHypothesisString(uint hypothesisId);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppBroadcastGetStatus(IntPtr requestingUser, out XAppBroadcastStatus appBroadcastStatus);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XAppBroadcastIsAppBroadcasting();

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppBroadcastShowUI(IntPtr requestingUser);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppBroadcastRegisterIsAppBroadcastingChanged(IntPtr queue, IntPtr context, XAppBroadcastMonitorCallback appBroadcastMonitorCallback, out ulong token);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureCloseScreenshotStream(IntPtr handle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureEnableRecord();

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureDisableRecord();

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XAppBroadcastUnregisterIsAppBroadcastingChanged(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureMetadataAddStringEvent([MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string value, XAppCaptureMetadataPriority priority);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureMetadataAddInt32Event([MarshalAs(UnmanagedType.LPStr)] string name, int value, XAppCaptureMetadataPriority priority);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureMetadataAddDoubleEvent([MarshalAs(UnmanagedType.LPStr)] string name, double value, XAppCaptureMetadataPriority priority);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureMetadataStartStringState([MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string value, XAppCaptureMetadataPriority priority);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureMetadataStartInt32State([MarshalAs(UnmanagedType.LPStr)] string name, int value, XAppCaptureMetadataPriority priority);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureMetadataStartDoubleState([MarshalAs(UnmanagedType.LPStr)] string name, double value, XAppCaptureMetadataPriority priority);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureMetadataStopState([MarshalAs(UnmanagedType.LPStr)] string name);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureMetadataStopAllStates();

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureMetadataRemainingStorageBytesAvailable(out ulong value);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureOpenScreenshotStream([MarshalAs(UnmanagedType.LPStr)] string localId, XAppCaptureScreenshotFormatFlag screenshotFormat, out IntPtr handle, out ulong totalBytes);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureReadScreenshotStream(IntPtr handle, ulong startPosition, uint bytesToRead, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] buffer, out uint bytesWritten);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureRecordDiagnosticClip(long startTime, uint durationInMs, [MarshalAs(UnmanagedType.LPStr)] string filenamePrefix, out XAppCaptureRecordClipResult result);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureTakeDiagnosticScreenshot([MarshalAs(UnmanagedType.I1)] bool gamescreenOnly, XAppCaptureScreenshotFormatFlag captureFlags, [MarshalAs(UnmanagedType.LPStr)] string filenamePrefix, out XAppCaptureDiagnosticScreenshotResult result);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureTakeScreenshot(IntPtr requestingUser, out XAppCaptureTakeScreenshotResult result);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureRegisterMetadataPurged(IntPtr queue, IntPtr context, XAppCaptureMetadataPurgedCallback callback, out ulong token);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XAppCaptureUnRegisterMetadataPurged(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureReadLocalStream(IntPtr handle, long startPosition, uint bytesToRead, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] buffer, out uint bytesWritten);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureCloseLocalStream(IntPtr handle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureRecordTimespan(IntPtr startTimestamp, ulong durationInMilliseconds, out XAppCaptureLocalResult result);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAppCaptureGetVideoCaptureSettings(out XAppCaptureVideoCaptureSettings userCaptureSettings);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAsyncGetStatus(IntPtr asyncBlock, [MarshalAs(UnmanagedType.I1)] bool wait);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAsyncGetResultSize(IntPtr asyncBlock, out ulong bufferSize);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XAsyncCancel(IntPtr asyncBlock);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAsyncRun(IntPtr asyncBlock, XAsyncWorkInterop work);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAsyncBegin(IntPtr asyncInterop, IntPtr context, IntPtr identity, [MarshalAs(UnmanagedType.LPStr)] string identityName, XAsyncProviderInterop provider);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAsyncSchedule(IntPtr asyncInterop, uint delayInMs);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XAsyncComplete(IntPtr asyncInterop, uint result, ulong requiredBufferSize);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XAsyncGetResult(IntPtr asyncInterop, IntPtr identity, ulong bufferSize, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] buffer, out ulong bufferUsed);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern XDisplayHdrModeResult XDisplayTryEnableHdrMode(XDisplayHdrModePreference displayModePreference, out XDisplayHdrModeInfo displayHdrModeInfo);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XDisplayAcquireTimeoutDeferral(out IntPtr handle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XDisplayCloseTimeoutDeferralHandle(IntPtr handle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XErrorSetCallback(XErrorCallback callback, IntPtr context);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XErrorSetOptions(XErrorOptions optionsDebuggerPresent, XErrorOptions optionsDebuggerNotPresent);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameEventWrite(IntPtr user, [MarshalAs(UnmanagedType.LPStr)] string serviceConfigId, [MarshalAs(UnmanagedType.LPStr)] string playSessionId, [MarshalAs(UnmanagedType.LPStr)] string eventName, [MarshalAs(UnmanagedType.LPStr)] string dimensionsJson, [MarshalAs(UnmanagedType.LPStr)] string measurementsJson);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameGetXboxTitleId(out uint titleId);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XLaunchNewGame([MarshalAs(UnmanagedType.LPStr)] string exePath, [MarshalAs(UnmanagedType.LPStr)] string args, IntPtr defaultUser);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XLaunchRestartOnCrash([MarshalAs(UnmanagedType.LPStr)] string args, uint reserved);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameInviteRegisterForEvent(IntPtr queue, IntPtr context, XGameInviteEventCallback callback, out ulong token);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XGameInviteUnregisterForEvent(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameProtocolRegisterForActivation(IntPtr queue, IntPtr context, XGameProtocolActivationCallback callback, out ulong token);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XGameProtocolUnregisterForActivation(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern bool XGameRuntimeIsFeatureAvailable(XGameRuntimeFeature feature);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameRuntimeInitialize();

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameRuntimeInitializeWithOptions(XGameRuntimeOptions options);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XGameRuntimeUninitialize();

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveFilesGetFolderWithUiAsync(IntPtr requestingUser, [MarshalAs(UnmanagedType.LPStr)] string configurationId, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveFilesGetFolderWithUiResult(IntPtr async, ulong folderSize, StringBuilder folderResult);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveFilesGetRemainingQuota(IntPtr userContext, [MarshalAs(UnmanagedType.LPStr)] string configurationId, out ulong remainingQuota);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveInitializeProvider(IntPtr requestingUser, [MarshalAs(UnmanagedType.LPStr)] string configurationId, [MarshalAs(UnmanagedType.I1)] bool syncOnDemand, out IntPtr provider);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveInitializeProviderAsync(IntPtr requestingUser, [MarshalAs(UnmanagedType.LPStr)] string configurationId, [MarshalAs(UnmanagedType.I1)] bool syncOnDemand, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveInitializeProviderResult(IntPtr async, out IntPtr provider);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XGameSaveCloseProvider(IntPtr provider);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveGetRemainingQuota(IntPtr provider, out long remainingQuota);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveGetRemainingQuotaAsync(IntPtr provider, IntPtr xAsyncBlockInterop);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveGetRemainingQuotaResult(IntPtr async, out long remainingQuota);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveDeleteContainer(IntPtr provider, [MarshalAs(UnmanagedType.LPStr)] string containerName);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveDeleteContainerAsync(IntPtr provider, [MarshalAs(UnmanagedType.LPStr)] string containerName, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveDeleteContainerResult(IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveGetContainerInfo(IntPtr provider, [MarshalAs(UnmanagedType.LPStr)] string containerName, IntPtr context, XGameSaveContainerInfoCallback callback);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveEnumerateContainerInfo(IntPtr provider, IntPtr context, XGameSaveContainerInfoCallback callback);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveEnumerateContainerInfoByName(IntPtr provider, [MarshalAs(UnmanagedType.LPStr)] string containerNamePrefix, IntPtr context, XGameSaveContainerInfoCallback callback);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveCreateContainer(IntPtr provider, [MarshalAs(UnmanagedType.LPStr)] string containerName, out IntPtr containerContext);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XGameSaveCloseContainer(IntPtr context);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveEnumerateBlobInfo(IntPtr container, IntPtr context, XGameSaveBlobInfoCallback callback);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveEnumerateBlobInfoByName(IntPtr container, [MarshalAs(UnmanagedType.LPStr)] string blobNamePrefix, IntPtr context, XGameSaveBlobInfoCallback callback);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveReadBlobData(IntPtr container, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 2)] string[] blobNames, ref uint countOfBlobs, ulong blobsSize, IntPtr blobData);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveReadBlobDataAsync(IntPtr container, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 2)] string[] blobNames, uint countOfBlobs, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveReadBlobDataResult(IntPtr async, ulong blobsSize, IntPtr blobData, out uint countOfBlobs);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveCreateUpdate(IntPtr container, [MarshalAs(UnmanagedType.LPStr)] string containerDisplayName, out IntPtr updateContext);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveCloseUpdate(IntPtr context);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveSubmitBlobWrite(IntPtr updateContext, [MarshalAs(UnmanagedType.LPStr)] string blobName, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] data, ulong byteCount);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveSubmitBlobDelete(IntPtr updateContext, [MarshalAs(UnmanagedType.LPStr)] string blobName);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveSubmitUpdate(IntPtr updateContext);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveSubmitUpdateAsync(IntPtr updateContext, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameSaveSubmitUpdateResult(IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingInitialize();

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XGameStreamingUninitialize();

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XGameStreamingIsStreaming();

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern uint XGameStreamingGetClientCount();

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingGetClients(uint clientCount, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] XGameStreamingClientId[] clients, out uint clientUsed);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern XGameStreamingConnectionState XGameStreamingGetConnectionState(XGameStreamingClientId client);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingRegisterConnectionStateChanged(IntPtr queue, IntPtr context, XGameStreamingConnectionStateChangedCallback callback, out ulong token);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XGameStreamingUnregisterConnectionStateChanged(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XGameStreamingHideTouchControls();

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XGameStreamingHideTouchControlsOnClient(XGameStreamingClientId client);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XGameStreamingShowTouchControlLayout([MarshalAs(UnmanagedType.LPStr)] string layout);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XGameStreamingShowTouchControlLayoutOnClient(XGameStreamingClientId client, [MarshalAs(UnmanagedType.LPStr)] string layout);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingRegisterClientPropertiesChanged(XGameStreamingClientId client, IntPtr queue, IntPtr context, XGameStreamingClientPropertiesChangedCallback callback, out ulong token);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XGameStreamingUnregisterClientPropertiesChanged(XGameStreamingClientId client, ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingGetStreamPhysicalDimensions(XGameStreamingClientId client, out uint horizontalMm, out uint verticalMm);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingGetStreamAddedLatency(XGameStreamingClientId client, out uint averageInputLatencyUs, out uint averageOutputLatencyUs, out uint standardDeviationUs);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern ulong XGameStreamingGetServerLocationNameSize();

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingGetServerLocationName(ulong serverLocationNameSize, StringBuilder serverLocationName);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingIsTouchInputEnabled(XGameStreamingClientId client, [MarshalAs(UnmanagedType.I1)] out bool touchInputEnabled);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingGetLastFrameDisplayed(XGameStreamingClientId client, out ulong framePipelineToken);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingGetAssociatedFrame(IntPtr gamepadReading, out ulong framePipelineToken);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingGetGamepadPhysicality(IntPtr gamepadReading, out XGameStreamingGamepadPhysicality gamepadPhysicality);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingUpdateTouchControlsState(ulong operationCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] XGameStreamingTouchControlsStateOperation[] operations);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingUpdateTouchControlsStateOnClient(XGameStreamingClientId client, ulong operationCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XGameStreamingTouchControlsStateOperation[] operations);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingShowTouchControlsWithStateUpdate([MarshalAs(UnmanagedType.LPStr)] string layout, ulong operatoinCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XGameStreamingTouchControlsStateOperation[] operations);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingShowTouchControlsWithStateUpdateOnClient(XGameStreamingClientId client, [MarshalAs(UnmanagedType.LPStr)] string layout, ulong operationCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] XGameStreamingTouchControlsStateOperation[] operations);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern ulong XGameStreamingGetTouchBundleVersionNameSize(XGameStreamingClientId client);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingGetTouchBundleVersion(XGameStreamingClientId client, out XVersion version, ulong versionNameSize, StringBuilder versionName);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingGetClientIPAddress(XGameStreamingClientId client, ulong ipAddressSize, StringBuilder ipAddress);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingGetSessionId(XGameStreamingClientId client, ulong sessionIdSize, StringBuilder sessionId, out ulong sessionIdUsed);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingGetDisplayDetails(XGameStreamingClientId clientId, uint maxSupportedPixels, float widestSupportedAspectRatio, float tallestSupportedAspectRatio, out XGameStreamingDisplayDetails displayDetails);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameStreamingSetResolution(uint width, uint height);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowMessageDialogAsync(IntPtr async, [MarshalAs(UnmanagedType.LPStr)] string titleText, [MarshalAs(UnmanagedType.LPStr)] string contextText, [MarshalAs(UnmanagedType.LPStr)] string firstButtonText, [MarshalAs(UnmanagedType.LPStr)] string secondButtonText, [MarshalAs(UnmanagedType.LPStr)] string thirdButtonText, XGameUiMessageDialogButton defaultButton, XGameUiMessageDialogButton cancelButton);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowMessageDialogResult(IntPtr async, out XGameUiMessageDialogButton resultButton);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowSendGameInviteAsync(IntPtr async, IntPtr requestingUser, [MarshalAs(UnmanagedType.LPStr)] string sessionConfigurationId, [MarshalAs(UnmanagedType.LPStr)] string sessionTemplateName, [MarshalAs(UnmanagedType.LPStr)] string sessionId, [MarshalAs(UnmanagedType.LPStr)] string invitationText, [MarshalAs(UnmanagedType.LPStr)] string customActivationContext);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowSendGameInviteResult(IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowMultiplayerActivityGameInviteAsync(IntPtr async, IntPtr requestingUser);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowMultiplayerActivityGameInviteResult(IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowPlayerProfileCardAsync(IntPtr async, IntPtr requestingUser, ulong targetPlayer);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowPlayerProfileCardResult(IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowAchievementsAsync(IntPtr async, IntPtr requestingUser, uint titleId);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowAchievementsResult(IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowPlayerPickerAsync(IntPtr async, IntPtr requestingUser, [MarshalAs(UnmanagedType.LPStr)] string promptText, uint selectFromPlayersCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ulong[] selectFromPlayers, uint preSelectedPlayersCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] ulong[] preSelectedPlayers, uint minSelectionCount, uint maxSelectionCount);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowPlayerPickerResultCount(IntPtr async, out uint resultPlayersCount);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowPlayerPickerResult(IntPtr async, uint resultPlayersCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ulong[] resultPlayers, out uint resultPlayerUsed);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowErrorDialogAsync(IntPtr async, int errorCode, [MarshalAs(UnmanagedType.LPStr)] string context);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowErrorDialogResult(IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiSetNotificationPositionHint(XGameUiNotificationPositionHint position);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowTextEntryAsync(IntPtr async, [MarshalAs(UnmanagedType.LPStr)] string titleText, [MarshalAs(UnmanagedType.LPStr)] string descriptionText, [MarshalAs(UnmanagedType.LPStr)] string defaultText, XGameUiTextEntryInputScope inputScope, uint maxTextLength);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowTextEntryResultSize(IntPtr async, out uint resultTextBufferSize);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowTextEntryResult(IntPtr async, uint resultTextBufferSize, StringBuilder resultTextBuffer, out uint resultTextBufferUsed);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowWebAuthenticationAsync(IntPtr async, IntPtr requestingUser, [MarshalAs(UnmanagedType.LPStr)] string requestUri, [MarshalAs(UnmanagedType.LPStr)] string completionUri);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowWebAuthenticationWithOptionsAsync(IntPtr async, IntPtr requestingUser, [MarshalAs(UnmanagedType.LPStr)] string requestUri, [MarshalAs(UnmanagedType.LPStr)] string completionUri, XGameUiWebAuthenticationOptions options);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowWebAuthenticationResult(IntPtr asyncblock, ulong bufferSize, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] buffer, out IntPtr ptrToBuffer, out ulong bufferUsed);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiShowWebAuthenticationResultSize(IntPtr async, out ulong bufferSize);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiTextEntryOpen(XGameUiTextEntryOptions options, uint maxLength, [MarshalAs(UnmanagedType.LPStr)] string initialText, uint cursorIndex, out IntPtr handle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XGameUiTextEntryClose(IntPtr handle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiTextEntryGetExtents(IntPtr handle, out XGameUiTextEntryExtents extents);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiTextEntryGetState(IntPtr handle, out XGameUiTextEntryChangeTypeFlags changeType, out uint cursorIndex, out uint imeClauseStartIndex, out uint imeClauseEndIndex, uint bufferSize, StringBuilder buffer);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiTextEntryUpdatePositionHint(IntPtr handle, XGameUiTextEntryPositionHint positionHint);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XGameUiTextEntryUpdateVisibility(IntPtr handle, XGameUiTextEntryVisibilityFlags visibilityFlags);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XLaunchUri(IntPtr requestingUser, [MarshalAs(UnmanagedType.LPStr)] string uri);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XNetworkingGetConnectivityHint(out XNetworkingConnectivityHint connectivityHint);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XNetworkingQueryConfigurationSetting(XNetworkingConfigurationSetting configurationSetting, out ulong value);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XNetworkingQueryPreferredLocalUdpMultiplayerPort(out ushort value);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XNetworkingQueryPreferredLocalUdpMultiplayerPortAsync(IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XNetworkingQueryPreferredLocalUdpMultiplayerPortAsyncResult(IntPtr async, out ushort preferredLocalUdpMultiplayerPort);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XNetworkingQuerySecurityInformationForUrlAsync([MarshalAs(UnmanagedType.LPStr)] string url, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XNetworkingQuerySecurityInformationForUrlAsyncResultSize(IntPtr async, out ulong securityInformationBufferByteCount);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XNetworkingQuerySecurityInformationForUrlAsyncResult(IntPtr async, ulong securityInformationBufferByteCount, out ulong securityInformationBufferByteCountUsed, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] securityInformationBuffer, out IntPtr securityInformation);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XNetworkingQuerySecurityInformationForUrlUtf16Async([MarshalAs(UnmanagedType.LPWStr)] string url, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XNetworkingQuerySecurityInformationForUrlUtf16AsyncResultSize(IntPtr async, out ulong securityInformationBufferByteCount);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XNetworkingQuerySecurityInformationForUrlUtf16AsyncResult(IntPtr async, ulong securityInformationBufferByteCount, out ulong securityInformationBufferByteCountUsed, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] securityInformationBuffer, out IntPtr securityInformation);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XNetworkingQueryStatistics(XNetworkingStatisticsType statisticsType, out XNetworkingStatisticsBuffer statisticsBuffer);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XNetworkingRegisterConnectivityHintChanged(IntPtr taskQueueHandle, IntPtr context, XNetworkingConnectivityHintChangedCallback callback, out ulong registrationToken);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XNetworkingUnregisterConnectivityHintChanged(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XNetworkingRegisterPreferredLocalUdpMultiplayerPortChanged(IntPtr taskQueueHandle, IntPtr context, XNetworkingPreferredLocalUdpMultiplayerPortChangedCallback callback, out ulong registrationToken);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XNetworkingUnregisterPreferredLocalUdpMultiplayerPortChanged(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XNetworkingVerifyServerCertificate(IntPtr requestHandle, IntPtr securityInformation);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageCreateInstallationMonitor([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, uint selectorCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XPackageChunkSelectorInterop[] selectors, uint minimumUpdateIntervalMs, IntPtr queue, out IntPtr installationMonitor);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XPackageCloseInstallationMonitorHandle(IntPtr installationMonitor);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageGetCurrentProcessPackageIdentifier(ulong bufferSize, StringBuilder buffer);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XPackageIsPackagedProcess();

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XPackageGetInstallationProgress(IntPtr installationMonitor, out XPackageInstallationProgress progress);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XPackageUpdateInstallationMonitor(IntPtr installationMonitor);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageGetUserLocale(ulong localeSize, StringBuilder locale);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageFindChunkAvailability([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, uint selectorCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XPackageChunkSelectorInterop[] selectors, out XPackageChunkAvailability availability);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageChangeChunkInstallOrder([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, uint selectorCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XPackageChunkSelectorInterop[] selectors);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageInstallChunks([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, uint selectorCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XPackageChunkSelectorInterop[] selectors, uint minimumUpdateIntervalMs, [MarshalAs(UnmanagedType.I1)] bool suppressUserConfirmation, IntPtr queue, out IntPtr installationMonitor);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageInstallChunksAsync([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, uint selectorCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XPackageChunkSelectorInterop[] selectors, uint minimumUpdateIntervalMs, [MarshalAs(UnmanagedType.I1)] bool suppressUserConfirmation, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageInstallChunksResult(IntPtr asyncBlock, out IntPtr installationMonitor);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageEstimateDownloadSize([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, uint selectorCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XPackageChunkSelectorInterop[] selectors, out ulong downloadSize, [MarshalAs(UnmanagedType.I1)] out bool shouldPresentUserConfirmation);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageUninstallChunks([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, uint selectorCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XPackageChunkSelectorInterop[] selectors);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XPackageCloseMountHandle(IntPtr mount);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageEnumerateChunkAvailability([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, XPackageChunkSelectorType type, IntPtr context, XPackageChunkAvailabilityCallback callback);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageEnumerateFeatures([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, IntPtr context, XPackageFeatureEnumerationCallbackInterop callback);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageEnumeratePackages(XPackageKind kind, XPackageEnumerationScope scope, IntPtr context, XPackageEnumerationCallback callback);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageGetMountPathSize(IntPtr mount, out ulong pathSize);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageGetMountPath(IntPtr mount, ulong pathSize, StringBuilder path);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageGetWriteStats(out XPackageWriteStats writeStats);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageMountWithUiAsync([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageMountWithUiResult(IntPtr async, out IntPtr mount);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageRegisterInstallationProgressChanged(IntPtr installationMonitor, IntPtr context, XPackageInstallationProgressCallback callback, out ulong token);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageRegisterPackageInstalled(IntPtr queue, IntPtr context, XPackageInstalledCallback callback, out ulong token);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPackageUninstallUWPInstance([MarshalAs(UnmanagedType.LPStr)] string packageName);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XPackageUninstallPackage([MarshalAs(UnmanagedType.LPStr)] string packageIdentifier);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XPackageUnregisterInstallationProgressChanged(IntPtr installationMonitor, ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XPackageUnregisterPackageInstalled(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPersistentLocalStorageGetPathSize(out ulong pathSize);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPersistentLocalStorageGetPath(ulong pathSize, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] path, out ulong pathUsed);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPersistentLocalStorageGetSpaceInfo(out XPersistentLocalStorageSpaceInfo spaceInfo);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPersistentLocalStoragePromptUserForSpaceAsync(ulong requestedBytes, IntPtr asyncBlock);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XPersistentLocalStoragePromptUserForSpaceResult(IntPtr asyncBlock);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSpeechSynthesizerEnumerateInstalledVoices(IntPtr context, XSpeechSynthesizerInstalledVoicesCallback callback);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSpeechSynthesizerCreate(out IntPtr speechSynthesizer);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSpeechSynthesizerCloseHandle(IntPtr speechSynthesizer);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSpeechSynthesizerSetDefaultVoice(IntPtr speechSynthesizer);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSpeechSynthesizerSetCustomVoice(IntPtr speechSynthesizer, [MarshalAs(UnmanagedType.LPStr)] string voiceId);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSpeechSynthesizerCreateStreamFromText(IntPtr speechSynthesizer, [MarshalAs(UnmanagedType.LPStr)] string text, out IntPtr speechSynthesisStream);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSpeechSynthesizerCreateStreamFromSsml(IntPtr speechSynthesizer, [MarshalAs(UnmanagedType.LPStr)] string ssml, out IntPtr speechSynthesisStream);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSpeechSynthesizerCloseStreamHandle(IntPtr speechSynthesisStream);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSpeechSynthesizerGetStreamDataSize(IntPtr speechSynthesisStream, out ulong bufferSize);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSpeechSynthesizerGetStreamData(IntPtr speechSynthesisStream, ulong bufferSize, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] buffer, out ulong bufferUsed);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreCreateContext(IntPtr user, out IntPtr storeContextHandle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XStoreCloseContextHandle(IntPtr storeContextHandle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XStoreCloseLicenseHandle(IntPtr storeLicenseHandle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreAcquireLicenseForDurablesAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string storeId, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreAcquireLicenseForDurablesResult(IntPtr async, out IntPtr storeLicenseHandle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreAcquireLicenseForPackageAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreAcquireLicenseForPackageResult(IntPtr async, out IntPtr storeLicenseHandle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreCanAcquireLicenseForStoreIdAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string storeProductId, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreCanAcquireLicenseForStoreIdResult(IntPtr async, out XStoreCanAcquireLicenseResult storeCanAcquireLicenseResult);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreCanAcquireLicenseForPackageAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreCanAcquireLicenseForPackageResult(IntPtr async, out XStoreCanAcquireLicenseResult storeCanAcquireLicenseResult);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryProductForCurrentGameAsync(IntPtr storeContextHandle, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryProductForCurrentGameResult(IntPtr async, out IntPtr productQueryHandle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreEnumerateProductsQuery(IntPtr productQueryHandle, IntPtr context, XStoreProductQueryCallbackInterop callback);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XStoreCloseProductsQueryHandle(IntPtr productQueryHandle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreDownloadPackageUpdatesAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 2)] string[] packageIdentifiers, ulong packageIdentifiersCount, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreDownloadPackageUpdatesResult(IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreDownloadAndInstallPackageUpdatesAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 2)] string[] packageIdentifiers, ulong packageIdentifiersCount, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreDownloadAndInstallPackageUpdatesResult(IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreDownloadAndInstallPackagesAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 2)] string[] storeIds, ulong storeIdsCount, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreDownloadAndInstallPackagesResultCount(IntPtr async, out uint count);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreDownloadAndInstallPackagesResult(IntPtr async, uint count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XStorePackageIdentifierInterop[] identifiers);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreGetUserCollectionsIdAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string serviceTicket, [MarshalAs(UnmanagedType.LPStr)] string publisherUserId, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreGetUserCollectionsIdResultSize(IntPtr async, out ulong size);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreGetUserCollectionsIdResult(IntPtr async, ulong size, StringBuilder result);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreGetUserPurchaseIdAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string serviceTicket, [MarshalAs(UnmanagedType.LPStr)] string publisherUserId, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreGetUserPurchaseIdResultSize(IntPtr async, out ulong size);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreGetUserPurchaseIdResult(IntPtr async, ulong size, StringBuilder result);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XStoreIsAvailabilityPurchasable(XStoreAvailability availability);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XStoreIsLicenseValid(IntPtr storeLicenseHandle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XStoreProductsQueryHasMorePages(IntPtr productQueryHandle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreProductsQueryNextPageAsync(IntPtr productQueryHandle, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreProductsQueryNextPageResult(IntPtr async, out IntPtr productQueryHandle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryAddOnLicensesAsync(IntPtr storeContextHandle, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryAddOnLicensesResultCount(IntPtr async, out uint count);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryAddOnLicensesResult(IntPtr async, uint count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XStoreAddonLicense[] addOnLicenses);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryAssociatedProductsAsync(IntPtr storeContextHandle, XStoreProductKind productKinds, uint maxItemsToRetrievePerPage, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryAssociatedProductsResult(IntPtr async, out IntPtr productQueryHandle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryConsumableBalanceRemainingAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string storeProductId, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryConsumableBalanceRemainingResult(IntPtr async, out XStoreConsumableResult consumableResult);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryEntitledProductsAsync(IntPtr storeContextHandle, XStoreProductKind productKinds, uint maxItemsToRetrievePerPage, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryEntitledProductsResult(IntPtr async, out IntPtr productQueryHandle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryGameAndDlcPackageUpdatesAsync(IntPtr storeContextHandle, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryGameAndDlcPackageUpdatesResultCount(IntPtr async, out uint count);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryGameAndDlcPackageUpdatesResult(IntPtr async, uint count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] XStorePackageUpdate[] packageUpdates);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryGameLicenseAsync(IntPtr storeContextHandle, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryGameLicenseResult(IntPtr async, out XStoreGameLicense license);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryLicenseTokenAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 1)] string[] productIds, ulong productIdsCount, [MarshalAs(UnmanagedType.LPStr)] string customDeveloperString, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryLicenseTokenResultSize(IntPtr async, out ulong size);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryLicenseTokenResult(IntPtr async, ulong size, StringBuilder result);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryPackageIdentifier([MarshalAs(UnmanagedType.LPStr)] string storeId, ulong size, StringBuilder packageIdentifier);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryProductForPackageAsync(IntPtr storeContextHandle, XStoreProductKind productKinds, [MarshalAs(UnmanagedType.LPStr)] string packageIdentifier, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryProductForPackageResult(IntPtr async, out IntPtr productQueryHandle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryProductsAsync(IntPtr storeContextHandle, XStoreProductKind productKinds, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 3)] string[] storeIds, ulong storeIdsCount, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 5)] string[] actionFilters, ulong actionFiltersCount, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreQueryProductsResult(IntPtr async, out IntPtr productQueryHandle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreRegisterGameLicenseChanged(IntPtr storeContextHandle, IntPtr queue, IntPtr context, XStoreGameLicenseChangedCallback callback, out ulong token);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XStoreUnregisterGameLicenseChanged(IntPtr storeContextHandle, ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreRegisterPackageLicenseLost(IntPtr licenseHandle, IntPtr queue, IntPtr context, XStorePackageLicenseLostCallback callback, out ulong token);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XStoreUnregisterPackageLicenseLost(IntPtr licenseHandle, ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreReportConsumableFulfillmentAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string storeProductId, uint quantity, Guid trackingId, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreReportConsumableFulfillmentResult(IntPtr async, out XStoreConsumableResult consumableResult);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreShowAssociatedProductsUIAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string storeId, XStoreProductKind productKinds, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreShowAssociatedProductsUIResult(IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreShowProductPageUIAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string storeId, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreShowProductPageUIResult(IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreShowPurchaseUIAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string storeId, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string extendedJsonData, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreShowPurchaseUIResult(IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreShowRateAndReviewUIAsync(IntPtr storeContextHandle, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreShowRateAndReviewUIResult(IntPtr async, out XStoreRateAndReviewResult result);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreShowRedeemTokenUIAsync(IntPtr storeContextHandle, [MarshalAs(UnmanagedType.LPStr)] string token, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr, SizeParamIndex = 3)] string[] allowedStoreIds, ulong allowedStoreIdsCount, [MarshalAs(UnmanagedType.I1)] bool disallowCsvRedemption, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XStoreShowRedeemTokenUIResult(IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XSystemGetAnalyticsInfo(out XSystemAnalyticsInfo info);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSystemGetAppSpecificDeviceId(ulong appSpecificDeviceIdSize, StringBuilder appSpecificDeviceId, out ulong appSpecificDeviceIdUsed);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSystemGetConsoleId(ulong consoleIdSize, StringBuilder consoleId, out ulong consoleIdUsed);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern XSystemDeviceType XSystemGetDeviceType();

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSystemGetXboxLiveSandboxId(ulong sandboxIdSize, StringBuilder sandboxId, out ulong sandboxIdUsed);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern XSystemRuntimeInfo XSystemGetRuntimeInfo();

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XSystemIsHandleValid(IntPtr handle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XSystemHandleTrack(XSystemHandleCallback callback, IntPtr context);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XTaskQueueCloseHandle(IntPtr queue);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XTaskQueueCreate(XTaskQueueDispatchMode workDispatchMode, XTaskQueueDispatchMode completionDispatchMode, out IntPtr queue);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XTaskQueueCreateComposite(IntPtr workPort, IntPtr completionPort, out IntPtr queue);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XTaskQueueDispatch(IntPtr queue, XTaskQueuePort port, uint timeoutInMs);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XTaskQueueDuplicateHandle(IntPtr queueHandle, out IntPtr duplicatedHandle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XTaskQueueGetCurrentProcessTaskQueue(out IntPtr queue);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XTaskQueueGetPort(IntPtr queue, XTaskQueuePort port, out IntPtr portHandle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XTaskQueueRegisterMonitor(IntPtr queue, IntPtr callbackContext, XTaskQueueMonitorCallback callback, out ulong token);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XTaskQueueRegisterWaiter(IntPtr queue, XTaskQueuePort port, SafeWaitHandle waitHandle, IntPtr callbackContext, XTaskQueueCallback callback, out ulong token);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XTaskQueueSetCurrentProcessTaskQueue(IntPtr queue);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XTaskQueueSubmitCallback(IntPtr queue, XTaskQueuePort port, IntPtr callbackContext, XTaskQueueCallback callback);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XTaskQueueSubmitDelayedCallback(IntPtr queue, XTaskQueuePort port, uint delayMs, IntPtr callbackContext, XTaskQueueCallback callback);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XTaskQueueTerminate(IntPtr queue, [MarshalAs(UnmanagedType.I1)] bool wait, IntPtr callbackContext, XTaskQueueTerminatedCallback callback);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XTaskQueueUnregisterMonitor(IntPtr queue, ulong token);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XTaskQueueUnregisterWaiter(IntPtr queue, ulong token);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XThreadAssertNotTimeSensitive();

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XThreadIsTimeSensitive();

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XThreadSetTimeSensitive([MarshalAs(UnmanagedType.I1)] bool isTimeSensitiveThread);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserAddAsync(XUserAddOptions options, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserAddResult(IntPtr async, out IntPtr newUser);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserAddByIdWithUiAsync(ulong userId, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserAddByIdWithUiResult(IntPtr async, out IntPtr newUser);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserCheckPrivilege(IntPtr user, XUserPrivilegeOptions options, XUserPrivilege privilege, [MarshalAs(UnmanagedType.I1)] out bool hasPrivilege, out XUserPrivilegeDenyReason reason);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XUserCloseHandle(IntPtr user);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern void XUserCloseSignOutDeferralHandle(IntPtr deferral);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserCompare(IntPtr user1, IntPtr user2);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserDuplicateHandle(IntPtr handle, out IntPtr duplicatedHandle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserFindControllerForUserWithUiAsync(IntPtr user, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserFindControllerForUserWithUiResult(IntPtr async, out APP_LOCAL_DEVICE_ID deviceId);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserFindForDevice(ref APP_LOCAL_DEVICE_ID deviceId, out IntPtr handle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserFindUserById(ulong userId, out IntPtr handle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserFindUserByLocalId(XUserLocalId userLocalId, out IntPtr handle);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserGetAgeGroup(IntPtr user, out XUserAgeGroup ageGroup);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
	internal static extern int XUserGetDefaultAudioEndpointUtf16(XUserLocalId user, XUserDefaultAudioEndpointKind defaultAudioEndpointKind, ulong endpointIdUtf16Count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] char[] endpointIdUtf16, out ulong endpointIdUtf16Used);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserGetGamerPictureAsync(IntPtr user, XUserGamerPictureSize pictureSize, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserGetGamerPictureResultSize(IntPtr async, out ulong bufferSize);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserGetGamerPictureResult(IntPtr async, ulong bufferSize, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] buffer, out ulong bufferUsed);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserGetGamertag(IntPtr user, XUserGamertagComponent gamertagComponent, ulong gamertagSize, StringBuilder gamertag, out ulong gamertagUsed);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserGetId(IntPtr user, out ulong userId);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserGetIsGuest(IntPtr user, [MarshalAs(UnmanagedType.I1)] out bool isGuest);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserGetLocalId(IntPtr user, out XUserLocalId userLocalId);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserGetMaxUsers(out uint maxUsers);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserGetSignOutDeferral(out IntPtr deferral);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserGetState(IntPtr user, out XUserState state);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserGetTokenAndSignatureAsync(IntPtr user, XUserGetTokenAndSignatureOptions options, [MarshalAs(UnmanagedType.LPStr)] string method, [MarshalAs(UnmanagedType.LPStr)] string url, ulong headerCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] XUserGetTokenAndSignatureHttpHeader[] headers, ulong bodySize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] byte[] bodyBuffer, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserGetTokenAndSignatureResultSize(IntPtr async, out ulong bufferSize);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserGetTokenAndSignatureResult(IntPtr async, ulong bufferSize, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] buffer, out IntPtr ptrToBuffer, out ulong bufferUsed);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserGetTokenAndSignatureUtf16Async(IntPtr user, XUserGetTokenAndSignatureOptions options, [MarshalAs(UnmanagedType.LPWStr)] string method, [MarshalAs(UnmanagedType.LPWStr)] string url, ulong headerCount, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] XUserGetTokenAndSignatureUtf16HttpHeader[] headers, ulong bodySize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] byte[] bodyBuffer, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserGetTokenAndSignatureUtf16ResultSize(IntPtr async, out ulong bufferSize);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserGetTokenAndSignatureUtf16Result(IntPtr async, ulong bufferSize, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] buffer, out IntPtr ptrToBuffer, out ulong bufferUsed);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XUserIsStoreUser(IntPtr user);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserRegisterForChangeEvent(IntPtr queue, IntPtr context, XUserChangeEventCallback callback, out ulong token);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserRegisterForDefaultAudioEndpointUtf16Changed(IntPtr queue, IntPtr context, XUserDefaultAudioEndpointUtf16ChangedCallback callback, out ulong token);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserRegisterForDeviceAssociationChanged(IntPtr queue, IntPtr context, XUserDeviceAssociationChangedCallback callback, out ulong token);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserResolveIssueWithUiAsync(IntPtr user, [MarshalAs(UnmanagedType.LPStr)] string url, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserResolveIssueWithUiResult(IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserResolveIssueWithUiUtf16Async(IntPtr user, [MarshalAs(UnmanagedType.LPWStr)] string url, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserResolveIssueWithUiUtf16Result(IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserResolvePrivilegeWithUiAsync(IntPtr user, XUserPrivilegeOptions options, XUserPrivilege privilege, IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	internal static extern int XUserResolvePrivilegeWithUiResult(IntPtr async);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XUserUnregisterForChangeEvent(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XUserUnregisterForDefaultAudioEndpointUtf16Changed(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);

	[DllImport("XGameRuntime.Thunks", CallingConvention = CallingConvention.StdCall)]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static extern bool XUserUnregisterForDeviceAssociationChanged(ulong token, [MarshalAs(UnmanagedType.I1)] bool wait);
}
