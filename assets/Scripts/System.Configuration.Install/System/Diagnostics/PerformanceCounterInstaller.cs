using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Runtime.InteropServices;

namespace System.Diagnostics;

public class PerformanceCounterInstaller : ComponentInstaller
{
	private string _categoryHelp = string.Empty;

	private string _categoryName = string.Empty;

	private CounterCreationDataCollection _counters = new CounterCreationDataCollection();

	private UninstallAction _uninstallAction;

	private PerformanceCounterCategoryType _categoryType;

	[DefaultValue("")]
	public string CategoryHelp
	{
		get
		{
			return _categoryHelp;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			_categoryHelp = value;
		}
	}

	[TypeConverter("System.Diagnostics.Design.StringValueConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[DefaultValue("")]
	public string CategoryName
	{
		get
		{
			return _categoryName;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			_categoryName = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public CounterCreationDataCollection Counters => _counters;

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

	[ComVisible(false)]
	[DefaultValue(PerformanceCounterCategoryType.Unknown)]
	public PerformanceCounterCategoryType CategoryType
	{
		get
		{
			return _categoryType;
		}
		set
		{
			if (!Enum.IsDefined(typeof(PerformanceCounterCategoryType), value))
			{
				throw new InvalidEnumArgumentException("value", (int)value, typeof(PerformanceCounterCategoryType));
			}
			_categoryType = value;
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
