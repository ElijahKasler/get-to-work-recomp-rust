using Unity;

namespace System.Windows.Forms;

public static class ImeContext
{
	public static void Disable(IntPtr handle)
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}

	public static void Enable(IntPtr handle)
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}

	public static ImeMode GetImeMode(IntPtr handle)
	{
		Unity.ThrowStub.ThrowNotSupportedException();
		return default;
	}

	public static bool IsOpen(IntPtr handle)
	{
		Unity.ThrowStub.ThrowNotSupportedException();
		return default;
	}

	public static void SetImeStatus(ImeMode imeMode, IntPtr handle)
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}

	public static void SetOpenStatus(bool open, IntPtr handle)
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}
}
