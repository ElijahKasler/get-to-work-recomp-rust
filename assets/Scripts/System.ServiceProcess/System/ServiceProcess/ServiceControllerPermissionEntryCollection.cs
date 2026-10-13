using System.Collections;
using System.Security.Permissions;
using Unity;

namespace System.ServiceProcess;

[Serializable]
public class ServiceControllerPermissionEntryCollection : CollectionBase
{
	private ServiceControllerPermission owner;

	public ServiceControllerPermissionEntry this[int index]
	{
		get
		{
			return base.List[index] as ServiceControllerPermissionEntry;
		}
		set
		{
			base.List[index] = value;
		}
	}

	internal ServiceControllerPermissionEntryCollection(ServiceControllerPermission owner)
	{
		this.owner = owner;
		ResourcePermissionBaseEntry[] entries = owner.GetEntries();
		if (entries.Length != 0)
		{
			ResourcePermissionBaseEntry[] array = entries;
			foreach (ResourcePermissionBaseEntry obj in array)
			{
				ServiceControllerPermissionAccess permissionAccess = (ServiceControllerPermissionAccess)obj.PermissionAccess;
				string machineName = obj.PermissionAccessPath[0];
				string serviceName = obj.PermissionAccessPath[1];
				ServiceControllerPermissionEntry value = new ServiceControllerPermissionEntry(permissionAccess, machineName, serviceName);
				base.InnerList.Add(value);
			}
		}
	}

	public int Add(ServiceControllerPermissionEntry value)
	{
		return base.List.Add(value);
	}

	public void AddRange(ServiceControllerPermissionEntry[] value)
	{
		foreach (ServiceControllerPermissionEntry value2 in value)
		{
			base.List.Add(value2);
		}
	}

	public void AddRange(ServiceControllerPermissionEntryCollection value)
	{
		foreach (ServiceControllerPermissionEntry item in value)
		{
			base.List.Add(item);
		}
	}

	public bool Contains(ServiceControllerPermissionEntry value)
	{
		return base.List.Contains(value);
	}

	public void CopyTo(ServiceControllerPermissionEntry[] array, int index)
	{
		base.List.CopyTo(array, index);
	}

	public int IndexOf(ServiceControllerPermissionEntry value)
	{
		return base.List.IndexOf(value);
	}

	public void Insert(int index, ServiceControllerPermissionEntry value)
	{
		base.List.Insert(index, value);
	}

	public void Remove(ServiceControllerPermissionEntry value)
	{
		base.List.Remove(value);
	}

	protected override void OnClear()
	{
		owner.ClearEntries();
	}

	protected override void OnInsert(int index, object value)
	{
		owner.Add(value);
	}

	protected override void OnRemove(int index, object value)
	{
		owner.Remove(value);
	}

	protected override void OnSet(int index, object oldValue, object newValue)
	{
		owner.Remove(oldValue);
		owner.Add(newValue);
	}

	internal ServiceControllerPermissionEntryCollection()
	{
		Unity.ThrowStub.ThrowNotSupportedException();
	}
}
