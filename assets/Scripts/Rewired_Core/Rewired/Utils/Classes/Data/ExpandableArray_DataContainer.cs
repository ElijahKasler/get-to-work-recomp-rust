using System;

namespace Rewired.Utils.Classes.Data;

[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
[CustomObfuscation(rename = false)]
internal class ExpandableArray_DataContainer<T> where T : class, ExpandableArray_DataContainer<T>.gArfAJtfKDFFObFEYRHpYlAKGZlJA, new()
{
	public interface gArfAJtfKDFFObFEYRHpYlAKGZlJA : IComparable<T>
	{
		void sNbwAzJyFLoMSYPmTGreozoZOqtr(T P_0);

		bool dBGHjivPGiePYcDWqHqWDyGcJoJZA(T P_0);

		void VqfAOgAnPvWFimwBqdddjKEXDRCwA();
	}

	public readonly T injector;

	private T[] YWUGoMemLRCifGMgdRMoExHxkHyHc;

	private int LPObEknomXXpOudfhBCpihaiKipeb;

	private int ihixaGcvrUFtofnAfbTsgwsfeZeBb;

	private int nVzXbBGpdWwxTOyiXhZRGWvXUDkG;

	private int iYoVuDruspprEtxLFVgRCvBQNWwr;

	private bool RNGSyxPfwQTzcdKfZKOExGFRTyrD;

	public int Count => LPObEknomXXpOudfhBCpihaiKipeb;

	public int Length => LPObEknomXXpOudfhBCpihaiKipeb;

	public int MaxLength => ihixaGcvrUFtofnAfbTsgwsfeZeBb;

	public int FreeSpace => ihixaGcvrUFtofnAfbTsgwsfeZeBb - LPObEknomXXpOudfhBCpihaiKipeb;

	public T this[int index]
	{
		get
		{
			if (index >= LPObEknomXXpOudfhBCpihaiKipeb)
			{
				throw new IndexOutOfRangeException();
			}
			return YWUGoMemLRCifGMgdRMoExHxkHyHc[index];
		}
	}

	public ExpandableArray_DataContainer(int P_0, bool P_1 = true, int P_2 = 0)
	{
		injector = new T();
		YWUGoMemLRCifGMgdRMoExHxkHyHc = new T[P_0];
		LPObEknomXXpOudfhBCpihaiKipeb = 0;
		ihixaGcvrUFtofnAfbTsgwsfeZeBb = P_0;
		RNGSyxPfwQTzcdKfZKOExGFRTyrD = P_1;
		nVzXbBGpdWwxTOyiXhZRGWvXUDkG = P_2;
		for (int i = 0; i < ihixaGcvrUFtofnAfbTsgwsfeZeBb; i++)
		{
			YWUGoMemLRCifGMgdRMoExHxkHyHc[i] = new T();
		}
	}

	public int Inject()
	{
		int result = AddData(injector);
		if (RNGSyxPfwQTzcdKfZKOExGFRTyrD)
		{
			injector.VqfAOgAnPvWFimwBqdddjKEXDRCwA();
		}
		return result;
	}

	public int InjectIfUnique()
	{
		int result = AddIfUnique(injector);
		if (RNGSyxPfwQTzcdKfZKOExGFRTyrD)
		{
			injector.VqfAOgAnPvWFimwBqdddjKEXDRCwA();
		}
		return result;
	}

	public int AddData(T item)
	{
		if (LPObEknomXXpOudfhBCpihaiKipeb >= ihixaGcvrUFtofnAfbTsgwsfeZeBb)
		{
			if (nVzXbBGpdWwxTOyiXhZRGWvXUDkG <= 0)
			{
				return -1;
			}
			CKzywBTjBeLUDCqyxtChIfTgcMfc();
		}
		int lPObEknomXXpOudfhBCpihaiKipeb = LPObEknomXXpOudfhBCpihaiKipeb;
		YWUGoMemLRCifGMgdRMoExHxkHyHc[lPObEknomXXpOudfhBCpihaiKipeb].sNbwAzJyFLoMSYPmTGreozoZOqtr(item);
		LPObEknomXXpOudfhBCpihaiKipeb = lPObEknomXXpOudfhBCpihaiKipeb + 1;
		return lPObEknomXXpOudfhBCpihaiKipeb;
	}

	public int AddIfUnique(T item)
	{
		int num = IndexOfData(item);
		if (num >= 0)
		{
			return num;
		}
		return AddData(item);
	}

	public bool ContainsData(T item)
	{
		for (int i = 0; i < LPObEknomXXpOudfhBCpihaiKipeb; i++)
		{
			if (YWUGoMemLRCifGMgdRMoExHxkHyHc[i].dBGHjivPGiePYcDWqHqWDyGcJoJZA(item))
			{
				return true;
			}
		}
		return false;
	}

	public int IndexOfData(T item)
	{
		for (int i = 0; i < LPObEknomXXpOudfhBCpihaiKipeb; i++)
		{
			if (YWUGoMemLRCifGMgdRMoExHxkHyHc[i].dBGHjivPGiePYcDWqHqWDyGcJoJZA(item))
			{
				return i;
			}
		}
		return -1;
	}

	public void Clear()
	{
		if (RNGSyxPfwQTzcdKfZKOExGFRTyrD)
		{
			injector.VqfAOgAnPvWFimwBqdddjKEXDRCwA();
			for (int i = 0; i < LPObEknomXXpOudfhBCpihaiKipeb; i++)
			{
				YWUGoMemLRCifGMgdRMoExHxkHyHc[i].VqfAOgAnPvWFimwBqdddjKEXDRCwA();
			}
		}
		LPObEknomXXpOudfhBCpihaiKipeb = 0;
	}

	public void RemoveAt(int index)
	{
		if (index < 0 || index >= LPObEknomXXpOudfhBCpihaiKipeb)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		if (index == LPObEknomXXpOudfhBCpihaiKipeb - 1)
		{
			RemoveLast();
			return;
		}
		if (RNGSyxPfwQTzcdKfZKOExGFRTyrD)
		{
			YWUGoMemLRCifGMgdRMoExHxkHyHc[index].VqfAOgAnPvWFimwBqdddjKEXDRCwA();
		}
		for (int i = index; i < LPObEknomXXpOudfhBCpihaiKipeb - 1; i++)
		{
			YWUGoMemLRCifGMgdRMoExHxkHyHc[i].sNbwAzJyFLoMSYPmTGreozoZOqtr(YWUGoMemLRCifGMgdRMoExHxkHyHc[i + 1]);
		}
		if (RNGSyxPfwQTzcdKfZKOExGFRTyrD)
		{
			YWUGoMemLRCifGMgdRMoExHxkHyHc[LPObEknomXXpOudfhBCpihaiKipeb - 1].VqfAOgAnPvWFimwBqdddjKEXDRCwA();
		}
		LPObEknomXXpOudfhBCpihaiKipeb--;
	}

	public void RemoveLast()
	{
		if (LPObEknomXXpOudfhBCpihaiKipeb != 0)
		{
			if (RNGSyxPfwQTzcdKfZKOExGFRTyrD)
			{
				YWUGoMemLRCifGMgdRMoExHxkHyHc[LPObEknomXXpOudfhBCpihaiKipeb - 1].VqfAOgAnPvWFimwBqdddjKEXDRCwA();
			}
			LPObEknomXXpOudfhBCpihaiKipeb--;
		}
	}

	public void Resize(int size)
	{
		if (size <= 0)
		{
			throw new Exception("Size must be greater than 0.");
		}
		if (size == ihixaGcvrUFtofnAfbTsgwsfeZeBb)
		{
			return;
		}
		T[] array = new T[size];
		int num = Math.Min(size, ihixaGcvrUFtofnAfbTsgwsfeZeBb);
		for (int i = 0; i < num; i++)
		{
			array[i] = YWUGoMemLRCifGMgdRMoExHxkHyHc[i];
		}
		if (size > ihixaGcvrUFtofnAfbTsgwsfeZeBb)
		{
			for (int j = num; j < size; j++)
			{
				array[j] = new T();
			}
		}
		else if (LPObEknomXXpOudfhBCpihaiKipeb > size)
		{
			LPObEknomXXpOudfhBCpihaiKipeb = size;
		}
		ihixaGcvrUFtofnAfbTsgwsfeZeBb = size;
		YWUGoMemLRCifGMgdRMoExHxkHyHc = array;
	}

	public void SortAscending()
	{
		if (LPObEknomXXpOudfhBCpihaiKipeb == 0)
		{
			return;
		}
		for (int i = 0; i < LPObEknomXXpOudfhBCpihaiKipeb - 1; i++)
		{
			for (int j = i + 1; j < LPObEknomXXpOudfhBCpihaiKipeb; j++)
			{
				if (YWUGoMemLRCifGMgdRMoExHxkHyHc[j].CompareTo(YWUGoMemLRCifGMgdRMoExHxkHyHc[i]) < 0)
				{
					T val = YWUGoMemLRCifGMgdRMoExHxkHyHc[i];
					YWUGoMemLRCifGMgdRMoExHxkHyHc[i] = YWUGoMemLRCifGMgdRMoExHxkHyHc[j];
					YWUGoMemLRCifGMgdRMoExHxkHyHc[j] = val;
				}
			}
		}
	}

	public void SortDescending()
	{
		if (LPObEknomXXpOudfhBCpihaiKipeb == 0)
		{
			return;
		}
		for (int i = 0; i < LPObEknomXXpOudfhBCpihaiKipeb - 1; i++)
		{
			for (int j = i + 1; j < LPObEknomXXpOudfhBCpihaiKipeb; j++)
			{
				if (YWUGoMemLRCifGMgdRMoExHxkHyHc[j].CompareTo(YWUGoMemLRCifGMgdRMoExHxkHyHc[i]) > 0)
				{
					T val = YWUGoMemLRCifGMgdRMoExHxkHyHc[i];
					YWUGoMemLRCifGMgdRMoExHxkHyHc[i] = YWUGoMemLRCifGMgdRMoExHxkHyHc[j];
					YWUGoMemLRCifGMgdRMoExHxkHyHc[j] = val;
				}
			}
		}
	}

	private void CKzywBTjBeLUDCqyxtChIfTgcMfc()
	{
		iYoVuDruspprEtxLFVgRCvBQNWwr++;
		Resize(ihixaGcvrUFtofnAfbTsgwsfeZeBb + iYoVuDruspprEtxLFVgRCvBQNWwr * nVzXbBGpdWwxTOyiXhZRGWvXUDkG);
	}
}
