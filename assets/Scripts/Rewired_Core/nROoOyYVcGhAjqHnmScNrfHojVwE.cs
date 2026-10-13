using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

internal class nROoOyYVcGhAjqHnmScNrfHojVwE
{
	private class dYbaxPYQXXgniDzXwMxabYkDBTQtA
	{
		private readonly AList<IControllerTemplate> SWGelomRHiqsjuSeSPfDYCQWIelG;

		private IList CwKSvEoiWpJErmFmBQaKWJtldMIN;

		private IList IOccrYBMwoOgKoVFIzyMrQqsqpYh;

		public readonly Type gHZZUiSydpVeEdtIkLhYNbhaEnqQ;

		public dYbaxPYQXXgniDzXwMxabYkDBTQtA(Type P_0)
		{
			gHZZUiSydpVeEdtIkLhYNbhaEnqQ = P_0;
			SWGelomRHiqsjuSeSPfDYCQWIelG = new AList<IControllerTemplate>();
		}

		public IList<_0001> vUSVXTcyQPCHDbktlNghWFDufzpk<_0001>() where _0001 : IControllerTemplate
		{
			if (CwKSvEoiWpJErmFmBQaKWJtldMIN == null)
			{
				OTqVfheSiccPkgrsJnhjcArDkTTf<_0001>();
			}
			return IOccrYBMwoOgKoVFIzyMrQqsqpYh as IList<_0001>;
		}

		public void PnbCOomkcUEPmgQHPIgIdHYFcSIOA(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				SWGelomRHiqsjuSeSPfDYCQWIelG.Add(P_0);
				if (CwKSvEoiWpJErmFmBQaKWJtldMIN != null)
				{
					CwKSvEoiWpJErmFmBQaKWJtldMIN.Add(P_0);
				}
			}
		}

		public void zergPNyFmjaRpTXZGFCkGopyfCGQ(IControllerTemplate P_0)
		{
			if (P_0 != null)
			{
				SWGelomRHiqsjuSeSPfDYCQWIelG.Remove(P_0);
				if (CwKSvEoiWpJErmFmBQaKWJtldMIN != null)
				{
					CwKSvEoiWpJErmFmBQaKWJtldMIN.Remove(P_0);
				}
			}
		}

		private void OTqVfheSiccPkgrsJnhjcArDkTTf<_0001>() where _0001 : IControllerTemplate
		{
			CwKSvEoiWpJErmFmBQaKWJtldMIN = new AList<_0001>();
			IOccrYBMwoOgKoVFIzyMrQqsqpYh = new ReadOnlyCollection<_0001>((AList<_0001>)CwKSvEoiWpJErmFmBQaKWJtldMIN);
			for (int i = 0; i < SWGelomRHiqsjuSeSPfDYCQWIelG._count; i++)
			{
				CwKSvEoiWpJErmFmBQaKWJtldMIN.Add(SWGelomRHiqsjuSeSPfDYCQWIelG._items[i]);
			}
		}
	}

	private readonly AList<dYbaxPYQXXgniDzXwMxabYkDBTQtA> oLwWQKfFXSlQOdGTtfSZFBCqVlws;

	private readonly Type[] GBfYHvZTFyryJjhmITJIeGwhMhSf;

	private readonly Type[] FdBDcBYunzsdTiRHxpIcQhgCdmcP;

	private readonly int DypPIhfOeZjsNbnAvTiOeGqINqWdb;

	public nROoOyYVcGhAjqHnmScNrfHojVwE(Type[] P_0, Type[] P_1)
	{
		if (P_0.Length != P_1.Length)
		{
			throw new Exception("Controller template types and controller template interface types array lengths do not match.");
		}
		GBfYHvZTFyryJjhmITJIeGwhMhSf = P_0;
		FdBDcBYunzsdTiRHxpIcQhgCdmcP = P_1;
		DypPIhfOeZjsNbnAvTiOeGqINqWdb = GBfYHvZTFyryJjhmITJIeGwhMhSf.Length;
		oLwWQKfFXSlQOdGTtfSZFBCqVlws = new AList<dYbaxPYQXXgniDzXwMxabYkDBTQtA>();
		for (int i = 0; i < DypPIhfOeZjsNbnAvTiOeGqINqWdb; i++)
		{
			oLwWQKfFXSlQOdGTtfSZFBCqVlws.Add(new dYbaxPYQXXgniDzXwMxabYkDBTQtA(FdBDcBYunzsdTiRHxpIcQhgCdmcP[i]));
		}
	}

	public void NwCwRIqaKzXsvjtkBWSnlYNaVrQU(Controller P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		int templateCount = P_0.templateCount;
		for (int i = 0; i < templateCount; i++)
		{
			IControllerTemplate controllerTemplate = P_0.Templates[i];
			if (controllerTemplate == null)
			{
				Logger.LogError("Template was null.");
				continue;
			}
			Type type = KaGGshdJOsAMOggQBnnhsbWWqZTQ(controllerTemplate.GetType());
			if (type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				jEPFNYFvKEFcnxqWvwIMJYQNLqnWA(type)?.PnbCOomkcUEPmgQHPIgIdHYFcSIOA(controllerTemplate);
			}
		}
	}

	public void wUdFOsjHwFtryZkSuYDfCgLNwGrj(Controller P_0)
	{
		if (P_0 == null)
		{
			return;
		}
		int templateCount = P_0.templateCount;
		for (int i = 0; i < templateCount; i++)
		{
			IControllerTemplate controllerTemplate = P_0.Templates[i];
			if (controllerTemplate == null)
			{
				Logger.LogError("Template was null.");
				continue;
			}
			Type type = KaGGshdJOsAMOggQBnnhsbWWqZTQ(controllerTemplate.GetType());
			if (type == null)
			{
				Logger.LogError("Interface type " + controllerTemplate.GetType().Name + " was not found.");
			}
			else
			{
				jEPFNYFvKEFcnxqWvwIMJYQNLqnWA(type)?.zergPNyFmjaRpTXZGFCkGopyfCGQ(controllerTemplate);
			}
		}
	}

	public IList<_0001> bpzHUQyiYjpOkNEdpYqviVucnLDW<_0001>() where _0001 : IControllerTemplate
	{
		Type typeFromHandle = typeof(_0001);
		for (int i = 0; i < oLwWQKfFXSlQOdGTtfSZFBCqVlws._count; i++)
		{
			dYbaxPYQXXgniDzXwMxabYkDBTQtA dYbaxPYQXXgniDzXwMxabYkDBTQtA2 = oLwWQKfFXSlQOdGTtfSZFBCqVlws._items[i];
			if ((object)dYbaxPYQXXgniDzXwMxabYkDBTQtA2.gHZZUiSydpVeEdtIkLhYNbhaEnqQ == typeFromHandle)
			{
				return dYbaxPYQXXgniDzXwMxabYkDBTQtA2.vUSVXTcyQPCHDbktlNghWFDufzpk<_0001>();
			}
		}
		string text = "";
		for (int j = 0; j < FdBDcBYunzsdTiRHxpIcQhgCdmcP.Length; j++)
		{
			text += FdBDcBYunzsdTiRHxpIcQhgCdmcP[j].Name;
			if (j != FdBDcBYunzsdTiRHxpIcQhgCdmcP.Length - 1)
			{
				text += "\n";
			}
		}
		Logger.LogError("Invalid Controller Template type \"" + typeFromHandle.Name + "\". Only the following Controller Template interface types are allowed:\n" + text);
		return EmptyObjects<_0001>.EmptyReadOnlyIListT;
	}

	private dYbaxPYQXXgniDzXwMxabYkDBTQtA jEPFNYFvKEFcnxqWvwIMJYQNLqnWA(Type P_0)
	{
		for (int i = 0; i < oLwWQKfFXSlQOdGTtfSZFBCqVlws._count; i++)
		{
			if ((object)P_0 == oLwWQKfFXSlQOdGTtfSZFBCqVlws._items[i].gHZZUiSydpVeEdtIkLhYNbhaEnqQ)
			{
				return oLwWQKfFXSlQOdGTtfSZFBCqVlws._items[i];
			}
		}
		return null;
	}

	private Type KaGGshdJOsAMOggQBnnhsbWWqZTQ(Type P_0)
	{
		for (int i = 0; i < DypPIhfOeZjsNbnAvTiOeGqINqWdb; i++)
		{
			if ((object)GBfYHvZTFyryJjhmITJIeGwhMhSf[i] == P_0)
			{
				return FdBDcBYunzsdTiRHxpIcQhgCdmcP[i];
			}
		}
		return null;
	}
}
