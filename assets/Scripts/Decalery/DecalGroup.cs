using System.Collections.Generic;
using UnityEngine;

public class DecalGroup : MonoBehaviour
{
	public enum PickMode
	{
		Manual = 0,
		BoxIntersection = 1,
		RaycastFromVertices = 2
	}

	public GameObject parentObject;

	public List<GameObject> parentObjectsAdditional;

	public bool pickParentWithRaycast;

	public bool pickParentWithBox;

	public float bias;

	public float rayLength = 0.1f;

	public bool roadTransform;

	public Material optionalMateralChange;

	public List<Material> optionalMateralChangeAdditional;

	public bool tangents;

	public bool linkToParent;

	public bool linkToDecalGroup;

	public bool angleFade;

	public bool optimize;

	public bool useBurst;

	public bool makeAsset;

	public bool autoHideRenderer = true;

	public Material[] surfaceReplacement;

	public Material[] surfaceReplacementMaterial;

	public PickMode pickMode;

	public float boxScale = 1f;

	public LayerMask layerMask = -1;

	[Range(-1f, 1f)]
	public float angleClip = 0.5f;

	public string originalName;

	public List<GameObject> sceneObjects;

	[Range(0f, 1f)]
	public float atlasMinX;

	[Range(0f, 1f)]
	public float atlasMinY;

	[Range(0f, 1f)]
	public float atlasMaxX = 1f;

	[Range(0f, 1f)]
	public float atlasMaxY = 1f;

	public Vector3 avgDir;

	public static bool drawGizmoMode;

	public static Mesh drawGizmoMesh;

	public static Matrix4x4 drawGizmoMatrix;

	private void OnDrawGizmos()
	{
		Transform transform = base.transform;
		if (Mathf.Abs(avgDir.x) + Mathf.Abs(avgDir.y) + Mathf.Abs(avgDir.z) > 0.1f)
		{
			Gizmos.matrix = Matrix4x4.TRS(transform.position, Quaternion.LookRotation(-avgDir), Vector3.one);
			Gizmos.color = Color.white;
			Gizmos.DrawFrustum(Vector3.zero, 90f, 0.1f, 0f, 1f);
			Color cyan = Color.cyan;
			cyan.a = 0.5f;
			Gizmos.color = cyan;
			Gizmos.DrawCube(new Vector3(0f, 0f, 0.1f), new Vector3(0.2f, 0.2f, 0.01f));
		}
		else
		{
			Color cyan2 = Color.cyan;
			cyan2.a = 0.5f;
			Gizmos.color = cyan2;
			Gizmos.DrawSphere(transform.position, 0.1f);
			Gizmos.DrawWireSphere(transform.position, 0.1f);
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		if (pickMode == PickMode.BoxIntersection)
		{
			MeshRenderer component = GetComponent<MeshRenderer>();
			if (component != null)
			{
				Vector3 vector = component.bounds.extents * 2f * boxScale;
				vector = new Vector3(Mathf.Max(vector.x, rayLength), Mathf.Max(vector.y, rayLength), Mathf.Max(vector.z, rayLength));
				Gizmos.matrix = Matrix4x4.identity;
				Gizmos.DrawWireCube(component.bounds.center, vector);
			}
		}
		if (drawGizmoMode)
		{
			Gizmos.matrix = drawGizmoMatrix;
			Gizmos.DrawWireMesh(drawGizmoMesh);
		}
	}
}
