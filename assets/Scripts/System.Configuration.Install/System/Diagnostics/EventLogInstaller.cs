using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Runtime.InteropServices;

namespace System.Diagnostics;

public class EventLogInstaller : ComponentInstaller
{
	private string _log;

	private string _source;

	private UninstallAction _uninstallAction;

	private string _categoryResourceFile;

	private string _messageResourceFile;

	private string _parameterResourceFile;

	[System.MonoTODO]
	[ComVisible(false)]
	public int CategoryCount
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	[System.MonoTODO]
	[Editor("System.Windows.Forms.Design.FileNameEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[TypeConverter("System.Diagnostics.Design.StringValueConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[ComVisible(false)]
	public string CategoryResourceFile
	{
		get
		{
			return _categoryResourceFile;
		}
		set
		{
			_categoryResourceFile = value;
		}
	}

	[TypeConverter("System.Diagnostics.Design.StringValueConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[System.MonoTODO]
	[Editor("System.Windows.Forms.Design.FileNameEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[ComVisible(false)]
	public string MessageResourceFile
	{
		get
		{
			return _messageResourceFile;
		}
		set
		{
			_messageResourceFile = value;
		}
	}

	[ComVisible(false)]
	[System.MonoTODO]
	[Editor("System.Windows.Forms.Design.FileNameEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[TypeConverter("System.Diagnostics.Design.StringValueConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public string ParameterResourceFile
	{
		get
		{
			return _parameterResourceFile;
		}
		set
		{
			_parameterResourceFile = value;
		}
	}

	[TypeConverter("System.Diagnostics.Design.StringValueConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public string Log
	{
		get
		{
			if (_log == null && _source != null)
			{
				_log = EventLog.LogNameFromSourceName(_source, ".");
			}
			return _log;
		}
		set
		{
			_log = value;
		}
	}

	[TypeConverter("System.Diagnostics.Design.StringValueConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public string Source
	{
		get
		{
			return _source;
		}
		set
		{
			_source = value;
		}
	}

	[DefaultValue(UninstallAction.Remove)]
	public UninstallAction UninstallAction
	{
		get
		{
			return _uninstallAction;
		}
		set
		{
			if (!Enum.IsDefined(typeof(UninstallAction), value))
			{
				throw new InvalidEnumArgumentException("value", (int)value, typeof(UninstallAction));
			}
			_uninstallAction = value;
		}
	}

	[System.MonoTODO]
	public override void CopyFromComponent(IComponent component)
	{
		throw new NotImplementedException();
	}

	[System.MonoTODO]
	public override void Install(IDictionary stateSaver)
	{
		throw new NotImplementedException();
	}

	[System.MonoTODO]
	public override bool IsEquivalentInstaller(ComponentInstaller otherInstaller)
	{
		throw new NotImplementedException();
	}

	[System.MonoTODO]
	public override void Rollback(IDictionary savedState)
	{
		throw new NotImplementedException();
	}

	[System.MonoTODO]
	public override void Uninstall(IDictionary savedState)
	{
		throw new NotImplementedException();
	}
}
