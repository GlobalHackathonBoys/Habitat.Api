﻿// <auto-generated />
using System;
using Habitat.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Habitat.DataAccess.Migrations
{
    [DbContext(typeof(HabitatContext))]
    [Migration("20200406220906_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Habitat.DataAccess.Models.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EventDateTime")
                        .HasColumnName("event_date_time")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("NoteText")
                        .HasColumnName("note_text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("note");
                });
#pragma warning restore 612, 618
        }
    }
}
