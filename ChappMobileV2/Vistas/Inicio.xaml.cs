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
        _ = CargarPublicacionesGradualmenteAsync(); // Llamada as�ncrona sin bloqueo
        BindingContext = this;
    }

    private async Task CargarPublicacionesGradualmenteAsync()
    {
        // Lista de publicaciones
        var listaPublicaciones = new List<Publicacion>
        {
            new Publicacion
            {
                Titulo = "Manposteria",
                Descripcion = "Explora nuestra aplicaci�n y descubre una experiencia completa...",
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
        for (int i = 4; i <= 10; i++)
        {
            listaPublicaciones.Add(new Publicacion
            {
                Titulo = $"Publicaci�n {i}",
                Descripcion = $"Descripci�n de la publicaci�n {i}. Servicios variados en construcci�n.",
                Ubicacion = $"Ubicaci�n {i}",
                Imagen = "dotnet_bot.png"
            });
        }

        // Tama�o de lote din�mico
        int batchSize = Math.Min(5, listaPublicaciones.Count); // Evita lotes grandes en dispositivos lentos
        for (int i = 0; i < listaPublicaciones.Count; i += batchSize)
        {
            // Crear lote para agregar
            var batch = listaPublicaciones.Skip(i).Take(batchSize).ToList();
            foreach (var publicacion in batch)
            {
                Publicaciones.Add(publicacion);
            }
            // Retraso opcional para reducir carga en la interfaz
            await Task.Delay(250); // Ajustar seg�n rendimiento
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
