using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Isto.Core.Data;

[Serializable]
public class JiraBugData
{
	public string ReportedBy;

	public string Title;

	public string Description;

	public string ReproductionSteps;

	public string UsefulInformation;

	public string ImageFilePath;

	public string RuntimeScenario;

	public string CurrentScene;

	public string CurrentVersion;

	public string Date;

	public JiraBugData()
	{
		RuntimeScenario = (Application.isEditor ? "Editor" : Application.platform.ToString());
		CurrentScene = SceneManager.GetActiveScene().name;
		CurrentVersion = Application.version;
		Date = DateTime.Now.ToString(CultureInfo.InvariantCulture);
	}
}
