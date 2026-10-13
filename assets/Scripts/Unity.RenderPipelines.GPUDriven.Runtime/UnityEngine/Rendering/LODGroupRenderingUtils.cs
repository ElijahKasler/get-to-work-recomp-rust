using System;

namespace UnityEngine.Rendering;

internal static class LODGroupRenderingUtils
{
	public static float CalculateFOVHalfAngle(float fieldOfView)
	{
		return Mathf.Tan(MathF.PI / 180f * fieldOfView * 0.5f);
	}

	public static float CalculateScreenRelativeMetric(LODParameters lodParams, float lodBias)
	{
		float num;
		if (lodParams.isOrthographic)
		{
			num = 2f * lodParams.orthoSize;
		}
		else
		{
			float num2 = CalculateFOVHalfAngle(lodParams.fieldOfView);
			num = 2f * num2;
		}
		return num / lodBias;
	}

	public static float CalculatePerspectiveDistance(Vector3 objPosition, Vector3 camPosition, float sqrScreenRelativeMetric)
	{
		return Mathf.Sqrt(CalculateSqrPerspectiveDistance(objPosition, camPosition, sqrScreenRelativeMetric));
	}

	public static float CalculateSqrPerspectiveDistance(Vector3 objPosition, Vector3 camPosition, float sqrScreenRelativeMetric)
	{
		return (objPosition - camPosition).sqrMagnitude * sqrScreenRelativeMetric;
	}

	public static Vector3 GetWorldReferencePoint(this LODGroup lodGroup)
	{
		return lodGroup.transform.TransformPoint(lodGroup.localReferencePoint);
	}

	public static float GetWorldSpaceScale(this LODGroup lodGroup)
	{
		Vector3 lossyScale = lodGroup.transform.lossyScale;
		return Mathf.Max(Mathf.Max(Mathf.Abs(lossyScale.x), Mathf.Abs(lossyScale.y)), Mathf.Abs(lossyScale.z));
	}

	public static float GetWorldSpaceSize(this LODGroup lodGroup)
	{
		return lodGroup.GetWorldSpaceScale() * lodGroup.size;
	}

	public static float CalculateLODDistance(float relativeScreenHeight, float size)
	{
		return size / relativeScreenHeight;
	}
}
