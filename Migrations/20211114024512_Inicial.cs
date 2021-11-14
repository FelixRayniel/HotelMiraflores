using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelMiraflores.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    DepartamentoID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.DepartamentoID);
                });

            migrationBuilder.CreateTable(
                name: "Huespedes",
                columns: table => new
                {
                    HuespedID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Cedula = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Huespedes", x => x.HuespedID);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    MarcaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.MarcaID);
                });

            migrationBuilder.CreateTable(
                name: "Suplidores",
                columns: table => new
                {
                    SuplidorID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplidores", x => x.SuplidorID);
                });

            migrationBuilder.CreateTable(
                name: "TipoHabitaciones",
                columns: table => new
                {
                    TipoHabitacionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoHabitaciones", x => x.TipoHabitacionID);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Unidad = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecioCosto = table.Column<float>(type: "REAL", nullable: false),
                    PrecioVenta = table.Column<float>(type: "REAL", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    MarcaID = table.Column<int>(type: "INTEGER", nullable: true),
                    DepartamentoID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoID);
                    table.ForeignKey(
                        name: "FK_Productos_Departamentos_DepartamentoID",
                        column: x => x.DepartamentoID,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Marcas_MarcaID",
                        column: x => x.MarcaID,
                        principalTable: "Marcas",
                        principalColumn: "MarcaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Habitaciones",
                columns: table => new
                {
                    HabitacionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<string>(type: "TEXT", nullable: true),
                    Precio = table.Column<float>(type: "REAL", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    TipoHabitacionID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitaciones", x => x.HabitacionID);
                    table.ForeignKey(
                        name: "FK_Habitaciones_TipoHabitaciones_TipoHabitacionID",
                        column: x => x.TipoHabitacionID,
                        principalTable: "TipoHabitaciones",
                        principalColumn: "TipoHabitacionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservaciones",
                columns: table => new
                {
                    ReservacionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CantidadPersonas = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaEntrada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Total = table.Column<float>(type: "REAL", nullable: false),
                    ITBIS = table.Column<float>(type: "REAL", nullable: false),
                    Descuentos = table.Column<float>(type: "REAL", nullable: false),
                    TotalGeneral = table.Column<float>(type: "REAL", nullable: false),
                    Comentarios = table.Column<string>(type: "TEXT", nullable: true),
                    HuespedID = table.Column<int>(type: "INTEGER", nullable: true),
                    TipoHabitacionID = table.Column<int>(type: "INTEGER", nullable: true),
                    HabitacionID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservaciones", x => x.ReservacionID);
                    table.ForeignKey(
                        name: "FK_Reservaciones_Huespedes_HuespedID",
                        column: x => x.HuespedID,
                        principalTable: "Huespedes",
                        principalColumn: "HuespedID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservaciones_TipoHabitaciones_HabitacionID",
                        column: x => x.HabitacionID,
                        principalTable: "TipoHabitaciones",
                        principalColumn: "TipoHabitacionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservaciones_TipoHabitaciones_TipoHabitacionID",
                        column: x => x.TipoHabitacionID,
                        principalTable: "TipoHabitaciones",
                        principalColumn: "TipoHabitacionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "DepartamentoID", "Descripcion" },
                values: new object[] { 1, "Restaurante" });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "DepartamentoID", "Descripcion" },
                values: new object[] { 2, "Bar" });

            migrationBuilder.CreateIndex(
                name: "IX_Habitaciones_TipoHabitacionID",
                table: "Habitaciones",
                column: "TipoHabitacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_DepartamentoID",
                table: "Productos",
                column: "DepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MarcaID",
                table: "Productos",
                column: "MarcaID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_HabitacionID",
                table: "Reservaciones",
                column: "HabitacionID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_HuespedID",
                table: "Reservaciones",
                column: "HuespedID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservaciones_TipoHabitacionID",
                table: "Reservaciones",
                column: "TipoHabitacionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habitaciones");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Reservaciones");

            migrationBuilder.DropTable(
                name: "Suplidores");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Huespedes");

            migrationBuilder.DropTable(
                name: "TipoHabitaciones");
        }
    }
}
