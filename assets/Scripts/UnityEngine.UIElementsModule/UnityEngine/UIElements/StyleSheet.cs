using System;
using System.Collections.Generic;
using UnityEngine.Bindings;
using UnityEngine.UIElements.StyleSheets;

namespace UnityEngine.UIElements;

[Serializable]
[HelpURL("UIE-USS")]
public class StyleSheet : ScriptableObject
{
	[Serializable]
	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal struct ImportStruct
	{
		public StyleSheet styleSheet;

		public string[] mediaQueries;
	}

	internal enum OrderedSelectorType
	{
		None = -1,
		Name = 0,
		Type = 1,
		Class = 2,
		Length = 3
	}

	[SerializeField]
	private bool m_ImportedWithErrors;

	[SerializeField]
	private bool m_ImportedWithWarnings;

	[SerializeField]
	private StyleRule[] m_Rules;

	[SerializeField]
	private StyleComplexSelector[] m_ComplexSelectors;

	[SerializeField]
	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal float[] floats;

	[SerializeField]
	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal Dimension[] dimensions;

	[SerializeField]
	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal Color[] colors;

	[SerializeField]
	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal string[] strings;

	[SerializeField]
	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal Object[] assets;

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	[SerializeField]
	internal ImportStruct[] imports;

	[SerializeField]
	private List<StyleSheet> m_FlattenedImportedStyleSheets;

	[SerializeField]
	private int m_ContentHash;

	[SerializeField]
	internal ScalableImage[] scalableImages;

	[NonSerialized]
	internal Dictionary<string, StyleComplexSelector>[] tables;

	[NonSerialized]
	internal int nonEmptyTablesMask;

	[NonSerialized]
	internal StyleComplexSelector firstRootSelector;

	[NonSerialized]
	internal StyleComplexSelector firstWildCardSelector;

	[NonSerialized]
	private bool m_IsDefaultStyleSheet;

	private static string kCustomPropertyMarker = "--";

	public bool importedWithErrors
	{
		get
		{
			return m_ImportedWithErrors;
		}
		internal set
		{
			m_ImportedWithErrors = value;
		}
	}

	public bool importedWithWarnings
	{
		get
		{
			return m_ImportedWithWarnings;
		}
		internal set
		{
			m_ImportedWithWarnings = value;
		}
	}

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal StyleRule[] rules
	{
		get
		{
			return m_Rules;
		}
		set
		{
			m_Rules = value;
			SetupReferences();
		}
	}

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal StyleComplexSelector[] complexSelectors
	{
		get
		{
			return m_ComplexSelectors;
		}
		set
		{
			m_ComplexSelectors = value;
			SetupReferences();
		}
	}

	internal List<StyleSheet> flattenedRecursiveImports
	{
		[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
		get
		{
			return m_FlattenedImportedStyleSheets;
		}
	}

	public int contentHash
	{
		get
		{
			return m_ContentHash;
		}
		set
		{
			m_ContentHash = value;
		}
	}

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal bool isDefaultStyleSheet
	{
		get
		{
			return m_IsDefaultStyleSheet;
		}
		set
		{
			m_IsDefaultStyleSheet = value;
			if (flattenedRecursiveImports == null)
			{
				return;
			}
			foreach (StyleSheet flattenedRecursiveImport in flattenedRecursiveImports)
			{
				flattenedRecursiveImport.isDefaultStyleSheet = value;
			}
		}
	}

	private bool TryCheckAccess<T>(T[] list, StyleValueType type, StyleValueHandle handle, out T value)
	{
		bool result = false;
		value = default;
		if (handle.valueType == type && handle.valueIndex >= 0 && handle.valueIndex < list.Length)
		{
			value = list[handle.valueIndex];
			result = true;
		}
		else
		{
			Debug.LogErrorFormat(this, "Trying to read value of type {0} while reading a value of type {1}", type, handle.valueType);
		}
		return result;
	}

	private T CheckAccess<T>(T[] list, StyleValueType type, StyleValueHandle handle)
	{
		T result = default;
		if (handle.valueType != type)
		{
			Debug.LogErrorFormat(this, "Trying to read value of type {0} while reading a value of type {1}", type, handle.valueType);
		}
		else
		{
			if (list != null && handle.valueIndex >= 0 && handle.valueIndex < list.Length)
			{
				return list[handle.valueIndex];
			}
			Debug.LogError("Accessing invalid property", this);
		}
		return result;
	}

	internal virtual void OnEnable()
	{
		SetupReferences();
	}

	internal void FlattenImportedStyleSheetsRecursive()
	{
		m_FlattenedImportedStyleSheets = new List<StyleSheet>();
		FlattenImportedStyleSheetsRecursive(this);
	}

	private void FlattenImportedStyleSheetsRecursive(StyleSheet sheet)
	{
		if (sheet.imports == null)
		{
			return;
		}
		for (int i = 0; i < sheet.imports.Length; i++)
		{
			StyleSheet styleSheet = sheet.imports[i].styleSheet;
			if (!(styleSheet == null))
			{
				styleSheet.isDefaultStyleSheet = isDefaultStyleSheet;
				FlattenImportedStyleSheetsRecursive(styleSheet);
				m_FlattenedImportedStyleSheets.Add(styleSheet);
			}
		}
	}

	private void SetupReferences()
	{
		if (complexSelectors == null || rules == null)
		{
			return;
		}
		StyleRule[] array = rules;
		foreach (StyleRule styleRule in array)
		{
			StyleProperty[] properties = styleRule.properties;
			foreach (StyleProperty styleProperty in properties)
			{
				if (CustomStartsWith(styleProperty.name, kCustomPropertyMarker))
				{
					styleRule.customPropertiesCount++;
					styleProperty.isCustomProperty = true;
				}
				StyleValueHandle[] values = styleProperty.values;
				foreach (StyleValueHandle handle in values)
				{
					if (handle.IsVarFunction())
					{
						styleProperty.requireVariableResolve = true;
						break;
					}
				}
			}
		}
		int l = 0;
		for (int num = complexSelectors.Length; l < num; l++)
		{
			complexSelectors[l].CachePseudoStateMasks();
		}
		tables = new Dictionary<string, StyleComplexSelector>[3];
		tables[0] = new Dictionary<string, StyleComplexSelector>(StringComparer.Ordinal);
		tables[1] = new Dictionary<string, StyleComplexSelector>(StringComparer.Ordinal);
		tables[2] = new Dictionary<string, StyleComplexSelector>(StringComparer.Ordinal);
		nonEmptyTablesMask = 0;
		firstRootSelector = null;
		firstWildCardSelector = null;
		for (int m = 0; m < complexSelectors.Length; m++)
		{
			StyleComplexSelector styleComplexSelector = complexSelectors[m];
			if (styleComplexSelector.ruleIndex < rules.Length)
			{
				styleComplexSelector.rule = rules[styleComplexSelector.ruleIndex];
			}
			styleComplexSelector.CalculateHashes();
			styleComplexSelector.orderInStyleSheet = m;
			StyleSelector styleSelector = styleComplexSelector.selectors[styleComplexSelector.selectors.Length - 1];
			StyleSelectorPart styleSelectorPart = styleSelector.parts[0];
			string value = styleSelectorPart.value;
			OrderedSelectorType orderedSelectorType = OrderedSelectorType.None;
			switch (styleSelectorPart.type)
			{
			case StyleSelectorType.Class:
				orderedSelectorType = OrderedSelectorType.Class;
				break;
			case StyleSelectorType.ID:
				orderedSelectorType = OrderedSelectorType.Name;
				break;
			case StyleSelectorType.Type:
				value = styleSelectorPart.value;
				orderedSelectorType = OrderedSelectorType.Type;
				break;
			case StyleSelectorType.Wildcard:
				if (firstWildCardSelector != null)
				{
					styleComplexSelector.nextInTable = firstWildCardSelector;
				}
				firstWildCardSelector = styleComplexSelector;
				break;
			case StyleSelectorType.PseudoClass:
				if ((styleSelector.pseudoStateMask & 0x80) != 0)
				{
					if (firstRootSelector != null)
					{
						styleComplexSelector.nextInTable = firstRootSelector;
					}
					firstRootSelector = styleComplexSelector;
				}
				else
				{
					if (firstWildCardSelector != null)
					{
						styleComplexSelector.nextInTable = firstWildCardSelector;
					}
					firstWildCardSelector = styleComplexSelector;
				}
				break;
			default:
				Debug.LogError($"Invalid first part type {styleSelectorPart.type}", this);
				break;
			}
			if (orderedSelectorType != OrderedSelectorType.None)
			{
				Dictionary<string, StyleComplexSelector> dictionary = tables[(int)orderedSelectorType];
				if (dictionary.TryGetValue(value, out var value2))
				{
					styleComplexSelector.nextInTable = value2;
				}
				nonEmptyTablesMask |= 1 << (int)orderedSelectorType;
				dictionary[value] = styleComplexSelector;
			}
		}
	}

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal StyleValueKeyword ReadKeyword(StyleValueHandle handle)
	{
		return (StyleValueKeyword)handle.valueIndex;
	}

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal float ReadFloat(StyleValueHandle handle)
	{
		if (handle.valueType == StyleValueType.Dimension)
		{
			return CheckAccess(dimensions, StyleValueType.Dimension, handle).value;
		}
		return CheckAccess(floats, StyleValueType.Float, handle);
	}

	internal bool TryReadFloat(StyleValueHandle handle, out float value)
	{
		if (TryCheckAccess(floats, StyleValueType.Float, handle, out value))
		{
			return true;
		}
		bool result = TryCheckAccess(dimensions, StyleValueType.Float, handle, out var value2);
		value = value2.value;
		return result;
	}

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal Dimension ReadDimension(StyleValueHandle handle)
	{
		if (handle.valueType == StyleValueType.Float)
		{
			float value = CheckAccess(floats, StyleValueType.Float, handle);
			return new Dimension(value, Dimension.Unit.Unitless);
		}
		return CheckAccess(dimensions, StyleValueType.Dimension, handle);
	}

	internal bool TryReadDimension(StyleValueHandle handle, out Dimension value)
	{
		if (TryCheckAccess(dimensions, StyleValueType.Dimension, handle, out value))
		{
			return true;
		}
		float value2 = 0f;
		bool result = TryCheckAccess(floats, StyleValueType.Float, handle, out value2);
		value = new Dimension(value2, Dimension.Unit.Unitless);
		return result;
	}

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal Color ReadColor(StyleValueHandle handle)
	{
		return CheckAccess(colors, StyleValueType.Color, handle);
	}

	internal bool TryReadColor(StyleValueHandle handle, out Color value)
	{
		return TryCheckAccess(colors, StyleValueType.Color, handle, out value);
	}

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal string ReadString(StyleValueHandle handle)
	{
		return CheckAccess(strings, StyleValueType.String, handle);
	}

	internal bool TryReadString(StyleValueHandle handle, out string value)
	{
		return TryCheckAccess(strings, StyleValueType.String, handle, out value);
	}

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal string ReadEnum(StyleValueHandle handle)
	{
		return CheckAccess(strings, StyleValueType.Enum, handle);
	}

	internal bool TryReadEnum(StyleValueHandle handle, out string value)
	{
		return TryCheckAccess(strings, StyleValueType.Enum, handle, out value);
	}

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal string ReadVariable(StyleValueHandle handle)
	{
		return CheckAccess(strings, StyleValueType.Variable, handle);
	}

	internal bool TryReadVariable(StyleValueHandle handle, out string value)
	{
		return TryCheckAccess(strings, StyleValueType.Variable, handle, out value);
	}

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal string ReadResourcePath(StyleValueHandle handle)
	{
		return CheckAccess(strings, StyleValueType.ResourcePath, handle);
	}

	internal bool TryReadResourcePath(StyleValueHandle handle, out string value)
	{
		return TryCheckAccess(strings, StyleValueType.ResourcePath, handle, out value);
	}

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal Object ReadAssetReference(StyleValueHandle handle)
	{
		return CheckAccess(assets, StyleValueType.AssetReference, handle);
	}

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal string ReadMissingAssetReferenceUrl(StyleValueHandle handle)
	{
		return CheckAccess(strings, StyleValueType.MissingAssetReference, handle);
	}

	internal bool TryReadAssetReference(StyleValueHandle handle, out Object value)
	{
		return TryCheckAccess(assets, StyleValueType.AssetReference, handle, out value);
	}

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal StyleValueFunction ReadFunction(StyleValueHandle handle)
	{
		return (StyleValueFunction)handle.valueIndex;
	}

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal string ReadFunctionName(StyleValueHandle handle)
	{
		if (handle.valueType != StyleValueType.Function)
		{
			Debug.LogErrorFormat(this, $"Trying to read value of type {StyleValueType.Function} while reading a value of type {handle.valueType}");
			return string.Empty;
		}
		StyleValueFunction valueIndex = (StyleValueFunction)handle.valueIndex;
		return valueIndex.ToUssString();
	}

	[VisibleToOtherModules(new string[] { "UnityEditor.UIBuilderModule" })]
	internal ScalableImage ReadScalableImage(StyleValueHandle handle)
	{
		return CheckAccess(scalableImages, StyleValueType.ScalableImage, handle);
	}

	private static bool CustomStartsWith(string originalString, string pattern)
	{
		int length = originalString.Length;
		int length2 = pattern.Length;
		int num = 0;
		int num2 = 0;
		while (num < length && num2 < length2 && originalString[num] == pattern[num2])
		{
			num++;
			num2++;
		}
		return (num2 == length2 && length >= length2) || (num == length && length2 >= length);
	}
}
