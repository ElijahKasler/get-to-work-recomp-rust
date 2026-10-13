using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using FMODUnity;
using Isto.Core.Audio;
using Isto.Core.Enums;
using Isto.Core.Pooling;
using Isto.Core.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Isto.Core.Beings;

public class Health : MonoBehaviour, IStunnable, IActionOnRecycle
{
	public class DamageTypeEnum : Int32Enum<DamageTypeEnum>
	{
		public static readonly DamageTypeEnum PHYSICAL = new DamageTypeEnum(0, "PHYSICAL");

		public static readonly DamageTypeEnum STUN = new DamageTypeEnum(3, "STUN");

		public static readonly DamageTypeEnum FIRE = new DamageTypeEnum(5, "FIRE");

		public static readonly DamageTypeEnum HARVEST = new DamageTypeEnum(6, "HARVEST");

		public DamageTypeEnum(int value, string name)
			: base(value, name)
		{
		}
	}

	public class DamageSourceEnum : Int32Enum<DamageSourceEnum>
	{
		public static readonly DamageSourceEnum PLAYER = new DamageSourceEnum(0, "PLAYER");

		public static readonly DamageSourceEnum MOB = new DamageSourceEnum(1, "MOB");

		public DamageSourceEnum(int value, string name)
			: base(value, name)
		{
		}
	}

	[Header("Core Stats")]
	public float HP;

	public float fullHp;

	[Tooltip("If set, any damage that is taken is only applied to stun damage, not actualy HP.")]
	public bool takesStunDamage;

	public float stunDamageResistance;

	public bool takesInternalStunDamage;

	[Header("HealthBar")]
	[SerializeField]
	private GameObject _healthBar;

	[SerializeField]
	private Image _healthBarSlider;

	[SerializeField]
	private float _turnHealthBarRedPercent = 0.2f;

	[SerializeField]
	private Color _redSliderColor = Constants.ATRIO_RED;

	[SerializeField]
	private Color _normalSliderColor = Constants.ATRIO_LIGHT_GREY_TEXT;

	[SerializeField]
	private Color _greenSliderColor = Constants.ATRIO_GREEN_TEXT;

	[SerializeField]
	private float _showGreenDuration = 1f;

	[Header("Stun")]
	public float stunHP;

	public float stunResetTime = 3f;

	public float stunTimeOnDamage = 0.5f;

	[Header("VFX - Damage Flash")]
	public GameObject bodyContainer;

	public Color damageColor = Color.red;

	public float damageColorTime = 0.5f;

	[Header("Audio")]
	[EventRef]
	public string physicalImpactRef;

	[Header("Behavior Tree")]
	[SerializeField]
	private BehaviorTree _tree;

	[SerializeField]
	private string _damageBoolVarName;

	[SerializeField]
	private string _damageSourceVarName;

	private float _showGreenTimer;

	private bool _sliderIsGreen;

	private float _fullStunHP;

	private float _stunTimer;

	private float _damageSpamTimer;

	private Rigidbody _body;

	private bool _isInvincible;

	private float _previousPercent;

	private bool _hasHealthBar;

	private List<Material> _materials;

	private Color _startColor;

	private Coroutine _damageCoroutine;

	private IGameSounds _gameSounds;

	private UIDamageTextDisplay.Pool _dmgDisplayPool;

	public float StunPercent
	{
		get
		{
			if (!(stunHP <= 0f))
			{
				return 0f;
			}
			return 1f - _stunTimer / stunResetTime;
		}
	}

	public float HealthPercent => HP / fullHp;

	public event EventHandler<HealthEventArgs> TookDamage;

	public event EventHandler<HealthEventArgs> Stunned;

	public event EventHandler<HealthEventArgs> StunReset;

	public event EventHandler<HealthEventArgs> Killed;

	[Inject]
	public void Inject(IGameSounds gameSounds, [InjectOptional] UIDamageTextDisplay.Pool dmgDisplayPool)
	{
		_gameSounds = gameSounds;
		_dmgDisplayPool = dmgDisplayPool;
	}

	private void Awake()
	{
		_fullStunHP = stunHP;
		HP = fullHp;
		_body = GetComponent<Rigidbody>();
		_materials = new List<Material>();
		_hasHealthBar = _healthBar != null;
		LoadAllMaterials();
	}

	private void Start()
	{
		base.enabled = NeedsUpdate();
		ValidateBehaviorTreeVariables();
	}

	private void Update()
	{
		float deltaTime = Time.deltaTime;
		_stunTimer += deltaTime;
		if (_stunTimer > stunResetTime)
		{
			if (stunHP < _fullStunHP)
			{
				StunReset?.Invoke(this, null);
			}
			stunHP = _fullStunHP;
		}
		_damageSpamTimer += deltaTime;
		UpdateHealthBar(deltaTime);
		if (!NeedsUpdate())
		{
			base.enabled = false;
		}
	}

	private bool NeedsUpdate()
	{
		if ((!_hasHealthBar || !(HP < fullHp) || HealthPercent == _previousPercent) && !(stunHP < _fullStunHP) && !(_damageSpamTimer < Constants.DAMAGE_COOLDOWN_TIME))
		{
			return _damageCoroutine != null;
		}
		return true;
	}

	public void TakeDamage(float damage, DamageTypeEnum type, DamageSourceEnum source, Transform damageSourceTransform = null)
	{
		base.enabled = true;
		if (_isInvincible || !base.enabled || (_damageSpamTimer < Constants.DAMAGE_COOLDOWN_TIME && type != DamageTypeEnum.HARVEST))
		{
			return;
		}
		_damageSpamTimer = 0f;
		HealthEventArgs e = ApplyDamageByType(damage, type, source, damageSourceTransform);
		_damageCoroutine = StartCoroutine(FlashDamageColor(damageColorTime));
		if (e.type != DamageTypeEnum.HARVEST && Mathf.Abs(e.damage) >= 1f)
		{
			if (_dmgDisplayPool != null)
			{
				_dmgDisplayPool.Spawn(0f - damage, base.transform.position, e.type);
			}
			else
			{
				Debug.Log($"{damage} {e.type} damage on {base.gameObject.name}", base.gameObject);
			}
		}
		if (HP <= 0f)
		{
			HP = 0f;
			Killed?.Invoke(this, e);
			return;
		}
		if (damageSourceTransform != null)
		{
			UpdateBehaviorTree(damageSourceTransform.position);
		}
		e.sourceTransform = damageSourceTransform;
		e.stunTime = stunTimeOnDamage;
		TookDamage?.Invoke(this, e);
	}

	protected virtual HealthEventArgs ApplyDamageByType(float damageToApply, DamageTypeEnum type, DamageSourceEnum source, Transform damageSourceTransform)
	{
		return new HealthEventArgs(damageToApply, type, source);
	}

	protected void PlayPhysicalDamageSound()
	{
		if (!string.IsNullOrEmpty(physicalImpactRef))
		{
			_gameSounds.PlayOneShot(physicalImpactRef, base.transform.position);
		}
	}

	protected void TakeStunDamage(DamageSourceEnum source, Transform damageSourceTransform, float damageToApply)
	{
		stunHP -= damageToApply;
		_stunTimer = 0f;
		if (stunHP <= 0f)
		{
			if (_body != null)
			{
				_body.linearVelocity = Vector3.zero;
			}
			Stunned?.Invoke(this, new HealthEventArgs(damageToApply, DamageTypeEnum.STUN, source, damageSourceTransform, stunResetTime));
		}
		if (takesStunDamage && damageSourceTransform != null)
		{
			UpdateBehaviorTree(damageSourceTransform.position);
		}
	}

	private void ValidateBehaviorTreeVariables()
	{
		if (!(_tree != null))
		{
			return;
		}
		List<SharedVariable> allVariables = _tree.GetAllVariables();
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < allVariables.Count; i++)
		{
			if (allVariables[i].Name.Equals(_damageBoolVarName))
			{
				flag = true;
			}
			else if (allVariables[i].Name.Equals(_damageSourceVarName))
			{
				flag2 = true;
			}
		}
		if (!flag || !flag2)
		{
			Debug.LogError("BehaviorTree does not have variables that are named on component. Please check. Disabling the health notification on the BehaviorTree");
			_tree = null;
		}
	}

	private void UpdateBehaviorTree(Vector3 damagePosition)
	{
		if (_tree != null)
		{
			_tree.SetVariableValue(_damageBoolVarName, true);
			_tree.SetVariableValue(_damageSourceVarName, damagePosition);
		}
	}

	private void UpdateHealthBar(float deltaTime)
	{
		if (!_hasHealthBar || HealthPercent == _previousPercent)
		{
			return;
		}
		_previousPercent = HealthPercent;
		if (_healthBarSlider != null)
		{
			_healthBarSlider.fillAmount = HealthPercent;
		}
		if (HP == fullHp)
		{
			SetHealthBarColor(_normalSliderColor);
			_healthBar.SetActive(value: false);
			return;
		}
		_healthBar.SetActive(value: true);
		if (_sliderIsGreen)
		{
			_showGreenTimer += deltaTime;
			if (_showGreenTimer > _showGreenDuration)
			{
				SetHealthBarColor(_normalSliderColor);
				_sliderIsGreen = false;
			}
		}
		else if (HealthPercent < _turnHealthBarRedPercent)
		{
			SetHealthBarColor(_redSliderColor);
		}
		else
		{
			SetHealthBarColor(_normalSliderColor);
		}
	}

	private void SetHealthBarColor(Color healthBarColor)
	{
		if (_hasHealthBar)
		{
			_healthBarSlider.color = healthBarColor;
		}
	}

	public void Heal(float amount)
	{
		Heal(amount, DamageTypeEnum.PHYSICAL);
	}

	public void Heal(float amount, DamageTypeEnum type)
	{
		if (type == DamageTypeEnum.STUN)
		{
			stunHP = Mathf.Clamp(stunHP + amount, 0f, _fullStunHP);
			return;
		}
		if (type == DamageTypeEnum.PHYSICAL)
		{
			HP = Mathf.Clamp(HP + amount, 0f, fullHp);
			_sliderIsGreen = true;
			_showGreenTimer = 0f;
			SetHealthBarColor(_greenSliderColor);
			if (this != null)
			{
				base.enabled = true;
			}
			return;
		}
		throw new UnityException("No handler setup for Healing damage type: " + type.ToString());
	}

	public virtual float GetHealthRemaining(DamageTypeEnum type)
	{
		if (type == DamageTypeEnum.PHYSICAL)
		{
			return HP;
		}
		if (type == DamageTypeEnum.STUN)
		{
			return stunHP;
		}
		throw new UnityException("No handler for GetHealthRemaining of type " + type.ToString());
	}

	public void SetMaxHealth(float amount)
	{
		fullHp = amount;
		HP = amount;
	}

	public void TakeDamage(float damage, Vector3 force, DamageTypeEnum type, DamageSourceEnum source)
	{
		if (_body != null)
		{
			_body.AddForce(force, ForceMode.Impulse);
		}
		TakeDamage(damage, type, source);
	}

	public void SetInvincible(bool invincible)
	{
		_isInvincible = invincible;
	}

	private void LoadAllMaterials()
	{
		if (!(bodyContainer == null))
		{
			Renderer[] componentsInChildren = bodyContainer.GetComponentsInChildren<Renderer>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				_materials.Add(componentsInChildren[i].material);
			}
			if (_materials.Count > 0)
			{
				_startColor = _materials[0].GetColor("_Color");
			}
		}
	}

	private IEnumerator FlashDamageColor(float time)
	{
		if (_materials.Count == 0)
		{
			yield break;
		}
		float timer = 0f;
		int colorMaterialID = Shader.PropertyToID("_Color");
		while (timer < time)
		{
			timer += Time.deltaTime;
			Color value = Color.Lerp(_startColor, damageColor, timer / time);
			for (int i = 0; i < _materials.Count; i++)
			{
				_materials[i].SetColor(colorMaterialID, value);
			}
			yield return null;
		}
		timer = 0f;
		while (timer < time)
		{
			timer += Time.deltaTime;
			Color value2 = Color.Lerp(damageColor, _startColor, timer / time);
			for (int j = 0; j < _materials.Count; j++)
			{
				_materials[j].SetColor(colorMaterialID, value2);
			}
			yield return null;
		}
		ResetColor();
		_damageCoroutine = null;
	}

	private void ResetColor()
	{
		if (!(bodyContainer == null) && _materials.Count != 0)
		{
			int nameID = Shader.PropertyToID("_Color");
			for (int i = 0; i < _materials.Count; i++)
			{
				_materials[i].SetColor(nameID, _startColor);
			}
		}
	}

	public void Respawn()
	{
		Debug.LogError("Respawn not implemented for Health script.");
	}

	public void OnRecycle()
	{
		stunHP = _fullStunHP;
		HP = fullHp;
		SetInvincible(invincible: false);
		ResetColor();
		UpdateHealthBar(Time.deltaTime);
	}

	[ContextMenu("Take 20 Damage")]
	public void DoDamage()
	{
		TakeDamage(20f, DamageTypeEnum.PHYSICAL, DamageSourceEnum.PLAYER);
	}

	[ContextMenu("Kill")]
	public void Kill()
	{
		TakeDamage(3000f, DamageTypeEnum.PHYSICAL, DamageSourceEnum.PLAYER);
	}
}
