using System.Reflection;
using Unity.XGamingRuntime.Interop;
using UnityEngine.Scripting.APIUpdating;

namespace Unity.XGamingRuntime;

[MovedFrom("Unity.GameCore")]
public class HR : Unity.XGamingRuntime.Interop.HR
{
	public const int E_FAIL = -2147467259;

	public const int HTTP_E_STATUS_NONE_ACCEPTABLE = -2145844842;

	public const int HTTP_E_STATUS_NOT_FOUND = -2145844844;

	public const int HTTP_E_STATUS_NOT_MODIFIED = -2145844944;

	public const int HTTP_E_STATUS_NOT_SUPPORTED = -2145844747;

	public const int HTTP_E_STATUS_PAYMENT_REQ = -2145844846;

	public const int HTTP_E_STATUS_PRECOND_FAILED = -2145844836;

	public const int HTTP_E_STATUS_PROXY_AUTH_REQ = -2145844841;

	public const int E_GAME_MISSING_GAME_CONFIG = -2015035361;

	public const int E_DSTORAGE_BEGIN = -1994129408;

	public const int E_DSTORAGE_END = -1994129153;

	public const int E_GAMERUNTIME_NOT_INITIALIZED = -1994129152;

	public const int E_GAMERUNTIME_DLL_NOT_FOUND = -1994129151;

	public const int E_GAMERUNTIME_VERSION_MISMATCH = -1994129150;

	public const int E_GAMERUNTIME_WINDOW_NOT_FOREGROUND = -1994129149;

	public const int E_GAMERUNTIME_SUSPENDED = -1994129148;

	public const int E_GAMERUNTIME_UNINITIALIZE_ACTIVEOBJECTS = -1994129147;

	public const int E_GAMERUNTIME_MULTIPLAYER_NOT_CONFIGURED = -1994129146;

	public const int E_GAMERUNTIME_OPTIONS_MISMATCH = -1994129143;

	public const int E_GAMERUNTIME_OPTIONS_NOT_SUPPORTED = -1994129142;

	public const int E_GAMEUSER_MAX_USERS_ADDED = -1994108672;

	public const int E_GAMEUSER_SIGNED_OUT = -1994108671;

	public const int E_GAMEUSER_RESOLVE_USER_ISSUE_REQUIRED = -1994108670;

	public const int E_GAMEUSER_DEFERRAL_NOT_AVAILABLE = -1994108669;

	public const int E_GAMEUSER_USER_NOT_FOUND = -1994108668;

	public const int E_GAMEUSER_NO_TOKEN_REQUIRED = -1994108667;

	public const int E_GAMEUSER_NO_DEFAULT_USER = -1994108666;

	public const int E_GAMEUSER_FAILED_TO_RESOLVE = -1994108665;

	public const int E_GAMEUSER_NO_TITLE_ID = -1994108664;

	public const int E_GAMEUSER_UNKNOWN_GAME_IDENTITY = -1994108663;

	public const int E_GAMEUSER_NO_PACKAGE_IDENTITY = -1994108656;

	public const int E_GAMEUSER_FAILED_TO_GET_TOKEN = -1994108655;

	public const int E_GAMEPACKAGE_APP_NOT_PACKAGED = -1994108416;

	public const int E_GAMEPACKAGE_NO_INSTALLED_LANGUAGES = -1994108415;

	public const int E_GAMEPACKAGE_NO_STORE_ID = -1994108414;

	public const int E_GAMEPACKAGE_INVALID_SELECTOR = -1994108413;

	public const int E_GAMEPACKAGE_DOWNLOAD_REQUIRED = -1994108412;

	public const int E_GAMEPACKAGE_NO_TAG_CHANGE = -1994108411;

	public const int E_GAMESTORE_LICENSE_ACTION_NOT_APPLICABLE_TO_PRODUCT = -1994108160;

	public const int E_GAMESTORE_NETWORK_ERROR = -1994108159;

	public const int E_GAMESTORE_SERVER_ERROR = -1994108158;

	public const int E_GAMESTORE_INSUFFICIENT_QUANTITY = -1994108157;

	public const int E_GAMESTORE_ALREADY_PURCHASED = -1994108156;

	public const int E_GAMESTREAMING_NOT_INITIALIZED = -1994107904;

	public const int E_GAMESTREAMING_CLIENT_NOT_CONNECTED = -1994107903;

	public const int E_GAMESTREAMING_NO_DATA = -1994107902;

	public const int E_GAMESTREAMING_NO_DATACENTER = -1994107901;

	public const int E_GAMESTREAMING_NOT_STREAMING_CONTROLLER = -1994107900;

	public const int E_GS_INVALID_CONTAINER_NAME = -2138898431;

	public const int E_GS_NO_ACCESS = -2138898430;

	public const int E_GS_OUT_OF_LOCAL_STORAGE = -2138898429;

	public const int E_GS_USER_CANCELED = -2138898428;

	public const int E_GS_UPDATE_TOO_BIG = -2138898427;

	public const int E_GS_QUOTA_EXCEEDED = -2138898426;

	public const int E_GS_PROVIDED_BUFFER_TOO_SMALL = -2138898425;

	public const int E_GS_BLOB_NOT_FOUND = -2138898424;

	public const int E_GS_NO_SERVICE_CONFIGURATION = -2138898423;

	public const int E_GS_CONTAINER_NOT_IN_SYNC = -2138898422;

	public const int E_GS_CONTAINER_SYNC_FAILED = -2138898421;

	public const int E_GS_USER_NOT_REGISTERED_IN_SERVICE = -2138898420;

	public const int E_GS_HANDLE_EXPIRED = -2138898419;

	public const int E_GS_ASYNC_FUNCTION_REQUIRED = -2138898418;

	public const int E_XBL_RUNTIME_ERROR = -1994173952;

	public const int E_XBL_RTA_GENERIC_ERROR = -1994173951;

	public const int E_XBL_RTA_SUBSCRIPTION_LIMIT_REACHED = -1994173950;

	public const int E_XBL_RTA_ACCESS_DENIED = -1994173949;

	public const int E_XBL_AUTH_UNKNOWN_ERROR = -1994173948;

	public const int E_XBL_AUTH_RUNTIME_ERROR = -1994173947;

	public const int E_XBL_AUTH_NO_TOKEN = -1994173946;

	public const int E_XBL_ALREADY_INITIALIZED = -1994173945;

	public const int E_XBL_NOT_INITIALIZED = -1994173944;

	public const int XO_E_CONTENT_ISOLATION = -2146051054;

	public static string NameOf(int hr)
	{
		HR obj = new HR();
		FieldInfo[] fields = typeof(HR).GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			if (fieldInfo.GetValue(obj).Equals(hr))
			{
				return fieldInfo.Name;
			}
		}
		return "";
	}
}
