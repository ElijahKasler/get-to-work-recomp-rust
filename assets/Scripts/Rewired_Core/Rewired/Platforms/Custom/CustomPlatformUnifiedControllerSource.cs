using System;
using System.Collections.Generic;
using Rewired.Utils;

namespace Rewired.Platforms.Custom;

public abstract class CustomPlatformUnifiedControllerSource : IDisposable
{
	private readonly int dosJPHctfcGpMPjVZwPsFYfVhVky;

	private readonly int qYYWlYYxDxWipWvYuhMVVMPHwOkg;

	private readonly bool[] kKBwScJlLrlGNWOnYUpfCTuoPqbd;

	private readonly bool[] BmneyBbGwxJGqqnbnKRvLYyVrrgcA;

	private readonly float[] tqIFmNdseDeobBPOfNezGcpdFFBXc;

	private bool vsEDoXCyHjVAdfldRerkOBpSkPDs;

	public int axisCount => dosJPHctfcGpMPjVZwPsFYfVhVky;

	public int buttonCount => qYYWlYYxDxWipWvYuhMVVMPHwOkg;

	public virtual Controller.Extension controllerExtension => null;

	public CustomPlatformUnifiedControllerSource(int P_0, int P_1)
	{
		if (P_0 < 0)
		{
			P_0 = 0;
		}
		if (P_1 < 0)
		{
			P_1 = 0;
		}
		dosJPHctfcGpMPjVZwPsFYfVhVky = P_0;
		qYYWlYYxDxWipWvYuhMVVMPHwOkg = P_1;
		tqIFmNdseDeobBPOfNezGcpdFFBXc = new float[P_0];
		kKBwScJlLrlGNWOnYUpfCTuoPqbd = new bool[P_1];
		BmneyBbGwxJGqqnbnKRvLYyVrrgcA = new bool[P_1];
	}

	protected abstract void Update();

	internal virtual void VgVAtSmMniPvCujcBMNWPuINwWsK()
	{
	}

	protected virtual void OnInitialize()
	{
	}

	protected virtual void Clear()
	{
		Array.Clear(tqIFmNdseDeobBPOfNezGcpdFFBXc, 0, dosJPHctfcGpMPjVZwPsFYfVhVky);
		Array.Clear(kKBwScJlLrlGNWOnYUpfCTuoPqbd, 0, qYYWlYYxDxWipWvYuhMVVMPHwOkg);
		Array.Clear(BmneyBbGwxJGqqnbnKRvLYyVrrgcA, 0, qYYWlYYxDxWipWvYuhMVVMPHwOkg);
	}

	protected float GetAxisValue(int index)
	{
		if ((uint)index >= (uint)axisCount)
		{
			return 0f;
		}
		return tqIFmNdseDeobBPOfNezGcpdFFBXc[index];
	}

	protected bool GetButtonValue(int index)
	{
		if ((uint)index >= (uint)buttonCount)
		{
			return false;
		}
		return kKBwScJlLrlGNWOnYUpfCTuoPqbd[index];
	}

	protected void SetAxisValue(int index, float value)
	{
		if ((uint)index < (uint)axisCount)
		{
			tqIFmNdseDeobBPOfNezGcpdFFBXc[index] = value;
		}
	}

	protected void SetAxisValues(IList<float> values)
	{
		if (values == null)
		{
			return;
		}
		int num = MathTools.Min(values.Count, axisCount);
		if (values is float[])
		{
			Array.Copy(values as float[], tqIFmNdseDeobBPOfNezGcpdFFBXc, num);
			return;
		}
		for (int i = 0; i < num; i++)
		{
			tqIFmNdseDeobBPOfNezGcpdFFBXc[i] = values[i];
		}
	}

	protected void SetButtonValue(int index, bool value)
	{
		if ((uint)index < (uint)buttonCount)
		{
			if (!kKBwScJlLrlGNWOnYUpfCTuoPqbd[index] & value)
			{
				BmneyBbGwxJGqqnbnKRvLYyVrrgcA[index] = true;
			}
			kKBwScJlLrlGNWOnYUpfCTuoPqbd[index] = value;
		}
	}

	protected void SetButtonValues(IList<bool> values)
	{
		if (values == null)
		{
			return;
		}
		int num = MathTools.Min(values.Count, buttonCount);
		if (values is bool[])
		{
			for (int i = 0; i < num; i++)
			{
				if (!kKBwScJlLrlGNWOnYUpfCTuoPqbd[i] && values[i])
				{
					BmneyBbGwxJGqqnbnKRvLYyVrrgcA[i] = true;
				}
			}
			Array.Copy(values as bool[], kKBwScJlLrlGNWOnYUpfCTuoPqbd, num);
			return;
		}
		for (int j = 0; j < num; j++)
		{
			bool flag = values[j];
			if (!kKBwScJlLrlGNWOnYUpfCTuoPqbd[j] & flag)
			{
				BmneyBbGwxJGqqnbnKRvLYyVrrgcA[j] = true;
			}
			kKBwScJlLrlGNWOnYUpfCTuoPqbd[j] = flag;
		}
	}

	internal void XyasLKfyJSVTMaSEMGkouYJUdNFI()
	{
		OnInitialize();
	}

	internal void MeUgFkXZAlycSFvmTxRNpIlSKSRF()
	{
		Clear();
	}

	internal void rHAWMmxSortmYtGdceLvpokwFEVhA(ControllerDataUpdater P_0)
	{
		aKsfKrauaAGiiDLWtheRToNsjsrBA();
		Update();
		VgVAtSmMniPvCujcBMNWPuINwWsK();
		Array.Copy(tqIFmNdseDeobBPOfNezGcpdFFBXc, P_0.axisValues, dosJPHctfcGpMPjVZwPsFYfVhVky);
		for (int i = 0; i < dosJPHctfcGpMPjVZwPsFYfVhVky; i++)
		{
			if (tqIFmNdseDeobBPOfNezGcpdFFBXc[i] != 0f && !P_0.hasReceivedInput)
			{
				P_0.hasReceivedInput = true;
			}
		}
		Array.Copy(kKBwScJlLrlGNWOnYUpfCTuoPqbd, P_0.buttonValues, qYYWlYYxDxWipWvYuhMVVMPHwOkg);
		for (int j = 0; j < qYYWlYYxDxWipWvYuhMVVMPHwOkg; j++)
		{
			if (kKBwScJlLrlGNWOnYUpfCTuoPqbd[j] && !P_0.hasReceivedInput)
			{
				P_0.hasReceivedInput = true;
			}
			if (BmneyBbGwxJGqqnbnKRvLYyVrrgcA[j] && !kKBwScJlLrlGNWOnYUpfCTuoPqbd[j])
			{
				kKBwScJlLrlGNWOnYUpfCTuoPqbd[j] = true;
			}
		}
	}

	private void aKsfKrauaAGiiDLWtheRToNsjsrBA()
	{
		Array.Clear(BmneyBbGwxJGqqnbnKRvLYyVrrgcA, 0, BmneyBbGwxJGqqnbnKRvLYyVrrgcA.Length);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!vsEDoXCyHjVAdfldRerkOBpSkPDs)
		{
			vsEDoXCyHjVAdfldRerkOBpSkPDs = true;
		}
	}

	void IDisposable.Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
