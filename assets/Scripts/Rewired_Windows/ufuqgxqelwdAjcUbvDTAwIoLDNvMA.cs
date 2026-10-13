using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal abstract class ufuqgxqelwdAjcUbvDTAwIoLDNvMA : RJuFMMovzRGEIXUdsDmtkobvgyLdb
{
	[CompilerGenerated]
	private EJemtWVZyINExWFiYaQSsLFcajHY hGyFFEKnLNVnDfVLOjyUDKcfgRHr;

	public EJemtWVZyINExWFiYaQSsLFcajHY qxNclGGvrODwgYydzgShqYjuRclG
	{
		get
		{
			return BIUBfZlyhSrmyvqeuHJNlVigAMQT();
		}
		private set
		{
			ENcycKuiWQjVcVZobtDqedIyqOGS(eJemtWVZyINExWFiYaQSsLFcajHY);
		}
	}

	protected abstract RhLZYjZyaIarVnNGpyTXnPaZhfKeA xNAMWUJkpSVUojxVWeXKExqBIAdm { get; }

	public EJemtWVZyINExWFiYaQSsLFcajHY BIUBfZlyhSrmyvqeuHJNlVigAMQT()
	{
		return hGyFFEKnLNVnDfVLOjyUDKcfgRHr;
	}

	private void ENcycKuiWQjVcVZobtDqedIyqOGS(EJemtWVZyINExWFiYaQSsLFcajHY P_0)
	{
		hGyFFEKnLNVnDfVLOjyUDKcfgRHr = P_0;
	}

	protected abstract RhLZYjZyaIarVnNGpyTXnPaZhfKeA JkychxekXYaThbpbqaWeMjKgAGPTA();

	public unsafe virtual void AjlFrHQdFXILOCHACXxZQsRYJEdYA(EJemtWVZyINExWFiYaQSsLFcajHY P_0)
	{
		ENcycKuiWQjVcVZobtDqedIyqOGS(P_0);
		qZZgRllaEQtpHPKWsrRekqCOMioV(Marshal.AllocHGlobal(IntPtr.Size * 2));
		GCHandle value = GCHandle.Alloc(this);
		Marshal.WriteIntPtr(JlPEPpQhdeKwlZzQOhddIQKPYxtg(), JkychxekXYaThbpbqaWeMjKgAGPTA().FzkEuqCJgvQOBgepRzhbxNsgFOJFA());
		((IntPtr*)(void*)JlPEPpQhdeKwlZzQOhddIQKPYxtg())[1] = GCHandle.ToIntPtr(value);
	}

	protected unsafe virtual void zmVJwcntbguITBoGumSmVgWWJVAK(bool P_0)
	{
		if (JlPEPpQhdeKwlZzQOhddIQKPYxtg() != IntPtr.Zero)
		{
			GCHandle.FromIntPtr(((IntPtr*)(void*)JlPEPpQhdeKwlZzQOhddIQKPYxtg())[1]).Free();
			Marshal.FreeHGlobal(JlPEPpQhdeKwlZzQOhddIQKPYxtg());
			qZZgRllaEQtpHPKWsrRekqCOMioV(IntPtr.Zero);
		}
		ENcycKuiWQjVcVZobtDqedIyqOGS(null);
		PSowNxttGvjAoApPykbbbsEEFlkG(P_0);
	}

	internal unsafe static _0001 XxHFWErFZsKLRUgKBhJaXBmAajYi<_0001>(IntPtr P_0) where _0001 : ufuqgxqelwdAjcUbvDTAwIoLDNvMA
	{
		return (_0001)GCHandle.FromIntPtr(((IntPtr*)(void*)P_0)[1]).Target;
	}
}
