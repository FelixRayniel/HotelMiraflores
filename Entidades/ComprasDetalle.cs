using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMiraflores.Entidades
{
    public class ComprasDetalle
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int CompraId { get; set; }
        public float Costo { get; set; }
        public int Cantidad { get; set; }
        public float CantidadDisponible { get; set; }
        public int UsuarioId { get; set; }
        
        [NotMapped]
        public float SubtotalCompra
        {
            get
            {
                return Cantidad * Costo;
            }
        }

        [ForeignKey("ProductoId")]
        public virtual Productos Producto { get; set; }

        public ComprasDetalle()
        {
            Id = 0;
            ProductoId = 0;
            CompraId = 0;
            Costo = 0;
            Cantidad = 0;
            CantidadDisponible = 0;
        }

        public ComprasDetalle(int productoId, int compraId, float costo, int cantidad, float cantidadDisponible)
        {
            Id = 0;
            ProductoId = productoId;
            CompraId = compraId;
            Costo = costo;
            Cantidad = cantidad;
            CantidadDisponible = cantidadDisponible;
        }
    }
}
