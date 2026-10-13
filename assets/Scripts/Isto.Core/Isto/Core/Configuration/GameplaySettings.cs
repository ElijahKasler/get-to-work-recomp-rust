using Isto.Core.Enums;
using Isto.Core.Scenes;
using UnityEngine;
using UnityEngine.Serialization;

namespace Isto.Core.Configuration;

[CreateAssetMenu(fileName = "New Gameplay Settings", menuName = "Scriptables/Tools/CoreGameplaySettings")]
public class GameplaySettings : ScriptableObject
{
	public enum Loadout
	{
		Default = 0,
		Automation = 1,
		AIInteraction = 2,
		Crafting = 3,
		Speedrun = 4,
		Everything = 5,
		AICombat = 6,
		SteveWorking = 7,
		GameMechanics = 8,
		TestingResearch = 9,
		CreativeMode = 10
	}

	public class LoadoutEnum : Int32Enum<LoadoutEnum>
	{
		public static readonly LoadoutEnum DEFAULT = new LoadoutEnum(0, "DEFAULT");

		public static readonly LoadoutEnum AUTOMATION = new LoadoutEnum(1, "AUTOMATION");

		public LoadoutEnum(int value, string name)
			: base(value, name)
		{
		}
	}

	[Header("Scenes")]
	[SceneReference]
	public string titleScreenSceneName;

	[Header("Basic Configuration")]
	public bool endGamePopupLarge;

	public bool showWelcomePopup;

	public bool showBuildingConnectAnimations = true;

	public bool showDialogue = true;

	public string feedbackUrl = "https://docs.google.com/forms/d/e/1FAIpQLSeJoSIvdEM4a5XTYKo8yzJ6s2AIUQ5s0uihAIBvzSX5kvnwPQ/viewform?usp=sf_link";

	[Header("Game Scenarios")]
	[FormerlySerializedAs("mode")]
	[EnumDropdown(typeof(LoadoutEnum))]
	public int selectedScenario;

	[Header("Setups hookup")]
	public ScenarioSetup defaultSetup;

	public ScenarioSetup automationSetup;

	public LoadoutEnum Mode => Int32Enum<LoadoutEnum>.GetByValue(selectedScenario);

	public virtual ScenarioSetup GetStartingSetup()
	{
		if (selectedScenario == LoadoutEnum.DEFAULT.Value)
		{
			return defaultSetup;
		}
		if (selectedScenario == LoadoutEnum.AUTOMATION.Value)
		{
			return automationSetup;
		}
		return defaultSetup;
	}
}
