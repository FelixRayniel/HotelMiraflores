using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMiraflores.Entidades
{
    public class Huespedes
    {
        [Key]
        public int HuespedId { get; set; }
        public string Nombres { get; set; }
        public string Cedula { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
