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
    public class TipoHabitacionesBLL
    {
        public static bool Guardar(TipoHabitaciones tipoHabitaciones)
        {
            if (!Existe(tipoHabitaciones.TipoHabitacionID))
            {
                return Insertar(tipoHabitaciones);
            }
            else
            {
                return Modificar(tipoHabitaciones);
            }
        }
        private static bool Insertar(TipoHabitaciones tipoHabitaciones)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.TipoHabitaciones.Add(tipoHabitaciones);
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
        public static bool Modificar(TipoHabitaciones tipoHabitaciones)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(tipoHabitaciones).State = EntityState.Modified;
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
                var tipoHabitaciones = contexto.TipoHabitaciones.Find(id);

                if (tipoHabitaciones != null)
                {
                    contexto.TipoHabitaciones.Remove(tipoHabitaciones);
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
        public static TipoHabitaciones Buscar(int id)
        {
            Contexto contexto = new Contexto();
            TipoHabitaciones tipoHabitaciones;

            try
            {
                tipoHabitaciones = contexto.TipoHabitaciones.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return tipoHabitaciones;
        }
        public static List<TipoHabitaciones> GetList(Expression<Func<TipoHabitaciones, bool>> criterio)
        {
            List<TipoHabitaciones> lista = new List<TipoHabitaciones>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.TipoHabitaciones.Where(criterio).ToList();
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
                encontrado = contexto.TipoHabitaciones.Any(h => h.TipoHabitacionID == id);
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
        public static List<TipoHabitaciones> GettipoHabitaciones()
        {
            List<TipoHabitaciones> lista = new List<TipoHabitaciones>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.TipoHabitaciones.ToList();
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
