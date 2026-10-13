using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ModestTree;

namespace Zenject;

[DebuggerStepThrough]
public abstract class TaskUpdater<TTask>
{
	private class TaskInfo
	{
		public TTask Task;

		public int Priority;

		public bool IsRemoved;

		public TaskInfo(TTask task, int priority)
		{
			Task = task;
			Priority = priority;
		}
	}

	private readonly LinkedList<TaskInfo> _tasks = new LinkedList<TaskInfo>();

	private readonly List<TaskInfo> _queuedTasks = new List<TaskInfo>();

	private IEnumerable<TaskInfo> AllTasks => ActiveTasks.Concat(_queuedTasks);

	private IEnumerable<TaskInfo> ActiveTasks => _tasks;

	public void AddTask(TTask task, int priority)
	{
		AddTaskInternal(task, priority);
	}

	private void AddTaskInternal(TTask task, int priority)
	{
		Assert.That(!AllTasks.Select((TaskInfo x) => x.Task).ContainsItem(task), "Duplicate task added to DependencyRoot with name '" + task.GetType().FullName + "'");
		_queuedTasks.Add(new TaskInfo(task, priority));
	}

	public void RemoveTask(TTask task)
	{
		TaskInfo taskInfo = AllTasks.Where((TaskInfo x) => (object)x.Task == (object)task).SingleOrDefault();
		Assert.IsNotNull(taskInfo, "Tried to remove a task not added to DependencyRoot, task = " + task.GetType().Name);
		Assert.That(!taskInfo.IsRemoved, "Tried to remove task twice, task = " + task.GetType().Name);
		taskInfo.IsRemoved = true;
	}

	public void OnFrameStart()
	{
		AddQueuedTasks();
	}

	public void UpdateAll()
	{
		UpdateRange(int.MinValue, int.MaxValue);
	}

	public void UpdateRange(int minPriority, int maxPriority)
	{
		LinkedListNode<TaskInfo> linkedListNode = _tasks.First;
		while (linkedListNode != null)
		{
			LinkedListNode<TaskInfo> next = linkedListNode.Next;
			TaskInfo value = linkedListNode.Value;
			if (!value.IsRemoved && value.Priority >= minPriority && (maxPriority == int.MaxValue || value.Priority < maxPriority))
			{
				UpdateItem(value.Task);
			}
			linkedListNode = next;
		}
		ClearRemovedTasks(_tasks);
	}

	private void ClearRemovedTasks(LinkedList<TaskInfo> tasks)
	{
		LinkedListNode<TaskInfo> linkedListNode = tasks.First;
		while (linkedListNode != null)
		{
			LinkedListNode<TaskInfo> next = linkedListNode.Next;
			if (linkedListNode.Value.IsRemoved)
			{
				tasks.Remove(linkedListNode);
			}
			linkedListNode = next;
		}
	}

	private void AddQueuedTasks()
	{
		for (int i = 0; i < _queuedTasks.Count; i++)
		{
			TaskInfo taskInfo = _queuedTasks[i];
			if (!taskInfo.IsRemoved)
			{
				InsertTaskSorted(taskInfo);
			}
		}
		_queuedTasks.Clear();
	}

	private void InsertTaskSorted(TaskInfo task)
	{
		for (LinkedListNode<TaskInfo> linkedListNode = _tasks.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
		{
			if (linkedListNode.Value.Priority > task.Priority)
			{
				_tasks.AddBefore(linkedListNode, task);
				return;
			}
		}
		_tasks.AddLast(task);
	}

	protected abstract void UpdateItem(TTask task);
}
