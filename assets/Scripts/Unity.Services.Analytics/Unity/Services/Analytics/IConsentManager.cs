using System;

namespace Unity.Services.Analytics;

internal interface IConsentManager
{
	bool UsingOriginalFlow { get; }

	bool UsingDataFrameworkFlow { get; }

	bool DataFrameworkConsentGranted { get; }

	event Action ConsentGranted;

	event Action ConsentRevoked;

	void LockInOriginalFlow();
}
