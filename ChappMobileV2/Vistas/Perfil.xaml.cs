using ChappMobileV2.Vistas;
using ChappMobileV2.Menus;
using ChappMobileV2.Publicaciones;
using System.Collections.ObjectModel;
namespace ChappMobileV2.Vistas;

public partial class Perfil : ContentView
{
    public Perfil()
	{
		InitializeComponent();
    }
    // Método para mostrar el Frame de CrearPublicacionFrame
    private void OnCrearPublicacionClicked(object sender, EventArgs e)
    {
        CrearPublicacionFrame.IsVisible = true;
    }

    // Método para ocultar el Frame de CrearPublicacionFrame
    private void OnCerrarCrearPublicacionClicked(object sender, EventArgs e)
    {
        CrearPublicacionFrame.IsVisible = false;
    }

    private async void SeleccionarImageButton_Clicked(object sender, EventArgs e)
    {
        var foto = await MediaPicker.PickPhotoAsync();
        fotoImage.Source = ImageSource.FromStream(() => foto.OpenReadAsync().Result);
    }
}
