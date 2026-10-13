using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CPUDecalUtils : MonoBehaviour
{
	private struct HashedVertex
	{
		public Vector3 pos;

		public Vector3 normal;

		public Vector2 uv;

		public Vector2 uv2;

		public Color color;
	}

	private static BoneWeight tmpWeight;

	private static Plane decalTriPlane = default;

	private static Plane decalCutPlaneAB = default;

	private static Plane decalCutPlaneBC = default;

	private static Plane decalCutPlaneCA = default;

	private static Plane triPlane = default;

	private static Vector3[] splitTriPos = new Vector3[3];

	private static Vector3[] splitTriNormal = new Vector3[3];

	private static Vector2[] splitTriUV = new Vector2[3];

	private static Vector2[] splitTriUV2 = new Vector2[3];

	private static BoneWeight[] splitTriSkin = new BoneWeight[3];

	private static Color[] splitTriColor = new Color[3];

	private static Color decalColorA = default;

	private static Color decalColorB = default;

	private static Color decalColorC = default;

	private static Matrix4x4 cullingMatrix;

	private static Vector4 lightmapScaleOffset;

	private static float saturate(float f)
	{
		return Mathf.Clamp(f, 0f, 1f);
	}

	private static Vector3 triLerp(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 a, Vector3 b, Vector3 c, Vector3 pp)
	{
		Vector3 vector = b - a;
		Vector3 vector2 = c - a;
		Vector3 lhs = pp - a;
		float num = Vector3.Dot(vector, vector);
		float num2 = Vector3.Dot(vector, vector2);
		float num3 = Vector3.Dot(vector2, vector2);
		float num4 = Vector3.Dot(lhs, vector);
		float num5 = Vector3.Dot(lhs, vector2);
		float num6 = num * num3 - num2 * num2;
		float num7 = (num3 * num4 - num2 * num5) / num6;
		float num8 = (num * num5 - num2 * num4) / num6;
		float num9 = 1f - num7 - num8;
		return p0 * num9 + p1 * num7 + p2 * num8;
	}

	private static Color triLerp(Color p0, Color p1, Color p2, Vector3 a, Vector3 b, Vector3 c, Vector3 pp)
	{
		Vector3 vector = b - a;
		Vector3 vector2 = c - a;
		Vector3 lhs = pp - a;
		float num = Vector3.Dot(vector, vector);
		float num2 = Vector3.Dot(vector, vector2);
		float num3 = Vector3.Dot(vector2, vector2);
		float num4 = Vector3.Dot(lhs, vector);
		float num5 = Vector3.Dot(lhs, vector2);
		float num6 = num * num3 - num2 * num2;
		float num7 = (num3 * num4 - num2 * num5) / num6;
		float num8 = (num * num5 - num2 * num4) / num6;
		float num9 = 1f - num7 - num8;
		return p0 * num9 + p1 * num7 + p2 * num8;
	}

	private static BoneWeight LerpBoneWeights(BoneWeight a, BoneWeight b, float c)
	{
		a.weight0 = Mathf.Lerp(a.weight0, b.weight0, c);
		a.weight1 = Mathf.Lerp(a.weight1, b.weight1, c);
		a.weight2 = Mathf.Lerp(a.weight2, b.weight2, c);
		a.weight3 = Mathf.Lerp(a.weight3, b.weight3, c);
		return a;
	}

	private static void WeldVerts(List<int> inIndices, List<Vector3> inVerts, List<Vector3> inNormals, List<Vector2> inUV, List<Vector2> inUV2, List<BoneWeight> inSkin, List<Color> inColor, List<int> outIndices, List<Vector3> outVerts, List<Vector3> outNormals, List<Vector2> outUV, List<Vector2> outUV2, List<BoneWeight> outSkin, List<Color> outColor)
	{
		bool flag = inUV != null && inUV.Count > 0;
		bool flag2 = inColor != null && inColor.Count > 0;
		bool flag3 = inSkin != null && inSkin.Count > 0;
		HashedVertex key = default;
		Dictionary<HashedVertex, int> dictionary = new Dictionary<HashedVertex, int>();
		int count = inVerts.Count;
		int num = 0;
		int[] array = new int[count];
		for (int i = 0; i < count; i++)
		{
			array[i] = -1;
		}
		for (int j = 0; j < count; j++)
		{
			key.pos = inVerts[j];
			key.normal = inNormals[j];
			if (flag)
			{
				key.uv = inUV[j];
			}
			key.uv2 = inUV2[j];
			if (flag2)
			{
				key.color = inColor[j];
			}
			if (!dictionary.TryGetValue(key, out var value))
			{
				value = (dictionary[key] = num);
				array[j] = num;
				outVerts.Add(inVerts[j]);
				outNormals.Add(inNormals[j]);
				outUV2.Add(inUV2[j]);
				if (flag)
				{
					outUV.Add(inUV[j]);
				}
				if (flag2)
				{
					outColor.Add(inColor[j]);
				}
				if (flag3)
				{
					outSkin.Add(inSkin[j]);
				}
				num++;
			}
			else
			{
				array[j] = value;
			}
		}
		int count2 = inIndices.Count;
		for (int k = 0; k < count2; k++)
		{
			outIndices.Add(array[inIndices[k]]);
		}
	}

	private static void UpdateDecalFor(DecalGroup decal, Material sharedMaterial, Vector2[] decalUV, Vector3[] decalPosW, Transform decalTform, int[] decalTris, Color[] decalColor, GameObject parentObject, Material optionalMateralChange, float opacity, ref int fixedOffset, byte decalID = 0, Mesh newMesh = null, Vector3[] vPos = null, Vector3[] vNormal = null, Vector2[] vUV = null, Vector2[] vUV2 = null, Color[] vColor = null, BoneWeight[] vSkin = null, byte[] vDecalID = null, Vector4[] vTangents = null, int maxTrisInDecal = 0, bool transformToParent = false, bool earlyCull = false, bool transformUV1 = false)
	{
		if (decal.roadTransform)
		{
			Transform obj = decal.transform;
			Vector3 right = obj.right;
			Vector3 up = obj.up;
			Vector3 position = obj.position;
			Vector2 mainTextureScale = sharedMaterial.mainTextureScale;
			Vector2 mainTextureOffset = sharedMaterial.mainTextureOffset;
			Vector2 vector = new Vector2(right.x, 0f - right.z);
			Vector2 vector2 = new Vector2(0f - up.x, up.z);
			int num = decalUV.Length;
			for (int i = 0; i < num; i++)
			{
				float num2 = decalPosW[i].z - position.z;
				float num3 = decalPosW[i].x - position.x;
				decalUV[i] = new Vector2(num2 * vector.x + num3 * vector.y, num2 * vector2.x + num3 * vector2.y);
				decalUV[i] = new Vector2(decalUV[i].x * mainTextureScale.x + mainTextureOffset.x, decalUV[i].y * mainTextureScale.y + mainTextureOffset.y);
			}
		}
		if (decal.atlasMinX != 0f || decal.atlasMinY != 0f || decal.atlasMaxX != 1f || decal.atlasMaxY != 1f)
		{
			int num4 = decalUV.Length;
			float num5 = decal.atlasMaxX - decal.atlasMinX;
			float num6 = decal.atlasMaxY - decal.atlasMinY;
			float atlasMinX = decal.atlasMinX;
			float atlasMinY = decal.atlasMinY;
			for (int j = 0; j < num4; j++)
			{
				decalUV[j] = new Vector2(decalUV[j].x * num5 + atlasMinX, 1f - ((1f - decalUV[j].y) * num6 + atlasMinY));
			}
		}
		if (decalTform != null && Mathf.Sign(decalTform.lossyScale.x * decalTform.lossyScale.y * decalTform.lossyScale.z) < 0f)
		{
			int[] array = new int[decalTris.Length];
			for (int k = 0; k < decalTris.Length; k += 3)
			{
				array[k] = decalTris[k + 2];
				array[k + 1] = decalTris[k + 1];
				array[k + 2] = decalTris[k];
			}
			decalTris = array;
		}
		Mesh sharedMesh = DecalUtils.GetSharedMesh(parentObject, out var terrain);
		if (sharedMesh == null && terrain == null)
		{
			return;
		}
		Transform transform = parentObject.transform;
		Renderer component = parentObject.GetComponent<Renderer>();
		Vector3[] array2;
		Vector3[] array3;
		Vector2[] array4;
		int[] array5;
		if (terrain != null)
		{
			TerrainData terrainData = terrain.terrainData;
			int num7 = decalTris.Length;
			float num8 = float.MaxValue;
			float num9 = float.MaxValue;
			float num10 = float.MinValue;
			float num11 = float.MinValue;
			float rayLength = decal.rayLength;
			float num12 = 0f - decal.bias;
			for (int l = 0; l < num7; l += 3)
			{
				int num13 = decalTris[l];
				int num14 = decalTris[l + 1];
				int num15 = decalTris[l + 2];
				Vector3 a = decalPosW[num13];
				Vector3 b = decalPosW[num14];
				Vector3 c = decalPosW[num15];
				decalTriPlane.Set3Points(a, b, c);
				Vector3 normal = decalTriPlane.normal;
				float num16 = a.x + normal.x * rayLength;
				float num17 = a.z + normal.z * rayLength;
				if (num16 < num8)
				{
					num8 = num16;
				}
				if (num17 < num9)
				{
					num9 = num17;
				}
				if (num16 > num10)
				{
					num10 = num16;
				}
				if (num17 > num11)
				{
					num11 = num17;
				}
				num16 = b.x + normal.x * rayLength;
				num17 = b.z + normal.z * rayLength;
				if (num16 < num8)
				{
					num8 = num16;
				}
				if (num17 < num9)
				{
					num9 = num17;
				}
				if (num16 > num10)
				{
					num10 = num16;
				}
				if (num17 > num11)
				{
					num11 = num17;
				}
				num16 = c.x + normal.x * rayLength;
				num17 = c.z + normal.z * rayLength;
				if (num16 < num8)
				{
					num8 = num16;
				}
				if (num17 < num9)
				{
					num9 = num17;
				}
				if (num16 > num10)
				{
					num10 = num16;
				}
				if (num17 > num11)
				{
					num11 = num17;
				}
				num16 = a.x + normal.x * num12;
				num17 = a.z + normal.z * num12;
				if (num16 < num8)
				{
					num8 = num16;
				}
				if (num17 < num9)
				{
					num9 = num17;
				}
				if (num16 > num10)
				{
					num10 = num16;
				}
				if (num17 > num11)
				{
					num11 = num17;
				}
				num16 = b.x + normal.x * num12;
				num17 = b.z + normal.z * num12;
				if (num16 < num8)
				{
					num8 = num16;
				}
				if (num17 < num9)
				{
					num9 = num17;
				}
				if (num16 > num10)
				{
					num10 = num16;
				}
				if (num17 > num11)
				{
					num11 = num17;
				}
				num16 = c.x + normal.x * num12;
				num17 = c.z + normal.z * num12;
				if (num16 < num8)
				{
					num8 = num16;
				}
				if (num17 < num9)
				{
					num9 = num17;
				}
				if (num16 > num10)
				{
					num10 = num16;
				}
				if (num17 > num11)
				{
					num11 = num17;
				}
			}
			Vector3 position2 = transform.position;
			if (!DecalUtils.cachedTerrains.TryGetValue(terrainData, out var value))
			{
				value = DecalUtils.PrepareTerrain(terrainData, position2);
			}
			int heightmapResolution = terrainData.heightmapResolution;
			int num18 = 0;
			int num19 = 0;
			float num20 = (float)(heightmapResolution - 1) / terrainData.size.x;
			float num21 = (float)(heightmapResolution - 1) / terrainData.size.z;
			int num22 = (int)((num8 - position2.x) * num20);
			int num23 = (int)((num9 - position2.z) * num21);
			int num24 = (int)((num10 - position2.x) * num20) + 2;
			int num25 = (int)((num11 - position2.z) * num21) + 2;
			if (num22 >= heightmapResolution || num23 >= heightmapResolution || num24 <= 0 || num25 <= 0)
			{
				return;
			}
			if (num22 < 0)
			{
				num22 = 0;
			}
			if (num23 < 0)
			{
				num23 = 0;
			}
			if (num24 > heightmapResolution)
			{
				num24 = heightmapResolution;
			}
			if (num25 > heightmapResolution)
			{
				num25 = heightmapResolution;
			}
			int num26 = num24 - num22;
			int num27 = num25 - num23;
			array2 = new Vector3[num26 * num27];
			array3 = new Vector3[num26 * num27];
			array4 = new Vector2[num26 * num27];
			array5 = new int[(num26 - 1) * (num27 - 1) * 2 * 3];
			for (int m = 0; m < num27; m++)
			{
				int num28 = (num23 + m) * heightmapResolution;
				for (int n = 0; n < num26; n++)
				{
					int num29 = num28 + (num22 + n);
					int num30 = m * num26 + n;
					array2[num30] = value.pos[num29];
					array3[num30] = value.norm[num29];
					array4[num30] = value.uv[num29];
					if (n < num26 - 1 && m < num27 - 1)
					{
						array5[num19] = num18;
						array5[num19 + 1] = num18 + num26;
						array5[num19 + 2] = num18 + num26 + 1;
						array5[num19 + 3] = num18;
						array5[num19 + 4] = num18 + num26 + 1;
						array5[num19 + 5] = num18 + 1;
						num19 += 6;
					}
					num18++;
				}
			}
		}
		else
		{
			array2 = sharedMesh.vertices;
			array3 = sharedMesh.normals;
			array5 = sharedMesh.triangles;
			array4 = sharedMesh.uv2;
		}
		if (array4.Length == 0)
		{
			array4 = sharedMesh.uv;
			if (array4.Length == 0)
			{
				array4 = new Vector2[array3.Length];
			}
		}
		SkinnedMeshRenderer skinnedMeshRenderer = component as SkinnedMeshRenderer;
		BoneWeight[] array6 = ((sharedMesh != null) ? sharedMesh.boneWeights : null);
		bool flag = array6 != null && array6.Length != 0 && skinnedMeshRenderer != null;
		int num31 = array2.Length;
		Vector3[] array7 = new Vector3[num31];
		Vector3[] array8 = new Vector3[num31];
		bool flag2;
		if (terrain != null)
		{
			flag2 = false;
			array7 = array2;
		}
		else
		{
			flag2 = Mathf.Sign(transform.lossyScale.x * transform.lossyScale.y * transform.lossyScale.z) < 0f;
			for (int num32 = 0; num32 < num31; num32++)
			{
				array7[num32] = transform.TransformPoint(array2[num32]);
			}
		}
		bool flag3 = decalColor != null && decalColor.Length != 0;
		bool flag4 = flag3 || decal.angleFade || opacity != 1f;
		Color color2;
		Color color3;
		Color white;
		Color color = (color2 = (color3 = (white = Color.white)));
		bool flag5 = decalUV == null || decalUV.Length == 0;
		Vector2 zero = Vector2.zero;
		int num33 = decalTris.Length;
		int num34 = array5.Length;
		bool[] array9 = null;
		if (earlyCull)
		{
			array9 = new bool[num34];
			float num35 = cullingMatrix[0, 0];
			float num36 = cullingMatrix[0, 1];
			float num37 = cullingMatrix[0, 2];
			float num38 = cullingMatrix[0, 3];
			float num39 = cullingMatrix[1, 0];
			float num40 = cullingMatrix[1, 1];
			float num41 = cullingMatrix[1, 2];
			float num42 = cullingMatrix[1, 3];
			float num43 = cullingMatrix[2, 0];
			float num44 = cullingMatrix[2, 1];
			float num45 = cullingMatrix[2, 2];
			float num46 = cullingMatrix[2, 3];
			Vector3 vector4 = default;
			Vector3 vector5 = default;
			Vector3 vector6 = default;
			for (int num47 = 0; num47 < num34; num47 += 3)
			{
				Vector3 vector3 = array7[array5[num47]];
				vector4.x = num35 * vector3.x + num36 * vector3.y + num37 * vector3.z + num38;
				vector4.y = num39 * vector3.x + num40 * vector3.y + num41 * vector3.z + num42;
				vector4.z = num43 * vector3.x + num44 * vector3.y + num45 * vector3.z + num46;
				vector3 = array7[array5[num47 + 1]];
				vector5.x = num35 * vector3.x + num36 * vector3.y + num37 * vector3.z + num38;
				vector5.y = num39 * vector3.x + num40 * vector3.y + num41 * vector3.z + num42;
				vector5.z = num43 * vector3.x + num44 * vector3.y + num45 * vector3.z + num46;
				vector3 = array7[array5[num47 + 2]];
				vector6.x = num35 * vector3.x + num36 * vector3.y + num37 * vector3.z + num38;
				vector6.y = num39 * vector3.x + num40 * vector3.y + num41 * vector3.z + num42;
				vector6.z = num43 * vector3.x + num44 * vector3.y + num45 * vector3.z + num46;
				float num48 = ((vector4.x < vector5.x) ? vector4.x : vector5.x);
				num48 = ((vector6.x < num48) ? vector6.x : num48);
				float num49 = ((vector4.y < vector5.y) ? vector4.y : vector5.y);
				num49 = ((vector6.y < num49) ? vector6.y : num49);
				float num50 = ((vector4.z < vector5.z) ? vector4.z : vector5.z);
				num50 = ((vector6.z < num50) ? vector6.z : num50);
				float num51 = ((vector4.x > vector5.x) ? vector4.x : vector5.x);
				num51 = ((vector6.x > num51) ? vector6.x : num51);
				float num52 = ((vector4.y > vector5.y) ? vector4.y : vector5.y);
				num52 = ((vector6.y > num52) ? vector6.y : num52);
				float num53 = ((vector4.z > vector5.z) ? vector4.z : vector5.z);
				num53 = ((vector6.z > num53) ? vector6.z : num53);
				num48 -= 0.0001f;
				num49 -= 0.0001f;
				num50 -= 0.0001f;
				num51 += 0.0001f;
				num52 += 0.0001f;
				num53 += 0.0001f;
				bool flag6 = num48 <= 1f && num51 >= -1f && num49 <= 1f && num52 >= -1f && num50 <= 1f && num53 >= -1f;
				array9[num47] = !flag6;
			}
		}
		if (terrain != null)
		{
			array8 = array3;
		}
		else
		{
			for (int num54 = 0; num54 < num31; num54++)
			{
				array8[num54] = transform.TransformDirection(array3[num54]);
			}
		}
		bool flag7 = vPos != null;
		int num55 = 0;
		int num56 = fixedOffset;
		List<Vector3> list = null;
		List<Vector3> list2 = null;
		List<Vector2> list3 = null;
		List<Vector2> list4 = null;
		List<BoneWeight> list5 = null;
		List<Color> list6 = null;
		List<int> list7 = new List<int>();
		if (!flag7)
		{
			list = new List<Vector3>();
			list2 = new List<Vector3>();
			list3 = new List<Vector2>();
			list4 = new List<Vector2>();
			list5 = new List<BoneWeight>();
			if (flag4)
			{
				list6 = new List<Color>();
			}
			list7 = new List<int>();
		}
		else
		{
			num55 = vPos.Length;
		}
		float num57 = 0f;
		float num58 = 0f;
		if (decal.angleFade)
		{
			num57 = 1f / (1f - decal.angleClip);
			num58 = (0f - decal.angleClip) * num57;
		}
		decal.avgDir = Vector3.zero;
		for (int num59 = 0; num59 < num33; num59 += 3)
		{
			Vector3 vector7 = decalPosW[decalTris[num59]];
			Vector3 vector8 = decalPosW[decalTris[num59 + 1]];
			Vector3 vector9 = decalPosW[decalTris[num59 + 2]];
			Vector3 normalized = (vector8 - vector7).normalized;
			Vector3 normalized2 = (vector9 - vector8).normalized;
			Vector3 normalized3 = (vector7 - vector9).normalized;
			decalTriPlane.Set3Points(vector7, vector8, vector9);
			decal.avgDir += decalTriPlane.normal;
			Vector3 inNormal = Vector3.Cross(normalized, decalTriPlane.normal);
			decalCutPlaneAB.SetNormalAndPosition(inNormal, vector7);
			Vector3 inNormal2 = Vector3.Cross(normalized2, decalTriPlane.normal);
			decalCutPlaneBC.SetNormalAndPosition(inNormal2, vector8);
			Vector3 inNormal3 = Vector3.Cross(normalized3, decalTriPlane.normal);
			decalCutPlaneCA.SetNormalAndPosition(inNormal3, vector7);
			Vector2 vector10 = (flag5 ? zero : decalUV[decalTris[num59]]);
			Vector2 vector11 = (flag5 ? zero : decalUV[decalTris[num59 + 1]]);
			Vector2 vector12 = (flag5 ? zero : decalUV[decalTris[num59 + 2]]);
			if (flag3)
			{
				decalColorA = decalColor[decalTris[num59]];
				decalColorB = decalColor[decalTris[num59 + 1]];
				decalColorC = decalColor[decalTris[num59 + 2]];
			}
			for (int num60 = 0; num60 < num34; num60 += 3)
			{
				if (earlyCull && array9[num60])
				{
					continue;
				}
				int num61;
				int num62;
				int num63;
				if (flag2)
				{
					num61 = num60 + 2;
					num62 = num60 + 1;
					num63 = num60;
				}
				else
				{
					num61 = num60;
					num62 = num60 + 1;
					num63 = num60 + 2;
				}
				Vector3 vector13 = array7[array5[num61]];
				Vector3 vector14 = array7[array5[num62]];
				Vector3 vector15 = array7[array5[num63]];
				if (decal.angleFade)
				{
					splitTriNormal[0] = array8[array5[num61]];
					splitTriNormal[1] = array8[array5[num62]];
					splitTriNormal[2] = array8[array5[num63]];
					float num64 = Vector3.Dot(decalTriPlane.normal, splitTriNormal[0]);
					float num65 = Vector3.Dot(decalTriPlane.normal, splitTriNormal[1]);
					float num66 = Vector3.Dot(decalTriPlane.normal, splitTriNormal[2]);
					if (num64 < decal.angleClip && num65 < decal.angleClip && num66 < decal.angleClip)
					{
						continue;
					}
				}
				else
				{
					triPlane.Set3Points(vector13, vector14, vector15);
					if (Vector3.Dot(decalTriPlane.normal, triPlane.normal) < decal.angleClip)
					{
						continue;
					}
				}
				if ((decalTriPlane.GetDistanceToPoint(vector13) < 0f - decal.rayLength && decalTriPlane.GetDistanceToPoint(vector14) < 0f - decal.rayLength && decalTriPlane.GetDistanceToPoint(vector15) < 0f - decal.rayLength) || (decalTriPlane.GetDistanceToPoint(vector13) > decal.bias && decalTriPlane.GetDistanceToPoint(vector14) > decal.bias && decalTriPlane.GetDistanceToPoint(vector15) > decal.bias) || (decalCutPlaneAB.GetSide(vector13) && decalCutPlaneAB.GetSide(vector14) && decalCutPlaneAB.GetSide(vector15)) || (decalCutPlaneBC.GetSide(vector13) && decalCutPlaneBC.GetSide(vector14) && decalCutPlaneBC.GetSide(vector15)) || (decalCutPlaneCA.GetSide(vector13) && decalCutPlaneCA.GetSide(vector14) && decalCutPlaneCA.GetSide(vector15)))
				{
					continue;
				}
				bool num67 = !decalCutPlaneAB.GetSide(vector13) && !decalCutPlaneAB.GetSide(vector14) && !decalCutPlaneAB.GetSide(vector15) && !decalCutPlaneBC.GetSide(vector13) && !decalCutPlaneBC.GetSide(vector14) && !decalCutPlaneBC.GetSide(vector15) && !decalCutPlaneCA.GetSide(vector13) && !decalCutPlaneCA.GetSide(vector14) && !decalCutPlaneCA.GetSide(vector15);
				if (!decal.angleFade)
				{
					splitTriNormal[0] = array8[array5[num61]];
					splitTriNormal[1] = array8[array5[num62]];
					splitTriNormal[2] = array8[array5[num63]];
				}
				splitTriUV2[0] = array4[array5[num61]];
				splitTriUV2[1] = array4[array5[num62]];
				splitTriUV2[2] = array4[array5[num63]];
				if (flag)
				{
					splitTriSkin[0] = array6[array5[num61]];
					splitTriSkin[1] = array6[array5[num62]];
					splitTriSkin[2] = array6[array5[num63]];
				}
				if (num67)
				{
					Vector3 vector16 = triLerp(vector10, vector11, vector12, vector7, vector8, vector9, vector13);
					Vector3 vector17 = triLerp(vector10, vector11, vector12, vector7, vector8, vector9, vector14);
					Vector3 vector18 = triLerp(vector10, vector11, vector12, vector7, vector8, vector9, vector15);
					if (flag4)
					{
						if (flag3)
						{
							color = triLerp(decalColorA, decalColorB, decalColorC, vector7, vector8, vector9, vector13) * opacity;
							color2 = triLerp(decalColorA, decalColorB, decalColorC, vector7, vector8, vector9, vector14) * opacity;
							color3 = triLerp(decalColorA, decalColorB, decalColorC, vector7, vector8, vector9, vector15) * opacity;
						}
						else
						{
							color = (color2 = (color3 = white * opacity));
						}
						if (decal.angleFade)
						{
							color *= Mathf.Clamp(Vector3.Dot(splitTriNormal[0], decalTriPlane.normal) * num57 + num58, 0f, 1f);
							color2 *= Mathf.Clamp(Vector3.Dot(splitTriNormal[1], decalTriPlane.normal) * num57 + num58, 0f, 1f);
							color3 *= Mathf.Clamp(Vector3.Dot(splitTriNormal[2], decalTriPlane.normal) * num57 + num58, 0f, 1f);
						}
					}
					if (flag7)
					{
						if (fixedOffset + 3 >= num55)
						{
							fixedOffset = 0;
						}
						AddTriangle(ref fixedOffset, vPos, vNormal, vColor, vUV2, vUV, vSkin, vDecalID, vector13, splitTriNormal[0], color, splitTriUV2[0], vector16, splitTriSkin[0], vector14, splitTriNormal[1], color2, splitTriUV2[1], vector17, splitTriSkin[1], vector15, splitTriNormal[2], color3, splitTriUV2[2], vector18, splitTriSkin[2], decalID);
						continue;
					}
					list.Add(vector13);
					list.Add(vector14);
					list.Add(vector15);
					list2.Add(splitTriNormal[0]);
					list2.Add(splitTriNormal[1]);
					list2.Add(splitTriNormal[2]);
					list4.Add(splitTriUV2[0]);
					list4.Add(splitTriUV2[1]);
					list4.Add(splitTriUV2[2]);
					if (flag)
					{
						list5.Add(splitTriSkin[0]);
						list5.Add(splitTriSkin[1]);
						list5.Add(splitTriSkin[2]);
					}
					if (flag4)
					{
						list6.Add(color);
						list6.Add(color2);
						list6.Add(color3);
					}
					list3.Add(vector16);
					list3.Add(vector17);
					list3.Add(vector18);
					list7.Add(list.Count - 3);
					list7.Add(list.Count - 2);
					list7.Add(list.Count - 1);
					continue;
				}
				splitTriPos[0] = vector13;
				splitTriPos[1] = vector14;
				splitTriPos[2] = vector15;
				Plane plane = decalCutPlaneAB;
				List<Vector3> list8 = new List<Vector3>();
				List<Vector3> list9 = new List<Vector3>();
				List<Vector2> list10 = new List<Vector2>();
				List<BoneWeight> list11 = null;
				if (flag)
				{
					list11 = new List<BoneWeight>();
				}
				List<int> list12 = new List<int>();
				SplitTriangle(splitTriPos, splitTriNormal, splitTriUV, splitTriColor, splitTriUV2, flag ? splitTriSkin : null, plane, list8, list9, null, null, list10, list11, list12);
				plane = decalCutPlaneBC;
				List<Vector3> list13 = new List<Vector3>();
				List<Vector3> list14 = new List<Vector3>();
				List<Vector2> list15 = new List<Vector2>();
				List<BoneWeight> list16 = null;
				if (flag)
				{
					list16 = new List<BoneWeight>();
				}
				List<int> list17 = new List<int>();
				int count = list12.Count;
				for (int num68 = 0; num68 < count; num68 += 3)
				{
					splitTriPos[0] = list8[list12[num68]];
					splitTriPos[1] = list8[list12[num68 + 1]];
					splitTriPos[2] = list8[list12[num68 + 2]];
					splitTriNormal[0] = list9[list12[num68]];
					splitTriNormal[1] = list9[list12[num68 + 1]];
					splitTriNormal[2] = list9[list12[num68 + 2]];
					splitTriUV2[0] = list10[list12[num68]];
					splitTriUV2[1] = list10[list12[num68 + 1]];
					splitTriUV2[2] = list10[list12[num68 + 2]];
					if (flag)
					{
						splitTriSkin[0] = list11[list12[num68]];
						splitTriSkin[1] = list11[list12[num68 + 1]];
						splitTriSkin[2] = list11[list12[num68 + 2]];
					}
					SplitTriangle(splitTriPos, splitTriNormal, splitTriUV, splitTriColor, splitTriUV2, flag ? splitTriSkin : null, plane, list13, list14, null, null, list15, list16, list17);
				}
				plane = decalCutPlaneCA;
				int num69 = (flag7 ? fixedOffset : list3.Count);
				int count2 = list17.Count;
				for (int num70 = 0; num70 < count2; num70 += 3)
				{
					splitTriPos[0] = list13[list17[num70]];
					splitTriPos[1] = list13[list17[num70 + 1]];
					splitTriPos[2] = list13[list17[num70 + 2]];
					splitTriNormal[0] = list14[list17[num70]];
					splitTriNormal[1] = list14[list17[num70 + 1]];
					splitTriNormal[2] = list14[list17[num70 + 2]];
					splitTriUV2[0] = list15[list17[num70]];
					splitTriUV2[1] = list15[list17[num70 + 1]];
					splitTriUV2[2] = list15[list17[num70 + 2]];
					if (flag)
					{
						splitTriSkin[0] = list16[list17[num70]];
						splitTriSkin[1] = list16[list17[num70 + 1]];
						splitTriSkin[2] = list16[list17[num70 + 2]];
					}
					if (flag7)
					{
						SplitTriangle2(splitTriPos, splitTriNormal, splitTriUV, splitTriColor, splitTriUV2, flag ? splitTriSkin : null, plane, decalID, ref fixedOffset, vPos, vNormal, vUV, vColor, vUV2, vSkin, vDecalID);
					}
					else
					{
						SplitTriangle(splitTriPos, splitTriNormal, splitTriUV, splitTriColor, splitTriUV2, flag ? splitTriSkin : null, plane, list, list2, list3, list6, list4, list5, list7);
					}
				}
				int num71 = (flag7 ? fixedOffset : list3.Count);
				for (int num72 = num69; num72 < num71; num72++)
				{
					Vector3 pp = (flag7 ? vPos[num72] : list[num72]);
					Vector3 vector19 = triLerp(vector10, vector11, vector12, vector7, vector8, vector9, pp);
					if (flag7)
					{
						vUV[num72] = vector19;
					}
					else
					{
						list3[num72] = vector19;
					}
					if (flag4)
					{
						Color color4 = ((!flag3) ? white : (triLerp(decalColorA, decalColorB, decalColorC, vector7, vector8, vector9, pp) * opacity));
						if (decal.angleFade)
						{
							color4 *= Mathf.Clamp(Vector3.Dot(flag7 ? vNormal[num72] : list2[num72], decalTriPlane.normal) * num57 + num58, 0f, 1f) * opacity;
						}
						if (flag7)
						{
							vColor[num72] = color4;
						}
						else
						{
							list6[num72] = color4;
						}
					}
				}
			}
		}
		decal.avgDir = decal.avgDir.normalized;
		if (newMesh == null)
		{
			if (list.Count == 0)
			{
				Debug.Log("No mesh was created for " + decal.name + " / " + parentObject);
				return;
			}
			newMesh = new Mesh();
			if (flag)
			{
				Transform transform2 = transform;
				int count3 = list.Count;
				for (int num73 = 0; num73 < count3; num73++)
				{
					list[num73] = transform2.InverseTransformPoint(list[num73]);
					list2[num73] = transform2.InverseTransformDirection(list2[num73]);
				}
			}
			newMesh.vertices = list.ToArray();
			newMesh.normals = list2.ToArray();
			newMesh.uv = list3.ToArray();
			newMesh.uv2 = list4.ToArray();
			if (flag)
			{
				newMesh.boneWeights = list5.ToArray();
			}
			if (flag4)
			{
				newMesh.colors = list6.ToArray();
			}
			newMesh.triangles = list7.ToArray();
			if (decal.tangents)
			{
				newMesh.RecalculateTangents();
			}
			GameObject gameObject = new GameObject();
			gameObject.tag = decal.gameObject.tag;
			gameObject.name = "NEW_DECAL#" + decal.name + "#" + parentObject.name;
			if (decal.linkToParent)
			{
				gameObject.transform.parent = parentObject.transform;
			}
			else if (decal.linkToDecalGroup)
			{
				GameObject obj2 = new GameObject
				{
					name = "NEW_DECAL#parent"
				};
				Transform transform3 = decal.transform;
				Transform transform4 = obj2.transform;
				transform4.parent = transform3;
				transform4.localPosition = Vector3.zero;
				transform4.localRotation = Quaternion.identity;
				Vector3 localScale = transform3.localScale;
				transform4.localScale = new Vector3(1f / localScale.x, 1f / localScale.y, 1f / localScale.z);
				gameObject.transform.parent = transform4;
			}
			Renderer renderer = null;
			gameObject.layer = decal.gameObject.layer;
			if (flag)
			{
				SkinnedMeshRenderer skinnedMeshRenderer2 = gameObject.AddComponent<SkinnedMeshRenderer>();
				skinnedMeshRenderer2.sharedMaterial = ((optionalMateralChange != null) ? optionalMateralChange : sharedMaterial);
				skinnedMeshRenderer2.bones = skinnedMeshRenderer.bones;
				newMesh.bindposes = skinnedMeshRenderer.sharedMesh.bindposes;
				skinnedMeshRenderer2.sharedMesh = newMesh;
				skinnedMeshRenderer2.rootBone = skinnedMeshRenderer.rootBone;
				renderer = skinnedMeshRenderer2;
			}
			else
			{
				gameObject.AddComponent<MeshFilter>().sharedMesh = newMesh;
				renderer = gameObject.AddComponent<MeshRenderer>();
				renderer.sharedMaterial = ((optionalMateralChange != null) ? optionalMateralChange : sharedMaterial);
			}
			if (terrain != null)
			{
				renderer.lightmapIndex = terrain.lightmapIndex;
				renderer.lightmapScaleOffset = terrain.lightmapScaleOffset;
				renderer.realtimeLightmapIndex = terrain.realtimeLightmapIndex;
				renderer.realtimeLightmapScaleOffset = terrain.realtimeLightmapScaleOffset;
			}
			else
			{
				if (decal.surfaceReplacement != null)
				{
					for (int num74 = 0; num74 < decal.surfaceReplacement.Length; num74++)
					{
						if (decal.surfaceReplacement[num74] == component.sharedMaterial)
						{
							renderer.sharedMaterial = decal.surfaceReplacementMaterial[num74];
							break;
						}
					}
				}
				renderer.lightmapIndex = component.lightmapIndex;
				renderer.lightmapScaleOffset = component.lightmapScaleOffset;
				renderer.realtimeLightmapIndex = component.realtimeLightmapIndex;
				renderer.realtimeLightmapScaleOffset = component.realtimeLightmapScaleOffset;
				if (component.HasPropertyBlock())
				{
					MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
					component.GetPropertyBlock(materialPropertyBlock);
					renderer.SetPropertyBlock(materialPropertyBlock);
				}
			}
			GameObject gameObject2 = GameObject.Find("!decalLightmaps");
			if (gameObject2 != null)
			{
				Object.DestroyImmediate(gameObject2);
			}
			ftLightmapsStorage ftLightmapsStorage2 = null;
			if (ftLightmapsStorage2 == null)
			{
				GameObject gameObject3 = GameObject.Find("!ftraceLightmaps");
				if (gameObject3 == null)
				{
					gameObject3 = new GameObject();
					gameObject3.name = "!ftraceLightmaps";
					gameObject3.hideFlags = HideFlags.HideInHierarchy;
				}
				ftLightmapsStorage2 = gameObject3.GetComponent<ftLightmapsStorage>();
				if (ftLightmapsStorage2 == null)
				{
					ftLightmapsStorage2 = gameObject3.AddComponent<ftLightmapsStorage>();
				}
			}
			if (ftLightmapsStorage2 != null && ftLightmapsStorage2.bakedRenderers != null && ftLightmapsStorage2.bakedIDs != null && ftLightmapsStorage2.bakedRenderers.Count > 0)
			{
				int item = renderer.lightmapIndex;
				int num75 = ftLightmapsStorage2.bakedRenderers.LastIndexOf(component);
				if (num75 >= 0)
				{
					item = ftLightmapsStorage2.bakedIDs[num75];
				}
				ftLightmapsStorage2.bakedRenderers.Add(renderer);
				ftLightmapsStorage2.bakedIDs.Add(item);
				ftLightmapsStorage2.bakedScaleOffset.Add(renderer.lightmapScaleOffset);
			}
			return;
		}
		byte b2 = vDecalID[fixedOffset];
		int num76;
		int num77;
		if (b2 != 0)
		{
			num76 = fixedOffset;
			num77 = fixedOffset + maxTrisInDecal;
			float num78 = float.PositiveInfinity;
			Vector3 vector20 = new Vector3(num78, num78, num78);
			for (int num79 = num76; num79 < num77; num79++)
			{
				int num80 = num79;
				if (num80 >= num55)
				{
					num80 = num79 % num55;
				}
				if (vDecalID[num80] != b2)
				{
					break;
				}
				vPos[num80] = vector20;
			}
		}
		num76 = num56;
		num77 = ((fixedOffset >= num56) ? fixedOffset : (num55 + fixedOffset));
		if (transformToParent)
		{
			for (int num81 = num76; num81 < num77; num81++)
			{
				int num82 = num81;
				if (num82 >= num55)
				{
					num82 = num81 % num55;
				}
				vPos[num82] = transform.InverseTransformPoint(vPos[num82]);
				vNormal[num82] = transform.InverseTransformDirection(vNormal[num82]);
			}
		}
		if (transformUV1)
		{
			for (int num83 = num76; num83 < num77; num83++)
			{
				int num84 = num83;
				if (num84 >= num55)
				{
					num84 = num83 % num55;
				}
				vUV2[num84] = new Vector2(vUV2[num84].x * lightmapScaleOffset.x + lightmapScaleOffset.z, vUV2[num84].y * lightmapScaleOffset.y + lightmapScaleOffset.w);
			}
		}
		newMesh.vertices = vPos;
		newMesh.normals = vNormal;
		newMesh.uv = vUV;
		newMesh.uv2 = vUV2;
		if (flag)
		{
			newMesh.boneWeights = vSkin;
		}
		if (flag4)
		{
			newMesh.colors = vColor;
		}
		if (!decal.tangents)
		{
			return;
		}
		for (int num85 = num76; num85 < num77; num85 += 3)
		{
			int num86 = num85;
			if (num86 >= num55)
			{
				num86 = num85 % num55;
			}
			Vector3 vector21 = vPos[num86];
			if (!float.IsNaN(vector21.x))
			{
				Vector3 vector22 = vPos[num86 + 1];
				Vector3 vector23 = vPos[num86 + 2];
				Vector2 vector24 = vUV[num86];
				Vector2 vector25 = vUV[num86 + 1];
				Vector2 vector26 = vUV[num86 + 2];
				Vector3 vector27 = vector22 - vector21;
				Vector3 vector28 = vector23 - vector21;
				Vector2 vector29 = vector25 - vector24;
				Vector2 vector30 = vector26 - vector24;
				float num87 = 1f / (vector29.x * vector30.y - vector30.x * vector29.y);
				Vector3 normalized4 = ((vector30.y * vector27 - vector29.y * vector28) * num87).normalized;
				Vector3 normalized5 = ((vector29.x * vector28 - vector30.x * vector27) * num87).normalized;
				float w = ((Vector3.Dot(Vector3.Cross(vNormal[num86], normalized4), normalized5) < 0f) ? (-1f) : 1f);
				vTangents[num86] = (vTangents[num86 + 1] = (vTangents[num86 + 2] = new Vector4(normalized4.x, normalized4.y, normalized4.z, w)));
			}
		}
		newMesh.tangents = vTangents;
	}

	public static void UpdateDecal(DecalGroup decal)
	{
		GameObject gameObject = decal.gameObject;
		MeshFilter component = gameObject.GetComponent<MeshFilter>();
		if (component == null)
		{
			Debug.LogError("No mesh on " + decal.name);
			return;
		}
		if (gameObject.GetComponent<MeshFilter>() == null)
		{
			gameObject.AddComponent<MeshFilter>();
		}
		MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
		if (meshRenderer == null)
		{
			meshRenderer = gameObject.AddComponent<MeshRenderer>();
		}
		Mesh sharedMesh = component.sharedMesh;
		Transform transform = gameObject.transform;
		if (sharedMesh == null)
		{
			Debug.LogError("No decalmesh in " + component.name);
		}
		int[] triangles = sharedMesh.triangles;
		Vector3[] vertices = sharedMesh.vertices;
		Vector3[] array = new Vector3[vertices.Length];
		Vector2[] uv = sharedMesh.uv;
		Color[] colors = sharedMesh.colors;
		for (int i = 0; i < vertices.Length; i++)
		{
			array[i] = transform.TransformPoint(vertices[i]);
		}
		List<GameObject> list = new List<GameObject>();
		List<Material> list2 = null;
		int num = 0;
		if (decal.pickParentWithRaycast)
		{
			Vector3[] normals = sharedMesh.normals;
			for (int j = 0; j < vertices.Length; j++)
			{
				if (Physics.Raycast(array[j], -transform.TransformDirection(normals[j]), out var hitInfo, decal.rayLength))
				{
					GameObject gameObject2 = hitInfo.collider.gameObject;
					if (!list.Contains(gameObject2))
					{
						num |= 1 << gameObject2.layer;
						list.Add(gameObject2);
					}
				}
			}
		}
		else if (decal.pickParentWithBox)
		{
			Vector3 vector = meshRenderer.bounds.extents * 2f * decal.boxScale;
			Collider[] array2 = Physics.OverlapBox(halfExtents: new Vector3(Mathf.Max(vector.x, decal.rayLength), Mathf.Max(vector.y, decal.rayLength), Mathf.Max(vector.z, decal.rayLength)), center: meshRenderer.bounds.center);
			for (int k = 0; k < array2.Length; k++)
			{
				GameObject gameObject3 = array2[k].gameObject;
				if (!list.Contains(gameObject3))
				{
					num |= 1 << gameObject3.layer;
					list.Add(gameObject3);
				}
			}
		}
		else if (decal.parentObject != null)
		{
			num |= 1 << decal.parentObject.layer;
			list.Add(decal.parentObject);
			if (decal.parentObjectsAdditional != null)
			{
				list2 = new List<Material>();
				list2.Add(decal.optionalMateralChange);
				for (int l = 0; l < decal.parentObjectsAdditional.Count; l++)
				{
					if (!(decal.parentObjectsAdditional[l] == null))
					{
						num |= 1 << decal.parentObjectsAdditional[l].layer;
						list.Add(decal.parentObjectsAdditional[l]);
						list2.Add(decal.optionalMateralChangeAdditional[l]);
					}
				}
			}
		}
		if (list.Count > 0 && ((int)decal.layerMask & num) != num)
		{
			List<GameObject> list3 = new List<GameObject>();
			for (int m = 0; m < list.Count; m++)
			{
				if (((1 << list[m].layer) & decal.layerMask.value) != 0)
				{
					list3.Add(list[m]);
				}
			}
			list = list3;
		}
		if (list.Count == 0)
		{
			Debug.LogError("Parent object is not set for decal " + decal.name);
			return;
		}
		int fixedOffset = 0;
		for (int n = 0; n < list.Count; n++)
		{
			UpdateDecalFor(decal, meshRenderer.sharedMaterial, uv, array, transform, triangles, colors, list[n], (list2 == null) ? decal.optionalMateralChange : list2[n], 1f, ref fixedOffset, 0);
		}
	}

	private static void SplitTriangle(Vector3[] triPos, Vector3[] triNormal, Vector2[] triUV, Color[] triColor, Vector2[] triUV2, BoneWeight[] triSkin, Plane plane, List<Vector3> newPos, List<Vector3> newNormal, List<Vector2> newUV, List<Color> newColor, List<Vector2> newUV2, List<BoneWeight> newSkin, List<int> newIndices)
	{
		bool flag = newColor != null;
		bool flag2 = newUV != null;
		Vector3 vector = triPos[0];
		Vector3 vector2 = triPos[1];
		Vector3 vector3 = triPos[2];
		Vector3 vector4 = triNormal[0];
		Vector3 vector5 = triNormal[1];
		Vector3 vector6 = triNormal[2];
		Vector2 vector7 = triUV[0];
		Vector2 vector8 = triUV[1];
		Vector2 vector9 = triUV[2];
		Vector2 vector10 = triUV2[0];
		Vector2 vector11 = triUV2[1];
		Vector2 vector12 = triUV2[2];
		BoneWeight boneWeight = tmpWeight;
		BoneWeight boneWeight2 = tmpWeight;
		BoneWeight boneWeight3 = tmpWeight;
		bool flag3 = triSkin != null;
		if (flag3)
		{
			boneWeight = triSkin[0];
			boneWeight2 = triSkin[1];
			boneWeight3 = triSkin[2];
		}
		Color color = triColor[0];
		Color color2 = triColor[1];
		Color color3 = triColor[2];
		float distanceToPoint = plane.GetDistanceToPoint(vector);
		float distanceToPoint2 = plane.GetDistanceToPoint(vector2);
		float distanceToPoint3 = plane.GetDistanceToPoint(vector3);
		float num = Mathf.Sign(distanceToPoint);
		float num2 = Mathf.Sign(distanceToPoint2);
		float num3 = Mathf.Sign(distanceToPoint3);
		bool num4 = num == num2 && num2 == num3;
		bool flag4 = num2 == num3 && distanceToPoint == 0f;
		bool flag5 = num2 == num && distanceToPoint3 == 0f;
		bool flag6 = num == num3 && distanceToPoint2 == 0f;
		if (num4 | flag4 | flag5 | flag6)
		{
			if (!(distanceToPoint > 0f))
			{
				int count = newPos.Count;
				newPos.Add(vector);
				newNormal.Add(vector4);
				if (flag)
				{
					newColor.Add(color);
				}
				newUV2.Add(vector10);
				if (flag2)
				{
					newUV.Add(vector7);
				}
				int count2 = newPos.Count;
				newPos.Add(vector2);
				newNormal.Add(vector5);
				if (flag)
				{
					newColor.Add(color2);
				}
				newUV2.Add(vector11);
				if (flag2)
				{
					newUV.Add(vector8);
				}
				int count3 = newPos.Count;
				newPos.Add(vector3);
				newNormal.Add(vector6);
				if (flag)
				{
					newColor.Add(color3);
				}
				newUV2.Add(vector12);
				if (flag2)
				{
					newUV.Add(vector9);
				}
				if (flag3)
				{
					newSkin.Add(boneWeight);
					newSkin.Add(boneWeight2);
					newSkin.Add(boneWeight3);
				}
				newIndices.Add(count);
				newIndices.Add(count2);
				newIndices.Add(count3);
			}
		}
		else if (num == num2)
		{
			Ray ray = new Ray(vector, (vector3 - vector).normalized);
			plane.Raycast(ray, out var enter);
			Vector3 vector13 = ray.origin + ray.direction * enter;
			float num5 = saturate(enter / (vector3 - vector).magnitude);
			vector13 = Vector3.Lerp(vector, vector3, num5);
			Vector3 item = Vector3.Lerp(vector4, vector6, num5);
			Vector2 item2 = Vector2.Lerp(vector7, vector9, num5);
			Vector2 item3 = Vector2.Lerp(vector10, vector12, num5);
			BoneWeight item4 = tmpWeight;
			if (flag3)
			{
				item4 = LerpBoneWeights(boneWeight, boneWeight3, num5);
			}
			Color item5 = Color.Lerp(color, color3, num5);
			Ray ray2 = new Ray(vector2, (vector3 - vector2).normalized);
			plane.Raycast(ray2, out enter);
			Vector3 vector14 = ray2.origin + ray2.direction * enter;
			float num6 = saturate(enter / (vector3 - vector2).magnitude);
			vector14 = Vector3.Lerp(vector2, vector3, num6);
			Vector3 item6 = Vector3.Lerp(vector5, vector6, num6);
			Vector2 item7 = Vector2.Lerp(vector8, vector9, num6);
			Vector2 item8 = Vector2.Lerp(vector11, vector12, num6);
			BoneWeight item9 = tmpWeight;
			if (flag3)
			{
				item9 = LerpBoneWeights(boneWeight2, boneWeight3, num6);
			}
			Color item10 = Color.Lerp(color2, color3, num6);
			int count = newPos.Count;
			newPos.Add(vector);
			newNormal.Add(vector4);
			if (flag)
			{
				newColor.Add(color);
			}
			newUV2.Add(vector10);
			if (flag2)
			{
				newUV.Add(vector7);
			}
			int count2 = newPos.Count;
			newPos.Add(vector2);
			newNormal.Add(vector5);
			if (flag)
			{
				newColor.Add(color2);
			}
			newUV2.Add(vector11);
			if (flag2)
			{
				newUV.Add(vector8);
			}
			int count3 = newPos.Count;
			newPos.Add(vector3);
			newNormal.Add(vector6);
			if (flag)
			{
				newColor.Add(color3);
			}
			newUV2.Add(vector12);
			if (flag2)
			{
				newUV.Add(vector9);
			}
			int count4 = newPos.Count;
			newPos.Add(vector13);
			newNormal.Add(item);
			if (flag)
			{
				newColor.Add(item5);
			}
			newUV2.Add(item3);
			if (flag2)
			{
				newUV.Add(item2);
			}
			int count5 = newPos.Count;
			newPos.Add(vector14);
			newNormal.Add(item6);
			if (flag)
			{
				newColor.Add(item10);
			}
			newUV2.Add(item8);
			if (flag2)
			{
				newUV.Add(item7);
			}
			if (flag3)
			{
				newSkin.Add(boneWeight);
				newSkin.Add(boneWeight2);
				newSkin.Add(boneWeight3);
				newSkin.Add(item4);
				newSkin.Add(item9);
			}
			if (distanceToPoint < 0f)
			{
				newIndices.Add(count4);
				newIndices.Add(count);
				newIndices.Add(count2);
				newIndices.Add(count4);
				newIndices.Add(count2);
				newIndices.Add(count5);
			}
			count4 = newPos.Count;
			newPos.Add(vector13);
			newNormal.Add(item);
			if (flag)
			{
				newColor.Add(item5);
			}
			newUV2.Add(item3);
			if (flag2)
			{
				newUV.Add(item2);
			}
			count5 = newPos.Count;
			newPos.Add(vector14);
			newNormal.Add(item6);
			if (flag)
			{
				newColor.Add(item10);
			}
			newUV2.Add(item8);
			if (flag2)
			{
				newUV.Add(item7);
			}
			if (flag3)
			{
				newSkin.Add(item4);
				newSkin.Add(item9);
			}
			if (distanceToPoint > 0f)
			{
				newIndices.Add(count3);
				newIndices.Add(count4);
				newIndices.Add(count5);
			}
		}
		else if (num == num3)
		{
			Ray ray3 = new Ray(vector, (vector2 - vector).normalized);
			plane.Raycast(ray3, out var enter2);
			Vector3 vector13 = ray3.origin + ray3.direction * enter2;
			float num7 = saturate(enter2 / (vector2 - vector).magnitude);
			vector13 = Vector3.Lerp(vector, vector2, num7);
			Vector3 item11 = Vector3.Lerp(vector4, vector5, num7);
			Vector2 item12 = Vector2.Lerp(vector7, vector8, num7);
			Vector2 item13 = Vector2.Lerp(vector10, vector11, num7);
			BoneWeight item14 = tmpWeight;
			if (flag3)
			{
				item14 = LerpBoneWeights(boneWeight, boneWeight2, num7);
			}
			Color item15 = Color.Lerp(color, color2, num7);
			Ray ray4 = new Ray(vector2, (vector3 - vector2).normalized);
			plane.Raycast(ray4, out enter2);
			Vector3 vector14 = ray4.origin + ray4.direction * enter2;
			float num8 = saturate(enter2 / (vector3 - vector2).magnitude);
			vector14 = Vector3.Lerp(vector2, vector3, num8);
			Vector3 item16 = Vector3.Lerp(vector5, vector6, num8);
			Vector2 item17 = Vector2.Lerp(vector8, vector9, num8);
			Vector2 item18 = Vector2.Lerp(vector11, vector12, num8);
			BoneWeight item19 = tmpWeight;
			if (flag3)
			{
				item19 = LerpBoneWeights(boneWeight2, boneWeight3, num8);
			}
			Color item20 = Color.Lerp(color2, color3, num8);
			int count = newPos.Count;
			newPos.Add(vector);
			newNormal.Add(vector4);
			if (flag)
			{
				newColor.Add(color);
			}
			newUV2.Add(vector10);
			if (flag2)
			{
				newUV.Add(vector7);
			}
			int count2 = newPos.Count;
			newPos.Add(vector2);
			newNormal.Add(vector5);
			if (flag)
			{
				newColor.Add(color2);
			}
			newUV2.Add(vector11);
			if (flag2)
			{
				newUV.Add(vector8);
			}
			int count3 = newPos.Count;
			newPos.Add(vector3);
			newNormal.Add(vector6);
			if (flag)
			{
				newColor.Add(color3);
			}
			newUV2.Add(vector12);
			if (flag2)
			{
				newUV.Add(vector9);
			}
			int count4 = newPos.Count;
			newPos.Add(vector13);
			newNormal.Add(item11);
			if (flag)
			{
				newColor.Add(item15);
			}
			newUV2.Add(item13);
			if (flag2)
			{
				newUV.Add(item12);
			}
			int count5 = newPos.Count;
			newPos.Add(vector14);
			newNormal.Add(item16);
			if (flag)
			{
				newColor.Add(item20);
			}
			newUV2.Add(item18);
			if (flag2)
			{
				newUV.Add(item17);
			}
			if (flag3)
			{
				newSkin.Add(boneWeight);
				newSkin.Add(boneWeight2);
				newSkin.Add(boneWeight3);
				newSkin.Add(item14);
				newSkin.Add(item19);
			}
			if (distanceToPoint < 0f)
			{
				newIndices.Add(count);
				newIndices.Add(count4);
				newIndices.Add(count3);
				newIndices.Add(count4);
				newIndices.Add(count5);
				newIndices.Add(count3);
			}
			count4 = newPos.Count;
			newPos.Add(vector13);
			newNormal.Add(item11);
			if (flag)
			{
				newColor.Add(item15);
			}
			newUV2.Add(item13);
			if (flag2)
			{
				newUV.Add(item12);
			}
			count5 = newPos.Count;
			newPos.Add(vector14);
			newNormal.Add(item16);
			if (flag)
			{
				newColor.Add(item20);
			}
			newUV2.Add(item18);
			if (flag2)
			{
				newUV.Add(item17);
			}
			if (flag3)
			{
				newSkin.Add(item14);
				newSkin.Add(item19);
			}
			if (distanceToPoint > 0f)
			{
				newIndices.Add(count2);
				newIndices.Add(count5);
				newIndices.Add(count4);
			}
		}
		else if (num2 == num3)
		{
			Ray ray5 = new Ray(vector, (vector3 - vector).normalized);
			plane.Raycast(ray5, out var enter3);
			Vector3 vector13 = ray5.origin + ray5.direction * enter3;
			float num9 = saturate(enter3 / (vector3 - vector).magnitude);
			vector13 = Vector3.Lerp(vector, vector3, num9);
			Vector3 item21 = Vector3.Lerp(vector4, vector6, num9);
			Vector2 item22 = Vector2.Lerp(vector7, vector9, num9);
			Vector2 item23 = Vector2.Lerp(vector10, vector12, num9);
			BoneWeight item24 = tmpWeight;
			if (flag3)
			{
				item24 = LerpBoneWeights(boneWeight, boneWeight3, num9);
			}
			Color item25 = Color.Lerp(color, color3, num9);
			Ray ray6 = new Ray(vector2, (vector - vector2).normalized);
			plane.Raycast(ray6, out enter3);
			Vector3 vector14 = ray6.origin + ray6.direction * enter3;
			float num10 = saturate(enter3 / (vector - vector2).magnitude);
			vector14 = Vector3.Lerp(vector2, vector, num10);
			Vector3 item26 = Vector3.Lerp(vector5, vector4, num10);
			Vector2 item27 = Vector2.Lerp(vector8, vector7, num10);
			Vector2 item28 = Vector2.Lerp(vector11, vector10, num10);
			BoneWeight item29 = tmpWeight;
			if (flag3)
			{
				item29 = LerpBoneWeights(boneWeight2, boneWeight, num10);
			}
			Color item30 = Color.Lerp(color2, color3, num10);
			int count = newPos.Count;
			newPos.Add(vector);
			newNormal.Add(vector4);
			if (flag)
			{
				newColor.Add(color);
			}
			newUV2.Add(vector10);
			if (flag2)
			{
				newUV.Add(vector7);
			}
			int count2 = newPos.Count;
			newPos.Add(vector2);
			newNormal.Add(vector5);
			if (flag)
			{
				newColor.Add(color2);
			}
			newUV2.Add(vector11);
			if (flag2)
			{
				newUV.Add(vector8);
			}
			int count3 = newPos.Count;
			newPos.Add(vector3);
			newNormal.Add(vector6);
			if (flag)
			{
				newColor.Add(color3);
			}
			newUV2.Add(vector12);
			if (flag2)
			{
				newUV.Add(vector9);
			}
			int count4 = newPos.Count;
			newPos.Add(vector13);
			newNormal.Add(item21);
			if (flag)
			{
				newColor.Add(item25);
			}
			newUV2.Add(item23);
			if (flag2)
			{
				newUV.Add(item22);
			}
			int count5 = newPos.Count;
			newPos.Add(vector14);
			newNormal.Add(item26);
			if (flag)
			{
				newColor.Add(item30);
			}
			newUV2.Add(item28);
			if (flag2)
			{
				newUV.Add(item27);
			}
			if (flag3)
			{
				newSkin.Add(boneWeight);
				newSkin.Add(boneWeight2);
				newSkin.Add(boneWeight3);
				newSkin.Add(item24);
				newSkin.Add(item29);
			}
			if (distanceToPoint > 0f)
			{
				newIndices.Add(count2);
				newIndices.Add(count3);
				newIndices.Add(count4);
				newIndices.Add(count2);
				newIndices.Add(count4);
				newIndices.Add(count5);
			}
			count4 = newPos.Count;
			newPos.Add(vector13);
			newNormal.Add(item21);
			if (flag)
			{
				newColor.Add(item25);
			}
			newUV2.Add(item23);
			if (flag2)
			{
				newUV.Add(item22);
			}
			count5 = newPos.Count;
			newPos.Add(vector14);
			newNormal.Add(item26);
			if (flag)
			{
				newColor.Add(item30);
			}
			newUV2.Add(item28);
			if (flag2)
			{
				newUV.Add(item27);
			}
			if (flag3)
			{
				newSkin.Add(item24);
				newSkin.Add(item29);
			}
			if (distanceToPoint <= 0f)
			{
				newIndices.Add(count);
				newIndices.Add(count5);
				newIndices.Add(count4);
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void AddTriangle(ref int fixedOffset, Vector3[] vPos, Vector3[] vNormal, Color[] vColor, Vector2[] vUV2, Vector2[] vUV, BoneWeight[] vSkin, byte[] vDecalID, Vector3 Ap, Vector3 An, Color Ac, Vector2 At2, Vector2 At, BoneWeight Ab, Vector3 Bp, Vector3 Bn, Color Bc, Vector2 Bt2, Vector2 Bt, BoneWeight Bb, Vector3 Cp, Vector3 Cn, Color Cc, Vector2 Ct2, Vector2 Ct, BoneWeight Cb, byte decalID)
	{
		int num = fixedOffset;
		int num2 = fixedOffset + 1;
		int num3 = fixedOffset + 2;
		vPos[num] = Ap;
		vPos[num2] = Bp;
		vPos[num3] = Cp;
		vNormal[num] = An;
		vNormal[num2] = Bn;
		vNormal[num3] = Cn;
		if (vColor != null)
		{
			vColor[num] = Ac;
			vColor[num2] = Bc;
			vColor[num3] = Cc;
		}
		vUV2[num] = At2;
		vUV2[num2] = Bt2;
		vUV2[num3] = Ct2;
		if (vUV != null)
		{
			vUV[num] = At;
			vUV[num2] = Bt;
			vUV[num3] = Ct;
		}
		if (vSkin != null)
		{
			vSkin[num] = Ab;
			vSkin[num2] = Bb;
			vSkin[num3] = Cb;
		}
		vDecalID[num] = (vDecalID[num2] = (vDecalID[num3] = decalID));
		fixedOffset += 3;
	}

	private static void SplitTriangle2(Vector3[] triPos, Vector3[] triNormal, Vector2[] triUV, Color[] triColor, Vector2[] triUV2, BoneWeight[] triSkin, Plane plane, byte decalID, ref int fixedOffset, Vector3[] vPos, Vector3[] vNormal, Vector2[] vUV, Color[] vColor, Vector2[] vUV2, BoneWeight[] vSkin, byte[] vDecalID)
	{
		int num = vPos.Length;
		Vector3 vector = triPos[0];
		Vector3 vector2 = triPos[1];
		Vector3 vector3 = triPos[2];
		Vector3 vector4 = triNormal[0];
		Vector3 vector5 = triNormal[1];
		Vector3 vector6 = triNormal[2];
		Vector2 vector7 = triUV[0];
		Vector2 vector8 = triUV[1];
		Vector2 vector9 = triUV[2];
		Vector2 vector10 = triUV2[0];
		Vector2 vector11 = triUV2[1];
		Vector2 vector12 = triUV2[2];
		BoneWeight boneWeight = tmpWeight;
		BoneWeight boneWeight2 = tmpWeight;
		BoneWeight boneWeight3 = tmpWeight;
		bool flag = triSkin != null;
		if (flag)
		{
			boneWeight = triSkin[0];
			boneWeight2 = triSkin[1];
			boneWeight3 = triSkin[2];
		}
		Color color = triColor[0];
		Color color2 = triColor[1];
		Color color3 = triColor[2];
		float distanceToPoint = plane.GetDistanceToPoint(vector);
		float distanceToPoint2 = plane.GetDistanceToPoint(vector2);
		float distanceToPoint3 = plane.GetDistanceToPoint(vector3);
		float num2 = Mathf.Sign(distanceToPoint);
		float num3 = Mathf.Sign(distanceToPoint2);
		float num4 = Mathf.Sign(distanceToPoint3);
		bool num5 = num2 == num3 && num3 == num4;
		bool flag2 = num3 == num4 && distanceToPoint == 0f;
		bool flag3 = num3 == num2 && distanceToPoint3 == 0f;
		bool flag4 = num2 == num4 && distanceToPoint2 == 0f;
		if (num5 | flag2 | flag3 | flag4)
		{
			if (distanceToPoint <= 0f)
			{
				if (fixedOffset + 3 >= num)
				{
					fixedOffset = 0;
				}
				AddTriangle(ref fixedOffset, vPos, vNormal, vColor, vUV2, vUV, vSkin, vDecalID, vector, vector4, color, vector10, vector7, boneWeight, vector2, vector5, color2, vector11, vector8, boneWeight2, vector3, vector6, color3, vector12, vector9, boneWeight3, decalID);
			}
		}
		else if (num2 == num3)
		{
			Ray ray = new Ray(vector, (vector3 - vector).normalized);
			plane.Raycast(ray, out var enter);
			Vector3 vector13 = ray.origin + ray.direction * enter;
			float num6 = saturate(enter / (vector3 - vector).magnitude);
			vector13 = Vector3.Lerp(vector, vector3, num6);
			Vector3 vector14 = Vector3.Lerp(vector4, vector6, num6);
			Vector2 vector15 = Vector2.Lerp(vector7, vector9, num6);
			Vector2 vector16 = Vector2.Lerp(vector10, vector12, num6);
			BoneWeight boneWeight4 = tmpWeight;
			if (flag)
			{
				boneWeight4 = LerpBoneWeights(boneWeight, boneWeight3, num6);
			}
			Color color4 = Color.Lerp(color, color3, num6);
			Ray ray2 = new Ray(vector2, (vector3 - vector2).normalized);
			plane.Raycast(ray2, out enter);
			Vector3 vector17 = ray2.origin + ray2.direction * enter;
			float num7 = saturate(enter / (vector3 - vector2).magnitude);
			vector17 = Vector3.Lerp(vector2, vector3, num7);
			Vector3 cn = Vector3.Lerp(vector5, vector6, num7);
			Vector2 ct = Vector2.Lerp(vector8, vector9, num7);
			Vector2 ct2 = Vector2.Lerp(vector11, vector12, num7);
			BoneWeight cb = tmpWeight;
			if (flag)
			{
				cb = LerpBoneWeights(boneWeight2, boneWeight3, num7);
			}
			Color cc = Color.Lerp(color2, color3, num7);
			if (fixedOffset + 9 >= num)
			{
				fixedOffset = 0;
			}
			if (distanceToPoint < 0f)
			{
				AddTriangle(ref fixedOffset, vPos, vNormal, vColor, vUV2, vUV, vSkin, vDecalID, vector13, vector14, color4, vector16, vector15, boneWeight4, vector, vector4, color, vector10, vector7, boneWeight, vector2, vector5, color2, vector11, vector8, boneWeight2, decalID);
				AddTriangle(ref fixedOffset, vPos, vNormal, vColor, vUV2, vUV, vSkin, vDecalID, vector13, vector14, color4, vector16, vector15, boneWeight4, vector2, vector5, color2, vector11, vector8, boneWeight2, vector17, cn, cc, ct2, ct, cb, decalID);
			}
			if (distanceToPoint >= 0f)
			{
				AddTriangle(ref fixedOffset, vPos, vNormal, vColor, vUV2, vUV, vSkin, vDecalID, vector3, vector6, color3, vector12, vector9, boneWeight3, vector13, vector14, color4, vector16, vector15, boneWeight4, vector17, cn, cc, ct2, ct, cb, decalID);
			}
		}
		else if (num2 == num4)
		{
			Ray ray3 = new Ray(vector, (vector2 - vector).normalized);
			plane.Raycast(ray3, out var enter2);
			Vector3 vector13 = ray3.origin + ray3.direction * enter2;
			float num8 = saturate(enter2 / (vector2 - vector).magnitude);
			vector13 = Vector3.Lerp(vector, vector2, num8);
			Vector3 vector18 = Vector3.Lerp(vector4, vector5, num8);
			Vector2 vector19 = Vector2.Lerp(vector7, vector8, num8);
			Vector2 vector20 = Vector2.Lerp(vector10, vector11, num8);
			BoneWeight boneWeight5 = tmpWeight;
			if (flag)
			{
				boneWeight5 = LerpBoneWeights(boneWeight, boneWeight2, num8);
			}
			Color color5 = Color.Lerp(color, color2, num8);
			Ray ray4 = new Ray(vector2, (vector3 - vector2).normalized);
			plane.Raycast(ray4, out enter2);
			Vector3 vector17 = ray4.origin + ray4.direction * enter2;
			float num9 = saturate(enter2 / (vector3 - vector2).magnitude);
			vector17 = Vector3.Lerp(vector2, vector3, num9);
			Vector3 bn = Vector3.Lerp(vector5, vector6, num9);
			Vector2 bt = Vector2.Lerp(vector8, vector9, num9);
			Vector2 bt2 = Vector2.Lerp(vector11, vector12, num9);
			BoneWeight bb = tmpWeight;
			if (flag)
			{
				bb = LerpBoneWeights(boneWeight2, boneWeight3, num9);
			}
			Color bc = Color.Lerp(color2, color3, num9);
			if (fixedOffset + 9 >= num)
			{
				fixedOffset = 0;
			}
			if (distanceToPoint < 0f)
			{
				AddTriangle(ref fixedOffset, vPos, vNormal, vColor, vUV2, vUV, vSkin, vDecalID, vector, vector4, color, vector10, vector7, boneWeight, vector13, vector18, color5, vector20, vector19, boneWeight5, vector3, vector6, color3, vector12, vector9, boneWeight3, decalID);
				AddTriangle(ref fixedOffset, vPos, vNormal, vColor, vUV2, vUV, vSkin, vDecalID, vector13, vector18, color5, vector20, vector19, boneWeight5, vector17, bn, bc, bt2, bt, bb, vector3, vector6, color3, vector12, vector9, boneWeight3, decalID);
			}
			if (distanceToPoint >= 0f)
			{
				AddTriangle(ref fixedOffset, vPos, vNormal, vColor, vUV2, vUV, vSkin, vDecalID, vector2, vector5, color2, vector11, vector8, boneWeight2, vector17, bn, bc, bt2, bt, bb, vector13, vector18, color5, vector20, vector19, boneWeight5, decalID);
			}
		}
		else if (num3 == num4)
		{
			Ray ray5 = new Ray(vector, (vector3 - vector).normalized);
			plane.Raycast(ray5, out var enter3);
			Vector3 vector13 = ray5.origin + ray5.direction * enter3;
			float num10 = saturate(enter3 / (vector3 - vector).magnitude);
			vector13 = Vector3.Lerp(vector, vector3, num10);
			Vector3 vector21 = Vector3.Lerp(vector4, vector6, num10);
			Vector2 vector22 = Vector2.Lerp(vector7, vector9, num10);
			Vector2 vector23 = Vector2.Lerp(vector10, vector12, num10);
			BoneWeight boneWeight6 = tmpWeight;
			if (flag)
			{
				boneWeight6 = LerpBoneWeights(boneWeight, boneWeight3, num10);
			}
			Color color6 = Color.Lerp(color, color3, num10);
			Ray ray6 = new Ray(vector2, (vector - vector2).normalized);
			plane.Raycast(ray6, out enter3);
			Vector3 vector17 = ray6.origin + ray6.direction * enter3;
			float num11 = saturate(enter3 / (vector - vector2).magnitude);
			vector17 = Vector3.Lerp(vector2, vector, num11);
			Vector3 vector24 = Vector3.Lerp(vector5, vector4, num11);
			Vector2 vector25 = Vector2.Lerp(vector8, vector7, num11);
			Vector2 vector26 = Vector2.Lerp(vector11, vector10, num11);
			BoneWeight boneWeight7 = tmpWeight;
			if (flag)
			{
				boneWeight7 = LerpBoneWeights(boneWeight2, boneWeight, num11);
			}
			Color color7 = Color.Lerp(color2, color3, num11);
			if (fixedOffset + 9 >= num)
			{
				fixedOffset = 0;
			}
			if (distanceToPoint > 0f)
			{
				AddTriangle(ref fixedOffset, vPos, vNormal, vColor, vUV2, vUV, vSkin, vDecalID, vector2, vector5, color2, vector11, vector8, boneWeight2, vector3, vector6, color3, vector12, vector9, boneWeight3, vector13, vector21, color6, vector23, vector22, boneWeight6, decalID);
				AddTriangle(ref fixedOffset, vPos, vNormal, vColor, vUV2, vUV, vSkin, vDecalID, vector2, vector5, color2, vector11, vector8, boneWeight2, vector13, vector21, color6, vector23, vector22, boneWeight6, vector17, vector24, color7, vector26, vector25, boneWeight7, decalID);
			}
			if (distanceToPoint <= 0f)
			{
				AddTriangle(ref fixedOffset, vPos, vNormal, vColor, vUV2, vUV, vSkin, vDecalID, vector, vector4, color, vector10, vector7, boneWeight, vector17, vector24, color7, vector26, vector25, boneWeight7, vector13, vector21, color6, vector23, vector22, boneWeight6, decalID);
			}
		}
	}

	private static void SetTris(Mesh mesh, int count)
	{
		int[] array = new int[count * 3];
		for (int i = 0; i < count; i++)
		{
			array[i * 3] = i * 3;
			array[i * 3 + 1] = i * 3 + 1;
			array[i * 3 + 2] = i * 3 + 2;
		}
		mesh.triangles = array;
	}

	public static DecalUtils.Group CreateGroup(DecalUtils.GroupDesc desc)
	{
		Transform transform = ((desc.parent != null) ? desc.parent.transform : null);
		GameObject gameObject = new GameObject();
		gameObject.name = "Decals";
		Transform obj = gameObject.transform;
		obj.parent = transform;
		obj.localPosition = Vector3.zero;
		obj.localRotation = Quaternion.identity;
		obj.localScale = Vector3.one;
		Mesh mesh = new Mesh();
		bool flag = false;
		if (desc.parent != null)
		{
			MeshFilter component = desc.parent.GetComponent<MeshFilter>();
			if (component != null)
			{
				Mesh sharedMesh = component.sharedMesh;
				if (sharedMesh != null)
				{
					mesh.bounds = sharedMesh.bounds;
				}
			}
			SkinnedMeshRenderer component2 = desc.parent.GetComponent<SkinnedMeshRenderer>();
			if (component2 != null)
			{
				SkinnedMeshRenderer skinnedMeshRenderer = gameObject.AddComponent<SkinnedMeshRenderer>();
				skinnedMeshRenderer.sharedMaterial = desc.material;
				skinnedMeshRenderer.lightmapIndex = desc.lightmapID;
				skinnedMeshRenderer.realtimeLightmapIndex = desc.realtimeLightmapID;
				skinnedMeshRenderer.realtimeLightmapScaleOffset = desc.realtimeLightmapScaleOffset;
				skinnedMeshRenderer.bones = component2.bones;
				mesh.bindposes = component2.sharedMesh.bindposes;
				mesh.bounds = component2.sharedMesh.bounds;
				skinnedMeshRenderer.localBounds = component2.localBounds;
				skinnedMeshRenderer.sharedMesh = mesh;
				skinnedMeshRenderer.rootBone = component2.rootBone;
				if (desc.materialPropertyBlock != null)
				{
					skinnedMeshRenderer.SetPropertyBlock(desc.materialPropertyBlock);
				}
				flag = true;
			}
		}
		if (!flag)
		{
			gameObject.AddComponent<MeshFilter>().sharedMesh = mesh;
			MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
			meshRenderer.sharedMaterial = desc.material;
			meshRenderer.lightmapIndex = desc.lightmapID;
			meshRenderer.realtimeLightmapIndex = desc.realtimeLightmapID;
			meshRenderer.realtimeLightmapScaleOffset = desc.realtimeLightmapScaleOffset;
			if (desc.materialPropertyBlock != null)
			{
				meshRenderer.SetPropertyBlock(desc.materialPropertyBlock);
			}
		}
		DecalUtils.Group obj2 = new DecalUtils.Group();
		obj2.mode = DecalUtils.Mode.CPU;
		obj2.material = desc.material;
		obj2.totalTris = desc.maxTrisTotal;
		obj2.maxTrisInDecal = desc.maxTrisInDecal;
		obj2.parent = desc.parent;
		obj2.parentTform = transform;
		obj2.go = gameObject;
		obj2.mesh = mesh;
		obj2.lightmapID = desc.lightmapID;
		obj2.bounds = (obj2.nextBounds = new Bounds(new Vector3(-99999f, -99999f, -99999f), Vector3.zero));
		obj2.isTrail = desc.isTrail;
		obj2.trailVScale = desc.trailVScale;
		obj2.tangents = desc.tangents;
		obj2.isSkinned = flag;
		obj2.decalGroup = gameObject.AddComponent<DecalGroup>();
		obj2.decalGroup.linkToParent = obj2.parentTform != null;
		obj2.vPos = new Vector3[desc.maxTrisTotal * 3];
		obj2.vNormal = new Vector3[desc.maxTrisTotal * 3];
		obj2.vUV = new Vector2[desc.maxTrisTotal * 3];
		obj2.vUV2 = new Vector2[desc.maxTrisTotal * 3];
		obj2.vColor = new Color[desc.maxTrisTotal * 3];
		obj2.vDecalID = new byte[desc.maxTrisTotal * 3];
		if (desc.tangents)
		{
			obj2.vTangents = new Vector4[desc.maxTrisTotal * 3];
		}
		if (flag)
		{
			obj2.vSkin = new BoneWeight[desc.maxTrisTotal * 3];
		}
		return obj2;
	}

	public static void AddDecal(DecalUtils.Group group, DecalUtils.DecalDesc desc, GameObject receiver)
	{
		DecalGroup decalGroup = group.decalGroup;
		decalGroup.parentObject = receiver;
		decalGroup.rayLength = desc.distance;
		decalGroup.angleClip = desc.angleClip;
		decalGroup.angleFade = true;
		decalGroup.tangents = group.tangents;
		Vector3 vector = desc.rotation * Vector3.right;
		Vector3 vector2 = desc.rotation * Vector3.up;
		vector *= desc.sizeX;
		vector2 *= desc.sizeY;
		Vector3[] array = new Vector3[4];
		if (group.isTrail && group.numDecals > 0)
		{
			array[0] = group.prevDecalEdgeA;
			array[1] = group.prevDecalEdgeB;
			array[2] = desc.position + vector + vector2;
			array[3] = desc.position - vector + vector2;
		}
		else
		{
			array[0] = desc.position - vector - vector2;
			array[1] = desc.position + vector - vector2;
			array[2] = desc.position + vector + vector2;
			array[3] = desc.position - vector + vector2;
		}
		Vector2[] array2 = new Vector2[4];
		if (group.isTrail && group.numDecals > 0)
		{
			float trailV = group.trailV;
			float num = Mathf.Max(Vector3.Distance(array[3], group.prevDecalEdgeA), Vector3.Distance(array[2], group.prevDecalEdgeB));
			group.trailV += num * group.trailVScale;
			float trailV2 = group.trailV;
			array2[0] = new Vector2(0f, trailV);
			array2[1] = new Vector2(1f, trailV);
			array2[2] = new Vector2(1f, trailV2);
			array2[3] = new Vector2(0f, trailV2);
		}
		else
		{
			array2[0] = new Vector2(0f, 0f);
			array2[1] = new Vector2(1f, 0f);
			array2[2] = new Vector2(1f, 1f);
			array2[3] = new Vector2(0f, 1f);
		}
		int[] array3 = new int[6];
		array3[2] = 0;
		array3[1] = 1;
		array3[0] = 2;
		array3[5] = 2;
		array3[4] = 3;
		array3[3] = 0;
		bool transformToParent = group.parentTform != null;
		Matrix4x4 decalMatrix = (cullingMatrix = Matrix4x4.TRS(desc.position, desc.rotation, new Vector3(desc.sizeX, desc.sizeY, desc.distance)));
		cullingMatrix.SetColumn(3, decalMatrix.GetColumn(3) + decalMatrix.GetColumn(2) * desc.distance * 0.5f);
		cullingMatrix = cullingMatrix.inverse;
		bool earlyCull = true;
		lightmapScaleOffset = desc.lightmapScaleOffset;
		UpdateDecalFor(transformUV1: group.lightmapID >= 0, decal: decalGroup, sharedMaterial: group.material, decalUV: array2, decalPosW: array, decalTform: null, decalTris: array3, decalColor: null, parentObject: receiver.gameObject, optionalMateralChange: null, opacity: desc.opacity, fixedOffset: ref group.fixedOffset, decalID: (byte)(group.numDecals % 255 + 1), newMesh: group.mesh, vPos: group.vPos, vNormal: group.vNormal, vUV: group.vUV, vUV2: group.vUV2, vColor: group.vColor, vSkin: group.vSkin, vDecalID: group.vDecalID, vTangents: group.vTangents, maxTrisInDecal: group.maxTrisInDecal, transformToParent: transformToParent, earlyCull: earlyCull);
		if (group.parentTform == null)
		{
			DecalUtils.ExpandBounds(group, decalMatrix, desc);
			group.mesh.bounds = group.bounds;
		}
		if (group.isTrail)
		{
			group.prevDecalEdgeA = array[3];
			group.prevDecalEdgeB = array[2];
		}
		if (group.fixedOffset > 0)
		{
			if (group.numDecals == 0)
			{
				SetTris(group.mesh, group.totalTris);
			}
			group.numDecals++;
		}
	}

	public static void ClearDecals(DecalUtils.Group group)
	{
		if (group.mode != DecalUtils.Mode.CPU)
		{
			Debug.LogError("Decal mode is not CPU.");
			return;
		}
		group.bounds = (group.nextBounds = new Bounds(new Vector3(-99999f, -99999f, -99999f), Vector3.zero));
		group.numDecals = (group.boundsCounter = (group.boundsMinDecalCounter = 0));
		group.fixedOffset = 0;
		float num = float.PositiveInfinity;
		Vector3 vector = new Vector3(num, num, num);
		for (int i = 0; i < group.totalTris * 3; i++)
		{
			group.vPos[i] = vector;
		}
		group.mesh.vertices = group.vPos;
	}
}
