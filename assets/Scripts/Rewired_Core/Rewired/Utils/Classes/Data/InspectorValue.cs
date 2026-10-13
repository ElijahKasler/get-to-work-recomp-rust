using System.Collections.Generic;
using System.ComponentModel;

namespace Rewired.Utils.Classes.Data;

[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class InspectorValue<T>
{
	private T vBgFvFgvVIJLIaxiGuTLPoulaPwQ;

	private bool FAdbXTjZFDKTTtNhyGqKseDjdvaf;

	public bool isSet => FAdbXTjZFDKTTtNhyGqKseDjdvaf;

	public T value
	{
		get
		{
			return vBgFvFgvVIJLIaxiGuTLPoulaPwQ;
		}
		set
		{
			vBgFvFgvVIJLIaxiGuTLPoulaPwQ = value;
			FAdbXTjZFDKTTtNhyGqKseDjdvaf = true;
		}
	}

	public bool SetIfChanged(T value)
	{
		if (!FAdbXTjZFDKTTtNhyGqKseDjdvaf)
		{
			this.value = value;
			return false;
		}
		if (!EqualityComparer<T>.Default.Equals(vBgFvFgvVIJLIaxiGuTLPoulaPwQ, value))
		{
			this.value = value;
			return true;
		}
		return false;
	}

	public void Clear()
	{
		FAdbXTjZFDKTTtNhyGqKseDjdvaf = false;
		vBgFvFgvVIJLIaxiGuTLPoulaPwQ = default;
	}
}
