using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace CapsuleOcclusion;

[ExecuteInEditMode]
public class OcclusionCapsule : MonoBehaviour
{
	public const int MAX_CAPSULE_COUNT = 512;

	public static List<OcclusionCapsule> instances = new List<OcclusionCapsule>();

	public Vector3 A = new Vector3(0f, 0f, 0f);

	public Vector3 B = new Vector3(0f, 1f, 0f);

	[Min(0f)]
	public float radius = 0.1f;

	private Vector3 m_cachedPoint1;

	private Vector3 m_cachedPoint2;

	private float m_cachedRadiusSum;

	private Bounds m_cachedBounds;

	private float m_sortKey;

	private static int s_visibleCapsuleCount;

	private static Plane[] s_frustumPlanes = new Plane[6];

	private static List<OcclusionCapsule> s_visibleCapsules = new List<OcclusionCapsule>();

	private static Matrix4x4[] s_matrices = new Matrix4x4[512];

	private static Vector4[] s_capsuleParams1 = new Vector4[512];

	private static Vector4[] s_capsuleParams2 = new Vector4[512];

	public static int visibleCapsuleCount => s_visibleCapsuleCount;

	public Vector3 point1 => base.transform.TransformPoint(A);

	public Vector3 point2 => base.transform.TransformPoint(B);

	public static void UpdateCapsuleDataForCamera(Camera camera, int maxCount, float rangeMultiplier, bool cull, bool sort)
	{
		CacheDataForCamera(camera, rangeMultiplier);
		maxCount = Mathf.Min(maxCount, 511);
		s_visibleCapsules.Clear();
		int count;
		if (cull)
		{
			GeometryUtility.CalculateFrustumPlanes(camera, s_frustumPlanes);
			count = instances.Count;
			for (int i = 0; i < count; i++)
			{
				OcclusionCapsule occlusionCapsule = instances[i];
				if (GeometryUtility.TestPlanesAABB(s_frustumPlanes, occlusionCapsule.m_cachedBounds))
				{
					s_visibleCapsules.Add(occlusionCapsule);
				}
			}
		}
		else
		{
			s_visibleCapsules.AddRange(instances);
		}
		if (sort)
		{
			Vector3 vector = camera.transform.position * 2f;
			count = s_visibleCapsules.Count;
			for (int j = 0; j < count; j++)
			{
				OcclusionCapsule occlusionCapsule2 = s_visibleCapsules[j];
				occlusionCapsule2.m_sortKey = (vector - (occlusionCapsule2.m_cachedPoint1 + occlusionCapsule2.m_cachedPoint2)).sqrMagnitude;
			}
			s_visibleCapsules.Sort((OcclusionCapsule a, OcclusionCapsule b) => a.m_sortKey.CompareTo(b.m_sortKey));
		}
		s_visibleCapsuleCount = 0;
		count = s_visibleCapsules.Count;
		int num = Mathf.Min(maxCount, 512);
		for (int num2 = 0; num2 < count; num2++)
		{
			if (s_visibleCapsuleCount >= num)
			{
				break;
			}
			OcclusionCapsule occlusionCapsule3 = s_visibleCapsules[num2];
			Vector4 vector2 = occlusionCapsule3.m_cachedPoint1;
			vector2.w = occlusionCapsule3.radius;
			Vector4 vector3 = occlusionCapsule3.m_cachedPoint2;
			vector3.w = occlusionCapsule3.radius * rangeMultiplier;
			s_capsuleParams1[s_visibleCapsuleCount] = vector2;
			s_capsuleParams2[s_visibleCapsuleCount] = vector3;
			s_visibleCapsuleCount++;
		}
		Shader.SetGlobalVectorArray(ShaderIDs.CapsuleParams1, s_capsuleParams1);
		Shader.SetGlobalVectorArray(ShaderIDs.CapsuleParams2, s_capsuleParams2);
		Shader.SetGlobalInt(ShaderIDs.CapsuleCount, s_visibleCapsuleCount);
	}

	public static void DrawCapsules(CommandBuffer cmd, Mesh mesh, int subMesh, Material material, int shaderPass)
	{
		cmd.DrawMeshInstanced(mesh, subMesh, material, shaderPass, s_matrices, s_visibleCapsuleCount);
	}

	private static void CacheDataForCamera(Camera camera, float rangeMultiplier)
	{
		for (int i = 0; i < instances.Count; i++)
		{
			if (s_visibleCapsuleCount >= 512)
			{
				break;
			}
			instances[i].CacheInstanceData(rangeMultiplier);
		}
	}

	private void CacheInstanceData(float rangeMultiplier)
	{
		_ = base.transform;
		m_cachedPoint1 = point1;
		m_cachedPoint2 = point2;
		m_cachedRadiusSum = radius + radius * rangeMultiplier;
		float num = ((m_cachedPoint1.x < m_cachedPoint2.x) ? m_cachedPoint1.x : m_cachedPoint2.x) - m_cachedRadiusSum;
		float num2 = ((m_cachedPoint1.y < m_cachedPoint2.y) ? m_cachedPoint1.y : m_cachedPoint2.y) - m_cachedRadiusSum;
		float num3 = ((m_cachedPoint1.z < m_cachedPoint2.z) ? m_cachedPoint1.z : m_cachedPoint2.z) - m_cachedRadiusSum;
		float num4 = ((m_cachedPoint1.x > m_cachedPoint2.x) ? m_cachedPoint1.x : m_cachedPoint2.x) + m_cachedRadiusSum;
		float num5 = ((m_cachedPoint1.y > m_cachedPoint2.y) ? m_cachedPoint1.y : m_cachedPoint2.y) + m_cachedRadiusSum;
		float num6 = ((m_cachedPoint1.z > m_cachedPoint2.z) ? m_cachedPoint1.z : m_cachedPoint2.z) + m_cachedRadiusSum;
		m_cachedBounds = new Bounds(new Vector3((num + num4) * 0.5f, (num2 + num5) * 0.5f, (num3 + num6) * 0.5f), new Vector3(num4 - num, num5 - num2, num6 - num3));
	}

	private void OnEnable()
	{
		instances.Add(this);
	}

	private void OnDisable()
	{
		instances.Remove(this);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
		DrawCapsuleGizmo(point1, point2, radius);
		Gizmos.color = Color.yellow;
	}

	private static void DrawCapsuleGizmo(Vector3 point1, Vector3 point2, float radius)
	{
		Gizmos.DrawWireSphere(point1, radius);
		Gizmos.DrawWireSphere(point2, radius);
		Vector3 normalized = (point2 - point1).normalized;
		Vector3 up = Vector3.up;
		Vector3 normalized2 = Vector3.Cross(up, normalized).normalized;
		up = Vector3.Cross(normalized, normalized2);
		Gizmos.DrawLine(point1 - up * radius, point2 - up * radius);
		Gizmos.DrawLine(point1 + up * radius, point2 + up * radius);
		Gizmos.DrawLine(point1 - normalized2 * radius, point2 - normalized2 * radius);
		Gizmos.DrawLine(point1 + normalized2 * radius, point2 + normalized2 * radius);
	}

	public void DrawBoundsGizmo()
	{
		Gizmos.color = new Color(1f, 0f, 0f, 0.1f);
		Gizmos.DrawCube(m_cachedBounds.center, m_cachedBounds.size);
		Gizmos.color = new Color(1f, 0f, 0f, 1f);
		Gizmos.DrawWireCube(m_cachedBounds.center, m_cachedBounds.size);
	}
}
