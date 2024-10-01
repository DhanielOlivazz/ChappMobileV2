using ChappMobileV2.Models;
using ChappMobileV2.Services;

namespace ChappMobileV2.Publicaciones;

public partial class PlantillaPost : ContentView
{
    public PlantillaPost(Characters character)
	{
		InitializeComponent();
        this.BindingContext = character;
    }

}