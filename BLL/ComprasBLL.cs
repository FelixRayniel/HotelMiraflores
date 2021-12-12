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
                    contexto.Entry(detalle.Producto).State = EntityState.Modified;
                    detalle.Producto.CantidadDisponible += detalle.Cantidad;
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
                var CompraAnterior = contexto.Compras.Where(x => x.CompraId == compras.CompraId)
                    .Include(x => x.ComprasDetalle).ThenInclude(x => x.Producto)
                    .AsNoTracking()
                    .SingleOrDefault();

                foreach (var detalle in CompraAnterior.ComprasDetalle)
                {
                    detalle.Producto = contexto.Productos.Find(detalle.ProductoId);
                    detalle.Producto.CantidadDisponible -= detalle.Cantidad;

                }

                contexto.Database.ExecuteSqlRaw($"Delete FROM ComprasDetalle Where CompraId={compras.CompraId}");

                foreach(var item in compras.ComprasDetalle)
                {

                    item.Producto = contexto.Productos.Find(item.ProductoId);
                    item.Producto.CantidadDisponible += item.Cantidad;

                    contexto.Entry(item.Producto).State = EntityState.Modified;
                    contexto.Entry(item).State = EntityState.Added;
                    
                    
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
                    foreach (var detalle in Compra.ComprasDetalle)
                    {
                        detalle.Producto.CantidadDisponible -= detalle.Cantidad;
                        contexto.Entry(detalle.Producto).State = EntityState.Modified;
                    }

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
                .Where(x => x.CompraId == id).Include(x => x.ComprasDetalle).ThenInclude(x => x.Producto)
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
