using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChappMobileV2.Models
{
    public class Publicacion
    {
        public string _descripcion;
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
