using System;
using System.Collections.Generic;
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
    }
}
