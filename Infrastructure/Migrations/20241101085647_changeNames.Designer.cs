﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241101085647_changeNames")]
    partial class changeNames
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Beds")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdatedBy")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "1234, 5th Avenue, New York",
                            Beds = 2,
                            Description = "Standard Room Description",
                            ImageUrl = "https://acihome.vn/uploads/15/tieu-chuan-biet-thu-5-sao-co-canh-quan-dep-gan-gui-voi-thien-nhien.jpg",
                            Name = "Standard Room",
                            Occupancy = 2,
                            Price = 90.0,
                            Size = 200.0,
                            UpdatedBy = new DateTime(2024, 11, 1, 19, 26, 47, 260, DateTimeKind.Local).AddTicks(4982)
                        },
                        new
                        {
                            Id = 2,
                            Address = "1234, 5th Avenue, New York",
                            Beds = 2,
                            Description = "Standard Room Description",
                            ImageUrl = "https://acihome.vn/uploads/15/tieu-chuan-biet-thu-5-sao-co-canh-quan-dep-gan-gui-voi-thien-nhien.jpg",
                            Name = "Standard Room",
                            Occupancy = 2,
                            Price = 90.0,
                            Size = 200.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}