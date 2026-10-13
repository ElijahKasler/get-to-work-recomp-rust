using System;
using UnityEngine.Categorization;

namespace UnityEngine.Rendering.Universal;

[Serializable]
[SupportedOnRenderPipeline(typeof(UniversalRenderPipelineAsset))]
[CategoryInfo(Name = "R: Runtime Textures", Order = 1000)]
[HideInInspector]
public class UniversalRenderPipelineRuntimeTextures : IRenderPipelineResources, IRenderPipelineGraphicsSettings
{
	[SerializeField]
	[HideInInspector]
	private int m_Version = 1;

	[SerializeField]
	[ResourcePath("Textures/BlueNoise64/L/LDR_LLL1_0.png", SearchType.ProjectPath)]
	private Texture2D m_BlueNoise64LTex;

	[SerializeField]
	[ResourcePath("Textures/BayerMatrix.png", SearchType.ProjectPath)]
	private Texture2D m_BayerMatrixTex;

	[SerializeField]
	[ResourcePath("Textures/DebugFont.tga", SearchType.ProjectPath)]
	private Texture2D m_DebugFontTex;

	public int version => m_Version;

	bool IRenderPipelineGraphicsSettings.isAvailableInPlayerBuild => true;

	public Texture2D blueNoise64LTex
	{
		get
		{
			return m_BlueNoise64LTex;
		}
		set
		{
			this.SetValueAndNotify(ref m_BlueNoise64LTex, value, "m_BlueNoise64LTex");
		}
	}

	public Texture2D bayerMatrixTex
	{
		get
		{
			return m_BayerMatrixTex;
		}
		set
		{
			this.SetValueAndNotify(ref m_BayerMatrixTex, value, "m_BayerMatrixTex");
		}
	}

	public Texture2D debugFontTexture
	{
		get
		{
			return m_DebugFontTex;
		}
		set
		{
			this.SetValueAndNotify(ref m_DebugFontTex, value, "m_DebugFontTex");
		}
	}
}
