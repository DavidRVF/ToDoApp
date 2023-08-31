using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Models;

public partial class BdintroContext : DbContext
{
    public BdintroContext()
    {
    }

    public BdintroContext(DbContextOptions<BdintroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArchivosTarea> ArchivosTareas { get; set; }

    public virtual DbSet<ListaTarea> ListaTareas { get; set; }

    public virtual DbSet<Tarea> Tareas { get; set; }

    public virtual DbSet<TipoTarea> TipoTareas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data source=LAPTOP-I9DRU1VP\\SQLEXPRESS; Initial Catalog=BDINTRO; user id=sa; password=12345;trustservercertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArchivosTarea>(entity =>
        {
            entity.HasKey(e => e.IdArchivo).HasName("PK__Archivos__26B92111675040C6");

            entity.ToTable("ArchivosTarea");

            entity.Property(e => e.UrlArchivo).HasMaxLength(100);

            entity.HasOne(d => d.IdTareaNavigation).WithMany(p => p.ArchivosTareas)
                .HasForeignKey(d => d.IdTarea)
                .HasConstraintName("fk_IdTarea");
        });

        modelBuilder.Entity<ListaTarea>(entity =>
        {
            entity.HasKey(e => e.IdListaTarea).HasName("PK__ListaTar__B289BDC254097C28");

            entity.ToTable("ListaTarea");

            entity.Property(e => e.FechaTermino).HasColumnType("date");
            entity.Property(e => e.FechaAlta).HasColumnType("date");
            entity.Property(e => e.FechaLimite).HasColumnType("date");
            entity.Property(e => e.NombreLista).HasMaxLength(100);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ListaTareas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IdUsuario");
        });

        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__Tarea__EADE9098FD9AD498");

            entity.ToTable("Tarea");

            entity.Property(e => e.Descripcion).HasMaxLength(1000);
            entity.Property(e => e.FechaAlta).HasColumnType("date");
            entity.Property(e => e.FechaLimite).HasColumnType("date");
            entity.Property(e => e.FechaTermino).HasColumnType("date");
            entity.Property(e => e.Tarea1)
                .HasMaxLength(100)
                .HasColumnName("Tarea");

            entity.HasOne(d => d.IdListaTareaNavigation).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdListaTarea)
                .HasConstraintName("fk_IdListaTarea");

            entity.HasOne(d => d.IdTareaPadreNavigation).WithMany(p => p.InverseIdTareaPadreNavigation)
                .HasForeignKey(d => d.IdTareaPadre)
                .HasConstraintName("fk_IdTareaPadre");
        });

        modelBuilder.Entity<TipoTarea>(entity =>
        {
            entity.HasKey(e => e.IdTipoTarea);

            entity.ToTable("TipoTarea");

            entity.Property(e => e.TipoTarea1)
                .HasMaxLength(50)
                .HasColumnName("TipoTarea");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaAlta).HasColumnType("date");
            entity.Property(e => e.NombreCompleto).HasMaxLength(100);
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Usuario1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
