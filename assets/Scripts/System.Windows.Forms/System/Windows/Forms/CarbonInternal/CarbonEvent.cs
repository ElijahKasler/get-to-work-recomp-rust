namespace System.Windows.Forms.CarbonInternal;

internal struct CarbonEvent(IntPtr hWnd, IntPtr evt)
{
	public IntPtr hWnd = hWnd;

	public IntPtr evt = evt;
}
