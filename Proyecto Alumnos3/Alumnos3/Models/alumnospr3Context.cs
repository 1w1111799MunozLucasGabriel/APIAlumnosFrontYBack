using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Alumnos3.Models
{
    public partial class alumnospr3Context : DbContext
    {
        public alumnospr3Context()
        {
        }

        public alumnospr3Context(DbContextOptions<alumnospr3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Sexo> Sexos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("User ID=prog3; Password=123456; Server=localhost; Database=alumnospr3; Integrated Security=true; Pooling=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Spanish_Argentina.1252");

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.ToTable("alumnos");

                entity.Property(e => e.AlumnoId).HasColumnName("alumno_id");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .HasColumnName("apellido");

                entity.Property(e => e.Curso)
                    .HasMaxLength(50)
                    .HasColumnName("curso");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.SexoId).HasColumnName("sexo_id");

                entity.HasOne(d => d.Sexo)
                    .WithMany(p => p.Alumnos)
                    .HasForeignKey(d => d.SexoId)
                    .HasConstraintName("alumnos_sexo_id_fkey");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.ToTable("sexo");

                entity.Property(e => e.SexoId).HasColumnName("sexo_id");

                entity.Property(e => e.Sexo1)
                    .HasMaxLength(20)
                    .HasColumnName("sexo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
