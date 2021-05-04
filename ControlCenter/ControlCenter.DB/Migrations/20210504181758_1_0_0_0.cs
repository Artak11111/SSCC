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
                    Repeat = table.Column<int>(type: "int", nullable: true),
                    DateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "UserNotification",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotification", x => new { x.UserId, x.NotificationId });
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
                columns: new[] { "Id", "Birthday", "DepartmentId", "Email", "PasswordHash" },
                values: new object[,]
                {
                    { new Guid("18937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"), "hr1@solarsystem.com", null },
                    { new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"), "management3@solarsystem.com", null },
                    { new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"), "management2@solarsystem.com", null },
                    { new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"), "management1@solarsystem.com", null },
                    { new Guid("f886b336-8073-4004-befc-65f792585ef6"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"), "sales6@solarsystem.com", null },
                    { new Guid("f886b336-8073-4004-befc-65f792585ef5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"), "sales5@solarsystem.com", null },
                    { new Guid("f886b336-8073-4004-befc-65f792585ef4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"), "sales4@solarsystem.com", null },
                    { new Guid("f886b336-8073-4004-befc-65f792585ef3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"), "sales3@solarsystem.com", null },
                    { new Guid("f886b336-8073-4004-befc-65f792585ef2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"), "sales2@solarsystem.com", null },
                    { new Guid("f886b336-8073-4004-befc-65f792585efd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a3"), "sales1@solarsystem.com", null },
                    { new Guid("e886b336-8073-4004-befc-65f792585ef4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"), "devops4@solarsystem.com", null },
                    { new Guid("e886b336-8073-4004-befc-65f792585ef3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"), "devops3@solarsystem.com", null },
                    { new Guid("e886b336-8073-4004-befc-65f792585ef2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"), "devops2@solarsystem.com", null },
                    { new Guid("e886b336-8073-4004-befc-65f792585efd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a2"), "devops1@solarsystem.com", null },
                    { new Guid("19937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer15@solarsystem.com", null },
                    { new Guid("17137b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer14@solarsystem.com", null },
                    { new Guid("17937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer13@solarsystem.com", null },
                    { new Guid("16937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer12@solarsystem.com", null },
                    { new Guid("28937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"), "hr2@solarsystem.com", null },
                    { new Guid("31937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"), "hr3@solarsystem.com", null },
                    { new Guid("48937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a0"), "hr4@solarsystem.com", null },
                    { new Guid("58937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer1@solarsystem.com", null },
                    { new Guid("68937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer2@solarsystem.com", null },
                    { new Guid("71937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer3@solarsystem.com", null },
                    { new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"), "management4@solarsystem.com", null },
                    { new Guid("88937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer4@solarsystem.com", null },
                    { new Guid("10137b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer6@solarsystem.com", null },
                    { new Guid("11037b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer7@solarsystem.com", null },
                    { new Guid("12937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer8@solarsystem.com", null },
                    { new Guid("13937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer9@solarsystem.com", null },
                    { new Guid("14937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer10@solarsystem.com", null },
                    { new Guid("15937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer11@solarsystem.com", null },
                    { new Guid("98937b7a-ef15-4e14-a8c5-5f51552236a0"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a1"), "developer5@solarsystem.com", null },
                    { new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("39137b7a-ef15-4e14-a8c5-5f51552236a4"), "management5@solarsystem.com", null }
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
