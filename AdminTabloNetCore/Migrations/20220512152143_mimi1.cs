using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AdminTabloNetCore.Migrations
{
    public partial class mimi1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    idAnnouncement = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    dateAdded = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    dateClosed = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Priority = table.Column<string>(type: "text", nullable: true),
                    isActive = table.Column<bool>(type: "boolean", nullable: false),
                    status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.idAnnouncement);
                });

            migrationBuilder.CreateTable(
                name: "SupervisorShedules",
                columns: table => new
                {
                    idSupervisorShedule = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameSupervisor = table.Column<string>(type: "text", nullable: true),
                    position = table.Column<string>(type: "text", nullable: true),
                    SupervisorSheduleidSupervisorShedule = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupervisorShedules", x => x.idSupervisorShedule);
                    table.ForeignKey(
                        name: "FK_SupervisorShedules_SupervisorShedules_SupervisorSheduleidSu~",
                        column: x => x.SupervisorSheduleidSupervisorShedule,
                        principalTable: "SupervisorShedules",
                        principalColumn: "idSupervisorShedule",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeShedules",
                columns: table => new
                {
                    idTimeShedule = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Shedule = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeShedules", x => x.idTimeShedule);
                });

            migrationBuilder.CreateTable(
                name: "WeekNames",
                columns: table => new
                {
                    idWeekName = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Begin = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekNames", x => x.idWeekName);
                });

            migrationBuilder.CreateTable(
                name: "DatesSupervisiors",
                columns: table => new
                {
                    idDatesSupervisior = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    idSupervisorShedule = table.Column<int>(type: "integer", nullable: false),
                    d1 = table.Column<bool>(type: "boolean", nullable: false),
                    d2 = table.Column<bool>(type: "boolean", nullable: false),
                    d3 = table.Column<bool>(type: "boolean", nullable: false),
                    d4 = table.Column<bool>(type: "boolean", nullable: false),
                    d5 = table.Column<bool>(type: "boolean", nullable: false),
                    d6 = table.Column<bool>(type: "boolean", nullable: false),
                    d7 = table.Column<bool>(type: "boolean", nullable: false),
                    d8 = table.Column<bool>(type: "boolean", nullable: false),
                    d9 = table.Column<bool>(type: "boolean", nullable: false),
                    d10 = table.Column<bool>(type: "boolean", nullable: false),
                    d11 = table.Column<bool>(type: "boolean", nullable: false),
                    d12 = table.Column<bool>(type: "boolean", nullable: false),
                    d13 = table.Column<bool>(type: "boolean", nullable: false),
                    d14 = table.Column<bool>(type: "boolean", nullable: false),
                    d15 = table.Column<bool>(type: "boolean", nullable: false),
                    d16 = table.Column<bool>(type: "boolean", nullable: false),
                    d17 = table.Column<bool>(type: "boolean", nullable: false),
                    d18 = table.Column<bool>(type: "boolean", nullable: false),
                    d19 = table.Column<bool>(type: "boolean", nullable: false),
                    d20 = table.Column<bool>(type: "boolean", nullable: false),
                    d21 = table.Column<bool>(type: "boolean", nullable: false),
                    d22 = table.Column<bool>(type: "boolean", nullable: false),
                    d23 = table.Column<bool>(type: "boolean", nullable: false),
                    d24 = table.Column<bool>(type: "boolean", nullable: false),
                    d25 = table.Column<bool>(type: "boolean", nullable: false),
                    d26 = table.Column<bool>(type: "boolean", nullable: false),
                    d27 = table.Column<bool>(type: "boolean", nullable: false),
                    d28 = table.Column<bool>(type: "boolean", nullable: false),
                    d29 = table.Column<bool>(type: "boolean", nullable: false),
                    d30 = table.Column<bool>(type: "boolean", nullable: false),
                    d31 = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatesSupervisiors", x => x.idDatesSupervisior);
                    table.ForeignKey(
                        name: "FK_DatesSupervisiors_SupervisorShedules_idSupervisorShedule",
                        column: x => x.idSupervisorShedule,
                        principalTable: "SupervisorShedules",
                        principalColumn: "idSupervisorShedule",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatesSupervisiors_idSupervisorShedule",
                table: "DatesSupervisiors",
                column: "idSupervisorShedule");

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorShedules_SupervisorSheduleidSupervisorShedule",
                table: "SupervisorShedules",
                column: "SupervisorSheduleidSupervisorShedule");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "DatesSupervisiors");

            migrationBuilder.DropTable(
                name: "TimeShedules");

            migrationBuilder.DropTable(
                name: "WeekNames");

            migrationBuilder.DropTable(
                name: "SupervisorShedules");
        }
    }
}
