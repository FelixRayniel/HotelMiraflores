using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public float PrecioCosto { get; set; }
        public float PrecioVenta { get; set; }
        public int CantidadDisponible { get; set; }

        [ForeignKey("MarcaID")]
        public virtual Marcas Marca { get; set; }

        [ForeignKey("DepartamentoID")]
        public virtual Departamentos Departamento { get; set; }


    }
}
