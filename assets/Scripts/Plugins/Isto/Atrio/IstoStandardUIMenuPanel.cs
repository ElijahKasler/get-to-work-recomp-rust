using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Isto.Atrio;

public class IstoStandardUIMenuPanel : StandardUIMenuPanel
{
	private GameObject responseObjs;

	protected override void SetResponseButtons(Response[] responses, Transform target)
	{
		for (int i = 0; i < responses.Length; i++)
		{
		}
		Object.Instantiate(singleResponsePrefab, responeParentObj);
	}
}
