namespace UnityEngine.UIElements.Layout;

internal readonly struct LayoutConfig
{
	private readonly LayoutDataAccess m_Access;

	private readonly LayoutHandle m_Handle;

	public static LayoutConfig Undefined => new LayoutConfig(default, LayoutHandle.Undefined);

	public bool IsUndefined => m_Handle.Equals(LayoutHandle.Undefined);

	public LayoutHandle Handle => m_Handle;

	public ref float PointScaleFactor => ref m_Access.GetConfigData(m_Handle).PointScaleFactor;

	public ref bool ShouldLog => ref m_Access.GetConfigData(m_Handle).ShouldLog;

	internal LayoutConfig(LayoutDataAccess access, LayoutHandle handle)
	{
		m_Access = access;
		m_Handle = handle;
	}
}
