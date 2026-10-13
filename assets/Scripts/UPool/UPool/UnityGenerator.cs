using UnityEngine;

namespace UPool;

public class UnityGenerator : IGenerator
{
	private AbstractPool _owner;

	private GameObject _template;

	private Transform _container;

	public UnityGenerator(AbstractPool owner, GameObject template, Transform container)
	{
		_owner = owner;
		_template = template;
		_container = container;
	}

	public IPoolable CreateInstance()
	{
		GameObject gameObject = Object.Instantiate(_template, _container);
		gameObject.transform.localPosition = Vector3.zero;
		return gameObject.GetComponent<IPoolable>();
	}
}
