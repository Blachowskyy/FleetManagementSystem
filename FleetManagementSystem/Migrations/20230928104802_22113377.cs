using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class _22113377 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forklifts_Jobs_CurrentJobId",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "Locations");

            migrationBuilder.AddColumn<bool>(
                name: "LoadLastTaskAtStartup",
                table: "Forklifts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Forklifts_Tasks_CurrentJobId",
                table: "Forklifts",
                column: "CurrentJobId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forklifts_Tasks_CurrentJobId",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "LoadLastTaskAtStartup",
                table: "Forklifts");

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Locations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "Locations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Forklifts_Jobs_CurrentJobId",
                table: "Forklifts",
                column: "CurrentJobId",
                principalTable: "Jobs",
                principalColumn: "Id");
        }
    }
}
