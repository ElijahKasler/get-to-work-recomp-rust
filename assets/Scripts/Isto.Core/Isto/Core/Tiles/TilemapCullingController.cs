using System.Collections.Generic;
using Isto.Core.Automation;
using UnityEngine;
using Zenject;

namespace Isto.Core.Tiles;

public class TilemapCullingController : MonoBehaviour
{
	public float _cullingSphereRadiusPadding = 30f;

	[Header("Default Tile Setup")]
	public List<DefaultTileSetup> defaultTileSetups;

	private TilemapCullingSettings _tilemapSettings;

	private Dictionary<int, List<GameObject>> _tilemapLookup = new Dictionary<int, List<GameObject>>();

	private Vector3 _cornerToCenterOffset;

	[SerializeField]
	private Color _cullingSphereColor = Color.white;

	[SerializeField]
	private Color _tileAreaColor = Color.white;

	private CullingGroup _cullingGroup;

	private BoundingSphere[] _spheres;

	[Inject]
	public void Inject(TilemapCullingSettings groundMap)
	{
		_tilemapSettings = groundMap;
	}

	private void OnEnable()
	{
		if (_tilemapSettings == null)
		{
			base.enabled = false;
			return;
		}
		_cornerToCenterOffset = (Vector3.right + Vector3.forward) * Mathf.CeilToInt((float)_tilemapSettings.sliceSize / 2f);
		SetupCullingBounds(_tilemapSettings);
	}

	private void OnDestroy()
	{
		if (_cullingGroup != null)
		{
			_cullingGroup.Dispose();
		}
	}

	private void SetupCullingBounds(TilemapCullingSettings groundTileMap)
	{
		int num = Mathf.CeilToInt((float)_tilemapSettings.tileMapLargestSide / (float)_tilemapSettings.sliceSize);
		float cullingSphereRadius = GetCullingSphereRadius(_tilemapSettings);
		HashSet<int> hashSet = new HashSet<int>();
		_cullingGroup = new CullingGroup();
		_cullingGroup.targetCamera = Camera.main;
		_spheres = new BoundingSphere[num * num];
		int num2 = -1;
		for (int i = 0; i < _tilemapSettings.tilemapPrefabs.Count; i++)
		{
			TilemapPrefabSetup tilemapPrefabSetup = _tilemapSettings.tilemapPrefabs[i];
			Vector3 vector = tilemapPrefabSetup.tilemapCornerPosition + _cornerToCenterOffset;
			int item = AutomationGrid.HashCoordinate(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.z));
			if (!hashSet.Contains(item))
			{
				if (num2 >= _spheres.Length)
				{
					Debug.LogError($"Past Size of Sphere Array. Center:{vector}, Corner:{tilemapPrefabSetup.tilemapCornerPosition}, AlreadySeenCount:{hashSet.Count}");
				}
				num2++;
				_spheres[num2] = new BoundingSphere(vector, cullingSphereRadius);
				_tilemapLookup[num2] = new List<GameObject>();
				hashSet.Add(item);
			}
		}
		_cullingGroup.SetBoundingSpheres(_spheres);
		_cullingGroup.SetBoundingSphereCount(num2 + 1);
		_cullingGroup.onStateChanged = CullingGroupStateChanged;
	}

	private float GetCullingSphereRadius(TilemapCullingSettings groundTileMap)
	{
		return (float)(_tilemapSettings.sliceSize / 2) + _cullingSphereRadiusPadding;
	}

	private void CullingGroupStateChanged(CullingGroupEvent evt)
	{
		if (evt.hasBecomeInvisible)
		{
			if (_tilemapLookup.ContainsKey(evt.index))
			{
				for (int i = 0; i < _tilemapLookup[evt.index].Count; i++)
				{
					_tilemapLookup[evt.index][i].SetActive(value: false);
				}
			}
		}
		else
		{
			if (!evt.hasBecomeVisible || !_tilemapLookup.ContainsKey(evt.index))
			{
				return;
			}
			if (_tilemapLookup[evt.index].Count > 0)
			{
				for (int j = 0; j < _tilemapLookup[evt.index].Count; j++)
				{
					_tilemapLookup[evt.index][j].SetActive(value: true);
				}
			}
			else
			{
				_tilemapLookup[evt.index] = SpawnTilemapsForArea(_spheres[evt.index].position, evt.index);
			}
		}
	}

	private List<GameObject> SpawnTilemapsForArea(Vector3 position, int index)
	{
		List<GameObject> list = new List<GameObject>();
		Vector3 b = position - _cornerToCenterOffset;
		for (int i = 0; i < _tilemapSettings.tilemapPrefabs.Count; i++)
		{
			if (Mathf.Abs(Vector3.Distance(_tilemapSettings.tilemapPrefabs[i].tilemapCornerPosition, b)) < 2f)
			{
				GameObject item = Object.Instantiate(_tilemapSettings.tilemapPrefabs[i].prefab, base.transform);
				list.Add(item);
			}
		}
		if (list.Count == 0)
		{
			Debug.LogError($"No tilemaps found for position {position} but it has a bounding sphere setup with index {index}, this shouldn't happen");
		}
		return list;
	}

	public void OnDrawGizmosSelected()
	{
		if (Application.isPlaying && base.enabled)
		{
			for (int i = 0; i < _spheres.Length; i++)
			{
				if (_spheres[i].radius != 0f)
				{
					Gizmos.color = _cullingSphereColor;
					Gizmos.DrawSphere(_spheres[i].position, GetCullingSphereRadius(_tilemapSettings));
				}
			}
			DrawDeafultTileAreas();
			return;
		}
		if (_tilemapSettings != null)
		{
			int num = Mathf.CeilToInt((float)_tilemapSettings.tileMapLargestSide / (float)_tilemapSettings.sliceSize);
			int sliceSize = _tilemapSettings.sliceSize;
			int num2 = _tilemapSettings.sliceSize / 2;
			float cullingSphereRadius = GetCullingSphereRadius(_tilemapSettings);
			Vector3 size = new Vector3(sliceSize, 1f, sliceSize);
			for (int j = 0; j < num; j++)
			{
				for (int k = 0; k < num; k++)
				{
					Vector3Int vector3Int = new Vector3Int(_tilemapSettings.bottomCornerPosition.x + j * sliceSize, 0, _tilemapSettings.bottomCornerPosition.z + k * sliceSize) + Vector3Int.forward * num2 + Vector3Int.right * num2;
					Gizmos.color = _cullingSphereColor;
					Gizmos.DrawWireSphere(vector3Int, cullingSphereRadius);
					Gizmos.color = _tileAreaColor;
					Gizmos.DrawWireCube(vector3Int, size);
				}
			}
		}
		DrawDeafultTileAreas();
	}

	private void DrawDeafultTileAreas()
	{
		if (defaultTileSetups == null)
		{
			return;
		}
		for (int i = 0; i < defaultTileSetups.Count; i++)
		{
			DefaultTileSetup defaultTileSetup = defaultTileSetups[i];
			if (defaultTileSetup != null && defaultTileSetup.defaultTile != null)
			{
				UnityUtils.DrawBox(defaultTileSetup.bounds, defaultTileSetup.gizmoColor, defaultTileSetup.gizmoColor, defaultTileSetup.gizmoColor, defaultTileSetup.defaultTile.name);
			}
		}
	}
}
