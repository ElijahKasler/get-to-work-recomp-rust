using System;
using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Configuration;

[CreateAssetMenu(fileName = "Scriptables/New Time Step Setup", menuName = "Scriptables/New Time Step Setup")]
public class TimeStepSetup : ScriptableObject
{
	[Serializable]
	public class PlatformSpecificSettings
	{
		public RuntimePlatform platform;

		public float fixedTimeStep;
	}

	public List<PlatformSpecificSettings> settings;
}
