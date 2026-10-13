using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using Rewired.Utils.Interfaces;
using UnityEngine;

namespace Rewired.ComponentControls;

[Serializable]
[DisallowMultipleComponent]
public abstract class ComponentController : MonoBehaviour, IComponentController, IRegistrar<IComponentControl>
{
	private sealed class PPOAkfGAcSjHRzpSxkkIcNOjPKxFA : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int kRDJizyWcJRGVOjLRiebtbrEwVQq;

		private object qwPAAfbEESucHDuKgVMunrLzIIsF;

		public ComponentController kwtcFvAmNXOmhyxSaRRmcIqqLYrP;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return qwPAAfbEESucHDuKgVMunrLzIIsF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return qwPAAfbEESucHDuKgVMunrLzIIsF;
			}
		}

		[DebuggerHidden]
		public PPOAkfGAcSjHRzpSxkkIcNOjPKxFA(int P_0)
		{
			kRDJizyWcJRGVOjLRiebtbrEwVQq = P_0;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = kRDJizyWcJRGVOjLRiebtbrEwVQq;
			ComponentController componentController = kwtcFvAmNXOmhyxSaRRmcIqqLYrP;
			switch (num)
			{
			default:
				return false;
			case 0:
				kRDJizyWcJRGVOjLRiebtbrEwVQq = -1;
				qwPAAfbEESucHDuKgVMunrLzIIsF = null;
				kRDJizyWcJRGVOjLRiebtbrEwVQq = 1;
				return true;
			case 1:
				kRDJizyWcJRGVOjLRiebtbrEwVQq = -1;
				componentController.WCncdsFUaWQMhBVAuVkkRmCCmWuIA();
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

	[NonSerialized]
	private bool ooEDXEhUHnaEORLtwmLwXFkWyGgN;

	[NonSerialized]
	private bool OOPzDINkaZIzhnpGBOwPQCLNMlXV;

	private List<IComponentControl> _controls = new List<IComponentControl>(10);

	internal bool GnrZcowmOnrwcWIIevLbWCmUoXar => qDgftULavQAHtDpDqbEZBWFeELMo();

	internal bool qDgftULavQAHtDpDqbEZBWFeELMo()
	{
		return ooEDXEhUHnaEORLtwmLwXFkWyGgN;
	}

	[CustomObfuscation(rename = false)]
	internal ComponentController()
	{
	}

	[CustomObfuscation(rename = false)]
	internal virtual void Awake()
	{
		OOPzDINkaZIzhnpGBOwPQCLNMlXV = true;
	}

	[CustomObfuscation(rename = false)]
	internal virtual void Update()
	{
		if (!ooEDXEhUHnaEORLtwmLwXFkWyGgN)
		{
			return;
		}
		for (int num = _controls.Count - 1; num >= 0; num--)
		{
			IComponentControl componentControl = _controls[num];
			if (componentControl.IsNullOrDestroyed())
			{
				_controls.RemoveAt(num);
			}
			else
			{
				componentControl.Update();
			}
		}
	}

	[CustomObfuscation(rename = false)]
	internal virtual void OnEnable()
	{
		if (!OOPzDINkaZIzhnpGBOwPQCLNMlXV)
		{
			StartCoroutine(OQMdIoyoVdaCKYxuQmefUanQBAnHA());
			OOPzDINkaZIzhnpGBOwPQCLNMlXV = true;
		}
		else
		{
			WCncdsFUaWQMhBVAuVkkRmCCmWuIA();
		}
	}

	[CustomObfuscation(rename = false)]
	internal virtual void OnDisable()
	{
		if (ooEDXEhUHnaEORLtwmLwXFkWyGgN)
		{
			aloTWbsZhLukGpgapUbwAPoZbUQt();
		}
	}

	[CustomObfuscation(rename = false)]
	internal virtual void OnValidate()
	{
		if (ooEDXEhUHnaEORLtwmLwXFkWyGgN)
		{
			EYNBnNuYuFqFbJVwHKLahVBrPBmf();
		}
	}

	[CustomObfuscation(rename = false)]
	internal virtual void OnDestroy()
	{
		_controls.Clear();
	}

	internal virtual bool ZeWESYHNLbQlnSMROFUUFqeigMEBB()
	{
		return true;
	}

	internal virtual void efJirsEHzgEGSbUrZEVmNTltmjoiA()
	{
		aloTWbsZhLukGpgapUbwAPoZbUQt();
	}

	internal virtual void aloTWbsZhLukGpgapUbwAPoZbUQt()
	{
	}

	void IRegistrar<IComponentControl>.Register(IComponentControl control)
	{
		if (!control.IsNullOrDestroyed())
		{
			ListTools.AddIfUnique(_controls, control);
		}
	}

	void IRegistrar<IComponentControl>.Deregister(IComponentControl control)
	{
		if (!control.IsNullOrDestroyed())
		{
			_controls.Remove(control);
		}
	}

	public virtual void ClearControlValues()
	{
		if (!ooEDXEhUHnaEORLtwmLwXFkWyGgN)
		{
			return;
		}
		for (int num = _controls.Count - 1; num >= 0; num--)
		{
			if (_controls[num].IsNullOrDestroyed())
			{
				_controls.RemoveAt(num);
			}
			else
			{
				_controls[num].ClearValue();
			}
		}
	}

	void IComponentController.ClearControlValues()
	{
		//ILSpy generated this explicit interface implementation from .override directive in ClearControlValues
		this.ClearControlValues();
	}

	private void WCncdsFUaWQMhBVAuVkkRmCCmWuIA()
	{
		if (ZeWESYHNLbQlnSMROFUUFqeigMEBB())
		{
			ooEDXEhUHnaEORLtwmLwXFkWyGgN = true;
			efJirsEHzgEGSbUrZEVmNTltmjoiA();
		}
	}

	private void EYNBnNuYuFqFbJVwHKLahVBrPBmf()
	{
		qDgftULavQAHtDpDqbEZBWFeELMo();
	}

	[IteratorStateMachine(typeof(PPOAkfGAcSjHRzpSxkkIcNOjPKxFA))]
	private IEnumerator OQMdIoyoVdaCKYxuQmefUanQBAnHA()
	{
		return new PPOAkfGAcSjHRzpSxkkIcNOjPKxFA(0)
		{
			kwtcFvAmNXOmhyxSaRRmcIqqLYrP = this
		};
	}
}
