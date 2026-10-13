using System.Collections;
using Isto.Core.Beings;
using TMPro;
using UnityEngine;
using Zenject;

namespace Isto.Core.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIDamageTextDisplay : MonoBehaviour
{
	public class Pool : MonoMemoryPool<float, Vector3, Health.DamageTypeEnum, UIDamageTextDisplay>
	{
		protected override void Reinitialize(float damage, Vector3 worldPosition, Health.DamageTypeEnum dmgType, UIDamageTextDisplay item)
		{
			item.DisplayDamage(damage, worldPosition, dmgType);
		}
	}

	[SerializeField]
	private AnimationCurve _alphaCurve = AnimationCurve.Constant(0f, 1f, 0.5f);

	[SerializeField]
	private AnimationCurve _movementCurve;

	[SerializeField]
	private float _height;

	[SerializeField]
	private float _displayTime = 2f;

	private TextMeshProUGUI _damageText;

	private Pool _pool;

	private Canvas _canvas;

	[Inject]
	public void Inject(Pool pool)
	{
		_pool = pool;
	}

	private void Awake()
	{
		_damageText = GetComponent<TextMeshProUGUI>();
		_damageText.alpha = 0f;
	}

	internal void DisplayDamage(float damage, Vector3 worldPosition, Health.DamageTypeEnum dmgType)
	{
		if (dmgType == null)
		{
			dmgType = Health.DamageTypeEnum.PHYSICAL;
		}
		_damageText.text = ((int)damage).ToString();
		_damageText.overrideColorTags = true;
		_damageText.color = GetColorForDamge(damage, dmgType);
		_canvas = GetComponentInParent<Canvas>();
		base.transform.position = UnityUtils.TransformWorldToCanvasPoint(worldPosition, _canvas);
		StartCoroutine(ShowText(worldPosition));
	}

	protected virtual Color GetColorForDamge(float damage, Health.DamageTypeEnum dmgType)
	{
		Color result = ((damage < 0f) ? Color.red : Color.green);
		if (dmgType == Health.DamageTypeEnum.STUN)
		{
			result = ((damage < 0f) ? Color.cyan : Color.green);
		}
		return result;
	}

	private IEnumerator ShowText(Vector3 worldPosition)
	{
		float timer = 0f;
		_ = (Vector3)UnityUtils.TransformWorldToCanvasPoint(worldPosition, _canvas);
		while (timer < _displayTime)
		{
			timer += Time.deltaTime;
			_damageText.alpha = _alphaCurve.Evaluate(timer / _displayTime);
			Vector3 vector = UnityUtils.TransformWorldToCanvasPoint(worldPosition, _canvas);
			base.transform.position = Vector3.Lerp(vector, vector + Vector3.up * _height, timer / _displayTime);
			yield return null;
		}
		_damageText.alpha = 0f;
		_pool.Despawn(this);
	}
}
