using System;
using ApiPeliculas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiPeliculas.Infrastructure.Data
{
    public partial class PeliculasmezqContext : DbContext
    {
        public PeliculasmezqContext()
        {
        }

        public PeliculasmezqContext(DbContextOptions<PeliculasmezqContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Pelicula> Peliculas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Director>(entity =>
            {
                entity.HasKey(e => e.IdDirector)
                    .HasName("PK_DIRECTOR_ID");

                entity.ToTable("Director");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Pelicula)
                    .WithOne(p => p.Directors)
                    .HasForeignKey<Director>(d => d.IdPelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IDPELIDirector");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK_IDGENERO");

                entity.ToTable("Genero");

                entity.Property(e => e.Genero1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Genero");

                entity.HasOne(d => d.Pelicula)
                    .WithOne(p => p.Generos)
                    .HasForeignKey<Genero>(d => d.IdPelicula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IDPELICULA");
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.Property(e => e.FechaPublicacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Fecha_Publicacion");

                entity.Property(e => e.Rating).HasColumnType("decimal(4, 1)");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
