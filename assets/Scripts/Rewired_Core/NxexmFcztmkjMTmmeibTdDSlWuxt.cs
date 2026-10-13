using System;
using Rewired;

internal sealed class NxexmFcztmkjMTmmeibTdDSlWuxt : IControllerTemplateElementSource, IControllerTemplateAxisSource, IControllerTemplateButtonSource
{
	private ControllerTemplateElementType yKsgZwaTiIvNjjoCdTxmDHMloBrZA;

	private bool qWhLnLoiYqOiXKUdWBChpprTScJV;

	private IControllerElementTarget dJZKNIVlLIIQIgjygazyoTSJmbGBA;

	private IControllerElementTarget hAULpsqMGNImPVOHividobzklxZq;

	private IControllerElementTarget PoftxKsdGghKwinsYvSrCWJtDoeeb;

	ControllerTemplateElementSourceType IControllerTemplateElementSource.type => IyPmashUlRgIygDiHFyDZHZmauql.RbkBheAnNaEpuEggOOeBPsWGOQw(yKsgZwaTiIvNjjoCdTxmDHMloBrZA, false);

	bool IControllerTemplateAxisSource.splitAxis => qWhLnLoiYqOiXKUdWBChpprTScJV;

	IControllerElementTarget IControllerTemplateAxisSource.fullTarget => dJZKNIVlLIIQIgjygazyoTSJmbGBA;

	IControllerElementTarget IControllerTemplateAxisSource.positiveTarget => hAULpsqMGNImPVOHividobzklxZq;

	IControllerElementTarget IControllerTemplateAxisSource.negativeTarget => PoftxKsdGghKwinsYvSrCWJtDoeeb;

	IControllerElementTarget IControllerTemplateButtonSource.target => dJZKNIVlLIIQIgjygazyoTSJmbGBA;

	internal NxexmFcztmkjMTmmeibTdDSlWuxt(ControllerTemplateElementType P_0, bool P_1, IControllerElementTarget P_2, IControllerElementTarget P_3, IControllerElementTarget P_4)
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("target");
		}
		if (P_4 == null)
		{
			throw new ArgumentNullException("positiveTarget");
		}
		if (P_3 == null)
		{
			throw new ArgumentNullException("negativeTarget");
		}
		yKsgZwaTiIvNjjoCdTxmDHMloBrZA = P_0;
		qWhLnLoiYqOiXKUdWBChpprTScJV = P_1;
		dJZKNIVlLIIQIgjygazyoTSJmbGBA = P_2;
		hAULpsqMGNImPVOHividobzklxZq = P_3;
		PoftxKsdGghKwinsYvSrCWJtDoeeb = P_4;
	}

	internal static NxexmFcztmkjMTmmeibTdDSlWuxt AwJyFZSwQefPsVvLcjELYDJqdsFB(ControllerTemplateElementType P_0)
	{
		return new NxexmFcztmkjMTmmeibTdDSlWuxt(P_0, false, edomyHoabKkWzxLwelGsLkZrDlzw.mHYNZIULtvOBtTVRcToMsSDSvYEJ(), edomyHoabKkWzxLwelGsLkZrDlzw.mHYNZIULtvOBtTVRcToMsSDSvYEJ(), edomyHoabKkWzxLwelGsLkZrDlzw.mHYNZIULtvOBtTVRcToMsSDSvYEJ());
	}
}
