using DG.Tweening;
using TMPro;
using UnityEngine;

public class FlashingText : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _label;

	private void Awake()
	{
		_label.DOFade(0f, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo)
			.Play();
	}

	private void Update()
	{
	}
}
