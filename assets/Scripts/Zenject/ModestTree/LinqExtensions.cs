using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModestTree.Util;

namespace ModestTree;

public static class LinqExtensions
{
	public static IEnumerable<TSource> TakeUntilInclusive<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		foreach (TSource item in source)
		{
			yield return item;
			if (predicate(item))
			{
				yield break;
			}
		}
	}

	public static TSource OnlyOrDefault<TSource>(this IEnumerable<TSource> source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (source.Count() > 1)
		{
			return default;
		}
		return source.FirstOrDefault();
	}

	public static IEnumerable<T> Reversed<T>(this IEnumerable<T> list)
	{
		return list.Reverse();
	}

	public static IEnumerable<T> Prepend<T>(this IEnumerable<T> first, IEnumerable<T> second)
	{
		foreach (T item in second)
		{
			yield return item;
		}
		foreach (T item2 in first)
		{
			yield return item2;
		}
	}

	public static bool HasAtLeast<T>(this IEnumerable<T> enumerable, int amount)
	{
		return enumerable.Take(amount).Count() == amount;
	}

	public static bool HasMoreThan<T>(this IEnumerable<T> enumerable, int amount)
	{
		return enumerable.HasAtLeast(amount + 1);
	}

	public static bool HasLessThan<T>(this IEnumerable<T> enumerable, int amount)
	{
		return enumerable.HasAtMost(amount - 1);
	}

	public static bool HasAtMost<T>(this IEnumerable<T> enumerable, int amount)
	{
		return enumerable.Take(amount + 1).Count() <= amount;
	}

	public static bool IsEmpty<T>(this IEnumerable<T> enumerable)
	{
		return !enumerable.Any();
	}

	public static IEnumerable<T> GetDuplicates<T>(this IEnumerable<T> list)
	{
		return from x in list
			group x by x into x
			where x.Skip(1).Any()
			select x.Key;
	}

	public static IEnumerable<T> ReplaceOrAppend<T>(this IEnumerable<T> enumerable, Predicate<T> match, T replacement)
	{
		bool replaced = false;
		foreach (T item in enumerable)
		{
			if (match(item))
			{
				replaced = true;
				yield return replacement;
			}
			else
			{
				yield return item;
			}
		}
		if (!replaced)
		{
			yield return replacement;
		}
	}

	public static IEnumerable<T> ToEnumerable<T>(this IEnumerator enumerator)
	{
		while (enumerator.MoveNext())
		{
			yield return (T)enumerator.Current;
		}
	}

	public static IEnumerable<T> ToEnumerable<T>(this IEnumerator<T> enumerator)
	{
		while (enumerator.MoveNext())
		{
			yield return enumerator.Current;
		}
	}

	public static HashSet<T> ToHashSet<T>(this IEnumerable<T> enumerable)
	{
		return new HashSet<T>(enumerable);
	}

	public static bool IsLength<T>(this IEnumerable<T> enumerable, int amount)
	{
		return enumerable.Take(amount + 1).Count() == amount;
	}

	public static IEnumerable<T> Except<T>(this IEnumerable<T> list, T item)
	{
		return list.Except(item.Yield());
	}

	public static T GetSingle<T>(this object[] objectArray, bool required)
	{
		if (required)
		{
			return objectArray.Where((object x) => x is T).Cast<T>().Single();
		}
		return objectArray.Where((object x) => x is T).Cast<T>().SingleOrDefault();
	}

	public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		return source.DistinctBy(keySelector, null);
	}

	public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		if (keySelector == null)
		{
			throw new ArgumentNullException("keySelector");
		}
		return DistinctByImpl(source, keySelector, comparer);
	}

	private static IEnumerable<TSource> DistinctByImpl<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
	{
		HashSet<TKey> knownKeys = new HashSet<TKey>(comparer);
		foreach (TSource item in source)
		{
			if (knownKeys.Add(keySelector(item)))
			{
				yield return item;
			}
		}
	}

	public static T Second<T>(this IEnumerable<T> list)
	{
		return list.Skip(1).First();
	}

	public static T SecondOrDefault<T>(this IEnumerable<T> list)
	{
		return list.Skip(1).FirstOrDefault();
	}

	public static int RemoveAll<T>(this LinkedList<T> list, Func<T, bool> predicate)
	{
		int num = 0;
		LinkedListNode<T> linkedListNode = list.First;
		while (linkedListNode != null)
		{
			if (predicate(linkedListNode.Value))
			{
				LinkedListNode<T> node = linkedListNode;
				linkedListNode = linkedListNode.Next;
				list.Remove(node);
				num++;
			}
			else
			{
				linkedListNode = linkedListNode.Next;
			}
		}
		return num;
	}

	public static bool ContainsItem<T>(this IEnumerable<T> list, T value)
	{
		return list.Where((T x) => object.Equals(x, value)).Any();
	}

	public static IEnumerable<T> Zipper<A, B, T>(this IEnumerable<A> seqA, IEnumerable<B> seqB, Func<A, B, T> func)
	{
		using IEnumerator<A> iteratorA = seqA.GetEnumerator();
		using IEnumerator<B> iteratorB = seqB.GetEnumerator();
		while (true)
		{
			bool num = !iteratorA.MoveNext();
			bool flag = !iteratorB.MoveNext();
			Assert.That(num == flag, "Given collections have different length in Zip operator");
			if (num | flag)
			{
				break;
			}
			yield return func(iteratorA.Current, iteratorB.Current);
		}
	}

	public static IEnumerable<ValuePair<A, B>> Zipper<A, B>(this IEnumerable<A> seqA, IEnumerable<B> seqB)
	{
		return seqA.Zipper(seqB, ValuePair.New);
	}
}
