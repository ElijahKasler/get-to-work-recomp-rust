using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Isto.Core.UI;

public class UIAccessManager
{
	[Flags]
	public enum CanvasGroupId
	{
		None = 0,
		SceneBlackOut = 1,
		UIGameplay = 0x20,
		UIGameplayHideInDark = 0x40,
		UIGameplayIndependent = 0x400,
		UIGameplayIndependentHideInDark = 0x800,
		UIEquipMenu = 0x8000,
		UIEquipMenuItems = 0x10000,
		UIInitial = UIGameplay | UIGameplayIndependent | UIEquipMenu,
		TutorialActionText = 0x40000000,
		Tutorial = int.MinValue,
		HUDGroups = Tutorial | UIInitial,
		All = -1
	}

	private static readonly int CANVASGROUP_FLAG_BITCOUNT = 32;

	private List<CanvasGroupId> _allIndividualFlags = Enum.GetValues(typeof(CanvasGroupId)).Cast<CanvasGroupId>().ToList();

	private Dictionary<CanvasGroupId, CanvasGroup> _canvasGroups;

	[Inject]
	public void Inject([Inject(Id = "SceneBlackOut")] CanvasGroup sceneBlackOut, [Inject(Id = "UIGameplay")] CanvasGroup gameplayUI)
	{
		_canvasGroups = new Dictionary<CanvasGroupId, CanvasGroup>();
		_canvasGroups.Add(CanvasGroupId.SceneBlackOut, sceneBlackOut);
		_canvasGroups.Add(CanvasGroupId.UIGameplay, gameplayUI);
	}

	public CanvasGroup GetSingleCanvasGroup(CanvasGroupId target)
	{
		return _canvasGroups[target];
	}

	public List<CanvasGroup> GetCanvasGroups(CanvasGroupId targetCanvasFlags)
	{
		List<CanvasGroup> list = new List<CanvasGroup>();
		for (int i = 0; i < CANVASGROUP_FLAG_BITCOUNT; i++)
		{
			CanvasGroupId canvasGroupId = (CanvasGroupId)(1L << i);
			if (_allIndividualFlags.Contains(canvasGroupId) && targetCanvasFlags.HasFlag(canvasGroupId) && _canvasGroups.ContainsKey(canvasGroupId))
			{
				list.Add(_canvasGroups[canvasGroupId]);
			}
		}
		return list;
	}
}
