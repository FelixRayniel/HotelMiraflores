using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMiraflores.Entidades
{
    public class Reservaciones
    {
        [Key]
        public int ReservacionID { get; set; }
        public int HuespedID { get; set; }
        public int TipoHabitacionID { get; set; }
        public int HabitacionID { get; set; }
        public int CantidadPersonas { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public float Total { get; set; }
        public float ITBIS { get; set; }
        public float Descuentos { get; set; }
        public float TotalGeneral { get; set; }
        public string Comentarios { get; set; }

        [ForeignKey("HuespedID")]
        public virtual Huespedes Huesped { get; set; }

        [ForeignKey("TipoHabitacionID")]
        public virtual TipoHabitaciones TipoHabitacion { get; set; }

        [ForeignKey("HabitacionID")]
        public virtual TipoHabitaciones Habitacion { get; set; }



    }
}
