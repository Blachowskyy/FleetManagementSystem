using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RemeberTasksAtStartup = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConnectionDeviceType = table.Column<int>(type: "INTEGER", nullable: false),
                    ConnectionType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForkliftDataModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    LastDataUpdate = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentBatteryVoltage = table.Column<float>(type: "REAL", nullable: false),
                    CurrentBatteryPercentage = table.Column<float>(type: "REAL", nullable: false),
                    NeedCharging = table.Column<bool>(type: "INTEGER", nullable: false),
                    CurrentForkliftSpeed = table.Column<float>(type: "REAL", nullable: false),
                    CurrentForkliftSteeringAngle = table.Column<float>(type: "REAL", nullable: false),
                    CurrentForkliftPWM = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentWeightOnForks = table.Column<float>(type: "REAL", nullable: false),
                    CurrentForksHeight = table.Column<float>(type: "REAL", nullable: false),
                    CurrentPositionX = table.Column<float>(type: "REAL", nullable: false),
                    CurrentPositionY = table.Column<float>(type: "REAL", nullable: false),
                    CurrentPositionR = table.Column<float>(type: "REAL", nullable: false),
                    CurrentTitlAxis1 = table.Column<float>(type: "REAL", nullable: false),
                    CurrentTiltAxis2 = table.Column<float>(type: "REAL", nullable: false),
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
                    LeftScannerReduceSpeedZone = table.Column<bool>(type: "INTEGER", nullable: false),
                    LeftScannerSoftStopZone = table.Column<bool>(type: "INTEGER", nullable: false),
                    LeftScannerEmergencyZone = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightScannerReduceSpeedZone = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightScannerSoftStopZone = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightScannerEmergencyZone = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightScannerActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightScannerDeviceError = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightScannerContaminationWarning = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightScannerContaminationError = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightScannerApplicationError = table.Column<bool>(type: "INTEGER", nullable: false),
                    LeftScannerActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    LeftScannerContaminationWarning = table.Column<bool>(type: "INTEGER", nullable: false),
                    LeftScannerContaminationError = table.Column<bool>(type: "INTEGER", nullable: false),
                    LeftScannerApplicationError = table.Column<bool>(type: "INTEGER", nullable: false),
                    LeftScannerDeviceError = table.Column<bool>(type: "INTEGER", nullable: false),
                    LeftEmergencyStopButton = table.Column<bool>(type: "INTEGER", nullable: false),
                    RightEmergencyStopButton = table.Column<bool>(type: "INTEGER", nullable: false),
                    EncoderStatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    FlexiStatus = table.Column<bool>(type: "INTEGER", nullable: false),
                    SafeStandstill = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConfirmPauseWork = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConfirmCancelLastTask = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConfirmStartAutoMode = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConfirmContinueWork = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConfirmEmergencyStop = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConfirmDeleteAllTask = table.Column<bool>(type: "INTEGER", nullable: false),
                    CurrentJobID = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentJobReceiveDate = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentJobType = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentJobImportanceLevel = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentJobCoordinatesX = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentJobCoordinatesY = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentJobCoordinatesR = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentJobIsInQueue = table.Column<bool>(type: "INTEGER", nullable: false),
                    CurrentJobISInProgress = table.Column<bool>(type: "INTEGER", nullable: false),
                    CurrentJobIsCompleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForkliftDataModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    PositionX = table.Column<float>(type: "REAL", nullable: false),
                    PositionY = table.Column<float>(type: "REAL", nullable: false),
                    PositionR = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forklifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IpAddress = table.Column<string>(type: "TEXT", nullable: false),
                    Port = table.Column<int>(type: "INTEGER", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ForkliftDataId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forklifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forklifts_ForkliftDataModel_ForkliftDataId",
                        column: x => x.ForkliftDataId,
                        principalTable: "ForkliftDataModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImportanceLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    TaskType = table.Column<int>(type: "INTEGER", nullable: false),
                    TaskLocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    JobId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Locations_TaskLocationId",
                        column: x => x.TaskLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forklifts_ForkliftDataId",
                table: "Forklifts",
                column: "ForkliftDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_JobId",
                table: "Tasks",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskLocationId",
                table: "Tasks",
                column: "TaskLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSettings");

            migrationBuilder.DropTable(
                name: "Forklifts");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "ForkliftDataModel");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
