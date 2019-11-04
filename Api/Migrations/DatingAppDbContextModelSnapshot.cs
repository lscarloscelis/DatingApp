﻿// <auto-generated />
using System;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Api.Migrations
{
    [DbContext(typeof(DatingAppDbContext))]
    partial class DatingAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Api.Models.Foto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Agregada");

                    b.Property<string>("Descripcion");

                    b.Property<bool>("EsPerfil");

                    b.Property<string>("Url");

                    b.Property<string>("UsuarioDocument");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioDocument");

                    b.ToTable("Fotos");
                });

            modelBuilder.Entity("Api.Models.Usuario", b =>
                {
                    b.Property<string>("Document")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Buscando");

                    b.Property<string>("Ciudad");

                    b.Property<string>("ConocidoComo");

                    b.Property<DateTime>("Creado");

                    b.Property<string>("Genero");

                    b.Property<byte[]>("Hash");

                    b.Property<string>("Intereses");

                    b.Property<string>("Introduccion");

                    b.Property<DateTime>("Nacimiento");

                    b.Property<string>("Pais");

                    b.Property<byte[]>("Salt");

                    b.Property<DateTime>("UltimaActividad");

                    b.Property<string>("Username");

                    b.HasKey("Document");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Api.Models.Valor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cantidad");

                    b.HasKey("Id");

                    b.ToTable("Valores");
                });

            modelBuilder.Entity("Api.Models.Foto", b =>
                {
                    b.HasOne("Api.Models.Usuario", "Usuario")
                        .WithMany("Fotos")
                        .HasForeignKey("UsuarioDocument");
                });
#pragma warning restore 612, 618
        }
    }
}
