﻿// <auto-generated />
using System;
using FleetManagementSystem.Services.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FleetManagementSystem.Migrations
{
    [DbContext(typeof(FMSDbContext))]
    [Migration("20230906122437_nfc")]
    partial class nfc
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.10");

            modelBuilder.Entity("FleetManagementSystem.Models.AppSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ConnectionDeviceType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ConnectionType")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RemeberTasksAtStartup")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("AppSettings");
                });

            modelBuilder.Entity("FleetManagementSystem.Models.Forklift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ForkliftDataId")
                        .HasColumnType("TEXT");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsConnected")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LidarLocAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NfcCardReader")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Port")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ForkliftDataId");

                    b.ToTable("Forklifts");
                });

            modelBuilder.Entity("FleetManagementSystem.Models.ForkliftDataModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ConfirmCancelLastTask")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ConfirmContinueWork")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ConfirmDeleteAllTask")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ConfirmEmergencyStop")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ConfirmPauseWork")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ConfirmStartAutoMode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CurrentBatteryPercentage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentBatteryVoltage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentForkliftPWM")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentForkliftSpeed")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentForkliftSteeringAngle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentForksHeight")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentJobCoordinatesR")
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentJobCoordinatesX")
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentJobCoordinatesY")
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentJobID")
                        .HasColumnType("TEXT");

                    b.Property<bool>("CurrentJobISInProgress")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CurrentJobImportanceLevel")
                        .HasColumnType("TEXT");

                    b.Property<bool>("CurrentJobIsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CurrentJobIsInQueue")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CurrentJobReceiveDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentJobType")
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentPositionR")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentPositionX")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentPositionY")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentTiltAxis2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentTitlAxis1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrentWeightOnForks")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("EncoderStatus")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("FlexiStatus")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastDataUpdate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("LeftEmergencyStopButton")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LeftScannerActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LeftScannerApplicationError")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LeftScannerContaminationError")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LeftScannerContaminationWarning")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LeftScannerDeviceError")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LeftScannerEmergencyZone")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LeftScannerReduceSpeedZone")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LeftScannerSoftStopZone")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("NeedCharging")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RightEmergencyStopButton")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RightScannerActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RightScannerApplicationError")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RightScannerContaminationError")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RightScannerContaminationWarning")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RightScannerDeviceError")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RightScannerEmergencyZone")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RightScannerReduceSpeedZone")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RightScannerSoftStopZone")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("S01")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("S02")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("S03")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("S1")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("S2")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("S3")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("S4")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("S40")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("S41")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("S42")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("S43")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("S44")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("S45")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("S46")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SafeStandstill")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ForkliftDataModel");
                });

            modelBuilder.Entity("FleetManagementSystem.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("FleetManagementSystem.Models.JobStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ImportanceLevel")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("JobId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TaskLocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TaskType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.HasIndex("TaskLocationId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("FleetManagementSystem.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("PositionR")
                        .HasColumnType("REAL");

                    b.Property<float>("PositionX")
                        .HasColumnType("REAL");

                    b.Property<float>("PositionY")
                        .HasColumnType("REAL");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("FleetManagementSystem.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Installator")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsLogged")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NfcTag")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("SuperUser")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FleetManagementSystem.Models.Forklift", b =>
                {
                    b.HasOne("FleetManagementSystem.Models.ForkliftDataModel", "ForkliftData")
                        .WithMany()
                        .HasForeignKey("ForkliftDataId");

                    b.Navigation("ForkliftData");
                });

            modelBuilder.Entity("FleetManagementSystem.Models.JobStep", b =>
                {
                    b.HasOne("FleetManagementSystem.Models.Job", null)
                        .WithMany("TaskList")
                        .HasForeignKey("JobId");

                    b.HasOne("FleetManagementSystem.Models.Location", "TaskLocation")
                        .WithMany()
                        .HasForeignKey("TaskLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskLocation");
                });

            modelBuilder.Entity("FleetManagementSystem.Models.Job", b =>
                {
                    b.Navigation("TaskList");
                });
#pragma warning restore 612, 618
        }
    }
}