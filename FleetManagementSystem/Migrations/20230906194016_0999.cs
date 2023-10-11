using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class _0999 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImportanceLevel",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsConnected",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "NfcCardReader",
                table: "Forklifts");

            migrationBuilder.AddColumn<int>(
                name: "ForkliftId",
                table: "Jobs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Jobs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ForkliftId",
                table: "Jobs",
                column: "ForkliftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Forklifts_ForkliftId",
                table: "Jobs",
                column: "ForkliftId",
                principalTable: "Forklifts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Forklifts_ForkliftId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_ForkliftId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ForkliftId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "ImportanceLevel",
                table: "Tasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsConnected",
                table: "Forklifts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NfcCardReader",
                table: "Forklifts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
