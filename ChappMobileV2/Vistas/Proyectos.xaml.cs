using ChappMobileV2.ViewModels;

namespace ChappMobileV2.Vistas;

public partial class Proyectos : ContentView
{
	public Proyectos()
	{
		InitializeComponent();
        BindingContext = new ProyectosViewModel();
    }
}