namespace Unity.XGamingRuntime.Interop;

internal struct XblTournamentTeamResult
{
	internal readonly UTF8StringPtr Team;

	internal readonly XblTournamentGameResultWithRank GameResult;

	internal XblTournamentTeamResult(Unity.XGamingRuntime.XblTournamentTeamResult publicObject, DisposableCollection disposableCollection)
	{
		Team = new UTF8StringPtr(publicObject.Team, disposableCollection);
		GameResult = new XblTournamentGameResultWithRank(publicObject.GameResult);
	}
}
