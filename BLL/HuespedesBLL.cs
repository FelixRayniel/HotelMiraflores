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
        public static List<Huespedes> GetList()
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
