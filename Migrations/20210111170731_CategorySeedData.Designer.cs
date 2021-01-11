﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using onlineshop.Data;

namespace onlineshop.Migrations
{
    [DbContext(typeof(TimepieceContext))]
    [Migration("20210111170731_CategorySeedData")]
    partial class CategorySeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("onlineshop.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Used to compute a speed based on time.",
                            Name = "Tachymeter"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A stopwatch combined with a display watch.",
                            Name = "Chronograph"
                        },
                        new
                        {
                            Id = 3,
                            Description = "A small second hand",
                            Name = "Small Seconds"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Manual winding of the timepiece",
                            Name = "Manual Winding"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Automatic winding of the timepiece",
                            Name = "Automatic Winding"
                        });
                });

            modelBuilder.Entity("onlineshop.Models.CategoryToProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoriesToProducts");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 1,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 1,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 1,
                            CategoryId = 4
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 3
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 5
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 5
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 2
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 5
                        });
                });

            modelBuilder.Entity("onlineshop.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Dark Side of the Moon",
                            ItemId = 1,
                            Name = "Omega Speedmaster"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Carrera Calibre 16",
                            ItemId = 2,
                            Name = "TAG Heuer"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Unico Titanium 42mm",
                            ItemId = 3,
                            Name = "Hublot Big Bang"
                        },
                        new
                        {
                            Id = 4,
                            Description = "BR V2-94 Garde-Cotes",
                            ItemId = 4,
                            Name = "Bell & Ross"
                        });
                });

            modelBuilder.Entity("onlineshop.Models.CategoryToProduct", b =>
                {
                    b.HasOne("onlineshop.Models.Category", "Category")
                        .WithMany("CategoriesToProducts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("onlineshop.Models.Product", "Product")
                        .WithMany("CategoriesToProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("onlineshop.Models.Product", b =>
                {
                    b.OwnsOne("onlineshop.Models.Item", "Item", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<decimal>("Price")
                                .HasColumnType("Money");

                            b1.Property<int>("QuantityInStock")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.ToTable("Products");

                            b1.WithOwner("Product")
                                .HasForeignKey("Id");

                            b1.HasData(
                                new
                                {
                                    Id = 1,
                                    Price = 8895.0m,
                                    QuantityInStock = 5
                                },
                                new
                                {
                                    Id = 2,
                                    Price = 3360.0m,
                                    QuantityInStock = 8
                                },
                                new
                                {
                                    Id = 3,
                                    Price = 17800.0m,
                                    QuantityInStock = 1
                                },
                                new
                                {
                                    Id = 4,
                                    Price = 4300.0m,
                                    QuantityInStock = 3
                                });
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
