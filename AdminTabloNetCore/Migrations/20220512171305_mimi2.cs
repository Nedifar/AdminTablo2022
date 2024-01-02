using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminTabloNetCore.Migrations
{
    public partial class mimi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupervisorShedules_SupervisorShedules_SupervisorSheduleidSu~",
                table: "SupervisorShedules");

            migrationBuilder.DropIndex(
                name: "IX_SupervisorShedules_SupervisorSheduleidSupervisorShedule",
                table: "SupervisorShedules");

            migrationBuilder.DropColumn(
                name: "SupervisorSheduleidSupervisorShedule",
                table: "SupervisorShedules");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupervisorSheduleidSupervisorShedule",
                table: "SupervisorShedules",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupervisorShedules_SupervisorSheduleidSupervisorShedule",
                table: "SupervisorShedules",
                column: "SupervisorSheduleidSupervisorShedule");

            migrationBuilder.AddForeignKey(
                name: "FK_SupervisorShedules_SupervisorShedules_SupervisorSheduleidSu~",
                table: "SupervisorShedules",
                column: "SupervisorSheduleidSupervisorShedule",
                principalTable: "SupervisorShedules",
                principalColumn: "idSupervisorShedule",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
