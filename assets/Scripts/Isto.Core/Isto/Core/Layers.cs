namespace Isto.Core;

public static class Layers
{
	public static readonly int WATER = 4;

	public static readonly int WATER_MASK = 1 << WATER;

	public static readonly int UI = 5;

	public static readonly int UI_MASK = 1 << UI;

	public static readonly int PLAYER = 8;

	public static readonly int PLAYER_MASK = 1 << PLAYER;

	public static readonly int PROJECTILE = 9;

	public static readonly int PROJECTILE_MASK = 1 << PROJECTILE;

	public static readonly int GROUND = 10;

	public static readonly int GROUND_MASK = 1 << GROUND;

	public static readonly int ITEM_ON_GROUND = 11;

	public static readonly int ITEM_ON_GROUND_MASK = 1 << ITEM_ON_GROUND;

	public static readonly int BUILDING = 12;

	public static readonly int BUILDING_MASK = 1 << BUILDING;

	public static readonly int COLLECTABLE = 13;

	public static readonly int COLLECTABLE_MASK = 1 << COLLECTABLE;

	public static readonly int HARVESTABLE = 14;

	public static readonly int HARVESTABLE_MASK = 1 << HARVESTABLE;

	public static readonly int WEATHER = 15;

	public static readonly int WEATHER_MASK = 1 << WEATHER;

	public static readonly int LIGHT = 16;

	public static readonly int LIGHT_MASK = 1 << LIGHT;

	public static readonly int EVENT_TRIGGER = 17;

	public static readonly int EVENT_TRIGGER_MASK = 1 << EVENT_TRIGGER;

	public static readonly int PLAYER_TRIGGER = 18;

	public static readonly int PLAYER_TRIGGER_MASK = 1 << PLAYER_TRIGGER;

	public static readonly int MOB = 19;

	public static readonly int MOB_MASK = 524288;

	public static readonly int ENVIRONMENT = 20;

	public static readonly int ENVIRONMENT_MASK = 1048576;

	public static readonly int ITEM_OVERLAP = 22;

	public static readonly int ITEM_OVERLAP_MASK = 4194304;

	public static readonly int BASE_GROUND = 23;

	public static readonly int BASE_GROUND_MASK = 8388608;

	public static readonly int PATHS = 25;

	public static readonly int PATHS_MASK = 33554432;

	public static readonly int NON_NAVMESH_OBSTACLE = 28;

	public static readonly int NON_NAVMESH_OBSTACLE_MASK = 268435456;

	public static readonly int GROUND_LAYERS_MASK = (1 << GROUND) | (1 << BASE_GROUND);

	public static readonly int NAV_MESH_WALKABLE_AREA_LAYER_MASK = 1;
}
