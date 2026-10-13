#define UNITY_ASSERTIONS
using System;
using System.Runtime.CompilerServices;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Profiling;
using UnityEngine.UIElements.UIR;

namespace UnityEngine.UIElements;

internal static class UIRUtility
{
	private static readonly ProfilerMarker k_ComputeTransformMatrixMarker = new ProfilerMarker("UIR.ComputeTransformMatrix");

	public static readonly string k_DefaultShaderName = Shaders.k_Runtime;

	public static readonly string k_DefaultWorldSpaceShaderName = Shaders.k_RuntimeWorld;

	public const float k_Epsilon = 1E-30f;

	public const float k_ClearZ = 0.99f;

	public const float k_MeshPosZ = 0f;

	public const float k_MaskPosZ = 1f;

	public const int k_MaxMaskDepth = 7;

	public const byte k_DynamicColorDisabled = 0;

	public const byte k_DynamicColorEnabled = 1;

	public const byte k_DynamicColorEnabledText = 2;

	[ThreadStatic]
	private static int? s_ThreadIndex;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool ShapeWindingIsClockwise(int maskDepth, int stencilRef)
	{
		Debug.Assert(maskDepth == stencilRef || maskDepth == stencilRef + 1);
		return maskDepth == stencilRef;
	}

	public static void GetVerticesTransformInfo(VisualElement ve, out Matrix4x4 transform)
	{
		if (RenderChainVEData.AllocatesID(ve.renderChainData.transformID) || ve.renderChainData.isGroupTransform)
		{
			transform = Matrix4x4.identity;
		}
		else if (ve.renderChainData.boneTransformAncestor != null)
		{
			if (ve.renderChainData.boneTransformAncestor.renderChainData.worldTransformScaleZero)
			{
				ComputeTransformMatrix(ve, ve.renderChainData.boneTransformAncestor, out transform);
			}
			else
			{
				VisualElement.MultiplyMatrix34(ref ve.renderChainData.boneTransformAncestor.worldTransformInverse, ref ve.worldTransformRef, out transform);
			}
		}
		else if (ve.renderChainData.groupTransformAncestor != null)
		{
			if (ve.renderChainData.groupTransformAncestor.renderChainData.worldTransformScaleZero)
			{
				ComputeTransformMatrix(ve, ve.renderChainData.groupTransformAncestor, out transform);
			}
			else
			{
				VisualElement.MultiplyMatrix34(ref ve.renderChainData.groupTransformAncestor.worldTransformInverse, ref ve.worldTransformRef, out transform);
			}
		}
		else
		{
			transform = ve.worldTransform;
		}
		BaseVisualElementPanel elementPanel = ve.elementPanel;
		if (elementPanel != null && elementPanel.isFlat)
		{
			transform.m22 = 1f;
		}
	}

	internal static void ComputeTransformMatrix(VisualElement ve, VisualElement ancestor, out Matrix4x4 result)
	{
		ve.GetPivotedMatrixWithLayout(out result);
		VisualElement parent = ve.hierarchy.parent;
		if (parent == null || ancestor == parent)
		{
			return;
		}
		Matrix4x4 rhs = default;
		bool flag = true;
		do
		{
			parent.GetPivotedMatrixWithLayout(out var result2);
			if (flag)
			{
				VisualElement.MultiplyMatrix34(ref result2, ref result, out rhs);
			}
			else
			{
				VisualElement.MultiplyMatrix34(ref result2, ref rhs, out result);
			}
			parent = parent.hierarchy.parent;
			flag = !flag;
		}
		while (parent != null && ancestor != parent);
		if (!flag)
		{
			result = rhs;
		}
	}

	public static Vector4 ToVector4(Rect rc)
	{
		return new Vector4(rc.xMin, rc.yMin, rc.xMax, rc.yMax);
	}

	public static bool IsRoundRect(VisualElement ve)
	{
		IResolvedStyle resolvedStyle = ve.resolvedStyle;
		return !(resolvedStyle.borderTopLeftRadius < 1E-30f) || !(resolvedStyle.borderTopRightRadius < 1E-30f) || !(resolvedStyle.borderBottomLeftRadius < 1E-30f) || !(resolvedStyle.borderBottomRightRadius < 1E-30f);
	}

	public static void Multiply2D(this Quaternion rotation, ref Vector2 point)
	{
		float num = rotation.z * 2f;
		float num2 = 1f - rotation.z * num;
		float num3 = rotation.w * num;
		point = new Vector2(num2 * point.x - num3 * point.y, num3 * point.x + num2 * point.y);
	}

	public static bool IsVectorImageBackground(VisualElement ve)
	{
		return ve.computedStyle.backgroundImage.vectorImage != null;
	}

	public static bool IsElementSelfHidden(VisualElement ve)
	{
		return ve.resolvedStyle.visibility == Visibility.Hidden;
	}

	public static void Destroy(Object obj)
	{
		if (!(obj == null))
		{
			if (Application.isPlaying)
			{
				Object.Destroy(obj);
			}
			else
			{
				Object.DestroyImmediate(obj);
			}
		}
	}

	public static int GetPrevPow2(int n)
	{
		int num = 0;
		while (n > 1)
		{
			n >>= 1;
			num++;
		}
		return 1 << num;
	}

	public static int GetNextPow2(int n)
	{
		int num;
		for (num = 1; num < n; num <<= 1)
		{
		}
		return num;
	}

	public static int GetNextPow2Exp(int n)
	{
		int num = 1;
		int num2 = 0;
		while (num < n)
		{
			num <<= 1;
			num2++;
		}
		return num2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int GetThreadIndex()
	{
		int? num = s_ThreadIndex;
		if (num.HasValue)
		{
			return num.Value;
		}
		int threadIndex = JobsUtility.ThreadIndex;
		s_ThreadIndex = threadIndex;
		return threadIndex;
	}
}
