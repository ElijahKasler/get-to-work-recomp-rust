using System;
using Rewired.Internal.Localization;
using Rewired.Utils.Classes.Data;

internal sealed class NSbrwSqxkQipOgPUDCHONhtFYAor : OxefyMfZIgXEzbqjvpxteWerzayF, IDisposable
{
	private Action KmhBkMnrjTETNeTGomyimNtNjemFb;

	private Id teoPEkxqOUMgTYPreGBfQZfPbLUC;

	private bool CdpBElBBTAUvmzeWgaVFowHQHSUdA;

	public NSbrwSqxkQipOgPUDCHONhtFYAor(Action P_0)
	{
		KmhBkMnrjTETNeTGomyimNtNjemFb = P_0;
		teoPEkxqOUMgTYPreGBfQZfPbLUC = 0u;
		LocalizationManager.Add(this, ref teoPEkxqOUMgTYPreGBfQZfPbLUC);
	}

	void OxefyMfZIgXEzbqjvpxteWerzayF.Localize()
	{
		KmhBkMnrjTETNeTGomyimNtNjemFb();
	}

	private void crdbBpSEtXiRWlmEzPNNAWQbIfyO(bool P_0)
	{
		if (!CdpBElBBTAUvmzeWgaVFowHQHSUdA)
		{
			if (P_0)
			{
				LocalizationManager.Remove(ref teoPEkxqOUMgTYPreGBfQZfPbLUC);
			}
			CdpBElBBTAUvmzeWgaVFowHQHSUdA = true;
		}
	}

	public void Dispose()
	{
		crdbBpSEtXiRWlmEzPNNAWQbIfyO(true);
		GC.SuppressFinalize(this);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}
}
