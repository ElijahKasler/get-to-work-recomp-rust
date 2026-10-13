using System;
using Rewired.Utils.Classes.Data;

namespace Rewired.Utils.Classes.Utility;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal class LowLevelInputEventQueue : IDisposable
{
	private LowLevelInputEvent MzFXJDVDViEGnnIerIecubXhBcXJ;

	private readonly NativeRingBuffer aKEBRnVvzXFxbFHKLbcCrIKilQdbb;

	private readonly int nfVySUvBWivZoLWEdbyxKajiLWXK;

	private readonly int qmdfEnklRWHOgXYWoAJqilDhWmfMB;

	private readonly int iILsPkoZAPPgCJHvgznVAcVQjDAE;

	private readonly int BCXjGGKBdIVpzpDZoDAdoQpxmHeYA;

	private readonly int ZCtdCEBSdYZZKWgSpCKWVhnvWQJi;

	private uint gHHyJkJmKMprfVkpzyKfsfniamAT;

	private bool GCcsTYbyXdUWevwNTwpEWgOQTfol;

	public int Count => aKEBRnVvzXFxbFHKLbcCrIKilQdbb.BytesInBuffer / BCXjGGKBdIVpzpDZoDAdoQpxmHeYA;

	public int Capacity => ZCtdCEBSdYZZKWgSpCKWVhnvWQJi;

	public LowLevelInputEvent this[int index] => new LowLevelInputEvent(aKEBRnVvzXFxbFHKLbcCrIKilQdbb.GetPointerFromReadPosition(index * BCXjGGKBdIVpzpDZoDAdoQpxmHeYA), nfVySUvBWivZoLWEdbyxKajiLWXK, qmdfEnklRWHOgXYWoAJqilDhWmfMB, iILsPkoZAPPgCJHvgznVAcVQjDAE);

	public LowLevelInputEventQueue(int P_0, int P_1, int P_2, int P_3)
	{
		ZCtdCEBSdYZZKWgSpCKWVhnvWQJi = P_0;
		nfVySUvBWivZoLWEdbyxKajiLWXK = P_1;
		qmdfEnklRWHOgXYWoAJqilDhWmfMB = P_2;
		iILsPkoZAPPgCJHvgznVAcVQjDAE = P_3;
		BCXjGGKBdIVpzpDZoDAdoQpxmHeYA = LowLevelInputEvent.GetReportSize(P_1, P_2, P_3);
		aKEBRnVvzXFxbFHKLbcCrIKilQdbb = new NativeRingBuffer(ZCtdCEBSdYZZKWgSpCKWVhnvWQJi * BCXjGGKBdIVpzpDZoDAdoQpxmHeYA);
		MzFXJDVDViEGnnIerIecubXhBcXJ = new LowLevelInputEvent(IntPtr.Zero, nfVySUvBWivZoLWEdbyxKajiLWXK, qmdfEnklRWHOgXYWoAJqilDhWmfMB, P_3);
	}

	public LowLevelInputEvent CreateEvent()
	{
		IntPtr intPtr = aKEBRnVvzXFxbFHKLbcCrIKilQdbb.Allocate(BCXjGGKBdIVpzpDZoDAdoQpxmHeYA, zeroFill: false, out var _);
		LowLevelInputEvent result = new LowLevelInputEvent(intPtr, nfVySUvBWivZoLWEdbyxKajiLWXK, qmdfEnklRWHOgXYWoAJqilDhWmfMB, iILsPkoZAPPgCJHvgznVAcVQjDAE);
		result.SetId(gHHyJkJmKMprfVkpzyKfsfniamAT = MiscTools.Tick(gHHyJkJmKMprfVkpzyKfsfniamAT));
		return result;
	}

	public int FindNextIndex(uint id)
	{
		int num = aKEBRnVvzXFxbFHKLbcCrIKilQdbb.BytesInBuffer / BCXjGGKBdIVpzpDZoDAdoQpxmHeYA;
		if (num == 0)
		{
			return -1;
		}
		MzFXJDVDViEGnnIerIecubXhBcXJ._buffer = aKEBRnVvzXFxbFHKLbcCrIKilQdbb.GetPointerFromReadPosition(0);
		uint num2 = MzFXJDVDViEGnnIerIecubXhBcXJ.GetId();
		int num3 = 0;
		if (MiscTools.IsTickNewer(id, num2))
		{
			num3 = (int)MiscTools.TickDifference(id, num2) + 1;
			num2 = MiscTools.Tick(id);
		}
		for (int i = num3; i < num; i++)
		{
			if (!MiscTools.IsTickNewer(num2, id))
			{
				num2 = MiscTools.Tick(num2);
				continue;
			}
			return i;
		}
		return -1;
	}

	public bool TryGetNext(int index, out LowLevelInputEvent @event)
	{
		if (index < 0 || index >= aKEBRnVvzXFxbFHKLbcCrIKilQdbb.BytesInBuffer / BCXjGGKBdIVpzpDZoDAdoQpxmHeYA)
		{
			@event = default;
			return false;
		}
		@event = new LowLevelInputEvent(aKEBRnVvzXFxbFHKLbcCrIKilQdbb.GetPointerFromReadPosition(index * BCXjGGKBdIVpzpDZoDAdoQpxmHeYA), nfVySUvBWivZoLWEdbyxKajiLWXK, qmdfEnklRWHOgXYWoAJqilDhWmfMB, iILsPkoZAPPgCJHvgznVAcVQjDAE);
		return true;
	}

	public void Clear()
	{
		aKEBRnVvzXFxbFHKLbcCrIKilQdbb.Reset();
	}

	public void CopyAllFrom(LowLevelInputEventQueue other)
	{
		if (other == null)
		{
			throw new ArgumentNullException("other");
		}
		aKEBRnVvzXFxbFHKLbcCrIKilQdbb.CopyFrom(other.aKEBRnVvzXFxbFHKLbcCrIKilQdbb);
		gHHyJkJmKMprfVkpzyKfsfniamAT = other.gHHyJkJmKMprfVkpzyKfsfniamAT;
	}

	public void CopyNewEventsFrom(LowLevelInputEventQueue other)
	{
		if (other == null)
		{
			throw new ArgumentNullException("other");
		}
		int count = Count;
		int count2 = other.Count;
		if (count2 == 0)
		{
			return;
		}
		if (count == 0)
		{
			CopyAllFrom(other);
			return;
		}
		uint id = new LowLevelInputEvent(aKEBRnVvzXFxbFHKLbcCrIKilQdbb.GetPointerFromReadPosition((count - 1) * BCXjGGKBdIVpzpDZoDAdoQpxmHeYA), nfVySUvBWivZoLWEdbyxKajiLWXK, qmdfEnklRWHOgXYWoAJqilDhWmfMB, iILsPkoZAPPgCJHvgznVAcVQjDAE).GetId();
		int num = other.FindNextIndex(id);
		if (num < 0)
		{
			return;
		}
		int num2 = count2 - num;
		if (num2 != 0)
		{
			for (int i = 0; i < num2; i++)
			{
				IntPtr buffer = aKEBRnVvzXFxbFHKLbcCrIKilQdbb.Allocate(BCXjGGKBdIVpzpDZoDAdoQpxmHeYA, zeroFill: false, out var _);
				other.aKEBRnVvzXFxbFHKLbcCrIKilQdbb.RandomRead(buffer, BCXjGGKBdIVpzpDZoDAdoQpxmHeYA, BCXjGGKBdIVpzpDZoDAdoQpxmHeYA, other.aKEBRnVvzXFxbFHKLbcCrIKilQdbb.GetOffsetFromReadPosition((num + i) * BCXjGGKBdIVpzpDZoDAdoQpxmHeYA));
			}
			gHHyJkJmKMprfVkpzyKfsfniamAT = other.gHHyJkJmKMprfVkpzyKfsfniamAT;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	~LowLevelInputEventQueue()
	{
		Dispose(disposing: false);
	}

	protected void Dispose(bool disposing)
	{
		if (!GCcsTYbyXdUWevwNTwpEWgOQTfol)
		{
			if (disposing)
			{
				aKEBRnVvzXFxbFHKLbcCrIKilQdbb.Dispose();
			}
			GCcsTYbyXdUWevwNTwpEWgOQTfol = true;
		}
	}
}
