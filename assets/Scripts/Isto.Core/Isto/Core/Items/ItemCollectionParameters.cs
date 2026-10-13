using System;
using UnityEngine;

namespace Isto.Core.Items;

[Serializable]
public class ItemCollectionParameters
{
	public AnimationCurve movementCurve;

	public float moveTime = 0.25f;
}
