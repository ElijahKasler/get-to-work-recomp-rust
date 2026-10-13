using System;
using System.Collections.Generic;
using Isto.Core.Items;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Isto.Core.Pooling;

[CreateAssetMenu(fileName = "New PoolingConfigurationSettings", menuName = "Scriptables/Pooling Configuration")]
public class PoolingConfiguration : ScriptableObject
{
	[Serializable]
	public class PooledItemConfiguration
	{
		public string internalName;

		public Item item;

		public int startingAmount;
	}

	public AssetReference coreItemAddressable;

	public int coreItemPoolStartingAmount = 20;

	public List<PooledItemConfiguration> ItemPools;
}
