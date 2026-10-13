using System;
using System.Collections.Generic;
using Rewired.UI;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired;

public sealed class PlayerMouse : PlayerController, IPlayerMouse, IPlayerController, IMouseInputSource
{
	public new sealed class Definition : PlayerController.Definition
	{
		public bool defaultToCenter = true;

		public bool clampToMovementArea = true;

		public ScreenRect movementArea = aTGDkphtUdjgAGeizTlsfTcslRnFb;

		public MovementAreaUnit movementAreaUnit;

		public float pointerSpeed = 1f;

		public bool useHardwarePointerPosition = true;

		internal Definition()
		{
		}
	}

	public new static class Factory
	{
		public static PlayerMouse Create()
		{
			return jKpQdoIOSoXAdSTnZotwSKjoeDcFA(3, 3);
		}

		private static PlayerMouse jKpQdoIOSoXAdSTnZotwSKjoeDcFA(int P_0, int P_1)
		{
			if (P_0 < 0)
			{
				P_0 = 0;
			}
			if (P_1 < 0)
			{
				P_1 = 0;
			}
			List<Element.Definition> list = new List<Element.Definition>(P_0 + P_1);
			if (P_1 >= 1)
			{
				list.Add(new MouseAxis2D.Definition
				{
					name = "Movement",
					xAxis = new MouseAxis.Definition
					{
						name = "Horizontal"
					},
					yAxis = new MouseAxis.Definition
					{
						name = "Vertical"
					}
				});
			}
			if (P_1 >= 3)
			{
				list.Add(new MouseWheel.Definition
				{
					name = "Wheel",
					xAxis = new MouseWheelAxis.Definition
					{
						name = "Wheel Horizontal"
					},
					yAxis = new MouseWheelAxis.Definition
					{
						name = "Wheel Vertical"
					}
				});
			}
			for (int i = 4; i < P_1; i++)
			{
				list.Add(new Axis.Definition
				{
					coordinateMode = AxisCoordinateMode.Relative
				});
			}
			if (P_0 >= 1)
			{
				list.Add(new Button.Definition
				{
					name = "Left Button"
				});
			}
			if (P_0 >= 2)
			{
				list.Add(new Button.Definition
				{
					name = "Right Button"
				});
			}
			if (P_0 >= 3)
			{
				list.Add(new Button.Definition
				{
					name = "Middle Button"
				});
			}
			for (int j = 3; j < P_0; j++)
			{
				list.Add(new Button.Definition());
			}
			return new PlayerMouse(new Definition
			{
				elements = list
			});
		}

		public static PlayerMouse Create(Definition definition)
		{
			return new PlayerMouse(definition);
		}
	}

	public enum MovementAreaUnit
	{
		Screen = 0,
		Pixel = 1
	}

	[Serializable]
	private sealed class KmJWGtZsSAQEBKNICvlsLYdahJCI
	{
		public static readonly KmJWGtZsSAQEBKNICvlsLYdahJCI _003C_003E9 = new KmJWGtZsSAQEBKNICvlsLYdahJCI();

		public static Predicate<Axis> _003C_003E9__18_0;

		public static Predicate<Axis> _003C_003E9__18_1;

		internal bool YvhlYudcwQgDsBmUikzVKYTqGkGI(Axis P_0)
		{
			if ((object)P_0.GetType() == typeof(MouseWheelAxis))
			{
				return !P_0.fSqIDQHhZGMpJRLPhXuRcyqmMlwD();
			}
			return false;
		}

		internal bool fjKgigsREDuIyplbHFMsjVpqOIlNA(Axis P_0)
		{
			if ((object)P_0.GetType() == typeof(MouseWheelAxis))
			{
				return !P_0.fSqIDQHhZGMpJRLPhXuRcyqmMlwD();
			}
			return false;
		}
	}

	internal const bool DjZcygfzasXiFxouBQnamlgSkKdgb = true;

	internal const float wpWNVgEIfBslbkGrLEBNILeemdDJA = 1f;

	internal const bool sUQOMjkmbiCBnBQzWrnDzgBATGlL = true;

	internal const bool AjLValwVmWfxvaibEScyQaAiUjiT = true;

	internal const MovementAreaUnit iWIBoMjNvvoBAiqSuNHACFzVEATYA = MovementAreaUnit.Screen;

	internal static readonly ScreenRect aTGDkphtUdjgAGeizTlsfTcslRnFb = new ScreenRect(0f, 0f, 1f, 1f);

	private const int nsUpmplHRUdHHCMILsYtrIFpwWjq = 3;

	private const int QyEEDPDRzgpXXhRBaVghCNZKRqPtA = 3;

	internal const string ulOAXZFHGgUmgoKWfPTDgjKallTqc = "Movement";

	internal const string VPjsLmLENxwtxQIvBdjXapGiQIaP = "Horizontal";

	internal const string rTWhbrLDkDngCLLpJukoNfkAnYMk = "Vertical";

	internal const string NaNQVugQQfjEPaEVaeXCcaFYfGVu = "Wheel";

	internal const string iZVPKNTEFtNZQkmoMRwrMFDFzJB = "Wheel Horizontal";

	internal const string kQjelZBTDLdMypWfwdMCDXJZLGQTA = "Wheel Vertical";

	internal const string mwNCteGySWJgPIxQLbOsWedWkWfLA = "Left Button";

	internal const string FoxFtiFfbPvNREQCbnFawxurEzKb = "Right Button";

	internal const string IjlbOnVhtVdVsVMKgXPVCijCicv = "Middle Button";

	private readonly int JfPeWffPLIiNgMeLaoOGVpzIZxlu = -1;

	private readonly int evAwBnldnVaxRdlaEatzYwLSEMSX = -1;

	private readonly int xrbpbveKMkHYmukqhBSSMEeVxtjf = -1;

	private readonly int TgwradSvCdmdhlwCcjaeHIzwYphi = -1;

	private readonly int TdWAyIIKvPQBrUjTpdprOzvcoCeO = -1;

	private readonly int xefdSuKWYyJILjEpypiegUBvosAl = -1;

	private bool MEOSDLUavpmsRdjFJlmGOAidlcfO;

	private Vector2 tlyAiaSoXFTBxbvcPomFZLTTesU;

	private Vector2 yqEsWSqJNIdlDWqYNlEMWawcbhNbA;

	private Vector2 ZJeARywffcLslFsuJlCTmdsZCVKM;

	private Vector2 bTYbnOiHqvZzPDLvSaMKRbQrXIKT;

	private Vector2 jyiGduNOMyrANtMxptfwohRvRiZJ;

	private float TWzvBeyPsLyuvXvGicAlcuxzlxnL;

	private bool tYNPfRQsGLohPjfepobkVkfckUVN;

	private Action<Vector2> rEwlbOVGlEUUXcnwemEeAnATdSTHA;

	private bool RtzmNtdjRmlMrMcacLhzMxmlEvHp;

	private ScreenRect iZWjwEUBPVzrYtpwswUIpYwfelWl;

	private bool TEGEiLbncxjMuLOXKJWomivHNCyab;

	private MovementAreaUnit PNqCeTzmYxRvJwKFZjnRApQXjoDqA;

	bool IPlayerMouse.defaultToCenter
	{
		get
		{
			return get_defaultToCenter();
		}
		set
		{
			set_defaultToCenter(value);
		}
	}

	public bool clampToMovementArea
	{
		get
		{
			return TEGEiLbncxjMuLOXKJWomivHNCyab;
		}
		set
		{
			TEGEiLbncxjMuLOXKJWomivHNCyab = value;
		}
	}

	ScreenRect IPlayerMouse.movementArea
	{
		get
		{
			return get_movementArea();
		}
		set
		{
			set_movementArea(value);
		}
	}

	MovementAreaUnit IPlayerMouse.movementAreaUnit
	{
		get
		{
			return get_movementAreaUnit();
		}
		set
		{
			set_movementAreaUnit(value);
		}
	}

	Vector2 IPlayerMouse.screenPosition
	{
		get
		{
			return get_screenPosition();
		}
		set
		{
			set_screenPosition(value);
		}
	}

	Vector2 IPlayerMouse.screenPositionPrev => get_screenPositionPrev();

	Vector2 IPlayerMouse.screenPositionDelta => get_screenPositionDelta();

	MouseAxis IPlayerMouse.xAxis => get_xAxis();

	MouseAxis IPlayerMouse.yAxis => get_yAxis();

	MouseWheel IPlayerMouse.wheel => get_wheel();

	Button IPlayerMouse.leftButton => get_leftButton();

	Button IPlayerMouse.rightButton => get_rightButton();

	Button IPlayerMouse.middleButton => get_middleButton();

	float IPlayerMouse.pointerSpeed
	{
		get
		{
			return get_pointerSpeed();
		}
		set
		{
			set_pointerSpeed(value);
		}
	}

	bool IPlayerMouse.useHardwarePointerPosition
	{
		get
		{
			return get_useHardwarePointerPosition();
		}
		set
		{
			set_useHardwarePointerPosition(value);
		}
	}

	bool IMouseInputSource.enabled => get_enabled();

	Vector2 IMouseInputSource.screenPosition => ZJeARywffcLslFsuJlCTmdsZCVKM;

	Vector2 IMouseInputSource.screenPositionDelta => jyiGduNOMyrANtMxptfwohRvRiZJ;

	Vector2 IMouseInputSource.wheelDelta
	{
		get
		{
			if (get_wheel() == null)
			{
				return Vector2.zero;
			}
			return get_wheel().value;
		}
	}

	bool IMouseInputSource.locked => false;

	event Action<Vector2> IPlayerMouse.ScreenPositionChangedEvent
	{
		add
		{
			add_ScreenPositionChangedEvent(value);
		}
		remove
		{
			remove_ScreenPositionChangedEvent(value);
		}
	}

	private PlayerMouse(Definition P_0)
		: base(P_0)
	{
		RtzmNtdjRmlMrMcacLhzMxmlEvHp = P_0.defaultToCenter;
		TEGEiLbncxjMuLOXKJWomivHNCyab = P_0.clampToMovementArea;
		iZWjwEUBPVzrYtpwswUIpYwfelWl = P_0.movementArea;
		PNqCeTzmYxRvJwKFZjnRApQXjoDqA = P_0.movementAreaUnit;
		TWzvBeyPsLyuvXvGicAlcuxzlxnL = P_0.pointerSpeed;
		tYNPfRQsGLohPjfepobkVkfckUVN = P_0.useHardwarePointerPosition;
		int elementCount = get_elementCount();
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < elementCount; i++)
		{
			if (num < 2 && (object)get_elements()[i].GetType() == typeof(MouseAxis))
			{
				if (num == 0)
				{
					evAwBnldnVaxRdlaEatzYwLSEMSX = get_axes().IndexOf((MouseAxis)get_elements()[i]);
				}
				else
				{
					xrbpbveKMkHYmukqhBSSMEeVxtjf = get_axes().IndexOf((MouseAxis)get_elements()[i]);
				}
				num++;
			}
			else if (JfPeWffPLIiNgMeLaoOGVpzIZxlu < 0 && get_elements()[i] is MouseWheel)
			{
				JfPeWffPLIiNgMeLaoOGVpzIZxlu = i;
			}
			else if (num2 < 3 && (object)get_elements()[i].GetType() == typeof(Button))
			{
				switch (num2)
				{
				case 0:
					TgwradSvCdmdhlwCcjaeHIzwYphi = get_buttons().IndexOf((Button)get_elements()[i]);
					break;
				case 1:
					TdWAyIIKvPQBrUjTpdprOzvcoCeO = get_buttons().IndexOf((Button)get_elements()[i]);
					break;
				case 2:
					xefdSuKWYyJILjEpypiegUBvosAl = get_buttons().IndexOf((Button)get_elements()[i]);
					break;
				}
				num2++;
			}
		}
		if (JfPeWffPLIiNgMeLaoOGVpzIZxlu < 0)
		{
			int num3 = PlayerController.McDGpjfIdQQFasPJDBxhyAroeuIN(get_axes(), KmJWGtZsSAQEBKNICvlsLYdahJCI._003C_003E9.YvhlYudcwQgDsBmUikzVKYTqGkGI, 1);
			int num4 = PlayerController.McDGpjfIdQQFasPJDBxhyAroeuIN(get_axes(), KmJWGtZsSAQEBKNICvlsLYdahJCI._003C_003E9.fjKgigsREDuIyplbHFMsjVpqOIlNA, 2);
			if (num3 >= 0 || num4 >= 0)
			{
				MouseWheel mouseWheel = new MouseWheel(this, new MouseWheel.Definition
				{
					name = "Wheel"
				});
				WFVvjEUIofLQZdyJNKQXfSzJFyOt(mouseWheel);
				JfPeWffPLIiNgMeLaoOGVpzIZxlu = get_elements().Count - 1;
				if (num3 < 0 || num4 < 0)
				{
					Element element = new MouseWheelAxis(this, new MouseWheelAxis.Definition
					{
						name = "Wheel Horizontal",
						coordinateMode = AxisCoordinateMode.Relative
					});
					WFVvjEUIofLQZdyJNKQXfSzJFyOt(element);
					mouseWheel.GvZOHfwBoYuZWkguYLfaVlGLZPX(element);
					mouseWheel.GvZOHfwBoYuZWkguYLfaVlGLZPX((num3 < 0) ? get_axes()[num4] : get_axes()[num3]);
				}
				else
				{
					mouseWheel.GvZOHfwBoYuZWkguYLfaVlGLZPX(get_axes()[num3]);
					mouseWheel.GvZOHfwBoYuZWkguYLfaVlGLZPX(get_axes()[num4]);
				}
			}
		}
		if (RtzmNtdjRmlMrMcacLhzMxmlEvHp)
		{
			ScreenRect screenRect = yNccKTiHIFTVZmGHMxbxaYZUZGGhA();
			ZJeARywffcLslFsuJlCTmdsZCVKM = new Vector2(screenRect.center.x, screenRect.center.y);
		}
		else
		{
			ZJeARywffcLslFsuJlCTmdsZCVKM = Vector2.zero;
		}
	}

	public bool get_defaultToCenter()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return false;
		}
		return RtzmNtdjRmlMrMcacLhzMxmlEvHp;
	}

	public void set_defaultToCenter(bool value)
	{
		RtzmNtdjRmlMrMcacLhzMxmlEvHp = value;
	}

	public ScreenRect get_movementArea()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return default;
		}
		return iZWjwEUBPVzrYtpwswUIpYwfelWl;
	}

	public void set_movementArea(ScreenRect value)
	{
		iZWjwEUBPVzrYtpwswUIpYwfelWl = value;
	}

	public MovementAreaUnit get_movementAreaUnit()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return MovementAreaUnit.Screen;
		}
		return PNqCeTzmYxRvJwKFZjnRApQXjoDqA;
	}

	public void set_movementAreaUnit(MovementAreaUnit value)
	{
		PNqCeTzmYxRvJwKFZjnRApQXjoDqA = value;
	}

	public Vector2 get_screenPosition()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return Vector2.zero;
		}
		if (!get_enabled())
		{
			return Vector2.zero;
		}
		return ZJeARywffcLslFsuJlCTmdsZCVKM;
	}

	public void set_screenPosition(Vector2 value)
	{
		JVbEOgYpaTnKoyvFoHdLQkKMabgX(value);
	}

	public Vector2 get_screenPositionPrev()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return Vector2.zero;
		}
		if (!get_enabled())
		{
			return Vector2.zero;
		}
		return bTYbnOiHqvZzPDLvSaMKRbQrXIKT;
	}

	public Vector2 get_screenPositionDelta()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return Vector2.zero;
		}
		if (!get_enabled())
		{
			return Vector2.zero;
		}
		return jyiGduNOMyrANtMxptfwohRvRiZJ;
	}

	public MouseAxis get_xAxis()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return null;
		}
		if (evAwBnldnVaxRdlaEatzYwLSEMSX < 0)
		{
			return null;
		}
		return (MouseAxis)get_axes()[evAwBnldnVaxRdlaEatzYwLSEMSX];
	}

	public MouseAxis get_yAxis()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return null;
		}
		if (xrbpbveKMkHYmukqhBSSMEeVxtjf < 0)
		{
			return null;
		}
		return (MouseAxis)get_axes()[xrbpbveKMkHYmukqhBSSMEeVxtjf];
	}

	public MouseWheel get_wheel()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return null;
		}
		if (JfPeWffPLIiNgMeLaoOGVpzIZxlu < 0)
		{
			return null;
		}
		return (MouseWheel)get_elements()[JfPeWffPLIiNgMeLaoOGVpzIZxlu];
	}

	public Button get_leftButton()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return null;
		}
		if (TgwradSvCdmdhlwCcjaeHIzwYphi < 0)
		{
			return null;
		}
		return get_buttons()[TgwradSvCdmdhlwCcjaeHIzwYphi];
	}

	public Button get_rightButton()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return null;
		}
		if (TdWAyIIKvPQBrUjTpdprOzvcoCeO < 0)
		{
			return null;
		}
		return get_buttons()[TdWAyIIKvPQBrUjTpdprOzvcoCeO];
	}

	public Button get_middleButton()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return null;
		}
		if (xefdSuKWYyJILjEpypiegUBvosAl < 0)
		{
			return null;
		}
		return get_buttons()[xefdSuKWYyJILjEpypiegUBvosAl];
	}

	public float get_pointerSpeed()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return 0f;
		}
		return TWzvBeyPsLyuvXvGicAlcuxzlxnL;
	}

	public void set_pointerSpeed(float value)
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return;
		}
		if (value < 0f)
		{
			value = 0f;
		}
		TWzvBeyPsLyuvXvGicAlcuxzlxnL = value;
	}

	public bool get_useHardwarePointerPosition()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return false;
		}
		return tYNPfRQsGLohPjfepobkVkfckUVN;
	}

	public void set_useHardwarePointerPosition(bool value)
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return;
		}
		tYNPfRQsGLohPjfepobkVkfckUVN = value;
		if (!value)
		{
			XCDhKMyMLZNWixVHzKfPQFYJVHoP();
		}
	}

	public void add_ScreenPositionChangedEvent(Action<Vector2> value)
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
		}
		else
		{
			rEwlbOVGlEUUXcnwemEeAnATdSTHA = (Action<Vector2>)Delegate.Combine(rEwlbOVGlEUUXcnwemEeAnATdSTHA, value);
		}
	}

	public void remove_ScreenPositionChangedEvent(Action<Vector2> value)
	{
		rEwlbOVGlEUUXcnwemEeAnATdSTHA = (Action<Vector2>)Delegate.Remove(rEwlbOVGlEUUXcnwemEeAnATdSTHA, value);
	}

	protected override bool Update(UpdateLoopType updateLoop)
	{
		if (!base.Update(updateLoop))
		{
			return false;
		}
		if (updateLoop != UpdateLoopType.Update)
		{
			return false;
		}
		Player player;
		if (tYNPfRQsGLohPjfepobkVkfckUVN && (player = rIhuugtItTLJgKpKWPAdTXMiwyAt()) != null)
		{
			if (!player.controllers.hasMouse)
			{
				XCDhKMyMLZNWixVHzKfPQFYJVHoP();
			}
			else
			{
				tlyAiaSoXFTBxbvcPomFZLTTesU = ReInput.controllers.Mouse.screenPosition;
				if (tlyAiaSoXFTBxbvcPomFZLTTesU.x != yqEsWSqJNIdlDWqYNlEMWawcbhNbA.x || tlyAiaSoXFTBxbvcPomFZLTTesU.y != yqEsWSqJNIdlDWqYNlEMWawcbhNbA.y)
				{
					ZJeARywffcLslFsuJlCTmdsZCVKM.x = tlyAiaSoXFTBxbvcPomFZLTTesU.x;
					ZJeARywffcLslFsuJlCTmdsZCVKM.y = tlyAiaSoXFTBxbvcPomFZLTTesU.y;
				}
				yqEsWSqJNIdlDWqYNlEMWawcbhNbA.x = tlyAiaSoXFTBxbvcPomFZLTTesU.x;
				yqEsWSqJNIdlDWqYNlEMWawcbhNbA.y = tlyAiaSoXFTBxbvcPomFZLTTesU.y;
			}
		}
		if (evAwBnldnVaxRdlaEatzYwLSEMSX >= 0)
		{
			ZJeARywffcLslFsuJlCTmdsZCVKM.x = WUFYbCAMiadLHtiNHWpYXVPCXpTl(get_axes()[evAwBnldnVaxRdlaEatzYwLSEMSX], ZJeARywffcLslFsuJlCTmdsZCVKM.x, TWzvBeyPsLyuvXvGicAlcuxzlxnL);
		}
		if (xrbpbveKMkHYmukqhBSSMEeVxtjf >= 0)
		{
			ZJeARywffcLslFsuJlCTmdsZCVKM.y = WUFYbCAMiadLHtiNHWpYXVPCXpTl(get_axes()[xrbpbveKMkHYmukqhBSSMEeVxtjf], ZJeARywffcLslFsuJlCTmdsZCVKM.y, TWzvBeyPsLyuvXvGicAlcuxzlxnL);
		}
		JVbEOgYpaTnKoyvFoHdLQkKMabgX(ZJeARywffcLslFsuJlCTmdsZCVKM);
		jyiGduNOMyrANtMxptfwohRvRiZJ.x = ZJeARywffcLslFsuJlCTmdsZCVKM.x - bTYbnOiHqvZzPDLvSaMKRbQrXIKT.x;
		jyiGduNOMyrANtMxptfwohRvRiZJ.y = ZJeARywffcLslFsuJlCTmdsZCVKM.y - bTYbnOiHqvZzPDLvSaMKRbQrXIKT.y;
		MEOSDLUavpmsRdjFJlmGOAidlcfO = ZJeARywffcLslFsuJlCTmdsZCVKM.x != bTYbnOiHqvZzPDLvSaMKRbQrXIKT.x || ZJeARywffcLslFsuJlCTmdsZCVKM.y != bTYbnOiHqvZzPDLvSaMKRbQrXIKT.y;
		bTYbnOiHqvZzPDLvSaMKRbQrXIKT.x = ZJeARywffcLslFsuJlCTmdsZCVKM.x;
		bTYbnOiHqvZzPDLvSaMKRbQrXIKT.y = ZJeARywffcLslFsuJlCTmdsZCVKM.y;
		return true;
	}

	protected override void UpdateFinished()
	{
		base.UpdateFinished();
		if (MEOSDLUavpmsRdjFJlmGOAidlcfO && rEwlbOVGlEUUXcnwemEeAnATdSTHA != null)
		{
			try
			{
				rEwlbOVGlEUUXcnwemEeAnATdSTHA(ZJeARywffcLslFsuJlCTmdsZCVKM);
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception occurred in a listener of ScreenPositionChangedEvent. This means an exception was thrown by your code.\n" + ex);
			}
			MEOSDLUavpmsRdjFJlmGOAidlcfO = false;
		}
	}

	protected override void ClearVars()
	{
		base.ClearVars();
		bTYbnOiHqvZzPDLvSaMKRbQrXIKT = ZJeARywffcLslFsuJlCTmdsZCVKM;
		jyiGduNOMyrANtMxptfwohRvRiZJ = Vector2.zero;
		XCDhKMyMLZNWixVHzKfPQFYJVHoP();
		MEOSDLUavpmsRdjFJlmGOAidlcfO = false;
	}

	private void JVbEOgYpaTnKoyvFoHdLQkKMabgX(Vector2 P_0)
	{
		if (!TEGEiLbncxjMuLOXKJWomivHNCyab)
		{
			ZJeARywffcLslFsuJlCTmdsZCVKM = P_0;
			return;
		}
		if (PNqCeTzmYxRvJwKFZjnRApQXjoDqA == MovementAreaUnit.Screen)
		{
			float num = Screen.width;
			float num2 = Screen.height;
			ZJeARywffcLslFsuJlCTmdsZCVKM.x = Mathf.Clamp(P_0.x, iZWjwEUBPVzrYtpwswUIpYwfelWl.xMin * num, iZWjwEUBPVzrYtpwswUIpYwfelWl.xMax * num);
			ZJeARywffcLslFsuJlCTmdsZCVKM.y = Mathf.Clamp(P_0.y, iZWjwEUBPVzrYtpwswUIpYwfelWl.yMin * num2, iZWjwEUBPVzrYtpwswUIpYwfelWl.yMax * num2);
			return;
		}
		if (PNqCeTzmYxRvJwKFZjnRApQXjoDqA == MovementAreaUnit.Pixel)
		{
			ZJeARywffcLslFsuJlCTmdsZCVKM.x = Mathf.Clamp(P_0.x, iZWjwEUBPVzrYtpwswUIpYwfelWl.xMin, iZWjwEUBPVzrYtpwswUIpYwfelWl.xMax);
			ZJeARywffcLslFsuJlCTmdsZCVKM.y = Mathf.Clamp(P_0.y, iZWjwEUBPVzrYtpwswUIpYwfelWl.yMin, iZWjwEUBPVzrYtpwswUIpYwfelWl.yMax);
			return;
		}
		throw new NotImplementedException();
	}

	private ScreenRect yNccKTiHIFTVZmGHMxbxaYZUZGGhA()
	{
		if (PNqCeTzmYxRvJwKFZjnRApQXjoDqA == MovementAreaUnit.Screen)
		{
			return new ScreenRect(iZWjwEUBPVzrYtpwswUIpYwfelWl.xMin * (float)Screen.width, iZWjwEUBPVzrYtpwswUIpYwfelWl.yMin * (float)Screen.height, iZWjwEUBPVzrYtpwswUIpYwfelWl.width * (float)Screen.width, iZWjwEUBPVzrYtpwswUIpYwfelWl.height * (float)Screen.height);
		}
		if (PNqCeTzmYxRvJwKFZjnRApQXjoDqA == MovementAreaUnit.Pixel)
		{
			return iZWjwEUBPVzrYtpwswUIpYwfelWl;
		}
		throw new NotImplementedException();
	}

	private void XCDhKMyMLZNWixVHzKfPQFYJVHoP()
	{
		tlyAiaSoXFTBxbvcPomFZLTTesU = Vector2.zero;
		yqEsWSqJNIdlDWqYNlEMWawcbhNbA = Vector2.zero;
	}

	private static float WUFYbCAMiadLHtiNHWpYXVPCXpTl(Axis P_0, float P_1, float P_2)
	{
		if (P_0 == null)
		{
			return P_1;
		}
		return P_0.coordinateMode switch
		{
			AxisCoordinateMode.Absolute => P_0.value, 
			AxisCoordinateMode.Relative => P_1 + P_0.value * P_2, 
			_ => throw new NotImplementedException(), 
		};
	}

	bool IMouseInputSource.GetButtonDown(int button)
	{
		return GetButtonDown(button);
	}

	bool IMouseInputSource.GetButtonUp(int button)
	{
		return GetButtonUp(button);
	}

	bool IMouseInputSource.GetButton(int button)
	{
		return GetButton(button);
	}
}
