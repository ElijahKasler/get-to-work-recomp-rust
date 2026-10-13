using System;
using System.Runtime.CompilerServices;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class nLbAcapOagdnNrGGiTONDGTEQuzQ : xRwbEhgwfqETGQkYCofyzWNojclTA
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class TouchpadInfo
	{
		public int maxTouches;

		public int minX;

		public int maxX;

		public int minY;

		public int maxY;

		public bool invertY;

		public bool reverseY;

		public TouchpadInfo(int P_0, int P_1, int P_2, int P_3, int P_4, bool P_5, bool P_6)
		{
			maxTouches = P_0;
			minX = P_1;
			maxX = P_2;
			minY = P_3;
			maxY = P_4;
			invertY = P_5;
			reverseY = P_6;
		}

		public void CalculateTouch(ref TouchData data)
		{
			int num = (reverseY ? (maxY - data.positionRawY) : data.positionRawY);
			data.positionX = MathTools.ValueInNewRange(data.positionRawX, minX, maxX, 0f, 1f);
			data.positionY = MathTools.ValueInNewRange(num, minY, maxY, 0f, 1f);
			data.positionAbsX = data.positionRawX;
			data.positionAbsY = num;
			if (data.positionAbsX > maxX)
			{
				data.positionAbsX = maxX;
			}
			if (data.positionAbsY > maxY)
			{
				data.positionAbsY = maxY;
			}
			if (data.positionAbsX < minX)
			{
				data.positionAbsX = minX;
			}
			if (data.positionAbsY < minY)
			{
				data.positionAbsY = minY;
			}
			if (invertY)
			{
				data.positionY *= -1f;
				data.positionAbsY *= -1;
			}
		}
	}

	private class YHNMqEBOENqRAkgGrWjaLVGrjwBU
	{
		public readonly TouchData[] XxAQktirzvbDaIsQGqMzmmfCWsMc;

		public YHNMqEBOENqRAkgGrWjaLVGrjwBU(int P_0)
		{
			XxAQktirzvbDaIsQGqMzmmfCWsMc = new TouchData[P_0];
		}
	}

	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal struct TouchData
	{
		public int touchId;

		public float timeStamp;

		public bool isTouching;

		public int positionRawX;

		public int positionRawY;

		public float positionX;

		public float positionY;

		public int positionAbsX;

		public int positionAbsY;

		public void Clear()
		{
			touchId = -1;
			timeStamp = 0f;
			isTouching = false;
			positionRawX = 0;
			positionRawY = 0;
			positionX = 0f;
			positionY = 0f;
			positionAbsX = 0;
			positionAbsY = 0;
		}
	}

	private TouchpadInfo lSXNmvAbMKHnMkTYNYCMGlRgqRWl;

	private RingBuffer<YHNMqEBOENqRAkgGrWjaLVGrjwBU> NmVHmZKHbIKoGRnpBwwKikcZhojG;

	private TouchData[] BegBoCiPDYTCmaSTmWMvJvQpkfbIb;

	private Action<NativeBuffer, TouchData[]> EQjNJHrpKDaEmJmmNWIeSFLDGHSEb;

	public TouchData[] eRxGPKHfVUSoUvYtfLqInWzRcIsH;

	private ObjectPool<YHNMqEBOENqRAkgGrWjaLVGrjwBU> kQBKcJykYnbkByLZIsDYwJYazMNy;

	public nLbAcapOagdnNrGGiTONDGTEQuzQ(byte P_0, TouchpadInfo P_1, HIDInfo P_2, int P_3, Action<NativeBuffer, TouchData[]> P_4)
		: base(P_0, P_2)
	{
		lSXNmvAbMKHnMkTYNYCMGlRgqRWl = P_1;
		EQjNJHrpKDaEmJmmNWIeSFLDGHSEb = P_4;
		NmVHmZKHbIKoGRnpBwwKikcZhojG = new RingBuffer<YHNMqEBOENqRAkgGrWjaLVGrjwBU>(P_3);
		BegBoCiPDYTCmaSTmWMvJvQpkfbIb = new TouchData[P_1.maxTouches];
		eRxGPKHfVUSoUvYtfLqInWzRcIsH = new TouchData[P_1.maxTouches];
		for (int i = 0; i < eRxGPKHfVUSoUvYtfLqInWzRcIsH.Length; i++)
		{
			eRxGPKHfVUSoUvYtfLqInWzRcIsH[i].Clear();
		}
		kQBKcJykYnbkByLZIsDYwJYazMNy = new ObjectPool<YHNMqEBOENqRAkgGrWjaLVGrjwBU>(P_3, () => new YHNMqEBOENqRAkgGrWjaLVGrjwBU(lSXNmvAbMKHnMkTYNYCMGlRgqRWl.maxTouches));
	}

	public virtual void KPagSyenHfnJABZLNDDycVAOpTqGb(NativeBuffer P_0, double P_1)
	{
		if (EQjNJHrpKDaEmJmmNWIeSFLDGHSEb == null)
		{
			return;
		}
		EQjNJHrpKDaEmJmmNWIeSFLDGHSEb(P_0, BegBoCiPDYTCmaSTmWMvJvQpkfbIb);
		lock (NmVHmZKHbIKoGRnpBwwKikcZhojG)
		{
			YHNMqEBOENqRAkgGrWjaLVGrjwBU yHNMqEBOENqRAkgGrWjaLVGrjwBU = kQBKcJykYnbkByLZIsDYwJYazMNy.Get();
			for (int i = 0; i < lSXNmvAbMKHnMkTYNYCMGlRgqRWl.maxTouches; i++)
			{
				yHNMqEBOENqRAkgGrWjaLVGrjwBU.XxAQktirzvbDaIsQGqMzmmfCWsMc[i] = BegBoCiPDYTCmaSTmWMvJvQpkfbIb[i];
			}
			CollectionTools.Enqueue(kQBKcJykYnbkByLZIsDYwJYazMNy, NmVHmZKHbIKoGRnpBwwKikcZhojG, yHNMqEBOENqRAkgGrWjaLVGrjwBU, out var _);
		}
		lvdOJcEIsvdMMieNwzsdUwLVXNJmA();
	}

	public void lvdOJcEIsvdMMieNwzsdUwLVXNJmA()
	{
		for (int i = 0; i < eRxGPKHfVUSoUvYtfLqInWzRcIsH.Length; i++)
		{
			eRxGPKHfVUSoUvYtfLqInWzRcIsH[i].Clear();
		}
		lock (NmVHmZKHbIKoGRnpBwwKikcZhojG)
		{
			int num = NmVHmZKHbIKoGRnpBwwKikcZhojG.Count;
			while (num > 0)
			{
				YHNMqEBOENqRAkgGrWjaLVGrjwBU yHNMqEBOENqRAkgGrWjaLVGrjwBU = NmVHmZKHbIKoGRnpBwwKikcZhojG.Dequeue();
				num--;
				for (int j = 0; j < yHNMqEBOENqRAkgGrWjaLVGrjwBU.XxAQktirzvbDaIsQGqMzmmfCWsMc.Length; j++)
				{
					lSXNmvAbMKHnMkTYNYCMGlRgqRWl.CalculateTouch(ref yHNMqEBOENqRAkgGrWjaLVGrjwBU.XxAQktirzvbDaIsQGqMzmmfCWsMc[j]);
					eRxGPKHfVUSoUvYtfLqInWzRcIsH[j] = yHNMqEBOENqRAkgGrWjaLVGrjwBU.XxAQktirzvbDaIsQGqMzmmfCWsMc[j];
				}
				kQBKcJykYnbkByLZIsDYwJYazMNy.Return(yHNMqEBOENqRAkgGrWjaLVGrjwBU);
			}
		}
	}

	public bool nbrtEjncCqmLPUIIxfqKkvPpFsqbb(int P_0)
	{
		for (int i = 0; i < eRxGPKHfVUSoUvYtfLqInWzRcIsH.Length; i++)
		{
			if (eRxGPKHfVUSoUvYtfLqInWzRcIsH[i].isTouching && eRxGPKHfVUSoUvYtfLqInWzRcIsH[i].touchId == P_0)
			{
				return true;
			}
		}
		return false;
	}

	[CompilerGenerated]
	private YHNMqEBOENqRAkgGrWjaLVGrjwBU kBZYxyiUjqAwMqomgbDyFaBJuhJy()
	{
		return new YHNMqEBOENqRAkgGrWjaLVGrjwBU(lSXNmvAbMKHnMkTYNYCMGlRgqRWl.maxTouches);
	}
}
