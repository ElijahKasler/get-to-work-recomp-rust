using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core;

public class Identifier : MonoBehaviour
{
	public enum IdentifierFlags
	{
		None = 0,
		MiniDeer = 1,
		PushbackRegular = 2,
		PushbackAttackWave = 4,
		PushbackStampede = 8,
		AllPushbacks = 14,
		Tornatoad = 16,
		PopBox = 32,
		BoxMonster = 64,
		PickerPal = 128,
		AllCreatures = 255,
		SomethingElse = 1024,
		Everything = -1
	}

	protected static Dictionary<IdentifierFlags, List<GameObject>> _cache = new Dictionary<IdentifierFlags, List<GameObject>>();

	[SerializeField]
	protected IdentifierFlags _flag;

	public IdentifierFlags Flag => _flag;

	public static List<GameObject> GetGameObjectsForSingleFlag(IdentifierFlags flag)
	{
		return _cache[flag];
	}

	private void Start()
	{
		if (!_cache.ContainsKey(_flag))
		{
			_cache.Add(_flag, new List<GameObject>());
		}
		_cache[_flag].Add(base.gameObject);
	}

	private void OnDestroy()
	{
		_cache[_flag].Remove(base.gameObject);
	}
}
