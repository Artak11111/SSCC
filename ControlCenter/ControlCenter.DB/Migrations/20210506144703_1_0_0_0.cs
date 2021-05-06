using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlCenter.DB.Migrations
{
    public partial class _1_0_0_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Repeat = table.Column<int>(type: "int", nullable: false),
                    NextScheduledNotificatinoDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TargetUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsForEveryOne = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentNotification",
                columns: table => new
                {
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentNotification", x => new { x.DepartmentId, x.NotificationId });
                    table.ForeignKey(
                        name: "FK_DepartmentNotification_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentNotification_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notification",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DisabledDepartment",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabledDepartment", x => new { x.UserId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_DisabledDepartment_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisabledDepartment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserNotification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotification_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notification",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserNotification_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"), "HR" },
                    { new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "Development" },
                    { new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"), "DevOps" },
                    { new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"), "Sales" },
                    { new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"), "Management" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Birthday", "DepartmentId", "Email", "Name", "PasswordHash" },
                values: new object[,]
                {
                    { new Guid("18937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1991, 8, 9, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"), "hr1@solarsystem.com", "Ani", null },
                    { new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac3"), new DateTime(1991, 8, 28, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"), "management3@solarsystem.com", "Narek", null },
                    { new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac2"), new DateTime(2002, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"), "management2@solarsystem.com", "Nver", null },
                    { new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac1"), new DateTime(1995, 4, 10, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"), "management1@solarsystem.com", "Mxitar", null },
                    { new Guid("f886b336-8073-4004-befc-65f792585ef6"), new DateTime(1989, 1, 20, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"), "sales6@solarsystem.com", "Ando", null },
                    { new Guid("f886b336-8073-4004-befc-65f792585ef5"), new DateTime(1995, 3, 27, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"), "sales5@solarsystem.com", "Rafo", null },
                    { new Guid("f886b336-8073-4004-befc-65f792585ef4"), new DateTime(1994, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"), "sales4@solarsystem.com", "Arto", null },
                    { new Guid("f886b336-8073-4004-befc-65f792585ef3"), new DateTime(1988, 3, 14, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"), "sales3@solarsystem.com", "Arsen", null },
                    { new Guid("f886b336-8073-4004-befc-65f792585ef2"), new DateTime(2002, 6, 25, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"), "sales2@solarsystem.com", "Edgar", null },
                    { new Guid("f886b336-8073-4004-befc-65f792585efd"), new DateTime(1996, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"), "sales1@solarsystem.com", "Anahit", null },
                    { new Guid("e886b336-8073-4004-befc-65f792585ef4"), new DateTime(1997, 4, 9, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"), "devops4@solarsystem.com", "Kolya", null },
                    { new Guid("e886b336-8073-4004-befc-65f792585ef3"), new DateTime(1991, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"), "devops3@solarsystem.com", "Ashot", null },
                    { new Guid("e886b336-8073-4004-befc-65f792585ef2"), new DateTime(2001, 7, 10, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"), "devops2@solarsystem.com", "Karen", null },
                    { new Guid("e886b336-8073-4004-befc-65f792585efd"), new DateTime(1999, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"), "devops1@solarsystem.com", "Viktor", null },
                    { new Guid("19937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1987, 7, 4, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer15@solarsystem.com", "Gor", null },
                    { new Guid("17137b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1995, 2, 7, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer14@solarsystem.com", "Hasmik", null },
                    { new Guid("17937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1996, 3, 20, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer13@solarsystem.com", "Elen", null },
                    { new Guid("16937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1989, 3, 9, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer12@solarsystem.com", "Gurgen", null },
                    { new Guid("28937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(2003, 8, 17, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"), "hr2@solarsystem.com", "Arsen", null },
                    { new Guid("31937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1996, 6, 17, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"), "hr3@solarsystem.com", "Davit", null },
                    { new Guid("48937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1989, 9, 14, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"), "hr4@solarsystem.com", "Shushan", null },
                    { new Guid("58937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1990, 7, 18, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer1@solarsystem.com", "Abgar", null },
                    { new Guid("68937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1988, 5, 31, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer2@solarsystem.com", "Alex", null },
                    { new Guid("71937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1990, 3, 15, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer3@solarsystem.com", "Armen", null },
                    { new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac4"), new DateTime(1990, 9, 2, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"), "management4@solarsystem.com", "Syuzi", null },
                    { new Guid("88937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1991, 2, 14, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer4@solarsystem.com", "Arshak", null },
                    { new Guid("10137b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(2004, 3, 18, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer6@solarsystem.com", "Artyom", null },
                    { new Guid("11037b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1995, 11, 5, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer7@solarsystem.com", "Margarita", null },
                    { new Guid("12937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1998, 12, 3, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer8@solarsystem.com", "Tatevik", null },
                    { new Guid("13937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1996, 8, 19, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer9@solarsystem.com", "Mihran", null },
                    { new Guid("14937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1994, 9, 9, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer10@solarsystem.com", "Dianna", null },
                    { new Guid("15937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1991, 12, 26, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer11@solarsystem.com", "Murad", null },
                    { new Guid("98937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1998, 8, 28, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer5@solarsystem.com", "Tigran", null },
                    { new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac5"), new DateTime(1995, 9, 13, 0, 0, 0, 0, DateTimeKind.Local), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"), "management5@solarsystem.com", "Katya", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentNotification_NotificationId",
                table: "DepartmentNotification",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabledDepartment_DepartmentId",
                table: "DisabledDepartment",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_DepartmentId",
                table: "Notification",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_User_DepartmentId",
                table: "User",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_NotificationId",
                table: "UserNotification",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_UserId",
                table: "UserNotification",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentNotification");

            migrationBuilder.DropTable(
                name: "DisabledDepartment");

            migrationBuilder.DropTable(
                name: "UserNotification");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
