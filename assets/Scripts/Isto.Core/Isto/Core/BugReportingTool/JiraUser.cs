using UnityEngine;

namespace Isto.Core.BugReportingTool;

[CreateAssetMenu(fileName = "JiraUser-", menuName = "Isto/Core/New Jira User Login Data")]
public class JiraUser : ScriptableObject
{
	[Tooltip("Name of the user who is making the bug report.")]
	[SerializeField]
	private string _fullName = "isto";

	[Tooltip("Email the user is using for their Jira account.")]
	[SerializeField]
	private string _email = "istoincbuilds@outlook.com";

	[Tooltip("API token attached to the users account. Must be created on Jira and can be found here: https://id.atlassian.com/manage-profile/security/api-tokens")]
	[SerializeField]
	private string _jiraApiToken = "ATATT3xFfGF06i9q_FGbnsZ4YWYNYWtzf6YJihExgdBo27LDBDOMcUg0OavCRYar92e8A2mKikNgtbjcoRKRJHfCUdCmzg2UagnO7EUzxtl_WVLGq1KpKTTiUoeJva-vXJmHM2Jo29odsYNN-tq0TJ6Ohlo-ggOwPiQNelQdy4ES16zBks2CiQY=B6C9FE9E";

	[Tooltip("Project key attached to the given project. e.g. ATRIOBUG. Can be found here: https://istoinc.atlassian.net/jira/projects")]
	[SerializeField]
	private string _jiraProjectKey = "ATRIOBUG";

	public string FullName => _fullName;

	public string Email => _email;

	public string JiraApiToken => _jiraApiToken;

	public string JiraProjectKey => _jiraProjectKey;
}
