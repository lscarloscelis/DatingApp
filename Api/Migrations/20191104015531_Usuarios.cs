using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Api.Migrations
{
    public partial class Usuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Document = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Hash = table.Column<byte[]>(nullable: true),
                    Salt = table.Column<byte[]>(nullable: true),
                    Genero = table.Column<string>(nullable: true),
                    ConocidoComo = table.Column<string>(nullable: true),
                    Creado = table.Column<DateTime>(nullable: false),
                    UltimaActividad = table.Column<DateTime>(nullable: false),
                    Nacimiento = table.Column<DateTime>(nullable: false),
                    Introduccion = table.Column<string>(nullable: true),
                    Buscando = table.Column<string>(nullable: true),
                    Intereses = table.Column<string>(nullable: true),
                    Ciudad = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Document);
                });

            migrationBuilder.CreateTable(
                name: "Valores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Cantidad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fotos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Url = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Agregada = table.Column<DateTime>(nullable: false),
                    EsPerfil = table.Column<bool>(nullable: false),
                    UsuarioDocument = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fotos_Usuarios_UsuarioDocument",
                        column: x => x.UsuarioDocument,
                        principalTable: "Usuarios",
                        principalColumn: "Document",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fotos_UsuarioDocument",
                table: "Fotos",
                column: "UsuarioDocument");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fotos");

            migrationBuilder.DropTable(
                name: "Valores");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
