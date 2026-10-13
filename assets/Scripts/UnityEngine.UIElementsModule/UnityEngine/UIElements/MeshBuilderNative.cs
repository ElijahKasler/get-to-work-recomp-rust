using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine.Bindings;

namespace UnityEngine.UIElements;

[NativeHeader("Modules/UIElements/Core/Native/Renderer/UIRMeshBuilder.bindings.h")]
internal static class MeshBuilderNative
{
	public struct NativeColorPage
	{
		public int isValid;

		public Color32 pageAndID;
	}

	public struct NativeBorderParams
	{
		public Rect rect;

		public Color leftColor;

		public Color topColor;

		public Color rightColor;

		public Color bottomColor;

		public float leftWidth;

		public float topWidth;

		public float rightWidth;

		public float bottomWidth;

		public Vector2 topLeftRadius;

		public Vector2 topRightRadius;

		public Vector2 bottomRightRadius;

		public Vector2 bottomLeftRadius;

		internal NativeColorPage leftColorPage;

		internal NativeColorPage topColorPage;

		internal NativeColorPage rightColorPage;

		internal NativeColorPage bottomColorPage;
	}

	public struct NativeRectParams
	{
		public Rect rect;

		public Rect subRect;

		public Rect uv;

		public Color color;

		public ScaleMode scaleMode;

		public IntPtr backgroundRepeatInstanceList;

		public int backgroundRepeatInstanceListStartIndex;

		public int backgroundRepeatInstanceListEndIndex;

		public Vector2 topLeftRadius;

		public Vector2 topRightRadius;

		public Vector2 bottomRightRadius;

		public Vector2 bottomLeftRadius;

		public Rect backgroundRepeatRect;

		public IntPtr texture;

		public IntPtr sprite;

		public IntPtr vectorImage;

		public IntPtr spriteTexture;

		public IntPtr spriteVertices;

		public IntPtr spriteUVs;

		public IntPtr spriteTriangles;

		public Rect spriteGeomRect;

		public Vector2 contentSize;

		public Vector2 textureSize;

		public float texturePixelsPerPoint;

		public int leftSlice;

		public int topSlice;

		public int rightSlice;

		public int bottomSlice;

		public float sliceScale;

		public Vector4 rectInset;

		public NativeColorPage colorPage;

		public int meshFlags;
	}

	public const float kEpsilon = 0.001f;

	[ThreadSafe]
	public static MeshWriteDataInterface MakeBorder(NativeBorderParams borderParams, float posZ)
	{
		MakeBorder_Injected(ref borderParams, posZ, out var ret);
		return ret;
	}

	[ThreadSafe]
	public static MeshWriteDataInterface MakeSolidRect(NativeRectParams rectParams, float posZ)
	{
		MakeSolidRect_Injected(ref rectParams, posZ, out var ret);
		return ret;
	}

	[ThreadSafe]
	public static MeshWriteDataInterface MakeTexturedRect(NativeRectParams rectParams, float posZ)
	{
		MakeTexturedRect_Injected(ref rectParams, posZ, out var ret);
		return ret;
	}

	[ThreadSafe]
	public unsafe static MeshWriteDataInterface MakeVectorGraphicsStretchBackground(Vertex[] svgVertices, ushort[] svgIndices, float svgWidth, float svgHeight, Rect targetRect, Rect sourceUV, ScaleMode scaleMode, Color tint, NativeColorPage colorPage)
	{
		Span<Vertex> span = new Span<Vertex>(svgVertices);
		MeshWriteDataInterface ret;
		fixed (Vertex* begin = span)
		{
			ManagedSpanWrapper svgVertices2 = new ManagedSpanWrapper(begin, span.Length);
			Span<ushort> span2 = new Span<ushort>(svgIndices);
			fixed (ushort* begin2 = span2)
			{
				ManagedSpanWrapper svgIndices2 = new ManagedSpanWrapper(begin2, span2.Length);
				MakeVectorGraphicsStretchBackground_Injected(ref svgVertices2, ref svgIndices2, svgWidth, svgHeight, ref targetRect, ref sourceUV, scaleMode, ref tint, ref colorPage, out ret);
			}
		}
		return ret;
	}

	[ThreadSafe]
	public unsafe static MeshWriteDataInterface MakeVectorGraphics9SliceBackground(Vertex[] svgVertices, ushort[] svgIndices, float svgWidth, float svgHeight, Rect targetRect, Vector4 sliceLTRB, Color tint, NativeColorPage colorPage)
	{
		Span<Vertex> span = new Span<Vertex>(svgVertices);
		MeshWriteDataInterface ret;
		fixed (Vertex* begin = span)
		{
			ManagedSpanWrapper svgVertices2 = new ManagedSpanWrapper(begin, span.Length);
			Span<ushort> span2 = new Span<ushort>(svgIndices);
			fixed (ushort* begin2 = span2)
			{
				ManagedSpanWrapper svgIndices2 = new ManagedSpanWrapper(begin2, span2.Length);
				MakeVectorGraphics9SliceBackground_Injected(ref svgVertices2, ref svgIndices2, svgWidth, svgHeight, ref targetRect, ref sliceLTRB, ref tint, ref colorPage, out ret);
			}
		}
		return ret;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void MakeBorder_Injected([In] ref NativeBorderParams borderParams, float posZ, out MeshWriteDataInterface ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void MakeSolidRect_Injected([In] ref NativeRectParams rectParams, float posZ, out MeshWriteDataInterface ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void MakeTexturedRect_Injected([In] ref NativeRectParams rectParams, float posZ, out MeshWriteDataInterface ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void MakeVectorGraphicsStretchBackground_Injected(ref ManagedSpanWrapper svgVertices, ref ManagedSpanWrapper svgIndices, float svgWidth, float svgHeight, [In] ref Rect targetRect, [In] ref Rect sourceUV, ScaleMode scaleMode, [In] ref Color tint, [In] ref NativeColorPage colorPage, out MeshWriteDataInterface ret);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern void MakeVectorGraphics9SliceBackground_Injected(ref ManagedSpanWrapper svgVertices, ref ManagedSpanWrapper svgIndices, float svgWidth, float svgHeight, [In] ref Rect targetRect, [In] ref Vector4 sliceLTRB, [In] ref Color tint, [In] ref NativeColorPage colorPage, out MeshWriteDataInterface ret);
}
