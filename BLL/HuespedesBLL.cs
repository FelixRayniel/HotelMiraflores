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
    public class HuespedesBLL
    {
        public static bool Guardar(Huespedes huespedes)
        {
            if (!Existe(huespedes.HuespedID))
            {
                return Insertar(huespedes);
            }
            else
            {
                return Modificar(huespedes);
            }
        }
        private static bool Insertar(Huespedes huespedes)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Huespedes.Add(huespedes);
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
        public static bool Modificar(Huespedes huespedes)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(huespedes).State = EntityState.Modified;
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
                var huespedes = contexto.Huespedes.Find(id);

                if (huespedes != null)
                {
                    contexto.Huespedes.Remove(huespedes);
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
        public static Huespedes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Huespedes huespedes;

            try
            {
                huespedes = contexto.Huespedes.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return huespedes;
        }
        public static List<Huespedes> GetList(Expression<Func<Huespedes, bool>> criterio)
        {
            List<Huespedes> lista = new List<Huespedes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Huespedes.Where(criterio).ToList();
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
                encontrado = contexto.Huespedes.Any(h => h.HuespedID == id);
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
        public static List<Huespedes> GetHuespedes()
        {
            List<Huespedes> lista = new List<Huespedes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Huespedes.ToList();
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
