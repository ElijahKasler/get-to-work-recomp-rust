using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class ObqXgUUqhavcGIoFqIXpOyTOjTCP<_0001> : IDisposable where _0001 : struct
{
	private static readonly int PCNkcxPAiabVsBQYuexHnpocUiAwA = Marshal.SizeOf(typeof(_0001));

	private zPYtRvRddGYtyjvCeSHFiOzocDBi lZTHTSHjhDQTKhmQDkFBNIPTiMEF;

	private bool SKBmIxDywAoLVcLWdRjbyHcPUpyw;

	public zPYtRvRddGYtyjvCeSHFiOzocDBi YAZFWeRSIJjldHbBjeeGpBoPLDcE => mwSEgQGUOFjwVgCqBoHNLVnkJQTEA();

	public bool iDbgFoswjRThmpiEuGGcBJgViBIIA => FgblIZjvDVPAyaqPMXUnlLbXqzGH();

	public _0001 qRhMkSFwNsLwotYSSaZgiJqWjyXi
	{
		get
		{
			return RabisIhhjAWXkrDdLSlZljsLmVovA();
		}
		set
		{
			qgXcjcONdntCoXdHpYFklYrLmQsm(val);
		}
	}

	public zPYtRvRddGYtyjvCeSHFiOzocDBi mwSEgQGUOFjwVgCqBoHNLVnkJQTEA()
	{
		return lZTHTSHjhDQTKhmQDkFBNIPTiMEF;
	}

	public bool FgblIZjvDVPAyaqPMXUnlLbXqzGH()
	{
		if (lZTHTSHjhDQTKhmQDkFBNIPTiMEF != null)
		{
			return lZTHTSHjhDQTKhmQDkFBNIPTiMEF.omdFOnGtoXWkZqAnZcVvZMnvFnWb() != IntPtr.Zero;
		}
		return false;
	}

	public unsafe _0001 RabisIhhjAWXkrDdLSlZljsLmVovA()
	{
		FaasfOfpiGQODzVaXVhvqFWYGWVn();
		return Unsafe.Read<_0001>((void*)lZTHTSHjhDQTKhmQDkFBNIPTiMEF.omdFOnGtoXWkZqAnZcVvZMnvFnWb());
	}

	public unsafe void qgXcjcONdntCoXdHpYFklYrLmQsm(_0001 P_0)
	{
		FaasfOfpiGQODzVaXVhvqFWYGWVn();
		_0001* ptr = &P_0;
		lZTHTSHjhDQTKhmQDkFBNIPTiMEF.GtwIZzpYGHPYKnwFFduRkKKJKuZM((IntPtr)ptr, PCNkcxPAiabVsBQYuexHnpocUiAwA, PCNkcxPAiabVsBQYuexHnpocUiAwA);
	}

	public ObqXgUUqhavcGIoFqIXpOyTOjTCP()
	{
		lZTHTSHjhDQTKhmQDkFBNIPTiMEF = new zPYtRvRddGYtyjvCeSHFiOzocDBi(PCNkcxPAiabVsBQYuexHnpocUiAwA);
	}

	private void RNxOUZVJOQyVreHEtiyuBCNDzrhT()
	{
		if (lZTHTSHjhDQTKhmQDkFBNIPTiMEF == null)
		{
			lZTHTSHjhDQTKhmQDkFBNIPTiMEF.Dispose();
			lZTHTSHjhDQTKhmQDkFBNIPTiMEF = null;
		}
	}

	private void FaasfOfpiGQODzVaXVhvqFWYGWVn()
	{
		if (!FgblIZjvDVPAyaqPMXUnlLbXqzGH())
		{
			throw new Exception("Memory not allocated.");
		}
	}

	private void rvKMDTuTymsCyIcklMksSnqgsxvH(bool P_0)
	{
		if (!SKBmIxDywAoLVcLWdRjbyHcPUpyw)
		{
			if (P_0)
			{
				RNxOUZVJOQyVreHEtiyuBCNDzrhT();
			}
			SKBmIxDywAoLVcLWdRjbyHcPUpyw = true;
		}
	}

	public void Dispose()
	{
		rvKMDTuTymsCyIcklMksSnqgsxvH(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}
