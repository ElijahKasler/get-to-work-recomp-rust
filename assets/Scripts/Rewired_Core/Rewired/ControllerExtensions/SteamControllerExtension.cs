using System.Collections.Generic;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ControllerExtensions;

[CustomObfuscation(rename = false)]
[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
internal class SteamControllerExtension : Controller.Extension
{
	private class dLyFgqCkghKiIsRatHmrPcLKKbBVA : IControllerExtensionSource
	{
		public readonly ISteamControllerInternal tlcaJiMrzlWxyqicuUyfvGzQuagN;

		public dLyFgqCkghKiIsRatHmrPcLKKbBVA(ISteamControllerInternal P_0)
		{
			tlcaJiMrzlWxyqicuUyfvGzQuagN = P_0;
		}
	}

	private dLyFgqCkghKiIsRatHmrPcLKKbBVA JaFqAKliyTSVVwwvkvtOedMvdjkX;

	private Joystick joystick => NfYFyxbyXsHjCohOJLnIiYOyiauG();

	internal ISteamControllerInternal internalController => JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN;

	private Joystick NfYFyxbyXsHjCohOJLnIiYOyiauG()
	{
		return GetController<Joystick>();
	}

	internal SteamControllerExtension(ISteamControllerInternal P_0)
		: base(new dLyFgqCkghKiIsRatHmrPcLKKbBVA(P_0))
	{
		qKduLRayScDDPOoWTyibzPcESOWN();
	}

	private SteamControllerExtension(SteamControllerExtension P_0)
		: base(P_0)
	{
		qKduLRayScDDPOoWTyibzPcESOWN();
	}

	public ulong GetActionSetHandle(string actionSetName)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0uL;
		}
		return JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.GetActionSetHandle(ref actionSetName);
	}

	public ulong GetAnalogActionHandle(string actionName)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0uL;
		}
		return JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.GetAnalogActionHandle(ref actionName);
	}

	public ulong GetDigitalActionHandle(string actionName)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0uL;
		}
		return JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.GetDigitalActionHandle(ref actionName);
	}

	public string GetActionSetName(ulong actionSetHandle)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return string.Empty;
		}
		return JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.GetActionSetName(actionSetHandle);
	}

	public string GetAnalogActionName(ulong actionHandle)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return string.Empty;
		}
		return JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.GetAnalogActionName(actionHandle);
	}

	public string GetDigitalActionName(ulong actionHandle)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return string.Empty;
		}
		return JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.GetDigitalActionName(actionHandle);
	}

	public Vector2 GetAnalogActionValue(string actionName)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return Vector2.zero;
		}
		return JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.GetAnalogActionValue(ref actionName);
	}

	public Vector2 GetAnalogActionValue(ulong actionHandle)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return Vector2.zero;
		}
		return JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.GetAnalogActionValue(actionHandle);
	}

	public bool GetDigitalActionValue(string actionName)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return false;
		}
		return JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.GetDigitalActionValue(ref actionName);
	}

	public bool GetDigitalActionValue(ulong actionHandle)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return false;
		}
		return JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.GetDigitalActionValue(actionHandle);
	}

	public bool SetActiveActionSet(ulong actionSetHandle)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return false;
		}
		return JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.SetActiveActionSet(actionSetHandle);
	}

	public bool SetActiveActionSet(string actionSetName)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return false;
		}
		return JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.SetActiveActionSet(ref actionSetName);
	}

	public ulong GetActiveActionSetHandle()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return 0uL;
		}
		return JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.GetActiveActionSetHandle();
	}

	public string GetActiveActionSetName()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return string.Empty;
		}
		return JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.GetActiveActionSetName();
	}

	public void ShowBindingPanel()
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else
		{
			JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.ShowBindingPanel();
		}
	}

	public void SetHapticPulse(SteamControllerPadType targePad, float durationSeconds)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else
		{
			JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.SetHapticPulse(targePad, durationSeconds);
		}
	}

	public void SetHapticPulse(SteamControllerPadType targePad, ushort durationMicroSeconds)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
		}
		else
		{
			JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.SetHapticPulse(targePad, durationMicroSeconds);
		}
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(string actionSetName, string actionName)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
		}
		return JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.GetDigitalActionOrigins(ref actionSetName, ref actionName);
	}

	public IList<SteamControllerActionOrigin> GetDigitalActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
		}
		return JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.GetDigitalActionOrigins(actionSetHandle, actionHandle);
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(string actionSetName, string actionName)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
		}
		return JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.GetAnalogActionOrigins(ref actionSetName, ref actionName);
	}

	public IList<SteamControllerActionOrigin> GetAnalogActionOrigins(ulong actionSetHandle, ulong actionHandle)
	{
		if (ReInput._id != _reInputId)
		{
			ReInput.CheckInitialized(_reInputId);
			return EmptyObjects<SteamControllerActionOrigin>.EmptyReadOnlyIListT;
		}
		return JaFqAKliyTSVVwwvkvtOedMvdjkX.tlcaJiMrzlWxyqicuUyfvGzQuagN.GetAnalogActionOrigins(actionSetHandle, actionHandle);
	}

	internal override void UpdateData(UpdateLoopType updateLoop)
	{
	}

	internal override void SourceUpdated(IControllerExtensionSource source)
	{
		JaFqAKliyTSVVwwvkvtOedMvdjkX = source as dLyFgqCkghKiIsRatHmrPcLKKbBVA;
	}

	internal override Controller.Extension Clone()
	{
		return new SteamControllerExtension(this);
	}

	private void qKduLRayScDDPOoWTyibzPcESOWN()
	{
	}
}
