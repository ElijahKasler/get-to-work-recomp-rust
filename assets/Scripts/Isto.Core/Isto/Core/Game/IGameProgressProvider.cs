using System.Collections.Generic;
using Isto.Core.Localization;

namespace Isto.Core.Game;

public interface IGameProgressProvider
{
	int GetCurrentGameProgressLevel();

	int GetMaxGameProgressLevel();

	bool IsLastProgressLevel();

	float GetGameSecondsElapsedInLevel(int progressLevel);

	float GetGameSecondsElapsedInCurrentProgressLevel();

	float GetTotalGameSecondsElapsedInPlaythrough();

	LocTerm GetGameProgressLevelName(int progressLevel);

	string GetGameProgressLevelInternalName(int progressLevel);

	void LoadLevelTimes(Dictionary<int, float> dictionary);
}
