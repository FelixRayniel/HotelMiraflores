using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMiraflores.Entidades
{
    public class TipoHabitaciones
    {
        [Key]
        public int TipoHabitacionId { get; set; }
        public string Descripcion { get; set; }
    }
}
