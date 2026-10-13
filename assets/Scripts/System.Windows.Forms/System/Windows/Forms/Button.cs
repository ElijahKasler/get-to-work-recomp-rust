using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using Unity;

namespace System.Windows.Forms;

[Designer("System.Windows.Forms.Design.ButtonBaseDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.IDesigner")]
[ComVisible(true)]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
public class Button : ButtonBase, IButtonControl
{
	private DialogResult dialog_result;

	[Browsable(true)]
	[Localizable(true)]
	[DefaultValue(AutoSizeMode.GrowOnly)]
	[MWFCategory("Layout")]
	public AutoSizeMode AutoSizeMode
	{
		get
		{
			return GetAutoSizeMode();
		}
		set
		{
			SetAutoSizeMode(value);
		}
	}

	[MWFCategory("Behavior")]
	[DefaultValue(DialogResult.None)]
	public virtual DialogResult DialogResult
	{
		get
		{
			return dialog_result;
		}
		set
		{
			dialog_result = value;
		}
	}

	protected override CreateParams CreateParams => base.CreateParams;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public new event EventHandler DoubleClick
	{
		add
		{
			base.DoubleClick += value;
		}
		remove
		{
			base.DoubleClick -= value;
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public new event MouseEventHandler MouseDoubleClick
	{
		add
		{
			base.MouseDoubleClick += value;
		}
		remove
		{
			base.MouseDoubleClick -= value;
		}
	}

	public Button()
	{
		dialog_result = DialogResult.None;
		SetStyle(ControlStyles.StandardDoubleClick, value: false);
	}

	public virtual void NotifyDefault(bool value)
	{
		base.IsDefault = value;
	}

	public void PerformClick()
	{
		if (base.CanSelect)
		{
			OnClick(EventArgs.Empty);
		}
	}

	public override string ToString()
	{
		return base.ToString() + ", Text: " + Text;
	}

	protected override void OnClick(EventArgs e)
	{
		Form form = FindForm();
		if (form != null)
		{
			form.dialog_result_changed = false;
			base.OnClick(e);
			if (dialog_result != DialogResult.None && !form.dialog_result_changed)
			{
				form.DialogResult = dialog_result;
			}
		}
		else
		{
			base.OnClick(e);
		}
	}

	protected override void OnFontChanged(EventArgs e)
	{
		base.OnFontChanged(e);
	}

	protected override void OnMouseEnter(EventArgs e)
	{
		base.OnMouseEnter(e);
	}

	protected override void OnMouseLeave(EventArgs e)
	{
		base.OnMouseLeave(e);
	}

	protected override void OnMouseUp(MouseEventArgs mevent)
	{
		base.OnMouseUp(mevent);
	}

	protected override void OnTextChanged(EventArgs e)
	{
		base.OnTextChanged(e);
	}

	protected override bool ProcessMnemonic(char charCode)
	{
		if (base.UseMnemonic && Control.IsMnemonic(charCode, Text))
		{
			PerformClick();
			return true;
		}
		return base.ProcessMnemonic(charCode);
	}

	protected override void WndProc(ref Message m)
	{
		base.WndProc(ref m);
	}

	internal override void Draw(PaintEventArgs pevent)
	{
		if (base.FlatStyle == FlatStyle.System)
		{
			base.Draw(pevent);
			return;
		}
		ThemeEngine.Current.CalculateButtonTextAndImageLayout(pevent.Graphics, this, out var textRectangle, out var imageRectangle);
		if (base.FlatStyle == FlatStyle.Standard)
		{
			ThemeEngine.Current.DrawButton(pevent.Graphics, this, textRectangle, imageRectangle, pevent.ClipRectangle);
		}
		else if (base.FlatStyle == FlatStyle.Flat)
		{
			ThemeEngine.Current.DrawFlatButton(pevent.Graphics, this, textRectangle, imageRectangle, pevent.ClipRectangle);
		}
		else if (base.FlatStyle == FlatStyle.Popup)
		{
			ThemeEngine.Current.DrawPopupButton(pevent.Graphics, this, textRectangle, imageRectangle, pevent.ClipRectangle);
		}
	}

	internal override Size GetPreferredSizeCore(Size proposedSize)
	{
		Size result = ((!AutoSize) ? base.GetPreferredSizeCore(proposedSize) : ThemeEngine.Current.CalculateButtonAutoSize(this));
		if (AutoSizeMode == AutoSizeMode.GrowOnly)
		{
			result = new Size(Math.Max(result.Width, base.Width), Math.Max(result.Height, base.Height));
		}
		return result;
	}

	protected override void RescaleConstantsForDpi(int deviceDpiOld, int deviceDpiNew)
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}
}
