using System;
using UnityEngine;

namespace Rewired.Utils.Attributes;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class FieldRangeAttribute : PropertyAttribute
{
	private float ulZfmuaASAgNHpREbnQNAskrUnkyA;

	private float luadOochskqimfiLILyMmBgZzwlIA;

	private int UrjSGrtJhcDOqygWCjpDzENlbIzV;

	private int eLuCOSkHlZpTwwDQxwLrwEiQRZVnA;

	public float minFloat => ulZfmuaASAgNHpREbnQNAskrUnkyA;

	public float maxFloat => luadOochskqimfiLILyMmBgZzwlIA;

	public int minInt => UrjSGrtJhcDOqygWCjpDzENlbIzV;

	public int maxInt => eLuCOSkHlZpTwwDQxwLrwEiQRZVnA;

	public FieldRangeAttribute(float P_0, float P_1)
	{
		ulZfmuaASAgNHpREbnQNAskrUnkyA = P_0;
		luadOochskqimfiLILyMmBgZzwlIA = P_1;
		UrjSGrtJhcDOqygWCjpDzENlbIzV = (int)P_0;
		eLuCOSkHlZpTwwDQxwLrwEiQRZVnA = (int)P_1;
	}

	public FieldRangeAttribute(int P_0, int P_1)
	{
		UrjSGrtJhcDOqygWCjpDzENlbIzV = P_0;
		eLuCOSkHlZpTwwDQxwLrwEiQRZVnA = P_1;
		ulZfmuaASAgNHpREbnQNAskrUnkyA = P_0;
		luadOochskqimfiLILyMmBgZzwlIA = P_1;
	}
}
