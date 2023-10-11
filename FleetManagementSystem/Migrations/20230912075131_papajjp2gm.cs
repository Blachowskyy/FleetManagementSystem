using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class papajjp2gm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forklifts_ForkliftDataModel_ForkliftDataId",
                table: "Forklifts");

            migrationBuilder.DropTable(
                name: "ForkliftDataModel");

            migrationBuilder.DropIndex(
                name: "IX_Forklifts_ForkliftDataId",
                table: "Forklifts");

            migrationBuilder.DropColumn(
                name: "ForkliftDataId",
                table: "Forklifts");

            migrationBuilder.AddColumn<string>(
                name: "JobName",
                table: "Jobs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobName",
                table: "Jobs");

            migrationBuilder.AddColumn<string>(
                name: "ForkliftDataId",
                table: "Forklifts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ForkliftDataModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ConfirmCancelLastTask = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConfirmContinueWork = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConfirmDeleteAllTask = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConfirmEmergencyStop = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConfirmPauseWork = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConfirmStartAutoMode = table.Column<bool>(type: "INTEGER", nullable: false),
                    CurrentBatteryPercentage = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentBatteryVoltage = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentForkliftPWM = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentForkliftSpeed = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentForkliftSteeringAngle = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentForksHeight = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentJobCoordinatesR = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentJobCoordinatesX = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentJobCoordinatesY = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentJobID = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentJobISInProgress = table.Column<bool>(type: "INTEGER", nullable: false),
                    CurrentJobImportanceLevel = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentJobIsCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CurrentJobIsInQueue = table.Column<bool>(type: "INTEGER", nullable: false),
                    CurrentJobReceiveDate = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentJobType = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentPositionR = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentPositionX = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentPositionY = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentTiltAxis2 = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentTitlAxis1 = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentWeightOnForks = table.Column<string>(type: "TEXT", nullable: false),
                    EncoderStatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    FlexiStatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastDataUpdate = table.Column<string>(type: "TEXT", nullable: false),
                    LeftEmergencyStopButton = table.Column<bool>(type: "INTEGER", nullable: false),
                    LeftScannerActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    LeftScannerApplicationError = table.Column<bool>(type: "INTEGER", nullable: false),
                    LeftScannerContaminationError = table.Column<bool>(type: "INTEGER", nullable: false),
                    LeftScannerContaminationWarning = table.Column<bool>(type: "INTEGER", nullable: false),
                    LeftScannerDeviceError = table.Column<bool>(type: "INTEGER", nullable: false),
                    LeftScannerEmergencyZone = table.Column<bool>(type: "INTEGER", nullable: false),
                    LeftScannerReduceSpeedZone = table.Column<bool>(type: "INTEGER", nullable: false),
                    LeftScannerSoftStopZone = table.Column<bool>(type: "INTEGER", nullable: false),
                    NeedCharging = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightEmergencyStopButton = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightScannerActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightScannerApplicationError = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightScannerContaminationError = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightScannerContaminationWarning = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightScannerDeviceError = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightScannerEmergencyZone = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightScannerReduceSpeedZone = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightScannerSoftStopZone = table.Column<bool>(type: "INTEGER", nullable: false),
                    S01 = table.Column<bool>(type: "INTEGER", nullable: false),
                    S02 = table.Column<bool>(type: "INTEGER", nullable: false),
                    S03 = table.Column<bool>(type: "INTEGER", nullable: false),
                    S1 = table.Column<bool>(type: "INTEGER", nullable: false),
                    S2 = table.Column<bool>(type: "INTEGER", nullable: false),
                    S3 = table.Column<bool>(type: "INTEGER", nullable: false),
                    S4 = table.Column<bool>(type: "INTEGER", nullable: false),
                    S40 = table.Column<bool>(type: "INTEGER", nullable: false),
                    S41 = table.Column<bool>(type: "INTEGER", nullable: false),
                    S42 = table.Column<bool>(type: "INTEGER", nullable: false),
                    S43 = table.Column<bool>(type: "INTEGER", nullable: false),
                    S44 = table.Column<bool>(type: "INTEGER", nullable: false),
                    S45 = table.Column<bool>(type: "INTEGER", nullable: false),
                    S46 = table.Column<bool>(type: "INTEGER", nullable: false),
                    SafeStandstill = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForkliftDataModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forklifts_ForkliftDataId",
                table: "Forklifts",
                column: "ForkliftDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forklifts_ForkliftDataModel_ForkliftDataId",
                table: "Forklifts",
                column: "ForkliftDataId",
                principalTable: "ForkliftDataModel",
                principalColumn: "Id");
        }
    }
}
