using ChappMobileV2;
using ChappMobileV2.Vistas;
using ChappMobileV2.Menus;
using ChappMobileV2.Publicaciones;
namespace ChappMobileV2.Vistas;

public partial class Inicio : ContentView
{
	public Inicio()
	{
		InitializeComponent();
        RepetirPlantillaPost(3);
    }
    private void RepetirPlantillaPost(int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            var plantillaPost = new PlantillaPost();
            PublicacionesLayout.Children.Add(plantillaPost);
        }
    }
}