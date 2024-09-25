﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Models;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240802112745_addEmailP")]
    partial class addEmailP
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPI.Model.Address", b =>
                {
                    b.Property<int>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressID"));

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("City");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Country");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Phone");

                    b.Property<string>("street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Street");

                    b.HasKey("AddressID");

                    b.HasIndex("PersonID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("WebAPI.Model.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LName");

                    b.HasKey("PersonID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("WebAPI.Model.Address", b =>
                {
                    b.HasOne("WebAPI.Model.Person", "OfPerson")
                        .WithMany("Addresses")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OfPerson");
                });

            modelBuilder.Entity("WebAPI.Model.Person", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
