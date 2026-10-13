using System;
using Rewired;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;

internal sealed class edomyHoabKkWzxLwelGsLkZrDlzw : IControllerElementTarget, IPoolableObject_Internal, IPoolableObject, IDisposable
{
	[Serializable]
	private sealed class KpsJtBqKensLRBRynMiDjnZmmaod
	{
		public static readonly KpsJtBqKensLRBRynMiDjnZmmaod _003C_003E9 = new KpsJtBqKensLRBRynMiDjnZmmaod();

		public static Func<edomyHoabKkWzxLwelGsLkZrDlzw> _003C_003E9__30_0;

		internal edomyHoabKkWzxLwelGsLkZrDlzw KkaKovvgAMcTBCchFwyoppyAGbor()
		{
			return mHYNZIULtvOBtTVRcToMsSDSvYEJ();
		}
	}

	private static ObjectPool<edomyHoabKkWzxLwelGsLkZrDlzw> ptmkFKYynEGdWcZduVfUjwtJgvEp;

	private Controller FNvCcxGlvIbEfdWYykTHNIhqNRHv;

	private int MatdJCOBPHNOjqhDpbosKfIVNFjh;

	private AxisRange emIJvzilFozXZkVTJyzMqMmKRMlm;

	private IObjectPool ljucEqCBUMsRhqsbCbnRhXZxyiTn;

	private bool ArOGIMOWQOGPDJJmRVBrgcnlOJacb;

	int IControllerElementTarget.elementIdentifierId => get_elementIdentifierId();

	AxisRange IControllerElementTarget.axisRange => get_axisRange();

	bool IControllerElementTarget.hasTarget => get_hasTarget();

	ControllerElementType IControllerElementTarget.elementType => get_elementType();

	string IControllerElementTarget.descriptiveName => get_descriptiveName();

	Controller IControllerElementTarget.controller => get_controller();

	Controller.Element IControllerElementTarget.element => get_element();

	public ControllerElementIdentifier knGfNccRahKJviZQOWVJlQRZcUcEA => wjWSFkXCdysfJYSpAPFAwsyxuokV();

	IObjectPool IPoolableObject_Internal.pool
	{
		get
		{
			return ljucEqCBUMsRhqsbCbnRhXZxyiTn;
		}
		set
		{
			ljucEqCBUMsRhqsbCbnRhXZxyiTn = value;
		}
	}

	internal edomyHoabKkWzxLwelGsLkZrDlzw(Controller P_0, int P_1, AxisRange P_2)
	{
		FNvCcxGlvIbEfdWYykTHNIhqNRHv = P_0;
		MatdJCOBPHNOjqhDpbosKfIVNFjh = P_1;
		emIJvzilFozXZkVTJyzMqMmKRMlm = P_2;
	}

	internal void mHzVdPXVeXSbZxFKknILpiVnvvdu(ControllerElementTarget P_0)
	{
		FNvCcxGlvIbEfdWYykTHNIhqNRHv = P_0.controller;
		MatdJCOBPHNOjqhDpbosKfIVNFjh = P_0.elementIdentifierId;
		emIJvzilFozXZkVTJyzMqMmKRMlm = P_0.axisRange;
	}

	internal void aiQapFcfYuPgueVauvQhJfhOzIWx(IControllerElementTarget P_0)
	{
		FNvCcxGlvIbEfdWYykTHNIhqNRHv = P_0.controller;
		MatdJCOBPHNOjqhDpbosKfIVNFjh = P_0.elementIdentifierId;
		emIJvzilFozXZkVTJyzMqMmKRMlm = P_0.axisRange;
	}

	internal void IAHzyDBWnBEsKTSmcQzqXrBsAmre(edomyHoabKkWzxLwelGsLkZrDlzw P_0)
	{
		aiQapFcfYuPgueVauvQhJfhOzIWx(P_0);
	}

	public int get_elementIdentifierId()
	{
		return MatdJCOBPHNOjqhDpbosKfIVNFjh;
	}

	public AxisRange get_axisRange()
	{
		return emIJvzilFozXZkVTJyzMqMmKRMlm;
	}

	public bool get_hasTarget()
	{
		return get_element() != null;
	}

	public ControllerElementType get_elementType()
	{
		if (get_element() == null)
		{
			return ControllerElementType.Axis;
		}
		return get_element().type;
	}

	public string get_descriptiveName()
	{
		if (FNvCcxGlvIbEfdWYykTHNIhqNRHv == null)
		{
			return string.Empty;
		}
		ControllerElementIdentifier elementIdentifierById = FNvCcxGlvIbEfdWYykTHNIhqNRHv.GetElementIdentifierById(MatdJCOBPHNOjqhDpbosKfIVNFjh);
		if (elementIdentifierById == null)
		{
			return string.Empty;
		}
		Controller.Element elementById = FNvCcxGlvIbEfdWYykTHNIhqNRHv.GetElementById(MatdJCOBPHNOjqhDpbosKfIVNFjh);
		if (elementById == null)
		{
			return string.Empty;
		}
		return elementIdentifierById.GetDisplayName(elementById.type, emIJvzilFozXZkVTJyzMqMmKRMlm);
	}

	public Controller get_controller()
	{
		return FNvCcxGlvIbEfdWYykTHNIhqNRHv;
	}

	public Controller.Element get_element()
	{
		if (FNvCcxGlvIbEfdWYykTHNIhqNRHv == null)
		{
			return null;
		}
		if (FNvCcxGlvIbEfdWYykTHNIhqNRHv.GetElementIdentifierById(MatdJCOBPHNOjqhDpbosKfIVNFjh) == null)
		{
			return null;
		}
		return FNvCcxGlvIbEfdWYykTHNIhqNRHv.GetElementById(MatdJCOBPHNOjqhDpbosKfIVNFjh);
	}

	public ControllerElementIdentifier wjWSFkXCdysfJYSpAPFAwsyxuokV()
	{
		if (FNvCcxGlvIbEfdWYykTHNIhqNRHv == null)
		{
			return null;
		}
		return FNvCcxGlvIbEfdWYykTHNIhqNRHv.GetElementIdentifierById(MatdJCOBPHNOjqhDpbosKfIVNFjh);
	}

	void IPoolableObject_Internal.Clear()
	{
		FNvCcxGlvIbEfdWYykTHNIhqNRHv = null;
		MatdJCOBPHNOjqhDpbosKfIVNFjh = -1;
		emIJvzilFozXZkVTJyzMqMmKRMlm = AxisRange.Full;
	}

	void IPoolableObject.Return()
	{
		if (ljucEqCBUMsRhqsbCbnRhXZxyiTn != null)
		{
			ljucEqCBUMsRhqsbCbnRhXZxyiTn.Return(this);
		}
	}

	internal static edomyHoabKkWzxLwelGsLkZrDlzw hCdZvTyNEtFRzwlEfVDYOMrcfRrB()
	{
		if (ptmkFKYynEGdWcZduVfUjwtJgvEp == null)
		{
			ptmkFKYynEGdWcZduVfUjwtJgvEp = new ObjectPool<edomyHoabKkWzxLwelGsLkZrDlzw>(KpsJtBqKensLRBRynMiDjnZmmaod._003C_003E9.KkaKovvgAMcTBCchFwyoppyAGbor);
		}
		return ptmkFKYynEGdWcZduVfUjwtJgvEp.Get();
	}

	internal static edomyHoabKkWzxLwelGsLkZrDlzw YrulkGTOzpYsHraDBHAumBfMBGzd(ControllerElementTarget P_0)
	{
		edomyHoabKkWzxLwelGsLkZrDlzw obj = hCdZvTyNEtFRzwlEfVDYOMrcfRrB();
		obj.mHzVdPXVeXSbZxFKknILpiVnvvdu(P_0);
		return obj;
	}

	internal static void ZQnGowaWMdKIQroVeeRgAzvXTUJX(edomyHoabKkWzxLwelGsLkZrDlzw P_0)
	{
		if (P_0 != null && ptmkFKYynEGdWcZduVfUjwtJgvEp != null)
		{
			ptmkFKYynEGdWcZduVfUjwtJgvEp.Return(P_0);
		}
	}

	internal static edomyHoabKkWzxLwelGsLkZrDlzw mHYNZIULtvOBtTVRcToMsSDSvYEJ()
	{
		return new edomyHoabKkWzxLwelGsLkZrDlzw(null, -1, AxisRange.Full);
	}

	void IDisposable.Dispose()
	{
		SvQGTbxSfStCnzmjylOwfQvubmsF(true);
		GC.SuppressFinalize(this);
	}

	protected void qVfLyCfVQpmOWfiRcBdAOErpVzbL()
	{
		try
		{
			SvQGTbxSfStCnzmjylOwfQvubmsF(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	private void SvQGTbxSfStCnzmjylOwfQvubmsF(bool P_0)
	{
		if (!ArOGIMOWQOGPDJJmRVBrgcnlOJacb)
		{
			if (P_0)
			{
				((IPoolableObject)this).Return();
			}
			ArOGIMOWQOGPDJJmRVBrgcnlOJacb = true;
		}
	}
}
