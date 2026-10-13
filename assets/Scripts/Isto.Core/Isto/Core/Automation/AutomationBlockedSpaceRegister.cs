using UnityEngine;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationBlockedSpaceRegister : MonoBehaviour
{
	[SerializeField]
	private Vector2Int area;

	private AutomationSystem _automationSystem;

	[Inject]
	public void Inject(AutomationSystem automationSystem)
	{
		_automationSystem = automationSystem;
	}

	public void OnEnable()
	{
		_ = base.transform.position;
		for (int i = 0; i < area.x; i++)
		{
			for (int j = 0; j < area.y; j++)
			{
				Vector3 vector = base.transform.position + Vector3.right * i + Vector3.forward * j;
				if (_automationSystem.GetOrCreateGridSpace(vector).itemProcessor is AutomationBlockedSpace)
				{
					return;
				}
				if (!_automationSystem.TryAddItemProcessor(vector, new AutomationBlockedSpace()))
				{
					Debug.LogWarning($"Could not block automation space at {vector}.  There may be an existing item there already");
				}
			}
		}
	}

	public void OnDisable()
	{
		_ = base.transform.position;
		for (int i = 0; i < area.x; i++)
		{
			for (int j = 0; j < area.y; j++)
			{
				Vector3 position = base.transform.position + Vector3.right * i + Vector3.forward * j;
				_automationSystem.TryRemoveProcessor(position);
			}
		}
	}

	public void OnValidate()
	{
		if (area.x < 0)
		{
			area.x = 0;
		}
		if (area.y < 0)
		{
			area.y = 0;
		}
	}
}
