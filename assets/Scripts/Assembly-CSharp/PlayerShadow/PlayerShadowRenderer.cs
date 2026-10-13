using Isto.GTW.Player;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

namespace PlayerShadow;

[ExecuteAlways]
public class PlayerShadowRenderer : MonoBehaviour
{
	public static PlayerShadowRenderer Instance;

	[SerializeField]
	private PlayerController playerController;

	[SerializeField]
	private Camera targetCamera;

	[SerializeField]
	private int resolution = 1024;

	[SerializeField]
	private Vector3 frustumSize = new Vector3(10f, 10f, 10f);

	[SerializeField]
	private float ZOffset = 0.1f;

	[SerializeField]
	private RenderTexture target;

	private Shader depthShader;

	private Material depthMaterial;

	private void OnEnable()
	{
		Instance = this;
		DisposeIfNeeded();
		Initialize();
	}

	private void OnDisable()
	{
		DisposeIfNeeded();
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void Initialize()
	{
		target = new RenderTexture(resolution, resolution, 24, GraphicsFormat.R8_UNorm);
		target.useMipMap = true;
		target.autoGenerateMips = false;
		target.filterMode = FilterMode.Bilinear;
		target.wrapMode = TextureWrapMode.Clamp;
		target.Create();
		depthShader = Shader.Find("Hidden/PlayerShadow");
		if (depthShader == null)
		{
			Debug.LogError("Failed to load depth shader");
		}
		else
		{
			depthMaterial = new Material(depthShader);
		}
	}

	private void LateUpdate()
	{
		Vector3 playerPosition = GetPlayerPosition();
		playerPosition.y += frustumSize.z * 0.5f - ZOffset;
		base.transform.position = playerPosition;
		base.transform.rotation = Quaternion.LookRotation(Vector3.down, Vector3.right);
		targetCamera.targetTexture = target;
		targetCamera.orthographicSize = frustumSize.x * 0.5f;
		targetCamera.nearClipPlane = 0.0001f;
		targetCamera.farClipPlane = frustumSize.z;
		targetCamera.aspect = frustumSize.x / frustumSize.z;
		CommandBuffer commandBuffer = CommandBufferPool.Get("PlayerShadowRenderer");
		UpdateGlobals(commandBuffer);
		Graphics.ExecuteCommandBuffer(commandBuffer);
		CommandBufferPool.Release(commandBuffer);
	}

	private Vector3 GetPlayerPosition()
	{
		if (!Application.isPlaying)
		{
			return playerController.transform.position;
		}
		if (playerController.IsMoveState)
		{
			return playerController.PlayerPosition;
		}
		return playerController.PlayerModelController.PlayerIkController.PelvisBone.position;
	}

	private void UpdateGlobals(CommandBuffer cmd)
	{
		Matrix4x4 frustumTRS = GetFrustumTRS();
		cmd.SetGlobalMatrix(Shader.PropertyToID("_PlayerShadowTRS"), frustumTRS);
		cmd.SetGlobalMatrix(Shader.PropertyToID("_PlayerShadowInvTRS"), frustumTRS.inverse);
		cmd.SetGlobalTexture(Shader.PropertyToID("_PlayerShadowTexture"), target);
	}

	private void DisposeIfNeeded()
	{
		if (target != null)
		{
			target.Release();
			target = null;
		}
		if (depthMaterial != null)
		{
			Object.DestroyImmediate(depthMaterial);
			depthMaterial = null;
		}
	}

	private Matrix4x4 GetFrustumTRS()
	{
		return Matrix4x4.TRS(base.transform.position + Vector3.down * frustumSize.z * 0.5f, Quaternion.LookRotation(Vector3.down, Vector3.right), frustumSize);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.green;
		Gizmos.matrix = GetFrustumTRS();
		Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
	}
}
