using Isto.GTW.Managers;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using Zenject;

public class DialogueExtensions : MonoBehaviour
{
	private TimeManager _timeManager;

	[Inject]
	public void Inject(TimeManager timeManager)
	{
		_timeManager = timeManager;
	}

	private void OnEnable()
	{
		Lua.RegisterFunction("DebugLog", this, SymbolExtensions.GetMethodInfo(() => DebugLog(string.Empty)));
		Lua.RegisterFunction("TotalGameTime", this, SymbolExtensions.GetMethodInfo(() => TotalGameTime()));
		Lua.RegisterFunction("CoolDownCondition", this, SymbolExtensions.GetMethodInfo(() => CoolDownCondition(0.0, 0.0)));
	}

	private void OnDisable()
	{
		Lua.UnregisterFunction("DebugLog");
		Lua.UnregisterFunction("TotalGameTime");
		Lua.UnregisterFunction("CoolDownCondition");
	}

	public void DebugLog(string message)
	{
		Debug.Log(message);
	}

	public double TotalGameTime()
	{
		return _timeManager.TotalGameTime;
	}

	public bool CoolDownCondition(double gameTime, double cooldown)
	{
		return (double)_timeManager.TotalGameTime > gameTime + cooldown;
	}
}
