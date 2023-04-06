using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProyectoRest.ModelosC;

namespace ProyectoRest
{
    public partial class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext()
        {
        }

        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudad> Ciudades { get; set; } = null!;
        public virtual DbSet<Pais> Paises { get; set; } = null!;
        public virtual DbSet<Provincia> Provincias { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarioss { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=NB101388;Initial Catalog=UsuarioDb;Persist Security Info=true;User id=sa;Password=Andreani;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.IdCiudad);

                entity.ToTable("Ciudad");

                entity.Property(e => e.IdCiudad).HasColumnName("idCiudad");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                //entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithOne(p => p.Ciudad)
                    .HasForeignKey<Ciudad>(d => d.IdCiudad)
                    
                    .HasConstraintName("FK_Ciudad_Provincia");
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.IdPais);

                entity.ToTable("Pais");


                entity.Property(e => e.IdPais).HasColumnName("idPais");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.IdProvincia);
                
                entity.ToTable("Provincia");

                entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");
                    //.IsFixedLength();

                //entity.Property(e => e.IdPais).HasColumnName("idPais");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Provincia)
                    .HasForeignKey(d => d.IdPais)
                    .HasConstraintName("FK_Provincia_Pais");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("idUser");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdCiudad).HasColumnName("idCiudad");

                entity.Property(e => e.IdPais).HasColumnName("idPais");

                entity.Property(e => e.IdProvincia).HasColumnName("idProvincia");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.Property(e => e.Telefono).HasColumnName("telefono");

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdCiudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Ciudad");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Pais");

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdProvincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Provincia");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
