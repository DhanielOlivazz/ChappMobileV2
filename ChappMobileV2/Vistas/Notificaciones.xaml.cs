using static ChappMobileV2.Notis.NotisModel;

namespace ChappMobileV2.Vistas;

public partial class Notificaciones : ContentView
{
	public Notificaciones()
	{
		InitializeComponent();
        BindingContext = new NotisViewModel();
    }
}