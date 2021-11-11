﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMiraflores.Entidades
{
    public class Habitaciones
    {
        [Key]
        public int HabitacionID { get; set; }
        public int TipoHabitacionID { get; set; }
        public float Precio { get; set; }
        public string Descripcion { get; set; }
    }
}