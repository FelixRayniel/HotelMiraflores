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
        public int ID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public float TotalProducto { get; set; }

        [ForeignKey("ProductoID")]
        public virtual Productos Producto  { get; set; }

        public ReservacionesDetalle()
        {
            ID = 0;
            ProductoID = 0;
            Cantidad = 0;
            Precio = 0;
            TotalProducto = 0;
            Producto = null;
        }

        public ReservacionesDetalle(int ProductoId, int cantidad, float precio, float totalproducto, Productos producto)
        {
            ID = 0;
            ProductoID = ProductoId;
            Cantidad = cantidad;
            Precio = precio;
            TotalProducto = totalproducto;
            Producto = producto;
        }
    }
}
