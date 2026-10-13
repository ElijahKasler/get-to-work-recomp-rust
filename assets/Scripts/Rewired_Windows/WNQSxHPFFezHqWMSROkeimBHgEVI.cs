using System;
using System.Runtime.CompilerServices;

internal class WNQSxHPFFezHqWMSROkeimBHgEVI : IEquatable<WNQSxHPFFezHqWMSROkeimBHgEVI>
{
	private IntPtr SeXBVLqtNhPXvsLZfJmFZnPMiAn;

	public IntPtr vYWZmKmZmLdXUNUNRupknWqJefLb => ykmgEpIhpMSGFOhDIxsEGNunpZXK();

	public bool lhTxfuLRQuZzxtBHQFPYxyfxwimL => RhxGglCLtuZrYULUDJKkUeTIJNup();

	public IntPtr ykmgEpIhpMSGFOhDIxsEGNunpZXK()
	{
		return SeXBVLqtNhPXvsLZfJmFZnPMiAn;
	}

	public bool RhxGglCLtuZrYULUDJKkUeTIJNup()
	{
		return SeXBVLqtNhPXvsLZfJmFZnPMiAn != IntPtr.Zero;
	}

	public WNQSxHPFFezHqWMSROkeimBHgEVI(IntPtr P_0)
	{
		if (P_0 == IntPtr.Zero)
		{
			throw new ArgumentException("srcPtr cannot be IntPtr.Zero");
		}
		SeXBVLqtNhPXvsLZfJmFZnPMiAn = P_0;
	}

	public virtual bool zUzzhaPdoiUsrhkSySvQiponkRJT(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (!(P_0 is WNQSxHPFFezHqWMSROkeimBHgEVI))
		{
			return false;
		}
		return ((WNQSxHPFFezHqWMSROkeimBHgEVI)P_0).SeXBVLqtNhPXvsLZfJmFZnPMiAn == SeXBVLqtNhPXvsLZfJmFZnPMiAn;
	}

	public virtual int IUbyDFTXdgLhMKZBOrEYEfFmKRDe()
	{
		return base.GetHashCode();
	}

	public bool Equals(WNQSxHPFFezHqWMSROkeimBHgEVI other)
	{
		if (other == null)
		{
			return false;
		}
		return SeXBVLqtNhPXvsLZfJmFZnPMiAn == other.SeXBVLqtNhPXvsLZfJmFZnPMiAn;
	}

	bool IEquatable<WNQSxHPFFezHqWMSROkeimBHgEVI>.Equals(WNQSxHPFFezHqWMSROkeimBHgEVI other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	[SpecialName]
	public static bool mHsiPLmFFWSEEGUlhHPRtNxKiWeD(WNQSxHPFFezHqWMSROkeimBHgEVI P_0, WNQSxHPFFezHqWMSROkeimBHgEVI P_1)
	{
		if (P_0 == null && P_1 == null)
		{
			return true;
		}
		if (P_0 == null || P_1 == null)
		{
			return false;
		}
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool TJQtfcSjVwBgRbkyAJcfaZgkFXwL(WNQSxHPFFezHqWMSROkeimBHgEVI P_0, WNQSxHPFFezHqWMSROkeimBHgEVI P_1)
	{
		if (P_0 == null && P_1 == null)
		{
			return false;
		}
		if (P_0 == null || P_1 == null)
		{
			return true;
		}
		return !P_0.Equals(P_1);
	}
}
