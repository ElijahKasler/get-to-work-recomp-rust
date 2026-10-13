using System;
using UPool;
using UnityEngine;

namespace Isto.Core.Pooling;

public class FlexiblePool<T> : AbstractPool where T : IPoolable
{
	public static readonly Vector3 AUTO_CONTAINER_POSITION = new Vector3(-9999f, 0f, 0f);

	private Transform _container;

	private bool _isGameObject;

	public Transform Container => _container;

	public override Type PoolType => typeof(T);

	public FlexiblePool(int initialSize)
	{
		if (typeof(MonoBehaviour).IsAssignableFrom(typeof(T)))
		{
			throw new ArgumentException($"Type {typeof(T).ToString()} derives from MonoBehaviour. In order to Pool MonoBehaviours you must provide a template; use Pool(int, GameObject).");
		}
		_generator = new DefaultGenerator<T>(this);
		InitializePool(initialSize);
	}

	public FlexiblePool(int initialSize, GameObject template, Transform container = null, bool hideContainerInHierarchy = true)
	{
		if (!typeof(MonoBehaviour).IsAssignableFrom(typeof(T)))
		{
			throw new ArgumentException($"Type {typeof(T).ToString()} does not derive from MonoBehaviour. In order to Pool GameObjects, T should be a MonoBehaviour derivative.");
		}
		if (template == null)
		{
			throw new ArgumentException("The template GameObject cannot be null.");
		}
		if (template.GetComponent<T>() == null)
		{
			throw new ArgumentException($"The template GameObject must have a Component of type {typeof(T).ToString()}");
		}
		_container = ((container != null) ? container : CreateContainer(template.name));
		if (hideContainerInHierarchy)
		{
			_container.hideFlags = HideFlags.HideInHierarchy;
		}
		_generator = new UnityGenerator(this, template, _container);
		_isGameObject = true;
		InitializePool(initialSize);
	}

	public new T Acquire()
	{
		T val = (T)base.Acquire();
		if (_isGameObject)
		{
			Transform transform = (val as MonoBehaviour).transform;
			transform.SetParent(null);
			transform.rotation = Quaternion.identity;
			transform.localScale = Vector3.one;
			transform.position = Vector3.up * -5f;
		}
		return val;
	}

	public override void Recycle(IPoolable obj)
	{
		base.Recycle(obj);
		if (_isGameObject)
		{
			Transform transform = (obj as MonoBehaviour).transform;
			transform.SetParent(_container);
			transform.localPosition = Vector3.up * -5f;
		}
	}

	public override void Destroy()
	{
		base.Destroy();
		if (_container != null)
		{
			UnityEngine.Object.Destroy(_container.gameObject);
		}
	}

	public override void DestroyAndDeallocateAll()
	{
		base.DestroyAndDeallocateAll();
		if (_container != null)
		{
			UnityEngine.Object.Destroy(_container.gameObject);
		}
	}

	private Transform CreateContainer(string objectName)
	{
		GameObject gameObject = new GameObject($"{objectName}Pool");
		gameObject.transform.position = AUTO_CONTAINER_POSITION;
		return gameObject.transform;
	}
}
