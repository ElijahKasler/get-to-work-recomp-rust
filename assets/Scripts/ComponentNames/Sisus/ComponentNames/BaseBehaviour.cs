using UnityEngine;

namespace Sisus.ComponentNames;

public abstract class BaseBehaviour : MonoBehaviour
{
	public new virtual string name
	{
		get
		{
			return this.GetName();
		}
		set
		{
		}
	}

	public override string ToString()
	{
		return this.GetName();
	}
}
