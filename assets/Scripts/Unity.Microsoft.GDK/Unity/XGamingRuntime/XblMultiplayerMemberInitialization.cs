using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class XblMultiplayerMemberInitialization
{
	public ulong JoinTimeout { get; }

	public ulong MeasurementTimeout { get; }

	public ulong EvaluationTimeout { get; }

	public bool ExternalEvaluation { get; }

	public uint MembersNeededToStart { get; }

	internal XblMultiplayerMemberInitialization(Unity.XGamingRuntime.Interop.XblMultiplayerMemberInitialization interopStruct)
	{
		JoinTimeout = interopStruct.JoinTimeout;
		MeasurementTimeout = interopStruct.MeasurementTimeout;
		EvaluationTimeout = interopStruct.EvaluationTimeout;
		ExternalEvaluation = interopStruct.ExternalEvaluation.Value;
		MembersNeededToStart = interopStruct.MembersNeededToStart;
	}
}
