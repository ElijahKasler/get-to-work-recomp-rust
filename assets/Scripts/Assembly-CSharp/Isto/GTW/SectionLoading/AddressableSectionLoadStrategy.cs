using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Isto.GTW.SectionLoading;

public class AddressableSectionLoadStrategy : ISectionLoadStrategy
{
	private readonly string _sceneName;

	private readonly bool _showDebug;

	private AsyncOperationHandle<SceneInstance>? _loadHandle;

	private AsyncOperationHandle<SceneInstance>? _unloadHandle;

	public bool IsLoaded { get; private set; }

	public bool IsLoading
	{
		get
		{
			if (_loadHandle.HasValue)
			{
				return !_loadHandle.Value.IsDone;
			}
			return false;
		}
	}

	public bool IsUnloading
	{
		get
		{
			if (_unloadHandle.HasValue)
			{
				return !_unloadHandle.Value.IsDone;
			}
			return false;
		}
	}

	public float Progress
	{
		get
		{
			if (IsLoading)
			{
				return _loadHandle.Value.PercentComplete;
			}
			if (IsUnloading)
			{
				return _unloadHandle.Value.PercentComplete;
			}
			return 1f;
		}
	}

	public AddressableSectionLoadStrategy(string sceneName, bool showDebug)
	{
		_sceneName = sceneName;
		_showDebug = showDebug;
	}

	public void StartLoading()
	{
		if (IsLoading || IsLoaded)
		{
			return;
		}
		if (_showDebug)
		{
			Debug.Log("[Addressables] Loading Section: " + _sceneName);
		}
		_loadHandle = Addressables.LoadSceneAsync(_sceneName, LoadSceneMode.Additive);
		AsyncOperationHandle<SceneInstance> value = _loadHandle.Value;
		value.Completed += (AsyncOperationHandle<SceneInstance> handle) =>
		{
			if (handle.Status == AsyncOperationStatus.Succeeded)
			{
				IsLoaded = true;
				if (_showDebug)
				{
					Debug.Log("[Addressables] Scene loaded successfully: " + _sceneName);
				}
			}
			else
			{
				Debug.LogError("[Addressables] Failed to load scene: " + _sceneName);
			}
		};
	}

	public void StartUnloading()
	{
		if (IsUnloading || !IsLoaded)
		{
			return;
		}
		if (_showDebug)
		{
			Debug.Log("[Load Strategy: Addressables] Unloading Section: " + _sceneName);
		}
		if (_loadHandle.HasValue)
		{
			_unloadHandle = Addressables.UnloadSceneAsync(_loadHandle.Value);
			AsyncOperationHandle<SceneInstance> value = _unloadHandle.Value;
			value.Completed += (AsyncOperationHandle<SceneInstance> handle) =>
			{
				if (handle.Status == AsyncOperationStatus.Succeeded)
				{
					IsLoaded = false;
					if (_showDebug)
					{
						Debug.Log("[Load Strategy: Addressables] Scene unloaded successfully: " + _sceneName);
					}
				}
				else
				{
					Debug.LogError("[Load Strategy: Addressables] Failed to unload scene: " + _sceneName);
				}
			};
		}
		else
		{
			Debug.LogError("[Load Strategy: Addressables] No valid load handle to unload: " + _sceneName);
		}
	}
}
