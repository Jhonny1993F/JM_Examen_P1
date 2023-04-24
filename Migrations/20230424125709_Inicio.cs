using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JM_Examen_P1.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Montero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JM_SemestreId = table.Column<int>(type: "int", nullable: false),
                    JM_Nota = table.Column<double>(type: "float", nullable: false),
                    JM_Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JM_Estudiante = table.Column<bool>(type: "bit", nullable: false),
                    JM_Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Montero", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Montero");
        }
    }
}
