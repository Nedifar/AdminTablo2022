﻿// <auto-generated />
using System;
using AdminTabloNetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AdminTabloNetCore.Migrations
{
    [DbContext(typeof(context))]
    [Migration("20221012093048_DayPartAddMigration")]
    partial class DayPartAddMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            

            
            modelBuilder.Entity("AdminTabloNetCore.Models.DayPartHeader", b =>
                {
                    b.Property<int>("DayPartHeaderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Header")
                        .HasColumnType("text");

                    b.Property<DateTime>("beginTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("endTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("DayPartHeaderId");

                    b.ToTable("DayPartHeaders");
                });

         

            

           
           

           
#pragma warning restore 612, 618
        }
    }
}
