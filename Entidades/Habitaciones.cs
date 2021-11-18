using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMiraflores.Entidades
{
    public class Habitaciones
    {
        [Key]
        public int HabitacionId { get; set; }
        public int TipoHabitacionId {get; set;}
        public string Numero { get; set; }
        public float Precio { get; set; }
        public string Descripcion { get; set; }
        public bool Disponibilidad { get; set; }
        public int UsuarioId { get; set; }
    }
}
