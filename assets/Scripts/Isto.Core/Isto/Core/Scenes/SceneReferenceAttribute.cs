using UnityEngine;

namespace Isto.Core.Scenes;

public class SceneReferenceAttribute : PropertyAttribute
{
	public bool fullPath;

	public SceneReferenceAttribute()
	{
		fullPath = false;
	}

	public SceneReferenceAttribute(bool fullPath)
	{
		this.fullPath = fullPath;
	}
}
