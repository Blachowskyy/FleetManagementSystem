using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class _2104322 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Forklifts_ForkliftId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_ForkliftId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ForkliftId",
                table: "Jobs");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Locations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddColumn<bool>(
                name: "InQueue",
                table: "Jobs",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Jobs",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCurrentlyRunning",
                table: "Jobs",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CurrentJobId",
                table: "Forklifts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    MessageLevel = table.Column<string>(type: "TEXT", nullable: false),
                    MessageDate = table.Column<string>(type: "TEXT", nullable: false),
                    ForkliftId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Forklifts_ForkliftId",
                        column: x => x.ForkliftId,
                        principalTable: "Forklifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forklifts_CurrentJobId",
                table: "Forklifts",
                column: "CurrentJobId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ForkliftId",
                table: "Logs",
                column: "ForkliftId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Forklifts_Jobs_CurrentJobId",
                table: "Forklifts",
                column: "CurrentJobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forklifts_Jobs_CurrentJobId",
                table: "Forklifts");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Forklifts_CurrentJobId",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "InQueue",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "IsCurrentlyRunning",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CurrentJobId",
                table: "Forklifts");

            migrationBuilder.AddColumn<int>(
                name: "ForkliftId",
                table: "Jobs",
                type: "INTEGER",
                nullable: true);

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
    }
}
