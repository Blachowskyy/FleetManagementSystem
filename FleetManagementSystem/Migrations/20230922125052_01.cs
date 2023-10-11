using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class _01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowInitializeWithBackwardMotion",
                table: "Forklifts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowOscillationRecovery",
                table: "Forklifts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DTHysteresis",
                table: "Forklifts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DTRef",
                table: "Forklifts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DynamicObstacleInflationRadius",
                table: "Forklifts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GoalToleranceXY",
                table: "Forklifts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GoalToleranceYaw",
                table: "Forklifts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IncludeCostmapObstacles",
                table: "Forklifts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeDynamicObstacles",
                table: "Forklifts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MaxAcceleration",
                table: "Forklifts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaxBackwardSpeed",
                table: "Forklifts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaxForwardSpeed",
                table: "Forklifts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaxTurningAcceleration",
                table: "Forklifts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MaxTurningSpeed",
                table: "Forklifts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MinimalObstacleDistance",
                table: "Forklifts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ObstacleIflationRadius",
                table: "Forklifts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "SaveChanges",
                table: "Forklifts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TurningRadius",
                table: "Forklifts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WheelBase",
                table: "Forklifts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowInitializeWithBackwardMotion",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "AllowOscillationRecovery",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "DTHysteresis",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "DTRef",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "DynamicObstacleInflationRadius",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "GoalToleranceXY",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "GoalToleranceYaw",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "IncludeCostmapObstacles",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "IncludeDynamicObstacles",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "MaxAcceleration",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "MaxBackwardSpeed",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "MaxForwardSpeed",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "MaxTurningAcceleration",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "MaxTurningSpeed",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "MinimalObstacleDistance",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "ObstacleIflationRadius",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "SaveChanges",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "TurningRadius",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "WheelBase",
                table: "Forklifts");
        }
    }
}
