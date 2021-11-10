using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMiraflores.Entidades
{
    public class Suplidores
    {
        [Key]
        public int SuplidorID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Descripcion { get; set; }
    }
}
