using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class _007 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Logs_ForkliftId",
                table: "Logs");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ForkliftId",
                table: "Logs",
                column: "ForkliftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Logs_ForkliftId",
                table: "Logs");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ForkliftId",
                table: "Logs",
                column: "ForkliftId",
                unique: true);
        }
    }
}
