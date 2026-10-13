using System;
using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Items;

[CreateAssetMenu(fileName = "Tile Spawn Rules", menuName = "Scriptables/Tilemap/TileSpawnRules")]
public class TileSpriteSpawnRules : ScriptableObject
{
	[Serializable]
	public class SpriteRule
	{
		public string name;

		public List<Sprite> validSprites;
	}

	public List<SpriteRule> spriteRules;

	private HashSet<Sprite> _validSprites = new HashSet<Sprite>();

	public bool IsValidSpriteToSpawnOn(Sprite sprite)
	{
		if (_validSprites.Count == 0)
		{
			InitializeSpriteHash();
		}
		return _validSprites.Contains(sprite);
	}

	private void InitializeSpriteHash()
	{
		for (int i = 0; i < spriteRules.Count; i++)
		{
			SpriteRule spriteRule = spriteRules[i];
			for (int j = 0; j < spriteRule.validSprites.Count; j++)
			{
				_validSprites.Add(spriteRule.validSprites[j]);
			}
		}
	}
}
