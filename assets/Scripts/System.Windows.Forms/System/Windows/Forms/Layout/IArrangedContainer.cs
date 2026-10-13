using System.ComponentModel;

namespace System.Windows.Forms.Layout;

internal interface IArrangedContainer : IArrangedElement, IComponent, IDisposable
{
	ArrangedElementCollection Controls { get; }

	void PerformLayout(IArrangedElement affectedElement, string affectedProperty);
}
