using Isto.Core.Achievements;
using Isto.Core.Configuration;
using Isto.Core.Localization;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

namespace Isto.Core;

public class CoreInitialization : MonoBehaviour
{
	[SerializeField]
	protected bool UseAddressables = true;

	protected VersionInfo VersionInfo;

	private IAchievements _achievements;

	private ILocalizationProvider _locProvider;

	[Inject]
	public void Inject(ILocalizationProvider locProvider, IAchievements achievements)
	{
		_locProvider = locProvider;
		_achievements = achievements;
	}

	protected virtual void Awake()
	{
		VersionInfo = VersionInfo.LoadFromResources();
		Debug.Log(Application.productName + " v" + VersionInfo.ActiveVersion.FullVersionText);
		if (UseAddressables)
		{
			InitializeAddressables();
		}
	}

	protected virtual void Start()
	{
		LanguageChanger.LanguageEnum currentLanguage = _locProvider.GetCurrentLanguage();
		_locProvider.SetLanguage(currentLanguage);
		_achievements.Initialize();
	}

	protected virtual void InitializePlayerPrefs()
	{
		Debug.Log("PlayerPrefs initialized.");
	}

	protected virtual void InitializeAddressables()
	{
		AsyncOperationHandle<IResourceLocator> asyncOperationHandle = Addressables.InitializeAsync();
		asyncOperationHandle.Completed += OnAddressablesInitialized;
	}

	private void OnAddressablesInitialized(AsyncOperationHandle<IResourceLocator> handle)
	{
		if (handle.Status == AsyncOperationStatus.Succeeded)
		{
			Debug.Log("Addressables initialized successfully!");
		}
		else
		{
			Debug.LogError("Failed to initialize Addressables!");
		}
	}
}
