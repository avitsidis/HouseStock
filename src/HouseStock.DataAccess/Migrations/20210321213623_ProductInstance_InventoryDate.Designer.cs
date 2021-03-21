﻿// <auto-generated />
using System;
using HouseStock.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HouseStock.DataAccess.Migrations
{
    [DbContext(typeof(HouseStockDbContext))]
    [Migration("20210321213623_ProductInstance_InventoryDate")]
    partial class ProductInstance_InventoryDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HouseStock.Domain.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 2L,
                            Name = "Drinks"
                        },
                        new
                        {
                            Id = 1L,
                            Name = "Food"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Hygiene"
                        },
                        new
                        {
                            Id = 99L,
                            Name = "Other"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Pharmacy"
                        });
                });

            modelBuilder.Entity("HouseStock.Domain.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("HouseStock.Domain.ProductInstance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("AmountUnit")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("InventoryDate")
                        .HasColumnType("datetime");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ShelfId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShelfId");

                    b.ToTable("ProductInstances");
                });

            modelBuilder.Entity("HouseStock.Domain.Room", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HouseStock.Domain.Shelf", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<long?>("RoomId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("RoomId");

                    b.ToTable("Shelves");
                });

            modelBuilder.Entity("HouseStock.Domain.Product", b =>
                {
                    b.HasOne("HouseStock.Domain.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("HouseStock.Domain.ProductInstance", b =>
                {
                    b.HasOne("HouseStock.Domain.Product", "Product")
                        .WithMany("Instances")
                        .HasForeignKey("ProductId");

                    b.HasOne("HouseStock.Domain.Shelf", "Shelf")
                        .WithMany("ProductInstances")
                        .HasForeignKey("ShelfId");
                });

            modelBuilder.Entity("HouseStock.Domain.Shelf", b =>
                {
                    b.HasOne("HouseStock.Domain.Room", "Room")
                        .WithMany("Shelves")
                        .HasForeignKey("RoomId");
                });
#pragma warning restore 612, 618
        }
    }
}
