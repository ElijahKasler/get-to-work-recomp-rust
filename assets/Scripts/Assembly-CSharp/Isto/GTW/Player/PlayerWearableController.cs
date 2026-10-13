using System;
using System.Collections.Generic;
using Isto.GTW.LevelFeatures.Wearables;
using UnityEngine;
using Zenject;

namespace Isto.GTW.Player;

public class PlayerWearableController : MonoBehaviour
{
	public enum BodyPart
	{
		None = 0,
		Head = 1,
		LeftArm = 2,
		RightArm = 3,
		Torso = 4
	}

	[Serializable]
	public class BodyPartTransform
	{
		public BodyPart BodyPart;

		public Transform BodyPartModelTransform;
	}

	[SerializeField]
	private List<BodyPartTransform> _bodyPartList = new List<BodyPartTransform>();

	[SerializeField]
	private List<CharacterWearableData> _wearableDataList = new List<CharacterWearableData>();

	private Dictionary<BodyPart, Transform> _bodyPartTransforms = new Dictionary<BodyPart, Transform>();

	private GTWGameStats _gtwGameStats;

	[Inject]
	private void Inject(GTWGameStats gtwGameStats)
	{
		_gtwGameStats = gtwGameStats;
	}

	private void Awake()
	{
		foreach (BodyPartTransform bodyPart in _bodyPartList)
		{
			_bodyPartTransforms[bodyPart.BodyPart] = bodyPart.BodyPartModelTransform;
		}
	}

	public void SetCharacterWearablePart(CharacterWearableData newWearableData)
	{
		if (newWearableData == null || !_bodyPartTransforms.TryGetValue(newWearableData.BodyPart, out var value))
		{
			return;
		}
		foreach (Transform item in value)
		{
			UnityEngine.Object.Destroy(item.gameObject);
		}
		if ((bool)newWearableData)
		{
			InstantiateNewWearable(newWearableData, value);
		}
	}

	public void SetCharacterDunceHat(int characterDunceHat)
	{
		if (characterDunceHat > 0)
		{
			SetCharacterWearablePart(_wearableDataList[characterDunceHat]);
		}
	}

	private void InstantiateNewWearable(CharacterWearableData wearableData, Transform parentTransform)
	{
		Transform obj = UnityEngine.Object.Instantiate(wearableData.WearableModel, parentTransform).gameObject.transform;
		obj.localPosition = wearableData.PositionOffset;
		obj.localRotation = Quaternion.Euler(wearableData.RotationOffset);
		obj.localScale = wearableData.ScaleOffset;
	}
}
