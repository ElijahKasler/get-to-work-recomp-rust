using System;
using System.Collections.Generic;
using Rewired.Interfaces;

namespace Rewired;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
internal class InputSourceWrapper<T> : IInputSource, IDisposable
{
	private T prRZdzhqCjdsCrLTgoctwsuUMyjU;

	private bool HKODnwIHIoDGIZFekiLvoMZuUianA;

	public T source => prRZdzhqCjdsCrLTgoctwsuUMyjU;

	event Action IInputSource.DeviceChangedEvent
	{
		add
		{
			add_DeviceChangedEvent(value);
		}
		remove
		{
			remove_DeviceChangedEvent(value);
		}
	}

	public InputSourceWrapper(T P_0)
	{
		prRZdzhqCjdsCrLTgoctwsuUMyjU = P_0;
	}

	public void add_DeviceChangedEvent(Action value)
	{
		throw new NotImplementedException();
	}

	public void remove_DeviceChangedEvent(Action value)
	{
		throw new NotImplementedException();
	}

	public void SystemDeviceConnected()
	{
	}

	void IInputSource.SystemDeviceConnected()
	{
		//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceConnected
		this.SystemDeviceConnected();
	}

	public void SystemDeviceDisconnected()
	{
	}

	void IInputSource.SystemDeviceDisconnected()
	{
		//ILSpy generated this explicit interface implementation from .override directive in SystemDeviceDisconnected
		this.SystemDeviceDisconnected();
	}

	public void Update()
	{
		throw new NotImplementedException();
	}

	void IInputSource.Update()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Update
		this.Update();
	}

	public void UpdateDevices(UpdateLoopType updateLoop)
	{
		throw new NotImplementedException();
	}

	void IInputSource.UpdateDevices(UpdateLoopType updateLoop)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateDevices
		this.UpdateDevices(updateLoop);
	}

	public void UpdateFinished()
	{
		throw new NotImplementedException();
	}

	void IInputSource.UpdateFinished()
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateFinished
		this.UpdateFinished();
	}

	public IList<TJoy> GetJoysticks<TJoy>() where TJoy : class
	{
		throw new NotImplementedException();
	}

	IList<TJoy> IInputSource.GetJoysticks<TJoy>()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetJoysticks
		return this.GetJoysticks<TJoy>();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	~InputSourceWrapper()
	{
		Dispose(disposing: false);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!HKODnwIHIoDGIZFekiLvoMZuUianA)
		{
			HKODnwIHIoDGIZFekiLvoMZuUianA = true;
		}
	}
}
