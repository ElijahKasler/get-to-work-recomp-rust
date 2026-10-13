using System;

namespace Rewired;

[Serializable]
public sealed class InputActionCategory : InputCategory
{
	string InputCategory.keyCategory => get_keyCategory();

	internal string get_keyCategory()
	{
		return "action/category";
	}

	public InputActionCategory()
	{
	}

	public InputActionCategory(InputActionCategory P_0)
		: base(P_0)
	{
	}
}
