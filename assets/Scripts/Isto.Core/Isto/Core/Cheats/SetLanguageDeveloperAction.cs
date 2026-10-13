using System;
using System.Collections.Generic;
using Isto.Core.Enums;
using Isto.Core.Localization;
using UnityEngine;
using Zenject;

namespace Isto.Core.Cheats;

[CreateAssetMenu(fileName = "New Set Language Action", menuName = "Scriptables/Dev Mode Actions/Set Language Action")]
public class SetLanguageDeveloperAction : CheatAction
{
	public override void Activate(params object[] args)
	{
		LanguageChanger.SetLanguage(ExpandableEnum<StringEnum<LanguageChanger.LanguageEnum>, string>.GetFromName(args[0].ToString(), StringComparison.OrdinalIgnoreCase) as LanguageChanger.LanguageEnum);
	}

	public override void Deactivate()
	{
	}

	public override void OnUpdate()
	{
	}

	public override bool TryAutoCompleteParameters(string[] inputs, out string output)
	{
		List<string> languageNames = ProjectContext.Instance.Container.ResolveId<LanguageList>("SupportedLanguages").GetLanguageNames();
		return TryAutoCompleteFromList(inputs, languageNames, out output);
	}
}
