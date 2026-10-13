using System;
using System.Collections;
using UnityEngine;

namespace PixelCrushers.DialogueSystem;

[AddComponentMenu("")]
public class ExtraDatabases : MonoBehaviour
{
	public DialogueTriggerEvent addTrigger = DialogueTriggerEvent.OnStart;

	public DialogueTriggerEvent removeTrigger = DialogueTriggerEvent.None;

	public DialogueDatabase[] databases = new DialogueDatabase[0];

	public Condition condition = new Condition();

	[Tooltip("As soon as one event (add or remove) has occurred, destroy this component.")]
	public bool once;

	[Tooltip("Add/remove one database per frame instead of adding them all at the same time. Useful to avoid stutter when adding several databases.")]
	public bool onePerFrame;

	private bool m_trying;

	public static event Action addedDatabases = () =>
	{
	};

	public static event Action removedDatabases = () =>
	{
	};

	private void TryAddDatabases(Transform interactor, bool immediate)
	{
		if (m_trying)
		{
			return;
		}
		m_trying = true;
		try
		{
			if (condition == null || condition.IsTrue(interactor))
			{
				AddDatabases(immediate);
				if (once)
				{
					UnityEngine.Object.Destroy(this);
				}
			}
		}
		finally
		{
			m_trying = false;
		}
	}

	public void AddDatabases(bool immediate)
	{
		if (immediate)
		{
			AddDatabasesImmediate();
		}
		else if (base.gameObject.activeInHierarchy && base.enabled)
		{
			StartCoroutine(AddDatabasesCoroutine());
		}
	}

	private void AddDatabasesImmediate()
	{
		DialogueDatabase[] array = databases;
		foreach (DialogueDatabase database in array)
		{
			AddDatabase(database);
		}
		addedDatabases();
	}

	private IEnumerator AddDatabasesCoroutine()
	{
		DialogueDatabase[] array = databases;
		foreach (DialogueDatabase database in array)
		{
			AddDatabase(database);
			yield return null;
		}
		addedDatabases();
	}

	private void AddDatabase(DialogueDatabase database)
	{
		if (database != null)
		{
			if (DialogueDebug.logInfo)
			{
				Debug.Log("Dialogue System: Adding database " + database.name, this);
			}
			DialogueManager.AddDatabase(database);
		}
	}

	private void TryRemoveDatabases(Transform interactor, bool immediate)
	{
		if (m_trying)
		{
			return;
		}
		m_trying = true;
		try
		{
			if (condition == null || condition.IsTrue(interactor))
			{
				RemoveDatabases(immediate);
				if (once)
				{
					UnityEngine.Object.Destroy(this);
				}
			}
		}
		finally
		{
			m_trying = false;
		}
	}

	public void RemoveDatabases(bool immediate)
	{
		if (immediate)
		{
			RemoveDatabasesImmediate();
		}
		else if (base.gameObject.activeInHierarchy && base.enabled)
		{
			StartCoroutine(RemoveDatabasesCoroutine());
		}
	}

	private void RemoveDatabasesImmediate()
	{
		DialogueDatabase[] array = databases;
		foreach (DialogueDatabase database in array)
		{
			RemoveDatabase(database);
		}
		removedDatabases();
	}

	private IEnumerator RemoveDatabasesCoroutine()
	{
		DialogueDatabase[] array = databases;
		foreach (DialogueDatabase database in array)
		{
			RemoveDatabase(database);
			yield return null;
		}
		removedDatabases();
	}

	private void RemoveDatabase(DialogueDatabase database)
	{
		if (database != null)
		{
			if (DialogueDebug.logInfo)
			{
				Debug.Log("Dialogue System: Removing database " + database.name, this);
			}
			DialogueManager.RemoveDatabase(database);
		}
	}

	public void Start()
	{
		if (addTrigger == DialogueTriggerEvent.OnStart)
		{
			TryAddDatabases(null, onePerFrame);
		}
		if (removeTrigger == DialogueTriggerEvent.OnStart)
		{
			TryRemoveDatabases(null, onePerFrame);
		}
	}

	public void OnEnable()
	{
		if (addTrigger == DialogueTriggerEvent.OnEnable)
		{
			TryAddDatabases(null, onePerFrame);
		}
		if (removeTrigger == DialogueTriggerEvent.OnEnable)
		{
			TryRemoveDatabases(null, onePerFrame);
		}
	}

	public void OnDisable()
	{
		if (addTrigger == DialogueTriggerEvent.OnDisable)
		{
			TryAddDatabases(null, onePerFrame);
		}
		if (removeTrigger == DialogueTriggerEvent.OnDisable)
		{
			TryRemoveDatabases(null, onePerFrame);
		}
	}

	public void OnDestroy()
	{
		if (addTrigger == DialogueTriggerEvent.OnDestroy)
		{
			TryAddDatabases(null, onePerFrame);
		}
		if (removeTrigger == DialogueTriggerEvent.OnDestroy)
		{
			TryRemoveDatabases(null, onePerFrame);
		}
	}

	public void OnUse(Transform actor)
	{
		if (base.enabled)
		{
			if (addTrigger == DialogueTriggerEvent.OnUse)
			{
				TryAddDatabases(actor, onePerFrame);
			}
			if (removeTrigger == DialogueTriggerEvent.OnUse)
			{
				TryRemoveDatabases(actor, onePerFrame);
			}
		}
	}

	public void OnUse(string message)
	{
		if (base.enabled)
		{
			if (addTrigger == DialogueTriggerEvent.OnUse)
			{
				TryAddDatabases(null, onePerFrame);
			}
			if (removeTrigger == DialogueTriggerEvent.OnUse)
			{
				TryRemoveDatabases(null, onePerFrame);
			}
		}
	}

	public void OnUse()
	{
		if (base.enabled)
		{
			if (addTrigger == DialogueTriggerEvent.OnUse)
			{
				TryAddDatabases(null, onePerFrame);
			}
			if (removeTrigger == DialogueTriggerEvent.OnUse)
			{
				TryRemoveDatabases(null, onePerFrame);
			}
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		if (base.enabled)
		{
			if (addTrigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				TryAddDatabases(other.transform, onePerFrame);
			}
			if (removeTrigger == DialogueTriggerEvent.OnTriggerEnter)
			{
				TryRemoveDatabases(other.transform, onePerFrame);
			}
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (base.enabled)
		{
			if (addTrigger == DialogueTriggerEvent.OnTriggerExit)
			{
				TryAddDatabases(other.transform, onePerFrame);
			}
			if (removeTrigger == DialogueTriggerEvent.OnTriggerExit)
			{
				TryRemoveDatabases(other.transform, onePerFrame);
			}
		}
	}
}
