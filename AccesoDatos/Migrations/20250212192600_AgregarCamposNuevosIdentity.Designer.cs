﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models.Data;

#nullable disable

namespace ProyectoVentaMusical.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250212192600_AgregarCamposNuevosIdentity")]
    partial class AgregarCamposNuevosIdentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AspNetUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("Models.Data.Albumes", b =>
                {
                    b.Property<int>("CodigoAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoAlbum"));

                    b.Property<int>("AñoLanzamiento")
                        .HasColumnType("int");

                    b.Property<int>("CodigoArtista")
                        .HasColumnType("int");

                    b.Property<string>("ImagenAlbum")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NombreAlbum")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("CodigoAlbum")
                        .HasName("PK__Albumes__A192F53D9753F21D");

                    b.HasIndex("CodigoArtista");

                    b.ToTable("Albumes");
                });

            modelBuilder.Entity("Models.Data.Artistas", b =>
                {
                    b.Property<int>("CodigoArtista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoArtista"));

                    b.Property<DateOnly>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("FotoArtista")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LinkBiografia")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nacionalidad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NombreArtistico")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NombreReal")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("CodigoArtista")
                        .HasName("PK__Artistas__1E9FC153A06508F2");

                    b.ToTable("Artistas");
                });

            modelBuilder.Entity("Models.Data.AspNetRoleClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetRoleClaims_RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Models.Data.AspNetRoles", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedName" }, "RoleNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Models.Data.AspNetUserClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserClaims_UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Models.Data.AspNetUserLogins", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserLogins_UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Models.Data.AspNetUserTokens", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Models.Data.AspNetUsers", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedEmail" }, "EmailIndex");

                    b.HasIndex(new[] { "NormalizedUserName" }, "UserNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Models.Data.Canciones", b =>
                {
                    b.Property<int>("CodigoCancion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoCancion"));

                    b.Property<int>("CantidadDisponible")
                        .HasColumnType("int");

                    b.Property<int>("CodigoAlbum")
                        .HasColumnType("int");

                    b.Property<int>("CodigoGenero")
                        .HasColumnType("int");

                    b.Property<string>("LinkVideo")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NombreCancion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("CodigoCancion")
                        .HasName("PK__Cancione__E309E08A38BE660E");

                    b.HasIndex("CodigoAlbum");

                    b.HasIndex("CodigoGenero");

                    b.ToTable("Canciones");
                });

            modelBuilder.Entity("Models.Data.CarritoCompras", b =>
                {
                    b.Property<int>("IdCarrito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCarrito"));

                    b.Property<DateTime?>("FechaCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("TipoPago")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("IdCarrito")
                        .HasName("PK__CarritoC__8B4A618C6113C3DE");

                    b.HasIndex("IdUsuario");

                    b.ToTable("CarritoCompras");
                });

            modelBuilder.Entity("Models.Data.DetalleCarrito", b =>
                {
                    b.Property<int>("IdDetalleCarrito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleCarrito"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CodigoCancion")
                        .HasColumnType("int");

                    b.Property<int>("IdCarrito")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("IdDetalleCarrito")
                        .HasName("PK__DetalleC__27A5F83BFEAFA3F6");

                    b.HasIndex("CodigoCancion");

                    b.HasIndex("IdCarrito");

                    b.ToTable("DetalleCarrito", (string)null);
                });

            modelBuilder.Entity("Models.Data.DetalleVentas", b =>
                {
                    b.Property<int>("IdDetalleVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleVenta"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CodigoCancion")
                        .HasColumnType("int");

                    b.Property<int>("IdVenta")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("IdDetalleVenta")
                        .HasName("PK__DetalleV__AAA5CEC21F369556");

                    b.HasIndex("CodigoCancion");

                    b.HasIndex("IdVenta");

                    b.ToTable("DetalleVentas");
                });

            modelBuilder.Entity("Models.Data.GenerosMusicales", b =>
                {
                    b.Property<int>("CodigoGenero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoGenero"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FotoGenero")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CodigoGenero")
                        .HasName("PK__GenerosM__4806D4DE20F67BD8");

                    b.ToTable("GenerosMusicales");
                });

            modelBuilder.Entity("Models.Data.Perfiles", b =>
                {
                    b.Property<int>("IdPerfil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPerfil"));

                    b.Property<string>("NombrePerfil")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdPerfil")
                        .HasName("PK__Perfiles__C7BD5CC1CAECE20C");

                    b.ToTable("Perfiles");
                });

            modelBuilder.Entity("Models.Data.Usuarios", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("DineroDisponible")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<int>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NumeroIdentificacion")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("NumeroTarjeta")
                        .IsRequired()
                        .HasMaxLength(19)
                        .IsUnicode(false)
                        .HasColumnType("varchar(19)");

                    b.Property<string>("TipoTarjeta")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("IdUsuario")
                        .HasName("PK__Usuarios__5B65BF971D6D212C");

                    b.HasIndex("IdPerfil");

                    b.HasIndex(new[] { "CorreoElectronico" }, "UQ__Usuarios__531402F345CE6B0B")
                        .IsUnique();

                    b.HasIndex(new[] { "NumeroIdentificacion" }, "UQ__Usuarios__FCA68D91346B8688")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Models.Data.Ventas", b =>
                {
                    b.Property<int>("IdVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVenta"));

                    b.Property<DateTime?>("FechaCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("TipoPago")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("IdVenta")
                        .HasName("PK__Ventas__BC1240BD0B8C9999");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("AspNetUserRole", b =>
                {
                    b.HasOne("Models.Data.AspNetRoles", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Data.AspNetUsers", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Data.Albumes", b =>
                {
                    b.HasOne("Models.Data.Artistas", "CodigoArtistaNavigation")
                        .WithMany("Albumes")
                        .HasForeignKey("CodigoArtista")
                        .IsRequired()
                        .HasConstraintName("FK__Albumes__CodigoA__31EC6D26");

                    b.Navigation("CodigoArtistaNavigation");
                });

            modelBuilder.Entity("Models.Data.AspNetRoleClaims", b =>
                {
                    b.HasOne("Models.Data.AspNetRoles", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Models.Data.AspNetUserClaims", b =>
                {
                    b.HasOne("Models.Data.AspNetUsers", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Data.AspNetUserLogins", b =>
                {
                    b.HasOne("Models.Data.AspNetUsers", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Data.AspNetUserTokens", b =>
                {
                    b.HasOne("Models.Data.AspNetUsers", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Data.Canciones", b =>
                {
                    b.HasOne("Models.Data.Albumes", "CodigoAlbumNavigation")
                        .WithMany("Canciones")
                        .HasForeignKey("CodigoAlbum")
                        .IsRequired()
                        .HasConstraintName("FK__Canciones__Codig__35BCFE0A");

                    b.HasOne("Models.Data.GenerosMusicales", "CodigoGeneroNavigation")
                        .WithMany("Canciones")
                        .HasForeignKey("CodigoGenero")
                        .IsRequired()
                        .HasConstraintName("FK__Canciones__Codig__34C8D9D1");

                    b.Navigation("CodigoAlbumNavigation");

                    b.Navigation("CodigoGeneroNavigation");
                });

            modelBuilder.Entity("Models.Data.CarritoCompras", b =>
                {
                    b.HasOne("Models.Data.Usuarios", "IdUsuarioNavigation")
                        .WithMany("CarritoCompras")
                        .HasForeignKey("IdUsuario")
                        .IsRequired()
                        .HasConstraintName("FK__CarritoCo__IdUsu__38996AB5");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("Models.Data.DetalleCarrito", b =>
                {
                    b.HasOne("Models.Data.Canciones", "CodigoCancionNavigation")
                        .WithMany("DetalleCarritos")
                        .HasForeignKey("CodigoCancion")
                        .IsRequired()
                        .HasConstraintName("FK__DetalleCa__Codig__4316F928");

                    b.HasOne("Models.Data.CarritoCompras", "IdCarritoNavigation")
                        .WithMany("DetalleCarritos")
                        .HasForeignKey("IdCarrito")
                        .IsRequired()
                        .HasConstraintName("FK__DetalleCa__IdCar__4222D4EF");

                    b.Navigation("CodigoCancionNavigation");

                    b.Navigation("IdCarritoNavigation");
                });

            modelBuilder.Entity("Models.Data.DetalleVentas", b =>
                {
                    b.HasOne("Models.Data.Canciones", "CodigoCancionNavigation")
                        .WithMany("DetalleVenta")
                        .HasForeignKey("CodigoCancion")
                        .IsRequired()
                        .HasConstraintName("FK__DetalleVe__Codig__46E78A0C");

                    b.HasOne("Models.Data.Ventas", "IdVentaNavigation")
                        .WithMany("DetalleVenta")
                        .HasForeignKey("IdVenta")
                        .IsRequired()
                        .HasConstraintName("FK__DetalleVe__IdVen__45F365D3");

                    b.Navigation("CodigoCancionNavigation");

                    b.Navigation("IdVentaNavigation");
                });

            modelBuilder.Entity("Models.Data.Usuarios", b =>
                {
                    b.HasOne("Models.Data.Perfiles", "IdPerfilNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdPerfil")
                        .IsRequired()
                        .HasConstraintName("FK__Usuarios__IdPerf__2B3F6F97");

                    b.Navigation("IdPerfilNavigation");
                });

            modelBuilder.Entity("Models.Data.Ventas", b =>
                {
                    b.HasOne("Models.Data.Usuarios", "IdUsuarioNavigation")
                        .WithMany("Venta")
                        .HasForeignKey("IdUsuario")
                        .IsRequired()
                        .HasConstraintName("FK__Ventas__IdUsuari__3D5E1FD2");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("Models.Data.Albumes", b =>
                {
                    b.Navigation("Canciones");
                });

            modelBuilder.Entity("Models.Data.Artistas", b =>
                {
                    b.Navigation("Albumes");
                });

            modelBuilder.Entity("Models.Data.AspNetRoles", b =>
                {
                    b.Navigation("AspNetRoleClaims");
                });

            modelBuilder.Entity("Models.Data.AspNetUsers", b =>
                {
                    b.Navigation("AspNetUserClaims");

                    b.Navigation("AspNetUserLogins");

                    b.Navigation("AspNetUserTokens");
                });

            modelBuilder.Entity("Models.Data.Canciones", b =>
                {
                    b.Navigation("DetalleCarritos");

                    b.Navigation("DetalleVenta");
                });

            modelBuilder.Entity("Models.Data.CarritoCompras", b =>
                {
                    b.Navigation("DetalleCarritos");
                });

            modelBuilder.Entity("Models.Data.GenerosMusicales", b =>
                {
                    b.Navigation("Canciones");
                });

            modelBuilder.Entity("Models.Data.Perfiles", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Models.Data.Usuarios", b =>
                {
                    b.Navigation("CarritoCompras");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Models.Data.Ventas", b =>
                {
                    b.Navigation("DetalleVenta");
                });
#pragma warning restore 612, 618
        }
    }
}
