using UnityEngine.Experimental.Rendering;

namespace UnityEngine.Rendering;

public struct RTHandleAllocInfo
{
	public int slices { get; set; }

	public GraphicsFormat format { get; set; }

	public FilterMode filterMode { get; set; }

	public TextureWrapMode wrapModeU { get; set; }

	public TextureWrapMode wrapModeV { get; set; }

	public TextureWrapMode wrapModeW { get; set; }

	public TextureDimension dimension { get; set; }

	public bool enableRandomWrite { get; set; }

	public bool useMipMap { get; set; }

	public bool autoGenerateMips { get; set; }

	public int anisoLevel { get; set; }

	public float mipMapBias { get; set; }

	public MSAASamples msaaSamples { get; set; }

	public bool bindTextureMS { get; set; }

	public bool useDynamicScale { get; set; }

	public RenderTextureMemoryless memoryless { get; set; }

	public VRTextureUsage vrUsage { get; set; }

	public string name { get; set; }

	public RTHandleAllocInfo(string name = "")
	{
		slices = 1;
		format = GraphicsFormat.R8G8B8A8_SRGB;
		filterMode = FilterMode.Point;
		wrapModeU = TextureWrapMode.Repeat;
		wrapModeV = TextureWrapMode.Repeat;
		wrapModeW = TextureWrapMode.Repeat;
		dimension = TextureDimension.Tex2D;
		enableRandomWrite = false;
		useMipMap = false;
		autoGenerateMips = true;
		anisoLevel = 1;
		mipMapBias = 0f;
		msaaSamples = MSAASamples.None;
		bindTextureMS = false;
		useDynamicScale = false;
		memoryless = RenderTextureMemoryless.None;
		vrUsage = VRTextureUsage.None;
		this.name = name;
	}
}
