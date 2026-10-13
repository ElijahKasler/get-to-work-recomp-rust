using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using ModestTree.Util;

namespace Zenject;

public class GuiRenderableManager
{
	private class RenderableInfo
	{
		public IGuiRenderable Renderable;

		public int Priority;

		public RenderableInfo(IGuiRenderable renderable, int priority)
		{
			Renderable = renderable;
			Priority = priority;
		}
	}

	private List<RenderableInfo> _renderables;

	public GuiRenderableManager([Inject(Optional = true, Source = InjectSources.Local)] List<IGuiRenderable> renderables, [Inject(Optional = true, Source = InjectSources.Local)] List<ValuePair<Type, int>> priorities)
	{
		_renderables = new List<RenderableInfo>();
		foreach (IGuiRenderable renderable in renderables)
		{
			List<int> list = (from x in priorities
				where renderable.GetType().DerivesFromOrEqual(x.First)
				select x.Second).ToList();
			int priority = ((!list.IsEmpty()) ? list.Distinct().Single() : 0);
			_renderables.Add(new RenderableInfo(renderable, priority));
		}
		_renderables = _renderables.OrderBy((RenderableInfo x) => x.Priority).ToList();
	}

	public void OnGui()
	{
		foreach (RenderableInfo renderable in _renderables)
		{
			try
			{
				renderable.Renderable.GuiRender();
			}
			catch (Exception innerException)
			{
				throw Assert.CreateException(innerException, "Error occurred while calling {0}.GuiRender", renderable.Renderable.GetType());
			}
		}
	}
}
