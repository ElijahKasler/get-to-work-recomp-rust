using System;
using UnityEngine;

namespace Isto.Core.Enums;

public class EnumDropdownAttribute : PropertyAttribute
{
	public Type type;

	public EnumDropdownAttribute(Type t)
	{
		type = t;
	}
}
