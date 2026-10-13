using System;
using System.Collections.Generic;
using System.Linq;
using Isto.Core.UI.ButtonStyles;
using UnityEngine;

namespace Isto.Core.UI;

[RequireComponent(typeof(CoreButton))]
public class CoreButtonStyleController : MonoBehaviour
{
	[Serializable]
	public class CoreButtonStyleElement
	{
		[Serializable]
		public class TransitionPair
		{
			public CoreButtonTransitionBase transition;

			public CoreButtonStyle style;

			public void SetStyle()
			{
				if (transition != null)
				{
					(transition as ICoreButtonStyled)?.SetStyle(style);
				}
			}
		}

		public string name = "Style";

		public List<TransitionPair> transitionPairs = new List<TransitionPair>();

		public void AddTransitions(CoreButtonTransitionBase[] transitions, bool doubleCheck = true)
		{
			int i;
			for (i = 0; i < transitions.Length; i++)
			{
				if (!doubleCheck || !transitionPairs.Any((TransitionPair x) => x.transition != null && x.transition.GetType() == transitions[i].GetType()))
				{
					transitionPairs.Add(new TransitionPair
					{
						transition = transitions[i]
					});
				}
			}
		}

		public void SetStyle()
		{
			foreach (TransitionPair transitionPair in transitionPairs)
			{
				transitionPair.SetStyle();
			}
		}
	}

	[SerializeField]
	[CoreButtonStyleElementShowName]
	public List<CoreButtonStyleElement> buttonStyles = new List<CoreButtonStyleElement>();

	public void SetButtonStyle(int styleId)
	{
		if (styleId >= 0 && styleId < buttonStyles.Count)
		{
			buttonStyles[styleId].SetStyle();
		}
	}

	public void SetButtonStyle(string name)
	{
		int buttonStyle = buttonStyles.FindIndex((CoreButtonStyleElement x) => x.name == name);
		SetButtonStyle(buttonStyle);
	}

	[ContextMenu("Auto Complete Missing Transitions")]
	public void AutoCompleteMissingTransitions()
	{
		CoreButtonTransitionBase[] components = GetComponents<CoreButtonTransitionBase>();
		foreach (CoreButtonStyleElement buttonStyle in buttonStyles)
		{
			buttonStyle.AddTransitions(components);
		}
	}
}
