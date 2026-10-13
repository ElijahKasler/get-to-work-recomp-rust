using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UnityEngine.Rendering;

public struct Observable<T>
{
	private T m_Value;

	public T value
	{
		get
		{
			return m_Value;
		}
		set
		{
			if (!EqualityComparer<T>.Default.Equals(value, m_Value))
			{
				m_Value = value;
				System.Runtime.CompilerServices.Unsafe.As<Observable<T>, Observable<>>(ref this).onValueChanged?.Invoke(value);
			}
		}
	}

	public event Action<T> onValueChanged;

	public Observable(T newValue)
	{
		m_Value = newValue;
		System.Runtime.CompilerServices.Unsafe.As<Observable<T>, Observable<>>(ref this).onValueChanged = null;
	}
}
