using System;
using System.Collections.Generic;

namespace Rewired.Platforms.Custom;

public abstract class CustomPlatformInputSource : CustomInputSource
{
	public new abstract class Joystick : CustomInputSource.Joystick
	{
		protected Joystick(string P_0, long P_1, int P_2, int P_3)
			: base(P_0, P_1, P_2, P_3)
		{
			_isConnected = true;
		}
	}

	public sealed class InitOptions
	{
		public CustomPlatformUnifiedKeyboardSource unifiedKeyboardSource;

		public CustomPlatformUnifiedMouseSource unifiedMouseSource;
	}

	private readonly CustomPlatformConfigVars ptyXxUYNUGDyJGHEiMGEhLwlzpKG;

	private readonly bool OCDBDiUDSQDEHaSbcjVyZIjUvYnO;

	private readonly bool ymzlGnskAcFRhhcPtYBCSwrTHily;

	private bool PoJCVKQkleEqshBdgBZbNDfGEMjeA;

	protected CustomPlatformInputSource(CustomPlatformConfigVars P_0, InitOptions P_1)
		: base(100, (P_1 != null && P_1.unifiedKeyboardSource != null && P_0.useNativeKeyboard) ? new WLIVIlxdVKgPkFEvauwevsQWPUHi(P_1.unifiedKeyboardSource) : null, (P_1 != null && P_1.unifiedMouseSource != null && P_0.useNativeMouse) ? new xzxZfgrWdxPfQfTLTIdNMADfgGuR(P_1.unifiedMouseSource) : null)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("configVars");
		}
		ptyXxUYNUGDyJGHEiMGEhLwlzpKG = P_0;
		if (P_1 == null || P_1.unifiedKeyboardSource == null)
		{
			P_0.useNativeKeyboard = false;
		}
		if (P_1 == null || P_1.unifiedMouseSource == null)
		{
			P_0.useNativeMouse = false;
		}
		OCDBDiUDSQDEHaSbcjVyZIjUvYnO = P_0.useNativeKeyboard;
		ymzlGnskAcFRhhcPtYBCSwrTHily = P_0.useNativeMouse;
	}

	internal virtual void moEcjngsFhVbbmvYdbfgMhuCwvqU()
	{
		base.vLobTBkoHLkWgGTJFbSLORdclPkfc();
		if (OCDBDiUDSQDEHaSbcjVyZIjUvYnO && yrusJnycTryufNRnTDYdTOocFolh() is tLXHXtPkzoCxWTdhCCBPKJGccMByA)
		{
			(yrusJnycTryufNRnTDYdTOocFolh() as tLXHXtPkzoCxWTdhCCBPKJGccMByA).ZuUHEcedBdXtXALgOKADgkVVQEZP();
		}
		if (ymzlGnskAcFRhhcPtYBCSwrTHily && zbsTkGFlyWYPVbaeiZAucrajmamK() is tLXHXtPkzoCxWTdhCCBPKJGccMByA)
		{
			(zbsTkGFlyWYPVbaeiZAucrajmamK() as tLXHXtPkzoCxWTdhCCBPKJGccMByA).ZuUHEcedBdXtXALgOKADgkVVQEZP();
		}
	}

	internal virtual void IFPYEMdUpdbNWtNUDHezocFFsugt()
	{
		base.TiyPlhubPjCWsikbKViAwLnzFcUaA();
		IList<CustomInputSource.Joystick> joysticks = GetJoysticks();
		int count = joysticks.Count;
		for (int i = 0; i < count; i++)
		{
			joysticks[i].OlMxqNLsIInWYKgYqGyzhCpTLUhI();
			joysticks[i].Update();
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (!PoJCVKQkleEqshBdgBZbNDfGEMjeA)
		{
			PoJCVKQkleEqshBdgBZbNDfGEMjeA = true;
			base.Dispose(disposing);
		}
	}
}
