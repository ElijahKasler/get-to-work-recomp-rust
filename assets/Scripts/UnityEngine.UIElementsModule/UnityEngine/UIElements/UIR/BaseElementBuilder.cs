#define UNITY_ASSERTIONS
namespace UnityEngine.UIElements.UIR;

internal abstract class BaseElementBuilder
{
	public abstract bool RequiresStencilMask(VisualElement ve);

	public void Build(MeshGenerationContext mgc)
	{
		VisualElement visualElement = mgc.visualElement;
		Debug.Assert(visualElement.areAncestorsAndSelfDisplayed);
		if (visualElement.shouldCutRenderChain)
		{
			mgc.entryRecorder.CutRenderChain(mgc.parentEntry);
		}
		bool isGroupTransform = visualElement.renderChainData.isGroupTransform;
		if (isGroupTransform)
		{
			mgc.entryRecorder.PushGroupMatrix(mgc.parentEntry);
		}
		bool flag = visualElement.subRenderTargetMode != VisualElement.RenderTargetMode.None;
		if (flag)
		{
			mgc.entryRecorder.PushRenderTexture(mgc.parentEntry);
		}
		bool flag2 = visualElement.defaultMaterial != null;
		if (flag2)
		{
			mgc.entryRecorder.PushDefaultMaterial(mgc.parentEntry, visualElement.defaultMaterial);
		}
		bool flag3 = false;
		if (visualElement.visible)
		{
			DrawVisualElementBackground(mgc);
			DrawVisualElementBorder(mgc);
			PushVisualElementClipping(mgc);
			flag3 = true;
			InvokeGenerateVisualContent(mgc);
		}
		else
		{
			bool flag4 = visualElement.renderChainData.clipMethod == ClipMethod.Stencil;
			bool flag5 = visualElement.renderChainData.clipMethod == ClipMethod.Scissor;
			if (flag5 | flag4)
			{
				flag3 = true;
				PushVisualElementClipping(mgc);
			}
		}
		mgc.entryRecorder.DrawChildren(mgc.parentEntry);
		if (flag3)
		{
			PopVisualElementClipping(mgc);
		}
		if (flag2)
		{
			mgc.entryRecorder.PopDefaultMaterial(mgc.parentEntry);
		}
		if (isGroupTransform)
		{
			mgc.entryRecorder.PopGroupMatrix(mgc.parentEntry);
		}
		if (flag)
		{
			mgc.entryRecorder.BlitAndPopRenderTexture(mgc.parentEntry);
		}
	}

	protected abstract void DrawVisualElementBackground(MeshGenerationContext mgc);

	protected abstract void DrawVisualElementBorder(MeshGenerationContext mgc);

	protected abstract void DrawVisualElementStencilMask(MeshGenerationContext mgc);

	public abstract void ScheduleMeshGenerationJobs(MeshGenerationContext mgc);

	private void PushVisualElementClipping(MeshGenerationContext mgc)
	{
		VisualElement visualElement = mgc.visualElement;
		if (visualElement.renderChainData.clipMethod == ClipMethod.Scissor)
		{
			mgc.entryRecorder.PushScissors(mgc.parentEntry);
		}
		else if (visualElement.renderChainData.clipMethod == ClipMethod.Stencil)
		{
			mgc.entryRecorder.BeginStencilMask(mgc.parentEntry);
			DrawVisualElementStencilMask(mgc);
			mgc.entryRecorder.EndStencilMask(mgc.parentEntry);
		}
		mgc.entryRecorder.PushClippingRect(mgc.parentEntry);
	}

	private static void PopVisualElementClipping(MeshGenerationContext mgc)
	{
		VisualElement visualElement = mgc.visualElement;
		mgc.entryRecorder.PopClippingRect(mgc.parentEntry);
		if (visualElement.renderChainData.clipMethod == ClipMethod.Scissor)
		{
			mgc.entryRecorder.PopScissors(mgc.parentEntry);
		}
		else if (visualElement.renderChainData.clipMethod == ClipMethod.Stencil)
		{
			mgc.entryRecorder.PopStencilMask(mgc.parentEntry);
		}
	}

	private static void InvokeGenerateVisualContent(MeshGenerationContext mgc)
	{
		VisualElement visualElement = mgc.visualElement;
		Painter2D.isPainterActive = true;
		visualElement.InvokeGenerateVisualContent(mgc);
		Painter2D.isPainterActive = false;
	}
}
