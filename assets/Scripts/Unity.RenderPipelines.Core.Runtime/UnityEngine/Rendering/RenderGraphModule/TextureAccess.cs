namespace UnityEngine.Rendering.RenderGraphModule;

internal struct TextureAccess(TextureHandle handle, AccessFlags flags, int mipLevel, int depthSlice)
{
	public TextureHandle textureHandle = handle;

	public int mipLevel = mipLevel;

	public int depthSlice = depthSlice;

	public AccessFlags flags = flags;
}
