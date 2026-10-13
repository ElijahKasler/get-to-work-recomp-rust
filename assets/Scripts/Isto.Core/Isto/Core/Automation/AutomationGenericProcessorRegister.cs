using Isto.Core.Beings;
using Isto.Core.Data;
using Isto.Core.Game;
using Isto.Core.Items;
using UPool;
using UnityEngine;
using Zenject;

namespace Isto.Core.Automation;

public class AutomationGenericProcessorRegister : MonoBehaviour, IActivatable, IAutomationGridSpaceDisplay, IActionOnPickup, IDataLoadCompleteHandler
{
	[SerializeField]
	private AdvancedItem _item;

	[SerializeField]
	private bool _visualCulling = true;

	[SerializeField]
	private bool _pooledObject = true;

	private AutomationGenericProcessor _systemProcessor;

	private AutomationGridSpace _gridSpace;

	private AutomationSystem _autoSystem;

	private AutomationGenericProcessor.Factory _genericFactory;

	private AutomationSystemDisplay _autoSystemDisplay;

	[Inject]
	public void Inject(AutomationSystem automationSystem, AutomationGenericProcessor.Factory processorFactory, AutomationSystemDisplay systemDisplay)
	{
		_autoSystem = automationSystem;
		_genericFactory = processorFactory;
		_autoSystemDisplay = systemDisplay;
	}

	public void OnDataLoadComplete()
	{
		SetupInAutomationSystem(addToArea: false);
		if (_pooledObject)
		{
			PoolableObject component = base.gameObject.GetComponent<PoolableObject>();
			PooledInteractableItem component2 = base.gameObject.GetComponent<PooledInteractableItem>();
			if (component != null && component2 != null)
			{
				if (!GameState.LoadingFromSave)
				{
					component2.DeconfigurePooling();
				}
			}
			else
			{
				Debug.LogError("AutomationGenericProcessorRegister.OnDataLoadComplete: item " + base.gameObject.name + " should be pooled but it is not, is this a legitimate use case?", base.gameObject);
			}
			if (_visualCulling)
			{
				if (component2 != null)
				{
					component2.DestroyGameObject();
				}
				else
				{
					Debug.LogWarning("AutomationGenericProcessorRegister Destroying the non-pooled item " + base.gameObject.name + " directly.");
					Object.Destroy(base.gameObject);
				}
			}
		}
		if (_visualCulling)
		{
			Object.Destroy(base.gameObject);
		}
	}

	public void Activate()
	{
		SetupInAutomationSystem();
	}

	private void SetupInAutomationSystem(bool addToArea = true)
	{
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		_systemProcessor = _genericFactory.Create(_item.itemID);
		_systemProcessor.SetVisible(_visualCulling);
		if (_autoSystem.TryAddItemProcessor(base.transform.position, _systemProcessor, Vector3.back))
		{
			_gridSpace = _autoSystem.GetOrCreateGridSpace(base.transform.position);
			if (addToArea && _visualCulling)
			{
				_autoSystemDisplay.AddObjectToAreaDictionary(base.gameObject);
			}
			IAutomationGridSpaceDisplay[] components = GetComponents<IAutomationGridSpaceDisplay>();
			for (int i = 0; i < components.Length; i++)
			{
				components[i].SetGridSpace(_gridSpace);
			}
			Health component = GetComponent<Health>();
			if (component != null)
			{
				component.Killed += OnKilled;
			}
		}
		else
		{
			Debug.LogWarning($"Couldn't add {_item.itemID} generic processor to automation grid space at {base.transform.position}.");
		}
	}

	public void SetGridSpace(AutomationGridSpace space)
	{
		_gridSpace = space;
		_systemProcessor = space.itemProcessor as AutomationGenericProcessor;
	}

	public void DoPickupAction()
	{
		if (_autoSystem == null || _autoSystemDisplay == null || _gridSpace == null)
		{
			Debug.LogError("Null Automation Variables in DoPickUpAction on item:" + _item.itemID + ". Force destroying item");
			Object.Destroy(base.gameObject, 0.1f);
			return;
		}
		_autoSystem.TryRemoveProcessor(_gridSpace.position);
		if (_visualCulling)
		{
			_autoSystemDisplay.RemoveObjectFromAreaDictionary(base.gameObject);
		}
	}

	private void OnKilled(object sender, HealthEventArgs e)
	{
		DoPickupAction();
	}
}
