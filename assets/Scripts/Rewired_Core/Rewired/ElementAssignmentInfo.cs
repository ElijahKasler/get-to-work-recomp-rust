using System;
using UnityEngine;

namespace Rewired;

public sealed class ElementAssignmentInfo
{
	private readonly ControllerMap lRqHpjBLkvyfSvfoliRpzseJCoecA;

	private readonly ControllerElementType QIlorVfiHYIhXIPXxBswcIYVPZhcb;

	private readonly int lhEmQJWgDDAEJDjIqFMZCqlApOkHA;

	private readonly int LEOJJwMjARBpgxcEmVfcvQwigOPeA;

	private readonly AxisRange WseBqGnjRBRpjzVnvZgFjonrRedd;

	private readonly KeyCode EVLqxzOuedjHSNcTJHxUKCUbSteB;

	private readonly ModifierKeyFlags mntKZdjHyXkvVrXxuQKGxUHqfqsI;

	private readonly int IsTFdKWIaQxokJKBqBbKGlJUSCgW;

	private readonly Pole tvFhVEFJaFXcLBFFfeYfwOERwnbD;

	private readonly bool JRKNtRWGtFACDYQGeoEpnxdSiHCY;

	public Player player
	{
		get
		{
			if (!ReInput.isReady)
			{
				return null;
			}
			if (lRqHpjBLkvyfSvfoliRpzseJCoecA == null)
			{
				return null;
			}
			return lRqHpjBLkvyfSvfoliRpzseJCoecA.player;
		}
	}

	public InputAction action
	{
		get
		{
			if (!ReInput.isReady)
			{
				return null;
			}
			return ReInput.mapping.GetAction(IsTFdKWIaQxokJKBqBbKGlJUSCgW);
		}
	}

	public Controller controller
	{
		get
		{
			if (!ReInput.isReady)
			{
				return null;
			}
			if (lRqHpjBLkvyfSvfoliRpzseJCoecA == null)
			{
				return null;
			}
			return ReInput.controllers.GetController(lRqHpjBLkvyfSvfoliRpzseJCoecA.controllerType, lRqHpjBLkvyfSvfoliRpzseJCoecA.controllerId);
		}
	}

	public ControllerType controllerType
	{
		get
		{
			if (!ReInput.isReady || lRqHpjBLkvyfSvfoliRpzseJCoecA == null)
			{
				return ControllerType.Keyboard;
			}
			return lRqHpjBLkvyfSvfoliRpzseJCoecA.controllerType;
		}
	}

	public int controllerId
	{
		get
		{
			if (!ReInput.isReady || lRqHpjBLkvyfSvfoliRpzseJCoecA == null)
			{
				return -1;
			}
			return lRqHpjBLkvyfSvfoliRpzseJCoecA.controllerId;
		}
	}

	public ControllerMap controllerMap => lRqHpjBLkvyfSvfoliRpzseJCoecA;

	public ControllerElementIdentifier elementIdentifier
	{
		get
		{
			if (controller == null)
			{
				return null;
			}
			return controller.GetElementIdentifierById(LEOJJwMjARBpgxcEmVfcvQwigOPeA);
		}
	}

	public ActionElementMap elementMap
	{
		get
		{
			if (lRqHpjBLkvyfSvfoliRpzseJCoecA == null)
			{
				return null;
			}
			return lRqHpjBLkvyfSvfoliRpzseJCoecA.GetElementMap(lhEmQJWgDDAEJDjIqFMZCqlApOkHA);
		}
	}

	public ControllerElementType elementType => QIlorVfiHYIhXIPXxBswcIYVPZhcb;

	public Pole axisContribution => tvFhVEFJaFXcLBFFfeYfwOERwnbD;

	public AxisRange axisRange => WseBqGnjRBRpjzVnvZgFjonrRedd;

	public bool invert => JRKNtRWGtFACDYQGeoEpnxdSiHCY;

	public KeyCode keyCode => EVLqxzOuedjHSNcTJHxUKCUbSteB;

	public ModifierKeyFlags modifierKeyFlags => mntKZdjHyXkvVrXxuQKGxUHqfqsI;

	public string elementDisplayName
	{
		get
		{
			if (lRqHpjBLkvyfSvfoliRpzseJCoecA == null)
			{
				return string.Empty;
			}
			if (controllerType == ControllerType.Keyboard)
			{
				return Keyboard.GetKeyName(keyCode, modifierKeyFlags);
			}
			Controller controller = this.controller;
			if (controller == null)
			{
				return string.Empty;
			}
			ControllerElementIdentifier elementIdentifierById = controller.GetElementIdentifierById(LEOJJwMjARBpgxcEmVfcvQwigOPeA);
			if (elementIdentifierById == null)
			{
				return string.Empty;
			}
			if (QIlorVfiHYIhXIPXxBswcIYVPZhcb == ControllerElementType.Axis)
			{
				if (WseBqGnjRBRpjzVnvZgFjonrRedd == AxisRange.Full)
				{
					return elementIdentifierById.get_name();
				}
				if (WseBqGnjRBRpjzVnvZgFjonrRedd == AxisRange.Positive)
				{
					return elementIdentifierById.get_positiveName();
				}
				if (WseBqGnjRBRpjzVnvZgFjonrRedd == AxisRange.Negative)
				{
					return elementIdentifierById.get_negativeName();
				}
			}
			return elementIdentifierById.get_name();
		}
	}

	internal ElementAssignmentInfo(ControllerMap P_0, ElementAssignment P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("controllerMap");
		}
		IsTFdKWIaQxokJKBqBbKGlJUSCgW = P_1.actionId;
		lRqHpjBLkvyfSvfoliRpzseJCoecA = P_0;
		lhEmQJWgDDAEJDjIqFMZCqlApOkHA = P_1.elementMapId;
		LEOJJwMjARBpgxcEmVfcvQwigOPeA = P_1.elementIdentifierId;
		EVLqxzOuedjHSNcTJHxUKCUbSteB = P_1.keyboardKey;
		mntKZdjHyXkvVrXxuQKGxUHqfqsI = P_1.modifierKeyFlags;
		JRKNtRWGtFACDYQGeoEpnxdSiHCY = P_1.invert;
		QIlorVfiHYIhXIPXxBswcIYVPZhcb = IyPmashUlRgIygDiHFyDZHZmauql.GHSLwwyYQJsHZwAGrasLDiACdKRib(P_1.type);
		tvFhVEFJaFXcLBFFfeYfwOERwnbD = P_1.axisContribution;
		WseBqGnjRBRpjzVnvZgFjonrRedd = P_1.axisRange;
		if (lRqHpjBLkvyfSvfoliRpzseJCoecA.controllerType == ControllerType.Keyboard)
		{
			Keyboard.rtOODgVFayQeFFUGzfSlQrZxLkrX(ref LEOJJwMjARBpgxcEmVfcvQwigOPeA, ref EVLqxzOuedjHSNcTJHxUKCUbSteB);
		}
	}
}
