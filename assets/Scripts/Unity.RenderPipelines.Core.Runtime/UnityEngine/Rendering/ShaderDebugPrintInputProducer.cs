namespace UnityEngine.Rendering;

public static class ShaderDebugPrintInputProducer
{
	public static ShaderDebugPrintInput Get()
	{
		return new ShaderDebugPrintInput
		{
			pos = Input.mousePosition,
			leftDown = Input.GetMouseButton(0),
			rightDown = Input.GetMouseButton(1),
			middleDown = Input.GetMouseButton(2)
		};
	}
}
