using System.Collections.Generic;
using System.Linq;

namespace ModestTree;

public static class MiscExtensions
{
	public static string Fmt(this string s, params object[] args)
	{
		return string.Format(s, args);
	}

	public static IEnumerable<T> Yield<T>(this T item)
	{
		yield return item;
	}

	public static string Join(this IEnumerable<string> values, string separator)
	{
		return string.Join(separator, values.ToArray());
	}

	public static void RemoveWithConfirm<T>(this IList<T> list, T item)
	{
		Assert.That(list.Remove(item));
	}

	public static void RemoveWithConfirm<T>(this LinkedList<T> list, T item)
	{
		Assert.That(list.Remove(item));
	}

	public static void RemoveWithConfirm<TKey, TVal>(this IDictionary<TKey, TVal> dictionary, TKey key)
	{
		Assert.That(dictionary.Remove(key));
	}

	public static void RemoveWithConfirm<T>(this HashSet<T> set, T item)
	{
		Assert.That(set.Remove(item));
	}

	public static TVal GetValueAndRemove<TKey, TVal>(this IDictionary<TKey, TVal> dictionary, TKey key)
	{
		TVal result = dictionary[key];
		dictionary.RemoveWithConfirm(key);
		return result;
	}
}
