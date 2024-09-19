﻿// <auto-generated />
using System;
using API_Camiones.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Camiones.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_Camiones.Modelos.Amortizacion", b =>
                {
                    b.Property<int>("IdAmortizacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAmortizacion"));

                    b.Property<string>("Objetivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Periodo")
                        .HasColumnType("int");

                    b.Property<int>("Plazo")
                        .HasColumnType("int");

                    b.Property<float>("Porcentaje")
                        .HasColumnType("real");

                    b.Property<float>("Recaudado")
                        .HasColumnType("real");

                    b.HasKey("IdAmortizacion");

                    b.ToTable("Amortizacion");
                });

            modelBuilder.Entity("API_Camiones.Modelos.Carga", b =>
                {
                    b.Property<int>("IdCarga")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCarga"));

                    b.Property<double>("Bonif")
                        .HasColumnType("float");

                    b.Property<bool?>("Borrado")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.Property<int>("Codigo")
                        .HasColumnType("int");

                    b.Property<int>("IdViaje")
                        .HasColumnType("int");

                    b.Property<double>("Iva")
                        .HasColumnType("float");

                    b.Property<double>("PrecioUnit")
                        .HasColumnType("float");

                    b.Property<string>("Producto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Subtotal")
                        .HasColumnType("float");

                    b.Property<string>("UnidadDeMedida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCarga");

                    b.ToTable("Cargas");
                });

            modelBuilder.Entity("API_Camiones.Modelos.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<bool?>("Borrado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("API_Camiones.Modelos.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<bool?>("Borrado")
                        .HasColumnType("bit");

                    b.Property<string>("Condicion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuitCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RazonSoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("API_Camiones.Modelos.Factura", b =>
                {
                    b.Property<int>("IdFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFactura"));

                    b.Property<bool?>("Borrado")
                        .HasColumnType("bit");

                    b.Property<string>("Cargas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cuit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CuitCliente")
                        .HasColumnType("int");

                    b.Property<int>("CuitUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdFactura");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("API_Camiones.Modelos.Gasto", b =>
                {
                    b.Property<int>("IdGasto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGasto"));

                    b.Property<bool?>("Borrado")
                        .HasColumnType("bit");

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.Property<int?>("Categoria")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Viaje")
                        .HasColumnType("int");

                    b.HasKey("IdGasto");

                    b.ToTable("Gastos");
                });

            modelBuilder.Entity("API_Camiones.Modelos.Unidad", b =>
                {
                    b.Property<int>("IdUnidad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUnidad"));

                    b.Property<DateTime>("Aceite")
                        .HasColumnType("datetime2");

                    b.Property<int>("Amortizacion")
                        .HasColumnType("int");

                    b.Property<string>("EstadoRueda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<float>("KmAceite")
                        .HasColumnType("real");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ruedas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Valoracion")
                        .HasColumnType("real");

                    b.HasKey("IdUnidad");

                    b.ToTable("Unidades");
                });

            modelBuilder.Entity("API_Camiones.Modelos.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<bool?>("Borrado")
                        .HasColumnType("bit");

                    b.Property<string>("Condicion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cuit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facturas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Razon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("API_Camiones.Modelos.Viaje", b =>
                {
                    b.Property<int>("IdViaje")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdViaje"));

                    b.Property<bool?>("Borrado")
                        .HasColumnType("bit");

                    b.Property<string>("Cp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CuitUsuario")
                        .HasColumnType("int");

                    b.Property<float>("Distancia")
                        .HasColumnType("real");

                    b.Property<bool>("Facturado")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("date");

                    b.Property<string>("Final")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gastos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Inicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TotalFacturado")
                        .HasColumnType("real");

                    b.HasKey("IdViaje");

                    b.ToTable("Viajes");
                });
#pragma warning restore 612, 618
        }
    }
}
