using System.Collections.Generic;
using Isto.Core.Items;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Isto.Core.Power;

public class PowerTethered : MonoBehaviour, IActivatable
{
	public float maxRange;

	[FormerlySerializedAs("_connectionIn")]
	[SerializeField]
	private PowerTethered _parentConnection;

	[SerializeField]
	private bool _isPowerSource;

	[Tooltip("If this tether connects to a socket, this is the root of the part that will get offset to not clash with the socket visuals.")]
	[SerializeField]
	private Transform _visualsRoot;

	[FormerlySerializedAs("_connectionsOut")]
	[SerializeField]
	private List<PowerTethered> _childConnections = new List<PowerTethered>();

	private bool _quitting;

	private TetherSystem _tetherSystem;

	private bool _registered;

	public PowerTethered ParentConnection => _parentConnection;

	public List<PowerTethered> ChildConnections => _childConnections;

	public int NumChildConnections => _childConnections.Count;

	public bool IsBeingDestroyed { get; private set; }

	public bool Powered { get; private set; }

	public bool PowerSource => _isPowerSource;

	public bool Registered => _registered;

	public TetherSystem TetherSystem => _tetherSystem;

	[Inject]
	public void Inject(TetherSystem tetherSystem)
	{
		_tetherSystem = tetherSystem;
	}

	private void OnEnable()
	{
		if (_tetherSystem != null)
		{
			RegisterTether();
		}
	}

	private void OnDisable()
	{
		if (_quitting)
		{
			return;
		}
		IsBeingDestroyed = true;
		if (_parentConnection != null)
		{
			_parentConnection.RemoveChildConnection(this);
			_parentConnection = null;
		}
		for (int num = _childConnections.Count - 1; num >= 0; num--)
		{
			if (_childConnections[num] != null)
			{
				SetChildrenAsUnpowered(_childConnections[num]);
				_childConnections[num].SetParentConnection(null);
			}
			else
			{
				_childConnections.RemoveAt(num);
			}
		}
		_tetherSystem.Remove(this);
		_registered = false;
	}

	private void OnApplicationQuit()
	{
		_quitting = true;
	}

	public void AddOffset(Vector3 offset)
	{
		_visualsRoot.position += offset;
	}

	public void Activate()
	{
		if (base.gameObject.activeInHierarchy)
		{
			RegisterTether();
			if (ParentConnection == null)
			{
				UpdateNearest();
			}
		}
	}

	public void SetChildConnection(PowerTethered powerTethered)
	{
		if (!_childConnections.Contains(powerTethered))
		{
			_childConnections.Add(powerTethered);
		}
	}

	public void SetParentConnection(PowerTethered powerTethered)
	{
		if (_parentConnection != null && !_parentConnection.IsBeingDestroyed && powerTethered != _parentConnection)
		{
			_parentConnection.RemoveChildConnection(this);
		}
		_parentConnection = powerTethered;
		if (_parentConnection == null)
		{
			Powered = false;
			UpdateNearest();
		}
	}

	public void RemoveChildConnection(PowerTethered powerTethered)
	{
		_childConnections.Remove(powerTethered);
	}

	public void SetAsPowerSource()
	{
		_isPowerSource = true;
	}

	public void UpdateNearest(bool placementMode = false)
	{
		PowerTethered parentConnection = ParentConnection;
		_parentConnection = null;
		if (_isPowerSource)
		{
			return;
		}
		if (placementMode)
		{
			for (int num = ChildConnections.Count - 1; num >= 0; num--)
			{
				PowerTethered powerTethered = ChildConnections[num];
				SetChildrenAsUnpowered(powerTethered);
				powerTethered.SetParentConnection(null);
				RemoveChildConnection(powerTethered);
			}
		}
		List<PowerTethered> allInRange = _tetherSystem.GetAllInRange(this);
		bool flag = false;
		if (TryGetPowerSource(allInRange, out var powerSource))
		{
			_parentConnection = powerSource;
			powerSource.SetChildConnection(this);
			flag = true;
		}
		if (!flag)
		{
			for (int i = 0; i < allInRange.Count; i++)
			{
				if (allInRange[i].Powered && AllowConnection(allInRange[i], this))
				{
					_parentConnection = allInRange[i];
					ParentConnection.SetChildConnection(this);
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			for (int j = 0; j < allInRange.Count; j++)
			{
				if (AllowConnection(allInRange[j], this))
				{
					_parentConnection = allInRange[j];
					ParentConnection.SetChildConnection(this);
					flag = true;
					break;
				}
			}
		}
		if (ParentConnection != parentConnection)
		{
			SetPowered(powered: false);
			if (parentConnection != null)
			{
				parentConnection.RemoveChildConnection(this);
			}
		}
		for (int k = 0; k < allInRange.Count; k++)
		{
			if (allInRange[k].ParentConnection == this)
			{
				continue;
			}
			if (allInRange[k].ParentConnection == null && allInRange[k].AllowParenting(this))
			{
				allInRange[k].SetParentConnection(this);
				if (!_childConnections.Contains(allInRange[k]))
				{
					_childConnections.Add(allInRange[k]);
					continue;
				}
				Debug.LogWarning("A connection had no connection in but it was registered as a connection out, this shouldn't happen." + $" From {base.gameObject.name} at {base.transform.position}, to {allInRange[k].gameObject.name} at {allInRange[k].transform.position}");
			}
			else if (placementMode && allInRange[k].ParentConnection != null && IsOrphanedFromPowerSource(allInRange[k]) && allInRange[k].AllowParenting(this))
			{
				allInRange[k].ReverseDirection();
				if (allInRange[k].ParentConnection != null)
				{
					Debug.LogError("Reverse Direction failed on orphaned group at pos=" + allInRange[k].transform.position.ToString(), allInRange[k].gameObject);
				}
				allInRange[k].SetParentConnection(this);
				if (!_childConnections.Contains(allInRange[k]))
				{
					_childConnections.Add(allInRange[k]);
				}
			}
		}
	}

	[ContextMenu("Make Connections")]
	public void MakeConnectionsOutwards()
	{
		List<PowerTethered> allInRange = _tetherSystem.GetAllInRange(this);
		bool flag = false;
		while (allInRange.Count > 0 && !flag)
		{
			PowerTethered nextValidConnection = GetNextValidConnection(allInRange, this);
			if (nextValidConnection != null)
			{
				nextValidConnection.SetParentConnection(this);
				if (!_childConnections.Contains(nextValidConnection))
				{
					_childConnections.Add(nextValidConnection);
				}
				allInRange.Remove(nextValidConnection);
			}
			else
			{
				flag = true;
			}
		}
		for (int i = 0; i < _childConnections.Count; i++)
		{
			if (_childConnections[i].Registered)
			{
				_childConnections[i].MakeConnectionsOutwards();
			}
		}
	}

	private PowerTethered GetNextValidConnection(List<PowerTethered> nearby, PowerTethered source)
	{
		for (int i = 0; i < nearby.Count; i++)
		{
			PowerTethered powerTethered = nearby[i];
			if (powerTethered.Registered && powerTethered.ParentConnection == null && powerTethered.AllowParenting(source))
			{
				return powerTethered;
			}
		}
		return null;
	}

	private bool TryGetPowerSource(List<PowerTethered> nearby, out PowerTethered powerSource)
	{
		for (int i = 0; i < nearby.Count; i++)
		{
			if (nearby[i].PowerSource)
			{
				powerSource = nearby[i];
				return true;
			}
		}
		powerSource = null;
		return false;
	}

	public void TransmitConnectionsRemaining(int amount)
	{
		int num = amount - ((!PowerSource) ? 1 : 0);
		SetPowered(num >= 0);
	}

	protected void SetChildrenAsUnpowered(PowerTethered tethered)
	{
		for (int i = 0; i < tethered.ChildConnections.Count; i++)
		{
			PowerTethered powerTethered = tethered.ChildConnections[i];
			if (powerTethered.Registered)
			{
				powerTethered.SetPowered(powered: false);
				SetChildrenAsUnpowered(powerTethered);
			}
		}
	}

	private void RegisterTether()
	{
		if (!_registered)
		{
			_registered = true;
			_tetherSystem.Add(this);
		}
	}

	private bool AllowConnection(PowerTethered newConnection, PowerTethered currentConnection)
	{
		if (_isPowerSource)
		{
			return false;
		}
		PowerTethered parentConnection = newConnection.ParentConnection;
		while (true)
		{
			if (parentConnection == null)
			{
				return true;
			}
			if (parentConnection == currentConnection)
			{
				break;
			}
			parentConnection = parentConnection.ParentConnection;
		}
		return false;
	}

	public bool AllowParenting(PowerTethered parentCandidate)
	{
		if (_childConnections.Contains(parentCandidate))
		{
			return false;
		}
		bool flag = true;
		for (int i = 0; i < _childConnections.Count; i++)
		{
			flag &= _childConnections[i].AllowParenting(parentCandidate);
		}
		return flag;
	}

	public bool IsPartOfSameTree(PowerTethered incomingConnection)
	{
		if (incomingConnection == null)
		{
			return false;
		}
		HashSet<PowerTethered> allGraphNodes = GetAllGraphNodes(this);
		bool flag = false;
		HashSet<PowerTethered>.Enumerator enumerator = allGraphNodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			flag = enumerator.Current.ParentConnection == incomingConnection || enumerator.Current.ChildConnections.Contains(incomingConnection);
			if (flag)
			{
				break;
			}
		}
		return flag;
	}

	[ContextMenu("TestOrphanCheck")]
	private void TestOrphanCheck()
	{
		Debug.LogError("IsOrphanedFromPowerSource? " + IsOrphanedFromPowerSource(this));
	}

	public bool IsOrphanedFromPowerSource(PowerTethered incomingConnection)
	{
		if (incomingConnection._isPowerSource)
		{
			return false;
		}
		HashSet<PowerTethered> allGraphNodes = GetAllGraphNodes(incomingConnection);
		bool flag = false;
		HashSet<PowerTethered>.Enumerator enumerator = allGraphNodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			flag = enumerator.Current._isPowerSource;
			if (flag)
			{
				break;
			}
		}
		return !flag;
	}

	private HashSet<PowerTethered> GetAllGraphNodes(PowerTethered startNode)
	{
		HashSet<PowerTethered> hashSet = new HashSet<PowerTethered>();
		Queue<PowerTethered> queue = new Queue<PowerTethered>();
		queue.Enqueue(startNode);
		while (queue.Count > 0)
		{
			PowerTethered powerTethered = queue.Dequeue();
			if (hashSet.Contains(powerTethered))
			{
				continue;
			}
			hashSet.Add(powerTethered);
			if (powerTethered.ParentConnection != null && powerTethered.ParentConnection.Registered)
			{
				queue.Enqueue(powerTethered.ParentConnection);
			}
			if (powerTethered.ChildConnections == null)
			{
				continue;
			}
			for (int i = 0; i < powerTethered.ChildConnections.Count; i++)
			{
				if (powerTethered.ChildConnections[i] != null && powerTethered.ChildConnections[i].Registered)
				{
					queue.Enqueue(powerTethered.ChildConnections[i]);
				}
			}
		}
		return hashSet;
	}

	[ContextMenu("TestReverseDirection")]
	private void TestReverseDirection()
	{
		ReverseDirection();
	}

	private void ReverseDirection()
	{
		List<PowerTethered> list = new List<PowerTethered>();
		PowerTethered powerTethered = this;
		while (powerTethered != null)
		{
			list.Add(powerTethered);
			powerTethered = powerTethered.ParentConnection;
		}
		if (list.Count > 0)
		{
			_parentConnection.RemoveChildConnection(this);
			_parentConnection = null;
		}
		for (int i = 0; i < list.Count; i++)
		{
			powerTethered = list[i];
			if (i > 0)
			{
				powerTethered.SetParentConnection(list[i - 1]);
			}
			if (i < list.Count - 1)
			{
				powerTethered.SetChildConnection(list[i + 1]);
			}
		}
	}

	public void SetPowered(bool powered)
	{
		Powered = powered;
	}

	public void OnDrawGizmosSelected()
	{
		Vector3 position = base.transform.position;
		position.y += 0.1f;
		position.x += -0.5f;
		position.z += 0.5f;
		UnityUtils.DrawCircleRadius(position, maxRange, new Color(0.2f, 0.2f, 0.2f, 0.8f), new Color(0f, 0f, 0f, 0.2f), "Tether Range");
	}
}
