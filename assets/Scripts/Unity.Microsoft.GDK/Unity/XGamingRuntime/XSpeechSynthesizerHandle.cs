using System;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XSpeechSynthesizerHandle : EquatableHandle
{
	public int CloseResult { get; private set; }

	public override bool IsInvalid => handle == IntPtr.Zero;

	public XSpeechSynthesizerHandle(IntPtr handle)
		: base(IntPtr.Zero, ownsHandle: true, handle)
	{
	}

	protected override bool ReleaseHandle()
	{
		CloseResult = NativeMethods.XSpeechSynthesizerCloseHandle(handle);
		SetHandle(IntPtr.Zero);
		return Unity.XGamingRuntime.Interop.HR.SUCCEEDED(CloseResult);
	}
}
