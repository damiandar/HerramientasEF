﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyMVC.Models;

namespace ProyMVC.Migrations
{
    [DbContext(typeof(CineDbContext))]
    [Migration("20210605233447_Primera")]
    partial class Primera
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProyMVC.Models.ActorPeliculas", b =>
                {
                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.HasKey("ActorId", "PeliculaId");

                    b.HasIndex("PeliculaId");

                    b.ToTable("ActorPeliculas");
                });

            modelBuilder.Entity("ProyMVC.Models.Actores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoRuta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Actores");
                });

            modelBuilder.Entity("ProyMVC.Models.Bios", b =>
                {
                    b.Property<int>("BioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("EstadoCivil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BioId");

                    b.HasIndex("ActorId")
                        .IsUnique();

                    b.ToTable("Bios");
                });

            modelBuilder.Entity("ProyMVC.Models.Generos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("ProyMVC.Models.Peliculas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<int?>("GeneroId")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GeneroId");

                    b.ToTable("Peliculas");
                });

            modelBuilder.Entity("ProyMVC.Models.ActorPeliculas", b =>
                {
                    b.HasOne("ProyMVC.Models.Actores", "Actor")
                        .WithMany("ActorPeliculas")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyMVC.Models.Peliculas", "Pelicula")
                        .WithMany("ActorPeliculas")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("ProyMVC.Models.Bios", b =>
                {
                    b.HasOne("ProyMVC.Models.Actores", "Actor")
                        .WithOne("Bios")
                        .HasForeignKey("ProyMVC.Models.Bios", "ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");
                });

            modelBuilder.Entity("ProyMVC.Models.Peliculas", b =>
                {
                    b.HasOne("ProyMVC.Models.Generos", "Genero")
                        .WithMany("Peliculas")
                        .HasForeignKey("GeneroId");

                    b.Navigation("Genero");
                });

            modelBuilder.Entity("ProyMVC.Models.Actores", b =>
                {
                    b.Navigation("ActorPeliculas");

                    b.Navigation("Bios");
                });

            modelBuilder.Entity("ProyMVC.Models.Generos", b =>
                {
                    b.Navigation("Peliculas");
                });

            modelBuilder.Entity("ProyMVC.Models.Peliculas", b =>
                {
                    b.Navigation("ActorPeliculas");
                });
#pragma warning restore 612, 618
        }
    }
}