using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class testjoblist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Jobs_JobId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Tasks",
                newName: "JobID");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_JobId",
                table: "Tasks",
                newName: "IX_Tasks_JobID");

            migrationBuilder.AlterColumn<int>(
                name: "JobID",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Jobs_JobID",
                table: "Tasks",
                column: "JobID",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Jobs_JobID",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "JobID",
                table: "Tasks",
                newName: "JobId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_JobID",
                table: "Tasks",
                newName: "IX_Tasks_JobId");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "Tasks",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Jobs_JobId",
                table: "Tasks",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");
        }
    }
}
