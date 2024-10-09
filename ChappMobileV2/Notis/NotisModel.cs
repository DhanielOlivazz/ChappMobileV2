using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChappMobileV2.Notis;

namespace ChappMobileV2.Notis
{

    internal class NotisModel
    {
        // Clase que representa el ViewModel de Notificaciones
        public class NotisViewModel
        {
            public ObservableCollection<Notificacion> Notificaciones { get; set; }

            public NotisViewModel()
            {
                Notificaciones = new ObservableCollection<Notificacion>
            {
                new Notificacion { Titulo = "Aplicacion aceptada", Descripcion = "Se ha confirmado su aceptacion para un proyecto de fontaneria" },
                new Notificacion { Titulo = "Aprobacion para puesto", Descripcion = "Descripción de la notificación 2" },
                new Notificacion { Titulo = "Contacto con el empleador", Descripcion = "Descripción de la notificación 3" },
                new Notificacion { Titulo = "Oportunidad de empleo", Descripcion = "Descripción de la notificación 4" },
                new Notificacion { Titulo = "Vacantes completas", Descripcion = "Descripción de la notificación 5" },
            };
            }
        }

        // Clase que representa una notificación individual
        public class Notificacion
        {
            public string? Titulo { get; set; }
            public string? Descripcion { get; set; }
        }
    }
    
}
