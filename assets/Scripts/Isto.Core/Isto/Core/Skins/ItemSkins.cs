using System;
using System.Collections.Generic;

namespace Isto.Core.Skins;

[Serializable]
public class ItemSkins
{
	public string internalName;

	public ItemSkinGroup itemGroup;

	public List<SpriteToSwap> spritesToSwap;
}
