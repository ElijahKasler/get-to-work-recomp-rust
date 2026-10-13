using System;
using System.Diagnostics;
using System.Linq;
using Rewired.ControllerExtensions;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired.HID.Drivers;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
internal class DualSenseDriver : HIDDeviceDriver, IDriver_DualSense, IControllerDriver, IHIDControllerExtension, IDisposable
{
	private enum PhnMBXtAhcFhczaGReGRkQEmdKtx
	{
		X = 0,
		Y = 1,
		Z = 2
	}

	private enum VlKhVWAxlrhMTpJZtPJXanNDSGMW
	{
		None = 0,
		XZ = 1,
		Y = 2
	}

	private enum rfrTwOOXuSACJXCQFvgEMZtbwbkb : byte
	{
		Off = 0,
		Feedback = 1,
		Weapon = 2,
		Vibration = 3,
		SlopeFeedback = 4
	}

	private enum OUBttzqbTMqOLkLhXvVqwaEZiqRB : byte
	{
		High = 0,
		Medium = 1,
		Low = 2
	}

	private enum TFyaRaLQTXxptjcLsBuLFGdlGDwab : byte
	{
		Discharging = 0,
		Charging = 1,
		Full = 2,
		TemperatureOutOfRange = 10,
		TemperatureError = 11,
		ChargingError = 15
	}

	private enum lWxWENWkfvzXpRPDQHMwUBbepaXh
	{
		NotCharging = 0,
		Discharging = 1,
		Charging = 2,
		Full = 3,
		Unknown = 4
	}

	private enum iAYgyXvUXzVhXbdPtzPMVBzLrhyM : byte
	{
		None = 0,
		CompatibleVibrationMode1 = 1,
		HapticsSelect = 2,
		RightTriggerEffect = 4,
		LeftTriggerEffect = 8,
		AudioVolume = 0x10,
		ToggleInternalSpeaker = 0x20,
		MicrophoneVolume = 0x40,
		ToggleInternalMicOrExternalSpeaker = 0x80
	}

	private enum JZwCozFgiREWRRQPzHxOGNOndjbHA : byte
	{
		None = 0,
		MicrophoneLEDControl = 1,
		PowerSaveControl = 2,
		LightbarControl = 4,
		TurnOffLEDs = 8,
		PlayerIndicatorLEDControl = 0x10,
		Unknown1 = 0x20,
		ChangeOverallMotorEffectPower = 0x40,
		Unknown2 = 0x80
	}

	private enum auscnNGQVXhtSciVvcCsBqrIMtZoB : byte
	{
		None = 0,
		OtherLightBrightnessControl = 1,
		LightbarSetupControl = 2,
		CompatibleVibrationMode2 = 4
	}

	private struct NckCuArwgbjHLnjYNvutDMaxnesB
	{
		private const string cnZRZxzCccacdFWrDKBTEfGWJVqUA = "Value must be between 0 and 16.";

		public byte BRDzAdiGnhcntZCXkWjxMrKHDmdx;

		public byte VfagjamqmfuKafVGppCfEsVaenjL
		{
			get
			{
				return pofyWGZRQcDCIpDpcAZjgzgeihtvA();
			}
			set
			{
				kRqxJdTeiAVDRbZYEpDUEpQsrGgE(b);
			}
		}

		public byte jGVULePwCbRikjFhlEUWxikAAOLt
		{
			get
			{
				return RDBcbdUOHycsWfWobQbggbtwPDhGA();
			}
			set
			{
				CYggpeGXwknYYeORYTfmjKwbCuSc(b);
			}
		}

		public byte pofyWGZRQcDCIpDpcAZjgzgeihtvA()
		{
			return (byte)(BRDzAdiGnhcntZCXkWjxMrKHDmdx & 0xF);
		}

		public void kRqxJdTeiAVDRbZYEpDUEpQsrGgE(byte P_0)
		{
			if (P_0 >= 16)
			{
				throw new ArithmeticException("Value must be between 0 and 16.");
			}
			BRDzAdiGnhcntZCXkWjxMrKHDmdx = (byte)((RDBcbdUOHycsWfWobQbggbtwPDhGA() << 4) | (P_0 & 0xF));
		}

		public byte RDBcbdUOHycsWfWobQbggbtwPDhGA()
		{
			return (byte)(BRDzAdiGnhcntZCXkWjxMrKHDmdx >> 4);
		}

		public void CYggpeGXwknYYeORYTfmjKwbCuSc(byte P_0)
		{
			if (P_0 >= 16)
			{
				throw new ArithmeticException("Value must be between 0 and 16.");
			}
			BRDzAdiGnhcntZCXkWjxMrKHDmdx = (byte)((P_0 << 4) | pofyWGZRQcDCIpDpcAZjgzgeihtvA());
		}

		public NckCuArwgbjHLnjYNvutDMaxnesB(byte P_0)
		{
			BRDzAdiGnhcntZCXkWjxMrKHDmdx = P_0;
		}

		public NckCuArwgbjHLnjYNvutDMaxnesB(byte P_0, byte P_1)
		{
			if (P_0 >= 16 || P_1 >= 16)
			{
				throw new ArithmeticException("Value must be between 0 and 16.");
			}
			BRDzAdiGnhcntZCXkWjxMrKHDmdx = (byte)((P_1 << 4) | P_0);
		}
	}

	private static class uvQBqrcDxKDekfvpostrFbXxklko
	{
		public enum osbRroyCaKmiSJmRYiwIpjfPcbsl : byte
		{
			Off = 5,
			Feedback = 33,
			Weapon = 37,
			Vibration = 38,
			Bow = 34,
			Galloping = 35,
			Machine = 39,
			Simple_Feedback = 1,
			Simple_Weapon = 2,
			Simple_Vibration = 6,
			Limited_Feedback = 17,
			Limited_Weapon = 18,
			DebugFC = 252,
			DebugFD = 253,
			DebugFE = 254
		}

		public static class oZkMQrlNTHVmTOmjcAMUCLCWkDwn
		{
			public static class OtddDzlSzQBTdifiAbGvfcgrgjdb
			{
				public static bool ARPYyVOPQrNWeXajCCiRKQSfaCUTA(byte[] P_0, int P_1)
				{
					return kbVZIQhwgzbMIVTkVzTSxlEpUPQC(P_0, P_1);
				}

				public static bool CFnTrLHwUZArvVMwEZXlOTydxglC(byte[] P_0, int P_1, float P_2, float P_3)
				{
					P_2 = (float)Math.Round(P_2 * 9f);
					P_3 = (float)Math.Round(P_3 * 8f);
					return MkZYIgvfHmZcHFbZBXGtSkiEdabDA(P_0, P_1, (byte)P_2, (byte)P_3);
				}

				public static bool BcoldgMpWJxtUwlbYJkXyDfhJYlm(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
				{
					P_2 = (float)Math.Round(P_2 * 9f);
					P_3 = (float)Math.Round(P_3 * 9f);
					P_4 = (float)Math.Round(P_4 * 8f);
					return GpwzTPBPSKzxaGBBtRuHoVzwrcNU(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4);
				}

				public static bool ZHWqjWXrZLSBnNxiTuAMBjDTzexG(byte[] P_0, int P_1, float P_2, float P_3, float P_4)
				{
					P_2 = (float)Math.Round(P_2 * 9f);
					P_3 = (float)Math.Round(P_3 * 8f);
					P_4 = (float)Math.Round(P_4 * 255f);
					return eUNPgwTYyVLIndSPpOeBeMnHaJdAA(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4);
				}

				public static bool RrcwGIwECdaVTiRPsUKnIkmIYHPaA(byte[] P_0, int P_1, float[] P_2)
				{
					if (P_2.Length != 10)
					{
						return false;
					}
					byte[] array = new byte[10];
					for (int i = 0; i < 10; i++)
					{
						array[i] = (byte)Math.Round(P_2[i] * 8f);
					}
					return KWqNOvYvhaAgJgFKoDyLqXTWRjQL(P_0, P_1, array);
				}

				public static bool NZxKPHGpDoVmJdXeDWdUqCYQohig(byte[] P_0, int P_1, float P_2, float P_3, float P_4, float P_5)
				{
					P_2 = (float)Math.Round(P_2 * 9f);
					P_3 = (float)Math.Round(P_3 * 9f);
					P_4 = (float)Math.Round(P_4 * 8f);
					P_5 = (float)Math.Round(P_5 * 8f);
					return AQljzGXPJLTeiEKOZUJvzRJwCrW(P_0, P_1, (byte)P_2, (byte)P_3, (byte)P_4, (byte)P_5);
				}

				public static bool DnWdFjWCfbAvYcOifXGkqdFVYbPG(byte[] P_0, int P_1, float[] P_2, float P_3)
				{
					if (P_2.Length != 10)
					{
						return false;
					}
					P_3 = (float)Math.Round(P_3 * 255f);
					byte[] array = new byte[10];
					for (int i = 0; i < 10; i++)
					{
						array[i] = (byte)Math.Round(P_2[i] * 8f);
					}
					return gtJuZjeJTRSEdFyYqTKvAzJleuNt(P_0, P_1, (byte)P_3, array);
				}
			}

			[Serializable]
			private sealed class qFkkSDvLwhiNFFFMpiHDBnwtvpDV
			{
				public static readonly qFkkSDvLwhiNFFFMpiHDBnwtvpDV _003C_003E9 = new qFkkSDvLwhiNFFFMpiHDBnwtvpDV();

				public static Func<byte, bool> _003C_003E9__4_0;

				public static Func<byte, bool> _003C_003E9__6_0;

				internal bool bQoujGSvhygfFYSoZpCuQUrJzeGd(byte P_0)
				{
					return P_0 > 0;
				}

				internal bool gXUjwXSjmNmRzMKnOsPItnhXrbKv(byte P_0)
				{
					return P_0 > 0;
				}
			}

			public static bool kbVZIQhwgzbMIVTkVzTSxlEpUPQC(byte[] P_0, int P_1)
			{
				P_0[P_1] = 5;
				P_0[P_1 + 1] = 0;
				P_0[P_1 + 2] = 0;
				P_0[P_1 + 3] = 0;
				P_0[P_1 + 4] = 0;
				P_0[P_1 + 5] = 0;
				P_0[P_1 + 6] = 0;
				P_0[P_1 + 7] = 0;
				P_0[P_1 + 8] = 0;
				P_0[P_1 + 9] = 0;
				P_0[P_1 + 10] = 0;
				return true;
			}

			public static bool MkZYIgvfHmZcHFbZBXGtSkiEdabDA(byte[] P_0, int P_1, byte P_2, byte P_3)
			{
				if (P_2 > 9)
				{
					return false;
				}
				if (P_3 > 8)
				{
					return false;
				}
				if (P_3 > 0)
				{
					byte b = (byte)((P_3 - 1) & 7);
					uint num = 0u;
					ushort num2 = 0;
					for (int i = P_2; i < 10; i++)
					{
						num |= (uint)(b << 3 * i);
						num2 |= (ushort)(1 << i);
					}
					P_0[P_1] = 33;
					P_0[P_1 + 1] = (byte)(num2 & 0xFF);
					P_0[P_1 + 2] = (byte)((num2 >> 8) & 0xFF);
					P_0[P_1 + 3] = (byte)(num & 0xFF);
					P_0[P_1 + 4] = (byte)((num >> 8) & 0xFF);
					P_0[P_1 + 5] = (byte)((num >> 16) & 0xFF);
					P_0[P_1 + 6] = (byte)((num >> 24) & 0xFF);
					P_0[P_1 + 7] = 0;
					P_0[P_1 + 8] = 0;
					P_0[P_1 + 9] = 0;
					P_0[P_1 + 10] = 0;
					return true;
				}
				return kbVZIQhwgzbMIVTkVzTSxlEpUPQC(P_0, P_1);
			}

			public static bool GpwzTPBPSKzxaGBBtRuHoVzwrcNU(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
			{
				if (P_2 > 7 || P_2 < 2)
				{
					return false;
				}
				if (P_3 > 8)
				{
					return false;
				}
				if (P_3 <= P_2)
				{
					return false;
				}
				if (P_4 > 8)
				{
					return false;
				}
				if (P_4 > 0)
				{
					ushort num = (ushort)((1 << (int)P_2) | (1 << (int)P_3));
					P_0[P_1] = 37;
					P_0[P_1 + 1] = (byte)(num & 0xFF);
					P_0[P_1 + 2] = (byte)((num >> 8) & 0xFF);
					P_0[P_1 + 3] = (byte)(P_4 - 1);
					P_0[P_1 + 4] = 0;
					P_0[P_1 + 5] = 0;
					P_0[P_1 + 6] = 0;
					P_0[P_1 + 7] = 0;
					P_0[P_1 + 8] = 0;
					P_0[P_1 + 9] = 0;
					P_0[P_1 + 10] = 0;
					return true;
				}
				return kbVZIQhwgzbMIVTkVzTSxlEpUPQC(P_0, P_1);
			}

			public static bool eUNPgwTYyVLIndSPpOeBeMnHaJdAA(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
			{
				if (P_2 > 9)
				{
					return false;
				}
				if (P_3 > 8)
				{
					return false;
				}
				if (P_3 > 0 && P_4 > 0)
				{
					byte b = (byte)((P_3 - 1) & 7);
					uint num = 0u;
					ushort num2 = 0;
					for (int i = P_2; i < 10; i++)
					{
						num |= (uint)(b << 3 * i);
						num2 |= (ushort)(1 << i);
					}
					P_0[P_1] = 38;
					P_0[P_1 + 1] = (byte)(num2 & 0xFF);
					P_0[P_1 + 2] = (byte)((num2 >> 8) & 0xFF);
					P_0[P_1 + 3] = (byte)(num & 0xFF);
					P_0[P_1 + 4] = (byte)((num >> 8) & 0xFF);
					P_0[P_1 + 5] = (byte)((num >> 16) & 0xFF);
					P_0[P_1 + 6] = (byte)((num >> 24) & 0xFF);
					P_0[P_1 + 7] = 0;
					P_0[P_1 + 8] = 0;
					P_0[P_1 + 9] = P_4;
					P_0[P_1 + 10] = 0;
					return true;
				}
				return kbVZIQhwgzbMIVTkVzTSxlEpUPQC(P_0, P_1);
			}

			public static bool KWqNOvYvhaAgJgFKoDyLqXTWRjQL(byte[] P_0, int P_1, byte[] P_2)
			{
				if (P_2.Length != 10)
				{
					return false;
				}
				if (P_2.Any(qFkkSDvLwhiNFFFMpiHDBnwtvpDV._003C_003E9.bQoujGSvhygfFYSoZpCuQUrJzeGd))
				{
					uint num = 0u;
					ushort num2 = 0;
					for (int i = 0; i < 10; i++)
					{
						if (P_2[i] > 0)
						{
							byte b = (byte)((P_2[i] - 1) & 7);
							num |= (uint)(b << 3 * i);
							num2 |= (ushort)(1 << i);
						}
					}
					P_0[P_1] = 33;
					P_0[P_1 + 1] = (byte)(num2 & 0xFF);
					P_0[P_1 + 2] = (byte)((num2 >> 8) & 0xFF);
					P_0[P_1 + 3] = (byte)(num & 0xFF);
					P_0[P_1 + 4] = (byte)((num >> 8) & 0xFF);
					P_0[P_1 + 5] = (byte)((num >> 16) & 0xFF);
					P_0[P_1 + 6] = (byte)((num >> 24) & 0xFF);
					P_0[P_1 + 7] = 0;
					P_0[P_1 + 8] = 0;
					P_0[P_1 + 9] = 0;
					P_0[P_1 + 10] = 0;
					return true;
				}
				return kbVZIQhwgzbMIVTkVzTSxlEpUPQC(P_0, P_1);
			}

			public static bool AQljzGXPJLTeiEKOZUJvzRJwCrW(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
			{
				if (P_2 > 8 || P_2 < 0)
				{
					return false;
				}
				if (P_3 > 9)
				{
					return false;
				}
				if (P_3 <= P_2)
				{
					return false;
				}
				if (P_4 > 8)
				{
					return false;
				}
				if (P_4 < 1)
				{
					return false;
				}
				if (P_5 > 8)
				{
					return false;
				}
				if (P_5 < 1)
				{
					return false;
				}
				byte[] array = new byte[10];
				float num = 1f * (float)(P_5 - P_4) / (float)(P_3 - P_2);
				for (int i = P_2; i < 10; i++)
				{
					if (i <= P_3)
					{
						array[i] = (byte)Math.Round((float)(int)P_4 + num * (float)(i - P_2));
					}
					else
					{
						array[i] = P_5;
					}
				}
				return KWqNOvYvhaAgJgFKoDyLqXTWRjQL(P_0, P_1, array);
			}

			public static bool gtJuZjeJTRSEdFyYqTKvAzJleuNt(byte[] P_0, int P_1, byte P_2, byte[] P_3)
			{
				if (P_3.Length != 10)
				{
					return false;
				}
				if (P_2 > 0 && P_3.Any(qFkkSDvLwhiNFFFMpiHDBnwtvpDV._003C_003E9.gXUjwXSjmNmRzMKnOsPItnhXrbKv))
				{
					uint num = 0u;
					ushort num2 = 0;
					for (int i = 0; i < 10; i++)
					{
						if (P_3[i] > 0)
						{
							byte b = (byte)((P_3[i] - 1) & 7);
							num |= (uint)(b << 3 * i);
							num2 |= (ushort)(1 << i);
						}
					}
					P_0[P_1] = 38;
					P_0[P_1 + 1] = (byte)(num2 & 0xFF);
					P_0[P_1 + 2] = (byte)((num2 >> 8) & 0xFF);
					P_0[P_1 + 3] = (byte)(num & 0xFF);
					P_0[P_1 + 4] = (byte)((num >> 8) & 0xFF);
					P_0[P_1 + 5] = (byte)((num >> 16) & 0xFF);
					P_0[P_1 + 6] = (byte)((num >> 24) & 0xFF);
					P_0[P_1 + 7] = 0;
					P_0[P_1 + 8] = 0;
					P_0[P_1 + 9] = P_2;
					P_0[P_1 + 10] = 0;
					return true;
				}
				return kbVZIQhwgzbMIVTkVzTSxlEpUPQC(P_0, P_1);
			}

			public static bool QtRaMqxLHjtwecabqOBKWmZiHzwL(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5)
			{
				if (P_2 > 8)
				{
					return false;
				}
				if (P_3 > 8)
				{
					return false;
				}
				if (P_2 >= P_3)
				{
					return false;
				}
				if (P_4 > 8)
				{
					return false;
				}
				if (P_5 > 8)
				{
					return false;
				}
				if (P_3 > 0 && P_4 > 0 && P_5 > 0)
				{
					ushort num = (ushort)((1 << (int)P_2) | (1 << (int)P_3));
					uint num2 = (uint)(((P_4 - 1) & 7) | (((P_5 - 1) & 7) << 3));
					P_0[P_1] = 34;
					P_0[P_1 + 1] = (byte)(num & 0xFF);
					P_0[P_1 + 2] = (byte)((num >> 8) & 0xFF);
					P_0[P_1 + 3] = (byte)(num2 & 0xFF);
					P_0[P_1 + 4] = (byte)((num2 >> 8) & 0xFF);
					P_0[P_1 + 5] = 0;
					P_0[P_1 + 6] = 0;
					P_0[P_1 + 7] = 0;
					P_0[P_1 + 8] = 0;
					P_0[P_1 + 9] = 0;
					P_0[P_1 + 10] = 0;
					return true;
				}
				return kbVZIQhwgzbMIVTkVzTSxlEpUPQC(P_0, P_1);
			}

			public static bool oDirRBEWPsYdarQFKNVXPMBkaebG(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6)
			{
				if (P_2 > 8)
				{
					return false;
				}
				if (P_3 > 9)
				{
					return false;
				}
				if (P_2 >= P_3)
				{
					return false;
				}
				if (P_5 > 7)
				{
					return false;
				}
				if (P_4 > 6)
				{
					return false;
				}
				if (P_4 >= P_5)
				{
					return false;
				}
				if (P_6 > 0)
				{
					ushort num = (ushort)((1 << (int)P_2) | (1 << (int)P_3));
					uint num2 = (uint)((P_5 & 7) | ((P_4 & 7) << 3));
					P_0[P_1] = 35;
					P_0[P_1 + 1] = (byte)(num & 0xFF);
					P_0[P_1 + 2] = (byte)((num >> 8) & 0xFF);
					P_0[P_1 + 3] = (byte)(num2 & 0xFF);
					P_0[P_1 + 4] = P_6;
					P_0[P_1 + 5] = 0;
					P_0[P_1 + 6] = 0;
					P_0[P_1 + 7] = 0;
					P_0[P_1 + 8] = 0;
					P_0[P_1 + 9] = 0;
					P_0[P_1 + 10] = 0;
					return true;
				}
				return kbVZIQhwgzbMIVTkVzTSxlEpUPQC(P_0, P_1);
			}

			public static bool wVPoXWhDyiUMUWPSnNuZyCZPHCFu(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4, byte P_5, byte P_6, byte P_7)
			{
				if (P_2 > 8)
				{
					return false;
				}
				if (P_3 > 9)
				{
					return false;
				}
				if (P_3 <= P_2)
				{
					return false;
				}
				if (P_4 > 7)
				{
					return false;
				}
				if (P_5 > 7)
				{
					return false;
				}
				if (P_6 > 0)
				{
					ushort num = (ushort)((1 << (int)P_2) | (1 << (int)P_3));
					uint num2 = (uint)((P_4 & 7) | ((P_5 & 7) << 3));
					P_0[P_1] = 39;
					P_0[P_1 + 1] = (byte)(num & 0xFF);
					P_0[P_1 + 2] = (byte)((num >> 8) & 0xFF);
					P_0[P_1 + 3] = (byte)(num2 & 0xFF);
					P_0[P_1 + 4] = P_6;
					P_0[P_1 + 5] = P_7;
					P_0[P_1 + 6] = 0;
					P_0[P_1 + 7] = 0;
					P_0[P_1 + 8] = 0;
					P_0[P_1 + 9] = 0;
					P_0[P_1 + 10] = 0;
					return true;
				}
				return kbVZIQhwgzbMIVTkVzTSxlEpUPQC(P_0, P_1);
			}

			public static bool twJayQTcHhFunGfVYZrcSgtfcZAf(byte[] P_0, int P_1, byte P_2, byte P_3)
			{
				P_0[P_1] = 1;
				P_0[P_1 + 1] = P_2;
				P_0[P_1 + 2] = P_3;
				P_0[P_1 + 3] = 0;
				P_0[P_1 + 4] = 0;
				P_0[P_1 + 5] = 0;
				P_0[P_1 + 6] = 0;
				P_0[P_1 + 7] = 0;
				P_0[P_1 + 8] = 0;
				P_0[P_1 + 9] = 0;
				P_0[P_1 + 10] = 0;
				return true;
			}

			public static bool dLpAneJtSIKYxAhbGbCaSNFgmXCOB(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
			{
				P_0[P_1] = 2;
				P_0[P_1 + 1] = P_2;
				P_0[P_1 + 2] = P_3;
				P_0[P_1 + 3] = P_4;
				P_0[P_1 + 4] = 0;
				P_0[P_1 + 5] = 0;
				P_0[P_1 + 6] = 0;
				P_0[P_1 + 7] = 0;
				P_0[P_1 + 8] = 0;
				P_0[P_1 + 9] = 0;
				P_0[P_1 + 10] = 0;
				return true;
			}

			public static bool lGNAcuifAlvBQSzjNnStuOgmOWjGb(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
			{
				if (P_4 > 0 && P_3 > 0)
				{
					P_0[P_1] = 6;
					P_0[P_1 + 1] = P_4;
					P_0[P_1 + 2] = P_3;
					P_0[P_1 + 3] = P_2;
					P_0[P_1 + 4] = 0;
					P_0[P_1 + 5] = 0;
					P_0[P_1 + 6] = 0;
					P_0[P_1 + 7] = 0;
					P_0[P_1 + 8] = 0;
					P_0[P_1 + 9] = 0;
					P_0[P_1 + 10] = 0;
					return true;
				}
				return kbVZIQhwgzbMIVTkVzTSxlEpUPQC(P_0, P_1);
			}

			public static bool djJYVaxqbEUrbieGjtCcfXTNpNUs(byte[] P_0, int P_1, byte P_2, byte P_3)
			{
				if (P_3 > 10)
				{
					return false;
				}
				if (P_3 > 0)
				{
					P_0[P_1] = 17;
					P_0[P_1 + 1] = P_2;
					P_0[P_1 + 2] = P_3;
					P_0[P_1 + 3] = 0;
					P_0[P_1 + 4] = 0;
					P_0[P_1 + 5] = 0;
					P_0[P_1 + 6] = 0;
					P_0[P_1 + 7] = 0;
					P_0[P_1 + 8] = 0;
					P_0[P_1 + 9] = 0;
					P_0[P_1 + 10] = 0;
					return true;
				}
				return kbVZIQhwgzbMIVTkVzTSxlEpUPQC(P_0, P_1);
			}

			public static bool xsfdeRFgDUMjUIWwBcIUvLMTFmxLb(byte[] P_0, int P_1, byte P_2, byte P_3, byte P_4)
			{
				if (P_2 < 16)
				{
					return false;
				}
				if (P_3 < P_2 || P_2 + 100 < P_3)
				{
					return false;
				}
				if (P_4 > 10)
				{
					return false;
				}
				if (P_4 > 0)
				{
					P_0[P_1] = 18;
					P_0[P_1 + 1] = P_2;
					P_0[P_1 + 2] = P_3;
					P_0[P_1 + 3] = P_4;
					P_0[P_1 + 4] = 0;
					P_0[P_1 + 5] = 0;
					P_0[P_1 + 6] = 0;
					P_0[P_1 + 7] = 0;
					P_0[P_1 + 8] = 0;
					P_0[P_1 + 9] = 0;
					P_0[P_1 + 10] = 0;
					return true;
				}
				return kbVZIQhwgzbMIVTkVzTSxlEpUPQC(P_0, P_1);
			}
		}
	}

	private const float OLkDMNEiVIXdzlkqXsonHNwNRUMsA = 4f;

	private const int MVoUoofGhyUenCyGuWdpidYeXLFg = 15;

	private const int oaejYwDpZZLfhduOSYCakMPOpwHg = 2;

	private const int HQaEHtjrZZChzacAqbiNvrYUCTmJ = 0;

	private const int UWBhtijdQvHdfPlaYdyHyjJGxQNbA = 1912;

	private const int MLymNWVaudwPqkCFCXKGfZtkPPMx = 0;

	private const int dmzcLccQpvwvAQSIzyVmipXnBbQG = 941;

	private const bool hkTwAvnkWpJuaIYrjMLUFGmpAxUH = false;

	private const bool mymXbQHipoqFJwFrZQcRAxrObBlE = true;

	private const float XgosNhySKmluAeGUETRloYIJeFyC = 2.5f;

	private const int HZwQaveLNtgCnSctAMjCzIHQPeUA = 0;

	private const int MtGuGslctKuSKFjbgDgifivpRECGA = 0;

	private const int JeJlRDWMthtUIbsyFJSsROjnFEfKA = 1;

	private const int qeFpgRykPaAkQHGZZlHcDIXJwkxFA = 0;

	private const int ckCgcvIauePMhVbuIExtiBErpIeZA = 0;

	private const int hFRQrLPKFaIwjdEHhyScydWZGWIW = 0;

	private const int IASLvDuHbWgRYhUjCAwEoulgQzox = 1;

	private const int zaOSlEhKNQGdvyaSqeQIzDvOjIhs = 49;

	private const int JFjsSrnKdmaJJSEMzfTavguHHYFK = 0;

	private const int sBOyVqXkAthaNyMJeMZfxwjGsTuB = 1;

	private const int PHEZVuplSJLBuxhtkcRZDQFvmUuK = 64;

	private const int TYrPhNGhRGdoilbSTvyAXNMfBuQE = 48;

	private const int fCgCpNECedmditcdCAOqprtRAfjPA = 78;

	private const int XuBoYiyUMqhqvCzStwOqSLUqkZhH = 5;

	private const int dFTDiYIBNzDKvENkiZCGfbvJBBGGc = 41;

	private const byte wxozdtjYiSVgWlHhMbhInDEMCNBbA = 1;

	private const byte QCBvfMaGRgbfmDvLLyNgdrvDDHwe = 2;

	private const int SUtHGDDmSXUFfWGCqwDXfwLIppTw = 1;

	private const int vYOahufhIbKdfGMdnavhfKHbagUxb = 2;

	private const int EIRHAWbDRoeZCFsegwqbNBfhjoCib = 3;

	private const int yPPQtKwYiRJwxoGYXpwPiwSUaExF = 4;

	private const int peMAVZCZHOIyVrGFBBBCjJJFIUzjB = 5;

	private const int gAzpkcuZAAZRZoQPgwHQqFqDDelk = 6;

	private const int JQScbKSMMPLrRVyqBTBGuYUqsUPL = 8;

	private const int hhBCCUXBQSFWpwwXFXAxNOLVfrUy = 22;

	private const int PfNGqSqBOwOcgHOHePLJONoykHi = 16;

	private const int GcoEKHigKwpxUQpurjPDgZmvQNmB = 33;

	private const int hRtkKCaGhdjcLAXmoKFxgwvbfuAM = 8;

	private const int FJEMiyHKgcZdwEhFnwabLltFHqKF = 9;

	private const int hMQELPghowBANcgKjEIpenkIQRfpA = 10;

	private const int UlcWLplGRXEFBjWDeGZXJlPqOJxu = 28;

	private const int LCYdjgeFkiESzOebjuRstJOUrCMNA = 53;

	private const int KtIOjFBTQhkxlFJQTvZyqzojOhym = 54;

	private const int HEoZEApwItwyxdvOEQRALzdOASOC = 43;

	private const int WzbwhwFaidtqkJKoMHmGCrRBhymB = 42;

	private const int ooTKgMHeWRllvLHZVfohjmlvAkwx = 48;

	private const bool faofWCBDMbqpcgMxVzorjtxDlFFvA = true;

	private const int abjVXYUDSIUtNCMDYHyYqDjcTjAM = 60;

	private const int AAKjTwCBVssYOTVVuDzxfSJbFbvBA = 60;

	private const int KmUYlnrAEPaFjBoobqzErqxgJKKL = 3000000;

	private const float hsvMUuDNEeeOftwQHxrCKjEPoIwh = 8192f;

	private const float PcQmHyMjHBfZlGsfiKhjVlcwVmqU = 0.0010652969f;

	private const float UjXsUkPdTFqLYGWEuaAjCwGLRxDM = 0.06103702f;

	private const bool FVjcIkcpuhBGINpHiXUJEyQrssSG = true;

	private const bool qmRAMJdOXxFfqsRUnFMKlHYEbpzMA = true;

	private const bool teofYylhompAXpefLYFbtBzVFWaq = true;

	private const bool ZesDgrFlfjQDwgVYUDYNsCpRtbKB = true;

	private const float wCyforLWurAGrcRvKuhrtInUQnFbA = 4096f;

	private const float qpsxMetGLNMlPwJTajvYZXRzgOsH = 16384f;

	private const float zIxLYUVjPSiEDurEvefqbTODtBQFA = 16777216f;

	private const float afBNJGfipRbcgvphCGWWmkjTHZUd = 268435460f;

	private const float ZTUwyJvfWHRZvlfsyaFbWoYVGMHdA = 0.01999998f;

	private const float PtILTydJenfHVaMPOcaoDpTTobwf = 8192f;

	private const float URQIgzwBbgRvGiPNcaFmbCtTDsPMA = 0.98f;

	private const float rduHVzwlrKregbPQkNjuIhhWBINj = 45f;

	private const float xoxCKmhJDSAUhFLvAkVQIVjSyxlXA = 20f;

	private const DualSenseVibrationMode ipNQvFRezSATgsICfSOnjTPZlYcB = DualSenseVibrationMode.Compatible2;

	private readonly IHIDDevice vYQflXkltQIfLKoqsiLFWfbnmPRtA;

	private readonly HIDProperties DwlXqFCJQeIokYIEASPeZUJsvylB;

	private readonly bool vDuFkngDDEgBaZtxPixXkuqffnnxA;

	private readonly int CNVNkYBRpYOIseDOwNEGRxIyphJt;

	private readonly int AItiiweGwOagdLrBkGwbXuPMcbZR;

	private readonly bool VepGAwtGCxFpXGmrHhKwXObqpgsjA;

	private readonly byte WuaSLRQMbmiiAJWdHBJfExqXKhrX;

	private readonly int vPxjgrSwkXIICulkAIpEchIbPpMn;

	private readonly int qjBbnSXncjopSgxZKhoNeHGmWpsq;

	private readonly int VJjekAgvyojxuBnSKeHTvxAofFzI;

	private readonly int suycAzGJfAENrUHbMuPvvUgWgMXqA;

	private readonly NativeBuffer YJauqHMYVvJngOTmuFfEIRuZgwtr;

	private readonly NativeBuffer wfkntfxVPBpztXLroSSthYSAWvbc;

	private YgqnhctsoyAiZixKeAsniiZNPqQeA FoYzqJlFhhwnPovwRjDJFfFKTzTm;

	private int WuWEwYbAYsEdPLZocvENIaxTtcHv;

	private bool CbJfDVnsosKjVGszmODDtYDdJzek;

	private bool OOhkrKUnAsnwKWWgVPjfrMGObWjX;

	private double VYQGFSkRDQBEHJmFyIElDfhjXslyb;

	private int DAGXDAaHKKTahhzCDttZgQSxpmpt;

	private lWxWENWkfvzXpRPDQHMwUBbepaXh NZWohAvKtJUTbmqMHBKvwCMrGIFz;

	private bool cNcWVzabxuuCfcBYQRipsgYpeCzO;

	private Quaternion RJZPXozEHigHLIXIQKpnoeKHfBvZ = Quaternion.identity;

	private DualSenseMicrophoneLightMode VwscpRJkNLGgPlnnmlRbkXrqDQPA;

	private OUBttzqbTMqOLkLhXvVqwaEZiqRB xUiOqQjlkHsufvSxtXtqbyXUOMFQ;

	private DualSensePlayerLightFlags ubNIxACZAjQMpbeXBzQJWKYDlroiA;

	private bool ulSCjlcnMfSOmzJjgFlpfnDUOoFs;

	private uint aMVGRuMGQoIvqOVSmzmhmfYIeMZp;

	private float UaJHYlMlzRUqETxfRvJTcRAuItxW;

	private double OtrTnSCdykHHsSjVxAyjstliwwit;

	private float vddXtUfzTIibXCtmEDWDZiHdcTTp;

	private readonly IDualSenseTriggerEffect[] kbFylPbRkZWGmOzxdjLXdCfujROfA = new IDualSenseTriggerEffect[2];

	private readonly byte[] NsCbNGjgqHpoZAjWnjXinjElWMGOA = new byte[10];

	private readonly byte[] HJHpxmvUNCidGqvjXapxdaySRTAE = new byte[11];

	private DualSenseTriggerEffectState[] vEYqEIqGRilXjKwEonSkAhbQdquy = new DualSenseTriggerEffectState[2];

	private DualSenseVibrationMode vlIoyOsPQeNzgbZRunGISSsmFiTA;

	private byte YoVFTPaEYYyThrbXAymCixCgVxSJA;

	private bool qHgHyAKUibEeghwmrsxMoCFGieChA;

	private bool zawMkmbsVmFmCeQIOwjpnkhoFZoM;

	private bool hyQAzoKwDzcxKYUsgaauYtsJzCQD;

	private bool ctICCtEGroVmJxaxGcCmWYyrOHZL;

	private bool sklGWubkJXTpgTfVUaQjCCyYMYvd;

	private bool JgPBUkvndddfTgtDGRIXhTwLOOTRA;

	private bool PdhVaqUBPcauqhDamhOpsVawtzxL;

	private bool nBuavkrmLYDDYTeisxjEPofgmCdk;

	private bool uWNmMdDQHoHPiAzdxaLTCVPfgALEB;

	private byte hmXzSUalrYHRfTwRaUkWerLEPhYd;

	private byte NuGgNFbLToKnYfJFcHUDDvtkUKcDc;

	private Quaternion bGoMZrUGRkKWSOpURHYucQRVsPuX = Quaternion.identity;

	private Quaternion BOPzrbQchlqAtgsOdJNKHJjOXGsr = Quaternion.identity;

	private bool HVmBQsATdeUOSalCBbtSrvMrCZDlA;

	private int ARkGmmrKKTmoAdExaIYRFhSxcYYr;

	private int[] mdTpqgmeeMqXNJeJOaogBdBuElUc = new int[2];

	private int[] VEAgcmTuLudqYJUgeqcLudxJZJnD = new int[2];

	private static uint[] NOyrZARErKfsOEiflfLCIcGiIFgzA = new uint[256]
	{
		3523407757u, 2768625435u, 1007455905u, 1259060791u, 3580832660u, 2724731650u, 996231864u, 1281784366u, 3705235391u, 2883475241u,
		852952723u, 1171273221u, 3686048678u, 2897449776u, 901431946u, 1119744540u, 3484811241u, 3098726271u, 565944005u, 1455205971u,
		3369614320u, 3219065702u, 651582172u, 1372678730u, 3245242331u, 3060352845u, 794826487u, 1483155041u, 3322131394u, 2969862996u,
		671994606u, 1594548856u, 3916222277u, 2657877971u, 123907689u, 1885708031u, 3993045852u, 2567322570u, 1010288u, 1997036262u,
		3887548279u, 2427484129u, 163128923u, 2126386893u, 3772416878u, 2547889144u, 248832578u, 2043925204u, 4108050209u, 2212294583u,
		450215437u, 1842515611u, 4088798008u, 2226203566u, 498629140u, 1790921346u, 4194326291u, 2366072709u, 336475711u, 1661535913u,
		4251816714u, 2322244508u, 325317158u, 1684325040u, 2766056989u, 3554254475u, 1255198513u, 1037565863u, 2746444292u, 3568589458u,
		1304234792u, 985283518u, 2852464175u, 3707901625u, 1141589763u, 856455061u, 2909332022u, 3664761504u, 1130791706u, 878818188u,
		3110715001u, 3463352047u, 1466425173u, 543223747u, 3187964512u, 3372436214u, 1342839628u, 655174618u, 3081909835u, 3233089245u,
		1505515367u, 784033777u, 2967466578u, 3352871620u, 1590793086u, 701932520u, 2679148245u, 3904355907u, 1908338681u, 112844655u,
		2564639436u, 4024072794u, 1993550816u, 30677878u, 2439710439u, 3865851505u, 2137352139u, 140662621u, 2517025534u, 3775001192u,
		2013832146u, 252678980u, 2181537457u, 4110462503u, 1812594589u, 453955339u, 2238339752u, 4067256894u, 1801730948u, 476252946u,
		2363233923u, 4225443349u, 1657960367u, 366298937u, 2343686810u, 4239843852u, 1707062198u, 314082080u, 1069182125u, 1220369467u,
		3518238081u, 2796764439u, 953657524u, 1339070498u, 3604597144u, 2715744526u, 828499103u, 1181144073u, 3748627891u, 2825434405u,
		906764422u, 1091244048u, 3624026538u, 2936369468u, 571309257u, 1426738271u, 3422756325u, 3137613171u, 627095760u, 1382516806u,
		3413039612u, 3161057642u, 752284923u, 1540473965u, 3268974039u, 3051332929u, 733688034u, 1555824756u, 3316994510u, 2998034776u,
		81022053u, 1943239923u, 3940166985u, 2648514015u, 62490748u, 1958656234u, 3988253008u, 2595281350u, 168805463u, 2097738945u,
		3825313147u, 2466682349u, 224526414u, 2053451992u, 3815530850u, 2490061300u, 425942017u, 1852075159u, 4151131437u, 2154433979u,
		504272920u, 1762240654u, 4026595636u, 2265434530u, 397988915u, 1623188645u, 4189500703u, 2393998729u, 282398762u, 1741824188u,
		4275794182u, 2312913296u, 1231433021u, 1046551979u, 2808630289u, 3496967303u, 1309403428u, 957143474u, 2684717064u, 3607279774u,
		1203610895u, 817534361u, 2847130659u, 3736401077u, 1087398166u, 936857984u, 2933784634u, 3654889644u, 1422998873u, 601230799u,
		3135200373u, 3453512931u, 1404893504u, 616286678u, 3182598252u, 3400902906u, 1510651243u, 755860989u, 3020215367u, 3271812305u,
		1567060338u, 710951396u, 3010007134u, 3295551688u, 1913130485u, 84884835u, 2617666777u, 3942734927u, 1969605100u, 40040826u,
		2607524032u, 3966539862u, 2094237127u, 198489425u, 2464015595u, 3856323709u, 2076066270u, 213479752u, 2511347954u, 3803648100u,
		1874795921u, 414723335u, 2175892669u, 4139142187u, 1758648712u, 534112542u, 2262612132u, 4057696306u, 1633981859u, 375629109u,
		2406151311u, 4167943193u, 1711886778u, 286155052u, 2282172566u, 4278190080u
	};

	private const uint nXegbfZLyLLHlvUtCeieTnFnpFgP = 3940166985u;

	private bool isVibrating => EZcesOHsFbyYKjYvaAwWXkSCxCOy();

	float IDriver_DualSense.BatteryLevel => get_BatteryLevel();

	bool IDriver_DualSense.BatteryCharging => get_BatteryCharging();

	DualSenseVibrationMode IDriver_DualSense.vibrationMode
	{
		get
		{
			return get_vibrationMode();
		}
		set
		{
			set_vibrationMode(value);
		}
	}

	float IDriver_DualSense.LeftMotor
	{
		get
		{
			return get_LeftMotor();
		}
		set
		{
			set_LeftMotor(value);
		}
	}

	float IDriver_DualSense.RightMotor
	{
		get
		{
			return get_RightMotor();
		}
		set
		{
			set_RightMotor(value);
		}
	}

	float IDriver_DualSense.LightColorR
	{
		get
		{
			return get_LightColorR();
		}
		set
		{
			set_LightColorR(value);
		}
	}

	float IDriver_DualSense.LightColorG
	{
		get
		{
			return get_LightColorG();
		}
		set
		{
			set_LightColorG(value);
		}
	}

	float IDriver_DualSense.LightColorB
	{
		get
		{
			return get_LightColorB();
		}
		set
		{
			set_LightColorB(value);
		}
	}

	float IDriver_DualSense.LightFlashOnDuration
	{
		get
		{
			return get_LightFlashOnDuration();
		}
		set
		{
			set_LightFlashOnDuration(value);
		}
	}

	float IDriver_DualSense.LightFlashOffDuration
	{
		get
		{
			return get_LightFlashOffDuration();
		}
		set
		{
			set_LightFlashOffDuration(value);
		}
	}

	DualSenseMicrophoneLightMode IDriver_DualSense.microphoneLightMode
	{
		get
		{
			return get_microphoneLightMode();
		}
		set
		{
			set_microphoneLightMode(value);
		}
	}

	DualSenseOtherLightBrightness IDriver_DualSense.otherLightBrightness
	{
		get
		{
			return get_otherLightBrightness();
		}
		set
		{
			set_otherLightBrightness(value);
		}
	}

	DualSensePlayerLightFlags IDriver_DualSense.playerLights
	{
		get
		{
			return get_playerLights();
		}
		set
		{
			set_playerLights(value);
		}
	}

	Vector3 IDriver_DualSense.AccelerometerValue => get_AccelerometerValue();

	Vector3 IDriver_DualSense.AccelerometerValueRaw => get_AccelerometerValueRaw();

	Vector3 IDriver_DualSense.GyroscopeValue => get_GyroscopeValue();

	Vector3 IDriver_DualSense.GyroscopeValueRaw => get_GyroscopeValueRaw();

	Vector3 IDriver_DualSense.LastGyroscopeValue => get_LastGyroscopeValue();

	Vector3 IDriver_DualSense.LastGyroscopeValueRaw => get_LastGyroscopeValueRaw();

	Quaternion IDriver_DualSense.Orientation => get_Orientation();

	int IDriver_DualSense.MaxTouches => get_MaxTouches();

	ushort IHIDControllerExtension.vendorId => DwlXqFCJQeIokYIEASPeZUJsvylB.vendorId;

	ushort IHIDControllerExtension.productId => DwlXqFCJQeIokYIEASPeZUJsvylB.productId;

	string IHIDControllerExtension.productName => DwlXqFCJQeIokYIEASPeZUJsvylB.productName;

	string IHIDControllerExtension.manufacturer => DwlXqFCJQeIokYIEASPeZUJsvylB.manufacturer;

	ushort IHIDControllerExtension.usagePage => DwlXqFCJQeIokYIEASPeZUJsvylB.usagePage;

	ushort IHIDControllerExtension.usage => DwlXqFCJQeIokYIEASPeZUJsvylB.usage;

	private bool EZcesOHsFbyYKjYvaAwWXkSCxCOy()
	{
		for (int i = 0; i < get_VibrationMotorCount(); i++)
		{
			if (vibrationMotors[i].DYWGVvmfVdcRhDBgOuJRwnGnXSli() > 0)
			{
				return true;
			}
		}
		return false;
	}

	public float get_BatteryLevel()
	{
		return DAGXDAaHKKTahhzCDttZgQSxpmpt;
	}

	public bool get_BatteryCharging()
	{
		return NZWohAvKtJUTbmqMHBKvwCMrGIFz == lWxWENWkfvzXpRPDQHMwUBbepaXh.Charging;
	}

	public DualSenseVibrationMode get_vibrationMode()
	{
		return vlIoyOsPQeNzgbZRunGISSsmFiTA;
	}

	public void set_vibrationMode(DualSenseVibrationMode value)
	{
		vlIoyOsPQeNzgbZRunGISSsmFiTA = value;
		enzDdQkgcbCujrmPClufCwlraOde();
	}

	public float get_LeftMotor()
	{
		return vibrationMotors[0].amCmtGfdAUDdaZFcOaPOItQCQwvxA();
	}

	public void set_LeftMotor(float value)
	{
		vibrationMotors[0].PpwdGZtDTfEXYRzvADURwiBhyEjQ(value);
	}

	public float get_RightMotor()
	{
		return vibrationMotors[1].amCmtGfdAUDdaZFcOaPOItQCQwvxA();
	}

	public void set_RightMotor(float value)
	{
		vibrationMotors[1].PpwdGZtDTfEXYRzvADURwiBhyEjQ(value);
	}

	public float get_LightColorR()
	{
		return lights[0].JkOEkXmSevFHHIbHaIPCbPlWahQC();
	}

	public void set_LightColorR(float value)
	{
		lights[0].dmKUYsNgSXMmITOvEWrXLrXwGmvx(value);
	}

	public float get_LightColorG()
	{
		return lights[0].pGhchgeKEMJzEkOggJOWNhBvhEJC();
	}

	public void set_LightColorG(float value)
	{
		lights[0].qoVyMSSfQbOjxsqKXIAwIARRZkFZ(value);
	}

	public float get_LightColorB()
	{
		return lights[0].AJqNhAYOnzCUEbqYvulmqEcmRPcOA();
	}

	public void set_LightColorB(float value)
	{
		lights[0].CYuIGSeGplGAFcqHpZMjSLBFsgxZA(value);
	}

	public float get_LightFlashOnDuration()
	{
		return (int)hmXzSUalrYHRfTwRaUkWerLEPhYd;
	}

	public void set_LightFlashOnDuration(float value)
	{
		hmXzSUalrYHRfTwRaUkWerLEPhYd = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
		nJIJiKWZqDaQOzHzQEwiQnoAtLNf();
		if (hmXzSUalrYHRfTwRaUkWerLEPhYd == 0 && NuGgNFbLToKnYfJFcHUDDvtkUKcDc == 0)
		{
			OOhkrKUnAsnwKWWgVPjfrMGObWjX = true;
		}
	}

	public float get_LightFlashOffDuration()
	{
		return (int)NuGgNFbLToKnYfJFcHUDDvtkUKcDc;
	}

	public void set_LightFlashOffDuration(float value)
	{
		NuGgNFbLToKnYfJFcHUDDvtkUKcDc = (byte)MathTools.Clamp(MathTools.Clamp(value, 0f, 2.5f) * 100f, 0f, 255f);
		nJIJiKWZqDaQOzHzQEwiQnoAtLNf();
		if (hmXzSUalrYHRfTwRaUkWerLEPhYd == 0 && NuGgNFbLToKnYfJFcHUDDvtkUKcDc == 0)
		{
			OOhkrKUnAsnwKWWgVPjfrMGObWjX = true;
		}
	}

	public DualSenseMicrophoneLightMode get_microphoneLightMode()
	{
		return VwscpRJkNLGgPlnnmlRbkXrqDQPA;
	}

	public void set_microphoneLightMode(DualSenseMicrophoneLightMode value)
	{
		VwscpRJkNLGgPlnnmlRbkXrqDQPA = value;
		enzDdQkgcbCujrmPClufCwlraOde();
		ctICCtEGroVmJxaxGcCmWYyrOHZL = true;
	}

	public DualSenseOtherLightBrightness get_otherLightBrightness()
	{
		return zpRfroKUeiwTqQUBXYhorvBoPdtRA(xUiOqQjlkHsufvSxtXtqbyXUOMFQ);
	}

	public void set_otherLightBrightness(DualSenseOtherLightBrightness value)
	{
		xUiOqQjlkHsufvSxtXtqbyXUOMFQ = IllplHGZACiPFjFapVWAlzAeqPEt(value);
		enzDdQkgcbCujrmPClufCwlraOde();
		JgPBUkvndddfTgtDGRIXhTwLOOTRA = true;
	}

	public DualSensePlayerLightFlags get_playerLights()
	{
		return ubNIxACZAjQMpbeXBzQJWKYDlroiA;
	}

	public void set_playerLights(DualSensePlayerLightFlags value)
	{
		ubNIxACZAjQMpbeXBzQJWKYDlroiA = value;
		enzDdQkgcbCujrmPClufCwlraOde();
		sklGWubkJXTpgTfVUaQjCCyYMYvd = true;
	}

	public Vector3 get_AccelerometerValue()
	{
		return IgczdfLLgHgqXbdkCApvhyEiBOqAA(accelerometers[0].kHKNsnXlXktGYBPiLEFMIeDjXJlhA);
	}

	public Vector3 get_AccelerometerValueRaw()
	{
		return new Vector3(accelerometers[0].kHKNsnXlXktGYBPiLEFMIeDjXJlhA[0], accelerometers[0].kHKNsnXlXktGYBPiLEFMIeDjXJlhA[1], accelerometers[0].kHKNsnXlXktGYBPiLEFMIeDjXJlhA[2]);
	}

	public Vector3 get_GyroscopeValue()
	{
		return zjXfydiHtVqKvcGlOKNcUXkllDpy(gyroscopes[0].IZXXwacTbRSqzBmoETmswjBBLJKB());
	}

	public Vector3 get_GyroscopeValueRaw()
	{
		return new Vector3(gyroscopes[0].YAYnMednfYBUXhNTdquxcBMJaPTBB()[0], gyroscopes[0].YAYnMednfYBUXhNTdquxcBMJaPTBB()[1], gyroscopes[0].YAYnMednfYBUXhNTdquxcBMJaPTBB()[2]);
	}

	public Vector3 get_LastGyroscopeValue()
	{
		Vector3 vector = new Vector3(gyroscopes[0].lXibhhIpZcFeBrHtdwGikQrKfnMdb[0], gyroscopes[0].lXibhhIpZcFeBrHtdwGikQrKfnMdb[1], gyroscopes[0].lXibhhIpZcFeBrHtdwGikQrKfnMdb[2]);
		return IAIiCjEgImYTzmpMIMTmoqtfShTS(vector, UaJHYlMlzRUqETxfRvJTcRAuItxW);
	}

	public Vector3 get_LastGyroscopeValueRaw()
	{
		return new Vector3(gyroscopes[0].lXibhhIpZcFeBrHtdwGikQrKfnMdb[0], gyroscopes[0].lXibhhIpZcFeBrHtdwGikQrKfnMdb[1], gyroscopes[0].lXibhhIpZcFeBrHtdwGikQrKfnMdb[2]);
	}

	public Quaternion get_Orientation()
	{
		return RJZPXozEHigHLIXIQKpnoeKHfBvZ;
	}

	public void ResetOrientation()
	{
		RJZPXozEHigHLIXIQKpnoeKHfBvZ = Quaternion.identity;
		HVmBQsATdeUOSalCBbtSrvMrCZDlA = false;
	}

	void IDriver_DualSense.ResetOrientation()
	{
		//ILSpy generated this explicit interface implementation from .override directive in ResetOrientation
		this.ResetOrientation();
	}

	public int get_MaxTouches()
	{
		return 2;
	}

	public int GetTouchCount()
	{
		int num = 0;
		for (int i = 0; i < 2; i++)
		{
			if (touchpads[0].eRxGPKHfVUSoUvYtfLqInWzRcIsH[i].isTouching)
			{
				num++;
			}
		}
		return num;
	}

	int IDriver_DualSense.GetTouchCount()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetTouchCount
		return this.GetTouchCount();
	}

	public bool IsTouchingAtIndex(int index)
	{
		if (index < 0 || index >= 2)
		{
			return false;
		}
		return touchpads[0].eRxGPKHfVUSoUvYtfLqInWzRcIsH[index].isTouching;
	}

	bool IDriver_DualSense.IsTouchingAtIndex(int index)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtIndex
		return this.IsTouchingAtIndex(index);
	}

	public bool IsTouchingAtTouchId(int touchId)
	{
		return touchpads[0].nbrtEjncCqmLPUIIxfqKkvPpFsqbb(touchId);
	}

	bool IDriver_DualSense.IsTouchingAtTouchId(int touchId)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsTouchingAtTouchId
		return this.IsTouchingAtTouchId(touchId);
	}

	public int GetTouchIdAtIndex(int index)
	{
		if (index < 0 || index >= 2)
		{
			return -1;
		}
		return touchpads[0].eRxGPKHfVUSoUvYtfLqInWzRcIsH[index].touchId;
	}

	int IDriver_DualSense.GetTouchIdAtIndex(int index)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetTouchIdAtIndex
		return this.GetTouchIdAtIndex(index);
	}

	public bool GetTouchPositionByIndex(int index, out Vector2 position)
	{
		position = default;
		if (index < 0 || index >= 2)
		{
			return false;
		}
		nLbAcapOagdnNrGGiTONDGTEQuzQ.TouchData[] eRxGPKHfVUSoUvYtfLqInWzRcIsH = touchpads[0].eRxGPKHfVUSoUvYtfLqInWzRcIsH;
		if (!eRxGPKHfVUSoUvYtfLqInWzRcIsH[index].isTouching)
		{
			return false;
		}
		position.x = eRxGPKHfVUSoUvYtfLqInWzRcIsH[index].positionX;
		position.y = eRxGPKHfVUSoUvYtfLqInWzRcIsH[index].positionY;
		return true;
	}

	bool IDriver_DualSense.GetTouchPositionByIndex(int index, out Vector2 position)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionByIndex
		return this.GetTouchPositionByIndex(index, out position);
	}

	public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
	{
		position = default;
		if (!touchpads[0].nbrtEjncCqmLPUIIxfqKkvPpFsqbb(touchId))
		{
			return false;
		}
		nLbAcapOagdnNrGGiTONDGTEQuzQ.TouchData[] eRxGPKHfVUSoUvYtfLqInWzRcIsH = touchpads[0].eRxGPKHfVUSoUvYtfLqInWzRcIsH;
		for (int i = 0; i < eRxGPKHfVUSoUvYtfLqInWzRcIsH.Length; i++)
		{
			if (eRxGPKHfVUSoUvYtfLqInWzRcIsH[i].isTouching)
			{
				position.x = eRxGPKHfVUSoUvYtfLqInWzRcIsH[i].positionX;
				position.y = eRxGPKHfVUSoUvYtfLqInWzRcIsH[i].positionY;
			}
		}
		return true;
	}

	bool IDriver_DualSense.GetTouchPositionByTouchId(int touchId, out Vector2 position)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionByTouchId
		return this.GetTouchPositionByTouchId(touchId, out position);
	}

	public bool GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
	{
		positionX = 0;
		positionY = 0;
		if (index < 0 || index >= 2)
		{
			return false;
		}
		nLbAcapOagdnNrGGiTONDGTEQuzQ.TouchData[] eRxGPKHfVUSoUvYtfLqInWzRcIsH = touchpads[0].eRxGPKHfVUSoUvYtfLqInWzRcIsH;
		if (!eRxGPKHfVUSoUvYtfLqInWzRcIsH[index].isTouching)
		{
			return false;
		}
		positionX = eRxGPKHfVUSoUvYtfLqInWzRcIsH[index].positionAbsX;
		positionY = eRxGPKHfVUSoUvYtfLqInWzRcIsH[index].positionAbsY;
		return true;
	}

	bool IDriver_DualSense.GetTouchPositionAbsoluteByIndex(int index, out int positionX, out int positionY)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionAbsoluteByIndex
		return this.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
	}

	public bool GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
	{
		positionX = 0;
		positionY = 0;
		if (!touchpads[0].nbrtEjncCqmLPUIIxfqKkvPpFsqbb(touchId))
		{
			return false;
		}
		nLbAcapOagdnNrGGiTONDGTEQuzQ.TouchData[] eRxGPKHfVUSoUvYtfLqInWzRcIsH = touchpads[0].eRxGPKHfVUSoUvYtfLqInWzRcIsH;
		for (int i = 0; i < eRxGPKHfVUSoUvYtfLqInWzRcIsH.Length; i++)
		{
			if (eRxGPKHfVUSoUvYtfLqInWzRcIsH[i].isTouching)
			{
				positionX = eRxGPKHfVUSoUvYtfLqInWzRcIsH[i].positionAbsX;
				positionY = eRxGPKHfVUSoUvYtfLqInWzRcIsH[i].positionAbsY;
			}
		}
		return true;
	}

	bool IDriver_DualSense.GetTouchPositionAbsoluteByTouchId(int touchId, out int positionX, out int positionY)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionAbsoluteByTouchId
		return this.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
	}

	public void StopLightFlash()
	{
		hmXzSUalrYHRfTwRaUkWerLEPhYd = 0;
		NuGgNFbLToKnYfJFcHUDDvtkUKcDc = 0;
		enzDdQkgcbCujrmPClufCwlraOde();
		OOhkrKUnAsnwKWWgVPjfrMGObWjX = true;
		PdhVaqUBPcauqhDamhOpsVawtzxL = true;
	}

	void IDriver_DualSense.StopLightFlash()
	{
		//ILSpy generated this explicit interface implementation from .override directive in StopLightFlash
		this.StopLightFlash();
	}

	public void StopVibration()
	{
		int vibrationMotorCount = get_VibrationMotorCount();
		for (int i = 0; i < vibrationMotorCount; i++)
		{
			vibrationMotors[i].ZzeucWTvdVBzsUkrmxpdrFxcbvgG(0);
		}
	}

	void IDriver_DualSense.StopVibration()
	{
		//ILSpy generated this explicit interface implementation from .override directive in StopVibration
		this.StopVibration();
	}

	public bool SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
	{
		switch (trigger)
		{
		case DualSenseTriggerType.Left:
			kbFylPbRkZWGmOzxdjLXdCfujROfA[0] = effect;
			enzDdQkgcbCujrmPClufCwlraOde();
			zawMkmbsVmFmCeQIOwjpnkhoFZoM = true;
			return true;
		case DualSenseTriggerType.Right:
			kbFylPbRkZWGmOzxdjLXdCfujROfA[1] = effect;
			enzDdQkgcbCujrmPClufCwlraOde();
			hyQAzoKwDzcxKYUsgaauYtsJzCQD = true;
			return true;
		default:
			return false;
		}
	}

	bool IDriver_DualSense.SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
	{
		//ILSpy generated this explicit interface implementation from .override directive in SetTriggerEffect
		return this.SetTriggerEffect(trigger, effect);
	}

	public DualSenseTriggerEffectStates GetTriggerEffectStates()
	{
		return new DualSenseTriggerEffectStates
		{
			leftTrigger = vEYqEIqGRilXjKwEonSkAhbQdquy[0],
			rightTrigger = vEYqEIqGRilXjKwEonSkAhbQdquy[1]
		};
	}

	DualSenseTriggerEffectStates IDriver_DualSense.GetTriggerEffectStates()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetTriggerEffectStates
		return this.GetTriggerEffectStates();
	}

	public DualSenseDriver(InitArgs P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("initArgs");
		}
		vYQflXkltQIfLKoqsiLFWfbnmPRtA = P_0.hidDevice;
		DwlXqFCJQeIokYIEASPeZUJsvylB = vYQflXkltQIfLKoqsiLFWfbnmPRtA.properties;
		CNVNkYBRpYOIseDOwNEGRxIyphJt = P_0.hatZeroValue;
		AItiiweGwOagdLrBkGwbXuPMcbZR = P_0.hatSpan;
		vDuFkngDDEgBaZtxPixXkuqffnnxA = P_0.connectionType == mcGCOmKmWTEVYWVKfxUduOlekNVWA.Bluetooth;
		if (vDuFkngDDEgBaZtxPixXkuqffnnxA)
		{
			WuWEwYbAYsEdPLZocvENIaxTtcHv = 78;
		}
		else
		{
			WuWEwYbAYsEdPLZocvENIaxTtcHv = 48;
		}
		YJauqHMYVvJngOTmuFfEIRuZgwtr = new NativeBuffer(64);
		wfkntfxVPBpztXLroSSthYSAWvbc = new NativeBuffer(WuWEwYbAYsEdPLZocvENIaxTtcHv);
		FoYzqJlFhhwnPovwRjDJFfFKTzTm = new YgqnhctsoyAiZixKeAsniiZNPqQeA(wfkntfxVPBpztXLroSSthYSAWvbc.Pointer, wfkntfxVPBpztXLroSSthYSAWvbc.Length, WuWEwYbAYsEdPLZocvENIaxTtcHv);
		lights = new HzYEQAmIRNSiWjhheMaNLEiYjqKH[1]
		{
			new HzYEQAmIRNSiWjhheMaNLEiYjqKH(11, 24, 28)
		};
		lights[0].JsqZEamZPJVwNPTRfoRVPDhHmSeJ(JGMQePRPYWBBiBNEHpMSiRznAOiR);
		vibrationMotors = new UJKgOyiCpkBVwnefNmaagmCQWRFGb[2]
		{
			new UJKgOyiCpkBVwnefNmaagmCQWRFGb(0, 255),
			new UJKgOyiCpkBVwnefNmaagmCQWRFGb(0, 255)
		};
		vibrationMotors[0].kaRSfqFlYVGBiBQLpDLehwzBbhMl(KBsGGPzHyRDfkvKShvcuoPPdbmWM);
		vibrationMotors[1].kaRSfqFlYVGBiBQLpDLehwzBbhMl(KBsGGPzHyRDfkvKShvcuoPPdbmWM);
		vlIoyOsPQeNzgbZRunGISSsmFiTA = DualSenseVibrationMode.Compatible2;
		qHgHyAKUibEeghwmrsxMoCFGieChA = true;
		zawMkmbsVmFmCeQIOwjpnkhoFZoM = true;
		hyQAzoKwDzcxKYUsgaauYtsJzCQD = true;
		ctICCtEGroVmJxaxGcCmWYyrOHZL = true;
		sklGWubkJXTpgTfVUaQjCCyYMYvd = true;
		JgPBUkvndddfTgtDGRIXhTwLOOTRA = true;
		PdhVaqUBPcauqhDamhOpsVawtzxL = true;
		nBuavkrmLYDDYTeisxjEPofgmCdk = true;
		uWNmMdDQHoHPiAzdxaLTCVPfgALEB = true;
		YoVFTPaEYYyThrbXAymCixCgVxSJA = 2;
		if (vDuFkngDDEgBaZtxPixXkuqffnnxA)
		{
			byte[] hidFeatureData = vYQflXkltQIfLKoqsiLFWfbnmPRtA.GetHidFeatureData(5, 41, 1000, 3);
			VepGAwtGCxFpXGmrHhKwXObqpgsjA = hidFeatureData != null && hidFeatureData.Length != 0;
			if (VepGAwtGCxFpXGmrHhKwXObqpgsjA)
			{
				IflzOUkvoVyPOmltUEDTJBUANGXB(lZZYSzlENjVckJKEzwKsVotVgXhb.Synchronous);
			}
		}
		else
		{
			VepGAwtGCxFpXGmrHhKwXObqpgsjA = true;
			VepGAwtGCxFpXGmrHhKwXObqpgsjA = IflzOUkvoVyPOmltUEDTJBUANGXB(lZZYSzlENjVckJKEzwKsVotVgXhb.Synchronous);
		}
		if (!VepGAwtGCxFpXGmrHhKwXObqpgsjA)
		{
			throw new Exception("Special features not supported so just treat this as a standard HID device.");
		}
		WuaSLRQMbmiiAJWdHBJfExqXKhrX = 1;
		vPxjgrSwkXIICulkAIpEchIbPpMn = 0;
		if (vDuFkngDDEgBaZtxPixXkuqffnnxA && VepGAwtGCxFpXGmrHhKwXObqpgsjA)
		{
			WuaSLRQMbmiiAJWdHBJfExqXKhrX = 49;
			vPxjgrSwkXIICulkAIpEchIbPpMn = 1;
		}
		qjBbnSXncjopSgxZKhoNeHGmWpsq = 8 + vPxjgrSwkXIICulkAIpEchIbPpMn;
		VJjekAgvyojxuBnSKeHTvxAofFzI = 9 + vPxjgrSwkXIICulkAIpEchIbPpMn;
		suycAzGJfAENrUHbMuPvvUgWgMXqA = 10 + vPxjgrSwkXIICulkAIpEchIbPpMn;
		buttons = new zcGvJvonyWXVMOLIHiTlBSzzCQP[15];
		for (int i = 0; i < 15; i++)
		{
			buttons[i] = new zcGvJvonyWXVMOLIHiTlBSzzCQP(WuaSLRQMbmiiAJWdHBJfExqXKhrX, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 9,
				usage = (ushort)i
			});
		}
		axes = new CZoMFTjfkBKcdHwbjLAHvGhrFKlm[6]
		{
			new CZoMFTjfkBKcdHwbjLAHvGhrFKlm(WuaSLRQMbmiiAJWdHBJfExqXKhrX, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 48,
				dataIndex = 1 + vPxjgrSwkXIICulkAIpEchIbPpMn,
				bitSize = 8,
				logicalMin = 0,
				logicalMax = 255,
				physicalMin = 0,
				physicalMax = 0,
				units = 0u,
				unitsExp = 0u
			}, false, 127),
			new CZoMFTjfkBKcdHwbjLAHvGhrFKlm(WuaSLRQMbmiiAJWdHBJfExqXKhrX, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 49,
				dataIndex = 2 + vPxjgrSwkXIICulkAIpEchIbPpMn,
				bitSize = 8,
				logicalMin = 0,
				logicalMax = 255,
				physicalMin = 0,
				physicalMax = 0,
				units = 0u,
				unitsExp = 0u
			}, false, 127),
			new CZoMFTjfkBKcdHwbjLAHvGhrFKlm(WuaSLRQMbmiiAJWdHBJfExqXKhrX, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 50,
				dataIndex = 3 + vPxjgrSwkXIICulkAIpEchIbPpMn,
				bitSize = 8,
				logicalMin = 0,
				logicalMax = 255,
				physicalMin = 0,
				physicalMax = 0,
				units = 0u,
				unitsExp = 0u
			}, false, 127),
			new CZoMFTjfkBKcdHwbjLAHvGhrFKlm(WuaSLRQMbmiiAJWdHBJfExqXKhrX, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 53,
				dataIndex = 4 + vPxjgrSwkXIICulkAIpEchIbPpMn,
				bitSize = 8,
				logicalMin = 0,
				logicalMax = 255,
				physicalMin = 0,
				physicalMax = 0,
				units = 0u,
				unitsExp = 0u
			}, false, 127),
			new CZoMFTjfkBKcdHwbjLAHvGhrFKlm(WuaSLRQMbmiiAJWdHBJfExqXKhrX, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 51,
				dataIndex = 5 + vPxjgrSwkXIICulkAIpEchIbPpMn,
				bitSize = 8,
				logicalMin = 0,
				logicalMax = 255,
				physicalMin = 0,
				physicalMax = 315,
				units = 0u,
				unitsExp = 0u
			}, false, 0),
			new CZoMFTjfkBKcdHwbjLAHvGhrFKlm(WuaSLRQMbmiiAJWdHBJfExqXKhrX, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 52,
				dataIndex = 6 + vPxjgrSwkXIICulkAIpEchIbPpMn,
				bitSize = 8,
				logicalMin = 0,
				logicalMax = 255,
				physicalMin = 0,
				physicalMax = 315,
				units = 0u,
				unitsExp = 0u
			}, false, 0)
		};
		hats = new yVtJYaXVmlAkOpMlEdRssBJtGidG[1]
		{
			new yVtJYaXVmlAkOpMlEdRssBJtGidG(WuaSLRQMbmiiAJWdHBJfExqXKhrX, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				usage = 57,
				dataIndex = 8 + vPxjgrSwkXIICulkAIpEchIbPpMn,
				bitSize = 4,
				logicalMin = 0,
				logicalMax = 7,
				physicalMin = 0,
				physicalMax = 315,
				units = 20u,
				unitsExp = 0u
			}, sHJgStAkhwIMIGmvDLdiAOmDMSNKc)
		};
		accelerometers = new PuNiRanhRtGcawmdkdYFXXryaDNI[1]
		{
			new PuNiRanhRtGcawmdkdYFXXryaDNI(WuaSLRQMbmiiAJWdHBJfExqXKhrX, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				dataIndex = 22 + vPxjgrSwkXIICulkAIpEchIbPpMn,
				bitSize = 48
			}, 3, BJLxmlYvWNraQDiBisYTAIgxHJVx)
		};
		gyroscopes = new HzWNjGbJTcqWRFLBLnqFlnsJEvnz[1]
		{
			new HzWNjGbJTcqWRFLBLnqFlnsJEvnz(P_0.updateLoopSetting, WuaSLRQMbmiiAJWdHBJfExqXKhrX, new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				dataIndex = 16 + vPxjgrSwkXIICulkAIpEchIbPpMn,
				bitSize = 48
			}, 3, 60, NUKgYqZGvVvGqoWJvJIkNRLfuwPg, LTqkSRlarcrTngenGpALCdUPYNXl)
		};
		touchpads = new nLbAcapOagdnNrGGiTONDGTEQuzQ[1]
		{
			new nLbAcapOagdnNrGGiTONDGTEQuzQ(WuaSLRQMbmiiAJWdHBJfExqXKhrX, new nLbAcapOagdnNrGGiTONDGTEQuzQ.TouchpadInfo(2, 0, 1912, 0, 941, false, true), new xRwbEhgwfqETGQkYCofyzWNojclTA.HIDInfo
			{
				usagePage = 1,
				dataIndex = 33 + vPxjgrSwkXIICulkAIpEchIbPpMn,
				bitSize = 48
			}, 60, FHjAoedcxFmgKuEnsbAanzqZIOlQA)
		};
		OtrTnSCdykHHsSjVxAyjstliwwit = ReInput.realTime;
	}

	public override void Update(UpdateLoopType updateLoop)
	{
		OKqDaIfdCCgaYSOKYjgCaSMfNDjYb();
		qGGADwJzrlQOGAfXRdiiCsaCgsnPc(lZZYSzlENjVckJKEzwKsVotVgXhb.Asynchronous);
	}

	public unsafe override bool ParseInputReport(IntPtr inputReportPtr, int inputReportLength, double timestamp)
	{
		if (inputReportPtr == IntPtr.Zero)
		{
			return false;
		}
		if (inputReportLength < YJauqHMYVvJngOTmuFfEIRuZgwtr.Length)
		{
			return false;
		}
		if (vDuFkngDDEgBaZtxPixXkuqffnnxA && VepGAwtGCxFpXGmrHhKwXObqpgsjA && *(byte*)(void*)inputReportPtr == 1)
		{
			return false;
		}
		vddXtUfzTIibXCtmEDWDZiHdcTTp = (float)(timestamp - OtrTnSCdykHHsSjVxAyjstliwwit);
		OtrTnSCdykHHsSjVxAyjstliwwit = timestamp;
		YJauqHMYVvJngOTmuFfEIRuZgwtr.Write(inputReportPtr, inputReportLength, YJauqHMYVvJngOTmuFfEIRuZgwtr.Length);
		wUPxMnEXWcoybUgNihdNaeeUhwLNA(YJauqHMYVvJngOTmuFfEIRuZgwtr);
		YobdcqgaYyTqxInJxcQgpSJRNhGK(YJauqHMYVvJngOTmuFfEIRuZgwtr, timestamp);
		xRwbEhgwfqETGQkYCofyzWNojclTA[] array = axes;
		lAlEspBmBJwvOGbcCptkQVevcihH(array, YJauqHMYVvJngOTmuFfEIRuZgwtr, timestamp);
		array = hats;
		lAlEspBmBJwvOGbcCptkQVevcihH(array, YJauqHMYVvJngOTmuFfEIRuZgwtr, timestamp);
		array = accelerometers;
		lAlEspBmBJwvOGbcCptkQVevcihH(array, YJauqHMYVvJngOTmuFfEIRuZgwtr, timestamp);
		array = gyroscopes;
		lAlEspBmBJwvOGbcCptkQVevcihH(array, YJauqHMYVvJngOTmuFfEIRuZgwtr, timestamp);
		array = touchpads;
		lAlEspBmBJwvOGbcCptkQVevcihH(array, YJauqHMYVvJngOTmuFfEIRuZgwtr, timestamp);
		byte b = YJauqHMYVvJngOTmuFfEIRuZgwtr[53 + vPxjgrSwkXIICulkAIpEchIbPpMn];
		TFyaRaLQTXxptjcLsBuLFGdlGDwab tFyaRaLQTXxptjcLsBuLFGdlGDwab = (TFyaRaLQTXxptjcLsBuLFGdlGDwab)((b & 0xF0) >> 4);
		if (tFyaRaLQTXxptjcLsBuLFGdlGDwab <= TFyaRaLQTXxptjcLsBuLFGdlGDwab.Full)
		{
			if (tFyaRaLQTXxptjcLsBuLFGdlGDwab > TFyaRaLQTXxptjcLsBuLFGdlGDwab.Charging)
			{
				if (tFyaRaLQTXxptjcLsBuLFGdlGDwab != TFyaRaLQTXxptjcLsBuLFGdlGDwab.Full)
				{
					goto IL_0171;
				}
				DAGXDAaHKKTahhzCDttZgQSxpmpt = 100;
				NZWohAvKtJUTbmqMHBKvwCMrGIFz = lWxWENWkfvzXpRPDQHMwUBbepaXh.Full;
			}
			else
			{
				DAGXDAaHKKTahhzCDttZgQSxpmpt = MathTools.Clamp((b & 0xF) * 10 + 5, 0, 100);
				NZWohAvKtJUTbmqMHBKvwCMrGIFz = ((tFyaRaLQTXxptjcLsBuLFGdlGDwab != TFyaRaLQTXxptjcLsBuLFGdlGDwab.Charging) ? lWxWENWkfvzXpRPDQHMwUBbepaXh.Discharging : lWxWENWkfvzXpRPDQHMwUBbepaXh.Charging);
			}
		}
		else
		{
			if (tFyaRaLQTXxptjcLsBuLFGdlGDwab - 10 > TFyaRaLQTXxptjcLsBuLFGdlGDwab.Charging)
			{
				if (tFyaRaLQTXxptjcLsBuLFGdlGDwab == TFyaRaLQTXxptjcLsBuLFGdlGDwab.ChargingError)
				{
				}
				goto IL_0171;
			}
			DAGXDAaHKKTahhzCDttZgQSxpmpt = 0;
			NZWohAvKtJUTbmqMHBKvwCMrGIFz = lWxWENWkfvzXpRPDQHMwUBbepaXh.Charging;
		}
		goto IL_017f;
		IL_0171:
		DAGXDAaHKKTahhzCDttZgQSxpmpt = 0;
		NZWohAvKtJUTbmqMHBKvwCMrGIFz = lWxWENWkfvzXpRPDQHMwUBbepaXh.Unknown;
		goto IL_017f;
		IL_017f:
		cNcWVzabxuuCfcBYQRipsgYpeCzO = (YJauqHMYVvJngOTmuFfEIRuZgwtr[54 + vPxjgrSwkXIICulkAIpEchIbPpMn] & 1) != 0;
		vEYqEIqGRilXjKwEonSkAhbQdquy[0] = HxToXqKKNxzmBhvhAxcNFLcAUsJg(DualSenseTriggerType.Left, YJauqHMYVvJngOTmuFfEIRuZgwtr[43 + vPxjgrSwkXIICulkAIpEchIbPpMn], YJauqHMYVvJngOTmuFfEIRuZgwtr[48 + vPxjgrSwkXIICulkAIpEchIbPpMn]);
		vEYqEIqGRilXjKwEonSkAhbQdquy[1] = HxToXqKKNxzmBhvhAxcNFLcAUsJg(DualSenseTriggerType.Right, YJauqHMYVvJngOTmuFfEIRuZgwtr[42 + vPxjgrSwkXIICulkAIpEchIbPpMn], YJauqHMYVvJngOTmuFfEIRuZgwtr[48 + vPxjgrSwkXIICulkAIpEchIbPpMn]);
		rlGHMWVwsPMlvrCOdVuLJyZfuDvN();
		return true;
	}

	public override Controller.Extension CreateControllerExtension()
	{
		return new DualSenseExtension(this);
	}

	private void qGGADwJzrlQOGAfXRdiiCsaCgsnPc(lZZYSzlENjVckJKEzwKsVotVgXhb P_0)
	{
		if (CbJfDVnsosKjVGszmODDtYDdJzek)
		{
			IflzOUkvoVyPOmltUEDTJBUANGXB(P_0);
			CbJfDVnsosKjVGszmODDtYDdJzek = false;
		}
	}

	private bool IflzOUkvoVyPOmltUEDTJBUANGXB(lZZYSzlENjVckJKEzwKsVotVgXhb P_0)
	{
		zGaReWRWRMtligibnpgfNhHqIGCX();
		bool result = vtdhHeJWOKpxdBdCTlxfZZBvrdQc(P_0);
		if (OOhkrKUnAsnwKWWgVPjfrMGObWjX)
		{
			result = vtdhHeJWOKpxdBdCTlxfZZBvrdQc(P_0);
			OOhkrKUnAsnwKWWgVPjfrMGObWjX = false;
		}
		return result;
	}

	private void zGaReWRWRMtligibnpgfNhHqIGCX()
	{
		if (vDuFkngDDEgBaZtxPixXkuqffnnxA && VepGAwtGCxFpXGmrHhKwXObqpgsjA)
		{
			wfkntfxVPBpztXLroSSthYSAWvbc[0] = 49;
			wfkntfxVPBpztXLroSSthYSAWvbc[1] = 2;
			QRvZJQqaWClatpHrDKWGMEIlgWhq(wfkntfxVPBpztXLroSSthYSAWvbc, 2);
			uint num = axRLtIukbbXnooJrVfVChBuZmlRZA(wfkntfxVPBpztXLroSSthYSAWvbc, 74);
			wfkntfxVPBpztXLroSSthYSAWvbc[74] = (byte)(num & 0xFF);
			wfkntfxVPBpztXLroSSthYSAWvbc[75] = (byte)((num & 0xFF00) >> 8);
			wfkntfxVPBpztXLroSSthYSAWvbc[76] = (byte)((num & 0xFF0000) >> 16);
			wfkntfxVPBpztXLroSSthYSAWvbc[77] = (byte)((num & 0xFF000000u) >> 24);
		}
		else
		{
			wfkntfxVPBpztXLroSSthYSAWvbc[0] = 2;
			QRvZJQqaWClatpHrDKWGMEIlgWhq(wfkntfxVPBpztXLroSSthYSAWvbc, 1);
		}
	}

	private void QRvZJQqaWClatpHrDKWGMEIlgWhq(NativeBuffer P_0, int P_1)
	{
		iAYgyXvUXzVhXbdPtzPMVBzLrhyM iAYgyXvUXzVhXbdPtzPMVBzLrhyM2 = iAYgyXvUXzVhXbdPtzPMVBzLrhyM.None;
		JZwCozFgiREWRRQPzHxOGNOndjbHA jZwCozFgiREWRRQPzHxOGNOndjbHA = JZwCozFgiREWRRQPzHxOGNOndjbHA.None;
		iAYgyXvUXzVhXbdPtzPMVBzLrhyM2 |= iAYgyXvUXzVhXbdPtzPMVBzLrhyM.HapticsSelect;
		if (vlIoyOsPQeNzgbZRunGISSsmFiTA == DualSenseVibrationMode.Compatible)
		{
			iAYgyXvUXzVhXbdPtzPMVBzLrhyM2 |= iAYgyXvUXzVhXbdPtzPMVBzLrhyM.CompatibleVibrationMode1;
		}
		qHgHyAKUibEeghwmrsxMoCFGieChA = false;
		iAYgyXvUXzVhXbdPtzPMVBzLrhyM2 |= iAYgyXvUXzVhXbdPtzPMVBzLrhyM.LeftTriggerEffect;
		zawMkmbsVmFmCeQIOwjpnkhoFZoM = false;
		iAYgyXvUXzVhXbdPtzPMVBzLrhyM2 |= iAYgyXvUXzVhXbdPtzPMVBzLrhyM.RightTriggerEffect;
		hyQAzoKwDzcxKYUsgaauYtsJzCQD = false;
		jZwCozFgiREWRRQPzHxOGNOndjbHA |= JZwCozFgiREWRRQPzHxOGNOndjbHA.MicrophoneLEDControl;
		ctICCtEGroVmJxaxGcCmWYyrOHZL = false;
		jZwCozFgiREWRRQPzHxOGNOndjbHA |= JZwCozFgiREWRRQPzHxOGNOndjbHA.PlayerIndicatorLEDControl;
		sklGWubkJXTpgTfVUaQjCCyYMYvd = false;
		jZwCozFgiREWRRQPzHxOGNOndjbHA |= JZwCozFgiREWRRQPzHxOGNOndjbHA.LightbarControl;
		PdhVaqUBPcauqhDamhOpsVawtzxL = false;
		jZwCozFgiREWRRQPzHxOGNOndjbHA |= JZwCozFgiREWRRQPzHxOGNOndjbHA.ChangeOverallMotorEffectPower;
		uWNmMdDQHoHPiAzdxaLTCVPfgALEB = false;
		P_0[P_1] = (byte)iAYgyXvUXzVhXbdPtzPMVBzLrhyM2;
		P_0[1 + P_1] = (byte)jZwCozFgiREWRRQPzHxOGNOndjbHA;
		P_0[2 + P_1] = (byte)vibrationMotors[1].DYWGVvmfVdcRhDBgOuJRwnGnXSli();
		P_0[3 + P_1] = (byte)vibrationMotors[0].DYWGVvmfVdcRhDBgOuJRwnGnXSli();
		P_0[8 + P_1] = (byte)VwscpRJkNLGgPlnnmlRbkXrqDQPA;
		auscnNGQVXhtSciVvcCsBqrIMtZoB auscnNGQVXhtSciVvcCsBqrIMtZoB2 = auscnNGQVXhtSciVvcCsBqrIMtZoB.None;
		auscnNGQVXhtSciVvcCsBqrIMtZoB2 |= auscnNGQVXhtSciVvcCsBqrIMtZoB.OtherLightBrightnessControl;
		JgPBUkvndddfTgtDGRIXhTwLOOTRA = false;
		if (vlIoyOsPQeNzgbZRunGISSsmFiTA == DualSenseVibrationMode.Compatible2)
		{
			auscnNGQVXhtSciVvcCsBqrIMtZoB2 |= auscnNGQVXhtSciVvcCsBqrIMtZoB.CompatibleVibrationMode2;
		}
		auscnNGQVXhtSciVvcCsBqrIMtZoB2 |= auscnNGQVXhtSciVvcCsBqrIMtZoB.LightbarSetupControl;
		nBuavkrmLYDDYTeisxjEPofgmCdk = false;
		P_0[38 + P_1] = (byte)auscnNGQVXhtSciVvcCsBqrIMtZoB2;
		P_0[41 + P_1] = YoVFTPaEYYyThrbXAymCixCgVxSJA;
		P_0[42 + P_1] = (byte)xUiOqQjlkHsufvSxtXtqbyXUOMFQ;
		P_0[43 + P_1] = (byte)ubNIxACZAjQMpbeXBzQJWKYDlroiA;
		if (ulSCjlcnMfSOmzJjgFlpfnDUOoFs)
		{
			P_0[43 + P_1] = (byte)(P_0[43 + P_1] & -33);
		}
		else
		{
			P_0[43 + P_1] |= 32;
		}
		P_0[44 + P_1] = lights[0].fMmsggZOsscOuVMYSBsIqYOBQdqI();
		P_0[45 + P_1] = lights[0].JhRteqBJskBczNyyhRGQdGLByHed();
		P_0[46 + P_1] = lights[0].AMTRtdCBoICpIfejWgQiwgwDnqyHA();
		wsqShKkITXAzCPrNiZiCsyIwwkly(ref kbFylPbRkZWGmOzxdjLXdCfujROfA[1], P_0, 10 + P_1);
		wsqShKkITXAzCPrNiZiCsyIwwkly(ref kbFylPbRkZWGmOzxdjLXdCfujROfA[0], P_0, 21 + P_1);
		P_0[36 + P_1] = 0;
	}

	private void wsqShKkITXAzCPrNiZiCsyIwwkly(ref IDualSenseTriggerEffect P_0, NativeBuffer P_1, int P_2)
	{
		if (P_0 == null)
		{
			P_1[P_2] = 0;
			return;
		}
		switch (P_0.triggerEffectType)
		{
		case DualSenseTriggerEffectType.Off:
			uvQBqrcDxKDekfvpostrFbXxklko.oZkMQrlNTHVmTOmjcAMUCLCWkDwn.kbVZIQhwgzbMIVTkVzTSxlEpUPQC(HJHpxmvUNCidGqvjXapxdaySRTAE, 0);
			break;
		case DualSenseTriggerEffectType.Feedback:
		{
			DualSenseTriggerEffectFeedback dualSenseTriggerEffectFeedback = (DualSenseTriggerEffectFeedback)(object)P_0;
			uvQBqrcDxKDekfvpostrFbXxklko.oZkMQrlNTHVmTOmjcAMUCLCWkDwn.MkZYIgvfHmZcHFbZBXGtSkiEdabDA(HJHpxmvUNCidGqvjXapxdaySRTAE, 0, dualSenseTriggerEffectFeedback.position, dualSenseTriggerEffectFeedback.strength);
			break;
		}
		case DualSenseTriggerEffectType.Weapon:
		{
			DualSenseTriggerEffectWeapon dualSenseTriggerEffectWeapon = (DualSenseTriggerEffectWeapon)(object)P_0;
			uvQBqrcDxKDekfvpostrFbXxklko.oZkMQrlNTHVmTOmjcAMUCLCWkDwn.GpwzTPBPSKzxaGBBtRuHoVzwrcNU(HJHpxmvUNCidGqvjXapxdaySRTAE, 0, dualSenseTriggerEffectWeapon.startPosition, dualSenseTriggerEffectWeapon.endPosition, dualSenseTriggerEffectWeapon.strength);
			break;
		}
		case DualSenseTriggerEffectType.Vibration:
		{
			DualSenseTriggerEffectVibration dualSenseTriggerEffectVibration = (DualSenseTriggerEffectVibration)(object)P_0;
			uvQBqrcDxKDekfvpostrFbXxklko.oZkMQrlNTHVmTOmjcAMUCLCWkDwn.eUNPgwTYyVLIndSPpOeBeMnHaJdAA(HJHpxmvUNCidGqvjXapxdaySRTAE, 0, dualSenseTriggerEffectVibration.position, dualSenseTriggerEffectVibration.amplitude, dualSenseTriggerEffectVibration.frequency);
			break;
		}
		case DualSenseTriggerEffectType.MultiplePositionFeedback:
			((DualSenseTriggerEffectMultiplePositionFeedback)(object)P_0).strength.CopyTo(NsCbNGjgqHpoZAjWnjXinjElWMGOA);
			uvQBqrcDxKDekfvpostrFbXxklko.oZkMQrlNTHVmTOmjcAMUCLCWkDwn.KWqNOvYvhaAgJgFKoDyLqXTWRjQL(HJHpxmvUNCidGqvjXapxdaySRTAE, 0, NsCbNGjgqHpoZAjWnjXinjElWMGOA);
			break;
		case DualSenseTriggerEffectType.SlopeFeedback:
		{
			DualSenseTriggerEffectSlopeFeedback dualSenseTriggerEffectSlopeFeedback = (DualSenseTriggerEffectSlopeFeedback)(object)P_0;
			uvQBqrcDxKDekfvpostrFbXxklko.oZkMQrlNTHVmTOmjcAMUCLCWkDwn.AQljzGXPJLTeiEKOZUJvzRJwCrW(HJHpxmvUNCidGqvjXapxdaySRTAE, 0, dualSenseTriggerEffectSlopeFeedback.startPosition, dualSenseTriggerEffectSlopeFeedback.endPosition, dualSenseTriggerEffectSlopeFeedback.startStrength, dualSenseTriggerEffectSlopeFeedback.endStrength);
			break;
		}
		case DualSenseTriggerEffectType.MultiplePositionVibration:
		{
			DualSenseTriggerEffectMultiplePositionVibration dualSenseTriggerEffectMultiplePositionVibration = (DualSenseTriggerEffectMultiplePositionVibration)(object)P_0;
			dualSenseTriggerEffectMultiplePositionVibration.amplitude.CopyTo(NsCbNGjgqHpoZAjWnjXinjElWMGOA);
			uvQBqrcDxKDekfvpostrFbXxklko.oZkMQrlNTHVmTOmjcAMUCLCWkDwn.gtJuZjeJTRSEdFyYqTKvAzJleuNt(HJHpxmvUNCidGqvjXapxdaySRTAE, 0, dualSenseTriggerEffectMultiplePositionVibration.frequency, NsCbNGjgqHpoZAjWnjXinjElWMGOA);
			break;
		}
		default:
			Logger.LogWarning("Unknown trigger effect type: 0x" + ((byte)P_0.triggerEffectType).ToString("x2"));
			return;
		}
		P_1.Write(HJHpxmvUNCidGqvjXapxdaySRTAE, HJHpxmvUNCidGqvjXapxdaySRTAE.Length, P_2);
	}

	private bool vtdhHeJWOKpxdBdCTlxfZZBvrdQc(lZZYSzlENjVckJKEzwKsVotVgXhb P_0)
	{
		VYQGFSkRDQBEHJmFyIElDfhjXslyb = ReInput.realTime + 4.0;
		switch (P_0)
		{
		case lZZYSzlENjVckJKEzwKsVotVgXhb.Synchronous:
			return vYQflXkltQIfLKoqsiLFWfbnmPRtA.WriteSync(FoYzqJlFhhwnPovwRjDJFfFKTzTm, 0);
		case lZZYSzlENjVckJKEzwKsVotVgXhb.Asynchronous:
			vYQflXkltQIfLKoqsiLFWfbnmPRtA.WriteAsync(FoYzqJlFhhwnPovwRjDJFfFKTzTm, 1000);
			return true;
		default:
			throw new NotImplementedException();
		}
	}

	private void YobdcqgaYyTqxInJxcQgpSJRNhGK(NativeBuffer P_0, double P_1)
	{
		byte b = P_0[qjBbnSXncjopSgxZKhoNeHGmWpsq];
		buttons[0].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x10) != 0, P_1);
		buttons[1].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x20) != 0, P_1);
		buttons[2].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x40) != 0, P_1);
		buttons[3].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x80) != 0, P_1);
		b = P_0[VJjekAgvyojxuBnSKeHTvxAofFzI];
		buttons[4].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 1) != 0, P_1);
		buttons[5].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 2) != 0, P_1);
		buttons[6].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 4) != 0, P_1);
		buttons[7].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 8) != 0, P_1);
		buttons[8].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x10) != 0, P_1);
		buttons[9].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x20) != 0, P_1);
		buttons[10].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x40) != 0, P_1);
		buttons[11].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 0x80) != 0, P_1);
		b = P_0[suycAzGJfAENrUHbMuPvvUgWgMXqA];
		buttons[12].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 1) != 0, P_1);
		buttons[13].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 2) != 0, P_1);
		if (VepGAwtGCxFpXGmrHhKwXObqpgsjA)
		{
			buttons[14].bmTWObZDLAHwBwVIFbvrHBOVINETA((b & 4) != 0, P_1);
		}
	}

	private void lAlEspBmBJwvOGbcCptkQVevcihH(xRwbEhgwfqETGQkYCofyzWNojclTA[] P_0, NativeBuffer P_1, double P_2)
	{
		for (int i = 0; i < P_0.Length; i++)
		{
			P_0[i].GbhSjusArEIYoVADpBQtaLlsuRfPA(P_1, P_2);
		}
	}

	private void OKqDaIfdCCgaYSOKYjgCaSMfNDjYb()
	{
		if (EZcesOHsFbyYKjYvaAwWXkSCxCOy() && ReInput.realTime >= VYQGFSkRDQBEHJmFyIElDfhjXslyb)
		{
			enzDdQkgcbCujrmPClufCwlraOde();
			qHgHyAKUibEeghwmrsxMoCFGieChA = true;
		}
	}

	private void wUPxMnEXWcoybUgNihdNaeeUhwLNA(NativeBuffer P_0)
	{
		if (VepGAwtGCxFpXGmrHhKwXObqpgsjA)
		{
			uint num = YJauqHMYVvJngOTmuFfEIRuZgwtr.ReadUInt(28 + vPxjgrSwkXIICulkAIpEchIbPpMn);
			float uaJHYlMlzRUqETxfRvJTcRAuItxW;
			if (num != aMVGRuMGQoIvqOVSmzmhmfYIeMZp)
			{
				uint num2 = (uint)((num >= aMVGRuMGQoIvqOVSmzmhmfYIeMZp) ? (num - aMVGRuMGQoIvqOVSmzmhmfYIeMZp) : ((long)num + 4294967295L - aMVGRuMGQoIvqOVSmzmhmfYIeMZp));
				uaJHYlMlzRUqETxfRvJTcRAuItxW = (float)num2 / 3000000f;
			}
			else
			{
				uint num2 = 0u;
				uaJHYlMlzRUqETxfRvJTcRAuItxW = 0f;
			}
			aMVGRuMGQoIvqOVSmzmhmfYIeMZp = num;
			UaJHYlMlzRUqETxfRvJTcRAuItxW = uaJHYlMlzRUqETxfRvJTcRAuItxW;
		}
	}

	private void rlGHMWVwsPMlvrCOdVuLJyZfuDvN()
	{
		if (VepGAwtGCxFpXGmrHhKwXObqpgsjA && !(UaJHYlMlzRUqETxfRvJTcRAuItxW <= 0f))
		{
			Vector3 vector = IAIiCjEgImYTzmpMIMTmoqtfShTS(new Vector3(gyroscopes[0].lXibhhIpZcFeBrHtdwGikQrKfnMdb[0], gyroscopes[0].lXibhhIpZcFeBrHtdwGikQrKfnMdb[1], gyroscopes[0].lXibhhIpZcFeBrHtdwGikQrKfnMdb[2]), UaJHYlMlzRUqETxfRvJTcRAuItxW);
			aeaAFYCVgBCwMIJEDKpqTVzGVhLDA(ref vector);
			Vector3 vector2 = new Vector3(accelerometers[0].kHKNsnXlXktGYBPiLEFMIeDjXJlhA[0] * -1f, accelerometers[0].kHKNsnXlXktGYBPiLEFMIeDjXJlhA[1] * -1f, accelerometers[0].kHKNsnXlXktGYBPiLEFMIeDjXJlhA[2] * -1f);
			AhjjEyAaeKwqqSImRQSUSMXCOGFn(vector2, vector);
		}
	}

	private static bool aeaAFYCVgBCwMIJEDKpqTVzGVhLDA(ref Vector3 P_0)
	{
		if (P_0.magnitude < 0.004f)
		{
			P_0.x = 0f;
			P_0.y = 0f;
			P_0.z = 0f;
			return false;
		}
		return true;
	}

	private void AhjjEyAaeKwqqSImRQSUSMXCOGFn(Vector3 P_0, Vector3 P_1)
	{
		Quaternion quaternion = Quaternion.Euler(P_1);
		float sqrMagnitude = P_0.sqrMagnitude;
		if (sqrMagnitude > 16777216f && sqrMagnitude < 268435460f && QYzktSqknXHifzJrimJOSgYXXCHw(P_0, out var vlKhVWAxlrhMTpJZtPJXanNDSGMW))
		{
			Quaternion a = RJZPXozEHigHLIXIQKpnoeKHfBvZ * quaternion;
			if (!HVmBQsATdeUOSalCBbtSrvMrCZDlA)
			{
				HVmBQsATdeUOSalCBbtSrvMrCZDlA = true;
				bGoMZrUGRkKWSOpURHYucQRVsPuX = Quaternion.identity * Quaternion.Euler(new Vector3(90f, 0f, 0f));
				BOPzrbQchlqAtgsOdJNKHJjOXGsr = RJZPXozEHigHLIXIQKpnoeKHfBvZ;
			}
			bGoMZrUGRkKWSOpURHYucQRVsPuX *= quaternion;
			BOPzrbQchlqAtgsOdJNKHJjOXGsr *= quaternion;
			Quaternion b;
			if ((vlKhVWAxlrhMTpJZtPJXanNDSGMW & VlKhVWAxlrhMTpJZtPJXanNDSGMW.XZ) != VlKhVWAxlrhMTpJZtPJXanNDSGMW.None)
			{
				b = ARJRvuZWELYeHYsnTTgYHElmsaPl(P_0, a.eulerAngles.y);
			}
			else if ((vlKhVWAxlrhMTpJZtPJXanNDSGMW & VlKhVWAxlrhMTpJZtPJXanNDSGMW.Y) != VlKhVWAxlrhMTpJZtPJXanNDSGMW.None)
			{
				b = PoOYLvvxtRZkRwehAxISRfzYAcTf(P_0);
				Vector3 vector = BOPzrbQchlqAtgsOdJNKHJjOXGsr * Vector3.right;
				float y = 0f - MathTools.SignedAngle(new Vector3(vector.x, 0f, vector.z), Vector3.right, Vector3.up);
				b = Quaternion.Euler(0f, y, 0f) * b;
			}
			else
			{
				b = Quaternion.identity;
			}
			RJZPXozEHigHLIXIQKpnoeKHfBvZ = Quaternion.Lerp(a, b, 0.01999998f);
		}
		else
		{
			RJZPXozEHigHLIXIQKpnoeKHfBvZ *= quaternion;
			if (HVmBQsATdeUOSalCBbtSrvMrCZDlA)
			{
				HVmBQsATdeUOSalCBbtSrvMrCZDlA = false;
			}
		}
	}

	private static Quaternion xgcethKIusoYcMljVVxOpwpQswsn(Quaternion P_0, Vector3 P_1)
	{
		Vector3 vector = KZRMVZMxyzmabVjVNegnalhZFbHfA(new Vector3(P_0.x, P_0.y, P_0.z), P_1);
		return new Quaternion(vector.x, vector.y, vector.z, P_0.w);
	}

	private static Vector3 KZRMVZMxyzmabVjVNegnalhZFbHfA(Vector3 P_0, Vector3 P_1)
	{
		float num = Vector3.Dot(P_1, P_1);
		if (num < float.Epsilon)
		{
			return Vector3.zero;
		}
		return P_1 * Vector3.Dot(P_0, P_1) / num;
	}

	private Quaternion lMxycVQwupVkJghpBXLjfrdykjxl(Quaternion P_0, PhnMBXtAhcFhczaGReGRkQEmdKtx P_1)
	{
		Vector4 vector = default;
		if (MathTools.Approximately(P_0.w, 0f) && MathTools.Approximately(P_0[(int)P_1], 0f))
		{
			P_0 = Quaternion.identity;
		}
		else
		{
			float num = P_0[(int)P_1];
			float num2 = MathTools.Sqrt(P_0.w * P_0.w + num * num);
			vector[3] = P_0.w / num2;
			vector[(int)P_1] = num / num2;
			P_0 = new Quaternion(vector[0], vector[1], vector[2], vector[3]);
		}
		return P_0;
	}

	public static Quaternion Inverse(Quaternion quaternion)
	{
		float num = quaternion.x * quaternion.x + quaternion.y * quaternion.y + quaternion.z * quaternion.z + quaternion.w * quaternion.w;
		float num2 = 1f / num;
		Quaternion result = default;
		result.x = (0f - quaternion.x) * num2;
		result.y = (0f - quaternion.y) * num2;
		result.z = (0f - quaternion.z) * num2;
		result.w = quaternion.w * num2;
		return result;
	}

	private float swZZxdZBcKbWqStrvkEqFdSWgkukA(float P_0, float P_1)
	{
		P_0 = MathTools.ClampAngle360(P_0);
		P_1 = MathTools.ClampAngle360(P_1);
		if (P_0 == P_1)
		{
			return 0f;
		}
		if (P_0 >= 180f)
		{
			P_0 -= 360f;
		}
		if (P_1 >= 180f)
		{
			P_1 -= 360f;
		}
		return P_0 - P_1;
	}

	private Vector3 bxgqCzDiTIJUvVErfdaIAdokNilVA(Vector3 P_0, float P_1 = 0f)
	{
		float num = MathTools.Atan2(P_0.z, P_0.y);
		float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
		float x = num * 57.29578f + 180f;
		float z = (0f - num2) * 57.29578f;
		return new Vector3(x, P_1, z);
	}

	private Quaternion ARJRvuZWELYeHYsnTTgYHElmsaPl(Vector3 P_0, float P_1 = 0f)
	{
		float num = MathTools.Atan2(P_0.z, P_0.y);
		float num2 = MathTools.Atan2(x: MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f)), y: P_0.x);
		float x = num * 57.29578f + 180f;
		float z = (0f - num2) * 57.29578f;
		return Quaternion.Euler(x, P_1, z);
	}

	private Quaternion PoOYLvvxtRZkRwehAxISRfzYAcTf(Vector3 P_0, float P_1 = 0f)
	{
		float num = MathTools.Atan2(P_0.z, P_0.y);
		float x = MathTools.Sqrt(MathTools.Pow(P_0.y, 2f) + MathTools.Pow(P_0.z, 2f));
		float num2 = MathTools.Atan2(P_0.x, x);
		float x2 = num * 57.29578f + 180f;
		float z = (0f - num2) * 57.29578f;
		Quaternion quaternion = Quaternion.Euler(0f, 0f, z) * Quaternion.Euler(x2, 0f, 0f);
		if (P_1 != 0f)
		{
			return quaternion * Quaternion.Euler(0f, P_1, 0f);
		}
		return quaternion;
	}

	private float dvJvJptOGjBqWqtqPcRSBmxOEYAfA(Vector3 P_0)
	{
		return MathTools.Atan2(P_0.x, P_0.z) * 57.29578f;
	}

	private bool cnHbggfjmcMGBfHBpueJEazEFyphB(float P_0)
	{
		if (P_0 >= 45f)
		{
			return P_0 <= 70f;
		}
		return false;
	}

	private bool QYzktSqknXHifzJrimJOSgYXXCHw(Vector3 P_0, out VlKhVWAxlrhMTpJZtPJXanNDSGMW P_1)
	{
		P_0.Normalize();
		P_1 = VlKhVWAxlrhMTpJZtPJXanNDSGMW.None;
		bool result = false;
		if (ExHoEHCqPYYPwaKipCgrovJPPFGb(P_0))
		{
			result = true;
			P_1 |= VlKhVWAxlrhMTpJZtPJXanNDSGMW.XZ;
		}
		if (WsgmAnTqbSVWRTgAYhuhqKTtBuFA(P_0))
		{
			result = true;
			P_1 |= VlKhVWAxlrhMTpJZtPJXanNDSGMW.Y;
		}
		return result;
	}

	private bool ExHoEHCqPYYPwaKipCgrovJPPFGb(Vector3 P_0)
	{
		if (P_0.y > 0f)
		{
			return false;
		}
		if (Vector3.Angle(Vector3.down, P_0) > 45f)
		{
			return false;
		}
		return true;
	}

	private bool WsgmAnTqbSVWRTgAYhuhqKTtBuFA(Vector3 P_0)
	{
		if (P_0.z < 0f)
		{
			return false;
		}
		if (Vector3.Angle(new Vector3(0f, 0f, 1f), P_0) > 20f)
		{
			return false;
		}
		return true;
	}

	private Vector3 IgczdfLLgHgqXbdkCApvhyEiBOqAA(float[] P_0)
	{
		return new Vector3(P_0[0] * (1f / 8192f) * -1f, P_0[1] * (1f / 8192f) * -1f, P_0[2] * (1f / 8192f));
	}

	private Vector3 zjXfydiHtVqKvcGlOKNcUXkllDpy(RingBuffer<HzWNjGbJTcqWRFLBLnqFlnsJEvnz.TcghcTkzcNarrATcRVAAaJvzzIqhA> P_0)
	{
		Vector3 result = default;
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			HzWNjGbJTcqWRFLBLnqFlnsJEvnz.TcghcTkzcNarrATcRVAAaJvzzIqhA tcghcTkzcNarrATcRVAAaJvzzIqhA = P_0[i];
			result += IAIiCjEgImYTzmpMIMTmoqtfShTS(tcghcTkzcNarrATcRVAAaJvzzIqhA.lPuGxwuWzBbTrDajXKXLGRwQturQ, tcghcTkzcNarrATcRVAAaJvzzIqhA.LmKHhhHGpixLVWWDHRfgAapyJDgI);
		}
		return result;
	}

	private Vector3 IAIiCjEgImYTzmpMIMTmoqtfShTS(Vector3 P_0, float P_1)
	{
		P_0.x *= -1f;
		P_0.y *= -1f;
		return P_0 * 0.06103702f * P_1;
	}

	private int sHJgStAkhwIMIGmvDLdiAOmDMSNKc(int P_0)
	{
		P_0 &= 0xF;
		return P_0;
	}

	private void BJLxmlYvWNraQDiBisYTAIgxHJVx(byte[] P_0, float[] P_1)
	{
		P_1[0] = BitConverter.ToInt16(P_0, 0);
		P_1[1] = BitConverter.ToInt16(P_0, 2);
		P_1[2] = BitConverter.ToInt16(P_0, 4);
	}

	private void NUKgYqZGvVvGqoWJvJIkNRLfuwPg(byte[] P_0, float[] P_1)
	{
		P_1[0] = BitConverter.ToInt16(P_0, 0);
		P_1[1] = BitConverter.ToInt16(P_0, 2);
		P_1[2] = BitConverter.ToInt16(P_0, 4);
	}

	private float LTqkSRlarcrTngenGpALCdUPYNXl()
	{
		return UaJHYlMlzRUqETxfRvJTcRAuItxW;
	}

	private void FHjAoedcxFmgKuEnsbAanzqZIOlQA(NativeBuffer P_0, nLbAcapOagdnNrGGiTONDGTEQuzQ.TouchData[] P_1)
	{
		int num = 33 + vPxjgrSwkXIICulkAIpEchIbPpMn;
		int positionRawX = P_0[1 + num] + (P_0[2 + num] & 0xF) * 255;
		int positionRawY = ((P_0[2 + num] & 0xF0) >> 4) + P_0[3 + num] * 16;
		int positionRawX2 = P_0[5 + num] + (P_0[6 + num] & 0xF) * 255;
		int positionRawY2 = ((P_0[6 + num] & 0xF0) >> 4) + P_0[7 + num] * 16;
		byte b = P_0[num];
		bool flag = b < 128;
		byte num2 = P_0[num + 4];
		bool flag2 = num2 < 128;
		int num3 = b & 0x7F;
		int num4 = num2 & 0x7F;
		P_1[0].isTouching = flag;
		P_1[0].touchId = bXhZfyTjQrLIftKDkreMLmPMrsCh(0, flag, num3);
		P_1[0].positionRawX = positionRawX;
		P_1[0].positionRawY = positionRawY;
		P_1[1].isTouching = flag2;
		P_1[1].touchId = bXhZfyTjQrLIftKDkreMLmPMrsCh(1, flag2, num4);
		P_1[1].positionRawX = positionRawX2;
		P_1[1].positionRawY = positionRawY2;
	}

	private int bXhZfyTjQrLIftKDkreMLmPMrsCh(int P_0, bool P_1, int P_2)
	{
		if (!P_1)
		{
			mdTpqgmeeMqXNJeJOaogBdBuElUc[P_0] = -1;
			VEAgcmTuLudqYJUgeqcLudxJZJnD[P_0] = P_2;
			return -1;
		}
		if (P_2 != VEAgcmTuLudqYJUgeqcLudxJZJnD[P_0])
		{
			int aRkGmmrKKTmoAdExaIYRFhSxcYYr = ARkGmmrKKTmoAdExaIYRFhSxcYYr;
			if (ARkGmmrKKTmoAdExaIYRFhSxcYYr == int.MaxValue)
			{
				ARkGmmrKKTmoAdExaIYRFhSxcYYr = 0;
			}
			else
			{
				ARkGmmrKKTmoAdExaIYRFhSxcYYr++;
			}
			VEAgcmTuLudqYJUgeqcLudxJZJnD[P_0] = P_2;
			mdTpqgmeeMqXNJeJOaogBdBuElUc[P_0] = aRkGmmrKKTmoAdExaIYRFhSxcYYr;
			return aRkGmmrKKTmoAdExaIYRFhSxcYYr;
		}
		return mdTpqgmeeMqXNJeJOaogBdBuElUc[P_0];
	}

	private void JGMQePRPYWBBiBNEHpMSiRznAOiR()
	{
		PdhVaqUBPcauqhDamhOpsVawtzxL = true;
		enzDdQkgcbCujrmPClufCwlraOde();
	}

	private void nJIJiKWZqDaQOzHzQEwiQnoAtLNf()
	{
		PdhVaqUBPcauqhDamhOpsVawtzxL = true;
		enzDdQkgcbCujrmPClufCwlraOde();
	}

	private void KBsGGPzHyRDfkvKShvcuoPPdbmWM()
	{
		qHgHyAKUibEeghwmrsxMoCFGieChA = true;
		enzDdQkgcbCujrmPClufCwlraOde();
	}

	private void enzDdQkgcbCujrmPClufCwlraOde()
	{
		CbJfDVnsosKjVGszmODDtYDdJzek = true;
	}

	~DualSenseDriver()
	{
		Dispose(disposing: false);
	}

	protected override void Dispose(bool disposing)
	{
		if (base.disposed)
		{
			return;
		}
		base.Dispose(disposing);
		if (disposing)
		{
			StopVibration();
			qGGADwJzrlQOGAfXRdiiCsaCgsnPc(lZZYSzlENjVckJKEzwKsVotVgXhb.Synchronous);
			if (YJauqHMYVvJngOTmuFfEIRuZgwtr != null)
			{
				YJauqHMYVvJngOTmuFfEIRuZgwtr.Dispose();
			}
			if (wfkntfxVPBpztXLroSSthYSAWvbc != null)
			{
				wfkntfxVPBpztXLroSSthYSAWvbc.Dispose();
			}
		}
	}

	public static bool Matches(int vid, int pid)
	{
		if (pid == 3302)
		{
			return vid == 1356;
		}
		return false;
	}

	private static uint axRLtIukbbXnooJrVfVChBuZmlRZA(NativeBuffer P_0, int P_1)
	{
		uint num = 3940166985u;
		for (int i = 0; i < P_1; i++)
		{
			num = NOyrZARErKfsOEiflfLCIcGiIFgzA[(byte)num ^ P_0[i]] ^ (num >> 8);
		}
		return num;
	}

	private static OUBttzqbTMqOLkLhXvVqwaEZiqRB IllplHGZACiPFjFapVWAlzAeqPEt(DualSenseOtherLightBrightness P_0)
	{
		return P_0 switch
		{
			DualSenseOtherLightBrightness.High => OUBttzqbTMqOLkLhXvVqwaEZiqRB.High, 
			DualSenseOtherLightBrightness.Medium => OUBttzqbTMqOLkLhXvVqwaEZiqRB.Medium, 
			DualSenseOtherLightBrightness.Low => OUBttzqbTMqOLkLhXvVqwaEZiqRB.Low, 
			_ => throw new NotImplementedException(), 
		};
	}

	private static DualSenseOtherLightBrightness zpRfroKUeiwTqQUBXYhorvBoPdtRA(OUBttzqbTMqOLkLhXvVqwaEZiqRB P_0)
	{
		return P_0 switch
		{
			OUBttzqbTMqOLkLhXvVqwaEZiqRB.High => DualSenseOtherLightBrightness.High, 
			OUBttzqbTMqOLkLhXvVqwaEZiqRB.Medium => DualSenseOtherLightBrightness.Medium, 
			OUBttzqbTMqOLkLhXvVqwaEZiqRB.Low => DualSenseOtherLightBrightness.Low, 
			_ => throw new NotImplementedException(), 
		};
	}

	private static rfrTwOOXuSACJXCQFvgEMZtbwbkb wcPvIAtAvjbhZTHVUdiDsBqVMEHO(DualSenseTriggerType P_0, byte P_1)
	{
		byte b;
		switch (P_0)
		{
		case DualSenseTriggerType.Left:
			b = new NckCuArwgbjHLnjYNvutDMaxnesB(P_1).RDBcbdUOHycsWfWobQbggbtwPDhGA();
			break;
		case DualSenseTriggerType.Right:
			b = new NckCuArwgbjHLnjYNvutDMaxnesB(P_1).pofyWGZRQcDCIpDpcAZjgzgeihtvA();
			break;
		default:
			return rfrTwOOXuSACJXCQFvgEMZtbwbkb.Off;
		}
		return b switch
		{
			0 => rfrTwOOXuSACJXCQFvgEMZtbwbkb.Off, 
			1 => rfrTwOOXuSACJXCQFvgEMZtbwbkb.Feedback, 
			2 => rfrTwOOXuSACJXCQFvgEMZtbwbkb.Weapon, 
			3 => rfrTwOOXuSACJXCQFvgEMZtbwbkb.Vibration, 
			4 => rfrTwOOXuSACJXCQFvgEMZtbwbkb.SlopeFeedback, 
			_ => rfrTwOOXuSACJXCQFvgEMZtbwbkb.Off, 
		};
	}

	private static DualSenseTriggerEffectState HxToXqKKNxzmBhvhAxcNFLcAUsJg(DualSenseTriggerType P_0, byte P_1, byte P_2)
	{
		byte b = new NckCuArwgbjHLnjYNvutDMaxnesB(P_1).RDBcbdUOHycsWfWobQbggbtwPDhGA();
		return wcPvIAtAvjbhZTHVUdiDsBqVMEHO(P_0, P_2) switch
		{
			rfrTwOOXuSACJXCQFvgEMZtbwbkb.Off => DualSenseTriggerEffectState.Off, 
			rfrTwOOXuSACJXCQFvgEMZtbwbkb.Feedback => b switch
			{
				0 => DualSenseTriggerEffectState.FeedbackIdle, 
				1 => DualSenseTriggerEffectState.FeedbackApplyingForce, 
				_ => DualSenseTriggerEffectState.FeedbackIdle, 
			}, 
			rfrTwOOXuSACJXCQFvgEMZtbwbkb.Weapon => b switch
			{
				0 => DualSenseTriggerEffectState.WeaponIdle, 
				1 => DualSenseTriggerEffectState.WeaponFiring, 
				2 => DualSenseTriggerEffectState.WeaponFired, 
				_ => DualSenseTriggerEffectState.WeaponIdle, 
			}, 
			rfrTwOOXuSACJXCQFvgEMZtbwbkb.Vibration => b switch
			{
				0 => DualSenseTriggerEffectState.VibrationIdle, 
				1 => DualSenseTriggerEffectState.VibrationVibrating, 
				_ => DualSenseTriggerEffectState.VibrationIdle, 
			}, 
			rfrTwOOXuSACJXCQFvgEMZtbwbkb.SlopeFeedback => b switch
			{
				0 => (DualSenseTriggerEffectState)8, 
				1 => (DualSenseTriggerEffectState)9, 
				2 => (DualSenseTriggerEffectState)10, 
				_ => (DualSenseTriggerEffectState)8, 
			}, 
			_ => DualSenseTriggerEffectState.Off, 
		};
	}

	[Conditional("DEBUG_THIS")]
	protected static void DLog(object msg)
	{
		if (msg != null)
		{
			Logger.Log("DualSenseDriver: " + msg);
		}
	}
}
