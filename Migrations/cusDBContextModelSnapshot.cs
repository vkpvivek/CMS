﻿// <auto-generated />
using System;
using CMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CMS.Migrations
{
    [DbContext(typeof(cusDBContext))]
    partial class cusDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CMS.Models.Customer", b =>
                {
                    b.Property<int>("cusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("LocationlocId")
                        .HasColumnType("int");

                    b.Property<string>("cusAdd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("cusAge")
                        .HasColumnType("int");

                    b.Property<string>("cusGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cusImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cusName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cusId");

                    b.HasIndex("LocationlocId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CMS.Models.Location", b =>
                {
                    b.Property<int>("locId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("locName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("locId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("CMS.Models.Customer", b =>
                {
                    b.HasOne("CMS.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationlocId");

                    b.Navigation("Location");
                });
#pragma warning restore 612, 618
        }
    }
}
