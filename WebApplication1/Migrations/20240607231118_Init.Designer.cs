﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240607231118_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("IdClient");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            IdClient = 1,
                            Email = "dfjfnennt@o2.com",
                            FirstName = "John",
                            Lastname = "Doe",
                            Pesel = "12345678901",
                            Telephone = "43254376588"
                        },
                        new
                        {
                            IdClient = 2,
                            Email = "dkfjk@gmail.com",
                            FirstName = "Jane",
                            Lastname = "Damian",
                            Pesel = "12345678902",
                            Telephone = "4321454356453"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Client_Trip", b =>
                {
                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<int>("IdTrip")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RegisteredAt")
                        .HasColumnType("int");

                    b.HasKey("IdClient", "IdTrip");

                    b.ToTable("Client_Trips");

                    b.HasData(
                        new
                        {
                            IdClient = 1,
                            IdTrip = 1,
                            PaymentDate = new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegisteredAt = 1630454400
                        },
                        new
                        {
                            IdClient = 2,
                            IdTrip = 2,
                            PaymentDate = new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegisteredAt = 1630454400
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Country", b =>
                {
                    b.Property<int>("IdCountry")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCountry"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("IdCountry");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            IdCountry = 1,
                            Name = "France"
                        },
                        new
                        {
                            IdCountry = 2,
                            Name = "United Kingdom"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Country_Trip", b =>
                {
                    b.Property<int>("IdCountry")
                        .HasColumnType("int");

                    b.Property<int>("IdTrip")
                        .HasColumnType("int");

                    b.HasKey("IdCountry", "IdTrip");

                    b.ToTable("Country_Trips");

                    b.HasData(
                        new
                        {
                            IdCountry = 1,
                            IdTrip = 1
                        },
                        new
                        {
                            IdCountry = 2,
                            IdTrip = 2
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Trip", b =>
                {
                    b.Property<int>("IdTrip")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTrip"));

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(220)
                        .HasColumnType("nvarchar(220)");

                    b.Property<int>("MaxPeople")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.HasKey("IdTrip");

                    b.ToTable("Trips");

                    b.HasData(
                        new
                        {
                            IdTrip = 1,
                            DateFrom = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "bla bla",
                            MaxPeople = 20,
                            Name = "Trip to Paris"
                        },
                        new
                        {
                            IdTrip = 2,
                            DateFrom = new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2022, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "bla bla bla",
                            MaxPeople = 10,
                            Name = "Trip to London"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}