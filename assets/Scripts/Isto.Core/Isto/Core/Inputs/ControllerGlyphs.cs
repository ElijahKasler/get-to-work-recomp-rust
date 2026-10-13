using System;
using System.Collections.Generic;
using System.Linq;
using Rewired;
using Rewired.Data.Mapping;
using UnityEngine;

namespace Isto.Core.Inputs;

public class ControllerGlyphs : MonoBehaviour
{
	[Serializable]
	private class ControllerEntry
	{
		public string name;

		public HardwareJoystickMap joystick;

		public List<HardwareJoystickMap> alternateJoysticks;

		public GlyphEntry[] glyphs;

		public Sprite GetGlyph(int elementIdentifierId, AxisRange axisRange)
		{
			if (glyphs == null)
			{
				return null;
			}
			for (int i = 0; i < glyphs.Length; i++)
			{
				if (glyphs[i] != null && glyphs[i].elementIdentifierId == elementIdentifierId)
				{
					return glyphs[i].GetGlyph(axisRange);
				}
			}
			return null;
		}
	}

	[Serializable]
	private class GlyphEntry
	{
		public int elementIdentifierId;

		public Sprite glyph;

		public Sprite glyphPos;

		public Sprite glyphNeg;

		public Sprite GetGlyph(AxisRange axisRange)
		{
			switch (axisRange)
			{
			case AxisRange.Full:
				return glyph;
			case AxisRange.Positive:
				if (!(glyphPos != null))
				{
					return glyph;
				}
				return glyphPos;
			case AxisRange.Negative:
				if (!(glyphNeg != null))
				{
					return glyph;
				}
				return glyphNeg;
			default:
				return null;
			}
		}
	}

	[SerializeField]
	private ControllerEntry[] controllers;

	[SerializeField]
	private Sprite defaultButtonGlyph;

	[SerializeField]
	private GlyphEntry[] keyboardMapping;

	[SerializeField]
	private GlyphEntry[] mouseMapping;

	public Sprite GetDefaultControllerGlyph()
	{
		return defaultButtonGlyph;
	}

	public Sprite GetGlyph(string action, Controls.InputDevice device)
	{
		InputAction action2 = ReInput.mapping.GetAction(action.ToString());
		return GetGlyphForInputAction(action2, device);
	}

	public Sprite GetGlyph(int actionId, Controls.InputDevice device)
	{
		InputAction action = ReInput.mapping.GetAction(actionId);
		return GetGlyphForInputAction(action, device);
	}

	private Sprite GetGlyphForInputAction(InputAction inputAction, Controls.InputDevice device)
	{
		if (inputAction != null)
		{
			Player player = ReInput.players.GetPlayer(0);
			Controller activeController = GetActiveController(device, player);
			if (activeController == null || inputAction == null)
			{
				return null;
			}
			switch (device)
			{
			case Controls.InputDevice.Joystick:
				return GetSpriteForController(activeController, inputAction.id, player);
			case Controls.InputDevice.Keyboard:
			{
				Sprite spriteForController2 = GetSpriteForController(activeController, inputAction.id, player);
				if (spriteForController2 == null)
				{
					spriteForController2 = GetSpriteForController(GetActiveController(Controls.InputDevice.Mouse, player), inputAction.id, player);
				}
				return spriteForController2;
			}
			case Controls.InputDevice.Mouse:
			{
				Sprite spriteForController = GetSpriteForController(activeController, inputAction.id, player);
				if (spriteForController == null)
				{
					spriteForController = GetSpriteForController(GetActiveController(Controls.InputDevice.Keyboard, player), inputAction.id, player);
				}
				return spriteForController;
			}
			}
		}
		return null;
	}

	private Sprite GetSpriteForController(Controller controller, int actionId, Player p)
	{
		ActionElementMap firstElementMapWithAction = p.controllers.maps.GetFirstElementMapWithAction(controller, actionId, skipDisabledMaps: true);
		if (firstElementMapWithAction == null)
		{
			firstElementMapWithAction = p.controllers.maps.GetFirstElementMapWithAction(controller, actionId, skipDisabledMaps: false);
		}
		if (firstElementMapWithAction == null)
		{
			return null;
		}
		switch (controller.type)
		{
		case ControllerType.Keyboard:
			return GetKeyboardGlyph(firstElementMapWithAction.elementIdentifierId);
		case ControllerType.Mouse:
			return GetMouseGlyph(firstElementMapWithAction.elementIdentifierId);
		case ControllerType.Joystick:
			return GetJoystickGlyph((controller as Joystick).hardwareTypeGuid, firstElementMapWithAction.elementIdentifierId, firstElementMapWithAction.axisRange);
		default:
			Debug.LogError("Unknown Controller type used in ControllerGlyphs.");
			return null;
		}
	}

	private Controller GetActiveController(Controls.InputDevice device, Player p)
	{
		Controller controller = null;
		if (p == null)
		{
			return null;
		}
		switch (device)
		{
		case Controls.InputDevice.Joystick:
			controller = p.controllers.GetController(ControllerType.Joystick, 0);
			break;
		case Controls.InputDevice.Keyboard:
			controller = p.controllers.GetController(ControllerType.Keyboard, 0);
			break;
		case Controls.InputDevice.Mouse:
			controller = p.controllers.GetController(ControllerType.Mouse, 0);
			break;
		}
		if (controller == null)
		{
			controller = p.controllers.Keyboard;
		}
		return controller;
	}

	public Sprite GetJoystickGlyph(Guid joystickGuid, int elementIdentifierId, AxisRange axisRange)
	{
		if (controllers == null)
		{
			return null;
		}
		ControllerEntry controllerEntry = controllers.Where((ControllerEntry x) => x.alternateJoysticks.Where((HardwareJoystickMap y) => y.Guid == joystickGuid).FirstOrDefault() != null).FirstOrDefault();
		if (controllerEntry == null)
		{
			controllerEntry = controllers[0];
		}
		if (controllerEntry != null)
		{
			return controllerEntry.GetGlyph(elementIdentifierId, axisRange);
		}
		for (int num = 0; num < controllers.Length; num++)
		{
			if (controllers[num] != null && !(controllers[num].joystick == null) && !(controllers[num].joystick.Guid != joystickGuid))
			{
				return controllers[num].GetGlyph(elementIdentifierId, axisRange);
			}
		}
		return null;
	}

	public Sprite GetMouseGlyph(int elementIdentifierId)
	{
		if (mouseMapping == null)
		{
			return null;
		}
		for (int i = 0; i < mouseMapping.Length; i++)
		{
			if (mouseMapping[i] != null && mouseMapping[i].elementIdentifierId == elementIdentifierId)
			{
				return mouseMapping[i].glyph;
			}
		}
		return null;
	}

	public Sprite GetKeyboardGlyph(int elementIdentifierId)
	{
		if (keyboardMapping == null)
		{
			return null;
		}
		for (int i = 0; i < keyboardMapping.Length; i++)
		{
			if (keyboardMapping[i] != null && keyboardMapping[i].elementIdentifierId == elementIdentifierId)
			{
				return keyboardMapping[i].glyph;
			}
		}
		return null;
	}
}
