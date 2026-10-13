using Isto.Core.Inputs;

namespace Isto.GTW.Inputs;

public class GTWUserActions : UserActions
{
	public static readonly GTWUserActions GRAB = new GTWUserActions("Grab", "GRAB");

	public static readonly GTWUserActions BRAKE = new GTWUserActions("Brake", "BRAKE");

	public static readonly GTWUserActions SLOWMOTION = new GTWUserActions("SlowMotion", "SLOWMOTION");

	public static readonly GTWUserActions NOCLIP = new GTWUserActions("NoClip", "NOCLIP");

	public static readonly GTWUserActions NOCLIPMOVEUP = new GTWUserActions("NoClipMoveUp", "NOCLIPMOVEUP");

	public static readonly GTWUserActions NOCLIPMOVEDOWN = new GTWUserActions("NoClipMoveDown", "NOCLIPMOVEDOWN");

	public static readonly GTWUserActions NOCLIPHIGHSPEED = new GTWUserActions("NoClipHighSpeed", "NOCLIPHIGHSPEED");

	public static readonly GTWUserActions RESPAWNACTIVECHECKPOINT = new GTWUserActions("RespawnActiveCheckpoint", "RESPAWNACTIVECHECKPOINT");

	public static readonly GTWUserActions RESPAWNSTARTINGCHECKPOINT = new GTWUserActions("RespawnStartingCheckpoint", "RESPAWNSTARTINGCHECKPOINT");

	public static readonly GTWUserActions GIVEUP = new GTWUserActions("Ragdoll", "GIVEUP");

	public static readonly GTWUserActions RESTART = new GTWUserActions("Restart", "RESTART");

	public static readonly GTWUserActions STARTGAME = new GTWUserActions("StartGame", "STARTGAME");

	protected internal GTWUserActions(string value, string name)
		: base(value, name)
	{
	}
}
