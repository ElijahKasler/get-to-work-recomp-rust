using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired;

public sealed class Keyboard : ControllerWithMap
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class ModifierKeyInfo
	{
		public readonly string shortName;

		public readonly string longName;

		public readonly string shortKey;

		public readonly string longKey;

		public ModifierKeyInfo(string P_0, string P_1, string P_2, string P_3)
		{
			shortName = P_0;
			longName = P_1;
			shortKey = P_2;
			longKey = P_3;
		}

		public string GetName(bool useShort)
		{
			if (!useShort)
			{
				return longName;
			}
			return shortName;
		}

		public string GetKey(bool useShort)
		{
			if (!useShort)
			{
				return longKey;
			}
			return shortKey;
		}
	}

	private class ZPTQbqTcMztpVfxJBhgQVISNhphW
	{
		public readonly NjAOflGrmZHBxopImRGhvMZerrwc KSJewQqFKxhMTSnSGCPTHPHnpEId;

		public readonly NjAOflGrmZHBxopImRGhvMZerrwc SxzkIHvfdWDPoebDWPCXBGtWAogHb;

		public ZPTQbqTcMztpVfxJBhgQVISNhphW(string P_0, string P_1)
		{
			if (!string.IsNullOrEmpty(P_0))
			{
				KSJewQqFKxhMTSnSGCPTHPHnpEId = new NjAOflGrmZHBxopImRGhvMZerrwc(new LocalizedString());
			}
			if (!string.IsNullOrEmpty(P_1))
			{
				SxzkIHvfdWDPoebDWPCXBGtWAogHb = new NjAOflGrmZHBxopImRGhvMZerrwc(new LocalizedString());
			}
		}
	}

	private sealed class NjAOflGrmZHBxopImRGhvMZerrwc
	{
		public readonly LocalizedString XHXfcMEBaWQOfUJeYSbyUBCAEQcjA;

		public bool sdKCFwTuTFlKzDiwMiOjVgmtcrlO;

		public NjAOflGrmZHBxopImRGhvMZerrwc(LocalizedString P_0)
		{
			XHXfcMEBaWQOfUJeYSbyUBCAEQcjA = P_0;
		}
	}

	private sealed class iVIXOHFicTRPMDAZUNUaXgbjgFmK
	{
		public readonly KeyedGlyph YQgYNeVzITsuEAzYOUJZqxGADYq;

		public bool eePEJLbuXqFVbybEzsfPPYffLrvaA;

		public iVIXOHFicTRPMDAZUNUaXgbjgFmK(KeyedGlyph P_0)
		{
			YQgYNeVzITsuEAzYOUJZqxGADYq = P_0;
		}
	}

	private sealed class ThAbPIHyHxjxceeuehAkzUNmhgbhb : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
	{
		private int KotggaDgxfFGEsYVkAJUpuBMzNgGA;

		private ControllerPollingInfo GsxoVaMboTeaZDuRJZprlQdWnkyTA;

		private int NrxKhBPKyOTKXOYVTgQewbhbNcCS;

		public Keyboard uXWKfRFnJorNsFpmEynuADKvwgru;

		private int OpwebSElrBhpmHLNqjGAceZpwOgvA;

		private int vGbEXhBCPGgEezaQQRnrwcrPhOFEA;

		ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
		{
			[DebuggerHidden]
			get
			{
				return GsxoVaMboTeaZDuRJZprlQdWnkyTA;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return GsxoVaMboTeaZDuRJZprlQdWnkyTA;
			}
		}

		[DebuggerHidden]
		public ThAbPIHyHxjxceeuehAkzUNmhgbhb(int P_0)
		{
			KotggaDgxfFGEsYVkAJUpuBMzNgGA = P_0;
			NrxKhBPKyOTKXOYVTgQewbhbNcCS = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int kotggaDgxfFGEsYVkAJUpuBMzNgGA = KotggaDgxfFGEsYVkAJUpuBMzNgGA;
			Keyboard keyboard = uXWKfRFnJorNsFpmEynuADKvwgru;
			if (kotggaDgxfFGEsYVkAJUpuBMzNgGA != 0)
			{
				if (kotggaDgxfFGEsYVkAJUpuBMzNgGA != 1)
				{
					return false;
				}
				KotggaDgxfFGEsYVkAJUpuBMzNgGA = -1;
				goto IL_00bf;
			}
			KotggaDgxfFGEsYVkAJUpuBMzNgGA = -1;
			if (ReInput._id != keyboard.qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(keyboard.qostqwFsdWROzwZYaTyZVeYSeDOM);
				return false;
			}
			OpwebSElrBhpmHLNqjGAceZpwOgvA = Consts.keyboardKeyValues.Count;
			vGbEXhBCPGgEezaQQRnrwcrPhOFEA = 0;
			goto IL_00cf;
			IL_00cf:
			if (vGbEXhBCPGgEezaQQRnrwcrPhOFEA < OpwebSElrBhpmHLNqjGAceZpwOgvA)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[vGbEXhBCPGgEezaQQRnrwcrPhOFEA];
				if (keyboard.GetKey(keyCode))
				{
					GsxoVaMboTeaZDuRJZprlQdWnkyTA = new ControllerPollingInfo(true, -1, keyboard.id, keyboard._name, keyboard._type, ControllerElementType.Button, vGbEXhBCPGgEezaQQRnrwcrPhOFEA, Pole.Positive, GetKeyName(keyCode), keyboard.aHJMAWzbypGgwCcRCqDEaoqVGwfA.buttonElementIdentifierIds[vGbEXhBCPGgEezaQQRnrwcrPhOFEA], keyCode);
					KotggaDgxfFGEsYVkAJUpuBMzNgGA = 1;
					return true;
				}
				goto IL_00bf;
			}
			return false;
			IL_00bf:
			vGbEXhBCPGgEezaQQRnrwcrPhOFEA++;
			goto IL_00cf;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
		{
			ThAbPIHyHxjxceeuehAkzUNmhgbhb thAbPIHyHxjxceeuehAkzUNmhgbhb;
			if (KotggaDgxfFGEsYVkAJUpuBMzNgGA == -2 && NrxKhBPKyOTKXOYVTgQewbhbNcCS == Environment.CurrentManagedThreadId)
			{
				KotggaDgxfFGEsYVkAJUpuBMzNgGA = 0;
				thAbPIHyHxjxceeuehAkzUNmhgbhb = this;
			}
			else
			{
				thAbPIHyHxjxceeuehAkzUNmhgbhb = new ThAbPIHyHxjxceeuehAkzUNmhgbhb(0);
				thAbPIHyHxjxceeuehAkzUNmhgbhb.uXWKfRFnJorNsFpmEynuADKvwgru = uXWKfRFnJorNsFpmEynuADKvwgru;
			}
			return thAbPIHyHxjxceeuehAkzUNmhgbhb;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
		}
	}

	private sealed class iOhtrddANahYDfmmAeEyJkaazOoi : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
	{
		private int EicpaSaCbWEaqnUAUbTcHxvTiIFw;

		private ControllerPollingInfo VTgLMimhKoOFCiIynkpMWFKoZqBN;

		private int mtrrKWpuKUePnzCQKLFZiwDsgYsK;

		public Keyboard MYaKRPyRvIbVCHRXFWcCKpifIYOE;

		private int fkCBKfJzXIHVCFpsQnBkkVfpOkvn;

		private int kAifypNkTiusHxTxHRitQEYEilef;

		ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
		{
			[DebuggerHidden]
			get
			{
				return VTgLMimhKoOFCiIynkpMWFKoZqBN;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return VTgLMimhKoOFCiIynkpMWFKoZqBN;
			}
		}

		[DebuggerHidden]
		public iOhtrddANahYDfmmAeEyJkaazOoi(int P_0)
		{
			EicpaSaCbWEaqnUAUbTcHxvTiIFw = P_0;
			mtrrKWpuKUePnzCQKLFZiwDsgYsK = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int eicpaSaCbWEaqnUAUbTcHxvTiIFw = EicpaSaCbWEaqnUAUbTcHxvTiIFw;
			Keyboard mYaKRPyRvIbVCHRXFWcCKpifIYOE = MYaKRPyRvIbVCHRXFWcCKpifIYOE;
			if (eicpaSaCbWEaqnUAUbTcHxvTiIFw != 0)
			{
				if (eicpaSaCbWEaqnUAUbTcHxvTiIFw != 1)
				{
					return false;
				}
				EicpaSaCbWEaqnUAUbTcHxvTiIFw = -1;
				goto IL_00bf;
			}
			EicpaSaCbWEaqnUAUbTcHxvTiIFw = -1;
			if (ReInput._id != mYaKRPyRvIbVCHRXFWcCKpifIYOE.qostqwFsdWROzwZYaTyZVeYSeDOM)
			{
				ReInput.CheckInitialized(mYaKRPyRvIbVCHRXFWcCKpifIYOE.qostqwFsdWROzwZYaTyZVeYSeDOM);
				return false;
			}
			fkCBKfJzXIHVCFpsQnBkkVfpOkvn = Consts.keyboardKeyValues.Count;
			kAifypNkTiusHxTxHRitQEYEilef = 0;
			goto IL_00cf;
			IL_00cf:
			if (kAifypNkTiusHxTxHRitQEYEilef < fkCBKfJzXIHVCFpsQnBkkVfpOkvn)
			{
				KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[kAifypNkTiusHxTxHRitQEYEilef];
				if (mYaKRPyRvIbVCHRXFWcCKpifIYOE.GetKeyDown(keyCode))
				{
					VTgLMimhKoOFCiIynkpMWFKoZqBN = new ControllerPollingInfo(true, -1, mYaKRPyRvIbVCHRXFWcCKpifIYOE.id, mYaKRPyRvIbVCHRXFWcCKpifIYOE._name, mYaKRPyRvIbVCHRXFWcCKpifIYOE._type, ControllerElementType.Button, kAifypNkTiusHxTxHRitQEYEilef, Pole.Positive, GetKeyName(keyCode), mYaKRPyRvIbVCHRXFWcCKpifIYOE.aHJMAWzbypGgwCcRCqDEaoqVGwfA.buttonElementIdentifierIds[kAifypNkTiusHxTxHRitQEYEilef], keyCode);
					EicpaSaCbWEaqnUAUbTcHxvTiIFw = 1;
					return true;
				}
				goto IL_00bf;
			}
			return false;
			IL_00bf:
			kAifypNkTiusHxTxHRitQEYEilef++;
			goto IL_00cf;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
		{
			iOhtrddANahYDfmmAeEyJkaazOoi iOhtrddANahYDfmmAeEyJkaazOoi2;
			if (EicpaSaCbWEaqnUAUbTcHxvTiIFw == -2 && mtrrKWpuKUePnzCQKLFZiwDsgYsK == Environment.CurrentManagedThreadId)
			{
				EicpaSaCbWEaqnUAUbTcHxvTiIFw = 0;
				iOhtrddANahYDfmmAeEyJkaazOoi2 = this;
			}
			else
			{
				iOhtrddANahYDfmmAeEyJkaazOoi2 = new iOhtrddANahYDfmmAeEyJkaazOoi(0);
				iOhtrddANahYDfmmAeEyJkaazOoi2.MYaKRPyRvIbVCHRXFWcCKpifIYOE = MYaKRPyRvIbVCHRXFWcCKpifIYOE;
			}
			return iOhtrddANahYDfmmAeEyJkaazOoi2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
		}
	}

	private const string AfbEGrdrJsWyVKfsYSMWzNWJMqtH = " + ";

	private static Keyboard gzOGLzgpZoDbdQRapjSqyJOWNLaaA;

	private static KeyboardKeyCode[] ThvuzprjuBrXiTQRcVTYmtecZxkc;

	private static Guid wfyJrnSosZSbgAgOzwKleiMKBEme;

	private readonly IUnifiedKeyboardSource fhnAIbSwkVCbKbsegDWggnfBKQuec;

	private ModifierKeyFlags dxbNRCsfoAqJFtdUHjoGcgWKZNFh;

	private ModifierKeyFlags EGjSNwWHiyHfTBXTDcaCRvWLVczsA;

	private Func<KeyboardKeyCode, int> gTXRkwewKjWAWJgdGEfRfqTgRLEi;

	private readonly int[] rspZZdokxcSOgHfBaWKyoDOTGLXC;

	private readonly int ZzLNbFGtyOSSsDqwbVoQnFCYhRci;

	private readonly NSbrwSqxkQipOgPUDCHONhtFYAor kiJMLMpqELEFKgMIzEGEkUorUmjO;

	private readonly VSVmHUODbXomiGNnnXuDkqxnRQPA kwZBHbqnPMmvAXfibcrjBbmkLKNBb;

	private Dictionary<int, ZPTQbqTcMztpVfxJBhgQVISNhphW> hmghCKGlrItzSivjeGDwpXQcFCRM;

	private Dictionary<int, iVIXOHFicTRPMDAZUNUaXgbjgFmK> bCEjKjjpvUvptEfuPjYshrcuaymeA;

	private static KeyboardKeyCode[] WBgHHgAhSGxdRjtVkotXZvSZEKaab => akTqeKPWUhjKhyPLXIFBiyAhOaTcA();

	private Dictionary<int, ZPTQbqTcMztpVfxJBhgQVISNhphW> yFvknJVupnNjKutRkspXmGBBczsl => KyYdecEyDktVErmuPzrMAGaOudVMA();

	private Dictionary<int, iVIXOHFicTRPMDAZUNUaXgbjgFmK> oqxlDWKVrXDLrVBPvuRlpCGtgSJbA => qbrLmTlFHecAtkjAGtkUAOnyPnKdb();

	Guid Controller.deviceInstanceGuid => get_deviceInstanceGuid();

	private static KeyboardKeyCode[] akTqeKPWUhjKhyPLXIFBiyAhOaTcA()
	{
		if (ThvuzprjuBrXiTQRcVTYmtecZxkc == null)
		{
			int[] keyboardKeyValues = Consts._keyboardKeyValues;
			int num = keyboardKeyValues.Length;
			ThvuzprjuBrXiTQRcVTYmtecZxkc = new KeyboardKeyCode[num];
			for (int i = 0; i < num; i++)
			{
				ThvuzprjuBrXiTQRcVTYmtecZxkc[i] = (KeyboardKeyCode)keyboardKeyValues[i];
			}
		}
		return ThvuzprjuBrXiTQRcVTYmtecZxkc;
	}

	private Dictionary<int, ZPTQbqTcMztpVfxJBhgQVISNhphW> KyYdecEyDktVErmuPzrMAGaOudVMA()
	{
		if (hmghCKGlrItzSivjeGDwpXQcFCRM == null)
		{
			Rewired.Utils.Interfaces.IReadOnlyDictionary<int, ModifierKeyInfo> modifierKeyInfo = Consts.modifierKeyInfo;
			Dictionary<int, ZPTQbqTcMztpVfxJBhgQVISNhphW> dictionary = new Dictionary<int, ZPTQbqTcMztpVfxJBhgQVISNhphW>();
			foreach (KeyValuePair<int, ModifierKeyInfo> item in modifierKeyInfo)
			{
				if (item.Key != 0)
				{
					dictionary.Add(item.Key, new ZPTQbqTcMztpVfxJBhgQVISNhphW(item.Value.shortKey, item.Value.longKey));
				}
			}
			hmghCKGlrItzSivjeGDwpXQcFCRM = dictionary;
		}
		return hmghCKGlrItzSivjeGDwpXQcFCRM;
	}

	private Dictionary<int, iVIXOHFicTRPMDAZUNUaXgbjgFmK> qbrLmTlFHecAtkjAGtkUAOnyPnKdb()
	{
		if (bCEjKjjpvUvptEfuPjYshrcuaymeA == null)
		{
			Rewired.Utils.Interfaces.IReadOnlyDictionary<int, ModifierKeyInfo> modifierKeyInfo = Consts.modifierKeyInfo;
			Dictionary<int, iVIXOHFicTRPMDAZUNUaXgbjgFmK> dictionary = new Dictionary<int, iVIXOHFicTRPMDAZUNUaXgbjgFmK>();
			foreach (KeyValuePair<int, ModifierKeyInfo> item in modifierKeyInfo)
			{
				if (item.Key != 0)
				{
					iVIXOHFicTRPMDAZUNUaXgbjgFmK value = new iVIXOHFicTRPMDAZUNUaXgbjgFmK(new KeyedGlyph());
					dictionary.Add(item.Key, value);
				}
			}
			bCEjKjjpvUvptEfuPjYshrcuaymeA = dictionary;
		}
		return bCEjKjjpvUvptEfuPjYshrcuaymeA;
	}

	internal Keyboard(string P_0, IUnifiedKeyboardSource P_1)
		: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.hardwareMap, 132, P_1?.controllerExtension, new ControllerDataUpdater(P_1.inputSource, 0, 132, null))
	{
		wfyJrnSosZSbgAgOzwKleiMKBEme = MiscTools.CreateGuidHashSHA1("[Universal Keyboard]");
		kiJMLMpqELEFKgMIzEGEkUorUmjO = new NSbrwSqxkQipOgPUDCHONhtFYAor(() =>
		{
			IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
			for (int i = 0; i < values.Count; i++)
			{
				BjobjQSVpLEDNRAOZGjnkUqsyjUSA(values[i], true);
				BjobjQSVpLEDNRAOZGjnkUqsyjUSA(values[i], false);
			}
		});
		kwZBHbqnPMmvAXfibcrjBbmkLKNBb = new VSVmHUODbXomiGNnnXuDkqxnRQPA(() =>
		{
			IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
			for (int i = 0; i < values.Count; i++)
			{
				hMrmEQdKkxonfUTklIDhOXCZpgPg(values[i]);
			}
		});
		int[] keyboardKeyValues = Consts._keyboardKeyValues;
		int num = keyboardKeyValues.Length;
		for (int num2 = 0; num2 < num; num2++)
		{
			if (keyboardKeyValues[num2] > ZzLNbFGtyOSSsDqwbVoQnFCYhRci)
			{
				ZzLNbFGtyOSSsDqwbVoQnFCYhRci = keyboardKeyValues[num2];
			}
		}
		rspZZdokxcSOgHfBaWKyoDOTGLXC = new int[ZzLNbFGtyOSSsDqwbVoQnFCYhRci + 1];
		ArrayTools.Fill(rspZZdokxcSOgHfBaWKyoDOTGLXC, -1);
		for (int num3 = 0; num3 < num; num3++)
		{
			rspZZdokxcSOgHfBaWKyoDOTGLXC[keyboardKeyValues[num3]] = num3;
		}
		fhnAIbSwkVCbKbsegDWggnfBKQuec = P_1;
		if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
		{
			((OxefyMfZIgXEzbqjvpxteWerzayF)kiJMLMpqELEFKgMIzEGEkUorUmjO).Localize();
		}
		if (GlyphManager.isEnabled && GlyphManager.autoPrefetch)
		{
			((IPrefetch)kwZBHbqnPMmvAXfibcrjBbmkLKNBb).Prefetch();
		}
		EMBHjcsxjUDMCsHethyxgQTJtbEg();
	}

	private Keyboard(int P_0, InputSource P_1, string P_2, string P_3, HardwareControllerMap_Game P_4, int P_5, Extension P_6, ControllerDataUpdater P_7)
		: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Keyboard, Consts.hardwareTypeGuid_universalKeyboard, P_5, null, P_4, P_6, P_7)
	{
		gzOGLzgpZoDbdQRapjSqyJOWNLaaA = this;
	}

	public Guid get_deviceInstanceGuid()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return Guid.Empty;
		}
		return wfyJrnSosZSbgAgOzwKleiMKBEme;
	}

	public bool GetKey(KeyCode keyCode)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if ((uint)keyCode > (uint)ZzLNbFGtyOSSsDqwbVoQnFCYhRci)
		{
			return false;
		}
		int num = rspZZdokxcSOgHfBaWKyoDOTGLXC[(int)keyCode];
		if (num < 0)
		{
			return false;
		}
		return buttons[num].value;
	}

	public bool GetKeyDown(KeyCode keyCode)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if ((uint)keyCode > (uint)ZzLNbFGtyOSSsDqwbVoQnFCYhRci)
		{
			return false;
		}
		int num = rspZZdokxcSOgHfBaWKyoDOTGLXC[(int)keyCode];
		if (num < 0)
		{
			return false;
		}
		return buttons[num].justPressed;
	}

	public bool GetKeyUp(KeyCode keyCode)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if ((uint)keyCode > (uint)ZzLNbFGtyOSSsDqwbVoQnFCYhRci)
		{
			return false;
		}
		int num = rspZZdokxcSOgHfBaWKyoDOTGLXC[(int)keyCode];
		if (num < 0)
		{
			return false;
		}
		return buttons[num].justReleased;
	}

	public bool GetKeyDoublePressHold(KeyCode keyCode, float speed)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if ((uint)keyCode > (uint)ZzLNbFGtyOSSsDqwbVoQnFCYhRci)
		{
			return false;
		}
		int num = rspZZdokxcSOgHfBaWKyoDOTGLXC[(int)keyCode];
		if (num < 0)
		{
			return false;
		}
		return buttons[num].DoublePressedAndHeld(speed);
	}

	public bool GetKeyDoublePressHold(KeyCode keyCode)
	{
		if ((uint)keyCode > (uint)ZzLNbFGtyOSSsDqwbVoQnFCYhRci)
		{
			return false;
		}
		int num = rspZZdokxcSOgHfBaWKyoDOTGLXC[(int)keyCode];
		if (num < 0)
		{
			return false;
		}
		return buttons[num].DoublePressedAndHeld(0f);
	}

	public bool GetKeyDoublePressDown(KeyCode keyCode, float speed)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if ((uint)keyCode > (uint)ZzLNbFGtyOSSsDqwbVoQnFCYhRci)
		{
			return false;
		}
		int num = rspZZdokxcSOgHfBaWKyoDOTGLXC[(int)keyCode];
		if (num < 0)
		{
			return false;
		}
		return buttons[num].JustDoublePressed(speed);
	}

	public bool GetKeyDoublePressDown(KeyCode keyCode)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if ((uint)keyCode > (uint)ZzLNbFGtyOSSsDqwbVoQnFCYhRci)
		{
			return false;
		}
		int num = rspZZdokxcSOgHfBaWKyoDOTGLXC[(int)keyCode];
		if (num < 0)
		{
			return false;
		}
		return buttons[num].JustDoublePressed(0f);
	}

	public bool GetKeyPrev(KeyCode keyCode)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if ((uint)keyCode > (uint)ZzLNbFGtyOSSsDqwbVoQnFCYhRci)
		{
			return false;
		}
		int num = rspZZdokxcSOgHfBaWKyoDOTGLXC[(int)keyCode];
		if (num < 0)
		{
			return false;
		}
		return buttons[num].valuePrev;
	}

	public double GetKeyTimePressed(KeyCode keyCode)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if ((uint)keyCode > (uint)ZzLNbFGtyOSSsDqwbVoQnFCYhRci)
		{
			return 0.0;
		}
		int num = rspZZdokxcSOgHfBaWKyoDOTGLXC[(int)keyCode];
		if (num < 0)
		{
			return 0.0;
		}
		return buttons[num].timePressed;
	}

	public double GetKeyTimeUnpressed(KeyCode keyCode)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if ((uint)keyCode > (uint)ZzLNbFGtyOSSsDqwbVoQnFCYhRci)
		{
			return 0.0;
		}
		int num = rspZZdokxcSOgHfBaWKyoDOTGLXC[(int)keyCode];
		if (num < 0)
		{
			return 0.0;
		}
		return buttons[num].timeUnpressed;
	}

	public bool GetModifierKey(ModifierKey key)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if (!IAxaPXkVXAacxYqeckOKcqMncdKw(out var button, out var button2, key))
		{
			return false;
		}
		if (button.value || button2.value)
		{
			return true;
		}
		return false;
	}

	public bool GetModifierKeyDown(ModifierKey key)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if (!IAxaPXkVXAacxYqeckOKcqMncdKw(out var button, out var button2, key))
		{
			return false;
		}
		if (!button.value && !button2.value)
		{
			return false;
		}
		if (button.valuePrev || button2.valuePrev)
		{
			return false;
		}
		return true;
	}

	public bool GetModifierKeyUp(ModifierKey key)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if (!IAxaPXkVXAacxYqeckOKcqMncdKw(out var button, out var button2, key))
		{
			return false;
		}
		if (button.value || button2.value)
		{
			return false;
		}
		if (!button.valuePrev && !button2.valuePrev)
		{
			return false;
		}
		return true;
	}

	public bool GetModifierKeyPrev(ModifierKey key)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return false;
		}
		if (!IAxaPXkVXAacxYqeckOKcqMncdKw(out var button, out var button2, key))
		{
			return false;
		}
		if (button.valuePrev || button2.valuePrev)
		{
			return true;
		}
		return false;
	}

	public double GetModifierKeyTimePressed(ModifierKey key)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if (!IAxaPXkVXAacxYqeckOKcqMncdKw(out var button, out var button2, key))
		{
			return 0.0;
		}
		return MathTools.Max(button.timePressed, button2.timePressed);
	}

	public double GetModifierKeyTimeUnpressed(ModifierKey key)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return 0.0;
		}
		if (!IAxaPXkVXAacxYqeckOKcqMncdKw(out var button, out var button2, key))
		{
			return 0.0;
		}
		return MathTools.Min(button.timeUnpressed, button2.timeUnpressed);
	}

	public KeyCode GetKeyCodeByButtonIndex(int buttonIndex)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return KeyCode.None;
		}
		return bWsNtLPZmlbIGQkjJQJaqyrMPnnM(GetKeyboardKeyCodeByButtonIndex(buttonIndex));
	}

	public KeyCode GetKeyCodeById(int elementIdentifierId)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return KeyCode.None;
		}
		return GetKeyCodeByButtonIndex(GetButtonIndexById(elementIdentifierId));
	}

	public int GetButtonIndexByKeyCode(KeyCode keyCode)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return -1;
		}
		if ((uint)keyCode > (uint)ZzLNbFGtyOSSsDqwbVoQnFCYhRci)
		{
			return -1;
		}
		return rspZZdokxcSOgHfBaWKyoDOTGLXC[(int)keyCode];
	}

	public ControllerElementIdentifier GetElementIdentifierByKeyCode(KeyCode keyCode)
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return null;
		}
		if ((uint)keyCode > (uint)ZzLNbFGtyOSSsDqwbVoQnFCYhRci)
		{
			return null;
		}
		int num = rspZZdokxcSOgHfBaWKyoDOTGLXC[(int)keyCode];
		if (num < 0)
		{
			return null;
		}
		return aHJMAWzbypGgwCcRCqDEaoqVGwfA.buttonElementIdentifiers_cache[num];
	}

	public ControllerPollingInfo PollForFirstKey()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
		}
		int count = Consts.keyboardKeyValues.Count;
		for (int i = 0; i < count; i++)
		{
			KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
			if (GetKey(keyCode))
			{
				return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), aHJMAWzbypGgwCcRCqDEaoqVGwfA.buttonElementIdentifierIds[i], keyCode);
			}
		}
		return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
	}

	[IteratorStateMachine(typeof(ThAbPIHyHxjxceeuehAkzUNmhgbhb))]
	public IEnumerable<ControllerPollingInfo> PollForAllKeys()
	{
		return new ThAbPIHyHxjxceeuehAkzUNmhgbhb(-2)
		{
			uXWKfRFnJorNsFpmEynuADKvwgru = this
		};
	}

	[IteratorStateMachine(typeof(iOhtrddANahYDfmmAeEyJkaazOoi))]
	public IEnumerable<ControllerPollingInfo> PollForAllKeysDown()
	{
		return new iOhtrddANahYDfmmAeEyJkaazOoi(-2)
		{
			MYaKRPyRvIbVCHRXFWcCKpifIYOE = this
		};
	}

	public ControllerPollingInfo PollForFirstKeyDown()
	{
		if (ReInput._id != qostqwFsdWROzwZYaTyZVeYSeDOM)
		{
			ReInput.CheckInitialized(qostqwFsdWROzwZYaTyZVeYSeDOM);
			return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
		}
		int count = Consts.keyboardKeyValues.Count;
		for (int i = 0; i < count; i++)
		{
			KeyCode keyCode = (KeyCode)Consts.keyboardKeyValues[i];
			if (GetKeyDown(keyCode))
			{
				return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, GetKeyName(keyCode), aHJMAWzbypGgwCcRCqDEaoqVGwfA.buttonElementIdentifierIds[i], keyCode);
			}
		}
		return ControllerPollingInfo.wybtSxBKyoFevDSBzxAFgDtcKhkHA();
	}

	public override ControllerPollingInfo PollForFirstButton()
	{
		return PollForFirstKey();
	}

	public override ControllerPollingInfo PollForFirstButtonDown()
	{
		return PollForFirstKeyDown();
	}

	public override IEnumerable<ControllerPollingInfo> PollForAllButtons()
	{
		return PollForAllKeys();
	}

	public override IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
	{
		return PollForAllKeysDown();
	}

	public static bool IsModifierKey(KeyCode key)
	{
		switch (key)
		{
		case KeyCode.None:
			return false;
		case KeyCode.RightShift:
		case KeyCode.LeftShift:
		case KeyCode.RightControl:
		case KeyCode.LeftControl:
		case KeyCode.RightAlt:
		case KeyCode.LeftAlt:
		case KeyCode.RightMeta:
		case KeyCode.LeftMeta:
			return true;
		default:
			return false;
		}
	}

	internal static bool hzZZLFZHMzadEfHJXJCMCovSzAed(KeyboardKeyCode P_0)
	{
		switch (P_0)
		{
		case KeyboardKeyCode.None:
			return false;
		case KeyboardKeyCode.RightShift:
		case KeyboardKeyCode.LeftShift:
		case KeyboardKeyCode.RightControl:
		case KeyboardKeyCode.LeftControl:
		case KeyboardKeyCode.RightAlt:
		case KeyboardKeyCode.LeftAlt:
		case KeyboardKeyCode.RightCommand:
		case KeyboardKeyCode.LeftCommand:
			return true;
		default:
			return false;
		}
	}

	public static ModifierKey KeyCodeToModifierKey(KeyCode key)
	{
		switch (key)
		{
		case KeyCode.None:
			return ModifierKey.None;
		case KeyCode.RightControl:
		case KeyCode.LeftControl:
			return ModifierKey.Control;
		case KeyCode.RightAlt:
		case KeyCode.LeftAlt:
			return ModifierKey.Alt;
		case KeyCode.RightMeta:
		case KeyCode.LeftMeta:
			return ModifierKey.Command;
		case KeyCode.RightShift:
		case KeyCode.LeftShift:
			return ModifierKey.Shift;
		default:
			return ModifierKey.None;
		}
	}

	public static ModifierKeyFlags KeyCodeToModifierKeyFlags(KeyCode key)
	{
		return key switch
		{
			KeyCode.LeftControl => ModifierKeyFlags.LeftControl, 
			KeyCode.RightControl => ModifierKeyFlags.RightControl, 
			KeyCode.LeftAlt => ModifierKeyFlags.LeftAlt, 
			KeyCode.RightAlt => ModifierKeyFlags.RightAlt, 
			KeyCode.LeftShift => ModifierKeyFlags.LeftShift, 
			KeyCode.RightShift => ModifierKeyFlags.RightShift, 
			KeyCode.LeftMeta => ModifierKeyFlags.LeftCommand, 
			KeyCode.RightMeta => ModifierKeyFlags.RightCommand, 
			_ => ModifierKeyFlags.None, 
		};
	}

	public static bool ModifierKeyFlagsContain(ModifierKeyFlags flags, ModifierKey key)
	{
		switch (key)
		{
		case ModifierKey.None:
			return false;
		case ModifierKey.Control:
			if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				return true;
			}
			if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				return true;
			}
			return false;
		case ModifierKey.Alt:
			if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				return true;
			}
			if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				return true;
			}
			return false;
		case ModifierKey.Shift:
			if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
			{
				return true;
			}
			if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				return true;
			}
			return false;
		case ModifierKey.Command:
			if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				return true;
			}
			if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				return true;
			}
			return false;
		default:
			return false;
		}
	}

	public static bool ModifierKeyFlagsContain(ModifierKeyFlags flags, KeyCode key)
	{
		switch (key)
		{
		case KeyCode.None:
			return false;
		case KeyCode.LeftControl:
			if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
			{
				return true;
			}
			return false;
		case KeyCode.RightControl:
			if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
			{
				return true;
			}
			return false;
		case KeyCode.LeftAlt:
			if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
			{
				return true;
			}
			return false;
		case KeyCode.RightAlt:
			if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
			{
				return true;
			}
			return false;
		case KeyCode.LeftShift:
			if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
			{
				return true;
			}
			return false;
		case KeyCode.RightShift:
			if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
			{
				return true;
			}
			return false;
		case KeyCode.LeftMeta:
			if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
			{
				return true;
			}
			return false;
		case KeyCode.RightMeta:
			if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
			{
				return true;
			}
			return false;
		default:
			return false;
		}
	}

	public static ModifierKey ModifierKeyFlagsToModifierKey(ModifierKeyFlags flags)
	{
		if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
		{
			return ModifierKey.Control;
		}
		if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
		{
			return ModifierKey.Control;
		}
		if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
		{
			return ModifierKey.Alt;
		}
		if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
		{
			return ModifierKey.Alt;
		}
		if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
		{
			return ModifierKey.Shift;
		}
		if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
		{
			return ModifierKey.Shift;
		}
		if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
		{
			return ModifierKey.Command;
		}
		if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
		{
			return ModifierKey.Command;
		}
		return ModifierKey.None;
	}

	public static KeyCode ModifierKeyFlagsToKeyCode(ModifierKeyFlags flags)
	{
		if ((flags & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
		{
			return KeyCode.LeftControl;
		}
		if ((flags & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
		{
			return KeyCode.RightControl;
		}
		if ((flags & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
		{
			return KeyCode.LeftAlt;
		}
		if ((flags & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
		{
			return KeyCode.RightAlt;
		}
		if ((flags & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
		{
			return KeyCode.LeftShift;
		}
		if ((flags & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
		{
			return KeyCode.RightShift;
		}
		if ((flags & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
		{
			return KeyCode.LeftMeta;
		}
		if ((flags & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
		{
			return KeyCode.RightMeta;
		}
		return KeyCode.None;
	}

	public static ModifierKeyFlags ModifierKeyToModifierKeyFlags(ModifierKey key)
	{
		return key switch
		{
			ModifierKey.None => ModifierKeyFlags.None, 
			ModifierKey.Control => ModifierKeyFlags.LeftControl | ModifierKeyFlags.RightControl, 
			ModifierKey.Alt => ModifierKeyFlags.LeftAlt | ModifierKeyFlags.RightAlt, 
			ModifierKey.Shift => ModifierKeyFlags.LeftShift | ModifierKeyFlags.RightShift, 
			ModifierKey.Command => ModifierKeyFlags.LeftCommand | ModifierKeyFlags.RightCommand, 
			_ => ModifierKeyFlags.None, 
		};
	}

	public static string GetKeyName(KeyCode key)
	{
		if (gzOGLzgpZoDbdQRapjSqyJOWNLaaA == null)
		{
			return string.Empty;
		}
		int buttonIndex = gzOGLzgpZoDbdQRapjSqyJOWNLaaA.GetButtonIndex(vztxvYXrxhewNOOGhOaDLFGBdahN(key));
		if (buttonIndex < 0)
		{
			return string.Empty;
		}
		return gzOGLzgpZoDbdQRapjSqyJOWNLaaA.ButtonElementIdentifiers[buttonIndex].get_name();
	}

	public static string GetKeyName(KeyCode key, ModifierKeyFlags flags)
	{
		string text = GetKeyName(key);
		if (flags != ModifierKeyFlags.None)
		{
			StringBuilder stringBuilder = new StringBuilder(text);
			stringBuilder.Append(" + ");
			stringBuilder.Append(ModifierKeyFlagsToString(flags));
			text = stringBuilder.ToString();
		}
		return text;
	}

	public static string GetModifierKeyName(ModifierKey modifierKey)
	{
		if (gzOGLzgpZoDbdQRapjSqyJOWNLaaA == null)
		{
			return string.Empty;
		}
		return gzOGLzgpZoDbdQRapjSqyJOWNLaaA.BjobjQSVpLEDNRAOZGjnkUqsyjUSA(modifierKey, false);
	}

	public static string GetModifierKeyName(ModifierKey modifierKey, bool getShortName)
	{
		if (gzOGLzgpZoDbdQRapjSqyJOWNLaaA == null)
		{
			return string.Empty;
		}
		return gzOGLzgpZoDbdQRapjSqyJOWNLaaA.BjobjQSVpLEDNRAOZGjnkUqsyjUSA(modifierKey, getShortName);
	}

	public static string ModifierKeyFlagsToString(ModifierKeyFlags flags, bool getShortName)
	{
		int num = 0;
		StringBuilder stringBuilder = new StringBuilder();
		if (ModifierKeyFlagsContain(flags, ModifierKey.Control))
		{
			stringBuilder.Append(GetModifierKeyName(ModifierKey.Control, getShortName));
			num++;
		}
		if (ModifierKeyFlagsContain(flags, ModifierKey.Command))
		{
			if (num > 0)
			{
				stringBuilder.Append(" + ");
			}
			stringBuilder.Append(GetModifierKeyName(ModifierKey.Command, getShortName));
			num++;
		}
		if (ModifierKeyFlagsContain(flags, ModifierKey.Alt))
		{
			if (num > 0)
			{
				stringBuilder.Append(" + ");
			}
			stringBuilder.Append(GetModifierKeyName(ModifierKey.Alt, getShortName));
			num++;
		}
		if (num >= 3)
		{
			return stringBuilder.ToString();
		}
		if (ModifierKeyFlagsContain(flags, ModifierKey.Shift))
		{
			if (num > 0)
			{
				stringBuilder.Append(" + ");
			}
			stringBuilder.Append(GetModifierKeyName(ModifierKey.Shift, getShortName));
			num++;
		}
		return stringBuilder.ToString();
	}

	public static string ModifierKeyFlagsToString(ModifierKeyFlags flags)
	{
		return ModifierKeyFlagsToString(flags, getShortName: false);
	}

	public static object GetModifierKeyGlyph(ModifierKey modifierKey)
	{
		if (gzOGLzgpZoDbdQRapjSqyJOWNLaaA == null)
		{
			return null;
		}
		return gzOGLzgpZoDbdQRapjSqyJOWNLaaA.hMrmEQdKkxonfUTklIDhOXCZpgPg(modifierKey);
	}

	internal static string dQCjoJNlyjNWtjFerFWsNtgFGQdr(ModifierKey P_0)
	{
		if (gzOGLzgpZoDbdQRapjSqyJOWNLaaA == null)
		{
			return string.Empty;
		}
		return gzOGLzgpZoDbdQRapjSqyJOWNLaaA.dIaenmijhZuXpMgPPIOWxfZiRfYV(P_0);
	}

	internal static KeyboardKeyCode vztxvYXrxhewNOOGhOaDLFGBdahN(KeyCode P_0)
	{
		return (KeyboardKeyCode)P_0;
	}

	internal static KeyCode bWsNtLPZmlbIGQkjJQJaqyrMPnnM(KeyboardKeyCode P_0)
	{
		return (KeyCode)P_0;
	}

	internal static ModifierKeyFlags yVOOnzQOZAndhwoswDCylSPzrfbg(ModifierKeyFlags P_0)
	{
		if ((P_0 & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
		{
			P_0 |= ModifierKeyFlags.RightControl;
		}
		if ((P_0 & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
		{
			P_0 |= ModifierKeyFlags.LeftControl;
		}
		if ((P_0 & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
		{
			P_0 |= ModifierKeyFlags.RightCommand;
		}
		if ((P_0 & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
		{
			P_0 |= ModifierKeyFlags.LeftCommand;
		}
		if ((P_0 & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
		{
			P_0 |= ModifierKeyFlags.RightAlt;
		}
		if ((P_0 & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
		{
			P_0 |= ModifierKeyFlags.LeftAlt;
		}
		if ((P_0 & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
		{
			P_0 |= ModifierKeyFlags.RightShift;
		}
		if ((P_0 & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
		{
			P_0 |= ModifierKeyFlags.LeftShift;
		}
		return P_0;
	}

	internal static int MopOEcUkLlWQZnYBbugSQiDxtAWm(ModifierKeyFlags P_0)
	{
		if (P_0 == ModifierKeyFlags.None)
		{
			return 0;
		}
		int num = 0;
		if ((P_0 & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl)
		{
			num++;
		}
		else if ((P_0 & ModifierKeyFlags.RightControl) == ModifierKeyFlags.RightControl)
		{
			num++;
		}
		if ((P_0 & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand)
		{
			num++;
		}
		else if ((P_0 & ModifierKeyFlags.RightCommand) == ModifierKeyFlags.RightCommand)
		{
			num++;
		}
		if ((P_0 & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt)
		{
			num++;
		}
		else if ((P_0 & ModifierKeyFlags.RightAlt) == ModifierKeyFlags.RightAlt)
		{
			num++;
		}
		if ((P_0 & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift)
		{
			num++;
		}
		else if ((P_0 & ModifierKeyFlags.RightShift) == ModifierKeyFlags.RightShift)
		{
			num++;
		}
		return num;
	}

	[CustomObfuscation(rename = false)]
	internal static KeyboardKeyCode GetKeyboardKeyCodeByButtonIndex(int buttonIndex)
	{
		if ((uint)buttonIndex > 132u)
		{
			return KeyboardKeyCode.None;
		}
		return akTqeKPWUhjKhyPLXIFBiyAhOaTcA()[buttonIndex];
	}

	internal static int kkGguClWsqoMZpUYXvDgHMOsFZGI(KeyboardKeyCode P_0)
	{
		int buttonIndex = gzOGLzgpZoDbdQRapjSqyJOWNLaaA.GetButtonIndex(P_0);
		if (buttonIndex < 0)
		{
			return -1;
		}
		return gzOGLzgpZoDbdQRapjSqyJOWNLaaA.ButtonElementIdentifiers[buttonIndex].get_id();
	}

	internal static void rtOODgVFayQeFFUGzfSlQrZxLkrX(ref int P_0, ref KeyCode P_1)
	{
		if (P_1 != KeyCode.None)
		{
			P_0 = kkGguClWsqoMZpUYXvDgHMOsFZGI(vztxvYXrxhewNOOGhOaDLFGBdahN(P_1));
		}
		else
		{
			P_1 = ReInput.jCkgZLcnXoMycBxzcMXWvnUfSROEb.CJDSMKuYTmJFQKoQSdBfaFNyeDGkA().GetKeyCodeById(P_0);
		}
	}

	internal void BTmRHXKUunHHrRMtTLxBauAfenrT(UpdateLoopType P_0)
	{
		fhnAIbSwkVCbKbsegDWggnfBKQuec.UpdateInputData(KRqNAliDQUoGilZWSpebheoTCzwBA);
		base.zGxdVtiyTLpxaqKGIAgsfZozxwRZA(P_0);
		ZtCSPdcKltHovjKDMBuuMSbAPIozA();
	}

	internal void whmbFkkYvbhlMqPYTZWvHwGLHVwy(UpdateLoopType P_0)
	{
		buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape].OnsYqlJnwMAVWAIfTSVljurlKtAhA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Escape, KRqNAliDQUoGilZWSpebheoTCzwBA);
		buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu].OnsYqlJnwMAVWAIfTSVljurlKtAhA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_Menu, KRqNAliDQUoGilZWSpebheoTCzwBA);
		buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_F2].OnsYqlJnwMAVWAIfTSVljurlKtAhA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_F2, KRqNAliDQUoGilZWSpebheoTCzwBA);
		buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow].OnsYqlJnwMAVWAIfTSVljurlKtAhA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_UpArrow, KRqNAliDQUoGilZWSpebheoTCzwBA);
		buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow].OnsYqlJnwMAVWAIfTSVljurlKtAhA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_RightArrow, KRqNAliDQUoGilZWSpebheoTCzwBA);
		buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow].OnsYqlJnwMAVWAIfTSVljurlKtAhA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_DownArrow, KRqNAliDQUoGilZWSpebheoTCzwBA);
		buttons[ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow].OnsYqlJnwMAVWAIfTSVljurlKtAhA(P_0, ThreadSafeUnityInput.Keyboard.keyValueIndex_LeftArrow, KRqNAliDQUoGilZWSpebheoTCzwBA);
	}

	internal bool LcRtBwpaNuFLMEtquABBTscmBwmbb(KeyboardKeyCode P_0)
	{
		if ((uint)P_0 > (uint)ZzLNbFGtyOSSsDqwbVoQnFCYhRci)
		{
			return false;
		}
		int num = rspZZdokxcSOgHfBaWKyoDOTGLXC[(int)P_0];
		if (num < 0)
		{
			return false;
		}
		return buttons[num].value;
	}

	internal bool yRoAvCOsLVIORwdNXwmizgdZHJKG(KeyboardKeyCode P_0)
	{
		if ((uint)P_0 > (uint)ZzLNbFGtyOSSsDqwbVoQnFCYhRci)
		{
			return false;
		}
		int num = rspZZdokxcSOgHfBaWKyoDOTGLXC[(int)P_0];
		if (num < 0)
		{
			return false;
		}
		return buttons[num].valuePrev;
	}

	internal bool DbSOkpYFUKHZTIVwRZLUnRZcAxZb(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
	{
		if (!LcRtBwpaNuFLMEtquABBTscmBwmbb(P_0))
		{
			return false;
		}
		if (P_1 == ModifierKeyFlags.None)
		{
			return true;
		}
		if ((P_1 & EGjSNwWHiyHfTBXTDcaCRvWLVczsA) != P_1)
		{
			return false;
		}
		double keyTimePressed = GetKeyTimePressed((KeyCode)P_0);
		if ((P_1 & ModifierKeyFlags.LeftControl) == ModifierKeyFlags.LeftControl && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Control))
		{
			return false;
		}
		if ((P_1 & ModifierKeyFlags.LeftCommand) == ModifierKeyFlags.LeftCommand && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Command))
		{
			return false;
		}
		if ((P_1 & ModifierKeyFlags.LeftAlt) == ModifierKeyFlags.LeftAlt && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Alt))
		{
			return false;
		}
		if ((P_1 & ModifierKeyFlags.LeftShift) == ModifierKeyFlags.LeftShift && keyTimePressed > GetModifierKeyTimePressed(ModifierKey.Shift))
		{
			return false;
		}
		return true;
	}

	internal bool dYKZwCceraHMqwLhqfzzAvXZPccXA(KeyboardKeyCode P_0, ModifierKeyFlags P_1)
	{
		if (LcRtBwpaNuFLMEtquABBTscmBwmbb(P_0))
		{
			return true;
		}
		if (GetModifierKey(ModifierKeyFlagsToModifierKey(P_1)))
		{
			return true;
		}
		return false;
	}

	[CustomObfuscation(rename = false)]
	internal int GetButtonIndex(KeyboardKeyCode keyCode)
	{
		if ((uint)keyCode > (uint)ZzLNbFGtyOSSsDqwbVoQnFCYhRci)
		{
			return -1;
		}
		return rspZZdokxcSOgHfBaWKyoDOTGLXC[(int)keyCode];
	}

	[CustomObfuscation(rename = false)]
	internal void BakeMap(ControllerMap controllerMap)
	{
		if (controllerMap != null)
		{
			IList<ActionElementMap> list = controllerMap.hycZGsxqYWqTYWkWVVCDVrvexwwT();
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				fGQOtKpVEJmrMXNYeONgsnXNwkIC(controllerMap, list[i]);
			}
		}
	}

	[CustomObfuscation(rename = false)]
	internal void BakeActionElementMap(ControllerMap controllerMap, ActionElementMap map)
	{
		map?.mmPDimdZnoHuGihimrrBmSVsLhfcb(controllerMap);
	}

	internal void wjQVOoybGFCzUqNDBKoPCuAzRnkL()
	{
		base.PodVUGvDnUHydzVhCxMAInDDVsXW();
		dxbNRCsfoAqJFtdUHjoGcgWKZNFh = ModifierKeyFlags.None;
		EGjSNwWHiyHfTBXTDcaCRvWLVczsA = ModifierKeyFlags.None;
	}

	internal bool zpKlmyhlFILePTPtljzmPzUCGLZm(bool P_0)
	{
		if (!base.inMOXJxCMugPOHqUhiIifiebgFebc(P_0))
		{
			return false;
		}
		if (fhnAIbSwkVCbKbsegDWggnfBKQuec is IGetSetEnabled)
		{
			(fhnAIbSwkVCbKbsegDWggnfBKQuec as IGetSetEnabled).enabled = P_0;
		}
		return true;
	}

	private bool IAxaPXkVXAacxYqeckOKcqMncdKw(out Button P_0, out Button P_1, ModifierKey P_2)
	{
		P_0 = null;
		P_1 = null;
		switch (P_2)
		{
		case ModifierKey.None:
			return false;
		case ModifierKey.Control:
			P_0 = buttons[rspZZdokxcSOgHfBaWKyoDOTGLXC[306]];
			P_1 = buttons[rspZZdokxcSOgHfBaWKyoDOTGLXC[305]];
			return true;
		case ModifierKey.Alt:
			P_0 = buttons[rspZZdokxcSOgHfBaWKyoDOTGLXC[308]];
			P_1 = buttons[rspZZdokxcSOgHfBaWKyoDOTGLXC[307]];
			return true;
		case ModifierKey.Command:
			P_0 = buttons[rspZZdokxcSOgHfBaWKyoDOTGLXC[310]];
			P_1 = buttons[rspZZdokxcSOgHfBaWKyoDOTGLXC[309]];
			return true;
		case ModifierKey.Shift:
			P_0 = buttons[rspZZdokxcSOgHfBaWKyoDOTGLXC[304]];
			P_1 = buttons[rspZZdokxcSOgHfBaWKyoDOTGLXC[303]];
			return true;
		default:
			return false;
		}
	}

	private void ZtCSPdcKltHovjKDMBuuMSbAPIozA()
	{
		ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
		if (buttons[rspZZdokxcSOgHfBaWKyoDOTGLXC[306]].value)
		{
			modifierKeyFlags |= ModifierKeyFlags.LeftControl;
		}
		if (buttons[rspZZdokxcSOgHfBaWKyoDOTGLXC[305]].value)
		{
			modifierKeyFlags |= ModifierKeyFlags.RightControl;
		}
		if (buttons[rspZZdokxcSOgHfBaWKyoDOTGLXC[310]].value)
		{
			modifierKeyFlags |= ModifierKeyFlags.LeftCommand;
		}
		if (buttons[rspZZdokxcSOgHfBaWKyoDOTGLXC[309]].value)
		{
			modifierKeyFlags |= ModifierKeyFlags.RightCommand;
		}
		if (buttons[rspZZdokxcSOgHfBaWKyoDOTGLXC[308]].value)
		{
			modifierKeyFlags |= ModifierKeyFlags.LeftAlt;
		}
		if (buttons[rspZZdokxcSOgHfBaWKyoDOTGLXC[307]].value)
		{
			modifierKeyFlags |= ModifierKeyFlags.RightAlt;
		}
		if (buttons[rspZZdokxcSOgHfBaWKyoDOTGLXC[304]].value)
		{
			modifierKeyFlags |= ModifierKeyFlags.LeftShift;
		}
		if (buttons[rspZZdokxcSOgHfBaWKyoDOTGLXC[303]].value)
		{
			modifierKeyFlags |= ModifierKeyFlags.RightShift;
		}
		dxbNRCsfoAqJFtdUHjoGcgWKZNFh = modifierKeyFlags;
		EGjSNwWHiyHfTBXTDcaCRvWLVczsA = yVOOnzQOZAndhwoswDCylSPzrfbg(modifierKeyFlags);
	}

	private string BjobjQSVpLEDNRAOZGjnkUqsyjUSA(ModifierKey P_0, bool P_1)
	{
		if (P_0 == ModifierKey.None)
		{
			return string.Empty;
		}
		ModifierKeyInfo modifierKeyInfo = Consts.modifierKeyInfo[(int)P_0];
		string result = modifierKeyInfo.GetName(P_1);
		if (!LocalizationManager.isEnabled)
		{
			return result;
		}
		if (!KyYdecEyDktVErmuPzrMAGaOudVMA().TryGetValue((int)P_0, out var value))
		{
			return result;
		}
		string result2;
		if (P_1)
		{
			if (value.KSJewQqFKxhMTSnSGCPTHPHnpEId != null && cjZCiYDkRfGJbeCFrulVTWDJZzYn(value.KSJewQqFKxhMTSnSGCPTHPHnpEId, modifierKeyInfo.shortKey, modifierKeyInfo.shortName, aHJMAWzbypGgwCcRCqDEaoqVGwfA.deviceLocalizationInfo, out result2))
			{
				return result2;
			}
			if (value.SxzkIHvfdWDPoebDWPCXBGtWAogHb != null && cjZCiYDkRfGJbeCFrulVTWDJZzYn(value.SxzkIHvfdWDPoebDWPCXBGtWAogHb, modifierKeyInfo.longKey, modifierKeyInfo.longName, aHJMAWzbypGgwCcRCqDEaoqVGwfA.deviceLocalizationInfo, out result2))
			{
				return result2;
			}
			return result;
		}
		if (value.SxzkIHvfdWDPoebDWPCXBGtWAogHb == null)
		{
			return result;
		}
		cjZCiYDkRfGJbeCFrulVTWDJZzYn(value.SxzkIHvfdWDPoebDWPCXBGtWAogHb, modifierKeyInfo.longKey, modifierKeyInfo.longName, aHJMAWzbypGgwCcRCqDEaoqVGwfA.deviceLocalizationInfo, out result2);
		return result2;
	}

	private static bool cjZCiYDkRfGJbeCFrulVTWDJZzYn(NjAOflGrmZHBxopImRGhvMZerrwc P_0, string P_1, string P_2, DeviceLocalizationInfo P_3, out string P_4)
	{
		LocalizationManager.GetAndUpdateLocalizedStringResultFlags getAndUpdateLocalizedStringResultFlags = DIFNnnaZcXQLPYxsIZWTkUfgTNzj.ejQmDWYYTbyZmGUJbbHLDieSsvUl(P_0.XHXfcMEBaWQOfUJeYSbyUBCAEQcjA, P_1, "controller", P_2, P_3, EIJabuCGuIkogTgNjoJeTXIEuNcy.Keyboard, -1, AxisRange.Full, -1, out P_4);
		if ((getAndUpdateLocalizedStringResultFlags & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.Changed) != LocalizationManager.GetAndUpdateLocalizedStringResultFlags.None)
		{
			P_0.sdKCFwTuTFlKzDiwMiOjVgmtcrlO = (getAndUpdateLocalizedStringResultFlags & LocalizationManager.GetAndUpdateLocalizedStringResultFlags.JustLocalized) != 0;
		}
		return P_0.sdKCFwTuTFlKzDiwMiOjVgmtcrlO;
	}

	private object hMrmEQdKkxonfUTklIDhOXCZpgPg(ModifierKey P_0)
	{
		if (P_0 == ModifierKey.None)
		{
			return null;
		}
		ModifierKeyInfo modifierKeyInfo = Consts.modifierKeyInfo[(int)P_0];
		if (!GlyphManager.isEnabled)
		{
			return null;
		}
		if (!qbrLmTlFHecAtkjAGtkUAOnyPnKdb().TryGetValue((int)P_0, out var value))
		{
			return null;
		}
		if (GQfLkNrJQmXPAGGRkBKFhSQyyzax(value, modifierKeyInfo.longKey, aHJMAWzbypGgwCcRCqDEaoqVGwfA.deviceLocalizationInfo, out var result))
		{
			return result;
		}
		return null;
	}

	private string dIaenmijhZuXpMgPPIOWxfZiRfYV(ModifierKey P_0)
	{
		if (P_0 == ModifierKey.None)
		{
			return null;
		}
		ModifierKeyInfo modifierKeyInfo = Consts.modifierKeyInfo[(int)P_0];
		if (!GlyphManager.isEnabled)
		{
			return null;
		}
		if (!qbrLmTlFHecAtkjAGtkUAOnyPnKdb().TryGetValue((int)P_0, out var value))
		{
			return null;
		}
		if (OwJOSMjPIaPhzPNcMtdqKrwuQXPJ(value, modifierKeyInfo.longKey, aHJMAWzbypGgwCcRCqDEaoqVGwfA.deviceLocalizationInfo, out var result))
		{
			return result;
		}
		return null;
	}

	private static bool GQfLkNrJQmXPAGGRkBKFhSQyyzax(iVIXOHFicTRPMDAZUNUaXgbjgFmK P_0, string P_1, DeviceLocalizationInfo P_2, out object P_3)
	{
		GlyphManager.GetAndUpdateGlyphResultFlags getAndUpdateGlyphResultFlags = vAHPFPhkhgNIjzvoIpmTJXLxjDhy.QrYdifztHBGkRdmBSXcpRTxarRQPA(P_0.YQgYNeVzITsuEAzYOUJZqxGADYq, P_1, "controller", P_2, EIJabuCGuIkogTgNjoJeTXIEuNcy.Keyboard, -1, AxisRange.Full, -1, out P_3);
		if ((getAndUpdateGlyphResultFlags & GlyphManager.GetAndUpdateGlyphResultFlags.Changed) != GlyphManager.GetAndUpdateGlyphResultFlags.None)
		{
			P_0.eePEJLbuXqFVbybEzsfPPYffLrvaA = (getAndUpdateGlyphResultFlags & GlyphManager.GetAndUpdateGlyphResultFlags.JustGot) != 0;
		}
		return P_0.eePEJLbuXqFVbybEzsfPPYffLrvaA;
	}

	private static bool OwJOSMjPIaPhzPNcMtdqKrwuQXPJ(iVIXOHFicTRPMDAZUNUaXgbjgFmK P_0, string P_1, DeviceLocalizationInfo P_2, out string P_3)
	{
		bool result = GQfLkNrJQmXPAGGRkBKFhSQyyzax(P_0, P_1, P_2, out var _);
		P_3 = P_0.YQgYNeVzITsuEAzYOUJZqxGADYq.cachedKey;
		return result;
	}

	[CompilerGenerated]
	private void mmzbtNlfENMlxQKVKYwdEbpXFWIo()
	{
		IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
		for (int i = 0; i < values.Count; i++)
		{
			BjobjQSVpLEDNRAOZGjnkUqsyjUSA(values[i], true);
			BjobjQSVpLEDNRAOZGjnkUqsyjUSA(values[i], false);
		}
	}

	[CompilerGenerated]
	private void zVLRsaWlxduuhUVqShrzHmawSgrm()
	{
		IList<ModifierKey> values = EnumValueHelper<ModifierKey>.Default.values;
		for (int i = 0; i < values.Count; i++)
		{
			hMrmEQdKkxonfUTklIDhOXCZpgPg(values[i]);
		}
	}
}
