using System;

namespace Isto.Core;

public static class Environment
{
	[Flags]
	public enum GroundType
	{
		Grass = 0,
		BloodWater = 1,
		Road = 2,
		QuartzWater = 4,
		Quartz = 8,
		GravRock = 0x10,
		Plains = 0x20,
		CobbleStone = 0x40,
		Sidewalk = 0x80,
		NotSet = 0x100,
		Corrosive = 0x200
	}
}
