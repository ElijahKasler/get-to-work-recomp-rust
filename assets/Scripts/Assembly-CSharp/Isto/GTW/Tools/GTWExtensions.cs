using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Isto.GTW.Tools;

public static class GTWExtensions
{
	[Serializable]
	public struct Location(Vector3 position, Quaternion rotation)
	{
		public Vector3 Position = position;

		public Quaternion Rotation = rotation;
	}

	public class DictionaryComparer<TKey, TValue> : IEqualityComparer<Dictionary<TKey, TValue>>
	{
		public bool Equals(Dictionary<TKey, TValue> x, Dictionary<TKey, TValue> y)
		{
			if (x.Count == y.Count)
			{
				return !x.Except(y).Any();
			}
			return false;
		}

		public int GetHashCode(Dictionary<TKey, TValue> obj)
		{
			int num = 0;
			foreach (KeyValuePair<TKey, TValue> item in obj)
			{
				num ^= item.GetHashCode();
			}
			return num;
		}
	}

	private static readonly System.Random random = new System.Random();

	public static float Spring(float currentValue, float targetValue, ref float velocity, float deltaTime, float damping = 0.1f, float stiffness = 1f, float valueThreshold = 0.001f, float velocityThreshold = 0.001f)
	{
		float num = Mathf.Max(0f, 1f - damping * deltaTime);
		float num2 = (targetValue - currentValue) * stiffness * deltaTime;
		velocity = velocity * num + num2;
		currentValue += velocity * deltaTime;
		if (Mathf.Abs(currentValue - targetValue) < valueThreshold && Mathf.Abs(velocity) < velocityThreshold)
		{
			currentValue = targetValue;
			velocity = 0f;
		}
		return currentValue;
	}

	public static string RandomString(int length)
	{
		return new string((from s in Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", length)
			select s[random.Next(s.Length)]).ToArray());
	}
}
