using System;
using System.Collections.Generic;
using UnityEngine;

namespace Isto.GTW.SectionLoading;

[CreateAssetMenu(fileName = "GTW-LevelSectionData", menuName = "Scriptables/GTW/LevelSectionData")]
public class SectionData : ScriptableObject
{
	[Serializable]
	public struct LevelSectionData
	{
		public string sceneName;

		public string scenePath;

		public Bounds bounds;

		public Bounds[] loadBounds;

		public Bounds[] unloadBounds;

		public Bounds[] ignoreUnloadBounds;

		public bool alwaysLoaded;

		public bool HasLoadBounds => loadBounds.Length != 0;

		public bool HasUnloadBounds => unloadBounds.Length != 0;

		public bool HasIgnoreUnloadBounds => ignoreUnloadBounds.Length != 0;

		public bool IsInBounds(Vector3 point, float sqrLoadDistance)
		{
			return bounds.SqrDistance(point) < sqrLoadDistance;
		}

		public bool IsInLoadBounds(Vector3 point)
		{
			Bounds[] array = loadBounds;
			foreach (Bounds bounds in array)
			{
				if (bounds.Contains(point))
				{
					return true;
				}
			}
			return false;
		}

		public bool IsInUnloadBounds(Vector3 point)
		{
			Bounds[] array = unloadBounds;
			foreach (Bounds bounds in array)
			{
				if (bounds.Contains(point))
				{
					return true;
				}
			}
			return false;
		}

		public bool IsInIgnoreUnloadBounds(Vector3 point)
		{
			Bounds[] array = ignoreUnloadBounds;
			foreach (Bounds bounds in array)
			{
				if (bounds.Contains(point))
				{
					return true;
				}
			}
			return false;
		}
	}

	public List<LevelSectionData> levelSections = new List<LevelSectionData>();
}
