namespace UnityEngine.UIElements;

public static class UIToolkitInputConfiguration
{
	public static void SetRuntimeInputBackend(UIToolkitInputBackendOption backend)
	{
		UIElementsRuntimeUtility.defaultEventSystem.useInputForUI = backend != UIToolkitInputBackendOption.LegacyBackend;
	}
}
