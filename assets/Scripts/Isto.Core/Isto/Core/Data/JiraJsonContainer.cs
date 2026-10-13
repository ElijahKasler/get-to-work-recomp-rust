using System;

namespace Isto.Core.Data;

public class JiraJsonContainer
{
	[Serializable]
	public class JiraFields
	{
		public JiraProject project;

		public string summary;

		public string description;

		public string environment;

		public JiraIssueType issuetype;
	}

	[Serializable]
	public class JiraProject
	{
		public string key;
	}

	[Serializable]
	public class JiraIssueType
	{
		public string name;
	}

	public JiraFields fields;
}
