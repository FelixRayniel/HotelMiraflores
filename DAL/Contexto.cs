using HotelMiraflores.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMiraflores.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Huespedes> Huespedes { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Marcas> Marcas { get; set; }
        public DbSet<Habitaciones> Habitaciones { get; set; }
        public DbSet<TipoHabitaciones> TipoHabitaciones { get; set; }
        public DbSet<Reservaciones> Reservaciones { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\BDHotelMiraFlores.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamentos>().HasData(new Departamentos
            {
                DepartamentoId = 1,
                Descripcion = "Restaurante",
            });

            modelBuilder.Entity<Departamentos>().HasData(new Departamentos
            {
                DepartamentoId = 2,
                Descripcion = "Bar",
            });

            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                RolId = 1,
                Descripcion = "Administrador",
            });

            modelBuilder.Entity<Roles>().HasData(new Roles
            {
                RolId = 2,
                Descripcion = "Recepcionista",
            });

            modelBuilder.Entity<TipoHabitaciones>().HasData(new TipoHabitaciones
            {
                TipoHabitacionId = 1,
                Descripcion = "Sencilla",
            });

            modelBuilder.Entity<TipoHabitaciones>().HasData(new TipoHabitaciones
            {
                TipoHabitacionId = 2,
                Descripcion = "Double",

            });

            modelBuilder.Entity<TipoHabitaciones>().HasData(new TipoHabitaciones
            {
                TipoHabitacionId = 3,
                Descripcion = "Triple",

            });

        }
    }
}
