// <auto-generated />
using System;
using HotelMiraflores.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelMiraflores.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("HotelMiraflores.Entidades.Compras", b =>
                {
                    b.Property<int>("CompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("SuplidorId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("TotalCompra")
                        .HasColumnType("REAL");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CompraId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.ComprasDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadDisponible")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompraId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Costo")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompraId");

                    b.HasIndex("ProductoId");

                    b.ToTable("ComprasDetalle");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.Departamentos", b =>
                {
                    b.Property<int>("DepartamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.HasKey("DepartamentoId");

                    b.ToTable("Departamentos");

                    b.HasData(
                        new
                        {
                            DepartamentoId = 1,
                            Descripcion = "Restaurante"
                        },
                        new
                        {
                            DepartamentoId = 2,
                            Descripcion = "Bar"
                        });
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.Habitaciones", b =>
                {
                    b.Property<int>("HabitacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Numero")
                        .HasColumnType("TEXT");

                    b.Property<float>("Precio")
                        .HasColumnType("REAL");

                    b.Property<int>("TipoHabitacionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("HabitacionId");

                    b.ToTable("Habitaciones");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.Huespedes", b =>
                {
                    b.Property<int>("HuespedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cedula")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("HuespedId");

                    b.ToTable("Huespedes");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.Marcas", b =>
                {
                    b.Property<int>("MarcaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MarcaId");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.Productos", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadDisponible")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("MarcaId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("PrecioCosto")
                        .HasColumnType("REAL");

                    b.Property<float>("PrecioVenta")
                        .HasColumnType("REAL");

                    b.Property<int>("SuplidorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Unidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.Reservaciones", b =>
                {
                    b.Property<int>("ReservacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadDias")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadPersonas")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comentarios")
                        .HasColumnType("TEXT");

                    b.Property<float>("Descuentos")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaEntrada")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("TEXT");

                    b.Property<int>("HabitacionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HuespedId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Total")
                        .HasColumnType("REAL");

                    b.Property<float>("TotalGeneral")
                        .HasColumnType("REAL");

                    b.Property<float>("TotalProductos")
                        .HasColumnType("REAL");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReservacionId");

                    b.ToTable("Reservaciones");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.ReservacionesDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Precio")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ReservacionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("ReservacionId");

                    b.ToTable("ReservacionesDetalle");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.Roles", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.HasKey("RolId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RolId = 1,
                            Descripcion = "Administrador"
                        },
                        new
                        {
                            RolId = 2,
                            Descripcion = "Recepcionista"
                        });
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.Suplidores", b =>
                {
                    b.Property<int>("SuplidorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SuplidorId");

                    b.ToTable("Suplidores");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.TipoHabitaciones", b =>
                {
                    b.Property<int>("TipoHabitacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TipoHabitacionId");

                    b.ToTable("TipoHabitaciones");

                    b.HasData(
                        new
                        {
                            TipoHabitacionId = 1,
                            Descripcion = "Sencilla",
                            UsuarioId = 0
                        },
                        new
                        {
                            TipoHabitacionId = 2,
                            Descripcion = "Double",
                            UsuarioId = 0
                        },
                        new
                        {
                            TipoHabitacionId = 3,
                            Descripcion = "Triple",
                            UsuarioId = 0
                        });
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Clave")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<int>("RolId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            Clave = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                            NombreUsuario = "admin",
                            Nombres = "Profesor",
                            RolId = 1
                        },
                        new
                        {
                            UsuarioId = 2,
                            Clave = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                            NombreUsuario = "F.Reynoso",
                            Nombres = "Felix Reynoso",
                            RolId = 1
                        },
                        new
                        {
                            UsuarioId = 3,
                            Clave = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                            NombreUsuario = "P.Canario",
                            Nombres = "Perla Canario",
                            RolId = 1
                        });
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.ComprasDetalle", b =>
                {
                    b.HasOne("HotelMiraflores.Entidades.Compras", null)
                        .WithMany("ComprasDetalle")
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelMiraflores.Entidades.Productos", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.ReservacionesDetalle", b =>
                {
                    b.HasOne("HotelMiraflores.Entidades.Productos", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelMiraflores.Entidades.Reservaciones", null)
                        .WithMany("ReservacionDetalle")
                        .HasForeignKey("ReservacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.Compras", b =>
                {
                    b.Navigation("ComprasDetalle");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.Reservaciones", b =>
                {
                    b.Navigation("ReservacionDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
