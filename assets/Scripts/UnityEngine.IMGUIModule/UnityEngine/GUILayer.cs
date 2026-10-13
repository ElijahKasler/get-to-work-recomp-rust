using System;
using System.ComponentModel;

namespace UnityEngine;

[ExcludeFromPreset]
[ExcludeFromObjectFactory]
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("GUILayer has been removed.", true)]
public sealed class GUILayer
{
	[Obsolete("GUILayer has been removed.", true)]
	public GUIElement HitTest(Vector3 screenPosition)
	{
		throw new Exception("GUILayer has been removed from Unity.");
	}
}
