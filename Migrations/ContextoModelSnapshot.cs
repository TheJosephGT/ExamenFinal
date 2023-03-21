﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Parcial2_Joseph.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("Paquete", b =>
                {
                    b.Property<int>("PaqueteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreCliente")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PaqueteId");

                    b.ToTable("Paquete");
                });

            modelBuilder.Entity("Productos", b =>
                {
                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Existencia")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaqueteId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Costo = 300.0,
                            Descripcion = "Maní",
                            Existencia = 3,
                            PaqueteId = 0,
                            Precio = 10.0
                        },
                        new
                        {
                            ProductoId = 2,
                            Costo = 300.0,
                            Descripcion = "Pistachos",
                            Existencia = 5,
                            PaqueteId = 0,
                            Precio = 28.0
                        },
                        new
                        {
                            ProductoId = 3,
                            Costo = 250.0,
                            Descripcion = "Ciruelas",
                            Existencia = 3,
                            PaqueteId = 0,
                            Precio = 50.0
                        },
                        new
                        {
                            ProductoId = 4,
                            Costo = 350.0,
                            Descripcion = "Pasas",
                            Existencia = 25,
                            PaqueteId = 0,
                            Precio = 100.0
                        },
                        new
                        {
                            ProductoId = 5,
                            Costo = 250.0,
                            Descripcion = "Arándanos",
                            Existencia = 15,
                            PaqueteId = 0,
                            Precio = 10.0
                        });
                });

            modelBuilder.Entity("Productos", b =>
                {
                    b.HasOne("Paquete", null)
                        .WithMany("Productos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Paquete", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
