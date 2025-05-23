using ChappMobileV2.Vistas;
using ChappMobileV2.Menus;
using ChappMobileV2.Publicaciones;
using System.Collections.ObjectModel;
namespace ChappMobileV2.Vistas;

public partial class Perfil : ContentView
{
    public ObservableCollection<Publicacion> Publicaciones { get; set; }

    public Perfil()
	{
		InitializeComponent();
        Publicaciones = new ObservableCollection<Publicacion>();
        CargarPublicaciones();
        BindingContext = this;
    }
    private void CargarPublicaciones()
    {
        // Crear publicaciones con datos diferentes
        Publicaciones.Add(new Publicacion
        {
            Titulo = "Manposteria",
            Descripcion = "Servicios en trabajos de mampostería de tipo castillo o confinada.",
            Ubicacion = "Esteli",
            Imagen = "dotnet_bot.png"
        });
        Publicaciones.Add(new Publicacion
        {
            Titulo = "Construcción",
            Descripcion = "Expertos en construcción y reformas.",
            Ubicacion = "Managua",
            Imagen = "dotnet_bot.png"
        });
        Publicaciones.Add(new Publicacion
        {
            Titulo = "Pintura",
            Descripcion = "Servicios de pintura interior y exterior.",
            Ubicacion = "Granada",
            Imagen = "dotnet_bot.png"
        });
        // Agregar más publicaciones con diferentes datos
        for (int i = 4; i <= 20; i++)
        {
            Publicaciones.Add(new Publicacion
            {
                Titulo = $"Publicación {i}",
                Descripcion = $"Descripción de la publicación {i}. Servicios variados en construcción.",
                Ubicacion = $"Ubicación {i}",
                Imagen = "dotnet_bot.png"
            });
        }
    }
    public class Publicacion
    {
        private string _descripcion;
        public string? Titulo { get; set; }
        public string Descripcion
        {
            get => _descripcion;
            set => _descripcion = string.Join(" ", value.Split(' ').Take(100));
        }
        public string? Ubicacion { get; set; }
        public string? Imagen { get; set; }
    }
}
