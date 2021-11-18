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
    public class MarcasBLL
    {
        public static bool Guardar(Marcas marcas)
        {
            if (!Existe(marcas.MarcaId))
            {
                return Insertar(marcas);
            }
            else
            {
                return Modificar(marcas);
            }
        }
        private static bool Insertar(Marcas marcas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Marcas.Add(marcas);
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
        public static bool Modificar(Marcas marcas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(marcas).State = EntityState.Modified;
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
                var marcas = contexto.Marcas.Find(id);

                if (marcas != null)
                {
                    contexto.Marcas.Remove(marcas);
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
        public static Marcas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Marcas marcas;

            try
            {
                marcas = contexto.Marcas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return marcas;
        }
        public static List<Marcas> GetList(Expression<Func<Marcas, bool>> criterio)
        {
            List<Marcas> lista = new List<Marcas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Marcas.Where(criterio).ToList();
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
                encontrado = contexto.Marcas.Any(h => h.MarcaId == id);
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
        public static List<Marcas> GetMarcas()
        {
            List<Marcas> lista = new List<Marcas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Marcas.ToList();
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
