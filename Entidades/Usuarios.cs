using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMiraflores.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Nombres { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        

        public Usuarios()
        {
            UsuarioId = 0;
            Email = string.Empty;
            Nombres = string.Empty;
            NombreUsuario = string.Empty;
            Clave = string.Empty;
        }
    }
}
