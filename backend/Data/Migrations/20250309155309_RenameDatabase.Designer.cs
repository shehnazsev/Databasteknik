﻿// <auto-generated />
using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250309155309_RenameDatabase")]
    partial class RenameDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Models.Kund", b =>
                {
                    b.Property<int>("Kundnummer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Kundnummer"));

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefonnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Kundnummer");

                    b.ToTable("Kunder");
                });

            modelBuilder.Entity("Data.Models.Projekt", b =>
                {
                    b.Property<int>("Projektnummer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Projektnummer"));

                    b.Property<int>("Kundnummer")
                        .HasColumnType("int");

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Projektansvarig")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Slutdatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Startdatum")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TjanstId")
                        .HasColumnType("int");

                    b.Property<decimal>("Totalpris")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Projektnummer");

                    b.HasIndex("Kundnummer");

                    b.HasIndex("TjanstId");

                    b.ToTable("Projekt");
                });

            modelBuilder.Entity("Data.Models.Tjanst", b =>
                {
                    b.Property<int>("TjanstId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TjanstId"));

                    b.Property<string>("Namn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrisPerTimme")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("TjanstId");

                    b.ToTable("Tjanster");
                });

            modelBuilder.Entity("Data.Models.Projekt", b =>
                {
                    b.HasOne("Data.Models.Kund", "Kund")
                        .WithMany("Projekt")
                        .HasForeignKey("Kundnummer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.Tjanst", "Tjanst")
                        .WithMany("Projekt")
                        .HasForeignKey("TjanstId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kund");

                    b.Navigation("Tjanst");
                });

            modelBuilder.Entity("Data.Models.Kund", b =>
                {
                    b.Navigation("Projekt");
                });

            modelBuilder.Entity("Data.Models.Tjanst", b =>
                {
                    b.Navigation("Projekt");
                });
#pragma warning restore 612, 618
        }
    }
}
