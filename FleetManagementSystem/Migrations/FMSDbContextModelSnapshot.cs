﻿// <auto-generated />
using System;
using FleetManagementSystem.Services.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FleetManagementSystem.Migrations
{
    [DbContext(typeof(FMSDbContext))]
    partial class FMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<bool>("AllowInitializeWithBackwardMotion")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AllowOscillationRecovery")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CurrentJobId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DTHysteresis")
                        .HasColumnType("TEXT");

                    b.Property<string>("DTRef")
                        .HasColumnType("TEXT");

                    b.Property<string>("DynamicObstacleInflationRadius")
                        .HasColumnType("TEXT");

                    b.Property<string>("GoalToleranceXY")
                        .HasColumnType("TEXT");

                    b.Property<string>("GoalToleranceYaw")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IncludeCostmapObstacles")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IncludeDynamicObstacles")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LidarLocAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("LoadLastTaskAtStartup")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MaxAcceleration")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaxBackwardSpeed")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaxForwardSpeed")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaxTurningAcceleration")
                        .HasColumnType("TEXT");

                    b.Property<string>("MaxTurningSpeed")
                        .HasColumnType("TEXT");

                    b.Property<string>("MinimalObstacleDistance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ObstacleIflationRadius")
                        .HasColumnType("TEXT");

                    b.Property<int>("Port")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ReceiveOrdersFromWms")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TurningRadius")
                        .HasColumnType("TEXT");

                    b.Property<string>("WheelBase")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CurrentJobId");

                    b.ToTable("Forklifts");
                });

            modelBuilder.Entity("FleetManagementSystem.Models.ForkliftLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ForkliftId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MessageDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MessageLevel")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ForkliftId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("FleetManagementSystem.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("InQueue")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCurrentlyRunning")
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("FleetManagementSystem.Models.JobStep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsDone")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRunning")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JobID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TaskLocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TaskType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("JobID");

                    b.HasIndex("TaskLocationId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("FleetManagementSystem.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PositionR")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PositionX")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PositionY")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("FleetManagementSystem.Models.TaskType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TaskTypes");
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
                    b.HasOne("FleetManagementSystem.Models.JobStep", "CurrentJob")
                        .WithMany()
                        .HasForeignKey("CurrentJobId");

                    b.Navigation("CurrentJob");
                });

            modelBuilder.Entity("FleetManagementSystem.Models.ForkliftLog", b =>
                {
                    b.HasOne("FleetManagementSystem.Models.Forklift", null)
                        .WithMany("Log")
                        .HasForeignKey("ForkliftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FleetManagementSystem.Models.JobStep", b =>
                {
                    b.HasOne("FleetManagementSystem.Models.Job", "Job")
                        .WithMany("TaskList")
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FleetManagementSystem.Models.Location", "TaskLocation")
                        .WithMany()
                        .HasForeignKey("TaskLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");

                    b.Navigation("TaskLocation");
                });

            modelBuilder.Entity("FleetManagementSystem.Models.Forklift", b =>
                {
                    b.Navigation("Log");
                });

            modelBuilder.Entity("FleetManagementSystem.Models.Job", b =>
                {
                    b.Navigation("TaskList");
                });
#pragma warning restore 612, 618
        }
    }
}
