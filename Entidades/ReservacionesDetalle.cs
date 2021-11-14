using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMiraflores.Entidades
{
    public class ReservacionesDetalle
    {
        public int ID { get; set; }
        public int ReservacionID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public float TotalProducto { get; set; }

        [ForeignKey("ReservacionID")]
        public virtual Reservaciones Reservacion { get; set; }

        [ForeignKey("ProductoID")]
        public virtual Productos Producto  { get; set; }

        public ReservacionesDetalle()
        {
            ID = 0;
            ReservacionID = 0;
            ProductoID = 0;
            Cantidad = 0;
            Precio = 0;
            TotalProducto = 0;
            Reservacion = null;
            Producto = null;
        }

        public ReservacionesDetalle(int ReservacionId, int ProductoId, int cantidad, float precio, float totalproducto, Reservaciones reservacion, Productos producto)
        {
            ID = 0;
            ReservacionID = ReservacionId;
            ProductoID = ProductoId;
            Cantidad = cantidad;
            Precio = precio;
            TotalProducto = totalproducto;
            Reservacion = reservacion;
            Producto = producto;
        }
    }
}
