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
    public class ReservacionesBLL
    {
        
            public static bool Guardar(Reservaciones Reservacion)
            {
                if (!Existe(Reservacion.ReservacionID))
                    return Insertar(Reservacion);
                else
                    return Modificar(Reservacion);
            }
            private static bool Insertar(Reservaciones Reservacion)
            {
                bool paso = false;
                Contexto contexto = new Contexto();

                try
                {
                    contexto.Reservaciones.Add(Reservacion);

                    foreach (var detalle in Reservacion.ReservacionDetalle)
                    {
                        contexto.Entry(detalle.Producto).State = EntityState.Modified;
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
            private static bool Modificar(Reservaciones Reservacion)
            {
                bool paso = false;
                Contexto contexto = new Contexto();

                try
                {

                    var ProductoAnterior = contexto.Reservaciones
                        .Where(x => x.ReservacionID == Reservacion.ReservacionID)
                        .Include(x => x.ReservacionDetalle).ThenInclude(x => x.Producto)
                        .AsNoTracking()
                        .SingleOrDefault();

                    contexto.Database.ExecuteSqlRaw($"Delete FROM TareasDetalle Where ID={Reservacion.ReservacionID}");

                    foreach (var detalle in ProductoAnterior.ReservacionDetalle)
                    {
                        contexto.Entry(detalle.Producto).State = EntityState.Modified;

                    }

                    contexto.Entry(Reservacion).State = EntityState.Modified;
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
                var Reservacion = ReservacionesBLL.Buscar(id);

                    if (Reservacion != null)
                    {
                        contexto.Reservaciones.Remove(Reservacion);
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
            public static Reservaciones Buscar(int id)
            {
                Reservaciones Reservacion = new Reservaciones();
                Contexto contexto = new Contexto();

                try
                {
                    Reservacion = contexto.Reservaciones.Include(x => x.ReservacionDetalle)
                    .Where(x => x.ReservacionID == id).Include(x => x.ReservacionDetalle).ThenInclude(x => x.Producto)
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
                return Reservacion;
            }
            public static List<Reservaciones> GetList(Expression<Func<Reservaciones, bool>> criterio)
            {
                List<Reservaciones> Lista = new List<Reservaciones>();

                Contexto contexto = new Contexto();

                try
                {
                    //obtener la lista y filtrarla según el criterio recibido por parametro.
                    Lista = contexto.Reservaciones.Where(criterio).ToList();
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
                    encontrado = contexto.Reservaciones.Any(e => e.ReservacionID == id);
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

