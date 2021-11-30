using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMiraflores.Entidades
{
    public class ReservacionesDetalle
    {
        [Key]
        public int Id { get; set; }
        public int ReservacionId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public int UsuarioId { get; set; }

        [NotMapped]
        public float TotalProducto { 
            get 
            {
                return Cantidad * Precio;
            } 
        }

        [ForeignKey("ProductoId")]
        public virtual Productos Producto  { get; set; }


        public ReservacionesDetalle()
        {
            Id = 0;
            ReservacionId = 0;
            Cantidad = 0;
            Precio = 0;
            Producto = null;
        }


        public ReservacionesDetalle(int reservacionid, int cantidad, float precio, Productos producto)
        {
            Id = 0;
            ReservacionId = reservacionid;
            Cantidad = cantidad;
            Precio = precio;
            Producto = producto;
        }

    }
}
