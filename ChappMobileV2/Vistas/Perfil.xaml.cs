using ChappMobileV2.Vistas;
using ChappMobileV2.Menus;
using ChappMobileV2.Controllers;
using ChappMobileV2.Publicaciones;
using ChappMobileV2.Models.User;
using System.Collections.ObjectModel;
namespace ChappMobileV2.Vistas;

public partial class Perfil : ContentView
{
    public Perfil()
	{

		InitializeComponent();
        BindingContext = new PerfilViewModels();
    }

}
