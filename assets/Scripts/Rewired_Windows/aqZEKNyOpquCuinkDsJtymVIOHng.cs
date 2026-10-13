using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Rewired.Utils;

[DefaultMember("Item")]
internal class aqZEKNyOpquCuinkDsJtymVIOHng : IEnumerable<byte>, IEnumerable, IDisposable
{
	private struct AFSjVuKVaQcPKvWGlGEUCsfQcrttA(aqZEKNyOpquCuinkDsJtymVIOHng P_0) : IEnumerator<byte>, IEnumerator, IDisposable
	{
		private aqZEKNyOpquCuinkDsJtymVIOHng NohuvRHWLBGUfTfQsReetjQvCjUm = P_0;

		private int alhGhycbocpqRydCApinfiZdedHDb = -1;

		byte IEnumerator<byte>.Current => get_Current();

		object IEnumerator.Current => NohuvRHWLBGUfTfQsReetjQvCjUm.ZeFWUbvgsMPhdOJEJFzXFVZEhYiS(alhGhycbocpqRydCApinfiZdedHDb);

		public byte get_Current()
		{
			return NohuvRHWLBGUfTfQsReetjQvCjUm.ZeFWUbvgsMPhdOJEJFzXFVZEhYiS(alhGhycbocpqRydCApinfiZdedHDb);
		}

		public void Dispose()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Dispose
			this.Dispose();
		}

		public bool MoveNext()
		{
			if (alhGhycbocpqRydCApinfiZdedHDb >= NohuvRHWLBGUfTfQsReetjQvCjUm.lqGCtljsXGjFYeAHBEsaKYuETIBJD - 1)
			{
				return false;
			}
			alhGhycbocpqRydCApinfiZdedHDb++;
			return true;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		public void Reset()
		{
			alhGhycbocpqRydCApinfiZdedHDb = 0;
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Reset
			this.Reset();
		}
	}

	private int lqGCtljsXGjFYeAHBEsaKYuETIBJD;

	private unsafe byte* FSfRINErmluqhCqimwCOgaNJFdQgA;

	public int SWESaZflcUphrVsNqZkLVjuOWFmJ => DqRHjhhfDDHRDGxzbcIwPOtkrhzrA();

	public bool mKYoxgoLxeUboPymOFtrjhmLgKyJ => qFseiiMcrlLGKOthRmwJOBfQbqrr();

	// C# has no syntax for parameterized property 'CLCFAjLMIXFFRFFCuMKIxosSqeBk'.
	public byte get_CLCFAjLMIXFFRFFCuMKIxosSqeBk(int P_0)
	{
		return ZeFWUbvgsMPhdOJEJFzXFVZEhYiS(P_0);
	}

	public void set_CLCFAjLMIXFFRFFCuMKIxosSqeBk(int P_0, byte P_1)
	{
		CMBzegOPrQIDIEPDqLaUJFFNqSMb(num, b);
	}

	public int DqRHjhhfDDHRDGxzbcIwPOtkrhzrA()
	{
		return lqGCtljsXGjFYeAHBEsaKYuETIBJD;
	}

	public unsafe bool qFseiiMcrlLGKOthRmwJOBfQbqrr()
	{
		if (lqGCtljsXGjFYeAHBEsaKYuETIBJD <= 0)
		{
			return true;
		}
		return FSfRINErmluqhCqimwCOgaNJFdQgA != null;
	}

	public unsafe byte ZeFWUbvgsMPhdOJEJFzXFVZEhYiS(int P_0)
	{
		if (P_0 < 0 || P_0 >= lqGCtljsXGjFYeAHBEsaKYuETIBJD)
		{
			throw new IndexOutOfRangeException();
		}
		return FSfRINErmluqhCqimwCOgaNJFdQgA[P_0];
	}

	public unsafe void CMBzegOPrQIDIEPDqLaUJFFNqSMb(int P_0, byte P_1)
	{
		if (P_0 < 0 || P_0 >= lqGCtljsXGjFYeAHBEsaKYuETIBJD)
		{
			throw new IndexOutOfRangeException();
		}
		FSfRINErmluqhCqimwCOgaNJFdQgA[P_0] = P_1;
	}

	public aqZEKNyOpquCuinkDsJtymVIOHng(int P_0)
	{
		cAiQpwoMfLctFPjijvVCkeNNOlbE(P_0);
	}

	public unsafe aqZEKNyOpquCuinkDsJtymVIOHng(params byte[] P_0)
		: this(P_0.Length)
	{
		Marshal.Copy(P_0, 0, (IntPtr)FSfRINErmluqhCqimwCOgaNJFdQgA, P_0.Length);
	}

	public aqZEKNyOpquCuinkDsJtymVIOHng(aqZEKNyOpquCuinkDsJtymVIOHng P_0)
		: this(P_0.lqGCtljsXGjFYeAHBEsaKYuETIBJD)
	{
		P_0.PPHEcYSfXWQacLNEXvQarNyVvaoP(this, 0, P_0.lqGCtljsXGjFYeAHBEsaKYuETIBJD);
	}

	public unsafe aqZEKNyOpquCuinkDsJtymVIOHng(byte* P_0, int P_1)
		: this(P_1)
	{
		nszCkLYuchMjpmuavlajKXkkRecO.vSSqnOEIihSQrYOkHwJRZowXfcAY(P_0, FSfRINErmluqhCqimwCOgaNJFdQgA, 0, 0, P_1);
	}

	public unsafe bool nCMfLUtdNGbhvoPxLqDCgdPfsCzI(byte* P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= lqGCtljsXGjFYeAHBEsaKYuETIBJD || P_2 >= P_1)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > lqGCtljsXGjFYeAHBEsaKYuETIBJD || P_3 > P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_3 + P_2;
		if (num >= lqGCtljsXGjFYeAHBEsaKYuETIBJD || num >= P_1)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return nszCkLYuchMjpmuavlajKXkkRecO.vSSqnOEIihSQrYOkHwJRZowXfcAY(FSfRINErmluqhCqimwCOgaNJFdQgA, P_0, P_2, P_2, P_3);
	}

	public unsafe bool PPHEcYSfXWQacLNEXvQarNyVvaoP(aqZEKNyOpquCuinkDsJtymVIOHng P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return nCMfLUtdNGbhvoPxLqDCgdPfsCzI(P_0.FSfRINErmluqhCqimwCOgaNJFdQgA, P_0.lqGCtljsXGjFYeAHBEsaKYuETIBJD, P_1, P_2, P_3);
	}

	public unsafe bool UcoIqyWJxJWUICXvJscNhthiOwNT(byte[] P_0, int P_1, int P_2, bool P_3 = true)
	{
		if (P_0 == null)
		{
			if (P_3)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= lqGCtljsXGjFYeAHBEsaKYuETIBJD || P_1 >= P_0.Length)
		{
			if (P_3)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 <= 0 || P_2 > lqGCtljsXGjFYeAHBEsaKYuETIBJD || P_2 > P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		int num = P_2 + P_1;
		if (num >= lqGCtljsXGjFYeAHBEsaKYuETIBJD || num >= P_0.Length)
		{
			if (P_3)
			{
				throw new ArgumentOutOfRangeException("startIndex + length must be < Length of either array");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)FSfRINErmluqhCqimwCOgaNJFdQgA, P_0, P_1, P_1, P_2, P_3);
	}

	public unsafe bool ruHtdzHSkCKErECEUfdlatmxSybX(byte* P_0, int P_1, int P_2, int P_3, int P_4, bool P_5 = true)
	{
		if (P_0 == null)
		{
			if (P_5)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= lqGCtljsXGjFYeAHBEsaKYuETIBJD)
		{
			if (P_5)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 < 0 || P_3 >= P_1)
		{
			if (P_5)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_4 <= 0 || P_4 > lqGCtljsXGjFYeAHBEsaKYuETIBJD || P_4 > P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_4 + P_2 >= lqGCtljsXGjFYeAHBEsaKYuETIBJD)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex + length must be < source.Length");
			}
			return false;
		}
		if (P_4 + P_3 >= P_1)
		{
			if (P_5)
			{
				throw new ArgumentOutOfRangeException("destinationStartIndex + length must be < destination.Length");
			}
			return false;
		}
		return nszCkLYuchMjpmuavlajKXkkRecO.vSSqnOEIihSQrYOkHwJRZowXfcAY(FSfRINErmluqhCqimwCOgaNJFdQgA, P_0, P_2, P_3, P_4);
	}

	public unsafe bool ZoQnjQTrhyNHdynfFAjhkiUztIVqA(aqZEKNyOpquCuinkDsJtymVIOHng P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		return ruHtdzHSkCKErECEUfdlatmxSybX(P_0.FSfRINErmluqhCqimwCOgaNJFdQgA, P_0.lqGCtljsXGjFYeAHBEsaKYuETIBJD, P_1, P_2, P_3, P_4);
	}

	public unsafe bool cyYHYMgpeIqzAXpIRlEXxRPrihxb(byte[] P_0, int P_1, int P_2, int P_3, bool P_4 = true)
	{
		if (P_0 == null)
		{
			if (P_4)
			{
				throw new ArgumentNullException("destination");
			}
			return false;
		}
		if (P_1 < 0 || P_1 >= lqGCtljsXGjFYeAHBEsaKYuETIBJD)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_2 < 0 || P_2 >= P_0.Length)
		{
			if (P_4)
			{
				throw new IndexOutOfRangeException("startIndex");
			}
			return false;
		}
		if (P_3 <= 0 || P_3 > lqGCtljsXGjFYeAHBEsaKYuETIBJD || P_3 > P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			return false;
		}
		if (P_3 + P_1 >= lqGCtljsXGjFYeAHBEsaKYuETIBJD)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("sourceStartIndex + length must be < source.Length");
			}
			return false;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			if (P_4)
			{
				throw new ArgumentOutOfRangeException("destinationStartIndex + length must be < destination.Length");
			}
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)FSfRINErmluqhCqimwCOgaNJFdQgA, P_0, P_1, P_2, P_3, P_4);
	}

	public unsafe bool BteGaPBxUMPXdmYsVkNLFIfMQzcLA(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= lqGCtljsXGjFYeAHBEsaKYuETIBJD || P_2 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		int num = P_3 + P_2;
		if (num >= lqGCtljsXGjFYeAHBEsaKYuETIBJD)
		{
			P_3 = lqGCtljsXGjFYeAHBEsaKYuETIBJD - P_2;
		}
		if (num >= P_1)
		{
			P_3 = P_1 - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return nszCkLYuchMjpmuavlajKXkkRecO.vSSqnOEIihSQrYOkHwJRZowXfcAY(FSfRINErmluqhCqimwCOgaNJFdQgA, P_0, P_2, P_2, P_3);
	}

	public unsafe bool ZDeoIixoeUfcFWAqJDMqRclksuVU(aqZEKNyOpquCuinkDsJtymVIOHng P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		return BteGaPBxUMPXdmYsVkNLFIfMQzcLA(P_0.FSfRINErmluqhCqimwCOgaNJFdQgA, P_0.lqGCtljsXGjFYeAHBEsaKYuETIBJD, P_1, P_2);
	}

	public unsafe bool cEbeMAxyNNrsvTyxOBhrGqYHdEyh(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= lqGCtljsXGjFYeAHBEsaKYuETIBJD || P_1 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		int num = P_2 + P_1;
		if (num >= lqGCtljsXGjFYeAHBEsaKYuETIBJD)
		{
			P_2 = lqGCtljsXGjFYeAHBEsaKYuETIBJD - P_1;
		}
		if (num >= P_0.Length)
		{
			P_2 = P_0.Length - P_1;
		}
		if (P_2 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)FSfRINErmluqhCqimwCOgaNJFdQgA, P_0, P_1, P_1, P_2, throwOnError: false);
	}

	public unsafe bool jMlqcFXDhcBhCbOqeKWkyzajTmes(byte* P_0, int P_1, int P_2, int P_3, int P_4)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_2 >= lqGCtljsXGjFYeAHBEsaKYuETIBJD)
		{
			return false;
		}
		if (P_3 >= P_1)
		{
			return false;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 < 0)
		{
			P_3 = 0;
		}
		if (P_4 + P_2 >= lqGCtljsXGjFYeAHBEsaKYuETIBJD)
		{
			P_4 = lqGCtljsXGjFYeAHBEsaKYuETIBJD - P_2;
		}
		if (P_4 + P_3 >= P_1)
		{
			P_4 = P_1 - P_3;
		}
		if (P_4 <= 0)
		{
			return false;
		}
		return nszCkLYuchMjpmuavlajKXkkRecO.vSSqnOEIihSQrYOkHwJRZowXfcAY(FSfRINErmluqhCqimwCOgaNJFdQgA, P_0, P_2, P_3, P_4);
	}

	public unsafe bool OURqwFCSdKCtzfRqEukhdVKopskc(aqZEKNyOpquCuinkDsJtymVIOHng P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		return jMlqcFXDhcBhCbOqeKWkyzajTmes(P_0.FSfRINErmluqhCqimwCOgaNJFdQgA, P_0.lqGCtljsXGjFYeAHBEsaKYuETIBJD, P_1, P_2, P_3);
	}

	public unsafe bool RUBjmTyjFfXJxdgIasxMdqRKYSDk(byte[] P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_1 >= lqGCtljsXGjFYeAHBEsaKYuETIBJD)
		{
			return false;
		}
		if (P_2 >= P_0.Length)
		{
			return false;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		if (P_3 + P_1 >= lqGCtljsXGjFYeAHBEsaKYuETIBJD)
		{
			P_3 = lqGCtljsXGjFYeAHBEsaKYuETIBJD - P_1;
		}
		if (P_3 + P_2 >= P_0.Length)
		{
			P_3 = P_0.Length - P_2;
		}
		if (P_3 <= 0)
		{
			return false;
		}
		return NativeTools.CopyMemory((IntPtr)FSfRINErmluqhCqimwCOgaNJFdQgA, P_0, P_1, P_2, P_3, throwOnError: false);
	}

	public void xpBNdBRSvuuSbflzWCLfGJNiJCPhA(int P_0)
	{
		if (P_0 < 0)
		{
			throw new ArgumentOutOfRangeException("length must be >= 0");
		}
		if (lqGCtljsXGjFYeAHBEsaKYuETIBJD != P_0)
		{
			cAiQpwoMfLctFPjijvVCkeNNOlbE(P_0);
		}
	}

	public unsafe void tNGjvERuHrvPoUhIdkQklKxhGKqo()
	{
		if (lqGCtljsXGjFYeAHBEsaKYuETIBJD != 0 && FSfRINErmluqhCqimwCOgaNJFdQgA != null)
		{
			nszCkLYuchMjpmuavlajKXkkRecO.KhJYDYMLwtrMmSUfniSvlDNTVNwe(FSfRINErmluqhCqimwCOgaNJFdQgA, lqGCtljsXGjFYeAHBEsaKYuETIBJD);
		}
	}

	private unsafe void cAiQpwoMfLctFPjijvVCkeNNOlbE(int P_0)
	{
		if (P_0 == lqGCtljsXGjFYeAHBEsaKYuETIBJD)
		{
			tNGjvERuHrvPoUhIdkQklKxhGKqo();
			return;
		}
		if (lqGCtljsXGjFYeAHBEsaKYuETIBJD > 0)
		{
			clIqMLHnapmqQbMIzcqpzSpdLvBp();
		}
		FSfRINErmluqhCqimwCOgaNJFdQgA = (byte*)(void*)Marshal.AllocHGlobal(P_0);
		if (FSfRINErmluqhCqimwCOgaNJFdQgA == null)
		{
			throw new Exception("Could not allocate memory for array.");
		}
		lqGCtljsXGjFYeAHBEsaKYuETIBJD = P_0;
		tNGjvERuHrvPoUhIdkQklKxhGKqo();
	}

	private unsafe void clIqMLHnapmqQbMIzcqpzSpdLvBp()
	{
		if (FSfRINErmluqhCqimwCOgaNJFdQgA != null)
		{
			Marshal.FreeHGlobal((IntPtr)FSfRINErmluqhCqimwCOgaNJFdQgA);
		}
		FSfRINErmluqhCqimwCOgaNJFdQgA = null;
		lqGCtljsXGjFYeAHBEsaKYuETIBJD = 0;
	}

	public void Dispose()
	{
		qUQEdzXxnyezidDrSMRvuqQnclmjb(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	protected virtual void dXtJVbaTTSIhqPvTtFDKQjVNXNHR()
	{
		try
		{
			qUQEdzXxnyezidDrSMRvuqQnclmjb(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	protected void qUQEdzXxnyezidDrSMRvuqQnclmjb(bool P_0)
	{
		clIqMLHnapmqQbMIzcqpzSpdLvBp();
	}

	public IEnumerator<byte> GetEnumerator()
	{
		return new AFSjVuKVaQcPKvWGlGEUCsfQcrttA(this);
	}

	IEnumerator<byte> IEnumerable<byte>.GetEnumerator()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
		return this.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new AFSjVuKVaQcPKvWGlGEUCsfQcrttA(this);
	}
}
