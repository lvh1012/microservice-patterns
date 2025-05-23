﻿// <auto-generated />
using System;
using CQRS.Library.BorrowingService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CQRS.Library.BorrowingApi.Migrations
{
    [DbContext(typeof(BorrowingDbContext))]
    [Migration("20250302172957_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CQRS.Library.BorrowingApi.Infrastructure.Entity.Borrowing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("BorrowedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("BorrowerId")
                        .HasColumnType("uuid");

                    b.Property<bool>("HasReturned")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ReturnedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Borrowings");
                });
#pragma warning restore 612, 618
        }
    }
}
