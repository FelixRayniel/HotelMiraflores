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
        public int CantidadPersonas { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public DateTime FechaEntrada { get; set; } = DateTime.Now;
        public DateTime FechaSalida { get; set; } = DateTime.Now;
        public int CantidadDias { get; set; }
        public int HabitacionID { get; set; }
        public float Descuentos { get; set; }
        public float Total { get; set; }
        public float TotalProductos { get; set; }
        public float TotalGeneral { get; set; }
        public string Comentarios { get; set; }

        [ForeignKey("ReservacionID")]
        public List<ReservacionesDetalle> ReservacionDetalle { get; set; } = new List<ReservacionesDetalle>();

    }
}
