﻿// <auto-generated />
using System;
using HotelMiraflores.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelMiraflores.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20211115221600_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("HotelMiraflores.Entidades.Departamentos", b =>
                {
                    b.Property<int>("DepartamentoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.HasKey("DepartamentoID");

                    b.ToTable("Departamentos");

                    b.HasData(
                        new
                        {
                            DepartamentoID = 1,
                            Descripcion = "Restaurante"
                        },
                        new
                        {
                            DepartamentoID = 2,
                            Descripcion = "Bar"
                        });
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.Habitaciones", b =>
                {
                    b.Property<int>("HabitacionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Disponibilidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Numero")
                        .HasColumnType("TEXT");

                    b.Property<float>("Precio")
                        .HasColumnType("REAL");

                    b.Property<int>("TipoHabitacionID")
                        .HasColumnType("INTEGER");

                    b.HasKey("HabitacionID");

                    b.ToTable("Habitaciones");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.Huespedes", b =>
                {
                    b.Property<int>("HuespedID")
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

                    b.HasKey("HuespedID");

                    b.ToTable("Huespedes");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.Marcas", b =>
                {
                    b.Property<int>("MarcaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.HasKey("MarcaID");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.Productos", b =>
                {
                    b.Property<int>("ProductoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadDisponible")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DepartamentoID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("MarcaID")
                        .HasColumnType("INTEGER");

                    b.Property<float>("PrecioCosto")
                        .HasColumnType("REAL");

                    b.Property<float>("PrecioVenta")
                        .HasColumnType("REAL");

                    b.Property<int>("Unidad")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductoID");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.Reservaciones", b =>
                {
                    b.Property<int>("ReservacionID")
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

                    b.Property<int>("HabitacionID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HuespedID")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Total")
                        .HasColumnType("REAL");

                    b.Property<float>("TotalGeneral")
                        .HasColumnType("REAL");

                    b.Property<float>("TotalProductos")
                        .HasColumnType("REAL");

                    b.HasKey("ReservacionID");

                    b.ToTable("Reservaciones");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.ReservacionesDetalle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Precio")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductoID")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ReservacionID")
                        .HasColumnType("INTEGER");

                    b.Property<float>("TotalProducto")
                        .HasColumnType("REAL");

                    b.HasKey("ID");

                    b.HasIndex("ProductoID");

                    b.HasIndex("ReservacionID");

                    b.ToTable("ReservacionesDetalle");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.Suplidores", b =>
                {
                    b.Property<int>("SuplidorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.HasKey("SuplidorID");

                    b.ToTable("Suplidores");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.TipoHabitaciones", b =>
                {
                    b.Property<int>("TipoHabitacionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.HasKey("TipoHabitacionID");

                    b.ToTable("TipoHabitaciones");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.ReservacionesDetalle", b =>
                {
                    b.HasOne("HotelMiraflores.Entidades.Productos", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelMiraflores.Entidades.Reservaciones", null)
                        .WithMany("ReservacionDetalle")
                        .HasForeignKey("ReservacionID");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("HotelMiraflores.Entidades.Reservaciones", b =>
                {
                    b.Navigation("ReservacionDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
