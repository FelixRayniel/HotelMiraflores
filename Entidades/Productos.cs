using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMiraflores.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoID { get; set; }
        public string Descripcion { get; set; }
        public int Unidad { get; set; }
        public int MarcaID { get; set; }
        public int DepartamentoID { get; set; }
        public float PrecioCosto { get; set; }
        public float PrecioVenta { get; set; }
        public int Cantidad { get; set; }
    }
}
