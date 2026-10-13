using UnityEngine;

namespace Rewired;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
internal struct TouchInfo
{
	private bool yExdeNflXkPLEMNKuRasBDUjZTojA;

	private int yuUpkTaBGBSBnIDEENZOVstqXefK;

	private Vector2 uHYxqPMJJxhDAEOwmllFItUGuuVn;

	private Vector2 SxWZFBUqSkmYVTWvtFSHBXLiAlwb;

	private Vector2 pSQtNQLdlsRfuwkmtALTFdOSgAyjA;

	private Vector2 WDoBcUnQHuWCipoQBqDBeiQmEvPL;

	private float VoTeBYIaUlPTlltsmACEaWZbeUnMb;

	private int MfaUXiXzACnvkCTOXNpozEEUopUD;

	public bool isValid
	{
		get
		{
			return yExdeNflXkPLEMNKuRasBDUjZTojA;
		}
		internal set
		{
			yExdeNflXkPLEMNKuRasBDUjZTojA = value;
		}
	}

	public int touchId
	{
		get
		{
			return yuUpkTaBGBSBnIDEENZOVstqXefK;
		}
		internal set
		{
			yuUpkTaBGBSBnIDEENZOVstqXefK = value;
		}
	}

	public Vector2 touchPos
	{
		get
		{
			return uHYxqPMJJxhDAEOwmllFItUGuuVn;
		}
		internal set
		{
			uHYxqPMJJxhDAEOwmllFItUGuuVn = value;
		}
	}

	public Vector2 touchPosRaw
	{
		get
		{
			return SxWZFBUqSkmYVTWvtFSHBXLiAlwb;
		}
		internal set
		{
			SxWZFBUqSkmYVTWvtFSHBXLiAlwb = value;
		}
	}

	public Vector2 deltaPos
	{
		get
		{
			return pSQtNQLdlsRfuwkmtALTFdOSgAyjA;
		}
		internal set
		{
			pSQtNQLdlsRfuwkmtALTFdOSgAyjA = value;
		}
	}

	public Vector2 deltaPosRaw
	{
		get
		{
			return WDoBcUnQHuWCipoQBqDBeiQmEvPL;
		}
		internal set
		{
			WDoBcUnQHuWCipoQBqDBeiQmEvPL = value;
		}
	}

	public float deltaTime
	{
		get
		{
			return VoTeBYIaUlPTlltsmACEaWZbeUnMb;
		}
		internal set
		{
			VoTeBYIaUlPTlltsmACEaWZbeUnMb = value;
		}
	}

	public int tapCount
	{
		get
		{
			return MfaUXiXzACnvkCTOXNpozEEUopUD;
		}
		internal set
		{
			MfaUXiXzACnvkCTOXNpozEEUopUD = value;
		}
	}

	internal static TouchInfo Invalid => new TouchInfo
	{
		yExdeNflXkPLEMNKuRasBDUjZTojA = false
	};

	internal TouchInfo(bool P_0, int P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, Vector2 P_5, float P_6, int P_7)
	{
		yExdeNflXkPLEMNKuRasBDUjZTojA = P_0;
		yuUpkTaBGBSBnIDEENZOVstqXefK = P_1;
		uHYxqPMJJxhDAEOwmllFItUGuuVn = P_2;
		SxWZFBUqSkmYVTWvtFSHBXLiAlwb = P_3;
		pSQtNQLdlsRfuwkmtALTFdOSgAyjA = P_4;
		WDoBcUnQHuWCipoQBqDBeiQmEvPL = P_5;
		VoTeBYIaUlPTlltsmACEaWZbeUnMb = P_6;
		MfaUXiXzACnvkCTOXNpozEEUopUD = P_7;
	}
}
