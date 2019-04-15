﻿// <auto-generated />
using System;
using BookStore.Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStore.Api.Migrations
{
    [DbContext(typeof(BookDbContext))]
    [Migration("20190121125419_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookStore.Entity.Models.Book", b =>
                {
                    b.Property<Guid>("BOOK_ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NAME")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("SUMMARY")
                        .IsRequired();

                    b.HasKey("BOOK_ID");

                    b.ToTable("Books");
                });
#pragma warning restore 612, 618
        }
    }
}