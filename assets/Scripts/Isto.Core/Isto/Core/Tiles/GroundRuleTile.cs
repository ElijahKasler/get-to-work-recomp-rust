using System.Collections.Generic;
using UnityEngine;

namespace Isto.Core.Tiles;

[CreateAssetMenu(fileName = "New Ground Rule Tile", menuName = "Scriptables/Tilemap/GroundRuleTile")]
public class GroundRuleTile : RuleTile
{
	public Environment.GroundType groundType;

	public bool navigatable = true;

	public List<Sprite> GetAllValidSprites()
	{
		List<Sprite> list = new List<Sprite>();
		for (int i = 0; i < m_TilingRules.Count; i++)
		{
			list.AddRange(m_TilingRules[i].m_Sprites);
		}
		if (m_DefaultSprite != null)
		{
			list.Add(m_DefaultSprite);
		}
		return list;
	}
}
