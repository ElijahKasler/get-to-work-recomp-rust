using System.ComponentModel;

namespace System.Windows.Forms;

public interface IBindableComponent : IComponent, IDisposable
{
	BindingContext BindingContext { get; set; }

	ControlBindingsCollection DataBindings { get; }
}
