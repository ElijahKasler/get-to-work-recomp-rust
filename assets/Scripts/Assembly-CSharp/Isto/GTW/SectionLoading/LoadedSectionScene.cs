using UnityEngine;

namespace Isto.GTW.SectionLoading;

public class LoadedSectionScene
{
	public SectionData.LevelSectionData sectionData;

	public ISectionLoadStrategy loadStrategy;

	private bool requireSectionLoaded;

	public bool IsBusy
	{
		get
		{
			if (!loadStrategy.IsLoading)
			{
				return loadStrategy.IsUnloading;
			}
			return true;
		}
	}

	public float Progress => loadStrategy.Progress;

	public void UpdateLoadRequirement(Vector3 playerPosition, float sqrLoadDistance)
	{
		if (IsBusy)
		{
			return;
		}
		if (sectionData.alwaysLoaded)
		{
			requireSectionLoaded = true;
			return;
		}
		if (!requireSectionLoaded)
		{
			if (sectionData.HasLoadBounds)
			{
				requireSectionLoaded = sectionData.IsInLoadBounds(playerPosition);
			}
			else
			{
				requireSectionLoaded = sectionData.IsInBounds(playerPosition, sqrLoadDistance);
			}
			return;
		}
		if (sectionData.HasUnloadBounds)
		{
			requireSectionLoaded = sectionData.IsInUnloadBounds(playerPosition);
		}
		else if (sectionData.HasLoadBounds)
		{
			requireSectionLoaded = sectionData.IsInLoadBounds(playerPosition);
		}
		else
		{
			requireSectionLoaded = sectionData.IsInBounds(playerPosition, sqrLoadDistance);
		}
		if (sectionData.HasIgnoreUnloadBounds && !requireSectionLoaded)
		{
			requireSectionLoaded = sectionData.IsInIgnoreUnloadBounds(playerPosition);
		}
	}

	public void Update()
	{
		if (requireSectionLoaded && !loadStrategy.IsLoaded && !IsBusy)
		{
			loadStrategy.StartLoading();
		}
		else if (!requireSectionLoaded && loadStrategy.IsLoaded && !IsBusy)
		{
			loadStrategy.StartUnloading();
		}
	}
}
