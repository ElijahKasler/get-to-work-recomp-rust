using System;
using System.Collections.Generic;
using System.Text;
using Rewired.Utils;
using UnityEngine;

namespace Rewired;

public sealed class InputMapper
{
	public class Context
	{
		private int XqgCeOaGnNmlXlUpZIvvXAQsKgBnA = -1;

		private ControllerMap aaHKkOyjYpDjegWUSJZXDTQhlBcaA;

		private ActionElementMap oSYgtZfMGqbtBoIjwycGREupXulrA;

		private AxisRange uNPLFICXKpyTOVXXKQFREiBVoRZF = AxisRange.Positive;

		private bool fiaXzTbcimoDIYAUrIxrPISIRsvX;

		public int actionId
		{
			get
			{
				return XqgCeOaGnNmlXlUpZIvvXAQsKgBnA;
			}
			set
			{
				if (!zuutgfQShHPJsyaIGsbSiorJcqXi())
				{
					XqgCeOaGnNmlXlUpZIvvXAQsKgBnA = value;
				}
			}
		}

		public string actionName
		{
			get
			{
				InputAction action = ReInput.mapping.GetAction(XqgCeOaGnNmlXlUpZIvvXAQsKgBnA);
				if (action == null)
				{
					return string.Empty;
				}
				return action.name;
			}
			set
			{
				if (!zuutgfQShHPJsyaIGsbSiorJcqXi())
				{
					InputAction action = ReInput.mapping.GetAction(value);
					if (action == null)
					{
						XqgCeOaGnNmlXlUpZIvvXAQsKgBnA = -1;
						Logger.LogError("The Action \"" + value + "\" is not a valid Action and cannot be used!");
					}
					else
					{
						XqgCeOaGnNmlXlUpZIvvXAQsKgBnA = action.id;
					}
				}
			}
		}

		public ControllerMap controllerMap
		{
			get
			{
				return aaHKkOyjYpDjegWUSJZXDTQhlBcaA;
			}
			set
			{
				if (!zuutgfQShHPJsyaIGsbSiorJcqXi())
				{
					aaHKkOyjYpDjegWUSJZXDTQhlBcaA = value;
				}
			}
		}

		public ActionElementMap actionElementMapToReplace
		{
			get
			{
				return oSYgtZfMGqbtBoIjwycGREupXulrA;
			}
			set
			{
				if (!zuutgfQShHPJsyaIGsbSiorJcqXi())
				{
					oSYgtZfMGqbtBoIjwycGREupXulrA = value;
				}
			}
		}

		public AxisRange actionRange
		{
			get
			{
				return uNPLFICXKpyTOVXXKQFREiBVoRZF;
			}
			set
			{
				if (!zuutgfQShHPJsyaIGsbSiorJcqXi())
				{
					uNPLFICXKpyTOVXXKQFREiBVoRZF = value;
				}
			}
		}

		public Context()
		{
		}

		private Context(Context P_0)
			: this()
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			Copy(P_0, this);
		}

		public Context Clone()
		{
			return new Context(this);
		}

		internal void NRaOJVPDVQWPXVwgpjuFfcLtlhce()
		{
			fiaXzTbcimoDIYAUrIxrPISIRsvX = true;
		}

		private bool zuutgfQShHPJsyaIGsbSiorJcqXi()
		{
			if (fiaXzTbcimoDIYAUrIxrPISIRsvX)
			{
				Logger.LogError("Context is read-only and cannot be modified after Input Mapper has been started.");
				return true;
			}
			return false;
		}

		public static void Copy(Context source, Context destination)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			destination.XqgCeOaGnNmlXlUpZIvvXAQsKgBnA = source.XqgCeOaGnNmlXlUpZIvvXAQsKgBnA;
			destination.aaHKkOyjYpDjegWUSJZXDTQhlBcaA = source.aaHKkOyjYpDjegWUSJZXDTQhlBcaA;
			destination.oSYgtZfMGqbtBoIjwycGREupXulrA = source.oSYgtZfMGqbtBoIjwycGREupXulrA;
			destination.uNPLFICXKpyTOVXXKQFREiBVoRZF = source.uNPLFICXKpyTOVXXKQFREiBVoRZF;
		}
	}

	public enum ConflictResponse
	{
		Cancel = 0,
		Replace = 1,
		Add = 2,
		Ignore = 3,
		Swap = 4
	}

	public abstract class EventData
	{
		public readonly InputMapper inputMapper;

		internal EventData(InputMapper P_0)
		{
			inputMapper = P_0;
		}
	}

	public class InputMappedEventData : EventData
	{
		public readonly ActionElementMap actionElementMap;

		internal InputMappedEventData(InputMapper P_0, ActionElementMap P_1)
			: base(P_0)
		{
			actionElementMap = P_1;
		}
	}

	public class CanceledEventData : EventData
	{
		public readonly string message;

		internal CanceledEventData(InputMapper P_0, string P_1)
			: base(P_0)
		{
			message = P_1;
		}
	}

	public class ErrorEventData : EventData
	{
		public readonly string message;

		internal ErrorEventData(InputMapper P_0, string P_1)
			: base(P_0)
		{
			message = P_1;
		}
	}

	public class TimedOutEventData : EventData
	{
		internal TimedOutEventData(InputMapper P_0)
			: base(P_0)
		{
		}
	}

	public class StartedEventData : EventData
	{
		internal StartedEventData(InputMapper P_0)
			: base(P_0)
		{
		}
	}

	public class StoppedEventData : EventData
	{
		internal StoppedEventData(InputMapper P_0)
			: base(P_0)
		{
		}
	}

	public class ConflictFoundEventData : EventData
	{
		public readonly Action<ConflictResponse> responseCallback;

		public readonly ElementAssignmentInfo assignment;

		public readonly IList<ElementAssignmentConflictInfo> conflicts;

		public readonly bool isProtected;

		private readonly Func<int, bool> dxpiMLUzmjeIMyhhHwyXofxGpdWf;

		public bool IsSwapAllowed(int maxInputFieldCount)
		{
			if (dxpiMLUzmjeIMyhhHwyXofxGpdWf == null)
			{
				return false;
			}
			return dxpiMLUzmjeIMyhhHwyXofxGpdWf(maxInputFieldCount);
		}

		internal ConflictFoundEventData(InputMapper P_0, Action<ConflictResponse> P_1, ElementAssignmentInfo P_2, IList<ElementAssignmentConflictInfo> P_3, bool P_4, Func<int, bool> P_5)
			: base(P_0)
		{
			responseCallback = P_1;
			assignment = P_2;
			conflicts = P_3;
			isProtected = P_4;
			dxpiMLUzmjeIMyhhHwyXofxGpdWf = P_5;
		}
	}

	private enum lUEWlnSMHujBffRXGzPhqVBKpQffb
	{
		InputMapped = 0,
		Error = 1,
		Canceled = 2,
		TimedOut = 3,
		Started = 4,
		Stopped = 5,
		ConflictsFound = 6
	}

	public enum Status
	{
		Idle = 0,
		Listening = 1,
		AwaitingResponse = 2
	}

	private class KWOESeDEwcLfmAQUZvCBjsmJVyWRA
	{
		private enum VUoNoMuDWYDluGoGiNNxVRDpBZQEA
		{
			Quit = 0,
			Continue = 1
		}

		private enum lsIUUqxtbFyrBNflJCtckAcYhDCN
		{
			None = 0,
			ConflictChecking = 1
		}

		private class cbrIYpDhqlwBlfGIFbaqljLkNKNd
		{
			private Player oKLFMKFihBoAgEAGdvnrGtmLsInCB;

			private int FkXWttYWaZUdJMBDOXjoYNDiChoEA;

			private Context wIOpsUhmlXgbIBHHHkHgcNbBpdIdc;

			private ControllerType IyvbAKbebuNzsBkJKOodwFKPoHDic;

			private int UxTFlLkdulteQWqFZRWRtdNVCPNt;

			private ControllerPollingInfo arpAKCURHxIbBOWGsjMJIgbxbWeK;

			private ModifierKeyFlags pfWEDmztnodJUEpnflNOyUxVNocA;

			public Player EflVXkrWYnlqRoILtKPYkVmyoXov => IeXaTXgZQakcMaCRtqTedcbmlPdWA();

			public int bRWOzePUmWOKwExNGLDQDGGItwwM => nvbainMEWmwlPVqtwDmpFvFGRdfJ();

			public Context khhAILWpwkfrpWMpbiOzJFqNVAyt => YVVCrXBMBqGHRwbUmCGrIHmiqYCvB();

			public ControllerType FZfwxklGpyqMjJRobNWJnADtMrgb => EWwrwvDaaxBhgcLtvzWtfgpcdYdAb();

			public int PLnkKtBcTirdIQgUHpmmJxFEsOJx => EGVWogHtlQhhbHBFNIVXYhPZSmWi();

			public ControllerPollingInfo fGZpnIibpDWwSWXpxIMWTjgEljMr => LoVleWEfxwJlTiWBtbhjeKIwAhUh();

			public ModifierKeyFlags qKOEsgearklMsYvetCAivIbDNSECA => oaOgSbjVXHwlNZBjCHZLunfEQTj();

			public AxisRange ogaskyTfYWAGDCftHptxPFuWzCVM => xAgdoRCoVsVwHsnNLXNZABIjWdGAA();

			public string nyphPllAhsYtjhHnTrfldcYxSMAu => PMAegUfQyKfPoBPFxhwQZOScyToqA();

			public Player IeXaTXgZQakcMaCRtqTedcbmlPdWA()
			{
				return oKLFMKFihBoAgEAGdvnrGtmLsInCB;
			}

			public int nvbainMEWmwlPVqtwDmpFvFGRdfJ()
			{
				return FkXWttYWaZUdJMBDOXjoYNDiChoEA;
			}

			public Context YVVCrXBMBqGHRwbUmCGrIHmiqYCvB()
			{
				return wIOpsUhmlXgbIBHHHkHgcNbBpdIdc;
			}

			public ControllerType EWwrwvDaaxBhgcLtvzWtfgpcdYdAb()
			{
				return IyvbAKbebuNzsBkJKOodwFKPoHDic;
			}

			public int EGVWogHtlQhhbHBFNIVXYhPZSmWi()
			{
				return UxTFlLkdulteQWqFZRWRtdNVCPNt;
			}

			public ControllerPollingInfo LoVleWEfxwJlTiWBtbhjeKIwAhUh()
			{
				return arpAKCURHxIbBOWGsjMJIgbxbWeK;
			}

			public ModifierKeyFlags oaOgSbjVXHwlNZBjCHZLunfEQTj()
			{
				return pfWEDmztnodJUEpnflNOyUxVNocA;
			}

			public AxisRange xAgdoRCoVsVwHsnNLXNZABIjWdGAA()
			{
				AxisRange result = AxisRange.Positive;
				if (LoVleWEfxwJlTiWBtbhjeKIwAhUh().elementType == ControllerElementType.Axis)
				{
					result = ((wIOpsUhmlXgbIBHHHkHgcNbBpdIdc.actionRange != AxisRange.Full) ? ((LoVleWEfxwJlTiWBtbhjeKIwAhUh().axisPole == Pole.Positive) ? AxisRange.Positive : AxisRange.Negative) : AxisRange.Full);
				}
				return result;
			}

			public string PMAegUfQyKfPoBPFxhwQZOScyToqA()
			{
				if (EWwrwvDaaxBhgcLtvzWtfgpcdYdAb() == ControllerType.Keyboard && oaOgSbjVXHwlNZBjCHZLunfEQTj() != ModifierKeyFlags.None)
				{
					return $"{Keyboard.ModifierKeyFlagsToString(oaOgSbjVXHwlNZBjCHZLunfEQTj())} + {LoVleWEfxwJlTiWBtbhjeKIwAhUh().elementIdentifierName}";
				}
				string text = LoVleWEfxwJlTiWBtbhjeKIwAhUh().elementIdentifierName;
				if (LoVleWEfxwJlTiWBtbhjeKIwAhUh().elementType == ControllerElementType.Axis)
				{
					if (xAgdoRCoVsVwHsnNLXNZABIjWdGAA() == AxisRange.Positive)
					{
						text += " +";
					}
					else if (xAgdoRCoVsVwHsnNLXNZABIjWdGAA() == AxisRange.Negative)
					{
						text += " -";
					}
				}
				return text;
			}

			public void IxfuzQjPzPeZoATiXEYQcWHSpzno(Player P_0, Context P_1)
			{
				if (P_1.controllerMap == null)
				{
					throw new ArgumentNullException("controllerMap");
				}
				RfOhfekwNopoBwCHweNPcunDQTpm();
				oKLFMKFihBoAgEAGdvnrGtmLsInCB = P_0;
				FkXWttYWaZUdJMBDOXjoYNDiChoEA = P_1.actionId;
				IyvbAKbebuNzsBkJKOodwFKPoHDic = P_1.controllerMap.controllerType;
				UxTFlLkdulteQWqFZRWRtdNVCPNt = P_1.controllerMap.controllerId;
				wIOpsUhmlXgbIBHHHkHgcNbBpdIdc = P_1;
				IyvbAKbebuNzsBkJKOodwFKPoHDic = P_1.controllerMap.controllerType;
				UxTFlLkdulteQWqFZRWRtdNVCPNt = P_1.controllerMap.controllerId;
				P_1.NRaOJVPDVQWPXVwgpjuFfcLtlhce();
			}

			public void RfOhfekwNopoBwCHweNPcunDQTpm()
			{
				oKLFMKFihBoAgEAGdvnrGtmLsInCB = null;
				FkXWttYWaZUdJMBDOXjoYNDiChoEA = -1;
				wIOpsUhmlXgbIBHHHkHgcNbBpdIdc = null;
				IyvbAKbebuNzsBkJKOodwFKPoHDic = ControllerType.Keyboard;
				UxTFlLkdulteQWqFZRWRtdNVCPNt = -1;
				arpAKCURHxIbBOWGsjMJIgbxbWeK = default;
				pfWEDmztnodJUEpnflNOyUxVNocA = ModifierKeyFlags.None;
			}

			public ElementAssignment SGLTQxOgRdjWkqihJWOubWdFwidN(ControllerPollingInfo P_0)
			{
				arpAKCURHxIbBOWGsjMJIgbxbWeK = P_0;
				return FGEZKdoqyLIPlepVUkqnppEAokrf();
			}

			public ElementAssignment eNIMRBjBCGlbQsFOxYyJYmGRPBvX(ControllerPollingInfo P_0, ModifierKeyFlags P_1)
			{
				arpAKCURHxIbBOWGsjMJIgbxbWeK = P_0;
				pfWEDmztnodJUEpnflNOyUxVNocA = P_1;
				return FGEZKdoqyLIPlepVUkqnppEAokrf();
			}

			public ElementAssignment FGEZKdoqyLIPlepVUkqnppEAokrf()
			{
				return new ElementAssignment(EWwrwvDaaxBhgcLtvzWtfgpcdYdAb(), arpAKCURHxIbBOWGsjMJIgbxbWeK.elementType, arpAKCURHxIbBOWGsjMJIgbxbWeK.elementIdentifierId, xAgdoRCoVsVwHsnNLXNZABIjWdGAA(), arpAKCURHxIbBOWGsjMJIgbxbWeK.keyboardKey, pfWEDmztnodJUEpnflNOyUxVNocA, FkXWttYWaZUdJMBDOXjoYNDiChoEA, (wIOpsUhmlXgbIBHHHkHgcNbBpdIdc.actionRange == AxisRange.Negative) ? Pole.Negative : Pole.Positive, false, (wIOpsUhmlXgbIBHHHkHgcNbBpdIdc.actionElementMapToReplace != null) ? wIOpsUhmlXgbIBHHHkHgcNbBpdIdc.actionElementMapToReplace.id : (-1));
			}
		}

		private sealed class RUSddEVEJlrCqvxVLoFVOJaEdZNR
		{
			public ActionElementMap bsZcEGbfZxALESBswEWqSnVnyvTRA;

			internal bool gzJHdPSUXiIuPPTeaTDzTcKsRLK(ElementAssignmentConflictInfo P_0)
			{
				return P_0.elementMapId == bsZcEGbfZxALESBswEWqSnVnyvTRA.id;
			}
		}

		private sealed class HfhsSiBVOuUmUKCdgaWmKXFOkQCS
		{
			public KWOESeDEwcLfmAQUZvCBjsmJVyWRA VyAdFRVgGvTCYPDKgwDTyVqqlRKB;

			public ElementAssignmentInfo NmUJWVxmHEdzdmRvIcfCaDAeZcmy;

			public IList<ElementAssignmentConflictInfo> ezfAcxffXNAzYQmmaeWoJlxkzFueA;

			public bool fwrjhRLGmdqfZvNeytiRxepmCEMR;

			internal bool bAYHUzAjRzjgocjlOzvVrsAoqXCbb(int P_0)
			{
				return VyAdFRVgGvTCYPDKgwDTyVqqlRKB.quFsyQkKrbcURuSrGsGbtmVHaVHk(NmUJWVxmHEdzdmRvIcfCaDAeZcmy, ezfAcxffXNAzYQmmaeWoJlxkzFueA, fwrjhRLGmdqfZvNeytiRxepmCEMR, P_0);
			}
		}

		private readonly InputMapper ubVDJlcqantYlnLWFYmjuxTRUKxZ;

		private readonly Options liMaDcGMHvSslsBzZQRehIPKHepib = new Options();

		private readonly cbrIYpDhqlwBlfGIFbaqljLkNKNd OUzcIxKQVzjGqhAzLwMpySMBKryb = new cbrIYpDhqlwBlfGIFbaqljLkNKNd();

		private readonly Dictionary<lUEWlnSMHujBffRXGzPhqVBKpQffb, SafeDelegate> foRTsfCOnUcXCZVxbxspOeoreDvq;

		private readonly Dictionary<string, SafeDelegate> fyOATEWWktawPNpdogIfdKVCOmlJA;

		private Status ALfamEGhChBFyZqDMjbIYCxzYptcA;

		private lsIUUqxtbFyrBNflJCtckAcYhDCN ZzdNNAfKfUNrQDJNSjhBtwVPbKqBA;

		private double wUwnOHnbzbJDffaxJWIxAmcgcsteA;

		private bool MwsdxXaaotcfSCgmEzWPIxUGHRlGA;

		private List<Player> SqSlOTaCfbxOGKojONLYAHNSgKSd = new List<Player>();

		private readonly List<ControllerPollingInfo> EzNBowzUlxkWYRdircxngbYVxrIPA = new List<ControllerPollingInfo>();

		private ElementAssignment XURExqLSNhjAvbparQfloDoxrBtb;

		public Status pgZNmlnErgcZjtmyOKlJcpsLQdx => xmbbGqVxuHxjfWggwIohnsmHiuSCA();

		public float kyqacAWgIiNHpNEzuYSHvcMkNHLx => guupFXdCgyiclIJSfnQNtJhTDtyvA();

		public Context XPofnvHTeYgBBctSPdWpAktwnXfCb => TMYVhsJwCpNJTDVYMdRmlWwygolg();

		private bool qtbHFqklURzzaWUdRlMdSZTSoChg => EctAWlGkaUpUVEhNQsihthkLhsKQ();

		public Status xmbbGqVxuHxjfWggwIohnsmHiuSCA()
		{
			return ALfamEGhChBFyZqDMjbIYCxzYptcA;
		}

		public float guupFXdCgyiclIJSfnQNtJhTDtyvA()
		{
			if (ALfamEGhChBFyZqDMjbIYCxzYptcA == Status.Idle)
			{
				return 0f;
			}
			if (liMaDcGMHvSslsBzZQRehIPKHepib.timeout <= 0f)
			{
				return 0f;
			}
			return (float)MathTools.Max(0.0, wUwnOHnbzbJDffaxJWIxAmcgcsteA + (double)liMaDcGMHvSslsBzZQRehIPKHepib.timeout - ReInput.unscaledTime);
		}

		public Context TMYVhsJwCpNJTDVYMdRmlWwygolg()
		{
			if (ALfamEGhChBFyZqDMjbIYCxzYptcA == Status.Idle)
			{
				return null;
			}
			return OUzcIxKQVzjGqhAzLwMpySMBKryb.YVVCrXBMBqGHRwbUmCGrIHmiqYCvB();
		}

		private bool EctAWlGkaUpUVEhNQsihthkLhsKQ()
		{
			if (MwsdxXaaotcfSCgmEzWPIxUGHRlGA)
			{
				return false;
			}
			if (!(liMaDcGMHvSslsBzZQRehIPKHepib.timeout > 0f))
			{
				return false;
			}
			return true;
		}

		public KWOESeDEwcLfmAQUZvCBjsmJVyWRA(InputMapper P_0, Dictionary<lUEWlnSMHujBffRXGzPhqVBKpQffb, SafeDelegate> P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("parent");
			}
			if (P_1 == null)
			{
				throw new ArgumentNullException("events");
			}
			ubVDJlcqantYlnLWFYmjuxTRUKxZ = P_0;
			foRTsfCOnUcXCZVxbxspOeoreDvq = P_1;
			pSokgqKnJzWopMldBcnfdkLObwHD();
		}

		protected virtual void qVKImtoFAmunvuwmZstsWKhKCqYJ()
		{
			try
			{
				yFlPIQUTvUwIrOVFSVscbWiASZaA();
			}
			finally
			{
				base.Finalize();
			}
		}

		public void XWnyCWNUrktKVyEXDPdesBCkjvnn(Context P_0, Options P_1)
		{
			if (ALfamEGhChBFyZqDMjbIYCxzYptcA != Status.Idle)
			{
				jjarcZfxIwMEQYFlSjZbeyoMCCSyA("User started a new listening session.");
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("context");
			}
			if (P_0.controllerMap == null)
			{
				throw new ArgumentNullException("controllerMap");
			}
			if (P_1 == null)
			{
				throw new ArgumentNullException("options");
			}
			P_0 = P_0.Clone();
			Options.Copy(P_1, liMaDcGMHvSslsBzZQRehIPKHepib);
			Player player = ReInput.players.GetPlayer(P_0.controllerMap.playerId);
			if (ReInput.mapping.GetAction(P_0.actionId) == null)
			{
				ThfYFaVHNrYGMVkdKCZMHjOKoadEb("No Action found for actionId: " + P_0.actionId);
				return;
			}
			OUzcIxKQVzjGqhAzLwMpySMBKryb.IxfuzQjPzPeZoATiXEYQcWHSpzno(player, P_0);
			ALfamEGhChBFyZqDMjbIYCxzYptcA = Status.Listening;
			yKIbNwwZgAqinPzaIwIiuEwpOhgg();
			KROCyBfcAZUTCbPCmdRhnaLFBjlHb();
			svPwYleliYVUBMZMvpFPKcPvavZx();
			laaeemfQGFdBhCHyIlWegFZERbbIc();
		}

		public void uNtYgZWCyHjCowATXAAhaZenGaBH(string P_0)
		{
			if (ALfamEGhChBFyZqDMjbIYCxzYptcA != Status.Idle)
			{
				jjarcZfxIwMEQYFlSjZbeyoMCCSyA(P_0);
			}
		}

		private void EmbFJkavPWpEDcdKqhlWhoddZDIeA(UpdateLoopType P_0)
		{
			if (P_0 == UpdateLoopType.Update && ALfamEGhChBFyZqDMjbIYCxzYptcA == Status.Listening)
			{
				ElementAssignment elementAssignment;
				if (EctAWlGkaUpUVEhNQsihthkLhsKQ() && guupFXdCgyiclIJSfnQNtJhTDtyvA() <= 0f)
				{
					QJtFhAMlASeVHOkVSBpckmDLVCMh();
				}
				else if (ReInput.controllers.GetController(OUzcIxKQVzjGqhAzLwMpySMBKryb.EWwrwvDaaxBhgcLtvzWtfgpcdYdAb(), OUzcIxKQVzjGqhAzLwMpySMBKryb.EGVWogHtlQhhbHBFNIVXYhPZSmWi()) == null)
				{
					ThfYFaVHNrYGMVkdKCZMHjOKoadEb("Controller not found for type: " + OUzcIxKQVzjGqhAzLwMpySMBKryb.EWwrwvDaaxBhgcLtvzWtfgpcdYdAb().ToString() + " id: " + OUzcIxKQVzjGqhAzLwMpySMBKryb.EGVWogHtlQhhbHBFNIVXYhPZSmWi());
				}
				else if (egQiosfksJJLjofheMhmmMIkuWtd(out elementAssignment) != VUoNoMuDWYDluGoGiNNxVRDpBZQEA.Quit && culcLPexkVNFMRBxyWAOoUcGJOaZA(elementAssignment) != VUoNoMuDWYDluGoGiNNxVRDpBZQEA.Quit)
				{
					VMqzlunCgyXCzegTMjHbfDCJCvVQ(elementAssignment);
				}
			}
		}

		private void zxiTCHdFeusAnHiSaiozGfFstnNX()
		{
			if (ALfamEGhChBFyZqDMjbIYCxzYptcA != Status.Idle)
			{
				pSokgqKnJzWopMldBcnfdkLObwHD();
				yFlPIQUTvUwIrOVFSVscbWiASZaA();
				ZTvsUcTkuuBgiujGOkvYhuaWIMFB();
			}
		}

		private void pSokgqKnJzWopMldBcnfdkLObwHD()
		{
			ALfamEGhChBFyZqDMjbIYCxzYptcA = Status.Idle;
			wUwnOHnbzbJDffaxJWIxAmcgcsteA = 0.0;
			liMaDcGMHvSslsBzZQRehIPKHepib.FrCfEOUsWxXmwUPzTCQAqNhrNIqT();
			OUzcIxKQVzjGqhAzLwMpySMBKryb.RfOhfekwNopoBwCHweNPcunDQTpm();
			XURExqLSNhjAvbparQfloDoxrBtb = default;
			ZzdNNAfKfUNrQDJNSjhBtwVPbKqBA = lsIUUqxtbFyrBNflJCtckAcYhDCN.None;
			MwsdxXaaotcfSCgmEzWPIxUGHRlGA = false;
			SqSlOTaCfbxOGKojONLYAHNSgKSd.Clear();
		}

		private VUoNoMuDWYDluGoGiNNxVRDpBZQEA egQiosfksJJLjofheMhmmMIkuWtd(out ElementAssignment P_0)
		{
			if (!pSfjMldhQteaKxEHDiqwkAUeDggq(out var enumerable, out var modifierKeyFlags))
			{
				P_0 = default;
				return VUoNoMuDWYDluGoGiNNxVRDpBZQEA.Quit;
			}
			ControllerPollingInfo controllerPollingInfo = default;
			foreach (ControllerPollingInfo item in enumerable)
			{
				if (item.success && !HvCUYynZrbjOKWDcogqGMXCHXicN(item, liMaDcGMHvSslsBzZQRehIPKHepib))
				{
					controllerPollingInfo = item;
					break;
				}
			}
			if (!controllerPollingInfo.success)
			{
				P_0 = default;
				return VUoNoMuDWYDluGoGiNNxVRDpBZQEA.Quit;
			}
			if (!qKqJxdXGTpWntZRYnVyBXolVXCJb(OUzcIxKQVzjGqhAzLwMpySMBKryb, controllerPollingInfo, liMaDcGMHvSslsBzZQRehIPKHepib))
			{
				P_0 = default;
				return VUoNoMuDWYDluGoGiNNxVRDpBZQEA.Quit;
			}
			P_0 = OUzcIxKQVzjGqhAzLwMpySMBKryb.SGLTQxOgRdjWkqihJWOubWdFwidN(controllerPollingInfo);
			P_0.modifierKeyFlags = modifierKeyFlags;
			return VUoNoMuDWYDluGoGiNNxVRDpBZQEA.Continue;
		}

		private bool pSfjMldhQteaKxEHDiqwkAUeDggq(out IEnumerable<ControllerPollingInfo> P_0, out ModifierKeyFlags P_1)
		{
			P_1 = ModifierKeyFlags.None;
			ControllerType controllerType = OUzcIxKQVzjGqhAzLwMpySMBKryb.EWwrwvDaaxBhgcLtvzWtfgpcdYdAb();
			int controllerId = OUzcIxKQVzjGqhAzLwMpySMBKryb.EGVWogHtlQhhbHBFNIVXYhPZSmWi();
			if (controllerType == ControllerType.Keyboard)
			{
				P_0 = ZDRdtdJCvzoYTMLaHfGjhPRPNUOzA(out P_1);
				return true;
			}
			if (liMaDcGMHvSslsBzZQRehIPKHepib.allowAxes)
			{
				if (liMaDcGMHvSslsBzZQRehIPKHepib.allowButtons)
				{
					if (OUzcIxKQVzjGqhAzLwMpySMBKryb.IeXaTXgZQakcMaCRtqTedcbmlPdWA() != null)
					{
						P_0 = OUzcIxKQVzjGqhAzLwMpySMBKryb.IeXaTXgZQakcMaCRtqTedcbmlPdWA().controllers.polling.PollControllerForAllElementsDown(controllerType, controllerId);
					}
					else
					{
						P_0 = ReInput.controllers.polling.PollControllerForAllElementsDown(OUzcIxKQVzjGqhAzLwMpySMBKryb.EWwrwvDaaxBhgcLtvzWtfgpcdYdAb(), OUzcIxKQVzjGqhAzLwMpySMBKryb.EGVWogHtlQhhbHBFNIVXYhPZSmWi());
					}
				}
				else if (OUzcIxKQVzjGqhAzLwMpySMBKryb.IeXaTXgZQakcMaCRtqTedcbmlPdWA() != null)
				{
					P_0 = OUzcIxKQVzjGqhAzLwMpySMBKryb.IeXaTXgZQakcMaCRtqTedcbmlPdWA().controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
				}
				else
				{
					P_0 = ReInput.controllers.polling.PollControllerForAllAxes(controllerType, controllerId);
				}
			}
			else
			{
				if (!liMaDcGMHvSslsBzZQRehIPKHepib.allowButtons)
				{
					ThfYFaVHNrYGMVkdKCZMHjOKoadEb("You must enable listening for at least one element type.");
					P_0 = null;
					return false;
				}
				if (OUzcIxKQVzjGqhAzLwMpySMBKryb.IeXaTXgZQakcMaCRtqTedcbmlPdWA() != null)
				{
					P_0 = OUzcIxKQVzjGqhAzLwMpySMBKryb.IeXaTXgZQakcMaCRtqTedcbmlPdWA().controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
				}
				else
				{
					P_0 = ReInput.controllers.polling.PollControllerForAllButtonsDown(controllerType, controllerId);
				}
			}
			return true;
		}

		private IEnumerable<ControllerPollingInfo> ZDRdtdJCvzoYTMLaHfGjhPRPNUOzA(out ModifierKeyFlags P_0)
		{
			P_0 = ModifierKeyFlags.None;
			EzNBowzUlxkWYRdircxngbYVxrIPA.Clear();
			if (!liMaDcGMHvSslsBzZQRehIPKHepib.allowButtons)
			{
				return EzNBowzUlxkWYRdircxngbYVxrIPA;
			}
			EzNBowzUlxkWYRdircxngbYVxrIPA.Add(LoUgFjhCPViTQfdYlCTuBmWSssRz(liMaDcGMHvSslsBzZQRehIPKHepib, out P_0));
			return EzNBowzUlxkWYRdircxngbYVxrIPA;
		}

		private ControllerPollingInfo LoUgFjhCPViTQfdYlCTuBmWSssRz(Options P_0, out ModifierKeyFlags P_1)
		{
			ControllerPollingInfo result = TCnMGgJIfOHTJTgLNEMDErGTetQG(P_0, out var flag, out P_1, out var _);
			if (flag)
			{
				yKIbNwwZgAqinPzaIwIiuEwpOhgg();
			}
			return result;
		}

		private static ControllerPollingInfo TCnMGgJIfOHTJTgLNEMDErGTetQG(Options P_0, out bool P_1, out ModifierKeyFlags P_2, out string P_3)
		{
			P_3 = string.Empty;
			P_1 = false;
			P_2 = ModifierKeyFlags.None;
			int num = 0;
			ControllerPollingInfo result = default;
			ControllerPollingInfo result2 = default;
			ModifierKeyFlags modifierKeyFlags = ModifierKeyFlags.None;
			foreach (ControllerPollingInfo item in ReInput.controllers.Keyboard.PollForAllKeys())
			{
				KeyCode keyboardKey = item.keyboardKey;
				if (keyboardKey == KeyCode.AltGr)
				{
					continue;
				}
				if (Keyboard.IsModifierKey(item.keyboardKey))
				{
					if (num == 0)
					{
						result2 = item;
					}
					modifierKeyFlags |= Keyboard.KeyCodeToModifierKeyFlags(keyboardKey);
					num++;
				}
				else if (result.keyboardKey == KeyCode.None)
				{
					result = item;
				}
			}
			if (result.keyboardKey != KeyCode.None)
			{
				if (!ReInput.controllers.Keyboard.GetKeyDown(result.keyboardKey))
				{
					return default;
				}
				if (num == 0 || !P_0.allowKeyboardKeysWithModifiers)
				{
					return result;
				}
				P_2 = modifierKeyFlags;
				return result;
			}
			if (num > 0)
			{
				P_1 = true;
				if (num == 1)
				{
					if (P_0.allowKeyboardModifierKeyAsPrimary)
					{
						if (!P_0.allowKeyboardKeysWithModifiers || P_0.holdDurationToMapKeyboardModifierKeyAsPrimary <= 0f)
						{
							if (!ReInput.controllers.Keyboard.GetKeyDown(result2.keyboardKey))
							{
								return default;
							}
							return result2;
						}
						if (ReInput.controllers.Keyboard.GetKeyTimePressed(result2.keyboardKey) >= (double)P_0.holdDurationToMapKeyboardModifierKeyAsPrimary)
						{
							return result2;
						}
					}
					P_3 = Keyboard.GetKeyName(result2.keyboardKey);
				}
				else
				{
					P_3 = Keyboard.ModifierKeyFlagsToString(modifierKeyFlags, getShortName: false);
				}
			}
			return default;
		}

		private static bool HvCUYynZrbjOKWDcogqGMXCHXicN(ControllerPollingInfo P_0, Options P_1)
		{
			if (!P_1.allowAxes && P_0.elementType == ControllerElementType.Axis)
			{
				return false;
			}
			if (!P_1.allowButtons && P_0.elementType == ControllerElementType.Button)
			{
				return false;
			}
			if (P_0.controllerType == ControllerType.Mouse && P_0.elementType == ControllerElementType.Axis)
			{
				switch (P_0.elementIndex)
				{
				case 0:
					if (P_1.ignoreMouseXAxis)
					{
						return true;
					}
					break;
				case 1:
					if (P_1.ignoreMouseYAxis)
					{
						return true;
					}
					break;
				}
			}
			SafePredicate<ControllerPollingInfo> safePredicate = P_1.MsVXKQoenqAKqdeCMnJhHmuJuifAc<SafePredicate<ControllerPollingInfo>>("isElementAllowed");
			if (safePredicate != null)
			{
				return !safePredicate.Invoke(P_0);
			}
			return false;
		}

		private static bool qKqJxdXGTpWntZRYnVyBXolVXCJb(cbrIYpDhqlwBlfGIFbaqljLkNKNd P_0, ControllerPollingInfo P_1, Options P_2)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (P_2 == null)
			{
				return true;
			}
			if (P_0.xAgdoRCoVsVwHsnNLXNZABIjWdGAA() == AxisRange.Full && !P_2.allowButtonsOnFullAxisAssignment && P_1.elementType == ControllerElementType.Button)
			{
				return false;
			}
			return true;
		}

		private void KROCyBfcAZUTCbPCmdRhnaLFBjlHb()
		{
			if (!liMaDcGMHvSslsBzZQRehIPKHepib.checkForConflicts)
			{
				return;
			}
			if (liMaDcGMHvSslsBzZQRehIPKHepib.checkForConflictsWithSelf && OUzcIxKQVzjGqhAzLwMpySMBKryb.IeXaTXgZQakcMaCRtqTedcbmlPdWA() != null)
			{
				ListTools.AddIfUnique(SqSlOTaCfbxOGKojONLYAHNSgKSd, OUzcIxKQVzjGqhAzLwMpySMBKryb.IeXaTXgZQakcMaCRtqTedcbmlPdWA());
			}
			if (liMaDcGMHvSslsBzZQRehIPKHepib.checkForConflictsWithSystemPlayer)
			{
				ListTools.AddIfUnique(SqSlOTaCfbxOGKojONLYAHNSgKSd, ReInput.players.SystemPlayer);
			}
			if (liMaDcGMHvSslsBzZQRehIPKHepib.checkForConflictsWithAllPlayers)
			{
				IList<Player> players = ReInput.players.Players;
				for (int i = 0; i < players.Count; i++)
				{
					ListTools.AddIfUnique(SqSlOTaCfbxOGKojONLYAHNSgKSd, players[i]);
				}
			}
			else
			{
				if (liMaDcGMHvSslsBzZQRehIPKHepib.checkForConflictsWithPlayerIds == null)
				{
					return;
				}
				IList<Player> allPlayers = ReInput.players.AllPlayers;
				int count = allPlayers.Count;
				for (int j = 0; j < count; j++)
				{
					if (ArrayTools.Contains(liMaDcGMHvSslsBzZQRehIPKHepib.checkForConflictsWithPlayerIds, allPlayers[j].id))
					{
						ListTools.AddIfUnique(SqSlOTaCfbxOGKojONLYAHNSgKSd, allPlayers[j]);
					}
				}
			}
		}

		private VUoNoMuDWYDluGoGiNNxVRDpBZQEA culcLPexkVNFMRBxyWAOoUcGJOaZA(ElementAssignment P_0)
		{
			if (liMaDcGMHvSslsBzZQRehIPKHepib.checkForConflicts && OUzcIxKQVzjGqhAzLwMpySMBKryb.IeXaTXgZQakcMaCRtqTedcbmlPdWA() != null && ZHuZUKXHcqEHiaYBKRnxFBqWXsZMA(OUzcIxKQVzjGqhAzLwMpySMBKryb, P_0, SqSlOTaCfbxOGKojONLYAHNSgKSd))
			{
				return cPfoovvecrmcVMdPXwBSgkFmNeSM(P_0);
			}
			return VUoNoMuDWYDluGoGiNNxVRDpBZQEA.Continue;
		}

		private static bool ZHuZUKXHcqEHiaYBKRnxFBqWXsZMA(cbrIYpDhqlwBlfGIFbaqljLkNKNd P_0, ElementAssignment P_1, List<Player> P_2)
		{
			if (P_0 == null || P_0.IeXaTXgZQakcMaCRtqTedcbmlPdWA() == null)
			{
				return false;
			}
			if (P_2 == null || P_2.Count == 0)
			{
				return false;
			}
			if (!LsWkWiNKGmlZulTyNMiNYEHpdUWJ(P_0, P_1, out var conflictCheck))
			{
				return false;
			}
			for (int i = 0; i < P_2.Count; i++)
			{
				if (P_2[i].controllers.conflictChecking.DoesElementAssignmentConflict(conflictCheck))
				{
					return true;
				}
			}
			return false;
		}

		private static bool cKnTrPGMBVhuMALwbnFHcxcquAtPA(cbrIYpDhqlwBlfGIFbaqljLkNKNd P_0, ElementAssignment P_1, List<Player> P_2)
		{
			if (P_0 == null || P_0.IeXaTXgZQakcMaCRtqTedcbmlPdWA() == null)
			{
				return false;
			}
			if (P_2 == null || P_2.Count == 0)
			{
				return false;
			}
			if (!LsWkWiNKGmlZulTyNMiNYEHpdUWJ(P_0, P_1, out var conflictCheck))
			{
				return false;
			}
			for (int i = 0; i < P_2.Count; i++)
			{
				foreach (ElementAssignmentConflictInfo item in P_2[i].controllers.conflictChecking.ElementAssignmentConflicts(conflictCheck))
				{
					if (!item.isUserAssignable)
					{
						return true;
					}
				}
			}
			return false;
		}

		private static IList<ElementAssignmentConflictInfo> EMggazMvBaHbjFovfVYJEofXLRZtA(cbrIYpDhqlwBlfGIFbaqljLkNKNd P_0, ElementAssignment P_1, List<Player> P_2)
		{
			if (P_0 == null || P_0.IeXaTXgZQakcMaCRtqTedcbmlPdWA() == null)
			{
				return null;
			}
			if (P_2 == null || P_2.Count == 0)
			{
				return null;
			}
			if (!LsWkWiNKGmlZulTyNMiNYEHpdUWJ(P_0, P_1, out var conflictCheck))
			{
				return null;
			}
			List<ElementAssignmentConflictInfo> list = new List<ElementAssignmentConflictInfo>();
			for (int i = 0; i < P_2.Count; i++)
			{
				foreach (ElementAssignmentConflictInfo item in P_2[i].controllers.conflictChecking.ElementAssignmentConflicts(conflictCheck))
				{
					list.Add(item);
				}
			}
			return list;
		}

		private static bool LsWkWiNKGmlZulTyNMiNYEHpdUWJ(cbrIYpDhqlwBlfGIFbaqljLkNKNd P_0, ElementAssignment P_1, out ElementAssignmentConflictCheck P_2)
		{
			Player player;
			if (P_0 == null || (player = P_0.IeXaTXgZQakcMaCRtqTedcbmlPdWA()) == null)
			{
				P_2 = default;
				return false;
			}
			P_2 = P_1.ToElementAssignmentConflictCheck();
			P_2.playerId = player.id;
			P_2.controllerType = P_0.EWwrwvDaaxBhgcLtvzWtfgpcdYdAb();
			P_2.controllerId = P_0.EGVWogHtlQhhbHBFNIVXYhPZSmWi();
			P_2.controllerMapId = P_0.YVVCrXBMBqGHRwbUmCGrIHmiqYCvB().controllerMap.id;
			P_2.controllerMapCategoryId = P_0.YVVCrXBMBqGHRwbUmCGrIHmiqYCvB().controllerMap.categoryId;
			if (P_0.YVVCrXBMBqGHRwbUmCGrIHmiqYCvB().actionElementMapToReplace != null)
			{
				P_2.elementMapId = P_0.YVVCrXBMBqGHRwbUmCGrIHmiqYCvB().actionElementMapToReplace.id;
			}
			return true;
		}

		private static void HTltaGdkDPMInmAZGPJuYgvGEMhD(cbrIYpDhqlwBlfGIFbaqljLkNKNd P_0, ElementAssignment P_1, List<Player> P_2)
		{
			if (P_0 == null || P_0.IeXaTXgZQakcMaCRtqTedcbmlPdWA() == null)
			{
				return;
			}
			if (!LsWkWiNKGmlZulTyNMiNYEHpdUWJ(P_0, P_1, out var conflictCheck))
			{
				Logger.LogError("Error creating conflict check!");
				return;
			}
			for (int i = 0; i < P_2.Count; i++)
			{
				P_2[i].controllers.conflictChecking.RemoveElementAssignmentConflicts(conflictCheck);
			}
		}

		private void svPwYleliYVUBMZMvpFPKcPvavZx()
		{
			ReInput.UpdateEndedEvent -= EmbFJkavPWpEDcdKqhlWhoddZDIeA;
			ReInput.UpdateEndedEvent += EmbFJkavPWpEDcdKqhlWhoddZDIeA;
		}

		private void yFlPIQUTvUwIrOVFSVscbWiASZaA()
		{
			ReInput.UpdateEndedEvent -= EmbFJkavPWpEDcdKqhlWhoddZDIeA;
		}

		private bool YPbxUYdYlgwLEWvifAsWdpdSvArP(lUEWlnSMHujBffRXGzPhqVBKpQffb P_0)
		{
			SafeDelegate safeDelegate = foRTsfCOnUcXCZVxbxspOeoreDvq[P_0];
			if (safeDelegate != null)
			{
				return safeDelegate.Count > 0;
			}
			return false;
		}

		private void paVacOfdcwSMsAaQbcqZmCJORrifb<_0001>(lUEWlnSMHujBffRXGzPhqVBKpQffb P_0, _0001 P_1)
		{
			SafeAction<_0001> safeAction = (SafeAction<_0001>)foRTsfCOnUcXCZVxbxspOeoreDvq[P_0];
			if (safeAction.Count != 0)
			{
				safeAction.Invoke(P_1);
			}
		}

		private void yKIbNwwZgAqinPzaIwIiuEwpOhgg()
		{
			wUwnOHnbzbJDffaxJWIxAmcgcsteA = ReInput.unscaledTime;
		}

		private void cZCEyvVPpWjrGzPODIXZBSeXmVxB()
		{
			MwsdxXaaotcfSCgmEzWPIxUGHRlGA = true;
		}

		private bool quFsyQkKrbcURuSrGsGbtmVHaVHk(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2, int P_3)
		{
			if (P_3 < 0)
			{
				P_3 = 0;
			}
			if (P_0 == null || P_1 == null)
			{
				return false;
			}
			if (P_2)
			{
				return false;
			}
			ActionElementMap elementMap = P_0.elementMap;
			if (elementMap == null)
			{
				return false;
			}
			List<ElementAssignmentConflictInfo> list = new List<ElementAssignmentConflictInfo>();
			for (int i = 0; i < P_1.Count; i++)
			{
				if (P_1[i].playerId == P_0.player.id)
				{
					list.Add(P_1[i]);
				}
			}
			if (list.Count > 1)
			{
				return false;
			}
			ElementAssignmentConflictInfo elementAssignmentConflictInfo = list[0];
			if (elementAssignmentConflictInfo.elementMap == null)
			{
				return false;
			}
			if (!elementAssignmentConflictInfo.isConflict)
			{
				return false;
			}
			if (elementAssignmentConflictInfo.playerId != P_0.player.id)
			{
				return false;
			}
			int actionId = elementAssignmentConflictInfo.elementMap.actionId;
			Pole axisContribution = elementAssignmentConflictInfo.elementMap.axisContribution;
			AxisRange axisRange = elementMap.axisRange;
			ControllerElementType elementType = elementMap.elementType;
			if (elementType == elementAssignmentConflictInfo.elementMap.elementType && elementType == ControllerElementType.Axis)
			{
				if (axisRange != elementAssignmentConflictInfo.elementMap.axisRange)
				{
					if (axisRange == AxisRange.Full)
					{
						axisRange = AxisRange.Positive;
					}
					else if (elementAssignmentConflictInfo.elementMap.axisRange != AxisRange.Full)
					{
					}
				}
			}
			else if (elementType == ControllerElementType.Axis && (elementAssignmentConflictInfo.elementMap.elementType == ControllerElementType.Button || (elementAssignmentConflictInfo.elementMap.elementType == ControllerElementType.Axis && elementAssignmentConflictInfo.elementMap.axisRange != AxisRange.Full)) && axisRange == AxisRange.Full)
			{
				axisRange = AxisRange.Positive;
			}
			int num = 0;
			if (P_0.action.id == elementAssignmentConflictInfo.actionId && P_0.controllerMap == elementAssignmentConflictInfo.controllerMap)
			{
				Controller controller = ReInput.controllers.GetController(P_0.controllerType, P_0.controllerId);
				if (kYirZjzGUpsgJVjbzTCLiKrYdRxV(elementType, axisRange, axisContribution, controller.GetElementById(P_0.elementIdentifier.get_id()).type, P_0.axisRange, P_0.axisContribution))
				{
					num++;
				}
			}
			using (IEnumerator<ActionElementMap> enumerator = elementAssignmentConflictInfo.controllerMap.ElementMapsWithAction(actionId).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					RUSddEVEJlrCqvxVLoFVOJaEdZNR rUSddEVEJlrCqvxVLoFVOJaEdZNR = new RUSddEVEJlrCqvxVLoFVOJaEdZNR();
					rUSddEVEJlrCqvxVLoFVOJaEdZNR.bsZcEGbfZxALESBswEWqSnVnyvTRA = enumerator.Current;
					if (rUSddEVEJlrCqvxVLoFVOJaEdZNR.bsZcEGbfZxALESBswEWqSnVnyvTRA.id != elementMap.id && ListTools.FindIndex(list, rUSddEVEJlrCqvxVLoFVOJaEdZNR.gzJHdPSUXiIuPPTeaTDzTcKsRLK) < 0 && kYirZjzGUpsgJVjbzTCLiKrYdRxV(elementType, axisRange, axisContribution, rUSddEVEJlrCqvxVLoFVOJaEdZNR.bsZcEGbfZxALESBswEWqSnVnyvTRA.elementType, rUSddEVEJlrCqvxVLoFVOJaEdZNR.bsZcEGbfZxALESBswEWqSnVnyvTRA.axisRange, rUSddEVEJlrCqvxVLoFVOJaEdZNR.bsZcEGbfZxALESBswEWqSnVnyvTRA.axisContribution))
					{
						num++;
					}
				}
			}
			return num < P_3;
		}

		private bool IwTeIcmFYzghZxUVbFLxIoPfxkZJA(cbrIYpDhqlwBlfGIFbaqljLkNKNd P_0, ElementAssignment P_1, bool P_2, out string P_3)
		{
			if (P_0 == null)
			{
				P_3 = "Mapping is null reference.";
				return false;
			}
			List<Player> list = new List<Player> { P_0.IeXaTXgZQakcMaCRtqTedcbmlPdWA() };
			IList<ElementAssignmentConflictInfo> list2 = EMggazMvBaHbjFovfVYJEofXLRZtA(P_0, P_1, list);
			int count = list2.Count;
			if (count == 0)
			{
				P_3 = "Swap was canceled because no conflicts were found.";
				return false;
			}
			if (count > 1)
			{
				P_3 = "Swap was canceled because more than one conflict was found.";
				return false;
			}
			if (P_2)
			{
				P_3 = "Swap was canceled due to a protected conflict that cannot be replaced.";
				return false;
			}
			if (P_0.YVVCrXBMBqGHRwbUmCGrIHmiqYCvB().actionElementMapToReplace == null)
			{
				P_3 = "Swap was canceled because this is not a replacement assignment.";
				return false;
			}
			ElementAssignmentConflictInfo elementAssignmentConflictInfo = list2[0];
			if (!elementAssignmentConflictInfo.isConflict)
			{
				P_3 = "Swap was canceled because conflict was invalid.";
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(elementAssignmentConflictInfo.elementMap);
			if (actionElementMap == null)
			{
				P_3 = "Swap was canceled because conflict ActionElementMap was null.";
				return false;
			}
			ActionElementMap actionElementMap2 = new ActionElementMap(P_0.YVVCrXBMBqGHRwbUmCGrIHmiqYCvB().actionElementMapToReplace);
			HTltaGdkDPMInmAZGPJuYgvGEMhD(P_0, P_1, list);
			int actionId = actionElementMap.actionId;
			Pole axisContribution = actionElementMap.axisContribution;
			bool invert = actionElementMap.invert;
			AxisRange axisRange = actionElementMap2.axisRange;
			ControllerElementType elementType = actionElementMap2.elementType;
			int elementIdentifierId = actionElementMap2.elementIdentifierId;
			KeyCode keyCode = actionElementMap2.keyCode;
			ModifierKeyFlags modifierKeyFlags = actionElementMap2.modifierKeyFlags;
			if (elementType == actionElementMap.elementType && elementType == ControllerElementType.Axis)
			{
				if (axisRange != actionElementMap.axisRange)
				{
					if (axisRange == AxisRange.Full)
					{
						axisRange = AxisRange.Positive;
					}
					else if (actionElementMap.axisRange != AxisRange.Full)
					{
					}
				}
			}
			else if (elementType == ControllerElementType.Axis && (actionElementMap.elementType == ControllerElementType.Button || (actionElementMap.elementType == ControllerElementType.Axis && actionElementMap.axisRange != AxisRange.Full)) && axisRange == AxisRange.Full)
			{
				axisRange = AxisRange.Positive;
			}
			if (elementType != ControllerElementType.Axis || axisRange != AxisRange.Full)
			{
				invert = false;
			}
			elementAssignmentConflictInfo.controllerMap.ReplaceOrCreateElementMap(ElementAssignment.CompleteAssignment(P_0.EWwrwvDaaxBhgcLtvzWtfgpcdYdAb(), elementType, elementIdentifierId, axisRange, keyCode, modifierKeyFlags, actionId, axisContribution, invert));
			P_3 = null;
			return true;
		}

		private static bool kYirZjzGUpsgJVjbzTCLiKrYdRxV(ControllerElementType P_0, AxisRange P_1, Pole P_2, ControllerElementType P_3, AxisRange P_4, Pole P_5)
		{
			if ((P_0 == ControllerElementType.Button || (P_0 == ControllerElementType.Axis && P_1 != AxisRange.Full)) && (P_3 == ControllerElementType.Button || (P_3 == ControllerElementType.Axis && P_4 != AxisRange.Full)) && P_5 == P_2)
			{
				return true;
			}
			if (P_0 == ControllerElementType.Axis && P_1 == AxisRange.Full && P_3 == ControllerElementType.Axis && P_4 == AxisRange.Full)
			{
				return true;
			}
			return false;
		}

		private void icsDLNhdbQoqeQvDiVVKUtfnIKbn(ActionElementMap P_0)
		{
			MpuTiBkvQgsYTeQuaBpvVPXKDuIX(P_0);
			zxiTCHdFeusAnHiSaiozGfFstnNX();
		}

		private void jjarcZfxIwMEQYFlSjZbeyoMCCSyA(string P_0)
		{
			dTFamxjfbKrxfAxyBhtBmHUZusFvB(P_0);
			zxiTCHdFeusAnHiSaiozGfFstnNX();
		}

		private VUoNoMuDWYDluGoGiNNxVRDpBZQEA cPfoovvecrmcVMdPXwBSgkFmNeSM(ElementAssignment P_0)
		{
			if (YPbxUYdYlgwLEWvifAsWdpdSvArP(lUEWlnSMHujBffRXGzPhqVBKpQffb.ConflictsFound))
			{
				bool flag = cKnTrPGMBVhuMALwbnFHcxcquAtPA(OUzcIxKQVzjGqhAzLwMpySMBKryb, P_0, SqSlOTaCfbxOGKojONLYAHNSgKSd);
				XURExqLSNhjAvbparQfloDoxrBtb = P_0;
				IList<ElementAssignmentConflictInfo> list = EMggazMvBaHbjFovfVYJEofXLRZtA(OUzcIxKQVzjGqhAzLwMpySMBKryb, P_0, SqSlOTaCfbxOGKojONLYAHNSgKSd);
				ZzdNNAfKfUNrQDJNSjhBtwVPbKqBA = lsIUUqxtbFyrBNflJCtckAcYhDCN.ConflictChecking;
				floNSomtMkcRewfVBJZfLIwADzgo();
				UIlbwAWWYJJCbBujOIsqTByuLeNW(new ElementAssignmentInfo(OUzcIxKQVzjGqhAzLwMpySMBKryb.YVVCrXBMBqGHRwbUmCGrIHmiqYCvB().controllerMap, P_0), list, flag);
				return VUoNoMuDWYDluGoGiNNxVRDpBZQEA.Quit;
			}
			return LpoVALZrrYVpHEaINUJQmqmgzJLk(liMaDcGMHvSslsBzZQRehIPKHepib.defaultActionWhenConflictFound, P_0);
		}

		private VUoNoMuDWYDluGoGiNNxVRDpBZQEA LpoVALZrrYVpHEaINUJQmqmgzJLk(ConflictResponse P_0, ElementAssignment P_1)
		{
			return vaNExmNGRIqVXgRyPKnIpSUtYbYd(P_0, P_1, cKnTrPGMBVhuMALwbnFHcxcquAtPA(OUzcIxKQVzjGqhAzLwMpySMBKryb, P_1, SqSlOTaCfbxOGKojONLYAHNSgKSd));
		}

		private VUoNoMuDWYDluGoGiNNxVRDpBZQEA vaNExmNGRIqVXgRyPKnIpSUtYbYd(ConflictResponse P_0, ElementAssignment P_1, bool P_2)
		{
			switch (P_0)
			{
			case ConflictResponse.Cancel:
				jjarcZfxIwMEQYFlSjZbeyoMCCSyA("Mapping assignment was canceled due to a conflict.");
				return VUoNoMuDWYDluGoGiNNxVRDpBZQEA.Quit;
			case ConflictResponse.Replace:
				if (P_2)
				{
					jjarcZfxIwMEQYFlSjZbeyoMCCSyA("Mapping assignment was canceled due to a protected conflict that cannot be replaced.");
					return VUoNoMuDWYDluGoGiNNxVRDpBZQEA.Quit;
				}
				HTltaGdkDPMInmAZGPJuYgvGEMhD(OUzcIxKQVzjGqhAzLwMpySMBKryb, P_1, SqSlOTaCfbxOGKojONLYAHNSgKSd);
				return VUoNoMuDWYDluGoGiNNxVRDpBZQEA.Continue;
			case ConflictResponse.Add:
				return VUoNoMuDWYDluGoGiNNxVRDpBZQEA.Continue;
			case ConflictResponse.Ignore:
				kMJDOFODoyhIkzfgdiwLmJtyXObf();
				return VUoNoMuDWYDluGoGiNNxVRDpBZQEA.Quit;
			case ConflictResponse.Swap:
			{
				if (!IwTeIcmFYzghZxUVbFLxIoPfxkZJA(OUzcIxKQVzjGqhAzLwMpySMBKryb, P_1, P_2, out var text))
				{
					jjarcZfxIwMEQYFlSjZbeyoMCCSyA(text);
					return VUoNoMuDWYDluGoGiNNxVRDpBZQEA.Quit;
				}
				return VUoNoMuDWYDluGoGiNNxVRDpBZQEA.Continue;
			}
			default:
				throw new NotImplementedException();
			}
		}

		private void QJtFhAMlASeVHOkVSBpckmDLVCMh()
		{
			VXSwCPFQFbtjnuOiieJFjHjdWdUb();
			zxiTCHdFeusAnHiSaiozGfFstnNX();
		}

		private void ThfYFaVHNrYGMVkdKCZMHjOKoadEb(string P_0)
		{
			QWkPMSxmwZXmBKRsqdoRCblumhix(P_0);
			zxiTCHdFeusAnHiSaiozGfFstnNX();
		}

		private void floNSomtMkcRewfVBJZfLIwADzgo()
		{
			cZCEyvVPpWjrGzPODIXZBSeXmVxB();
			yFlPIQUTvUwIrOVFSVscbWiASZaA();
			ALfamEGhChBFyZqDMjbIYCxzYptcA = Status.AwaitingResponse;
		}

		private void kMJDOFODoyhIkzfgdiwLmJtyXObf()
		{
			ALfamEGhChBFyZqDMjbIYCxzYptcA = Status.Listening;
			ZzdNNAfKfUNrQDJNSjhBtwVPbKqBA = lsIUUqxtbFyrBNflJCtckAcYhDCN.None;
			yKIbNwwZgAqinPzaIwIiuEwpOhgg();
			svPwYleliYVUBMZMvpFPKcPvavZx();
		}

		private void VMqzlunCgyXCzegTMjHbfDCJCvVQ(ElementAssignment P_0)
		{
			if (OUzcIxKQVzjGqhAzLwMpySMBKryb.YVVCrXBMBqGHRwbUmCGrIHmiqYCvB().controllerMap.ReplaceOrCreateElementMap(P_0, out var result))
			{
				icsDLNhdbQoqeQvDiVVKUtfnIKbn(result);
			}
			else
			{
				ThfYFaVHNrYGMVkdKCZMHjOKoadEb("Failed to create element assignment.");
			}
		}

		private void MpuTiBkvQgsYTeQuaBpvVPXKDuIX(ActionElementMap P_0)
		{
			if (YPbxUYdYlgwLEWvifAsWdpdSvArP(lUEWlnSMHujBffRXGzPhqVBKpQffb.InputMapped))
			{
				paVacOfdcwSMsAaQbcqZmCJORrifb(lUEWlnSMHujBffRXGzPhqVBKpQffb.InputMapped, new InputMappedEventData(ubVDJlcqantYlnLWFYmjuxTRUKxZ, P_0));
			}
		}

		private void VXSwCPFQFbtjnuOiieJFjHjdWdUb()
		{
			if (YPbxUYdYlgwLEWvifAsWdpdSvArP(lUEWlnSMHujBffRXGzPhqVBKpQffb.TimedOut))
			{
				paVacOfdcwSMsAaQbcqZmCJORrifb(lUEWlnSMHujBffRXGzPhqVBKpQffb.TimedOut, new TimedOutEventData(ubVDJlcqantYlnLWFYmjuxTRUKxZ));
			}
		}

		private void QWkPMSxmwZXmBKRsqdoRCblumhix(string P_0)
		{
			if (YPbxUYdYlgwLEWvifAsWdpdSvArP(lUEWlnSMHujBffRXGzPhqVBKpQffb.Error))
			{
				paVacOfdcwSMsAaQbcqZmCJORrifb(lUEWlnSMHujBffRXGzPhqVBKpQffb.Error, new ErrorEventData(ubVDJlcqantYlnLWFYmjuxTRUKxZ, P_0));
			}
		}

		private void dTFamxjfbKrxfAxyBhtBmHUZusFvB(string P_0)
		{
			if (YPbxUYdYlgwLEWvifAsWdpdSvArP(lUEWlnSMHujBffRXGzPhqVBKpQffb.Canceled))
			{
				paVacOfdcwSMsAaQbcqZmCJORrifb(lUEWlnSMHujBffRXGzPhqVBKpQffb.Canceled, new CanceledEventData(ubVDJlcqantYlnLWFYmjuxTRUKxZ, P_0));
			}
		}

		private void UIlbwAWWYJJCbBujOIsqTByuLeNW(ElementAssignmentInfo P_0, IList<ElementAssignmentConflictInfo> P_1, bool P_2)
		{
			HfhsSiBVOuUmUKCdgaWmKXFOkQCS hfhsSiBVOuUmUKCdgaWmKXFOkQCS = new HfhsSiBVOuUmUKCdgaWmKXFOkQCS();
			hfhsSiBVOuUmUKCdgaWmKXFOkQCS.VyAdFRVgGvTCYPDKgwDTyVqqlRKB = this;
			hfhsSiBVOuUmUKCdgaWmKXFOkQCS.NmUJWVxmHEdzdmRvIcfCaDAeZcmy = P_0;
			hfhsSiBVOuUmUKCdgaWmKXFOkQCS.ezfAcxffXNAzYQmmaeWoJlxkzFueA = P_1;
			hfhsSiBVOuUmUKCdgaWmKXFOkQCS.fwrjhRLGmdqfZvNeytiRxepmCEMR = P_2;
			if (YPbxUYdYlgwLEWvifAsWdpdSvArP(lUEWlnSMHujBffRXGzPhqVBKpQffb.ConflictsFound))
			{
				paVacOfdcwSMsAaQbcqZmCJORrifb(lUEWlnSMHujBffRXGzPhqVBKpQffb.ConflictsFound, new ConflictFoundEventData(ubVDJlcqantYlnLWFYmjuxTRUKxZ, jNVXortSRKaVlrIzHYeLnGCZtfkG, hfhsSiBVOuUmUKCdgaWmKXFOkQCS.NmUJWVxmHEdzdmRvIcfCaDAeZcmy, hfhsSiBVOuUmUKCdgaWmKXFOkQCS.ezfAcxffXNAzYQmmaeWoJlxkzFueA, hfhsSiBVOuUmUKCdgaWmKXFOkQCS.fwrjhRLGmdqfZvNeytiRxepmCEMR, hfhsSiBVOuUmUKCdgaWmKXFOkQCS.bAYHUzAjRzjgocjlOzvVrsAoqXCbb));
			}
		}

		private void laaeemfQGFdBhCHyIlWegFZERbbIc()
		{
			if (YPbxUYdYlgwLEWvifAsWdpdSvArP(lUEWlnSMHujBffRXGzPhqVBKpQffb.Started))
			{
				paVacOfdcwSMsAaQbcqZmCJORrifb(lUEWlnSMHujBffRXGzPhqVBKpQffb.Started, new StartedEventData(ubVDJlcqantYlnLWFYmjuxTRUKxZ));
			}
		}

		private void ZTvsUcTkuuBgiujGOkvYhuaWIMFB()
		{
			if (YPbxUYdYlgwLEWvifAsWdpdSvArP(lUEWlnSMHujBffRXGzPhqVBKpQffb.Stopped))
			{
				paVacOfdcwSMsAaQbcqZmCJORrifb(lUEWlnSMHujBffRXGzPhqVBKpQffb.Stopped, new StoppedEventData(ubVDJlcqantYlnLWFYmjuxTRUKxZ));
			}
		}

		public void jNVXortSRKaVlrIzHYeLnGCZtfkG(ConflictResponse P_0)
		{
			if (ALfamEGhChBFyZqDMjbIYCxzYptcA != Status.AwaitingResponse || ZzdNNAfKfUNrQDJNSjhBtwVPbKqBA != lsIUUqxtbFyrBNflJCtckAcYhDCN.ConflictChecking)
			{
				Logger.LogWarning("The Mapping Listener was not waiting for a conflict checking response. The response will be ignored.");
				return;
			}
			try
			{
				if (LpoVALZrrYVpHEaINUJQmqmgzJLk(P_0, XURExqLSNhjAvbparQfloDoxrBtb) == VUoNoMuDWYDluGoGiNNxVRDpBZQEA.Continue)
				{
					VMqzlunCgyXCzegTMjHbfDCJCvVQ(XURExqLSNhjAvbparQfloDoxrBtb);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("An exception occurred in the conflict check user response callback.\n" + ex);
			}
		}
	}

	public class Options
	{
		[Serializable]
		private sealed class KGKZmusjgpJydYdiTwHnpmpPgOqd
		{
			public static readonly KGKZmusjgpJydYdiTwHnpmpPgOqd _003C_003E9 = new KGKZmusjgpJydYdiTwHnpmpPgOqd();

			public static Action<Exception> _003C_003E9__64_0;

			internal void MdhFTXOHBGiOCSdkFPsXaYiGemrV(Exception P_0)
			{
				ReInput.HandleCallbackException("InputMapper.Options.isElementAllowedCallback", P_0);
			}
		}

		private bool USOZOcLfVDMmdwiJeHvzDKRkMlhKA = true;

		private bool LwLFGbDMgelpHHxBfLKQeIoGlHkQA = true;

		private bool lPcPcpTdFNrASisfDsQPaSzwgTsf = true;

		private float AnnzhvFnIjZTFQhmclVRqWgFjsSk;

		private bool afgzIZAoxmhUXjjUAcvKgTihYATNA = true;

		private bool ihXjapyQIbJBBZSoOQyOjaUIbHrBA = true;

		private bool nTArKDLRXTXHUvEdCqSkNvWDPgJU = true;

		private bool BBRhqYpSfGzqLtgPQywgopleluHe = true;

		private int[] mECJrAEhKSEgxzjppQcCrVYehVGq;

		private ConflictResponse WkipPalqNkFlvtEpXekSlIOTcTNiA = ConflictResponse.Replace;

		private bool KLZeXAMTAETjBstIpFhbuCnmmhdt;

		private bool ODDQvLIIwYOIDoMmKGWQVpDnMgIC;

		private bool vwmDZhWqZaCmGAdnmVDqjeyyEYmdA = true;

		private bool wspAFYOnsCFAofmeSYiATgLiiKfF = true;

		private float uOefZYYgcoWFWPmddcwBdHslhIdA = 1f;

		internal const string lMlFCpmqiaytGGDhkDulTbFMCyRQ = "isElementAllowed";

		private readonly Dictionary<string, SafeDelegate> pTSSbPTELHcuFgTviEmBZzBCqdRHA = new Dictionary<string, SafeDelegate> { { "isElementAllowed", null } };

		public bool allowAxes
		{
			get
			{
				return USOZOcLfVDMmdwiJeHvzDKRkMlhKA;
			}
			set
			{
				USOZOcLfVDMmdwiJeHvzDKRkMlhKA = value;
			}
		}

		public bool allowButtons
		{
			get
			{
				return LwLFGbDMgelpHHxBfLKQeIoGlHkQA;
			}
			set
			{
				LwLFGbDMgelpHHxBfLKQeIoGlHkQA = value;
			}
		}

		public bool allowButtonsOnFullAxisAssignment
		{
			get
			{
				return lPcPcpTdFNrASisfDsQPaSzwgTsf;
			}
			set
			{
				lPcPcpTdFNrASisfDsQPaSzwgTsf = value;
			}
		}

		public float timeout
		{
			get
			{
				return AnnzhvFnIjZTFQhmclVRqWgFjsSk;
			}
			set
			{
				AnnzhvFnIjZTFQhmclVRqWgFjsSk = MathTools.Max(0f, value);
			}
		}

		public bool checkForConflicts
		{
			get
			{
				return afgzIZAoxmhUXjjUAcvKgTihYATNA;
			}
			set
			{
				afgzIZAoxmhUXjjUAcvKgTihYATNA = value;
			}
		}

		public bool checkForConflictsWithAllPlayers
		{
			get
			{
				return ihXjapyQIbJBBZSoOQyOjaUIbHrBA;
			}
			set
			{
				ihXjapyQIbJBBZSoOQyOjaUIbHrBA = value;
			}
		}

		public bool checkForConflictsWithSelf
		{
			get
			{
				return nTArKDLRXTXHUvEdCqSkNvWDPgJU;
			}
			set
			{
				nTArKDLRXTXHUvEdCqSkNvWDPgJU = value;
			}
		}

		public bool checkForConflictsWithSystemPlayer
		{
			get
			{
				return BBRhqYpSfGzqLtgPQywgopleluHe;
			}
			set
			{
				BBRhqYpSfGzqLtgPQywgopleluHe = value;
			}
		}

		public int[] checkForConflictsWithPlayerIds
		{
			get
			{
				return mECJrAEhKSEgxzjppQcCrVYehVGq;
			}
			set
			{
				mECJrAEhKSEgxzjppQcCrVYehVGq = value;
			}
		}

		public ConflictResponse defaultActionWhenConflictFound
		{
			get
			{
				return WkipPalqNkFlvtEpXekSlIOTcTNiA;
			}
			set
			{
				WkipPalqNkFlvtEpXekSlIOTcTNiA = value;
			}
		}

		public bool ignoreMouseXAxis
		{
			get
			{
				return KLZeXAMTAETjBstIpFhbuCnmmhdt;
			}
			set
			{
				KLZeXAMTAETjBstIpFhbuCnmmhdt = value;
			}
		}

		public bool ignoreMouseYAxis
		{
			get
			{
				return ODDQvLIIwYOIDoMmKGWQVpDnMgIC;
			}
			set
			{
				ODDQvLIIwYOIDoMmKGWQVpDnMgIC = value;
			}
		}

		public bool allowKeyboardKeysWithModifiers
		{
			get
			{
				return vwmDZhWqZaCmGAdnmVDqjeyyEYmdA;
			}
			set
			{
				vwmDZhWqZaCmGAdnmVDqjeyyEYmdA = value;
			}
		}

		public bool allowKeyboardModifierKeyAsPrimary
		{
			get
			{
				return wspAFYOnsCFAofmeSYiATgLiiKfF;
			}
			set
			{
				wspAFYOnsCFAofmeSYiATgLiiKfF = value;
			}
		}

		public float holdDurationToMapKeyboardModifierKeyAsPrimary
		{
			get
			{
				return uOefZYYgcoWFWPmddcwBdHslhIdA;
			}
			set
			{
				uOefZYYgcoWFWPmddcwBdHslhIdA = MathTools.Max(0f, value);
			}
		}

		public Predicate<ControllerPollingInfo> isElementAllowedCallback
		{
			get
			{
				return (SafePredicate<ControllerPollingInfo>)pTSSbPTELHcuFgTviEmBZzBCqdRHA["isElementAllowed"];
			}
			set
			{
				SafePredicate<ControllerPollingInfo> safePredicate = value;
				if (safePredicate != null)
				{
					safePredicate.ExceptionHandler = KGKZmusjgpJydYdiTwHnpmpPgOqd._003C_003E9.MdhFTXOHBGiOCSdkFPsXaYiGemrV;
				}
				pTSSbPTELHcuFgTviEmBZzBCqdRHA["isElementAllowed"] = safePredicate;
			}
		}

		internal _0001 MsVXKQoenqAKqdeCMnJhHmuJuifAc<_0001>(string P_0) where _0001 : SafeDelegate
		{
			if (!pTSSbPTELHcuFgTviEmBZzBCqdRHA.TryGetValue(P_0, out var value))
			{
				return null;
			}
			return value as _0001;
		}

		public Options()
		{
			FrCfEOUsWxXmwUPzTCQAqNhrNIqT();
		}

		private Options(Options P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			Copy(P_0, this);
		}

		public Options Clone()
		{
			return new Options(this);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Options:\n");
			stringBuilder.Append("allowAxes = " + USOZOcLfVDMmdwiJeHvzDKRkMlhKA + "\n");
			stringBuilder.Append("allowButtons = " + LwLFGbDMgelpHHxBfLKQeIoGlHkQA + "\n");
			stringBuilder.Append("allowButtonsOnFullAxisAssignment = " + lPcPcpTdFNrASisfDsQPaSzwgTsf + "\n");
			stringBuilder.Append("timeout = " + AnnzhvFnIjZTFQhmclVRqWgFjsSk + "\n");
			stringBuilder.Append("checkForConflicts = " + afgzIZAoxmhUXjjUAcvKgTihYATNA + "\n");
			stringBuilder.Append("checkForConflictsWithAllPlayers = " + ihXjapyQIbJBBZSoOQyOjaUIbHrBA + "\n");
			stringBuilder.Append("checkForConflictsWithSelf = " + nTArKDLRXTXHUvEdCqSkNvWDPgJU + "\n");
			stringBuilder.Append("checkForConflictsWithSystemPlayer = " + BBRhqYpSfGzqLtgPQywgopleluHe + "\n");
			if (mECJrAEhKSEgxzjppQcCrVYehVGq == null)
			{
				stringBuilder.Append("_checkForConflictsWithPlayerIds = null\n");
			}
			else
			{
				stringBuilder.Append("_checkForConflictsWithPlayerIds = " + StringTools.ToString(mECJrAEhKSEgxzjppQcCrVYehVGq) + "\n");
			}
			stringBuilder.Append("defaultActionWhenConflictFound = " + WkipPalqNkFlvtEpXekSlIOTcTNiA.ToString() + "\n");
			stringBuilder.Append("ignoreMouseXAxis = " + KLZeXAMTAETjBstIpFhbuCnmmhdt);
			stringBuilder.Append("ignoreMouseYAxis = " + ODDQvLIIwYOIDoMmKGWQVpDnMgIC);
			stringBuilder.Append("allowKeyboardKeysWithModifiers = " + vwmDZhWqZaCmGAdnmVDqjeyyEYmdA + "\n");
			stringBuilder.Append("allowKeyboardModifierAsPrimary = " + wspAFYOnsCFAofmeSYiATgLiiKfF + "\n");
			stringBuilder.Append("holdDurationToMapKeyboardModifierKeyAsPrimary = " + uOefZYYgcoWFWPmddcwBdHslhIdA + "\n");
			return stringBuilder.ToString();
		}

		internal void FrCfEOUsWxXmwUPzTCQAqNhrNIqT()
		{
			USOZOcLfVDMmdwiJeHvzDKRkMlhKA = true;
			LwLFGbDMgelpHHxBfLKQeIoGlHkQA = true;
			lPcPcpTdFNrASisfDsQPaSzwgTsf = true;
			AnnzhvFnIjZTFQhmclVRqWgFjsSk = 0f;
			afgzIZAoxmhUXjjUAcvKgTihYATNA = true;
			ihXjapyQIbJBBZSoOQyOjaUIbHrBA = true;
			nTArKDLRXTXHUvEdCqSkNvWDPgJU = true;
			BBRhqYpSfGzqLtgPQywgopleluHe = true;
			mECJrAEhKSEgxzjppQcCrVYehVGq = null;
			WkipPalqNkFlvtEpXekSlIOTcTNiA = ConflictResponse.Replace;
			KLZeXAMTAETjBstIpFhbuCnmmhdt = false;
			ODDQvLIIwYOIDoMmKGWQVpDnMgIC = false;
			vwmDZhWqZaCmGAdnmVDqjeyyEYmdA = true;
			wspAFYOnsCFAofmeSYiATgLiiKfF = true;
			uOefZYYgcoWFWPmddcwBdHslhIdA = 1f;
			foreach (string item in new List<string>(pTSSbPTELHcuFgTviEmBZzBCqdRHA.Keys))
			{
				pTSSbPTELHcuFgTviEmBZzBCqdRHA[item] = null;
			}
		}

		public static void Copy(Options source, Options destination)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			destination.USOZOcLfVDMmdwiJeHvzDKRkMlhKA = source.USOZOcLfVDMmdwiJeHvzDKRkMlhKA;
			destination.LwLFGbDMgelpHHxBfLKQeIoGlHkQA = source.LwLFGbDMgelpHHxBfLKQeIoGlHkQA;
			destination.lPcPcpTdFNrASisfDsQPaSzwgTsf = source.lPcPcpTdFNrASisfDsQPaSzwgTsf;
			destination.AnnzhvFnIjZTFQhmclVRqWgFjsSk = source.AnnzhvFnIjZTFQhmclVRqWgFjsSk;
			destination.afgzIZAoxmhUXjjUAcvKgTihYATNA = source.afgzIZAoxmhUXjjUAcvKgTihYATNA;
			destination.ihXjapyQIbJBBZSoOQyOjaUIbHrBA = source.ihXjapyQIbJBBZSoOQyOjaUIbHrBA;
			destination.nTArKDLRXTXHUvEdCqSkNvWDPgJU = source.nTArKDLRXTXHUvEdCqSkNvWDPgJU;
			destination.BBRhqYpSfGzqLtgPQywgopleluHe = source.BBRhqYpSfGzqLtgPQywgopleluHe;
			destination.mECJrAEhKSEgxzjppQcCrVYehVGq = ArrayTools.ShallowCopy(source.mECJrAEhKSEgxzjppQcCrVYehVGq);
			destination.WkipPalqNkFlvtEpXekSlIOTcTNiA = source.WkipPalqNkFlvtEpXekSlIOTcTNiA;
			destination.KLZeXAMTAETjBstIpFhbuCnmmhdt = source.KLZeXAMTAETjBstIpFhbuCnmmhdt;
			destination.ODDQvLIIwYOIDoMmKGWQVpDnMgIC = source.ODDQvLIIwYOIDoMmKGWQVpDnMgIC;
			destination.vwmDZhWqZaCmGAdnmVDqjeyyEYmdA = source.vwmDZhWqZaCmGAdnmVDqjeyyEYmdA;
			destination.wspAFYOnsCFAofmeSYiATgLiiKfF = source.wspAFYOnsCFAofmeSYiATgLiiKfF;
			destination.uOefZYYgcoWFWPmddcwBdHslhIdA = source.uOefZYYgcoWFWPmddcwBdHslhIdA;
			foreach (KeyValuePair<string, SafeDelegate> item in source.pTSSbPTELHcuFgTviEmBZzBCqdRHA)
			{
				destination.pTSSbPTELHcuFgTviEmBZzBCqdRHA[item.Key] = MiscTools.Clone(item.Value);
			}
		}
	}

	[Serializable]
	private sealed class AygrsjTvtZrsFprecZoSSrhDEkho
	{
		public static readonly AygrsjTvtZrsFprecZoSSrhDEkho _003C_003E9 = new AygrsjTvtZrsFprecZoSSrhDEkho();

		public static Action<Exception> _003C_003E9__54_0;

		public static Action<Exception> _003C_003E9__54_1;

		public static Action<Exception> _003C_003E9__54_2;

		public static Action<Exception> _003C_003E9__54_3;

		public static Action<Exception> _003C_003E9__54_4;

		public static Action<Exception> _003C_003E9__54_5;

		public static Action<Exception> _003C_003E9__54_6;

		internal void kjykldxdwecEtGQOjLvwDlQeBcAF(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.AssignedEvent", P_0);
		}

		internal void RpqKynzsNUvSEcVarHMzpqiEgjPv(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.ErrorEvent", P_0);
		}

		internal void hdxhZKgFLiegJdhSbTigqMKsNRYYb(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.CanceledEvent", P_0);
		}

		internal void KihqVifeUFiRpdaGgcpYEXDmgSTp(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.TimedOutEvent", P_0);
		}

		internal void eaMfhcknKWGugqUybDEnEEcInsAt(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.StartedEvent", P_0);
		}

		internal void juDvsOrCRattIXyNfzUWxWLvfYQj(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.StoppedEvent", P_0);
		}

		internal void OBPnJDNFdXxzKbExoBIwDgNVCxycA(Exception P_0)
		{
			ReInput.HandleCallbackException("InputMapper.ConflictFoundEvent", P_0);
		}
	}

	private static InputMapper FNwEJXAraTIjPJGlAGuVvKkhKjXj;

	private static int tpolfxJjyYxdpFOyVDrHdPHfEVUN;

	private readonly int CtvXCZlrYdtvPMpKwCQVERRBVRiU;

	private readonly bool IXDkvwxjMRpPYUZULfwbkfkqnKcQ;

	private readonly KWOESeDEwcLfmAQUZvCBjsmJVyWRA gGJdSVkvxfTgTKEFlIsNAtvdKRUp;

	private Options esuoKSZKqdVmuIzrAhLatmXsmRNl;

	private readonly Dictionary<lUEWlnSMHujBffRXGzPhqVBKpQffb, SafeDelegate> VeKvLZWVyEmdWknvCrvqeQRcsyZm = new Dictionary<lUEWlnSMHujBffRXGzPhqVBKpQffb, SafeDelegate>
	{
		{
			lUEWlnSMHujBffRXGzPhqVBKpQffb.InputMapped,
			new SafeAction<InputMappedEventData>(AygrsjTvtZrsFprecZoSSrhDEkho._003C_003E9.kjykldxdwecEtGQOjLvwDlQeBcAF)
		},
		{
			lUEWlnSMHujBffRXGzPhqVBKpQffb.Error,
			new SafeAction<ErrorEventData>(AygrsjTvtZrsFprecZoSSrhDEkho._003C_003E9.RpqKynzsNUvSEcVarHMzpqiEgjPv)
		},
		{
			lUEWlnSMHujBffRXGzPhqVBKpQffb.Canceled,
			new SafeAction<CanceledEventData>(AygrsjTvtZrsFprecZoSSrhDEkho._003C_003E9.hdxhZKgFLiegJdhSbTigqMKsNRYYb)
		},
		{
			lUEWlnSMHujBffRXGzPhqVBKpQffb.TimedOut,
			new SafeAction<TimedOutEventData>(AygrsjTvtZrsFprecZoSSrhDEkho._003C_003E9.KihqVifeUFiRpdaGgcpYEXDmgSTp)
		},
		{
			lUEWlnSMHujBffRXGzPhqVBKpQffb.Started,
			new SafeAction<StartedEventData>(AygrsjTvtZrsFprecZoSSrhDEkho._003C_003E9.eaMfhcknKWGugqUybDEnEEcInsAt)
		},
		{
			lUEWlnSMHujBffRXGzPhqVBKpQffb.Stopped,
			new SafeAction<StoppedEventData>(AygrsjTvtZrsFprecZoSSrhDEkho._003C_003E9.juDvsOrCRattIXyNfzUWxWLvfYQj)
		},
		{
			lUEWlnSMHujBffRXGzPhqVBKpQffb.ConflictsFound,
			new SafeAction<ConflictFoundEventData>(AygrsjTvtZrsFprecZoSSrhDEkho._003C_003E9.OBPnJDNFdXxzKbExoBIwDgNVCxycA)
		}
	};

	public static InputMapper Default => FNwEJXAraTIjPJGlAGuVvKkhKjXj ?? (FNwEJXAraTIjPJGlAGuVvKkhKjXj = new InputMapper(true));

	public Options options
	{
		get
		{
			Options obj = esuoKSZKqdVmuIzrAhLatmXsmRNl;
			if (obj == null)
			{
				if (!IXDkvwxjMRpPYUZULfwbkfkqnKcQ)
				{
					return esuoKSZKqdVmuIzrAhLatmXsmRNl = Default.options.Clone();
				}
				obj = (esuoKSZKqdVmuIzrAhLatmXsmRNl = new Options());
			}
			return obj;
		}
		set
		{
			esuoKSZKqdVmuIzrAhLatmXsmRNl = value;
		}
	}

	public Context mappingContext => gGJdSVkvxfTgTKEFlIsNAtvdKRUp.TMYVhsJwCpNJTDVYMdRmlWwygolg();

	public Status status => gGJdSVkvxfTgTKEFlIsNAtvdKRUp.xmbbGqVxuHxjfWggwIohnsmHiuSCA();

	public float timeRemaining => gGJdSVkvxfTgTKEFlIsNAtvdKRUp.guupFXdCgyiclIJSfnQNtJhTDtyvA();

	internal int nsTclyjQXooqlpCpBxRhvQWTfEIHA => JGyumzftilHfrivWhNDhZfjTZWWU();

	public event Action<InputMappedEventData> InputMappedEvent
	{
		add
		{
			if (value != null)
			{
				lUEWlnSMHujBffRXGzPhqVBKpQffb key = lUEWlnSMHujBffRXGzPhqVBKpQffb.InputMapped;
				VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] = (SafeAction<InputMappedEventData>)VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] + value;
			}
		}
		remove
		{
			if (value != null)
			{
				lUEWlnSMHujBffRXGzPhqVBKpQffb key = lUEWlnSMHujBffRXGzPhqVBKpQffb.InputMapped;
				VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] = (SafeAction<InputMappedEventData>)VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] - value;
			}
		}
	}

	public event Action<ErrorEventData> ErrorEvent
	{
		add
		{
			if (value != null)
			{
				lUEWlnSMHujBffRXGzPhqVBKpQffb key = lUEWlnSMHujBffRXGzPhqVBKpQffb.Error;
				VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] = (SafeAction<ErrorEventData>)VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] + value;
			}
		}
		remove
		{
			if (value != null)
			{
				lUEWlnSMHujBffRXGzPhqVBKpQffb key = lUEWlnSMHujBffRXGzPhqVBKpQffb.Error;
				VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] = (SafeAction<ErrorEventData>)VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] - value;
			}
		}
	}

	public event Action<CanceledEventData> CanceledEvent
	{
		add
		{
			if (value != null)
			{
				lUEWlnSMHujBffRXGzPhqVBKpQffb key = lUEWlnSMHujBffRXGzPhqVBKpQffb.Canceled;
				VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] = (SafeAction<CanceledEventData>)VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] + value;
			}
		}
		remove
		{
			if (value != null)
			{
				lUEWlnSMHujBffRXGzPhqVBKpQffb key = lUEWlnSMHujBffRXGzPhqVBKpQffb.Canceled;
				VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] = (SafeAction<CanceledEventData>)VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] - value;
			}
		}
	}

	public event Action<TimedOutEventData> TimedOutEvent
	{
		add
		{
			if (value != null)
			{
				lUEWlnSMHujBffRXGzPhqVBKpQffb key = lUEWlnSMHujBffRXGzPhqVBKpQffb.TimedOut;
				VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] = (SafeAction<TimedOutEventData>)VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] + value;
			}
		}
		remove
		{
			if (value != null)
			{
				lUEWlnSMHujBffRXGzPhqVBKpQffb key = lUEWlnSMHujBffRXGzPhqVBKpQffb.TimedOut;
				VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] = (SafeAction<TimedOutEventData>)VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] - value;
			}
		}
	}

	public event Action<StartedEventData> StartedEvent
	{
		add
		{
			if (value != null)
			{
				lUEWlnSMHujBffRXGzPhqVBKpQffb key = lUEWlnSMHujBffRXGzPhqVBKpQffb.Started;
				VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] = (SafeAction<StartedEventData>)VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] + value;
			}
		}
		remove
		{
			if (value != null)
			{
				lUEWlnSMHujBffRXGzPhqVBKpQffb key = lUEWlnSMHujBffRXGzPhqVBKpQffb.Started;
				VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] = (SafeAction<StartedEventData>)VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] - value;
			}
		}
	}

	public event Action<StoppedEventData> StoppedEvent
	{
		add
		{
			if (value != null)
			{
				lUEWlnSMHujBffRXGzPhqVBKpQffb key = lUEWlnSMHujBffRXGzPhqVBKpQffb.Stopped;
				VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] = (SafeAction<StoppedEventData>)VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] + value;
			}
		}
		remove
		{
			if (value != null)
			{
				lUEWlnSMHujBffRXGzPhqVBKpQffb key = lUEWlnSMHujBffRXGzPhqVBKpQffb.Stopped;
				VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] = (SafeAction<StoppedEventData>)VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] - value;
			}
		}
	}

	public event Action<ConflictFoundEventData> ConflictFoundEvent
	{
		add
		{
			if (value != null)
			{
				lUEWlnSMHujBffRXGzPhqVBKpQffb key = lUEWlnSMHujBffRXGzPhqVBKpQffb.ConflictsFound;
				VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] = (SafeAction<ConflictFoundEventData>)VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] + value;
			}
		}
		remove
		{
			if (value != null)
			{
				lUEWlnSMHujBffRXGzPhqVBKpQffb key = lUEWlnSMHujBffRXGzPhqVBKpQffb.ConflictsFound;
				VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] = (SafeAction<ConflictFoundEventData>)VeKvLZWVyEmdWknvCrvqeQRcsyZm[key] - value;
			}
		}
	}

	private static int WhojSApHhycLfnKlPjMNBrroLxes()
	{
		int result = tpolfxJjyYxdpFOyVDrHdPHfEVUN;
		if (tpolfxJjyYxdpFOyVDrHdPHfEVUN == int.MaxValue)
		{
			tpolfxJjyYxdpFOyVDrHdPHfEVUN = 0;
			return result;
		}
		tpolfxJjyYxdpFOyVDrHdPHfEVUN++;
		return result;
	}

	internal int JGyumzftilHfrivWhNDhZfjTZWWU()
	{
		return CtvXCZlrYdtvPMpKwCQVERRBVRiU;
	}

	public InputMapper()
		: this(false)
	{
		CtvXCZlrYdtvPMpKwCQVERRBVRiU = WhojSApHhycLfnKlPjMNBrroLxes();
	}

	private InputMapper(bool P_0)
	{
		IXDkvwxjMRpPYUZULfwbkfkqnKcQ = P_0;
		if (IXDkvwxjMRpPYUZULfwbkfkqnKcQ)
		{
			esuoKSZKqdVmuIzrAhLatmXsmRNl = new Options();
		}
		gGJdSVkvxfTgTKEFlIsNAtvdKRUp = new KWOESeDEwcLfmAQUZvCBjsmJVyWRA(this, VeKvLZWVyEmdWknvCrvqeQRcsyZm);
	}

	public void RemoveEventListeners(object listenerOrParent)
	{
		if (listenerOrParent == null)
		{
			return;
		}
		foreach (KeyValuePair<lUEWlnSMHujBffRXGzPhqVBKpQffb, SafeDelegate> item in VeKvLZWVyEmdWknvCrvqeQRcsyZm)
		{
			item.Value.RemoveDelegateOrAllDelegatesFromAnObject(listenerOrParent);
		}
	}

	public void RemoveAllEventListeners()
	{
		foreach (KeyValuePair<lUEWlnSMHujBffRXGzPhqVBKpQffb, SafeDelegate> item in VeKvLZWVyEmdWknvCrvqeQRcsyZm)
		{
			item.Value.Clear();
		}
	}

	internal void PlYYqOhrQcMEjtnFQxfmYYvpjVAw(object P_0)
	{
	}

	internal void AtjQRtbmUkBlQHftWipgqCNgasJp()
	{
	}

	public bool Start(Context mappingContext)
	{
		return aWDgqtEinRAZuXhIXZovMDtAnsXLA(mappingContext, (esuoKSZKqdVmuIzrAhLatmXsmRNl != null) ? esuoKSZKqdVmuIzrAhLatmXsmRNl : Default.options);
	}

	public void Stop()
	{
		gGJdSVkvxfTgTKEFlIsNAtvdKRUp.uNtYgZWCyHjCowATXAAhaZenGaBH("User canceled.");
	}

	public void Clear()
	{
		Stop();
		RemoveAllEventListeners();
		AtjQRtbmUkBlQHftWipgqCNgasJp();
		esuoKSZKqdVmuIzrAhLatmXsmRNl = null;
	}

	private bool aWDgqtEinRAZuXhIXZovMDtAnsXLA(Context P_0, Options P_1)
	{
		if (!ReInput.isReady)
		{
			return false;
		}
		if (P_0 == null)
		{
			Logger.LogError("The Context cannot be null.");
			return false;
		}
		if (P_0.controllerMap == null)
		{
			Logger.LogError("The Controller Map cannot be null.");
			return false;
		}
		if (P_0.actionElementMapToReplace != null && !P_0.controllerMap.ContainsElementMap(P_0.actionElementMapToReplace))
		{
			Logger.LogError("The Action Element Map must belong to the same Controller Map you are passing in.");
			return false;
		}
		try
		{
			gGJdSVkvxfTgTKEFlIsNAtvdKRUp.XWnyCWNUrktKVyEXDPdesBCkjvnn(P_0, P_1);
			return true;
		}
		catch
		{
			gGJdSVkvxfTgTKEFlIsNAtvdKRUp.uNtYgZWCyHjCowATXAAhaZenGaBH("Failed to start due to an exception.");
			return false;
		}
	}
}
