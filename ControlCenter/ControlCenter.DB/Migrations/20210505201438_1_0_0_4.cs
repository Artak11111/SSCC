using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlCenter.DB.Migrations
{
    public partial class _1_0_0_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserNotification");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DepartmentNotification");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("10137b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1998, 5, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("11037b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1995, 2, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("12937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1990, 9, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("13937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1989, 3, 11, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("14937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2001, 12, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("15937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1992, 11, 10, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("16937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2001, 5, 19, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("17137b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1988, 1, 21, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("17937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1998, 2, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("18937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("19937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1995, 8, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("28937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1988, 1, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("31937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1993, 10, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("48937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1991, 10, 30, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("58937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2004, 1, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("68937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1991, 3, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("71937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2001, 7, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("88937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1997, 3, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac1"),
                column: "Birthday",
                value: new DateTime(1993, 12, 31, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac2"),
                column: "Birthday",
                value: new DateTime(2003, 12, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac3"),
                column: "Birthday",
                value: new DateTime(2002, 10, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac4"),
                column: "Birthday",
                value: new DateTime(1994, 6, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac5"),
                column: "Birthday",
                value: new DateTime(1992, 8, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("98937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2002, 9, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef2"),
                column: "Birthday",
                value: new DateTime(1995, 1, 31, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef3"),
                column: "Birthday",
                value: new DateTime(2000, 5, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef4"),
                column: "Birthday",
                value: new DateTime(1994, 3, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585efd"),
                column: "Birthday",
                value: new DateTime(1991, 5, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef2"),
                column: "Birthday",
                value: new DateTime(1999, 12, 31, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef3"),
                column: "Birthday",
                value: new DateTime(1998, 1, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef4"),
                column: "Birthday",
                value: new DateTime(1990, 7, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef5"),
                column: "Birthday",
                value: new DateTime(1991, 4, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef6"),
                column: "Birthday",
                value: new DateTime(2001, 8, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585efd"),
                column: "Birthday",
                value: new DateTime(2003, 12, 8, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserNotification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "DepartmentNotification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("10137b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2000, 10, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("11037b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1998, 7, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("12937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1992, 7, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("13937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1999, 5, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("14937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1994, 2, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("15937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1997, 11, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("16937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1992, 5, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("17137b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1988, 11, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("17937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2002, 5, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("18937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1989, 5, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("19937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2003, 2, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("28937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1989, 11, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("31937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1996, 6, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("48937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1998, 9, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("58937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1993, 7, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("68937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1991, 6, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("71937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1998, 10, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("88937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1997, 11, 19, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac1"),
                column: "Birthday",
                value: new DateTime(2004, 2, 10, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac2"),
                column: "Birthday",
                value: new DateTime(1994, 12, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac3"),
                column: "Birthday",
                value: new DateTime(1991, 1, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac4"),
                column: "Birthday",
                value: new DateTime(2002, 11, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac5"),
                column: "Birthday",
                value: new DateTime(1997, 8, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("98937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1989, 8, 21, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef2"),
                column: "Birthday",
                value: new DateTime(1994, 9, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef3"),
                column: "Birthday",
                value: new DateTime(2002, 10, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef4"),
                column: "Birthday",
                value: new DateTime(1989, 12, 6, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585efd"),
                column: "Birthday",
                value: new DateTime(1995, 4, 30, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef2"),
                column: "Birthday",
                value: new DateTime(1996, 7, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef3"),
                column: "Birthday",
                value: new DateTime(2004, 2, 24, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef4"),
                column: "Birthday",
                value: new DateTime(1999, 5, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef5"),
                column: "Birthday",
                value: new DateTime(1987, 5, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef6"),
                column: "Birthday",
                value: new DateTime(1994, 6, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585efd"),
                column: "Birthday",
                value: new DateTime(1999, 6, 19, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
