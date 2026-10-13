using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Isto.Core.Cameras;

[RequireComponent(typeof(Camera))]
public class SampleBrightness : MonoBehaviour
{
	[Tooltip("The number of times the RenderTexture will be sampled to calculate the brightness level.")]
	public int sampleSize = 16;

	[Tooltip("Factor that is used to smooth light sampling over several frames.  Higher values mean less smoothing")]
	public float sensitivity = 1f;

	protected Queue<AsyncGPUReadbackRequest> _requests = new Queue<AsyncGPUReadbackRequest>();

	protected RenderTexture _camRenderTexture;

	public float Level { get; private set; }

	private void Awake()
	{
		Camera component = GetComponent<Camera>();
		if (component.targetTexture == null)
		{
			_camRenderTexture = new RenderTexture(32, 32, 1, RenderTextureFormat.ARGB32);
			component.targetTexture = _camRenderTexture;
		}
		Level = 0.5f;
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
				NativeArray<Color32> data = asyncGPUReadbackRequest.GetData<Color32>();
				float num = CalculateBrightness(data, sampleSize);
				float num2 = ((Level > num) ? sensitivity : (sensitivity * 5f));
				Level = Mathf.MoveTowards(Level, num, num2 * Time.deltaTime);
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
}
