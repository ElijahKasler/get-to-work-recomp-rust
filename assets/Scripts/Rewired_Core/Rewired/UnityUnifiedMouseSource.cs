using System;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal class UnityUnifiedMouseSource : IUnifiedMouseSource, IGetSetEnabled, IDisposable
{
	private class dLpEIvbwasLRPJiGeovdgDDOTWmb
	{
		private float[] IuCNeCidRHJIoUZVfUhkvCCNvwUr;

		private bool[] qIvSXfBlfIMbkJUIGeqLnGZUAoZr;

		public dLpEIvbwasLRPJiGeovdgDDOTWmb(int P_0, int P_1)
		{
			qIvSXfBlfIMbkJUIGeqLnGZUAoZr = new bool[P_0];
			IuCNeCidRHJIoUZVfUhkvCCNvwUr = new float[P_1];
		}

		public void TnUfyYDTcRfQJvnEHwKexrvqzvLJ(bool[] P_0, float[] P_1)
		{
			Array.Copy(P_0, qIvSXfBlfIMbkJUIGeqLnGZUAoZr, P_0.Length);
			for (int i = 0; i < IuCNeCidRHJIoUZVfUhkvCCNvwUr.Length; i++)
			{
				IuCNeCidRHJIoUZVfUhkvCCNvwUr[i] += P_1[i];
			}
		}

		public void gcRxqLYmOOKPYzBkIaiclXeKWKqF(ControllerDataUpdater P_0)
		{
			Array.Copy(IuCNeCidRHJIoUZVfUhkvCCNvwUr, P_0.axisValues, IuCNeCidRHJIoUZVfUhkvCCNvwUr.Length);
			Array.Copy(qIvSXfBlfIMbkJUIGeqLnGZUAoZr, P_0.buttonValues, qIvSXfBlfIMbkJUIGeqLnGZUAoZr.Length);
		}

		public void CqiFKDHIDRHfTQHcPrYnaKNbDMUSb()
		{
			Array.Clear(IuCNeCidRHJIoUZVfUhkvCCNvwUr, 0, IuCNeCidRHJIoUZVfUhkvCCNvwUr.Length);
			Array.Clear(qIvSXfBlfIMbkJUIGeqLnGZUAoZr, 0, qIvSXfBlfIMbkJUIGeqLnGZUAoZr.Length);
		}

		public void dsSBZuJCDEuftSeHMzrYtkpgVYwu()
		{
			Array.Clear(IuCNeCidRHJIoUZVfUhkvCCNvwUr, 0, IuCNeCidRHJIoUZVfUhkvCCNvwUr.Length);
		}
	}

	[Serializable]
	private sealed class zcebCCiVcRkBIoqeRTUbHrjgOvJh
	{
		public static readonly zcebCCiVcRkBIoqeRTUbHrjgOvJh _003C_003E9 = new zcebCCiVcRkBIoqeRTUbHrjgOvJh();

		public static Func<dLpEIvbwasLRPJiGeovdgDDOTWmb> _003C_003E9__20_0;

		internal dLpEIvbwasLRPJiGeovdgDDOTWmb dPRUGNHRLccxpMDGrMUVzYiusIPE()
		{
			return new dLpEIvbwasLRPJiGeovdgDDOTWmb(7, 4);
		}
	}

	private static HardwareControllerMap_Game UswMVLRrtdpLyJcptgEpXKWSGZBT;

	private UpdateLoopDataSet<dLpEIvbwasLRPJiGeovdgDDOTWmb> iRapHqLVDGSguuLCqYrEueqbKJqB;

	private float[] mRsEYmdRubUkDqVPqpUQceNSfEgA;

	private bool[] nOUGewifyBInapOdtYraYZwCQUuO;

	private bool hllBjeaaFoggeikkDECsbBOdRELab;

	private bool itnZNGMKINntKYBniNBAEpfuGjnE;

	bool IGetSetEnabled.enabled
	{
		get
		{
			return get_enabled();
		}
		set
		{
			set_enabled(value);
		}
	}

	InputSource IUnifiedMouseSource.inputSource => get_inputSource();

	HardwareControllerMap_Game IUnifiedMouseSource.hardwareMap => get_hardwareMap();

	int IUnifiedMouseSource.buttonCount => get_buttonCount();

	int IUnifiedMouseSource.axisCount => get_axisCount();

	Vector2 IUnifiedMouseSource.mousePosition => get_mousePosition();

	Controller.Extension IUnifiedMouseSource.controllerExtension => get_controllerExtension();

	public bool get_enabled()
	{
		return hllBjeaaFoggeikkDECsbBOdRELab;
	}

	public void set_enabled(bool value)
	{
		if (hllBjeaaFoggeikkDECsbBOdRELab != value)
		{
			hllBjeaaFoggeikkDECsbBOdRELab = value;
			Clear();
			ThreadSafeUnityInput.mouse.Monitor(value);
		}
	}

	public InputSource get_inputSource()
	{
		return InputSource.UnityKeyboardAndMouse;
	}

	public HardwareControllerMap_Game get_hardwareMap()
	{
		if (UswMVLRrtdpLyJcptgEpXKWSGZBT == null)
		{
			UswMVLRrtdpLyJcptgEpXKWSGZBT = CreateHardwareMap();
		}
		return UswMVLRrtdpLyJcptgEpXKWSGZBT;
	}

	public int get_buttonCount()
	{
		return 7;
	}

	public int get_axisCount()
	{
		return 4;
	}

	public Vector2 get_mousePosition()
	{
		if (!hllBjeaaFoggeikkDECsbBOdRELab)
		{
			return default;
		}
		return ThreadSafeUnityInput.mouse.mousePosition;
	}

	public Controller.Extension get_controllerExtension()
	{
		return null;
	}

	public UnityUnifiedMouseSource()
	{
		iRapHqLVDGSguuLCqYrEueqbKJqB = new UpdateLoopDataSet<dLpEIvbwasLRPJiGeovdgDDOTWmb>(ReInput.configVars.updateLoop, zcebCCiVcRkBIoqeRTUbHrjgOvJh._003C_003E9.dPRUGNHRLccxpMDGrMUVzYiusIPE);
		mRsEYmdRubUkDqVPqpUQceNSfEgA = new float[4];
		nOUGewifyBInapOdtYraYZwCQUuO = new bool[7];
		set_enabled(value: true);
		ReInput.UpdateEndedEvent += wheGouisKyHGxAppexqsuOiJfthCb;
		ReInput.EarlyUpdateEvent += JMcnpzKVpBQtSUMWwroYNFsgkVel;
	}

	public void UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		iRapHqLVDGSguuLCqYrEueqbKJqB.Get(ReInput.currentUpdateLoop).gcRxqLYmOOKPYzBkIaiclXeKWKqF(dataUpdater);
	}

	void IUnifiedMouseSource.UpdateInputData(ControllerDataUpdater dataUpdater)
	{
		//ILSpy generated this explicit interface implementation from .override directive in UpdateInputData
		this.UpdateInputData(dataUpdater);
	}

	public void Clear()
	{
		int count = iRapHqLVDGSguuLCqYrEueqbKJqB.Count;
		for (int i = 0; i < count; i++)
		{
			iRapHqLVDGSguuLCqYrEueqbKJqB.Get(i).CqiFKDHIDRHfTQHcPrYnaKNbDMUSb();
		}
	}

	void IUnifiedMouseSource.Clear()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Clear
		this.Clear();
	}

	private void JMcnpzKVpBQtSUMWwroYNFsgkVel()
	{
		if (hllBjeaaFoggeikkDECsbBOdRELab)
		{
			ThreadSafeUnityInput.mouse.GetAxisRawValues(mRsEYmdRubUkDqVPqpUQceNSfEgA);
			ThreadSafeUnityInput.mouse.GetButtonValues(nOUGewifyBInapOdtYraYZwCQUuO);
			int count = iRapHqLVDGSguuLCqYrEueqbKJqB.Count;
			for (int i = 0; i < count; i++)
			{
				iRapHqLVDGSguuLCqYrEueqbKJqB.Get(i).TnUfyYDTcRfQJvnEHwKexrvqzvLJ(nOUGewifyBInapOdtYraYZwCQUuO, mRsEYmdRubUkDqVPqpUQceNSfEgA);
			}
		}
	}

	private void wheGouisKyHGxAppexqsuOiJfthCb(UpdateLoopType P_0)
	{
		iRapHqLVDGSguuLCqYrEueqbKJqB.Get(P_0).dsSBZuJCDEuftSeHMzrYtkpgVYwu();
	}

	internal static HardwareControllerMap_Game CreateHardwareMap()
	{
		ControllerElementIdentifier[] array = new ControllerElementIdentifier[Consts.unityUnifiedMouseElementIdentifiers.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new ControllerElementIdentifier(Consts.unityUnifiedMouseElementIdentifiers[i]);
		}
		int[] array2 = new int[7];
		int[] array3 = new int[4];
		int num = 0;
		int num2 = 0;
		for (int j = 0; j < array.Length; j++)
		{
			if (array[j].elementType == ControllerElementType.Axis)
			{
				array3[num2++] = array[j].get_id();
			}
			else if (array[j].elementType == ControllerElementType.Button)
			{
				array2[num++] = array[j].get_id();
			}
		}
		AxisCalibrationData[] array4 = new AxisCalibrationData[4];
		AxisRange[] array5 = new AxisRange[4];
		HardwareAxisInfo[] array6 = new HardwareAxisInfo[4];
		HardwareButtonInfo[] array7 = new HardwareButtonInfo[7];
		for (int k = 0; k < 4; k++)
		{
			array4[k] = AxisCalibrationData.Raw;
			array5[k] = AxisRange.Full;
			float num3 = (((uint)k > 1u) ? 2f : 100f);
			array6[k] = new HardwareAxisInfo(AxisCoordinateMode.Relative, false, num3, SpecialAxisType.None);
		}
		for (int l = 0; l < 7; l++)
		{
			array7[l] = new HardwareButtonInfo();
		}
		return new HardwareControllerMap_Game("Mouse", default, array, array2, array3, array4, array5, array6, array7, null);
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

	~UnityUnifiedMouseSource()
	{
		Dispose(disposing: false);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (itnZNGMKINntKYBniNBAEpfuGjnE)
		{
			return;
		}
		if (disposing)
		{
			if (hllBjeaaFoggeikkDECsbBOdRELab)
			{
				ThreadSafeUnityInput.mouse.Monitor(state: false);
			}
			ReInput.UpdateEndedEvent -= wheGouisKyHGxAppexqsuOiJfthCb;
			ReInput.EarlyUpdateEvent -= JMcnpzKVpBQtSUMWwroYNFsgkVel;
		}
		itnZNGMKINntKYBniNBAEpfuGjnE = true;
	}

	public static ControllerElementType GetHardwareElementType(int elementIdentifierId)
	{
		if (UswMVLRrtdpLyJcptgEpXKWSGZBT == null)
		{
			UswMVLRrtdpLyJcptgEpXKWSGZBT = CreateHardwareMap();
		}
		return UswMVLRrtdpLyJcptgEpXKWSGZBT.GetElementType(elementIdentifierId);
	}
}
