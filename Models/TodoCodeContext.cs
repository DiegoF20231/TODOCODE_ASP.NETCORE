using Microsoft.EntityFrameworkCore;

namespace BackendTodoCode.Models;

public partial class TodoCodeContext : DbContext
{
    public TodoCodeContext()
    {
    }

    public TodoCodeContext(DbContextOptions<TodoCodeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<Nacionalidad> Nacionalidads { get; set; }

    public virtual DbSet<Paquete> Paquetes { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<VentaPaquete> VentaPaquetes { get; set; }

    public virtual DbSet<VentaServicio> VentaServicios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Cliente__885457EE5DD148F4");

            entity.ToTable("Cliente");

            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.ApellidoCliente)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.DireccionCliente)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Dniempleado)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("DNIEmpleado");
            entity.Property(e => e.EmailCliente)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.IdNacionalidad).HasColumnName("idNacionalidad");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(90)
                .IsUnicode(false);

            entity.HasOne(d => d.IdNacionalidadNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdNacionalidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_Nacionalidad");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__Empleado__5295297CFE028234");

            entity.ToTable("Empleado");

            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.ApellidoEmpleado)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Cargo)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.CelularEmpleado)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.DireccionEmpleado)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Dniempleado)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("DNIEmpleado");
            entity.Property(e => e.EmailEmpleado)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.IdNacionalidad).HasColumnName("idNacionalidad");
            entity.Property(e => e.NombreEmpleado)
                .HasMaxLength(90)
                .IsUnicode(false);
            entity.Property(e => e.Sueldo).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdNacionalidadNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdNacionalidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleado_Nacionalidad");
        });

        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasKey(e => e.IdMetodoPago).HasName("PK__MetodoPa__817BFC32C7583C5E");

            entity.ToTable("MetodoPago");

            entity.Property(e => e.IdMetodoPago).HasColumnName("idMetodoPago");
            entity.Property(e => e.MetodoPago1)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("MetodoPago");
        });

        modelBuilder.Entity<Nacionalidad>(entity =>
        {
            entity.HasKey(e => e.IdNacionalidad).HasName("PK__Nacional__52613BE73F1D5AB9");

            entity.ToTable("Nacionalidad");

            entity.Property(e => e.IdNacionalidad).HasColumnName("idNacionalidad");
            entity.Property(e => e.NombreNacionalidad)
                .HasMaxLength(45)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Paquete>(entity =>
        {
            entity.HasKey(e => e.IdPaquete).HasName("PK__Paquete__646BA35FFE92C50E");

            entity.ToTable("Paquete");

            entity.Property(e => e.IdPaquete).HasColumnName("idPaquete");
            entity.Property(e => e.CostoPaquete).HasColumnType("decimal(10, 2)");

            entity.HasMany(d => d.IdServicos).WithMany(p => p.IdPaquetes)
                .UsingEntity<Dictionary<string, object>>(
                    "PaqueteTuristico",
                    r => r.HasOne<Servicio>().WithMany()
                        .HasForeignKey("IdServico")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PaqueteTuristico_Servicio"),
                    l => l.HasOne<Paquete>().WithMany()
                        .HasForeignKey("IdPaquete")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PaqueteTuristico_Paquete"),
                    j =>
                    {
                        j.HasKey("IdPaquete", "IdServico").HasName("PK__PaqueteT__6488491B59AA6D8E");
                        j.ToTable("PaqueteTuristico");
                        j.IndexerProperty<int>("IdPaquete").HasColumnName("idPaquete");
                        j.IndexerProperty<int>("IdServico").HasColumnName("idServico");
                    });
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__CEB98119E1A04795");

            entity.ToTable("Servicio");

            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.CostoServicio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.DestinoServicio)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.FechaServicio).HasColumnType("datetime");
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(45)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VentaPaquete>(entity =>
        {
            entity.HasKey(e => e.IdVentaPaquete).HasName("PK__VentaPaq__3C60818260917F19");

            entity.ToTable("VentaPaquete");

            entity.Property(e => e.IdVentaPaquete).HasColumnName("idVentaPaquete");
            entity.Property(e => e.FechaVenta).HasColumnType("datetime");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdMetodoPago).HasColumnName("idMetodoPago");
            entity.Property(e => e.IdPaquete).HasColumnName("idPaquete");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.VentaPaquetes)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VentaPaquete_Cliente");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.VentaPaquetes)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VentaPaquete_Empleado");

            entity.HasOne(d => d.IdMetodoPagoNavigation).WithMany(p => p.VentaPaquetes)
                .HasForeignKey(d => d.IdMetodoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VentaPaquete_MetodoPago");

            entity.HasOne(d => d.IdPaqueteNavigation).WithMany(p => p.VentaPaquetes)
                .HasForeignKey(d => d.IdPaquete)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VentaPaquete_Paquete");
        });

        modelBuilder.Entity<VentaServicio>(entity =>
        {
            entity.HasKey(e => e.IdVentaServicio).HasName("PK__VentaSer__59B03D9C510F2514");

            entity.ToTable("VentaServicio");

            entity.Property(e => e.IdVentaServicio).HasColumnName("idVentaServicio");
            entity.Property(e => e.FechaVenta).HasColumnType("datetime");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");
            entity.Property(e => e.IdMetodoPago).HasColumnName("idMetodoPago");
            entity.Property(e => e.IdServicio).HasColumnName("idServicio");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.VentaServicios)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VentaServicio_Cliente");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.VentaServicios)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VentaServicio_Empleado");

            entity.HasOne(d => d.IdMetodoPagoNavigation).WithMany(p => p.VentaServicios)
                .HasForeignKey(d => d.IdMetodoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VentaServicio_MetodoPago");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.VentaServicios)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VentaServicio_Servicio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
