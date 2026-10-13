using System;
using System.Threading;

namespace Rewired.Utils.Classes.Utility;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal sealed class SpinLock : IDisposable
{
	private const int RtXnZQJDCRsZwTWrFmHukzePigwG = 1;

	private const int btIxzwFxspGRWJjdGIhjdpsVjrPe = 0;

	private int LjaZkFLaasmLewGJSKvrTQhvJySA;

	void IDisposable.Dispose()
	{
		latCWzpxcutKnhgyKcbCgOUzaCWIb();
	}

	private void RaylmObGexDgsIqOctyNfalXXXEi()
	{
		while (Interlocked.Exchange(ref LjaZkFLaasmLewGJSKvrTQhvJySA, 1) != 0)
		{
			Thread.SpinWait(1);
		}
	}

	private void latCWzpxcutKnhgyKcbCgOUzaCWIb()
	{
		Interlocked.Exchange(ref LjaZkFLaasmLewGJSKvrTQhvJySA, 0);
	}

	public SpinLock Lock()
	{
		RaylmObGexDgsIqOctyNfalXXXEi();
		return this;
	}
}
