using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DecalGlobalRuntimeSettings : MonoBehaviour
{
	public enum Mode
	{
		CPU = 0,
		CPUBurst = 1,
		GPUWithReadback = 2,
		FullGPU = 3
	}

	public enum FullGPUShaderPass
	{
		ForwardBase = 0,
		Deferred = 1
	}

	public Mode mode;

	public FullGPUShaderPass shaderPass;

	public bool renderFullGPUModeWithBuiltInRenderPipeline;

	private Vector3[] positions;

	private SphericalHarmonicsL2[] shs;

	private Vector4[] occlusions;

	private Camera cam;

	private bool deferred;

	private int pass;

	private void Awake()
	{
		DecalManager.Cleanup();
		deferred = shaderPass == FullGPUShaderPass.Deferred;
		pass = (deferred ? 2 : 0);
		if (mode == Mode.CPU)
		{
			DecalManager.SetPreferredMode(DecalUtils.Mode.CPU, drawIndirect: false, pass);
			base.enabled = false;
			return;
		}
		if (mode == Mode.CPUBurst)
		{
			DecalManager.SetPreferredMode(DecalUtils.Mode.CPUBurst, drawIndirect: false, pass);
			base.enabled = false;
			return;
		}
		if (mode == Mode.GPUWithReadback)
		{
			DecalManager.SetPreferredMode(DecalUtils.Mode.GPU, drawIndirect: false, pass);
			base.enabled = false;
			return;
		}
		DecalManager.SetPreferredMode(DecalUtils.Mode.GPU, drawIndirect: true, pass);
		if (renderFullGPUModeWithBuiltInRenderPipeline)
		{
			positions = new Vector3[1];
			shs = new SphericalHarmonicsL2[1];
			occlusions = new Vector4[1];
		}
		else
		{
			base.enabled = false;
		}
	}

	private void LateUpdate()
	{
		if (mode != Mode.FullGPU)
		{
			return;
		}
		if (cam == null)
		{
			cam = Camera.current;
		}
		if (cam == null)
		{
			cam = Camera.main;
		}
		if (!(cam != null))
		{
			return;
		}
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
		CameraEvent evt = (deferred ? CameraEvent.AfterGBuffer : CameraEvent.AfterForwardOpaque);
		foreach (DecalSpawner item in DecalSpawner.All)
		{
			foreach (KeyValuePair<int, DecalUtils.Group> staticGroup in item.staticGroups)
			{
				DecalUtils.Group value = staticGroup.Value;
				if (value.drawCmd != null)
				{
					cam.RemoveCommandBuffer(evt, value.drawCmd);
					if (value.numDecals != 0 && value.indirectDraw && GeometryUtility.TestPlanesAABB(planes, value.bounds))
					{
						cam.AddCommandBuffer(evt, value.drawCmd);
					}
				}
			}
			foreach (KeyValuePair<Transform, DecalUtils.Group> movableGroup in item.movableGroups)
			{
				DecalUtils.Group value2 = movableGroup.Value;
				if (value2.drawCmd == null)
				{
					continue;
				}
				cam.RemoveCommandBuffer(evt, value2.drawCmd);
				if (value2.numDecals != 0 && value2.indirectDraw && GeometryUtility.TestPlanesAABB(planes, value2.parent.bounds))
				{
					GPUDecalUtils.UpdateDrawIndirectCommandBuffer(value2, value2.parent.localToWorldMatrix, pass);
					positions[0] = value2.parent.bounds.center;
					if (value2.materialPropertyBlock == null)
					{
						value2.materialPropertyBlock = new MaterialPropertyBlock();
					}
					LightProbes.CalculateInterpolatedLightAndOcclusionProbes(positions, shs, occlusions);
					value2.materialPropertyBlock.CopySHCoefficientArraysFrom(shs);
					value2.materialPropertyBlock.CopyProbeOcclusionArrayFrom(occlusions);
					cam.AddCommandBuffer(evt, value2.drawCmd);
				}
			}
		}
	}
}
