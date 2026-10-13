using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Isto.Core.Cameras;

[RequireComponent(typeof(Camera))]
public class ScreenSpaceSampleBrightness : MonoBehaviour
{
	[Tooltip("The number of times the RenderTexture will be sampled to calculate the brightness level.")]
	public int sampleSize = 16;

	protected Queue<AsyncGPUReadbackRequest> _requests = new Queue<AsyncGPUReadbackRequest>();

	protected RenderTexture _camRenderTexture;

	private NativeArray<Color32> _colorBuffer;

	private void Awake()
	{
		Camera component = GetComponent<Camera>();
		if (component.targetTexture == null)
		{
			_camRenderTexture = new RenderTexture(Screen.width, Screen.height, 0, RenderTextureFormat.ARGB32);
			component.targetTexture = _camRenderTexture;
		}
		_colorBuffer = new NativeArray<Color32>(Screen.width * Screen.height * 2, Allocator.Persistent);
	}

	private void Update()
	{
		while (_requests.Count > 0)
		{
			AsyncGPUReadbackRequest asyncGPUReadbackRequest = _requests.Peek();
			if (asyncGPUReadbackRequest.hasError)
			{
				Debug.Log("GPU readback error detected.");
				_requests.Dequeue();
				continue;
			}
			if (asyncGPUReadbackRequest.done)
			{
				asyncGPUReadbackRequest.GetData<Color32>().CopyTo(_colorBuffer);
				_requests.Dequeue();
				continue;
			}
			break;
		}
	}

	private void OnDestroy()
	{
		if (_camRenderTexture != null)
		{
			_camRenderTexture.Release();
		}
		if (_colorBuffer.IsCreated)
		{
			_colorBuffer.Dispose();
		}
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (_requests.Count < 8)
		{
			_requests.Enqueue(AsyncGPUReadback.Request(source));
		}
		Graphics.Blit(source, destination);
	}

	private float CalculateBrightness(NativeArray<Color32> buffer, int sampleCount)
	{
		int num = buffer.Length / sampleCount;
		float num2 = 0f;
		for (int i = 0; i < buffer.Length; i += num)
		{
			num2 += (float)(buffer[i].r + buffer[i].g + buffer[i].b);
		}
		return num2 / (float)(sampleCount * 3 * 256);
	}

	public float LightAtViewPortPosition(Vector2 viewPortPosition)
	{
		if (viewPortPosition.x > 1f || viewPortPosition.y > 1f)
		{
			Vector2 vector = viewPortPosition;
			Debug.LogError("Invalid position passed to screen space check for light. " + vector.ToString());
		}
		int num = (int)(viewPortPosition.x * 2f * (float)_camRenderTexture.width);
		int num2 = (int)(viewPortPosition.y * (float)_camRenderTexture.height * (float)_camRenderTexture.width * 2f);
		int num3 = num + num2;
		float num4 = 0f;
		for (int i = -sampleSize; i < sampleSize; i += 2)
		{
			if (num3 + i < _colorBuffer.Length && num3 + i > 0)
			{
				num4 += (float)(_colorBuffer[num3 + i].r + _colorBuffer[num3 + i].g + _colorBuffer[num3 + i].b);
			}
		}
		return num4 / (768f * (float)sampleSize);
	}

	public float LightAtWorldPosition(Vector3 worldPosition)
	{
		Vector2 viewPortPosition = Camera.main.WorldToViewportPoint(worldPosition);
		if (viewPortPosition.x < 0f || viewPortPosition.x > 1f || viewPortPosition.y < 0f || viewPortPosition.y > 1f)
		{
			return 0f;
		}
		return LightAtViewPortPosition(viewPortPosition);
	}
}
