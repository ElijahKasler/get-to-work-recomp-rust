using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.Data.Mapping;

[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
public sealed class HardwareJoystickMap : ScriptableObject, IHardwareControllerMap, IHardwareControllerMap_Internal
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public abstract class Platform : IDeepCloneable
	{
		private sealed class yqVAPLIOCXnfvzFwArOQluCMeuNXA : IEnumerable<Platform>, IEnumerable, IEnumerator<Platform>, IEnumerator, IDisposable
		{
			private int nunRleJvpnxhQmqASpyeZifEmXUH;

			private Platform WZXicsLAqQxFnTUvpssSSISsxtBF;

			private int YblaRcFRtbyMpsZSLAMNWwoLztjJ;

			public Platform jMQuRODQFpUMjJCPQpMzyvmJdMUm;

			private IList<Platform> cVpbRJKeQEJhFUxhIlocrcOulUWBb;

			private int xYJqJNWITGNPDZrqaaWjFUtqVQbQA;

			Platform IEnumerator<Platform>.Current
			{
				[DebuggerHidden]
				get
				{
					return WZXicsLAqQxFnTUvpssSSISsxtBF;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WZXicsLAqQxFnTUvpssSSISsxtBF;
				}
			}

			[DebuggerHidden]
			public yqVAPLIOCXnfvzFwArOQluCMeuNXA(int P_0)
			{
				nunRleJvpnxhQmqASpyeZifEmXUH = P_0;
				YblaRcFRtbyMpsZSLAMNWwoLztjJ = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = nunRleJvpnxhQmqASpyeZifEmXUH;
				Platform platform = jMQuRODQFpUMjJCPQpMzyvmJdMUm;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					nunRleJvpnxhQmqASpyeZifEmXUH = -1;
					goto IL_0077;
				}
				nunRleJvpnxhQmqASpyeZifEmXUH = -1;
				cVpbRJKeQEJhFUxhIlocrcOulUWBb = platform.GetVariants();
				if (cVpbRJKeQEJhFUxhIlocrcOulUWBb == null)
				{
					return false;
				}
				xYJqJNWITGNPDZrqaaWjFUtqVQbQA = 0;
				goto IL_0087;
				IL_0087:
				if (xYJqJNWITGNPDZrqaaWjFUtqVQbQA < cVpbRJKeQEJhFUxhIlocrcOulUWBb.Count)
				{
					if (cVpbRJKeQEJhFUxhIlocrcOulUWBb[xYJqJNWITGNPDZrqaaWjFUtqVQbQA] != null)
					{
						WZXicsLAqQxFnTUvpssSSISsxtBF = cVpbRJKeQEJhFUxhIlocrcOulUWBb[xYJqJNWITGNPDZrqaaWjFUtqVQbQA];
						nunRleJvpnxhQmqASpyeZifEmXUH = 1;
						return true;
					}
					goto IL_0077;
				}
				return false;
				IL_0077:
				xYJqJNWITGNPDZrqaaWjFUtqVQbQA++;
				goto IL_0087;
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
			IEnumerator<Platform> IEnumerable<Platform>.GetEnumerator()
			{
				yqVAPLIOCXnfvzFwArOQluCMeuNXA yqVAPLIOCXnfvzFwArOQluCMeuNXA2;
				if (nunRleJvpnxhQmqASpyeZifEmXUH == -2 && YblaRcFRtbyMpsZSLAMNWwoLztjJ == Environment.CurrentManagedThreadId)
				{
					nunRleJvpnxhQmqASpyeZifEmXUH = 0;
					yqVAPLIOCXnfvzFwArOQluCMeuNXA2 = this;
				}
				else
				{
					yqVAPLIOCXnfvzFwArOQluCMeuNXA2 = new yqVAPLIOCXnfvzFwArOQluCMeuNXA(0);
					yqVAPLIOCXnfvzFwArOQluCMeuNXA2.jMQuRODQFpUMjJCPQpMzyvmJdMUm = jMQuRODQFpUMjJCPQpMzyvmJdMUm;
				}
				return yqVAPLIOCXnfvzFwArOQluCMeuNXA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform>)this).GetEnumerator();
			}
		}

		[Tooltip("A description of this platform map. For reference only.")]
		public string description;

		internal abstract InputPlatform platform { get; }

		public abstract int assignedButtonCount { get; }

		public abstract int assignedAxisCount { get; }

		public virtual string controllerNameOverride => null;

		internal abstract Elements_Base elements_base { get; }

		internal virtual bool isAllowed
		{
			get
			{
				if (!disabled)
				{
					if (assignedButtonCount <= 0)
					{
						return assignedAxisCount > 0;
					}
					return true;
				}
				return false;
			}
		}

		internal abstract bool hasData { get; }

		internal abstract bool disabled { get; }

		internal IEnumerable<Platform> Variants
		{
			[IteratorStateMachine(typeof(yqVAPLIOCXnfvzFwArOQluCMeuNXA))]
			get
			{
				return new yqVAPLIOCXnfvzFwArOQluCMeuNXA(-2)
				{
					jMQuRODQFpUMjJCPQpMzyvmJdMUm = this
				};
			}
		}

		internal bool hasVariants => variantCount > 0;

		[CustomObfuscation(rename = false)]
		internal int variantCount
		{
			get
			{
				if (GetVariants() == null)
				{
					return 0;
				}
				return GetVariants().Count;
			}
		}

		internal bool selfOrVariantHasData
		{
			get
			{
				if (hasData)
				{
					return true;
				}
				foreach (Platform variant in Variants)
				{
					if (variant.hasData)
					{
						return true;
					}
				}
				return false;
			}
		}

		internal bool selfOrVariantIsValid
		{
			get
			{
				if (!selfOrVariantHasData)
				{
					return false;
				}
				if (isAllowed && hasData)
				{
					return true;
				}
				foreach (Platform variant in Variants)
				{
					if (variant.isAllowed && variant.hasData)
					{
						return true;
					}
				}
				return false;
			}
		}

		internal bool selfOrVariantIsAllowed
		{
			get
			{
				if (isAllowed)
				{
					return true;
				}
				foreach (Platform variant in Variants)
				{
					if (variant.isAllowed)
					{
						return true;
					}
				}
				return false;
			}
		}

		internal abstract bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap);

		internal abstract void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes);

		internal abstract bool IsElementIdentifierMapped(int elementIdentifierId);

		public abstract IList<Platform> GetVariants();

		internal Platform GetFirstValidPlatformMap(out int variantIndex)
		{
			variantIndex = -1;
			if (!selfOrVariantIsValid)
			{
				return null;
			}
			if (isAllowed && hasData)
			{
				variantIndex = -1;
				return this;
			}
			IList<Platform> variants = GetVariants();
			if (variants != null)
			{
				for (int i = 0; i < variants.Count; i++)
				{
					Platform platform = variants[i];
					if (platform != null && platform.isAllowed && platform.hasData)
					{
						variantIndex = i;
						return platform;
					}
				}
			}
			return null;
		}

		internal int IndexOfElementIdentifier(ControllerElementIdentifier[] elementIdentifiers, int id)
		{
			if (elementIdentifiers == null)
			{
				return -1;
			}
			for (int i = 0; i < elementIdentifiers.Length; i++)
			{
				if (elementIdentifiers[i].get_id() == id)
				{
					return i;
				}
			}
			return -1;
		}

		internal abstract AxisCalibrationData[] GetAxisCalibrationData();

		internal abstract void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos);

		internal abstract void GetButtonData(out HardwareButtonInfo[] buttonInfos);

		internal abstract ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier);

		internal abstract bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange);

		internal Platform GetPlatformMap(int variantIndex)
		{
			if (variantIndex < 0)
			{
				return this;
			}
			if (!hasVariants)
			{
				return null;
			}
			IList<Platform> variants = GetVariants();
			if (variantCount <= variantIndex)
			{
				return null;
			}
			return variants[variantIndex];
		}

		internal HardwareJoystickMap_InputManager ToHardwareJoystickMap_InputManager(HardwareJoystickMap hardwareJoystickMap, InputSource inputSource, InputPlatform actualInputPlatform, int variantIndex)
		{
			if (hardwareJoystickMap == null)
			{
				return null;
			}
			Platform platform = MiscTools.DeepClone(this);
			string controllerName = platform.controllerNameOverride;
			if (string.IsNullOrEmpty(controllerName))
			{
				controllerName = hardwareJoystickMap.controllerName;
			}
			List<Guid> list = new List<Guid>();
			hardwareJoystickMap.GetTemplateGuids(list);
			DeviceLocalizationInfo deviceLocalizationInfo = new DeviceLocalizationInfo(ControllerType.Joystick, false, hardwareJoystickMap.Guid, new List<string> { hardwareJoystickMap.Key }, list);
			HardwareJoystickMap_InputManager hardwareJoystickMap_InputManager = new HardwareJoystickMap_InputManager(new HardwareControllerMapIdentifier(hardwareJoystickMap.Guid, inputSource, actualInputPlatform, variantIndex), hardwareJoystickMap.joystickTypes, deviceLocalizationInfo, platform, controllerName, platform.assignedButtonCount, platform.assignedAxisCount, hardwareJoystickMap.elementIdentifiers.Length, hardwareJoystickMap.compoundElements);
			ControllerElementIdentifier[] elementIdentifiers = hardwareJoystickMap.elementIdentifiers;
			int elementIdentifierCount = hardwareJoystickMap.elementIdentifierCount;
			for (int i = 0; i < elementIdentifierCount; i++)
			{
				hardwareJoystickMap_InputManager.elementIdentifiers[i] = new ControllerElementIdentifier(elementIdentifiers[i], hardwareJoystickMap_InputManager.map.IsElementIdentifierMapped(elementIdentifiers[i].get_id()), hardwareJoystickMap_InputManager.map.GetEffectiveElementIdentifierType(elementIdentifiers[i]));
			}
			if (inputSource == InputSource.PS4 && (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyDualShock4 || hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4AimController))
			{
				for (int j = 0; j < elementIdentifierCount; j++)
				{
					switch (elementIdentifiers[j].get_id())
					{
					case 0:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("left stick x");
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_positiveName("left stick right");
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_negativeName("left stick left");
						break;
					case 1:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("left stick y");
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_positiveName("left stick up");
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_negativeName("left stick down");
						break;
					case 2:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("right stick x");
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_positiveName("right stick right");
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_negativeName("right stick left");
						break;
					case 3:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("right stick y");
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_positiveName("right stick up");
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_negativeName("right stick down");
						break;
					case 4:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("L2 button");
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_positiveName("L2 button");
						break;
					case 5:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("R2 button");
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_positiveName("R2 button");
						break;
					case 6:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("cross button");
						break;
					case 7:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("circle button");
						break;
					case 8:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("square button");
						break;
					case 9:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("triangle button");
						break;
					case 10:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("L1 button");
						break;
					case 11:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("R1 button");
						break;
					case 12:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("SHARE button");
						break;
					case 13:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("OPTIONS button");
						break;
					case 14:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("PS button");
						break;
					case 15:
						if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4AimController)
						{
							hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("pad button");
						}
						else
						{
							hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("touch pad button");
						}
						break;
					case 16:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("L3 button");
						break;
					case 17:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("R3 button");
						break;
					case 18:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("up button");
						break;
					case 19:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("right button");
						break;
					case 20:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("down button");
						break;
					case 21:
						hardwareJoystickMap_InputManager.elementIdentifiers[j].set_name("left button");
						break;
					}
				}
			}
			if (inputSource == InputSource.PS5)
			{
				if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyDualSense)
				{
					for (int k = 0; k < elementIdentifierCount; k++)
					{
						switch (elementIdentifiers[k].get_id())
						{
						case 0:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("left stick x");
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_positiveName("left stick right");
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_negativeName("left stick left");
							break;
						case 1:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("left stick y");
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_positiveName("left stick up");
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_negativeName("left stick down");
							break;
						case 2:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("right stick x");
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_positiveName("right stick right");
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_negativeName("right stick left");
							break;
						case 3:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("right stick y");
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_positiveName("right stick up");
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_negativeName("right stick down");
							break;
						case 4:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("L2 button");
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_positiveName("L2 button");
							break;
						case 5:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("R2 button");
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_positiveName("R2 button");
							break;
						case 6:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("cross button");
							break;
						case 7:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("circle button");
							break;
						case 8:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("square button");
							break;
						case 9:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("triangle button");
							break;
						case 10:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("L1 button");
							break;
						case 11:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("R1 button");
							break;
						case 12:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("create button");
							break;
						case 13:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("options button");
							break;
						case 14:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("PS button");
							break;
						case 15:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("touch pad button");
							break;
						case 16:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("L3 button");
							break;
						case 17:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("R3 button");
							break;
						case 18:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("up button");
							break;
						case 19:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("right button");
							break;
						case 20:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("down button");
							break;
						case 21:
							hardwareJoystickMap_InputManager.elementIdentifiers[k].set_name("left button");
							break;
						}
					}
				}
				else if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4Drums || hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4Guitar || hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4SteeringWheel)
				{
					for (int l = 0; l < elementIdentifierCount; l++)
					{
						switch (elementIdentifiers[l].get_id())
						{
						case 19:
							hardwareJoystickMap_InputManager.elementIdentifiers[l].set_name("create button");
							break;
						case 20:
							hardwareJoystickMap_InputManager.elementIdentifiers[l].set_name("options button");
							break;
						}
					}
				}
				else if (hardwareJoystickMap.Guid == Consts.joystickGuid_SonyPS4FlightStick)
				{
					for (int m = 0; m < elementIdentifierCount; m++)
					{
						switch (elementIdentifiers[m].get_id())
						{
						case 21:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].set_name("create button");
							break;
						case 22:
							hardwareJoystickMap_InputManager.elementIdentifiers[m].set_name("options button");
							break;
						}
					}
				}
			}
			return hardwareJoystickMap_InputManager;
		}

		public abstract object DeepClone();

		internal abstract void CopyVars(Platform destination);
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public abstract class Elements_Base : IDeepCloneable
	{
		public abstract int buttonCount { get; }

		public abstract int axisCount { get; }

		internal virtual void CopyVars(Elements_Base destination)
		{
		}

		internal abstract ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier);

		internal abstract bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange);

		public abstract object DeepClone();
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public abstract class MatchingCriteria_Base : IDeepCloneable
	{
		[Serializable]
		public class ElementCount_Base : IDeepCloneable
		{
			public int axisCount;

			public int buttonCount;

			public virtual object DeepClone()
			{
				ElementCount_Base elementCount_Base = new ElementCount_Base();
				DHyZsEQjfQXqCiERWSJlkrWZAVDE(elementCount_Base);
				return elementCount_Base;
			}

			object IDeepCloneable.DeepClone()
			{
				//ILSpy generated this explicit interface implementation from .override directive in DeepClone
				return this.DeepClone();
			}

			internal virtual void DHyZsEQjfQXqCiERWSJlkrWZAVDE(ElementCount_Base P_0)
			{
				if (P_0 != null)
				{
					P_0.axisCount = axisCount;
					P_0.buttonCount = buttonCount;
				}
			}

			internal virtual bool cubDYXAvXKoMbRtseYFVkoMtvxhf(BridgedControllerHWInfo P_0)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (axisCount < 0 || axisCount == P_0.hardwareAxisCount)
				{
					if (buttonCount >= 0)
					{
						return buttonCount == P_0.hardwareButtonCount;
					}
					return true;
				}
				return false;
			}
		}

		[Tooltip("The number of axes reported by the controller. If the value reported by the controller differs from this value, the controller is not a match. [-1 to match to any number of axes]")]
		public int axisCount;

		[Tooltip("The number of buttons reported by the controller. If the value reported by the controller differs from this value, the controller is not a match. [-1 to match to any number of buttons]")]
		public int buttonCount;

		[Tooltip("If checked, this entire platform map will be skipped and will not match to any controller.")]
		public bool disabled;

		[Tooltip("User-defined string. May have functionality on some input sources but not on others.")]
		public string tag;

		internal abstract bool hasData { get; }

		internal virtual bool isAllowed
		{
			get
			{
				if (disabled)
				{
					return false;
				}
				return true;
			}
		}

		internal abstract int alternateElementCount { get; }

		internal virtual bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch)
		{
			if (disabled)
			{
				return false;
			}
			if (!isAllowed)
			{
				return false;
			}
			if (!ElementCountsMatch(BridgedControllerHWInfo, out var _))
			{
				return false;
			}
			if (!string.IsNullOrEmpty(BridgedControllerHWInfo.definitionMatchTag) && !BridgedControllerHWInfo.definitionMatchTag.Equals(tag, StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			return true;
		}

		internal abstract ElementCount_Base GetAlternateElementCount(int index);

		internal virtual bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
		{
			alternateMatched = false;
			if (bridgedControllerHWInfo == null)
			{
				return false;
			}
			int num = alternateElementCount;
			for (int i = 0; i < num; i++)
			{
				ElementCount_Base elementCount_Base = GetAlternateElementCount(i);
				if (elementCount_Base != null && elementCount_Base.cubDYXAvXKoMbRtseYFVkoMtvxhf(bridgedControllerHWInfo))
				{
					alternateMatched = true;
					return true;
				}
			}
			if (axisCount < 0 || axisCount == bridgedControllerHWInfo.hardwareAxisCount)
			{
				if (buttonCount >= 0)
				{
					return buttonCount == bridgedControllerHWInfo.hardwareButtonCount;
				}
				return true;
			}
			return false;
		}

		internal virtual void CopyVars(MatchingCriteria_Base destination)
		{
			destination.axisCount = axisCount;
			destination.buttonCount = buttonCount;
			destination.disabled = disabled;
			destination.tag = tag;
		}

		internal static bool StringMatches(string searchIn, string searchFor, bool useRegex)
		{
			if (searchIn == null)
			{
				searchIn = string.Empty;
			}
			if (searchFor == null)
			{
				searchFor = string.Empty;
			}
			if (useRegex)
			{
				return Regex.IsMatch(searchIn, searchFor, RegexOptions.IgnoreCase);
			}
			return searchFor.Trim().Equals(searchIn.Trim(), StringComparison.OrdinalIgnoreCase);
		}

		public abstract object DeepClone();
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class CompoundElement : IDeepCloneable
	{
		public CompoundControllerElementType type;

		public int elementIdentifier = -1;

		public int[] componentElementIdentifiers = new int[0];

		public int elementCount
		{
			get
			{
				if (componentElementIdentifiers == null)
				{
					return 0;
				}
				return componentElementIdentifiers.Length;
			}
		}

		public CompoundElement()
		{
			if (componentElementIdentifiers == null)
			{
				componentElementIdentifiers = new int[0];
			}
		}

		public CompoundElement(CompoundElement P_0)
		{
			ImportVars(P_0);
		}

		public int GetComponentElementIdentifierId(int index)
		{
			if (index < 0 || index >= elementCount)
			{
				return -1;
			}
			return componentElementIdentifiers[index];
		}

		public virtual object DeepClone()
		{
			return new CompoundElement(this);
		}

		object IDeepCloneable.DeepClone()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DeepClone
			return this.DeepClone();
		}

		protected virtual void ImportVars(CompoundElement source)
		{
			type = source.type;
			elementIdentifier = source.elementIdentifier;
			componentElementIdentifiers = ArrayTools.ShallowCopy(source.componentElementIdentifiers);
		}

		internal static void SortHatElementsClockwise(CompoundElement element)
		{
			if (element != null && element.type == CompoundControllerElementType.Hat && element.componentElementIdentifiers != null && element.componentElementIdentifiers.Length == 8)
			{
				int[] array = new int[8]
				{
					element.componentElementIdentifiers[0],
					element.componentElementIdentifiers[4],
					element.componentElementIdentifiers[1],
					element.componentElementIdentifiers[5],
					element.componentElementIdentifiers[2],
					element.componentElementIdentifiers[6],
					element.componentElementIdentifiers[3],
					element.componentElementIdentifiers[7]
				};
				Array.Copy(array, element.componentElementIdentifiers, array.Length);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class VidPid
	{
		public int vendorId;

		public int productId;
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class AxisCalibrationInfoEntry : IDeepCloneable
	{
		[SerializeField]
		internal AlternateAxisCalibrationType key;

		[SerializeField]
		internal AxisCalibrationInfo calibration;

		public AxisCalibrationInfoEntry(AxisCalibrationInfoEntry P_0)
		{
			ImportVars(P_0);
		}

		public virtual object DeepClone()
		{
			return new AxisCalibrationInfoEntry(this);
		}

		object IDeepCloneable.DeepClone()
		{
			//ILSpy generated this explicit interface implementation from .override directive in DeepClone
			return this.DeepClone();
		}

		protected virtual void ImportVars(AxisCalibrationInfoEntry source)
		{
			key = source.key;
			calibration = MiscTools.DeepClone(source.calibration);
		}

		public static Dictionary<int, AxisCalibrationInfo> ToDictionary(AxisCalibrationInfoEntry[] calibrations, bool deepClone)
		{
			if (calibrations == null)
			{
				return new Dictionary<int, AxisCalibrationInfo>();
			}
			Dictionary<int, AxisCalibrationInfo> dictionary = new Dictionary<int, AxisCalibrationInfo>();
			foreach (AxisCalibrationInfoEntry axisCalibrationInfoEntry in calibrations)
			{
				if (axisCalibrationInfoEntry != null && axisCalibrationInfoEntry.calibration != null && Enum.IsDefined(typeof(AlternateAxisCalibrationType), axisCalibrationInfoEntry.key))
				{
					if (dictionary.ContainsKey((int)axisCalibrationInfoEntry.key))
					{
						Logger.LogError("A duplicate key was found in AxisCalibrationInfoEntry array in HardwareJoystickMap. Skipping.");
					}
					else if (deepClone)
					{
						dictionary.Add((int)axisCalibrationInfoEntry.key, (AxisCalibrationInfo)axisCalibrationInfoEntry.calibration.DeepClone());
					}
					else
					{
						dictionary.Add((int)axisCalibrationInfoEntry.key, axisCalibrationInfoEntry.calibration);
					}
				}
			}
			return dictionary;
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public abstract class Platform_RawOrDirectInput : Platform
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class MatchingCriteria : MatchingCriteria_Base
		{
			[Serializable]
			public sealed class ElementCount : ElementCount_Base
			{
				public int hatCount;

				public override object DeepClone()
				{
					ElementCount elementCount = new ElementCount();
					DHyZsEQjfQXqCiERWSJlkrWZAVDE(elementCount);
					return elementCount;
				}

				internal void RGXVJgBGfKQRrcKTiQkmFnamXGbW(ElementCount_Base P_0)
				{
					base.DHyZsEQjfQXqCiERWSJlkrWZAVDE(P_0);
					if (P_0 is ElementCount elementCount)
					{
						elementCount.hatCount = hatCount;
					}
				}

				internal bool oRhPuiFJVoEluHVwnHAyZetfjaEJ(BridgedControllerHWInfo P_0)
				{
					if (!base.cubDYXAvXKoMbRtseYFVkoMtvxhf(P_0))
					{
						return false;
					}
					if (hatCount >= 0)
					{
						return hatCount == P_0.hardwareHatCount;
					}
					return true;
				}
			}

			public int hatCount;

			public ElementCount[] alternateElementCounts;

			public bool productName_useRegex;

			public string[] productName;

			public string[] productGUID;

			public int[] productId;

			public DeviceType deviceType;

			bool MatchingCriteria_Base.hasData => get_hasData();

			bool MatchingCriteria_Base.isAllowed => get_isAllowed();

			int MatchingCriteria_Base.alternateElementCount => get_alternateElementCount();

			internal bool get_hasData()
			{
				if (disabled)
				{
					return false;
				}
				if (productGUID != null && productGUID.Length != 0)
				{
					return true;
				}
				if (productName != null && productName.Length != 0)
				{
					return true;
				}
				return false;
			}

			internal bool get_isAllowed()
			{
				if (!base.isAllowed)
				{
					return false;
				}
				return true;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
				{
					return true;
				}
				if (!base.Matches(bridgedControllerHWInfo, strictMatch))
				{
					return false;
				}
				if (strictMatch)
				{
					if (PidVid.ArrayContains(productGUID, ref bridgedControllerHWInfo.hw_pidVid))
					{
						if (!ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
						{
							return true;
						}
						if (productName == null || productName.Length == 0)
						{
							return true;
						}
						return ProductNameMatches(bridgedControllerHWInfo);
					}
					if (!ProductNameMatches(bridgedControllerHWInfo))
					{
						return false;
					}
					return true;
				}
				return ProductNameMatches(bridgedControllerHWInfo);
			}

			internal int get_alternateElementCount()
			{
				if (alternateElementCounts == null)
				{
					return 0;
				}
				return alternateElementCounts.Length;
			}

			internal override ElementCount_Base GetAlternateElementCount(int index)
			{
				if (alternateElementCounts == null || index < 0 || index >= alternateElementCounts.Length)
				{
					return null;
				}
				return alternateElementCounts[index];
			}

			internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
			{
				if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
				{
					return false;
				}
				if (alternateMatched)
				{
					return true;
				}
				if (hatCount >= 0)
				{
					return bridgedControllerHWInfo.hardwareHatCount == hatCount;
				}
				return true;
			}

			private bool ProductNameMatches(BridgedControllerHWInfo controller)
			{
				if (controller.hw_isBluetoothDevice && !string.IsNullOrEmpty(controller.hw_bluetoothDeviceName))
				{
					if (ProductNameMatches(controller.hw_productName) || ProductNameMatches(controller.hw_bluetoothDeviceName))
					{
						return true;
					}
					return false;
				}
				return ProductNameMatches(controller.hw_productName);
			}

			private bool ProductNameMatches(string name)
			{
				if (string.IsNullOrEmpty(name) || productName == null)
				{
					return false;
				}
				string searchIn = name.Trim();
				for (int i = 0; i < productName.Length; i++)
				{
					if (productName[i] != null && !(productName[i] == string.Empty) && MatchingCriteria_Base.StringMatches(searchIn, productName[i], productName_useRegex))
					{
						return true;
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			internal override void CopyVars(MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				if (destination is MatchingCriteria matchingCriteria)
				{
					matchingCriteria.hatCount = hatCount;
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
					matchingCriteria.productId = ArrayTools.ShallowCopy(productId);
					matchingCriteria.deviceType = deviceType;
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Elements_Platform_Base : Elements_Base
		{
			internal abstract IEnumerable<Axis_Base> Axes { get; }

			internal abstract IEnumerable<Button_Base> Buttons { get; }

			internal abstract Axis_Base GetAxis(int axisIndex);
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class CustomCalculationSourceData : IDeepCloneable
		{
			public int sourceType;

			public int sourceAxis;

			public int sourceButton;

			public int sourceOtherAxis;

			public AxisRange sourceAxisRange;

			public float axisDeadZone;

			public bool invert;

			public AxisCalibrationType axisCalibrationType;

			public float axisZero;

			public float axisMin;

			public float axisMax;

			public object DeepClone()
			{
				return new CustomCalculationSourceData
				{
					sourceType = sourceType,
					sourceAxis = sourceAxis,
					sourceButton = sourceButton,
					sourceOtherAxis = sourceOtherAxis,
					sourceAxisRange = sourceAxisRange,
					axisDeadZone = axisDeadZone,
					invert = invert,
					axisCalibrationType = axisCalibrationType,
					axisZero = axisZero,
					axisMin = axisMin,
					axisMax = axisMax
				};
			}

			object IDeepCloneable.DeepClone()
			{
				//ILSpy generated this explicit interface implementation from .override directive in DeepClone
				return this.DeepClone();
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Element : IDeepCloneable
		{
			public CustomCalculation customCalculation;

			public CustomCalculationSourceData[] customCalculationSourceData;

			public abstract object DeepClone();

			protected void ImportVars(Element source)
			{
				customCalculation = source.customCalculation;
				customCalculationSourceData = ArrayTools.DeepClone(source.customCalculationSourceData);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Button_Base : Element
		{
			public int elementIdentifier;

			public HardwareElementSourceTypeWithHat sourceType;

			public int sourceButton;

			public int sourceAxis;

			public Pole sourceAxisPole;

			public float axisDeadZone;

			public int sourceHat;

			public HatType sourceHatType;

			public HatDirection sourceHatDirection;

			public bool requireMultipleButtons;

			public int[] requiredButtons;

			public bool ignoreIfButtonsActive;

			public int[] ignoreIfButtonsActiveButtons;

			public HardwareButtonInfo buttonInfo;

			public Button_Base()
			{
				sourceType = HardwareElementSourceTypeWithHat.Button;
			}

			protected void ImportVars(Button_Base source)
			{
				ImportVars((Element)source);
				elementIdentifier = source.elementIdentifier;
				sourceType = source.sourceType;
				sourceButton = source.sourceButton;
				sourceAxis = source.sourceAxis;
				sourceAxisPole = source.sourceAxisPole;
				axisDeadZone = source.axisDeadZone;
				sourceHat = source.sourceHat;
				sourceHatType = source.sourceHatType;
				sourceHatDirection = source.sourceHatDirection;
				requireMultipleButtons = source.requireMultipleButtons;
				requiredButtons = ArrayTools.ShallowCopy(source.requiredButtons);
				ignoreIfButtonsActive = source.ignoreIfButtonsActive;
				ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(source.ignoreIfButtonsActiveButtons);
				buttonInfo = MiscTools.DeepClone(source.buttonInfo);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Axis_Base : Element
		{
			public int elementIdentifier;

			public HardwareElementSourceTypeWithHat sourceType;

			public int sourceAxis;

			public AxisRange sourceAxisRange;

			public bool invert;

			public float axisDeadZone;

			public bool calibrateAxis;

			public float axisZero;

			public float axisMin;

			public float axisMax;

			public HardwareAxisInfo axisInfo;

			public AxisCalibrationInfoEntry[] alternateCalibrations;

			public int sourceButton;

			public Pole buttonAxisContribution;

			public int sourceHat;

			public AxisDirection sourceHatDirection;

			public AxisRange sourceHatRange;

			public Axis_Base()
			{
				sourceType = HardwareElementSourceTypeWithHat.Axis;
			}

			protected void ImportVars(Axis_Base source)
			{
				ImportVars((Element)source);
				elementIdentifier = source.elementIdentifier;
				sourceType = source.sourceType;
				sourceAxis = source.sourceAxis;
				sourceAxisRange = source.sourceAxisRange;
				invert = source.invert;
				axisDeadZone = source.axisDeadZone;
				calibrateAxis = source.calibrateAxis;
				axisZero = source.axisZero;
				axisMin = source.axisMin;
				axisMax = source.axisMax;
				axisInfo = MiscTools.DeepClone(source.axisInfo);
				sourceButton = source.sourceButton;
				buttonAxisContribution = source.buttonAxisContribution;
				sourceHat = source.sourceHat;
				sourceHatDirection = source.sourceHatDirection;
				sourceHatRange = source.sourceHatRange;
				alternateCalibrations = MiscTools.DeepClone(source.alternateCalibrations);
			}
		}

		public enum DeviceType
		{
			Any = 0,
			Device = 17,
			Mouse = 18,
			Keyboard = 19,
			Joystick = 20,
			Gamepad = 21,
			Driving = 22,
			Flight = 23,
			FirstPerson = 24,
			ControlDevice = 25,
			ScreenPointer = 26,
			Remote = 27,
			Supplemental = 28
		}

		public MatchingCriteria matchingCriteria;

		bool Platform.hasData => get_hasData();

		bool Platform.disabled => get_disabled();

		bool Platform.isAllowed => get_isAllowed();

		internal virtual bool get_hasData()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			if (!matchingCriteria.hasData)
			{
				return false;
			}
			if (assignedAxisCount == 0 && assignedButtonCount == 0)
			{
				return false;
			}
			return true;
		}

		internal virtual bool get_disabled()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.disabled;
		}

		internal virtual bool get_isAllowed()
		{
			if (!base.isAllowed)
			{
				return false;
			}
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.isAllowed;
		}

		internal abstract IEnumerable<Axis_Base> IterateAxes();

		internal abstract IEnumerable<Button_Base> IterateButtons();

		internal override void CopyVars(Platform destination)
		{
			if (destination is Platform_RawOrDirectInput platform_RawOrDirectInput)
			{
				platform_RawOrDirectInput.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class Platform_DirectInput_Base : Platform_RawOrDirectInput
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Elements : Elements_Platform_Base
		{
			private sealed class VtyaSYtzVPAqWeqZSYJCzoDMPjTf : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int ABNAbfuOrxPBOwdnavWOYZrYiICQ;

				private Axis_Base wcUcdbeBAxREoBXTVgbRIRLKdPLbA;

				private int uIDHVEmZikohcFSJZfCmQzLRoBFF;

				public Elements EHVIxjUjywXMWlVANLjwSbGYqAtL;

				private int zYbFHBenqHsrffYbQkDmJleoEtwx;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return wcUcdbeBAxREoBXTVgbRIRLKdPLbA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return wcUcdbeBAxREoBXTVgbRIRLKdPLbA;
					}
				}

				[DebuggerHidden]
				public VtyaSYtzVPAqWeqZSYJCzoDMPjTf(int P_0)
				{
					ABNAbfuOrxPBOwdnavWOYZrYiICQ = P_0;
					uIDHVEmZikohcFSJZfCmQzLRoBFF = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int aBNAbfuOrxPBOwdnavWOYZrYiICQ = ABNAbfuOrxPBOwdnavWOYZrYiICQ;
					Elements eHVIxjUjywXMWlVANLjwSbGYqAtL = EHVIxjUjywXMWlVANLjwSbGYqAtL;
					switch (aBNAbfuOrxPBOwdnavWOYZrYiICQ)
					{
					default:
						return false;
					case 0:
						ABNAbfuOrxPBOwdnavWOYZrYiICQ = -1;
						if (eHVIxjUjywXMWlVANLjwSbGYqAtL.axes == null)
						{
							return false;
						}
						zYbFHBenqHsrffYbQkDmJleoEtwx = 0;
						break;
					case 1:
						ABNAbfuOrxPBOwdnavWOYZrYiICQ = -1;
						zYbFHBenqHsrffYbQkDmJleoEtwx++;
						break;
					}
					if (zYbFHBenqHsrffYbQkDmJleoEtwx < eHVIxjUjywXMWlVANLjwSbGYqAtL.axes.Length)
					{
						wcUcdbeBAxREoBXTVgbRIRLKdPLbA = eHVIxjUjywXMWlVANLjwSbGYqAtL.axes[zYbFHBenqHsrffYbQkDmJleoEtwx];
						ABNAbfuOrxPBOwdnavWOYZrYiICQ = 1;
						return true;
					}
					return false;
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
				IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
				{
					VtyaSYtzVPAqWeqZSYJCzoDMPjTf vtyaSYtzVPAqWeqZSYJCzoDMPjTf;
					if (ABNAbfuOrxPBOwdnavWOYZrYiICQ == -2 && uIDHVEmZikohcFSJZfCmQzLRoBFF == Environment.CurrentManagedThreadId)
					{
						ABNAbfuOrxPBOwdnavWOYZrYiICQ = 0;
						vtyaSYtzVPAqWeqZSYJCzoDMPjTf = this;
					}
					else
					{
						vtyaSYtzVPAqWeqZSYJCzoDMPjTf = new VtyaSYtzVPAqWeqZSYJCzoDMPjTf(0);
						vtyaSYtzVPAqWeqZSYJCzoDMPjTf.EHVIxjUjywXMWlVANLjwSbGYqAtL = EHVIxjUjywXMWlVANLjwSbGYqAtL;
					}
					return vtyaSYtzVPAqWeqZSYJCzoDMPjTf;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}
			}

			private sealed class MCADgtjvIxXAdNdyKmFAGGuemxwLB : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int IzThKQMIalAvlEZrUzNurSrRuTjuA;

				private Button_Base wVLwRzpwYvEuXcnewRuTSbVJENDD;

				private int sMxJfGDGADrDLyrIlCeETorbLCUM;

				public Elements EYDfXZKbWLEZONAtNnzjIpKUjeGU;

				private int kYBdXkVVROsYpgYXTHHhjXYRyjJg;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return wVLwRzpwYvEuXcnewRuTSbVJENDD;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return wVLwRzpwYvEuXcnewRuTSbVJENDD;
					}
				}

				[DebuggerHidden]
				public MCADgtjvIxXAdNdyKmFAGGuemxwLB(int P_0)
				{
					IzThKQMIalAvlEZrUzNurSrRuTjuA = P_0;
					sMxJfGDGADrDLyrIlCeETorbLCUM = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int izThKQMIalAvlEZrUzNurSrRuTjuA = IzThKQMIalAvlEZrUzNurSrRuTjuA;
					Elements eYDfXZKbWLEZONAtNnzjIpKUjeGU = EYDfXZKbWLEZONAtNnzjIpKUjeGU;
					switch (izThKQMIalAvlEZrUzNurSrRuTjuA)
					{
					default:
						return false;
					case 0:
						IzThKQMIalAvlEZrUzNurSrRuTjuA = -1;
						if (eYDfXZKbWLEZONAtNnzjIpKUjeGU.buttons == null)
						{
							return false;
						}
						kYBdXkVVROsYpgYXTHHhjXYRyjJg = 0;
						break;
					case 1:
						IzThKQMIalAvlEZrUzNurSrRuTjuA = -1;
						kYBdXkVVROsYpgYXTHHhjXYRyjJg++;
						break;
					}
					if (kYBdXkVVROsYpgYXTHHhjXYRyjJg < eYDfXZKbWLEZONAtNnzjIpKUjeGU.buttons.Length)
					{
						wVLwRzpwYvEuXcnewRuTSbVJENDD = eYDfXZKbWLEZONAtNnzjIpKUjeGU.buttons[kYBdXkVVROsYpgYXTHHhjXYRyjJg];
						IzThKQMIalAvlEZrUzNurSrRuTjuA = 1;
						return true;
					}
					return false;
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
				IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
				{
					MCADgtjvIxXAdNdyKmFAGGuemxwLB mCADgtjvIxXAdNdyKmFAGGuemxwLB;
					if (IzThKQMIalAvlEZrUzNurSrRuTjuA == -2 && sMxJfGDGADrDLyrIlCeETorbLCUM == Environment.CurrentManagedThreadId)
					{
						IzThKQMIalAvlEZrUzNurSrRuTjuA = 0;
						mCADgtjvIxXAdNdyKmFAGGuemxwLB = this;
					}
					else
					{
						mCADgtjvIxXAdNdyKmFAGGuemxwLB = new MCADgtjvIxXAdNdyKmFAGGuemxwLB(0);
						mCADgtjvIxXAdNdyKmFAGGuemxwLB.EYDfXZKbWLEZONAtNnzjIpKUjeGU = EYDfXZKbWLEZONAtNnzjIpKUjeGU;
					}
					return mCADgtjvIxXAdNdyKmFAGGuemxwLB;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button_Base>)this).GetEnumerator();
				}
			}

			public Axis[] axes;

			public Button[] buttons;

			int Elements_Base.buttonCount => get_buttonCount();

			int Elements_Base.axisCount => get_axisCount();

			IEnumerable<Axis_Base> Elements_Platform_Base.Axes
			{
				[IteratorStateMachine(typeof(VtyaSYtzVPAqWeqZSYJCzoDMPjTf))]
				get
				{
					return get_Axes();
				}
			}

			IEnumerable<Button_Base> Elements_Platform_Base.Buttons
			{
				[IteratorStateMachine(typeof(MCADgtjvIxXAdNdyKmFAGGuemxwLB))]
				get
				{
					return get_Buttons();
				}
			}

			public int get_buttonCount()
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}

			public int get_axisCount()
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}

			internal override Axis_Base GetAxis(int axisIndex)
			{
				if (axes == null || axisIndex < 0 || axisIndex >= axes.Length)
				{
					return null;
				}
				return axes[axisIndex];
			}

			[IteratorStateMachine(typeof(VtyaSYtzVPAqWeqZSYJCzoDMPjTf))]
			internal IEnumerable<Axis_Base> get_Axes()
			{
				return new VtyaSYtzVPAqWeqZSYJCzoDMPjTf(-2)
				{
					EHVIxjUjywXMWlVANLjwSbGYqAtL = this
				};
			}

			[IteratorStateMachine(typeof(MCADgtjvIxXAdNdyKmFAGGuemxwLB))]
			internal IEnumerable<Button_Base> get_Buttons()
			{
				return new MCADgtjvIxXAdNdyKmFAGGuemxwLB(-2)
				{
					EYDfXZKbWLEZONAtNnzjIpKUjeGU = this
				};
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Axis;
					}
				}
				for (int j = 0; j < buttonCount; j++)
				{
					if (buttons[j].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Button;
					}
				}
				return elementIdentifier.elementType;
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier != elementIdentifier.get_id())
					{
						continue;
					}
					switch (axes[i].sourceType)
					{
					case HardwareElementSourceTypeWithHat.Axis:
						axisRange = axes[i].sourceAxisRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					case HardwareElementSourceTypeWithHat.Button:
						axisRange = AxisRange.Positive;
						return true;
					case HardwareElementSourceTypeWithHat.Hat:
						axisRange = axes[i].sourceHatRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					default:
						throw new NotImplementedException();
					}
				}
				axisRange = AxisRange.Full;
				return false;
			}

			public override object DeepClone()
			{
				Elements elements = new Elements();
				CopyVars(elements);
				return elements;
			}

			internal override void CopyVars(Elements_Base destination)
			{
				base.CopyVars(destination);
				if (destination is Elements elements)
				{
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Button : Button_Base
		{
			public override object DeepClone()
			{
				Button button = new Button();
				button.ImportVars(this);
				return button;
			}

			private void ImportVars(Button source)
			{
				ImportVars((Button_Base)source);
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Axis : Axis_Base
		{
			public override object DeepClone()
			{
				Axis axis = new Axis();
				axis.ImportVars(this);
				return axis;
			}

			private void ImportVars(Axis source)
			{
				ImportVars((Axis_Base)source);
			}
		}

		private sealed class xgfoNMrlHfQYKWdhznIHffJUqcGP : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
		{
			private int lyIgPobfipsOdORYCCezQpBrePJbb;

			private Axis_Base BOHBHASCZeTnywxzcuJmJINqIcsI;

			private int spzzSXBhjvreUNZpjrKGgXEkKZnE;

			public Platform_DirectInput_Base UfuJIBqckTaWfArxgoEoCeHMXUYDA;

			private int RjQWLgUYAwhcjEsxWyhbFRlJVRKd;

			private int WIouZDqeYyQDmjQrnXwHUmqCTRCh;

			Axis_Base IEnumerator<Axis_Base>.Current
			{
				[DebuggerHidden]
				get
				{
					return BOHBHASCZeTnywxzcuJmJINqIcsI;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return BOHBHASCZeTnywxzcuJmJINqIcsI;
				}
			}

			[DebuggerHidden]
			public xgfoNMrlHfQYKWdhznIHffJUqcGP(int P_0)
			{
				lyIgPobfipsOdORYCCezQpBrePJbb = P_0;
				spzzSXBhjvreUNZpjrKGgXEkKZnE = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = lyIgPobfipsOdORYCCezQpBrePJbb;
				Platform_DirectInput_Base ufuJIBqckTaWfArxgoEoCeHMXUYDA = UfuJIBqckTaWfArxgoEoCeHMXUYDA;
				switch (num)
				{
				default:
					return false;
				case 0:
					lyIgPobfipsOdORYCCezQpBrePJbb = -1;
					if (ufuJIBqckTaWfArxgoEoCeHMXUYDA.elements == null || ufuJIBqckTaWfArxgoEoCeHMXUYDA.elements.axes == null)
					{
						return false;
					}
					RjQWLgUYAwhcjEsxWyhbFRlJVRKd = ufuJIBqckTaWfArxgoEoCeHMXUYDA.elements.axes.Length;
					WIouZDqeYyQDmjQrnXwHUmqCTRCh = 0;
					break;
				case 1:
					lyIgPobfipsOdORYCCezQpBrePJbb = -1;
					WIouZDqeYyQDmjQrnXwHUmqCTRCh++;
					break;
				}
				if (WIouZDqeYyQDmjQrnXwHUmqCTRCh < RjQWLgUYAwhcjEsxWyhbFRlJVRKd)
				{
					BOHBHASCZeTnywxzcuJmJINqIcsI = ufuJIBqckTaWfArxgoEoCeHMXUYDA.elements.axes[WIouZDqeYyQDmjQrnXwHUmqCTRCh];
					lyIgPobfipsOdORYCCezQpBrePJbb = 1;
					return true;
				}
				return false;
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
			IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
			{
				xgfoNMrlHfQYKWdhznIHffJUqcGP xgfoNMrlHfQYKWdhznIHffJUqcGP2;
				if (lyIgPobfipsOdORYCCezQpBrePJbb == -2 && spzzSXBhjvreUNZpjrKGgXEkKZnE == Environment.CurrentManagedThreadId)
				{
					lyIgPobfipsOdORYCCezQpBrePJbb = 0;
					xgfoNMrlHfQYKWdhznIHffJUqcGP2 = this;
				}
				else
				{
					xgfoNMrlHfQYKWdhznIHffJUqcGP2 = new xgfoNMrlHfQYKWdhznIHffJUqcGP(0);
					xgfoNMrlHfQYKWdhznIHffJUqcGP2.UfuJIBqckTaWfArxgoEoCeHMXUYDA = UfuJIBqckTaWfArxgoEoCeHMXUYDA;
				}
				return xgfoNMrlHfQYKWdhznIHffJUqcGP2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Axis_Base>)this).GetEnumerator();
			}
		}

		private sealed class QPGgbXjQkTQJmwkLcERBafoZJql : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
		{
			private int iGBnSCbKbBDdBzrqmbeazaHKBCUL;

			private Button_Base nVklwnCsAJIzaSFeYLSIqdRsARliA;

			private int qYHBQdMdEqKFcbyJuEiDjPaFtCMM;

			public Platform_DirectInput_Base SfpezHytgsFpgPGdXOOgxSFEuhGI;

			private int TfBzzMGVLPeqbJTwiIQlKsnFCKSt;

			private int NDQHSUDOpRYCKDTBRaMNapspQrzgA;

			Button_Base IEnumerator<Button_Base>.Current
			{
				[DebuggerHidden]
				get
				{
					return nVklwnCsAJIzaSFeYLSIqdRsARliA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return nVklwnCsAJIzaSFeYLSIqdRsARliA;
				}
			}

			[DebuggerHidden]
			public QPGgbXjQkTQJmwkLcERBafoZJql(int P_0)
			{
				iGBnSCbKbBDdBzrqmbeazaHKBCUL = P_0;
				qYHBQdMdEqKFcbyJuEiDjPaFtCMM = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = iGBnSCbKbBDdBzrqmbeazaHKBCUL;
				Platform_DirectInput_Base sfpezHytgsFpgPGdXOOgxSFEuhGI = SfpezHytgsFpgPGdXOOgxSFEuhGI;
				switch (num)
				{
				default:
					return false;
				case 0:
					iGBnSCbKbBDdBzrqmbeazaHKBCUL = -1;
					if (sfpezHytgsFpgPGdXOOgxSFEuhGI.elements == null || sfpezHytgsFpgPGdXOOgxSFEuhGI.elements.buttons == null)
					{
						return false;
					}
					TfBzzMGVLPeqbJTwiIQlKsnFCKSt = sfpezHytgsFpgPGdXOOgxSFEuhGI.elements.buttons.Length;
					NDQHSUDOpRYCKDTBRaMNapspQrzgA = 0;
					break;
				case 1:
					iGBnSCbKbBDdBzrqmbeazaHKBCUL = -1;
					NDQHSUDOpRYCKDTBRaMNapspQrzgA++;
					break;
				}
				if (NDQHSUDOpRYCKDTBRaMNapspQrzgA < TfBzzMGVLPeqbJTwiIQlKsnFCKSt)
				{
					nVklwnCsAJIzaSFeYLSIqdRsARliA = sfpezHytgsFpgPGdXOOgxSFEuhGI.elements.buttons[NDQHSUDOpRYCKDTBRaMNapspQrzgA];
					iGBnSCbKbBDdBzrqmbeazaHKBCUL = 1;
					return true;
				}
				return false;
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
			IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
			{
				QPGgbXjQkTQJmwkLcERBafoZJql qPGgbXjQkTQJmwkLcERBafoZJql;
				if (iGBnSCbKbBDdBzrqmbeazaHKBCUL == -2 && qYHBQdMdEqKFcbyJuEiDjPaFtCMM == Environment.CurrentManagedThreadId)
				{
					iGBnSCbKbBDdBzrqmbeazaHKBCUL = 0;
					qPGgbXjQkTQJmwkLcERBafoZJql = this;
				}
				else
				{
					qPGgbXjQkTQJmwkLcERBafoZJql = new QPGgbXjQkTQJmwkLcERBafoZJql(0);
					qPGgbXjQkTQJmwkLcERBafoZJql.SfpezHytgsFpgPGdXOOgxSFEuhGI = SfpezHytgsFpgPGdXOOgxSFEuhGI;
				}
				return qPGgbXjQkTQJmwkLcERBafoZJql;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Button_Base>)this).GetEnumerator();
			}
		}

		public Elements elements;

		InputPlatform Platform.platform => get_platform();

		internal Axis[] Axes_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.axes;
			}
		}

		internal Button[] Buttons_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.buttons;
			}
		}

		int Platform.assignedButtonCount => get_assignedButtonCount();

		int Platform.assignedAxisCount => get_assignedAxisCount();

		Elements_Base Platform.elements_base => get_elements_base();

		internal virtual InputPlatform get_platform()
		{
			return InputPlatform.WindowsDirectInput;
		}

		public override IList<Platform> GetVariants()
		{
			return null;
		}

		public virtual int get_assignedButtonCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.buttonCount;
		}

		public virtual int get_assignedAxisCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.axisCount;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			return false;
		}

		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			foreach (Axis item in IterateAxes())
			{
				if (item.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			foreach (Button item2 in IterateButtons())
			{
				if (item2.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[assignedButtonCount];
			axes = new int[assignedAxisCount];
			int num = 0;
			foreach (Button item in IterateButtons())
			{
				buttons[num] = item.elementIdentifier;
				num++;
			}
			num = 0;
			foreach (Axis item2 in IterateAxes())
			{
				axes[num] = item2.elementIdentifier;
				num++;
			}
		}

		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			Axis[] axes_orig = Axes_orig;
			if (axes_orig == null)
			{
				return null;
			}
			AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
				{
					array[i] = AxisCalibrationData.Default;
					array[i].invert = axes_orig[i].invert;
					array[i].deadZone = axes_orig[i].axisDeadZone;
					if (Axes_orig[i].calibrateAxis)
					{
						array[i].zero = axes_orig[i].axisZero;
						array[i].min = axes_orig[i].axisMin;
						array[i].max = axes_orig[i].axisMax;
					}
				}
				else
				{
					if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
					{
						throw new NotImplementedException();
					}
					array[i] = AxisCalibrationData.Default;
				}
				array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
			}
			return array;
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[Axes_orig.Length];
			for (int i = 0; i < Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
				if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
				{
					axisRanges[i] = Axes_orig[i].sourceAxisRange;
					continue;
				}
				if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
				{
					axisRanges[i] = AxisRange.Full;
					continue;
				}
				throw new Exception();
			}
		}

		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = null;
			if (Buttons_orig != null)
			{
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				for (int i = 0; i < Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
				}
			}
		}

		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (elements == null)
			{
				return ControllerElementType.Axis;
			}
			return elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		[IteratorStateMachine(typeof(xgfoNMrlHfQYKWdhznIHffJUqcGP))]
		internal override IEnumerable<Axis_Base> IterateAxes()
		{
			return new xgfoNMrlHfQYKWdhznIHffJUqcGP(-2)
			{
				UfuJIBqckTaWfArxgoEoCeHMXUYDA = this
			};
		}

		[IteratorStateMachine(typeof(QPGgbXjQkTQJmwkLcERBafoZJql))]
		internal override IEnumerable<Button_Base> IterateButtons()
		{
			return new QPGgbXjQkTQJmwkLcERBafoZJql(-2)
			{
				SfpezHytgsFpgPGdXOOgxSFEuhGI = this
			};
		}

		internal virtual Elements_Base get_elements_base()
		{
			return elements;
		}

		public override object DeepClone()
		{
			Platform_DirectInput_Base platform_DirectInput_Base = new Platform_DirectInput_Base();
			CopyVars(platform_DirectInput_Base);
			return platform_DirectInput_Base;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_DirectInput_Base platform_DirectInput_Base)
			{
				platform_DirectInput_Base.elements = MiscTools.DeepClone(elements);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Platform_DirectInput : Platform_DirectInput_Base
	{
		public Platform_DirectInput_Base[] variants;

		public override IList<Platform> GetVariants()
		{
			return variants;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return true;
			}
			if (base.hasVariants)
			{
				for (int i = 0; i < variants.Length; i++)
				{
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		public override object DeepClone()
		{
			Platform_DirectInput platform_DirectInput = new Platform_DirectInput();
			CopyVars(platform_DirectInput);
			return platform_DirectInput;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_DirectInput platform_DirectInput)
			{
				platform_DirectInput.variants = MiscTools.DeepClone(variants);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class Platform_RawInput_Base : Platform_RawOrDirectInput
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Elements : Elements_Platform_Base
		{
			private sealed class gttdBovssjGSlfvBxlGLPgPFqOohA : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
			{
				private int JwONQCnbilpHDfXLnswROYDvWAmI;

				private Axis_Base ItegpwkDHZDJeQIuWUHHziVoEAej;

				private int cwCeXiHbBGHMOitLDAVKYEnPcNBKc;

				public Elements UjuRoSmumANyzjiBAmxYIHqqjDWL;

				private int KiaQDzJjsEdayDLjfJuOqgKPHUnh;

				Axis_Base IEnumerator<Axis_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return ItegpwkDHZDJeQIuWUHHziVoEAej;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return ItegpwkDHZDJeQIuWUHHziVoEAej;
					}
				}

				[DebuggerHidden]
				public gttdBovssjGSlfvBxlGLPgPFqOohA(int P_0)
				{
					JwONQCnbilpHDfXLnswROYDvWAmI = P_0;
					cwCeXiHbBGHMOitLDAVKYEnPcNBKc = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int jwONQCnbilpHDfXLnswROYDvWAmI = JwONQCnbilpHDfXLnswROYDvWAmI;
					Elements ujuRoSmumANyzjiBAmxYIHqqjDWL = UjuRoSmumANyzjiBAmxYIHqqjDWL;
					switch (jwONQCnbilpHDfXLnswROYDvWAmI)
					{
					default:
						return false;
					case 0:
						JwONQCnbilpHDfXLnswROYDvWAmI = -1;
						if (ujuRoSmumANyzjiBAmxYIHqqjDWL.axes == null)
						{
							return false;
						}
						KiaQDzJjsEdayDLjfJuOqgKPHUnh = 0;
						break;
					case 1:
						JwONQCnbilpHDfXLnswROYDvWAmI = -1;
						KiaQDzJjsEdayDLjfJuOqgKPHUnh++;
						break;
					}
					if (KiaQDzJjsEdayDLjfJuOqgKPHUnh < ujuRoSmumANyzjiBAmxYIHqqjDWL.axes.Length)
					{
						ItegpwkDHZDJeQIuWUHHziVoEAej = ujuRoSmumANyzjiBAmxYIHqqjDWL.axes[KiaQDzJjsEdayDLjfJuOqgKPHUnh];
						JwONQCnbilpHDfXLnswROYDvWAmI = 1;
						return true;
					}
					return false;
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
				IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
				{
					gttdBovssjGSlfvBxlGLPgPFqOohA gttdBovssjGSlfvBxlGLPgPFqOohA2;
					if (JwONQCnbilpHDfXLnswROYDvWAmI == -2 && cwCeXiHbBGHMOitLDAVKYEnPcNBKc == Environment.CurrentManagedThreadId)
					{
						JwONQCnbilpHDfXLnswROYDvWAmI = 0;
						gttdBovssjGSlfvBxlGLPgPFqOohA2 = this;
					}
					else
					{
						gttdBovssjGSlfvBxlGLPgPFqOohA2 = new gttdBovssjGSlfvBxlGLPgPFqOohA(0);
						gttdBovssjGSlfvBxlGLPgPFqOohA2.UjuRoSmumANyzjiBAmxYIHqqjDWL = UjuRoSmumANyzjiBAmxYIHqqjDWL;
					}
					return gttdBovssjGSlfvBxlGLPgPFqOohA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis_Base>)this).GetEnumerator();
				}
			}

			private sealed class RwNDQHdAkyaRTnKvroQLGnqFsmbAB : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
			{
				private int AGPBYRleIqFQBHrGrAaXlpTDosAf;

				private Button_Base iaLjKDGWTALYmfZGblIACLtXAubh;

				private int nHRGOUQIkEUKAzBeixnZTctuDhreA;

				public Elements rKJTGVKYHxsbGdrZKqZFWkExSMsP;

				private int DPeRrUtOUzyKMZOMYqzSZHOmkMQQ;

				Button_Base IEnumerator<Button_Base>.Current
				{
					[DebuggerHidden]
					get
					{
						return iaLjKDGWTALYmfZGblIACLtXAubh;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return iaLjKDGWTALYmfZGblIACLtXAubh;
					}
				}

				[DebuggerHidden]
				public RwNDQHdAkyaRTnKvroQLGnqFsmbAB(int P_0)
				{
					AGPBYRleIqFQBHrGrAaXlpTDosAf = P_0;
					nHRGOUQIkEUKAzBeixnZTctuDhreA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int aGPBYRleIqFQBHrGrAaXlpTDosAf = AGPBYRleIqFQBHrGrAaXlpTDosAf;
					Elements elements = rKJTGVKYHxsbGdrZKqZFWkExSMsP;
					switch (aGPBYRleIqFQBHrGrAaXlpTDosAf)
					{
					default:
						return false;
					case 0:
						AGPBYRleIqFQBHrGrAaXlpTDosAf = -1;
						if (elements.buttons == null)
						{
							return false;
						}
						DPeRrUtOUzyKMZOMYqzSZHOmkMQQ = 0;
						break;
					case 1:
						AGPBYRleIqFQBHrGrAaXlpTDosAf = -1;
						DPeRrUtOUzyKMZOMYqzSZHOmkMQQ++;
						break;
					}
					if (DPeRrUtOUzyKMZOMYqzSZHOmkMQQ < elements.buttons.Length)
					{
						iaLjKDGWTALYmfZGblIACLtXAubh = elements.buttons[DPeRrUtOUzyKMZOMYqzSZHOmkMQQ];
						AGPBYRleIqFQBHrGrAaXlpTDosAf = 1;
						return true;
					}
					return false;
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
				IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
				{
					RwNDQHdAkyaRTnKvroQLGnqFsmbAB rwNDQHdAkyaRTnKvroQLGnqFsmbAB;
					if (AGPBYRleIqFQBHrGrAaXlpTDosAf == -2 && nHRGOUQIkEUKAzBeixnZTctuDhreA == Environment.CurrentManagedThreadId)
					{
						AGPBYRleIqFQBHrGrAaXlpTDosAf = 0;
						rwNDQHdAkyaRTnKvroQLGnqFsmbAB = this;
					}
					else
					{
						rwNDQHdAkyaRTnKvroQLGnqFsmbAB = new RwNDQHdAkyaRTnKvroQLGnqFsmbAB(0);
						rwNDQHdAkyaRTnKvroQLGnqFsmbAB.rKJTGVKYHxsbGdrZKqZFWkExSMsP = rKJTGVKYHxsbGdrZKqZFWkExSMsP;
					}
					return rwNDQHdAkyaRTnKvroQLGnqFsmbAB;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button_Base>)this).GetEnumerator();
				}
			}

			public Axis[] axes;

			public Button[] buttons;

			int Elements_Base.buttonCount => get_buttonCount();

			int Elements_Base.axisCount => get_axisCount();

			IEnumerable<Axis_Base> Elements_Platform_Base.Axes
			{
				[IteratorStateMachine(typeof(gttdBovssjGSlfvBxlGLPgPFqOohA))]
				get
				{
					return get_Axes();
				}
			}

			IEnumerable<Button_Base> Elements_Platform_Base.Buttons
			{
				[IteratorStateMachine(typeof(RwNDQHdAkyaRTnKvroQLGnqFsmbAB))]
				get
				{
					return get_Buttons();
				}
			}

			public int get_buttonCount()
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}

			public int get_axisCount()
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}

			internal override Axis_Base GetAxis(int axisIndex)
			{
				if (axes == null || axisIndex < 0 || axisIndex >= axes.Length)
				{
					return null;
				}
				return axes[axisIndex];
			}

			[IteratorStateMachine(typeof(gttdBovssjGSlfvBxlGLPgPFqOohA))]
			internal IEnumerable<Axis_Base> get_Axes()
			{
				return new gttdBovssjGSlfvBxlGLPgPFqOohA(-2)
				{
					UjuRoSmumANyzjiBAmxYIHqqjDWL = this
				};
			}

			[IteratorStateMachine(typeof(RwNDQHdAkyaRTnKvroQLGnqFsmbAB))]
			internal IEnumerable<Button_Base> get_Buttons()
			{
				return new RwNDQHdAkyaRTnKvroQLGnqFsmbAB(-2)
				{
					rKJTGVKYHxsbGdrZKqZFWkExSMsP = this
				};
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Axis;
					}
				}
				for (int j = 0; j < buttonCount; j++)
				{
					if (buttons[j].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Button;
					}
				}
				return elementIdentifier.elementType;
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier != elementIdentifier.get_id())
					{
						continue;
					}
					switch (axes[i].sourceType)
					{
					case HardwareElementSourceTypeWithHat.Axis:
					case HardwareElementSourceTypeWithHat.Custom:
						axisRange = axes[i].sourceAxisRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					case HardwareElementSourceTypeWithHat.Button:
						axisRange = AxisRange.Positive;
						return true;
					case HardwareElementSourceTypeWithHat.Hat:
						axisRange = axes[i].sourceHatRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					default:
						throw new NotImplementedException();
					}
				}
				axisRange = AxisRange.Full;
				return false;
			}

			public override object DeepClone()
			{
				Elements elements = new Elements();
				CopyVars(elements);
				return elements;
			}

			internal override void CopyVars(Elements_Base destination)
			{
				base.CopyVars(destination);
				if (destination is Elements elements)
				{
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Button : Button_Base
		{
			public int sourceOtherAxis;

			public override object DeepClone()
			{
				Button button = new Button();
				button.ImportVars(this);
				return button;
			}

			private void ImportVars(Button source)
			{
				ImportVars((Button_Base)source);
				sourceOtherAxis = source.sourceOtherAxis;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Axis : Axis_Base
		{
			public int sourceOtherAxis;

			public override object DeepClone()
			{
				Axis axis = new Axis();
				axis.ImportVars(this);
				return axis;
			}

			private void ImportVars(Axis source)
			{
				ImportVars((Axis_Base)source);
				sourceOtherAxis = source.sourceOtherAxis;
			}
		}

		private sealed class svoMMbaKyHFThOjmbkXVLQBhCbAo : IEnumerable<Axis_Base>, IEnumerable, IEnumerator<Axis_Base>, IEnumerator, IDisposable
		{
			private int qfwnglVbZvEVetimlirSIhBQgHNhb;

			private Axis_Base gnBTbzemqYvaLoeHoHIxhUNAcOICb;

			private int eGUyKTNPnGFwSBcRVLKXuqhQMfdj;

			public Platform_RawInput_Base oIUJiJwRMRmcNaELVhodgdjXqNHJA;

			private int hSScwkRaDbdnffksCEEexfGrmTVkA;

			private int NJKZoQjxsuAvyfWWFdDrtqmFOgml;

			Axis_Base IEnumerator<Axis_Base>.Current
			{
				[DebuggerHidden]
				get
				{
					return gnBTbzemqYvaLoeHoHIxhUNAcOICb;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return gnBTbzemqYvaLoeHoHIxhUNAcOICb;
				}
			}

			[DebuggerHidden]
			public svoMMbaKyHFThOjmbkXVLQBhCbAo(int P_0)
			{
				qfwnglVbZvEVetimlirSIhBQgHNhb = P_0;
				eGUyKTNPnGFwSBcRVLKXuqhQMfdj = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = qfwnglVbZvEVetimlirSIhBQgHNhb;
				Platform_RawInput_Base platform_RawInput_Base = oIUJiJwRMRmcNaELVhodgdjXqNHJA;
				switch (num)
				{
				default:
					return false;
				case 0:
					qfwnglVbZvEVetimlirSIhBQgHNhb = -1;
					if (platform_RawInput_Base.elements == null || platform_RawInput_Base.elements.axes == null)
					{
						return false;
					}
					hSScwkRaDbdnffksCEEexfGrmTVkA = platform_RawInput_Base.elements.axes.Length;
					NJKZoQjxsuAvyfWWFdDrtqmFOgml = 0;
					break;
				case 1:
					qfwnglVbZvEVetimlirSIhBQgHNhb = -1;
					NJKZoQjxsuAvyfWWFdDrtqmFOgml++;
					break;
				}
				if (NJKZoQjxsuAvyfWWFdDrtqmFOgml < hSScwkRaDbdnffksCEEexfGrmTVkA)
				{
					gnBTbzemqYvaLoeHoHIxhUNAcOICb = platform_RawInput_Base.elements.axes[NJKZoQjxsuAvyfWWFdDrtqmFOgml];
					qfwnglVbZvEVetimlirSIhBQgHNhb = 1;
					return true;
				}
				return false;
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
			IEnumerator<Axis_Base> IEnumerable<Axis_Base>.GetEnumerator()
			{
				svoMMbaKyHFThOjmbkXVLQBhCbAo svoMMbaKyHFThOjmbkXVLQBhCbAo2;
				if (qfwnglVbZvEVetimlirSIhBQgHNhb == -2 && eGUyKTNPnGFwSBcRVLKXuqhQMfdj == Environment.CurrentManagedThreadId)
				{
					qfwnglVbZvEVetimlirSIhBQgHNhb = 0;
					svoMMbaKyHFThOjmbkXVLQBhCbAo2 = this;
				}
				else
				{
					svoMMbaKyHFThOjmbkXVLQBhCbAo2 = new svoMMbaKyHFThOjmbkXVLQBhCbAo(0);
					svoMMbaKyHFThOjmbkXVLQBhCbAo2.oIUJiJwRMRmcNaELVhodgdjXqNHJA = oIUJiJwRMRmcNaELVhodgdjXqNHJA;
				}
				return svoMMbaKyHFThOjmbkXVLQBhCbAo2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Axis_Base>)this).GetEnumerator();
			}
		}

		private sealed class aSkngsTEvlSzBPjWMXcZMpyTbDkG : IEnumerable<Button_Base>, IEnumerable, IEnumerator<Button_Base>, IEnumerator, IDisposable
		{
			private int IiJtTWYhFHgGvkQehgnQIrVdHCfec;

			private Button_Base yFvXjFovvdEhndDrwdFxnNbJyjMH;

			private int BZadWcHqElulOLOnVTHAUhTurtnaA;

			public Platform_RawInput_Base ERXWsyXJRvnNfcphrKhXZtBePsYT;

			private int pOcunzJNJjHEZrdbbCNNRfAjwzbm;

			private int rzhFDblGyMdklmIDAkDryHSoMPzQ;

			Button_Base IEnumerator<Button_Base>.Current
			{
				[DebuggerHidden]
				get
				{
					return yFvXjFovvdEhndDrwdFxnNbJyjMH;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return yFvXjFovvdEhndDrwdFxnNbJyjMH;
				}
			}

			[DebuggerHidden]
			public aSkngsTEvlSzBPjWMXcZMpyTbDkG(int P_0)
			{
				IiJtTWYhFHgGvkQehgnQIrVdHCfec = P_0;
				BZadWcHqElulOLOnVTHAUhTurtnaA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int iiJtTWYhFHgGvkQehgnQIrVdHCfec = IiJtTWYhFHgGvkQehgnQIrVdHCfec;
				Platform_RawInput_Base eRXWsyXJRvnNfcphrKhXZtBePsYT = ERXWsyXJRvnNfcphrKhXZtBePsYT;
				switch (iiJtTWYhFHgGvkQehgnQIrVdHCfec)
				{
				default:
					return false;
				case 0:
					IiJtTWYhFHgGvkQehgnQIrVdHCfec = -1;
					if (eRXWsyXJRvnNfcphrKhXZtBePsYT.elements == null || eRXWsyXJRvnNfcphrKhXZtBePsYT.elements.buttons == null)
					{
						return false;
					}
					pOcunzJNJjHEZrdbbCNNRfAjwzbm = eRXWsyXJRvnNfcphrKhXZtBePsYT.elements.buttons.Length;
					rzhFDblGyMdklmIDAkDryHSoMPzQ = 0;
					break;
				case 1:
					IiJtTWYhFHgGvkQehgnQIrVdHCfec = -1;
					rzhFDblGyMdklmIDAkDryHSoMPzQ++;
					break;
				}
				if (rzhFDblGyMdklmIDAkDryHSoMPzQ < pOcunzJNJjHEZrdbbCNNRfAjwzbm)
				{
					yFvXjFovvdEhndDrwdFxnNbJyjMH = eRXWsyXJRvnNfcphrKhXZtBePsYT.elements.buttons[rzhFDblGyMdklmIDAkDryHSoMPzQ];
					IiJtTWYhFHgGvkQehgnQIrVdHCfec = 1;
					return true;
				}
				return false;
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
			IEnumerator<Button_Base> IEnumerable<Button_Base>.GetEnumerator()
			{
				aSkngsTEvlSzBPjWMXcZMpyTbDkG aSkngsTEvlSzBPjWMXcZMpyTbDkG2;
				if (IiJtTWYhFHgGvkQehgnQIrVdHCfec == -2 && BZadWcHqElulOLOnVTHAUhTurtnaA == Environment.CurrentManagedThreadId)
				{
					IiJtTWYhFHgGvkQehgnQIrVdHCfec = 0;
					aSkngsTEvlSzBPjWMXcZMpyTbDkG2 = this;
				}
				else
				{
					aSkngsTEvlSzBPjWMXcZMpyTbDkG2 = new aSkngsTEvlSzBPjWMXcZMpyTbDkG(0);
					aSkngsTEvlSzBPjWMXcZMpyTbDkG2.ERXWsyXJRvnNfcphrKhXZtBePsYT = ERXWsyXJRvnNfcphrKhXZtBePsYT;
				}
				return aSkngsTEvlSzBPjWMXcZMpyTbDkG2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Button_Base>)this).GetEnumerator();
			}
		}

		public Elements elements;

		InputPlatform Platform.platform => get_platform();

		internal Axis[] Axes_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.axes;
			}
		}

		internal Button[] Buttons_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.buttons;
			}
		}

		int Platform.assignedButtonCount => get_assignedButtonCount();

		int Platform.assignedAxisCount => get_assignedAxisCount();

		Elements_Base Platform.elements_base => get_elements_base();

		internal virtual InputPlatform get_platform()
		{
			return InputPlatform.WindowsRawInput;
		}

		public override IList<Platform> GetVariants()
		{
			return null;
		}

		public virtual int get_assignedButtonCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.buttonCount;
		}

		public virtual int get_assignedAxisCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.axisCount;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			return false;
		}

		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			foreach (Axis item in IterateAxes())
			{
				if (item.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			foreach (Button item2 in IterateButtons())
			{
				if (item2.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[assignedButtonCount];
			axes = new int[assignedAxisCount];
			int num = 0;
			foreach (Button item in IterateButtons())
			{
				buttons[num] = item.elementIdentifier;
				num++;
			}
			num = 0;
			foreach (Axis item2 in IterateAxes())
			{
				axes[num] = item2.elementIdentifier;
				num++;
			}
		}

		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			Axis[] axes_orig = Axes_orig;
			if (axes_orig == null)
			{
				return null;
			}
			AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
				{
					array[i] = AxisCalibrationData.Default;
					array[i].invert = axes_orig[i].invert;
					array[i].deadZone = axes_orig[i].axisDeadZone;
					if (Axes_orig[i].calibrateAxis)
					{
						array[i].zero = axes_orig[i].axisZero;
						array[i].min = axes_orig[i].axisMin;
						array[i].max = axes_orig[i].axisMax;
					}
				}
				else
				{
					if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
					{
						throw new NotImplementedException();
					}
					array[i] = AxisCalibrationData.Default;
				}
				array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
			}
			return array;
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[Axes_orig.Length];
			for (int i = 0; i < Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
				if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
				{
					axisRanges[i] = Axes_orig[i].sourceAxisRange;
					continue;
				}
				if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
				{
					axisRanges[i] = AxisRange.Full;
					continue;
				}
				throw new Exception();
			}
		}

		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = null;
			if (Buttons_orig != null)
			{
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				for (int i = 0; i < Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
				}
			}
		}

		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (elements == null)
			{
				return ControllerElementType.Axis;
			}
			return elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		[IteratorStateMachine(typeof(svoMMbaKyHFThOjmbkXVLQBhCbAo))]
		internal override IEnumerable<Axis_Base> IterateAxes()
		{
			return new svoMMbaKyHFThOjmbkXVLQBhCbAo(-2)
			{
				oIUJiJwRMRmcNaELVhodgdjXqNHJA = this
			};
		}

		[IteratorStateMachine(typeof(aSkngsTEvlSzBPjWMXcZMpyTbDkG))]
		internal override IEnumerable<Button_Base> IterateButtons()
		{
			return new aSkngsTEvlSzBPjWMXcZMpyTbDkG(-2)
			{
				ERXWsyXJRvnNfcphrKhXZtBePsYT = this
			};
		}

		internal virtual Elements_Base get_elements_base()
		{
			return elements;
		}

		public override object DeepClone()
		{
			Platform_RawInput_Base platform_RawInput_Base = new Platform_RawInput_Base();
			CopyVars(platform_RawInput_Base);
			return platform_RawInput_Base;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_RawInput_Base platform_RawInput_Base)
			{
				platform_RawInput_Base.elements = MiscTools.DeepClone(elements);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Platform_RawInput : Platform_RawInput_Base
	{
		public Platform_RawInput_Base[] variants;

		public override IList<Platform> GetVariants()
		{
			return variants;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return true;
			}
			if (base.hasVariants)
			{
				for (int i = 0; i < variants.Length; i++)
				{
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		public override object DeepClone()
		{
			Platform_RawInput platform_RawInput = new Platform_RawInput();
			CopyVars(platform_RawInput);
			return platform_RawInput;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_RawInput platform_RawInput)
			{
				platform_RawInput.variants = MiscTools.DeepClone(variants);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class Platform_XInput_Base : Platform
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class MatchingCriteria : MatchingCriteria_Base
		{
			public XInputDeviceSubType[] subType;

			bool MatchingCriteria_Base.hasData => get_hasData();

			bool MatchingCriteria_Base.isAllowed => get_isAllowed();

			int MatchingCriteria_Base.alternateElementCount => get_alternateElementCount();

			internal bool get_hasData()
			{
				if (disabled)
				{
					return false;
				}
				if (subType.Length == 0)
				{
					return false;
				}
				return true;
			}

			internal bool get_isAllowed()
			{
				if (!base.isAllowed)
				{
					return false;
				}
				return true;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (disabled)
				{
					return false;
				}
				if (!isAllowed)
				{
					return false;
				}
				if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
				{
					return true;
				}
				for (int i = 0; i < subType.Length; i++)
				{
					if (subType[i] == bridgedControllerHWInfo.hw_xInputSubType)
					{
						return true;
					}
				}
				return false;
			}

			internal int get_alternateElementCount()
			{
				return 0;
			}

			internal override ElementCount_Base GetAlternateElementCount(int index)
			{
				return null;
			}

			internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
			{
				return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched);
			}

			public override object DeepClone()
			{
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			internal override void CopyVars(MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				if (destination is MatchingCriteria matchingCriteria)
				{
					matchingCriteria.subType = ArrayTools.ShallowCopy(subType);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Elements : Elements_Base
		{
			public Axis[] axes;

			public Button[] buttons;

			int Elements_Base.buttonCount => get_buttonCount();

			int Elements_Base.axisCount => get_axisCount();

			public int get_buttonCount()
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}

			public int get_axisCount()
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}

			public override object DeepClone()
			{
				Elements elements = new Elements();
				CopyVars(elements);
				return elements;
			}

			internal override void CopyVars(Elements_Base destination)
			{
				base.CopyVars(destination);
				if (destination is Elements elements)
				{
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Axis;
					}
				}
				for (int j = 0; j < buttonCount; j++)
				{
					if (buttons[j].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Button;
					}
				}
				return elementIdentifier.elementType;
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier != elementIdentifier.get_id())
					{
						continue;
					}
					switch (axes[i].sourceType)
					{
					case HardwareElementSourceType.Axis:
					case HardwareElementSourceType.Custom:
						axisRange = axes[i].sourceAxisRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					case HardwareElementSourceType.Button:
						axisRange = AxisRange.Positive;
						return true;
					default:
						throw new NotImplementedException();
					}
				}
				axisRange = AxisRange.Full;
				return false;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Element : IDeepCloneable
		{
			public int elementIdentifier;

			public HardwareElementSourceType sourceType;

			public XInputButton sourceButton;

			public XInputAxis sourceAxis;

			public float axisDeadZone;

			public abstract object DeepClone();

			internal virtual void CopyVars(Element destination)
			{
				destination.elementIdentifier = elementIdentifier;
				destination.sourceType = sourceType;
				destination.sourceButton = sourceButton;
				destination.sourceAxis = sourceAxis;
				destination.axisDeadZone = axisDeadZone;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Button : Element
		{
			public Pole sourceAxisPole;

			public HardwareButtonInfo buttonInfo;

			public Button()
			{
				sourceType = HardwareElementSourceType.Button;
			}

			public override object DeepClone()
			{
				Button button = new Button();
				CopyVars(button);
				return button;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				if (destination is Button button)
				{
					button.sourceAxisPole = sourceAxisPole;
					button.buttonInfo = MiscTools.DeepClone(buttonInfo);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Axis : Element
		{
			public bool invert;

			public Pole buttonAxisContribution;

			public AxisRange sourceAxisRange;

			public bool calibrateAxis;

			public float axisZero;

			public float axisMin;

			public float axisMax;

			public AxisCalibrationInfoEntry[] alternateCalibrations;

			public HardwareAxisInfo axisInfo;

			public Axis()
			{
				sourceType = HardwareElementSourceType.Axis;
			}

			public override object DeepClone()
			{
				Axis axis = new Axis();
				CopyVars(axis);
				return axis;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				if (destination is Axis axis)
				{
					axis.invert = invert;
					axis.buttonAxisContribution = buttonAxisContribution;
					axis.sourceAxisRange = sourceAxisRange;
					axis.calibrateAxis = calibrateAxis;
					axis.axisZero = axisZero;
					axis.axisMin = axisMin;
					axis.axisMax = axisMax;
					axis.axisInfo = MiscTools.DeepClone(axisInfo);
					axis.alternateCalibrations = MiscTools.DeepClone(alternateCalibrations);
				}
			}
		}

		private sealed class RElEXCEQAMKNQNDDALVJwyfDCcWg : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
		{
			private int lrWbcOPhwDuoHUrxuqtTZNQvgQGz;

			private Axis jgiFebGPfGEDtYWBwygEsFvdbibV;

			private int CNzgjTkGToqHPHqPQEPWmySSInYgA;

			public Platform_XInput_Base ylnHwbGeJIUgONcNDTMVfkmwOSuK;

			private int OKEyfJUIcyKcWCTMTHFGXjBghPAf;

			Axis IEnumerator<Axis>.Current
			{
				[DebuggerHidden]
				get
				{
					return jgiFebGPfGEDtYWBwygEsFvdbibV;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return jgiFebGPfGEDtYWBwygEsFvdbibV;
				}
			}

			[DebuggerHidden]
			public RElEXCEQAMKNQNDDALVJwyfDCcWg(int P_0)
			{
				lrWbcOPhwDuoHUrxuqtTZNQvgQGz = P_0;
				CNzgjTkGToqHPHqPQEPWmySSInYgA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = lrWbcOPhwDuoHUrxuqtTZNQvgQGz;
				Platform_XInput_Base platform_XInput_Base = ylnHwbGeJIUgONcNDTMVfkmwOSuK;
				switch (num)
				{
				default:
					return false;
				case 0:
					lrWbcOPhwDuoHUrxuqtTZNQvgQGz = -1;
					if (platform_XInput_Base.elements == null || platform_XInput_Base.elements.axes == null)
					{
						return false;
					}
					OKEyfJUIcyKcWCTMTHFGXjBghPAf = 0;
					break;
				case 1:
					lrWbcOPhwDuoHUrxuqtTZNQvgQGz = -1;
					OKEyfJUIcyKcWCTMTHFGXjBghPAf++;
					break;
				}
				if (OKEyfJUIcyKcWCTMTHFGXjBghPAf < platform_XInput_Base.elements.axes.Length)
				{
					jgiFebGPfGEDtYWBwygEsFvdbibV = platform_XInput_Base.elements.axes[OKEyfJUIcyKcWCTMTHFGXjBghPAf];
					lrWbcOPhwDuoHUrxuqtTZNQvgQGz = 1;
					return true;
				}
				return false;
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
			IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
			{
				RElEXCEQAMKNQNDDALVJwyfDCcWg rElEXCEQAMKNQNDDALVJwyfDCcWg;
				if (lrWbcOPhwDuoHUrxuqtTZNQvgQGz == -2 && CNzgjTkGToqHPHqPQEPWmySSInYgA == Environment.CurrentManagedThreadId)
				{
					lrWbcOPhwDuoHUrxuqtTZNQvgQGz = 0;
					rElEXCEQAMKNQNDDALVJwyfDCcWg = this;
				}
				else
				{
					rElEXCEQAMKNQNDDALVJwyfDCcWg = new RElEXCEQAMKNQNDDALVJwyfDCcWg(0);
					rElEXCEQAMKNQNDDALVJwyfDCcWg.ylnHwbGeJIUgONcNDTMVfkmwOSuK = ylnHwbGeJIUgONcNDTMVfkmwOSuK;
				}
				return rElEXCEQAMKNQNDDALVJwyfDCcWg;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Axis>)this).GetEnumerator();
			}
		}

		private sealed class dROncOgQVEZbGwuuPPigHbeBfdxk : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
		{
			private int fJXdSwRzxQzaUeUWgpFcFoigjlaC;

			private Button wHQTMuwrsFQaMLKCVJLHscluarXC;

			private int xhytTiiDAFPLxahXnpmIMBPwDJDJ;

			public Platform_XInput_Base bdSAgkJKZAnTfFwQGrMfWYsDoRgcA;

			private int qfuXuftTsgSgDBiiUTsVVidODiZr;

			Button IEnumerator<Button>.Current
			{
				[DebuggerHidden]
				get
				{
					return wHQTMuwrsFQaMLKCVJLHscluarXC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return wHQTMuwrsFQaMLKCVJLHscluarXC;
				}
			}

			[DebuggerHidden]
			public dROncOgQVEZbGwuuPPigHbeBfdxk(int P_0)
			{
				fJXdSwRzxQzaUeUWgpFcFoigjlaC = P_0;
				xhytTiiDAFPLxahXnpmIMBPwDJDJ = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = fJXdSwRzxQzaUeUWgpFcFoigjlaC;
				Platform_XInput_Base platform_XInput_Base = bdSAgkJKZAnTfFwQGrMfWYsDoRgcA;
				switch (num)
				{
				default:
					return false;
				case 0:
					fJXdSwRzxQzaUeUWgpFcFoigjlaC = -1;
					if (platform_XInput_Base.elements == null || platform_XInput_Base.elements.buttons == null)
					{
						return false;
					}
					qfuXuftTsgSgDBiiUTsVVidODiZr = 0;
					break;
				case 1:
					fJXdSwRzxQzaUeUWgpFcFoigjlaC = -1;
					qfuXuftTsgSgDBiiUTsVVidODiZr++;
					break;
				}
				if (qfuXuftTsgSgDBiiUTsVVidODiZr < platform_XInput_Base.elements.buttons.Length)
				{
					wHQTMuwrsFQaMLKCVJLHscluarXC = platform_XInput_Base.elements.buttons[qfuXuftTsgSgDBiiUTsVVidODiZr];
					fJXdSwRzxQzaUeUWgpFcFoigjlaC = 1;
					return true;
				}
				return false;
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
			IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
			{
				dROncOgQVEZbGwuuPPigHbeBfdxk dROncOgQVEZbGwuuPPigHbeBfdxk2;
				if (fJXdSwRzxQzaUeUWgpFcFoigjlaC == -2 && xhytTiiDAFPLxahXnpmIMBPwDJDJ == Environment.CurrentManagedThreadId)
				{
					fJXdSwRzxQzaUeUWgpFcFoigjlaC = 0;
					dROncOgQVEZbGwuuPPigHbeBfdxk2 = this;
				}
				else
				{
					dROncOgQVEZbGwuuPPigHbeBfdxk2 = new dROncOgQVEZbGwuuPPigHbeBfdxk(0);
					dROncOgQVEZbGwuuPPigHbeBfdxk2.bdSAgkJKZAnTfFwQGrMfWYsDoRgcA = bdSAgkJKZAnTfFwQGrMfWYsDoRgcA;
				}
				return dROncOgQVEZbGwuuPPigHbeBfdxk2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Button>)this).GetEnumerator();
			}
		}

		public MatchingCriteria matchingCriteria;

		public Elements elements;

		int Platform.assignedButtonCount => get_assignedButtonCount();

		int Platform.assignedAxisCount => get_assignedAxisCount();

		InputPlatform Platform.platform => get_platform();

		internal Axis[] Axes_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.axes;
			}
		}

		internal Button[] Buttons_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.buttons;
			}
		}

		bool Platform.hasData => get_hasData();

		bool Platform.disabled => get_disabled();

		bool Platform.isAllowed => get_isAllowed();

		Elements_Base Platform.elements_base => get_elements_base();

		public virtual int get_assignedButtonCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.buttonCount;
		}

		public virtual int get_assignedAxisCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.axisCount;
		}

		internal virtual InputPlatform get_platform()
		{
			return InputPlatform.WindowsXInput;
		}

		internal virtual bool get_hasData()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			if (!matchingCriteria.hasData)
			{
				return false;
			}
			if (assignedAxisCount == 0 && assignedButtonCount == 0)
			{
				return false;
			}
			return true;
		}

		internal virtual bool get_disabled()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.disabled;
		}

		internal virtual bool get_isAllowed()
		{
			if (!base.isAllowed)
			{
				return false;
			}
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.isAllowed;
		}

		internal virtual Elements_Base get_elements_base()
		{
			return elements;
		}

		public override IList<Platform> GetVariants()
		{
			return null;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			return false;
		}

		[IteratorStateMachine(typeof(RElEXCEQAMKNQNDDALVJwyfDCcWg))]
		internal IEnumerable<Axis> IterateAxes()
		{
			return new RElEXCEQAMKNQNDDALVJwyfDCcWg(-2)
			{
				ylnHwbGeJIUgONcNDTMVfkmwOSuK = this
			};
		}

		[IteratorStateMachine(typeof(dROncOgQVEZbGwuuPPigHbeBfdxk))]
		internal IEnumerable<Button> IterateButtons()
		{
			return new dROncOgQVEZbGwuuPPigHbeBfdxk(-2)
			{
				bdSAgkJKZAnTfFwQGrMfWYsDoRgcA = this
			};
		}

		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			foreach (Axis item in IterateAxes())
			{
				if (item.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			foreach (Button item2 in IterateButtons())
			{
				if (item2.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[assignedButtonCount];
			axes = new int[assignedAxisCount];
			int num = 0;
			foreach (Button item in IterateButtons())
			{
				buttons[num] = item.elementIdentifier;
				num++;
			}
			num = 0;
			foreach (Axis item2 in IterateAxes())
			{
				axes[num] = item2.elementIdentifier;
				num++;
			}
		}

		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			Axis[] axes_orig = Axes_orig;
			if (axes_orig == null)
			{
				return null;
			}
			AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i].sourceType == HardwareElementSourceType.Axis || axes_orig[i].sourceType == HardwareElementSourceType.Custom)
				{
					array[i] = AxisCalibrationData.Default;
					array[i].invert = axes_orig[i].invert;
					array[i].deadZone = axes_orig[i].axisDeadZone;
					if (Axes_orig[i].calibrateAxis)
					{
						array[i].zero = axes_orig[i].axisZero;
						array[i].min = axes_orig[i].axisMin;
						array[i].max = axes_orig[i].axisMax;
					}
				}
				else
				{
					if (axes_orig[i].sourceType != HardwareElementSourceType.Button)
					{
						throw new NotImplementedException();
					}
					array[i] = AxisCalibrationData.Default;
				}
				array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
			}
			return array;
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[Axes_orig.Length];
			for (int i = 0; i < Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
				if (Axes_orig[i].sourceType == HardwareElementSourceType.Axis || Axes_orig[i].sourceType == HardwareElementSourceType.Custom)
				{
					axisRanges[i] = Axes_orig[i].sourceAxisRange;
					continue;
				}
				if (Axes_orig[i].sourceType == HardwareElementSourceType.Button)
				{
					axisRanges[i] = AxisRange.Full;
					continue;
				}
				throw new Exception();
			}
		}

		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = null;
			if (Buttons_orig != null)
			{
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				for (int i = 0; i < Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
				}
			}
		}

		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (elements == null)
			{
				return ControllerElementType.Axis;
			}
			return elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		public override object DeepClone()
		{
			Platform_XInput_Base platform_XInput_Base = new Platform_XInput_Base();
			CopyVars(platform_XInput_Base);
			return platform_XInput_Base;
		}

		internal override void CopyVars(Platform destination)
		{
			if (destination is Platform_XInput_Base platform_XInput_Base)
			{
				platform_XInput_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
				platform_XInput_Base.elements = MiscTools.DeepClone(elements);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Platform_XInput : Platform_XInput_Base
	{
		public Platform_XInput_Base[] variants;

		public override IList<Platform> GetVariants()
		{
			return variants;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return true;
			}
			if (base.hasVariants)
			{
				for (int i = 0; i < variants.Length; i++)
				{
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		public override object DeepClone()
		{
			Platform_XInput platform_XInput = new Platform_XInput();
			CopyVars(platform_XInput);
			return platform_XInput;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_XInput platform_XInput)
			{
				platform_XInput.variants = MiscTools.DeepClone(variants);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class Platform_OSX_Base : Platform
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class MatchingCriteria : MatchingCriteria_Base
		{
			[Serializable]
			public sealed class ElementCount : ElementCount_Base
			{
				public int hatCount;

				public override object DeepClone()
				{
					ElementCount elementCount = new ElementCount();
					DHyZsEQjfQXqCiERWSJlkrWZAVDE(elementCount);
					return elementCount;
				}

				internal void ZplGDNVdKqICIOZLuQaOAApFULyq(ElementCount_Base P_0)
				{
					base.DHyZsEQjfQXqCiERWSJlkrWZAVDE(P_0);
					if (P_0 is ElementCount elementCount)
					{
						elementCount.hatCount = hatCount;
					}
				}

				internal bool nZVBxfxOPsrIpOGZKVXXEIHlwGTB(BridgedControllerHWInfo P_0)
				{
					if (!base.cubDYXAvXKoMbRtseYFVkoMtvxhf(P_0))
					{
						return false;
					}
					if (hatCount >= 0)
					{
						return hatCount == P_0.hardwareHatCount;
					}
					return true;
				}
			}

			public int hatCount;

			public ElementCount[] alternateElementCounts;

			public bool productName_useRegex;

			public string[] productName;

			public string[] manufacturer;

			public int[] productId;

			public int[] vendorId;

			bool MatchingCriteria_Base.hasData => get_hasData();

			bool MatchingCriteria_Base.isAllowed => get_isAllowed();

			int MatchingCriteria_Base.alternateElementCount => get_alternateElementCount();

			internal bool get_hasData()
			{
				if (disabled)
				{
					return false;
				}
				if (productName != null && productName.Length != 0)
				{
					return true;
				}
				if (productId != null && productId.Length != 0 && vendorId != null && vendorId.Length != 0)
				{
					return true;
				}
				return false;
			}

			internal bool get_isAllowed()
			{
				if (!base.isAllowed)
				{
					return false;
				}
				return true;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
				{
					return true;
				}
				if (!base.Matches(bridgedControllerHWInfo, strictMatch))
				{
					return false;
				}
				if (strictMatch)
				{
					bool flag = false;
					for (int i = 0; i < vendorId.Length; i++)
					{
						if (vendorId[i] == bridgedControllerHWInfo.hw_vendorId && i < productId.Length && productId[i] == bridgedControllerHWInfo.hw_productId)
						{
							flag = true;
						}
					}
					if (!flag)
					{
						return false;
					}
					if (ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_vendorId))
					{
						string name = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
						if (!ProductNameMatches(name))
						{
							return false;
						}
					}
					return true;
				}
				string text = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
				text = text.Trim();
				if (!ProductNameMatches(text))
				{
					return false;
				}
				return true;
			}

			internal int get_alternateElementCount()
			{
				if (alternateElementCounts == null)
				{
					return 0;
				}
				return alternateElementCounts.Length;
			}

			internal override ElementCount_Base GetAlternateElementCount(int index)
			{
				if (alternateElementCounts == null || index < 0 || index >= alternateElementCounts.Length)
				{
					return null;
				}
				return alternateElementCounts[index];
			}

			internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
			{
				if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
				{
					return false;
				}
				if (alternateMatched)
				{
					return true;
				}
				if (hatCount >= 0)
				{
					return bridgedControllerHWInfo.hardwareHatCount == hatCount;
				}
				return true;
			}

			private bool ProductNameMatches(string name)
			{
				if (productName == null)
				{
					return false;
				}
				for (int i = 0; i < productName.Length; i++)
				{
					string text = ((productName[i] == null) ? string.Empty : productName[i]);
					text = text.Trim();
					if (MatchingCriteria_Base.StringMatches(name, text, productName_useRegex))
					{
						return true;
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			internal override void CopyVars(MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				if (destination is MatchingCriteria matchingCriteria)
				{
					matchingCriteria.hatCount = hatCount;
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
					matchingCriteria.productId = ArrayTools.ShallowCopy(productId);
					matchingCriteria.vendorId = ArrayTools.ShallowCopy(vendorId);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Elements : Elements_Base
		{
			private sealed class azFufCaoDvjkoVVxiZLSlCpKeaLl : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int AdjHVlxUwbkVJEFalCVPCPaJNVId;

				private Axis BnPtzuQvFXKeLmciYxjYpZqhWKLR;

				private int UMhPCwkxbZKqVYaHlprwBBuzGnZCA;

				public Elements aMGHsonfNtZyZLqsenjzvCQhGkni;

				private Axis[] BAPWXOyLBOtvdnEOCYudzKMfDhPe;

				private int MnrFfDJYKGwZNRvPkMCbjQxsvxvc;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return BnPtzuQvFXKeLmciYxjYpZqhWKLR;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return BnPtzuQvFXKeLmciYxjYpZqhWKLR;
					}
				}

				[DebuggerHidden]
				public azFufCaoDvjkoVVxiZLSlCpKeaLl(int P_0)
				{
					AdjHVlxUwbkVJEFalCVPCPaJNVId = P_0;
					UMhPCwkxbZKqVYaHlprwBBuzGnZCA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int adjHVlxUwbkVJEFalCVPCPaJNVId = AdjHVlxUwbkVJEFalCVPCPaJNVId;
					Elements elements = aMGHsonfNtZyZLqsenjzvCQhGkni;
					switch (adjHVlxUwbkVJEFalCVPCPaJNVId)
					{
					default:
						return false;
					case 0:
						AdjHVlxUwbkVJEFalCVPCPaJNVId = -1;
						if (elements.axes == null)
						{
							return false;
						}
						BAPWXOyLBOtvdnEOCYudzKMfDhPe = elements.axes;
						MnrFfDJYKGwZNRvPkMCbjQxsvxvc = 0;
						break;
					case 1:
						AdjHVlxUwbkVJEFalCVPCPaJNVId = -1;
						MnrFfDJYKGwZNRvPkMCbjQxsvxvc++;
						break;
					}
					if (MnrFfDJYKGwZNRvPkMCbjQxsvxvc < BAPWXOyLBOtvdnEOCYudzKMfDhPe.Length)
					{
						Axis bnPtzuQvFXKeLmciYxjYpZqhWKLR = BAPWXOyLBOtvdnEOCYudzKMfDhPe[MnrFfDJYKGwZNRvPkMCbjQxsvxvc];
						BnPtzuQvFXKeLmciYxjYpZqhWKLR = bnPtzuQvFXKeLmciYxjYpZqhWKLR;
						AdjHVlxUwbkVJEFalCVPCPaJNVId = 1;
						return true;
					}
					BAPWXOyLBOtvdnEOCYudzKMfDhPe = null;
					return false;
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					azFufCaoDvjkoVVxiZLSlCpKeaLl azFufCaoDvjkoVVxiZLSlCpKeaLl2;
					if (AdjHVlxUwbkVJEFalCVPCPaJNVId == -2 && UMhPCwkxbZKqVYaHlprwBBuzGnZCA == Environment.CurrentManagedThreadId)
					{
						AdjHVlxUwbkVJEFalCVPCPaJNVId = 0;
						azFufCaoDvjkoVVxiZLSlCpKeaLl2 = this;
					}
					else
					{
						azFufCaoDvjkoVVxiZLSlCpKeaLl2 = new azFufCaoDvjkoVVxiZLSlCpKeaLl(0);
						azFufCaoDvjkoVVxiZLSlCpKeaLl2.aMGHsonfNtZyZLqsenjzvCQhGkni = aMGHsonfNtZyZLqsenjzvCQhGkni;
					}
					return azFufCaoDvjkoVVxiZLSlCpKeaLl2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class PMJBdcjvxEwsXErKhdZUhnhzCfBcA : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int UvjqvzATJismOSMJHlqmdsbhMNtS;

				private Button pYuGQeiAHHbcmYSbHJmRgLWpuGbsA;

				private int EzYKhTUdOxtGfXDYGvzFhfSiDdWE;

				public Elements FJYnoghtOPVJfaoZvqjeDPcESahu;

				private Button[] cvBwHdnUcnqZbFWVrOvKRizCOPOm;

				private int HEIGwtcSNLXJXMObhhofpdQdEoBI;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return pYuGQeiAHHbcmYSbHJmRgLWpuGbsA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return pYuGQeiAHHbcmYSbHJmRgLWpuGbsA;
					}
				}

				[DebuggerHidden]
				public PMJBdcjvxEwsXErKhdZUhnhzCfBcA(int P_0)
				{
					UvjqvzATJismOSMJHlqmdsbhMNtS = P_0;
					EzYKhTUdOxtGfXDYGvzFhfSiDdWE = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int uvjqvzATJismOSMJHlqmdsbhMNtS = UvjqvzATJismOSMJHlqmdsbhMNtS;
					Elements fJYnoghtOPVJfaoZvqjeDPcESahu = FJYnoghtOPVJfaoZvqjeDPcESahu;
					switch (uvjqvzATJismOSMJHlqmdsbhMNtS)
					{
					default:
						return false;
					case 0:
						UvjqvzATJismOSMJHlqmdsbhMNtS = -1;
						if (fJYnoghtOPVJfaoZvqjeDPcESahu.buttons == null)
						{
							return false;
						}
						cvBwHdnUcnqZbFWVrOvKRizCOPOm = fJYnoghtOPVJfaoZvqjeDPcESahu.buttons;
						HEIGwtcSNLXJXMObhhofpdQdEoBI = 0;
						break;
					case 1:
						UvjqvzATJismOSMJHlqmdsbhMNtS = -1;
						HEIGwtcSNLXJXMObhhofpdQdEoBI++;
						break;
					}
					if (HEIGwtcSNLXJXMObhhofpdQdEoBI < cvBwHdnUcnqZbFWVrOvKRizCOPOm.Length)
					{
						Button button = cvBwHdnUcnqZbFWVrOvKRizCOPOm[HEIGwtcSNLXJXMObhhofpdQdEoBI];
						pYuGQeiAHHbcmYSbHJmRgLWpuGbsA = button;
						UvjqvzATJismOSMJHlqmdsbhMNtS = 1;
						return true;
					}
					cvBwHdnUcnqZbFWVrOvKRizCOPOm = null;
					return false;
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					PMJBdcjvxEwsXErKhdZUhnhzCfBcA pMJBdcjvxEwsXErKhdZUhnhzCfBcA;
					if (UvjqvzATJismOSMJHlqmdsbhMNtS == -2 && EzYKhTUdOxtGfXDYGvzFhfSiDdWE == Environment.CurrentManagedThreadId)
					{
						UvjqvzATJismOSMJHlqmdsbhMNtS = 0;
						pMJBdcjvxEwsXErKhdZUhnhzCfBcA = this;
					}
					else
					{
						pMJBdcjvxEwsXErKhdZUhnhzCfBcA = new PMJBdcjvxEwsXErKhdZUhnhzCfBcA(0);
						pMJBdcjvxEwsXErKhdZUhnhzCfBcA.FJYnoghtOPVJfaoZvqjeDPcESahu = FJYnoghtOPVJfaoZvqjeDPcESahu;
					}
					return pMJBdcjvxEwsXErKhdZUhnhzCfBcA;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public Axis[] axes;

			public Button[] buttons;

			int Elements_Base.buttonCount => get_buttonCount();

			int Elements_Base.axisCount => get_axisCount();

			public int get_buttonCount()
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}

			public int get_axisCount()
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}

			[IteratorStateMachine(typeof(azFufCaoDvjkoVVxiZLSlCpKeaLl))]
			public IEnumerable<Axis> IterateAxes()
			{
				return new azFufCaoDvjkoVVxiZLSlCpKeaLl(-2)
				{
					aMGHsonfNtZyZLqsenjzvCQhGkni = this
				};
			}

			[IteratorStateMachine(typeof(PMJBdcjvxEwsXErKhdZUhnhzCfBcA))]
			public IEnumerable<Button> IterateButtons()
			{
				return new PMJBdcjvxEwsXErKhdZUhnhzCfBcA(-2)
				{
					FJYnoghtOPVJfaoZvqjeDPcESahu = this
				};
			}

			public override object DeepClone()
			{
				Elements elements = new Elements();
				CopyVars(elements);
				return elements;
			}

			internal override void CopyVars(Elements_Base destination)
			{
				base.CopyVars(destination);
				if (destination is Elements elements)
				{
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Axis;
					}
				}
				for (int j = 0; j < buttonCount; j++)
				{
					if (buttons[j].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Button;
					}
				}
				return elementIdentifier.elementType;
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier != elementIdentifier.get_id())
					{
						continue;
					}
					switch (axes[i].sourceType)
					{
					case HardwareElementSourceTypeWithHat.Axis:
					case HardwareElementSourceTypeWithHat.Custom:
						axisRange = axes[i].sourceAxisRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					case HardwareElementSourceTypeWithHat.Button:
						axisRange = AxisRange.Positive;
						return true;
					case HardwareElementSourceTypeWithHat.Hat:
						axisRange = axes[i].sourceHatRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					default:
						throw new NotImplementedException();
					}
				}
				axisRange = AxisRange.Full;
				return false;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Element : IDeepCloneable
		{
			public abstract object DeepClone();
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Button : Element
		{
			public int elementIdentifier;

			public HardwareElementSourceTypeWithHat sourceType;

			public int sourceButton;

			public int sourceStick;

			public OSXAxis sourceAxis;

			public int sourceOtherAxis;

			public Pole sourceAxisPole;

			public float axisDeadZone;

			public int sourceHat;

			public HatType sourceHatType;

			public HatDirection sourceHatDirection;

			public bool requireMultipleButtons;

			public int[] requiredButtons;

			public bool ignoreIfButtonsActive;

			public int[] ignoreIfButtonsActiveButtons;

			public HardwareButtonInfo buttonInfo;

			public Button()
			{
				sourceType = HardwareElementSourceTypeWithHat.Button;
			}

			public override object DeepClone()
			{
				return new Button
				{
					elementIdentifier = elementIdentifier,
					sourceType = sourceType,
					sourceButton = sourceButton,
					sourceStick = sourceStick,
					sourceAxis = sourceAxis,
					sourceOtherAxis = sourceOtherAxis,
					sourceAxisPole = sourceAxisPole,
					axisDeadZone = axisDeadZone,
					sourceHat = sourceHat,
					sourceHatType = sourceHatType,
					sourceHatDirection = sourceHatDirection,
					requireMultipleButtons = requireMultipleButtons,
					requiredButtons = ArrayTools.ShallowCopy(requiredButtons),
					ignoreIfButtonsActive = ignoreIfButtonsActive,
					ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(ignoreIfButtonsActiveButtons),
					buttonInfo = MiscTools.DeepClone(buttonInfo)
				};
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Axis : Element
		{
			public int elementIdentifier;

			public HardwareElementSourceTypeWithHat sourceType;

			public int sourceStick;

			public OSXAxis sourceAxis;

			public int sourceOtherAxis;

			public AxisRange sourceAxisRange;

			public bool invert;

			public float axisDeadZone;

			public bool calibrateAxis;

			public float axisZero;

			public float axisMin;

			public float axisMax;

			public AxisCalibrationInfoEntry[] alternateCalibrations;

			public HardwareAxisInfo axisInfo;

			public int sourceButton;

			public Pole buttonAxisContribution;

			public int sourceHat;

			public AxisDirection sourceHatDirection;

			public AxisRange sourceHatRange;

			public Axis()
			{
				sourceType = HardwareElementSourceTypeWithHat.Axis;
				axisZero = 0f;
				axisMin = -1f;
				axisMax = 1f;
			}

			public override object DeepClone()
			{
				return new Axis
				{
					elementIdentifier = elementIdentifier,
					sourceType = sourceType,
					sourceStick = sourceStick,
					sourceAxis = sourceAxis,
					sourceOtherAxis = sourceOtherAxis,
					sourceAxisRange = sourceAxisRange,
					invert = invert,
					axisDeadZone = axisDeadZone,
					calibrateAxis = calibrateAxis,
					axisZero = axisZero,
					axisMin = axisMin,
					axisMax = axisMax,
					axisInfo = MiscTools.DeepClone(axisInfo),
					sourceButton = sourceButton,
					buttonAxisContribution = buttonAxisContribution,
					sourceHat = sourceHat,
					sourceHatDirection = sourceHatDirection,
					sourceHatRange = sourceHatRange,
					alternateCalibrations = MiscTools.DeepClone(alternateCalibrations)
				};
			}
		}

		private sealed class CuBhFSOxZhcVBqdzeWBezlMJHbhY : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
		{
			private int BJcCSpEDxIAmgEelgblIsUKhSDAXb;

			private Axis fVdeJhZXZYfiMdvBawKkkLBpfGfA;

			private int OPAeLzSrWnJgAGqUWCxFQSfisShq;

			public Platform_OSX_Base pTdgWFiKJsJBCXppRHVKCcThaDqmA;

			private int fLyRiYKWxlBNgpugpmCYXBVMAtij;

			Axis IEnumerator<Axis>.Current
			{
				[DebuggerHidden]
				get
				{
					return fVdeJhZXZYfiMdvBawKkkLBpfGfA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return fVdeJhZXZYfiMdvBawKkkLBpfGfA;
				}
			}

			[DebuggerHidden]
			public CuBhFSOxZhcVBqdzeWBezlMJHbhY(int P_0)
			{
				BJcCSpEDxIAmgEelgblIsUKhSDAXb = P_0;
				OPAeLzSrWnJgAGqUWCxFQSfisShq = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int bJcCSpEDxIAmgEelgblIsUKhSDAXb = BJcCSpEDxIAmgEelgblIsUKhSDAXb;
				Platform_OSX_Base platform_OSX_Base = pTdgWFiKJsJBCXppRHVKCcThaDqmA;
				switch (bJcCSpEDxIAmgEelgblIsUKhSDAXb)
				{
				default:
					return false;
				case 0:
					BJcCSpEDxIAmgEelgblIsUKhSDAXb = -1;
					if (platform_OSX_Base.elements == null || platform_OSX_Base.elements.axes == null)
					{
						return false;
					}
					fLyRiYKWxlBNgpugpmCYXBVMAtij = 0;
					break;
				case 1:
					BJcCSpEDxIAmgEelgblIsUKhSDAXb = -1;
					fLyRiYKWxlBNgpugpmCYXBVMAtij++;
					break;
				}
				if (fLyRiYKWxlBNgpugpmCYXBVMAtij < platform_OSX_Base.elements.axes.Length)
				{
					fVdeJhZXZYfiMdvBawKkkLBpfGfA = platform_OSX_Base.elements.axes[fLyRiYKWxlBNgpugpmCYXBVMAtij];
					BJcCSpEDxIAmgEelgblIsUKhSDAXb = 1;
					return true;
				}
				return false;
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
			IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
			{
				CuBhFSOxZhcVBqdzeWBezlMJHbhY cuBhFSOxZhcVBqdzeWBezlMJHbhY;
				if (BJcCSpEDxIAmgEelgblIsUKhSDAXb == -2 && OPAeLzSrWnJgAGqUWCxFQSfisShq == Environment.CurrentManagedThreadId)
				{
					BJcCSpEDxIAmgEelgblIsUKhSDAXb = 0;
					cuBhFSOxZhcVBqdzeWBezlMJHbhY = this;
				}
				else
				{
					cuBhFSOxZhcVBqdzeWBezlMJHbhY = new CuBhFSOxZhcVBqdzeWBezlMJHbhY(0);
					cuBhFSOxZhcVBqdzeWBezlMJHbhY.pTdgWFiKJsJBCXppRHVKCcThaDqmA = pTdgWFiKJsJBCXppRHVKCcThaDqmA;
				}
				return cuBhFSOxZhcVBqdzeWBezlMJHbhY;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Axis>)this).GetEnumerator();
			}
		}

		private sealed class APCJxVRatUMPIkfrTHXaaeiSaBdO : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
		{
			private int iXQRErbDXSOKevBurfwVOdnnoUhQ;

			private Button ZxlxwYtXybYygretmQhJCJdwAxo;

			private int txKGDYRStplLaFbCNcAZwCmbwfWU;

			public Platform_OSX_Base SjGIHGRhyoebfkhULXXyHrEocYgC;

			private int isobsqpogiKsdKtjNmkUAofuzNnb;

			Button IEnumerator<Button>.Current
			{
				[DebuggerHidden]
				get
				{
					return ZxlxwYtXybYygretmQhJCJdwAxo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ZxlxwYtXybYygretmQhJCJdwAxo;
				}
			}

			[DebuggerHidden]
			public APCJxVRatUMPIkfrTHXaaeiSaBdO(int P_0)
			{
				iXQRErbDXSOKevBurfwVOdnnoUhQ = P_0;
				txKGDYRStplLaFbCNcAZwCmbwfWU = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = iXQRErbDXSOKevBurfwVOdnnoUhQ;
				Platform_OSX_Base sjGIHGRhyoebfkhULXXyHrEocYgC = SjGIHGRhyoebfkhULXXyHrEocYgC;
				switch (num)
				{
				default:
					return false;
				case 0:
					iXQRErbDXSOKevBurfwVOdnnoUhQ = -1;
					if (sjGIHGRhyoebfkhULXXyHrEocYgC.elements == null || sjGIHGRhyoebfkhULXXyHrEocYgC.elements.buttons == null)
					{
						return false;
					}
					isobsqpogiKsdKtjNmkUAofuzNnb = 0;
					break;
				case 1:
					iXQRErbDXSOKevBurfwVOdnnoUhQ = -1;
					isobsqpogiKsdKtjNmkUAofuzNnb++;
					break;
				}
				if (isobsqpogiKsdKtjNmkUAofuzNnb < sjGIHGRhyoebfkhULXXyHrEocYgC.elements.buttons.Length)
				{
					ZxlxwYtXybYygretmQhJCJdwAxo = sjGIHGRhyoebfkhULXXyHrEocYgC.elements.buttons[isobsqpogiKsdKtjNmkUAofuzNnb];
					iXQRErbDXSOKevBurfwVOdnnoUhQ = 1;
					return true;
				}
				return false;
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
			IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
			{
				APCJxVRatUMPIkfrTHXaaeiSaBdO aPCJxVRatUMPIkfrTHXaaeiSaBdO;
				if (iXQRErbDXSOKevBurfwVOdnnoUhQ == -2 && txKGDYRStplLaFbCNcAZwCmbwfWU == Environment.CurrentManagedThreadId)
				{
					iXQRErbDXSOKevBurfwVOdnnoUhQ = 0;
					aPCJxVRatUMPIkfrTHXaaeiSaBdO = this;
				}
				else
				{
					aPCJxVRatUMPIkfrTHXaaeiSaBdO = new APCJxVRatUMPIkfrTHXaaeiSaBdO(0);
					aPCJxVRatUMPIkfrTHXaaeiSaBdO.SjGIHGRhyoebfkhULXXyHrEocYgC = SjGIHGRhyoebfkhULXXyHrEocYgC;
				}
				return aPCJxVRatUMPIkfrTHXaaeiSaBdO;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Button>)this).GetEnumerator();
			}
		}

		public MatchingCriteria matchingCriteria;

		public Elements elements;

		int Platform.assignedButtonCount => get_assignedButtonCount();

		int Platform.assignedAxisCount => get_assignedAxisCount();

		InputPlatform Platform.platform => get_platform();

		internal Button[] Buttons_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.buttons;
			}
		}

		internal Axis[] Axes_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.axes;
			}
		}

		bool Platform.hasData => get_hasData();

		bool Platform.disabled => get_disabled();

		bool Platform.isAllowed => get_isAllowed();

		Elements_Base Platform.elements_base => get_elements_base();

		public virtual int get_assignedButtonCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.buttonCount;
		}

		public virtual int get_assignedAxisCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.axisCount;
		}

		internal virtual InputPlatform get_platform()
		{
			return InputPlatform.OSXNative;
		}

		internal virtual bool get_hasData()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			if (!matchingCriteria.hasData)
			{
				return false;
			}
			if (assignedAxisCount == 0 && assignedButtonCount == 0)
			{
				return false;
			}
			return true;
		}

		internal virtual bool get_disabled()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.disabled;
		}

		internal virtual bool get_isAllowed()
		{
			if (!base.isAllowed)
			{
				return false;
			}
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.isAllowed;
		}

		internal virtual Elements_Base get_elements_base()
		{
			return elements;
		}

		public override IList<Platform> GetVariants()
		{
			return null;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			return false;
		}

		[IteratorStateMachine(typeof(CuBhFSOxZhcVBqdzeWBezlMJHbhY))]
		internal IEnumerable<Axis> IterateAxes()
		{
			return new CuBhFSOxZhcVBqdzeWBezlMJHbhY(-2)
			{
				pTdgWFiKJsJBCXppRHVKCcThaDqmA = this
			};
		}

		[IteratorStateMachine(typeof(APCJxVRatUMPIkfrTHXaaeiSaBdO))]
		internal IEnumerable<Button> IterateButtons()
		{
			return new APCJxVRatUMPIkfrTHXaaeiSaBdO(-2)
			{
				SjGIHGRhyoebfkhULXXyHrEocYgC = this
			};
		}

		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			foreach (Axis item in IterateAxes())
			{
				if (item.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			foreach (Button item2 in IterateButtons())
			{
				if (item2.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[assignedButtonCount];
			axes = new int[assignedAxisCount];
			int num = 0;
			foreach (Button item in IterateButtons())
			{
				buttons[num] = item.elementIdentifier;
				num++;
			}
			num = 0;
			foreach (Axis item2 in IterateAxes())
			{
				axes[num] = item2.elementIdentifier;
				num++;
			}
		}

		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			Axis[] axes_orig = Axes_orig;
			if (axes_orig == null)
			{
				return null;
			}
			AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
				{
					array[i] = AxisCalibrationData.Default;
					array[i].invert = axes_orig[i].invert;
					array[i].deadZone = axes_orig[i].axisDeadZone;
					if (Axes_orig[i].calibrateAxis)
					{
						array[i].zero = axes_orig[i].axisZero;
						array[i].min = axes_orig[i].axisMin;
						array[i].max = axes_orig[i].axisMax;
					}
				}
				else
				{
					if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
					{
						throw new NotImplementedException();
					}
					array[i] = AxisCalibrationData.Default;
				}
				array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
			}
			return array;
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[Axes_orig.Length];
			for (int i = 0; i < Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
				if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
				{
					axisRanges[i] = Axes_orig[i].sourceAxisRange;
					continue;
				}
				if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
				{
					axisRanges[i] = AxisRange.Full;
					continue;
				}
				throw new Exception();
			}
		}

		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = null;
			if (Buttons_orig != null)
			{
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				for (int i = 0; i < Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
				}
			}
		}

		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (elements == null)
			{
				return ControllerElementType.Axis;
			}
			return elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		public override object DeepClone()
		{
			Platform_OSX_Base platform_OSX_Base = new Platform_OSX_Base();
			CopyVars(platform_OSX_Base);
			return platform_OSX_Base;
		}

		internal override void CopyVars(Platform destination)
		{
			if (destination is Platform_OSX_Base platform_OSX_Base)
			{
				platform_OSX_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
				platform_OSX_Base.elements = MiscTools.DeepClone(elements);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Platform_OSX : Platform_OSX_Base
	{
		public Platform_OSX_Base[] variants;

		public override IList<Platform> GetVariants()
		{
			return variants;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return true;
			}
			if (base.hasVariants)
			{
				for (int i = 0; i < variants.Length; i++)
				{
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		public override object DeepClone()
		{
			Platform_OSX platform_OSX = new Platform_OSX();
			CopyVars(platform_OSX);
			return platform_OSX;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_OSX platform_OSX)
			{
				platform_OSX.variants = MiscTools.DeepClone(variants);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class Platform_Linux_Base : Platform
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class MatchingCriteria : MatchingCriteria_Base
		{
			[Serializable]
			public sealed class ElementCount : ElementCount_Base
			{
				public int hatCount;

				public override object DeepClone()
				{
					ElementCount elementCount = new ElementCount();
					DHyZsEQjfQXqCiERWSJlkrWZAVDE(elementCount);
					return elementCount;
				}

				internal void kZdNWPqBgnpQiPdiSByjCTkkrcJY(ElementCount_Base P_0)
				{
					base.DHyZsEQjfQXqCiERWSJlkrWZAVDE(P_0);
					if (P_0 is ElementCount elementCount)
					{
						elementCount.hatCount = hatCount;
					}
				}

				internal bool eYzvuOHvxyOLbqIHzHKDrWRZXEYW(BridgedControllerHWInfo P_0)
				{
					if (!base.cubDYXAvXKoMbRtseYFVkoMtvxhf(P_0))
					{
						return false;
					}
					if (hatCount >= 0)
					{
						return hatCount == P_0.hardwareHatCount;
					}
					return true;
				}
			}

			public int hatCount;

			public ElementCount[] alternateElementCounts;

			public bool manufacturer_useRegex;

			public bool productName_useRegex;

			public bool systemName_useRegex;

			public string[] manufacturer;

			public string[] productName;

			public string[] systemName;

			public string[] productGUID;

			bool MatchingCriteria_Base.hasData => get_hasData();

			bool MatchingCriteria_Base.isAllowed => get_isAllowed();

			int MatchingCriteria_Base.alternateElementCount => get_alternateElementCount();

			internal bool get_hasData()
			{
				if (disabled)
				{
					return false;
				}
				if (productGUID != null && productGUID.Length != 0)
				{
					return true;
				}
				if (productName != null && productName.Length != 0)
				{
					return true;
				}
				return false;
			}

			internal bool get_isAllowed()
			{
				if (!base.isAllowed)
				{
					return false;
				}
				return true;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
				{
					return true;
				}
				if (!base.Matches(bridgedControllerHWInfo, strictMatch))
				{
					return false;
				}
				if (strictMatch)
				{
					if (PidVid.ArrayContains(productGUID, ref bridgedControllerHWInfo.hw_pidVid))
					{
						if (!ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
						{
							return true;
						}
						if (productName == null || productName.Length == 0)
						{
							return true;
						}
					}
					if (!AnyNameMatches(bridgedControllerHWInfo))
					{
						return false;
					}
					return true;
				}
				return AnyNameMatches(bridgedControllerHWInfo);
			}

			internal int get_alternateElementCount()
			{
				if (alternateElementCounts == null)
				{
					return 0;
				}
				return alternateElementCounts.Length;
			}

			internal override ElementCount_Base GetAlternateElementCount(int index)
			{
				if (alternateElementCounts == null || index < 0 || index >= alternateElementCounts.Length)
				{
					return null;
				}
				return alternateElementCounts[index];
			}

			internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
			{
				if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
				{
					return false;
				}
				if (alternateMatched)
				{
					return true;
				}
				if (hatCount >= 0)
				{
					return bridgedControllerHWInfo.hardwareHatCount == hatCount;
				}
				return true;
			}

			private bool AnyNameMatches(BridgedControllerHWInfo bridgedControllerHWInfo)
			{
				if (NameMatches(bridgedControllerHWInfo.hw_productName, productName, productName_useRegex))
				{
					return true;
				}
				if (NameMatches(bridgedControllerHWInfo.hw_systemDeviceName, systemName, systemName_useRegex))
				{
					return true;
				}
				return false;
			}

			private bool NameMatches(string name, string[] names, bool useRegex)
			{
				if (string.IsNullOrEmpty(name) || names == null)
				{
					return false;
				}
				string searchIn = name.Trim();
				for (int i = 0; i < names.Length; i++)
				{
					if (!string.IsNullOrEmpty(names[i]) && MatchingCriteria_Base.StringMatches(searchIn, names[i], useRegex))
					{
						return true;
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			internal override void CopyVars(MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				if (destination is MatchingCriteria matchingCriteria)
				{
					matchingCriteria.hatCount = hatCount;
					matchingCriteria.manufacturer_useRegex = manufacturer_useRegex;
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.systemName_useRegex = systemName_useRegex;
					matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					matchingCriteria.systemName = ArrayTools.ShallowCopy(systemName);
					matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Elements : Elements_Base
		{
			private sealed class uFbHPzciSSQutAQIrPKywOElsYuPA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int wKtbVIYxKbuZjpiPiKINeVTOkXbo;

				private Axis suvfRxeGLwCZQKeNXpFWstwSQrTuA;

				private int YunAZtFTPUDbQHYhoXgECrRaPvsaB;

				public Elements zDoZzZeSTMgilbBNLbpLptjgLwdJ;

				private int HHcqyWOGOViWOHKumbrBTIjAxMsv;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return suvfRxeGLwCZQKeNXpFWstwSQrTuA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return suvfRxeGLwCZQKeNXpFWstwSQrTuA;
					}
				}

				[DebuggerHidden]
				public uFbHPzciSSQutAQIrPKywOElsYuPA(int P_0)
				{
					wKtbVIYxKbuZjpiPiKINeVTOkXbo = P_0;
					YunAZtFTPUDbQHYhoXgECrRaPvsaB = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = wKtbVIYxKbuZjpiPiKINeVTOkXbo;
					Elements elements = zDoZzZeSTMgilbBNLbpLptjgLwdJ;
					switch (num)
					{
					default:
						return false;
					case 0:
						wKtbVIYxKbuZjpiPiKINeVTOkXbo = -1;
						if (elements.axes == null)
						{
							return false;
						}
						HHcqyWOGOViWOHKumbrBTIjAxMsv = 0;
						break;
					case 1:
						wKtbVIYxKbuZjpiPiKINeVTOkXbo = -1;
						HHcqyWOGOViWOHKumbrBTIjAxMsv++;
						break;
					}
					if (HHcqyWOGOViWOHKumbrBTIjAxMsv < elements.axes.Length)
					{
						suvfRxeGLwCZQKeNXpFWstwSQrTuA = elements.axes[HHcqyWOGOViWOHKumbrBTIjAxMsv];
						wKtbVIYxKbuZjpiPiKINeVTOkXbo = 1;
						return true;
					}
					return false;
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					uFbHPzciSSQutAQIrPKywOElsYuPA uFbHPzciSSQutAQIrPKywOElsYuPA2;
					if (wKtbVIYxKbuZjpiPiKINeVTOkXbo == -2 && YunAZtFTPUDbQHYhoXgECrRaPvsaB == Environment.CurrentManagedThreadId)
					{
						wKtbVIYxKbuZjpiPiKINeVTOkXbo = 0;
						uFbHPzciSSQutAQIrPKywOElsYuPA2 = this;
					}
					else
					{
						uFbHPzciSSQutAQIrPKywOElsYuPA2 = new uFbHPzciSSQutAQIrPKywOElsYuPA(0);
						uFbHPzciSSQutAQIrPKywOElsYuPA2.zDoZzZeSTMgilbBNLbpLptjgLwdJ = zDoZzZeSTMgilbBNLbpLptjgLwdJ;
					}
					return uFbHPzciSSQutAQIrPKywOElsYuPA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class RFWijpwSNFhpkExOKDRQlbyeUYDu : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int fAEwrXCCzuuDmEKVAZEYSbjddoDM;

				private Button YVwWtMYuceHVsZInRMvGGRXffCuS;

				private int qEJFeKFYWguyFarmikhHIYNzTihz;

				public Elements AVMErERrQRGOEfquRhYXRJobmQyg;

				private int uddJvuaFpqrAlzVsqoGULOLrkvzK;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return YVwWtMYuceHVsZInRMvGGRXffCuS;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return YVwWtMYuceHVsZInRMvGGRXffCuS;
					}
				}

				[DebuggerHidden]
				public RFWijpwSNFhpkExOKDRQlbyeUYDu(int P_0)
				{
					fAEwrXCCzuuDmEKVAZEYSbjddoDM = P_0;
					qEJFeKFYWguyFarmikhHIYNzTihz = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = fAEwrXCCzuuDmEKVAZEYSbjddoDM;
					Elements aVMErERrQRGOEfquRhYXRJobmQyg = AVMErERrQRGOEfquRhYXRJobmQyg;
					switch (num)
					{
					default:
						return false;
					case 0:
						fAEwrXCCzuuDmEKVAZEYSbjddoDM = -1;
						if (aVMErERrQRGOEfquRhYXRJobmQyg.buttons == null)
						{
							return false;
						}
						uddJvuaFpqrAlzVsqoGULOLrkvzK = 0;
						break;
					case 1:
						fAEwrXCCzuuDmEKVAZEYSbjddoDM = -1;
						uddJvuaFpqrAlzVsqoGULOLrkvzK++;
						break;
					}
					if (uddJvuaFpqrAlzVsqoGULOLrkvzK < aVMErERrQRGOEfquRhYXRJobmQyg.buttons.Length)
					{
						YVwWtMYuceHVsZInRMvGGRXffCuS = aVMErERrQRGOEfquRhYXRJobmQyg.buttons[uddJvuaFpqrAlzVsqoGULOLrkvzK];
						fAEwrXCCzuuDmEKVAZEYSbjddoDM = 1;
						return true;
					}
					return false;
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					RFWijpwSNFhpkExOKDRQlbyeUYDu rFWijpwSNFhpkExOKDRQlbyeUYDu;
					if (fAEwrXCCzuuDmEKVAZEYSbjddoDM == -2 && qEJFeKFYWguyFarmikhHIYNzTihz == Environment.CurrentManagedThreadId)
					{
						fAEwrXCCzuuDmEKVAZEYSbjddoDM = 0;
						rFWijpwSNFhpkExOKDRQlbyeUYDu = this;
					}
					else
					{
						rFWijpwSNFhpkExOKDRQlbyeUYDu = new RFWijpwSNFhpkExOKDRQlbyeUYDu(0);
						rFWijpwSNFhpkExOKDRQlbyeUYDu.AVMErERrQRGOEfquRhYXRJobmQyg = AVMErERrQRGOEfquRhYXRJobmQyg;
					}
					return rFWijpwSNFhpkExOKDRQlbyeUYDu;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public Axis[] axes;

			public Button[] buttons;

			int Elements_Base.buttonCount => get_buttonCount();

			int Elements_Base.axisCount => get_axisCount();

			internal IEnumerable<Axis> Axes
			{
				[IteratorStateMachine(typeof(uFbHPzciSSQutAQIrPKywOElsYuPA))]
				get
				{
					return new uFbHPzciSSQutAQIrPKywOElsYuPA(-2)
					{
						zDoZzZeSTMgilbBNLbpLptjgLwdJ = this
					};
				}
			}

			internal IEnumerable<Button> Buttons
			{
				[IteratorStateMachine(typeof(RFWijpwSNFhpkExOKDRQlbyeUYDu))]
				get
				{
					return new RFWijpwSNFhpkExOKDRQlbyeUYDu(-2)
					{
						AVMErERrQRGOEfquRhYXRJobmQyg = this
					};
				}
			}

			public int get_buttonCount()
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}

			public int get_axisCount()
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}

			internal Axis GetAxis(int axisIndex)
			{
				if (axes == null || axisIndex < 0 || axisIndex >= axes.Length)
				{
					return null;
				}
				return axes[axisIndex];
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Axis;
					}
				}
				for (int j = 0; j < buttonCount; j++)
				{
					if (buttons[j].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Button;
					}
				}
				return elementIdentifier.elementType;
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier != elementIdentifier.get_id())
					{
						continue;
					}
					switch (axes[i].sourceType)
					{
					case HardwareElementSourceTypeWithHat.Axis:
					case HardwareElementSourceTypeWithHat.Custom:
						axisRange = axes[i].sourceAxisRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					case HardwareElementSourceTypeWithHat.Button:
						axisRange = AxisRange.Positive;
						return true;
					case HardwareElementSourceTypeWithHat.Hat:
						axisRange = axes[i].sourceHatRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					default:
						throw new NotImplementedException();
					}
				}
				axisRange = AxisRange.Full;
				return false;
			}

			public override object DeepClone()
			{
				Elements elements = new Elements();
				CopyVars(elements);
				return elements;
			}

			internal override void CopyVars(Elements_Base destination)
			{
				base.CopyVars(destination);
				if (destination is Elements elements)
				{
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Element : IDeepCloneable
		{
			public abstract object DeepClone();

			protected virtual void ImportVars(Element source)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Button : Element
		{
			public int elementIdentifier;

			public HardwareElementSourceTypeWithHat sourceType;

			public int sourceButton;

			public int sourceAxis;

			public Pole sourceAxisPole;

			public float axisDeadZone;

			public int sourceHat;

			public HatType sourceHatType;

			public HatDirection sourceHatDirection;

			public bool requireMultipleButtons;

			public int[] requiredButtons;

			public bool ignoreIfButtonsActive;

			public int[] ignoreIfButtonsActiveButtons;

			public HardwareButtonInfo buttonInfo;

			public Button()
			{
				sourceType = HardwareElementSourceTypeWithHat.Button;
			}

			public override object DeepClone()
			{
				Button button = new Button();
				button.ImportVars(this);
				return button;
			}

			protected override void ImportVars(Element source)
			{
				base.ImportVars(source);
				if (source is Button button)
				{
					elementIdentifier = button.elementIdentifier;
					sourceType = button.sourceType;
					sourceButton = button.sourceButton;
					sourceAxis = button.sourceAxis;
					sourceAxisPole = button.sourceAxisPole;
					axisDeadZone = button.axisDeadZone;
					sourceHat = button.sourceHat;
					sourceHatType = button.sourceHatType;
					sourceHatDirection = button.sourceHatDirection;
					requireMultipleButtons = button.requireMultipleButtons;
					requiredButtons = ArrayTools.ShallowCopy(button.requiredButtons);
					ignoreIfButtonsActive = button.ignoreIfButtonsActive;
					ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(button.ignoreIfButtonsActiveButtons);
					buttonInfo = MiscTools.DeepClone(button.buttonInfo);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Axis : Element
		{
			public int elementIdentifier;

			public HardwareElementSourceTypeWithHat sourceType;

			public int sourceAxis;

			public AxisRange sourceAxisRange;

			public bool invert;

			public float axisDeadZone;

			public bool calibrateAxis;

			public float axisZero;

			public float axisMin;

			public float axisMax;

			public AxisCalibrationInfoEntry[] alternateCalibrations;

			public HardwareAxisInfo axisInfo;

			public int sourceButton;

			public Pole buttonAxisContribution;

			public int sourceHat;

			public AxisDirection sourceHatDirection;

			public AxisRange sourceHatRange;

			public Axis()
			{
				sourceType = HardwareElementSourceTypeWithHat.Axis;
			}

			public override object DeepClone()
			{
				Axis axis = new Axis();
				axis.ImportVars(this);
				return axis;
			}

			protected override void ImportVars(Element source)
			{
				base.ImportVars(source);
				if (source is Axis axis)
				{
					elementIdentifier = axis.elementIdentifier;
					sourceType = axis.sourceType;
					sourceAxis = axis.sourceAxis;
					sourceAxisRange = axis.sourceAxisRange;
					invert = axis.invert;
					axisDeadZone = axis.axisDeadZone;
					calibrateAxis = axis.calibrateAxis;
					axisZero = axis.axisZero;
					axisMin = axis.axisMin;
					axisMax = axis.axisMax;
					axisInfo = MiscTools.DeepClone(axis.axisInfo);
					sourceButton = axis.sourceButton;
					buttonAxisContribution = axis.buttonAxisContribution;
					sourceHat = axis.sourceHat;
					sourceHatDirection = axis.sourceHatDirection;
					sourceHatRange = axis.sourceHatRange;
					alternateCalibrations = MiscTools.DeepClone(axis.alternateCalibrations);
				}
			}
		}

		private sealed class nPDuUwImOKnGxCIYMwlUzmRwlpCW : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
		{
			private int CibbpvEBcGKDXuccBxQzuqlrwywoA;

			private Axis obXFdBhaRaCwVXGHUfFTMGzKtllo;

			private int XgcvAIROKqEIRQcOcYfPxHUvfKRz;

			public Platform_Linux_Base MxSdcxYNVHVItmpZedLjIoPbpIgR;

			private int ITydIJoMiYVqAyaRDpKwQccOsat;

			private int StFvSNwVHsunGntaweSIDhKdDeQt;

			Axis IEnumerator<Axis>.Current
			{
				[DebuggerHidden]
				get
				{
					return obXFdBhaRaCwVXGHUfFTMGzKtllo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return obXFdBhaRaCwVXGHUfFTMGzKtllo;
				}
			}

			[DebuggerHidden]
			public nPDuUwImOKnGxCIYMwlUzmRwlpCW(int P_0)
			{
				CibbpvEBcGKDXuccBxQzuqlrwywoA = P_0;
				XgcvAIROKqEIRQcOcYfPxHUvfKRz = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int cibbpvEBcGKDXuccBxQzuqlrwywoA = CibbpvEBcGKDXuccBxQzuqlrwywoA;
				Platform_Linux_Base mxSdcxYNVHVItmpZedLjIoPbpIgR = MxSdcxYNVHVItmpZedLjIoPbpIgR;
				switch (cibbpvEBcGKDXuccBxQzuqlrwywoA)
				{
				default:
					return false;
				case 0:
					CibbpvEBcGKDXuccBxQzuqlrwywoA = -1;
					if (mxSdcxYNVHVItmpZedLjIoPbpIgR.elements == null || mxSdcxYNVHVItmpZedLjIoPbpIgR.elements.axes == null)
					{
						return false;
					}
					ITydIJoMiYVqAyaRDpKwQccOsat = mxSdcxYNVHVItmpZedLjIoPbpIgR.elements.axes.Length;
					StFvSNwVHsunGntaweSIDhKdDeQt = 0;
					break;
				case 1:
					CibbpvEBcGKDXuccBxQzuqlrwywoA = -1;
					StFvSNwVHsunGntaweSIDhKdDeQt++;
					break;
				}
				if (StFvSNwVHsunGntaweSIDhKdDeQt < ITydIJoMiYVqAyaRDpKwQccOsat)
				{
					obXFdBhaRaCwVXGHUfFTMGzKtllo = mxSdcxYNVHVItmpZedLjIoPbpIgR.elements.axes[StFvSNwVHsunGntaweSIDhKdDeQt];
					CibbpvEBcGKDXuccBxQzuqlrwywoA = 1;
					return true;
				}
				return false;
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
			IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
			{
				nPDuUwImOKnGxCIYMwlUzmRwlpCW nPDuUwImOKnGxCIYMwlUzmRwlpCW2;
				if (CibbpvEBcGKDXuccBxQzuqlrwywoA == -2 && XgcvAIROKqEIRQcOcYfPxHUvfKRz == Environment.CurrentManagedThreadId)
				{
					CibbpvEBcGKDXuccBxQzuqlrwywoA = 0;
					nPDuUwImOKnGxCIYMwlUzmRwlpCW2 = this;
				}
				else
				{
					nPDuUwImOKnGxCIYMwlUzmRwlpCW2 = new nPDuUwImOKnGxCIYMwlUzmRwlpCW(0);
					nPDuUwImOKnGxCIYMwlUzmRwlpCW2.MxSdcxYNVHVItmpZedLjIoPbpIgR = MxSdcxYNVHVItmpZedLjIoPbpIgR;
				}
				return nPDuUwImOKnGxCIYMwlUzmRwlpCW2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Axis>)this).GetEnumerator();
			}
		}

		private sealed class rqCDVmeztKbOUXhxEapAgRRdodPMc : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
		{
			private int VyjwaYGojmgqfvgLCnANbqHIoUSi;

			private Button VhnMPxYKeAbZjgfjWSynjlpLdzLNA;

			private int MzPXFoyoRDgkhqRGdNQuvnYSRkZU;

			public Platform_Linux_Base vUPZePaRZcbYrqRlVFjbTGrTdxbHA;

			private int pYkUCCvLGtxlohtLNoiIneCBvWf;

			private int cCXFZPYwbwgfbXOMXmjcPesINNHj;

			Button IEnumerator<Button>.Current
			{
				[DebuggerHidden]
				get
				{
					return VhnMPxYKeAbZjgfjWSynjlpLdzLNA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return VhnMPxYKeAbZjgfjWSynjlpLdzLNA;
				}
			}

			[DebuggerHidden]
			public rqCDVmeztKbOUXhxEapAgRRdodPMc(int P_0)
			{
				VyjwaYGojmgqfvgLCnANbqHIoUSi = P_0;
				MzPXFoyoRDgkhqRGdNQuvnYSRkZU = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int vyjwaYGojmgqfvgLCnANbqHIoUSi = VyjwaYGojmgqfvgLCnANbqHIoUSi;
				Platform_Linux_Base platform_Linux_Base = vUPZePaRZcbYrqRlVFjbTGrTdxbHA;
				switch (vyjwaYGojmgqfvgLCnANbqHIoUSi)
				{
				default:
					return false;
				case 0:
					VyjwaYGojmgqfvgLCnANbqHIoUSi = -1;
					if (platform_Linux_Base.elements == null || platform_Linux_Base.elements.buttons == null)
					{
						return false;
					}
					pYkUCCvLGtxlohtLNoiIneCBvWf = platform_Linux_Base.elements.buttons.Length;
					cCXFZPYwbwgfbXOMXmjcPesINNHj = 0;
					break;
				case 1:
					VyjwaYGojmgqfvgLCnANbqHIoUSi = -1;
					cCXFZPYwbwgfbXOMXmjcPesINNHj++;
					break;
				}
				if (cCXFZPYwbwgfbXOMXmjcPesINNHj < pYkUCCvLGtxlohtLNoiIneCBvWf)
				{
					VhnMPxYKeAbZjgfjWSynjlpLdzLNA = platform_Linux_Base.elements.buttons[cCXFZPYwbwgfbXOMXmjcPesINNHj];
					VyjwaYGojmgqfvgLCnANbqHIoUSi = 1;
					return true;
				}
				return false;
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
			IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
			{
				rqCDVmeztKbOUXhxEapAgRRdodPMc rqCDVmeztKbOUXhxEapAgRRdodPMc2;
				if (VyjwaYGojmgqfvgLCnANbqHIoUSi == -2 && MzPXFoyoRDgkhqRGdNQuvnYSRkZU == Environment.CurrentManagedThreadId)
				{
					VyjwaYGojmgqfvgLCnANbqHIoUSi = 0;
					rqCDVmeztKbOUXhxEapAgRRdodPMc2 = this;
				}
				else
				{
					rqCDVmeztKbOUXhxEapAgRRdodPMc2 = new rqCDVmeztKbOUXhxEapAgRRdodPMc(0);
					rqCDVmeztKbOUXhxEapAgRRdodPMc2.vUPZePaRZcbYrqRlVFjbTGrTdxbHA = vUPZePaRZcbYrqRlVFjbTGrTdxbHA;
				}
				return rqCDVmeztKbOUXhxEapAgRRdodPMc2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Button>)this).GetEnumerator();
			}
		}

		public MatchingCriteria matchingCriteria;

		public Elements elements;

		InputPlatform Platform.platform => get_platform();

		bool Platform.hasData => get_hasData();

		bool Platform.disabled => get_disabled();

		bool Platform.isAllowed => get_isAllowed();

		internal Axis[] Axes_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.axes;
			}
		}

		internal Button[] Buttons_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.buttons;
			}
		}

		int Platform.assignedButtonCount => get_assignedButtonCount();

		int Platform.assignedAxisCount => get_assignedAxisCount();

		Elements_Base Platform.elements_base => get_elements_base();

		internal virtual InputPlatform get_platform()
		{
			return InputPlatform.LinuxNative;
		}

		internal virtual bool get_hasData()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			if (!matchingCriteria.hasData)
			{
				return false;
			}
			if (assignedAxisCount == 0 && assignedButtonCount == 0)
			{
				return false;
			}
			return true;
		}

		internal virtual bool get_disabled()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.disabled;
		}

		internal virtual bool get_isAllowed()
		{
			if (!base.isAllowed)
			{
				return false;
			}
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.isAllowed;
		}

		public override IList<Platform> GetVariants()
		{
			return null;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			return false;
		}

		public virtual int get_assignedButtonCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.buttonCount;
		}

		public virtual int get_assignedAxisCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.axisCount;
		}

		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			foreach (Axis item in IterateAxes())
			{
				if (item.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			foreach (Button item2 in IterateButtons())
			{
				if (item2.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[assignedButtonCount];
			axes = new int[assignedAxisCount];
			int num = 0;
			foreach (Button item in IterateButtons())
			{
				buttons[num] = item.elementIdentifier;
				num++;
			}
			num = 0;
			foreach (Axis item2 in IterateAxes())
			{
				axes[num] = item2.elementIdentifier;
				num++;
			}
		}

		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			Axis[] axes_orig = Axes_orig;
			if (axes_orig == null)
			{
				return null;
			}
			AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
				{
					array[i] = AxisCalibrationData.Default;
					array[i].invert = axes_orig[i].invert;
					array[i].deadZone = axes_orig[i].axisDeadZone;
					if (Axes_orig[i].calibrateAxis)
					{
						array[i].zero = axes_orig[i].axisZero;
						array[i].min = axes_orig[i].axisMin;
						array[i].max = axes_orig[i].axisMax;
					}
				}
				else
				{
					if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
					{
						throw new NotImplementedException();
					}
					array[i] = AxisCalibrationData.Default;
				}
				array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
			}
			return array;
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[Axes_orig.Length];
			for (int i = 0; i < Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
				if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
				{
					axisRanges[i] = Axes_orig[i].sourceAxisRange;
					continue;
				}
				if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
				{
					axisRanges[i] = AxisRange.Full;
					continue;
				}
				throw new Exception();
			}
		}

		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = null;
			if (Buttons_orig != null)
			{
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				for (int i = 0; i < Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
				}
			}
		}

		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (elements == null)
			{
				return ControllerElementType.Axis;
			}
			return elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		[IteratorStateMachine(typeof(nPDuUwImOKnGxCIYMwlUzmRwlpCW))]
		internal IEnumerable<Axis> IterateAxes()
		{
			return new nPDuUwImOKnGxCIYMwlUzmRwlpCW(-2)
			{
				MxSdcxYNVHVItmpZedLjIoPbpIgR = this
			};
		}

		[IteratorStateMachine(typeof(rqCDVmeztKbOUXhxEapAgRRdodPMc))]
		internal IEnumerable<Button> IterateButtons()
		{
			return new rqCDVmeztKbOUXhxEapAgRRdodPMc(-2)
			{
				vUPZePaRZcbYrqRlVFjbTGrTdxbHA = this
			};
		}

		internal virtual Elements_Base get_elements_base()
		{
			return elements;
		}

		public override object DeepClone()
		{
			Platform_Linux_Base platform_Linux_Base = new Platform_Linux_Base();
			CopyVars(platform_Linux_Base);
			return platform_Linux_Base;
		}

		internal override void CopyVars(Platform destination)
		{
			if (destination is Platform_Linux_Base platform_Linux_Base)
			{
				platform_Linux_Base.elements = MiscTools.DeepClone(elements);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Platform_Linux : Platform_Linux_Base
	{
		public Platform_Linux_Base[] variants;

		public override IList<Platform> GetVariants()
		{
			return variants;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return true;
			}
			if (base.hasVariants)
			{
				for (int i = 0; i < variants.Length; i++)
				{
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		public override object DeepClone()
		{
			Platform_Linux platform_Linux = new Platform_Linux();
			CopyVars(platform_Linux);
			return platform_Linux;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_Linux platform_Linux)
			{
				platform_Linux.variants = MiscTools.DeepClone(variants);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class Platform_WindowsUWP_Base : Platform
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class MatchingCriteria : MatchingCriteria_Base
		{
			[Serializable]
			public sealed class ElementCount : ElementCount_Base
			{
				public int hatCount;

				public override object DeepClone()
				{
					ElementCount elementCount = new ElementCount();
					DHyZsEQjfQXqCiERWSJlkrWZAVDE(elementCount);
					return elementCount;
				}

				internal void pWBJSgfNsikoSKkwnbEsHYejTpqoA(ElementCount_Base P_0)
				{
					base.DHyZsEQjfQXqCiERWSJlkrWZAVDE(P_0);
					if (P_0 is ElementCount elementCount)
					{
						elementCount.hatCount = hatCount;
					}
				}

				internal bool klFafxakRiORxnUaaQJNqUIqeMFf(BridgedControllerHWInfo P_0)
				{
					if (!base.cubDYXAvXKoMbRtseYFVkoMtvxhf(P_0))
					{
						return false;
					}
					if (hatCount >= 0)
					{
						return hatCount == P_0.hardwareHatCount;
					}
					return true;
				}
			}

			public int hatCount;

			public ElementCount[] alternateElementCounts;

			public bool manufacturer_useRegex;

			public bool productName_useRegex;

			public string[] manufacturer;

			public string[] productName;

			public string[] productGUID;

			public DeviceType deviceType;

			bool MatchingCriteria_Base.hasData => get_hasData();

			bool MatchingCriteria_Base.isAllowed => get_isAllowed();

			int MatchingCriteria_Base.alternateElementCount => get_alternateElementCount();

			internal bool get_hasData()
			{
				if (disabled)
				{
					return false;
				}
				if (productGUID != null && productGUID.Length != 0)
				{
					return true;
				}
				if (productName != null && productName.Length != 0)
				{
					return true;
				}
				return false;
			}

			internal bool get_isAllowed()
			{
				if (!base.isAllowed)
				{
					return false;
				}
				return true;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
				{
					return true;
				}
				if (!base.Matches(bridgedControllerHWInfo, strictMatch))
				{
					return false;
				}
				if (deviceType != (DeviceType)bridgedControllerHWInfo.deviceType)
				{
					return false;
				}
				if (!HasProductName() && (productGUID == null || productGUID.Length == 0))
				{
					return true;
				}
				if (strictMatch)
				{
					if (PidVid.ArrayContains(productGUID, ref bridgedControllerHWInfo.hw_pidVid))
					{
						if (!ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
						{
							return true;
						}
						if (productName == null || productName.Length == 0)
						{
							return true;
						}
					}
					if (!AnyNameMatches(bridgedControllerHWInfo))
					{
						return false;
					}
					return true;
				}
				return AnyNameMatches(bridgedControllerHWInfo);
			}

			internal int get_alternateElementCount()
			{
				if (alternateElementCounts == null)
				{
					return 0;
				}
				return alternateElementCounts.Length;
			}

			internal override ElementCount_Base GetAlternateElementCount(int index)
			{
				if (alternateElementCounts == null || index < 0 || index >= alternateElementCounts.Length)
				{
					return null;
				}
				return alternateElementCounts[index];
			}

			internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
			{
				if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
				{
					return false;
				}
				if (alternateMatched)
				{
					return true;
				}
				if (hatCount >= 0)
				{
					return bridgedControllerHWInfo.hardwareHatCount == hatCount;
				}
				return true;
			}

			private bool AnyNameMatches(BridgedControllerHWInfo bridgedControllerHWInfo)
			{
				if (NameMatches(bridgedControllerHWInfo.hw_productName, productName, productName_useRegex))
				{
					return true;
				}
				return false;
			}

			private bool NameMatches(string name, string[] names, bool useRegex)
			{
				if (string.IsNullOrEmpty(name) || names == null)
				{
					return false;
				}
				string searchIn = name.Trim();
				for (int i = 0; i < names.Length; i++)
				{
					if (!string.IsNullOrEmpty(names[i]) && MatchingCriteria_Base.StringMatches(searchIn, names[i], useRegex))
					{
						return true;
					}
				}
				return false;
			}

			private bool HasProductName()
			{
				if (productName == null)
				{
					return false;
				}
				for (int i = 0; i < productName.Length; i++)
				{
					if (!string.IsNullOrEmpty(productName[i]))
					{
						return true;
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			internal override void CopyVars(MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				if (destination is MatchingCriteria matchingCriteria)
				{
					matchingCriteria.hatCount = hatCount;
					matchingCriteria.manufacturer_useRegex = manufacturer_useRegex;
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
					matchingCriteria.deviceType = deviceType;
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Elements : Elements_Base
		{
			private sealed class roWNpmoDhqkjlAejhKUQyIFGcilCA : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int kUJtUtocSVNvSBmxkngzfPYzNNei;

				private Axis xrhBlgAXdaqZKKSVNoiEizBxtoPsA;

				private int sXmffEaWsuLhGPdSkhHOMHVHYjqK;

				public Elements ofIupVsrhHqmbysoEfECIgACpMhIb;

				private int nVtVoQUIieElANRBYctZdhUpqSoGA;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return xrhBlgAXdaqZKKSVNoiEizBxtoPsA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return xrhBlgAXdaqZKKSVNoiEizBxtoPsA;
					}
				}

				[DebuggerHidden]
				public roWNpmoDhqkjlAejhKUQyIFGcilCA(int P_0)
				{
					kUJtUtocSVNvSBmxkngzfPYzNNei = P_0;
					sXmffEaWsuLhGPdSkhHOMHVHYjqK = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int num = kUJtUtocSVNvSBmxkngzfPYzNNei;
					Elements elements = ofIupVsrhHqmbysoEfECIgACpMhIb;
					switch (num)
					{
					default:
						return false;
					case 0:
						kUJtUtocSVNvSBmxkngzfPYzNNei = -1;
						if (elements.axes == null)
						{
							return false;
						}
						nVtVoQUIieElANRBYctZdhUpqSoGA = 0;
						break;
					case 1:
						kUJtUtocSVNvSBmxkngzfPYzNNei = -1;
						nVtVoQUIieElANRBYctZdhUpqSoGA++;
						break;
					}
					if (nVtVoQUIieElANRBYctZdhUpqSoGA < elements.axes.Length)
					{
						xrhBlgAXdaqZKKSVNoiEizBxtoPsA = elements.axes[nVtVoQUIieElANRBYctZdhUpqSoGA];
						kUJtUtocSVNvSBmxkngzfPYzNNei = 1;
						return true;
					}
					return false;
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					roWNpmoDhqkjlAejhKUQyIFGcilCA roWNpmoDhqkjlAejhKUQyIFGcilCA2;
					if (kUJtUtocSVNvSBmxkngzfPYzNNei == -2 && sXmffEaWsuLhGPdSkhHOMHVHYjqK == Environment.CurrentManagedThreadId)
					{
						kUJtUtocSVNvSBmxkngzfPYzNNei = 0;
						roWNpmoDhqkjlAejhKUQyIFGcilCA2 = this;
					}
					else
					{
						roWNpmoDhqkjlAejhKUQyIFGcilCA2 = new roWNpmoDhqkjlAejhKUQyIFGcilCA(0);
						roWNpmoDhqkjlAejhKUQyIFGcilCA2.ofIupVsrhHqmbysoEfECIgACpMhIb = ofIupVsrhHqmbysoEfECIgACpMhIb;
					}
					return roWNpmoDhqkjlAejhKUQyIFGcilCA2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class YrFqavMEdIebNnHhpusWFTjenKDX : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int FyCThHmJOYThPEkcabcqmdBEPiyc;

				private Button NhTomYDwVYzmqKGTfOPJQLOHgjlc;

				private int piUXxYTMvnNeRyqRBaiCJpdAgokLA;

				public Elements sDMjZyBSkEqHaBCrJoJojnbOWcVxA;

				private int aSXRSTZAmBDqeFDazYjDoLfrbTMPA;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return NhTomYDwVYzmqKGTfOPJQLOHgjlc;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return NhTomYDwVYzmqKGTfOPJQLOHgjlc;
					}
				}

				[DebuggerHidden]
				public YrFqavMEdIebNnHhpusWFTjenKDX(int P_0)
				{
					FyCThHmJOYThPEkcabcqmdBEPiyc = P_0;
					piUXxYTMvnNeRyqRBaiCJpdAgokLA = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int fyCThHmJOYThPEkcabcqmdBEPiyc = FyCThHmJOYThPEkcabcqmdBEPiyc;
					Elements elements = sDMjZyBSkEqHaBCrJoJojnbOWcVxA;
					switch (fyCThHmJOYThPEkcabcqmdBEPiyc)
					{
					default:
						return false;
					case 0:
						FyCThHmJOYThPEkcabcqmdBEPiyc = -1;
						if (elements.buttons == null)
						{
							return false;
						}
						aSXRSTZAmBDqeFDazYjDoLfrbTMPA = 0;
						break;
					case 1:
						FyCThHmJOYThPEkcabcqmdBEPiyc = -1;
						aSXRSTZAmBDqeFDazYjDoLfrbTMPA++;
						break;
					}
					if (aSXRSTZAmBDqeFDazYjDoLfrbTMPA < elements.buttons.Length)
					{
						NhTomYDwVYzmqKGTfOPJQLOHgjlc = elements.buttons[aSXRSTZAmBDqeFDazYjDoLfrbTMPA];
						FyCThHmJOYThPEkcabcqmdBEPiyc = 1;
						return true;
					}
					return false;
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					YrFqavMEdIebNnHhpusWFTjenKDX yrFqavMEdIebNnHhpusWFTjenKDX;
					if (FyCThHmJOYThPEkcabcqmdBEPiyc == -2 && piUXxYTMvnNeRyqRBaiCJpdAgokLA == Environment.CurrentManagedThreadId)
					{
						FyCThHmJOYThPEkcabcqmdBEPiyc = 0;
						yrFqavMEdIebNnHhpusWFTjenKDX = this;
					}
					else
					{
						yrFqavMEdIebNnHhpusWFTjenKDX = new YrFqavMEdIebNnHhpusWFTjenKDX(0);
						yrFqavMEdIebNnHhpusWFTjenKDX.sDMjZyBSkEqHaBCrJoJojnbOWcVxA = sDMjZyBSkEqHaBCrJoJojnbOWcVxA;
					}
					return yrFqavMEdIebNnHhpusWFTjenKDX;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public Axis[] axes;

			public Button[] buttons;

			int Elements_Base.buttonCount => get_buttonCount();

			int Elements_Base.axisCount => get_axisCount();

			internal IEnumerable<Axis> Axes
			{
				[IteratorStateMachine(typeof(roWNpmoDhqkjlAejhKUQyIFGcilCA))]
				get
				{
					return new roWNpmoDhqkjlAejhKUQyIFGcilCA(-2)
					{
						ofIupVsrhHqmbysoEfECIgACpMhIb = this
					};
				}
			}

			internal IEnumerable<Button> Buttons
			{
				[IteratorStateMachine(typeof(YrFqavMEdIebNnHhpusWFTjenKDX))]
				get
				{
					return new YrFqavMEdIebNnHhpusWFTjenKDX(-2)
					{
						sDMjZyBSkEqHaBCrJoJojnbOWcVxA = this
					};
				}
			}

			public int get_buttonCount()
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}

			public int get_axisCount()
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}

			internal Axis GetAxis(int axisIndex)
			{
				if (axes == null || axisIndex < 0 || axisIndex >= axes.Length)
				{
					return null;
				}
				return axes[axisIndex];
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Axis;
					}
				}
				for (int j = 0; j < buttonCount; j++)
				{
					if (buttons[j].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Button;
					}
				}
				return elementIdentifier.elementType;
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier != elementIdentifier.get_id())
					{
						continue;
					}
					switch (axes[i].sourceType)
					{
					case HardwareElementSourceTypeWithHat.Axis:
					case HardwareElementSourceTypeWithHat.Custom:
						axisRange = axes[i].sourceAxisRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					case HardwareElementSourceTypeWithHat.Button:
						axisRange = AxisRange.Positive;
						return true;
					case HardwareElementSourceTypeWithHat.Hat:
						axisRange = axes[i].sourceHatRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					default:
						throw new NotImplementedException();
					}
				}
				axisRange = AxisRange.Full;
				return false;
			}

			public override object DeepClone()
			{
				Elements elements = new Elements();
				CopyVars(elements);
				return elements;
			}

			internal override void CopyVars(Elements_Base destination)
			{
				base.CopyVars(destination);
				if (destination is Elements elements)
				{
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Element : IDeepCloneable
		{
			public abstract object DeepClone();

			protected virtual void ImportVars(Element source)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Button : Element
		{
			public int elementIdentifier;

			public HardwareElementSourceTypeWithHat sourceType;

			public int sourceButton;

			public int sourceAxis;

			public Pole sourceAxisPole;

			public float axisDeadZone;

			public int sourceHat;

			public HatType sourceHatType;

			public HatDirection sourceHatDirection;

			public bool requireMultipleButtons;

			public int[] requiredButtons;

			public bool ignoreIfButtonsActive;

			public int[] ignoreIfButtonsActiveButtons;

			public HardwareButtonInfo buttonInfo;

			public Button()
			{
				sourceType = HardwareElementSourceTypeWithHat.Button;
			}

			public override object DeepClone()
			{
				Button button = new Button();
				button.ImportVars(this);
				return button;
			}

			protected override void ImportVars(Element source)
			{
				base.ImportVars(source);
				if (source is Button button)
				{
					elementIdentifier = button.elementIdentifier;
					sourceType = button.sourceType;
					sourceButton = button.sourceButton;
					sourceAxis = button.sourceAxis;
					sourceAxisPole = button.sourceAxisPole;
					axisDeadZone = button.axisDeadZone;
					sourceHat = button.sourceHat;
					sourceHatType = button.sourceHatType;
					sourceHatDirection = button.sourceHatDirection;
					requireMultipleButtons = button.requireMultipleButtons;
					requiredButtons = ArrayTools.ShallowCopy(button.requiredButtons);
					ignoreIfButtonsActive = button.ignoreIfButtonsActive;
					ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(button.ignoreIfButtonsActiveButtons);
					buttonInfo = MiscTools.DeepClone(button.buttonInfo);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Axis : Element
		{
			public int elementIdentifier;

			public HardwareElementSourceTypeWithHat sourceType;

			public int sourceAxis;

			public AxisRange sourceAxisRange;

			public bool invert;

			public float axisDeadZone;

			public bool calibrateAxis;

			public float axisZero;

			public float axisMin;

			public float axisMax;

			public AxisCalibrationInfoEntry[] alternateCalibrations;

			public HardwareAxisInfo axisInfo;

			public int sourceButton;

			public Pole buttonAxisContribution;

			public int sourceHat;

			public AxisDirection sourceHatDirection;

			public AxisRange sourceHatRange;

			public Axis()
			{
				sourceType = HardwareElementSourceTypeWithHat.Axis;
			}

			public override object DeepClone()
			{
				Axis axis = new Axis();
				axis.ImportVars(this);
				return axis;
			}

			protected override void ImportVars(Element source)
			{
				base.ImportVars(source);
				if (source is Axis axis)
				{
					elementIdentifier = axis.elementIdentifier;
					sourceType = axis.sourceType;
					sourceAxis = axis.sourceAxis;
					sourceAxisRange = axis.sourceAxisRange;
					invert = axis.invert;
					axisDeadZone = axis.axisDeadZone;
					calibrateAxis = axis.calibrateAxis;
					axisZero = axis.axisZero;
					axisMin = axis.axisMin;
					axisMax = axis.axisMax;
					axisInfo = MiscTools.DeepClone(axis.axisInfo);
					sourceButton = axis.sourceButton;
					buttonAxisContribution = axis.buttonAxisContribution;
					sourceHat = axis.sourceHat;
					sourceHatDirection = axis.sourceHatDirection;
					sourceHatRange = axis.sourceHatRange;
					alternateCalibrations = MiscTools.DeepClone(axis.alternateCalibrations);
				}
			}
		}

		public enum DeviceType
		{
			HIDJoystick = 0,
			WGIGamepad = 1
		}

		private sealed class lsiGnyXPAeQrLoFmVcumKkoENncF : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
		{
			private int mVJqygtoQMGLRdfRRWFxyjrPawEbA;

			private Axis TTMDZiYzDZBtGWpDwIHtMBzyMpxe;

			private int HWHPAGrxcxSexKocOyoEbDOlsWMj;

			public Platform_WindowsUWP_Base BHVGKtbaaNvAsqsgiWDCfbgbktyz;

			private int okpcgPuZzYCvNvselouVACljQoQh;

			private int pXdhlEMTarCYRSskbFXKhzpZcOcE;

			Axis IEnumerator<Axis>.Current
			{
				[DebuggerHidden]
				get
				{
					return TTMDZiYzDZBtGWpDwIHtMBzyMpxe;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return TTMDZiYzDZBtGWpDwIHtMBzyMpxe;
				}
			}

			[DebuggerHidden]
			public lsiGnyXPAeQrLoFmVcumKkoENncF(int P_0)
			{
				mVJqygtoQMGLRdfRRWFxyjrPawEbA = P_0;
				HWHPAGrxcxSexKocOyoEbDOlsWMj = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = mVJqygtoQMGLRdfRRWFxyjrPawEbA;
				Platform_WindowsUWP_Base bHVGKtbaaNvAsqsgiWDCfbgbktyz = BHVGKtbaaNvAsqsgiWDCfbgbktyz;
				switch (num)
				{
				default:
					return false;
				case 0:
					mVJqygtoQMGLRdfRRWFxyjrPawEbA = -1;
					if (bHVGKtbaaNvAsqsgiWDCfbgbktyz.elements == null || bHVGKtbaaNvAsqsgiWDCfbgbktyz.elements.axes == null)
					{
						return false;
					}
					okpcgPuZzYCvNvselouVACljQoQh = bHVGKtbaaNvAsqsgiWDCfbgbktyz.elements.axes.Length;
					pXdhlEMTarCYRSskbFXKhzpZcOcE = 0;
					break;
				case 1:
					mVJqygtoQMGLRdfRRWFxyjrPawEbA = -1;
					pXdhlEMTarCYRSskbFXKhzpZcOcE++;
					break;
				}
				if (pXdhlEMTarCYRSskbFXKhzpZcOcE < okpcgPuZzYCvNvselouVACljQoQh)
				{
					TTMDZiYzDZBtGWpDwIHtMBzyMpxe = bHVGKtbaaNvAsqsgiWDCfbgbktyz.elements.axes[pXdhlEMTarCYRSskbFXKhzpZcOcE];
					mVJqygtoQMGLRdfRRWFxyjrPawEbA = 1;
					return true;
				}
				return false;
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
			IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
			{
				lsiGnyXPAeQrLoFmVcumKkoENncF lsiGnyXPAeQrLoFmVcumKkoENncF2;
				if (mVJqygtoQMGLRdfRRWFxyjrPawEbA == -2 && HWHPAGrxcxSexKocOyoEbDOlsWMj == Environment.CurrentManagedThreadId)
				{
					mVJqygtoQMGLRdfRRWFxyjrPawEbA = 0;
					lsiGnyXPAeQrLoFmVcumKkoENncF2 = this;
				}
				else
				{
					lsiGnyXPAeQrLoFmVcumKkoENncF2 = new lsiGnyXPAeQrLoFmVcumKkoENncF(0);
					lsiGnyXPAeQrLoFmVcumKkoENncF2.BHVGKtbaaNvAsqsgiWDCfbgbktyz = BHVGKtbaaNvAsqsgiWDCfbgbktyz;
				}
				return lsiGnyXPAeQrLoFmVcumKkoENncF2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Axis>)this).GetEnumerator();
			}
		}

		private sealed class nnRszSbZdEfMMqyVVJeFiYPEbFni : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
		{
			private int FbDcqNgFqXvHzapPBBsVVVCPvslbA;

			private Button bpNzcZBttEZXqzydRZIHrSJXuAef;

			private int hZBOPXKvdGKBehGKOBrJIhrZGWuI;

			public Platform_WindowsUWP_Base MehLycNGVbffLAFugiwBazyZqcrO;

			private int VYsFifTdCQCEFAeHnXSbLjHgVirX;

			private int jXVBCjYDENBAuaunSlyiTrSYySufA;

			Button IEnumerator<Button>.Current
			{
				[DebuggerHidden]
				get
				{
					return bpNzcZBttEZXqzydRZIHrSJXuAef;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return bpNzcZBttEZXqzydRZIHrSJXuAef;
				}
			}

			[DebuggerHidden]
			public nnRszSbZdEfMMqyVVJeFiYPEbFni(int P_0)
			{
				FbDcqNgFqXvHzapPBBsVVVCPvslbA = P_0;
				hZBOPXKvdGKBehGKOBrJIhrZGWuI = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int fbDcqNgFqXvHzapPBBsVVVCPvslbA = FbDcqNgFqXvHzapPBBsVVVCPvslbA;
				Platform_WindowsUWP_Base mehLycNGVbffLAFugiwBazyZqcrO = MehLycNGVbffLAFugiwBazyZqcrO;
				switch (fbDcqNgFqXvHzapPBBsVVVCPvslbA)
				{
				default:
					return false;
				case 0:
					FbDcqNgFqXvHzapPBBsVVVCPvslbA = -1;
					if (mehLycNGVbffLAFugiwBazyZqcrO.elements == null || mehLycNGVbffLAFugiwBazyZqcrO.elements.buttons == null)
					{
						return false;
					}
					VYsFifTdCQCEFAeHnXSbLjHgVirX = mehLycNGVbffLAFugiwBazyZqcrO.elements.buttons.Length;
					jXVBCjYDENBAuaunSlyiTrSYySufA = 0;
					break;
				case 1:
					FbDcqNgFqXvHzapPBBsVVVCPvslbA = -1;
					jXVBCjYDENBAuaunSlyiTrSYySufA++;
					break;
				}
				if (jXVBCjYDENBAuaunSlyiTrSYySufA < VYsFifTdCQCEFAeHnXSbLjHgVirX)
				{
					bpNzcZBttEZXqzydRZIHrSJXuAef = mehLycNGVbffLAFugiwBazyZqcrO.elements.buttons[jXVBCjYDENBAuaunSlyiTrSYySufA];
					FbDcqNgFqXvHzapPBBsVVVCPvslbA = 1;
					return true;
				}
				return false;
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
			IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
			{
				nnRszSbZdEfMMqyVVJeFiYPEbFni nnRszSbZdEfMMqyVVJeFiYPEbFni2;
				if (FbDcqNgFqXvHzapPBBsVVVCPvslbA == -2 && hZBOPXKvdGKBehGKOBrJIhrZGWuI == Environment.CurrentManagedThreadId)
				{
					FbDcqNgFqXvHzapPBBsVVVCPvslbA = 0;
					nnRszSbZdEfMMqyVVJeFiYPEbFni2 = this;
				}
				else
				{
					nnRszSbZdEfMMqyVVJeFiYPEbFni2 = new nnRszSbZdEfMMqyVVJeFiYPEbFni(0);
					nnRszSbZdEfMMqyVVJeFiYPEbFni2.MehLycNGVbffLAFugiwBazyZqcrO = MehLycNGVbffLAFugiwBazyZqcrO;
				}
				return nnRszSbZdEfMMqyVVJeFiYPEbFni2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Button>)this).GetEnumerator();
			}
		}

		public MatchingCriteria matchingCriteria;

		public Elements elements;

		InputPlatform Platform.platform => get_platform();

		bool Platform.hasData => get_hasData();

		bool Platform.disabled => get_disabled();

		bool Platform.isAllowed => get_isAllowed();

		internal Axis[] Axes_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.axes;
			}
		}

		internal Button[] Buttons_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.buttons;
			}
		}

		int Platform.assignedButtonCount => get_assignedButtonCount();

		int Platform.assignedAxisCount => get_assignedAxisCount();

		Elements_Base Platform.elements_base => get_elements_base();

		internal virtual InputPlatform get_platform()
		{
			return InputPlatform.WindowsUWP;
		}

		internal virtual bool get_hasData()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			if (!matchingCriteria.hasData)
			{
				return false;
			}
			if (assignedAxisCount == 0 && assignedButtonCount == 0)
			{
				return false;
			}
			return true;
		}

		internal virtual bool get_disabled()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.disabled;
		}

		internal virtual bool get_isAllowed()
		{
			if (!base.isAllowed)
			{
				return false;
			}
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.isAllowed;
		}

		public override IList<Platform> GetVariants()
		{
			return null;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			return false;
		}

		public virtual int get_assignedButtonCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.buttonCount;
		}

		public virtual int get_assignedAxisCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.axisCount;
		}

		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			foreach (Axis item in IterateAxes())
			{
				if (item.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			foreach (Button item2 in IterateButtons())
			{
				if (item2.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[assignedButtonCount];
			axes = new int[assignedAxisCount];
			int num = 0;
			foreach (Button item in IterateButtons())
			{
				buttons[num] = item.elementIdentifier;
				num++;
			}
			num = 0;
			foreach (Axis item2 in IterateAxes())
			{
				axes[num] = item2.elementIdentifier;
				num++;
			}
		}

		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			Axis[] axes_orig = Axes_orig;
			if (axes_orig == null)
			{
				return null;
			}
			AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
				{
					array[i] = AxisCalibrationData.Default;
					array[i].invert = axes_orig[i].invert;
					array[i].deadZone = axes_orig[i].axisDeadZone;
					if (Axes_orig[i].calibrateAxis)
					{
						array[i].zero = axes_orig[i].axisZero;
						array[i].min = axes_orig[i].axisMin;
						array[i].max = axes_orig[i].axisMax;
					}
				}
				else
				{
					if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
					{
						throw new NotImplementedException();
					}
					array[i] = AxisCalibrationData.Default;
				}
				array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
			}
			return array;
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[Axes_orig.Length];
			for (int i = 0; i < Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
				if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
				{
					axisRanges[i] = Axes_orig[i].sourceAxisRange;
					continue;
				}
				if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
				{
					axisRanges[i] = AxisRange.Full;
					continue;
				}
				throw new Exception();
			}
		}

		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = null;
			if (Buttons_orig != null)
			{
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				for (int i = 0; i < Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
				}
			}
		}

		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (elements == null)
			{
				return ControllerElementType.Axis;
			}
			return elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		[IteratorStateMachine(typeof(lsiGnyXPAeQrLoFmVcumKkoENncF))]
		internal IEnumerable<Axis> IterateAxes()
		{
			return new lsiGnyXPAeQrLoFmVcumKkoENncF(-2)
			{
				BHVGKtbaaNvAsqsgiWDCfbgbktyz = this
			};
		}

		[IteratorStateMachine(typeof(nnRszSbZdEfMMqyVVJeFiYPEbFni))]
		internal IEnumerable<Button> IterateButtons()
		{
			return new nnRszSbZdEfMMqyVVJeFiYPEbFni(-2)
			{
				MehLycNGVbffLAFugiwBazyZqcrO = this
			};
		}

		internal virtual Elements_Base get_elements_base()
		{
			return elements;
		}

		public override object DeepClone()
		{
			Platform_WindowsUWP_Base platform_WindowsUWP_Base = new Platform_WindowsUWP_Base();
			CopyVars(platform_WindowsUWP_Base);
			return platform_WindowsUWP_Base;
		}

		internal override void CopyVars(Platform destination)
		{
			if (destination is Platform_WindowsUWP_Base platform_WindowsUWP_Base)
			{
				platform_WindowsUWP_Base.elements = MiscTools.DeepClone(elements);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Platform_WindowsUWP : Platform_WindowsUWP_Base
	{
		public Platform_WindowsUWP_Base[] variants;

		public override IList<Platform> GetVariants()
		{
			return variants;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return true;
			}
			if (base.hasVariants)
			{
				for (int i = 0; i < variants.Length; i++)
				{
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		public override object DeepClone()
		{
			Platform_WindowsUWP platform_WindowsUWP = new Platform_WindowsUWP();
			CopyVars(platform_WindowsUWP);
			return platform_WindowsUWP;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_WindowsUWP platform_WindowsUWP)
			{
				platform_WindowsUWP.variants = MiscTools.DeepClone(variants);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class Platform_Fallback_Base : Platform
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class MatchingCriteria : MatchingCriteria_Base
		{
			public bool alwaysMatch;

			public bool productName_useRegex;

			public string[] productName;

			public bool matchUnityVersion;

			public string matchUnityVersion_min;

			public string matchUnityVersion_max;

			public bool matchSysVersion;

			public string matchSysVersion_min;

			public string matchSysVersion_max;

			bool MatchingCriteria_Base.hasData => get_hasData();

			bool MatchingCriteria_Base.isAllowed => get_isAllowed();

			int MatchingCriteria_Base.alternateElementCount => get_alternateElementCount();

			internal bool get_hasData()
			{
				if (disabled)
				{
					return false;
				}
				if (alwaysMatch)
				{
					return true;
				}
				if (productName != null && productName.Length != 0)
				{
					return true;
				}
				return false;
			}

			internal bool get_isAllowed()
			{
				if (!base.isAllowed)
				{
					return false;
				}
				if (matchUnityVersion && !UnityTools.IsUnityVersionInRange(matchUnityVersion_min, matchUnityVersion_max))
				{
					return false;
				}
				if (matchSysVersion && !PlatformTools.IsSysVersionInRange(matchSysVersion_min, matchSysVersion_max))
				{
					return false;
				}
				return true;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
				{
					return true;
				}
				if (!isAllowed)
				{
					return false;
				}
				if (alwaysMatch)
				{
					return true;
				}
				if (!base.Matches(bridgedControllerHWInfo, strictMatch))
				{
					return false;
				}
				string text = bridgedControllerHWInfo.hw_productName;
				if (text == null)
				{
					text = string.Empty;
				}
				text = text.Trim();
				if (productName != null)
				{
					for (int i = 0; i < productName.Length; i++)
					{
						string searchFor = productName[i];
						if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
						{
							return true;
						}
					}
				}
				return false;
			}

			internal int get_alternateElementCount()
			{
				return 0;
			}

			internal override ElementCount_Base GetAlternateElementCount(int index)
			{
				return null;
			}

			internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
			{
				return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched);
			}

			public override object DeepClone()
			{
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			internal override void CopyVars(MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				if (destination is MatchingCriteria matchingCriteria)
				{
					matchingCriteria.alwaysMatch = alwaysMatch;
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					matchingCriteria.matchUnityVersion = matchUnityVersion;
					matchingCriteria.matchUnityVersion_min = matchUnityVersion_min;
					matchingCriteria.matchUnityVersion_max = matchUnityVersion_max;
					matchingCriteria.matchSysVersion = matchSysVersion;
					matchingCriteria.matchSysVersion_min = matchSysVersion_min;
					matchingCriteria.matchSysVersion_max = matchSysVersion_max;
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Elements : Elements_Base
		{
			public Axis[] axes;

			public Button[] buttons;

			int Elements_Base.buttonCount => get_buttonCount();

			int Elements_Base.axisCount => get_axisCount();

			public int get_buttonCount()
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}

			public int get_axisCount()
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Axis;
					}
				}
				for (int j = 0; j < buttonCount; j++)
				{
					if (buttons[j].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Button;
					}
				}
				return elementIdentifier.elementType;
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier != elementIdentifier.get_id())
					{
						continue;
					}
					switch (axes[i].sourceType)
					{
					case HardwareElementSourceTypeWithHat.Axis:
					case HardwareElementSourceTypeWithHat.Custom:
						axisRange = axes[i].sourceAxisRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					case HardwareElementSourceTypeWithHat.Button:
						axisRange = AxisRange.Positive;
						return true;
					default:
						throw new NotImplementedException();
					}
				}
				axisRange = AxisRange.Full;
				return false;
			}

			public override object DeepClone()
			{
				Elements elements = new Elements();
				CopyVars(elements);
				return elements;
			}

			internal override void CopyVars(Elements_Base destination)
			{
				base.CopyVars(destination);
				if (destination is Elements elements)
				{
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class CustomCalculationSourceData : IDeepCloneable
		{
			public int sourceType;

			public int sourceElement;

			public AxisRange sourceAxisRange;

			public float deadzone;

			public bool invert;

			public object DeepClone()
			{
				return new CustomCalculationSourceData
				{
					sourceType = sourceType,
					sourceElement = sourceElement,
					sourceAxisRange = sourceAxisRange,
					deadzone = deadzone,
					invert = invert
				};
			}

			object IDeepCloneable.DeepClone()
			{
				//ILSpy generated this explicit interface implementation from .override directive in DeepClone
				return this.DeepClone();
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Element : IDeepCloneable
		{
			public int elementIdentifier;

			public HardwareElementSourceTypeWithHat sourceType;

			public UnityAxis sourceAxis;

			public float axisDeadZone;

			public UnityButton sourceButton;

			public KeyCode sourceKeyCode;

			public CustomCalculation customCalculation;

			public CustomCalculationSourceData[] customCalculationSourceData;

			public abstract object DeepClone();

			internal virtual void CopyVars(Element destination)
			{
				if (destination != null)
				{
					destination.elementIdentifier = elementIdentifier;
					destination.sourceType = sourceType;
					destination.sourceAxis = sourceAxis;
					destination.axisDeadZone = axisDeadZone;
					destination.sourceButton = sourceButton;
					destination.sourceKeyCode = sourceKeyCode;
					destination.customCalculation = customCalculation;
					destination.customCalculationSourceData = ArrayTools.DeepClone(customCalculationSourceData);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Button : Element
		{
			public Pole sourceAxisPole;

			public UnityAxis unityHat_sourceAxis1;

			public UnityAxis unityHat_sourceAxis2;

			public Vector2 unityHat_isActiveAxisValues1;

			public Vector2 unityHat_isActiveAxisValues2;

			public Vector2 unityHat_isActiveAxisValues3;

			public Vector2 unityHat_zeroValues;

			public bool unityHat_checkNeverPressed;

			public Vector2 unityHat_neverPressedZeroValues;

			public bool requireMultipleButtons;

			public UnityButton[] requiredButtons;

			public bool ignoreIfButtonsActive;

			public UnityButton[] ignoreIfButtonsActiveButtons;

			public HardwareButtonInfo buttonInfo;

			public override object DeepClone()
			{
				Button button = new Button();
				CopyVars(button);
				return button;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				if (destination is Button button)
				{
					button.sourceAxisPole = sourceAxisPole;
					button.unityHat_sourceAxis1 = unityHat_sourceAxis1;
					button.unityHat_sourceAxis2 = unityHat_sourceAxis2;
					button.unityHat_isActiveAxisValues1 = unityHat_isActiveAxisValues1;
					button.unityHat_isActiveAxisValues2 = unityHat_isActiveAxisValues2;
					button.unityHat_isActiveAxisValues3 = unityHat_isActiveAxisValues3;
					button.unityHat_zeroValues = unityHat_zeroValues;
					button.unityHat_checkNeverPressed = unityHat_checkNeverPressed;
					button.unityHat_neverPressedZeroValues = unityHat_neverPressedZeroValues;
					button.requireMultipleButtons = requireMultipleButtons;
					button.requiredButtons = ArrayTools.ShallowCopy(requiredButtons);
					button.ignoreIfButtonsActive = ignoreIfButtonsActive;
					button.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(ignoreIfButtonsActiveButtons);
					button.buttonInfo = MiscTools.DeepClone(buttonInfo);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Axis : Element
		{
			public bool invert;

			public AxisRange sourceAxisRange;

			public Pole buttonAxisContribution;

			public bool calibrateAxis;

			public float axisZero;

			public float axisMin;

			public float axisMax;

			public AxisCalibrationInfoEntry[] alternateCalibrations;

			public HardwareAxisInfo axisInfo;

			public override object DeepClone()
			{
				Axis axis = new Axis();
				CopyVars(axis);
				return axis;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				if (destination is Axis axis)
				{
					axis.invert = invert;
					axis.sourceAxisRange = sourceAxisRange;
					axis.buttonAxisContribution = buttonAxisContribution;
					axis.calibrateAxis = calibrateAxis;
					axis.axisZero = axisZero;
					axis.axisMin = axisMin;
					axis.axisMax = axisMax;
					axis.axisInfo = MiscTools.DeepClone(axisInfo);
					axis.alternateCalibrations = MiscTools.DeepClone(alternateCalibrations);
				}
			}
		}

		private sealed class ybWdpGdeKMfyKHujxDRJShIGkAIs : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
		{
			private int AZBaSkJvWwNaiPaHPPZuLJgiXSYB;

			private Axis OQUYbvKdWgSxcuGPaSrvwSjkmih;

			private int OIoUwWjHPOVhNSxCijVGIGDPQUup;

			public Platform_Fallback_Base XsGPIGWFzwDPvlcVNRhBfIpGcxbk;

			private int aWfGwoerXZkAbHflBYyNjVEOqklSA;

			Axis IEnumerator<Axis>.Current
			{
				[DebuggerHidden]
				get
				{
					return OQUYbvKdWgSxcuGPaSrvwSjkmih;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return OQUYbvKdWgSxcuGPaSrvwSjkmih;
				}
			}

			[DebuggerHidden]
			public ybWdpGdeKMfyKHujxDRJShIGkAIs(int P_0)
			{
				AZBaSkJvWwNaiPaHPPZuLJgiXSYB = P_0;
				OIoUwWjHPOVhNSxCijVGIGDPQUup = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int aZBaSkJvWwNaiPaHPPZuLJgiXSYB = AZBaSkJvWwNaiPaHPPZuLJgiXSYB;
				Platform_Fallback_Base xsGPIGWFzwDPvlcVNRhBfIpGcxbk = XsGPIGWFzwDPvlcVNRhBfIpGcxbk;
				switch (aZBaSkJvWwNaiPaHPPZuLJgiXSYB)
				{
				default:
					return false;
				case 0:
					AZBaSkJvWwNaiPaHPPZuLJgiXSYB = -1;
					if (xsGPIGWFzwDPvlcVNRhBfIpGcxbk.elements == null || xsGPIGWFzwDPvlcVNRhBfIpGcxbk.elements.axes == null)
					{
						return false;
					}
					aWfGwoerXZkAbHflBYyNjVEOqklSA = 0;
					break;
				case 1:
					AZBaSkJvWwNaiPaHPPZuLJgiXSYB = -1;
					aWfGwoerXZkAbHflBYyNjVEOqklSA++;
					break;
				}
				if (aWfGwoerXZkAbHflBYyNjVEOqklSA < xsGPIGWFzwDPvlcVNRhBfIpGcxbk.elements.axes.Length)
				{
					OQUYbvKdWgSxcuGPaSrvwSjkmih = xsGPIGWFzwDPvlcVNRhBfIpGcxbk.elements.axes[aWfGwoerXZkAbHflBYyNjVEOqklSA];
					AZBaSkJvWwNaiPaHPPZuLJgiXSYB = 1;
					return true;
				}
				return false;
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
			IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
			{
				ybWdpGdeKMfyKHujxDRJShIGkAIs ybWdpGdeKMfyKHujxDRJShIGkAIs2;
				if (AZBaSkJvWwNaiPaHPPZuLJgiXSYB == -2 && OIoUwWjHPOVhNSxCijVGIGDPQUup == Environment.CurrentManagedThreadId)
				{
					AZBaSkJvWwNaiPaHPPZuLJgiXSYB = 0;
					ybWdpGdeKMfyKHujxDRJShIGkAIs2 = this;
				}
				else
				{
					ybWdpGdeKMfyKHujxDRJShIGkAIs2 = new ybWdpGdeKMfyKHujxDRJShIGkAIs(0);
					ybWdpGdeKMfyKHujxDRJShIGkAIs2.XsGPIGWFzwDPvlcVNRhBfIpGcxbk = XsGPIGWFzwDPvlcVNRhBfIpGcxbk;
				}
				return ybWdpGdeKMfyKHujxDRJShIGkAIs2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Axis>)this).GetEnumerator();
			}
		}

		private sealed class UsGoueRDcOXoJsayYaBRNslaucJg : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
		{
			private int AAVEjpAuWVODxfEFUwTBJAqcTFNr;

			private Button VOXdFNKQkifZVKgbOBMlTAhDpUrfb;

			private int qSMPUHEkEKzRULUHzeIHKodnWgns;

			public Platform_Fallback_Base kXOdJiqCfvrVOqoQeecwHylddiPaA;

			private int NZcPlRFWcmCKVzGiHvHQTDVtBrKiA;

			Button IEnumerator<Button>.Current
			{
				[DebuggerHidden]
				get
				{
					return VOXdFNKQkifZVKgbOBMlTAhDpUrfb;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return VOXdFNKQkifZVKgbOBMlTAhDpUrfb;
				}
			}

			[DebuggerHidden]
			public UsGoueRDcOXoJsayYaBRNslaucJg(int P_0)
			{
				AAVEjpAuWVODxfEFUwTBJAqcTFNr = P_0;
				qSMPUHEkEKzRULUHzeIHKodnWgns = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int aAVEjpAuWVODxfEFUwTBJAqcTFNr = AAVEjpAuWVODxfEFUwTBJAqcTFNr;
				Platform_Fallback_Base platform_Fallback_Base = kXOdJiqCfvrVOqoQeecwHylddiPaA;
				switch (aAVEjpAuWVODxfEFUwTBJAqcTFNr)
				{
				default:
					return false;
				case 0:
					AAVEjpAuWVODxfEFUwTBJAqcTFNr = -1;
					if (platform_Fallback_Base.elements == null || platform_Fallback_Base.elements.buttons == null)
					{
						return false;
					}
					NZcPlRFWcmCKVzGiHvHQTDVtBrKiA = 0;
					break;
				case 1:
					AAVEjpAuWVODxfEFUwTBJAqcTFNr = -1;
					NZcPlRFWcmCKVzGiHvHQTDVtBrKiA++;
					break;
				}
				if (NZcPlRFWcmCKVzGiHvHQTDVtBrKiA < platform_Fallback_Base.elements.buttons.Length)
				{
					VOXdFNKQkifZVKgbOBMlTAhDpUrfb = platform_Fallback_Base.elements.buttons[NZcPlRFWcmCKVzGiHvHQTDVtBrKiA];
					AAVEjpAuWVODxfEFUwTBJAqcTFNr = 1;
					return true;
				}
				return false;
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
			IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
			{
				UsGoueRDcOXoJsayYaBRNslaucJg usGoueRDcOXoJsayYaBRNslaucJg;
				if (AAVEjpAuWVODxfEFUwTBJAqcTFNr == -2 && qSMPUHEkEKzRULUHzeIHKodnWgns == Environment.CurrentManagedThreadId)
				{
					AAVEjpAuWVODxfEFUwTBJAqcTFNr = 0;
					usGoueRDcOXoJsayYaBRNslaucJg = this;
				}
				else
				{
					usGoueRDcOXoJsayYaBRNslaucJg = new UsGoueRDcOXoJsayYaBRNslaucJg(0);
					usGoueRDcOXoJsayYaBRNslaucJg.kXOdJiqCfvrVOqoQeecwHylddiPaA = kXOdJiqCfvrVOqoQeecwHylddiPaA;
				}
				return usGoueRDcOXoJsayYaBRNslaucJg;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Button>)this).GetEnumerator();
			}
		}

		public MatchingCriteria matchingCriteria;

		public Elements elements;

		int Platform.assignedButtonCount => get_assignedButtonCount();

		int Platform.assignedAxisCount => get_assignedAxisCount();

		InputPlatform Platform.platform => get_platform();

		internal Axis[] Axes_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.axes;
			}
		}

		internal Button[] Buttons_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.buttons;
			}
		}

		bool Platform.hasData => get_hasData();

		bool Platform.disabled => get_disabled();

		bool Platform.isAllowed => get_isAllowed();

		Elements_Base Platform.elements_base => get_elements_base();

		public virtual int get_assignedButtonCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.buttonCount;
		}

		public virtual int get_assignedAxisCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.axisCount;
		}

		internal virtual InputPlatform get_platform()
		{
			return InputPlatform.Fallback;
		}

		internal virtual bool get_hasData()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			if (!matchingCriteria.hasData)
			{
				return false;
			}
			if (assignedButtonCount == 0 && assignedAxisCount == 0)
			{
				return false;
			}
			return true;
		}

		internal virtual bool get_disabled()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.disabled;
		}

		internal virtual bool get_isAllowed()
		{
			if (!base.isAllowed)
			{
				return false;
			}
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.isAllowed;
		}

		internal virtual Elements_Base get_elements_base()
		{
			return elements;
		}

		public override IList<Platform> GetVariants()
		{
			return null;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			return false;
		}

		[IteratorStateMachine(typeof(ybWdpGdeKMfyKHujxDRJShIGkAIs))]
		internal IEnumerable<Axis> IterateAxes()
		{
			return new ybWdpGdeKMfyKHujxDRJShIGkAIs(-2)
			{
				XsGPIGWFzwDPvlcVNRhBfIpGcxbk = this
			};
		}

		[IteratorStateMachine(typeof(UsGoueRDcOXoJsayYaBRNslaucJg))]
		internal IEnumerable<Button> IterateButtons()
		{
			return new UsGoueRDcOXoJsayYaBRNslaucJg(-2)
			{
				kXOdJiqCfvrVOqoQeecwHylddiPaA = this
			};
		}

		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			foreach (Axis item in IterateAxes())
			{
				if (item.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			foreach (Button item2 in IterateButtons())
			{
				if (item2.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[assignedButtonCount];
			axes = new int[assignedAxisCount];
			int num = 0;
			foreach (Button item in IterateButtons())
			{
				buttons[num] = item.elementIdentifier;
				num++;
			}
			num = 0;
			foreach (Axis item2 in IterateAxes())
			{
				axes[num] = item2.elementIdentifier;
				num++;
			}
		}

		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			Axis[] axes_orig = Axes_orig;
			if (axes_orig == null)
			{
				return null;
			}
			AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
				{
					array[i] = AxisCalibrationData.Default;
					array[i].invert = axes_orig[i].invert;
					array[i].deadZone = axes_orig[i].axisDeadZone;
					if (Axes_orig[i].calibrateAxis)
					{
						array[i].zero = axes_orig[i].axisZero;
						array[i].min = axes_orig[i].axisMin;
						array[i].max = axes_orig[i].axisMax;
					}
				}
				else
				{
					if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
					{
						throw new NotImplementedException();
					}
					array[i] = AxisCalibrationData.Default;
				}
				array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
			}
			return array;
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[Axes_orig.Length];
			for (int i = 0; i < Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
				if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
				{
					axisRanges[i] = Axes_orig[i].sourceAxisRange;
					continue;
				}
				if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
				{
					axisRanges[i] = AxisRange.Full;
					continue;
				}
				throw new Exception();
			}
		}

		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = null;
			if (Buttons_orig != null)
			{
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				for (int i = 0; i < Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
				}
			}
		}

		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (elements == null)
			{
				return ControllerElementType.Axis;
			}
			return elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		public override object DeepClone()
		{
			Platform_Fallback_Base platform_Fallback_Base = new Platform_Fallback_Base();
			CopyVars(platform_Fallback_Base);
			return platform_Fallback_Base;
		}

		internal override void CopyVars(Platform destination)
		{
			if (destination is Platform_Fallback_Base platform_Fallback_Base)
			{
				platform_Fallback_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
				platform_Fallback_Base.elements = MiscTools.DeepClone(elements);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Platform_Fallback : Platform_Fallback_Base
	{
		public Platform_Fallback_Base[] variants;

		public override IList<Platform> GetVariants()
		{
			return variants;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return true;
			}
			if (base.hasVariants)
			{
				for (int i = 0; i < variants.Length; i++)
				{
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		public override object DeepClone()
		{
			Platform_Fallback platform_Fallback = new Platform_Fallback();
			CopyVars(platform_Fallback);
			return platform_Fallback;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_Fallback platform_Fallback)
			{
				platform_Fallback.variants = MiscTools.DeepClone(variants);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public abstract class Platform_Custom : Platform
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class MatchingCriteria : MatchingCriteria_Base
		{
			[Tooltip("If enabled, this will match to every controller regardless of other matching criteria.")]
			public bool alwaysMatch;

			bool MatchingCriteria_Base.hasData => get_hasData();

			bool MatchingCriteria_Base.isAllowed => get_isAllowed();

			int MatchingCriteria_Base.alternateElementCount => get_alternateElementCount();

			internal virtual bool get_hasData()
			{
				if (disabled)
				{
					return false;
				}
				if (alwaysMatch)
				{
					return true;
				}
				return false;
			}

			internal virtual bool get_isAllowed()
			{
				if (!base.isAllowed)
				{
					return false;
				}
				return true;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
				{
					return true;
				}
				if (disabled)
				{
					return false;
				}
				if (!isAllowed)
				{
					return false;
				}
				_ = alwaysMatch;
				return true;
			}

			internal virtual int get_alternateElementCount()
			{
				return 0;
			}

			internal override ElementCount_Base GetAlternateElementCount(int index)
			{
				return null;
			}

			internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
			{
				return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched);
			}

			internal override void CopyVars(MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				if (destination is MatchingCriteria matchingCriteria)
				{
					matchingCriteria.alwaysMatch = alwaysMatch;
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Elements : Elements_Base
		{
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class CustomCalculationSourceData : IDeepCloneable
		{
			public int sourceType;

			public int sourceAxis;

			public int sourceButton;

			public int sourceOtherAxis;

			public AxisRange sourceAxisRange;

			public float axisDeadZone;

			public bool invert;

			public AxisCalibrationType axisCalibrationType;

			public float axisZero;

			public float axisMin;

			public float axisMax;

			public virtual object DeepClone()
			{
				return new CustomCalculationSourceData
				{
					sourceType = sourceType,
					sourceAxis = sourceAxis,
					sourceButton = sourceButton,
					sourceOtherAxis = sourceOtherAxis,
					sourceAxisRange = sourceAxisRange,
					axisDeadZone = axisDeadZone,
					invert = invert,
					axisCalibrationType = axisCalibrationType,
					axisZero = axisZero,
					axisMin = axisMin,
					axisMax = axisMax
				};
			}

			object IDeepCloneable.DeepClone()
			{
				//ILSpy generated this explicit interface implementation from .override directive in DeepClone
				return this.DeepClone();
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Element : IDeepCloneable
		{
			public int elementIdentifier;

			public int sourceType;

			public int sourceAxis;

			public float axisDeadZone;

			public int sourceButton;

			public CustomCalculation customCalculation;

			public CustomCalculationSourceData[] customCalculationSourceData;

			internal virtual void CopyVars(Element destination)
			{
				destination.elementIdentifier = elementIdentifier;
				destination.sourceType = sourceType;
				destination.sourceAxis = sourceAxis;
				destination.axisDeadZone = axisDeadZone;
				destination.sourceButton = sourceButton;
				destination.customCalculation = customCalculation;
				destination.customCalculationSourceData = ArrayTools.DeepClone(customCalculationSourceData);
			}

			public abstract object DeepClone();
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Button : Element
		{
			public Pole sourceAxisPole;

			public bool requireMultipleButtons;

			public int[] requiredButtons;

			public bool ignoreIfButtonsActive;

			public int[] ignoreIfButtonsActiveButtons;

			public HardwareButtonInfo buttonInfo;

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				if (destination is Button button)
				{
					button.sourceAxisPole = sourceAxisPole;
					button.requireMultipleButtons = requireMultipleButtons;
					button.requiredButtons = ArrayTools.ShallowCopy(requiredButtons);
					button.ignoreIfButtonsActive = ignoreIfButtonsActive;
					button.ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(ignoreIfButtonsActiveButtons);
					button.buttonInfo = MiscTools.DeepClone(buttonInfo);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Axis : Element
		{
			public bool invert;

			public AxisRange sourceAxisRange;

			public Pole buttonAxisContribution;

			public bool calibrateAxis;

			public float axisZero;

			public float axisMin;

			public float axisMax;

			public AxisCalibrationInfoEntry[] alternateCalibrations;

			public HardwareAxisInfo axisInfo;

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				if (destination is Axis axis)
				{
					axis.invert = invert;
					axis.sourceAxisRange = sourceAxisRange;
					axis.buttonAxisContribution = buttonAxisContribution;
					axis.calibrateAxis = calibrateAxis;
					axis.axisZero = axisZero;
					axis.axisMin = axisMin;
					axis.axisMax = axisMax;
					axis.axisInfo = MiscTools.DeepClone(axisInfo);
					axis.alternateCalibrations = MiscTools.DeepClone(alternateCalibrations);
				}
			}
		}

		internal abstract Axis[] Axes { get; }

		internal abstract Button[] Buttons { get; }

		internal abstract IEnumerable<Axis> IterateAxes();

		internal abstract IEnumerable<Button> IterateButtons();

		internal override void CopyVars(Platform destination)
		{
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class Platform_XboxOne_Base : Platform_Custom
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
		{
			public bool productName_useRegex;

			public string[] productName;

			bool hasData => get_hasData();

			bool isAllowed => get_isAllowed();

			internal override bool get_hasData()
			{
				if (base.get_hasData())
				{
					return true;
				}
				if (productName != null && productName.Length != 0)
				{
					return true;
				}
				return false;
			}

			internal override bool get_isAllowed()
			{
				if (!base.get_isAllowed())
				{
					return false;
				}
				if (disabled)
				{
					return false;
				}
				return true;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
				{
					return true;
				}
				if (!base.Matches(bridgedControllerHWInfo, strictMatch))
				{
					return false;
				}
				if (alwaysMatch)
				{
					return true;
				}
				string text = bridgedControllerHWInfo.hw_productName;
				if (text == null)
				{
					text = string.Empty;
				}
				text = text.Trim();
				if (productName != null)
				{
					for (int i = 0; i < productName.Length; i++)
					{
						string searchFor = productName[i];
						if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
						{
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			internal override void CopyVars(MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				if (destination is MatchingCriteria matchingCriteria)
				{
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Elements : Platform_Custom.Elements
		{
			public Axis[] axes;

			public Button[] buttons;

			int Elements_Base.buttonCount => get_buttonCount();

			int Elements_Base.axisCount => get_axisCount();

			public int get_buttonCount()
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}

			public int get_axisCount()
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Axis;
					}
				}
				for (int j = 0; j < buttonCount; j++)
				{
					if (buttons[j].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Button;
					}
				}
				return elementIdentifier.elementType;
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier != elementIdentifier.get_id())
					{
						continue;
					}
					switch (axes[i].sourceType)
					{
					case 1:
					case 100:
						axisRange = axes[i].sourceAxisRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					case 0:
						axisRange = AxisRange.Positive;
						return true;
					default:
						throw new NotImplementedException();
					}
				}
				axisRange = AxisRange.Full;
				return false;
			}

			public override object DeepClone()
			{
				Elements elements = new Elements();
				CopyVars(elements);
				return elements;
			}

			internal override void CopyVars(Elements_Base destination)
			{
				base.CopyVars(destination);
				if (destination is Elements elements)
				{
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Button : Platform_Custom.Button
		{
			public override object DeepClone()
			{
				Button button = new Button();
				CopyVars(button);
				return button;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				_ = destination is Button;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Axis : Platform_Custom.Axis
		{
			public override object DeepClone()
			{
				Axis axis = new Axis();
				CopyVars(axis);
				return axis;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				_ = destination is Axis;
			}
		}

		private sealed class rDgMDVqlAqVYdmTqArpgIsSQaCZD : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
		{
			private int FIsJGOrgtncpaUTgtMVYTugAPyEJ;

			private Platform_Custom.Axis JypiGVQjThdKAEwCTkYDgQWypMxcb;

			private int OpUUVFVWLDdapnmwWSFumNlswJaw;

			public Platform_XboxOne_Base pDykXUhqMbKyrtyZvdsLtyouAhYP;

			private int ViWgxEywekpJrQObDlzSJacjnzms;

			Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
			{
				[DebuggerHidden]
				get
				{
					return JypiGVQjThdKAEwCTkYDgQWypMxcb;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return JypiGVQjThdKAEwCTkYDgQWypMxcb;
				}
			}

			[DebuggerHidden]
			public rDgMDVqlAqVYdmTqArpgIsSQaCZD(int P_0)
			{
				FIsJGOrgtncpaUTgtMVYTugAPyEJ = P_0;
				OpUUVFVWLDdapnmwWSFumNlswJaw = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int fIsJGOrgtncpaUTgtMVYTugAPyEJ = FIsJGOrgtncpaUTgtMVYTugAPyEJ;
				Platform_XboxOne_Base platform_XboxOne_Base = pDykXUhqMbKyrtyZvdsLtyouAhYP;
				switch (fIsJGOrgtncpaUTgtMVYTugAPyEJ)
				{
				default:
					return false;
				case 0:
					FIsJGOrgtncpaUTgtMVYTugAPyEJ = -1;
					if (platform_XboxOne_Base.elements == null || platform_XboxOne_Base.elements.axes == null)
					{
						return false;
					}
					ViWgxEywekpJrQObDlzSJacjnzms = 0;
					break;
				case 1:
					FIsJGOrgtncpaUTgtMVYTugAPyEJ = -1;
					ViWgxEywekpJrQObDlzSJacjnzms++;
					break;
				}
				if (ViWgxEywekpJrQObDlzSJacjnzms < platform_XboxOne_Base.elements.axes.Length)
				{
					JypiGVQjThdKAEwCTkYDgQWypMxcb = platform_XboxOne_Base.elements.axes[ViWgxEywekpJrQObDlzSJacjnzms];
					FIsJGOrgtncpaUTgtMVYTugAPyEJ = 1;
					return true;
				}
				return false;
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
			IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
			{
				rDgMDVqlAqVYdmTqArpgIsSQaCZD rDgMDVqlAqVYdmTqArpgIsSQaCZD2;
				if (FIsJGOrgtncpaUTgtMVYTugAPyEJ == -2 && OpUUVFVWLDdapnmwWSFumNlswJaw == Environment.CurrentManagedThreadId)
				{
					FIsJGOrgtncpaUTgtMVYTugAPyEJ = 0;
					rDgMDVqlAqVYdmTqArpgIsSQaCZD2 = this;
				}
				else
				{
					rDgMDVqlAqVYdmTqArpgIsSQaCZD2 = new rDgMDVqlAqVYdmTqArpgIsSQaCZD(0);
					rDgMDVqlAqVYdmTqArpgIsSQaCZD2.pDykXUhqMbKyrtyZvdsLtyouAhYP = pDykXUhqMbKyrtyZvdsLtyouAhYP;
				}
				return rDgMDVqlAqVYdmTqArpgIsSQaCZD2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
			}
		}

		private sealed class XPwEgAAaKsHyzpNzBrQUZLthxez : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
		{
			private int kCxRDllKBlUJrcwQtuPgKVihBYQF;

			private Platform_Custom.Button tyekTIYJjRdRMPkmSAcFEZbyOOYpA;

			private int uvcnutNrAULAHkHqzByIuVrRHvCw;

			public Platform_XboxOne_Base QeqiebBsvNQhzJMNQIOdGmAHRapfA;

			private int QUbjtGyxCqrxkVWGsTDElBuHKPFC;

			Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
			{
				[DebuggerHidden]
				get
				{
					return tyekTIYJjRdRMPkmSAcFEZbyOOYpA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return tyekTIYJjRdRMPkmSAcFEZbyOOYpA;
				}
			}

			[DebuggerHidden]
			public XPwEgAAaKsHyzpNzBrQUZLthxez(int P_0)
			{
				kCxRDllKBlUJrcwQtuPgKVihBYQF = P_0;
				uvcnutNrAULAHkHqzByIuVrRHvCw = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = kCxRDllKBlUJrcwQtuPgKVihBYQF;
				Platform_XboxOne_Base qeqiebBsvNQhzJMNQIOdGmAHRapfA = QeqiebBsvNQhzJMNQIOdGmAHRapfA;
				switch (num)
				{
				default:
					return false;
				case 0:
					kCxRDllKBlUJrcwQtuPgKVihBYQF = -1;
					if (qeqiebBsvNQhzJMNQIOdGmAHRapfA.elements == null || qeqiebBsvNQhzJMNQIOdGmAHRapfA.elements.buttons == null)
					{
						return false;
					}
					QUbjtGyxCqrxkVWGsTDElBuHKPFC = 0;
					break;
				case 1:
					kCxRDllKBlUJrcwQtuPgKVihBYQF = -1;
					QUbjtGyxCqrxkVWGsTDElBuHKPFC++;
					break;
				}
				if (QUbjtGyxCqrxkVWGsTDElBuHKPFC < qeqiebBsvNQhzJMNQIOdGmAHRapfA.elements.buttons.Length)
				{
					tyekTIYJjRdRMPkmSAcFEZbyOOYpA = qeqiebBsvNQhzJMNQIOdGmAHRapfA.elements.buttons[QUbjtGyxCqrxkVWGsTDElBuHKPFC];
					kCxRDllKBlUJrcwQtuPgKVihBYQF = 1;
					return true;
				}
				return false;
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
			IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
			{
				XPwEgAAaKsHyzpNzBrQUZLthxez xPwEgAAaKsHyzpNzBrQUZLthxez;
				if (kCxRDllKBlUJrcwQtuPgKVihBYQF == -2 && uvcnutNrAULAHkHqzByIuVrRHvCw == Environment.CurrentManagedThreadId)
				{
					kCxRDllKBlUJrcwQtuPgKVihBYQF = 0;
					xPwEgAAaKsHyzpNzBrQUZLthxez = this;
				}
				else
				{
					xPwEgAAaKsHyzpNzBrQUZLthxez = new XPwEgAAaKsHyzpNzBrQUZLthxez(0);
					xPwEgAAaKsHyzpNzBrQUZLthxez.QeqiebBsvNQhzJMNQIOdGmAHRapfA = QeqiebBsvNQhzJMNQIOdGmAHRapfA;
				}
				return xPwEgAAaKsHyzpNzBrQUZLthxez;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
			}
		}

		public MatchingCriteria matchingCriteria;

		public Elements elements;

		private Platform_Custom.Axis[] _axesOrigGame;

		private Platform_Custom.Button[] _buttonsOrigGame;

		int Platform.assignedButtonCount => get_assignedButtonCount();

		int Platform.assignedAxisCount => get_assignedAxisCount();

		InputPlatform Platform.platform => get_platform();

		Platform_Custom.Axis[] Platform_Custom.Axes => get_Axes();

		Platform_Custom.Button[] Platform_Custom.Buttons => get_Buttons();

		internal Axis[] Axes_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.axes;
			}
		}

		internal Button[] Buttons_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.buttons;
			}
		}

		bool Platform.hasData => get_hasData();

		bool Platform.disabled => get_disabled();

		bool Platform.isAllowed => get_isAllowed();

		Elements_Base Platform.elements_base => get_elements_base();

		public virtual int get_assignedButtonCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.buttonCount;
		}

		public virtual int get_assignedAxisCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.axisCount;
		}

		internal virtual InputPlatform get_platform()
		{
			return InputPlatform.XboxOne;
		}

		internal virtual Platform_Custom.Axis[] get_Axes()
		{
			if (_axesOrigGame == null)
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig != null)
				{
					_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
					for (int i = 0; i < axes_orig.Length; i++)
					{
						_axesOrigGame[i] = axes_orig[i];
					}
				}
			}
			return _axesOrigGame;
		}

		internal virtual Platform_Custom.Button[] get_Buttons()
		{
			if (_buttonsOrigGame == null)
			{
				Button[] buttons_orig = Buttons_orig;
				if (buttons_orig != null)
				{
					_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						_buttonsOrigGame[i] = buttons_orig[i];
					}
				}
			}
			return _buttonsOrigGame;
		}

		internal virtual bool get_hasData()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			if (!matchingCriteria.hasData)
			{
				return false;
			}
			if (assignedButtonCount == 0 && assignedAxisCount == 0)
			{
				return false;
			}
			return true;
		}

		internal virtual bool get_disabled()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.disabled;
		}

		internal virtual bool get_isAllowed()
		{
			if (!base.isAllowed)
			{
				return false;
			}
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.isAllowed;
		}

		internal virtual Elements_Base get_elements_base()
		{
			return elements;
		}

		public override IList<Platform> GetVariants()
		{
			return null;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			return false;
		}

		[IteratorStateMachine(typeof(rDgMDVqlAqVYdmTqArpgIsSQaCZD))]
		internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
		{
			return new rDgMDVqlAqVYdmTqArpgIsSQaCZD(-2)
			{
				pDykXUhqMbKyrtyZvdsLtyouAhYP = this
			};
		}

		[IteratorStateMachine(typeof(XPwEgAAaKsHyzpNzBrQUZLthxez))]
		internal override IEnumerable<Platform_Custom.Button> IterateButtons()
		{
			return new XPwEgAAaKsHyzpNzBrQUZLthxez(-2)
			{
				QeqiebBsvNQhzJMNQIOdGmAHRapfA = this
			};
		}

		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			foreach (Axis item in IterateAxes())
			{
				if (item.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			foreach (Button item2 in IterateButtons())
			{
				if (item2.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[assignedButtonCount];
			axes = new int[assignedAxisCount];
			int num = 0;
			foreach (Button item in IterateButtons())
			{
				buttons[num] = item.elementIdentifier;
				num++;
			}
			num = 0;
			foreach (Axis item2 in IterateAxes())
			{
				axes[num] = item2.elementIdentifier;
				num++;
			}
		}

		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			Axis[] axes_orig = Axes_orig;
			if (axes_orig == null)
			{
				return null;
			}
			AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
				{
					array[i] = AxisCalibrationData.Default;
					array[i].invert = axes_orig[i].invert;
					array[i].deadZone = axes_orig[i].axisDeadZone;
					if (Axes_orig[i].calibrateAxis)
					{
						array[i].zero = axes_orig[i].axisZero;
						array[i].min = axes_orig[i].axisMin;
						array[i].max = axes_orig[i].axisMax;
					}
				}
				else
				{
					if (axes_orig[i].sourceType != 0)
					{
						throw new NotImplementedException();
					}
					array[i] = AxisCalibrationData.Default;
				}
				array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
			}
			return array;
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[Axes_orig.Length];
			for (int i = 0; i < Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
				if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
				{
					axisRanges[i] = Axes_orig[i].sourceAxisRange;
					continue;
				}
				if (Axes_orig[i].sourceType == 0)
				{
					axisRanges[i] = AxisRange.Full;
					continue;
				}
				throw new Exception();
			}
		}

		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = null;
			if (Buttons_orig != null)
			{
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				for (int i = 0; i < Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
				}
			}
		}

		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (elements == null)
			{
				return ControllerElementType.Axis;
			}
			return elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		public override object DeepClone()
		{
			Platform_XboxOne_Base platform_XboxOne_Base = new Platform_XboxOne_Base();
			CopyVars(platform_XboxOne_Base);
			return platform_XboxOne_Base;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_XboxOne_Base platform_XboxOne_Base)
			{
				platform_XboxOne_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
				platform_XboxOne_Base.elements = MiscTools.DeepClone(elements);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Platform_XboxOne : Platform_XboxOne_Base
	{
		public Platform_XboxOne_Base[] variants;

		public override IList<Platform> GetVariants()
		{
			return variants;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return true;
			}
			if (base.hasVariants)
			{
				for (int i = 0; i < variants.Length; i++)
				{
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		public override object DeepClone()
		{
			Platform_XboxOne platform_XboxOne = new Platform_XboxOne();
			CopyVars(platform_XboxOne);
			return platform_XboxOne;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_XboxOne platform_XboxOne)
			{
				platform_XboxOne.variants = MiscTools.DeepClone(variants);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class Platform_PS4_Base : Platform_Custom
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
		{
			public bool productName_useRegex;

			public string[] productName;

			bool hasData => get_hasData();

			bool isAllowed => get_isAllowed();

			internal override bool get_hasData()
			{
				if (base.get_hasData())
				{
					return true;
				}
				if (productName != null && productName.Length != 0)
				{
					return true;
				}
				return false;
			}

			internal override bool get_isAllowed()
			{
				if (!base.get_isAllowed())
				{
					return false;
				}
				if (disabled)
				{
					return false;
				}
				return true;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
				{
					return true;
				}
				if (!base.Matches(bridgedControllerHWInfo, strictMatch))
				{
					return false;
				}
				if (alwaysMatch)
				{
					return true;
				}
				string text = bridgedControllerHWInfo.hw_productName;
				if (text == null)
				{
					text = string.Empty;
				}
				text = text.Trim();
				if (productName != null)
				{
					for (int i = 0; i < productName.Length; i++)
					{
						string searchFor = productName[i];
						if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
						{
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			internal override void CopyVars(MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				if (destination is MatchingCriteria matchingCriteria)
				{
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Elements : Platform_Custom.Elements
		{
			public Axis[] axes;

			public Button[] buttons;

			int Elements_Base.buttonCount => get_buttonCount();

			int Elements_Base.axisCount => get_axisCount();

			public int get_buttonCount()
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}

			public int get_axisCount()
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Axis;
					}
				}
				for (int j = 0; j < buttonCount; j++)
				{
					if (buttons[j].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Button;
					}
				}
				return elementIdentifier.elementType;
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier != elementIdentifier.get_id())
					{
						continue;
					}
					switch (axes[i].sourceType)
					{
					case 1:
					case 100:
						axisRange = axes[i].sourceAxisRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					case 0:
						axisRange = AxisRange.Positive;
						return true;
					default:
						throw new NotImplementedException();
					}
				}
				axisRange = AxisRange.Full;
				return false;
			}

			public override object DeepClone()
			{
				Elements elements = new Elements();
				CopyVars(elements);
				return elements;
			}

			internal override void CopyVars(Elements_Base destination)
			{
				base.CopyVars(destination);
				if (destination is Elements elements)
				{
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Button : Platform_Custom.Button
		{
			public override object DeepClone()
			{
				Button button = new Button();
				CopyVars(button);
				return button;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				_ = destination is Button;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Axis : Platform_Custom.Axis
		{
			public override object DeepClone()
			{
				Axis axis = new Axis();
				CopyVars(axis);
				return axis;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				_ = destination is Axis;
			}
		}

		private sealed class fONaDVzXkECZbrMzJPruQlvyKtQw : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
		{
			private int GvTgEfnUNtbWRQaJqMUriXfIInDU;

			private Platform_Custom.Axis OpyPuWcJKHiqUhLJHCWhCApiDCuEA;

			private int HVYSeemULggVHxBSZHVQuCpVoQDk;

			public Platform_PS4_Base bmSQteldiwEGjIKROifldEYjayskB;

			private int TilbfQHtoXCuTsxxOjlTZzAqoopX;

			Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
			{
				[DebuggerHidden]
				get
				{
					return OpyPuWcJKHiqUhLJHCWhCApiDCuEA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return OpyPuWcJKHiqUhLJHCWhCApiDCuEA;
				}
			}

			[DebuggerHidden]
			public fONaDVzXkECZbrMzJPruQlvyKtQw(int P_0)
			{
				GvTgEfnUNtbWRQaJqMUriXfIInDU = P_0;
				HVYSeemULggVHxBSZHVQuCpVoQDk = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gvTgEfnUNtbWRQaJqMUriXfIInDU = GvTgEfnUNtbWRQaJqMUriXfIInDU;
				Platform_PS4_Base platform_PS4_Base = bmSQteldiwEGjIKROifldEYjayskB;
				switch (gvTgEfnUNtbWRQaJqMUriXfIInDU)
				{
				default:
					return false;
				case 0:
					GvTgEfnUNtbWRQaJqMUriXfIInDU = -1;
					if (platform_PS4_Base.elements == null || platform_PS4_Base.elements.axes == null)
					{
						return false;
					}
					TilbfQHtoXCuTsxxOjlTZzAqoopX = 0;
					break;
				case 1:
					GvTgEfnUNtbWRQaJqMUriXfIInDU = -1;
					TilbfQHtoXCuTsxxOjlTZzAqoopX++;
					break;
				}
				if (TilbfQHtoXCuTsxxOjlTZzAqoopX < platform_PS4_Base.elements.axes.Length)
				{
					OpyPuWcJKHiqUhLJHCWhCApiDCuEA = platform_PS4_Base.elements.axes[TilbfQHtoXCuTsxxOjlTZzAqoopX];
					GvTgEfnUNtbWRQaJqMUriXfIInDU = 1;
					return true;
				}
				return false;
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
			IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
			{
				fONaDVzXkECZbrMzJPruQlvyKtQw fONaDVzXkECZbrMzJPruQlvyKtQw2;
				if (GvTgEfnUNtbWRQaJqMUriXfIInDU == -2 && HVYSeemULggVHxBSZHVQuCpVoQDk == Environment.CurrentManagedThreadId)
				{
					GvTgEfnUNtbWRQaJqMUriXfIInDU = 0;
					fONaDVzXkECZbrMzJPruQlvyKtQw2 = this;
				}
				else
				{
					fONaDVzXkECZbrMzJPruQlvyKtQw2 = new fONaDVzXkECZbrMzJPruQlvyKtQw(0);
					fONaDVzXkECZbrMzJPruQlvyKtQw2.bmSQteldiwEGjIKROifldEYjayskB = bmSQteldiwEGjIKROifldEYjayskB;
				}
				return fONaDVzXkECZbrMzJPruQlvyKtQw2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
			}
		}

		private sealed class EIBohRGwCDbIHLrQlaHzzFQCLNtq : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
		{
			private int zcqELwoGQLnATHDEhNUsYYsGbTQy;

			private Platform_Custom.Button awkgWshCakDzqbxncsSinmHPgkjZb;

			private int sEGZgqEraaBtqmnooYNUQALgtjYt;

			public Platform_PS4_Base dANCaukPchGHIHcxRMEdvkXzOWsPA;

			private int lmXdExBQsGnFvvttJAzyARuSiqhPA;

			Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
			{
				[DebuggerHidden]
				get
				{
					return awkgWshCakDzqbxncsSinmHPgkjZb;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return awkgWshCakDzqbxncsSinmHPgkjZb;
				}
			}

			[DebuggerHidden]
			public EIBohRGwCDbIHLrQlaHzzFQCLNtq(int P_0)
			{
				zcqELwoGQLnATHDEhNUsYYsGbTQy = P_0;
				sEGZgqEraaBtqmnooYNUQALgtjYt = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = zcqELwoGQLnATHDEhNUsYYsGbTQy;
				Platform_PS4_Base platform_PS4_Base = dANCaukPchGHIHcxRMEdvkXzOWsPA;
				switch (num)
				{
				default:
					return false;
				case 0:
					zcqELwoGQLnATHDEhNUsYYsGbTQy = -1;
					if (platform_PS4_Base.elements == null || platform_PS4_Base.elements.buttons == null)
					{
						return false;
					}
					lmXdExBQsGnFvvttJAzyARuSiqhPA = 0;
					break;
				case 1:
					zcqELwoGQLnATHDEhNUsYYsGbTQy = -1;
					lmXdExBQsGnFvvttJAzyARuSiqhPA++;
					break;
				}
				if (lmXdExBQsGnFvvttJAzyARuSiqhPA < platform_PS4_Base.elements.buttons.Length)
				{
					awkgWshCakDzqbxncsSinmHPgkjZb = platform_PS4_Base.elements.buttons[lmXdExBQsGnFvvttJAzyARuSiqhPA];
					zcqELwoGQLnATHDEhNUsYYsGbTQy = 1;
					return true;
				}
				return false;
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
			IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
			{
				EIBohRGwCDbIHLrQlaHzzFQCLNtq eIBohRGwCDbIHLrQlaHzzFQCLNtq;
				if (zcqELwoGQLnATHDEhNUsYYsGbTQy == -2 && sEGZgqEraaBtqmnooYNUQALgtjYt == Environment.CurrentManagedThreadId)
				{
					zcqELwoGQLnATHDEhNUsYYsGbTQy = 0;
					eIBohRGwCDbIHLrQlaHzzFQCLNtq = this;
				}
				else
				{
					eIBohRGwCDbIHLrQlaHzzFQCLNtq = new EIBohRGwCDbIHLrQlaHzzFQCLNtq(0);
					eIBohRGwCDbIHLrQlaHzzFQCLNtq.dANCaukPchGHIHcxRMEdvkXzOWsPA = dANCaukPchGHIHcxRMEdvkXzOWsPA;
				}
				return eIBohRGwCDbIHLrQlaHzzFQCLNtq;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
			}
		}

		public MatchingCriteria matchingCriteria;

		public Elements elements;

		private Platform_Custom.Axis[] _axesOrigGame;

		private Platform_Custom.Button[] _buttonsOrigGame;

		int Platform.assignedButtonCount => get_assignedButtonCount();

		int Platform.assignedAxisCount => get_assignedAxisCount();

		InputPlatform Platform.platform => get_platform();

		Platform_Custom.Axis[] Platform_Custom.Axes => get_Axes();

		Platform_Custom.Button[] Platform_Custom.Buttons => get_Buttons();

		internal Axis[] Axes_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.axes;
			}
		}

		internal Button[] Buttons_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.buttons;
			}
		}

		bool Platform.hasData => get_hasData();

		bool Platform.disabled => get_disabled();

		bool Platform.isAllowed => get_isAllowed();

		Elements_Base Platform.elements_base => get_elements_base();

		public virtual int get_assignedButtonCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.buttonCount;
		}

		public virtual int get_assignedAxisCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.axisCount;
		}

		internal virtual InputPlatform get_platform()
		{
			return InputPlatform.PS4;
		}

		internal virtual Platform_Custom.Axis[] get_Axes()
		{
			if (_axesOrigGame == null)
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig != null)
				{
					_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
					for (int i = 0; i < axes_orig.Length; i++)
					{
						_axesOrigGame[i] = axes_orig[i];
					}
				}
			}
			return _axesOrigGame;
		}

		internal virtual Platform_Custom.Button[] get_Buttons()
		{
			if (_buttonsOrigGame == null)
			{
				Button[] buttons_orig = Buttons_orig;
				if (buttons_orig != null)
				{
					_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						_buttonsOrigGame[i] = buttons_orig[i];
					}
				}
			}
			return _buttonsOrigGame;
		}

		internal virtual bool get_hasData()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			if (!matchingCriteria.hasData)
			{
				return false;
			}
			if (assignedButtonCount == 0 && assignedAxisCount == 0)
			{
				return false;
			}
			return true;
		}

		internal virtual bool get_disabled()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.disabled;
		}

		internal virtual bool get_isAllowed()
		{
			if (!base.isAllowed)
			{
				return false;
			}
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.isAllowed;
		}

		internal virtual Elements_Base get_elements_base()
		{
			return elements;
		}

		public override IList<Platform> GetVariants()
		{
			return null;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			return false;
		}

		[IteratorStateMachine(typeof(fONaDVzXkECZbrMzJPruQlvyKtQw))]
		internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
		{
			return new fONaDVzXkECZbrMzJPruQlvyKtQw(-2)
			{
				bmSQteldiwEGjIKROifldEYjayskB = this
			};
		}

		[IteratorStateMachine(typeof(EIBohRGwCDbIHLrQlaHzzFQCLNtq))]
		internal override IEnumerable<Platform_Custom.Button> IterateButtons()
		{
			return new EIBohRGwCDbIHLrQlaHzzFQCLNtq(-2)
			{
				dANCaukPchGHIHcxRMEdvkXzOWsPA = this
			};
		}

		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			foreach (Axis item in IterateAxes())
			{
				if (item.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			foreach (Button item2 in IterateButtons())
			{
				if (item2.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[assignedButtonCount];
			axes = new int[assignedAxisCount];
			int num = 0;
			foreach (Button item in IterateButtons())
			{
				buttons[num] = item.elementIdentifier;
				num++;
			}
			num = 0;
			foreach (Axis item2 in IterateAxes())
			{
				axes[num] = item2.elementIdentifier;
				num++;
			}
		}

		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			Axis[] axes_orig = Axes_orig;
			if (axes_orig == null)
			{
				return null;
			}
			AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
				{
					array[i] = AxisCalibrationData.Default;
					array[i].invert = axes_orig[i].invert;
					array[i].deadZone = axes_orig[i].axisDeadZone;
					if (Axes_orig[i].calibrateAxis)
					{
						array[i].zero = axes_orig[i].axisZero;
						array[i].min = axes_orig[i].axisMin;
						array[i].max = axes_orig[i].axisMax;
					}
				}
				else
				{
					if (axes_orig[i].sourceType != 0)
					{
						throw new NotImplementedException();
					}
					array[i] = AxisCalibrationData.Default;
				}
				array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
			}
			return array;
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[Axes_orig.Length];
			for (int i = 0; i < Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
				if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
				{
					axisRanges[i] = Axes_orig[i].sourceAxisRange;
					continue;
				}
				if (Axes_orig[i].sourceType == 0)
				{
					axisRanges[i] = AxisRange.Full;
					continue;
				}
				throw new Exception();
			}
		}

		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = null;
			if (Buttons_orig != null)
			{
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				for (int i = 0; i < Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
				}
			}
		}

		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (elements == null)
			{
				return ControllerElementType.Axis;
			}
			return elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		public override object DeepClone()
		{
			Platform_PS4_Base platform_PS4_Base = new Platform_PS4_Base();
			CopyVars(platform_PS4_Base);
			return platform_PS4_Base;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_PS4_Base platform_PS4_Base)
			{
				platform_PS4_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
				platform_PS4_Base.elements = MiscTools.DeepClone(elements);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Platform_PS4 : Platform_PS4_Base
	{
		public Platform_PS4_Base[] variants;

		public override IList<Platform> GetVariants()
		{
			return variants;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return true;
			}
			if (base.hasVariants)
			{
				for (int i = 0; i < variants.Length; i++)
				{
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		public override object DeepClone()
		{
			Platform_PS4 platform_PS = new Platform_PS4();
			CopyVars(platform_PS);
			return platform_PS;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_PS4 platform_PS)
			{
				platform_PS.variants = MiscTools.DeepClone(variants);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class Platform_NintendoSwitch_Base : Platform_Custom
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
		{
			public bool productName_useRegex;

			public string[] productName;

			bool hasData => get_hasData();

			bool isAllowed => get_isAllowed();

			internal override bool get_hasData()
			{
				if (base.get_hasData())
				{
					return true;
				}
				if (productName != null && productName.Length != 0)
				{
					return true;
				}
				return false;
			}

			internal override bool get_isAllowed()
			{
				if (!base.get_isAllowed())
				{
					return false;
				}
				if (disabled)
				{
					return false;
				}
				return true;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
				{
					return true;
				}
				if (!base.Matches(bridgedControllerHWInfo, strictMatch))
				{
					return false;
				}
				if (alwaysMatch)
				{
					return true;
				}
				string text = bridgedControllerHWInfo.hw_productName;
				if (text == null)
				{
					text = string.Empty;
				}
				text = text.Trim();
				if (productName != null)
				{
					for (int i = 0; i < productName.Length; i++)
					{
						string searchFor = productName[i];
						if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
						{
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			internal override void CopyVars(MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				if (destination is MatchingCriteria matchingCriteria)
				{
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Elements : Platform_Custom.Elements
		{
			public Axis[] axes;

			public Button[] buttons;

			int Elements_Base.buttonCount => get_buttonCount();

			int Elements_Base.axisCount => get_axisCount();

			public int get_buttonCount()
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}

			public int get_axisCount()
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Axis;
					}
				}
				for (int j = 0; j < buttonCount; j++)
				{
					if (buttons[j].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Button;
					}
				}
				return elementIdentifier.elementType;
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier != elementIdentifier.get_id())
					{
						continue;
					}
					switch (axes[i].sourceType)
					{
					case 1:
					case 100:
						axisRange = axes[i].sourceAxisRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					case 0:
						axisRange = AxisRange.Positive;
						return true;
					default:
						throw new NotImplementedException();
					}
				}
				axisRange = AxisRange.Full;
				return false;
			}

			public override object DeepClone()
			{
				Elements elements = new Elements();
				CopyVars(elements);
				return elements;
			}

			internal override void CopyVars(Elements_Base destination)
			{
				base.CopyVars(destination);
				if (destination is Elements elements)
				{
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Button : Platform_Custom.Button
		{
			public override object DeepClone()
			{
				Button button = new Button();
				CopyVars(button);
				return button;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				_ = destination is Button;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Axis : Platform_Custom.Axis
		{
			public override object DeepClone()
			{
				Axis axis = new Axis();
				CopyVars(axis);
				return axis;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				_ = destination is Axis;
			}
		}

		private sealed class rOmJOXyMLdOZOMBmCHVadysnAwsmA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
		{
			private int wiZRppMKFpmLRwKoyAUmIBKQyaVL;

			private Platform_Custom.Axis KjMmUxvWfUTWRfRCNccmNxIzbNxg;

			private int YqoZVDqKrJERmiTcWoxjMyUzqerOA;

			public Platform_NintendoSwitch_Base vekDyhwxZcaWTFQgmLFziVwXSmlKA;

			private int qwFVvXmsABwWminJHSEiQZtpGyde;

			Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
			{
				[DebuggerHidden]
				get
				{
					return KjMmUxvWfUTWRfRCNccmNxIzbNxg;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return KjMmUxvWfUTWRfRCNccmNxIzbNxg;
				}
			}

			[DebuggerHidden]
			public rOmJOXyMLdOZOMBmCHVadysnAwsmA(int P_0)
			{
				wiZRppMKFpmLRwKoyAUmIBKQyaVL = P_0;
				YqoZVDqKrJERmiTcWoxjMyUzqerOA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = wiZRppMKFpmLRwKoyAUmIBKQyaVL;
				Platform_NintendoSwitch_Base platform_NintendoSwitch_Base = vekDyhwxZcaWTFQgmLFziVwXSmlKA;
				switch (num)
				{
				default:
					return false;
				case 0:
					wiZRppMKFpmLRwKoyAUmIBKQyaVL = -1;
					if (platform_NintendoSwitch_Base.elements == null || platform_NintendoSwitch_Base.elements.axes == null)
					{
						return false;
					}
					qwFVvXmsABwWminJHSEiQZtpGyde = 0;
					break;
				case 1:
					wiZRppMKFpmLRwKoyAUmIBKQyaVL = -1;
					qwFVvXmsABwWminJHSEiQZtpGyde++;
					break;
				}
				if (qwFVvXmsABwWminJHSEiQZtpGyde < platform_NintendoSwitch_Base.elements.axes.Length)
				{
					KjMmUxvWfUTWRfRCNccmNxIzbNxg = platform_NintendoSwitch_Base.elements.axes[qwFVvXmsABwWminJHSEiQZtpGyde];
					wiZRppMKFpmLRwKoyAUmIBKQyaVL = 1;
					return true;
				}
				return false;
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
			IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
			{
				rOmJOXyMLdOZOMBmCHVadysnAwsmA rOmJOXyMLdOZOMBmCHVadysnAwsmA2;
				if (wiZRppMKFpmLRwKoyAUmIBKQyaVL == -2 && YqoZVDqKrJERmiTcWoxjMyUzqerOA == Environment.CurrentManagedThreadId)
				{
					wiZRppMKFpmLRwKoyAUmIBKQyaVL = 0;
					rOmJOXyMLdOZOMBmCHVadysnAwsmA2 = this;
				}
				else
				{
					rOmJOXyMLdOZOMBmCHVadysnAwsmA2 = new rOmJOXyMLdOZOMBmCHVadysnAwsmA(0);
					rOmJOXyMLdOZOMBmCHVadysnAwsmA2.vekDyhwxZcaWTFQgmLFziVwXSmlKA = vekDyhwxZcaWTFQgmLFziVwXSmlKA;
				}
				return rOmJOXyMLdOZOMBmCHVadysnAwsmA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
			}
		}

		private sealed class aQoTMoYCODCtvgDgfmrfBCNadtgKB : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
		{
			private int xDmrNkmuudNkAhRQlocoGAMVpzjH;

			private Platform_Custom.Button cBiyhaWhWqOmeqGbJLpYXvknpRPs;

			private int WbQjsxgHQztNRayxzRSwOWRJHwuQA;

			public Platform_NintendoSwitch_Base BpYVljJjsegeYVcVEPftlGagujsl;

			private int oiRiSIkixyrNkuWjjAZacnJKEBhC;

			Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
			{
				[DebuggerHidden]
				get
				{
					return cBiyhaWhWqOmeqGbJLpYXvknpRPs;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return cBiyhaWhWqOmeqGbJLpYXvknpRPs;
				}
			}

			[DebuggerHidden]
			public aQoTMoYCODCtvgDgfmrfBCNadtgKB(int P_0)
			{
				xDmrNkmuudNkAhRQlocoGAMVpzjH = P_0;
				WbQjsxgHQztNRayxzRSwOWRJHwuQA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = xDmrNkmuudNkAhRQlocoGAMVpzjH;
				Platform_NintendoSwitch_Base bpYVljJjsegeYVcVEPftlGagujsl = BpYVljJjsegeYVcVEPftlGagujsl;
				switch (num)
				{
				default:
					return false;
				case 0:
					xDmrNkmuudNkAhRQlocoGAMVpzjH = -1;
					if (bpYVljJjsegeYVcVEPftlGagujsl.elements == null || bpYVljJjsegeYVcVEPftlGagujsl.elements.buttons == null)
					{
						return false;
					}
					oiRiSIkixyrNkuWjjAZacnJKEBhC = 0;
					break;
				case 1:
					xDmrNkmuudNkAhRQlocoGAMVpzjH = -1;
					oiRiSIkixyrNkuWjjAZacnJKEBhC++;
					break;
				}
				if (oiRiSIkixyrNkuWjjAZacnJKEBhC < bpYVljJjsegeYVcVEPftlGagujsl.elements.buttons.Length)
				{
					cBiyhaWhWqOmeqGbJLpYXvknpRPs = bpYVljJjsegeYVcVEPftlGagujsl.elements.buttons[oiRiSIkixyrNkuWjjAZacnJKEBhC];
					xDmrNkmuudNkAhRQlocoGAMVpzjH = 1;
					return true;
				}
				return false;
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
			IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
			{
				aQoTMoYCODCtvgDgfmrfBCNadtgKB aQoTMoYCODCtvgDgfmrfBCNadtgKB2;
				if (xDmrNkmuudNkAhRQlocoGAMVpzjH == -2 && WbQjsxgHQztNRayxzRSwOWRJHwuQA == Environment.CurrentManagedThreadId)
				{
					xDmrNkmuudNkAhRQlocoGAMVpzjH = 0;
					aQoTMoYCODCtvgDgfmrfBCNadtgKB2 = this;
				}
				else
				{
					aQoTMoYCODCtvgDgfmrfBCNadtgKB2 = new aQoTMoYCODCtvgDgfmrfBCNadtgKB(0);
					aQoTMoYCODCtvgDgfmrfBCNadtgKB2.BpYVljJjsegeYVcVEPftlGagujsl = BpYVljJjsegeYVcVEPftlGagujsl;
				}
				return aQoTMoYCODCtvgDgfmrfBCNadtgKB2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
			}
		}

		public MatchingCriteria matchingCriteria;

		public Elements elements;

		private Platform_Custom.Axis[] _axesOrigGame;

		private Platform_Custom.Button[] _buttonsOrigGame;

		int Platform.assignedButtonCount => get_assignedButtonCount();

		int Platform.assignedAxisCount => get_assignedAxisCount();

		InputPlatform Platform.platform => get_platform();

		Platform_Custom.Axis[] Platform_Custom.Axes => get_Axes();

		Platform_Custom.Button[] Platform_Custom.Buttons => get_Buttons();

		internal Axis[] Axes_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.axes;
			}
		}

		internal Button[] Buttons_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.buttons;
			}
		}

		bool Platform.hasData => get_hasData();

		bool Platform.disabled => get_disabled();

		bool Platform.isAllowed => get_isAllowed();

		Elements_Base Platform.elements_base => get_elements_base();

		public virtual int get_assignedButtonCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.buttonCount;
		}

		public virtual int get_assignedAxisCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.axisCount;
		}

		internal virtual InputPlatform get_platform()
		{
			return InputPlatform.NintendoSwitch;
		}

		internal virtual Platform_Custom.Axis[] get_Axes()
		{
			if (_axesOrigGame == null)
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig != null)
				{
					_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
					for (int i = 0; i < axes_orig.Length; i++)
					{
						_axesOrigGame[i] = axes_orig[i];
					}
				}
			}
			return _axesOrigGame;
		}

		internal virtual Platform_Custom.Button[] get_Buttons()
		{
			if (_buttonsOrigGame == null)
			{
				Button[] buttons_orig = Buttons_orig;
				if (buttons_orig != null)
				{
					_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						_buttonsOrigGame[i] = buttons_orig[i];
					}
				}
			}
			return _buttonsOrigGame;
		}

		internal virtual bool get_hasData()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			if (!matchingCriteria.hasData)
			{
				return false;
			}
			if (assignedButtonCount == 0 && assignedAxisCount == 0)
			{
				return false;
			}
			return true;
		}

		internal virtual bool get_disabled()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.disabled;
		}

		internal virtual bool get_isAllowed()
		{
			if (!base.isAllowed)
			{
				return false;
			}
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.isAllowed;
		}

		internal virtual Elements_Base get_elements_base()
		{
			return elements;
		}

		public override IList<Platform> GetVariants()
		{
			return null;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			return false;
		}

		[IteratorStateMachine(typeof(rOmJOXyMLdOZOMBmCHVadysnAwsmA))]
		internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
		{
			return new rOmJOXyMLdOZOMBmCHVadysnAwsmA(-2)
			{
				vekDyhwxZcaWTFQgmLFziVwXSmlKA = this
			};
		}

		[IteratorStateMachine(typeof(aQoTMoYCODCtvgDgfmrfBCNadtgKB))]
		internal override IEnumerable<Platform_Custom.Button> IterateButtons()
		{
			return new aQoTMoYCODCtvgDgfmrfBCNadtgKB(-2)
			{
				BpYVljJjsegeYVcVEPftlGagujsl = this
			};
		}

		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			foreach (Axis item in IterateAxes())
			{
				if (item.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			foreach (Button item2 in IterateButtons())
			{
				if (item2.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[assignedButtonCount];
			axes = new int[assignedAxisCount];
			int num = 0;
			foreach (Button item in IterateButtons())
			{
				buttons[num] = item.elementIdentifier;
				num++;
			}
			num = 0;
			foreach (Axis item2 in IterateAxes())
			{
				axes[num] = item2.elementIdentifier;
				num++;
			}
		}

		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			Axis[] axes_orig = Axes_orig;
			if (axes_orig == null)
			{
				return null;
			}
			AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
				{
					array[i] = AxisCalibrationData.Default;
					array[i].invert = axes_orig[i].invert;
					array[i].deadZone = axes_orig[i].axisDeadZone;
					if (Axes_orig[i].calibrateAxis)
					{
						array[i].zero = axes_orig[i].axisZero;
						array[i].min = axes_orig[i].axisMin;
						array[i].max = axes_orig[i].axisMax;
					}
				}
				else
				{
					if (axes_orig[i].sourceType != 0)
					{
						throw new NotImplementedException();
					}
					array[i] = AxisCalibrationData.Default;
				}
				array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
			}
			return array;
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[Axes_orig.Length];
			for (int i = 0; i < Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
				if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
				{
					axisRanges[i] = Axes_orig[i].sourceAxisRange;
					continue;
				}
				if (Axes_orig[i].sourceType == 0)
				{
					axisRanges[i] = AxisRange.Full;
					continue;
				}
				throw new Exception();
			}
		}

		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = null;
			if (Buttons_orig != null)
			{
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				for (int i = 0; i < Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
				}
			}
		}

		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (elements == null)
			{
				return ControllerElementType.Axis;
			}
			return elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		public override object DeepClone()
		{
			Platform_NintendoSwitch_Base platform_NintendoSwitch_Base = new Platform_NintendoSwitch_Base();
			CopyVars(platform_NintendoSwitch_Base);
			return platform_NintendoSwitch_Base;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_NintendoSwitch_Base platform_NintendoSwitch_Base)
			{
				platform_NintendoSwitch_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
				platform_NintendoSwitch_Base.elements = MiscTools.DeepClone(elements);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Platform_NintendoSwitch : Platform_NintendoSwitch_Base
	{
		public Platform_NintendoSwitch_Base[] variants;

		public override IList<Platform> GetVariants()
		{
			return variants;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return true;
			}
			if (base.hasVariants)
			{
				for (int i = 0; i < variants.Length; i++)
				{
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		public override object DeepClone()
		{
			Platform_NintendoSwitch platform_NintendoSwitch = new Platform_NintendoSwitch();
			CopyVars(platform_NintendoSwitch);
			return platform_NintendoSwitch;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_NintendoSwitch platform_NintendoSwitch)
			{
				platform_NintendoSwitch.variants = MiscTools.DeepClone(variants);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class Platform_GameCore_Base : Platform_Custom
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
		{
			public bool productName_useRegex;

			public string[] productName;

			public VidPid[] vidPid;

			public DeviceType deviceType;

			public GamepadSubType gamepadSubType;

			public int hatCount;

			bool hasData => get_hasData();

			bool isAllowed => get_isAllowed();

			internal override bool get_hasData()
			{
				if (base.get_hasData())
				{
					return true;
				}
				if (productName != null && productName.Length != 0)
				{
					return true;
				}
				if (deviceType != DeviceType.None)
				{
					return true;
				}
				if (vidPid != null && vidPid.Length != 0)
				{
					return true;
				}
				return false;
			}

			internal override bool get_isAllowed()
			{
				if (!base.get_isAllowed())
				{
					return false;
				}
				if (disabled)
				{
					return false;
				}
				return true;
			}

			internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
			{
				if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
				{
					return false;
				}
				if (hatCount >= 0)
				{
					return hatCount == bridgedControllerHWInfo.hardwareHatCount;
				}
				return true;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
				{
					return true;
				}
				if (alwaysMatch)
				{
					return true;
				}
				if (!base.Matches(bridgedControllerHWInfo, strictMatch))
				{
					return false;
				}
				if (!ElementCountsMatch(bridgedControllerHWInfo, out var _))
				{
					return false;
				}
				if (deviceType != DeviceType.None)
				{
					if (deviceType != (DeviceType)bridgedControllerHWInfo.deviceType)
					{
						return false;
					}
					if (deviceType == DeviceType.Gamepad && gamepadSubType != GamepadSubType.None && gamepadSubType != (GamepadSubType)bridgedControllerHWInfo.hw_xInputSubType)
					{
						return false;
					}
					if (!HasProductName() && (vidPid == null || vidPid.Length == 0))
					{
						return true;
					}
				}
				string text = bridgedControllerHWInfo.hw_productName;
				if (text == null)
				{
					text = string.Empty;
				}
				text = text.Trim();
				if (strictMatch)
				{
					if (vidPid != null)
					{
						for (int i = 0; i < vidPid.Length; i++)
						{
							int vendorId = vidPid[i].vendorId;
							int productId = vidPid[i].productId;
							if (ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_vendorId))
							{
								string name = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
								if (!ProductNameMatches(name))
								{
									return false;
								}
							}
							if (bridgedControllerHWInfo.hw_vendorId == vendorId && bridgedControllerHWInfo.hw_productId == productId)
							{
								return true;
							}
						}
					}
					return false;
				}
				return ProductNameMatches(text);
			}

			public override object DeepClone()
			{
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			internal override void CopyVars(MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				if (destination is MatchingCriteria matchingCriteria)
				{
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					matchingCriteria.deviceType = deviceType;
					matchingCriteria.gamepadSubType = gamepadSubType;
					matchingCriteria.hatCount = hatCount;
					matchingCriteria.vidPid = ArrayTools.ShallowCopy(vidPid);
				}
			}

			private bool HasProductName()
			{
				if (productName == null)
				{
					return false;
				}
				for (int i = 0; i < productName.Length; i++)
				{
					if (!string.IsNullOrEmpty(productName[i]))
					{
						return true;
					}
				}
				return false;
			}

			private bool ProductNameMatches(string name)
			{
				if (productName == null)
				{
					return false;
				}
				for (int i = 0; i < productName.Length; i++)
				{
					string searchFor = productName[i];
					if (MatchingCriteria_Base.StringMatches(name, searchFor, productName_useRegex))
					{
						return true;
					}
				}
				return false;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Elements : Platform_Custom.Elements
		{
			public Axis[] axes;

			public Button[] buttons;

			int Elements_Base.buttonCount => get_buttonCount();

			int Elements_Base.axisCount => get_axisCount();

			public int get_buttonCount()
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}

			public int get_axisCount()
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Axis;
					}
				}
				for (int j = 0; j < buttonCount; j++)
				{
					if (buttons[j].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Button;
					}
				}
				return elementIdentifier.elementType;
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier != elementIdentifier.get_id())
					{
						continue;
					}
					switch (axes[i].sourceType)
					{
					case 1:
					case 100:
						axisRange = axes[i].sourceAxisRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					case 0:
						axisRange = AxisRange.Positive;
						return true;
					case 2:
						axisRange = axes[i].sourceHatRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					default:
						throw new NotImplementedException();
					}
				}
				axisRange = AxisRange.Full;
				return false;
			}

			public override object DeepClone()
			{
				Elements elements = new Elements();
				CopyVars(elements);
				return elements;
			}

			internal override void CopyVars(Elements_Base destination)
			{
				base.CopyVars(destination);
				if (destination is Elements elements)
				{
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Button : Platform_Custom.Button
		{
			public int sourceHat;

			public HatDirection sourceHatDirection;

			public HatType sourceHatType;

			public override object DeepClone()
			{
				Button button = new Button();
				CopyVars(button);
				return button;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				if (destination is Button button)
				{
					button.sourceHat = sourceHat;
					button.sourceHatDirection = sourceHatDirection;
					button.sourceHatType = sourceHatType;
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Axis : Platform_Custom.Axis
		{
			public int sourceHat;

			public AxisDirection sourceHatDirection;

			public HatType sourceHatType;

			public AxisRange sourceHatRange;

			public override object DeepClone()
			{
				Axis axis = new Axis();
				CopyVars(axis);
				return axis;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				if (destination is Axis axis)
				{
					axis.sourceHat = sourceHat;
					axis.sourceHatDirection = sourceHatDirection;
					axis.sourceHatType = sourceHatType;
					axis.sourceHatRange = sourceHatRange;
				}
			}
		}

		public enum DeviceType
		{
			None = 0,
			Gamepad = 1,
			ArcadeStick = 2,
			FlightStick = 3,
			RacingWheel = 4,
			Raw = 6
		}

		public enum GamepadSubType
		{
			None = 0,
			Xbox360 = 1,
			XboxOne = 2,
			DualShock = 3,
			NintendoProController = 4,
			Unknown = 1000
		}

		private sealed class JgvCbGcdryRoLGjxJsyKboKXEfJJ : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
		{
			private int IPYDFSNffxlpkhMMziEFFXwuSfWc;

			private Platform_Custom.Axis DEPGXxNDhPXUindpqCSlTxFbSfsG;

			private int tTrbZwayRVazaZFxPurNGGYJyGRk;

			public Platform_GameCore_Base jlOAfddspnpkMgfjKjCslJJKbdXbB;

			private int WFunqnRNcDZYmpfWCaCcKiaZstXc;

			Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
			{
				[DebuggerHidden]
				get
				{
					return DEPGXxNDhPXUindpqCSlTxFbSfsG;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return DEPGXxNDhPXUindpqCSlTxFbSfsG;
				}
			}

			[DebuggerHidden]
			public JgvCbGcdryRoLGjxJsyKboKXEfJJ(int P_0)
			{
				IPYDFSNffxlpkhMMziEFFXwuSfWc = P_0;
				tTrbZwayRVazaZFxPurNGGYJyGRk = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int iPYDFSNffxlpkhMMziEFFXwuSfWc = IPYDFSNffxlpkhMMziEFFXwuSfWc;
				Platform_GameCore_Base platform_GameCore_Base = jlOAfddspnpkMgfjKjCslJJKbdXbB;
				switch (iPYDFSNffxlpkhMMziEFFXwuSfWc)
				{
				default:
					return false;
				case 0:
					IPYDFSNffxlpkhMMziEFFXwuSfWc = -1;
					if (platform_GameCore_Base.elements == null || platform_GameCore_Base.elements.axes == null)
					{
						return false;
					}
					WFunqnRNcDZYmpfWCaCcKiaZstXc = 0;
					break;
				case 1:
					IPYDFSNffxlpkhMMziEFFXwuSfWc = -1;
					WFunqnRNcDZYmpfWCaCcKiaZstXc++;
					break;
				}
				if (WFunqnRNcDZYmpfWCaCcKiaZstXc < platform_GameCore_Base.elements.axes.Length)
				{
					DEPGXxNDhPXUindpqCSlTxFbSfsG = platform_GameCore_Base.elements.axes[WFunqnRNcDZYmpfWCaCcKiaZstXc];
					IPYDFSNffxlpkhMMziEFFXwuSfWc = 1;
					return true;
				}
				return false;
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
			IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
			{
				JgvCbGcdryRoLGjxJsyKboKXEfJJ jgvCbGcdryRoLGjxJsyKboKXEfJJ;
				if (IPYDFSNffxlpkhMMziEFFXwuSfWc == -2 && tTrbZwayRVazaZFxPurNGGYJyGRk == Environment.CurrentManagedThreadId)
				{
					IPYDFSNffxlpkhMMziEFFXwuSfWc = 0;
					jgvCbGcdryRoLGjxJsyKboKXEfJJ = this;
				}
				else
				{
					jgvCbGcdryRoLGjxJsyKboKXEfJJ = new JgvCbGcdryRoLGjxJsyKboKXEfJJ(0);
					jgvCbGcdryRoLGjxJsyKboKXEfJJ.jlOAfddspnpkMgfjKjCslJJKbdXbB = jlOAfddspnpkMgfjKjCslJJKbdXbB;
				}
				return jgvCbGcdryRoLGjxJsyKboKXEfJJ;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
			}
		}

		private sealed class kZTOLPUvCAyqVBygMwjNUlwlRDVG : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
		{
			private int drjNvEatOBToIbIQPtFnYdWKUEcR;

			private Platform_Custom.Button hWxuJDdPaSvvPgsPaRjrtMOhhLwA;

			private int AIhaKgdfTSsOsvLXzjKHxcRbEAqr;

			public Platform_GameCore_Base moWTIbYUxCLetXAapWkuljofHRmb;

			private int OAucuynbsDhwhdjlnBYVqpDNZDDW;

			Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
			{
				[DebuggerHidden]
				get
				{
					return hWxuJDdPaSvvPgsPaRjrtMOhhLwA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return hWxuJDdPaSvvPgsPaRjrtMOhhLwA;
				}
			}

			[DebuggerHidden]
			public kZTOLPUvCAyqVBygMwjNUlwlRDVG(int P_0)
			{
				drjNvEatOBToIbIQPtFnYdWKUEcR = P_0;
				AIhaKgdfTSsOsvLXzjKHxcRbEAqr = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = drjNvEatOBToIbIQPtFnYdWKUEcR;
				Platform_GameCore_Base platform_GameCore_Base = moWTIbYUxCLetXAapWkuljofHRmb;
				switch (num)
				{
				default:
					return false;
				case 0:
					drjNvEatOBToIbIQPtFnYdWKUEcR = -1;
					if (platform_GameCore_Base.elements == null || platform_GameCore_Base.elements.buttons == null)
					{
						return false;
					}
					OAucuynbsDhwhdjlnBYVqpDNZDDW = 0;
					break;
				case 1:
					drjNvEatOBToIbIQPtFnYdWKUEcR = -1;
					OAucuynbsDhwhdjlnBYVqpDNZDDW++;
					break;
				}
				if (OAucuynbsDhwhdjlnBYVqpDNZDDW < platform_GameCore_Base.elements.buttons.Length)
				{
					hWxuJDdPaSvvPgsPaRjrtMOhhLwA = platform_GameCore_Base.elements.buttons[OAucuynbsDhwhdjlnBYVqpDNZDDW];
					drjNvEatOBToIbIQPtFnYdWKUEcR = 1;
					return true;
				}
				return false;
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
			IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
			{
				kZTOLPUvCAyqVBygMwjNUlwlRDVG kZTOLPUvCAyqVBygMwjNUlwlRDVG2;
				if (drjNvEatOBToIbIQPtFnYdWKUEcR == -2 && AIhaKgdfTSsOsvLXzjKHxcRbEAqr == Environment.CurrentManagedThreadId)
				{
					drjNvEatOBToIbIQPtFnYdWKUEcR = 0;
					kZTOLPUvCAyqVBygMwjNUlwlRDVG2 = this;
				}
				else
				{
					kZTOLPUvCAyqVBygMwjNUlwlRDVG2 = new kZTOLPUvCAyqVBygMwjNUlwlRDVG(0);
					kZTOLPUvCAyqVBygMwjNUlwlRDVG2.moWTIbYUxCLetXAapWkuljofHRmb = moWTIbYUxCLetXAapWkuljofHRmb;
				}
				return kZTOLPUvCAyqVBygMwjNUlwlRDVG2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
			}
		}

		public MatchingCriteria matchingCriteria;

		public Elements elements;

		public string controllerName;

		private Platform_Custom.Axis[] _axesOrigGame;

		private Platform_Custom.Button[] _buttonsOrigGame;

		int Platform.assignedButtonCount => get_assignedButtonCount();

		int Platform.assignedAxisCount => get_assignedAxisCount();

		string Platform.controllerNameOverride => get_controllerNameOverride();

		InputPlatform Platform.platform => get_platform();

		Platform_Custom.Axis[] Platform_Custom.Axes => get_Axes();

		Platform_Custom.Button[] Platform_Custom.Buttons => get_Buttons();

		internal Axis[] Axes_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.axes;
			}
		}

		internal Button[] Buttons_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.buttons;
			}
		}

		bool Platform.hasData => get_hasData();

		bool Platform.disabled => get_disabled();

		bool Platform.isAllowed => get_isAllowed();

		Elements_Base Platform.elements_base => get_elements_base();

		public virtual int get_assignedButtonCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.buttonCount;
		}

		public virtual int get_assignedAxisCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.axisCount;
		}

		public virtual string get_controllerNameOverride()
		{
			return controllerName;
		}

		internal virtual InputPlatform get_platform()
		{
			return InputPlatform.GameCore;
		}

		internal virtual Platform_Custom.Axis[] get_Axes()
		{
			if (_axesOrigGame == null)
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig != null)
				{
					_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
					for (int i = 0; i < axes_orig.Length; i++)
					{
						_axesOrigGame[i] = axes_orig[i];
					}
				}
			}
			return _axesOrigGame;
		}

		internal virtual Platform_Custom.Button[] get_Buttons()
		{
			if (_buttonsOrigGame == null)
			{
				Button[] buttons_orig = Buttons_orig;
				if (buttons_orig != null)
				{
					_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						_buttonsOrigGame[i] = buttons_orig[i];
					}
				}
			}
			return _buttonsOrigGame;
		}

		internal virtual bool get_hasData()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			if (!matchingCriteria.hasData)
			{
				return false;
			}
			if (assignedButtonCount == 0 && assignedAxisCount == 0)
			{
				return false;
			}
			return true;
		}

		internal virtual bool get_disabled()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.disabled;
		}

		internal virtual bool get_isAllowed()
		{
			if (!base.isAllowed)
			{
				return false;
			}
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.isAllowed;
		}

		internal virtual Elements_Base get_elements_base()
		{
			return elements;
		}

		public override IList<Platform> GetVariants()
		{
			return null;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			return false;
		}

		[IteratorStateMachine(typeof(JgvCbGcdryRoLGjxJsyKboKXEfJJ))]
		internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
		{
			return new JgvCbGcdryRoLGjxJsyKboKXEfJJ(-2)
			{
				jlOAfddspnpkMgfjKjCslJJKbdXbB = this
			};
		}

		[IteratorStateMachine(typeof(kZTOLPUvCAyqVBygMwjNUlwlRDVG))]
		internal override IEnumerable<Platform_Custom.Button> IterateButtons()
		{
			return new kZTOLPUvCAyqVBygMwjNUlwlRDVG(-2)
			{
				moWTIbYUxCLetXAapWkuljofHRmb = this
			};
		}

		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			foreach (Axis item in IterateAxes())
			{
				if (item.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			foreach (Button item2 in IterateButtons())
			{
				if (item2.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[assignedButtonCount];
			axes = new int[assignedAxisCount];
			int num = 0;
			foreach (Button item in IterateButtons())
			{
				buttons[num] = item.elementIdentifier;
				num++;
			}
			num = 0;
			foreach (Axis item2 in IterateAxes())
			{
				axes[num] = item2.elementIdentifier;
				num++;
			}
		}

		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			Axis[] axes_orig = Axes_orig;
			if (axes_orig == null)
			{
				return null;
			}
			AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
				{
					array[i] = AxisCalibrationData.Default;
					array[i].invert = axes_orig[i].invert;
					array[i].deadZone = axes_orig[i].axisDeadZone;
					if (Axes_orig[i].calibrateAxis)
					{
						array[i].zero = axes_orig[i].axisZero;
						array[i].min = axes_orig[i].axisMin;
						array[i].max = axes_orig[i].axisMax;
					}
				}
				else
				{
					if (axes_orig[i].sourceType != 0 && axes_orig[i].sourceType != 2)
					{
						throw new NotImplementedException();
					}
					array[i] = AxisCalibrationData.Default;
				}
				array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
			}
			return array;
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[Axes_orig.Length];
			for (int i = 0; i < Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
				if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
				{
					axisRanges[i] = Axes_orig[i].sourceAxisRange;
					continue;
				}
				if (Axes_orig[i].sourceType == 0 || Axes_orig[i].sourceType == 2)
				{
					axisRanges[i] = AxisRange.Full;
					continue;
				}
				throw new Exception();
			}
		}

		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = null;
			if (Buttons_orig != null)
			{
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				for (int i = 0; i < Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
				}
			}
		}

		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (elements == null)
			{
				return ControllerElementType.Axis;
			}
			return elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		public override object DeepClone()
		{
			Platform_GameCore_Base platform_GameCore_Base = new Platform_GameCore_Base();
			CopyVars(platform_GameCore_Base);
			return platform_GameCore_Base;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_GameCore_Base platform_GameCore_Base)
			{
				platform_GameCore_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
				platform_GameCore_Base.elements = MiscTools.DeepClone(elements);
				platform_GameCore_Base.controllerName = controllerName;
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Platform_GameCore : Platform_GameCore_Base
	{
		public Platform_GameCore_Base[] variants;

		public override IList<Platform> GetVariants()
		{
			return variants;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return true;
			}
			if (base.hasVariants)
			{
				for (int i = 0; i < variants.Length; i++)
				{
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		public override object DeepClone()
		{
			Platform_GameCore platform_GameCore = new Platform_GameCore();
			CopyVars(platform_GameCore);
			return platform_GameCore;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_GameCore platform_GameCore)
			{
				platform_GameCore.variants = MiscTools.DeepClone(variants);
			}
		}

		internal static Platform_GameCore CreateDefaultMap(BridgedControllerHWInfo bridgedController)
		{
			Platform_GameCore platform_GameCore = new Platform_GameCore();
			_ = Consts.unknownJoystickElementIdentifiers_orig;
			platform_GameCore.controllerName = "Unknown Controller";
			platform_GameCore.description = "";
			Elements elements = (platform_GameCore.elements = new Elements());
			int num = 32;
			elements.axes = new Axis[num];
			for (int i = 0; i < num; i++)
			{
				Axis axis = new Axis();
				elements.axes[i] = axis;
				axis.axisDeadZone = 0.1f;
				axis.axisInfo = HardwareAxisInfo.Default;
				axis.axisMin = -1f;
				axis.axisMax = 1f;
				axis.axisZero = 0f;
				axis.calibrateAxis = false;
				axis.buttonAxisContribution = Pole.Positive;
				axis.elementIdentifier = i;
				axis.invert = false;
				axis.sourceAxis = i;
				axis.sourceAxisRange = AxisRange.Full;
				axis.sourceType = 1;
			}
			int num2 = 128;
			int num3 = 2 * 8;
			elements.buttons = new Button[num2 + num3];
			for (int j = 0; j < num2; j++)
			{
				Button button = new Button();
				elements.buttons[j] = button;
				button.buttonInfo = new HardwareButtonInfo(false, false);
				button.elementIdentifier = 32 + j;
				button.sourceButton = j;
				button.sourceType = 0;
			}
			int num4 = num2;
			int num5 = 160;
			int num6 = 224;
			for (int k = 0; k < 2; k++)
			{
				for (int l = 0; l < 8; l++)
				{
					bool flag = l % 2 == 0;
					Button button2 = new Button();
					elements.buttons[num4++] = button2;
					button2.buttonInfo = new HardwareButtonInfo(false, false);
					button2.elementIdentifier = (flag ? num5++ : num6++);
					button2.sourceHat = k;
					button2.sourceType = 2;
					button2.sourceHatDirection = (HatDirection)(flag ? (l / 2) : (4 + l / 2));
				}
			}
			MatchingCriteria matchingCriteria = new MatchingCriteria();
			platform_GameCore.matchingCriteria = matchingCriteria;
			platform_GameCore.variants = new Platform_GameCore_Base[0];
			return platform_GameCore;
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class Platform_PS5_Base : Platform_Custom
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
		{
			public bool productName_useRegex;

			public string[] productName;

			bool hasData => get_hasData();

			bool isAllowed => get_isAllowed();

			internal override bool get_hasData()
			{
				if (base.get_hasData())
				{
					return true;
				}
				if (productName != null && productName.Length != 0)
				{
					return true;
				}
				return false;
			}

			internal override bool get_isAllowed()
			{
				if (!base.get_isAllowed())
				{
					return false;
				}
				if (disabled)
				{
					return false;
				}
				return true;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
				{
					return true;
				}
				if (!base.Matches(bridgedControllerHWInfo, strictMatch))
				{
					return false;
				}
				if (alwaysMatch)
				{
					return true;
				}
				string text = bridgedControllerHWInfo.hw_productName;
				if (text == null)
				{
					text = string.Empty;
				}
				text = text.Trim();
				if (productName != null)
				{
					for (int i = 0; i < productName.Length; i++)
					{
						string searchFor = productName[i];
						if (MatchingCriteria_Base.StringMatches(text, searchFor, productName_useRegex))
						{
							return true;
						}
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			internal override void CopyVars(MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				if (destination is MatchingCriteria matchingCriteria)
				{
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Elements : Platform_Custom.Elements
		{
			public Axis[] axes;

			public Button[] buttons;

			int Elements_Base.buttonCount => get_buttonCount();

			int Elements_Base.axisCount => get_axisCount();

			public int get_buttonCount()
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}

			public int get_axisCount()
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Axis;
					}
				}
				for (int j = 0; j < buttonCount; j++)
				{
					if (buttons[j].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Button;
					}
				}
				return elementIdentifier.elementType;
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier != elementIdentifier.get_id())
					{
						continue;
					}
					switch (axes[i].sourceType)
					{
					case 1:
					case 100:
						axisRange = axes[i].sourceAxisRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					case 0:
						axisRange = AxisRange.Positive;
						return true;
					default:
						throw new NotImplementedException();
					}
				}
				axisRange = AxisRange.Full;
				return false;
			}

			public override object DeepClone()
			{
				Elements elements = new Elements();
				CopyVars(elements);
				return elements;
			}

			internal override void CopyVars(Elements_Base destination)
			{
				base.CopyVars(destination);
				if (destination is Elements elements)
				{
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Button : Platform_Custom.Button
		{
			public override object DeepClone()
			{
				Button button = new Button();
				CopyVars(button);
				return button;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				_ = destination is Button;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Axis : Platform_Custom.Axis
		{
			public override object DeepClone()
			{
				Axis axis = new Axis();
				CopyVars(axis);
				return axis;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				_ = destination is Axis;
			}
		}

		private sealed class OrQSOxfRBiXyFaSLWNwOZWNJxIql : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
		{
			private int zXVjcnednvPvlBqpMAyhmAeoCVbAA;

			private Platform_Custom.Axis FIvLKvnLnwqwPUVrHOETcRtUSvkc;

			private int hPGHBAEDYiFjDbeooiFmVqXZbDWhb;

			public Platform_PS5_Base BvtYsjieFaWPcOcpuIagbpBbGDDe;

			private int iZolAqUsaGgnXhEdmakMfHUZvmDq;

			Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
			{
				[DebuggerHidden]
				get
				{
					return FIvLKvnLnwqwPUVrHOETcRtUSvkc;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return FIvLKvnLnwqwPUVrHOETcRtUSvkc;
				}
			}

			[DebuggerHidden]
			public OrQSOxfRBiXyFaSLWNwOZWNJxIql(int P_0)
			{
				zXVjcnednvPvlBqpMAyhmAeoCVbAA = P_0;
				hPGHBAEDYiFjDbeooiFmVqXZbDWhb = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = zXVjcnednvPvlBqpMAyhmAeoCVbAA;
				Platform_PS5_Base bvtYsjieFaWPcOcpuIagbpBbGDDe = BvtYsjieFaWPcOcpuIagbpBbGDDe;
				switch (num)
				{
				default:
					return false;
				case 0:
					zXVjcnednvPvlBqpMAyhmAeoCVbAA = -1;
					if (bvtYsjieFaWPcOcpuIagbpBbGDDe.elements == null || bvtYsjieFaWPcOcpuIagbpBbGDDe.elements.axes == null)
					{
						return false;
					}
					iZolAqUsaGgnXhEdmakMfHUZvmDq = 0;
					break;
				case 1:
					zXVjcnednvPvlBqpMAyhmAeoCVbAA = -1;
					iZolAqUsaGgnXhEdmakMfHUZvmDq++;
					break;
				}
				if (iZolAqUsaGgnXhEdmakMfHUZvmDq < bvtYsjieFaWPcOcpuIagbpBbGDDe.elements.axes.Length)
				{
					FIvLKvnLnwqwPUVrHOETcRtUSvkc = bvtYsjieFaWPcOcpuIagbpBbGDDe.elements.axes[iZolAqUsaGgnXhEdmakMfHUZvmDq];
					zXVjcnednvPvlBqpMAyhmAeoCVbAA = 1;
					return true;
				}
				return false;
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
			IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
			{
				OrQSOxfRBiXyFaSLWNwOZWNJxIql orQSOxfRBiXyFaSLWNwOZWNJxIql;
				if (zXVjcnednvPvlBqpMAyhmAeoCVbAA == -2 && hPGHBAEDYiFjDbeooiFmVqXZbDWhb == Environment.CurrentManagedThreadId)
				{
					zXVjcnednvPvlBqpMAyhmAeoCVbAA = 0;
					orQSOxfRBiXyFaSLWNwOZWNJxIql = this;
				}
				else
				{
					orQSOxfRBiXyFaSLWNwOZWNJxIql = new OrQSOxfRBiXyFaSLWNwOZWNJxIql(0);
					orQSOxfRBiXyFaSLWNwOZWNJxIql.BvtYsjieFaWPcOcpuIagbpBbGDDe = BvtYsjieFaWPcOcpuIagbpBbGDDe;
				}
				return orQSOxfRBiXyFaSLWNwOZWNJxIql;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
			}
		}

		private sealed class bSfvFHxrYamnmWQOgsUjDjKaiPpv : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
		{
			private int WFIlGYbnEzLUyJkBiRLIKQncHdOO;

			private Platform_Custom.Button DZJyRsNTobVLRfIDGBErHETjFNIgA;

			private int OziXWbekrgbDaqmrivyhwDMWqaIx;

			public Platform_PS5_Base vkjNRxXOPkYmjAwQovcPqKpFfPDEA;

			private int SZzgcQJpEIceKeZtJarFEpClaiIkA;

			Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
			{
				[DebuggerHidden]
				get
				{
					return DZJyRsNTobVLRfIDGBErHETjFNIgA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return DZJyRsNTobVLRfIDGBErHETjFNIgA;
				}
			}

			[DebuggerHidden]
			public bSfvFHxrYamnmWQOgsUjDjKaiPpv(int P_0)
			{
				WFIlGYbnEzLUyJkBiRLIKQncHdOO = P_0;
				OziXWbekrgbDaqmrivyhwDMWqaIx = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int wFIlGYbnEzLUyJkBiRLIKQncHdOO = WFIlGYbnEzLUyJkBiRLIKQncHdOO;
				Platform_PS5_Base platform_PS5_Base = vkjNRxXOPkYmjAwQovcPqKpFfPDEA;
				switch (wFIlGYbnEzLUyJkBiRLIKQncHdOO)
				{
				default:
					return false;
				case 0:
					WFIlGYbnEzLUyJkBiRLIKQncHdOO = -1;
					if (platform_PS5_Base.elements == null || platform_PS5_Base.elements.buttons == null)
					{
						return false;
					}
					SZzgcQJpEIceKeZtJarFEpClaiIkA = 0;
					break;
				case 1:
					WFIlGYbnEzLUyJkBiRLIKQncHdOO = -1;
					SZzgcQJpEIceKeZtJarFEpClaiIkA++;
					break;
				}
				if (SZzgcQJpEIceKeZtJarFEpClaiIkA < platform_PS5_Base.elements.buttons.Length)
				{
					DZJyRsNTobVLRfIDGBErHETjFNIgA = platform_PS5_Base.elements.buttons[SZzgcQJpEIceKeZtJarFEpClaiIkA];
					WFIlGYbnEzLUyJkBiRLIKQncHdOO = 1;
					return true;
				}
				return false;
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
			IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
			{
				bSfvFHxrYamnmWQOgsUjDjKaiPpv bSfvFHxrYamnmWQOgsUjDjKaiPpv2;
				if (WFIlGYbnEzLUyJkBiRLIKQncHdOO == -2 && OziXWbekrgbDaqmrivyhwDMWqaIx == Environment.CurrentManagedThreadId)
				{
					WFIlGYbnEzLUyJkBiRLIKQncHdOO = 0;
					bSfvFHxrYamnmWQOgsUjDjKaiPpv2 = this;
				}
				else
				{
					bSfvFHxrYamnmWQOgsUjDjKaiPpv2 = new bSfvFHxrYamnmWQOgsUjDjKaiPpv(0);
					bSfvFHxrYamnmWQOgsUjDjKaiPpv2.vkjNRxXOPkYmjAwQovcPqKpFfPDEA = vkjNRxXOPkYmjAwQovcPqKpFfPDEA;
				}
				return bSfvFHxrYamnmWQOgsUjDjKaiPpv2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
			}
		}

		public MatchingCriteria matchingCriteria;

		public Elements elements;

		public string controllerName;

		private Platform_Custom.Axis[] _axesOrigGame;

		private Platform_Custom.Button[] _buttonsOrigGame;

		int Platform.assignedButtonCount => get_assignedButtonCount();

		int Platform.assignedAxisCount => get_assignedAxisCount();

		string Platform.controllerNameOverride => get_controllerNameOverride();

		InputPlatform Platform.platform => get_platform();

		Platform_Custom.Axis[] Platform_Custom.Axes => get_Axes();

		Platform_Custom.Button[] Platform_Custom.Buttons => get_Buttons();

		internal Axis[] Axes_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.axes;
			}
		}

		internal Button[] Buttons_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.buttons;
			}
		}

		bool Platform.hasData => get_hasData();

		bool Platform.disabled => get_disabled();

		bool Platform.isAllowed => get_isAllowed();

		Elements_Base Platform.elements_base => get_elements_base();

		public virtual int get_assignedButtonCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.buttonCount;
		}

		public virtual int get_assignedAxisCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.axisCount;
		}

		public virtual string get_controllerNameOverride()
		{
			return controllerName;
		}

		internal virtual InputPlatform get_platform()
		{
			return InputPlatform.PS5;
		}

		internal virtual Platform_Custom.Axis[] get_Axes()
		{
			if (_axesOrigGame == null)
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig != null)
				{
					_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
					for (int i = 0; i < axes_orig.Length; i++)
					{
						_axesOrigGame[i] = axes_orig[i];
					}
				}
			}
			return _axesOrigGame;
		}

		internal virtual Platform_Custom.Button[] get_Buttons()
		{
			if (_buttonsOrigGame == null)
			{
				Button[] buttons_orig = Buttons_orig;
				if (buttons_orig != null)
				{
					_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						_buttonsOrigGame[i] = buttons_orig[i];
					}
				}
			}
			return _buttonsOrigGame;
		}

		internal virtual bool get_hasData()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			if (!matchingCriteria.hasData)
			{
				return false;
			}
			if (assignedButtonCount == 0 && assignedAxisCount == 0)
			{
				return false;
			}
			return true;
		}

		internal virtual bool get_disabled()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.disabled;
		}

		internal virtual bool get_isAllowed()
		{
			if (!base.isAllowed)
			{
				return false;
			}
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.isAllowed;
		}

		internal virtual Elements_Base get_elements_base()
		{
			return elements;
		}

		public override IList<Platform> GetVariants()
		{
			return null;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			return false;
		}

		[IteratorStateMachine(typeof(OrQSOxfRBiXyFaSLWNwOZWNJxIql))]
		internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
		{
			return new OrQSOxfRBiXyFaSLWNwOZWNJxIql(-2)
			{
				BvtYsjieFaWPcOcpuIagbpBbGDDe = this
			};
		}

		[IteratorStateMachine(typeof(bSfvFHxrYamnmWQOgsUjDjKaiPpv))]
		internal override IEnumerable<Platform_Custom.Button> IterateButtons()
		{
			return new bSfvFHxrYamnmWQOgsUjDjKaiPpv(-2)
			{
				vkjNRxXOPkYmjAwQovcPqKpFfPDEA = this
			};
		}

		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			foreach (Axis item in IterateAxes())
			{
				if (item.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			foreach (Button item2 in IterateButtons())
			{
				if (item2.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[assignedButtonCount];
			axes = new int[assignedAxisCount];
			int num = 0;
			foreach (Button item in IterateButtons())
			{
				buttons[num] = item.elementIdentifier;
				num++;
			}
			num = 0;
			foreach (Axis item2 in IterateAxes())
			{
				axes[num] = item2.elementIdentifier;
				num++;
			}
		}

		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			Axis[] axes_orig = Axes_orig;
			if (axes_orig == null)
			{
				return null;
			}
			AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
				{
					array[i] = AxisCalibrationData.Default;
					array[i].invert = axes_orig[i].invert;
					array[i].deadZone = axes_orig[i].axisDeadZone;
					if (Axes_orig[i].calibrateAxis)
					{
						array[i].zero = axes_orig[i].axisZero;
						array[i].min = axes_orig[i].axisMin;
						array[i].max = axes_orig[i].axisMax;
					}
				}
				else
				{
					if (axes_orig[i].sourceType != 0)
					{
						throw new NotImplementedException();
					}
					array[i] = AxisCalibrationData.Default;
				}
				array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
			}
			return array;
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[Axes_orig.Length];
			for (int i = 0; i < Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
				if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
				{
					axisRanges[i] = Axes_orig[i].sourceAxisRange;
					continue;
				}
				if (Axes_orig[i].sourceType == 0)
				{
					axisRanges[i] = AxisRange.Full;
					continue;
				}
				throw new Exception();
			}
		}

		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = null;
			if (Buttons_orig != null)
			{
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				for (int i = 0; i < Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
				}
			}
		}

		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (elements == null)
			{
				return ControllerElementType.Axis;
			}
			return elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		public override object DeepClone()
		{
			Platform_PS5_Base platform_PS5_Base = new Platform_PS5_Base();
			CopyVars(platform_PS5_Base);
			return platform_PS5_Base;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_PS5_Base platform_PS5_Base)
			{
				platform_PS5_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
				platform_PS5_Base.elements = MiscTools.DeepClone(elements);
				platform_PS5_Base.controllerName = controllerName;
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Platform_PS5 : Platform_PS5_Base
	{
		public Platform_PS5_Base[] variants;

		public override IList<Platform> GetVariants()
		{
			return variants;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return true;
			}
			if (base.hasVariants)
			{
				for (int i = 0; i < variants.Length; i++)
				{
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		public override object DeepClone()
		{
			Platform_PS5 platform_PS = new Platform_PS5();
			CopyVars(platform_PS);
			return platform_PS;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_PS5 platform_PS)
			{
				platform_PS.variants = MiscTools.DeepClone(variants);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class Platform_InternalDriver_Base : Platform_Custom
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
		{
			public bool productName_useRegex;

			public string[] productName;

			public VidPid[] vidPid;

			public int hatCount;

			bool hasData => get_hasData();

			bool isAllowed => get_isAllowed();

			internal override bool get_hasData()
			{
				if (base.get_hasData())
				{
					return true;
				}
				if (productName != null && productName.Length != 0)
				{
					return true;
				}
				if (vidPid != null && vidPid.Length != 0)
				{
					return true;
				}
				return false;
			}

			internal override bool get_isAllowed()
			{
				if (!base.get_isAllowed())
				{
					return false;
				}
				if (disabled)
				{
					return false;
				}
				return true;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
				{
					return true;
				}
				if (!base.Matches(bridgedControllerHWInfo, strictMatch))
				{
					return false;
				}
				if (alwaysMatch)
				{
					return true;
				}
				if (!ElementCountsMatch(bridgedControllerHWInfo, out var _))
				{
					return false;
				}
				string text = bridgedControllerHWInfo.hw_productName;
				if (text == null)
				{
					text = string.Empty;
				}
				text = text.Trim();
				if (strictMatch)
				{
					if (vidPid != null)
					{
						for (int i = 0; i < vidPid.Length; i++)
						{
							int vendorId = vidPid[i].vendorId;
							int productId = vidPid[i].productId;
							if (ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_vendorId))
							{
								string name = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
								if (!ProductNameMatches(name))
								{
									return false;
								}
							}
							if (bridgedControllerHWInfo.hw_vendorId == vendorId && bridgedControllerHWInfo.hw_productId == productId)
							{
								return true;
							}
						}
					}
					return false;
				}
				return ProductNameMatches(text);
			}

			internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
			{
				if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
				{
					return false;
				}
				if (alternateMatched)
				{
					return true;
				}
				if (hatCount >= 0)
				{
					return bridgedControllerHWInfo.hardwareHatCount == hatCount;
				}
				return true;
			}

			public override object DeepClone()
			{
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			internal override void CopyVars(MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				if (destination is MatchingCriteria matchingCriteria)
				{
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					matchingCriteria.vidPid = ArrayTools.ShallowCopy(vidPid);
					matchingCriteria.hatCount = hatCount;
				}
			}

			private bool ProductNameMatches(string name)
			{
				if (productName == null)
				{
					return false;
				}
				for (int i = 0; i < productName.Length; i++)
				{
					string searchFor = productName[i];
					if (MatchingCriteria_Base.StringMatches(name, searchFor, productName_useRegex))
					{
						return true;
					}
				}
				return false;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Elements : Platform_Custom.Elements
		{
			public Axis[] axes;

			public Button[] buttons;

			int Elements_Base.buttonCount => get_buttonCount();

			int Elements_Base.axisCount => get_axisCount();

			public int get_buttonCount()
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}

			public int get_axisCount()
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Axis;
					}
				}
				for (int j = 0; j < buttonCount; j++)
				{
					if (buttons[j].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Button;
					}
				}
				return elementIdentifier.elementType;
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier != elementIdentifier.get_id())
					{
						continue;
					}
					switch (axes[i].sourceType)
					{
					case 1:
					case 100:
						axisRange = axes[i].sourceAxisRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					case 0:
						axisRange = AxisRange.Positive;
						return true;
					case 2:
						axisRange = axes[i].sourceHatRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					default:
						throw new NotImplementedException();
					}
				}
				axisRange = AxisRange.Full;
				return false;
			}

			public override object DeepClone()
			{
				Elements elements = new Elements();
				CopyVars(elements);
				return elements;
			}

			internal override void CopyVars(Elements_Base destination)
			{
				base.CopyVars(destination);
				if (destination is Elements elements)
				{
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Button : Platform_Custom.Button
		{
			public int sourceHat;

			public HatDirection sourceHatDirection;

			public HatType sourceHatType;

			public override object DeepClone()
			{
				Button button = new Button();
				CopyVars(button);
				return button;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				if (destination is Button button)
				{
					button.sourceHat = sourceHat;
					button.sourceHatDirection = sourceHatDirection;
					button.sourceHatType = sourceHatType;
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Axis : Platform_Custom.Axis
		{
			public int sourceHat;

			public AxisDirection sourceHatDirection;

			public HatType sourceHatType;

			public AxisRange sourceHatRange;

			public override object DeepClone()
			{
				Axis axis = new Axis();
				CopyVars(axis);
				return axis;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				if (destination is Axis axis)
				{
					axis.sourceHat = sourceHat;
					axis.sourceHatDirection = sourceHatDirection;
					axis.sourceHatType = sourceHatType;
					axis.sourceHatRange = sourceHatRange;
				}
			}
		}

		private sealed class ksxohGNitWwcptJutaNDdrRnqmtv : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
		{
			private int nNCgfNluJwLQRcFPNmddoBMfMVyr;

			private Platform_Custom.Axis NRMXylTjOORnKPahdkCtxlabILgIA;

			private int mEvbnLXozxwQXoyfYvpBysEHSImt;

			public Platform_InternalDriver_Base XOEHjOPvZbLaVIijjQTnLURWtFMF;

			private int IFNCOevhABGhXvAzsLFPeHhlvaLD;

			Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
			{
				[DebuggerHidden]
				get
				{
					return NRMXylTjOORnKPahdkCtxlabILgIA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return NRMXylTjOORnKPahdkCtxlabILgIA;
				}
			}

			[DebuggerHidden]
			public ksxohGNitWwcptJutaNDdrRnqmtv(int P_0)
			{
				nNCgfNluJwLQRcFPNmddoBMfMVyr = P_0;
				mEvbnLXozxwQXoyfYvpBysEHSImt = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = nNCgfNluJwLQRcFPNmddoBMfMVyr;
				Platform_InternalDriver_Base xOEHjOPvZbLaVIijjQTnLURWtFMF = XOEHjOPvZbLaVIijjQTnLURWtFMF;
				switch (num)
				{
				default:
					return false;
				case 0:
					nNCgfNluJwLQRcFPNmddoBMfMVyr = -1;
					if (xOEHjOPvZbLaVIijjQTnLURWtFMF.elements == null || xOEHjOPvZbLaVIijjQTnLURWtFMF.elements.axes == null)
					{
						return false;
					}
					IFNCOevhABGhXvAzsLFPeHhlvaLD = 0;
					break;
				case 1:
					nNCgfNluJwLQRcFPNmddoBMfMVyr = -1;
					IFNCOevhABGhXvAzsLFPeHhlvaLD++;
					break;
				}
				if (IFNCOevhABGhXvAzsLFPeHhlvaLD < xOEHjOPvZbLaVIijjQTnLURWtFMF.elements.axes.Length)
				{
					NRMXylTjOORnKPahdkCtxlabILgIA = xOEHjOPvZbLaVIijjQTnLURWtFMF.elements.axes[IFNCOevhABGhXvAzsLFPeHhlvaLD];
					nNCgfNluJwLQRcFPNmddoBMfMVyr = 1;
					return true;
				}
				return false;
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
			IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
			{
				ksxohGNitWwcptJutaNDdrRnqmtv ksxohGNitWwcptJutaNDdrRnqmtv2;
				if (nNCgfNluJwLQRcFPNmddoBMfMVyr == -2 && mEvbnLXozxwQXoyfYvpBysEHSImt == Environment.CurrentManagedThreadId)
				{
					nNCgfNluJwLQRcFPNmddoBMfMVyr = 0;
					ksxohGNitWwcptJutaNDdrRnqmtv2 = this;
				}
				else
				{
					ksxohGNitWwcptJutaNDdrRnqmtv2 = new ksxohGNitWwcptJutaNDdrRnqmtv(0);
					ksxohGNitWwcptJutaNDdrRnqmtv2.XOEHjOPvZbLaVIijjQTnLURWtFMF = XOEHjOPvZbLaVIijjQTnLURWtFMF;
				}
				return ksxohGNitWwcptJutaNDdrRnqmtv2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
			}
		}

		private sealed class iqIKmEvLfMLvFgXDNUREUCrPFlTaA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
		{
			private int inoACWdDfSNIKeuwdFlAqGpIyzgPB;

			private Platform_Custom.Button wUCkdCOHgmOoAmWyFblWKcQPIxoC;

			private int SOdsAWKtbUdEGSStnLIVVsybauJI;

			public Platform_InternalDriver_Base wshEKdZQFpNWQnDmDbamAZruxiVPA;

			private int YcXYNrrnFhHfNFIhLQEfuzWNsGNUA;

			Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
			{
				[DebuggerHidden]
				get
				{
					return wUCkdCOHgmOoAmWyFblWKcQPIxoC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return wUCkdCOHgmOoAmWyFblWKcQPIxoC;
				}
			}

			[DebuggerHidden]
			public iqIKmEvLfMLvFgXDNUREUCrPFlTaA(int P_0)
			{
				inoACWdDfSNIKeuwdFlAqGpIyzgPB = P_0;
				SOdsAWKtbUdEGSStnLIVVsybauJI = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = inoACWdDfSNIKeuwdFlAqGpIyzgPB;
				Platform_InternalDriver_Base platform_InternalDriver_Base = wshEKdZQFpNWQnDmDbamAZruxiVPA;
				switch (num)
				{
				default:
					return false;
				case 0:
					inoACWdDfSNIKeuwdFlAqGpIyzgPB = -1;
					if (platform_InternalDriver_Base.elements == null || platform_InternalDriver_Base.elements.buttons == null)
					{
						return false;
					}
					YcXYNrrnFhHfNFIhLQEfuzWNsGNUA = 0;
					break;
				case 1:
					inoACWdDfSNIKeuwdFlAqGpIyzgPB = -1;
					YcXYNrrnFhHfNFIhLQEfuzWNsGNUA++;
					break;
				}
				if (YcXYNrrnFhHfNFIhLQEfuzWNsGNUA < platform_InternalDriver_Base.elements.buttons.Length)
				{
					wUCkdCOHgmOoAmWyFblWKcQPIxoC = platform_InternalDriver_Base.elements.buttons[YcXYNrrnFhHfNFIhLQEfuzWNsGNUA];
					inoACWdDfSNIKeuwdFlAqGpIyzgPB = 1;
					return true;
				}
				return false;
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
			IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
			{
				iqIKmEvLfMLvFgXDNUREUCrPFlTaA iqIKmEvLfMLvFgXDNUREUCrPFlTaA2;
				if (inoACWdDfSNIKeuwdFlAqGpIyzgPB == -2 && SOdsAWKtbUdEGSStnLIVVsybauJI == Environment.CurrentManagedThreadId)
				{
					inoACWdDfSNIKeuwdFlAqGpIyzgPB = 0;
					iqIKmEvLfMLvFgXDNUREUCrPFlTaA2 = this;
				}
				else
				{
					iqIKmEvLfMLvFgXDNUREUCrPFlTaA2 = new iqIKmEvLfMLvFgXDNUREUCrPFlTaA(0);
					iqIKmEvLfMLvFgXDNUREUCrPFlTaA2.wshEKdZQFpNWQnDmDbamAZruxiVPA = wshEKdZQFpNWQnDmDbamAZruxiVPA;
				}
				return iqIKmEvLfMLvFgXDNUREUCrPFlTaA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
			}
		}

		public MatchingCriteria matchingCriteria;

		public Elements elements;

		private Platform_Custom.Axis[] _axesOrigGame;

		private Platform_Custom.Button[] _buttonsOrigGame;

		int Platform.assignedButtonCount => get_assignedButtonCount();

		int Platform.assignedAxisCount => get_assignedAxisCount();

		InputPlatform Platform.platform => get_platform();

		Platform_Custom.Axis[] Platform_Custom.Axes => get_Axes();

		Platform_Custom.Button[] Platform_Custom.Buttons => get_Buttons();

		internal Axis[] Axes_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.axes;
			}
		}

		internal Button[] Buttons_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.buttons;
			}
		}

		bool Platform.hasData => get_hasData();

		bool Platform.disabled => get_disabled();

		bool Platform.isAllowed => get_isAllowed();

		Elements_Base Platform.elements_base => get_elements_base();

		public virtual int get_assignedButtonCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.buttonCount;
		}

		public virtual int get_assignedAxisCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.axisCount;
		}

		internal virtual InputPlatform get_platform()
		{
			return InputPlatform.InternalDriver;
		}

		internal virtual Platform_Custom.Axis[] get_Axes()
		{
			if (_axesOrigGame == null)
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig != null)
				{
					_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
					for (int i = 0; i < axes_orig.Length; i++)
					{
						_axesOrigGame[i] = axes_orig[i];
					}
				}
			}
			return _axesOrigGame;
		}

		internal virtual Platform_Custom.Button[] get_Buttons()
		{
			if (_buttonsOrigGame == null)
			{
				Button[] buttons_orig = Buttons_orig;
				if (buttons_orig != null)
				{
					_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						_buttonsOrigGame[i] = buttons_orig[i];
					}
				}
			}
			return _buttonsOrigGame;
		}

		internal virtual bool get_hasData()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			if (!matchingCriteria.hasData)
			{
				return false;
			}
			if (assignedButtonCount == 0 && assignedAxisCount == 0)
			{
				return false;
			}
			return true;
		}

		internal virtual bool get_disabled()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.disabled;
		}

		internal virtual bool get_isAllowed()
		{
			if (!base.isAllowed)
			{
				return false;
			}
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.isAllowed;
		}

		internal virtual Elements_Base get_elements_base()
		{
			return elements;
		}

		public override IList<Platform> GetVariants()
		{
			return null;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			return false;
		}

		[IteratorStateMachine(typeof(ksxohGNitWwcptJutaNDdrRnqmtv))]
		internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
		{
			return new ksxohGNitWwcptJutaNDdrRnqmtv(-2)
			{
				XOEHjOPvZbLaVIijjQTnLURWtFMF = this
			};
		}

		[IteratorStateMachine(typeof(iqIKmEvLfMLvFgXDNUREUCrPFlTaA))]
		internal override IEnumerable<Platform_Custom.Button> IterateButtons()
		{
			return new iqIKmEvLfMLvFgXDNUREUCrPFlTaA(-2)
			{
				wshEKdZQFpNWQnDmDbamAZruxiVPA = this
			};
		}

		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			foreach (Axis item in IterateAxes())
			{
				if (item.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			foreach (Button item2 in IterateButtons())
			{
				if (item2.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[assignedButtonCount];
			axes = new int[assignedAxisCount];
			int num = 0;
			foreach (Button item in IterateButtons())
			{
				buttons[num] = item.elementIdentifier;
				num++;
			}
			num = 0;
			foreach (Axis item2 in IterateAxes())
			{
				axes[num] = item2.elementIdentifier;
				num++;
			}
		}

		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			Axis[] axes_orig = Axes_orig;
			if (axes_orig == null)
			{
				return null;
			}
			AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
				{
					array[i] = AxisCalibrationData.Default;
					array[i].invert = axes_orig[i].invert;
					array[i].deadZone = axes_orig[i].axisDeadZone;
					if (Axes_orig[i].calibrateAxis)
					{
						array[i].zero = axes_orig[i].axisZero;
						array[i].min = axes_orig[i].axisMin;
						array[i].max = axes_orig[i].axisMax;
					}
				}
				else
				{
					if (axes_orig[i].sourceType != 0 && axes_orig[i].sourceType != 2)
					{
						throw new NotImplementedException();
					}
					array[i] = AxisCalibrationData.Default;
				}
				array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
			}
			return array;
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[Axes_orig.Length];
			for (int i = 0; i < Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
				if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
				{
					axisRanges[i] = Axes_orig[i].sourceAxisRange;
					continue;
				}
				if (Axes_orig[i].sourceType == 0 || Axes_orig[i].sourceType == 2)
				{
					axisRanges[i] = AxisRange.Full;
					continue;
				}
				throw new Exception();
			}
		}

		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = null;
			if (Buttons_orig != null)
			{
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				for (int i = 0; i < Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
				}
			}
		}

		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (elements == null)
			{
				return ControllerElementType.Axis;
			}
			return elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		public override object DeepClone()
		{
			Platform_InternalDriver_Base platform_InternalDriver_Base = new Platform_InternalDriver_Base();
			CopyVars(platform_InternalDriver_Base);
			return platform_InternalDriver_Base;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_InternalDriver_Base platform_InternalDriver_Base)
			{
				platform_InternalDriver_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
				platform_InternalDriver_Base.elements = MiscTools.DeepClone(elements);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Platform_InternalDriver : Platform_InternalDriver_Base
	{
		public Platform_InternalDriver_Base[] variants;

		public override IList<Platform> GetVariants()
		{
			return variants;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return true;
			}
			if (base.hasVariants)
			{
				for (int i = 0; i < variants.Length; i++)
				{
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		public override object DeepClone()
		{
			Platform_InternalDriver platform_InternalDriver = new Platform_InternalDriver();
			CopyVars(platform_InternalDriver);
			return platform_InternalDriver;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_InternalDriver platform_InternalDriver)
			{
				platform_InternalDriver.variants = MiscTools.DeepClone(variants);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class Platform_SDL2_Base : Platform
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class MatchingCriteria : MatchingCriteria_Base
		{
			[Serializable]
			public sealed class ElementCount : ElementCount_Base
			{
				public int hatCount;

				public override object DeepClone()
				{
					ElementCount elementCount = new ElementCount();
					DHyZsEQjfQXqCiERWSJlkrWZAVDE(elementCount);
					return elementCount;
				}

				internal void uOryzhzYBWjKCWpVZVzVfNvGKfSf(ElementCount_Base P_0)
				{
					base.DHyZsEQjfQXqCiERWSJlkrWZAVDE(P_0);
					if (P_0 is ElementCount elementCount)
					{
						elementCount.hatCount = hatCount;
					}
				}

				internal bool pWifNpNnYyPCIrNxLMXIGZLtwgO(BridgedControllerHWInfo P_0)
				{
					if (!base.cubDYXAvXKoMbRtseYFVkoMtvxhf(P_0))
					{
						return false;
					}
					if (hatCount >= 0)
					{
						return hatCount == P_0.hardwareHatCount;
					}
					return true;
				}
			}

			public int hatCount;

			public bool manufacturer_useRegex;

			public bool productName_useRegex;

			public bool systemName_useRegex;

			public string[] manufacturer;

			public string[] productName;

			public string[] systemName;

			public string[] productGUID;

			bool MatchingCriteria_Base.hasData => get_hasData();

			bool MatchingCriteria_Base.isAllowed => get_isAllowed();

			int MatchingCriteria_Base.alternateElementCount => get_alternateElementCount();

			internal bool get_hasData()
			{
				if (disabled)
				{
					return false;
				}
				if (productGUID != null && productGUID.Length != 0)
				{
					return true;
				}
				if (productName != null && productName.Length != 0)
				{
					return true;
				}
				return false;
			}

			internal bool get_isAllowed()
			{
				if (!base.isAllowed)
				{
					return false;
				}
				return true;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
				{
					return true;
				}
				if (!base.Matches(bridgedControllerHWInfo, strictMatch))
				{
					return false;
				}
				if (strictMatch)
				{
					if (PidVid.ArrayContains(productGUID, ref bridgedControllerHWInfo.hw_pidVid))
					{
						if (!ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
						{
							return true;
						}
						if (productName == null || productName.Length == 0)
						{
							return true;
						}
					}
					if (!AnyNameMatches(bridgedControllerHWInfo))
					{
						return false;
					}
					return true;
				}
				return AnyNameMatches(bridgedControllerHWInfo);
			}

			internal int get_alternateElementCount()
			{
				return 0;
			}

			internal override ElementCount_Base GetAlternateElementCount(int index)
			{
				return null;
			}

			internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
			{
				if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
				{
					return false;
				}
				if (alternateMatched)
				{
					return true;
				}
				if (hatCount >= 0)
				{
					return bridgedControllerHWInfo.hardwareHatCount == hatCount;
				}
				return true;
			}

			private bool AnyNameMatches(BridgedControllerHWInfo bridgedControllerHWInfo)
			{
				if (NameMatches(bridgedControllerHWInfo.hw_productName, productName, productName_useRegex))
				{
					return true;
				}
				if (NameMatches(bridgedControllerHWInfo.hw_systemDeviceName, systemName, systemName_useRegex))
				{
					return true;
				}
				return false;
			}

			private bool NameMatches(string name, string[] names, bool useRegex)
			{
				if (string.IsNullOrEmpty(name) || names == null)
				{
					return false;
				}
				string searchIn = name.Trim();
				for (int i = 0; i < names.Length; i++)
				{
					if (!string.IsNullOrEmpty(names[i]) && MatchingCriteria_Base.StringMatches(searchIn, names[i], useRegex))
					{
						return true;
					}
				}
				return false;
			}

			public override object DeepClone()
			{
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			internal override void CopyVars(MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				if (destination is MatchingCriteria matchingCriteria)
				{
					matchingCriteria.hatCount = hatCount;
					matchingCriteria.manufacturer_useRegex = manufacturer_useRegex;
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.systemName_useRegex = systemName_useRegex;
					matchingCriteria.manufacturer = ArrayTools.ShallowCopy(manufacturer);
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					matchingCriteria.systemName = ArrayTools.ShallowCopy(systemName);
					matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Elements : Elements_Base
		{
			private sealed class pMmFnMCBCBIPttZISXNJDIEkgxyfb : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
			{
				private int FJYhdRuzGbegYaLxmJLBsBAcgKkEA;

				private Axis sBNQnsVNrokJTYqcxKZYcbUiJbUd;

				private int bjRfrtmkaOHixNcximFpnkaxAUwB;

				public Elements LwZNXNGPJdjyEpJdsVfhedvOnros;

				private int sPyrhIbRogqEpZjcyDDnFmBFOJiDA;

				Axis IEnumerator<Axis>.Current
				{
					[DebuggerHidden]
					get
					{
						return sBNQnsVNrokJTYqcxKZYcbUiJbUd;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return sBNQnsVNrokJTYqcxKZYcbUiJbUd;
					}
				}

				[DebuggerHidden]
				public pMmFnMCBCBIPttZISXNJDIEkgxyfb(int P_0)
				{
					FJYhdRuzGbegYaLxmJLBsBAcgKkEA = P_0;
					bjRfrtmkaOHixNcximFpnkaxAUwB = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int fJYhdRuzGbegYaLxmJLBsBAcgKkEA = FJYhdRuzGbegYaLxmJLBsBAcgKkEA;
					Elements lwZNXNGPJdjyEpJdsVfhedvOnros = LwZNXNGPJdjyEpJdsVfhedvOnros;
					switch (fJYhdRuzGbegYaLxmJLBsBAcgKkEA)
					{
					default:
						return false;
					case 0:
						FJYhdRuzGbegYaLxmJLBsBAcgKkEA = -1;
						if (lwZNXNGPJdjyEpJdsVfhedvOnros.axes == null)
						{
							return false;
						}
						sPyrhIbRogqEpZjcyDDnFmBFOJiDA = 0;
						break;
					case 1:
						FJYhdRuzGbegYaLxmJLBsBAcgKkEA = -1;
						sPyrhIbRogqEpZjcyDDnFmBFOJiDA++;
						break;
					}
					if (sPyrhIbRogqEpZjcyDDnFmBFOJiDA < lwZNXNGPJdjyEpJdsVfhedvOnros.axes.Length)
					{
						sBNQnsVNrokJTYqcxKZYcbUiJbUd = lwZNXNGPJdjyEpJdsVfhedvOnros.axes[sPyrhIbRogqEpZjcyDDnFmBFOJiDA];
						FJYhdRuzGbegYaLxmJLBsBAcgKkEA = 1;
						return true;
					}
					return false;
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
				IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
				{
					pMmFnMCBCBIPttZISXNJDIEkgxyfb pMmFnMCBCBIPttZISXNJDIEkgxyfb2;
					if (FJYhdRuzGbegYaLxmJLBsBAcgKkEA == -2 && bjRfrtmkaOHixNcximFpnkaxAUwB == Environment.CurrentManagedThreadId)
					{
						FJYhdRuzGbegYaLxmJLBsBAcgKkEA = 0;
						pMmFnMCBCBIPttZISXNJDIEkgxyfb2 = this;
					}
					else
					{
						pMmFnMCBCBIPttZISXNJDIEkgxyfb2 = new pMmFnMCBCBIPttZISXNJDIEkgxyfb(0);
						pMmFnMCBCBIPttZISXNJDIEkgxyfb2.LwZNXNGPJdjyEpJdsVfhedvOnros = LwZNXNGPJdjyEpJdsVfhedvOnros;
					}
					return pMmFnMCBCBIPttZISXNJDIEkgxyfb2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Axis>)this).GetEnumerator();
				}
			}

			private sealed class lconboyrPaNwvmyXwnevZNAbGbxi : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
			{
				private int ZmfLIzMUXBrkLorfHxmJNKUcvQnc;

				private Button QYxTsbIlQrJKbUChShhMAxDodbLCb;

				private int ENJQjNoDwakGJPGnqHVBAwBYBBxIb;

				public Elements maajTeFIQGqDKatiHsmbgsLhgcPCA;

				private int JgnlGcoqewhpMvNXLBBadiEIgcdqA;

				Button IEnumerator<Button>.Current
				{
					[DebuggerHidden]
					get
					{
						return QYxTsbIlQrJKbUChShhMAxDodbLCb;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return QYxTsbIlQrJKbUChShhMAxDodbLCb;
					}
				}

				[DebuggerHidden]
				public lconboyrPaNwvmyXwnevZNAbGbxi(int P_0)
				{
					ZmfLIzMUXBrkLorfHxmJNKUcvQnc = P_0;
					ENJQjNoDwakGJPGnqHVBAwBYBBxIb = Environment.CurrentManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int zmfLIzMUXBrkLorfHxmJNKUcvQnc = ZmfLIzMUXBrkLorfHxmJNKUcvQnc;
					Elements elements = maajTeFIQGqDKatiHsmbgsLhgcPCA;
					switch (zmfLIzMUXBrkLorfHxmJNKUcvQnc)
					{
					default:
						return false;
					case 0:
						ZmfLIzMUXBrkLorfHxmJNKUcvQnc = -1;
						if (elements.buttons == null)
						{
							return false;
						}
						JgnlGcoqewhpMvNXLBBadiEIgcdqA = 0;
						break;
					case 1:
						ZmfLIzMUXBrkLorfHxmJNKUcvQnc = -1;
						JgnlGcoqewhpMvNXLBBadiEIgcdqA++;
						break;
					}
					if (JgnlGcoqewhpMvNXLBBadiEIgcdqA < elements.buttons.Length)
					{
						QYxTsbIlQrJKbUChShhMAxDodbLCb = elements.buttons[JgnlGcoqewhpMvNXLBBadiEIgcdqA];
						ZmfLIzMUXBrkLorfHxmJNKUcvQnc = 1;
						return true;
					}
					return false;
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
				IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
				{
					lconboyrPaNwvmyXwnevZNAbGbxi lconboyrPaNwvmyXwnevZNAbGbxi2;
					if (ZmfLIzMUXBrkLorfHxmJNKUcvQnc == -2 && ENJQjNoDwakGJPGnqHVBAwBYBBxIb == Environment.CurrentManagedThreadId)
					{
						ZmfLIzMUXBrkLorfHxmJNKUcvQnc = 0;
						lconboyrPaNwvmyXwnevZNAbGbxi2 = this;
					}
					else
					{
						lconboyrPaNwvmyXwnevZNAbGbxi2 = new lconboyrPaNwvmyXwnevZNAbGbxi(0);
						lconboyrPaNwvmyXwnevZNAbGbxi2.maajTeFIQGqDKatiHsmbgsLhgcPCA = maajTeFIQGqDKatiHsmbgsLhgcPCA;
					}
					return lconboyrPaNwvmyXwnevZNAbGbxi2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<Button>)this).GetEnumerator();
				}
			}

			public Axis[] axes;

			public Button[] buttons;

			int Elements_Base.buttonCount => get_buttonCount();

			int Elements_Base.axisCount => get_axisCount();

			internal IEnumerable<Axis> Axes
			{
				[IteratorStateMachine(typeof(pMmFnMCBCBIPttZISXNJDIEkgxyfb))]
				get
				{
					return new pMmFnMCBCBIPttZISXNJDIEkgxyfb(-2)
					{
						LwZNXNGPJdjyEpJdsVfhedvOnros = this
					};
				}
			}

			internal IEnumerable<Button> Buttons
			{
				[IteratorStateMachine(typeof(lconboyrPaNwvmyXwnevZNAbGbxi))]
				get
				{
					return new lconboyrPaNwvmyXwnevZNAbGbxi(-2)
					{
						maajTeFIQGqDKatiHsmbgsLhgcPCA = this
					};
				}
			}

			public int get_buttonCount()
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}

			public int get_axisCount()
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}

			internal Axis GetAxis(int axisIndex)
			{
				if (axes == null || axisIndex < 0 || axisIndex >= axes.Length)
				{
					return null;
				}
				return axes[axisIndex];
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Axis;
					}
				}
				for (int j = 0; j < buttonCount; j++)
				{
					if (buttons[j].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Button;
					}
				}
				return elementIdentifier.elementType;
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier != elementIdentifier.get_id())
					{
						continue;
					}
					switch (axes[i].sourceType)
					{
					case HardwareElementSourceTypeWithHat.Axis:
					case HardwareElementSourceTypeWithHat.Custom:
						axisRange = axes[i].sourceAxisRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					case HardwareElementSourceTypeWithHat.Button:
						axisRange = AxisRange.Positive;
						return true;
					case HardwareElementSourceTypeWithHat.Hat:
						axisRange = axes[i].sourceHatRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					default:
						throw new NotImplementedException();
					}
				}
				axisRange = AxisRange.Full;
				return false;
			}

			public override object DeepClone()
			{
				Elements elements = new Elements();
				CopyVars(elements);
				return elements;
			}

			internal override void CopyVars(Elements_Base destination)
			{
				base.CopyVars(destination);
				if (destination is Elements elements)
				{
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public abstract class Element : IDeepCloneable
		{
			public abstract object DeepClone();

			protected virtual void ImportVars(Element source)
			{
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Button : Element
		{
			public int elementIdentifier;

			public HardwareElementSourceTypeWithHat sourceType;

			public int sourceButton;

			public int sourceAxis;

			public Pole sourceAxisPole;

			public float axisDeadZone;

			public int sourceHat;

			public HatType sourceHatType;

			public HatDirection sourceHatDirection;

			public bool requireMultipleButtons;

			public int[] requiredButtons;

			public bool ignoreIfButtonsActive;

			public int[] ignoreIfButtonsActiveButtons;

			public HardwareButtonInfo buttonInfo;

			public Button()
			{
				sourceType = HardwareElementSourceTypeWithHat.Button;
			}

			public override object DeepClone()
			{
				Button button = new Button();
				button.ImportVars(this);
				return button;
			}

			protected override void ImportVars(Element source)
			{
				base.ImportVars(source);
				if (source is Button button)
				{
					elementIdentifier = button.elementIdentifier;
					sourceType = button.sourceType;
					sourceButton = button.sourceButton;
					sourceAxis = button.sourceAxis;
					sourceAxisPole = button.sourceAxisPole;
					axisDeadZone = button.axisDeadZone;
					sourceHat = button.sourceHat;
					sourceHatType = button.sourceHatType;
					sourceHatDirection = button.sourceHatDirection;
					requireMultipleButtons = button.requireMultipleButtons;
					requiredButtons = ArrayTools.ShallowCopy(button.requiredButtons);
					ignoreIfButtonsActive = button.ignoreIfButtonsActive;
					ignoreIfButtonsActiveButtons = ArrayTools.ShallowCopy(button.ignoreIfButtonsActiveButtons);
					buttonInfo = MiscTools.DeepClone(button.buttonInfo);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public class Axis : Element
		{
			public int elementIdentifier;

			public HardwareElementSourceTypeWithHat sourceType;

			public int sourceAxis;

			public AxisRange sourceAxisRange;

			public bool invert;

			public float axisDeadZone;

			public bool calibrateAxis;

			public float axisZero;

			public float axisMin;

			public float axisMax;

			public AxisCalibrationInfoEntry[] alternateCalibrations;

			public HardwareAxisInfo axisInfo;

			public int sourceButton;

			public Pole buttonAxisContribution;

			public int sourceHat;

			public AxisDirection sourceHatDirection;

			public AxisRange sourceHatRange;

			public Axis()
			{
				sourceType = HardwareElementSourceTypeWithHat.Axis;
			}

			public override object DeepClone()
			{
				Axis axis = new Axis();
				axis.ImportVars(this);
				return axis;
			}

			protected override void ImportVars(Element source)
			{
				base.ImportVars(source);
				if (source is Axis axis)
				{
					elementIdentifier = axis.elementIdentifier;
					sourceType = axis.sourceType;
					sourceAxis = axis.sourceAxis;
					sourceAxisRange = axis.sourceAxisRange;
					invert = axis.invert;
					axisDeadZone = axis.axisDeadZone;
					calibrateAxis = axis.calibrateAxis;
					axisZero = axis.axisZero;
					axisMin = axis.axisMin;
					axisMax = axis.axisMax;
					axisInfo = MiscTools.DeepClone(axis.axisInfo);
					sourceButton = axis.sourceButton;
					buttonAxisContribution = axis.buttonAxisContribution;
					sourceHat = axis.sourceHat;
					sourceHatDirection = axis.sourceHatDirection;
					sourceHatRange = axis.sourceHatRange;
					alternateCalibrations = MiscTools.DeepClone(axis.alternateCalibrations);
				}
			}
		}

		private sealed class pdkmIQotIWETTjSCACIJMCTtYxAI : IEnumerable<Axis>, IEnumerable, IEnumerator<Axis>, IEnumerator, IDisposable
		{
			private int rFnxhmiwiodeImnqkKKrCScRotZ;

			private Axis ybxjYCQADjCvRMVDCiHTGnXjWAui;

			private int uacRKhTSgcVnFqVWYGBbgRdBnqqM;

			public Platform_SDL2_Base WYsxcAnlRcIQAwKilTCtUJQMYAXO;

			private int YoLruCFCdriiuKjHGYMxZlbRaGli;

			private int ojNcUYaULyBNMeMlEEAKGMScOzSBA;

			Axis IEnumerator<Axis>.Current
			{
				[DebuggerHidden]
				get
				{
					return ybxjYCQADjCvRMVDCiHTGnXjWAui;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ybxjYCQADjCvRMVDCiHTGnXjWAui;
				}
			}

			[DebuggerHidden]
			public pdkmIQotIWETTjSCACIJMCTtYxAI(int P_0)
			{
				rFnxhmiwiodeImnqkKKrCScRotZ = P_0;
				uacRKhTSgcVnFqVWYGBbgRdBnqqM = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = rFnxhmiwiodeImnqkKKrCScRotZ;
				Platform_SDL2_Base wYsxcAnlRcIQAwKilTCtUJQMYAXO = WYsxcAnlRcIQAwKilTCtUJQMYAXO;
				switch (num)
				{
				default:
					return false;
				case 0:
					rFnxhmiwiodeImnqkKKrCScRotZ = -1;
					if (wYsxcAnlRcIQAwKilTCtUJQMYAXO.elements == null || wYsxcAnlRcIQAwKilTCtUJQMYAXO.elements.axes == null)
					{
						return false;
					}
					YoLruCFCdriiuKjHGYMxZlbRaGli = wYsxcAnlRcIQAwKilTCtUJQMYAXO.elements.axes.Length;
					ojNcUYaULyBNMeMlEEAKGMScOzSBA = 0;
					break;
				case 1:
					rFnxhmiwiodeImnqkKKrCScRotZ = -1;
					ojNcUYaULyBNMeMlEEAKGMScOzSBA++;
					break;
				}
				if (ojNcUYaULyBNMeMlEEAKGMScOzSBA < YoLruCFCdriiuKjHGYMxZlbRaGli)
				{
					ybxjYCQADjCvRMVDCiHTGnXjWAui = wYsxcAnlRcIQAwKilTCtUJQMYAXO.elements.axes[ojNcUYaULyBNMeMlEEAKGMScOzSBA];
					rFnxhmiwiodeImnqkKKrCScRotZ = 1;
					return true;
				}
				return false;
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
			IEnumerator<Axis> IEnumerable<Axis>.GetEnumerator()
			{
				pdkmIQotIWETTjSCACIJMCTtYxAI pdkmIQotIWETTjSCACIJMCTtYxAI2;
				if (rFnxhmiwiodeImnqkKKrCScRotZ == -2 && uacRKhTSgcVnFqVWYGBbgRdBnqqM == Environment.CurrentManagedThreadId)
				{
					rFnxhmiwiodeImnqkKKrCScRotZ = 0;
					pdkmIQotIWETTjSCACIJMCTtYxAI2 = this;
				}
				else
				{
					pdkmIQotIWETTjSCACIJMCTtYxAI2 = new pdkmIQotIWETTjSCACIJMCTtYxAI(0);
					pdkmIQotIWETTjSCACIJMCTtYxAI2.WYsxcAnlRcIQAwKilTCtUJQMYAXO = WYsxcAnlRcIQAwKilTCtUJQMYAXO;
				}
				return pdkmIQotIWETTjSCACIJMCTtYxAI2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Axis>)this).GetEnumerator();
			}
		}

		private sealed class EmQfDZGzmaWrvJBXcmALeAyqtPZDb : IEnumerable<Button>, IEnumerable, IEnumerator<Button>, IEnumerator, IDisposable
		{
			private int cxMjwlUOoZgterBKnNcSUjOgfsvm;

			private Button jTYEXdODdoupCgsJBLHPneGXLInV;

			private int jBAsyvjCEYGfaiuIHpNfgPgCtDpFB;

			public Platform_SDL2_Base PMNLcdguylFkqXyvWaWtCXJTkEmf;

			private int HlrZIlFqGPMNXliOTsTiBgodONFF;

			private int GiRjEoxeMHonXFQoFhhAEwQhbXlc;

			Button IEnumerator<Button>.Current
			{
				[DebuggerHidden]
				get
				{
					return jTYEXdODdoupCgsJBLHPneGXLInV;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return jTYEXdODdoupCgsJBLHPneGXLInV;
				}
			}

			[DebuggerHidden]
			public EmQfDZGzmaWrvJBXcmALeAyqtPZDb(int P_0)
			{
				cxMjwlUOoZgterBKnNcSUjOgfsvm = P_0;
				jBAsyvjCEYGfaiuIHpNfgPgCtDpFB = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = cxMjwlUOoZgterBKnNcSUjOgfsvm;
				Platform_SDL2_Base pMNLcdguylFkqXyvWaWtCXJTkEmf = PMNLcdguylFkqXyvWaWtCXJTkEmf;
				switch (num)
				{
				default:
					return false;
				case 0:
					cxMjwlUOoZgterBKnNcSUjOgfsvm = -1;
					if (pMNLcdguylFkqXyvWaWtCXJTkEmf.elements == null || pMNLcdguylFkqXyvWaWtCXJTkEmf.elements.buttons == null)
					{
						return false;
					}
					HlrZIlFqGPMNXliOTsTiBgodONFF = pMNLcdguylFkqXyvWaWtCXJTkEmf.elements.buttons.Length;
					GiRjEoxeMHonXFQoFhhAEwQhbXlc = 0;
					break;
				case 1:
					cxMjwlUOoZgterBKnNcSUjOgfsvm = -1;
					GiRjEoxeMHonXFQoFhhAEwQhbXlc++;
					break;
				}
				if (GiRjEoxeMHonXFQoFhhAEwQhbXlc < HlrZIlFqGPMNXliOTsTiBgodONFF)
				{
					jTYEXdODdoupCgsJBLHPneGXLInV = pMNLcdguylFkqXyvWaWtCXJTkEmf.elements.buttons[GiRjEoxeMHonXFQoFhhAEwQhbXlc];
					cxMjwlUOoZgterBKnNcSUjOgfsvm = 1;
					return true;
				}
				return false;
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
			IEnumerator<Button> IEnumerable<Button>.GetEnumerator()
			{
				EmQfDZGzmaWrvJBXcmALeAyqtPZDb emQfDZGzmaWrvJBXcmALeAyqtPZDb;
				if (cxMjwlUOoZgterBKnNcSUjOgfsvm == -2 && jBAsyvjCEYGfaiuIHpNfgPgCtDpFB == Environment.CurrentManagedThreadId)
				{
					cxMjwlUOoZgterBKnNcSUjOgfsvm = 0;
					emQfDZGzmaWrvJBXcmALeAyqtPZDb = this;
				}
				else
				{
					emQfDZGzmaWrvJBXcmALeAyqtPZDb = new EmQfDZGzmaWrvJBXcmALeAyqtPZDb(0);
					emQfDZGzmaWrvJBXcmALeAyqtPZDb.PMNLcdguylFkqXyvWaWtCXJTkEmf = PMNLcdguylFkqXyvWaWtCXJTkEmf;
				}
				return emQfDZGzmaWrvJBXcmALeAyqtPZDb;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Button>)this).GetEnumerator();
			}
		}

		public MatchingCriteria matchingCriteria;

		public Elements elements;

		InputPlatform Platform.platform => get_platform();

		bool Platform.hasData => get_hasData();

		bool Platform.disabled => get_disabled();

		bool Platform.isAllowed => get_isAllowed();

		internal Axis[] Axes_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.axes;
			}
		}

		internal Button[] Buttons_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.buttons;
			}
		}

		int Platform.assignedButtonCount => get_assignedButtonCount();

		int Platform.assignedAxisCount => get_assignedAxisCount();

		Elements_Base Platform.elements_base => get_elements_base();

		internal virtual InputPlatform get_platform()
		{
			return InputPlatform.SDL2;
		}

		internal virtual bool get_hasData()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			if (!matchingCriteria.hasData)
			{
				return false;
			}
			if (assignedAxisCount == 0 && assignedButtonCount == 0)
			{
				return false;
			}
			return true;
		}

		internal virtual bool get_disabled()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.disabled;
		}

		internal virtual bool get_isAllowed()
		{
			if (!base.isAllowed)
			{
				return false;
			}
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.isAllowed;
		}

		public override IList<Platform> GetVariants()
		{
			return null;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			return false;
		}

		public virtual int get_assignedButtonCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.buttonCount;
		}

		public virtual int get_assignedAxisCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.axisCount;
		}

		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			foreach (Axis item in IterateAxes())
			{
				if (item.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			foreach (Button item2 in IterateButtons())
			{
				if (item2.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[assignedButtonCount];
			axes = new int[assignedAxisCount];
			int num = 0;
			foreach (Button item in IterateButtons())
			{
				buttons[num] = item.elementIdentifier;
				num++;
			}
			num = 0;
			foreach (Axis item2 in IterateAxes())
			{
				axes[num] = item2.elementIdentifier;
				num++;
			}
		}

		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			Axis[] axes_orig = Axes_orig;
			if (axes_orig == null)
			{
				return null;
			}
			AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
				{
					array[i] = AxisCalibrationData.Default;
					array[i].invert = axes_orig[i].invert;
					array[i].deadZone = axes_orig[i].axisDeadZone;
					if (Axes_orig[i].calibrateAxis)
					{
						array[i].zero = axes_orig[i].axisZero;
						array[i].min = axes_orig[i].axisMin;
						array[i].max = axes_orig[i].axisMax;
					}
				}
				else
				{
					if (axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Button && axes_orig[i].sourceType != HardwareElementSourceTypeWithHat.Hat)
					{
						throw new NotImplementedException();
					}
					array[i] = AxisCalibrationData.Default;
				}
				array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
			}
			return array;
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[Axes_orig.Length];
			for (int i = 0; i < Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
				if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Axis || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Custom)
				{
					axisRanges[i] = Axes_orig[i].sourceAxisRange;
					continue;
				}
				if (Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Button || Axes_orig[i].sourceType == HardwareElementSourceTypeWithHat.Hat)
				{
					axisRanges[i] = AxisRange.Full;
					continue;
				}
				throw new Exception();
			}
		}

		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = null;
			if (Buttons_orig != null)
			{
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				for (int i = 0; i < Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
				}
			}
		}

		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (elements == null)
			{
				return ControllerElementType.Axis;
			}
			return elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		[IteratorStateMachine(typeof(pdkmIQotIWETTjSCACIJMCTtYxAI))]
		internal IEnumerable<Axis> IterateAxes()
		{
			return new pdkmIQotIWETTjSCACIJMCTtYxAI(-2)
			{
				WYsxcAnlRcIQAwKilTCtUJQMYAXO = this
			};
		}

		[IteratorStateMachine(typeof(EmQfDZGzmaWrvJBXcmALeAyqtPZDb))]
		internal IEnumerable<Button> IterateButtons()
		{
			return new EmQfDZGzmaWrvJBXcmALeAyqtPZDb(-2)
			{
				PMNLcdguylFkqXyvWaWtCXJTkEmf = this
			};
		}

		internal virtual Elements_Base get_elements_base()
		{
			return elements;
		}

		public override object DeepClone()
		{
			Platform_SDL2_Base platform_SDL2_Base = new Platform_SDL2_Base();
			CopyVars(platform_SDL2_Base);
			return platform_SDL2_Base;
		}

		internal override void CopyVars(Platform destination)
		{
			if (destination is Platform_SDL2_Base platform_SDL2_Base)
			{
				platform_SDL2_Base.elements = MiscTools.DeepClone(elements);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Platform_SDL2 : Platform_SDL2_Base
	{
		public Platform_SDL2_Base[] variants;

		public override IList<Platform> GetVariants()
		{
			return variants;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return true;
			}
			if (base.hasVariants)
			{
				for (int i = 0; i < variants.Length; i++)
				{
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		public override object DeepClone()
		{
			Platform_SDL2 platform_SDL = new Platform_SDL2();
			CopyVars(platform_SDL);
			return platform_SDL;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_SDL2 platform_SDL)
			{
				platform_SDL.variants = MiscTools.DeepClone(variants);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class Platform_Steam_Base : Platform
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class MatchingCriteria : MatchingCriteria_Base
		{
			bool MatchingCriteria_Base.hasData => get_hasData();

			bool MatchingCriteria_Base.isAllowed => get_isAllowed();

			int MatchingCriteria_Base.alternateElementCount => get_alternateElementCount();

			internal bool get_hasData()
			{
				return true;
			}

			internal bool get_isAllowed()
			{
				if (!base.isAllowed)
				{
					return false;
				}
				return true;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
				{
					return true;
				}
				if (disabled)
				{
					return false;
				}
				if (!isAllowed)
				{
					return false;
				}
				return true;
			}

			internal int get_alternateElementCount()
			{
				return 0;
			}

			internal override ElementCount_Base GetAlternateElementCount(int index)
			{
				return null;
			}

			internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
			{
				return base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched);
			}

			public override object DeepClone()
			{
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			internal override void CopyVars(MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				_ = destination is MatchingCriteria;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class Elements : Elements_Base
		{
			int Elements_Base.buttonCount => get_buttonCount();

			int Elements_Base.axisCount => get_axisCount();

			public int get_buttonCount()
			{
				return 0;
			}

			public int get_axisCount()
			{
				return 0;
			}

			public override object DeepClone()
			{
				Elements elements = new Elements();
				CopyVars(elements);
				return elements;
			}

			internal override void CopyVars(Elements_Base destination)
			{
				base.CopyVars(destination);
				_ = destination is Elements;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				return elementIdentifier.elementType;
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				axisRange = AxisRange.Full;
				return false;
			}
		}

		public MatchingCriteria matchingCriteria;

		public Elements elements;

		int Platform.assignedButtonCount => get_assignedButtonCount();

		int Platform.assignedAxisCount => get_assignedAxisCount();

		InputPlatform Platform.platform => get_platform();

		bool Platform.hasData => get_hasData();

		bool Platform.disabled => get_disabled();

		bool Platform.isAllowed => get_isAllowed();

		Elements_Base Platform.elements_base => get_elements_base();

		public virtual int get_assignedButtonCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.buttonCount;
		}

		public virtual int get_assignedAxisCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.axisCount;
		}

		internal virtual InputPlatform get_platform()
		{
			return InputPlatform.Steam;
		}

		internal virtual bool get_hasData()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			if (!matchingCriteria.hasData)
			{
				return false;
			}
			if (assignedAxisCount == 0 && assignedButtonCount == 0)
			{
				return false;
			}
			return true;
		}

		internal virtual bool get_disabled()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.disabled;
		}

		internal virtual bool get_isAllowed()
		{
			if (!base.isAllowed)
			{
				return false;
			}
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.isAllowed;
		}

		internal virtual Elements_Base get_elements_base()
		{
			return elements;
		}

		public override IList<Platform> GetVariants()
		{
			return null;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			return false;
		}

		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			return false;
		}

		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[0];
			axes = new int[0];
		}

		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			return new AxisCalibrationData[0];
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = new AxisRange[0];
			axisInfos = new HardwareAxisInfo[0];
		}

		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = new HardwareButtonInfo[0];
		}

		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (elements == null)
			{
				return ControllerElementType.Axis;
			}
			return elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		public override object DeepClone()
		{
			Platform_Steam_Base platform_Steam_Base = new Platform_Steam_Base();
			CopyVars(platform_Steam_Base);
			return platform_Steam_Base;
		}

		internal override void CopyVars(Platform destination)
		{
			if (destination is Platform_Steam_Base platform_Steam_Base)
			{
				platform_Steam_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
				platform_Steam_Base.elements = MiscTools.DeepClone(elements);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Platform_Steam : Platform_Steam_Base
	{
		public Platform_Steam_Base[] variants;

		public override IList<Platform> GetVariants()
		{
			return variants;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return true;
			}
			if (base.hasVariants)
			{
				for (int i = 0; i < variants.Length; i++)
				{
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		public override object DeepClone()
		{
			Platform_Steam platform_Steam = new Platform_Steam();
			CopyVars(platform_Steam);
			return platform_Steam;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_Steam platform_Steam)
			{
				platform_Steam.variants = MiscTools.DeepClone(variants);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class Platform_WebGL_Base : Platform_Custom
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
		{
			[Serializable]
			public sealed class ClientInfo : IDeepCloneable
			{
				public int browser;

				public string browserVersionMin;

				public string browserVersionMax;

				public int os;

				public string osVersionMin;

				public string osVersionMax;

				public object DeepClone()
				{
					return new ClientInfo
					{
						browser = browser,
						browserVersionMin = browserVersionMin,
						browserVersionMax = browserVersionMax,
						os = os,
						osVersionMin = osVersionMin,
						osVersionMax = osVersionMax
					};
				}

				object IDeepCloneable.DeepClone()
				{
					//ILSpy generated this explicit interface implementation from .override directive in DeepClone
					return this.DeepClone();
				}
			}

			public bool productName_useRegex;

			public string[] productName;

			public string[] productGUID;

			public int[] mapping;

			public ElementCount_Base[] elementCount;

			public ClientInfo[] clientInfo;

			bool hasData => get_hasData();

			bool isAllowed => get_isAllowed();

			internal override bool get_hasData()
			{
				if (base.get_hasData())
				{
					return true;
				}
				if (productName != null && productName.Length != 0)
				{
					return true;
				}
				if (mapping != null && mapping.Length != 0)
				{
					return true;
				}
				if (productGUID != null && productGUID.Length != 0)
				{
					return true;
				}
				if (elementCount != null && elementCount.Length != 0)
				{
					return true;
				}
				if (clientInfo != null && clientInfo.Length != 0)
				{
					return true;
				}
				return false;
			}

			internal override bool get_isAllowed()
			{
				if (!base.get_isAllowed())
				{
					return false;
				}
				if (disabled)
				{
					return false;
				}
				return true;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
				{
					return true;
				}
				if (!base.Matches(bridgedControllerHWInfo, strictMatch))
				{
					return false;
				}
				if (alwaysMatch)
				{
					return true;
				}
				bool result = false;
				string text = StringTools.Trim(tag);
				if (!string.IsNullOrEmpty(text) && !string.Equals(bridgedControllerHWInfo.definitionMatchTag, text, StringComparison.OrdinalIgnoreCase))
				{
					return false;
				}
				if (this.clientInfo != null && this.clientInfo.Length != 0)
				{
					bool flag = false;
					for (int i = 0; i < this.clientInfo.Length; i++)
					{
						ClientInfo clientInfo = this.clientInfo[i];
						if (clientInfo == null)
						{
							continue;
						}
						if (clientInfo.browser != 0)
						{
							if (clientInfo.browser != (int)bridgedControllerHWInfo.webGL_webBrowserType)
							{
								continue;
							}
							if (!CheckBrowserVersion(clientInfo.browser, clientInfo.browserVersionMin, clientInfo.browserVersionMax, bridgedControllerHWInfo.webGL_webBrowserVersionSplit))
							{
								return false;
							}
						}
						if (clientInfo.os != 0)
						{
							if (clientInfo.os != (int)bridgedControllerHWInfo.webGL_osType)
							{
								continue;
							}
							if (!CheckOSVersion(clientInfo.osVersionMin, clientInfo.osVersionMax, bridgedControllerHWInfo.webGL_osVersionSplit))
							{
								return false;
							}
						}
						flag = true;
						break;
					}
					if (!flag)
					{
						return false;
					}
					result = true;
				}
				if (elementCount != null && elementCount.Length != 0)
				{
					bool flag2 = false;
					for (int j = 0; j < elementCount.Length; j++)
					{
						ElementCount_Base elementCount_Base = elementCount[j];
						if (elementCount_Base != null && (elementCount_Base.buttonCount < 0 || elementCount_Base.buttonCount == bridgedControllerHWInfo.hardwareButtonCount) && (elementCount_Base.axisCount < 0 || elementCount_Base.axisCount == bridgedControllerHWInfo.hardwareAxisCount))
						{
							flag2 = true;
						}
					}
					if (!flag2)
					{
						return false;
					}
					result = true;
				}
				if (mapping != null && mapping.Length != 0)
				{
					bool flag3 = false;
					for (int k = 0; k < mapping.Length; k++)
					{
						if (mapping[k] == (int)bridgedControllerHWInfo.webGL_mappingType)
						{
							flag3 = true;
						}
					}
					if (!flag3)
					{
						return false;
					}
					result = true;
				}
				bool flag4 = false;
				bool flag5 = false;
				if (productGUID != null && productGUID.Length != 0 && !ArrayTools.Contains(Consts.questionablePidVids, bridgedControllerHWInfo.hw_pidVid))
				{
					flag5 = true;
					for (int l = 0; l < productGUID.Length; l++)
					{
						if (bridgedControllerHWInfo.hw_pidVid.Equals(productGUID[l]))
						{
							flag4 = true;
							break;
						}
					}
				}
				if (flag4)
				{
					return true;
				}
				string text2 = StringTools.Trim(bridgedControllerHWInfo.hw_productName);
				if (text2 == null)
				{
					text2 = string.Empty;
				}
				if (productName != null && productName.Length != 0)
				{
					flag5 = true;
					for (int m = 0; m < productName.Length; m++)
					{
						string searchFor = productName[m];
						if (MatchingCriteria_Base.StringMatches(text2, searchFor, productName_useRegex))
						{
							flag4 = true;
							break;
						}
					}
				}
				if (flag4)
				{
					return true;
				}
				if (flag5)
				{
					return false;
				}
				return result;
			}

			private static bool CheckBrowserVersion(int browser, string versionMin, string versionMax, string[] currentVersion)
			{
				versionMin = StringTools.Trim(versionMin);
				versionMax = StringTools.Trim(versionMax);
				bool flag = !string.IsNullOrEmpty(versionMin);
				bool flag2 = !string.IsNullOrEmpty(versionMax);
				if (!flag && !flag2)
				{
					return true;
				}
				if (currentVersion == null || currentVersion.Length == 0)
				{
					return false;
				}
				switch (browser)
				{
				case -1:
				case 0:
					return true;
				default:
					if (flag)
					{
						string[] array = versionMin.Split('.');
						int num = MathTools.Min(array.Length, currentVersion.Length);
						bool flag3 = false;
						for (int i = 0; i < num; i++)
						{
							bool flag4 = int.TryParse(array[i], out var result);
							bool flag5 = int.TryParse(currentVersion[i], out var result2);
							if (flag4 && !flag5)
							{
								return false;
							}
							if (!flag4)
							{
								break;
							}
							if (result2 < result)
							{
								return false;
							}
							flag3 = true;
						}
						if (!flag3)
						{
							return false;
						}
					}
					if (flag2)
					{
						string[] array2 = versionMax.Split('.');
						int num2 = MathTools.Min(array2.Length, currentVersion.Length);
						bool flag6 = false;
						for (int j = 0; j < num2; j++)
						{
							bool flag7 = int.TryParse(array2[j], out var result3);
							bool flag8 = int.TryParse(currentVersion[j], out var result4);
							if (flag7 && !flag8)
							{
								return false;
							}
							if (!flag7)
							{
								break;
							}
							if (result4 > result3)
							{
								return false;
							}
							flag6 = true;
						}
						if (!flag6)
						{
							return false;
						}
					}
					return true;
				}
			}

			private static bool CheckOSVersion(string versionMin, string versionMax, string[] currentVersion)
			{
				versionMin = StringTools.Trim(versionMin);
				versionMax = StringTools.Trim(versionMax);
				bool flag = !string.IsNullOrEmpty(versionMin);
				bool flag2 = !string.IsNullOrEmpty(versionMax);
				if (!flag && !flag2)
				{
					return true;
				}
				if (currentVersion == null || currentVersion.Length == 0)
				{
					return false;
				}
				if (flag)
				{
					string[] array = versionMin.Split('.');
					int num = MathTools.Min(array.Length, currentVersion.Length);
					bool flag3 = false;
					for (int i = 0; i < num; i++)
					{
						bool flag4 = int.TryParse(array[i], out var result);
						bool flag5 = int.TryParse(currentVersion[i], out var result2);
						if (flag4 && !flag5)
						{
							return false;
						}
						if (!flag4)
						{
							break;
						}
						if (result2 < result)
						{
							return false;
						}
						flag3 = true;
					}
					if (!flag3)
					{
						return false;
					}
				}
				if (flag2)
				{
					string[] array2 = versionMax.Split('.');
					int num2 = MathTools.Min(array2.Length, currentVersion.Length);
					bool flag6 = false;
					for (int j = 0; j < num2; j++)
					{
						bool flag7 = int.TryParse(array2[j], out var result3);
						bool flag8 = int.TryParse(currentVersion[j], out var result4);
						if (flag7 && !flag8)
						{
							return false;
						}
						if (!flag7)
						{
							break;
						}
						if (result4 > result3)
						{
							return false;
						}
						flag6 = true;
					}
					if (!flag6)
					{
						return false;
					}
				}
				return true;
			}

			public override object DeepClone()
			{
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			internal override void CopyVars(MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				if (destination is MatchingCriteria matchingCriteria)
				{
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					matchingCriteria.productGUID = ArrayTools.ShallowCopy(productGUID);
					matchingCriteria.mapping = ArrayTools.ShallowCopy(mapping);
					matchingCriteria.elementCount = ArrayTools.DeepClone(elementCount);
					matchingCriteria.clientInfo = ArrayTools.DeepClone(clientInfo);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Elements : Platform_Custom.Elements
		{
			public Axis[] axes;

			public Button[] buttons;

			int Elements_Base.buttonCount => get_buttonCount();

			int Elements_Base.axisCount => get_axisCount();

			public int get_buttonCount()
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}

			public int get_axisCount()
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Axis;
					}
				}
				for (int j = 0; j < buttonCount; j++)
				{
					if (buttons[j].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Button;
					}
				}
				return elementIdentifier.elementType;
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier != elementIdentifier.get_id())
					{
						continue;
					}
					switch (axes[i].sourceType)
					{
					case 1:
					case 100:
						axisRange = axes[i].sourceAxisRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					case 0:
						axisRange = AxisRange.Positive;
						return true;
					default:
						throw new NotImplementedException();
					}
				}
				axisRange = AxisRange.Full;
				return false;
			}

			public override object DeepClone()
			{
				Elements elements = new Elements();
				CopyVars(elements);
				return elements;
			}

			internal override void CopyVars(Elements_Base destination)
			{
				base.CopyVars(destination);
				if (destination is Elements elements)
				{
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Button : Platform_Custom.Button
		{
			public override object DeepClone()
			{
				Button button = new Button();
				CopyVars(button);
				return button;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				_ = destination is Button;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Axis : Platform_Custom.Axis
		{
			public override object DeepClone()
			{
				Axis axis = new Axis();
				CopyVars(axis);
				return axis;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				_ = destination is Axis;
			}
		}

		private sealed class qPYXgnDgEEIEshNVNSwNJSfAclGZA : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
		{
			private int EHMmeGFdlaQaHMcwZMQHijzVpdrV;

			private Platform_Custom.Axis aoPIDxRPnYuhMSGIeUaaIsJGbKAdA;

			private int lJQNYqRgtnOdHQCcfiTxphLpZQGb;

			public Platform_WebGL_Base mKoaZeGRDsQKGZgmAODGjXlHqjOJb;

			private int cbGDBsgONRfGBowabRiGaADVDUVDb;

			Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
			{
				[DebuggerHidden]
				get
				{
					return aoPIDxRPnYuhMSGIeUaaIsJGbKAdA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aoPIDxRPnYuhMSGIeUaaIsJGbKAdA;
				}
			}

			[DebuggerHidden]
			public qPYXgnDgEEIEshNVNSwNJSfAclGZA(int P_0)
			{
				EHMmeGFdlaQaHMcwZMQHijzVpdrV = P_0;
				lJQNYqRgtnOdHQCcfiTxphLpZQGb = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int eHMmeGFdlaQaHMcwZMQHijzVpdrV = EHMmeGFdlaQaHMcwZMQHijzVpdrV;
				Platform_WebGL_Base platform_WebGL_Base = mKoaZeGRDsQKGZgmAODGjXlHqjOJb;
				switch (eHMmeGFdlaQaHMcwZMQHijzVpdrV)
				{
				default:
					return false;
				case 0:
					EHMmeGFdlaQaHMcwZMQHijzVpdrV = -1;
					if (platform_WebGL_Base.elements == null || platform_WebGL_Base.elements.axes == null)
					{
						return false;
					}
					cbGDBsgONRfGBowabRiGaADVDUVDb = 0;
					break;
				case 1:
					EHMmeGFdlaQaHMcwZMQHijzVpdrV = -1;
					cbGDBsgONRfGBowabRiGaADVDUVDb++;
					break;
				}
				if (cbGDBsgONRfGBowabRiGaADVDUVDb < platform_WebGL_Base.elements.axes.Length)
				{
					aoPIDxRPnYuhMSGIeUaaIsJGbKAdA = platform_WebGL_Base.elements.axes[cbGDBsgONRfGBowabRiGaADVDUVDb];
					EHMmeGFdlaQaHMcwZMQHijzVpdrV = 1;
					return true;
				}
				return false;
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
			IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
			{
				qPYXgnDgEEIEshNVNSwNJSfAclGZA qPYXgnDgEEIEshNVNSwNJSfAclGZA2;
				if (EHMmeGFdlaQaHMcwZMQHijzVpdrV == -2 && lJQNYqRgtnOdHQCcfiTxphLpZQGb == Environment.CurrentManagedThreadId)
				{
					EHMmeGFdlaQaHMcwZMQHijzVpdrV = 0;
					qPYXgnDgEEIEshNVNSwNJSfAclGZA2 = this;
				}
				else
				{
					qPYXgnDgEEIEshNVNSwNJSfAclGZA2 = new qPYXgnDgEEIEshNVNSwNJSfAclGZA(0);
					qPYXgnDgEEIEshNVNSwNJSfAclGZA2.mKoaZeGRDsQKGZgmAODGjXlHqjOJb = mKoaZeGRDsQKGZgmAODGjXlHqjOJb;
				}
				return qPYXgnDgEEIEshNVNSwNJSfAclGZA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
			}
		}

		private sealed class RsZrKnMdmuWRkngpcpXemkFpvPjP : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
		{
			private int YzNhcwSuMShbYVioRvVRBqKpiZaS;

			private Platform_Custom.Button MlVnUAeBTMDzXfZIkOgRCSfQBFah;

			private int JMjyffSPsKtAUWlHexMnuusKodJm;

			public Platform_WebGL_Base dTLmryjkqWhDgSqbYIVidVoNSFYTA;

			private int nVBGaokaQyZLqpiEoKFmGqNCiAapA;

			Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
			{
				[DebuggerHidden]
				get
				{
					return MlVnUAeBTMDzXfZIkOgRCSfQBFah;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return MlVnUAeBTMDzXfZIkOgRCSfQBFah;
				}
			}

			[DebuggerHidden]
			public RsZrKnMdmuWRkngpcpXemkFpvPjP(int P_0)
			{
				YzNhcwSuMShbYVioRvVRBqKpiZaS = P_0;
				JMjyffSPsKtAUWlHexMnuusKodJm = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int yzNhcwSuMShbYVioRvVRBqKpiZaS = YzNhcwSuMShbYVioRvVRBqKpiZaS;
				Platform_WebGL_Base platform_WebGL_Base = dTLmryjkqWhDgSqbYIVidVoNSFYTA;
				switch (yzNhcwSuMShbYVioRvVRBqKpiZaS)
				{
				default:
					return false;
				case 0:
					YzNhcwSuMShbYVioRvVRBqKpiZaS = -1;
					if (platform_WebGL_Base.elements == null || platform_WebGL_Base.elements.buttons == null)
					{
						return false;
					}
					nVBGaokaQyZLqpiEoKFmGqNCiAapA = 0;
					break;
				case 1:
					YzNhcwSuMShbYVioRvVRBqKpiZaS = -1;
					nVBGaokaQyZLqpiEoKFmGqNCiAapA++;
					break;
				}
				if (nVBGaokaQyZLqpiEoKFmGqNCiAapA < platform_WebGL_Base.elements.buttons.Length)
				{
					MlVnUAeBTMDzXfZIkOgRCSfQBFah = platform_WebGL_Base.elements.buttons[nVBGaokaQyZLqpiEoKFmGqNCiAapA];
					YzNhcwSuMShbYVioRvVRBqKpiZaS = 1;
					return true;
				}
				return false;
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
			IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
			{
				RsZrKnMdmuWRkngpcpXemkFpvPjP rsZrKnMdmuWRkngpcpXemkFpvPjP;
				if (YzNhcwSuMShbYVioRvVRBqKpiZaS == -2 && JMjyffSPsKtAUWlHexMnuusKodJm == Environment.CurrentManagedThreadId)
				{
					YzNhcwSuMShbYVioRvVRBqKpiZaS = 0;
					rsZrKnMdmuWRkngpcpXemkFpvPjP = this;
				}
				else
				{
					rsZrKnMdmuWRkngpcpXemkFpvPjP = new RsZrKnMdmuWRkngpcpXemkFpvPjP(0);
					rsZrKnMdmuWRkngpcpXemkFpvPjP.dTLmryjkqWhDgSqbYIVidVoNSFYTA = dTLmryjkqWhDgSqbYIVidVoNSFYTA;
				}
				return rsZrKnMdmuWRkngpcpXemkFpvPjP;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
			}
		}

		public MatchingCriteria matchingCriteria;

		public Elements elements;

		private Platform_Custom.Axis[] _axesOrigGame;

		private Platform_Custom.Button[] _buttonsOrigGame;

		int Platform.assignedButtonCount => get_assignedButtonCount();

		int Platform.assignedAxisCount => get_assignedAxisCount();

		InputPlatform Platform.platform => get_platform();

		Platform_Custom.Axis[] Platform_Custom.Axes => get_Axes();

		Platform_Custom.Button[] Platform_Custom.Buttons => get_Buttons();

		internal Axis[] Axes_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.axes;
			}
		}

		internal Button[] Buttons_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.buttons;
			}
		}

		bool Platform.hasData => get_hasData();

		bool Platform.disabled => get_disabled();

		bool Platform.isAllowed => get_isAllowed();

		Elements_Base Platform.elements_base => get_elements_base();

		public virtual int get_assignedButtonCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.buttonCount;
		}

		public virtual int get_assignedAxisCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.axisCount;
		}

		internal virtual InputPlatform get_platform()
		{
			return InputPlatform.WebGL;
		}

		internal virtual Platform_Custom.Axis[] get_Axes()
		{
			if (_axesOrigGame == null)
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig != null)
				{
					_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
					for (int i = 0; i < axes_orig.Length; i++)
					{
						_axesOrigGame[i] = axes_orig[i];
					}
				}
			}
			return _axesOrigGame;
		}

		internal virtual Platform_Custom.Button[] get_Buttons()
		{
			if (_buttonsOrigGame == null)
			{
				Button[] buttons_orig = Buttons_orig;
				if (buttons_orig != null)
				{
					_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						_buttonsOrigGame[i] = buttons_orig[i];
					}
				}
			}
			return _buttonsOrigGame;
		}

		internal virtual bool get_hasData()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			if (!matchingCriteria.hasData)
			{
				return false;
			}
			if (assignedButtonCount == 0 && assignedAxisCount == 0)
			{
				return false;
			}
			return true;
		}

		internal virtual bool get_disabled()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.disabled;
		}

		internal virtual bool get_isAllowed()
		{
			if (!base.isAllowed)
			{
				return false;
			}
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.isAllowed;
		}

		internal virtual Elements_Base get_elements_base()
		{
			return elements;
		}

		public override IList<Platform> GetVariants()
		{
			return null;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			return false;
		}

		[IteratorStateMachine(typeof(qPYXgnDgEEIEshNVNSwNJSfAclGZA))]
		internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
		{
			return new qPYXgnDgEEIEshNVNSwNJSfAclGZA(-2)
			{
				mKoaZeGRDsQKGZgmAODGjXlHqjOJb = this
			};
		}

		[IteratorStateMachine(typeof(RsZrKnMdmuWRkngpcpXemkFpvPjP))]
		internal override IEnumerable<Platform_Custom.Button> IterateButtons()
		{
			return new RsZrKnMdmuWRkngpcpXemkFpvPjP(-2)
			{
				dTLmryjkqWhDgSqbYIVidVoNSFYTA = this
			};
		}

		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			foreach (Axis item in IterateAxes())
			{
				if (item.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			foreach (Button item2 in IterateButtons())
			{
				if (item2.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[assignedButtonCount];
			axes = new int[assignedAxisCount];
			int num = 0;
			foreach (Button item in IterateButtons())
			{
				buttons[num] = item.elementIdentifier;
				num++;
			}
			num = 0;
			foreach (Axis item2 in IterateAxes())
			{
				axes[num] = item2.elementIdentifier;
				num++;
			}
		}

		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			Axis[] axes_orig = Axes_orig;
			if (axes_orig == null)
			{
				return null;
			}
			AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
				{
					array[i] = AxisCalibrationData.Default;
					array[i].invert = axes_orig[i].invert;
					array[i].deadZone = axes_orig[i].axisDeadZone;
					if (Axes_orig[i].calibrateAxis)
					{
						array[i].zero = axes_orig[i].axisZero;
						array[i].min = axes_orig[i].axisMin;
						array[i].max = axes_orig[i].axisMax;
					}
				}
				else
				{
					if (axes_orig[i].sourceType != 0)
					{
						throw new NotImplementedException();
					}
					array[i] = AxisCalibrationData.Default;
				}
				array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
			}
			return array;
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[Axes_orig.Length];
			for (int i = 0; i < Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
				if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
				{
					axisRanges[i] = Axes_orig[i].sourceAxisRange;
					continue;
				}
				if (Axes_orig[i].sourceType == 0)
				{
					axisRanges[i] = AxisRange.Full;
					continue;
				}
				throw new Exception();
			}
		}

		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = null;
			if (Buttons_orig != null)
			{
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				for (int i = 0; i < Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
				}
			}
		}

		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (elements == null)
			{
				return ControllerElementType.Axis;
			}
			return elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		public override object DeepClone()
		{
			Platform_WebGL_Base platform_WebGL_Base = new Platform_WebGL_Base();
			CopyVars(platform_WebGL_Base);
			return platform_WebGL_Base;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_WebGL_Base platform_WebGL_Base)
			{
				platform_WebGL_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
				platform_WebGL_Base.elements = MiscTools.DeepClone(elements);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Platform_WebGL : Platform_WebGL_Base
	{
		public Platform_WebGL_Base[] variants;

		public override IList<Platform> GetVariants()
		{
			return variants;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return true;
			}
			if (base.hasVariants)
			{
				for (int i = 0; i < variants.Length; i++)
				{
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		public override object DeepClone()
		{
			Platform_WebGL platform_WebGL = new Platform_WebGL();
			CopyVars(platform_WebGL);
			return platform_WebGL;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_WebGL platform_WebGL)
			{
				platform_WebGL.variants = MiscTools.DeepClone(variants);
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class Platform_AppleGCController_Base : Platform_Custom
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
		{
			public bool productCategory_useRegex;

			public string[] productCategory;

			public bool productName_useRegex;

			public string[] productName;

			public AppleGCControllerProfileTypeFlags primaryProfileType;

			public AppleGCControllerProfileSubType[] profileSubTypes;

			bool hasData => get_hasData();

			bool isAllowed => get_isAllowed();

			internal override bool get_hasData()
			{
				if (base.get_hasData())
				{
					return true;
				}
				if (productCategory != null && productCategory.Length != 0)
				{
					return true;
				}
				if (productName != null && productName.Length != 0)
				{
					return true;
				}
				if (primaryProfileType != AppleGCControllerProfileTypeFlags.None)
				{
					return true;
				}
				if (profileSubTypes != null && profileSubTypes.Length != 0)
				{
					return true;
				}
				return false;
			}

			internal override bool get_isAllowed()
			{
				if (!base.get_isAllowed())
				{
					return false;
				}
				if (disabled)
				{
					return false;
				}
				return true;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
				{
					return true;
				}
				if (alwaysMatch)
				{
					return true;
				}
				if (!base.Matches(bridgedControllerHWInfo, strictMatch))
				{
					return false;
				}
				if (!ElementCountsMatch(bridgedControllerHWInfo, out var _))
				{
					return false;
				}
				bool flag = HasProductName();
				bool flag2 = HasProductCategory();
				bool result = false;
				if (primaryProfileType != AppleGCControllerProfileTypeFlags.None)
				{
					if (((uint)bridgedControllerHWInfo.deviceType & (uint)primaryProfileType) == 0)
					{
						return false;
					}
					if (profileSubTypes != null && profileSubTypes.Length != 0)
					{
						bool flag3 = false;
						for (int i = 0; i < profileSubTypes.Length; i++)
						{
							if (profileSubTypes[i] == (AppleGCControllerProfileSubType)bridgedControllerHWInfo.hw_xInputSubType)
							{
								flag3 = true;
								break;
							}
						}
						if (!flag3)
						{
							return false;
						}
					}
					result = true;
				}
				bool flag4 = false;
				if (flag2)
				{
					flag4 = true;
					if (!string.IsNullOrEmpty(bridgedControllerHWInfo.hw_systemDeviceName) && ProductCategoryMatches(bridgedControllerHWInfo.hw_systemDeviceName.Trim()))
					{
						return true;
					}
				}
				if (flag)
				{
					flag4 = true;
					if (!string.IsNullOrEmpty(bridgedControllerHWInfo.hw_productName) && ProductNameMatches(bridgedControllerHWInfo.hw_productName.Trim()))
					{
						return true;
					}
				}
				if (flag4)
				{
					return false;
				}
				return result;
			}

			public override object DeepClone()
			{
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			internal override void CopyVars(MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				if (destination is MatchingCriteria matchingCriteria)
				{
					matchingCriteria.productCategory_useRegex = productCategory_useRegex;
					matchingCriteria.productCategory = ArrayTools.ShallowCopy(productCategory);
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					matchingCriteria.primaryProfileType = primaryProfileType;
					matchingCriteria.profileSubTypes = ArrayTools.ShallowCopy(profileSubTypes);
				}
			}

			private bool HasProductCategory()
			{
				if (productCategory == null)
				{
					return false;
				}
				for (int i = 0; i < productCategory.Length; i++)
				{
					if (!string.IsNullOrEmpty(productCategory[i]))
					{
						return true;
					}
				}
				return false;
			}

			private bool ProductCategoryMatches(string name)
			{
				if (productCategory == null)
				{
					return false;
				}
				for (int i = 0; i < productCategory.Length; i++)
				{
					string searchFor = productCategory[i];
					if (MatchingCriteria_Base.StringMatches(name, searchFor, productCategory_useRegex))
					{
						return true;
					}
				}
				return false;
			}

			private bool HasProductName()
			{
				if (productName == null)
				{
					return false;
				}
				for (int i = 0; i < productName.Length; i++)
				{
					if (!string.IsNullOrEmpty(productName[i]))
					{
						return true;
					}
				}
				return false;
			}

			private bool ProductNameMatches(string name)
			{
				if (productName == null)
				{
					return false;
				}
				for (int i = 0; i < productName.Length; i++)
				{
					string searchFor = productName[i];
					if (MatchingCriteria_Base.StringMatches(name, searchFor, productName_useRegex))
					{
						return true;
					}
				}
				return false;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Elements : Platform_Custom.Elements
		{
			public Axis[] axes;

			public Button[] buttons;

			public CompoundElement[] compoundElements;

			int Elements_Base.buttonCount => get_buttonCount();

			int Elements_Base.axisCount => get_axisCount();

			public int compoundElementCount
			{
				get
				{
					if (compoundElements == null)
					{
						return 0;
					}
					return compoundElements.Length;
				}
			}

			public int get_buttonCount()
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}

			public int get_axisCount()
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Axis;
					}
				}
				for (int j = 0; j < buttonCount; j++)
				{
					if (buttons[j].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Button;
					}
				}
				return elementIdentifier.elementType;
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier != elementIdentifier.get_id())
					{
						continue;
					}
					switch (axes[i].sourceType)
					{
					case 1:
					case 100:
						axisRange = axes[i].sourceAxisRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					case 0:
						axisRange = AxisRange.Positive;
						return true;
					default:
						throw new NotImplementedException();
					}
				}
				axisRange = AxisRange.Full;
				return false;
			}

			public override object DeepClone()
			{
				Elements elements = new Elements();
				CopyVars(elements);
				return elements;
			}

			internal override void CopyVars(Elements_Base destination)
			{
				base.CopyVars(destination);
				if (destination is Elements elements)
				{
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
					elements.compoundElements = ArrayTools.DeepClone(compoundElements);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Button : Platform_Custom.Button
		{
			public AppleGCControllerElementIdentifier sourceElementId;

			public override object DeepClone()
			{
				Button button = new Button();
				CopyVars(button);
				return button;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				if (destination is Button button)
				{
					button.sourceElementId = sourceElementId;
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Axis : Platform_Custom.Axis
		{
			public AppleGCControllerElementIdentifier sourceElementId;

			public override object DeepClone()
			{
				Axis axis = new Axis();
				CopyVars(axis);
				return axis;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				if (destination is Axis axis)
				{
					axis.sourceElementId = sourceElementId;
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public sealed class CompoundElement : IDeepCloneable
		{
			public int elementIdentifier;

			public int sourceElementIndex;

			public AppleGCControllerElementIdentifierCompoundElements sourceElementId;

			internal void CopyVars(CompoundElement destination)
			{
				destination.elementIdentifier = elementIdentifier;
				destination.sourceElementIndex = sourceElementIndex;
				destination.sourceElementId = sourceElementId;
			}

			public object DeepClone()
			{
				CompoundElement compoundElement = new CompoundElement();
				CopyVars(compoundElement);
				return compoundElement;
			}

			object IDeepCloneable.DeepClone()
			{
				//ILSpy generated this explicit interface implementation from .override directive in DeepClone
				return this.DeepClone();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public enum AppleGCControllerProfileTypeFlags
		{
			None = 0,
			Generic = 1,
			ExtendedGamepad = 2,
			MicroGamepad = 4,
			Unknown = int.MinValue
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public enum AppleGCControllerProfileSubType
		{
			None = 0,
			Xbox = 1,
			DualShock = 2,
			DualSense = 3,
			Unknown = -1
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public enum AppleGCControllerElementIdentifier
		{
			None = 0,
			A = 1,
			B = 2,
			X = 3,
			Y = 4,
			LeftShoulder = 5,
			RightShoulder = 6,
			Menu = 7,
			Options = 8,
			Home = 9,
			LeftStickButton = 10,
			RightStickButton = 11,
			DPadUp = 12,
			DPadRight = 13,
			DPadDown = 14,
			DPadLeft = 15,
			LeftStickX = 16,
			LeftStickY = 17,
			RightStickX = 18,
			RightStickY = 19,
			LeftTrigger = 20,
			RightTrigger = 21,
			DPadVertical = 22,
			DPadHorizontal = 23,
			TouchpadButton = 24,
			Paddle1 = 25,
			Paddle2 = 26,
			Paddle3 = 27,
			Paddle4 = 28,
			IndexedButton = 29,
			IndexedAxis = 30
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public enum AppleGCControllerElementIdentifierCompoundElements
		{
			None = 0,
			IndexedStick = 31,
			IndexedDPad = 32,
			LeftStick = 33,
			RightStick = 34,
			DPad = 35
		}

		[CustomObfuscation(rename = false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal enum AppleGCControllerElementIdentifierAxes
		{
			[CustomObfuscation(rename = false)]
			None = 0,
			[CustomObfuscation(rename = false)]
			LeftStickX = 16,
			[CustomObfuscation(rename = false)]
			LeftStickY = 17,
			[CustomObfuscation(rename = false)]
			RightStickX = 18,
			[CustomObfuscation(rename = false)]
			RightStickY = 19,
			[CustomObfuscation(rename = false)]
			DPadVertical = 22,
			[CustomObfuscation(rename = false)]
			DPadHorizontal = 23,
			[CustomObfuscation(rename = false)]
			IndexedAxis = 30
		}

		[CustomObfuscation(rename = false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal enum AppleGCControllerElementIdentifierButtons
		{
			[CustomObfuscation(rename = false)]
			None = 0,
			[CustomObfuscation(rename = false)]
			A = 1,
			[CustomObfuscation(rename = false)]
			B = 2,
			[CustomObfuscation(rename = false)]
			X = 3,
			[CustomObfuscation(rename = false)]
			Y = 4,
			[CustomObfuscation(rename = false)]
			LeftShoulder = 5,
			[CustomObfuscation(rename = false)]
			RightShoulder = 6,
			[CustomObfuscation(rename = false)]
			Menu = 7,
			[CustomObfuscation(rename = false)]
			Options = 8,
			[CustomObfuscation(rename = false)]
			Home = 9,
			[CustomObfuscation(rename = false)]
			LeftStickButton = 10,
			[CustomObfuscation(rename = false)]
			RightStickButton = 11,
			[CustomObfuscation(rename = false)]
			DPadUp = 12,
			[CustomObfuscation(rename = false)]
			DPadRight = 13,
			[CustomObfuscation(rename = false)]
			DPadDown = 14,
			[CustomObfuscation(rename = false)]
			DPadLeft = 15,
			[CustomObfuscation(rename = false)]
			LeftTrigger = 20,
			[CustomObfuscation(rename = false)]
			RightTrigger = 21,
			[CustomObfuscation(rename = false)]
			TouchpadButton = 24,
			[CustomObfuscation(rename = false)]
			Paddle1 = 25,
			[CustomObfuscation(rename = false)]
			Paddle2 = 26,
			[CustomObfuscation(rename = false)]
			Paddle3 = 27,
			[CustomObfuscation(rename = false)]
			Paddle4 = 28,
			[CustomObfuscation(rename = false)]
			IndexedButton = 29
		}

		private sealed class kVjougmiOLPtPKtBTZXTwkGNoMxh : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
		{
			private int FmXReBMtAkMTxClrLwUhvuffyVML;

			private Platform_Custom.Axis pnferDAyUDengpISPTvePnEdnYfAb;

			private int hHiGrxsHYVfdUjfDbndkNcjJWWyDA;

			public Platform_AppleGCController_Base JPAvJzVQNKPsFboDFEtmEVFnLtlGA;

			private int VWpgdVibmtGEWDVOWoPuqszXjjxO;

			Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
			{
				[DebuggerHidden]
				get
				{
					return pnferDAyUDengpISPTvePnEdnYfAb;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return pnferDAyUDengpISPTvePnEdnYfAb;
				}
			}

			[DebuggerHidden]
			public kVjougmiOLPtPKtBTZXTwkGNoMxh(int P_0)
			{
				FmXReBMtAkMTxClrLwUhvuffyVML = P_0;
				hHiGrxsHYVfdUjfDbndkNcjJWWyDA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int fmXReBMtAkMTxClrLwUhvuffyVML = FmXReBMtAkMTxClrLwUhvuffyVML;
				Platform_AppleGCController_Base jPAvJzVQNKPsFboDFEtmEVFnLtlGA = JPAvJzVQNKPsFboDFEtmEVFnLtlGA;
				switch (fmXReBMtAkMTxClrLwUhvuffyVML)
				{
				default:
					return false;
				case 0:
					FmXReBMtAkMTxClrLwUhvuffyVML = -1;
					if (jPAvJzVQNKPsFboDFEtmEVFnLtlGA.elements == null || jPAvJzVQNKPsFboDFEtmEVFnLtlGA.elements.axes == null)
					{
						return false;
					}
					VWpgdVibmtGEWDVOWoPuqszXjjxO = 0;
					break;
				case 1:
					FmXReBMtAkMTxClrLwUhvuffyVML = -1;
					VWpgdVibmtGEWDVOWoPuqszXjjxO++;
					break;
				}
				if (VWpgdVibmtGEWDVOWoPuqszXjjxO < jPAvJzVQNKPsFboDFEtmEVFnLtlGA.elements.axes.Length)
				{
					pnferDAyUDengpISPTvePnEdnYfAb = jPAvJzVQNKPsFboDFEtmEVFnLtlGA.elements.axes[VWpgdVibmtGEWDVOWoPuqszXjjxO];
					FmXReBMtAkMTxClrLwUhvuffyVML = 1;
					return true;
				}
				return false;
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
			IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
			{
				kVjougmiOLPtPKtBTZXTwkGNoMxh kVjougmiOLPtPKtBTZXTwkGNoMxh2;
				if (FmXReBMtAkMTxClrLwUhvuffyVML == -2 && hHiGrxsHYVfdUjfDbndkNcjJWWyDA == Environment.CurrentManagedThreadId)
				{
					FmXReBMtAkMTxClrLwUhvuffyVML = 0;
					kVjougmiOLPtPKtBTZXTwkGNoMxh2 = this;
				}
				else
				{
					kVjougmiOLPtPKtBTZXTwkGNoMxh2 = new kVjougmiOLPtPKtBTZXTwkGNoMxh(0);
					kVjougmiOLPtPKtBTZXTwkGNoMxh2.JPAvJzVQNKPsFboDFEtmEVFnLtlGA = JPAvJzVQNKPsFboDFEtmEVFnLtlGA;
				}
				return kVjougmiOLPtPKtBTZXTwkGNoMxh2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
			}
		}

		private sealed class zVRmTCsKxjSzpmvbDGsryylginIA : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
		{
			private int eSsAeIeGxqbqlkYQbcDJjSIMohvX;

			private Platform_Custom.Button FVDZkrZPcVtlKaFXRJgLHYKEKKff;

			private int aKcKwMROlSwsXVadHymBEKogAJUEA;

			public Platform_AppleGCController_Base IfFcJYmJGYEznsLuufICJJNkKfaib;

			private int qhJMjjPZBlaaIWLwSIHykQvwGkPb;

			Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
			{
				[DebuggerHidden]
				get
				{
					return FVDZkrZPcVtlKaFXRJgLHYKEKKff;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return FVDZkrZPcVtlKaFXRJgLHYKEKKff;
				}
			}

			[DebuggerHidden]
			public zVRmTCsKxjSzpmvbDGsryylginIA(int P_0)
			{
				eSsAeIeGxqbqlkYQbcDJjSIMohvX = P_0;
				aKcKwMROlSwsXVadHymBEKogAJUEA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = eSsAeIeGxqbqlkYQbcDJjSIMohvX;
				Platform_AppleGCController_Base ifFcJYmJGYEznsLuufICJJNkKfaib = IfFcJYmJGYEznsLuufICJJNkKfaib;
				switch (num)
				{
				default:
					return false;
				case 0:
					eSsAeIeGxqbqlkYQbcDJjSIMohvX = -1;
					if (ifFcJYmJGYEznsLuufICJJNkKfaib.elements == null || ifFcJYmJGYEznsLuufICJJNkKfaib.elements.buttons == null)
					{
						return false;
					}
					qhJMjjPZBlaaIWLwSIHykQvwGkPb = 0;
					break;
				case 1:
					eSsAeIeGxqbqlkYQbcDJjSIMohvX = -1;
					qhJMjjPZBlaaIWLwSIHykQvwGkPb++;
					break;
				}
				if (qhJMjjPZBlaaIWLwSIHykQvwGkPb < ifFcJYmJGYEznsLuufICJJNkKfaib.elements.buttons.Length)
				{
					FVDZkrZPcVtlKaFXRJgLHYKEKKff = ifFcJYmJGYEznsLuufICJJNkKfaib.elements.buttons[qhJMjjPZBlaaIWLwSIHykQvwGkPb];
					eSsAeIeGxqbqlkYQbcDJjSIMohvX = 1;
					return true;
				}
				return false;
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
			IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
			{
				zVRmTCsKxjSzpmvbDGsryylginIA zVRmTCsKxjSzpmvbDGsryylginIA2;
				if (eSsAeIeGxqbqlkYQbcDJjSIMohvX == -2 && aKcKwMROlSwsXVadHymBEKogAJUEA == Environment.CurrentManagedThreadId)
				{
					eSsAeIeGxqbqlkYQbcDJjSIMohvX = 0;
					zVRmTCsKxjSzpmvbDGsryylginIA2 = this;
				}
				else
				{
					zVRmTCsKxjSzpmvbDGsryylginIA2 = new zVRmTCsKxjSzpmvbDGsryylginIA(0);
					zVRmTCsKxjSzpmvbDGsryylginIA2.IfFcJYmJGYEznsLuufICJJNkKfaib = IfFcJYmJGYEznsLuufICJJNkKfaib;
				}
				return zVRmTCsKxjSzpmvbDGsryylginIA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
			}
		}

		public MatchingCriteria matchingCriteria;

		public Elements elements;

		public string controllerName;

		private Platform_Custom.Axis[] _axesOrigGame;

		private Platform_Custom.Button[] _buttonsOrigGame;

		private CompoundElement[] _compoundElementsOrigGame;

		int Platform.assignedButtonCount => get_assignedButtonCount();

		int Platform.assignedAxisCount => get_assignedAxisCount();

		string Platform.controllerNameOverride => get_controllerNameOverride();

		InputPlatform Platform.platform => get_platform();

		Platform_Custom.Axis[] Platform_Custom.Axes => get_Axes();

		Platform_Custom.Button[] Platform_Custom.Buttons => get_Buttons();

		internal CompoundElement[] CompoundElements
		{
			get
			{
				if (_compoundElementsOrigGame == null)
				{
					CompoundElement[] compoundElements_orig = CompoundElements_orig;
					if (compoundElements_orig != null)
					{
						_compoundElementsOrigGame = new CompoundElement[compoundElements_orig.Length];
						for (int i = 0; i < compoundElements_orig.Length; i++)
						{
							_compoundElementsOrigGame[i] = compoundElements_orig[i];
						}
					}
				}
				return _compoundElementsOrigGame;
			}
		}

		internal Axis[] Axes_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.axes;
			}
		}

		internal Button[] Buttons_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.buttons;
			}
		}

		internal CompoundElement[] CompoundElements_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.compoundElements;
			}
		}

		bool Platform.hasData => get_hasData();

		bool Platform.disabled => get_disabled();

		bool Platform.isAllowed => get_isAllowed();

		Elements_Base Platform.elements_base => get_elements_base();

		public virtual int get_assignedButtonCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.buttonCount;
		}

		public virtual int get_assignedAxisCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.axisCount;
		}

		public virtual string get_controllerNameOverride()
		{
			return controllerName;
		}

		internal virtual InputPlatform get_platform()
		{
			return InputPlatform.AppleGameController;
		}

		internal virtual Platform_Custom.Axis[] get_Axes()
		{
			if (_axesOrigGame == null)
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig != null)
				{
					_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
					for (int i = 0; i < axes_orig.Length; i++)
					{
						_axesOrigGame[i] = axes_orig[i];
					}
				}
			}
			return _axesOrigGame;
		}

		internal virtual Platform_Custom.Button[] get_Buttons()
		{
			if (_buttonsOrigGame == null)
			{
				Button[] buttons_orig = Buttons_orig;
				if (buttons_orig != null)
				{
					_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						_buttonsOrigGame[i] = buttons_orig[i];
					}
				}
			}
			return _buttonsOrigGame;
		}

		internal virtual bool get_hasData()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			if (!matchingCriteria.hasData)
			{
				return false;
			}
			if (assignedButtonCount == 0 && assignedAxisCount == 0)
			{
				return false;
			}
			return true;
		}

		internal virtual bool get_disabled()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.disabled;
		}

		internal virtual bool get_isAllowed()
		{
			if (!base.isAllowed)
			{
				return false;
			}
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.isAllowed;
		}

		internal virtual Elements_Base get_elements_base()
		{
			return elements;
		}

		public override IList<Platform> GetVariants()
		{
			return null;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			return false;
		}

		[IteratorStateMachine(typeof(kVjougmiOLPtPKtBTZXTwkGNoMxh))]
		internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
		{
			return new kVjougmiOLPtPKtBTZXTwkGNoMxh(-2)
			{
				JPAvJzVQNKPsFboDFEtmEVFnLtlGA = this
			};
		}

		[IteratorStateMachine(typeof(zVRmTCsKxjSzpmvbDGsryylginIA))]
		internal override IEnumerable<Platform_Custom.Button> IterateButtons()
		{
			return new zVRmTCsKxjSzpmvbDGsryylginIA(-2)
			{
				IfFcJYmJGYEznsLuufICJJNkKfaib = this
			};
		}

		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			foreach (Axis item in IterateAxes())
			{
				if (item.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			foreach (Button item2 in IterateButtons())
			{
				if (item2.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[assignedButtonCount];
			axes = new int[assignedAxisCount];
			int num = 0;
			foreach (Button item in IterateButtons())
			{
				buttons[num] = item.elementIdentifier;
				num++;
			}
			num = 0;
			foreach (Axis item2 in IterateAxes())
			{
				axes[num] = item2.elementIdentifier;
				num++;
			}
		}

		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			Axis[] axes_orig = Axes_orig;
			if (axes_orig == null)
			{
				return null;
			}
			AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
				{
					array[i] = AxisCalibrationData.Default;
					array[i].invert = axes_orig[i].invert;
					array[i].deadZone = axes_orig[i].axisDeadZone;
					if (Axes_orig[i].calibrateAxis)
					{
						array[i].zero = axes_orig[i].axisZero;
						array[i].min = axes_orig[i].axisMin;
						array[i].max = axes_orig[i].axisMax;
					}
				}
				else
				{
					if (axes_orig[i].sourceType != 0)
					{
						throw new NotImplementedException();
					}
					array[i] = AxisCalibrationData.Default;
				}
				array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
			}
			return array;
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[Axes_orig.Length];
			for (int i = 0; i < Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
				if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
				{
					axisRanges[i] = Axes_orig[i].sourceAxisRange;
					continue;
				}
				if (Axes_orig[i].sourceType == 0)
				{
					axisRanges[i] = AxisRange.Full;
					continue;
				}
				throw new Exception();
			}
		}

		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = null;
			if (Buttons_orig != null)
			{
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				for (int i = 0; i < Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
				}
			}
		}

		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (elements == null)
			{
				return ControllerElementType.Axis;
			}
			return elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		public override object DeepClone()
		{
			Platform_AppleGCController_Base platform_AppleGCController_Base = new Platform_AppleGCController_Base();
			CopyVars(platform_AppleGCController_Base);
			return platform_AppleGCController_Base;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_AppleGCController_Base platform_AppleGCController_Base)
			{
				platform_AppleGCController_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
				platform_AppleGCController_Base.elements = MiscTools.DeepClone(elements);
				platform_AppleGCController_Base.controllerName = controllerName;
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Platform_AppleGCController : Platform_AppleGCController_Base
	{
		public Platform_AppleGCController_Base[] variants;

		public override IList<Platform> GetVariants()
		{
			return variants;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return true;
			}
			if (base.hasVariants)
			{
				for (int i = 0; i < variants.Length; i++)
				{
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		public override object DeepClone()
		{
			Platform_AppleGCController platform_AppleGCController = new Platform_AppleGCController();
			CopyVars(platform_AppleGCController);
			return platform_AppleGCController;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_AppleGCController platform_AppleGCController)
			{
				platform_AppleGCController.variants = MiscTools.DeepClone(variants);
			}
		}

		internal static Platform_AppleGCController CreateDefaultMap(BridgedControllerHWInfo bridgedController)
		{
			Platform_AppleGCController platform_AppleGCController = new Platform_AppleGCController();
			_ = Consts.unknownJoystickElementIdentifiers_orig;
			platform_AppleGCController.controllerName = "Unknown Controller";
			platform_AppleGCController.description = "";
			Elements elements = (platform_AppleGCController.elements = new Elements());
			int num = 32;
			elements.axes = new Axis[num];
			for (int i = 0; i < num; i++)
			{
				Axis axis = new Axis();
				elements.axes[i] = axis;
				axis.axisDeadZone = 0.1f;
				axis.axisInfo = HardwareAxisInfo.Default;
				axis.axisMin = -1f;
				axis.axisMax = 1f;
				axis.axisZero = 0f;
				axis.calibrateAxis = false;
				axis.buttonAxisContribution = Pole.Positive;
				axis.elementIdentifier = i;
				axis.invert = false;
				axis.sourceAxis = i;
				axis.sourceAxisRange = AxisRange.Full;
				axis.sourceType = 1;
			}
			int num2 = 128;
			elements.buttons = new Button[num2];
			for (int j = 0; j < num2; j++)
			{
				Button button = new Button();
				elements.buttons[j] = button;
				button.buttonInfo = new HardwareButtonInfo(false, false);
				button.elementIdentifier = 32 + j;
				button.sourceButton = j;
				button.sourceType = 0;
			}
			MatchingCriteria matchingCriteria = new MatchingCriteria();
			platform_AppleGCController.matchingCriteria = matchingCriteria;
			platform_AppleGCController.variants = new Platform_AppleGCController_Base[0];
			return platform_AppleGCController;
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class Platform_WindowsWGI_Base : Platform_Custom
	{
		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class MatchingCriteria : Platform_Custom.MatchingCriteria
		{
			public bool productName_useRegex;

			public string[] productName;

			public VidPid[] vidPid;

			public DeviceType deviceType;

			public int hatCount;

			bool hasData => get_hasData();

			bool isAllowed => get_isAllowed();

			internal override bool get_hasData()
			{
				if (base.get_hasData())
				{
					return true;
				}
				if (productName != null && productName.Length != 0)
				{
					return true;
				}
				if (deviceType != DeviceType.None)
				{
					return true;
				}
				if (vidPid != null && vidPid.Length != 0)
				{
					return true;
				}
				return false;
			}

			internal override bool get_isAllowed()
			{
				if (!base.get_isAllowed())
				{
					return false;
				}
				if (disabled)
				{
					return false;
				}
				return true;
			}

			internal override bool ElementCountsMatch(BridgedControllerHWInfo bridgedControllerHWInfo, out bool alternateMatched)
			{
				if (!base.ElementCountsMatch(bridgedControllerHWInfo, out alternateMatched))
				{
					return false;
				}
				if (hatCount >= 0)
				{
					return hatCount == bridgedControllerHWInfo.hardwareHatCount;
				}
				return true;
			}

			internal override bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch)
			{
				if (bridgedControllerHWInfo.isMock && hasData && isAllowed)
				{
					return true;
				}
				if (alwaysMatch)
				{
					return true;
				}
				if (!base.Matches(bridgedControllerHWInfo, strictMatch))
				{
					return false;
				}
				if (!ElementCountsMatch(bridgedControllerHWInfo, out var _))
				{
					return false;
				}
				if ((!string.IsNullOrEmpty(bridgedControllerHWInfo.definitionMatchTag) || !string.IsNullOrEmpty(tag)) && !string.Equals(bridgedControllerHWInfo.definitionMatchTag, tag, StringComparison.OrdinalIgnoreCase))
				{
					return false;
				}
				if (deviceType != DeviceType.None)
				{
					if (deviceType != (DeviceType)bridgedControllerHWInfo.deviceType)
					{
						return false;
					}
					if (!HasProductName() && (vidPid == null || vidPid.Length == 0))
					{
						return true;
					}
				}
				string text = bridgedControllerHWInfo.hw_productName;
				if (text == null)
				{
					text = string.Empty;
				}
				text = text.Trim();
				if (strictMatch)
				{
					if (vidPid != null)
					{
						for (int i = 0; i < vidPid.Length; i++)
						{
							int vendorId = vidPid[i].vendorId;
							int productId = vidPid[i].productId;
							if (ArrayTools.Contains(Consts.questionableVIDs, bridgedControllerHWInfo.hw_pidVid.vendorId))
							{
								string name = ((bridgedControllerHWInfo.hw_productName == null) ? string.Empty : bridgedControllerHWInfo.hw_productName);
								if (!ProductNameMatches(name))
								{
									return false;
								}
							}
							if ((vendorId < 0 || bridgedControllerHWInfo.hw_pidVid.vendorId == vendorId) && (productId < 0 || bridgedControllerHWInfo.hw_pidVid.productId == productId))
							{
								return true;
							}
						}
					}
					return false;
				}
				return ProductNameMatches(text);
			}

			public override object DeepClone()
			{
				MatchingCriteria matchingCriteria = new MatchingCriteria();
				CopyVars(matchingCriteria);
				return matchingCriteria;
			}

			internal override void CopyVars(MatchingCriteria_Base destination)
			{
				base.CopyVars(destination);
				if (destination is MatchingCriteria matchingCriteria)
				{
					matchingCriteria.productName_useRegex = productName_useRegex;
					matchingCriteria.productName = ArrayTools.ShallowCopy(productName);
					matchingCriteria.deviceType = deviceType;
					matchingCriteria.hatCount = hatCount;
					matchingCriteria.vidPid = ArrayTools.ShallowCopy(vidPid);
				}
			}

			private bool HasProductName()
			{
				if (productName == null)
				{
					return false;
				}
				for (int i = 0; i < productName.Length; i++)
				{
					if (!string.IsNullOrEmpty(productName[i]))
					{
						return true;
					}
				}
				return false;
			}

			private bool ProductNameMatches(string name)
			{
				if (productName == null)
				{
					return false;
				}
				for (int i = 0; i < productName.Length; i++)
				{
					string searchFor = productName[i];
					if (MatchingCriteria_Base.StringMatches(name, searchFor, productName_useRegex))
					{
						return true;
					}
				}
				return false;
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Elements : Platform_Custom.Elements
		{
			public Axis[] axes;

			public Button[] buttons;

			int Elements_Base.buttonCount => get_buttonCount();

			int Elements_Base.axisCount => get_axisCount();

			public int get_buttonCount()
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Length;
			}

			public int get_axisCount()
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Length;
			}

			internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Axis;
					}
				}
				for (int j = 0; j < buttonCount; j++)
				{
					if (buttons[j].elementIdentifier == elementIdentifier.get_id())
					{
						return ControllerElementType.Button;
					}
				}
				return elementIdentifier.elementType;
			}

			internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
			{
				for (int i = 0; i < axisCount; i++)
				{
					if (axes[i].elementIdentifier != elementIdentifier.get_id())
					{
						continue;
					}
					switch (axes[i].sourceType)
					{
					case 1:
					case 100:
						axisRange = axes[i].sourceAxisRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					case 0:
						axisRange = AxisRange.Positive;
						return true;
					case 2:
						axisRange = axes[i].sourceHatRange;
						if (axes[i].invert)
						{
							axisRange = InputTools.InvertAxisRange(axisRange);
						}
						return true;
					default:
						throw new NotImplementedException();
					}
				}
				axisRange = AxisRange.Full;
				return false;
			}

			public override object DeepClone()
			{
				Elements elements = new Elements();
				CopyVars(elements);
				return elements;
			}

			internal override void CopyVars(Elements_Base destination)
			{
				base.CopyVars(destination);
				if (destination is Elements elements)
				{
					elements.axes = ArrayTools.DeepClone(axes);
					elements.buttons = ArrayTools.DeepClone(buttons);
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Button : Platform_Custom.Button
		{
			public int sourceHat;

			public HatDirection sourceHatDirection;

			public HatType sourceHatType;

			public override object DeepClone()
			{
				Button button = new Button();
				CopyVars(button);
				return button;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				if (destination is Button button)
				{
					button.sourceHat = sourceHat;
					button.sourceHatDirection = sourceHatDirection;
					button.sourceHatType = sourceHatType;
				}
			}
		}

		[Serializable]
		[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
		public new sealed class Axis : Platform_Custom.Axis
		{
			public int sourceHat;

			public AxisDirection sourceHatDirection;

			public HatType sourceHatType;

			public AxisRange sourceHatRange;

			public override object DeepClone()
			{
				Axis axis = new Axis();
				CopyVars(axis);
				return axis;
			}

			internal override void CopyVars(Element destination)
			{
				base.CopyVars(destination);
				if (destination is Axis axis)
				{
					axis.sourceHat = sourceHat;
					axis.sourceHatDirection = sourceHatDirection;
					axis.sourceHatType = sourceHatType;
					axis.sourceHatRange = sourceHatRange;
				}
			}
		}

		public enum DeviceType
		{
			None = 0,
			Gamepad = 1
		}

		private sealed class myTanCpJVjubIXnkyjxXcYtmOVpy : IEnumerable<Platform_Custom.Axis>, IEnumerable, IEnumerator<Platform_Custom.Axis>, IEnumerator, IDisposable
		{
			private int eQkEgbgGBsuHvtltGDYxPAreUaii;

			private Platform_Custom.Axis cXOKgkImCQGbAvQaHtvzUaTyMpAC;

			private int akpLjghnsMbcagkbkpsFGJxJvLazB;

			public Platform_WindowsWGI_Base nZhYSXWxACmRJSdIWEFcHRvUNBrfA;

			private int VeJYsWYtUeSapNOJzfoccbqiYpKBA;

			Platform_Custom.Axis IEnumerator<Platform_Custom.Axis>.Current
			{
				[DebuggerHidden]
				get
				{
					return cXOKgkImCQGbAvQaHtvzUaTyMpAC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return cXOKgkImCQGbAvQaHtvzUaTyMpAC;
				}
			}

			[DebuggerHidden]
			public myTanCpJVjubIXnkyjxXcYtmOVpy(int P_0)
			{
				eQkEgbgGBsuHvtltGDYxPAreUaii = P_0;
				akpLjghnsMbcagkbkpsFGJxJvLazB = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = eQkEgbgGBsuHvtltGDYxPAreUaii;
				Platform_WindowsWGI_Base platform_WindowsWGI_Base = nZhYSXWxACmRJSdIWEFcHRvUNBrfA;
				switch (num)
				{
				default:
					return false;
				case 0:
					eQkEgbgGBsuHvtltGDYxPAreUaii = -1;
					if (platform_WindowsWGI_Base.elements == null || platform_WindowsWGI_Base.elements.axes == null)
					{
						return false;
					}
					VeJYsWYtUeSapNOJzfoccbqiYpKBA = 0;
					break;
				case 1:
					eQkEgbgGBsuHvtltGDYxPAreUaii = -1;
					VeJYsWYtUeSapNOJzfoccbqiYpKBA++;
					break;
				}
				if (VeJYsWYtUeSapNOJzfoccbqiYpKBA < platform_WindowsWGI_Base.elements.axes.Length)
				{
					cXOKgkImCQGbAvQaHtvzUaTyMpAC = platform_WindowsWGI_Base.elements.axes[VeJYsWYtUeSapNOJzfoccbqiYpKBA];
					eQkEgbgGBsuHvtltGDYxPAreUaii = 1;
					return true;
				}
				return false;
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
			IEnumerator<Platform_Custom.Axis> IEnumerable<Platform_Custom.Axis>.GetEnumerator()
			{
				myTanCpJVjubIXnkyjxXcYtmOVpy myTanCpJVjubIXnkyjxXcYtmOVpy2;
				if (eQkEgbgGBsuHvtltGDYxPAreUaii == -2 && akpLjghnsMbcagkbkpsFGJxJvLazB == Environment.CurrentManagedThreadId)
				{
					eQkEgbgGBsuHvtltGDYxPAreUaii = 0;
					myTanCpJVjubIXnkyjxXcYtmOVpy2 = this;
				}
				else
				{
					myTanCpJVjubIXnkyjxXcYtmOVpy2 = new myTanCpJVjubIXnkyjxXcYtmOVpy(0);
					myTanCpJVjubIXnkyjxXcYtmOVpy2.nZhYSXWxACmRJSdIWEFcHRvUNBrfA = nZhYSXWxACmRJSdIWEFcHRvUNBrfA;
				}
				return myTanCpJVjubIXnkyjxXcYtmOVpy2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform_Custom.Axis>)this).GetEnumerator();
			}
		}

		private sealed class sPTOmRuHXRkmSYdydfOFrhOtPAev : IEnumerable<Platform_Custom.Button>, IEnumerable, IEnumerator<Platform_Custom.Button>, IEnumerator, IDisposable
		{
			private int YASOCHOjtOcdZesUreWMHVivxtlAA;

			private Platform_Custom.Button FXdXmyQKcTBIzvfftNbTETeVtHqm;

			private int OVhuqhoRQhsbhuGPiLtKfWkfgqgE;

			public Platform_WindowsWGI_Base qXbFeAyKESxZwqsNHfgyKmGzbRtc;

			private int XKavGEBfTUvkjOWmsJXDvpJakOwg;

			Platform_Custom.Button IEnumerator<Platform_Custom.Button>.Current
			{
				[DebuggerHidden]
				get
				{
					return FXdXmyQKcTBIzvfftNbTETeVtHqm;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return FXdXmyQKcTBIzvfftNbTETeVtHqm;
				}
			}

			[DebuggerHidden]
			public sPTOmRuHXRkmSYdydfOFrhOtPAev(int P_0)
			{
				YASOCHOjtOcdZesUreWMHVivxtlAA = P_0;
				OVhuqhoRQhsbhuGPiLtKfWkfgqgE = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int yASOCHOjtOcdZesUreWMHVivxtlAA = YASOCHOjtOcdZesUreWMHVivxtlAA;
				Platform_WindowsWGI_Base platform_WindowsWGI_Base = qXbFeAyKESxZwqsNHfgyKmGzbRtc;
				switch (yASOCHOjtOcdZesUreWMHVivxtlAA)
				{
				default:
					return false;
				case 0:
					YASOCHOjtOcdZesUreWMHVivxtlAA = -1;
					if (platform_WindowsWGI_Base.elements == null || platform_WindowsWGI_Base.elements.buttons == null)
					{
						return false;
					}
					XKavGEBfTUvkjOWmsJXDvpJakOwg = 0;
					break;
				case 1:
					YASOCHOjtOcdZesUreWMHVivxtlAA = -1;
					XKavGEBfTUvkjOWmsJXDvpJakOwg++;
					break;
				}
				if (XKavGEBfTUvkjOWmsJXDvpJakOwg < platform_WindowsWGI_Base.elements.buttons.Length)
				{
					FXdXmyQKcTBIzvfftNbTETeVtHqm = platform_WindowsWGI_Base.elements.buttons[XKavGEBfTUvkjOWmsJXDvpJakOwg];
					YASOCHOjtOcdZesUreWMHVivxtlAA = 1;
					return true;
				}
				return false;
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
			IEnumerator<Platform_Custom.Button> IEnumerable<Platform_Custom.Button>.GetEnumerator()
			{
				sPTOmRuHXRkmSYdydfOFrhOtPAev sPTOmRuHXRkmSYdydfOFrhOtPAev2;
				if (YASOCHOjtOcdZesUreWMHVivxtlAA == -2 && OVhuqhoRQhsbhuGPiLtKfWkfgqgE == Environment.CurrentManagedThreadId)
				{
					YASOCHOjtOcdZesUreWMHVivxtlAA = 0;
					sPTOmRuHXRkmSYdydfOFrhOtPAev2 = this;
				}
				else
				{
					sPTOmRuHXRkmSYdydfOFrhOtPAev2 = new sPTOmRuHXRkmSYdydfOFrhOtPAev(0);
					sPTOmRuHXRkmSYdydfOFrhOtPAev2.qXbFeAyKESxZwqsNHfgyKmGzbRtc = qXbFeAyKESxZwqsNHfgyKmGzbRtc;
				}
				return sPTOmRuHXRkmSYdydfOFrhOtPAev2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<Platform_Custom.Button>)this).GetEnumerator();
			}
		}

		public MatchingCriteria matchingCriteria;

		public Elements elements;

		public string controllerName;

		private Platform_Custom.Axis[] _axesOrigGame;

		private Platform_Custom.Button[] _buttonsOrigGame;

		int Platform.assignedButtonCount => get_assignedButtonCount();

		int Platform.assignedAxisCount => get_assignedAxisCount();

		string Platform.controllerNameOverride => get_controllerNameOverride();

		InputPlatform Platform.platform => get_platform();

		Platform_Custom.Axis[] Platform_Custom.Axes => get_Axes();

		Platform_Custom.Button[] Platform_Custom.Buttons => get_Buttons();

		internal Axis[] Axes_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.axes;
			}
		}

		internal Button[] Buttons_orig
		{
			get
			{
				if (elements == null)
				{
					return null;
				}
				return elements.buttons;
			}
		}

		bool Platform.hasData => get_hasData();

		bool Platform.disabled => get_disabled();

		bool Platform.isAllowed => get_isAllowed();

		Elements_Base Platform.elements_base => get_elements_base();

		public virtual int get_assignedButtonCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.buttonCount;
		}

		public virtual int get_assignedAxisCount()
		{
			if (elements == null)
			{
				return 0;
			}
			return elements.axisCount;
		}

		public virtual string get_controllerNameOverride()
		{
			return controllerName;
		}

		internal virtual InputPlatform get_platform()
		{
			return InputPlatform.WindowsWGI;
		}

		internal virtual Platform_Custom.Axis[] get_Axes()
		{
			if (_axesOrigGame == null)
			{
				Axis[] axes_orig = Axes_orig;
				if (axes_orig != null)
				{
					_axesOrigGame = new Platform_Custom.Axis[axes_orig.Length];
					for (int i = 0; i < axes_orig.Length; i++)
					{
						_axesOrigGame[i] = axes_orig[i];
					}
				}
			}
			return _axesOrigGame;
		}

		internal virtual Platform_Custom.Button[] get_Buttons()
		{
			if (_buttonsOrigGame == null)
			{
				Button[] buttons_orig = Buttons_orig;
				if (buttons_orig != null)
				{
					_buttonsOrigGame = new Platform_Custom.Button[buttons_orig.Length];
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						_buttonsOrigGame[i] = buttons_orig[i];
					}
				}
			}
			return _buttonsOrigGame;
		}

		internal virtual bool get_hasData()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			if (!matchingCriteria.hasData)
			{
				return false;
			}
			if (assignedButtonCount == 0 && assignedAxisCount == 0)
			{
				return false;
			}
			return true;
		}

		internal virtual bool get_disabled()
		{
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.disabled;
		}

		internal virtual bool get_isAllowed()
		{
			if (!base.isAllowed)
			{
				return false;
			}
			if (matchingCriteria == null)
			{
				return false;
			}
			return matchingCriteria.isAllowed;
		}

		internal virtual Elements_Base get_elements_base()
		{
			return elements;
		}

		public override IList<Platform> GetVariants()
		{
			return null;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			variantIndex = -1;
			platformMap = null;
			if (matchingCriteria != null && matchingCriteria.Matches(BridgedControllerHWInfo, strictMatch))
			{
				platformMap = this;
				return true;
			}
			return false;
		}

		[IteratorStateMachine(typeof(myTanCpJVjubIXnkyjxXcYtmOVpy))]
		internal override IEnumerable<Platform_Custom.Axis> IterateAxes()
		{
			return new myTanCpJVjubIXnkyjxXcYtmOVpy(-2)
			{
				nZhYSXWxACmRJSdIWEFcHRvUNBrfA = this
			};
		}

		[IteratorStateMachine(typeof(sPTOmRuHXRkmSYdydfOFrhOtPAev))]
		internal override IEnumerable<Platform_Custom.Button> IterateButtons()
		{
			return new sPTOmRuHXRkmSYdydfOFrhOtPAev(-2)
			{
				qXbFeAyKESxZwqsNHfgyKmGzbRtc = this
			};
		}

		internal override bool IsElementIdentifierMapped(int elementIdentifierId)
		{
			foreach (Axis item in IterateAxes())
			{
				if (item.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			foreach (Button item2 in IterateButtons())
			{
				if (item2.elementIdentifier == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		internal override void GetGameElementIdentifierIdMappings(out int[] buttons, out int[] axes)
		{
			buttons = new int[assignedButtonCount];
			axes = new int[assignedAxisCount];
			int num = 0;
			foreach (Button item in IterateButtons())
			{
				buttons[num] = item.elementIdentifier;
				num++;
			}
			num = 0;
			foreach (Axis item2 in IterateAxes())
			{
				axes[num] = item2.elementIdentifier;
				num++;
			}
		}

		internal override AxisCalibrationData[] GetAxisCalibrationData()
		{
			Axis[] axes_orig = Axes_orig;
			if (axes_orig == null)
			{
				return null;
			}
			AxisCalibrationData[] array = new AxisCalibrationData[axes_orig.Length];
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (axes_orig[i].sourceType == 1 || axes_orig[i].sourceType == 100)
				{
					array[i] = AxisCalibrationData.Default;
					array[i].invert = axes_orig[i].invert;
					array[i].deadZone = axes_orig[i].axisDeadZone;
					if (Axes_orig[i].calibrateAxis)
					{
						array[i].zero = axes_orig[i].axisZero;
						array[i].min = axes_orig[i].axisMin;
						array[i].max = axes_orig[i].axisMax;
					}
				}
				else
				{
					if (axes_orig[i].sourceType != 0 && axes_orig[i].sourceType != 2)
					{
						throw new NotImplementedException();
					}
					array[i] = AxisCalibrationData.Default;
				}
				array[i].calibrations = AxisCalibrationInfoEntry.ToDictionary(axes_orig[i].alternateCalibrations, deepClone: true);
			}
			return array;
		}

		internal override void GetAxisData(out AxisRange[] axisRanges, out HardwareAxisInfo[] axisInfos)
		{
			axisRanges = null;
			axisInfos = null;
			if (Axes_orig == null)
			{
				return;
			}
			axisRanges = new AxisRange[Axes_orig.Length];
			axisInfos = new HardwareAxisInfo[Axes_orig.Length];
			for (int i = 0; i < Axes_orig.Length; i++)
			{
				axisInfos[i] = MiscTools.DeepClone(Axes_orig[i].axisInfo, createIfNull: true);
				if (Axes_orig[i].sourceType == 1 || Axes_orig[i].sourceType == 100)
				{
					axisRanges[i] = Axes_orig[i].sourceAxisRange;
					continue;
				}
				if (Axes_orig[i].sourceType == 0 || Axes_orig[i].sourceType == 2)
				{
					axisRanges[i] = AxisRange.Full;
					continue;
				}
				throw new Exception();
			}
		}

		internal override void GetButtonData(out HardwareButtonInfo[] buttonInfos)
		{
			buttonInfos = null;
			if (Buttons_orig != null)
			{
				buttonInfos = new HardwareButtonInfo[Buttons_orig.Length];
				for (int i = 0; i < Buttons_orig.Length; i++)
				{
					buttonInfos[i] = MiscTools.DeepClone(Buttons_orig[i].buttonInfo, createIfNull: true);
				}
			}
		}

		internal override ControllerElementType GetEffectiveElementIdentifierType(ControllerElementIdentifier elementIdentifier)
		{
			if (elements == null)
			{
				return ControllerElementType.Axis;
			}
			return elements.GetEffectiveElementIdentifierType(elementIdentifier);
		}

		internal override bool GetEffectiveAxisRange(ControllerElementIdentifier elementIdentifier, out AxisRange axisRange)
		{
			if (elements == null)
			{
				axisRange = AxisRange.Full;
				return false;
			}
			return elements.GetEffectiveAxisRange(elementIdentifier, out axisRange);
		}

		public override object DeepClone()
		{
			Platform_WindowsWGI_Base platform_WindowsWGI_Base = new Platform_WindowsWGI_Base();
			CopyVars(platform_WindowsWGI_Base);
			return platform_WindowsWGI_Base;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_WindowsWGI_Base platform_WindowsWGI_Base)
			{
				platform_WindowsWGI_Base.matchingCriteria = MiscTools.DeepClone(matchingCriteria);
				platform_WindowsWGI_Base.elements = MiscTools.DeepClone(elements);
				platform_WindowsWGI_Base.controllerName = controllerName;
			}
		}
	}

	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Platform_WindowsWGI : Platform_WindowsWGI_Base
	{
		public Platform_WindowsWGI_Base[] variants;

		public override IList<Platform> GetVariants()
		{
			return variants;
		}

		internal override bool Matches(BridgedControllerHWInfo BridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
		{
			if (base.Matches(BridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return true;
			}
			if (base.hasVariants)
			{
				for (int i = 0; i < variants.Length; i++)
				{
					if (variants[i] != null && variants[i].Matches(BridgedControllerHWInfo, strictMatch, out var _, out platformMap))
					{
						variantIndex = i;
						return true;
					}
				}
			}
			return false;
		}

		public override object DeepClone()
		{
			Platform_WindowsWGI platform_WindowsWGI = new Platform_WindowsWGI();
			CopyVars(platform_WindowsWGI);
			return platform_WindowsWGI;
		}

		internal override void CopyVars(Platform destination)
		{
			base.CopyVars(destination);
			if (destination is Platform_WindowsWGI platform_WindowsWGI)
			{
				platform_WindowsWGI.variants = MiscTools.DeepClone(variants);
			}
		}

		internal static Platform_WindowsWGI CreateDefaultMap(BridgedControllerHWInfo bridgedController)
		{
			Platform_WindowsWGI platform_WindowsWGI = new Platform_WindowsWGI();
			_ = Consts.unknownJoystickElementIdentifiers_orig;
			platform_WindowsWGI.controllerName = "Unknown Controller";
			platform_WindowsWGI.description = "";
			Elements elements = (platform_WindowsWGI.elements = new Elements());
			int num = 32;
			elements.axes = new Axis[num];
			for (int i = 0; i < num; i++)
			{
				Axis axis = new Axis();
				elements.axes[i] = axis;
				axis.axisDeadZone = 0.1f;
				axis.axisInfo = HardwareAxisInfo.Default;
				axis.axisMin = -1f;
				axis.axisMax = 1f;
				axis.axisZero = 0f;
				axis.calibrateAxis = false;
				axis.buttonAxisContribution = Pole.Positive;
				axis.elementIdentifier = i;
				axis.invert = false;
				axis.sourceAxis = i;
				axis.sourceAxisRange = AxisRange.Full;
				axis.sourceType = 1;
			}
			int num2 = 128;
			int num3 = 16 * 8;
			elements.buttons = new Button[num2 + num3];
			for (int j = 0; j < num2; j++)
			{
				Button button = new Button();
				elements.buttons[j] = button;
				button.buttonInfo = new HardwareButtonInfo(false, false);
				button.elementIdentifier = 32 + j;
				button.sourceButton = j;
				button.sourceType = 0;
			}
			int num4 = num2;
			int num5 = 160;
			int num6 = 224;
			for (int k = 0; k < 16; k++)
			{
				for (int l = 0; l < 8; l++)
				{
					bool flag = l % 2 == 0;
					Button button2 = new Button();
					elements.buttons[num4++] = button2;
					button2.buttonInfo = new HardwareButtonInfo(false, false);
					button2.elementIdentifier = (flag ? num5++ : num6++);
					button2.sourceHat = k;
					button2.sourceType = 2;
					button2.sourceHatDirection = (HatDirection)(flag ? (l / 2) : (4 + l / 2));
				}
			}
			MatchingCriteria matchingCriteria = new MatchingCriteria();
			platform_WindowsWGI.matchingCriteria = matchingCriteria;
			platform_WindowsWGI.variants = new Platform_WindowsWGI_Base[0];
			return platform_WindowsWGI;
		}
	}

	private sealed class CBIklamezZjFsvbmQjvyAZzbhssnA : IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerable, IEnumerator<IControllerElementIdentifierCommon_Internal>, IEnumerator, IDisposable
	{
		private int RYIzKAydDXkXcNfhsvEZUYqCBBXv;

		private IControllerElementIdentifierCommon_Internal kNPhYwjOJpBDaUlnksbdZglXFrns;

		private int QyPhbXxUpsVgpusMILpDaDvPRHmQ;

		public HardwareJoystickMap JbRNvgBqNNkqMpiNdjPeIdmlFbDkA;

		private int IazmumbpfexcNeOEmIRhNOeQuzXH;

		IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
		{
			[DebuggerHidden]
			get
			{
				return kNPhYwjOJpBDaUlnksbdZglXFrns;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return kNPhYwjOJpBDaUlnksbdZglXFrns;
			}
		}

		[DebuggerHidden]
		public CBIklamezZjFsvbmQjvyAZzbhssnA(int P_0)
		{
			RYIzKAydDXkXcNfhsvEZUYqCBBXv = P_0;
			QyPhbXxUpsVgpusMILpDaDvPRHmQ = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int rYIzKAydDXkXcNfhsvEZUYqCBBXv = RYIzKAydDXkXcNfhsvEZUYqCBBXv;
			HardwareJoystickMap jbRNvgBqNNkqMpiNdjPeIdmlFbDkA = JbRNvgBqNNkqMpiNdjPeIdmlFbDkA;
			switch (rYIzKAydDXkXcNfhsvEZUYqCBBXv)
			{
			default:
				return false;
			case 0:
				RYIzKAydDXkXcNfhsvEZUYqCBBXv = -1;
				if (jbRNvgBqNNkqMpiNdjPeIdmlFbDkA.elementIdentifiers == null)
				{
					return false;
				}
				IazmumbpfexcNeOEmIRhNOeQuzXH = 0;
				break;
			case 1:
				RYIzKAydDXkXcNfhsvEZUYqCBBXv = -1;
				IazmumbpfexcNeOEmIRhNOeQuzXH++;
				break;
			}
			if (IazmumbpfexcNeOEmIRhNOeQuzXH < jbRNvgBqNNkqMpiNdjPeIdmlFbDkA.elementIdentifiers.Length)
			{
				kNPhYwjOJpBDaUlnksbdZglXFrns = jbRNvgBqNNkqMpiNdjPeIdmlFbDkA.elementIdentifiers[IazmumbpfexcNeOEmIRhNOeQuzXH];
				RYIzKAydDXkXcNfhsvEZUYqCBBXv = 1;
				return true;
			}
			return false;
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
		IEnumerator<IControllerElementIdentifierCommon_Internal> IEnumerable<IControllerElementIdentifierCommon_Internal>.GetEnumerator()
		{
			CBIklamezZjFsvbmQjvyAZzbhssnA cBIklamezZjFsvbmQjvyAZzbhssnA;
			if (RYIzKAydDXkXcNfhsvEZUYqCBBXv == -2 && QyPhbXxUpsVgpusMILpDaDvPRHmQ == Environment.CurrentManagedThreadId)
			{
				RYIzKAydDXkXcNfhsvEZUYqCBBXv = 0;
				cBIklamezZjFsvbmQjvyAZzbhssnA = this;
			}
			else
			{
				cBIklamezZjFsvbmQjvyAZzbhssnA = new CBIklamezZjFsvbmQjvyAZzbhssnA(0);
				cBIklamezZjFsvbmQjvyAZzbhssnA.JbRNvgBqNNkqMpiNdjPeIdmlFbDkA = JbRNvgBqNNkqMpiNdjPeIdmlFbDkA;
			}
			return cBIklamezZjFsvbmQjvyAZzbhssnA;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<IControllerElementIdentifierCommon_Internal>)this).GetEnumerator();
		}
	}

	private sealed class TlnKcjDTqzFEnVWPEovzteeADhRU : IEnumerable<ControllerElementIdentifier>, IEnumerable, IEnumerator<ControllerElementIdentifier>, IEnumerator, IDisposable
	{
		private int QFgUsbudKtfJoSzgNrtBXONmTWv;

		private ControllerElementIdentifier mNJbVSIJUdaLZQQzXlQRhDOGIIqM;

		private int hefUDHPaKUftiBDeiCdSgRovCpOA;

		public HardwareJoystickMap YXHcHUhinmbMYSbWMiuertlLKpPYA;

		private int oyMAzPjAmaziHiSwlbtJIDPHEagI;

		ControllerElementIdentifier IEnumerator<ControllerElementIdentifier>.Current
		{
			[DebuggerHidden]
			get
			{
				return mNJbVSIJUdaLZQQzXlQRhDOGIIqM;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return mNJbVSIJUdaLZQQzXlQRhDOGIIqM;
			}
		}

		[DebuggerHidden]
		public TlnKcjDTqzFEnVWPEovzteeADhRU(int P_0)
		{
			QFgUsbudKtfJoSzgNrtBXONmTWv = P_0;
			hefUDHPaKUftiBDeiCdSgRovCpOA = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int qFgUsbudKtfJoSzgNrtBXONmTWv = QFgUsbudKtfJoSzgNrtBXONmTWv;
			HardwareJoystickMap yXHcHUhinmbMYSbWMiuertlLKpPYA = YXHcHUhinmbMYSbWMiuertlLKpPYA;
			switch (qFgUsbudKtfJoSzgNrtBXONmTWv)
			{
			default:
				return false;
			case 0:
				QFgUsbudKtfJoSzgNrtBXONmTWv = -1;
				if (yXHcHUhinmbMYSbWMiuertlLKpPYA.elementIdentifiers == null)
				{
					return false;
				}
				oyMAzPjAmaziHiSwlbtJIDPHEagI = 0;
				break;
			case 1:
				QFgUsbudKtfJoSzgNrtBXONmTWv = -1;
				oyMAzPjAmaziHiSwlbtJIDPHEagI++;
				break;
			}
			if (oyMAzPjAmaziHiSwlbtJIDPHEagI < yXHcHUhinmbMYSbWMiuertlLKpPYA.elementIdentifiers.Length)
			{
				mNJbVSIJUdaLZQQzXlQRhDOGIIqM = yXHcHUhinmbMYSbWMiuertlLKpPYA.elementIdentifiers[oyMAzPjAmaziHiSwlbtJIDPHEagI];
				QFgUsbudKtfJoSzgNrtBXONmTWv = 1;
				return true;
			}
			return false;
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
		IEnumerator<ControllerElementIdentifier> IEnumerable<ControllerElementIdentifier>.GetEnumerator()
		{
			TlnKcjDTqzFEnVWPEovzteeADhRU tlnKcjDTqzFEnVWPEovzteeADhRU;
			if (QFgUsbudKtfJoSzgNrtBXONmTWv == -2 && hefUDHPaKUftiBDeiCdSgRovCpOA == Environment.CurrentManagedThreadId)
			{
				QFgUsbudKtfJoSzgNrtBXONmTWv = 0;
				tlnKcjDTqzFEnVWPEovzteeADhRU = this;
			}
			else
			{
				tlnKcjDTqzFEnVWPEovzteeADhRU = new TlnKcjDTqzFEnVWPEovzteeADhRU(0);
				tlnKcjDTqzFEnVWPEovzteeADhRU.YXHcHUhinmbMYSbWMiuertlLKpPYA = YXHcHUhinmbMYSbWMiuertlLKpPYA;
			}
			return tlnKcjDTqzFEnVWPEovzteeADhRU;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<ControllerElementIdentifier>)this).GetEnumerator();
		}
	}

	private sealed class zwMQANNjMqIBWnYCbGrUBPhVCrldA : IEnumerable<JoystickType>, IEnumerable, IEnumerator<JoystickType>, IEnumerator, IDisposable
	{
		private int TgCYlVAMFtLejjQQravVwjdgsySb;

		private JoystickType WhOIeptqnUzqSNCTeDnBGWdMuGDgA;

		private int zrDhMiNdBIquMSLAqxcNQmuOPLNA;

		public HardwareJoystickMap xPhRBDZndnYsuUqqiWtVDfmHeWdD;

		private int eYMtiyVhsbxLoGbcXnPYidshrJJe;

		JoystickType IEnumerator<JoystickType>.Current
		{
			[DebuggerHidden]
			get
			{
				return WhOIeptqnUzqSNCTeDnBGWdMuGDgA;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return WhOIeptqnUzqSNCTeDnBGWdMuGDgA;
			}
		}

		[DebuggerHidden]
		public zwMQANNjMqIBWnYCbGrUBPhVCrldA(int P_0)
		{
			TgCYlVAMFtLejjQQravVwjdgsySb = P_0;
			zrDhMiNdBIquMSLAqxcNQmuOPLNA = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int tgCYlVAMFtLejjQQravVwjdgsySb = TgCYlVAMFtLejjQQravVwjdgsySb;
			HardwareJoystickMap hardwareJoystickMap = xPhRBDZndnYsuUqqiWtVDfmHeWdD;
			switch (tgCYlVAMFtLejjQQravVwjdgsySb)
			{
			default:
				return false;
			case 0:
				TgCYlVAMFtLejjQQravVwjdgsySb = -1;
				if (hardwareJoystickMap.joystickTypes == null)
				{
					return false;
				}
				eYMtiyVhsbxLoGbcXnPYidshrJJe = 0;
				break;
			case 1:
				TgCYlVAMFtLejjQQravVwjdgsySb = -1;
				eYMtiyVhsbxLoGbcXnPYidshrJJe++;
				break;
			}
			if (eYMtiyVhsbxLoGbcXnPYidshrJJe < hardwareJoystickMap.joystickTypes.Length)
			{
				WhOIeptqnUzqSNCTeDnBGWdMuGDgA = hardwareJoystickMap.joystickTypes[eYMtiyVhsbxLoGbcXnPYidshrJJe];
				TgCYlVAMFtLejjQQravVwjdgsySb = 1;
				return true;
			}
			return false;
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
		IEnumerator<JoystickType> IEnumerable<JoystickType>.GetEnumerator()
		{
			zwMQANNjMqIBWnYCbGrUBPhVCrldA zwMQANNjMqIBWnYCbGrUBPhVCrldA2;
			if (TgCYlVAMFtLejjQQravVwjdgsySb == -2 && zrDhMiNdBIquMSLAqxcNQmuOPLNA == Environment.CurrentManagedThreadId)
			{
				TgCYlVAMFtLejjQQravVwjdgsySb = 0;
				zwMQANNjMqIBWnYCbGrUBPhVCrldA2 = this;
			}
			else
			{
				zwMQANNjMqIBWnYCbGrUBPhVCrldA2 = new zwMQANNjMqIBWnYCbGrUBPhVCrldA(0);
				zwMQANNjMqIBWnYCbGrUBPhVCrldA2.xPhRBDZndnYsuUqqiWtVDfmHeWdD = xPhRBDZndnYsuUqqiWtVDfmHeWdD;
			}
			return zwMQANNjMqIBWnYCbGrUBPhVCrldA2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<JoystickType>)this).GetEnumerator();
		}
	}

	private sealed class eoktVpPvCwqSURYGFvVIyEXJeHbg : IEnumerable<Guid>, IEnumerable, IEnumerator<Guid>, IEnumerator, IDisposable
	{
		private int QCeUVcQKJfrdQIYCHRAEzdlrcYLbA;

		private Guid lSCKRydkFvYssLoHwyqtKTKwQamQ;

		private int QxbwplbOBkjFICGpJkKIPRIUsCUVA;

		public HardwareJoystickMap yZwGrDTofxnzAySqtOqHnGthEKjk;

		private Guid[] bLdWwIgiLeeCoKKlEBiwGMNWqsTVA;

		private int EVTUhBSvyTQJwxMpRGWZEQbvayIIA;

		Guid IEnumerator<Guid>.Current
		{
			[DebuggerHidden]
			get
			{
				return lSCKRydkFvYssLoHwyqtKTKwQamQ;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return lSCKRydkFvYssLoHwyqtKTKwQamQ;
			}
		}

		[DebuggerHidden]
		public eoktVpPvCwqSURYGFvVIyEXJeHbg(int P_0)
		{
			QCeUVcQKJfrdQIYCHRAEzdlrcYLbA = P_0;
			QxbwplbOBkjFICGpJkKIPRIUsCUVA = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int qCeUVcQKJfrdQIYCHRAEzdlrcYLbA = QCeUVcQKJfrdQIYCHRAEzdlrcYLbA;
			HardwareJoystickMap hardwareJoystickMap = yZwGrDTofxnzAySqtOqHnGthEKjk;
			switch (qCeUVcQKJfrdQIYCHRAEzdlrcYLbA)
			{
			default:
				return false;
			case 0:
				QCeUVcQKJfrdQIYCHRAEzdlrcYLbA = -1;
				if (ReInput.isReady)
				{
					bLdWwIgiLeeCoKKlEBiwGMNWqsTVA = hardwareJoystickMap.runtimeTemplateGuids;
					if (bLdWwIgiLeeCoKKlEBiwGMNWqsTVA == null)
					{
						return false;
					}
					EVTUhBSvyTQJwxMpRGWZEQbvayIIA = 0;
					goto IL_0086;
				}
				if (hardwareJoystickMap.templateGuids == null)
				{
					return false;
				}
				EVTUhBSvyTQJwxMpRGWZEQbvayIIA = 0;
				goto IL_00ea;
			case 1:
				QCeUVcQKJfrdQIYCHRAEzdlrcYLbA = -1;
				EVTUhBSvyTQJwxMpRGWZEQbvayIIA++;
				goto IL_0086;
			case 2:
				{
					QCeUVcQKJfrdQIYCHRAEzdlrcYLbA = -1;
					EVTUhBSvyTQJwxMpRGWZEQbvayIIA++;
					goto IL_00ea;
				}
				IL_0086:
				if (EVTUhBSvyTQJwxMpRGWZEQbvayIIA < bLdWwIgiLeeCoKKlEBiwGMNWqsTVA.Length)
				{
					lSCKRydkFvYssLoHwyqtKTKwQamQ = bLdWwIgiLeeCoKKlEBiwGMNWqsTVA[EVTUhBSvyTQJwxMpRGWZEQbvayIIA];
					QCeUVcQKJfrdQIYCHRAEzdlrcYLbA = 1;
					return true;
				}
				bLdWwIgiLeeCoKKlEBiwGMNWqsTVA = null;
				break;
				IL_00ea:
				if (EVTUhBSvyTQJwxMpRGWZEQbvayIIA < hardwareJoystickMap.templateGuids.Length)
				{
					lSCKRydkFvYssLoHwyqtKTKwQamQ = StringTools.ToGuid(hardwareJoystickMap.templateGuids[EVTUhBSvyTQJwxMpRGWZEQbvayIIA]);
					QCeUVcQKJfrdQIYCHRAEzdlrcYLbA = 2;
					return true;
				}
				break;
			}
			return false;
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
		IEnumerator<Guid> IEnumerable<Guid>.GetEnumerator()
		{
			eoktVpPvCwqSURYGFvVIyEXJeHbg eoktVpPvCwqSURYGFvVIyEXJeHbg2;
			if (QCeUVcQKJfrdQIYCHRAEzdlrcYLbA == -2 && QxbwplbOBkjFICGpJkKIPRIUsCUVA == Environment.CurrentManagedThreadId)
			{
				QCeUVcQKJfrdQIYCHRAEzdlrcYLbA = 0;
				eoktVpPvCwqSURYGFvVIyEXJeHbg2 = this;
			}
			else
			{
				eoktVpPvCwqSURYGFvVIyEXJeHbg2 = new eoktVpPvCwqSURYGFvVIyEXJeHbg(0);
				eoktVpPvCwqSURYGFvVIyEXJeHbg2.yZwGrDTofxnzAySqtOqHnGthEKjk = yZwGrDTofxnzAySqtOqHnGthEKjk;
			}
			return eoktVpPvCwqSURYGFvVIyEXJeHbg2;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Guid>)this).GetEnumerator();
		}
	}

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private string controllerName;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private string editorControllerName;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private string description;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private string controllerGuid;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private string controllerKey;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private string[] templateGuids;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private bool hideInLists;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private JoystickType[] joystickTypes;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private ControllerElementIdentifier[] elementIdentifiers;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private CompoundElement[] compoundElements;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_DirectInput directInput;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_RawInput rawInput;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_XInput xInput;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_WindowsWGI windowsWGI;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_OSX osx;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_Linux linux;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_WindowsUWP windowsUWP;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_Fallback fallback_Windows;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_Fallback fallback_WindowsUWP;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_Fallback fallback_OSX;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_Fallback fallback_Linux;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_Fallback fallback_Linux_PreConfigured;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_Fallback fallback_Android;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_Fallback fallback_iOS;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_Fallback fallback_XBoxOne;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_Fallback fallback_PS4;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_PS5 ps5;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_Fallback fallback_PSM;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_Fallback fallback_PSVita;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_Fallback fallback_AmazonFireTV;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_WebGL webGL;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_XboxOne xboxOne;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_GameCore gameCore;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_PS4 ps4;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_NintendoSwitch nintendoSwitch;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_InternalDriver internalDriver;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_SDL2 sdl2_Linux;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_SDL2 sdl2_Windows;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_SDL2 sdl2_OSX;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private Platform_AppleGCController appleGCController;

	[SerializeField]
	[CustomObfuscation(rename = false)]
	private int elementIdentifierIdCounter;

	[NonSerialized]
	private Guid? __runtimeControllerGuidCache;

	[NonSerialized]
	private Guid[] __runtimeTemplateGuidCache;

	private Guid runtimeControllerGuid
	{
		get
		{
			if (!__runtimeControllerGuidCache.HasValue || !__runtimeControllerGuidCache.HasValue)
			{
				__runtimeControllerGuidCache = StringTools.ToGuid(controllerGuid);
			}
			return __runtimeControllerGuidCache.Value;
		}
	}

	private Guid[] runtimeTemplateGuids
	{
		get
		{
			if (__runtimeTemplateGuidCache == null && templateGuids != null)
			{
				__runtimeTemplateGuidCache = new Guid[templateGuids.Length];
				for (int i = 0; i < templateGuids.Length; i++)
				{
					__runtimeTemplateGuidCache[i] = StringTools.ToGuid(templateGuids[i]);
				}
			}
			return __runtimeTemplateGuidCache;
		}
	}

	public string ControllerName => controllerName;

	public string EditorControllerName => editorControllerName;

	public Guid Guid
	{
		get
		{
			if (!ReInput.isReady)
			{
				return StringTools.ToGuid(controllerGuid);
			}
			return runtimeControllerGuid;
		}
	}

	public string Key => controllerKey;

	public IEnumerable<Guid> TemplateGuids
	{
		[IteratorStateMachine(typeof(eoktVpPvCwqSURYGFvVIyEXJeHbg))]
		get
		{
			return new eoktVpPvCwqSURYGFvVIyEXJeHbg(-2)
			{
				yZwGrDTofxnzAySqtOqHnGthEKjk = this
			};
		}
	}

	public IEnumerable<ControllerElementIdentifier> ElementIdentifiers
	{
		[IteratorStateMachine(typeof(TlnKcjDTqzFEnVWPEovzteeADhRU))]
		get
		{
			return new TlnKcjDTqzFEnVWPEovzteeADhRU(-2)
			{
				YXHcHUhinmbMYSbWMiuertlLKpPYA = this
			};
		}
	}

	public int elementIdentifierCount
	{
		get
		{
			if (elementIdentifiers == null)
			{
				return 0;
			}
			return elementIdentifiers.Length;
		}
	}

	public bool HideInLists => hideInLists;

	internal IEnumerable<JoystickType> JoystickTypes
	{
		[IteratorStateMachine(typeof(zwMQANNjMqIBWnYCbGrUBPhVCrldA))]
		get
		{
			return new zwMQANNjMqIBWnYCbGrUBPhVCrldA(-2)
			{
				xPhRBDZndnYsuUqqiWtVDfmHeWdD = this
			};
		}
	}

	Guid IHardwareControllerMap_Internal.typeGuid => Guid;

	string IHardwareControllerMap_Internal.typeKey => controllerKey;

	ControllerType IHardwareControllerMap_Internal.controllerType => ControllerType.Joystick;

	IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
	{
		[IteratorStateMachine(typeof(CBIklamezZjFsvbmQjvyAZzbhssnA))]
		get
		{
			return new CBIklamezZjFsvbmQjvyAZzbhssnA(-2)
			{
				JbRNvgBqNNkqMpiNdjPeIdmlFbDkA = this
			};
		}
	}

	string IHardwareControllerMap_Internal.name => base.name;

	public HardwareJoystickMap()
	{
		if (joystickTypes == null || joystickTypes.Length == 0)
		{
			joystickTypes = new JoystickType[1];
		}
		if (directInput == null)
		{
			directInput = new Platform_DirectInput();
		}
		if (rawInput == null)
		{
			rawInput = new Platform_RawInput();
		}
		if (xInput == null)
		{
			xInput = new Platform_XInput();
		}
		if (windowsWGI == null)
		{
			windowsWGI = new Platform_WindowsWGI();
		}
		if (osx == null)
		{
			osx = new Platform_OSX();
		}
		if (appleGCController == null)
		{
			appleGCController = new Platform_AppleGCController();
		}
		if (linux == null)
		{
			linux = new Platform_Linux();
		}
		if (windowsUWP == null)
		{
			windowsUWP = new Platform_WindowsUWP();
		}
		if (fallback_Android == null)
		{
			fallback_Android = new Platform_Fallback();
		}
		if (fallback_iOS == null)
		{
			fallback_iOS = new Platform_Fallback();
		}
		if (fallback_Linux == null)
		{
			fallback_Linux = new Platform_Fallback();
		}
		if (fallback_Linux_PreConfigured == null)
		{
			fallback_Linux_PreConfigured = new Platform_Fallback();
		}
		if (fallback_OSX == null)
		{
			fallback_OSX = new Platform_Fallback();
		}
		if (fallback_PS4 == null)
		{
			fallback_PS4 = new Platform_Fallback();
		}
		if (fallback_PSM == null)
		{
			fallback_PSM = new Platform_Fallback();
		}
		if (fallback_PSVita == null)
		{
			fallback_PSVita = new Platform_Fallback();
		}
		if (fallback_Windows == null)
		{
			fallback_Windows = new Platform_Fallback();
		}
		if (fallback_WindowsUWP == null)
		{
			fallback_WindowsUWP = new Platform_Fallback();
		}
		if (fallback_XBoxOne == null)
		{
			fallback_XBoxOne = new Platform_Fallback();
		}
		if (fallback_AmazonFireTV == null)
		{
			fallback_AmazonFireTV = new Platform_Fallback();
		}
		if (webGL == null)
		{
			webGL = new Platform_WebGL();
		}
		if (xboxOne == null)
		{
			xboxOne = new Platform_XboxOne();
		}
		if (gameCore == null)
		{
			gameCore = new Platform_GameCore();
		}
		if (ps4 == null)
		{
			ps4 = new Platform_PS4();
		}
		if (ps5 == null)
		{
			ps5 = new Platform_PS5();
		}
		if (nintendoSwitch == null)
		{
			nintendoSwitch = new Platform_NintendoSwitch();
		}
		if (internalDriver == null)
		{
			internalDriver = new Platform_InternalDriver();
		}
		if (sdl2_Linux == null)
		{
			sdl2_Linux = new Platform_SDL2();
		}
		if (sdl2_Windows == null)
		{
			sdl2_Windows = new Platform_SDL2();
		}
		if (sdl2_OSX == null)
		{
			sdl2_OSX = new Platform_SDL2();
		}
	}

	public HardwareJoystickMap(HardwareJoystickMap P_0)
		: this()
	{
		controllerGuid = P_0.controllerGuid;
		if (P_0.templateGuids != null)
		{
			int num = P_0.templateGuids.Length;
			templateGuids = new string[num];
			for (int i = 0; i < num; i++)
			{
				templateGuids[i] = templateGuids[i];
			}
		}
		if (P_0.elementIdentifiers != null)
		{
			int num2 = P_0.elementIdentifiers.Length;
			elementIdentifiers = new ControllerElementIdentifier[num2];
			for (int j = 0; j < num2; j++)
			{
				elementIdentifiers[j] = elementIdentifiers[j].Clone();
			}
		}
		elementIdentifierIdCounter = P_0.elementIdentifierIdCounter;
		if (P_0.compoundElements != null)
		{
			int num3 = P_0.compoundElements.Length;
			compoundElements = new CompoundElement[num3];
			for (int k = 0; k < num3; k++)
			{
				compoundElements[k] = P_0.compoundElements[k].DeepClone() as CompoundElement;
			}
		}
		joystickTypes = ArrayTools.ShallowCopy(P_0.joystickTypes);
		if (P_0.directInput != null)
		{
			directInput = MiscTools.DeepClone(P_0.directInput);
		}
		if (P_0.rawInput != null)
		{
			rawInput = MiscTools.DeepClone(rawInput);
		}
		if (P_0.xInput != null)
		{
			xInput = MiscTools.DeepClone(P_0.xInput);
		}
		if (P_0.windowsWGI != null)
		{
			windowsWGI = MiscTools.DeepClone(P_0.windowsWGI);
		}
		if (P_0.osx != null)
		{
			osx = MiscTools.DeepClone(P_0.osx);
		}
		if (P_0.appleGCController != null)
		{
			appleGCController = MiscTools.DeepClone(P_0.appleGCController);
		}
		if (P_0.linux != null)
		{
			linux = MiscTools.DeepClone(P_0.linux);
		}
		if (P_0.windowsUWP != null)
		{
			windowsUWP = MiscTools.DeepClone(P_0.windowsUWP);
		}
		if (P_0.fallback_Windows != null)
		{
			fallback_Windows = MiscTools.DeepClone(fallback_Windows);
		}
		if (P_0.fallback_WindowsUWP != null)
		{
			fallback_WindowsUWP = MiscTools.DeepClone(fallback_WindowsUWP);
		}
		if (P_0.fallback_OSX != null)
		{
			fallback_OSX = MiscTools.DeepClone(fallback_OSX);
		}
		if (P_0.fallback_Android != null)
		{
			fallback_Android = MiscTools.DeepClone(fallback_Android);
		}
		if (P_0.fallback_iOS != null)
		{
			fallback_iOS = MiscTools.DeepClone(fallback_iOS);
		}
		if (P_0.fallback_Linux != null)
		{
			fallback_Linux = MiscTools.DeepClone(fallback_Linux);
		}
		if (P_0.fallback_Linux_PreConfigured != null)
		{
			fallback_Linux_PreConfigured = MiscTools.DeepClone(fallback_Linux_PreConfigured);
		}
		if (P_0.fallback_PS4 != null)
		{
			fallback_PS4 = MiscTools.DeepClone(fallback_PS4);
		}
		if (P_0.fallback_PSM != null)
		{
			fallback_PSM = MiscTools.DeepClone(fallback_PSM);
		}
		if (P_0.fallback_PSVita != null)
		{
			fallback_PSVita = MiscTools.DeepClone(fallback_PSVita);
		}
		if (P_0.fallback_XBoxOne != null)
		{
			fallback_XBoxOne = MiscTools.DeepClone(fallback_XBoxOne);
		}
		if (P_0.nintendoSwitch != null)
		{
			nintendoSwitch = MiscTools.DeepClone(P_0.nintendoSwitch);
		}
		if (P_0.fallback_AmazonFireTV != null)
		{
			fallback_AmazonFireTV = MiscTools.DeepClone(fallback_AmazonFireTV);
		}
		if (P_0.webGL != null)
		{
			webGL = MiscTools.DeepClone(P_0.webGL);
		}
		if (P_0.xboxOne != null)
		{
			xboxOne = MiscTools.DeepClone(P_0.xboxOne);
		}
		if (P_0.gameCore != null)
		{
			gameCore = MiscTools.DeepClone(P_0.gameCore);
		}
		if (P_0.ps4 != null)
		{
			ps4 = MiscTools.DeepClone(P_0.ps4);
		}
		if (P_0.ps5 != null)
		{
			ps5 = MiscTools.DeepClone(P_0.ps5);
		}
		if (P_0.internalDriver != null)
		{
			internalDriver = MiscTools.DeepClone(P_0.internalDriver);
		}
		if (P_0.sdl2_Linux != null)
		{
			sdl2_Linux = MiscTools.DeepClone(P_0.sdl2_Linux);
		}
		if (P_0.sdl2_Windows != null)
		{
			sdl2_Windows = MiscTools.DeepClone(P_0.sdl2_Windows);
		}
		if (P_0.sdl2_OSX != null)
		{
			sdl2_OSX = MiscTools.DeepClone(P_0.sdl2_OSX);
		}
	}

	public int GetTemplateGuids(IList<Guid> results)
	{
		int num = 0;
		if (ReInput.isReady)
		{
			Guid[] array = runtimeTemplateGuids;
			if (array == null)
			{
				return 0;
			}
			int num2 = array.Length;
			for (int i = 0; i < num2; i++)
			{
				results.Add(array[i]);
				num++;
			}
		}
		else
		{
			if (templateGuids == null)
			{
				return 0;
			}
			for (int j = 0; j < templateGuids.Length; j++)
			{
				results.Add(StringTools.ToGuid(templateGuids[j]));
				num++;
			}
		}
		return num;
	}

	public bool ContainsTemplateGuid(Guid guid)
	{
		if (ReInput.isReady)
		{
			Guid[] array = runtimeTemplateGuids;
			if (array == null)
			{
				return false;
			}
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				if (guid == array[i])
				{
					return true;
				}
			}
		}
		else
		{
			if (templateGuids == null)
			{
				return false;
			}
			for (int j = 0; j < templateGuids.Length; j++)
			{
				if (guid == StringTools.ToGuid(templateGuids[j]))
				{
					return true;
				}
			}
		}
		return false;
	}

	[CustomObfuscation(rename = false)]
	public string[] GetElementIdentifierNames()
	{
		int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
		if (num == 0)
		{
			return null;
		}
		string[] array = new string[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = elementIdentifiers[i].get_name();
		}
		return array;
	}

	string[] IHardwareControllerMap.GetElementIdentifierNames()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetElementIdentifierNames
		return this.GetElementIdentifierNames();
	}

	[CustomObfuscation(rename = false)]
	public int[] GetElementIdentifierIds()
	{
		int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
		if (num == 0)
		{
			return null;
		}
		int[] array = new int[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = elementIdentifiers[i].get_id();
		}
		return array;
	}

	int[] IHardwareControllerMap.GetElementIdentifierIds()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetElementIdentifierIds
		return this.GetElementIdentifierIds();
	}

	[CustomObfuscation(rename = false)]
	public ControllerElementIdentifier GetElementIdentifier(int id)
	{
		int num = IndexOfElementIdentifier(id);
		if (num < 0 || num >= elementIdentifiers.Length)
		{
			return null;
		}
		return elementIdentifiers[num];
	}

	[CustomObfuscation(rename = false)]
	public ControllerElementIdentifier GetElementIdentifierAtIndex(int index)
	{
		if (index < 0 || index >= elementIdentifiers.Length)
		{
			return null;
		}
		return elementIdentifiers[index];
	}

	[CustomObfuscation(rename = false)]
	public bool ContainsElementIdentifier(int id)
	{
		return IndexOfElementIdentifier(id) >= 0;
	}

	bool IHardwareControllerMap.ContainsElementIdentifier(int id)
	{
		//ILSpy generated this explicit interface implementation from .override directive in ContainsElementIdentifier
		return this.ContainsElementIdentifier(id);
	}

	[CustomObfuscation(rename = false)]
	public int GetElementIdentifierInfo(ControllerElementType type, out string[] names, out int[] ids)
	{
		names = null;
		ids = null;
		int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
		if (num == 0)
		{
			return 0;
		}
		List<ControllerElementIdentifier> list = new List<ControllerElementIdentifier>();
		for (int i = 0; i < num; i++)
		{
			if (elementIdentifiers[i] != null && elementIdentifiers[i].elementType == type)
			{
				list.Add(elementIdentifiers[i]);
			}
		}
		int count = list.Count;
		if (count == 0)
		{
			return 0;
		}
		names = new string[count];
		ids = new int[count];
		for (int j = 0; j < count; j++)
		{
			names[j] = list[j].get_name();
			ids[j] = list[j].get_id();
		}
		return count;
	}

	[CustomObfuscation(rename = false)]
	public int GetMappableElementIdentifierInfo(out string[] names, out int[] ids)
	{
		names = null;
		ids = null;
		int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
		if (num == 0)
		{
			return 0;
		}
		List<ControllerElementIdentifier> list = new List<ControllerElementIdentifier>();
		for (int i = 0; i < num; i++)
		{
			if (elementIdentifiers[i] != null && InputTools.IsMappableType(elementIdentifiers[i].elementType))
			{
				list.Add(elementIdentifiers[i]);
			}
		}
		int count = list.Count;
		if (count == 0)
		{
			return 0;
		}
		names = new string[count];
		ids = new int[count];
		for (int j = 0; j < count; j++)
		{
			names[j] = list[j].get_name();
			ids[j] = list[j].get_id();
		}
		return count;
	}

	int IHardwareControllerMap.GetMappableElementIdentifierInfo(out string[] names, out int[] ids)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetMappableElementIdentifierInfo
		return this.GetMappableElementIdentifierInfo(out names, out ids);
	}

	internal HardwareJoystickMap Clone()
	{
		return new HardwareJoystickMap(this);
	}

	internal int IndexOfElementIdentifier(int id)
	{
		if (elementIdentifiers == null)
		{
			return -1;
		}
		for (int i = 0; i < elementIdentifiers.Length; i++)
		{
			if (elementIdentifiers[i].get_id() == id)
			{
				return i;
			}
		}
		return -1;
	}

	internal ControllerElementType GetEffectiveElementIdentifierType(HardwareControllerMapIdentifier hardwareMapIdentifier, int elementIdentifierId, bool isDefaultMap)
	{
		ControllerElementIdentifier elementIdentifier = GetElementIdentifier(elementIdentifierId);
		if (elementIdentifier == null)
		{
			return ControllerElementType.Axis;
		}
		return GetSpecificPlatformMap(hardwareMapIdentifier)?.GetEffectiveElementIdentifierType(elementIdentifier) ?? ControllerElementType.Axis;
	}

	internal bool GetEffectiveAxisRange(HardwareControllerMapIdentifier hardwareMapIdentifier, int elementIdentifierId, bool isDefaultMap, out AxisRange axisRange)
	{
		axisRange = AxisRange.Full;
		ControllerElementIdentifier elementIdentifier = GetElementIdentifier(elementIdentifierId);
		if (elementIdentifier == null)
		{
			return false;
		}
		return GetSpecificPlatformMap(hardwareMapIdentifier)?.GetEffectiveAxisRange(elementIdentifier, out axisRange) ?? false;
	}

	internal void GetElementIdentifiersForControllerElements(HardwareControllerMapIdentifier hardwareMapIdentifier, bool isDefaultMap, out int[] buttons, out int[] axes)
	{
		buttons = null;
		axes = null;
		Platform specificPlatformMap = GetSpecificPlatformMap(hardwareMapIdentifier);
		if (specificPlatformMap != null && specificPlatformMap.assignedButtonCount > 0)
		{
			specificPlatformMap.GetGameElementIdentifierIdMappings(out buttons, out axes);
		}
	}

	internal static bool Matches(Platform platform, BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, out int variantIndex, out Platform platformMap)
	{
		if (platform == null)
		{
			variantIndex = -1;
			platformMap = null;
			return false;
		}
		return platform.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
	}

	internal bool Matches(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex, out Platform platformMap)
	{
		actualInputPlatform = InputPlatform.Unknown;
		variantIndex = -1;
		platformMap = null;
		if (bridgedControllerHWInfo == null)
		{
			return false;
		}
		switch (bridgedControllerHWInfo.inputSource)
		{
		case InputSource.DirectInput:
			if (Matches(directInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				actualInputPlatform = InputPlatform.WindowsDirectInput;
				return true;
			}
			if (Matches(rawInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				actualInputPlatform = InputPlatform.WindowsRawInput;
				return true;
			}
			return false;
		case InputSource.RawInput:
			if (Matches(rawInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				actualInputPlatform = InputPlatform.WindowsRawInput;
				return true;
			}
			if (Matches(directInput, bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				actualInputPlatform = InputPlatform.WindowsDirectInput;
				return true;
			}
			return false;
		case InputSource.XInput:
			if (xInput == null)
			{
				return false;
			}
			actualInputPlatform = InputPlatform.WindowsXInput;
			return xInput.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
		case InputSource.WindowsGamingInput:
			if (windowsWGI == null)
			{
				return false;
			}
			actualInputPlatform = InputPlatform.WindowsWGI;
			return windowsWGI.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
		case InputSource.OSX:
			if (osx == null)
			{
				return false;
			}
			actualInputPlatform = InputPlatform.OSXNative;
			return osx.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
		case InputSource.AppleGameController:
			if (appleGCController == null)
			{
				return false;
			}
			actualInputPlatform = InputPlatform.AppleGameController;
			return appleGCController.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
		case InputSource.Linux:
			if (linux == null)
			{
				return false;
			}
			actualInputPlatform = InputPlatform.LinuxNative;
			return linux.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
		case InputSource.WindowsUWP:
			if (windowsUWP == null)
			{
				return false;
			}
			actualInputPlatform = InputPlatform.WindowsUWP;
			return windowsUWP.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
		case InputSource.Fallback:
		case InputSource.Fallback_PreConfigured:
			platformMap = FindFallbackMatch(bridgedControllerHWInfo, strictMatch, isDefaultMap, out actualInputPlatform, out variantIndex);
			return platformMap != null;
		case InputSource.WebGL:
			if (webGL == null)
			{
				return false;
			}
			actualInputPlatform = InputPlatform.WebGL;
			return webGL.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
		case InputSource.XboxOne:
			if (xboxOne == null)
			{
				return false;
			}
			actualInputPlatform = InputPlatform.XboxOne;
			return xboxOne.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
		case InputSource.GameCoreXboxOne:
		case InputSource.GameCoreScarlett:
			if (gameCore == null)
			{
				return false;
			}
			actualInputPlatform = InputPlatform.GameCore;
			return gameCore.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
		case InputSource.PS4:
			if (ps4 == null)
			{
				return false;
			}
			actualInputPlatform = InputPlatform.PS4;
			return ps4.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
		case InputSource.PS5:
			if (ps5 == null)
			{
				return false;
			}
			actualInputPlatform = InputPlatform.PS5;
			return ps5.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
		case InputSource.NintendoSwitch:
			if (nintendoSwitch == null)
			{
				return false;
			}
			actualInputPlatform = InputPlatform.NintendoSwitch;
			return nintendoSwitch.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
		case InputSource.InternalDriver:
			if (internalDriver == null)
			{
				return false;
			}
			actualInputPlatform = InputPlatform.InternalDriver;
			return internalDriver.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
		case InputSource.SDL2:
			platformMap = FindSDL2Match(bridgedControllerHWInfo, strictMatch, isDefaultMap, out actualInputPlatform, out variantIndex);
			return platformMap != null;
		case InputSource.Steam:
			actualInputPlatform = InputPlatform.Steam;
			return false;
		case InputSource.Custom:
			if (!DYXEicTUvpxnVFlTbwIfiujTNpTs.ZCGrnntEgTOKZdITtdptDPSiYsuz())
			{
				return false;
			}
			actualInputPlatform = InputPlatform.Custom;
			platformMap = DYXEicTUvpxnVFlTbwIfiujTNpTs.YDIrRsFjIHjnZjDZXkaWvaZcvrth().GetPlatformMap(DYXEicTUvpxnVFlTbwIfiujTNpTs.XSbLyONHNwqeYxvuTBVWMKHSndSv(), Guid);
			if (platformMap != null)
			{
				return platformMap.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap);
			}
			return false;
		default:
			throw new NotImplementedException();
		}
	}

	internal HardwareJoystickMap_InputManager GetDefaultHardwareJoystickMap_InputManager(BridgedControllerHWInfo bridgedController)
	{
		InputSource inputSource = bridgedController.inputSource;
		InputPlatform actualInputPlatform;
		Platform platform;
		int variantIndex;
		switch (inputSource)
		{
		case InputSource.DirectInput:
			actualInputPlatform = InputPlatform.WindowsDirectInput;
			platform = directInput;
			break;
		case InputSource.RawInput:
			actualInputPlatform = InputPlatform.WindowsRawInput;
			platform = rawInput;
			break;
		case InputSource.XInput:
			actualInputPlatform = InputPlatform.WindowsXInput;
			platform = xInput;
			break;
		case InputSource.WindowsGamingInput:
			actualInputPlatform = InputPlatform.WindowsWGI;
			platform = windowsWGI;
			break;
		case InputSource.OSX:
			actualInputPlatform = InputPlatform.OSXNative;
			platform = osx;
			break;
		case InputSource.AppleGameController:
			actualInputPlatform = InputPlatform.AppleGameController;
			platform = appleGCController;
			break;
		case InputSource.Linux:
			actualInputPlatform = InputPlatform.LinuxNative;
			platform = linux;
			break;
		case InputSource.WindowsUWP:
			actualInputPlatform = InputPlatform.WindowsUWP;
			platform = windowsUWP;
			break;
		case InputSource.Fallback:
		case InputSource.Fallback_PreConfigured:
			platform = FindFallbackMap(inputSource, isDefaultMap: true, out actualInputPlatform, out variantIndex);
			break;
		case InputSource.WebGL:
			actualInputPlatform = InputPlatform.WebGL;
			platform = webGL;
			break;
		case InputSource.XboxOne:
			actualInputPlatform = InputPlatform.XboxOne;
			platform = xboxOne;
			break;
		case InputSource.GameCoreXboxOne:
		case InputSource.GameCoreScarlett:
			actualInputPlatform = InputPlatform.GameCore;
			platform = gameCore;
			if (!gameCore.hasData)
			{
				platform = Platform_GameCore.CreateDefaultMap(bridgedController);
			}
			break;
		case InputSource.PS4:
			actualInputPlatform = InputPlatform.PS4;
			platform = ps4;
			break;
		case InputSource.PS5:
			actualInputPlatform = InputPlatform.PS5;
			platform = ps5;
			break;
		case InputSource.NintendoSwitch:
			actualInputPlatform = InputPlatform.NintendoSwitch;
			platform = nintendoSwitch;
			break;
		case InputSource.InternalDriver:
			actualInputPlatform = InputPlatform.InternalDriver;
			platform = internalDriver;
			break;
		case InputSource.SDL2:
			platform = FindSDL2Map(inputSource, isDefaultMap: true, out actualInputPlatform, out variantIndex);
			break;
		case InputSource.Custom:
			if (!DYXEicTUvpxnVFlTbwIfiujTNpTs.ZCGrnntEgTOKZdITtdptDPSiYsuz())
			{
				return null;
			}
			actualInputPlatform = InputPlatform.Custom;
			platform = DYXEicTUvpxnVFlTbwIfiujTNpTs.YDIrRsFjIHjnZjDZXkaWvaZcvrth().GetPlatformMap(DYXEicTUvpxnVFlTbwIfiujTNpTs.XSbLyONHNwqeYxvuTBVWMKHSndSv(), Guid);
			break;
		case InputSource.None:
			return null;
		case InputSource.Steam:
		case InputSource.UnityKeyboardAndMouse:
			throw new NotImplementedException();
		default:
			throw new NotImplementedException();
		}
		return platform?.ToHardwareJoystickMap_InputManager(this, inputSource, actualInputPlatform, -1);
	}

	internal string[] GetTemplateGuidsOrig()
	{
		return templateGuids;
	}

	IControllerElementIdentifierCommon_Internal IHardwareControllerMap_Internal.GetElementIdentifier(int id)
	{
		return GetElementIdentifier(id);
	}

	private Platform_Fallback_Base FindFallbackMatch(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
	{
		InputSource inputSource = bridgedControllerHWInfo.inputSource;
		Rewired.Platforms.Platform platform = UnityTools.platform;
		switch (UnityTools.editorPlatform)
		{
		case EditorPlatform.Windows:
			platform = Rewired.Platforms.Platform.Windows;
			break;
		case EditorPlatform.OSX:
			platform = Rewired.Platforms.Platform.OSX;
			break;
		case EditorPlatform.Linux:
			platform = Rewired.Platforms.Platform.Linux;
			break;
		}
		switch (platform)
		{
		case Rewired.Platforms.Platform.Windows:
		case Rewired.Platforms.Platform.WindowsAppStore:
		{
			Platform_Fallback_Base mainMap = fallback_Windows;
			actualInputPlatform = InputPlatform.WindowsFallback;
			return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.WindowsUWP:
		{
			Platform_Fallback_Base mainMap = fallback_WindowsUWP;
			actualInputPlatform = InputPlatform.WindowsUWPFallback;
			return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.OSX:
		{
			Platform_Fallback_Base mainMap = fallback_OSX;
			actualInputPlatform = InputPlatform.OSXFallback;
			return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.Linux:
		{
			Platform_Fallback_Base mainMap;
			if (inputSource == InputSource.Fallback_PreConfigured)
			{
				mainMap = fallback_Linux_PreConfigured;
				actualInputPlatform = InputPlatform.LinuxFallback_PreConfigured;
				mainMap = TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
				if (isDefaultMap && mainMap != null && actualInputPlatform != InputPlatform.LinuxFallback_PreConfigured)
				{
					mainMap = null;
				}
				if (mainMap != null)
				{
					return mainMap;
				}
			}
			mainMap = fallback_Linux;
			actualInputPlatform = InputPlatform.LinuxFallback;
			return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.Android:
		{
			Platform_Fallback_Base mainMap = fallback_Android;
			actualInputPlatform = InputPlatform.AndroidFallback;
			return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.iOS:
		case Rewired.Platforms.Platform.tvOS:
		{
			Platform_Fallback_Base mainMap = fallback_iOS;
			actualInputPlatform = InputPlatform.iOSFallback;
			return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.XboxOne:
		{
			Platform_Fallback_Base mainMap = fallback_XBoxOne;
			actualInputPlatform = InputPlatform.XBoxOneFallback;
			return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.PS4:
		{
			Platform_Fallback_Base mainMap = fallback_PS4;
			actualInputPlatform = InputPlatform.PS4Fallback;
			return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.PSMobile:
		{
			Platform_Fallback_Base mainMap = fallback_PSM;
			actualInputPlatform = InputPlatform.PSMFallback;
			return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.PSVita:
		{
			Platform_Fallback_Base mainMap = fallback_PSVita;
			actualInputPlatform = InputPlatform.PSVitaFallback;
			return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.AmazonFireTV:
		{
			Platform_Fallback_Base mainMap = fallback_AmazonFireTV;
			actualInputPlatform = InputPlatform.AmazonFireTVFallback;
			mainMap = TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			if (isDefaultMap && mainMap != null && actualInputPlatform != InputPlatform.AmazonFireTVFallback)
			{
				mainMap = null;
			}
			if (mainMap != null)
			{
				return mainMap;
			}
			mainMap = fallback_Android;
			actualInputPlatform = InputPlatform.AndroidFallback;
			return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.Webplayer:
			if (UnityTools.webplayerPlatform == WebplayerPlatform.Windows)
			{
				Platform_Fallback_Base mainMap = fallback_Windows;
				actualInputPlatform = InputPlatform.WindowsFallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			if (UnityTools.webplayerPlatform == WebplayerPlatform.OSX)
			{
				Platform_Fallback_Base mainMap = fallback_OSX;
				actualInputPlatform = InputPlatform.OSXFallback;
				return TryGetFirstMatchingMap(mainMap, bridgedControllerHWInfo, strictMatch, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			break;
		}
		if (isDefaultMap)
		{
			return GetUniversalDefaultMap<Platform_Fallback_Base>(out actualInputPlatform, out variantIndex);
		}
		variantIndex = -1;
		actualInputPlatform = InputPlatform.Unknown;
		return null;
	}

	private Platform_Fallback_Base FindFallbackMap(InputSource inputSource, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
	{
		Rewired.Platforms.Platform platform = UnityTools.platform;
		switch (UnityTools.editorPlatform)
		{
		case EditorPlatform.Windows:
			platform = Rewired.Platforms.Platform.Windows;
			break;
		case EditorPlatform.OSX:
			platform = Rewired.Platforms.Platform.OSX;
			break;
		case EditorPlatform.Linux:
			platform = Rewired.Platforms.Platform.Linux;
			break;
		}
		switch (platform)
		{
		case Rewired.Platforms.Platform.Windows:
		case Rewired.Platforms.Platform.WindowsAppStore:
		{
			Platform_Fallback_Base mainMap = fallback_Windows;
			actualInputPlatform = InputPlatform.WindowsFallback;
			return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.WindowsUWP:
		{
			Platform_Fallback_Base mainMap = fallback_WindowsUWP;
			actualInputPlatform = InputPlatform.WindowsUWPFallback;
			return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.OSX:
		{
			Platform_Fallback_Base mainMap = fallback_OSX;
			actualInputPlatform = InputPlatform.OSXFallback;
			return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.Linux:
		{
			Platform_Fallback_Base mainMap;
			if (inputSource == InputSource.Fallback_PreConfigured)
			{
				mainMap = fallback_Linux_PreConfigured;
				actualInputPlatform = InputPlatform.LinuxFallback_PreConfigured;
				mainMap = TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
				if (isDefaultMap && mainMap != null && actualInputPlatform != InputPlatform.LinuxFallback_PreConfigured)
				{
					mainMap = null;
				}
				if (mainMap != null)
				{
					return mainMap;
				}
			}
			mainMap = fallback_Linux;
			actualInputPlatform = InputPlatform.LinuxFallback;
			return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.Android:
		{
			Platform_Fallback_Base mainMap = fallback_Android;
			actualInputPlatform = InputPlatform.AndroidFallback;
			return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.iOS:
		case Rewired.Platforms.Platform.tvOS:
		{
			Platform_Fallback_Base mainMap = fallback_iOS;
			actualInputPlatform = InputPlatform.iOSFallback;
			return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.XboxOne:
		{
			Platform_Fallback_Base mainMap = fallback_XBoxOne;
			actualInputPlatform = InputPlatform.XBoxOneFallback;
			return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.PS4:
		{
			Platform_Fallback_Base mainMap = fallback_PS4;
			actualInputPlatform = InputPlatform.PS4Fallback;
			return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.PSMobile:
		{
			Platform_Fallback_Base mainMap = fallback_PSM;
			actualInputPlatform = InputPlatform.PSMFallback;
			return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.PSVita:
		{
			Platform_Fallback_Base mainMap = fallback_PSVita;
			actualInputPlatform = InputPlatform.PSVitaFallback;
			return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.AmazonFireTV:
		{
			Platform_Fallback_Base mainMap = fallback_AmazonFireTV;
			actualInputPlatform = InputPlatform.AmazonFireTVFallback;
			mainMap = TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			if (isDefaultMap && mainMap != null && actualInputPlatform != InputPlatform.AmazonFireTVFallback)
			{
				mainMap = null;
			}
			if (mainMap != null)
			{
				return mainMap;
			}
			mainMap = fallback_Android;
			actualInputPlatform = InputPlatform.AndroidFallback;
			return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.Webplayer:
			if (UnityTools.webplayerPlatform == WebplayerPlatform.Windows)
			{
				Platform_Fallback_Base mainMap = fallback_Windows;
				actualInputPlatform = InputPlatform.WindowsFallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			if (UnityTools.webplayerPlatform == WebplayerPlatform.OSX)
			{
				Platform_Fallback_Base mainMap = fallback_OSX;
				actualInputPlatform = InputPlatform.OSXFallback;
				return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
			}
			break;
		}
		if (isDefaultMap)
		{
			return GetUniversalDefaultMap<Platform_Fallback_Base>(out actualInputPlatform, out variantIndex);
		}
		variantIndex = -1;
		actualInputPlatform = InputPlatform.Unknown;
		return null;
	}

	private Platform_SDL2_Base FindSDL2Match(BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
	{
		Rewired.Platforms.Platform platform = UnityTools.platform;
		switch (UnityTools.editorPlatform)
		{
		case EditorPlatform.Windows:
			platform = Rewired.Platforms.Platform.Windows;
			break;
		case EditorPlatform.OSX:
			platform = Rewired.Platforms.Platform.OSX;
			break;
		case EditorPlatform.Linux:
			platform = Rewired.Platforms.Platform.Linux;
			break;
		}
		switch (platform)
		{
		case Rewired.Platforms.Platform.Windows:
		{
			Platform_SDL2_Base mainMap = sdl2_Windows;
			actualInputPlatform = InputPlatform.SDL2Windows;
			return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.Linux:
		{
			Platform_SDL2_Base mainMap = sdl2_Linux;
			actualInputPlatform = InputPlatform.SDL2Linux;
			return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.OSX:
		{
			Platform_SDL2_Base mainMap = sdl2_OSX;
			actualInputPlatform = InputPlatform.SDL2OSX;
			return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		default:
			if (isDefaultMap)
			{
				GetUniversalDefaultMap<Platform_SDL2_Base>(out actualInputPlatform, out variantIndex);
			}
			actualInputPlatform = InputPlatform.Unknown;
			variantIndex = -1;
			return null;
		}
	}

	private Platform_SDL2_Base FindSDL2Map(InputSource inputSource, bool isDefaultMap, out InputPlatform actualInputPlatform, out int variantIndex)
	{
		Rewired.Platforms.Platform platform = UnityTools.platform;
		switch (UnityTools.editorPlatform)
		{
		case EditorPlatform.Windows:
			platform = Rewired.Platforms.Platform.Windows;
			break;
		case EditorPlatform.OSX:
			platform = Rewired.Platforms.Platform.OSX;
			break;
		case EditorPlatform.Linux:
			platform = Rewired.Platforms.Platform.Linux;
			break;
		}
		switch (platform)
		{
		case Rewired.Platforms.Platform.Windows:
		{
			Platform_SDL2_Base mainMap = sdl2_Windows;
			actualInputPlatform = InputPlatform.SDL2Windows;
			return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.Linux:
		{
			Platform_SDL2_Base mainMap = sdl2_Linux;
			actualInputPlatform = InputPlatform.SDL2Linux;
			return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		case Rewired.Platforms.Platform.OSX:
		{
			Platform_SDL2_Base mainMap = sdl2_OSX;
			actualInputPlatform = InputPlatform.SDL2OSX;
			return TryGetFirstValidMap(mainMap, isDefaultMap, ref actualInputPlatform, out variantIndex);
		}
		default:
			if (isDefaultMap)
			{
				GetUniversalDefaultMap<Platform_SDL2_Base>(out actualInputPlatform, out variantIndex);
			}
			actualInputPlatform = InputPlatform.Unknown;
			variantIndex = -1;
			return null;
		}
	}

	private T TryGetFirstValidMap<T>(T mainMap, bool isDefaultMap, ref InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
	{
		if (isDefaultMap)
		{
			if (mainMap == null || !mainMap.selfOrVariantIsAllowed)
			{
				return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
			}
			if (mainMap.isAllowed)
			{
				variantIndex = -1;
				return mainMap;
			}
			IList<Platform> variants = mainMap.GetVariants();
			if (variants != null)
			{
				for (int i = 0; i < variants.Count; i++)
				{
					Platform platform = variants[i];
					if (platform != null && platform.isAllowed)
					{
						variantIndex = i;
						return platform as T;
					}
				}
			}
			return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
		}
		if (mainMap == null || !mainMap.selfOrVariantIsValid)
		{
			variantIndex = -1;
			return null;
		}
		return mainMap.GetFirstValidPlatformMap(out variantIndex) as T;
	}

	private T TryGetFirstMatchingMap<T>(T mainMap, BridgedControllerHWInfo bridgedControllerHWInfo, bool strictMatch, bool isDefaultMap, ref InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
	{
		Platform platformMap;
		if (isDefaultMap)
		{
			if (mainMap == null)
			{
				return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
			}
			if (mainMap.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
			{
				return platformMap as T;
			}
			return GetUniversalDefaultMap<T>(out actualInputPlatform, out variantIndex);
		}
		if (mainMap == null)
		{
			variantIndex = -1;
			return null;
		}
		if (mainMap.Matches(bridgedControllerHWInfo, strictMatch, out variantIndex, out platformMap))
		{
			return platformMap as T;
		}
		variantIndex = -1;
		return null;
	}

	private T GetUniversalDefaultMap<T>(out InputPlatform actualInputPlatform, out int variantIndex) where T : Platform
	{
		T universalDefaultMapRoot = GetUniversalDefaultMapRoot<T>(typeof(T), out actualInputPlatform);
		actualInputPlatform = InputPlatform.SDL2Windows;
		variantIndex = -1;
		if (universalDefaultMapRoot == null || !universalDefaultMapRoot.selfOrVariantIsAllowed)
		{
			return null;
		}
		if (universalDefaultMapRoot.isAllowed)
		{
			return universalDefaultMapRoot;
		}
		IList<Platform> variants = universalDefaultMapRoot.GetVariants();
		if (variants != null)
		{
			for (int i = 0; i < variants.Count; i++)
			{
				if (variants[i] != null && variants[i].isAllowed)
				{
					variantIndex = i;
					return variants[i] as T;
				}
			}
		}
		return null;
	}

	private T GetUniversalDefaultMapRoot<T>(Type type, out InputPlatform actualInputPlatform) where T : Platform
	{
		if ((object)type == typeof(Platform_Fallback_Base))
		{
			actualInputPlatform = InputPlatform.WindowsFallback;
			return fallback_Windows as T;
		}
		if ((object)type == typeof(Platform_SDL2_Base))
		{
			actualInputPlatform = InputPlatform.SDL2Windows;
			return sdl2_Windows as T;
		}
		throw new NotImplementedException();
	}

	private Platform GetSpecificPlatformMap(HardwareControllerMapIdentifier hardwareMapIdentifier)
	{
		return GetSpecificPlatformRoot(hardwareMapIdentifier.actualInputPlatform)?.GetPlatformMap(hardwareMapIdentifier.variantIndex);
	}

	private Platform GetSpecificPlatformRoot(InputPlatform exactInputPlatform)
	{
		switch (exactInputPlatform)
		{
		case InputPlatform.WindowsDirectInput:
			return directInput;
		case InputPlatform.WindowsRawInput:
			return rawInput;
		case InputPlatform.WindowsXInput:
			return xInput;
		case InputPlatform.WindowsWGI:
			return windowsWGI;
		case InputPlatform.WindowsFallback:
			return fallback_Windows;
		case InputPlatform.WindowsUWP:
			return windowsUWP;
		case InputPlatform.WindowsUWPFallback:
			return fallback_WindowsUWP;
		case InputPlatform.OSXNative:
			return osx;
		case InputPlatform.AppleGameController:
			return appleGCController;
		case InputPlatform.OSXFallback:
			return fallback_OSX;
		case InputPlatform.LinuxNative:
			return linux;
		case InputPlatform.LinuxFallback:
			return fallback_Linux;
		case InputPlatform.LinuxFallback_PreConfigured:
			return fallback_Linux_PreConfigured;
		case InputPlatform.AndroidFallback:
			return fallback_Android;
		case InputPlatform.AmazonFireTVFallback:
			return fallback_AmazonFireTV;
		case InputPlatform.RazerForgeTVFallback:
			return fallback_Android;
		case InputPlatform.iOSFallback:
			return fallback_iOS;
		case InputPlatform.PS4Fallback:
			return fallback_PS4;
		case InputPlatform.PSMFallback:
			return fallback_PSM;
		case InputPlatform.PSVitaFallback:
			return fallback_PSVita;
		case InputPlatform.XBoxOneFallback:
			return fallback_XBoxOne;
		case InputPlatform.NintendoSwitch:
			return nintendoSwitch;
		case InputPlatform.Fallback:
			throw new NotImplementedException();
		case InputPlatform.WebGL:
			return webGL;
		case InputPlatform.XboxOne:
			return xboxOne;
		case InputPlatform.GameCore:
			return gameCore;
		case InputPlatform.PS4:
			return ps4;
		case InputPlatform.PS5:
			return ps5;
		case InputPlatform.Custom:
			if (!DYXEicTUvpxnVFlTbwIfiujTNpTs.ZCGrnntEgTOKZdITtdptDPSiYsuz())
			{
				throw new Exception("Custom Platform is not set.");
			}
			try
			{
				return DYXEicTUvpxnVFlTbwIfiujTNpTs.YDIrRsFjIHjnZjDZXkaWvaZcvrth().GetPlatformMap(DYXEicTUvpxnVFlTbwIfiujTNpTs.XSbLyONHNwqeYxvuTBVWMKHSndSv(), Guid);
			}
			catch (Exception msg)
			{
				Logger.LogError(msg);
				return null;
			}
		case InputPlatform.InternalDriver:
			return internalDriver;
		case InputPlatform.SDL2:
			throw new NotImplementedException();
		case InputPlatform.SDL2Windows:
			return sdl2_Windows;
		case InputPlatform.SDL2OSX:
			return sdl2_OSX;
		case InputPlatform.SDL2Linux:
			return sdl2_Linux;
		case InputPlatform.Unknown:
		case InputPlatform.Steam:
			throw new NotImplementedException();
		default:
			throw new NotImplementedException();
		}
	}
}
