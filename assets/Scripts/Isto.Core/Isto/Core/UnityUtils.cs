using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Isto.Core;

public static class UnityUtils
{
	private static List<Vector3> _directions = new List<Vector3>
	{
		Vector3.back,
		Vector3.forward,
		Vector3.left,
		Vector3.right
	};

	private static Vector3 backLeft = (Vector3.back + Vector3.left).normalized;

	private static Vector3 backRight = (Vector3.back + Vector3.right).normalized;

	private static Vector3 frontLeft = (Vector3.forward + Vector3.left).normalized;

	private static Vector3 frontRight = (Vector3.forward + Vector3.right).normalized;

	private static List<Vector3> _octoDirections = new List<Vector3>
	{
		Vector3.back,
		backLeft,
		backRight,
		Vector3.forward,
		frontLeft,
		frontRight,
		Vector3.left,
		Vector3.right
	};

	public static Vector3 GetNearestPositionOnCollider(GameObject target, Vector3 sourcePosition, LayerMask validLayers)
	{
		List<Collider> list = new List<Collider>();
		list.AddRange(target.GetComponents<Collider>());
		list.AddRange(target.GetComponentsInChildren<Collider>());
		list = list.Where((Collider x) => validLayers.Contains(x.gameObject.layer)).ToList();
		if (list.Count == 0)
		{
			Debug.LogWarning("Looking for colliders on item without any. Item: " + target.name);
			return target.transform.position;
		}
		Vector3 vector = list[0].ClosestPoint(sourcePosition);
		float num = Vector3.Distance(sourcePosition, vector);
		for (int num2 = 1; num2 < list.Count; num2++)
		{
			Vector3 vector2 = list[num2].ClosestPoint(sourcePosition);
			float num3 = Vector3.Distance(sourcePosition, vector2);
			if (num3 < num)
			{
				vector = vector2;
				num = num3;
			}
		}
		vector.y = 0f;
		return vector;
	}

	public static GameObject GetClosestHitObject(Collider[] hitBuffer, int hitCount, Vector3 fromPosition)
	{
		Collider collider = hitBuffer[0];
		float num = Vector3.Distance(collider.transform.position, fromPosition);
		for (int i = 1; i < hitCount; i++)
		{
			float num2 = Vector3.Distance(hitBuffer[i].transform.position, fromPosition);
			if (num2 < num)
			{
				num = num2;
				collider = hitBuffer[i];
			}
		}
		return collider.gameObject;
	}

	public static GameObject GetClosestHitObject<T>(Collider[] hitBuffer, int hitCount, Vector3 fromPosition)
	{
		Collider collider = null;
		float num = float.PositiveInfinity;
		for (int i = 0; i < hitCount; i++)
		{
			float num2 = Vector3.Distance(hitBuffer[i].transform.position, fromPosition);
			bool flag = hitBuffer[i].GetComponentInParent<T>() != null;
			if ((num2 < num) & flag)
			{
				num = num2;
				collider = hitBuffer[i];
			}
		}
		if (!(collider == null))
		{
			return collider.gameObject;
		}
		return null;
	}

	public static float GetRelativeHorizontalDirection(Vector3 main, Vector3 other)
	{
		Vector3 up = Vector3.up;
		Vector3 lhs = new Vector3(-1f, 0f, 1f);
		return Mathf.Sign(Vector3.Dot(up, Vector3.Cross(lhs, main - other)));
	}

	public static Vector2 TransformWorldToCanvasPoint(Vector3 worldPoint, Canvas canvas)
	{
		Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, worldPoint);
		RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPoint, canvas.worldCamera, out var localPoint);
		return canvas.transform.TransformPoint(localPoint);
	}

	public static IEnumerator ZoomCamera(float amount, float time)
	{
		Transform camTransform = Camera.main.transform;
		Vector3 startPosition = camTransform.localPosition;
		float timer = 0f;
		while (timer < time)
		{
			timer += Time.deltaTime;
			float num = Mathf.Lerp(0f, amount, timer / time);
			camTransform.localPosition = startPosition + camTransform.forward * num;
			yield return null;
		}
	}

	public static Vector3 RandomXZVector(float size)
	{
		float num = UnityEngine.Random.Range((0f - size) / 2f, size / 2f);
		Vector3 result = UnityEngine.Random.insideUnitSphere * num;
		result.y = 0f;
		return result;
	}

	public static Vector3 RandomXZVectorLinearDistribution(float size)
	{
		float num = RandomFromDistribution.RandomRangeLinear(0f - size, size, 1f);
		Vector3 result = UnityEngine.Random.insideUnitSphere * num;
		result.y = 0f;
		return result;
	}

	public static IEnumerator LerpLightIntensity(Light light, float targetIntensity, float lerpTime)
	{
		float timer = 0f;
		float startIntensity = light.intensity;
		while (timer < lerpTime)
		{
			timer += Time.deltaTime;
			light.intensity = Mathf.Lerp(startIntensity, targetIntensity, timer / lerpTime);
			yield return null;
		}
	}

	public static Vector3 ConvertScreenVectorToIsometric(float horizontal, float vertical)
	{
		Vector3 result = default;
		result.x += horizontal / 2f;
		result.z += horizontal / 2f;
		result.x -= vertical / 2f;
		result.z += vertical / 2f;
		return result;
	}

	public static Vector3 GetRandomWorldPositionNearScreenEdge(float insideOffset)
	{
		return GetViewPortPositionOnGround(GetRandomViewPortPositionNearEdge(insideOffset));
	}

	public static Vector3 GetViewPortPositionOnGround(Vector2 viewportPos)
	{
		Ray ray = Camera.main.ViewportPointToRay(new Vector3(viewportPos.x, viewportPos.y, 0f));
		Vector3 zero = Vector3.zero;
		if (Physics.Raycast(ray, out var hitInfo, Layers.GROUND_LAYERS_MASK))
		{
			zero = hitInfo.point;
			zero.y = 0f;
			Vector3 vector = new Vector3(-1f, 0f, 1f);
			return zero - vector * 2f;
		}
		Debug.LogError("Looking for teleport position could not find ground with raycast.");
		return zero;
	}

	public static Vector2 GetRandomViewPortPositionNearEdge(float insideOffset, bool normalDistribution = false)
	{
		float x;
		float y;
		if (UnityEngine.Random.value > 0.5f)
		{
			x = ((UnityEngine.Random.value > 0.5f) ? (1f - insideOffset) : insideOffset);
			y = ((!normalDistribution) ? UnityEngine.Random.Range(insideOffset, 1f - insideOffset) : RandomFromDistribution.RandomRangeNormalDistribution(insideOffset, 1f - insideOffset, RandomFromDistribution.ConfidenceLevel_e._99));
		}
		else
		{
			y = ((UnityEngine.Random.value > 0.5f) ? (1f - insideOffset) : insideOffset);
			x = ((!normalDistribution) ? UnityEngine.Random.Range(insideOffset, 1f - insideOffset) : RandomFromDistribution.RandomRangeNormalDistribution(insideOffset, 1f - insideOffset, RandomFromDistribution.ConfidenceLevel_e._99));
		}
		return new Vector2(x, y);
	}

	public static bool IsWorldPositionOnScreen(Vector3 worldPosition, Camera camera)
	{
		Vector2 vector = camera.WorldToViewportPoint(worldPosition);
		if (!(vector.x < 0f) && !(vector.x > 1f) && !(vector.y < 0f))
		{
			return !(vector.y > 1f);
		}
		return false;
	}

	public static float GetLightRangeAtGroundLevel(Light light)
	{
		return CalculateLightRangeAtGroundLevel(light.range, light.transform.position.y);
	}

	public static float CalculateLightRangeAtGroundLevel(float range, float height)
	{
		return Mathf.Sqrt(range * range - height * height) + 1f;
	}

	public static bool TryParseToVector3(string input, out Vector3 result)
	{
		bool flag = true;
		result = Vector3.zero;
		if (input.StartsWith("(") && input.EndsWith(")"))
		{
			input = input.Substring(1, input.Length - 2);
		}
		string[] array = input.Split(',');
		flag &= array.Length == 3;
		if (flag)
		{
			flag &= float.TryParse(array[0], out var result2);
			flag &= float.TryParse(array[1], out var result3);
			flag &= float.TryParse(array[2], out var result4);
			if (flag)
			{
				result = new Vector3(result2, result3, result4);
			}
		}
		return flag;
	}

	public static Vector3 GetNearestAxisDirection(Vector3 direction)
	{
		return GetNearestAxisDirection(_directions, direction);
	}

	public static Vector3 GetNearestOctoDirection(Vector3 direction)
	{
		new List<Vector3>
		{
			Vector3.back,
			backLeft,
			backRight,
			Vector3.forward,
			frontLeft,
			frontRight,
			Vector3.left,
			Vector3.right
		};
		return GetNearestAxisDirection(_octoDirections, direction);
	}

	public static Vector3 GetNearestScreenSpaceAxisDirection(Vector3 direction)
	{
		return GetNearestAxisDirection(_directions, direction);
	}

	public static Vector3 GetNearestAxisDirection(List<Vector3> axisDirections, Vector3 sourceDirection)
	{
		if (sourceDirection == Vector3.zero)
		{
			return Vector3.zero;
		}
		float num = 0f;
		int index = 0;
		for (int i = 0; i < axisDirections.Count; i++)
		{
			float num2 = ((Vector3.Angle(sourceDirection, axisDirections[i]) < 90f) ? Vector3.Project(sourceDirection, axisDirections[i]).magnitude : 0f);
			if (num < num2)
			{
				num = num2;
				index = i;
			}
		}
		return axisDirections[index];
	}

	public static void SetAllChildAnimatorsState(GameObject parent, bool enabled)
	{
		Animator[] componentsInChildren = parent.GetComponentsInChildren<Animator>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = enabled;
		}
	}

	public static void SetCornersForSearchArea(Vector3 center, float radius, out Vector3Int topLeft, out Vector3Int botRight)
	{
		Vector3 v = new Vector3(center.x - radius, 0f, center.z + radius);
		Vector3 v2 = new Vector3(center.x + radius, 0f, center.z - radius);
		topLeft = Vector3Int.RoundToInt(v);
		botRight = Vector3Int.RoundToInt(v2);
	}

	public static void DrawCircleRadius(Vector3 position, float radius, Color ringColor, Color fillColor, string label, float labelOffset = 4f)
	{
	}

	public static void DrawCircleWire(Vector3 position, float radius, Color ringColor, Color labelColor, string label, float labelOffset = 0f)
	{
	}

	public static void DrawBox(Bounds boxBounds, Color edgeColor, Color fillColor, Color labelColor, string label, float labelOffset = 1f)
	{
	}

	public static void DrawRangeForLight(Light light, string label)
	{
		float lightRangeAtGroundLevel = GetLightRangeAtGroundLevel(light);
		Vector3 position = light.transform.position;
		position.y = 0.1f;
		DrawCircleRadius(position, lightRangeAtGroundLevel, new Color(1f, 1f, 1f, 1f), new Color(0f, 0f, 0f, 0f), label);
	}

	public static void DrawBoxFromCorners(Vector3Int corner1, Vector3Int corner2, Color fillColor)
	{
		Vector3 center = ((Vector3)corner1 + (Vector3)corner2) / 2f;
		float x = Mathf.Abs(corner1.x - corner2.x);
		float z = Mathf.Abs(corner1.z - corner2.z);
		Gizmos.color = fillColor;
		Gizmos.DrawCube(center, new Vector3(x, 1f, z));
	}

	public static IEnumerator LoadMultipleScenes(string[] sceneNames, string sceneToSetActive)
	{
		Debug.Log($"Loading {sceneNames.Length} Scenes");
		for (int i = 0; i < sceneNames.Length; i++)
		{
			AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(sceneNames[i], LoadSceneMode.Additive);
			if (sceneLoad == null)
			{
				Debug.LogError("Unable to load scene: " + sceneNames[i]);
				yield break;
			}
			while (!sceneLoad.isDone)
			{
				yield return null;
			}
		}
		SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneToSetActive));
		bool sceneNotActivated = true;
		float maxLoadTime = 120f;
		while (sceneNotActivated && maxLoadTime > 0f)
		{
			maxLoadTime -= Time.deltaTime;
			Scene activeScene = SceneManager.GetActiveScene();
			if (activeScene.name != null && activeScene.name.Equals(sceneToSetActive))
			{
				sceneNotActivated = false;
			}
			yield return null;
		}
		if (maxLoadTime < 0f)
		{
			Debug.LogError("Unable to load all scenes");
		}
	}

	public static bool TryGetComponentFromRootObjects<T>(Scene scene, out T component)
	{
		GameObject[] rootGameObjects = scene.GetRootGameObjects();
		for (int i = 0; i < rootGameObjects.Length; i++)
		{
			if (rootGameObjects[i].TryGetComponent<T>(out var component2))
			{
				component = component2;
				return true;
			}
		}
		component = default;
		return false;
	}

	public static void DebugLogThreadSafe(string logMessage)
	{
		Debug.Log("<color=green>" + logMessage + "</color>    |");
	}

	public static void DebugLogWarningThreadSafe(string logMessage)
	{
		Debug.Log("<color=yellow>" + logMessage + "</color>    |");
	}

	public static bool IsCameraZoomSupported()
	{
		return true;
	}

	public static bool IsAutoSaveSupported()
	{
		return true;
	}

	public static bool TryGetGameObjectFromInterface(Component interfaceAsComponent, out GameObject gameObject)
	{
		bool result = false;
		gameObject = null;
		if ((bool)interfaceAsComponent)
		{
			gameObject = interfaceAsComponent.gameObject;
			result = true;
		}
		return result;
	}

	public static string ConvertTimespanToTotalDaysHoursMinutes(TimeSpan timeSpan)
	{
		return $"{(int)timeSpan.TotalDays}:{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}";
	}

	public static string ConvertTimespanToTotalHoursMinutesSeconds(TimeSpan timeSpan)
	{
		return $"{(int)timeSpan.TotalHours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
	}

	public static string ConvertTimespanToTotalMinutesSecondsMilliseconds(TimeSpan timeSpan)
	{
		return $"{(int)timeSpan.TotalMinutes:D2}:{timeSpan.Seconds:D2}:{timeSpan.Milliseconds:D3}";
	}
}
