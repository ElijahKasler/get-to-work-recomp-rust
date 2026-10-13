using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Interfaces;
using Rewired.Utils.Libraries.TinyJson;
using UnityEngine;

namespace Rewired;

public sealed class ControllerMapLayoutManager
{
	internal class cUhsarZCgVkkiQMvHfbBJdlcDTAR
	{
		public bool bBFSAhKuzSrUzgVwYwNCqIUSUVZd;

		public bool VoRTsWAezQQeJJasfLCIbIWdEQTG;

		public boXUVZSpTpcopaaUnxDKswlkAzHFb[] dUqJlNtdRaQmydQGlxBjDZBpfEoL;

		public cUhsarZCgVkkiQMvHfbBJdlcDTAR(bool P_0, bool P_1, boXUVZSpTpcopaaUnxDKswlkAzHFb[] P_2)
		{
			bBFSAhKuzSrUzgVwYwNCqIUSUVZd = P_0;
			VoRTsWAezQQeJJasfLCIbIWdEQTG = P_1;
			dUqJlNtdRaQmydQGlxBjDZBpfEoL = P_2;
		}
	}

	[Serializable]
	[Preserve]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Rule : IDeepCloneable
	{
		[SerializeField]
		[Serialize(Name = "tag")]
		private string _tag;

		[SerializeField]
		[Serialize(Name = "categoryIds")]
		private int[] _categoryIds;

		[SerializeField]
		[Serialize(Name = "layoutId")]
		private int _layoutId;

		[SerializeField]
		[Serialize(Name = "controllerSetSelector")]
		private ControllerSetSelector _controllerSetSelector;

		[NonSerialized]
		private string[] _preInitCategoryNames;

		[NonSerialized]
		private string _preInitLayoutName;

		public string tag
		{
			get
			{
				return _tag;
			}
			set
			{
				_tag = value;
			}
		}

		public ControllerSetSelector controllerSetSelector
		{
			get
			{
				return _controllerSetSelector ?? (_controllerSetSelector = new ControllerSetSelector(ControllerSetSelector.Type.ControllerType));
			}
			set
			{
				if (value == null)
				{
					value = new ControllerSetSelector(ControllerSetSelector.Type.ControllerType);
				}
				if (!value.tebuGQJPHtXUICAmsiObbDOQQvJJ())
				{
					Logger.LogError(value.type.ToString() + " is not allowed. Each Controller Type has its own unique Layouts and a single Layout cannot be set for all Controller Types. ControllerSelector.type has been changed to ControllerSelector.Type.ControllerType.", requiredThreadSafety: true);
					value.type = ControllerSetSelector.Type.ControllerType;
				}
				_controllerSetSelector = value;
			}
		}

		public int categoryId
		{
			get
			{
				Initialize();
				if (_categoryIds == null || _categoryIds.Length == 0)
				{
					return -1;
				}
				return categoryIds[0];
			}
			set
			{
				if (value < 0)
				{
					_categoryIds = EmptyObjects<int>.array;
				}
				else
				{
					if (_categoryIds == null || _categoryIds.Length == 0)
					{
						_categoryIds = new int[1];
					}
					_categoryIds[0] = value;
				}
				_preInitCategoryNames = null;
			}
		}

		public int[] categoryIds
		{
			get
			{
				Initialize();
				return _categoryIds ?? (_categoryIds = EmptyObjects<int>.array);
			}
			set
			{
				if (value == null)
				{
					value = EmptyObjects<int>.array;
				}
				_categoryIds = value;
				_preInitCategoryNames = null;
			}
		}

		public int layoutId
		{
			get
			{
				Initialize();
				return _layoutId;
			}
			set
			{
				if (value < 0)
				{
					value = -1;
				}
				_layoutId = value;
				_preInitLayoutName = null;
			}
		}

		public string categoryName
		{
			get
			{
				if (!ReInput.isReady)
				{
					if (_preInitCategoryNames == null || _preInitCategoryNames.Length == 0)
					{
						return null;
					}
					return _preInitCategoryNames[0];
				}
				Initialize();
				if (_categoryIds == null || _categoryIds.Length == 0)
				{
					return null;
				}
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryIds[0]);
				if (mapCategory == null)
				{
					return "INVALID";
				}
				return mapCategory.name;
			}
			set
			{
				if (!ReInput.isReady)
				{
					_preInitCategoryNames = (string.IsNullOrEmpty(value) ? null : new string[1] { value });
					_categoryIds = EmptyObjects<int>.array;
					return;
				}
				if (string.IsNullOrEmpty(value))
				{
					_preInitCategoryNames = null;
					_categoryIds = EmptyObjects<int>.array;
					return;
				}
				int mapCategoryId = ReInput.mapping.GetMapCategoryId(value);
				if (mapCategoryId >= 0)
				{
					categoryId = mapCategoryId;
				}
				else
				{
					Logger.LogWarning("Map Category \"" + value + "\" does not exist.");
				}
			}
		}

		public string[] categoryNames
		{
			get
			{
				if (!ReInput.isReady)
				{
					if (_preInitCategoryNames == null)
					{
						return EmptyObjects<string>.array;
					}
					return _preInitCategoryNames;
				}
				Initialize();
				if (_categoryIds == null)
				{
					return EmptyObjects<string>.array;
				}
				string[] array = new string[_categoryIds.Length];
				for (int i = 0; i < _categoryIds.Length; i++)
				{
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryIds[i]);
					array[i] = ((mapCategory != null) ? mapCategory.name : "INVALID");
				}
				return array;
			}
			set
			{
				if (!ReInput.isReady)
				{
					_preInitCategoryNames = ((value != null && value.Length != 0) ? value : null);
					_categoryIds = EmptyObjects<int>.array;
					return;
				}
				if (value == null || value.Length == 0)
				{
					_preInitCategoryNames = null;
					_categoryIds = EmptyObjects<int>.array;
					return;
				}
				List<int> list = new List<int>(value.Length);
				for (int i = 0; i < value.Length; i++)
				{
					if (!string.IsNullOrEmpty(value[i]))
					{
						int mapCategoryId = ReInput.mapping.GetMapCategoryId(value[i]);
						if (mapCategoryId >= 0)
						{
							list.Add(mapCategoryId);
						}
						else
						{
							Logger.LogWarning("Map Category \"" + value[i] + "\" does not exist.");
						}
					}
				}
				_categoryIds = list.ToArray();
			}
		}

		public string layoutName
		{
			get
			{
				if (!ReInput.isReady)
				{
					return _preInitLayoutName;
				}
				Initialize();
				InputLayout layout = ReInput.mapping.GetLayout(controllerSetSelector.controllerType, _layoutId);
				if (layout == null)
				{
					return "INVALID";
				}
				return layout.name;
			}
			set
			{
				if (!ReInput.isReady)
				{
					_preInitLayoutName = value;
					_layoutId = -1;
					return;
				}
				if (string.IsNullOrEmpty(value))
				{
					_preInitLayoutName = null;
					_layoutId = -1;
					return;
				}
				layoutId = ReInput.mapping.GetLayoutId(controllerSetSelector.controllerType, value);
				if (_layoutId < 0)
				{
					Logger.LogWarning(controllerSetSelector.controllerType.ToString() + " Layout \"" + value + "\" does not exist.");
				}
			}
		}

		internal bool isValid
		{
			get
			{
				if (_controllerSetSelector == null)
				{
					return false;
				}
				Initialize();
				if (_categoryIds == null || _categoryIds.Length == 0)
				{
					return false;
				}
				if (!ReInput.isReady)
				{
					if (_categoryIds[0] >= 0)
					{
						return _layoutId >= 0;
					}
					return false;
				}
				bool flag = false;
				for (int i = 0; i < _categoryIds.Length; i++)
				{
					if (ReInput.mapping.GetMapCategory(_categoryIds[i]) != null)
					{
						flag = true;
					}
				}
				if (!flag)
				{
					return false;
				}
				return ReInput.mapping.GetLayout(_controllerSetSelector.controllerType, _layoutId) != null;
			}
		}

		public Rule()
		{
			_categoryIds = EmptyObjects<int>.array;
			_layoutId = -1;
			_controllerSetSelector = new ControllerSetSelector(ControllerSetSelector.Type.ControllerType);
		}

		public Rule(Rule P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			_tag = P_0._tag;
			_categoryIds = ArrayTools.ShallowCopy(P_0._categoryIds);
			_layoutId = P_0._layoutId;
			_controllerSetSelector = MiscTools.DeepClone(P_0._controllerSetSelector);
			_preInitCategoryNames = ArrayTools.ShallowCopy(P_0._preInitCategoryNames);
			_preInitLayoutName = P_0._preInitLayoutName;
		}

		internal Rule(string P_0, int[] P_1, int P_2, ControllerSetSelector P_3)
		{
			_tag = P_0;
			_categoryIds = P_1;
			_layoutId = P_2;
			_controllerSetSelector = P_3;
		}

		private void Initialize()
		{
			if (!ReInput.isReady || _controllerSetSelector == null)
			{
				return;
			}
			if (_categoryIds == null)
			{
				_categoryIds = EmptyObjects<int>.array;
			}
			if (_preInitCategoryNames != null && _preInitCategoryNames.Length != 0)
			{
				List<int> list = new List<int>(_preInitCategoryNames.Length);
				for (int i = 0; i < _preInitCategoryNames.Length; i++)
				{
					if (!string.IsNullOrEmpty(_preInitCategoryNames[i]))
					{
						int mapCategoryId = ReInput.mapping.GetMapCategoryId(_preInitCategoryNames[i]);
						if (mapCategoryId >= 0)
						{
							list.Add(mapCategoryId);
						}
						else
						{
							Logger.LogWarning("Map Category \"" + _preInitCategoryNames[i] + "\" does not exist.");
						}
					}
				}
				_categoryIds = list.ToArray();
				_preInitCategoryNames = null;
			}
			if (!string.IsNullOrEmpty(_preInitLayoutName))
			{
				layoutName = _preInitLayoutName;
				_preInitLayoutName = null;
			}
		}

		object IDeepCloneable.DeepClone()
		{
			return new Rule(this);
		}
	}

	[Serializable]
	[DefaultMember("Item")]
	[Preserve]
	[SerializationType(SerializationTypeAttribute.SerializationType.Object)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class RuleSet : IList<Rule>, ICollection<Rule>, IEnumerable<Rule>, IEnumerable, IDeepCloneable
	{
		private const string className = "ControllerMapLayoutManager.RuleSet";

		[SerializeField]
		[Serialize(Name = "enabled")]
		private bool _enabled;

		[SerializeField]
		[Serialize(Name = "tag")]
		private string _tag;

		[SerializeField]
		[Serialize(Name = "rules")]
		private List<Rule> _rules;

		public bool enabled
		{
			get
			{
				return _enabled;
			}
			set
			{
				_enabled = value;
			}
		}

		public string tag
		{
			get
			{
				return _tag;
			}
			set
			{
				_tag = value;
			}
		}

		public List<Rule> rules
		{
			get
			{
				return _rules;
			}
			set
			{
				_rules = value;
				CheckList();
			}
		}

		Rule IList<Rule>.this[int index]
		{
			get
			{
				return get_Item(index);
			}
			set
			{
				set_Item(index, value);
			}
		}

		int ICollection<Rule>.Count => get_Count();

		bool ICollection<Rule>.IsReadOnly
		{
			get
			{
				CheckList();
				return ((ICollection<Rule>)_rules).IsReadOnly;
			}
		}

		internal RuleSet(bool P_0, string P_1, List<Rule> P_2)
			: this()
		{
			_enabled = P_0;
			_tag = P_1;
			_rules = P_2;
			CheckList();
		}

		public RuleSet()
		{
			_enabled = true;
			_rules = new List<Rule>();
		}

		public RuleSet(RuleSet P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("source");
			}
			_enabled = P_0._enabled;
			_tag = P_0._tag;
			_rules = MiscTools.DeepClone(P_0._rules);
			CheckList();
		}

		public Rule Find(Predicate<Rule> predicate)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			int num = ((_rules != null) ? _rules.Count : 0);
			for (int i = 0; i < num; i++)
			{
				try
				{
					if (predicate(_rules[i]))
					{
						return _rules[i];
					}
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ControllerMapLayoutManager.RuleSet.Find", exception);
				}
			}
			return null;
		}

		public Rule FindLast(Predicate<Rule> predicate)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			for (int num = ((_rules != null) ? _rules.Count : 0) - 1; num >= 0; num--)
			{
				try
				{
					if (predicate(_rules[num]))
					{
						return _rules[num];
					}
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ControllerMapLayoutManager.RuleSet.FindLast", exception);
				}
			}
			return null;
		}

		public int FindIndex(Predicate<Rule> predicate)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			int num = ((_rules != null) ? _rules.Count : 0);
			for (int i = 0; i < num; i++)
			{
				try
				{
					if (predicate(_rules[i]))
					{
						return i;
					}
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ControllerMapLayoutManager.RuleSet.FindIndex", exception);
				}
			}
			return -1;
		}

		public int FindLastIndex(Predicate<Rule> predicate)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			for (int num = ((_rules != null) ? _rules.Count : 0) - 1; num >= 0; num--)
			{
				try
				{
					if (predicate(_rules[num]))
					{
						return num;
					}
				}
				catch (Exception exception)
				{
					ReInput.HandleCallbackException("ControllerMapLayoutManager.RuleSet.FindLastIndex", exception);
				}
			}
			return -1;
		}

		public int IndexOf(Rule item)
		{
			CheckList();
			return _rules.Count;
		}

		int IList<Rule>.IndexOf(Rule item)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IndexOf
			return this.IndexOf(item);
		}

		public void Insert(int index, Rule item)
		{
			CheckList();
			_rules.Insert(index, item);
		}

		void IList<Rule>.Insert(int index, Rule item)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Insert
			this.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			CheckList();
			_rules.RemoveAt(index);
		}

		void IList<Rule>.RemoveAt(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in RemoveAt
			this.RemoveAt(index);
		}

		public Rule get_Item(int index)
		{
			CheckList();
			return _rules[index];
		}

		public void set_Item(int index, Rule value)
		{
			CheckList();
			_rules[index] = value;
		}

		public void Add(Rule item)
		{
			CheckList();
			_rules.Add(item);
		}

		void ICollection<Rule>.Add(Rule item)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Add
			this.Add(item);
		}

		public void Clear()
		{
			CheckList();
			_rules.Clear();
		}

		void ICollection<Rule>.Clear()
		{
			//ILSpy generated this explicit interface implementation from .override directive in Clear
			this.Clear();
		}

		public bool Contains(Rule item)
		{
			CheckList();
			return _rules.Contains(item);
		}

		bool ICollection<Rule>.Contains(Rule item)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Contains
			return this.Contains(item);
		}

		public void CopyTo(Rule[] array, int arrayIndex)
		{
			CheckList();
			_rules.CopyTo(array, arrayIndex);
		}

		void ICollection<Rule>.CopyTo(Rule[] array, int arrayIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in CopyTo
			this.CopyTo(array, arrayIndex);
		}

		public int get_Count()
		{
			CheckList();
			return _rules.Count;
		}

		public bool Remove(Rule item)
		{
			CheckList();
			return _rules.Remove(item);
		}

		bool ICollection<Rule>.Remove(Rule item)
		{
			//ILSpy generated this explicit interface implementation from .override directive in Remove
			return this.Remove(item);
		}

		public IEnumerator<Rule> GetEnumerator()
		{
			CheckList();
			return _rules.GetEnumerator();
		}

		IEnumerator<Rule> IEnumerable<Rule>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
			return this.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			CheckList();
			return _rules.GetEnumerator();
		}

		object IDeepCloneable.DeepClone()
		{
			return new RuleSet(this);
		}

		private void CheckList()
		{
			if (_rules == null)
			{
				_rules = new List<Rule>();
			}
		}
	}

	private bool QBrXRvFsNPEWPozJulDagFMyRPXm;

	private bool AgthlzLDggGeDjQkZafwgHmbroXF = true;

	private Player DJYhbByJjVSBQZLfbhzITNDNqPvy;

	private cUhsarZCgVkkiQMvHfbBJdlcDTAR LjAhxreUqWegcFLynNzwXpFXczVJ;

	private readonly int EsHxsiWLUZDPxQmKFcJTEnMyOINy;

	private List<RuleSet> GDhKMCAqOcbprHpqiNOYqakOSpBW;

	private Action DOjxaMBFiQKmopjdFWlBRgWDKaTD;

	public bool enabled
	{
		get
		{
			return QBrXRvFsNPEWPozJulDagFMyRPXm;
		}
		set
		{
			QBrXRvFsNPEWPozJulDagFMyRPXm = value;
			if (value)
			{
				Apply();
			}
		}
	}

	public bool loadFromUserDataStore
	{
		get
		{
			return AgthlzLDggGeDjQkZafwgHmbroXF;
		}
		set
		{
			AgthlzLDggGeDjQkZafwgHmbroXF = value;
		}
	}

	public List<RuleSet> ruleSets
	{
		get
		{
			return GDhKMCAqOcbprHpqiNOYqakOSpBW;
		}
		set
		{
			if (value == null)
			{
				value = new List<RuleSet>();
			}
			GDhKMCAqOcbprHpqiNOYqakOSpBW = value;
		}
	}

	internal event Action MwGIHkPPvDMZgrzhOvUVjwbnbSMW
	{
		add
		{
			kpNmQoKgmWzBsTcXLarOIjLlkVqo(action);
		}
		remove
		{
			tBDnmfyYxGIKjCJGNjNecboKwEqtA(action);
		}
	}

	internal void kpNmQoKgmWzBsTcXLarOIjLlkVqo(Action P_0)
	{
		DOjxaMBFiQKmopjdFWlBRgWDKaTD = (Action)Delegate.Combine(DOjxaMBFiQKmopjdFWlBRgWDKaTD, P_0);
	}

	internal void tBDnmfyYxGIKjCJGNjNecboKwEqtA(Action P_0)
	{
		DOjxaMBFiQKmopjdFWlBRgWDKaTD = (Action)Delegate.Remove(DOjxaMBFiQKmopjdFWlBRgWDKaTD, P_0);
	}

	internal ControllerMapLayoutManager(Player P_0, cUhsarZCgVkkiQMvHfbBJdlcDTAR P_1)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("player");
		}
		if (P_1 == null)
		{
			throw new ArgumentNullException("startingSettings");
		}
		EsHxsiWLUZDPxQmKFcJTEnMyOINy = ReInput.id;
		DJYhbByJjVSBQZLfbhzITNDNqPvy = P_0;
		LjAhxreUqWegcFLynNzwXpFXczVJ = P_1;
	}

	public void Apply()
	{
		if (ReInput._id != EsHxsiWLUZDPxQmKFcJTEnMyOINy)
		{
			ReInput.CheckInitialized(EsHxsiWLUZDPxQmKFcJTEnMyOINy);
			return;
		}
		DOjxaMBFiQKmopjdFWlBRgWDKaTD?.Invoke();
		if (!QBrXRvFsNPEWPozJulDagFMyRPXm || GDhKMCAqOcbprHpqiNOYqakOSpBW == null)
		{
			return;
		}
		int count = GDhKMCAqOcbprHpqiNOYqakOSpBW.Count;
		if (count == 0)
		{
			return;
		}
		using TempListPool.TList<ControllerMap> tList = TempListPool.GetTList<ControllerMap>();
		List<ControllerMap> list = tList.list;
		using TempListPool.TList<Controller> tList2 = TempListPool.GetTList<Controller>();
		List<Controller> list2 = tList2.list;
		if (!list2.Contains(ReInput.controllers.Keyboard))
		{
			list2.Add(ReInput.controllers.Keyboard);
		}
		if (!list2.Contains(ReInput.controllers.Mouse))
		{
			list2.Add(ReInput.controllers.Mouse);
		}
		DJYhbByJjVSBQZLfbhzITNDNqPvy.controllers.maps.GetAllMaps(list);
		list2.AddRange(DJYhbByJjVSBQZLfbhzITNDNqPvy.controllers.Controllers);
		IControllerMapStore controllerMapStore = ReInput.userDataStore as IControllerMapStore;
		for (int i = 0; i < count; i++)
		{
			RuleSet ruleSet = GDhKMCAqOcbprHpqiNOYqakOSpBW[i];
			if (ruleSet == null || !ruleSet.enabled)
			{
				continue;
			}
			int count2 = ruleSet.get_Count();
			for (int j = 0; j < count2; j++)
			{
				Rule rule = ruleSet.get_Item(j);
				if (rule == null || !rule.isValid)
				{
					continue;
				}
				for (int num = list.Count - 1; num >= 0; num--)
				{
					ControllerMap controllerMap = list[num];
					if (rule.controllerSetSelector.Matches(controllerMap.controller) && ArrayTools.Contains(rule.categoryIds, controllerMap.categoryId) && controllerMap.layoutId != rule.layoutId)
					{
						list.RemoveAt(num);
						DJYhbByJjVSBQZLfbhzITNDNqPvy.controllers.maps.RemoveMap(controllerMap.controllerType, controllerMap.controllerId, controllerMap.id);
					}
				}
				foreach (Controller controller in DJYhbByJjVSBQZLfbhzITNDNqPvy.controllers.Controllers)
				{
					if (!rule.controllerSetSelector.Matches(controller))
					{
						continue;
					}
					int[] categoryIds = rule.categoryIds;
					for (int k = 0; k < categoryIds.Length; k++)
					{
						ControllerMap controllerMap2 = DJYhbByJjVSBQZLfbhzITNDNqPvy.controllers.maps.GetMap(controller, categoryIds[k], rule.layoutId);
						if (controllerMap2 != null)
						{
							continue;
						}
						if (AgthlzLDggGeDjQkZafwgHmbroXF && controllerMapStore != null)
						{
							try
							{
								controllerMap2 = controllerMapStore.LoadControllerMap(DJYhbByJjVSBQZLfbhzITNDNqPvy.id, controller.identifier, categoryIds[k], rule.layoutId);
							}
							catch (Exception exception)
							{
								ReInput.HandleExternalInterfaceException(typeof(ControllerMapLayoutManager).Name, exception);
							}
							if (controllerMap2 != null)
							{
								DJYhbByJjVSBQZLfbhzITNDNqPvy.controllers.maps.AddMap(controller, controllerMap2);
								continue;
							}
						}
						DJYhbByJjVSBQZLfbhzITNDNqPvy.controllers.maps.LoadMap(controller.type, controller.id, categoryIds[k], rule.layoutId, startEnabled: true);
					}
				}
			}
		}
	}

	public void LoadDefaults()
	{
		if (ReInput._id != EsHxsiWLUZDPxQmKFcJTEnMyOINy)
		{
			ReInput.CheckInitialized(EsHxsiWLUZDPxQmKFcJTEnMyOINy);
			return;
		}
		List<RuleSet> list = new List<RuleSet>();
		int num = ((LjAhxreUqWegcFLynNzwXpFXczVJ != null && LjAhxreUqWegcFLynNzwXpFXczVJ.dUqJlNtdRaQmydQGlxBjDZBpfEoL != null) ? LjAhxreUqWegcFLynNzwXpFXczVJ.dUqJlNtdRaQmydQGlxBjDZBpfEoL.Length : 0);
		for (int i = 0; i < num; i++)
		{
			RuleSet controllerMapLayoutManagerRuleSetInstance = ReInput.mapping.GetControllerMapLayoutManagerRuleSetInstance(LjAhxreUqWegcFLynNzwXpFXczVJ.dUqJlNtdRaQmydQGlxBjDZBpfEoL[i].EhKltrLWcDOhyQRnmiwRcxArXCkg());
			if (controllerMapLayoutManagerRuleSetInstance == null)
			{
				Logger.LogError("Invalid Layout Manager Rule Set is assigned to Player. This should not be possible. If you are seeing this error, this is a sign of serialized data corruption, usually caused by a bad source control merge.");
				continue;
			}
			controllerMapLayoutManagerRuleSetInstance.enabled = LjAhxreUqWegcFLynNzwXpFXczVJ.dUqJlNtdRaQmydQGlxBjDZBpfEoL[i].VHnKGLVzvRfFlusbXSTLdEPcRyEC();
			list.Add(controllerMapLayoutManagerRuleSetInstance);
		}
		if (LjAhxreUqWegcFLynNzwXpFXczVJ != null)
		{
			QBrXRvFsNPEWPozJulDagFMyRPXm = LjAhxreUqWegcFLynNzwXpFXczVJ.bBFSAhKuzSrUzgVwYwNCqIUSUVZd;
			AgthlzLDggGeDjQkZafwgHmbroXF = LjAhxreUqWegcFLynNzwXpFXczVJ.VoRTsWAezQQeJJasfLCIbIWdEQTG;
		}
		GDhKMCAqOcbprHpqiNOYqakOSpBW = list;
		Apply();
	}

	public string ToXmlString()
	{
		if (ReInput._id != EsHxsiWLUZDPxQmKFcJTEnMyOINy)
		{
			ReInput.CheckInitialized(EsHxsiWLUZDPxQmKFcJTEnMyOINy);
			return string.Empty;
		}
		try
		{
			return lnWmAgfRHBMpxRNSjIlGYclFcCgfA().ToXmlString(writeDocumentTag: true);
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
			return string.Empty;
		}
	}

	public string ToJsonString()
	{
		if (ReInput._id != EsHxsiWLUZDPxQmKFcJTEnMyOINy)
		{
			ReInput.CheckInitialized(EsHxsiWLUZDPxQmKFcJTEnMyOINy);
			return string.Empty;
		}
		try
		{
			return lnWmAgfRHBMpxRNSjIlGYclFcCgfA().ToJsonString();
		}
		catch (Exception ex)
		{
			Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
			return string.Empty;
		}
	}

	public bool ImportXml(string xmlString)
	{
		if (ReInput._id != EsHxsiWLUZDPxQmKFcJTEnMyOINy)
		{
			ReInput.CheckInitialized(EsHxsiWLUZDPxQmKFcJTEnMyOINy);
			return false;
		}
		try
		{
			lhlrvVlfXLtCkMULDeSzQCQQWAQR(SerializedObject.FromXml(GetType(), xmlString));
			Apply();
			return true;
		}
		catch (Exception ex)
		{
			Logger.LogError("Error importing " + GetType().Name + " data from XML. " + ex.Message);
			return false;
		}
	}

	public bool ImportJson(string jsonString)
	{
		if (ReInput._id != EsHxsiWLUZDPxQmKFcJTEnMyOINy)
		{
			ReInput.CheckInitialized(EsHxsiWLUZDPxQmKFcJTEnMyOINy);
			return false;
		}
		try
		{
			lhlrvVlfXLtCkMULDeSzQCQQWAQR(SerializedObject.FromJson(GetType(), jsonString));
			Apply();
			return true;
		}
		catch (Exception ex)
		{
			Logger.LogError("Error importing " + GetType().Name + " data from JSON. " + ex.Message);
			return false;
		}
	}

	private SerializedObject lnWmAgfRHBMpxRNSjIlGYclFcCgfA()
	{
		SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
		JyWIhdLKXKeAgtkFwyceISVZAnVM(serializedObject);
		return serializedObject;
	}

	private void JyWIhdLKXKeAgtkFwyceISVZAnVM(SerializedObject P_0)
	{
		if (P_0.xmlInfo == null)
		{
			P_0.xmlInfo = new SerializedObject.XmlInfo();
		}
		P_0.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
		P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.hDUwNfLYRsDfBMVYhNNeoTRkzGbG
		{
			MutqyAFuCjIZnSTNtUBAVEJnuQVU = "dataVersion",
			TGWZwlpMZfNRNCdsoptLnolSpctw = 1.ToString()
		});
		P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.hDUwNfLYRsDfBMVYhNNeoTRkzGbG
		{
			lzZvWcSBFLIaPeQCcDYWrLhMPUfsA = "xmlns",
			MutqyAFuCjIZnSTNtUBAVEJnuQVU = "xsi",
			afJFISBmEARIUnwOMVvxEtRhSwGz = null,
			TGWZwlpMZfNRNCdsoptLnolSpctw = "http://www.w3.org/2001/XMLSchema-instance"
		});
		P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.hDUwNfLYRsDfBMVYhNNeoTRkzGbG
		{
			lzZvWcSBFLIaPeQCcDYWrLhMPUfsA = "xsi",
			MutqyAFuCjIZnSTNtUBAVEJnuQVU = "schemaLocation",
			afJFISBmEARIUnwOMVvxEtRhSwGz = null,
			TGWZwlpMZfNRNCdsoptLnolSpctw = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.0", "/", GetType().Name, ".xsd")
		});
		P_0.Add("enabled", QBrXRvFsNPEWPozJulDagFMyRPXm);
		P_0.Add("loadFromUserDataStore", AgthlzLDggGeDjQkZafwgHmbroXF);
		P_0.Add("ruleSets", GDhKMCAqOcbprHpqiNOYqakOSpBW);
	}

	private bool lhlrvVlfXLtCkMULDeSzQCQQWAQR(SerializedObject P_0)
	{
		QBrXRvFsNPEWPozJulDagFMyRPXm = false;
		GDhKMCAqOcbprHpqiNOYqakOSpBW = null;
		P_0.TryGetDeserializedValueByRef("enabled", ref QBrXRvFsNPEWPozJulDagFMyRPXm);
		P_0.TryGetDeserializedValueByRef("loadFromUserDataStore", ref AgthlzLDggGeDjQkZafwgHmbroXF);
		List<RuleSet> value = new List<RuleSet>();
		P_0.TryGetDeserializedValueByRef("ruleSets", ref value);
		GDhKMCAqOcbprHpqiNOYqakOSpBW = value;
		return true;
	}
}
