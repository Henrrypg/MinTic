﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehiculosTransporte.App.Persistencia;

namespace VehiculosTransporte.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("VehiculosTransporte.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero_Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("VehiculosTransporte.App.Dominio.Repuesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<int>("VerificacionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VerificacionId");

                    b.ToTable("Repuestos");
                });

            modelBuilder.Entity("VehiculosTransporte.App.Dominio.Vehiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expiracion_extra_contractual")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Expiracion_seguro_contractual")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Expiracion_soat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Expiracion_tenicomecanica")
                        .HasColumnType("datetime2");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehiculos");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Vehiculo");
                });

            modelBuilder.Entity("VehiculosTransporte.App.Dominio.Verificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MecanicoId")
                        .HasColumnType("int");

                    b.Property<string>("Nivel_Aceite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nivel_Liquido_direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nivel_Liquido_frenos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nivel_Refrigerante")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MecanicoId");

                    b.HasIndex("VehiculoId");

                    b.ToTable("Verificaciones");
                });

            modelBuilder.Entity("VehiculosTransporte.App.Dominio.Auxiliar", b =>
                {
                    b.HasBaseType("VehiculosTransporte.App.Dominio.Persona");

                    b.HasDiscriminator().HasValue("Auxiliar");
                });

            modelBuilder.Entity("VehiculosTransporte.App.Dominio.JefeOperaciones", b =>
                {
                    b.HasBaseType("VehiculosTransporte.App.Dominio.Persona");

                    b.HasDiscriminator().HasValue("JefeOperaciones");
                });

            modelBuilder.Entity("VehiculosTransporte.App.Dominio.Mecanico", b =>
                {
                    b.HasBaseType("VehiculosTransporte.App.Dominio.Persona");

                    b.HasDiscriminator().HasValue("Mecanico");
                });

            modelBuilder.Entity("VehiculosTransporte.App.Dominio.Propietario", b =>
                {
                    b.HasBaseType("VehiculosTransporte.App.Dominio.Persona");

                    b.Property<int>("VehiculoId")
                        .HasColumnType("int");

                    b.HasIndex("VehiculoId");

                    b.HasDiscriminator().HasValue("Propietario");
                });

            modelBuilder.Entity("VehiculosTransporte.App.Dominio.Bus", b =>
                {
                    b.HasBaseType("VehiculosTransporte.App.Dominio.Vehiculo");

                    b.HasDiscriminator().HasValue("Bus");
                });

            modelBuilder.Entity("VehiculosTransporte.App.Dominio.Microbus", b =>
                {
                    b.HasBaseType("VehiculosTransporte.App.Dominio.Vehiculo");

                    b.HasDiscriminator().HasValue("Microbus");
                });

            modelBuilder.Entity("VehiculosTransporte.App.Dominio.Repuesto", b =>
                {
                    b.HasOne("VehiculosTransporte.App.Dominio.Verificacion", "Verificacion")
                        .WithMany()
                        .HasForeignKey("VerificacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Verificacion");
                });

            modelBuilder.Entity("VehiculosTransporte.App.Dominio.Verificacion", b =>
                {
                    b.HasOne("VehiculosTransporte.App.Dominio.Mecanico", "Mecanico")
                        .WithMany()
                        .HasForeignKey("MecanicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VehiculosTransporte.App.Dominio.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mecanico");

                    b.Navigation("Vehiculo");
                });

            modelBuilder.Entity("VehiculosTransporte.App.Dominio.Propietario", b =>
                {
                    b.HasOne("VehiculosTransporte.App.Dominio.Vehiculo", "Vehiculo")
                        .WithMany()
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehiculo");
                });
#pragma warning restore 612, 618
        }
    }
}
