using ChappMobileV2;
using ChappMobileV2.Vistas;
using ChappMobileV2.Menus;
using ChappMobileV2.Publicaciones;
using ChappMobileV2.Models;
using System.Collections.ObjectModel;

namespace ChappMobileV2.Vistas;
public partial class Inicio : ContentView
{
    public ObservableCollection<Publicacion> Publicaciones { get; set; }

    public Inicio()
    {
        InitializeComponent();
        Publicaciones = new ObservableCollection<Publicacion>();
        CargarPublicacionesGradualmente();
        BindingContext = this;
    }

    private async void CargarPublicacionesGradualmente()
    {
        // Crear una lista de publicaciones para ir agreg�ndolas de una en una
        var listaPublicaciones = new List<Publicacion>
        {
            new Publicacion
            {
                Titulo = "Manposteria",
                Descripcion = "Explora nuestra aplicaci�n y descubre una experiencia completa. Navega entre las pesta�as para acceder a funciones como perfil, configuraci�n y notificaciones. Simplifica tu d�a con herramientas intuitivas, accede a contenidos personalizados y mantente actualizado en todo momento. �Optimiza tu rutina y disfruta cada funci�n al m�ximo!",
                Ubicacion = "Esteli",
                Imagen = "dotnet_bot.png"
            },
            new Publicacion
            {
                Titulo = "Construcci�n",
                Descripcion = "Expertos en construcci�n y reformas.",
                Ubicacion = "Managua",
                Imagen = "dotnet_bot.png"
            },
            new Publicacion
            {
                Titulo = "Pintura",
                Descripcion = "Servicios de pintura interior y exterior.",
                Ubicacion = "Granada",
                Imagen = "dotnet_bot.png"
            }
        };

        // Agregar m�s publicaciones con diferentes datos
        for (int i = 4; i <= 20; i++)
        {
            listaPublicaciones.Add(new Publicacion
            {
                Titulo = $"Publicaci�n {i}",
                Descripcion = $"Descripci�n de la publicaci�n {i}. Servicios variados en construcci�n.",
                Ubicacion = $"Ubicaci�n {i}",
                Imagen = "dotnet_bot.png"
            });
        }

        // Agregar publicaciones gradualmente con una demora
        foreach (var publicacion in listaPublicaciones)
        {
            Publicaciones.Add(publicacion);
            await Task.Delay(500); // Retraso de 500 ms entre cada carga de publicaci�n
        }
    }

    private void OnNotificacionesClicked(object sender, EventArgs e)
    {
        // Mostrar el Frame de notificaciones
        NotificacionesFrame.IsVisible = true;
    }

    private void OnCerrarNotificacionesClicked(object sender, EventArgs e)
    {
        // Ocultar el Frame de notificaciones
        NotificacionesFrame.IsVisible = false;
    }
}
