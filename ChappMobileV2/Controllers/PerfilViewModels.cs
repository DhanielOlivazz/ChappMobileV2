using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ChappMobileV2.Models.User;
using ChappMobileV2.Models;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChappMobileV2.Controllers
{
    public class PerfilViewModels : INotifyPropertyChanged
    {
        private bool _isCrearPublicacionVisible;

        public Perfil123 PerfilData { get; set; }
        public ObservableCollection<Publicacion> Publicaciones { get; set; }
        public Publicacion NuevaPublicacion { get; set; }

        public bool IsCrearPublicacionVisible
        {
            get => _isCrearPublicacionVisible;
            set
            {
                _isCrearPublicacionVisible = value;
                OnPropertyChanged(nameof(IsCrearPublicacionVisible));
            }
        }

        public ICommand AbrirCrearPublicacionCommand { get; }
        public ICommand GuardarPublicacionCommand { get; }

        public PerfilViewModels()
        {
            PerfilData = new Perfil123
            {
                UserName = "DanOlivazzz",
                Nombre = "Juan Daniel Olivas Castellon",
                Contacto = "+505 22511929",
                Correo = "nose@gmail1234",
                Direccion = "Esteli, Nicaragua",
                Campo = "Desarrollo de software"
            };

            Publicaciones = new ObservableCollection<Publicacion>();
            NuevaPublicacion = new Publicacion();

            CargarPublicaciones();

            AbrirCrearPublicacionCommand = new Command(() => IsCrearPublicacionVisible = true);
            GuardarPublicacionCommand = new Command(GuardarPublicacion);
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

            // Agregar más publicaciones de prueba
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

        private void GuardarPublicacion()
        {
            if (!string.IsNullOrWhiteSpace(NuevaPublicacion.Titulo) &&
                !string.IsNullOrWhiteSpace(NuevaPublicacion.Descripcion))
            {
                Publicaciones.Add(new Publicacion
                {
                    Titulo = NuevaPublicacion.Titulo,
                    Descripcion = NuevaPublicacion.Descripcion,
                    Ubicacion = NuevaPublicacion.Ubicacion,
                    Imagen = NuevaPublicacion.Imagen
                });

                NuevaPublicacion = new Publicacion();
                OnPropertyChanged(nameof(NuevaPublicacion));

                IsCrearPublicacionVisible = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
