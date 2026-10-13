#define UNITY_ASSERTIONS
namespace UnityEngine.UIElements.UIR;

internal static class CommandManipulator
{
	private static bool IsParentOrAncestorOf(this VisualElement ve, VisualElement child)
	{
		while (child.hierarchy.parent != null)
		{
			if (child.hierarchy.parent == ve)
			{
				return true;
			}
			child = child.hierarchy.parent;
		}
		return false;
	}

	public static void ReplaceCommands(RenderChain renderChain, VisualElement ve, EntryProcessor processor)
	{
		if (processor.firstHeadCommand == null && processor.firstTailCommand == null && ve.renderChainData.firstHeadCommand != null)
		{
			ResetCommands(renderChain, ve);
			return;
		}
		bool flag = false;
		RenderChainCommand prev = null;
		RenderChainCommand next = null;
		if (ve.renderChainData.firstHeadCommand != null)
		{
			prev = ve.renderChainData.firstHeadCommand.prev;
			next = ve.renderChainData.lastHeadCommand.next;
			RemoveChain(renderChain, ve.renderChainData.firstHeadCommand, ve.renderChainData.lastHeadCommand);
			flag = true;
		}
		if (processor.firstHeadCommand != null)
		{
			if (!flag)
			{
				FindHeadCommandInsertionPoint(ve, out prev, out next);
			}
			if (prev != null)
			{
				processor.firstHeadCommand.prev = prev;
				prev.next = processor.firstHeadCommand;
			}
			if (next != null)
			{
				processor.lastHeadCommand.next = next;
				next.prev = processor.lastHeadCommand;
			}
			renderChain.OnRenderCommandAdded(processor.firstHeadCommand);
		}
		ve.renderChainData.firstHeadCommand = processor.firstHeadCommand;
		ve.renderChainData.lastHeadCommand = processor.lastHeadCommand;
		bool flag2 = false;
		RenderChainCommand prev2 = null;
		RenderChainCommand next2 = null;
		if (ve.renderChainData.firstTailCommand != null)
		{
			prev2 = ve.renderChainData.firstTailCommand.prev;
			next2 = ve.renderChainData.lastTailCommand.next;
			RemoveChain(renderChain, ve.renderChainData.firstTailCommand, ve.renderChainData.lastTailCommand);
			flag2 = true;
		}
		if (processor.firstTailCommand != null)
		{
			if (!flag2)
			{
				FindTailCommandInsertionPoint(ve, out prev2, out next2);
			}
			if (prev2 != null)
			{
				processor.firstTailCommand.prev = prev2;
				prev2.next = processor.firstTailCommand;
			}
			if (next2 != null)
			{
				processor.lastTailCommand.next = next2;
				next2.prev = processor.lastTailCommand;
			}
			renderChain.OnRenderCommandAdded(processor.firstTailCommand);
		}
		ve.renderChainData.firstTailCommand = processor.firstTailCommand;
		ve.renderChainData.lastTailCommand = processor.lastTailCommand;
	}

	private static void FindHeadCommandInsertionPoint(VisualElement ve, out RenderChainCommand prev, out RenderChainCommand next)
	{
		VisualElement prev2 = ve.renderChainData.prev;
		while (prev2 != null && prev2.renderChainData.lastHeadCommand == null)
		{
			prev2 = prev2.renderChainData.prev;
		}
		if (prev2 != null && prev2.renderChainData.lastHeadCommand != null)
		{
			if (prev2.hierarchy.parent == ve.hierarchy.parent)
			{
				prev = prev2.renderChainData.lastTailOrHeadCommand;
			}
			else if (prev2.IsParentOrAncestorOf(ve))
			{
				prev = prev2.renderChainData.lastHeadCommand;
			}
			else
			{
				RenderChainCommand renderChainCommand = prev2.renderChainData.lastTailOrHeadCommand;
				do
				{
					prev = renderChainCommand;
					renderChainCommand = renderChainCommand.next;
				}
				while (renderChainCommand != null && renderChainCommand.owner != ve && renderChainCommand.isTail && !renderChainCommand.owner.IsParentOrAncestorOf(ve));
			}
			next = prev.next;
		}
		else
		{
			VisualElement next2 = ve.renderChainData.next;
			while (next2 != null && next2.renderChainData.firstHeadCommand == null)
			{
				next2 = next2.renderChainData.next;
			}
			next = next2?.renderChainData.firstHeadCommand;
			prev = null;
			Debug.Assert(next == null || next.prev == null);
		}
	}

	private static void FindTailCommandInsertionPoint(VisualElement ve, out RenderChainCommand prev, out RenderChainCommand next)
	{
		VisualElement visualElement = ve.renderChainData.next;
		while (visualElement != null && visualElement.renderChainData.firstHeadCommand == null)
		{
			visualElement = visualElement.renderChainData.next;
		}
		if (visualElement != null && visualElement.renderChainData.firstHeadCommand != null)
		{
			if (visualElement.hierarchy.parent == ve.hierarchy.parent)
			{
				next = visualElement.renderChainData.firstHeadCommand;
				prev = next.prev;
			}
			else if (ve.IsParentOrAncestorOf(visualElement))
			{
				do
				{
					prev = visualElement.renderChainData.lastTailOrHeadCommand;
					visualElement = prev.next?.owner;
				}
				while (visualElement != null && ve.IsParentOrAncestorOf(visualElement));
				next = prev.next;
			}
			else
			{
				prev = ve.renderChainData.lastHeadCommand;
				next = prev.next;
			}
		}
		else
		{
			prev = ve.renderChainData.lastHeadCommand;
			next = prev.next;
		}
	}

	private static void RemoveChain(RenderChain renderChain, RenderChainCommand first, RenderChainCommand last)
	{
		Debug.Assert(first != null);
		Debug.Assert(last != null);
		renderChain.OnRenderCommandsRemoved(first, last);
		if (first.prev != null)
		{
			first.prev.next = last.next;
		}
		if (last.next != null)
		{
			last.next.prev = first.prev;
		}
		RenderChainCommand renderChainCommand = first;
		RenderChainCommand renderChainCommand2;
		do
		{
			RenderChainCommand next = renderChainCommand.next;
			renderChain.FreeCommand(renderChainCommand);
			renderChainCommand2 = renderChainCommand;
			renderChainCommand = next;
		}
		while (renderChainCommand2 != last);
	}

	public static void ResetCommands(RenderChain renderChain, VisualElement ve)
	{
		if (ve.renderChainData.firstHeadCommand != null)
		{
			renderChain.OnRenderCommandsRemoved(ve.renderChainData.firstHeadCommand, ve.renderChainData.lastHeadCommand);
		}
		RenderChainCommand renderChainCommand = ((ve.renderChainData.firstHeadCommand != null) ? ve.renderChainData.firstHeadCommand.prev : null);
		RenderChainCommand renderChainCommand2 = ((ve.renderChainData.lastHeadCommand != null) ? ve.renderChainData.lastHeadCommand.next : null);
		Debug.Assert(renderChainCommand == null || renderChainCommand.owner != ve);
		Debug.Assert(renderChainCommand2 == null || renderChainCommand2 == ve.renderChainData.firstTailCommand || renderChainCommand2.owner != ve);
		if (renderChainCommand != null)
		{
			renderChainCommand.next = renderChainCommand2;
		}
		if (renderChainCommand2 != null)
		{
			renderChainCommand2.prev = renderChainCommand;
		}
		if (ve.renderChainData.firstHeadCommand != null)
		{
			RenderChainCommand renderChainCommand3 = ve.renderChainData.firstHeadCommand;
			while (renderChainCommand3 != ve.renderChainData.lastHeadCommand)
			{
				RenderChainCommand next = renderChainCommand3.next;
				renderChain.FreeCommand(renderChainCommand3);
				renderChainCommand3 = next;
			}
			renderChain.FreeCommand(renderChainCommand3);
		}
		ve.renderChainData.firstHeadCommand = (ve.renderChainData.lastHeadCommand = null);
		renderChainCommand = ((ve.renderChainData.firstTailCommand != null) ? ve.renderChainData.firstTailCommand.prev : null);
		renderChainCommand2 = ((ve.renderChainData.lastTailCommand != null) ? ve.renderChainData.lastTailCommand.next : null);
		Debug.Assert(renderChainCommand == null || renderChainCommand.owner != ve);
		Debug.Assert(renderChainCommand2 == null || renderChainCommand2.owner != ve);
		if (renderChainCommand != null)
		{
			renderChainCommand.next = renderChainCommand2;
		}
		if (renderChainCommand2 != null)
		{
			renderChainCommand2.prev = renderChainCommand;
		}
		if (ve.renderChainData.firstTailCommand != null)
		{
			renderChain.OnRenderCommandsRemoved(ve.renderChainData.firstTailCommand, ve.renderChainData.lastTailCommand);
			RenderChainCommand renderChainCommand4 = ve.renderChainData.firstTailCommand;
			while (renderChainCommand4 != ve.renderChainData.lastTailCommand)
			{
				RenderChainCommand next2 = renderChainCommand4.next;
				renderChain.FreeCommand(renderChainCommand4);
				renderChainCommand4 = next2;
			}
			renderChain.FreeCommand(renderChainCommand4);
		}
		ve.renderChainData.firstTailCommand = (ve.renderChainData.lastTailCommand = null);
	}

	private static void InjectCommandInBetween(RenderChain renderChain, RenderChainCommand cmd, RenderChainCommand prev, RenderChainCommand next)
	{
		if (prev != null)
		{
			cmd.prev = prev;
			prev.next = cmd;
		}
		if (next != null)
		{
			cmd.next = next;
			next.prev = cmd;
		}
		VisualElement owner = cmd.owner;
		if (!cmd.isTail)
		{
			if (owner.renderChainData.firstHeadCommand == null || owner.renderChainData.firstHeadCommand == next)
			{
				owner.renderChainData.firstHeadCommand = cmd;
			}
			if (owner.renderChainData.lastHeadCommand == null || owner.renderChainData.lastHeadCommand == prev)
			{
				owner.renderChainData.lastHeadCommand = cmd;
			}
		}
		else
		{
			if (owner.renderChainData.firstTailCommand == null || owner.renderChainData.firstTailCommand == next)
			{
				owner.renderChainData.firstTailCommand = cmd;
			}
			if (owner.renderChainData.lastTailCommand == null || owner.renderChainData.lastTailCommand == prev)
			{
				owner.renderChainData.lastTailCommand = cmd;
			}
		}
		renderChain.OnRenderCommandAdded(cmd);
	}

	public static void DisableElementRendering(RenderChain renderChain, VisualElement ve, bool renderingDisabled)
	{
		if (!ve.renderChainData.isInChain)
		{
			return;
		}
		if (renderingDisabled)
		{
			if (ve.renderChainData.firstHeadCommand == null || ve.renderChainData.firstHeadCommand.type != CommandType.BeginDisable)
			{
				RenderChainCommand renderChainCommand = renderChain.AllocCommand();
				renderChainCommand.type = CommandType.BeginDisable;
				renderChainCommand.owner = ve;
				if (ve.renderChainData.firstHeadCommand == null)
				{
					FindHeadCommandInsertionPoint(ve, out var prev, out var next);
					InjectCommandInBetween(renderChain, renderChainCommand, prev, next);
				}
				else
				{
					RenderChainCommand prev2 = ve.renderChainData.firstHeadCommand.prev;
					RenderChainCommand firstHeadCommand = ve.renderChainData.firstHeadCommand;
					RenderChainCommand lastHeadCommand = ve.renderChainData.lastHeadCommand;
					Debug.Assert(lastHeadCommand != null);
					ve.renderChainData.firstHeadCommand = null;
					InjectCommandInBetween(renderChain, renderChainCommand, prev2, firstHeadCommand);
					ve.renderChainData.lastHeadCommand = lastHeadCommand;
				}
			}
			if (ve.renderChainData.lastTailCommand == null || ve.renderChainData.lastTailCommand.type != CommandType.EndDisable)
			{
				RenderChainCommand renderChainCommand2 = renderChain.AllocCommand();
				renderChainCommand2.type = CommandType.EndDisable;
				renderChainCommand2.isTail = true;
				renderChainCommand2.owner = ve;
				if (ve.renderChainData.lastTailCommand == null)
				{
					FindTailCommandInsertionPoint(ve, out var prev3, out var next2);
					InjectCommandInBetween(renderChain, renderChainCommand2, prev3, next2);
					return;
				}
				RenderChainCommand lastTailCommand = ve.renderChainData.lastTailCommand;
				RenderChainCommand next3 = ve.renderChainData.lastTailCommand.next;
				Debug.Assert(ve.renderChainData.firstTailCommand != null);
				InjectCommandInBetween(renderChain, renderChainCommand2, lastTailCommand, next3);
			}
		}
		else
		{
			if (ve.renderChainData.firstHeadCommand != null && ve.renderChainData.firstHeadCommand.type == CommandType.BeginDisable)
			{
				RemoveSingleCommand(renderChain, ve, ve.renderChainData.firstHeadCommand);
			}
			if (ve.renderChainData.lastTailCommand != null && ve.renderChainData.lastTailCommand.type == CommandType.EndDisable)
			{
				RemoveSingleCommand(renderChain, ve, ve.renderChainData.lastTailCommand);
			}
		}
	}

	private static void RemoveSingleCommand(RenderChain renderChain, VisualElement ve, RenderChainCommand cmd)
	{
		Debug.Assert(cmd != null);
		Debug.Assert(cmd.owner == ve);
		renderChain.OnRenderCommandsRemoved(cmd, cmd);
		RenderChainCommand prev = cmd.prev;
		RenderChainCommand next = cmd.next;
		if (prev != null)
		{
			prev.next = next;
		}
		if (next != null)
		{
			next.prev = prev;
		}
		if (ve.renderChainData.firstHeadCommand == cmd)
		{
			if (ve.renderChainData.firstHeadCommand == ve.renderChainData.lastHeadCommand)
			{
				Debug.Assert(cmd.prev?.owner != ve, "When removing the first head command, the command before this one in the queue should belong to an other parent");
				Debug.Assert(cmd.next?.owner != ve || cmd.next == ve.renderChainData.firstTailCommand);
				ve.renderChainData.firstHeadCommand = null;
				ve.renderChainData.lastHeadCommand = null;
			}
			else
			{
				Debug.Assert(cmd.next.owner == ve);
				Debug.Assert(ve.renderChainData.lastHeadCommand != null);
				ve.renderChainData.firstHeadCommand = cmd.next;
			}
		}
		else if (ve.renderChainData.lastHeadCommand == cmd)
		{
			Debug.Assert(cmd.prev.owner == ve);
			Debug.Assert(ve.renderChainData.firstHeadCommand != null);
			ve.renderChainData.lastHeadCommand = cmd.prev;
		}
		if (ve.renderChainData.firstTailCommand == cmd)
		{
			if (ve.renderChainData.firstTailCommand == ve.renderChainData.lastTailCommand)
			{
				Debug.Assert(cmd.prev?.owner != ve || cmd.prev == ve.renderChainData.lastHeadCommand);
				Debug.Assert(cmd.next?.owner != ve);
				ve.renderChainData.firstTailCommand = null;
				ve.renderChainData.lastTailCommand = null;
			}
			else
			{
				Debug.Assert(cmd.next.owner == ve);
				Debug.Assert(ve.renderChainData.lastTailCommand != null);
				ve.renderChainData.firstTailCommand = cmd.next;
			}
		}
		else if (ve.renderChainData.lastTailCommand == cmd)
		{
			Debug.Assert(cmd.prev.owner == ve);
			Debug.Assert(ve.renderChainData.firstTailCommand != null);
			ve.renderChainData.lastTailCommand = cmd.prev;
		}
		renderChain.FreeCommand(cmd);
	}
}
