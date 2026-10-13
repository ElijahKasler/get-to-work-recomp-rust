namespace Isto.Core.Platforms.Xbox;

public class GDK_XUserManager
{
	public enum State
	{
		Idle = 0,
		AddUserWithUIAsync_Waiting = 1,
		AddUserWithUIAsync_Completed = 2,
		AddUserWithUIAsync_NeedsResolveIssueUI = 3,
		ResolveAddUserIssueWithUI_Waiting = 4,
		ResolveAddUserIssueWithUI_Completed = 5,
		GotUserHandle_CheckIfAlreadyAdded = 6,
		GetUserId = 7,
		GetUserId_Completed = 8,
		GetUserId_NeedsResolveUIIssue = 9,
		ResolveGetUserIdWithUI_Waiting = 10,
		ResolveGetUserIdWithUI_Completed = 11,
		GetContext = 12,
		GetContext_Completed = 13,
		GetGamerTag = 14,
		GetGamerTag_Completed = 15,
		GetLocalId = 16,
		GetLocalId_Completed = 17,
		AddingValidUser = 18,
		CompletedOk = 19,
		Error = 20,
		Error_AddUserWithUIAsync = 21,
		Error_AddUserWithUIAsync_UserCancelled = 22,
		Error_AddUserWithUIAsync_UnresolvedIssue = 23,
		Error_GetUserId = 24,
		Error_GetUserId_UnresolvedIssue = 25,
		Error_GetContext = 26,
		Error_GetGamerTag = 27,
		Error_GetLocalId = 28
	}

	public class XUserData
	{
		public ulong m_userXUID;

		public string m_userGamertag;
	}

	public delegate void AddUserCompletedDelegate(State exitState, XUserData selectedUser, int hResult);

	private const int k_iInvalidUserIndex = -1;

	private State m_State;

	private XUserData m_lastSelectedUser = new XUserData();

	private float _preConstrainTimeScale = 1f;

	private bool _preConstrainStoryActive;

	public XUserData LastSelectedUser => m_lastSelectedUser;

	public static bool UserIndexIsValid(int index)
	{
		return index > -1;
	}
}
