using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ChappMobileV2.Models;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChappMobileV2.Publicaciones
{
    public class PublicacionesViewModel : INotifyPropertyChanged
    {
        private bool _isCrearPublicacionVisible;

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

        public PublicacionesViewModel()
        {
            Publicaciones = new ObservableCollection<Publicacion>();
            NuevaPublicacion = new Publicacion();

            AbrirCrearPublicacionCommand = new Command(() => IsCrearPublicacionVisible = true);
            GuardarPublicacionCommand = new Command(GuardarPublicacion);
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
