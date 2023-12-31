﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tournament.Data.Data;

#nullable disable

namespace Tournament.Data.Migrations
{
    [DbContext(typeof(TournamentApiContext))]
    [Migration("20231129133741_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tournament.Core.Entities.Gamemodel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.Property<int?>("TournamnetmainmodelID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TournamnetmainmodelID");

                    b.ToTable("Gamemodel");
                });

            modelBuilder.Entity("Tournament.Core.Entities.Tournamnetmainmodel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Tournamnetmainmodel");
                });

            modelBuilder.Entity("Tournament.Core.Entities.Gamemodel", b =>
                {
                    b.HasOne("Tournament.Core.Entities.Tournamnetmainmodel", null)
                        .WithMany("Gamedetails")
                        .HasForeignKey("TournamnetmainmodelID");
                });

            modelBuilder.Entity("Tournament.Core.Entities.Tournamnetmainmodel", b =>
                {
                    b.Navigation("Gamedetails");
                });
#pragma warning restore 612, 618
        }
    }
}
