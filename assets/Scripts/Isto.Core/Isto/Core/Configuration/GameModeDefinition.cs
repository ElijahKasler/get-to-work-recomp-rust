using I2.Loc;
using UnityEngine;
using UnityEngine.Serialization;

namespace Isto.Core.Configuration;

[CreateAssetMenu(fileName = "Scriptables/New Core Game Mode Definition", menuName = "Scriptables/New Core Game Mode Definition")]
public class GameModeDefinition : ScriptableObject
{
	public LocalizedString nameLoc;

	public LocalizedString descriptionLoc;

	[FormerlySerializedAs("InternalName")]
	public string internalName;

	[FormerlySerializedAs("Allowed")]
	public bool allowed;

	[FormerlySerializedAs("ShowIntroCutscene")]
	public bool showIntroCutscene;

	[FormerlySerializedAs("DeveloperConsoleEnabled")]
	public bool developerConsoleEnabled;

	[FormerlySerializedAs("CanSaveGame")]
	public bool canSaveGame;

	[FormerlySerializedAs("CanLoadGame")]
	public bool canLoadGame;

	[FormerlySerializedAs("ShowRestartButton")]
	public bool showRestartButton;

	public GameModeDefinition NextModeUponCompletion;

	public virtual LocalizedString NameLoc => nameLoc;

	public virtual LocalizedString DescriptionLoc => descriptionLoc;

	public virtual string InternalName => internalName;

	public virtual bool Allowed => allowed;

	public virtual bool ShowIntroCutscene => showIntroCutscene;

	public virtual bool DeveloperConsoleEnabled => developerConsoleEnabled;

	public virtual bool CanSaveGame => canSaveGame;

	public virtual bool CanLoadGame => canLoadGame;

	public virtual bool ShowRestartButton => showRestartButton;
}
