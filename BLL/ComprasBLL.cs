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
    public class ComprasBLL
    {
        public static bool Guardar(Compras compras)
        {
            if (!Existe(compras.CompraId))
                return Insertar(compras);
            else
                return Modificar(compras);
        }
        private static bool Insertar(Compras compras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Compras.Add(compras);

                foreach (var detalle in compras.ComprasDetalle)
                {
                    contexto.Entry(detalle.CompraId).State = EntityState.Modified;
                }

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
        private static bool Modificar(Compras compras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var ProyectoAnterior = contexto.Compras
                    .Where(x => x.CompraId == compras.CompraId)
                    .Include(x => x.ComprasDetalle).ThenInclude(x => x.CompraId)
                    .AsNoTracking()
                    .SingleOrDefault();

                contexto.Database.ExecuteSqlRaw($"Delete FROM ComprasDetalle Where Id={compras.CompraId}");

                foreach (var detalle in ProyectoAnterior.ComprasDetalle)
                {
                    contexto.Entry(detalle.CompraId).State = EntityState.Modified;

                }

                contexto.Entry(compras).State = EntityState.Modified;
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
                var Compra = ComprasBLL.Buscar(id);

                if (Compra != null)
                {
                    contexto.Compras.Remove(Compra);
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
        public static Compras Buscar(int id)
        {
            Compras compras = new Compras();
            Contexto contexto = new Contexto();

            try
            {
                compras = contexto.Compras.Include(x => x.ComprasDetalle)
                .Where(x => x.CompraId == id).Include(x => x.ComprasDetalle).ThenInclude(x => x.CompraId)
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
            return compras;
        }
        public static List<Compras> GetList(Expression<Func<Compras, bool>> criterio)
        {
            List<Compras> Lista = new List<Compras>();

            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                Lista = contexto.Compras.Where(criterio).ToList();
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
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Compras.Any(e => e.CompraId == id);
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
    }
}
