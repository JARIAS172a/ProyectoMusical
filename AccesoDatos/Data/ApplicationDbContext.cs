using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Albumes> Albumes { get; set; }

    public virtual DbSet<Artistas> Artistas { get; set; }

    public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }

    public virtual DbSet<Canciones> Canciones { get; set; }

    public virtual DbSet<CarritoCompras> CarritoCompras { get; set; }

    public virtual DbSet<DetalleCarrito> DetalleCarrito { get; set; }

    public virtual DbSet<DetalleVentas> DetalleVentas { get; set; }

    public virtual DbSet<GenerosMusicales> GenerosMusicales { get; set; }

    public virtual DbSet<Perfiles> Perfiles { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    public virtual DbSet<Ventas> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-BJF469RI\\SQLDEVELOPER;Database=LaVentaMusical;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Albumes>(entity =>
        {
            entity.HasKey(e => e.CodigoAlbum).HasName("PK__Albumes__A192F53D9753F21D");

            entity.Property(e => e.ImagenAlbum)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreAlbum)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.CodigoArtistaNavigation).WithMany(p => p.Albumes)
                .HasForeignKey(d => d.CodigoArtista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Albumes__CodigoA__31EC6D26");
        });

        modelBuilder.Entity<Artistas>(entity =>
        {
            entity.HasKey(e => e.CodigoArtista).HasName("PK__Artistas__1E9FC153A06508F2");

            entity.Property(e => e.FotoArtista)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LinkBiografia)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nacionalidad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreArtistico).HasMaxLength(100);
            entity.Property(e => e.NombreReal)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AspNetRoles>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaims>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUsers>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRoles>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUsers>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaims>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogins>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserTokens>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Canciones>(entity =>
        {
            entity.HasKey(e => e.CodigoCancion).HasName("PK__Cancione__E309E08A38BE660E");

            entity.Property(e => e.LinkVideo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreCancion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CodigoAlbumNavigation).WithMany(p => p.Canciones)
                .HasForeignKey(d => d.CodigoAlbum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Canciones__Codig__35BCFE0A");

            entity.HasOne(d => d.CodigoGeneroNavigation).WithMany(p => p.Canciones)
                .HasForeignKey(d => d.CodigoGenero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Canciones__Codig__34C8D9D1");
        });

        modelBuilder.Entity<CarritoCompras>(entity =>
        {
            entity.HasKey(e => e.IdCarrito).HasName("PK__CarritoC__8B4A618C6113C3DE");

            entity.Property(e => e.FechaCompra)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.CarritoCompras)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarritoCo__IdUsu__38996AB5");
        });

        modelBuilder.Entity<DetalleCarrito>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCarrito).HasName("PK__DetalleC__27A5F83BFEAFA3F6");

            entity.ToTable("DetalleCarrito");

            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CodigoCancionNavigation).WithMany(p => p.DetalleCarritos)
                .HasForeignKey(d => d.CodigoCancion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleCa__Codig__4316F928");

            entity.HasOne(d => d.IdCarritoNavigation).WithMany(p => p.DetalleCarritos)
                .HasForeignKey(d => d.IdCarrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleCa__IdCar__4222D4EF");
        });

        modelBuilder.Entity<DetalleVentas>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PK__DetalleV__AAA5CEC21F369556");

            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CodigoCancionNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.CodigoCancion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleVe__Codig__46E78A0C");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetalleVe__IdVen__45F365D3");
        });

        modelBuilder.Entity<GenerosMusicales>(entity =>
        {
            entity.HasKey(e => e.CodigoGenero).HasName("PK__GenerosM__4806D4DE20F67BD8");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FotoGenero).HasMaxLength(100);
        });

        modelBuilder.Entity<Perfiles>(entity =>
        {
            entity.HasKey(e => e.IdPerfil).HasName("PK__Perfiles__C7BD5CC1CAECE20C");

            entity.Property(e => e.NombrePerfil)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__5B65BF971D6D212C");

            entity.HasIndex(e => e.CorreoElectronico, "UQ__Usuarios__531402F345CE6B0B").IsUnique();

            entity.HasIndex(e => e.NumeroIdentificacion, "UQ__Usuarios__FCA68D91346B8688").IsUnique();

            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DineroDisponible).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NumeroIdentificacion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NumeroTarjeta)
                .HasMaxLength(19)
                .IsUnicode(false);
            entity.Property(e => e.TipoTarjeta)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__IdPerf__2B3F6F97");
        });

        modelBuilder.Entity<Ventas>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Ventas__BC1240BD0B8C9999");

            entity.Property(e => e.FechaCompra)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ventas__IdUsuari__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
