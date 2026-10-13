using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Isto.Core;

public class CustomTransformation : MonoBehaviour
{
	[Tooltip("If this object's text mesh is being animated, then we need to refresh the transformation every frame, so enable this")]
	public bool isAnimated;

	public Matrix4x4 transformationMatrix = Matrix4x4.identity;

	private Mesh mesh;

	private Vector3[] startVertices;

	private Vector3[] vertices;

	private TMP_Text _text;

	private bool refreshPending;

	private TMP_Text Text
	{
		get
		{
			if (_text == null)
			{
				_text = GetComponent<TMP_Text>();
			}
			return _text;
		}
	}

	private void OnEnable()
	{
		RefreshAtEndOfFrame();
	}

	private void LateUpdate()
	{
		if (isAnimated)
		{
			Text.ForceMeshUpdate();
			Refresh();
		}
	}

	public void RefreshAtEndOfFrame()
	{
		if (!refreshPending)
		{
			StartCoroutine(WaitAndRefresh());
		}
	}

	private IEnumerator WaitAndRefresh()
	{
		Text.ForceMeshUpdate();
		Refresh();
		refreshPending = true;
		yield return new WaitForEndOfFrame();
		Text.ForceMeshUpdate();
		Refresh();
	}

	public void Refresh()
	{
		InitializeMesh();
		SetupCache();
		ComputeTransformation();
		ApplyMesh();
		refreshPending = false;
	}

	private void InitializeMesh()
	{
		if (_text != null)
		{
			mesh = Text.mesh;
		}
		else
		{
			mesh = GetComponent<MeshFilter>().mesh;
		}
	}

	private void SetupCache()
	{
		List<Vector3> list = new List<Vector3>(mesh.vertices);
		startVertices = list.ToArray();
		vertices = list.ToArray();
	}

	private void ComputeTransformation()
	{
		if (startVertices != null)
		{
			for (int i = 0; i < vertices.Length; i++)
			{
				vertices[i] = transformationMatrix.MultiplyPoint(startVertices[i]);
			}
		}
	}

	private void ApplyMesh()
	{
		mesh.vertices = vertices;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
	}
}
