using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChappMobileV2.Models.User;

namespace ChappMobileV2.Controllers
{
    public class UserController
    {
        public Perfil lol { get; set; } = new Perfil()
        {
            UserName = "DanOlivazzz",
            Nombre = "Juan Daniel Olivas Martinez",
            Contacto = "+505 22511929",
            Correo = "nose@gmail1234",
            Direccion = "Esteli, Nicaragua",
            Campo = "Desarrollo de software"
        };
    }
}
