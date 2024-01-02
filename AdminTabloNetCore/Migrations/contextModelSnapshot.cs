﻿// <auto-generated />
using System;
using AdminTabloNetCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AdminTabloNetCore.Migrations
{
    [DbContext(typeof(context))]
    partial class contextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AdminTabloNetCore.Models.Announcement", b =>
                {
                    b.Property<int>("idAnnouncement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Header")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Priority")
                        .HasColumnType("text");

                    b.Property<DateTime>("dateAdded")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("dateClosed")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("isActive")
                        .HasColumnType("boolean");

                    b.Property<string>("status")
                        .HasColumnType("text");

                    b.HasKey("idAnnouncement");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("AdminTabloNetCore.Models.DatesSupervisior", b =>
                {
                    b.Property<int>("idDatesSupervisior")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("d1")
                        .HasColumnType("boolean");

                    b.Property<bool>("d10")
                        .HasColumnType("boolean");

                    b.Property<bool>("d11")
                        .HasColumnType("boolean");

                    b.Property<bool>("d12")
                        .HasColumnType("boolean");

                    b.Property<bool>("d13")
                        .HasColumnType("boolean");

                    b.Property<bool>("d14")
                        .HasColumnType("boolean");

                    b.Property<bool>("d15")
                        .HasColumnType("boolean");

                    b.Property<bool>("d16")
                        .HasColumnType("boolean");

                    b.Property<bool>("d17")
                        .HasColumnType("boolean");

                    b.Property<bool>("d18")
                        .HasColumnType("boolean");

                    b.Property<bool>("d19")
                        .HasColumnType("boolean");

                    b.Property<bool>("d2")
                        .HasColumnType("boolean");

                    b.Property<bool>("d20")
                        .HasColumnType("boolean");

                    b.Property<bool>("d21")
                        .HasColumnType("boolean");

                    b.Property<bool>("d22")
                        .HasColumnType("boolean");

                    b.Property<bool>("d23")
                        .HasColumnType("boolean");

                    b.Property<bool>("d24")
                        .HasColumnType("boolean");

                    b.Property<bool>("d25")
                        .HasColumnType("boolean");

                    b.Property<bool>("d26")
                        .HasColumnType("boolean");

                    b.Property<bool>("d27")
                        .HasColumnType("boolean");

                    b.Property<bool>("d28")
                        .HasColumnType("boolean");

                    b.Property<bool>("d29")
                        .HasColumnType("boolean");

                    b.Property<bool>("d3")
                        .HasColumnType("boolean");

                    b.Property<bool>("d30")
                        .HasColumnType("boolean");

                    b.Property<bool>("d31")
                        .HasColumnType("boolean");

                    b.Property<bool>("d4")
                        .HasColumnType("boolean");

                    b.Property<bool>("d5")
                        .HasColumnType("boolean");

                    b.Property<bool>("d6")
                        .HasColumnType("boolean");

                    b.Property<bool>("d7")
                        .HasColumnType("boolean");

                    b.Property<bool>("d8")
                        .HasColumnType("boolean");

                    b.Property<bool>("d9")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("idSupervisorShedule")
                        .HasColumnType("integer");

                    b.HasKey("idDatesSupervisior");

                    b.HasIndex("idSupervisorShedule");

                    b.ToTable("DatesSupervisiors");
                });

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

            modelBuilder.Entity("AdminTabloNetCore.Models.MonthYear", b =>
                {
                    b.Property<int>("idMonthYear")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("idMonthYear");

                    b.ToTable("MonthYear");
                });

            modelBuilder.Entity("AdminTabloNetCore.Models.SupervisorShedule", b =>
                {
                    b.Property<int>("idSupervisorShedule")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("NameSupervisor")
                        .HasColumnType("text");

                    b.Property<string>("position")
                        .HasColumnType("text");

                    b.HasKey("idSupervisorShedule");

                    b.ToTable("SupervisorShedules");
                });

            modelBuilder.Entity("AdminTabloNetCore.Models.TimeShedule", b =>
                {
                    b.Property<int>("idTimeShedule")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Shedule")
                        .HasColumnType("text");

                    b.HasKey("idTimeShedule");

                    b.ToTable("TimeShedules");
                });

            modelBuilder.Entity("AdminTabloNetCore.Models.WeekName", b =>
                {
                    b.Property<int>("idWeekName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Begin")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("idWeekName");

                    b.ToTable("WeekNames");
                });

            modelBuilder.Entity("MonthYearSupervisorShedule", b =>
                {
                    b.Property<int>("MonthYearsidMonthYear")
                        .HasColumnType("integer");

                    b.Property<int>("SupervisorShedulesidSupervisorShedule")
                        .HasColumnType("integer");

                    b.HasKey("MonthYearsidMonthYear", "SupervisorShedulesidSupervisorShedule");

                    b.HasIndex("SupervisorShedulesidSupervisorShedule");

                    b.ToTable("MonthYearSupervisorShedule");
                });

            modelBuilder.Entity("AdminTabloNetCore.Models.DatesSupervisior", b =>
                {
                    b.HasOne("AdminTabloNetCore.Models.SupervisorShedule", "SupervisorShedule")
                        .WithMany("DatesSupervisiors")
                        .HasForeignKey("idSupervisorShedule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SupervisorShedule");
                });

            modelBuilder.Entity("MonthYearSupervisorShedule", b =>
                {
                    b.HasOne("AdminTabloNetCore.Models.MonthYear", null)
                        .WithMany()
                        .HasForeignKey("MonthYearsidMonthYear")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdminTabloNetCore.Models.SupervisorShedule", null)
                        .WithMany()
                        .HasForeignKey("SupervisorShedulesidSupervisorShedule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdminTabloNetCore.Models.SupervisorShedule", b =>
                {
                    b.Navigation("DatesSupervisiors");
                });
#pragma warning restore 612, 618
        }
    }
}
