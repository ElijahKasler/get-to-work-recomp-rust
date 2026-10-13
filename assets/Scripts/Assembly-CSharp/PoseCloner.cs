using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PoseCloner : MonoBehaviour
{
	public struct TransRec(Transform transform)
	{
		public Vector3 pos = transform.localPosition;

		public Quaternion rot = transform.localRotation;

		public Vector3 scale = transform.localScale;

		public void SetTransform(Transform t)
		{
			t.localPosition = pos;
			t.localRotation = rot;
			t.localScale = scale;
		}
	}

	public static Dictionary<string, TransRec> poseDict;

	public GameObject activeGO;

	public bool checkToCopy;

	public bool checkToPaste;

	private void OnDrawGizmos()
	{
		if (checkToCopy)
		{
			Copy();
			checkToCopy = false;
		}
		if (checkToPaste)
		{
			Paste();
			checkToPaste = false;
		}
	}

	private void Copy()
	{
		if (!(activeGO == null))
		{
			Transform[] componentsInChildren = activeGO.GetComponentsInChildren<Transform>();
			poseDict = new Dictionary<string, TransRec>();
			Transform[] array = componentsInChildren;
			foreach (Transform t in array)
			{
				string pathName = GetPathName(t);
				poseDict.Add(pathName, new TransRec(t));
			}
			Debug.Log("PoseCloner:Copy() - Copied " + componentsInChildren.Length + " transforms.");
		}
	}

	private void Paste()
	{
		if (activeGO == null)
		{
			return;
		}
		if (poseDict == null || poseDict.Count == 0)
		{
			Debug.Log("PoseCloner:Paste() - No copied data exists to paste.");
			return;
		}
		Transform[] componentsInChildren = activeGO.GetComponentsInChildren<Transform>();
		int num = 0;
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		List<string> list3 = new List<string>();
		Transform[] array = componentsInChildren;
		foreach (Transform t in array)
		{
			string pathName = GetPathName(t);
			if (poseDict.ContainsKey(pathName))
			{
				poseDict[pathName].SetTransform(t);
				num++;
				list.Add(pathName);
			}
			else
			{
				list3.Add(pathName);
			}
		}
		foreach (string key in poseDict.Keys)
		{
			if (list.IndexOf(key) == -1)
			{
				list2.Add(key);
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("PoseCloner:Paste() -");
		stringBuilder.Append(" Pasted:" + list.Count);
		stringBuilder.Append(" Skipped:" + list2.Count);
		stringBuilder.AppendLine(" NotFoundInPoseDict:" + list3.Count);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Pasted:");
		foreach (string item in list)
		{
			stringBuilder.Append("\t");
			stringBuilder.AppendLine(item);
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("Skipped:");
		foreach (string item2 in list2)
		{
			stringBuilder.Append("\t");
			stringBuilder.AppendLine(item2);
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("NotFoundInPoseDict:");
		foreach (string item3 in list3)
		{
			stringBuilder.Append("\t");
			stringBuilder.AppendLine(item3);
		}
		Debug.Log(stringBuilder.ToString());
	}

	private string GetPathName(Transform t)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(t.gameObject.name);
		while (t != activeGO.transform)
		{
			t = t.parent;
			if (t == null)
			{
				break;
			}
			stringBuilder.Insert(0, ":");
			stringBuilder.Insert(0, t.gameObject.name);
		}
		return stringBuilder.ToString();
	}
}
