﻿// <auto-generated />
using System;
using MagicVilla_VillaApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla_VillaApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240409085327_“adding_records”")]
    partial class adding_records
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVilla_VillaApi.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("amenity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageurl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("occupancy")
                        .HasColumnType("bit");

                    b.Property<double>("rate")
                        .HasColumnType("float");

                    b.Property<int>("sqft")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 4, 9, 14, 53, 27, 638, DateTimeKind.Local).AddTicks(9970),
                            Details = "Villa1 Details",
                            Name = "Villa1",
                            UpdateDate = new DateTime(2024, 4, 9, 14, 53, 27, 639, DateTimeKind.Local).AddTicks(10),
                            amenity = "Villa1 Amenities",
                            imageurl = "",
                            occupancy = true,
                            rate = 100.0,
                            sqft = 1000
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 4, 9, 14, 53, 27, 639, DateTimeKind.Local).AddTicks(40),
                            Details = "Villa2 Details",
                            Name = "Villa2",
                            UpdateDate = new DateTime(2024, 4, 9, 14, 53, 27, 639, DateTimeKind.Local).AddTicks(40),
                            amenity = "Villa2 Amenities",
                            imageurl = "",
                            occupancy = true,
                            rate = 200.0,
                            sqft = 2000
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 4, 9, 14, 53, 27, 639, DateTimeKind.Local).AddTicks(50),
                            Details = "Villa3 Details",
                            Name = "Villa3",
                            UpdateDate = new DateTime(2024, 4, 9, 14, 53, 27, 639, DateTimeKind.Local).AddTicks(60),
                            amenity = "Villa3 Amenities",
                            imageurl = "",
                            occupancy = true,
                            rate = 300.0,
                            sqft = 3000
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
