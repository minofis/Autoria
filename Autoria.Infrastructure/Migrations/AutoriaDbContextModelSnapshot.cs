﻿// <auto-generated />
using System;
using Autoria.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Autoria.Infrastructure.Migrations
{
    [DbContext(typeof(AutoriaDbContext))]
    partial class AutoriaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Autoria.Core.Entities.Buyer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FavoritesListId")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("Autoria.Core.Entities.FavoritesList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BuyerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BuyerId")
                        .IsUnique();

                    b.ToTable("FavoritesLists");
                });

            modelBuilder.Entity("Autoria.Core.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<int>("EngineCapacity")
                        .HasColumnType("integer");

                    b.Property<string>("EngineType")
                        .HasColumnType("text");

                    b.Property<int?>("FavoritesListId")
                        .HasColumnType("integer");

                    b.Property<int?>("LoadCapacity")
                        .HasColumnType("integer");

                    b.Property<int?>("Mileage")
                        .HasColumnType("integer");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FavoritesListId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Autoria.Core.Entities.FavoritesList", b =>
                {
                    b.HasOne("Autoria.Core.Entities.Buyer", "Buyer")
                        .WithOne("FavoritesList")
                        .HasForeignKey("Autoria.Core.Entities.FavoritesList", "BuyerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Buyer");
                });

            modelBuilder.Entity("Autoria.Core.Entities.Vehicle", b =>
                {
                    b.HasOne("Autoria.Core.Entities.FavoritesList", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("FavoritesListId");
                });

            modelBuilder.Entity("Autoria.Core.Entities.Buyer", b =>
                {
                    b.Navigation("FavoritesList")
                        .IsRequired();
                });

            modelBuilder.Entity("Autoria.Core.Entities.FavoritesList", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}