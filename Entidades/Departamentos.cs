using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMiraflores.Entidades
{
   public class Departamentos
    {
        [Key]
        public int DepartamentoID { get; set; }
        public string Descripcion { get; set; }

    }
}
