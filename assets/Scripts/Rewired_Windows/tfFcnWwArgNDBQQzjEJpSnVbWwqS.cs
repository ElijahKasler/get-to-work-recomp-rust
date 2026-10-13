using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal class tfFcnWwArgNDBQQzjEJpSnVbWwqS : zEjiigADjVKbvdFoCssHuBPvMHjw
{
	private readonly Dictionary<Guid, ufuqgxqelwdAjcUbvDTAwIoLDNvMA> kPJKrfeujzVUJUlcThTRYFeunQEy = new Dictionary<Guid, ufuqgxqelwdAjcUbvDTAwIoLDNvMA>();

	private static readonly Dictionary<Type, List<Type>> kfjNQqVhtguupjGoBrFhbPrxYlZE = new Dictionary<Type, List<Type>>();

	private IntPtr bhVIOfAXeHVYYPgDkSiyGLgchPxf;

	[CompilerGenerated]
	private IntPtr[] kMbJuWLssmWgVyJgUZaeKZKmjjqj;

	public IntPtr[] cVneUaxpJgtBmgeEbosNTstCbPXJ
	{
		get
		{
			return PrnLOCfjlOwTzmrCnbaIhdwYKsB();
		}
		private set
		{
			mOeLqpEnbjQmnPFRlogmtEmhDlaN(array);
		}
	}

	public IntPtr[] PrnLOCfjlOwTzmrCnbaIhdwYKsB()
	{
		return kMbJuWLssmWgVyJgUZaeKZKmjjqj;
	}

	private void mOeLqpEnbjQmnPFRlogmtEmhDlaN(IntPtr[] P_0)
	{
		kMbJuWLssmWgVyJgUZaeKZKmjjqj = P_0;
	}

	public void FOIHITQgfShiWxrSBYQhzHbTyBSR(EJemtWVZyINExWFiYaQSsLFcajHY P_0)
	{
		P_0.oTSwMzFrHUDHWQuwueFeePoQWDWW(this);
		Type type = P_0.GetType();
		List<Type> value;
		lock (kfjNQqVhtguupjGoBrFhbPrxYlZE)
		{
			if (!kfjNQqVhtguupjGoBrFhbPrxYlZE.TryGetValue(type, out value))
			{
				Type[] interfaces = type.GetInterfaces();
				value = new List<Type>();
				value.AddRange(interfaces);
				kfjNQqVhtguupjGoBrFhbPrxYlZE.Add(type, value);
				Type[] array = interfaces;
				foreach (Type type2 in array)
				{
					if (TdSeUOhgwtJCBHYQGefSLCAaFRbmA.WQLDUSalSExnpfjnFCRJdGkjERiG(type2) == null)
					{
						value.Remove(type2);
						continue;
					}
					Type[] interfaces2 = type2.GetInterfaces();
					foreach (Type item in interfaces2)
					{
						value.Remove(item);
					}
				}
			}
		}
		ufuqgxqelwdAjcUbvDTAwIoLDNvMA ufuqgxqelwdAjcUbvDTAwIoLDNvMA2 = null;
		foreach (Type item2 in value)
		{
			ufuqgxqelwdAjcUbvDTAwIoLDNvMA ufuqgxqelwdAjcUbvDTAwIoLDNvMA3 = (ufuqgxqelwdAjcUbvDTAwIoLDNvMA)Activator.CreateInstance(TdSeUOhgwtJCBHYQGefSLCAaFRbmA.WQLDUSalSExnpfjnFCRJdGkjERiG(item2).cVKNpyqexGrYbdIljWjMkbwJSrPB());
			ufuqgxqelwdAjcUbvDTAwIoLDNvMA3.AjlFrHQdFXILOCHACXxZQsRYJEdYA(P_0);
			if (ufuqgxqelwdAjcUbvDTAwIoLDNvMA2 == null)
			{
				ufuqgxqelwdAjcUbvDTAwIoLDNvMA2 = ufuqgxqelwdAjcUbvDTAwIoLDNvMA3;
				kPJKrfeujzVUJUlcThTRYFeunQEy.Add(YvxgaVdVKNGoaZgrMBdRirUZunpgA.nfBBroxpTbNSpxWfWvuNfReHCnlA, ufuqgxqelwdAjcUbvDTAwIoLDNvMA2);
			}
			kPJKrfeujzVUJUlcThTRYFeunQEy.Add(RhoSDdlPwZIYTHXfVerjMzvHNyu.AgKBXgeBvedMiWcXEjtVdzDUlxvfA(item2), ufuqgxqelwdAjcUbvDTAwIoLDNvMA3);
			Type[] array = item2.GetInterfaces();
			foreach (Type type3 in array)
			{
				if (TdSeUOhgwtJCBHYQGefSLCAaFRbmA.WQLDUSalSExnpfjnFCRJdGkjERiG(type3) != null)
				{
					kPJKrfeujzVUJUlcThTRYFeunQEy.Add(RhoSDdlPwZIYTHXfVerjMzvHNyu.AgKBXgeBvedMiWcXEjtVdzDUlxvfA(type3), ufuqgxqelwdAjcUbvDTAwIoLDNvMA3);
				}
			}
		}
	}

	internal IntPtr VrmbYWJEAbmlHIgDXXkrxmpPVpKp(Type P_0)
	{
		return DNQgJnAFIiGvanIUCDOxIaKzQQJn(RhoSDdlPwZIYTHXfVerjMzvHNyu.AgKBXgeBvedMiWcXEjtVdzDUlxvfA(P_0));
	}

	internal IntPtr DNQgJnAFIiGvanIUCDOxIaKzQQJn(Guid P_0)
	{
		return kPHBeDzSKXFByejALDxlCTVAbcjRA(P_0)?.JlPEPpQhdeKwlZzQOhddIQKPYxtg() ?? IntPtr.Zero;
	}

	internal ufuqgxqelwdAjcUbvDTAwIoLDNvMA kPHBeDzSKXFByejALDxlCTVAbcjRA(Guid P_0)
	{
		kPJKrfeujzVUJUlcThTRYFeunQEy.TryGetValue(P_0, out var value);
		return value;
	}

	protected virtual void zpkizvWYJaKextmlZZaQoaIkrDPj(bool P_0)
	{
		if (!P_0)
		{
			return;
		}
		foreach (ufuqgxqelwdAjcUbvDTAwIoLDNvMA value in kPJKrfeujzVUJUlcThTRYFeunQEy.Values)
		{
			value.Dispose();
		}
		kPJKrfeujzVUJUlcThTRYFeunQEy.Clear();
		if (bhVIOfAXeHVYYPgDkSiyGLgchPxf != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(bhVIOfAXeHVYYPgDkSiyGLgchPxf);
			bhVIOfAXeHVYYPgDkSiyGLgchPxf = IntPtr.Zero;
		}
	}
}
