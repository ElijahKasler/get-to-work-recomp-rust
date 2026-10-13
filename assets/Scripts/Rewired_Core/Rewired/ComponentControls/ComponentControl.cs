using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.ComponentControls;

[Serializable]
[DisallowMultipleComponent]
public abstract class ComponentControl : MonoBehaviour, IComponentControl
{
	private sealed class JHgPlMwaYHUwlxmlpoqxhPblAAYEA : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int TEcbVaTUBDwKVDQEpKdwJzATmDKd;

		private object uUVpleEdkrghbiwUjOsioXWCkAlW;

		public ComponentControl lkmgJmIEaxPGjGIcjMgcstaKZSOy;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return uUVpleEdkrghbiwUjOsioXWCkAlW;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return uUVpleEdkrghbiwUjOsioXWCkAlW;
			}
		}

		[DebuggerHidden]
		public JHgPlMwaYHUwlxmlpoqxhPblAAYEA(int P_0)
		{
			TEcbVaTUBDwKVDQEpKdwJzATmDKd = P_0;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int tEcbVaTUBDwKVDQEpKdwJzATmDKd = TEcbVaTUBDwKVDQEpKdwJzATmDKd;
			ComponentControl componentControl = lkmgJmIEaxPGjGIcjMgcstaKZSOy;
			switch (tEcbVaTUBDwKVDQEpKdwJzATmDKd)
			{
			default:
				return false;
			case 0:
				TEcbVaTUBDwKVDQEpKdwJzATmDKd = -1;
				uUVpleEdkrghbiwUjOsioXWCkAlW = null;
				TEcbVaTUBDwKVDQEpKdwJzATmDKd = 1;
				return true;
			case 1:
				TEcbVaTUBDwKVDQEpKdwJzATmDKd = -1;
				if (!componentControl.oaeJwcBeZoMZRNVcTgpbqRThFymT())
				{
					return false;
				}
				componentControl.OnEnable();
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private IComponentController _controller;

	[NonSerialized]
	private bool uGCCEEjRODMJuXGtccnjxODHzvhDA;

	[NonSerialized]
	private bool NbxgpMVScURueuWojWRqdbpYFYmK;

	private int _lastUpdateFrame = -1;

	internal abstract bool UuKfBWsQIvgArXrnREeZxtmoHqJfA { get; }

	internal bool FttaIIkKLhATbAAKCiElHZBpPoppb => QlySyzScDMyjiCtNiwSFHhQYXMxc();

	internal abstract bool cGatEfztsIqCLsTucDMygLcPoUUK();

	internal bool QlySyzScDMyjiCtNiwSFHhQYXMxc()
	{
		return uGCCEEjRODMJuXGtccnjxODHzvhDA;
	}

	[CustomObfuscation(rename = false)]
	internal ComponentControl()
	{
	}

	public abstract void ClearValue();

	void IComponentControl.Update()
	{
		int frameCount = Time.frameCount;
		if (_lastUpdateFrame != frameCount)
		{
			_lastUpdateFrame = frameCount;
			kIQxGaVRogzibbsOOvqmUHztgwdB();
		}
	}

	[CustomObfuscation(rename = false)]
	internal virtual void Awake()
	{
		NbxgpMVScURueuWojWRqdbpYFYmK = true;
	}

	[CustomObfuscation(rename = false)]
	internal virtual void Start()
	{
	}

	[CustomObfuscation(rename = false)]
	internal virtual void OnEnable()
	{
		if (!NbxgpMVScURueuWojWRqdbpYFYmK)
		{
			uGCCEEjRODMJuXGtccnjxODHzvhDA = false;
			StartCoroutine(qQXIMTnzedvDAoGbVNaZbwKqEQDi());
			NbxgpMVScURueuWojWRqdbpYFYmK = true;
		}
		else if (Application.isPlaying)
		{
			ubkimakmVJkRtCszXFHaclaIctpu();
		}
	}

	[CustomObfuscation(rename = false)]
	internal virtual void OnDisable()
	{
		if (Application.isPlaying)
		{
			HlbhlSoEjFICPlSgnNuKdmSdnkgv();
		}
	}

	[CustomObfuscation(rename = false)]
	internal virtual void OnDestroy()
	{
	}

	[CustomObfuscation(rename = false)]
	internal virtual void OnValidate()
	{
		if (uGCCEEjRODMJuXGtccnjxODHzvhDA)
		{
			tRpgEZYlidPDvyiNSuEvBxRSPNqP();
		}
	}

	[CustomObfuscation(rename = false)]
	internal virtual void OnCanvasGroupChanged()
	{
		if (uGCCEEjRODMJuXGtccnjxODHzvhDA)
		{
			VrvLFueOtcQFLItGSbYtWairmeJ(false, false);
		}
	}

	[CustomObfuscation(rename = false)]
	internal virtual void OnTransformParentChanged()
	{
		if (uGCCEEjRODMJuXGtccnjxODHzvhDA)
		{
			VrvLFueOtcQFLItGSbYtWairmeJ(false, false);
		}
	}

	[CustomObfuscation(rename = false)]
	internal virtual void OnDidApplyAnimationProperties()
	{
		_ = uGCCEEjRODMJuXGtccnjxODHzvhDA;
	}

	[CustomObfuscation(rename = false)]
	internal virtual void Reset()
	{
		_ = uGCCEEjRODMJuXGtccnjxODHzvhDA;
	}

	internal virtual void kIQxGaVRogzibbsOOvqmUHztgwdB()
	{
	}

	internal virtual bool FsdUEhTyInDeflICOqtuQITqTrWT()
	{
		uGCCEEjRODMJuXGtccnjxODHzvhDA = false;
		if (!VrvLFueOtcQFLItGSbYtWairmeJ(true, true))
		{
			return false;
		}
		_controller.Register(this);
		return true;
	}

	internal virtual void HlbhlSoEjFICPlSgnNuKdmSdnkgv()
	{
		ClearValue();
		if (!_controller.IsNullOrDestroyed())
		{
			_controller.Deregister(this);
		}
		UidTQXBpNskLbacEAcaiGQCoRZaEA();
		uGCCEEjRODMJuXGtccnjxODHzvhDA = false;
	}

	internal virtual void siYUHuwQhlovaiEnuWgbzvoXFJXv()
	{
		if (!_controller.IsNullOrDestroyed())
		{
			UidTQXBpNskLbacEAcaiGQCoRZaEA();
		}
	}

	internal virtual void UidTQXBpNskLbacEAcaiGQCoRZaEA()
	{
		_controller.IsNullOrDestroyed();
	}

	internal virtual void vkqeMcpvYrejUrwxCMROyCrCSmcD()
	{
		if (uGCCEEjRODMJuXGtccnjxODHzvhDA)
		{
			tRpgEZYlidPDvyiNSuEvBxRSPNqP();
		}
	}

	internal virtual void WGrRWPjtyGMsKfDIUdyYmUlKIsvP()
	{
		_ = uGCCEEjRODMJuXGtccnjxODHzvhDA;
	}

	internal virtual void KLBZDaJRxBjwjoskHhzNSdorplRS()
	{
	}

	internal bool oaeJwcBeZoMZRNVcTgpbqRThFymT()
	{
		return UnityTools.IsActiveAndEnabled(this);
	}

	internal bool NkQXqFgfLsxNEarUJhyeOugCUaYs()
	{
		return this == null;
	}

	internal IComponentController BuIhXAQcFtYVfhAxQBezxvNwKXPV()
	{
		return _controller;
	}

	[CustomObfuscation(rename = false)]
	internal abstract IComponentController FindController();

	[CustomObfuscation(rename = false)]
	internal abstract Type GetRequiredControllerType();

	[IteratorStateMachine(typeof(JHgPlMwaYHUwlxmlpoqxhPblAAYEA))]
	private IEnumerator qQXIMTnzedvDAoGbVNaZbwKqEQDi()
	{
		return new JHgPlMwaYHUwlxmlpoqxhPblAAYEA(0)
		{
			lkmgJmIEaxPGjGIcjMgcstaKZSOy = this
		};
	}

	private void ubkimakmVJkRtCszXFHaclaIctpu()
	{
		if (FsdUEhTyInDeflICOqtuQITqTrWT())
		{
			KLBZDaJRxBjwjoskHhzNSdorplRS();
			uGCCEEjRODMJuXGtccnjxODHzvhDA = true;
			siYUHuwQhlovaiEnuWgbzvoXFJXv();
		}
	}

	private bool VrvLFueOtcQFLItGSbYtWairmeJ(bool P_0, bool P_1)
	{
		bool flag = false;
		try
		{
			IComponentController componentController = FindController();
			if (!_controller.IsNullOrDestroyed() && _controller != componentController)
			{
				flag = true;
			}
			_controller = componentController;
			if (_controller == null)
			{
				Type type = GetRequiredControllerType();
				if (type == null)
				{
					type = typeof(IComponentController);
				}
				if (P_1)
				{
					Logger.LogError(type.Name + " could not be found. You must have a component that extends from " + type.Name + " on this or a parent GameObject.");
				}
				throw new Exception();
			}
			if (!P_0 & flag)
			{
				ubkimakmVJkRtCszXFHaclaIctpu();
			}
			return true;
		}
		catch
		{
			HlbhlSoEjFICPlSgnNuKdmSdnkgv();
			return false;
		}
	}

	private void tRpgEZYlidPDvyiNSuEvBxRSPNqP()
	{
		VrvLFueOtcQFLItGSbYtWairmeJ(false, true);
	}

	private void zocwuEhueaEKZfmMaBrozxvfeEVe()
	{
		if (!NkQXqFgfLsxNEarUJhyeOugCUaYs() && oaeJwcBeZoMZRNVcTgpbqRThFymT())
		{
			kIQxGaVRogzibbsOOvqmUHztgwdB();
		}
	}
}
