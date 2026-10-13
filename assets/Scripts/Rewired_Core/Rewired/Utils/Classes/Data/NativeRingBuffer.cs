using System;

namespace Rewired.Utils.Classes.Data;

[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal class NativeRingBuffer : IDisposable
{
	private readonly NativeBuffer sLIzjgjdFkaXgeykFrAgRoykdvcs;

	private readonly int NRdmMPYqPpxiRMiwDohUulwfFUay;

	private long DFRgJGbOaHkzKfvadzEWNvCLzMPab;

	private long RwpPsEnbKXLuXBtDRpLigVBDIsft;

	private int pvtGjVCrgyeqOBDvzRRVlcBKSZrEb;

	private bool NAJpkFuwPjMuDurKBrVpjJLdSLlX;

	private uint omWSkSFTgQSkefsUrAPthUCBQVdWA;

	private bool pdUPPEiXKDOBetvABtZqYzwXPOAS;

	public int Capacity => NRdmMPYqPpxiRMiwDohUulwfFUay;

	public int BytesInBuffer => pvtGjVCrgyeqOBDvzRRVlcBKSZrEb;

	public bool BufferOverrun => NAJpkFuwPjMuDurKBrVpjJLdSLlX;

	public int ReadPosition => (int)RwpPsEnbKXLuXBtDRpLigVBDIsft;

	public long WritePosition => DFRgJGbOaHkzKfvadzEWNvCLzMPab;

	public NativeRingBuffer(int P_0)
	{
		NRdmMPYqPpxiRMiwDohUulwfFUay = P_0;
		if (P_0 <= 0)
		{
			throw new ArgumentOutOfRangeException("sizeInBytes");
		}
		sLIzjgjdFkaXgeykFrAgRoykdvcs = new NativeBuffer(P_0);
	}

	public IntPtr Allocate(int bufferLength, bool zeroFill, out uint passId)
	{
		IntPtr pointer = sLIzjgjdFkaXgeykFrAgRoykdvcs.GetPointer((int)DFRgJGbOaHkzKfvadzEWNvCLzMPab);
		passId = omWSkSFTgQSkefsUrAPthUCBQVdWA;
		if (zeroFill)
		{
			int num = 0;
			sLIzjgjdFkaXgeykFrAgRoykdvcs.TryFill(0, bufferLength, (int)DFRgJGbOaHkzKfvadzEWNvCLzMPab);
			if (num == 0)
			{
				return IntPtr.Zero;
			}
			if (num < bufferLength)
			{
				num += sLIzjgjdFkaXgeykFrAgRoykdvcs.TryFill(0, bufferLength - num, num);
			}
		}
		ETExcwbVpxPRKFOIsGhfIjBNbtubA(bufferLength);
		return pointer;
	}

	public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite, out int startOffset, out uint passId)
	{
		startOffset = (int)DFRgJGbOaHkzKfvadzEWNvCLzMPab;
		passId = omWSkSFTgQSkefsUrAPthUCBQVdWA;
		if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToWrite <= 0)
		{
			return 0;
		}
		if (numBytesToWrite > bufferLength)
		{
			numBytesToWrite = bufferLength;
		}
		int num = sLIzjgjdFkaXgeykFrAgRoykdvcs.TryWriteBytes(buffer, bufferLength, numBytesToWrite, (int)DFRgJGbOaHkzKfvadzEWNvCLzMPab);
		if (num == 0)
		{
			return 0;
		}
		if (num < numBytesToWrite)
		{
			num += sLIzjgjdFkaXgeykFrAgRoykdvcs.TryWriteBytes(buffer, bufferLength, numBytesToWrite - num, 0, num);
		}
		ETExcwbVpxPRKFOIsGhfIjBNbtubA(num);
		return num;
	}

	public int Write(byte[] buffer, int numBytesToWrite, out int startOffset, out uint passId)
	{
		startOffset = (int)DFRgJGbOaHkzKfvadzEWNvCLzMPab;
		passId = omWSkSFTgQSkefsUrAPthUCBQVdWA;
		if (buffer == null)
		{
			return 0;
		}
		int num = buffer.Length;
		if (num <= 0 || numBytesToWrite <= 0)
		{
			return 0;
		}
		if (numBytesToWrite > num)
		{
			numBytesToWrite = num;
		}
		int num2 = sLIzjgjdFkaXgeykFrAgRoykdvcs.TryWriteBytes(buffer, numBytesToWrite, (int)DFRgJGbOaHkzKfvadzEWNvCLzMPab);
		if (num2 == 0)
		{
			return 0;
		}
		if (num2 < numBytesToWrite)
		{
			num2 += sLIzjgjdFkaXgeykFrAgRoykdvcs.TryWriteBytes(buffer, numBytesToWrite - num2, 0, num2);
		}
		ETExcwbVpxPRKFOIsGhfIjBNbtubA(num2);
		return num2;
	}

	public int Write(IntPtr buffer, int bufferLength, int numBytesToWrite)
	{
		int startOffset;
		uint passId;
		return Write(buffer, bufferLength, numBytesToWrite, out startOffset, out passId);
	}

	public int Write(byte[] buffer, int numBytesToWrite)
	{
		int startOffset;
		uint passId;
		return Write(buffer, numBytesToWrite, out startOffset, out passId);
	}

	public int Read(IntPtr buffer, int bufferLength, int numBytesToRead)
	{
		if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || pvtGjVCrgyeqOBDvzRRVlcBKSZrEb == 0)
		{
			return 0;
		}
		if (numBytesToRead > bufferLength)
		{
			numBytesToRead = bufferLength;
		}
		if (numBytesToRead > pvtGjVCrgyeqOBDvzRRVlcBKSZrEb)
		{
			numBytesToRead = pvtGjVCrgyeqOBDvzRRVlcBKSZrEb;
		}
		int num = sLIzjgjdFkaXgeykFrAgRoykdvcs.TryReadBytes(buffer, bufferLength, numBytesToRead, (int)RwpPsEnbKXLuXBtDRpLigVBDIsft);
		if (num <= 0)
		{
			return 0;
		}
		if (num < numBytesToRead)
		{
			num += sLIzjgjdFkaXgeykFrAgRoykdvcs.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
		}
		kfxGSicShjMeGgKEDjrAWBPnieoAb(num);
		return num;
	}

	public int Read(byte[] buffer, int numBytesToRead)
	{
		if (buffer == null)
		{
			return 0;
		}
		int num = buffer.Length;
		if (num <= 0 || numBytesToRead <= 0 || pvtGjVCrgyeqOBDvzRRVlcBKSZrEb == 0)
		{
			return 0;
		}
		if (numBytesToRead > num)
		{
			numBytesToRead = num;
		}
		if (numBytesToRead > pvtGjVCrgyeqOBDvzRRVlcBKSZrEb)
		{
			numBytesToRead = pvtGjVCrgyeqOBDvzRRVlcBKSZrEb;
		}
		int num2 = sLIzjgjdFkaXgeykFrAgRoykdvcs.TryReadBytes(buffer, numBytesToRead, (int)RwpPsEnbKXLuXBtDRpLigVBDIsft);
		if (num2 <= 0)
		{
			return 0;
		}
		if (num2 < numBytesToRead)
		{
			num2 += sLIzjgjdFkaXgeykFrAgRoykdvcs.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
		}
		kfxGSicShjMeGgKEDjrAWBPnieoAb(num2);
		return num2;
	}

	public int RandomRead(IntPtr buffer, int bufferLength, int numBytesToRead, int readStartIndex)
	{
		if (buffer == IntPtr.Zero || bufferLength <= 0 || numBytesToRead <= 0 || pvtGjVCrgyeqOBDvzRRVlcBKSZrEb == 0 || readStartIndex < 0 || readStartIndex >= NRdmMPYqPpxiRMiwDohUulwfFUay)
		{
			return 0;
		}
		if (numBytesToRead > bufferLength)
		{
			numBytesToRead = bufferLength;
		}
		if (numBytesToRead > pvtGjVCrgyeqOBDvzRRVlcBKSZrEb)
		{
			numBytesToRead = pvtGjVCrgyeqOBDvzRRVlcBKSZrEb;
		}
		int num = sLIzjgjdFkaXgeykFrAgRoykdvcs.TryReadBytes(buffer, bufferLength, numBytesToRead, readStartIndex);
		if (num <= 0)
		{
			return 0;
		}
		if (num < numBytesToRead)
		{
			num += sLIzjgjdFkaXgeykFrAgRoykdvcs.TryReadBytes(buffer, bufferLength, numBytesToRead - num, 0, num);
		}
		return num;
	}

	public int RandomRead(byte[] buffer, int numBytesToRead, int readStartIndex)
	{
		if (buffer == null)
		{
			return 0;
		}
		int num = buffer.Length;
		if (num <= 0 || numBytesToRead <= 0 || pvtGjVCrgyeqOBDvzRRVlcBKSZrEb == 0 || readStartIndex < 0 || readStartIndex >= NRdmMPYqPpxiRMiwDohUulwfFUay)
		{
			return 0;
		}
		if (numBytesToRead > num)
		{
			numBytesToRead = num;
		}
		if (numBytesToRead > pvtGjVCrgyeqOBDvzRRVlcBKSZrEb)
		{
			numBytesToRead = pvtGjVCrgyeqOBDvzRRVlcBKSZrEb;
		}
		int num2 = sLIzjgjdFkaXgeykFrAgRoykdvcs.TryReadBytes(buffer, numBytesToRead, readStartIndex);
		if (num2 <= 0)
		{
			return 0;
		}
		if (num2 < numBytesToRead)
		{
			num2 += sLIzjgjdFkaXgeykFrAgRoykdvcs.TryReadBytes(buffer, numBytesToRead - num2, 0, num2);
		}
		return num2;
	}

	public IntPtr GetPointerFromReadPosition(int offset)
	{
		int offsetFromReadPosition = GetOffsetFromReadPosition(offset);
		if (offsetFromReadPosition < 0)
		{
			return IntPtr.Zero;
		}
		return sLIzjgjdFkaXgeykFrAgRoykdvcs.GetPointer(offsetFromReadPosition);
	}

	public int GetOffsetFromReadPosition(int offset)
	{
		int num = (int)RwpPsEnbKXLuXBtDRpLigVBDIsft + offset;
		if (num >= NRdmMPYqPpxiRMiwDohUulwfFUay)
		{
			num -= NRdmMPYqPpxiRMiwDohUulwfFUay;
		}
		else if (num < 0)
		{
			num += NRdmMPYqPpxiRMiwDohUulwfFUay;
		}
		if (num < 0 || num >= NRdmMPYqPpxiRMiwDohUulwfFUay)
		{
			return -1;
		}
		return num;
	}

	public bool IsValid(int startIndex, uint passId)
	{
		if (startIndex < 0 || startIndex >= NRdmMPYqPpxiRMiwDohUulwfFUay)
		{
			return false;
		}
		if (startIndex < DFRgJGbOaHkzKfvadzEWNvCLzMPab)
		{
			if (passId == omWSkSFTgQSkefsUrAPthUCBQVdWA)
			{
				return true;
			}
		}
		else if (startIndex >= DFRgJGbOaHkzKfvadzEWNvCLzMPab)
		{
			if (omWSkSFTgQSkefsUrAPthUCBQVdWA == 0)
			{
				return false;
			}
			if (omWSkSFTgQSkefsUrAPthUCBQVdWA - 1 == passId)
			{
				return true;
			}
		}
		return false;
	}

	public void CopyFrom(NativeRingBuffer other)
	{
		if (other == null)
		{
			throw new ArgumentNullException("other");
		}
		if (NRdmMPYqPpxiRMiwDohUulwfFUay != other.NRdmMPYqPpxiRMiwDohUulwfFUay)
		{
			throw new Exception("Buffer does not have the same capacity. Cannot copy.");
		}
		DFRgJGbOaHkzKfvadzEWNvCLzMPab = other.DFRgJGbOaHkzKfvadzEWNvCLzMPab;
		RwpPsEnbKXLuXBtDRpLigVBDIsft = other.RwpPsEnbKXLuXBtDRpLigVBDIsft;
		pvtGjVCrgyeqOBDvzRRVlcBKSZrEb = other.pvtGjVCrgyeqOBDvzRRVlcBKSZrEb;
		NAJpkFuwPjMuDurKBrVpjJLdSLlX = other.NAJpkFuwPjMuDurKBrVpjJLdSLlX;
		omWSkSFTgQSkefsUrAPthUCBQVdWA = other.omWSkSFTgQSkefsUrAPthUCBQVdWA;
		sLIzjgjdFkaXgeykFrAgRoykdvcs.CopyFrom(other.sLIzjgjdFkaXgeykFrAgRoykdvcs);
	}

	public void Reset()
	{
		DFRgJGbOaHkzKfvadzEWNvCLzMPab = 0L;
		RwpPsEnbKXLuXBtDRpLigVBDIsft = 0L;
		pvtGjVCrgyeqOBDvzRRVlcBKSZrEb = 0;
		NAJpkFuwPjMuDurKBrVpjJLdSLlX = false;
		omWSkSFTgQSkefsUrAPthUCBQVdWA = 0u;
	}

	private void ETExcwbVpxPRKFOIsGhfIjBNbtubA(int P_0)
	{
		if (P_0 <= 0)
		{
			return;
		}
		int num = (int)DFRgJGbOaHkzKfvadzEWNvCLzMPab;
		DFRgJGbOaHkzKfvadzEWNvCLzMPab += P_0;
		bool flag = false;
		if (num < RwpPsEnbKXLuXBtDRpLigVBDIsft)
		{
			if (DFRgJGbOaHkzKfvadzEWNvCLzMPab > RwpPsEnbKXLuXBtDRpLigVBDIsft)
			{
				flag = true;
			}
		}
		else if (num > RwpPsEnbKXLuXBtDRpLigVBDIsft)
		{
			if (DFRgJGbOaHkzKfvadzEWNvCLzMPab - NRdmMPYqPpxiRMiwDohUulwfFUay > RwpPsEnbKXLuXBtDRpLigVBDIsft)
			{
				flag = true;
			}
		}
		else if (pvtGjVCrgyeqOBDvzRRVlcBKSZrEb > 0)
		{
			flag = true;
		}
		if (flag)
		{
			NAJpkFuwPjMuDurKBrVpjJLdSLlX = true;
			RwpPsEnbKXLuXBtDRpLigVBDIsft = DFRgJGbOaHkzKfvadzEWNvCLzMPab;
			if (RwpPsEnbKXLuXBtDRpLigVBDIsft >= NRdmMPYqPpxiRMiwDohUulwfFUay)
			{
				RwpPsEnbKXLuXBtDRpLigVBDIsft -= NRdmMPYqPpxiRMiwDohUulwfFUay;
			}
		}
		if (DFRgJGbOaHkzKfvadzEWNvCLzMPab >= NRdmMPYqPpxiRMiwDohUulwfFUay)
		{
			DFRgJGbOaHkzKfvadzEWNvCLzMPab -= NRdmMPYqPpxiRMiwDohUulwfFUay;
			PgTrylhGXFRkwZeKGJlupKVrlcqo();
		}
		pvtGjVCrgyeqOBDvzRRVlcBKSZrEb = (int)MathTools.Clamp((long)pvtGjVCrgyeqOBDvzRRVlcBKSZrEb + (long)P_0, 0L, NRdmMPYqPpxiRMiwDohUulwfFUay);
	}

	private void kfxGSicShjMeGgKEDjrAWBPnieoAb(int P_0)
	{
		if (P_0 > 0)
		{
			if (NAJpkFuwPjMuDurKBrVpjJLdSLlX)
			{
				NAJpkFuwPjMuDurKBrVpjJLdSLlX = false;
			}
			RwpPsEnbKXLuXBtDRpLigVBDIsft += P_0;
			if (RwpPsEnbKXLuXBtDRpLigVBDIsft >= NRdmMPYqPpxiRMiwDohUulwfFUay)
			{
				RwpPsEnbKXLuXBtDRpLigVBDIsft -= NRdmMPYqPpxiRMiwDohUulwfFUay;
			}
			long num = (long)pvtGjVCrgyeqOBDvzRRVlcBKSZrEb - (long)P_0;
			pvtGjVCrgyeqOBDvzRRVlcBKSZrEb = (int)((num >= 0) ? num : 0);
		}
	}

	private void PgTrylhGXFRkwZeKGJlupKVrlcqo()
	{
		if (omWSkSFTgQSkefsUrAPthUCBQVdWA == uint.MaxValue)
		{
			omWSkSFTgQSkefsUrAPthUCBQVdWA = 0u;
		}
		else
		{
			omWSkSFTgQSkefsUrAPthUCBQVdWA++;
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

	~NativeRingBuffer()
	{
		Dispose(disposing: false);
	}

	protected void Dispose(bool disposing)
	{
		if (!pdUPPEiXKDOBetvABtZqYzwXPOAS)
		{
			if (disposing && sLIzjgjdFkaXgeykFrAgRoykdvcs != null)
			{
				sLIzjgjdFkaXgeykFrAgRoykdvcs.Dispose();
			}
			pdUPPEiXKDOBetvABtZqYzwXPOAS = true;
		}
	}
}
