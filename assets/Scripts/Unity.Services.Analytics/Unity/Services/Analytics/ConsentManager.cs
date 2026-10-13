using System;

namespace Unity.Services.Analytics;

internal class ConsentManager : IConsentManager
{
	public bool UsingOriginalFlow { get; private set; }

	public bool UsingDataFrameworkFlow { get; private set; }

	public bool DataFrameworkConsentGranted { get; private set; }

	public event Action ConsentGranted;

	public event Action ConsentRevoked;

	public void LockInOriginalFlow()
	{
		UsingOriginalFlow = true;
	}

	internal void Initialize()
	{
		LockInOriginalFlow();
	}
}
