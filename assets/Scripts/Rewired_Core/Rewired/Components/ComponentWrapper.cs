using System;
using UnityEngine;

namespace Rewired.Components;

[Serializable]
[AddComponentMenu("")]
public abstract class ComponentWrapper<T> : MonoBehaviour where T : class
{
	[NonSerialized]
	private T zBaHGncSMPhzUgSUKvWSuARwWgVF;

	[NonSerialized]
	private bool tNiKPAYJSJGVZXOOGKOyVPSrfWKaA;

	protected T source => zBaHGncSMPhzUgSUKvWSuARwWgVF;

	protected bool initialized => tNiKPAYJSJGVZXOOGKOyVPSrfWKaA;

	[CustomObfuscation(rename = false)]
	private void Awake()
	{
		OnAwake();
		OnAwakeFinished();
	}

	[CustomObfuscation(rename = false)]
	private void Start()
	{
		OnStart();
	}

	[CustomObfuscation(rename = false)]
	private void OnEnable()
	{
		OnEnabled();
	}

	[CustomObfuscation(rename = false)]
	private void OnDisable()
	{
		OnDisabled();
	}

	[CustomObfuscation(rename = false)]
	private void OnDestroy()
	{
		OnDestroyed();
	}

	[CustomObfuscation(rename = false)]
	private void Reset()
	{
		OnReset();
	}

	[CustomObfuscation(rename = false)]
	private void OnValidate()
	{
		OnValidated();
	}

	protected virtual void OnAwake()
	{
		ReInput.InitializedEvent += mHfAMqExVrObHNyakadJcAYJYRlpb;
		Initialize();
	}

	protected virtual void OnAwakeFinished()
	{
	}

	protected virtual void OnStart()
	{
	}

	protected virtual void OnEnabled()
	{
	}

	protected virtual void OnDisabled()
	{
	}

	protected virtual void OnDestroyed()
	{
		Unsubscribe();
		ReInput.InitializedEvent -= mHfAMqExVrObHNyakadJcAYJYRlpb;
	}

	protected virtual void OnReset()
	{
	}

	protected virtual void OnValidated()
	{
	}

	protected virtual void Initialize()
	{
		if (TryInitialize())
		{
			tNiKPAYJSJGVZXOOGKOyVPSrfWKaA = true;
			PostInitialize();
		}
	}

	protected virtual bool TryInitialize()
	{
		if (tNiKPAYJSJGVZXOOGKOyVPSrfWKaA)
		{
			return false;
		}
		zBaHGncSMPhzUgSUKvWSuARwWgVF = CreateSource(GetCreateSourceArgs());
		if (zBaHGncSMPhzUgSUKvWSuARwWgVF == null)
		{
			Logger.LogError("Failed to create source object.");
			return false;
		}
		tNiKPAYJSJGVZXOOGKOyVPSrfWKaA = true;
		return true;
	}

	protected abstract T CreateSource(object args);

	protected abstract object GetCreateSourceArgs();

	protected virtual void PostInitialize()
	{
		Subscribe();
	}

	protected virtual void Deinitialize()
	{
		tNiKPAYJSJGVZXOOGKOyVPSrfWKaA = false;
		Unsubscribe();
		zBaHGncSMPhzUgSUKvWSuARwWgVF = null;
	}

	protected virtual void Subscribe()
	{
		Unsubscribe();
		ReInput.ShutDownEvent += KjMgXAIjbGXmypyySsgNCfmKlUNd;
	}

	protected virtual void Unsubscribe()
	{
		ReInput.ShutDownEvent -= KjMgXAIjbGXmypyySsgNCfmKlUNd;
	}

	private void KjMgXAIjbGXmypyySsgNCfmKlUNd()
	{
		Deinitialize();
	}

	private void mHfAMqExVrObHNyakadJcAYJYRlpb()
	{
		Initialize();
	}
}
