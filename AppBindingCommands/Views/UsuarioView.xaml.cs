using AppBindingCommands.ViewModels;

namespace AppBindingCommands.Views;

private UsuarioViewModel viewModel;
{
	public UsuarioView()
	{
		InitializeComponent();
		viewModel = new UsuarioViewModel();
		BindingContext = ViewModels;

	}
}