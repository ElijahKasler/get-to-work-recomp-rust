using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using Unity;

namespace System.Windows.Forms;

public sealed class DpiChangedEventArgs : CancelEventArgs
{
	public int DeviceDpiNew
	{
		[CompilerGenerated]
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return default;
		}
	}

	public int DeviceDpiOld
	{
		[CompilerGenerated]
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return default;
		}
	}

	public Rectangle SuggestedRectangle
	{
		[CompilerGenerated]
		get
		{
			Unity.ThrowStub.ThrowNotSupportedException();
			return default;
		}
	}

	internal DpiChangedEventArgs()
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}
}
