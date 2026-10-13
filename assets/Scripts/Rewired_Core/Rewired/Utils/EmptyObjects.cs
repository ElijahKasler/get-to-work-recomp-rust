using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rewired.Utils;

[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal static class EmptyObjects<T>
{
	private static T[] dgmkFrddytWzEyZAqfvSyJPWctNDA;

	private static IList<T> wAJMUlpRmPEjCGqITGkpgLtzBOQR;

	public static T[] array => dgmkFrddytWzEyZAqfvSyJPWctNDA ?? (dgmkFrddytWzEyZAqfvSyJPWctNDA = new T[0]);

	public static IList<T> EmptyReadOnlyIListT => wAJMUlpRmPEjCGqITGkpgLtzBOQR ?? (wAJMUlpRmPEjCGqITGkpgLtzBOQR = new ReadOnlyCollection<T>(new List<T>()));
}
