using System.Linq;
using UnityEngine;

namespace Isto.GTW.SectionLoading;

public class LevelSection : MonoBehaviour
{
	[SerializeField]
	private Bounds _bounds;

	[SerializeField]
	private Transform _loadBoundsColliders;

	[SerializeField]
	private Transform _unloadBoundsColliders;

	[SerializeField]
	private Transform _ignoreUnloadBoundsColliders;

	[Space]
	[SerializeField]
	private bool _alwaysLoaded;

	[Space]
	[SerializeField]
	private Color _boundsGizmoColor = new Color(1f, 1f, 0f, 0.1f);

	[SerializeField]
	private Color _loadBoundsGizmoColor = new Color(0.5f, 1f, 0f, 0.1f);

	[SerializeField]
	private Color _unloadBoundsGizmoColor = new Color(1f, 0.5f, 0f, 0.1f);

	[SerializeField]
	private Color _ignoreUnloadBoundsGizmoColor = new Color(0f, 0.5f, 1f, 0.1f);

	public Bounds Bounds => _bounds;

	public Bounds[] LoadBounds
	{
		get
		{
			if (!(_loadBoundsColliders != null))
			{
				return new Bounds[0];
			}
			return (from x in _loadBoundsColliders.GetComponents<BoxCollider>()
				select x.bounds).ToArray();
		}
	}

	public Bounds[] UnloadBounds
	{
		get
		{
			if (!(_unloadBoundsColliders != null))
			{
				return new Bounds[0];
			}
			return (from x in _unloadBoundsColliders.GetComponents<BoxCollider>()
				select x.bounds).ToArray();
		}
	}

	public Bounds[] IgnoreUnloadBounds
	{
		get
		{
			if (!(_ignoreUnloadBoundsColliders != null))
			{
				return new Bounds[0];
			}
			return (from x in _ignoreUnloadBoundsColliders.GetComponents<BoxCollider>()
				select x.bounds).ToArray();
		}
	}

	public bool AlwaysLoaded => _alwaysLoaded;

	private void OnValidate()
	{
		int num = LayerMask.NameToLayer("Ignore Raycast");
		if (_loadBoundsColliders != null && _loadBoundsColliders.gameObject.layer != num)
		{
			_loadBoundsColliders.gameObject.layer = num;
		}
		if (_unloadBoundsColliders != null && _unloadBoundsColliders.gameObject.layer != num)
		{
			_unloadBoundsColliders.gameObject.layer = num;
		}
		if (_ignoreUnloadBoundsColliders != null && _ignoreUnloadBoundsColliders.gameObject.layer != num)
		{
			_ignoreUnloadBoundsColliders.gameObject.layer = num;
		}
	}

	private void Awake()
	{
		if (_loadBoundsColliders != null)
		{
			_loadBoundsColliders.gameObject.SetActive(value: false);
		}
		if (_unloadBoundsColliders != null)
		{
			_unloadBoundsColliders.gameObject.SetActive(value: false);
		}
		if (_ignoreUnloadBoundsColliders != null)
		{
			_ignoreUnloadBoundsColliders.gameObject.SetActive(value: false);
		}
	}

	public void UpdateBounds()
	{
		Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
		if (componentsInChildren.Length != 0)
		{
			Bounds bounds = componentsInChildren[0].bounds;
			Renderer[] array = componentsInChildren;
			foreach (Renderer renderer in array)
			{
				bounds.Encapsulate(renderer.bounds);
			}
			_bounds = bounds;
			SetDirtyIfNotPlaying();
		}
		else
		{
			Debug.LogError("No child mesh found to update bounds.", base.gameObject);
		}
	}

	private void SetDirtyIfNotPlaying()
	{
	}

	private void OnDrawGizmosSelected()
	{
		if (!DrawLoadBounds() || !DrawUnloadBounds() || !DrawIgnoreUnloadBounds())
		{
			DrawBounds();
		}
	}

	public void DrawBounds()
	{
		Gizmos.color = _boundsGizmoColor;
		Gizmos.DrawCube(_bounds.center, _bounds.size);
		Color boundsGizmoColor = _boundsGizmoColor;
		boundsGizmoColor.a = 1f;
		Gizmos.color = boundsGizmoColor;
		Gizmos.DrawWireCube(_bounds.center, _bounds.size);
	}

	public bool DrawLoadBounds()
	{
		bool result = false;
		if (_loadBoundsColliders != null)
		{
			BoxCollider[] componentsInChildren = _loadBoundsColliders.GetComponentsInChildren<BoxCollider>(includeInactive: true);
			foreach (BoxCollider boxCollider in componentsInChildren)
			{
				Gizmos.color = _loadBoundsGizmoColor;
				Gizmos.DrawCube(boxCollider.bounds.center, boxCollider.bounds.size);
				Color loadBoundsGizmoColor = _loadBoundsGizmoColor;
				loadBoundsGizmoColor.a = 1f;
				Gizmos.color = loadBoundsGizmoColor;
				Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.bounds.size);
				result = true;
			}
		}
		return result;
	}

	public bool DrawUnloadBounds()
	{
		bool result = false;
		if (_unloadBoundsColliders != null)
		{
			BoxCollider[] componentsInChildren = _unloadBoundsColliders.GetComponentsInChildren<BoxCollider>(includeInactive: true);
			foreach (BoxCollider boxCollider in componentsInChildren)
			{
				Gizmos.color = _unloadBoundsGizmoColor;
				Gizmos.DrawCube(boxCollider.bounds.center, boxCollider.bounds.size);
				Color unloadBoundsGizmoColor = _unloadBoundsGizmoColor;
				unloadBoundsGizmoColor.a = 1f;
				Gizmos.color = unloadBoundsGizmoColor;
				Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.bounds.size);
				result = true;
			}
		}
		return result;
	}

	public bool DrawIgnoreUnloadBounds()
	{
		bool result = false;
		if (_ignoreUnloadBoundsColliders != null)
		{
			BoxCollider[] componentsInChildren = _ignoreUnloadBoundsColliders.GetComponentsInChildren<BoxCollider>(includeInactive: true);
			foreach (BoxCollider boxCollider in componentsInChildren)
			{
				Gizmos.color = _ignoreUnloadBoundsGizmoColor;
				Gizmos.DrawCube(boxCollider.bounds.center, boxCollider.bounds.size);
				Color ignoreUnloadBoundsGizmoColor = _ignoreUnloadBoundsGizmoColor;
				ignoreUnloadBoundsGizmoColor.a = 1f;
				Gizmos.color = ignoreUnloadBoundsGizmoColor;
				Gizmos.DrawWireCube(boxCollider.bounds.center, boxCollider.bounds.size);
				result = true;
			}
		}
		return result;
	}
}
