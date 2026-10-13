using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils;

[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal class EnumValueHelper<TEnum>
{
	private static EnumValueHelper<TEnum> ledWUhClllfqytlGDXVytHPryfTK;

	private TEnum[] TtxOPRReLxOqkkAPvmOixLOeibbBA;

	private ReadOnlyCollection<TEnum> hpxmZNsTvVfgWJkhIejiAHzNhPpjA;

	private string[] LdwLZNmzvaesuGfHSfANNOjSrMyQ;

	private ReadOnlyCollection<string> qhbfSFoctBLSksXECjgsdbuVppO;

	public static EnumValueHelper<TEnum> Default => ledWUhClllfqytlGDXVytHPryfTK ?? (ledWUhClllfqytlGDXVytHPryfTK = new EnumValueHelper<TEnum>());

	public IList<TEnum> values => hpxmZNsTvVfgWJkhIejiAHzNhPpjA;

	public IList<string> names
	{
		get
		{
			if (qhbfSFoctBLSksXECjgsdbuVppO == null)
			{
				LdwLZNmzvaesuGfHSfANNOjSrMyQ = Enum.GetNames(typeof(TEnum));
				qhbfSFoctBLSksXECjgsdbuVppO = new ReadOnlyCollection<string>(LdwLZNmzvaesuGfHSfANNOjSrMyQ);
			}
			return qhbfSFoctBLSksXECjgsdbuVppO;
		}
	}

	public EnumValueHelper()
	{
		if (!EnumTools.IsEnum(typeof(TEnum)))
		{
			throw new ArgumentException("TEnum must be an enum type.");
		}
		TtxOPRReLxOqkkAPvmOixLOeibbBA = (TEnum[])Enum.GetValues(typeof(TEnum));
		hpxmZNsTvVfgWJkhIejiAHzNhPpjA = new ReadOnlyCollection<TEnum>(TtxOPRReLxOqkkAPvmOixLOeibbBA);
	}
}
