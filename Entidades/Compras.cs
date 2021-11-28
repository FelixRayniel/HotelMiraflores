using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMiraflores.Entidades
{
    public class Compras
    {
        [Key]

        public int CompraId { get; set; }
        public int SuplidorId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public float TotalCompra { get; set; }
        public int UsuarioId { get; set; }

       

        [ForeignKey("CompraId")]
        public List<ComprasDetalle> ComprasDetalle { get; set; } = new List<ComprasDetalle>();

    }
}
