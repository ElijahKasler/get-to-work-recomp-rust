using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Unity.XGamingRuntime.Interop;

public static class InteropHelpers
{
	public static IntPtr MarshalStringUtf8(string str)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(str);
		IntPtr intPtr = Marshal.AllocCoTaskMem(bytes.Length + 1);
		Marshal.Copy(bytes, 0, intPtr, bytes.Length);
		Marshal.WriteByte(intPtr, bytes.Length, 0);
		return intPtr;
	}

	public static U[] MarshalArray<T, U>(IntPtr ptr, uint count, Func<T, U> converter) where T : struct
	{
		IntPtr ptr2 = ptr;
		U[] array = new U[count];
		for (uint num = 0u; num < count; num++)
		{
			T arg = (T)Marshal.PtrToStructure(ptr2, typeof(T));
			array[num] = converter(arg);
			ptr2 += Marshal.SizeOf(typeof(T));
		}
		return array;
	}

	public static T[] MarshalArray<T>(IntPtr ptr, uint count) where T : struct
	{
		IntPtr ptr2 = ptr;
		T[] array = new T[count];
		for (uint num = 0u; num < count; num++)
		{
			array[num] = (T)Marshal.PtrToStructure(ptr2, typeof(T));
			ptr2 += Marshal.SizeOf(typeof(T));
		}
		return array;
	}

	public static string[] MarshalStringArrayAnsi(IntPtr ptr, uint count)
	{
		IntPtr ptr2 = ptr;
		string[] array = new string[count];
		for (uint num = 0u; num < count; num++)
		{
			IntPtr ptr3 = (IntPtr)Marshal.PtrToStructure(ptr2, typeof(IntPtr));
			array[num] = Marshal.PtrToStringAnsi(ptr3);
			ptr2 += Marshal.SizeOf(typeof(IntPtr));
		}
		return array;
	}
}
