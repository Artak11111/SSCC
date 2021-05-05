using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlCenter.DB.Migrations
{
    public partial class _1_0_0_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Notification");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateTime",
                table: "UserNotification",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "UserNotification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NextScheduledNotificatinoDateTime",
                table: "Notification",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TargetUserId",
                table: "Notification",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DepartmentNotification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentNotification", x => x.Id);
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

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("10137b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2002, 7, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("11037b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1990, 12, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("12937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1992, 1, 21, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("13937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2003, 5, 19, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("14937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1994, 11, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("15937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1990, 6, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("16937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1996, 10, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("17137b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1995, 12, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("17937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1992, 2, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("18937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2000, 2, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("19937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1996, 7, 10, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("28937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1994, 5, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("31937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2001, 8, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("48937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1998, 9, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("58937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1989, 2, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("68937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1995, 11, 30, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("71937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1996, 2, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("88937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1989, 5, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac1"),
                column: "Birthday",
                value: new DateTime(1989, 11, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac2"),
                column: "Birthday",
                value: new DateTime(2003, 9, 25, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac3"),
                column: "Birthday",
                value: new DateTime(1990, 8, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac4"),
                column: "Birthday",
                value: new DateTime(1995, 6, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac5"),
                column: "Birthday",
                value: new DateTime(2003, 6, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("98937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1994, 4, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef2"),
                column: "Birthday",
                value: new DateTime(1999, 10, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef3"),
                column: "Birthday",
                value: new DateTime(1997, 12, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef4"),
                column: "Birthday",
                value: new DateTime(1996, 9, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585efd"),
                column: "Birthday",
                value: new DateTime(2002, 5, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef2"),
                column: "Birthday",
                value: new DateTime(2000, 11, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef3"),
                column: "Birthday",
                value: new DateTime(1996, 12, 25, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef4"),
                column: "Birthday",
                value: new DateTime(1988, 11, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef5"),
                column: "Birthday",
                value: new DateTime(1997, 5, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef6"),
                column: "Birthday",
                value: new DateTime(1994, 11, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585efd"),
                column: "Birthday",
                value: new DateTime(2002, 7, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentNotification_DepartmentId",
                table: "DepartmentNotification",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentNotification_NotificationId",
                table: "DepartmentNotification",
                column: "NotificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentNotification");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "UserNotification");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "UserNotification");

            migrationBuilder.DropColumn(
                name: "NextScheduledNotificatinoDateTime",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "TargetUserId",
                table: "Notification");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateTime",
                table: "Notification",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("10137b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1990, 1, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("11037b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1996, 7, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("12937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1998, 2, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("13937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2003, 4, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("14937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2003, 1, 31, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("15937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1994, 4, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("16937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2003, 7, 30, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("17137b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2001, 2, 21, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("17937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1988, 2, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("18937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1987, 10, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("19937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1993, 12, 21, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("28937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2000, 4, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("31937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2000, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("48937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2000, 10, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("58937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1996, 1, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("68937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2000, 6, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("71937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1999, 8, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("88937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1991, 2, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac1"),
                column: "Birthday",
                value: new DateTime(1988, 5, 19, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac2"),
                column: "Birthday",
                value: new DateTime(1994, 3, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac3"),
                column: "Birthday",
                value: new DateTime(1994, 1, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac4"),
                column: "Birthday",
                value: new DateTime(1996, 11, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac5"),
                column: "Birthday",
                value: new DateTime(2003, 10, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("98937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2000, 3, 25, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef2"),
                column: "Birthday",
                value: new DateTime(1995, 7, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef3"),
                column: "Birthday",
                value: new DateTime(1988, 2, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef4"),
                column: "Birthday",
                value: new DateTime(1995, 7, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585efd"),
                column: "Birthday",
                value: new DateTime(1997, 7, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef2"),
                column: "Birthday",
                value: new DateTime(1994, 11, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef3"),
                column: "Birthday",
                value: new DateTime(1988, 11, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef4"),
                column: "Birthday",
                value: new DateTime(1994, 6, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef5"),
                column: "Birthday",
                value: new DateTime(1994, 1, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef6"),
                column: "Birthday",
                value: new DateTime(1999, 10, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585efd"),
                column: "Birthday",
                value: new DateTime(1989, 11, 9, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
