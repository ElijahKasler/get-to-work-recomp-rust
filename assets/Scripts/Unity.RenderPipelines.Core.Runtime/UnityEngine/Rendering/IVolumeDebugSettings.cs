using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering;

public interface IVolumeDebugSettings
{
	int selectedComponent { get; set; }

	Camera selectedCamera { get; }

	IEnumerable<Camera> cameras { get; }

	int selectedCameraIndex { get; set; }

	VolumeStack selectedCameraVolumeStack { get; }

	LayerMask selectedCameraLayerMask { get; }

	Vector3 selectedCameraPosition { get; }

	Type selectedComponentType { get; set; }

	Volume[] GetVolumes();

	bool VolumeHasInfluence(Volume volume);

	bool RefreshVolumes(Volume[] newVolumes);

	float GetVolumeWeight(Volume volume);
}
