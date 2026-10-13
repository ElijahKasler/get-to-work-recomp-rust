using UnityEngine;

namespace Unity.XGamingRuntime;

public class GdkEditionAsset : ScriptableObject
{
	[SerializeField]
	[Tooltip("The GDK Edition number used for API compatibility checks")]
	private int m_EditionNumber;

	public int EditionNumber => m_EditionNumber;

	public static GdkEditionAsset CreateInstance(int editionNumber)
	{
		GdkEditionAsset gdkEditionAsset = ScriptableObject.CreateInstance<GdkEditionAsset>();
		gdkEditionAsset.m_EditionNumber = editionNumber;
		return gdkEditionAsset;
	}
}
