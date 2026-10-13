using System;
using System.Globalization;
using Isto.Core.Data;

namespace Isto.Core.BugReportingTool;

public static class JiraBugTypeConverter
{
	public static JiraJsonContainer JiraBugDataToJiraJsonContainer(JiraBugData jiraBugData, JiraUser currentJiraUser)
	{
		JiraJsonContainer jiraJsonContainer = new JiraJsonContainer();
		JiraJsonContainer.JiraProject project = new JiraJsonContainer.JiraProject
		{
			key = currentJiraUser.JiraProjectKey
		};
		JiraJsonContainer.JiraIssueType issuetype = new JiraJsonContainer.JiraIssueType
		{
			name = "Bug"
		};
		jiraJsonContainer.fields = new JiraJsonContainer.JiraFields
		{
			project = project,
			summary = jiraBugData.Title,
			description = CreateDescription(jiraBugData),
			environment = CreateEnvironment(jiraBugData),
			issuetype = issuetype
		};
		return jiraJsonContainer;
	}

	private static string CreateEnvironment(JiraBugData jiraBugData)
	{
		return "{panel:bgColor=#E9EAEF}\n* *Reported by :* " + jiraBugData.ReportedBy + "\n* *Found in :* " + jiraBugData.RuntimeScenario + "\n* *Scene :* " + jiraBugData.CurrentScene + "\n* *Version :* " + jiraBugData.CurrentVersion + "\n* *Date :* " + FormatDate(jiraBugData.Date) + "\n{panel}";
	}

	private static string CreateDescription(JiraBugData jiraBugData)
	{
		return jiraBugData.Description + "\nh2. +Repo Steps+ \n" + jiraBugData.ReproductionSteps + "\nh2. +Useful Info+ \n" + jiraBugData.UsefulInformation + "\n";
	}

	private static string FormatDate(string date)
	{
		DateTime dateTime = DateTime.Parse(date);
		string text = dateTime.ToString("MMM d, yyyy", CultureInfo.InvariantCulture);
		string text2 = dateTime.ToString("h:mm tt");
		return text + " at " + text2;
	}
}
