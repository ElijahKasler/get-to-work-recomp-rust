using System.Collections.Generic;

namespace UnityEngine.UIElements.Layout;

internal class ManagedObjectStore<T> where T : class
{
	private const int k_ChunkSize = 2048;

	private int m_Length;

	private readonly List<T[]> m_Chunks;

	private readonly Queue<int> m_Free;

	public ManagedObjectStore()
	{
		m_Chunks = new List<T[]> { new T[2048] };
		m_Length = 1;
		m_Free = new Queue<int>();
	}

	public T GetValue(int index)
	{
		if (index == 0)
		{
			return null;
		}
		int index2 = index / 2048;
		int num = index % 2048;
		return m_Chunks[index2][num];
	}

	public void UpdateValue(ref int index, T value)
	{
		if (index != 0)
		{
			if (value != null)
			{
				int index2 = index / 2048;
				int num = index % 2048;
				m_Chunks[index2][num] = value;
			}
			else
			{
				m_Free.Enqueue(index);
				int index3 = index / 2048;
				int num2 = index % 2048;
				m_Chunks[index3][num2] = null;
				index = 0;
			}
		}
		else
		{
			if (value == null)
			{
				return;
			}
			if (m_Free.Count > 0)
			{
				index = m_Free.Dequeue();
				int index4 = index / 2048;
				int num3 = index % 2048;
				m_Chunks[index4][num3] = value;
				return;
			}
			index = m_Length++;
			if (index >= m_Chunks.Count * 2048)
			{
				m_Chunks.Add(new T[2048]);
			}
			int index5 = index / 2048;
			int num4 = index % 2048;
			m_Chunks[index5][num4] = value;
		}
	}
}
