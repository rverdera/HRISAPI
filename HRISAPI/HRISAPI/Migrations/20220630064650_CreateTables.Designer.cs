﻿// <auto-generated />
using System;
using HRISAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HRISAPI.Migrations
{
    [DbContext(typeof(HRISDbContext))]
    [Migration("20220630064650_CreateTables")]
    partial class CreateTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HRISAPI.Models.FM.BloodTypeModel", b =>
                {
                    b.Property<int>("BloodTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BloodTypeID"), 1L, 1);

                    b.Property<DateTime>("DateStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDel")
                        .HasColumnType("bit");

                    b.Property<string>("UserStamp")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("BloodTypeID");

                    b.ToTable("BloodType", "FM");
                });

            modelBuilder.Entity("HRISAPI.Models.FM.CivilStatusModel", b =>
                {
                    b.Property<int>("CivilStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CivilStatusID"), 1L, 1);

                    b.Property<DateTime>("DateStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDel")
                        .HasColumnType("bit");

                    b.Property<string>("UserStamp")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CivilStatusID");

                    b.ToTable("CivilStatus", "FM");
                });

            modelBuilder.Entity("HRISAPI.Models.PersonModel", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonID"), 1L, 1);

                    b.Property<int>("BloodTypeModelBloodTypeID")
                        .HasColumnType("int");

                    b.Property<int>("CivilStatusModelCivilStatusID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateStamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExtensionName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsDel")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("UserStamp")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("PersonID");

                    b.HasIndex("BloodTypeModelBloodTypeID");

                    b.HasIndex("CivilStatusModelCivilStatusID");

                    b.ToTable("Person", "PDS");
                });

            modelBuilder.Entity("HRISAPI.Models.PersonModel", b =>
                {
                    b.HasOne("HRISAPI.Models.FM.BloodTypeModel", "BloodTypeModel")
                        .WithMany()
                        .HasForeignKey("BloodTypeModelBloodTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRISAPI.Models.FM.CivilStatusModel", "CivilStatusModel")
                        .WithMany()
                        .HasForeignKey("CivilStatusModelCivilStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BloodTypeModel");

                    b.Navigation("CivilStatusModel");
                });
#pragma warning restore 612, 618
        }
    }
}
