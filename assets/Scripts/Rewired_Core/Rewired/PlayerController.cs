using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired;

public class PlayerController : IPlayerController
{
	public class Definition
	{
		public bool enabled = true;

		public int playerId = -1;

		public ICollection<Element.Definition> elements;
	}

	public static class Factory
	{
		public static PlayerController Create(Definition definition)
		{
			return new PlayerController(definition);
		}
	}

	public class Axis : ElementWithSource
	{
		public new class Definition : ElementWithSource.Definition
		{
			public AxisCoordinateMode coordinateMode;

			public float absoluteToRelativeSensitivity;

			public Definition()
			{
				coordinateMode = AxisCoordinateMode.Absolute;
				absoluteToRelativeSensitivity = 1f;
			}

			internal virtual Element IvpBkMdsEKOyiGBVvzQtHLjengDIA(PlayerController P_0)
			{
				return new Axis(P_0, this);
			}
		}

		internal const float SCMTKRUCXKiDHvUdMvKQXUCOwre = 1f;

		[CustomObfuscation(rename = false)]
		internal const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Absolute;

		private float kEKOiPsiGjlqQccLvQfQYJaPCDdDA = 1f;

		private AxisCoordinateMode ZcsVceMShbufyEeEXuhYnRLVAGfP;

		public float absoluteToRelativeSensitivity
		{
			get
			{
				return kEKOiPsiGjlqQccLvQfQYJaPCDdDA;
			}
			set
			{
				if (value < 0f)
				{
					value = 0f;
				}
				kEKOiPsiGjlqQccLvQfQYJaPCDdDA = value;
			}
		}

		public AxisCoordinateMode coordinateMode => ZcsVceMShbufyEeEXuhYnRLVAGfP;

		public virtual float value
		{
			get
			{
				if (!base.selfAndParentEnabled || base.player == null)
				{
					return 0f;
				}
				float num = base.player.GetAxis(base.actionId);
				switch (base.player.GetAxisCoordinateMode(base.actionId))
				{
				case AxisCoordinateMode.Relative:
					if (ZcsVceMShbufyEeEXuhYnRLVAGfP == AxisCoordinateMode.Absolute)
					{
						return 0f;
					}
					break;
				case AxisCoordinateMode.Absolute:
					if (ZcsVceMShbufyEeEXuhYnRLVAGfP == AxisCoordinateMode.Relative)
					{
						num *= (float)ReInput.unscaledDeltaTime * kEKOiPsiGjlqQccLvQfQYJaPCDdDA;
					}
					break;
				}
				return num;
			}
		}

		public virtual float valueRaw
		{
			get
			{
				if (!base.selfAndParentEnabled || base.player == null)
				{
					return 0f;
				}
				return base.player.GetAxisRaw(base.actionId);
			}
		}

		internal Axis(PlayerController P_0, Definition P_1)
			: base(P_0, P_1)
		{
			kEKOiPsiGjlqQccLvQfQYJaPCDdDA = P_1.absoluteToRelativeSensitivity;
			ZcsVceMShbufyEeEXuhYnRLVAGfP = P_1.coordinateMode;
		}
	}

	public class MouseAxis : Axis
	{
		public new class Definition : Axis.Definition
		{
			public Definition()
			{
				coordinateMode = AxisCoordinateMode.Relative;
				absoluteToRelativeSensitivity = 600f;
			}

			internal virtual Element UgUqTQqcQUuyyfOLfvuXAslhByeE(PlayerController P_0)
			{
				return new MouseAxis(P_0, this);
			}
		}

		[CustomObfuscation(rename = false)]
		internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

		[CustomObfuscation(rename = false)]
		internal const float defaultAbsoluteToRelativeSensitivity = 600f;

		float Axis.value => get_value();

		internal MouseAxis(PlayerController P_0, Definition P_1)
			: base(P_0, P_1)
		{
		}

		public virtual float get_value()
		{
			float num = base.value;
			if (num == 0f)
			{
				return 0f;
			}
			if (base.coordinateMode == AxisCoordinateMode.Relative && base.player.GetAxisCoordinateMode(base.actionId) == AxisCoordinateMode.Absolute)
			{
				num *= (float)Screen.currentResolution.width / 1920f;
			}
			return num;
		}
	}

	public class Axis2D : CompoundElement
	{
		public new class Definition : CompoundElement.Definition
		{
			private Axis.Definition ainwKOFzYrkrRFeLMPZSkSVnCVxA;

			private Axis.Definition PBrpgwbAclvFijnnIKPaorQVyIcp;

			public Axis.Definition xAxis
			{
				get
				{
					return ainwKOFzYrkrRFeLMPZSkSVnCVxA;
				}
				set
				{
					ainwKOFzYrkrRFeLMPZSkSVnCVxA = value;
				}
			}

			public Axis.Definition yAxis
			{
				get
				{
					return PBrpgwbAclvFijnnIKPaorQVyIcp;
				}
				set
				{
					PBrpgwbAclvFijnnIKPaorQVyIcp = value;
				}
			}

			internal virtual Element GFqafoCvMXfhXdqujItPWbaNzqpJB(PlayerController P_0)
			{
				return new Axis2D(P_0, this);
			}
		}

		internal const int ZPPYdyUGdPSduzXPqzZuEKlJJXre = 0;

		internal const int OGNCiBeLQnQKWLXOXNbbWlQdUlvOA = 1;

		internal const int DFucvJBYCBiFyrTpLhuwpRaxADQEA = 2;

		public Axis xAxis => cgagxSQiRkAVVrEfDcQWtCwpgnXX<Axis>(0);

		public Axis yAxis => cgagxSQiRkAVVrEfDcQWtCwpgnXX<Axis>(1);

		public virtual Vector2 value => new Vector2(cgagxSQiRkAVVrEfDcQWtCwpgnXX<Axis>(0).value, cgagxSQiRkAVVrEfDcQWtCwpgnXX<Axis>(1).value);

		public virtual Vector2 valueRaw => new Vector2(cgagxSQiRkAVVrEfDcQWtCwpgnXX<Axis>(0).valueRaw, cgagxSQiRkAVVrEfDcQWtCwpgnXX<Axis>(1).valueRaw);

		internal Axis2D(PlayerController P_0, Definition P_1, Element.Definition[] P_2)
			: base(P_0, P_1, P_2)
		{
		}

		internal Axis2D(PlayerController P_0, Definition P_1)
			: base(P_0, P_1, (P_1 == null) ? null : new Element.Definition[2]
			{
				(P_1.xAxis != null) ? P_1.xAxis : new Axis.Definition(),
				(P_1.yAxis != null) ? P_1.yAxis : new Axis.Definition()
			})
		{
		}
	}

	public sealed class MouseAxis2D : Axis2D
	{
		public new class Definition : Axis2D.Definition
		{
			public new MouseAxis.Definition xAxis
			{
				get
				{
					return base.xAxis as MouseAxis.Definition;
				}
				set
				{
					base.xAxis = value;
				}
			}

			public new MouseAxis.Definition yAxis
			{
				get
				{
					return base.yAxis as MouseAxis.Definition;
				}
				set
				{
					base.yAxis = value;
				}
			}

			internal virtual Element GeyxnnOAlBjjDLfSkCmibMnkvDqL(PlayerController P_0)
			{
				return new MouseAxis2D(P_0, this);
			}
		}

		public new MouseAxis xAxis => cgagxSQiRkAVVrEfDcQWtCwpgnXX<MouseAxis>(0);

		public new MouseAxis yAxis => cgagxSQiRkAVVrEfDcQWtCwpgnXX<MouseAxis>(1);

		internal MouseAxis2D(PlayerController P_0, Definition P_1)
			: base(P_0, P_1, (P_1 == null) ? null : new Element.Definition[2]
			{
				(P_1.xAxis != null) ? P_1.xAxis : new MouseAxis.Definition(),
				(P_1.yAxis != null) ? P_1.yAxis : new MouseAxis.Definition()
			})
		{
		}
	}

	public sealed class Button : ElementWithSource
	{
		public new class Definition : ElementWithSource.Definition
		{
			internal virtual Element rOlTQyMAKHFCvBUwbwFZwIfCXjLx(PlayerController P_0)
			{
				return new Button(P_0, this);
			}
		}

		public bool value
		{
			get
			{
				if (!base.selfAndParentEnabled || base.player == null)
				{
					return false;
				}
				return base.player.GetButton(base.actionId);
			}
		}

		public bool valuePrev
		{
			get
			{
				if (!base.selfAndParentEnabled || base.player == null)
				{
					return false;
				}
				return base.player.GetButtonPrev(base.actionId);
			}
		}

		public bool justPressed
		{
			get
			{
				if (!base.selfAndParentEnabled || base.player == null)
				{
					return false;
				}
				return base.player.GetButtonDown(base.actionId);
			}
		}

		public bool justReleased
		{
			get
			{
				if (!base.selfAndParentEnabled || base.player == null)
				{
					return false;
				}
				return base.player.GetButtonUp(base.actionId);
			}
		}

		internal Button(PlayerController P_0, Definition P_1)
			: base(P_0, P_1)
		{
		}
	}

	public abstract class CompoundElement : Element
	{
		public new abstract class Definition : Element.Definition
		{
			public Definition()
			{
			}
		}

		private readonly List<Element> iGeZilGWBUdvCclsHADLmoWJHFjM;

		internal int oBRnfJFBATiYXUYFatdYNsqQYNUC => EOSwaUviGHtmuATNoLjYxkcdVATG();

		internal CompoundElement(PlayerController P_0, Definition P_1, Element.Definition[] P_2)
			: base(P_0, P_1)
		{
			iGeZilGWBUdvCclsHADLmoWJHFjM = new List<Element>();
			if (P_2 == null)
			{
				return;
			}
			for (int i = 0; i < P_2.Length; i++)
			{
				if (P_2[i] != null)
				{
					GvZOHfwBoYuZWkguYLfaVlGLZPX(P_2[i].AFUSiUWMFexMVsEefKaxMWqcvMdo(P_0));
				}
			}
		}

		internal int EOSwaUviGHtmuATNoLjYxkcdVATG()
		{
			return iGeZilGWBUdvCclsHADLmoWJHFjM.Count;
		}

		internal _0001 cgagxSQiRkAVVrEfDcQWtCwpgnXX<_0001>(int P_0) where _0001 : Element
		{
			if ((uint)P_0 >= (uint)iGeZilGWBUdvCclsHADLmoWJHFjM.Count)
			{
				return null;
			}
			return iGeZilGWBUdvCclsHADLmoWJHFjM[P_0] as _0001;
		}

		internal void zHpgRaJTqMfdzNatnTtWpyglVklQ(List<Element> P_0)
		{
			for (int i = 0; i < iGeZilGWBUdvCclsHADLmoWJHFjM.Count; i++)
			{
				if (iGeZilGWBUdvCclsHADLmoWJHFjM[i] is CompoundElement)
				{
					(iGeZilGWBUdvCclsHADLmoWJHFjM[i] as CompoundElement).zHpgRaJTqMfdzNatnTtWpyglVklQ(P_0);
				}
				else
				{
					P_0.Add(iGeZilGWBUdvCclsHADLmoWJHFjM[i]);
				}
			}
		}

		internal void GvZOHfwBoYuZWkguYLfaVlGLZPX(Element P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("element");
			}
			iGeZilGWBUdvCclsHADLmoWJHFjM.Add(P_0);
			P_0.SSIBcZklPMwueSqcxEXnUIwWQewj(true);
		}
	}

	public abstract class Element
	{
		[CustomObfuscation(rename = false)]
		internal enum Type
		{
			[CustomObfuscation(rename = false)]
			Button = 0,
			[CustomObfuscation(rename = false)]
			Axis = 1,
			[CustomObfuscation(rename = false)]
			MouseAxis = 2,
			[CustomObfuscation(rename = false)]
			MouseWheelAxis = 3,
			[CustomObfuscation(rename = false)]
			Axis2D = 100,
			[CustomObfuscation(rename = false)]
			MouseAxis2D = 101,
			[CustomObfuscation(rename = false)]
			MouseWheel = 102
		}

		[CustomObfuscation(rename = false)]
		internal enum TypeWithSource
		{
			[CustomObfuscation(rename = false)]
			Button = 0,
			[CustomObfuscation(rename = false)]
			Axis = 1,
			[CustomObfuscation(rename = false)]
			MouseAxis = 2,
			[CustomObfuscation(rename = false)]
			MouseWheelAxis = 3
		}

		[CustomObfuscation(rename = false)]
		internal enum CompoundTypes
		{
			[CustomObfuscation(rename = false)]
			Axis2D = 100,
			[CustomObfuscation(rename = false)]
			MouseAxis2D = 101,
			[CustomObfuscation(rename = false)]
			MouseWheel = 102
		}

		public abstract class Definition
		{
			public bool enabled;

			public string name;

			public Definition()
			{
				enabled = true;
				name = null;
			}

			internal abstract Element AFUSiUWMFexMVsEefKaxMWqcvMdo(PlayerController P_0);
		}

		internal struct fOPfPXjYYHIczGaqOjFsokyEoiZGA(ControllerElementType P_0, int P_1, float P_2)
		{
			public ControllerElementType jUorCjZvJKbZwOozCNSefQwvCETDA = P_0;

			public int YprjNDpfNtCbLEZYCEngMNLBdFhi = P_1;

			public float IRLeSJiphwwLCTvDJtvgvLrGtBMA = P_2;
		}

		[CustomObfuscation(rename = false)]
		internal const bool defaultEnabled = true;

		private readonly PlayerController UYKKvfKjgwhXNHHXLLtxvkQErNLvA;

		private bool zlaUYvGuqhpavRlbNghMoTstxjcY;

		private bool meQMLHdSVtnrnEvcFDYiTQyOLTeg = true;

		private string jxPKUkfbDMRRWcRNQNxgjMiWADJc;

		private static int[] aOKdMeDIzadueYzFCgCgyZgPbGoV;

		private static int[] orNDmnuAXDguHhMyXrNqPkSxFbkg;

		protected Player player
		{
			get
			{
				if (!ReInput.isReady)
				{
					return null;
				}
				return ReInput.players.GetPlayer(UYKKvfKjgwhXNHHXLLtxvkQErNLvA.xthRtuyMkyjJkDZJQDlXKOZETmWQ);
			}
		}

		protected bool selfAndParentEnabled
		{
			get
			{
				if (meQMLHdSVtnrnEvcFDYiTQyOLTeg)
				{
					return UYKKvfKjgwhXNHHXLLtxvkQErNLvA.XYJAwErdDcAgRupFtGcwlDriyUcV;
				}
				return false;
			}
		}

		internal bool cSqnktYrFRmMzJlcICQEBZwmOCZd
		{
			get
			{
				return fSqIDQHhZGMpJRLPhXuRcyqmMlwD();
			}
			set
			{
				SSIBcZklPMwueSqcxEXnUIwWQewj(flag);
			}
		}

		public bool enabled
		{
			get
			{
				return meQMLHdSVtnrnEvcFDYiTQyOLTeg;
			}
			set
			{
				if (meQMLHdSVtnrnEvcFDYiTQyOLTeg != value)
				{
					meQMLHdSVtnrnEvcFDYiTQyOLTeg = value;
					EnabledStateChanged(value);
				}
			}
		}

		public string name
		{
			get
			{
				return jxPKUkfbDMRRWcRNQNxgjMiWADJc;
			}
			set
			{
				jxPKUkfbDMRRWcRNQNxgjMiWADJc = value;
			}
		}

		internal Element(PlayerController P_0, Definition P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("parent");
			}
			if (P_1 == null)
			{
				throw new ArgumentNullException("definition");
			}
			UYKKvfKjgwhXNHHXLLtxvkQErNLvA = P_0;
			meQMLHdSVtnrnEvcFDYiTQyOLTeg = P_1.enabled;
			jxPKUkfbDMRRWcRNQNxgjMiWADJc = P_1.name;
		}

		internal bool fSqIDQHhZGMpJRLPhXuRcyqmMlwD()
		{
			return zlaUYvGuqhpavRlbNghMoTstxjcY;
		}

		internal void SSIBcZklPMwueSqcxEXnUIwWQewj(bool P_0)
		{
			zlaUYvGuqhpavRlbNghMoTstxjcY = true;
		}

		internal virtual void ebIXUyFsxVTvOFpBvwLueKFqjAHt()
		{
		}

		protected virtual void EnabledStateChanged(bool state)
		{
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsTypeWithSource(Type type)
		{
			if (aOKdMeDIzadueYzFCgCgyZgPbGoV == null)
			{
				aOKdMeDIzadueYzFCgCgyZgPbGoV = (int[])Enum.GetValues(typeof(TypeWithSource));
			}
			return ArrayTools.Contains(aOKdMeDIzadueYzFCgCgyZgPbGoV, (int)type);
		}

		[CustomObfuscation(rename = false)]
		internal static bool IsCompoundType(Type type)
		{
			if (orNDmnuAXDguHhMyXrNqPkSxFbkg == null)
			{
				orNDmnuAXDguHhMyXrNqPkSxFbkg = (int[])Enum.GetValues(typeof(CompoundTypes));
			}
			return ArrayTools.Contains(orNDmnuAXDguHhMyXrNqPkSxFbkg, (int)type);
		}

		[CustomObfuscation(rename = false)]
		internal static int GetMaxElementCount(Type type)
		{
			if (IsTypeWithSource(type))
			{
				return 1;
			}
			if (IsCompoundType(type))
			{
				return type switch
				{
					Type.Axis2D => 2, 
					Type.MouseAxis2D => 2, 
					Type.MouseWheel => 2, 
					_ => throw new NotImplementedException(), 
				};
			}
			throw new NotImplementedException();
		}

		[CustomObfuscation(rename = false)]
		internal static string GetElementTitle(Type type, int index)
		{
			if (index < 0 || index > GetMaxElementCount(type))
			{
				return null;
			}
			if (IsTypeWithSource(type))
			{
				return null;
			}
			if (IsCompoundType(type))
			{
				if ((uint)(type - 100) <= 2u)
				{
					if (index != 0)
					{
						return "Y Axis";
					}
					return "X Axis";
				}
				throw new NotImplementedException();
			}
			throw new NotImplementedException();
		}

		[CustomObfuscation(rename = false)]
		internal static Definition CreateDefinition(Type type)
		{
			return type switch
			{
				Type.Axis => new Axis.Definition(), 
				Type.Button => new Button.Definition(), 
				Type.MouseAxis => new MouseAxis.Definition(), 
				Type.MouseWheelAxis => new MouseWheelAxis.Definition(), 
				Type.Axis2D => new Axis2D.Definition(), 
				Type.MouseAxis2D => new MouseAxis2D.Definition(), 
				Type.MouseWheel => new MouseWheel.Definition(), 
				_ => throw new NotImplementedException(), 
			};
		}
	}

	public abstract class ElementWithSource : Element
	{
		public new abstract class Definition : Element.Definition
		{
			private int LUEjJUimPEiutbIbcpBVCKCBFIKTB;

			public int actionId
			{
				get
				{
					return LUEjJUimPEiutbIbcpBVCKCBFIKTB;
				}
				set
				{
					LUEjJUimPEiutbIbcpBVCKCBFIKTB = value;
				}
			}

			public string actionName
			{
				get
				{
					if (!ReInput.isReady || LUEjJUimPEiutbIbcpBVCKCBFIKTB < 0)
					{
						return null;
					}
					return ReInput.mapping.GetAction(LUEjJUimPEiutbIbcpBVCKCBFIKTB)?.name;
				}
				set
				{
					if (!ReInput.isReady)
					{
						Logger.LogError("You cannot set an Action Name because Rewired has not been intialized.");
						return;
					}
					InputAction action = ReInput.mapping.GetAction(value);
					if (action == null)
					{
						LUEjJUimPEiutbIbcpBVCKCBFIKTB = -1;
					}
					else
					{
						LUEjJUimPEiutbIbcpBVCKCBFIKTB = action.id;
					}
				}
			}

			public Definition()
			{
				LUEjJUimPEiutbIbcpBVCKCBFIKTB = -1;
			}
		}

		[CustomObfuscation(rename = false)]
		internal const int defaultActionId = -1;

		private int oLLgzpdajWxHUaDoBDHyxJsYcnej = -1;

		public int actionId
		{
			get
			{
				return oLLgzpdajWxHUaDoBDHyxJsYcnej;
			}
			set
			{
				oLLgzpdajWxHUaDoBDHyxJsYcnej = value;
			}
		}

		public string actionName
		{
			get
			{
				if (!ReInput.isReady || oLLgzpdajWxHUaDoBDHyxJsYcnej < 0)
				{
					return null;
				}
				return ReInput.mapping.GetAction(oLLgzpdajWxHUaDoBDHyxJsYcnej)?.name;
			}
			set
			{
				if (ReInput.isReady)
				{
					InputAction action = ReInput.mapping.GetAction(value);
					if (action == null)
					{
						oLLgzpdajWxHUaDoBDHyxJsYcnej = -1;
					}
					else
					{
						oLLgzpdajWxHUaDoBDHyxJsYcnej = action.id;
					}
				}
			}
		}

		internal ElementWithSource(PlayerController P_0, Definition P_1)
			: base(P_0, P_1)
		{
			oLLgzpdajWxHUaDoBDHyxJsYcnej = P_1.actionId;
		}
	}

	public sealed class MouseWheel : Axis2D
	{
		public new class Definition : Axis2D.Definition
		{
			public new MouseWheelAxis.Definition xAxis
			{
				get
				{
					return base.xAxis as MouseWheelAxis.Definition;
				}
				set
				{
					base.xAxis = value;
				}
			}

			public new MouseWheelAxis.Definition yAxis
			{
				get
				{
					return base.yAxis as MouseWheelAxis.Definition;
				}
				set
				{
					base.yAxis = value;
				}
			}

			internal virtual Element MYuZWBjZnAlAEpgWBpOkIESoFyYC(PlayerController P_0)
			{
				return new MouseWheel(P_0, this);
			}
		}

		public new MouseWheelAxis xAxis => cgagxSQiRkAVVrEfDcQWtCwpgnXX<MouseWheelAxis>(0);

		public new MouseWheelAxis yAxis => cgagxSQiRkAVVrEfDcQWtCwpgnXX<MouseWheelAxis>(1);

		internal MouseWheel(PlayerController P_0, Definition P_1)
			: base(P_0, P_1, (P_1 == null) ? null : new Element.Definition[2]
			{
				(P_1.xAxis != null) ? P_1.xAxis : new MouseWheelAxis.Definition(),
				(P_1.yAxis != null) ? P_1.yAxis : new MouseWheelAxis.Definition()
			})
		{
		}
	}

	public sealed class MouseWheelAxis : Axis
	{
		public new class Definition : Axis.Definition
		{
			public float repeatRate;

			public Definition()
			{
				coordinateMode = AxisCoordinateMode.Relative;
				repeatRate = 4f;
			}

			internal virtual Element sLgxrAPJBMaguuoEaXxgvRZrihHE(PlayerController P_0)
			{
				return new MouseWheelAxis(P_0, this);
			}
		}

		[CustomObfuscation(rename = false)]
		internal const float defaultRepeatRate = 4f;

		[CustomObfuscation(rename = false)]
		internal new const AxisCoordinateMode defaultAxisCoordinateMode = AxisCoordinateMode.Relative;

		private const float RxPJcIeHwWcRRJvlltjJPfcZuurB = 0.01f;

		private float SdunqSpBpEDJtXJBdCUpaDjYRLSG = 0.25f;

		private double jsCZWMawBNbszBJamOCHBWEQNmMc;

		private float waSGbGFIZGgMWgXfckJPsFrnvdzwb;

		public float repeatRate
		{
			get
			{
				if (SdunqSpBpEDJtXJBdCUpaDjYRLSG == 0f)
				{
					return 0f;
				}
				return 1f / SdunqSpBpEDJtXJBdCUpaDjYRLSG;
			}
			set
			{
				if (value < 0f)
				{
					value = 0f;
				}
				if (value == 0f)
				{
					SdunqSpBpEDJtXJBdCUpaDjYRLSG = 0f;
				}
				else
				{
					SdunqSpBpEDJtXJBdCUpaDjYRLSG = 1f / value;
				}
			}
		}

		float Axis.value => get_value();

		internal MouseWheelAxis(PlayerController P_0, Definition P_1)
			: base(P_0, P_1)
		{
			repeatRate = P_1.repeatRate;
		}

		public float get_value()
		{
			if (!base.selfAndParentEnabled)
			{
				return 0f;
			}
			return waSGbGFIZGgMWgXfckJPsFrnvdzwb;
		}

		internal void cDkrQAhmfyEFJvShhEeDdrWLKikyA()
		{
			base.ebIXUyFsxVTvOFpBvwLueKFqjAHt();
			if (base.selfAndParentEnabled)
			{
				waSGbGFIZGgMWgXfckJPsFrnvdzwb = oyvCkAhtVBetqNhlZrBwtmGfWCbt();
			}
		}

		protected override void EnabledStateChanged(bool state)
		{
			base.EnabledStateChanged(state);
			if (!state)
			{
				TqJyTHZPHPUFMUPfKkLDbacraaFk();
			}
		}

		private float oyvCkAhtVBetqNhlZrBwtmGfWCbt()
		{
			if (base.player == null)
			{
				return 0f;
			}
			float num = base.player.GetAxis(base.actionId);
			switch (base.player.GetAxisCoordinateMode(base.actionId))
			{
			case AxisCoordinateMode.Absolute:
			{
				bool flag = false;
				if (base.player.GetButtonDown(base.actionId))
				{
					flag = true;
					num = 1f;
				}
				else if (base.player.GetNegativeButtonDown(base.actionId))
				{
					flag = true;
					num = -1f;
				}
				if (!flag && ReInput.unscaledTime < jsCZWMawBNbszBJamOCHBWEQNmMc + (double)SdunqSpBpEDJtXJBdCUpaDjYRLSG)
				{
					return 0f;
				}
				if (Mathf.Abs(num) <= 0.01f)
				{
					return 0f;
				}
				num = Mathf.Sign(num);
				num *= base.absoluteToRelativeSensitivity;
				jsCZWMawBNbszBJamOCHBWEQNmMc = ReInput.unscaledTime;
				break;
			}
			}
			return num;
		}

		private void TqJyTHZPHPUFMUPfKkLDbacraaFk()
		{
			waSGbGFIZGgMWgXfckJPsFrnvdzwb = 0f;
			jsCZWMawBNbszBJamOCHBWEQNmMc = 0.0;
		}
	}

	internal readonly int eNRSgFNztYYGiquDIrzxcnCDCEtA;

	private bool XYJAwErdDcAgRupFtGcwlDriyUcV;

	private int xthRtuyMkyjJkDZJQDlXKOZETmWQ;

	private readonly AList<Element> YPGQghQqndHDpNWkNBlLtRaZPAcF;

	private readonly AList<Button> KFGHDYdIidqVXhGOoOpleambKdFv;

	private readonly AList<Axis> biaKgTMAmmhqKYXUOqaXDxJxcdBL;

	private readonly ReadOnlyCollection<Element> CCJgYThLsEJBYrPAjlFhBkRnzGDiA;

	private readonly ReadOnlyCollection<Button> MZPLJbdHfBVdzXjcubiyCtJNArHAb;

	private readonly ReadOnlyCollection<Axis> kwnbxmWBmfnJlvdnkFTeUbWlWlUm;

	private readonly List<Element.fOPfPXjYYHIczGaqOjFsokyEoiZGA> FGaAXoKDOJHBhJucAFFAmmmqZOHDA;

	private Action<int, bool> kZlBxfVXGERExsIHoieHBhFWHELKA;

	private Action<int, float> ZyGkXOJlBKIbMLTEGqRUbicCcNkn;

	private Action<bool> AoXgrEqIBDiAFimAmBixvUpDjPCbb;

	bool IPlayerController.enabled
	{
		get
		{
			return get_enabled();
		}
		set
		{
			set_enabled(value);
		}
	}

	int IPlayerController.playerId
	{
		get
		{
			return get_playerId();
		}
		set
		{
			set_playerId(value);
		}
	}

	IList<Button> IPlayerController.buttons => get_buttons();

	IList<Axis> IPlayerController.axes => get_axes();

	IList<Element> IPlayerController.elements => get_elements();

	int IPlayerController.buttonCount => get_buttonCount();

	int IPlayerController.axisCount => get_axisCount();

	int IPlayerController.elementCount => get_elementCount();

	internal Player eSXRTxfQxifjYpYLzQOFiYCfAtzj => rIhuugtItTLJgKpKWPAdTXMiwyAt();

	event Action<int, bool> IPlayerController.ButtonStateChangedEvent
	{
		add
		{
			add_ButtonStateChangedEvent(value);
		}
		remove
		{
			remove_ButtonStateChangedEvent(value);
		}
	}

	event Action<int, float> IPlayerController.AxisValueChangedEvent
	{
		add
		{
			add_AxisValueChangedEvent(value);
		}
		remove
		{
			remove_AxisValueChangedEvent(value);
		}
	}

	event Action<bool> IPlayerController.EnabledStateChangedEvent
	{
		add
		{
			add_EnabledStateChangedEvent(value);
		}
		remove
		{
			remove_EnabledStateChangedEvent(value);
		}
	}

	internal PlayerController(Definition P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("definition");
		}
		if (P_0.elements == null)
		{
			throw new ArgumentNullException("definition.elements");
		}
		eNRSgFNztYYGiquDIrzxcnCDCEtA = ReInput._id;
		xthRtuyMkyjJkDZJQDlXKOZETmWQ = P_0.playerId;
		XYJAwErdDcAgRupFtGcwlDriyUcV = P_0.enabled;
		List<Element> list = new List<Element>();
		List<Element> list2 = new List<Element>();
		List<Button> list3 = new List<Button>();
		List<Axis> list4 = new List<Axis>();
		foreach (Element.Definition element in P_0.elements)
		{
			uEdQgWmeoUBvvCICDMzPoaluhpdOA(element.AFUSiUWMFexMVsEefKaxMWqcvMdo(this), list, list2, list3, list4);
		}
		list.AddRange(list2);
		YPGQghQqndHDpNWkNBlLtRaZPAcF = new AList<Element>(list);
		KFGHDYdIidqVXhGOoOpleambKdFv = new AList<Button>(list3);
		biaKgTMAmmhqKYXUOqaXDxJxcdBL = new AList<Axis>(list4);
		CCJgYThLsEJBYrPAjlFhBkRnzGDiA = new ReadOnlyCollection<Element>(YPGQghQqndHDpNWkNBlLtRaZPAcF);
		MZPLJbdHfBVdzXjcubiyCtJNArHAb = new ReadOnlyCollection<Button>(KFGHDYdIidqVXhGOoOpleambKdFv);
		kwnbxmWBmfnJlvdnkFTeUbWlWlUm = new ReadOnlyCollection<Axis>(biaKgTMAmmhqKYXUOqaXDxJxcdBL);
		FGaAXoKDOJHBhJucAFFAmmmqZOHDA = new List<Element.fOPfPXjYYHIczGaqOjFsokyEoiZGA>();
		ReInput.UpdateEndedEvent += EHTMnDzqvvSGOhInieMekUzhuudOA;
	}

	~PlayerController()
	{
		ReInput.UpdateEndedEvent -= EHTMnDzqvvSGOhInieMekUzhuudOA;
	}

	public bool get_enabled()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return false;
		}
		return XYJAwErdDcAgRupFtGcwlDriyUcV;
	}

	public void set_enabled(bool value)
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
		}
		else
		{
			if (XYJAwErdDcAgRupFtGcwlDriyUcV == value)
			{
				return;
			}
			if (!value)
			{
				ClearVars();
			}
			XYJAwErdDcAgRupFtGcwlDriyUcV = value;
			for (int i = 0; i < YPGQghQqndHDpNWkNBlLtRaZPAcF._count; i++)
			{
				YPGQghQqndHDpNWkNBlLtRaZPAcF.get_Item(i).enabled = value;
			}
			if (AoXgrEqIBDiAFimAmBixvUpDjPCbb != null)
			{
				try
				{
					AoXgrEqIBDiAFimAmBixvUpDjPCbb(value);
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred in a listener of EnabledStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
				}
			}
		}
	}

	public int get_playerId()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return -1;
		}
		return xthRtuyMkyjJkDZJQDlXKOZETmWQ;
	}

	public void set_playerId(int value)
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
		}
		else if (xthRtuyMkyjJkDZJQDlXKOZETmWQ != value)
		{
			xthRtuyMkyjJkDZJQDlXKOZETmWQ = value;
			ClearVars();
		}
	}

	public IList<Button> get_buttons()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return null;
		}
		return MZPLJbdHfBVdzXjcubiyCtJNArHAb;
	}

	public IList<Axis> get_axes()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return null;
		}
		return kwnbxmWBmfnJlvdnkFTeUbWlWlUm;
	}

	public IList<Element> get_elements()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return null;
		}
		return CCJgYThLsEJBYrPAjlFhBkRnzGDiA;
	}

	public int get_buttonCount()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return 0;
		}
		if (KFGHDYdIidqVXhGOoOpleambKdFv == null)
		{
			return 0;
		}
		return KFGHDYdIidqVXhGOoOpleambKdFv._count;
	}

	public int get_axisCount()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return 0;
		}
		if (biaKgTMAmmhqKYXUOqaXDxJxcdBL == null)
		{
			return 0;
		}
		return biaKgTMAmmhqKYXUOqaXDxJxcdBL._count;
	}

	public int get_elementCount()
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return 0;
		}
		if (YPGQghQqndHDpNWkNBlLtRaZPAcF == null)
		{
			return 0;
		}
		return YPGQghQqndHDpNWkNBlLtRaZPAcF._count;
	}

	public void add_ButtonStateChangedEvent(Action<int, bool> value)
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
		}
		else
		{
			kZlBxfVXGERExsIHoieHBhFWHELKA = (Action<int, bool>)Delegate.Combine(kZlBxfVXGERExsIHoieHBhFWHELKA, value);
		}
	}

	public void remove_ButtonStateChangedEvent(Action<int, bool> value)
	{
		kZlBxfVXGERExsIHoieHBhFWHELKA = (Action<int, bool>)Delegate.Remove(kZlBxfVXGERExsIHoieHBhFWHELKA, value);
	}

	public void add_AxisValueChangedEvent(Action<int, float> value)
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
		}
		else
		{
			ZyGkXOJlBKIbMLTEGqRUbicCcNkn = (Action<int, float>)Delegate.Combine(ZyGkXOJlBKIbMLTEGqRUbicCcNkn, value);
		}
	}

	public void remove_AxisValueChangedEvent(Action<int, float> value)
	{
		ZyGkXOJlBKIbMLTEGqRUbicCcNkn = (Action<int, float>)Delegate.Remove(ZyGkXOJlBKIbMLTEGqRUbicCcNkn, value);
	}

	public void add_EnabledStateChangedEvent(Action<bool> value)
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
		}
		else
		{
			AoXgrEqIBDiAFimAmBixvUpDjPCbb = (Action<bool>)Delegate.Combine(AoXgrEqIBDiAFimAmBixvUpDjPCbb, value);
		}
	}

	public void remove_EnabledStateChangedEvent(Action<bool> value)
	{
		AoXgrEqIBDiAFimAmBixvUpDjPCbb = (Action<bool>)Delegate.Remove(AoXgrEqIBDiAFimAmBixvUpDjPCbb, value);
	}

	public bool GetButton(int index)
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return false;
		}
		if ((uint)index >= (uint)KFGHDYdIidqVXhGOoOpleambKdFv._count)
		{
			return false;
		}
		return KFGHDYdIidqVXhGOoOpleambKdFv.get_Item(index).value;
	}

	bool IPlayerController.GetButton(int index)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetButton
		return this.GetButton(index);
	}

	public bool GetButtonDown(int index)
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return false;
		}
		if ((uint)index >= (uint)KFGHDYdIidqVXhGOoOpleambKdFv._count)
		{
			return false;
		}
		return KFGHDYdIidqVXhGOoOpleambKdFv.get_Item(index).justPressed;
	}

	bool IPlayerController.GetButtonDown(int index)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetButtonDown
		return this.GetButtonDown(index);
	}

	public bool GetButtonUp(int index)
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return false;
		}
		if ((uint)index >= (uint)KFGHDYdIidqVXhGOoOpleambKdFv._count)
		{
			return false;
		}
		return KFGHDYdIidqVXhGOoOpleambKdFv.get_Item(index).justReleased;
	}

	bool IPlayerController.GetButtonUp(int index)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetButtonUp
		return this.GetButtonUp(index);
	}

	public float GetAxis(int index)
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return 0f;
		}
		if ((uint)index >= (uint)biaKgTMAmmhqKYXUOqaXDxJxcdBL._count)
		{
			return 0f;
		}
		return biaKgTMAmmhqKYXUOqaXDxJxcdBL.get_Item(index).value;
	}

	float IPlayerController.GetAxis(int index)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAxis
		return this.GetAxis(index);
	}

	public float GetAxisRaw(int index)
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return 0f;
		}
		if ((uint)index >= (uint)biaKgTMAmmhqKYXUOqaXDxJxcdBL._count)
		{
			return 0f;
		}
		return biaKgTMAmmhqKYXUOqaXDxJxcdBL.get_Item(index).valueRaw;
	}

	float IPlayerController.GetAxisRaw(int index)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAxisRaw
		return this.GetAxisRaw(index);
	}

	public Element GetElement(int index)
	{
		if (ReInput._id != eNRSgFNztYYGiquDIrzxcnCDCEtA)
		{
			ReInput.CheckInitialized(eNRSgFNztYYGiquDIrzxcnCDCEtA);
			return null;
		}
		if ((uint)index >= (uint)YPGQghQqndHDpNWkNBlLtRaZPAcF._count)
		{
			return null;
		}
		return YPGQghQqndHDpNWkNBlLtRaZPAcF.get_Item(index);
	}

	Element IPlayerController.GetElement(int index)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetElement
		return this.GetElement(index);
	}

	public T GetElement<T>(int index) where T : Element
	{
		return GetElement(index) as T;
	}

	T IPlayerController.GetElement<T>(int index)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetElement
		return this.GetElement<T>(index);
	}

	internal Player rIhuugtItTLJgKpKWPAdTXMiwyAt()
	{
		if (!ReInput.isReady)
		{
			return null;
		}
		return ReInput.players.GetPlayer(get_playerId());
	}

	private void EHTMnDzqvvSGOhInieMekUzhuudOA(UpdateLoopType P_0)
	{
		Update(P_0);
		UpdateFinished();
	}

	protected virtual bool Update(UpdateLoopType updateLoop)
	{
		if (!XYJAwErdDcAgRupFtGcwlDriyUcV)
		{
			return false;
		}
		bool flag = ZyGkXOJlBKIbMLTEGqRUbicCcNkn != null;
		bool flag2 = kZlBxfVXGERExsIHoieHBhFWHELKA != null;
		for (int i = 0; i < YPGQghQqndHDpNWkNBlLtRaZPAcF._count; i++)
		{
			float num = 0f;
			if (flag && YPGQghQqndHDpNWkNBlLtRaZPAcF.get_Item(i) is Axis)
			{
				Axis axis = YPGQghQqndHDpNWkNBlLtRaZPAcF.get_Item(i) as Axis;
				num = ((axis.coordinateMode != AxisCoordinateMode.Absolute) ? 0f : axis.value);
			}
			YPGQghQqndHDpNWkNBlLtRaZPAcF.get_Item(i).ebIXUyFsxVTvOFpBvwLueKFqjAHt();
			if (flag2 && YPGQghQqndHDpNWkNBlLtRaZPAcF.get_Item(i) is Button)
			{
				Button button = YPGQghQqndHDpNWkNBlLtRaZPAcF.get_Item(i) as Button;
				if (button.justPressed && button.value)
				{
					FGaAXoKDOJHBhJucAFFAmmmqZOHDA.Add(new Element.fOPfPXjYYHIczGaqOjFsokyEoiZGA(ControllerElementType.Button, i, 1f));
				}
				else if (button.justReleased && !button.value)
				{
					FGaAXoKDOJHBhJucAFFAmmmqZOHDA.Add(new Element.fOPfPXjYYHIczGaqOjFsokyEoiZGA(ControllerElementType.Button, i, 0f));
				}
			}
			else if (flag && YPGQghQqndHDpNWkNBlLtRaZPAcF.get_Item(i) is Axis)
			{
				FGaAXoKDOJHBhJucAFFAmmmqZOHDA.Add(new Element.fOPfPXjYYHIczGaqOjFsokyEoiZGA(ControllerElementType.Axis, i, (YPGQghQqndHDpNWkNBlLtRaZPAcF.get_Item(i) as Axis).value - num));
			}
		}
		return true;
	}

	protected virtual void UpdateFinished()
	{
		int count = FGaAXoKDOJHBhJucAFFAmmmqZOHDA.Count;
		if (count <= 0)
		{
			return;
		}
		for (int i = 0; i < count; i++)
		{
			Element.fOPfPXjYYHIczGaqOjFsokyEoiZGA fOPfPXjYYHIczGaqOjFsokyEoiZGA = FGaAXoKDOJHBhJucAFFAmmmqZOHDA[i];
			if (fOPfPXjYYHIczGaqOjFsokyEoiZGA.jUorCjZvJKbZwOozCNSefQwvCETDA == ControllerElementType.Button)
			{
				try
				{
					kZlBxfVXGERExsIHoieHBhFWHELKA(fOPfPXjYYHIczGaqOjFsokyEoiZGA.YprjNDpfNtCbLEZYCEngMNLBdFhi, fOPfPXjYYHIczGaqOjFsokyEoiZGA.IRLeSJiphwwLCTvDJtvgvLrGtBMA > 0f);
				}
				catch (Exception ex)
				{
					Logger.LogError("An exception occurred in a listener of ButtonStateChangedEvent. This means an exception was thrown by your code.\n" + ex);
				}
			}
			else if (fOPfPXjYYHIczGaqOjFsokyEoiZGA.jUorCjZvJKbZwOozCNSefQwvCETDA == ControllerElementType.Axis)
			{
				try
				{
					ZyGkXOJlBKIbMLTEGqRUbicCcNkn(fOPfPXjYYHIczGaqOjFsokyEoiZGA.YprjNDpfNtCbLEZYCEngMNLBdFhi, fOPfPXjYYHIczGaqOjFsokyEoiZGA.IRLeSJiphwwLCTvDJtvgvLrGtBMA);
				}
				catch (Exception ex2)
				{
					Logger.LogError("An exception occurred in a listener of AxisValueChangedEvent. This means an exception was thrown by your code.\n" + ex2);
				}
			}
		}
		FGaAXoKDOJHBhJucAFFAmmmqZOHDA.Clear();
	}

	protected virtual void ClearVars()
	{
		FGaAXoKDOJHBhJucAFFAmmmqZOHDA.Clear();
	}

	internal void WFVvjEUIofLQZdyJNKQXfSzJFyOt(Element P_0)
	{
		if (P_0 != null)
		{
			if (P_0 is Axis)
			{
				biaKgTMAmmhqKYXUOqaXDxJxcdBL.Add(P_0 as Axis);
			}
			else if (P_0 is Button)
			{
				KFGHDYdIidqVXhGOoOpleambKdFv.Add(P_0 as Button);
			}
			YPGQghQqndHDpNWkNBlLtRaZPAcF.Add(P_0);
		}
	}

	private void uEdQgWmeoUBvvCICDMzPoaluhpdOA(Element P_0, List<Element> P_1, List<Element> P_2, List<Button> P_3, List<Axis> P_4)
	{
		if (P_0 == null)
		{
			return;
		}
		P_0.GetType();
		if (P_0 is ElementWithSource)
		{
			if (P_0 is Button)
			{
				P_3.Add((Button)P_0);
			}
			else
			{
				if (!(P_0 is Axis))
				{
					Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
					return;
				}
				P_4.Add((Axis)P_0);
			}
			P_1.Add(P_0);
		}
		else if (P_0 is CompoundElement)
		{
			using (TempListPool.TList<Element> tList = TempListPool.GetTList<Element>())
			{
				List<Element> list = tList.list;
				(P_0 as CompoundElement).zHpgRaJTqMfdzNatnTtWpyglVklQ(list);
				for (int i = 0; i < list.Count; i++)
				{
					uEdQgWmeoUBvvCICDMzPoaluhpdOA(list[i], P_1, P_2, P_3, P_4);
				}
			}
			P_2.Add(P_0);
		}
		else
		{
			Logger.LogWarning("Unknown Element type encountered: " + P_0.GetType());
		}
	}

	internal static int McDGpjfIdQQFasPJDBxhyAroeuIN<_0001>(IList<_0001> P_0, Predicate<_0001> P_1, int P_2) where _0001 : Element
	{
		int num = 0;
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_1(P_0[i]))
			{
				num++;
			}
			if (num == P_2)
			{
				return i;
			}
		}
		return -1;
	}
}
