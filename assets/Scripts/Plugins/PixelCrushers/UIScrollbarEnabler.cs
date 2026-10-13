using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace PixelCrushers;

[AddComponentMenu("")]
public class UIScrollbarEnabler : MonoBehaviour
{
	[Tooltip("The scroll rect.")]
	[FormerlySerializedAs("container")]
	public ScrollRect scrollRect;

	[Tooltip("The content inside the scroll rect. The scrollbar will be enabled if the content is taller than the scroll rect.")]
	[FormerlySerializedAs("content")]
	public RectTransform scrollContent;

	[Tooltip("The scrollbar to enable or disable.")]
	public Scrollbar scrollbar;

	private bool m_started;

	private bool m_checking;

	public void TEST()
	{
		Debug.Log("1234");
	}

	private void Start()
	{
		m_started = true;
		CheckScrollbar();
	}

	public void OnEnable()
	{
		if (m_started)
		{
			CheckScrollbar();
		}
	}

	public void OnDisable()
	{
		m_checking = false;
	}

	public void CheckScrollbar()
	{
		if (!m_checking && !(scrollRect == null) && !(scrollContent == null) && !(scrollbar == null) && base.gameObject.activeInHierarchy && base.enabled)
		{
			StartCoroutine(CheckScrollbarAfterUIUpdate(useResetValue: false, 0f));
		}
	}

	public void CheckScrollbarWithResetValue(float value)
	{
		if (!m_checking && !(scrollRect == null) && !(scrollContent == null) && !(scrollbar == null) && base.gameObject.activeInHierarchy && base.enabled)
		{
			StartCoroutine(CheckScrollbarAfterUIUpdate(useResetValue: true, value));
		}
	}

	private IEnumerator CheckScrollbarAfterUIUpdate(bool useResetValue, float resetValue)
	{
		m_checking = true;
		yield return null;
		scrollbar.gameObject.SetActive(scrollContent.rect.height > scrollRect.GetComponent<RectTransform>().rect.height);
		m_checking = false;
		yield return null;
		if (useResetValue)
		{
			scrollbar.value = resetValue;
			scrollRect.verticalNormalizedPosition = resetValue;
		}
	}
}
