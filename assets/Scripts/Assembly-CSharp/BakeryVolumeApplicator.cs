using UnityEngine;

[ExecuteAlways]
[DefaultExecutionOrder(100)]
public class BakeryVolumeApplicator : MonoBehaviour
{
	public enum Mode
	{
		OnEnable = 0,
		OnUpdate = 1
	}

	[SerializeField]
	public Mode mode;

	[SerializeField]
	public Renderer[] renderers = new Renderer[0];

	[SerializeField]
	public MaterialPropertyBlock[] propertyBlocks = new MaterialPropertyBlock[0];

	private void OnEnable()
	{
		CollectRenderers();
		if (mode == Mode.OnEnable)
		{
			DetectAndPassVolumeData();
		}
	}

	private void LateUpdate()
	{
		if (mode == Mode.OnUpdate)
		{
			DetectAndPassVolumeData();
		}
	}

	private void CollectRenderers()
	{
		renderers = GetComponentsInChildren<Renderer>();
		propertyBlocks = new MaterialPropertyBlock[renderers.Length];
		for (int i = 0; i < propertyBlocks.Length; i++)
		{
			propertyBlocks[i] = new MaterialPropertyBlock();
		}
	}

	private void DetectAndPassVolumeData()
	{
		foreach (BakeryVolume avaibleVolume in BakeryVolumeRegistry.avaibleVolumes)
		{
			Matrix4x4 matrix = avaibleVolume.GetMatrix();
			Vector3 position = base.transform.position;
			Bounds bounds = avaibleVolume.bounds;
			if (!bounds.Contains(position))
			{
				continue;
			}
			Vector3 min = bounds.min;
			Vector3 vector = new Vector3(1f / bounds.size.x, 1f / bounds.size.y, 1f / bounds.size.z);
			for (int i = 0; i < renderers.Length; i++)
			{
				Renderer obj = renderers[i];
				MaterialPropertyBlock materialPropertyBlock = propertyBlocks[i];
				obj.GetPropertyBlock(materialPropertyBlock);
				materialPropertyBlock.SetTexture("_Volume0", avaibleVolume.bakedTexture0);
				materialPropertyBlock.SetTexture("_Volume1", avaibleVolume.bakedTexture1);
				materialPropertyBlock.SetTexture("_Volume2", avaibleVolume.bakedTexture2);
				if (avaibleVolume.bakedTexture3 != null)
				{
					materialPropertyBlock.SetTexture("_Volume3", avaibleVolume.bakedTexture3);
				}
				materialPropertyBlock.SetTexture("_VolumeMask", avaibleVolume.bakedMask);
				materialPropertyBlock.SetVector("_VolumeMin", min);
				materialPropertyBlock.SetVector("_VolumeInvSize", vector);
				materialPropertyBlock.SetVector("_GlobalVolumeMin", min);
				materialPropertyBlock.SetVector("_GlobalVolumeInvSize", vector);
				if (avaibleVolume.supportRotationAfterBake)
				{
					materialPropertyBlock.SetMatrix("_GlobalVolumeMatrix", matrix);
				}
				obj.SetPropertyBlock(materialPropertyBlock);
			}
			break;
		}
	}
}
