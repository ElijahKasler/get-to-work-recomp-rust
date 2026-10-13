using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using UnityEngine;

namespace Rewired;

[Serializable]
public sealed class InputMapCategory : InputCategory
{
	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool _checkConflictsWithAllCategories;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private List<int> _checkConflictsCategoryIds;

	private ReadOnlyCollection<int> _checkConflictsCategoryIds_readOnly;

	string InputCategory.keyCategory => get_keyCategory();

	public bool checkConflictsWithAllCategories
	{
		get
		{
			return _checkConflictsWithAllCategories;
		}
		internal set
		{
			jfsPfvRGLdBSucaZPLwuaeVJjtNHc(flag);
		}
	}

	public IList<int> checkConflictsCategoryIds => _checkConflictsCategoryIds_readOnly;

	internal List<int> sBcMCJdiAwwhPTQwVgTdKaurzpny => cRxpYSLLmekrJJbrwZQuGJpPWkqn();

	internal string get_keyCategory()
	{
		return "controller_map/category";
	}

	internal void jfsPfvRGLdBSucaZPLwuaeVJjtNHc(bool P_0)
	{
		_checkConflictsWithAllCategories = P_0;
	}

	internal List<int> cRxpYSLLmekrJJbrwZQuGJpPWkqn()
	{
		return _checkConflictsCategoryIds;
	}

	public InputMapCategory()
	{
		_checkConflictsCategoryIds = new List<int>();
	}

	public InputMapCategory(InputMapCategory P_0)
		: base(P_0)
	{
		_checkConflictsWithAllCategories = P_0._checkConflictsWithAllCategories;
		_checkConflictsCategoryIds = ListTools.ShallowCopy(P_0._checkConflictsCategoryIds);
	}

	internal void SayQxkSuYcjRfdOFmCskjbnTgJGB()
	{
		base.wRAchoXuDDGYINIYyZGdMXMtFbQA();
		if (_checkConflictsCategoryIds != null)
		{
			_checkConflictsCategoryIds_readOnly = new ReadOnlyCollection<int>(_checkConflictsCategoryIds);
		}
	}

	internal void LjvUHcQSBlwsLhmivFDTqGGdcbUt()
	{
		base.SkkZIQRqVtCXPJovgsaAYArhyqOe();
	}
}
