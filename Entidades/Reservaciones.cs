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
        public int ReservacionId { get; set; }
        public int HuespedId { get; set; }
        public int CantidadPersonas { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int CantidadDias { get; set; }
        public int HabitacionId { get; set; }
        public float Descuentos { get; set; }
        public float Total { get; set; }
        public float TotalProductos { get; set; }
        public float TotalGeneral { get; set; }
        public string Comentarios { get; set; }
        public int UsuarioId { get; set; }

        [ForeignKey("ReservacionId")]
        public virtual List<ReservacionesDetalle> ReservacionDetalle { get; set; } = new List<ReservacionesDetalle>();

    }
}
