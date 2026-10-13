using System.Drawing;
using System.Windows.Forms.VisualStyles;

namespace System.Windows.Forms;

public sealed class ProgressBarRenderer
{
	public static bool IsSupported
	{
		get
		{
			if (VisualStyleInformation.IsEnabledByUser)
			{
				if (Application.VisualStyleState != VisualStyleState.ClientAndNonClientAreasEnabled)
				{
					return Application.VisualStyleState == VisualStyleState.ClientAreaEnabled;
				}
				return true;
			}
			return false;
		}
	}

	public static int ChunkSpaceThickness
	{
		get
		{
			if (!IsSupported)
			{
				throw new InvalidOperationException();
			}
			return new VisualStyleRenderer(VisualStyleElement.ProgressBar.Chunk.Normal).GetInteger(IntegerProperty.ProgressSpaceSize);
		}
	}

	public static int ChunkThickness
	{
		get
		{
			if (!IsSupported)
			{
				throw new InvalidOperationException();
			}
			return new VisualStyleRenderer(VisualStyleElement.ProgressBar.Chunk.Normal).GetInteger(IntegerProperty.ProgressChunkSize);
		}
	}

	private ProgressBarRenderer()
	{
	}

	public static void DrawHorizontalBar(Graphics g, Rectangle bounds)
	{
		if (!IsSupported)
		{
			throw new InvalidOperationException();
		}
		new VisualStyleRenderer(VisualStyleElement.ProgressBar.Bar.Normal).DrawBackground(g, bounds);
	}

	public static void DrawHorizontalChunks(Graphics g, Rectangle bounds)
	{
		if (!IsSupported)
		{
			throw new InvalidOperationException();
		}
		new VisualStyleRenderer(VisualStyleElement.ProgressBar.Chunk.Normal).DrawBackground(g, bounds);
	}

	public static void DrawVerticalBar(Graphics g, Rectangle bounds)
	{
		if (!IsSupported)
		{
			throw new InvalidOperationException();
		}
		new VisualStyleRenderer(VisualStyleElement.ProgressBar.BarVertical.Normal).DrawBackground(g, bounds);
	}

	public static void DrawVerticalChunks(Graphics g, Rectangle bounds)
	{
		if (!IsSupported)
		{
			throw new InvalidOperationException();
		}
		new VisualStyleRenderer(VisualStyleElement.ProgressBar.ChunkVertical.Normal).DrawBackground(g, bounds);
	}
}
