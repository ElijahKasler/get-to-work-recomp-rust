using System;
using System.Collections.Generic;
using System.Text;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired.Internal.Localization;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
internal sealed class DeviceLocalizationInfo
{
	public readonly Guid guid;

	public readonly ControllerType controllerType;

	public readonly bool isControllerTemplate;

	private readonly ReadOnlyList<string> QNIEuQeKQwROhnEsWziSiiJFeuaeb;

	private readonly IList<string> qpWEKYUdhFboWENsLAHkWwzBYRWd;

	private readonly ReadOnlyList<Guid> MOcBFyAroKEAtBrcaYUHQLNxMxVeb;

	private string AkMhhKTzpMZJAajoamwMDBkIcRwN;

	private Bytes20 PKivVEDdseNtnwaTDmmKKLCjDNyc;

	private bool QcpokUqDvmUoAhkSFGKRUPkgHBlX;

	public ReadOnlyList<string> parentKeys => QNIEuQeKQwROhnEsWziSiiJFeuaeb;

	public ReadOnlyList<Guid> controllerTemplateGuids => MOcBFyAroKEAtBrcaYUHQLNxMxVeb;

	public string additionalIdentifyingInformation
	{
		get
		{
			return AkMhhKTzpMZJAajoamwMDBkIcRwN;
		}
		set
		{
			KDbRAQrfGluMqBeQuIKYTJtyPGNf();
			AkMhhKTzpMZJAajoamwMDBkIcRwN = value;
		}
	}

	public Bytes20 hash => PKivVEDdseNtnwaTDmmKKLCjDNyc;

	public DeviceLocalizationInfo()
	{
		qpWEKYUdhFboWENsLAHkWwzBYRWd = new List<string>();
		QNIEuQeKQwROhnEsWziSiiJFeuaeb = new ReadOnlyList<string>(qpWEKYUdhFboWENsLAHkWwzBYRWd);
	}

	public DeviceLocalizationInfo(ControllerType P_0, bool P_1, Guid P_2, IList<string> P_3, IList<Guid> P_4)
	{
		controllerType = P_0;
		isControllerTemplate = P_1;
		guid = P_2;
		IList<string> list2;
		if (P_3 == null)
		{
			IList<string> list = new List<string>();
			list2 = list;
		}
		else
		{
			list2 = P_3;
		}
		qpWEKYUdhFboWENsLAHkWwzBYRWd = list2;
		QNIEuQeKQwROhnEsWziSiiJFeuaeb = new ReadOnlyList<string>(qpWEKYUdhFboWENsLAHkWwzBYRWd);
		if (P_4 != null)
		{
			MOcBFyAroKEAtBrcaYUHQLNxMxVeb = new ReadOnlyList<Guid>(P_4);
		}
	}

	public DeviceLocalizationInfo(DeviceLocalizationInfo P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("source");
		}
		guid = P_0.guid;
		controllerType = P_0.controllerType;
		isControllerTemplate = P_0.isControllerTemplate;
		qpWEKYUdhFboWENsLAHkWwzBYRWd = ((P_0.qpWEKYUdhFboWENsLAHkWwzBYRWd != null) ? new List<string>(P_0.qpWEKYUdhFboWENsLAHkWwzBYRWd) : new List<string>());
		QNIEuQeKQwROhnEsWziSiiJFeuaeb = new ReadOnlyList<string>(qpWEKYUdhFboWENsLAHkWwzBYRWd);
		if (P_0.controllerTemplateGuids != null)
		{
			MOcBFyAroKEAtBrcaYUHQLNxMxVeb = new ReadOnlyList<Guid>(P_0.controllerTemplateGuids);
		}
		QcpokUqDvmUoAhkSFGKRUPkgHBlX = P_0.QcpokUqDvmUoAhkSFGKRUPkgHBlX;
	}

	public void InsertParentKey(int index, string key)
	{
		KDbRAQrfGluMqBeQuIKYTJtyPGNf();
		if (!string.IsNullOrEmpty(key))
		{
			qpWEKYUdhFboWENsLAHkWwzBYRWd.Insert(index, key);
		}
	}

	public void FinishRuntimeSetup()
	{
		ComputeHash();
		UriSkOjhGLNZSjPsdGzVxrcZBoML();
	}

	public Bytes20 ComputeHash()
	{
		StringBuilder sharedStringBuilder = LocalizationManager.GetSharedStringBuilder();
		sharedStringBuilder.Append(controllerType.ToString());
		bool flag = isControllerTemplate;
		sharedStringBuilder.Append(flag.ToString());
		sharedStringBuilder.Append(guid.ToString());
		int count = qpWEKYUdhFboWENsLAHkWwzBYRWd.Count;
		for (int i = 0; i < count; i++)
		{
			if (!string.IsNullOrEmpty(qpWEKYUdhFboWENsLAHkWwzBYRWd[i]))
			{
				sharedStringBuilder.Append(qpWEKYUdhFboWENsLAHkWwzBYRWd[i]);
			}
		}
		sharedStringBuilder.Append(AkMhhKTzpMZJAajoamwMDBkIcRwN);
		PKivVEDdseNtnwaTDmmKKLCjDNyc = MiscTools.HashSHA1(sharedStringBuilder.ToString());
		return PKivVEDdseNtnwaTDmmKKLCjDNyc;
	}

	private void UriSkOjhGLNZSjPsdGzVxrcZBoML()
	{
		QcpokUqDvmUoAhkSFGKRUPkgHBlX = true;
	}

	private void KDbRAQrfGluMqBeQuIKYTJtyPGNf()
	{
		if (QcpokUqDvmUoAhkSFGKRUPkgHBlX)
		{
			throw new Exception("Cannot modify a read-only object.");
		}
	}

	public static bool DataMatches(DeviceLocalizationInfo a, DeviceLocalizationInfo b)
	{
		if (a == null || b == null)
		{
			return false;
		}
		if (a.controllerType != b.controllerType || a.isControllerTemplate != b.isControllerTemplate || a.guid != b.guid || a.qpWEKYUdhFboWENsLAHkWwzBYRWd.Count != b.qpWEKYUdhFboWENsLAHkWwzBYRWd.Count)
		{
			return false;
		}
		int count = a.qpWEKYUdhFboWENsLAHkWwzBYRWd.Count;
		for (int i = 0; i < count; i++)
		{
			if (!string.Equals(a.qpWEKYUdhFboWENsLAHkWwzBYRWd[i], b.qpWEKYUdhFboWENsLAHkWwzBYRWd[i], StringComparison.Ordinal))
			{
				return false;
			}
		}
		int num = ((a.MOcBFyAroKEAtBrcaYUHQLNxMxVeb != null) ? a.MOcBFyAroKEAtBrcaYUHQLNxMxVeb.get_Count() : 0);
		int num2 = ((b.MOcBFyAroKEAtBrcaYUHQLNxMxVeb != null) ? b.MOcBFyAroKEAtBrcaYUHQLNxMxVeb.get_Count() : 0);
		if (num != num2)
		{
			return false;
		}
		for (int j = 0; j < num; j++)
		{
			if (a.MOcBFyAroKEAtBrcaYUHQLNxMxVeb.get_Item(j) != b.MOcBFyAroKEAtBrcaYUHQLNxMxVeb.get_Item(j))
			{
				return false;
			}
		}
		return true;
	}
}
