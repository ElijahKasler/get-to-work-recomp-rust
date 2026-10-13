using System.Security.Permissions;

namespace System.ServiceProcess;

[Serializable]
public sealed class ServiceControllerPermission : ResourcePermissionBase
{
	private ServiceControllerPermissionEntryCollection innerCollection;

	private static char[] invalidChars = new char[8] { '\t', '\n', '\v', '\f', '\r', ' ', '\\', 'Š' };

	private static char[] invalidServiceNameChars = new char[2] { '/', '\\' };

	public ServiceControllerPermissionEntryCollection PermissionEntries
	{
		get
		{
			if (innerCollection == null)
			{
				innerCollection = new ServiceControllerPermissionEntryCollection(this);
			}
			return innerCollection;
		}
	}

	public ServiceControllerPermission()
	{
		SetUp();
	}

	public ServiceControllerPermission(ServiceControllerPermissionEntry[] permissionAccessEntries)
	{
		if (permissionAccessEntries == null)
		{
			throw new ArgumentNullException("permissionAccessEntries");
		}
		SetUp();
		innerCollection = new ServiceControllerPermissionEntryCollection(this);
		innerCollection.AddRange(permissionAccessEntries);
	}

	public ServiceControllerPermission(PermissionState state)
		: base(state)
	{
		SetUp();
	}

	public ServiceControllerPermission(ServiceControllerPermissionAccess permissionAccess, string machineName, string serviceName)
	{
		SetUp();
		ServiceControllerPermissionEntry value = new ServiceControllerPermissionEntry(permissionAccess, machineName, serviceName);
		innerCollection = new ServiceControllerPermissionEntryCollection(this);
		innerCollection.Add(value);
	}

	private void SetUp()
	{
		base.TagNames = new string[2] { "Machine", "Service" };
		base.PermissionAccessType = typeof(ServiceControllerPermissionAccess);
	}

	internal ResourcePermissionBaseEntry[] GetEntries()
	{
		return GetPermissionEntries();
	}

	internal void ClearEntries()
	{
		Clear();
	}

	internal void Add(object obj)
	{
		ServiceControllerPermissionEntry serviceControllerPermissionEntry = obj as ServiceControllerPermissionEntry;
		AddPermissionAccess(serviceControllerPermissionEntry.GetBaseEntry());
	}

	internal void Remove(object obj)
	{
		ServiceControllerPermissionEntry serviceControllerPermissionEntry = obj as ServiceControllerPermissionEntry;
		RemovePermissionAccess(serviceControllerPermissionEntry.GetBaseEntry());
	}

	internal static void ValidateMachineName(string name)
	{
		if (name == null || name.Length == 0 || name.IndexOfAny(invalidChars) != -1)
		{
			string text = global::Locale.GetText("Invalid machine name '{0}'.");
			if (name == null)
			{
				name = "(null)";
			}
			throw new ArgumentException(string.Format(text, name), "MachineName");
		}
	}

	internal static void ValidateServiceName(string name)
	{
		if (name == null)
		{
			throw new ArgumentNullException("ServiceName");
		}
		if (name.Length == 0 || name.IndexOfAny(invalidServiceNameChars) != -1)
		{
			throw new ArgumentException(string.Format(global::Locale.GetText("Invalid service name '{0}'."), name), "ServiceName");
		}
	}
}
