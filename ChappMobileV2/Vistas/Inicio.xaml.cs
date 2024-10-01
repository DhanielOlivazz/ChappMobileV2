using ChappMobileV2;
using ChappMobileV2.Vistas;
using ChappMobileV2.Menus;
using ChappMobileV2.Publicaciones;
using ChappMobileV2.Services;
using System.ComponentModel;
using System.Collections.Specialized;
using ChappMobileV2.Models;
namespace ChappMobileV2.Vistas;

public partial class Inicio : ContentView
{
    RickandMorty service = new RickandMorty();

    public Inicio()
	{
		InitializeComponent();
        PlantillaPost();

    }
    private async void PlantillaPost()
    {
        var data = await setCharacters();  // Esperamos a que setCharacters() termine

        foreach (var item in data)
        {
            var plantillaPost = new PlantillaPost(item);  // Constructor que acepta el item
            PublicacionesLayout.Children.Add(plantillaPost);  // Agregar la vista a tu layout
        }
    }
    public async Task<List<Characters>> setCharacters()
    {
        var data = await service.GetPersonajeList();

        return data;
    }
}