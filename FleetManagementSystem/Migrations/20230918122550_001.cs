using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class _001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forklifts_Jobs_CurrentJobId",
                table: "Forklifts");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentJobId",
                table: "Forklifts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Forklifts_Jobs_CurrentJobId",
                table: "Forklifts",
                column: "CurrentJobId",
                principalTable: "Jobs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forklifts_Jobs_CurrentJobId",
                table: "Forklifts");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentJobId",
                table: "Forklifts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Forklifts_Jobs_CurrentJobId",
                table: "Forklifts",
                column: "CurrentJobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
