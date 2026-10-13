using UnityEngine;
using UnityEngine.Events;

namespace PixelCrushers.DialogueSystem;

[AddComponentMenu("")]
public class IncrementOnDestroy : MonoBehaviour
{
	public enum IncrementOn
	{
		Destroy = 0,
		Disable = 1,
		Manually = 2
	}

	[Tooltip("Increment on Destroy or Disable.")]
	public IncrementOn incrementOn;

	[Tooltip("Increment this Dialogue System variable.")]
	[VariablePopup(false)]
	public string variable = string.Empty;

	[Tooltip("Increment the variable by this amount. Use a negative value to decrement.")]
	public int increment = 1;

	[Tooltip("After incrementing, ensure that the variable is at least this value.")]
	public int min;

	[Tooltip("After incrementing, ensure that the variable is no more than this value.")]
	public int max = 100;

	[Tooltip("Optional alert message to show when incrementing.")]
	public string alertMessage = string.Empty;

	[Tooltip("Duration to show alert, or 0 to use default duration.")]
	public float alertDuration;

	[Tooltip("If set, only increment if the conditions are true.")]
	public Condition condition = new Condition();

	public UnityEvent onIncrement = new UnityEvent();

	private bool listenForOnDestroy;

	protected string actualVariableName
	{
		get
		{
			if (!string.IsNullOrEmpty(variable))
			{
				return variable;
			}
			return DialogueActor.GetPersistentDataName(base.transform);
		}
	}

	protected string ActualVariableName => actualVariableName;

	public void OnEnable()
	{
		listenForOnDestroy = true;
		PersistentDataManager.RegisterPersistentData(base.gameObject);
	}

	public void OnLevelWillBeUnloaded()
	{
		listenForOnDestroy = false;
	}

	public void OnApplicationQuit()
	{
		listenForOnDestroy = false;
	}

	public void OnDestroy()
	{
		if (incrementOn == IncrementOn.Destroy)
		{
			TryIncrement();
		}
	}

	public void OnDisable()
	{
		PersistentDataManager.UnregisterPersistentData(base.gameObject);
		if (incrementOn == IncrementOn.Disable)
		{
			TryIncrement();
		}
	}

	public void TryIncrement()
	{
		if (!Application.isPlaying || !listenForOnDestroy || DialogueManager.Instance == null || DialogueManager.DatabaseManager == null || DialogueManager.MasterDatabase == null || !condition.IsTrue(null))
		{
			return;
		}
		int num = Mathf.Clamp(DialogueLua.GetVariable(actualVariableName).asInt + increment, min, max);
		DialogueLua.SetVariable(actualVariableName, num);
		DialogueManager.SendUpdateTracker();
		if (!string.IsNullOrEmpty(alertMessage) && !(DialogueManager.instance == null))
		{
			if (Mathf.Approximately(0f, alertDuration))
			{
				DialogueManager.ShowAlert(alertMessage);
			}
			else
			{
				DialogueManager.ShowAlert(alertMessage, alertDuration);
			}
		}
		onIncrement.Invoke();
	}
}
