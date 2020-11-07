using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyMVC.Models
{
    public partial class CineDbContext : DbContext
    {
        public CineDbContext()
        {
        }

        public CineDbContext(DbContextOptions<CineDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActorPeliculas> ActorPeliculas { get; set; }
        public virtual DbSet<Actores> Actores { get; set; }
        public virtual DbSet<Bios> Bios { get; set; }
        public virtual DbSet<Generos> Generos { get; set; }
        public virtual DbSet<Peliculas> Peliculas { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=192.168.99.100;Database=Cine;user=sa;password=Password_123; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorPeliculas>(entity =>
            {
                entity.HasKey(e => new { e.ActorId, e.PeliculaId });

                entity.HasIndex(e => e.PeliculaId);

                entity.HasOne(d => d.Actor)
                    .WithMany(p => p.ActorPeliculas)
                    .HasForeignKey(d => d.ActorId);

                entity.HasOne(d => d.Pelicula)
                    .WithMany(p => p.ActorPeliculas)
                    .HasForeignKey(d => d.PeliculaId);
            });

            modelBuilder.Entity<Bios>(entity =>
            {
                entity.HasKey(e => e.BioId);

                entity.HasIndex(e => e.ActorId)
                    .IsUnique();

                entity.HasOne(d => d.Actor)
                    .WithOne(p => p.Bios)
                    .HasForeignKey<Bios>(d => d.ActorId);
            });

            modelBuilder.Entity<Peliculas>(entity =>
            {
                entity.HasIndex(e => e.GeneroId);

                entity.HasOne(d => d.Genero)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.GeneroId);
            });

           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
