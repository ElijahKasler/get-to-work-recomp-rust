using System;
using System.Collections.Generic;
using FMODUnity;
using Isto.Core.Audio;
using Isto.Core.Automation;
using UPool;
using UnityEngine;
using Zenject;

namespace Isto.Core.Items;

public class GrowingHarvestableVisuals : MonoBehaviour, IAutomationGridSpaceDisplay
{
	[Header("Planter Adjustments")]
	[SerializeField]
	private Vector3 _positionOffset;

	[SerializeField]
	private float _scaleFactor;

	[SerializeField]
	private Collider _harvestCollider;

	[SerializeField]
	private float _colliderScaleFactor = 1.25f;

	[SerializeField]
	private float _colliderYMoveAfterGrown = -0.25f;

	[SerializeField]
	private List<GameObject> _hideWhenOnPlanter;

	[Header("Visuals Container")]
	[SerializeField]
	private GameObject _visualsContainer;

	[Header("Animation Visuals")]
	[SerializeField]
	private AnimationClip _growStartClip;

	[SerializeField]
	private AnimationClip _growFinishClip;

	[SerializeField]
	[EventRef]
	private string _growingFinishedAudio;

	[Header("Sprite Visuals")]
	[SerializeField]
	private List<Sprite> _sprites;

	[SerializeField]
	private SpriteRenderer _spriteRenderer;

	[Space(10f)]
	[SerializeField]
	private Sprite _fullyGrownSprite;

	private Animator _anim;

	private PoolableObject _poolObj;

	protected AutomationGridSpace _gridSpace;

	private float _growthInterval;

	private int _currentSpriteIndex;

	private bool _onPlanter;

	private IGameSounds _gameSounds;

	private bool UsingAnimator
	{
		get
		{
			if (!(_growStartClip != null))
			{
				return _growFinishClip != null;
			}
			return true;
		}
	}

	[Inject]
	public void Inject(IGameSounds gameSounds)
	{
		_gameSounds = gameSounds;
	}

	public void Awake()
	{
		_anim = GetComponent<Animator>();
		if (_sprites.Count > 1)
		{
			_growthInterval = 1f / (float)_sprites.Count;
		}
		if (_visualsContainer != null)
		{
			_visualsContainer.SetActive(value: false);
		}
		if (!TryGetComponent<PoolableObject>(out _poolObj))
		{
			return;
		}
		PoolableObject poolObj = _poolObj;
		poolObj.ObjectDeallocated = (Action)Delegate.Combine(poolObj.ObjectDeallocated, (Action)(() =>
		{
			if (_gridSpace != null && _gridSpace.Resource != null)
			{
				_gridSpace.Resource.GrowthComplete -= GrowingFinish;
				if (UsingAnimator)
				{
					_anim.SetTrigger("reset");
				}
			}
		}));
	}

	public void Update()
	{
		UpdateSprites();
	}

	public void OnDestroy()
	{
		if (_gridSpace != null && _gridSpace.Resource != null)
		{
			_gridSpace.Resource.GrowthComplete -= GrowingFinish;
		}
	}

	public virtual void SetGridSpace(AutomationGridSpace space)
	{
		_gridSpace = space;
		if (space.itemProcessor is AutomationPlanter)
		{
			_onPlanter = true;
			base.transform.position += _positionOffset;
			base.transform.localScale = base.transform.localScale * _scaleFactor;
			for (int i = 0; i < _hideWhenOnPlanter.Count; i++)
			{
				_hideWhenOnPlanter[i].SetActive(value: false);
			}
		}
		space.Resource.GrowthComplete += GrowingFinish;
		if (_visualsContainer != null)
		{
			_visualsContainer.SetActive(value: true);
		}
		if (UsingAnimator && space.Resource.GrowthPercent < 1f)
		{
			_anim.enabled = true;
			_anim.Play(_growStartClip.name);
		}
	}

	private void GrowingStart(object sender, EventArgs e)
	{
		if (UsingAnimator)
		{
			_anim.Play(_growStartClip.name);
		}
	}

	private void GrowingFinish(object sender, EventArgs e)
	{
		CompleteGrowing();
	}

	protected virtual void CompleteGrowing()
	{
		if (UsingAnimator)
		{
			_anim.Play(_growFinishClip.name);
		}
		_gridSpace.Resource.GrowthComplete -= GrowingFinish;
		if (_harvestCollider != null && _gridSpace.itemProcessor is AutomationPlanter)
		{
			_harvestCollider.transform.localScale *= _colliderScaleFactor;
			_harvestCollider.transform.position += Vector3.up * _colliderYMoveAfterGrown;
		}
	}

	public void PlayGrowingSound()
	{
		if (!string.IsNullOrEmpty(_growingFinishedAudio))
		{
			_gameSounds.PlayOneShot(_growingFinishedAudio, base.transform.position);
		}
	}

	public bool IsOnPlanter()
	{
		return _onPlanter;
	}

	private void UpdateSprites()
	{
		if (_sprites.Count == 0 || _gridSpace == null || _gridSpace.Resource == null)
		{
			return;
		}
		float growthPercent = _gridSpace.Resource.GrowthPercent;
		if (growthPercent < 1f && _sprites.Count > 1)
		{
			if (_growthInterval * (float)(_currentSpriteIndex + 1) < growthPercent)
			{
				_currentSpriteIndex++;
			}
			if (_currentSpriteIndex < _sprites.Count)
			{
				_spriteRenderer.sprite = _sprites[_currentSpriteIndex];
			}
		}
		else if (_fullyGrownSprite != null)
		{
			_spriteRenderer.sprite = _fullyGrownSprite;
		}
	}
}
