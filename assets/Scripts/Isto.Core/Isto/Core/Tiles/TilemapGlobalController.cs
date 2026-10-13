using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Isto.Core.Tiles;

public class TilemapGlobalController : MonoBehaviour
{
	private List<TilemapCullingSettings> _loadedSettings = new List<TilemapCullingSettings>();

	private Tilemap[] _maps;

	private bool _settingsValidated;

	public Environment.GroundType GetGroundTypeForPosition(Vector3 position)
	{
		if (_loadedSettings.Count > 0)
		{
			if (!_settingsValidated)
			{
				for (int i = 0; i < _loadedSettings.Count; i++)
				{
					if (_loadedSettings[i].tiles.Count == 0)
					{
						Debug.LogError("Tilemaps for scene " + base.gameObject.scene.name + " with settings " + _loadedSettings[i].name + " has not had ground types baked yet.  Will not work properly!");
					}
				}
				_settingsValidated = true;
			}
			for (int j = 0; j < _loadedSettings.Count; j++)
			{
				Environment.GroundType groundForWorldPosition = _loadedSettings[j].GetGroundForWorldPosition(position);
				if (groundForWorldPosition != Environment.GroundType.NotSet)
				{
					return groundForWorldPosition;
				}
			}
			return Environment.GroundType.NotSet;
		}
		if (_maps == null)
		{
			_maps = TilemapUtils.GetAllTilemapsInSceneDecendingSortOrder().ToArray();
		}
		return TilemapUtils.GetGroundTypeForPosition(position, _maps);
	}

	public bool IsTileNavigatable(Vector3 position)
	{
		if (_loadedSettings.Count > 0)
		{
			if (!_settingsValidated)
			{
				for (int i = 0; i < _loadedSettings.Count; i++)
				{
					if (_loadedSettings[i].tiles.Count == 0)
					{
						Debug.LogError("Tilemaps for scene " + base.gameObject.scene.name + " with settings " + _loadedSettings[i].name + " has not had ground types baked yet.  Will not work properly!");
					}
				}
				_settingsValidated = true;
			}
			for (int j = 0; j < _loadedSettings.Count; j++)
			{
				if (!_loadedSettings[j].IsPositionNavigatable(position))
				{
					return false;
				}
			}
			return true;
		}
		return true;
	}

	public void AddTilemapSettings(TilemapCullingSettings settings)
	{
		if (settings != null && !_loadedSettings.Contains(settings))
		{
			_loadedSettings.Add(settings);
		}
	}
}
