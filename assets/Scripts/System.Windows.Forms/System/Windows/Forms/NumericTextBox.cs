namespace System.Windows.Forms;

internal class NumericTextBox : TextBox
{
	private double val;

	private double min;

	private static object ValueChangedEvent = new object();

	public double Value
	{
		get
		{
			return val;
		}
		set
		{
			if (value != val)
			{
				if (value < min)
				{
					value = min;
				}
				val = value;
				OnValueChanged(EventArgs.Empty);
			}
		}
	}

	public double Min
	{
		get
		{
			return min;
		}
		set
		{
			min = value;
		}
	}

	public event EventHandler ValueChanged
	{
		add
		{
			base.Events.AddHandler(ValueChangedEvent, value);
		}
		remove
		{
			base.Events.RemoveHandler(ValueChangedEvent, value);
		}
	}

	protected override void OnLostFocus(EventArgs args)
	{
		string text = Value.ToString();
		if (Text != text)
		{
			Text = text;
		}
		base.OnLostFocus(args);
	}

	protected override void OnTextChanged(EventArgs args)
	{
		try
		{
			double value = double.Parse((Text.Length == 0) ? "0" : Text);
			Value = value;
		}
		catch (FormatException)
		{
		}
		catch (OverflowException)
		{
		}
		base.OnTextChanged(args);
	}

	protected override void OnKeyPress(KeyPressEventArgs args)
	{
		if ("\b.01234567890".IndexOf(args.KeyChar) < 0)
		{
			args.Handled = true;
		}
		base.OnKeyPress(args);
	}

	protected virtual void OnValueChanged(EventArgs args)
	{
		((EventHandler)base.Events[ValueChangedEvent])?.Invoke(this, args);
	}
}
