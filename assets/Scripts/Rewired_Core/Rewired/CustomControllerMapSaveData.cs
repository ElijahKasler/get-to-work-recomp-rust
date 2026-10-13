namespace Rewired;

public sealed class CustomControllerMapSaveData : ControllerMapSaveData
{
	public CustomController customController
	{
		get
		{
			if (ReInput._id != lMmWmnIhNBeZArLUWXGHaejHwggK)
			{
				ReInput.CheckInitialized(lMmWmnIhNBeZArLUWXGHaejHwggK);
				return null;
			}
			return _controller as CustomController;
		}
	}

	public CustomControllerMap customControllerMap
	{
		get
		{
			if (ReInput._id != lMmWmnIhNBeZArLUWXGHaejHwggK)
			{
				ReInput.CheckInitialized(lMmWmnIhNBeZArLUWXGHaejHwggK);
				return null;
			}
			return _map as CustomControllerMap;
		}
	}

	public int customControllerSourceId
	{
		get
		{
			if (ReInput._id != lMmWmnIhNBeZArLUWXGHaejHwggK)
			{
				ReInput.CheckInitialized(lMmWmnIhNBeZArLUWXGHaejHwggK);
				return -1;
			}
			return customController.sourceControllerId;
		}
	}

	internal CustomControllerMapSaveData(CustomController P_0, CustomControllerMap P_1)
		: base(P_0, P_1)
	{
	}
}
