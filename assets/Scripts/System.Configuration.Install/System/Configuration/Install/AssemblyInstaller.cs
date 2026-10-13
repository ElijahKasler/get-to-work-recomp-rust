using System.Collections;
using System.IO;
using System.Reflection;

namespace System.Configuration.Install;

public class AssemblyInstaller : Installer
{
	private Assembly _assembly;

	private string[] _commandLine;

	private bool _useNewContext;

	public Assembly Assembly
	{
		get
		{
			return _assembly;
		}
		set
		{
			_assembly = value;
		}
	}

	public string[] CommandLine
	{
		get
		{
			return _commandLine;
		}
		set
		{
			_commandLine = value;
		}
	}

	public override string HelpText => base.HelpText;

	public string Path
	{
		get
		{
			if (_assembly == null)
			{
				return null;
			}
			return _assembly.Location;
		}
		set
		{
			if (value == null)
			{
				_assembly = null;
			}
			_assembly = Assembly.LoadFrom(value);
		}
	}

	public bool UseNewContext
	{
		get
		{
			return _useNewContext;
		}
		set
		{
			_useNewContext = value;
		}
	}

	public AssemblyInstaller()
	{
	}

	public AssemblyInstaller(Assembly assembly, string[] commandLine)
	{
		_assembly = assembly;
		_commandLine = commandLine;
		_useNewContext = true;
	}

	public AssemblyInstaller(string fileName, string[] commandLine)
	{
		Path = System.IO.Path.GetFullPath(fileName);
		_commandLine = commandLine;
		_useNewContext = true;
	}

	[System.MonoTODO]
	public static void CheckIfInstallable(string assemblyName)
	{
		throw new NotImplementedException();
	}

	public override void Commit(IDictionary savedState)
	{
		base.Commit(savedState);
	}

	public override void Install(IDictionary savedState)
	{
		base.Install(savedState);
	}

	public override void Rollback(IDictionary savedState)
	{
		base.Rollback(savedState);
	}

	public override void Uninstall(IDictionary savedState)
	{
		base.Uninstall(savedState);
	}
}
