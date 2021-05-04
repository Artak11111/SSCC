using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlCenter.DB.Migrations
{
    public partial class _1_0_0_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("10137b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1988, 2, 21, 0, 0, 0, 0, DateTimeKind.Local), "Artyom" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("11037b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1990, 7, 27, 0, 0, 0, 0, DateTimeKind.Local), "Margarita" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("12937b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1989, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), "Tatevik" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("13937b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1996, 8, 25, 0, 0, 0, 0, DateTimeKind.Local), "Mihran" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("14937b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1993, 7, 3, 0, 0, 0, 0, DateTimeKind.Local), "Dianna" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("15937b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1993, 7, 15, 0, 0, 0, 0, DateTimeKind.Local), "Murad" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("16937b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(2002, 6, 18, 0, 0, 0, 0, DateTimeKind.Local), "Gurgen" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("17137b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1997, 1, 5, 0, 0, 0, 0, DateTimeKind.Local), "Hasmik" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("17937b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1997, 11, 13, 0, 0, 0, 0, DateTimeKind.Local), "Elen" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("18937b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1987, 7, 5, 0, 0, 0, 0, DateTimeKind.Local), "Ani" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("19937b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(2003, 9, 27, 0, 0, 0, 0, DateTimeKind.Local), "Gor" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("28937b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1987, 9, 14, 0, 0, 0, 0, DateTimeKind.Local), "Arsen" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("31937b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1996, 4, 17, 0, 0, 0, 0, DateTimeKind.Local), "Davit" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("48937b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1991, 12, 13, 0, 0, 0, 0, DateTimeKind.Local), "Shushan" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("58937b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(2003, 10, 22, 0, 0, 0, 0, DateTimeKind.Local), "Abgar" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("68937b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1993, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), "Alex" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("71937b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1990, 4, 19, 0, 0, 0, 0, DateTimeKind.Local), "Armen" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("88937b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1994, 10, 18, 0, 0, 0, 0, DateTimeKind.Local), "Arshak" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac1"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1998, 8, 3, 0, 0, 0, 0, DateTimeKind.Local), "Mxitar" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac2"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1987, 5, 25, 0, 0, 0, 0, DateTimeKind.Local), "Nver" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac3"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1990, 9, 14, 0, 0, 0, 0, DateTimeKind.Local), "Narek" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac4"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1988, 2, 7, 0, 0, 0, 0, DateTimeKind.Local), "Syuzi" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac5"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(2001, 5, 30, 0, 0, 0, 0, DateTimeKind.Local), "Katya" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("98937b7a-ef15-4e14-a8c5-5f51552236a0"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1994, 2, 21, 0, 0, 0, 0, DateTimeKind.Local), "Tigran" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef2"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1991, 7, 17, 0, 0, 0, 0, DateTimeKind.Local), "Karen" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef3"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1991, 5, 2, 0, 0, 0, 0, DateTimeKind.Local), "Ashot" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef4"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1995, 6, 5, 0, 0, 0, 0, DateTimeKind.Local), "Kolya" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585efd"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1990, 12, 28, 0, 0, 0, 0, DateTimeKind.Local), "Viktor" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef2"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1993, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), "Edgar" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef3"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1989, 9, 16, 0, 0, 0, 0, DateTimeKind.Local), "Arsen" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef4"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1996, 4, 19, 0, 0, 0, 0, DateTimeKind.Local), "Arto" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef5"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1992, 8, 15, 0, 0, 0, 0, DateTimeKind.Local), "Rafo" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef6"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1989, 12, 8, 0, 0, 0, 0, DateTimeKind.Local), "Ando" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585efd"),
                columns: new[] { "Birthday", "Name" },
                values: new object[] { new DateTime(1987, 10, 20, 0, 0, 0, 0, DateTimeKind.Local), "Anahit" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("10137b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("11037b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("12937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("13937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("14937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("15937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("16937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("17137b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("17937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("18937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("19937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("28937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("31937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("48937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("58937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("68937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("71937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("88937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac1"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac2"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac3"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac4"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac5"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("98937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef2"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef3"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef4"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585efd"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef2"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef3"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef4"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef5"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef6"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585efd"),
                column: "Birthday",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
