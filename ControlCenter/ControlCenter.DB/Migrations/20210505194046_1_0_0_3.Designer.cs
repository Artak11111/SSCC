﻿// <auto-generated />
using System;
using ControlCenter.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControlCenter.DB.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210505194046_1_0_0_3")]
    partial class _1_0_0_3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ControlCenter.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            Id = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Name = "HR"
                        },
                        new
                        {
                            Id = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                            Name = "Development"
                        },
                        new
                        {
                            Id = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"),
                            Name = "DevOps"
                        },
                        new
                        {
                            Id = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"),
                            Name = "Sales"
                        },
                        new
                        {
                            Id = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"),
                            Name = "Management"
                        });
                });

            modelBuilder.Entity("ControlCenter.Entities.DepartmentNotification", b =>
                {
                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NotificationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DepartmentId", "NotificationId");

                    b.HasIndex("NotificationId");

                    b.ToTable("DepartmentNotification");
                });

            modelBuilder.Entity("ControlCenter.Entities.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsForEveryOne")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("NextScheduledNotificatinoDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("Repeat")
                        .HasColumnType("int");

                    b.Property<Guid?>("TargetUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("ControlCenter.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("18937b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(1989, 5, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Email = "hr1@solarsystem.com",
                            Name = "Ani"
                        },
                        new
                        {
                            Id = new Guid("28937b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(1989, 11, 29, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Email = "hr2@solarsystem.com",
                            Name = "Arsen"
                        },
                        new
                        {
                            Id = new Guid("31937b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(1996, 6, 27, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Email = "hr3@solarsystem.com",
                            Name = "Davit"
                        },
                        new
                        {
                            Id = new Guid("48937b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(1998, 9, 3, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Email = "hr4@solarsystem.com",
                            Name = "Shushan"
                        },
                        new
                        {
                            Id = new Guid("58937b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(1993, 7, 22, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                            Email = "developer1@solarsystem.com",
                            Name = "Abgar"
                        },
                        new
                        {
                            Id = new Guid("68937b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(1991, 6, 9, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                            Email = "developer2@solarsystem.com",
                            Name = "Alex"
                        },
                        new
                        {
                            Id = new Guid("71937b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(1998, 10, 27, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                            Email = "developer3@solarsystem.com",
                            Name = "Armen"
                        },
                        new
                        {
                            Id = new Guid("88937b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(1997, 11, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                            Email = "developer4@solarsystem.com",
                            Name = "Arshak"
                        },
                        new
                        {
                            Id = new Guid("98937b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(1989, 8, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                            Email = "developer5@solarsystem.com",
                            Name = "Tigran"
                        },
                        new
                        {
                            Id = new Guid("10137b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(2000, 10, 9, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                            Email = "developer6@solarsystem.com",
                            Name = "Artyom"
                        },
                        new
                        {
                            Id = new Guid("11037b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(1998, 7, 5, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                            Email = "developer7@solarsystem.com",
                            Name = "Margarita"
                        },
                        new
                        {
                            Id = new Guid("12937b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(1992, 7, 2, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                            Email = "developer8@solarsystem.com",
                            Name = "Tatevik"
                        },
                        new
                        {
                            Id = new Guid("13937b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(1999, 5, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                            Email = "developer9@solarsystem.com",
                            Name = "Mihran"
                        },
                        new
                        {
                            Id = new Guid("14937b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(1994, 2, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                            Email = "developer10@solarsystem.com",
                            Name = "Dianna"
                        },
                        new
                        {
                            Id = new Guid("15937b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(1997, 11, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                            Email = "developer11@solarsystem.com",
                            Name = "Murad"
                        },
                        new
                        {
                            Id = new Guid("16937b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(1992, 5, 22, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                            Email = "developer12@solarsystem.com",
                            Name = "Gurgen"
                        },
                        new
                        {
                            Id = new Guid("17937b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(2002, 5, 9, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                            Email = "developer13@solarsystem.com",
                            Name = "Elen"
                        },
                        new
                        {
                            Id = new Guid("17137b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(1988, 11, 2, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                            Email = "developer14@solarsystem.com",
                            Name = "Hasmik"
                        },
                        new
                        {
                            Id = new Guid("19937b7a-ef15-4e14-a8c5-5f51552236a0"),
                            Birthday = new DateTime(2003, 2, 20, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"),
                            Email = "developer15@solarsystem.com",
                            Name = "Gor"
                        },
                        new
                        {
                            Id = new Guid("e886b336-8073-4004-befc-65f792585efd"),
                            Birthday = new DateTime(1995, 4, 30, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"),
                            Email = "devops1@solarsystem.com",
                            Name = "Viktor"
                        },
                        new
                        {
                            Id = new Guid("e886b336-8073-4004-befc-65f792585ef2"),
                            Birthday = new DateTime(1994, 9, 14, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"),
                            Email = "devops2@solarsystem.com",
                            Name = "Karen"
                        },
                        new
                        {
                            Id = new Guid("e886b336-8073-4004-befc-65f792585ef3"),
                            Birthday = new DateTime(2002, 10, 4, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"),
                            Email = "devops3@solarsystem.com",
                            Name = "Ashot"
                        },
                        new
                        {
                            Id = new Guid("e886b336-8073-4004-befc-65f792585ef4"),
                            Birthday = new DateTime(1989, 12, 6, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"),
                            Email = "devops4@solarsystem.com",
                            Name = "Kolya"
                        },
                        new
                        {
                            Id = new Guid("f886b336-8073-4004-befc-65f792585efd"),
                            Birthday = new DateTime(1999, 6, 19, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"),
                            Email = "sales1@solarsystem.com",
                            Name = "Anahit"
                        },
                        new
                        {
                            Id = new Guid("f886b336-8073-4004-befc-65f792585ef2"),
                            Birthday = new DateTime(1996, 7, 17, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"),
                            Email = "sales2@solarsystem.com",
                            Name = "Edgar"
                        },
                        new
                        {
                            Id = new Guid("f886b336-8073-4004-befc-65f792585ef3"),
                            Birthday = new DateTime(2004, 2, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"),
                            Email = "sales3@solarsystem.com",
                            Name = "Arsen"
                        },
                        new
                        {
                            Id = new Guid("f886b336-8073-4004-befc-65f792585ef4"),
                            Birthday = new DateTime(1999, 5, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"),
                            Email = "sales4@solarsystem.com",
                            Name = "Arto"
                        },
                        new
                        {
                            Id = new Guid("f886b336-8073-4004-befc-65f792585ef5"),
                            Birthday = new DateTime(1987, 5, 9, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"),
                            Email = "sales5@solarsystem.com",
                            Name = "Rafo"
                        },
                        new
                        {
                            Id = new Guid("f886b336-8073-4004-befc-65f792585ef6"),
                            Birthday = new DateTime(1994, 6, 13, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"),
                            Email = "sales6@solarsystem.com",
                            Name = "Ando"
                        },
                        new
                        {
                            Id = new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac1"),
                            Birthday = new DateTime(2004, 2, 10, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"),
                            Email = "management1@solarsystem.com",
                            Name = "Mxitar"
                        },
                        new
                        {
                            Id = new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac2"),
                            Birthday = new DateTime(1994, 12, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"),
                            Email = "management2@solarsystem.com",
                            Name = "Nver"
                        },
                        new
                        {
                            Id = new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac3"),
                            Birthday = new DateTime(1991, 1, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"),
                            Email = "management3@solarsystem.com",
                            Name = "Narek"
                        },
                        new
                        {
                            Id = new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac4"),
                            Birthday = new DateTime(2002, 11, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"),
                            Email = "management4@solarsystem.com",
                            Name = "Syuzi"
                        },
                        new
                        {
                            Id = new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac5"),
                            Birthday = new DateTime(1997, 8, 20, 0, 0, 0, 0, DateTimeKind.Local),
                            DepartmentId = new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"),
                            Email = "management5@solarsystem.com",
                            Name = "Katya"
                        });
                });

            modelBuilder.Entity("ControlCenter.Entities.UserNotification", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NotificationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("DateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "NotificationId");

                    b.HasIndex("NotificationId");

                    b.ToTable("UserNotification");
                });

            modelBuilder.Entity("ControlCenter.Entities.DepartmentNotification", b =>
                {
                    b.HasOne("ControlCenter.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ControlCenter.Entities.Notification", "Notification")
                        .WithMany("TargetDepartments")
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Notification");
                });

            modelBuilder.Entity("ControlCenter.Entities.Notification", b =>
                {
                    b.HasOne("ControlCenter.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ControlCenter.Entities.User", b =>
                {
                    b.HasOne("ControlCenter.Entities.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ControlCenter.Entities.UserNotification", b =>
                {
                    b.HasOne("ControlCenter.Entities.Notification", "Notification")
                        .WithMany("TargetUsers")
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ControlCenter.Entities.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Notification");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ControlCenter.Entities.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ControlCenter.Entities.Notification", b =>
                {
                    b.Navigation("TargetDepartments");

                    b.Navigation("TargetUsers");
                });

            modelBuilder.Entity("ControlCenter.Entities.User", b =>
                {
                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
