using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

public class CPUBurstDecalUtils : MonoBehaviour
{
	private struct HashedVertex
	{
		public float3 pos;

		public float3 normal;

		public float2 uv;

		public float2 uv2;

		public float4 color;
	}

	[BurstCompile(CompileSynchronously = true)]
	private struct UpdateDecalFor_Job : IJob
	{
		public NativeArray<float2> decalUV;

		public NativeArray<float3> decalPosW;

		public NativeArray<int> decalTris;

		public NativeArray<float4> decalColor;

		public float opacity;

		public bool roadTransform;

		public float2 mainTextureScale;

		public float2 mainTextureOffset;

		public float atlasMinX;

		public float atlasMaxX;

		public float atlasMinY;

		public float atlasMaxY;

		public Vector3 tformRight;

		public Vector3 tformUp;

		public Vector3 tformForward;

		public Vector3 tformPosition;

		public bool isDecalFlipped;

		public NativeArray<float3> staticPos;

		public NativeArray<float3> staticNorm;

		public NativeArray<float2> staticUV2;

		public NativeArray<int> staticTris;

		public NativeArray<float3> staticPosW;

		public NativeArray<float3> staticNormW;

		public NativeArray<bool> staticTriCulled;

		public NativeArray<BoneWeight> staticSkin;

		public float4x4 staticTformMatrix;

		public float4x4 staticTformInvMatrix;

		public bool isStaticFlipped;

		public int heightmapRes;

		public float terrainInvScaleX;

		public float terrainInvScaleZ;

		public bool earlyCull;

		public float4x4 cullingMtx;

		public bool angleFade;

		public float angleClip;

		public float rayLength;

		public float bias;

		public NativeArray<float3> splitTriPos;

		public NativeArray<float3> splitTriNormal;

		public NativeArray<float2> splitTriUV;

		public NativeArray<float2> splitTriUV2;

		public NativeArray<float4> splitTriColor;

		public NativeArray<BoneWeight> splitTriSkin;

		public bool isRuntimeFixedArray;

		public int fixedOffset;

		public int fixedTriOffset;

		public NativeArray<float3> vPos;

		public NativeArray<float3> vNormal;

		public NativeArray<float4> vColor;

		public NativeArray<float4> vTangents;

		public NativeArray<float2> vUV2;

		public NativeArray<float2> vUV;

		public NativeArray<BoneWeight> vSkin;

		public NativeArray<byte> vDecalID;

		public NativeArray<int> vIndices;

		public NativeArray<float3> vTempSplitPos;

		public NativeArray<float3> vTempSplitNormal;

		public NativeArray<float4> vTempSplitColor;

		public NativeArray<float2> vTempSplitUV;

		public NativeArray<float2> vTempSplitUV2;

		public NativeArray<BoneWeight> vTempSplitSkin;

		public NativeArray<int> vTempSplitIndices;

		public byte decalID;

		public int decalFlags;

		public int staticFlags;

		public BoneWeight tmpWeight;

		public int maxTrisInDecal;

		public bool transformToParent;

		public bool transformUV1;

		public float4 _lightmapScaleOffset;

		public bool tangents;

		public NativeArray<int> outputsInt;

		public NativeArray<float3> avgDir;

		public void Execute()
		{
			int length = decalUV.Length;
			int length2 = decalTris.Length;
			bool flag = (decalFlags & 1) == 0;
			float2 zero = float2.zero;
			bool flag2 = (decalFlags & 2) != 0;
			bool flag3 = flag2 || angleFade || opacity != 1f;
			float4 p = new float4(1f, 1f, 1f, 1f);
			float4 p2 = new float4(1f, 1f, 1f, 1f);
			float4 p3 = new float4(1f, 1f, 1f, 1f);
			float4 float5 = new float4(1f, 1f, 1f, 1f);
			float4 float6 = new float4(1f, 1f, 1f, 1f);
			float4 float7 = new float4(1f, 1f, 1f, 1f);
			bool flag4 = (staticFlags & 4) != 0;
			bool flag5 = (decalFlags & 1) != 0;
			int length3 = vPos.Length;
			int num = fixedOffset;
			int num2 = staticPosW.Length;
			int num3 = staticTris.Length;
			bool flag6 = heightmapRes > 0;
			if (flag6)
			{
				float num4 = float.MaxValue;
				float num5 = float.MaxValue;
				float num6 = float.MinValue;
				float num7 = float.MinValue;
				float num8 = rayLength;
				float num9 = 0f - bias;
				for (int i = 0; i < length2; i += 3)
				{
					int index = decalTris[i];
					int index2 = decalTris[i + 1];
					int index3 = decalTris[i + 2];
					float3 float8 = decalPosW[index];
					float3 obj = decalPosW[index2];
					float3 float9 = decalPosW[index3];
					float3 x = obj - float8;
					float3 float10 = float8 - float9;
					float3 float11 = math.normalize(math.cross(x, -float10));
					float num10 = float8.x + float11.x * num8;
					float num11 = float8.z + float11.z * num8;
					if (num10 < num4)
					{
						num4 = num10;
					}
					if (num11 < num5)
					{
						num5 = num11;
					}
					if (num10 > num6)
					{
						num6 = num10;
					}
					if (num11 > num7)
					{
						num7 = num11;
					}
					num10 = obj.x + float11.x * num8;
					num11 = obj.z + float11.z * num8;
					if (num10 < num4)
					{
						num4 = num10;
					}
					if (num11 < num5)
					{
						num5 = num11;
					}
					if (num10 > num6)
					{
						num6 = num10;
					}
					if (num11 > num7)
					{
						num7 = num11;
					}
					num10 = float9.x + float11.x * num8;
					num11 = float9.z + float11.z * num8;
					if (num10 < num4)
					{
						num4 = num10;
					}
					if (num11 < num5)
					{
						num5 = num11;
					}
					if (num10 > num6)
					{
						num6 = num10;
					}
					if (num11 > num7)
					{
						num7 = num11;
					}
					num10 = float8.x + float11.x * num9;
					num11 = float8.z + float11.z * num9;
					if (num10 < num4)
					{
						num4 = num10;
					}
					if (num11 < num5)
					{
						num5 = num11;
					}
					if (num10 > num6)
					{
						num6 = num10;
					}
					if (num11 > num7)
					{
						num7 = num11;
					}
					num10 = obj.x + float11.x * num9;
					num11 = obj.z + float11.z * num9;
					if (num10 < num4)
					{
						num4 = num10;
					}
					if (num11 < num5)
					{
						num5 = num11;
					}
					if (num10 > num6)
					{
						num6 = num10;
					}
					if (num11 > num7)
					{
						num7 = num11;
					}
					num10 = float9.x + float11.x * num9;
					num11 = float9.z + float11.z * num9;
					if (num10 < num4)
					{
						num4 = num10;
					}
					if (num11 < num5)
					{
						num5 = num11;
					}
					if (num10 > num6)
					{
						num6 = num10;
					}
					if (num11 > num7)
					{
						num7 = num11;
					}
				}
				int num12 = heightmapRes;
				int num13 = 0;
				int num14 = 0;
				float4 c = staticTformMatrix.c3;
				int num15 = (int)((num4 - c.x) * terrainInvScaleX);
				int num16 = (int)((num5 - c.z) * terrainInvScaleZ);
				int num17 = (int)((num6 - c.x) * terrainInvScaleX) + 2;
				int num18 = (int)((num7 - c.z) * terrainInvScaleZ) + 2;
				if (num15 >= num12 || num16 >= num12 || num17 <= 0 || num18 <= 0)
				{
					return;
				}
				if (num15 < 0)
				{
					num15 = 0;
				}
				if (num16 < 0)
				{
					num16 = 0;
				}
				if (num17 > num12)
				{
					num17 = num12;
				}
				if (num18 > num12)
				{
					num18 = num12;
				}
				int num19 = num17 - num15;
				int num20 = num18 - num16;
				int num21 = staticPos.Length / 2;
				for (int j = 0; j < num20; j++)
				{
					int num22 = (num16 + j) * num12;
					for (int k = 0; k < num19; k++)
					{
						int num23 = num22 + (num15 + k);
						int index4 = j * num19 + k;
						staticPos[index4] = staticPos[num23 + num21];
						staticNorm[index4] = staticNorm[num23 + num21];
						staticUV2[index4] = staticUV2[num23 + num21];
						if (k < num19 - 1 && j < num20 - 1)
						{
							staticTris[num14] = num13;
							staticTris[num14 + 1] = num13 + num19;
							staticTris[num14 + 2] = num13 + num19 + 1;
							staticTris[num14 + 3] = num13;
							staticTris[num14 + 4] = num13 + num19 + 1;
							staticTris[num14 + 5] = num13 + 1;
							num14 += 6;
						}
						num13++;
					}
				}
				num2 = num13;
				num3 = num14;
			}
			if (roadTransform)
			{
				Vector2 vector = new Vector2(tformRight.x, 0f - tformRight.z);
				Vector2 vector2 = new Vector2(0f - tformForward.x, tformForward.z);
				for (int l = 0; l < length; l++)
				{
					float num24 = decalPosW[l].z - tformPosition.z;
					float num25 = decalPosW[l].x - tformPosition.x;
					decalUV[l] = new Vector2(num24 * vector.x + num25 * vector.y, num24 * vector2.x + num25 * vector2.y);
					decalUV[l] = new Vector2(decalUV[l].x * mainTextureScale.x + mainTextureOffset.x, decalUV[l].y * mainTextureScale.y + mainTextureOffset.y);
				}
			}
			if (atlasMinX != 0f || atlasMinY != 0f || atlasMaxX != 1f || atlasMaxY != 1f)
			{
				float num26 = atlasMaxX - atlasMinX;
				float num27 = atlasMaxY - atlasMinY;
				float num28 = atlasMinX;
				float num29 = atlasMinY;
				for (int m = 0; m < length; m++)
				{
					decalUV[m] = new Vector2(decalUV[m].x * num26 + num28, 1f - ((1f - decalUV[m].y) * num27 + num29));
				}
			}
			if (isDecalFlipped)
			{
				for (int n = 0; n < length2; n += 3)
				{
					int value = decalTris[n];
					int value2 = decalTris[n + 1];
					int value3 = decalTris[n + 2];
					decalTris[n] = value3;
					decalTris[n + 1] = value2;
					decalTris[n + 2] = value;
				}
			}
			if (flag6)
			{
				staticPosW = staticPos;
				staticNormW = staticNorm;
			}
			else
			{
				for (int num30 = 0; num30 < num2; num30++)
				{
					float4 float12 = math.mul(staticTformMatrix, new float4(staticPos[num30], 1f));
					staticPosW[num30] = new float3(float12.x, float12.y, float12.z);
				}
				float3x3 a = new float3x3(math.normalize(staticTformMatrix.c0.xyz), math.normalize(staticTformMatrix.c1.xyz), math.normalize(staticTformMatrix.c2.xyz));
				for (int num31 = 0; num31 < num2; num31++)
				{
					staticNormW[num31] = math.mul(a, staticNorm[num31]);
				}
			}
			if (earlyCull)
			{
				for (int num32 = 0; num32 < num3; num32 += 3)
				{
					float3 xyz = staticPosW[staticTris[num32]];
					float4 float13 = math.mul(cullingMtx, new float4(xyz, 1f));
					xyz = staticPosW[staticTris[num32 + 1]];
					float4 float14 = math.mul(cullingMtx, new float4(xyz, 1f));
					xyz = staticPosW[staticTris[num32 + 2]];
					float4 float15 = math.mul(cullingMtx, new float4(xyz, 1f));
					float num33 = ((float13.x < float14.x) ? float13.x : float14.x);
					num33 = ((float15.x < num33) ? float15.x : num33);
					float num34 = ((float13.y < float14.y) ? float13.y : float14.y);
					num34 = ((float15.y < num34) ? float15.y : num34);
					float num35 = ((float13.z < float14.z) ? float13.z : float14.z);
					num35 = ((float15.z < num35) ? float15.z : num35);
					float num36 = ((float13.x > float14.x) ? float13.x : float14.x);
					num36 = ((float15.x > num36) ? float15.x : num36);
					float num37 = ((float13.y > float14.y) ? float13.y : float14.y);
					num37 = ((float15.y > num37) ? float15.y : num37);
					float num38 = ((float13.z > float14.z) ? float13.z : float14.z);
					num38 = ((float15.z > num38) ? float15.z : num38);
					num33 -= 0.0001f;
					num34 -= 0.0001f;
					num35 -= 0.0001f;
					num36 += 0.0001f;
					num37 += 0.0001f;
					num38 += 0.0001f;
					bool flag7 = num33 <= 1f && num36 >= -1f && num34 <= 1f && num37 >= -1f && num35 <= 1f && num38 >= -1f;
					staticTriCulled[num32] = !flag7;
				}
			}
			float num39 = 0f;
			float num40 = 0f;
			if (angleFade)
			{
				num39 = 1f / (1f - angleClip);
				num40 = (0f - angleClip) * num39;
			}
			avgDir[0] = float3.zero;
			for (int num41 = 0; num41 < length2; num41 += 3)
			{
				float3 float16 = decalPosW[decalTris[num41]];
				float3 float17 = decalPosW[decalTris[num41 + 1]];
				float3 float18 = decalPosW[decalTris[num41 + 2]];
				float3 x2 = float17 - float16;
				float3 x3 = float18 - float17;
				float3 float19 = float16 - float18;
				float3 x4 = math.normalize(x2);
				float3 x5 = math.normalize(x3);
				float3 x6 = math.normalize(float19);
				float3 float20 = math.normalize(math.cross(x2, -float19));
				float num42 = 0f - math.dot(float20, float16);
				avgDir[0] += float20;
				float3 float21 = math.normalize(math.cross(x4, float20));
				float num43 = 0f - math.dot(float21, float16);
				float3 float22 = math.normalize(math.cross(x5, float20));
				float num44 = 0f - math.dot(float22, float17);
				float3 float23 = math.normalize(math.cross(x6, float20));
				float num45 = 0f - math.dot(float23, float16);
				float2 p4 = (flag ? zero : decalUV[decalTris[num41]]);
				float2 p5 = (flag ? zero : decalUV[decalTris[num41 + 1]]);
				float2 p6 = (flag ? zero : decalUV[decalTris[num41 + 2]]);
				if (flag2)
				{
					p = decalColor[decalTris[num41]];
					p2 = decalColor[decalTris[num41 + 1]];
					p3 = decalColor[decalTris[num41 + 2]];
				}
				for (int num46 = 0; num46 < num3; num46 += 3)
				{
					if (earlyCull && staticTriCulled[num46])
					{
						continue;
					}
					int index5;
					int index6;
					int index7;
					if (isStaticFlipped)
					{
						index5 = num46 + 2;
						index6 = num46 + 1;
						index7 = num46;
					}
					else
					{
						index5 = num46;
						index6 = num46 + 1;
						index7 = num46 + 2;
					}
					float3 float24 = staticPosW[staticTris[index5]];
					float3 float25 = staticPosW[staticTris[index6]];
					float3 float26 = staticPosW[staticTris[index7]];
					if (angleFade)
					{
						splitTriNormal[0] = staticNormW[staticTris[index5]];
						splitTriNormal[1] = staticNormW[staticTris[index6]];
						splitTriNormal[2] = staticNormW[staticTris[index7]];
						float num47 = math.dot(float20, splitTriNormal[0]);
						float num48 = math.dot(float20, splitTriNormal[1]);
						float num49 = math.dot(float20, splitTriNormal[2]);
						if (num47 < angleClip && num48 < angleClip && num49 < angleClip)
						{
							continue;
						}
					}
					else
					{
						float3 float27 = math.normalize(math.cross(float25 - float24, float26 - float24));
						math.dot(float27, float24);
						if (math.dot(float20, float27) < angleClip)
						{
							continue;
						}
					}
					if ((math.dot(float20, float24) + num42 < 0f - rayLength && math.dot(float20, float25) + num42 < 0f - rayLength && math.dot(float20, float26) + num42 < 0f - rayLength) || (math.dot(float20, float24) + num42 > bias && math.dot(float20, float25) + num42 > bias && math.dot(float20, float26) + num42 > bias) || (math.dot(float21, float24) + num43 > 0f && math.dot(float21, float25) + num43 > 0f && math.dot(float21, float26) + num43 > 0f) || (math.dot(float22, float24) + num44 > 0f && math.dot(float22, float25) + num44 > 0f && math.dot(float22, float26) + num44 > 0f) || (math.dot(float23, float24) + num45 > 0f && math.dot(float23, float25) + num45 > 0f && math.dot(float23, float26) + num45 > 0f))
					{
						continue;
					}
					bool num50 = !(math.dot(float21, float24) + num43 > 0f) && !(math.dot(float21, float25) + num43 > 0f) && !(math.dot(float21, float26) + num43 > 0f) && !(math.dot(float22, float24) + num44 > 0f) && !(math.dot(float22, float25) + num44 > 0f) && !(math.dot(float22, float26) + num44 > 0f) && !(math.dot(float23, float24) + num45 > 0f) && !(math.dot(float23, float25) + num45 > 0f) && !(math.dot(float23, float26) + num45 > 0f);
					if (!angleFade)
					{
						splitTriNormal[0] = staticNormW[staticTris[index5]];
						splitTriNormal[1] = staticNormW[staticTris[index6]];
						splitTriNormal[2] = staticNormW[staticTris[index7]];
					}
					splitTriUV2[0] = staticUV2[staticTris[index5]];
					splitTriUV2[1] = staticUV2[staticTris[index6]];
					splitTriUV2[2] = staticUV2[staticTris[index7]];
					if (flag4)
					{
						splitTriSkin[0] = staticSkin[staticTris[index5]];
						splitTriSkin[1] = staticSkin[staticTris[index6]];
						splitTriSkin[2] = staticSkin[staticTris[index7]];
					}
					if (num50)
					{
						float2 float28 = triLerp(p4, p5, p6, float16, float17, float18, float24);
						float2 float29 = triLerp(p4, p5, p6, float16, float17, float18, float25);
						float2 float30 = triLerp(p4, p5, p6, float16, float17, float18, float26);
						if (flag3)
						{
							if (flag2)
							{
								float5 = triLerp(p, p2, p3, float16, float17, float18, float24) * opacity;
								float6 = triLerp(p, p2, p3, float16, float17, float18, float25) * opacity;
								float7 = triLerp(p, p2, p3, float16, float17, float18, float26) * opacity;
							}
							else
							{
								float7 = new float4(opacity, opacity, opacity, opacity);
								float5 = (float6 = float7);
							}
							if (angleFade)
							{
								float5 *= math.clamp(math.dot(splitTriNormal[0], float20) * num39 + num40, 0f, 1f);
								float6 *= math.clamp(math.dot(splitTriNormal[1], float20) * num39 + num40, 0f, 1f);
								float7 *= math.clamp(math.dot(splitTriNormal[2], float20) * num39 + num40, 0f, 1f);
							}
						}
						if (isRuntimeFixedArray)
						{
							if (fixedOffset + 3 >= length3)
							{
								fixedOffset = 0;
							}
							AddTriangle(ref fixedOffset, vPos, vNormal, flag3, vColor, vUV2, flag5, vUV, flag4, vSkin, vDecalID, float24, splitTriNormal[0], float5, splitTriUV2[0], float28, splitTriSkin[0], float25, splitTriNormal[1], float6, splitTriUV2[1], float29, splitTriSkin[1], float26, splitTriNormal[2], float7, splitTriUV2[2], float30, splitTriSkin[2], decalID);
							continue;
						}
						if (fixedOffset + 3 >= length3)
						{
							fixedOffset = 0;
						}
						vPos[fixedOffset] = float24;
						vPos[fixedOffset + 1] = float25;
						vPos[fixedOffset + 2] = float26;
						vNormal[fixedOffset] = splitTriNormal[0];
						vNormal[fixedOffset + 1] = splitTriNormal[1];
						vNormal[fixedOffset + 2] = splitTriNormal[2];
						vUV2[fixedOffset] = splitTriUV2[0];
						vUV2[fixedOffset + 1] = splitTriUV2[1];
						vUV2[fixedOffset + 2] = splitTriUV2[2];
						if (flag4)
						{
							vSkin[fixedOffset] = splitTriSkin[0];
							vSkin[fixedOffset + 1] = splitTriSkin[1];
							vSkin[fixedOffset + 2] = splitTriSkin[2];
						}
						if (flag3)
						{
							vColor[fixedOffset] = float5;
							vColor[fixedOffset + 1] = float6;
							vColor[fixedOffset + 2] = float7;
						}
						vUV[fixedOffset] = float28;
						vUV[fixedOffset + 1] = float29;
						vUV[fixedOffset + 2] = float30;
						vIndices[fixedTriOffset] = fixedOffset;
						vIndices[fixedTriOffset + 1] = fixedOffset + 1;
						vIndices[fixedTriOffset + 2] = fixedOffset + 2;
						fixedOffset += 3;
						fixedTriOffset += 3;
						continue;
					}
					splitTriPos[0] = float24;
					splitTriPos[1] = float25;
					splitTriPos[2] = float26;
					float3 planeN = float21;
					float planeD = num43;
					int num51 = 0;
					int num52 = 0;
					SplitTriangle(splitTriPos, splitTriNormal, splitTriUV, splitTriColor, splitTriUV2, splitTriSkin, planeN, planeD, vTempSplitPos, vTempSplitNormal, vTempSplitUV, vTempSplitColor, vTempSplitUV2, vTempSplitSkin, vTempSplitIndices, ref num51, ref num52, flag3, useUV: false, flag4, tmpWeight);
					planeN = float22;
					planeD = num44;
					int num53 = num52;
					for (int num54 = 0; num54 < num53; num54 += 3)
					{
						splitTriPos[0] = vTempSplitPos[vTempSplitIndices[num54]];
						splitTriPos[1] = vTempSplitPos[vTempSplitIndices[num54 + 1]];
						splitTriPos[2] = vTempSplitPos[vTempSplitIndices[num54 + 2]];
						splitTriNormal[0] = vTempSplitNormal[vTempSplitIndices[num54]];
						splitTriNormal[1] = vTempSplitNormal[vTempSplitIndices[num54 + 1]];
						splitTriNormal[2] = vTempSplitNormal[vTempSplitIndices[num54 + 2]];
						splitTriUV2[0] = vTempSplitUV2[vTempSplitIndices[num54]];
						splitTriUV2[1] = vTempSplitUV2[vTempSplitIndices[num54 + 1]];
						splitTriUV2[2] = vTempSplitUV2[vTempSplitIndices[num54 + 2]];
						if (flag4)
						{
							splitTriSkin[0] = vTempSplitSkin[vTempSplitIndices[num54]];
							splitTriSkin[1] = vTempSplitSkin[vTempSplitIndices[num54 + 1]];
							splitTriSkin[2] = vTempSplitSkin[vTempSplitIndices[num54 + 2]];
						}
						SplitTriangle(splitTriPos, splitTriNormal, splitTriUV, splitTriColor, splitTriUV2, splitTriSkin, planeN, planeD, vTempSplitPos, vTempSplitNormal, vTempSplitUV, vTempSplitColor, vTempSplitUV2, vTempSplitSkin, vTempSplitIndices, ref num51, ref num52, flag3, useUV: false, flag4, tmpWeight);
					}
					planeN = float23;
					planeD = num45;
					int num55 = fixedOffset;
					int num56 = num52;
					for (int num57 = num53; num57 < num56; num57 += 3)
					{
						splitTriPos[0] = vTempSplitPos[vTempSplitIndices[num57]];
						splitTriPos[1] = vTempSplitPos[vTempSplitIndices[num57 + 1]];
						splitTriPos[2] = vTempSplitPos[vTempSplitIndices[num57 + 2]];
						splitTriNormal[0] = vTempSplitNormal[vTempSplitIndices[num57]];
						splitTriNormal[1] = vTempSplitNormal[vTempSplitIndices[num57 + 1]];
						splitTriNormal[2] = vTempSplitNormal[vTempSplitIndices[num57 + 2]];
						splitTriUV2[0] = vTempSplitUV2[vTempSplitIndices[num57]];
						splitTriUV2[1] = vTempSplitUV2[vTempSplitIndices[num57 + 1]];
						splitTriUV2[2] = vTempSplitUV2[vTempSplitIndices[num57 + 2]];
						if (flag4)
						{
							splitTriSkin[0] = vTempSplitSkin[vTempSplitIndices[num57]];
							splitTriSkin[1] = vTempSplitSkin[vTempSplitIndices[num57 + 1]];
							splitTriSkin[2] = vTempSplitSkin[vTempSplitIndices[num57 + 2]];
						}
						if (isRuntimeFixedArray)
						{
							SplitTriangle2(splitTriPos, splitTriNormal, splitTriUV, splitTriColor, splitTriUV2, splitTriSkin, planeN, planeD, decalID, ref fixedOffset, vPos, vNormal, vUV, vColor, vUV2, vSkin, vDecalID, flag3, flag5, flag4, tmpWeight);
						}
						else
						{
							SplitTriangle(splitTriPos, splitTriNormal, splitTriUV, splitTriColor, splitTriUV2, splitTriSkin, planeN, planeD, vPos, vNormal, vUV, vColor, vUV2, vSkin, vIndices, ref fixedOffset, ref fixedTriOffset, flag3, flag5, flag4, tmpWeight);
						}
					}
					int num58 = fixedOffset;
					for (int num59 = num55; num59 < num58; num59++)
					{
						float3 pp = vPos[num59];
						float2 value4 = triLerp(p4, p5, p6, float16, float17, float18, pp);
						vUV[num59] = value4;
						if (flag3)
						{
							float4 value5 = ((!flag2) ? new float4(1f, 1f, 1f, 1f) : (triLerp(p, p2, p3, float16, float17, float18, pp) * opacity));
							if (angleFade)
							{
								value5 *= math.clamp(math.dot(vNormal[num59], float20) * num39 + num40, 0f, 1f) * opacity;
							}
							vColor[num59] = value5;
						}
					}
				}
			}
			avgDir[0] = math.normalize(avgDir[0]);
			if (flag4)
			{
				float3x3 a = new float3x3(math.normalize(staticTformInvMatrix.c0.xyz), math.normalize(staticTformInvMatrix.c1.xyz), math.normalize(staticTformInvMatrix.c2.xyz));
				for (int num60 = 0; num60 < fixedOffset; num60++)
				{
					float4 float31 = math.mul(staticTformInvMatrix, new float4(vPos[num60], 1f));
					vPos[num60] = new float3(float31.x, float31.y, float31.z);
					vNormal[num60] = math.mul(a, vNormal[num60]);
				}
			}
			if (isRuntimeFixedArray)
			{
				byte b = vDecalID[fixedOffset];
				int num61;
				int num62;
				if (b != 0)
				{
					num61 = fixedOffset;
					num62 = fixedOffset + maxTrisInDecal;
					float num63 = float.PositiveInfinity;
					float3 value6 = new float3(num63, num63, num63);
					for (int num64 = num61; num64 < num62; num64++)
					{
						int num65 = num64;
						if (num65 >= length3)
						{
							num65 = num64 % length3;
						}
						if (vDecalID[num65] != b)
						{
							break;
						}
						vPos[num65] = value6;
					}
				}
				num61 = num;
				num62 = ((fixedOffset >= num) ? fixedOffset : (length3 + fixedOffset));
				if (transformToParent)
				{
					float3x3 a = new float3x3(math.normalize(staticTformInvMatrix.c0.xyz), math.normalize(staticTformInvMatrix.c1.xyz), math.normalize(staticTformInvMatrix.c2.xyz));
					for (int num66 = num61; num66 < num62; num66++)
					{
						int num67 = num66;
						if (num67 >= length3)
						{
							num67 = num66 % length3;
						}
						float4 float32 = math.mul(staticTformInvMatrix, new float4(vPos[num67], 1f));
						vPos[num67] = new float3(float32.x, float32.y, float32.z);
						vNormal[num67] = math.mul(a, vNormal[num67]);
					}
				}
				if (transformUV1)
				{
					for (int num68 = num61; num68 < num62; num68++)
					{
						int num69 = num68;
						if (num69 >= length3)
						{
							num69 = num68 % length3;
						}
						vUV2[num69] = new float2(vUV2[num69].x * _lightmapScaleOffset.x + _lightmapScaleOffset.z, vUV2[num69].y * _lightmapScaleOffset.y + _lightmapScaleOffset.w);
					}
				}
				if (tangents)
				{
					for (int num70 = num61; num70 < num62; num70 += 3)
					{
						int num71 = num70;
						if (num71 >= length3)
						{
							num71 = num70 % length3;
						}
						float3 float33 = vPos[num71];
						if (!float.IsNaN(float33.x))
						{
							float3 float34 = vPos[num71 + 1];
							float3 float35 = vPos[num71 + 2];
							float2 float36 = vUV[num71];
							float2 float37 = vUV[num71 + 1];
							float2 obj2 = vUV[num71 + 2];
							float3 float38 = float34 - float33;
							float3 float39 = float35 - float33;
							float2 float40 = float37 - float36;
							float2 float41 = obj2 - float36;
							float num72 = 1f / (float40.x * float41.y - float41.x * float40.y);
							float3 y = math.normalize((float41.y * float38 - float40.y * float39) * num72);
							float3 y2 = math.normalize((float40.x * float39 - float41.x * float38) * num72);
							float w = ((math.dot(math.cross(vNormal[num71], y), y2) < 0f) ? (-1f) : 1f);
							ref NativeArray<float4> reference = ref vTangents;
							int index8 = num71;
							ref NativeArray<float4> reference2 = ref vTangents;
							int index9 = num71 + 1;
							float4 float42 = (vTangents[num71 + 2] = new float4(y.x, y.y, y.z, w));
							float4 value7 = (reference2[index9] = float42);
							reference[index8] = value7;
						}
					}
				}
			}
			outputsInt[0] = fixedOffset;
			outputsInt[1] = fixedTriOffset;
		}
	}

	private static NativeArray<float3> _splitTriPos;

	private static NativeArray<float3> _splitTriNormal;

	private static NativeArray<float2> _splitTriUV;

	private static NativeArray<float2> _splitTriUV2;

	private static NativeArray<float4> _splitTriColor;

	private static NativeArray<BoneWeight> _splitTriSkin;

	private static NativeArray<float3> nAvgDir;

	private static NativeArray<int> nOutputs;

	private static NativeArray<float3> nvTempSplitPos;

	private static NativeArray<float3> nvTempSplitNormal;

	private static NativeArray<float4> nvTempSplitColor;

	private static NativeArray<float2> nvTempSplitUV2;

	private static NativeArray<float2> nvTempSplitUV;

	private static NativeArray<BoneWeight> nvTempSplitSkin;

	private static NativeArray<int> nvTempSplitIndices;

	private static NativeArray<float3> nvPos;

	private static NativeArray<float3> nvNormal;

	private static NativeArray<float4> nvColor;

	private static NativeArray<float4> vEmptyColor;

	private static NativeArray<float4> vEmptyTangent;

	private static NativeArray<float2> nvUV2;

	private static NativeArray<float2> nvUV;

	private static NativeArray<BoneWeight> nvSkin;

	private static NativeArray<BoneWeight> vEmptySkin;

	private static NativeArray<float3> vEmptyPos;

	private static NativeArray<float3> vEmptyNorm;

	private static NativeArray<byte> nvDecalID;

	private static NativeArray<int> nvIndices;

	private static NativeArray<int> vEmptyIndices;

	private static NativeArray<bool> nvCulled;

	private static bool staticNativeArraysInit;

	private const int maxOutputVerts = 256000;

	private const int maxOutputIndices = 768000;

	private const int maxTempSplitVerts = 256;

	private const int maxTempSplitIndices = 768;

	private static BoneWeight _tmpWeight;

	private static Matrix4x4 cullingMatrix;

	private static Vector4 lightmapScaleOffset;

	private const int FLAG_UV = 1;

	private const int FLAG_VC = 2;

	private const int FLAG_SKIN = 4;

	private static float saturate(float f)
	{
		return Mathf.Clamp(f, 0f, 1f);
	}

	private static float2 triLerp(float2 p0, float2 p1, float2 p2, float3 a, float3 b, float3 c, float3 pp)
	{
		float3 float5 = b - a;
		float3 float6 = c - a;
		float3 x = pp - a;
		float num = math.dot(float5, float5);
		float num2 = math.dot(float5, float6);
		float num3 = math.dot(float6, float6);
		float num4 = math.dot(x, float5);
		float num5 = math.dot(x, float6);
		float num6 = num * num3 - num2 * num2;
		float num7 = (num3 * num4 - num2 * num5) / num6;
		float num8 = (num * num5 - num2 * num4) / num6;
		float num9 = 1f - num7 - num8;
		return p0 * num9 + p1 * num7 + p2 * num8;
	}

	private static float3 triLerp(float3 p0, float3 p1, float3 p2, float3 a, float3 b, float3 c, float3 pp)
	{
		float3 float5 = b - a;
		float3 float6 = c - a;
		float3 x = pp - a;
		float num = math.dot(float5, float5);
		float num2 = math.dot(float5, float6);
		float num3 = math.dot(float6, float6);
		float num4 = math.dot(x, float5);
		float num5 = math.dot(x, float6);
		float num6 = num * num3 - num2 * num2;
		float num7 = (num3 * num4 - num2 * num5) / num6;
		float num8 = (num * num5 - num2 * num4) / num6;
		float num9 = 1f - num7 - num8;
		return p0 * num9 + p1 * num7 + p2 * num8;
	}

	private static float4 triLerp(float4 p0, float4 p1, float4 p2, float3 a, float3 b, float3 c, float3 pp)
	{
		float3 float5 = b - a;
		float3 float6 = c - a;
		float3 x = pp - a;
		float num = math.dot(float5, float5);
		float num2 = math.dot(float5, float6);
		float num3 = math.dot(float6, float6);
		float num4 = math.dot(x, float5);
		float num5 = math.dot(x, float6);
		float num6 = num * num3 - num2 * num2;
		float num7 = (num3 * num4 - num2 * num5) / num6;
		float num8 = (num * num5 - num2 * num4) / num6;
		float num9 = 1f - num7 - num8;
		return p0 * num9 + p1 * num7 + p2 * num8;
	}

	private static BoneWeight LerpBoneWeights(BoneWeight a, BoneWeight b, float c)
	{
		a.weight0 = math.lerp(a.weight0, b.weight0, c);
		a.weight1 = math.lerp(a.weight1, b.weight1, c);
		a.weight2 = math.lerp(a.weight2, b.weight2, c);
		a.weight3 = math.lerp(a.weight3, b.weight3, c);
		return a;
	}

	private static void WeldVerts(int numInVerts, int numInIndices, int inputFlags, ref int numOutVerts, ref int numOutIndices, NativeArray<int> inIndices, NativeArray<float3> inVerts, NativeArray<float3> inNormals, NativeArray<float2> inUV, NativeArray<float2> inUV2, NativeArray<BoneWeight> inSkin, NativeArray<float4> inColor, NativeArray<int> outIndices, NativeArray<float3> outVerts, NativeArray<float3> outNormals, NativeArray<float2> outUV, NativeArray<float2> outUV2, NativeArray<BoneWeight> outSkin, NativeArray<float4> outColor)
	{
		HashedVertex key = default;
		Dictionary<HashedVertex, int> dictionary = new Dictionary<HashedVertex, int>();
		bool flag = (inputFlags & 1) != 0;
		bool flag2 = (inputFlags & 2) != 0;
		bool flag3 = (inputFlags & 4) != 0;
		numOutVerts = 0;
		int[] array = new int[numInVerts];
		for (int i = 0; i < numInVerts; i++)
		{
			array[i] = -1;
		}
		for (int j = 0; j < numInVerts; j++)
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
				value = (dictionary[key] = numOutVerts);
				array[j] = numOutVerts;
				outVerts[numOutVerts] = inVerts[j];
				outNormals[numOutVerts] = inNormals[j];
				outUV2[numOutVerts] = inUV2[j];
				if (flag)
				{
					outUV[numOutVerts] = inUV[j];
				}
				if (flag2)
				{
					outColor[numOutVerts] = inColor[j];
				}
				if (flag3)
				{
					outSkin[numOutVerts] = inSkin[j];
				}
				numOutVerts++;
			}
			else
			{
				array[j] = value;
			}
		}
		numOutIndices = 0;
		for (int k = 0; k < numInIndices; k++)
		{
			outIndices[numOutIndices] = array[inIndices[k]];
			numOutIndices++;
		}
	}

	private static void UpdateDecalFor(DecalGroup decal, Material sharedMaterial, Vector2[] _decalUV, Vector3[] _decalPosW, Transform decalTform, int[] _decalTris, Color[] _decalColor, GameObject parentObject, Material optionalMateralChange, float _opacity, ref int _fixedOffset, byte _decalID = 0, Mesh newMesh = null, DecalUtils.Group groupData = null, int _maxTrisInDecal = 0, bool _transformToParent = false, bool _earlyCull = false, bool _transformUV1 = false)
	{
		int num = ((_decalUV != null && _decalUV.Length != 0) ? 1 : 0) | ((_decalColor != null && _decalColor.Length != 0) ? 2 : 0);
		bool flag = (num & 2) != 0;
		Vector2 zero = Vector2.zero;
		Vector3 zero2 = Vector3.zero;
		bool flag2 = decalTform != null;
		Mesh sharedMesh = DecalUtils.GetSharedMesh(parentObject, out var terrain);
		bool flag3 = terrain != null;
		if (sharedMesh == null && !flag3)
		{
			return;
		}
		Transform transform = parentObject.transform;
		Vector2[] array = null;
		BoneWeight[] array2 = null;
		bool flag4 = false;
		bool isStaticFlipped = false;
		SkinnedMeshRenderer skinnedMeshRenderer = null;
		int num2 = 0;
		float terrainInvScaleX = 0f;
		float terrainInvScaleZ = 0f;
		DecalUtils.CachedTerrain value = null;
		Renderer renderer;
		Vector3[] array3;
		Vector3[] array4;
		int[] array5;
		if (flag3)
		{
			TerrainData terrainData = terrain.terrainData;
			renderer = null;
			Vector3 position = transform.position;
			if (!DecalUtils.cachedTerrains.TryGetValue(terrainData, out value))
			{
				value = DecalUtils.PrepareTerrain(terrainData, position, useBurst: true);
			}
			if (value.nStaticPos.Length == 0)
			{
				value = DecalUtils.PrepareTerrain(terrainData, position, useBurst: true);
			}
			array3 = value.pos;
			array4 = value.norm;
			array = value.uv;
			array5 = value.indices;
			num2 = terrainData.heightmapResolution;
			terrainInvScaleX = (float)(num2 - 1) / terrainData.size.x;
			terrainInvScaleZ = (float)(num2 - 1) / terrainData.size.z;
		}
		else
		{
			renderer = parentObject.GetComponent<Renderer>();
			array3 = sharedMesh.vertices;
			array4 = sharedMesh.normals;
			array5 = sharedMesh.triangles;
		}
		if (array4 == null || array4.Length == 0)
		{
			if (!(decalTform == null))
			{
				Debug.LogError("Receiver " + decalTform.name + " has no normals");
			}
			return;
		}
		if (terrain == null)
		{
			array = sharedMesh.uv2;
			if (array.Length == 0)
			{
				array = sharedMesh.uv;
			}
			skinnedMeshRenderer = renderer as SkinnedMeshRenderer;
			array2 = sharedMesh.boneWeights;
			flag4 = array2 != null && array2.Length != 0 && skinnedMeshRenderer != null;
			isStaticFlipped = Mathf.Sign(transform.lossyScale.x * transform.lossyScale.y * transform.lossyScale.z) < 0f;
		}
		int staticFlags = (flag4 ? 4 : 0);
		int length = array3.Length;
		if (!staticNativeArraysInit)
		{
			_splitTriPos = new NativeArray<float3>(3, Allocator.Persistent);
			_splitTriNormal = new NativeArray<float3>(3, Allocator.Persistent);
			_splitTriUV = new NativeArray<float2>(3, Allocator.Persistent);
			_splitTriUV2 = new NativeArray<float2>(3, Allocator.Persistent);
			_splitTriColor = new NativeArray<float4>(3, Allocator.Persistent);
			_splitTriSkin = new NativeArray<BoneWeight>(3, Allocator.Persistent);
			nOutputs = new NativeArray<int>(2, Allocator.Persistent);
			nAvgDir = new NativeArray<float3>(1, Allocator.Persistent);
			nvTempSplitPos = new NativeArray<float3>(256, Allocator.Persistent);
			nvTempSplitNormal = new NativeArray<float3>(256, Allocator.Persistent);
			nvTempSplitColor = new NativeArray<float4>(256, Allocator.Persistent);
			nvTempSplitUV = new NativeArray<float2>(256, Allocator.Persistent);
			nvTempSplitUV2 = new NativeArray<float2>(256, Allocator.Persistent);
			nvTempSplitSkin = new NativeArray<BoneWeight>(256, Allocator.Persistent);
			nvTempSplitIndices = new NativeArray<int>(768, Allocator.Persistent);
			nvPos = new NativeArray<float3>(256000, Allocator.Persistent);
			nvNormal = new NativeArray<float3>(256000, Allocator.Persistent);
			nvColor = new NativeArray<float4>(256000, Allocator.Persistent);
			nvUV2 = new NativeArray<float2>(256000, Allocator.Persistent);
			nvUV = new NativeArray<float2>(256000, Allocator.Persistent);
			nvSkin = new NativeArray<BoneWeight>(256000, Allocator.Persistent);
			nvDecalID = new NativeArray<byte>(0, Allocator.Persistent);
			nvIndices = new NativeArray<int>(768000, Allocator.Persistent);
			nvCulled = new NativeArray<bool>(768000, Allocator.Persistent);
			vEmptySkin = new NativeArray<BoneWeight>(0, Allocator.Persistent);
			vEmptyPos = new NativeArray<float3>(0, Allocator.Persistent);
			vEmptyNorm = new NativeArray<float3>(0, Allocator.Persistent);
			vEmptyColor = new NativeArray<float4>(0, Allocator.Persistent);
			vEmptyTangent = new NativeArray<float4>(0, Allocator.Persistent);
			vEmptyIndices = new NativeArray<int>(0, Allocator.Persistent);
			staticNativeArraysInit = true;
		}
		NativeArray<float2> decalUV = new NativeArray<Vector2>(_decalUV, Allocator.TempJob).Reinterpret<float2>();
		NativeArray<float3> decalPosW = new NativeArray<Vector3>(_decalPosW, Allocator.TempJob).Reinterpret<float3>();
		NativeArray<int> decalTris = new NativeArray<int>(_decalTris, Allocator.TempJob);
		NativeArray<float4> decalColor = (flag ? new NativeArray<Color>(_decalColor, Allocator.TempJob).Reinterpret<float4>() : vEmptyColor);
		NativeArray<bool> staticTriCulled = nvCulled;
		NativeArray<float3> staticPos;
		NativeArray<float3> staticPosW;
		NativeArray<float3> staticNorm;
		NativeArray<float3> staticNormW;
		NativeArray<float2> staticUV;
		NativeArray<int> staticTris;
		NativeArray<BoneWeight> staticSkin;
		if (flag3)
		{
			staticPos = value.nStaticPos;
			staticPosW = vEmptyPos;
			staticNorm = value.nStaticNorm;
			staticNormW = vEmptyNorm;
			staticUV = value.nStaticUV2;
			staticTris = value.nStaticTris;
			staticSkin = vEmptySkin;
		}
		else
		{
			staticPos = new NativeArray<Vector3>(array3, Allocator.TempJob).Reinterpret<float3>();
			staticPosW = new NativeArray<float3>(length, Allocator.TempJob);
			staticNorm = new NativeArray<Vector3>(array4, Allocator.TempJob).Reinterpret<float3>();
			staticNormW = new NativeArray<float3>(length, Allocator.TempJob);
			staticTris = new NativeArray<int>(array5, Allocator.TempJob);
			staticUV = ((array.Length != 0) ? new NativeArray<Vector2>(array, Allocator.TempJob).Reinterpret<float2>() : new NativeArray<float2>(array3.Length, Allocator.TempJob));
			staticSkin = ((!flag4) ? vEmptySkin : new NativeArray<BoneWeight>(array2, Allocator.TempJob));
		}
		bool flag5 = groupData != null;
		int num3 = 0;
		int num4 = _fixedOffset;
		NativeArray<float3> vPos;
		NativeArray<float3> vNormal;
		NativeArray<float4> vColor;
		NativeArray<float2> vUV;
		NativeArray<float2> vUV2;
		NativeArray<BoneWeight> vSkin;
		NativeArray<byte> vDecalID;
		NativeArray<float4> vTangents;
		NativeArray<int> vIndices;
		if (flag5)
		{
			vPos = groupData.nvPos.Reinterpret<float3>();
			vNormal = groupData.nvNormal.Reinterpret<float3>();
			vColor = groupData.nvColor.Reinterpret<float4>();
			vUV = groupData.nvUV2.Reinterpret<float2>();
			vUV2 = groupData.nvUV.Reinterpret<float2>();
			vSkin = (flag4 ? groupData.nvSkin : nvSkin);
			vDecalID = groupData.nvDecalID;
			vTangents = (decal.tangents ? groupData.nvTangents.Reinterpret<float4>() : vEmptyTangent);
			vIndices = vEmptyIndices;
		}
		else
		{
			vPos = nvPos;
			vNormal = nvNormal;
			vColor = nvColor;
			vTangents = vEmptyTangent;
			vUV = nvUV2;
			vUV2 = nvUV;
			vSkin = nvSkin;
			vDecalID = nvDecalID;
			vIndices = nvIndices;
			_fixedOffset = 0;
		}
		int fixedTriOffset = 0;
		UpdateDecalFor_Job jobData = new UpdateDecalFor_Job
		{
			decalUV = decalUV,
			decalPosW = decalPosW,
			decalTris = decalTris,
			decalColor = decalColor,
			opacity = _opacity,
			roadTransform = decal.roadTransform,
			mainTextureScale = (decal.roadTransform ? sharedMaterial.mainTextureScale : zero),
			mainTextureOffset = (decal.roadTransform ? sharedMaterial.mainTextureOffset : zero),
			atlasMinX = decal.atlasMinX,
			atlasMaxX = decal.atlasMaxX,
			atlasMinY = decal.atlasMinY,
			atlasMaxY = decal.atlasMaxY,
			tformRight = (flag2 ? decalTform.right : zero2),
			tformUp = (flag2 ? decalTform.up : zero2),
			tformForward = (flag2 ? decalTform.forward : zero2),
			tformPosition = (flag2 ? decalTform.position : zero2),
			isDecalFlipped = (flag2 && Mathf.Sign(decalTform.lossyScale.x * decalTform.lossyScale.y * decalTform.lossyScale.z) < 0f),
			staticPos = staticPos,
			staticPosW = staticPosW,
			staticNorm = staticNorm,
			staticNormW = staticNormW,
			staticUV2 = staticUV,
			staticTris = staticTris,
			staticSkin = staticSkin,
			staticTriCulled = staticTriCulled,
			staticTformMatrix = transform.localToWorldMatrix,
			staticTformInvMatrix = transform.worldToLocalMatrix,
			isStaticFlipped = isStaticFlipped,
			heightmapRes = num2,
			terrainInvScaleX = terrainInvScaleX,
			terrainInvScaleZ = terrainInvScaleZ,
			earlyCull = _earlyCull,
			cullingMtx = cullingMatrix,
			angleFade = decal.angleFade,
			angleClip = decal.angleClip,
			rayLength = decal.rayLength,
			bias = decal.bias,
			splitTriPos = _splitTriPos,
			splitTriNormal = _splitTriNormal,
			splitTriUV = _splitTriUV,
			splitTriUV2 = _splitTriUV2,
			splitTriColor = _splitTriColor,
			splitTriSkin = _splitTriSkin,
			isRuntimeFixedArray = flag5,
			fixedOffset = _fixedOffset,
			fixedTriOffset = fixedTriOffset,
			vPos = vPos,
			vNormal = vNormal,
			vColor = vColor,
			vTangents = vTangents,
			vUV2 = vUV,
			vUV = vUV2,
			vSkin = vSkin,
			vDecalID = vDecalID,
			vIndices = vIndices,
			vTempSplitPos = nvTempSplitPos,
			vTempSplitNormal = nvTempSplitNormal,
			vTempSplitColor = nvTempSplitColor,
			vTempSplitUV = nvTempSplitUV,
			vTempSplitUV2 = nvTempSplitUV2,
			vTempSplitSkin = nvTempSplitSkin,
			vTempSplitIndices = nvTempSplitIndices,
			decalID = _decalID,
			decalFlags = num,
			staticFlags = staticFlags,
			tmpWeight = _tmpWeight,
			maxTrisInDecal = _maxTrisInDecal,
			transformToParent = _transformToParent,
			transformUV1 = _transformUV1,
			_lightmapScaleOffset = lightmapScaleOffset,
			tangents = decal.tangents,
			outputsInt = nOutputs,
			avgDir = nAvgDir
		};
		jobData.Schedule().Complete();
		decal.avgDir = jobData.avgDir[0];
		int num5 = nOutputs[0];
		int length2 = nOutputs[1];
		bool flag6 = false;
		bool flag7 = decalColor.Length > 0 || decal.angleFade || _opacity != 1f;
		num3 = jobData.vPos.Length;
		if (newMesh == null)
		{
			if (num5 == 0)
			{
				Debug.Log("No mesh was created for " + decal.name);
				flag6 = true;
			}
			if (!flag6)
			{
				newMesh = new Mesh();
				newMesh.vertices = new NativeSlice<Vector3>(jobData.vPos.Reinterpret<Vector3>(), 0, num5).ToArray();
				newMesh.normals = new NativeSlice<Vector3>(jobData.vNormal.Reinterpret<Vector3>(), 0, num5).ToArray();
				newMesh.uv = new NativeSlice<Vector2>(jobData.vUV.Reinterpret<Vector2>(), 0, num5).ToArray();
				newMesh.uv2 = new NativeSlice<Vector2>(jobData.vUV2.Reinterpret<Vector2>(), 0, num5).ToArray();
				if (flag4)
				{
					newMesh.boneWeights = new NativeSlice<BoneWeight>(jobData.vSkin, 0, num5).ToArray();
				}
				if (flag7)
				{
					newMesh.colors = new NativeSlice<Color>(jobData.vColor.Reinterpret<Color>(), 0, num5).ToArray();
				}
				newMesh.triangles = new NativeSlice<int>(jobData.vIndices, 0, length2).ToArray();
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
					GameObject obj = new GameObject
					{
						name = "NEW_DECAL#parent"
					};
					Transform transform2 = decal.transform;
					Transform transform3 = obj.transform;
					transform3.parent = transform2;
					transform3.localPosition = Vector3.zero;
					transform3.localRotation = Quaternion.identity;
					Vector3 localScale = transform2.localScale;
					transform3.localScale = new Vector3(1f / localScale.x, 1f / localScale.y, 1f / localScale.z);
					gameObject.transform.parent = transform3;
				}
				Renderer renderer2 = null;
				gameObject.layer = decal.gameObject.layer;
				if (flag4)
				{
					SkinnedMeshRenderer skinnedMeshRenderer2 = gameObject.AddComponent<SkinnedMeshRenderer>();
					skinnedMeshRenderer2.sharedMaterial = ((optionalMateralChange != null) ? optionalMateralChange : sharedMaterial);
					skinnedMeshRenderer2.bones = skinnedMeshRenderer.bones;
					newMesh.bindposes = skinnedMeshRenderer.sharedMesh.bindposes;
					skinnedMeshRenderer2.sharedMesh = newMesh;
					skinnedMeshRenderer2.rootBone = skinnedMeshRenderer.rootBone;
					renderer2 = skinnedMeshRenderer2;
				}
				else
				{
					gameObject.AddComponent<MeshFilter>().sharedMesh = newMesh;
					renderer2 = gameObject.AddComponent<MeshRenderer>();
					renderer2.sharedMaterial = ((optionalMateralChange != null) ? optionalMateralChange : sharedMaterial);
				}
				if (terrain != null)
				{
					renderer2.lightmapIndex = terrain.lightmapIndex;
					renderer2.lightmapScaleOffset = terrain.lightmapScaleOffset;
					renderer2.realtimeLightmapIndex = terrain.realtimeLightmapIndex;
					renderer2.realtimeLightmapScaleOffset = terrain.realtimeLightmapScaleOffset;
				}
				else
				{
					if (decal.surfaceReplacement != null)
					{
						for (int i = 0; i < decal.surfaceReplacement.Length; i++)
						{
							if (decal.surfaceReplacement[i] == renderer.sharedMaterial)
							{
								renderer2.sharedMaterial = decal.surfaceReplacementMaterial[i];
								break;
							}
						}
					}
					renderer2.lightmapIndex = renderer.lightmapIndex;
					renderer2.lightmapScaleOffset = renderer.lightmapScaleOffset;
					renderer2.realtimeLightmapIndex = renderer.realtimeLightmapIndex;
					renderer2.realtimeLightmapScaleOffset = renderer.realtimeLightmapScaleOffset;
					if (renderer.HasPropertyBlock())
					{
						MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
						renderer.GetPropertyBlock(materialPropertyBlock);
						renderer2.SetPropertyBlock(materialPropertyBlock);
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
					int item = renderer2.lightmapIndex;
					int num6 = ftLightmapsStorage2.bakedRenderers.LastIndexOf(renderer);
					if (num6 >= 0)
					{
						item = ftLightmapsStorage2.bakedIDs[num6];
					}
					ftLightmapsStorage2.bakedRenderers.Add(renderer2);
					ftLightmapsStorage2.bakedIDs.Add(item);
					ftLightmapsStorage2.bakedScaleOffset.Add(renderer2.lightmapScaleOffset);
				}
			}
		}
		else
		{
			newMesh.vertices = new NativeSlice<Vector3>(jobData.vPos.Reinterpret<Vector3>(), 0, num3).ToArray();
			newMesh.normals = new NativeSlice<Vector3>(jobData.vNormal.Reinterpret<Vector3>(), 0, num3).ToArray();
			newMesh.uv = new NativeSlice<Vector2>(jobData.vUV.Reinterpret<Vector2>(), 0, num3).ToArray();
			newMesh.uv2 = new NativeSlice<Vector2>(jobData.vUV2.Reinterpret<Vector2>(), 0, num3).ToArray();
			if (flag4)
			{
				newMesh.boneWeights = new NativeSlice<BoneWeight>(jobData.vSkin, 0, num3).ToArray();
			}
			if (flag7)
			{
				newMesh.colors = new NativeSlice<Color>(jobData.vColor.Reinterpret<Color>(), 0, num3).ToArray();
			}
			if (decal.tangents)
			{
				newMesh.tangents = new NativeSlice<Vector4>(jobData.vTangents.Reinterpret<Vector4>(), 0, num3).ToArray();
			}
			_fixedOffset = num5;
		}
		if (!flag3)
		{
			staticPos.Dispose();
			staticPosW.Dispose();
			staticNorm.Dispose();
			staticNormW.Dispose();
			staticUV.Dispose();
			staticTris.Dispose();
		}
		if (flag4)
		{
			staticSkin.Dispose();
		}
		decalUV.Dispose();
		decalPosW.Dispose();
		decalTris.Dispose();
		if (flag)
		{
			decalColor.Dispose();
		}
	}

	public static void UpdateDecal(DecalGroup decal)
	{
		GameObject gameObject = decal.gameObject;
		MeshFilter component = gameObject.GetComponent<MeshFilter>();
		if (component == null)
		{
			Debug.Log("No mesh on " + decal.name);
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
					num |= 1 << decal.parentObjectsAdditional[l].layer;
					list.Add(decal.parentObjectsAdditional[l]);
					list2.Add(decal.optionalMateralChangeAdditional[l]);
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
		int _fixedOffset = 0;
		for (int n = 0; n < list.Count; n++)
		{
			UpdateDecalFor(decal, meshRenderer.sharedMaterial, uv, array, transform, triangles, colors, list[n], (list2 == null) ? decal.optionalMateralChange : list2[n], 1f, ref _fixedOffset, 0);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static float GetDistanceToPoint(float3 pn, float pd, float3 p)
	{
		return math.dot(pn, p) + pd;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool PlaneRaycast(float3 planeN, float planeD, float3 rayO, float3 rayDir, out float enter)
	{
		float num = math.dot(rayDir, planeN);
		float num2 = 0f - math.dot(rayO, planeN) - planeD;
		if (math.abs(num) < 1E-05f)
		{
			enter = 0f;
			return false;
		}
		enter = num2 / num;
		return enter > 0f;
	}

	private static void SplitTriangle(NativeArray<float3> triPos, NativeArray<float3> triNormal, NativeArray<float2> triUV, NativeArray<float4> triColor, NativeArray<float2> triUV2, NativeArray<BoneWeight> triSkin, float3 planeN, float planeD, NativeArray<float3> newPos, NativeArray<float3> newNormal, NativeArray<float2> newUV, NativeArray<float4> newColor, NativeArray<float2> newUV2, NativeArray<BoneWeight> newSkin, NativeArray<int> newIndices, ref int fixedOffset, ref int fixedTriOffset, bool useVColor, bool useUV, bool hasSkin, BoneWeight tmpWeight)
	{
		float3 float5 = triPos[0];
		float3 float6 = triPos[1];
		float3 float7 = triPos[2];
		float3 float8 = triNormal[0];
		float3 float9 = triNormal[1];
		float3 float10 = triNormal[2];
		float2 float11 = triUV[0];
		float2 float12 = triUV[1];
		float2 float13 = triUV[2];
		float2 float14 = triUV2[0];
		float2 float15 = triUV2[1];
		float2 float16 = triUV2[2];
		BoneWeight boneWeight = tmpWeight;
		BoneWeight boneWeight2 = tmpWeight;
		BoneWeight boneWeight3 = tmpWeight;
		if (hasSkin)
		{
			boneWeight = triSkin[0];
			boneWeight2 = triSkin[1];
			boneWeight3 = triSkin[2];
		}
		float4 float17 = triColor[0];
		float4 float18 = triColor[1];
		float4 float19 = triColor[2];
		float distanceToPoint = GetDistanceToPoint(planeN, planeD, float5);
		float distanceToPoint2 = GetDistanceToPoint(planeN, planeD, float6);
		float distanceToPoint3 = GetDistanceToPoint(planeN, planeD, float7);
		float num = math.sign(distanceToPoint);
		float num2 = math.sign(distanceToPoint2);
		float num3 = math.sign(distanceToPoint3);
		bool num4 = num == num2 && num2 == num3;
		bool flag = num2 == num3 && distanceToPoint == 0f;
		bool flag2 = num2 == num && distanceToPoint3 == 0f;
		bool flag3 = num == num3 && distanceToPoint2 == 0f;
		if (num4 | flag | flag2 | flag3)
		{
			if (!(distanceToPoint > 0f))
			{
				newPos[fixedOffset] = float5;
				newPos[fixedOffset + 1] = float6;
				newPos[fixedOffset + 2] = float7;
				newNormal[fixedOffset] = float8;
				newNormal[fixedOffset + 1] = float9;
				newNormal[fixedOffset + 2] = float10;
				newUV2[fixedOffset] = float14;
				newUV2[fixedOffset + 1] = float15;
				newUV2[fixedOffset + 2] = float16;
				if (useVColor)
				{
					newColor[fixedOffset] = float17;
					newColor[fixedOffset + 1] = float18;
					newColor[fixedOffset + 2] = float19;
				}
				if (useUV)
				{
					newUV[fixedOffset] = float11;
					newUV[fixedOffset + 1] = float12;
					newUV[fixedOffset + 2] = float13;
				}
				if (hasSkin)
				{
					newSkin[fixedOffset] = boneWeight;
					newSkin[fixedOffset + 1] = boneWeight2;
					newSkin[fixedOffset + 2] = boneWeight3;
				}
				newIndices[fixedTriOffset] = fixedOffset;
				newIndices[fixedTriOffset + 1] = fixedOffset + 1;
				newIndices[fixedTriOffset + 2] = fixedOffset + 2;
				fixedOffset += 3;
				fixedTriOffset += 3;
			}
		}
		else if (num == num2)
		{
			float3 float20 = float5;
			float3 float21 = math.normalize(float7 - float5);
			PlaneRaycast(planeN, planeD, float20, float21, out var enter);
			float3 float22 = float20 + float21 * enter;
			float num5 = math.saturate(enter / math.length(float7 - float5));
			float22 = math.lerp(float5, float7, num5);
			float3 value = math.lerp(float8, float10, num5);
			float2 value2 = math.lerp(float11, float13, num5);
			float2 value3 = math.lerp(float14, float16, num5);
			BoneWeight value4 = tmpWeight;
			if (hasSkin)
			{
				value4 = LerpBoneWeights(boneWeight, boneWeight3, num5);
			}
			float4 value5 = math.lerp(float17, float19, num5);
			float3 float23 = float6;
			float3 float24 = math.normalize(float7 - float6);
			PlaneRaycast(planeN, planeD, float23, float24, out enter);
			float3 float25 = float23 + float24 * enter;
			float num6 = math.saturate(enter / math.length(float7 - float6));
			float25 = math.lerp(float6, float7, num6);
			float3 value6 = math.lerp(float9, float10, num6);
			float2 value7 = math.lerp(float12, float13, num6);
			float2 value8 = math.lerp(float15, float16, num6);
			BoneWeight value9 = tmpWeight;
			if (hasSkin)
			{
				value9 = LerpBoneWeights(boneWeight2, boneWeight3, num6);
			}
			float4 value10 = math.lerp(float18, float19, num6);
			int num7 = fixedOffset;
			int num8 = fixedOffset + 1;
			int num9 = fixedOffset + 2;
			int num10 = fixedOffset + 3;
			int num11 = fixedOffset + 4;
			newPos[num7] = float5;
			newPos[num8] = float6;
			newPos[num9] = float7;
			newPos[num10] = float22;
			newPos[num11] = float25;
			newNormal[num7] = float8;
			newNormal[num8] = float9;
			newNormal[num9] = float10;
			newNormal[num10] = value;
			newNormal[num11] = value6;
			newUV2[num7] = float14;
			newUV2[num8] = float15;
			newUV2[num9] = float16;
			newUV2[num10] = value3;
			newUV2[num11] = value8;
			if (useVColor)
			{
				newColor[num7] = float17;
				newColor[num8] = float18;
				newColor[num9] = float19;
				newColor[num10] = value5;
				newColor[num11] = value10;
			}
			if (useUV)
			{
				newUV[num7] = float11;
				newUV[num8] = float12;
				newUV[num9] = float13;
				newUV[num10] = value2;
				newUV[num11] = value7;
			}
			if (hasSkin)
			{
				newSkin[num7] = boneWeight;
				newSkin[num8] = boneWeight2;
				newSkin[num9] = boneWeight3;
				newSkin[num10] = value4;
				newSkin[num11] = value9;
			}
			fixedOffset += 5;
			if (distanceToPoint < 0f)
			{
				newIndices[fixedTriOffset] = num10;
				newIndices[fixedTriOffset + 1] = num7;
				newIndices[fixedTriOffset + 2] = num8;
				newIndices[fixedTriOffset + 3] = num10;
				newIndices[fixedTriOffset + 4] = num8;
				newIndices[fixedTriOffset + 5] = num11;
				fixedTriOffset += 6;
			}
			if (distanceToPoint > 0f)
			{
				newIndices[fixedTriOffset] = num9;
				newIndices[fixedTriOffset + 1] = num10;
				newIndices[fixedTriOffset + 2] = num11;
				fixedTriOffset += 3;
			}
		}
		else if (num == num3)
		{
			float3 float26 = float5;
			float3 float27 = math.normalize(float6 - float5);
			PlaneRaycast(planeN, planeD, float26, float27, out var enter2);
			float3 float22 = float26 + float27 * enter2;
			float num12 = math.saturate(enter2 / math.length(float6 - float5));
			float22 = math.lerp(float5, float6, num12);
			float3 value11 = math.lerp(float8, float9, num12);
			float2 value12 = math.lerp(float11, float12, num12);
			float2 value13 = math.lerp(float14, float15, num12);
			BoneWeight value14 = tmpWeight;
			if (hasSkin)
			{
				value14 = LerpBoneWeights(boneWeight, boneWeight2, num12);
			}
			float4 value15 = math.lerp(float17, float18, num12);
			float3 float28 = float6;
			float3 float29 = math.normalize(float7 - float6);
			PlaneRaycast(planeN, planeD, float28, float29, out enter2);
			float3 float25 = float28 + float29 * enter2;
			float num13 = math.saturate(enter2 / math.length(float7 - float6));
			float25 = math.lerp(float6, float7, num13);
			float3 value16 = math.lerp(float9, float10, num13);
			float2 value17 = math.lerp(float12, float13, num13);
			float2 value18 = math.lerp(float15, float16, num13);
			BoneWeight value19 = tmpWeight;
			if (hasSkin)
			{
				value19 = LerpBoneWeights(boneWeight2, boneWeight3, num13);
			}
			float4 value20 = math.lerp(float18, float19, num13);
			int num7 = fixedOffset;
			int num8 = fixedOffset + 1;
			int num9 = fixedOffset + 2;
			int num10 = fixedOffset + 3;
			int num11 = fixedOffset + 4;
			newPos[num7] = float5;
			newPos[num8] = float6;
			newPos[num9] = float7;
			newPos[num10] = float22;
			newPos[num11] = float25;
			newNormal[num7] = float8;
			newNormal[num8] = float9;
			newNormal[num9] = float10;
			newNormal[num10] = value11;
			newNormal[num11] = value16;
			newUV2[num7] = float14;
			newUV2[num8] = float15;
			newUV2[num9] = float16;
			newUV2[num10] = value13;
			newUV2[num11] = value18;
			if (useVColor)
			{
				newColor[num7] = float17;
				newColor[num8] = float18;
				newColor[num9] = float19;
				newColor[num10] = value15;
				newColor[num11] = value20;
			}
			if (useUV)
			{
				newUV[num7] = float11;
				newUV[num8] = float12;
				newUV[num9] = float13;
				newUV[num10] = value12;
				newUV[num11] = value17;
			}
			if (hasSkin)
			{
				newSkin[num7] = boneWeight;
				newSkin[num8] = boneWeight2;
				newSkin[num9] = boneWeight3;
				newSkin[num10] = value14;
				newSkin[num11] = value19;
			}
			fixedOffset += 5;
			if (distanceToPoint < 0f)
			{
				newIndices[fixedTriOffset] = num7;
				newIndices[fixedTriOffset + 1] = num10;
				newIndices[fixedTriOffset + 2] = num9;
				newIndices[fixedTriOffset + 3] = num10;
				newIndices[fixedTriOffset + 4] = num11;
				newIndices[fixedTriOffset + 5] = num9;
				fixedTriOffset += 6;
			}
			if (distanceToPoint > 0f)
			{
				newIndices[fixedTriOffset] = num8;
				newIndices[fixedTriOffset + 1] = num11;
				newIndices[fixedTriOffset + 2] = num10;
				fixedTriOffset += 3;
			}
		}
		else if (num2 == num3)
		{
			float3 float30 = float5;
			float3 float31 = math.normalize(float7 - float5);
			PlaneRaycast(planeN, planeD, float30, float31, out var enter3);
			float3 float22 = float30 + float31 * enter3;
			float num14 = math.saturate(enter3 / math.length(float7 - float5));
			float22 = math.lerp(float5, float7, num14);
			float3 value21 = math.lerp(float8, float10, num14);
			float2 value22 = math.lerp(float11, float13, num14);
			float2 value23 = math.lerp(float14, float16, num14);
			BoneWeight value24 = tmpWeight;
			if (hasSkin)
			{
				value24 = LerpBoneWeights(boneWeight, boneWeight3, num14);
			}
			float4 value25 = math.lerp(float17, float19, num14);
			float3 float32 = float6;
			float3 float33 = math.normalize(float5 - float6);
			PlaneRaycast(planeN, planeD, float32, float33, out enter3);
			float3 float25 = float32 + float33 * enter3;
			float num15 = math.saturate(enter3 / math.length(float5 - float6));
			float25 = math.lerp(float6, float5, num15);
			float3 value26 = math.lerp(float9, float8, num15);
			float2 value27 = math.lerp(float12, float11, num15);
			float2 value28 = math.lerp(float15, float14, num15);
			BoneWeight value29 = tmpWeight;
			if (hasSkin)
			{
				value29 = LerpBoneWeights(boneWeight2, boneWeight, num15);
			}
			float4 value30 = math.lerp(float18, float19, num15);
			int num7 = fixedOffset;
			int num8 = fixedOffset + 1;
			int num9 = fixedOffset + 2;
			int num10 = fixedOffset + 3;
			int num11 = fixedOffset + 4;
			newPos[num7] = float5;
			newPos[num8] = float6;
			newPos[num9] = float7;
			newPos[num10] = float22;
			newPos[num11] = float25;
			newNormal[num7] = float8;
			newNormal[num8] = float9;
			newNormal[num9] = float10;
			newNormal[num10] = value21;
			newNormal[num11] = value26;
			newUV2[num7] = float14;
			newUV2[num8] = float15;
			newUV2[num9] = float16;
			newUV2[num10] = value23;
			newUV2[num11] = value28;
			if (useVColor)
			{
				newColor[num7] = float17;
				newColor[num8] = float18;
				newColor[num9] = float19;
				newColor[num10] = value25;
				newColor[num11] = value30;
			}
			if (useUV)
			{
				newUV[num7] = float11;
				newUV[num8] = float12;
				newUV[num9] = float13;
				newUV[num10] = value22;
				newUV[num11] = value27;
			}
			if (hasSkin)
			{
				newSkin[num7] = boneWeight;
				newSkin[num8] = boneWeight2;
				newSkin[num9] = boneWeight3;
				newSkin[num10] = value24;
				newSkin[num11] = value29;
			}
			fixedOffset += 5;
			if (distanceToPoint > 0f)
			{
				newIndices[fixedTriOffset] = num8;
				newIndices[fixedTriOffset + 1] = num9;
				newIndices[fixedTriOffset + 2] = num10;
				newIndices[fixedTriOffset + 3] = num8;
				newIndices[fixedTriOffset + 4] = num10;
				newIndices[fixedTriOffset + 5] = num11;
				fixedTriOffset += 6;
			}
			if (distanceToPoint <= 0f)
			{
				newIndices[fixedTriOffset] = num7;
				newIndices[fixedTriOffset + 1] = num11;
				newIndices[fixedTriOffset + 2] = num10;
				fixedTriOffset += 3;
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static void AddTriangle(ref int fixedOffset, NativeArray<float3> vPos, NativeArray<float3> vNormal, bool hasVColor, NativeArray<float4> vColor, NativeArray<float2> vUV2, bool hasVUV, NativeArray<float2> vUV, bool hasVSkin, NativeArray<BoneWeight> vSkin, NativeArray<byte> vDecalID, float3 Ap, float3 An, float4 Ac, float2 At2, float2 At, BoneWeight Ab, float3 Bp, float3 Bn, float4 Bc, float2 Bt2, float2 Bt, BoneWeight Bb, float3 Cp, float3 Cn, float4 Cc, float2 Ct2, float2 Ct, BoneWeight Cb, byte decalID)
	{
		int index = fixedOffset;
		int index2 = fixedOffset + 1;
		int index3 = fixedOffset + 2;
		vPos[index] = Ap;
		vPos[index2] = Bp;
		vPos[index3] = Cp;
		vNormal[index] = An;
		vNormal[index2] = Bn;
		vNormal[index3] = Cn;
		if (hasVColor)
		{
			vColor[index] = Ac;
			vColor[index2] = Bc;
			vColor[index3] = Cc;
		}
		vUV2[index] = At2;
		vUV2[index2] = Bt2;
		vUV2[index3] = Ct2;
		if (hasVUV)
		{
			vUV[index] = At;
			vUV[index2] = Bt;
			vUV[index3] = Ct;
		}
		if (hasVSkin)
		{
			vSkin[index] = Ab;
			vSkin[index2] = Bb;
			vSkin[index3] = Cb;
		}
		byte b = (vDecalID[index3] = decalID);
		byte value = (vDecalID[index2] = b);
		vDecalID[index] = value;
		fixedOffset += 3;
	}

	private static void SplitTriangle2(NativeArray<float3> triPos, NativeArray<float3> triNormal, NativeArray<float2> triUV, NativeArray<float4> triColor, NativeArray<float2> triUV2, NativeArray<BoneWeight> triSkin, float3 planeN, float planeD, byte decalID, ref int fixedOffset, NativeArray<float3> vPos, NativeArray<float3> vNormal, NativeArray<float2> vUV, NativeArray<float4> vColor, NativeArray<float2> vUV2, NativeArray<BoneWeight> vSkin, NativeArray<byte> vDecalID, bool useVColor, bool useUV, bool hasSkin, BoneWeight tmpWeight)
	{
		int length = vPos.Length;
		float3 float5 = triPos[0];
		float3 float6 = triPos[1];
		float3 float7 = triPos[2];
		float3 float8 = triNormal[0];
		float3 float9 = triNormal[1];
		float3 float10 = triNormal[2];
		float2 float11 = triUV[0];
		float2 float12 = triUV[1];
		float2 float13 = triUV[2];
		float2 float14 = triUV2[0];
		float2 float15 = triUV2[1];
		float2 float16 = triUV2[2];
		BoneWeight boneWeight = tmpWeight;
		BoneWeight boneWeight2 = tmpWeight;
		BoneWeight boneWeight3 = tmpWeight;
		if (hasSkin)
		{
			boneWeight = triSkin[0];
			boneWeight2 = triSkin[1];
			boneWeight3 = triSkin[2];
		}
		float4 float17 = triColor[0];
		float4 float18 = triColor[1];
		float4 float19 = triColor[2];
		float distanceToPoint = GetDistanceToPoint(planeN, planeD, float5);
		float distanceToPoint2 = GetDistanceToPoint(planeN, planeD, float6);
		float distanceToPoint3 = GetDistanceToPoint(planeN, planeD, float7);
		float num = math.sign(distanceToPoint);
		float num2 = math.sign(distanceToPoint2);
		float num3 = math.sign(distanceToPoint3);
		bool num4 = num == num2 && num2 == num3;
		bool flag = num2 == num3 && distanceToPoint == 0f;
		bool flag2 = num2 == num && distanceToPoint3 == 0f;
		bool flag3 = num == num3 && distanceToPoint2 == 0f;
		if (num4 | flag | flag2 | flag3)
		{
			if (distanceToPoint <= 0f)
			{
				if (fixedOffset + 3 >= length)
				{
					fixedOffset = 0;
				}
				AddTriangle(ref fixedOffset, vPos, vNormal, useVColor, vColor, vUV2, useUV, vUV, hasSkin, vSkin, vDecalID, float5, float8, float17, float14, float11, boneWeight, float6, float9, float18, float15, float12, boneWeight2, float7, float10, float19, float16, float13, boneWeight3, decalID);
			}
		}
		else if (num == num2)
		{
			float3 float20 = float5;
			float3 float21 = math.normalize(float7 - float5);
			PlaneRaycast(planeN, planeD, float20, float21, out var enter);
			float3 float22 = float20 + float21 * enter;
			float num5 = math.saturate(enter / math.length(float7 - float5));
			float22 = math.lerp(float5, float7, num5);
			float3 float23 = math.lerp(float8, float10, num5);
			float2 float24 = math.lerp(float11, float13, num5);
			float2 float25 = math.lerp(float14, float16, num5);
			BoneWeight boneWeight4 = tmpWeight;
			if (hasSkin)
			{
				boneWeight4 = LerpBoneWeights(boneWeight, boneWeight3, num5);
			}
			float4 float26 = math.lerp(float17, float19, num5);
			float3 float27 = float6;
			float3 float28 = math.normalize(float7 - float6);
			PlaneRaycast(planeN, planeD, float27, float28, out enter);
			float3 float29 = float27 + float28 * enter;
			float num6 = math.saturate(enter / math.length(float7 - float6));
			float29 = math.lerp(float6, float7, num6);
			float3 cn = math.lerp(float9, float10, num6);
			float2 ct = math.lerp(float12, float13, num6);
			float2 ct2 = math.lerp(float15, float16, num6);
			BoneWeight cb = tmpWeight;
			if (hasSkin)
			{
				cb = LerpBoneWeights(boneWeight2, boneWeight3, num6);
			}
			float4 cc = math.lerp(float18, float19, num6);
			if (fixedOffset + 9 >= length)
			{
				fixedOffset = 0;
			}
			if (distanceToPoint < 0f)
			{
				AddTriangle(ref fixedOffset, vPos, vNormal, useVColor, vColor, vUV2, useUV, vUV, hasSkin, vSkin, vDecalID, float22, float23, float26, float25, float24, boneWeight4, float5, float8, float17, float14, float11, boneWeight, float6, float9, float18, float15, float12, boneWeight2, decalID);
				AddTriangle(ref fixedOffset, vPos, vNormal, useVColor, vColor, vUV2, useUV, vUV, hasSkin, vSkin, vDecalID, float22, float23, float26, float25, float24, boneWeight4, float6, float9, float18, float15, float12, boneWeight2, float29, cn, cc, ct2, ct, cb, decalID);
			}
			if (distanceToPoint >= 0f)
			{
				AddTriangle(ref fixedOffset, vPos, vNormal, useVColor, vColor, vUV2, useUV, vUV, hasSkin, vSkin, vDecalID, float7, float10, float19, float16, float13, boneWeight3, float22, float23, float26, float25, float24, boneWeight4, float29, cn, cc, ct2, ct, cb, decalID);
			}
		}
		else if (num == num3)
		{
			float3 float30 = float5;
			float3 float31 = math.normalize(float6 - float5);
			PlaneRaycast(planeN, planeD, float30, float31, out var enter2);
			float3 float22 = float30 + float31 * enter2;
			float num7 = math.saturate(enter2 / math.length(float6 - float5));
			float22 = math.lerp(float5, float6, num7);
			float3 float32 = math.lerp(float8, float9, num7);
			float2 float33 = math.lerp(float11, float12, num7);
			float2 float34 = math.lerp(float14, float15, num7);
			BoneWeight boneWeight5 = tmpWeight;
			if (hasSkin)
			{
				boneWeight5 = LerpBoneWeights(boneWeight, boneWeight2, num7);
			}
			float4 float35 = math.lerp(float17, float18, num7);
			float3 float36 = float6;
			float3 float37 = math.normalize(float7 - float6);
			PlaneRaycast(planeN, planeD, float36, float37, out enter2);
			float3 float29 = float36 + float37 * enter2;
			float num8 = math.saturate(enter2 / math.length(float7 - float6));
			float29 = math.lerp(float6, float7, num8);
			float3 bn = math.lerp(float9, float10, num8);
			float2 bt = math.lerp(float12, float13, num8);
			float2 bt2 = math.lerp(float15, float16, num8);
			BoneWeight bb = tmpWeight;
			if (hasSkin)
			{
				bb = LerpBoneWeights(boneWeight2, boneWeight3, num8);
			}
			float4 bc = math.lerp(float18, float19, num8);
			if (fixedOffset + 9 >= length)
			{
				fixedOffset = 0;
			}
			if (distanceToPoint < 0f)
			{
				AddTriangle(ref fixedOffset, vPos, vNormal, useVColor, vColor, vUV2, useUV, vUV, hasSkin, vSkin, vDecalID, float5, float8, float17, float14, float11, boneWeight, float22, float32, float35, float34, float33, boneWeight5, float7, float10, float19, float16, float13, boneWeight3, decalID);
				AddTriangle(ref fixedOffset, vPos, vNormal, useVColor, vColor, vUV2, useUV, vUV, hasSkin, vSkin, vDecalID, float22, float32, float35, float34, float33, boneWeight5, float29, bn, bc, bt2, bt, bb, float7, float10, float19, float16, float13, boneWeight3, decalID);
			}
			if (distanceToPoint >= 0f)
			{
				AddTriangle(ref fixedOffset, vPos, vNormal, useVColor, vColor, vUV2, useUV, vUV, hasSkin, vSkin, vDecalID, float6, float9, float18, float15, float12, boneWeight2, float29, bn, bc, bt2, bt, bb, float22, float32, float35, float34, float33, boneWeight5, decalID);
			}
		}
		else if (num2 == num3)
		{
			float3 float38 = float5;
			float3 float39 = math.normalize(float7 - float5);
			PlaneRaycast(planeN, planeD, float38, float39, out var enter3);
			float3 float22 = float38 + float39 * enter3;
			float num9 = math.saturate(enter3 / math.length(float7 - float5));
			float22 = math.lerp(float5, float7, num9);
			float3 float40 = math.lerp(float8, float10, num9);
			float2 float41 = math.lerp(float11, float13, num9);
			float2 float42 = math.lerp(float14, float16, num9);
			BoneWeight boneWeight6 = tmpWeight;
			if (hasSkin)
			{
				boneWeight6 = LerpBoneWeights(boneWeight, boneWeight3, num9);
			}
			float4 float43 = math.lerp(float17, float19, num9);
			float3 float44 = float6;
			float3 float45 = math.normalize(float5 - float6);
			PlaneRaycast(planeN, planeD, float44, float45, out enter3);
			float3 float29 = float44 + float45 * enter3;
			float num10 = math.saturate(enter3 / math.length(float5 - float6));
			float29 = math.lerp(float6, float5, num10);
			float3 float46 = math.lerp(float9, float8, num10);
			float2 float47 = math.lerp(float12, float11, num10);
			float2 float48 = math.lerp(float15, float14, num10);
			BoneWeight boneWeight7 = tmpWeight;
			if (hasSkin)
			{
				boneWeight7 = LerpBoneWeights(boneWeight2, boneWeight, num10);
			}
			float4 float49 = math.lerp(float18, float19, num10);
			if (fixedOffset + 9 >= length)
			{
				fixedOffset = 0;
			}
			if (distanceToPoint > 0f)
			{
				AddTriangle(ref fixedOffset, vPos, vNormal, useVColor, vColor, vUV2, useUV, vUV, hasSkin, vSkin, vDecalID, float6, float9, float18, float15, float12, boneWeight2, float7, float10, float19, float16, float13, boneWeight3, float22, float40, float43, float42, float41, boneWeight6, decalID);
				AddTriangle(ref fixedOffset, vPos, vNormal, useVColor, vColor, vUV2, useUV, vUV, hasSkin, vSkin, vDecalID, float6, float9, float18, float15, float12, boneWeight2, float22, float40, float43, float42, float41, boneWeight6, float29, float46, float49, float48, float47, boneWeight7, decalID);
			}
			if (distanceToPoint <= 0f)
			{
				AddTriangle(ref fixedOffset, vPos, vNormal, useVColor, vColor, vUV2, useUV, vUV, hasSkin, vSkin, vDecalID, float5, float8, float17, float14, float11, boneWeight, float29, float46, float49, float48, float47, boneWeight7, float22, float40, float43, float42, float41, boneWeight6, decalID);
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
		obj2.nvPos = new NativeArray<Vector3>(desc.maxTrisTotal * 3, Allocator.Persistent);
		obj2.nvNormal = new NativeArray<Vector3>(desc.maxTrisTotal * 3, Allocator.Persistent);
		obj2.nvColor = new NativeArray<Color>(desc.maxTrisTotal * 3, Allocator.Persistent);
		obj2.nvUV2 = new NativeArray<Vector2>(desc.maxTrisTotal * 3, Allocator.Persistent);
		obj2.nvUV = new NativeArray<Vector2>(desc.maxTrisTotal * 3, Allocator.Persistent);
		obj2.nvDecalID = new NativeArray<byte>(desc.maxTrisTotal * 3, Allocator.Persistent);
		if (flag)
		{
			obj2.nvSkin = new NativeArray<BoneWeight>(desc.maxTrisTotal * 3, Allocator.Persistent);
		}
		if (desc.tangents)
		{
			obj2.nvTangents = new NativeArray<Vector4>(desc.maxTrisTotal * 3, Allocator.Persistent);
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
		UpdateDecalFor(_transformUV1: group.lightmapID >= 0, decal: decalGroup, sharedMaterial: group.material, _decalUV: array2, _decalPosW: array, decalTform: null, _decalTris: array3, _decalColor: null, parentObject: receiver.gameObject, optionalMateralChange: null, _opacity: desc.opacity, _fixedOffset: ref group.fixedOffset, _decalID: (byte)(group.numDecals % 255 + 1), newMesh: group.mesh, groupData: group, _maxTrisInDecal: group.maxTrisInDecal, _transformToParent: transformToParent, _earlyCull: earlyCull);
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
