using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyLastBreath.Models
{
    public partial class bddefinitivaContext : DbContext
    {
        public bddefinitivaContext()
        {
        }

        public bddefinitivaContext(DbContextOptions<bddefinitivaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calificacion> Calificacions { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<Cursousuario> Cursousuarios { get; set; } = null!;
        public virtual DbSet<Disponibilidadcurso> Disponibilidadcursos { get; set; } = null!;
        public virtual DbSet<Profesore> Profesores { get; set; } = null!;
        public virtual DbSet<Tipocurso> Tipocursos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=bddefinitiva;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.24-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.HasKey(e => e.Idcalificacion)
                    .HasName("PRIMARY");

                entity.ToTable("calificacion");

                entity.Property(e => e.Idcalificacion)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("IDCalificacion");

                entity.Property(e => e.Nivel).HasMaxLength(255);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.Idcurso)
                    .HasName("PRIMARY");

                entity.ToTable("cursos");

                entity.HasIndex(e => e.ProfesorAsignado, "fk1");

                entity.HasIndex(e => e.Area, "fk2");

                entity.HasIndex(e => e.Disponibilidad, "fk3");

                entity.HasIndex(e => e.Dificultad, "fk4");

                entity.Property(e => e.Idcurso)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDCurso");

                entity.Property(e => e.Area).HasColumnType("int(11)");

                entity.Property(e => e.Dificultad).HasColumnType("int(11)");

                entity.Property(e => e.Disponibilidad).HasColumnType("int(11)");

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.NombreCurso).HasMaxLength(255);

                entity.Property(e => e.ProfesorAsignado).HasColumnType("int(11)");

                entity.HasOne(d => d.AreaNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.Area)
                    .HasConstraintName("fk2");

                entity.HasOne(d => d.DificultadNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.Dificultad)
                    .HasConstraintName("fk4");

                entity.HasOne(d => d.DisponibilidadNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.Disponibilidad)
                    .HasConstraintName("fk3");

                entity.HasOne(d => d.ProfesorAsignadoNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.ProfesorAsignado)
                    .HasConstraintName("fk1");
            });

            modelBuilder.Entity<Cursousuario>(entity =>
            {
                entity.HasKey(e => e.Idregistro)
                    .HasName("PRIMARY");

                entity.ToTable("cursousuario");

                entity.HasIndex(e => e.Idcursox, "asdasdasd");

                entity.HasIndex(e => e.Idusuariox, "qweqwe");

                entity.Property(e => e.Idregistro)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDRegistro");

                entity.Property(e => e.Idcursox)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDcursox");

                entity.Property(e => e.Idusuariox)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDusuariox");

                entity.HasOne(d => d.IdcursoxNavigation)
                    .WithMany(p => p.Cursousuarios)
                    .HasForeignKey(d => d.Idcursox)
                    .HasConstraintName("asdasdasd");

                entity.HasOne(d => d.IdusuarioxNavigation)
                    .WithMany(p => p.Cursousuarios)
                    .HasForeignKey(d => d.Idusuariox)
                    .HasConstraintName("qweqwe");
            });

            modelBuilder.Entity<Disponibilidadcurso>(entity =>
            {
                entity.HasKey(e => e.Iddisponibilidad)
                    .HasName("PRIMARY");

                entity.ToTable("disponibilidadcurso");

                entity.Property(e => e.Iddisponibilidad)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("IDDisponibilidad");

                entity.Property(e => e.Estado).HasMaxLength(255);
            });

            modelBuilder.Entity<Profesore>(entity =>
            {
                entity.HasKey(e => e.Idprofesor)
                    .HasName("PRIMARY");

                entity.ToTable("profesores");

                entity.Property(e => e.Idprofesor)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDProfesor");

                entity.Property(e => e.Apellido).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Tipocurso>(entity =>
            {
                entity.HasKey(e => e.IdtipoCurso)
                    .HasName("PRIMARY");

                entity.ToTable("tipocurso");

                entity.Property(e => e.IdtipoCurso)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("IDTipoCurso");

                entity.Property(e => e.Descripcion).HasMaxLength(255);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios");

                entity.Property(e => e.Iduser)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDUser");

                entity.Property(e => e.Nickname).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
