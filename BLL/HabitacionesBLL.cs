using HotelMiraflores.DAL;
using HotelMiraflores.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelMiraflores.BLL
{
   public class HabitacionesBLL
    {

        public static bool Guardar(Habitaciones Habitacion)
        {
            if (!Existe(Habitacion.HabitacionID))
            {
                return Insertar(Habitacion);
            }
            else
            {
                return Modificar(Habitacion);
            }
        }
        private static bool Insertar(Habitaciones Habitacion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Habitaciones.Add(Habitacion);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static bool Modificar(Habitaciones Habitacion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(Habitacion).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var habitacion = contexto.Habitaciones.Find(id);

                if (habitacion != null)
                {
                    contexto.Habitaciones.Remove(habitacion);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static Habitaciones Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Habitaciones habitacion;

            try
            {
                habitacion = contexto.Habitaciones.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return habitacion;
        }
        public static List<Habitaciones> GetList(Expression<Func<Habitaciones, bool>> criterio)
        {
            List<Habitaciones> lista = new List<Habitaciones>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Habitaciones.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Habitaciones.Any(h => h.HabitacionID == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        public static List<Habitaciones> GetHabitaciones()
        {
            List<Habitaciones> lista = new List<Habitaciones>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Habitaciones.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }

    }
}
