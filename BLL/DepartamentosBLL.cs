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
   public class DepartamentosBLL
    {
 
        public static Departamentos Buscar(int id)
        {
            Departamentos Departamento = new Departamentos();
            Contexto contexto = new Contexto();

            try
            {
                Departamento = contexto.Departamentos.Include(x => x.DepartamentoID)
                   .Where(x => x.DepartamentoID == id)
                   .SingleOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Departamento;
        }
        public static List<Departamentos> GetList(Expression<Func<Departamentos, bool>> criterio)
        {
            List<Departamentos> Lista = new List<Departamentos>();

            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Departamentos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }


        public static List<Departamentos> GetDepartamentos()
        {
            List<Departamentos> lista = new List<Departamentos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Departamentos.ToList();
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
