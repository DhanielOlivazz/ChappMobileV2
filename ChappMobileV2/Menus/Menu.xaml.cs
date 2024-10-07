using ChappMobileV2.Vistas;

namespace ChappMobileV2.Menus;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
	}
    public void OnTabClicked(object sender, EventArgs e)
    {
        // Resetear las l�neas blancas de todas las pesta�as
        InicioUnderline.IsVisible = false;
        PerfilUnderline.IsVisible = false;
        ProyectosUnderline.IsVisible = false;
        NotificacionesUnderline.IsVisible = false;

        // Cambiar el contenido seg�n la pesta�a seleccionada
        if (sender == InicioButton)
        {
            MainContent.Content = new Inicio(); 
            InicioUnderline.IsVisible = true;   
        }
        else if (sender == PerfilButton)
        {
            MainContent.Content = new Perfil();  
            PerfilUnderline.IsVisible = true;   
        }
        else if (sender == ProyectosButton)
        {
            MainContent.Content = new Proyectos();  
            ProyectosUnderline.IsVisible = true;   
        }
        else if(sender == NotificacionesButton)
        {
            MainContent.Content = new Notificaciones();
            NotificacionesUnderline.IsVisible = true;
        }
    }
    
}