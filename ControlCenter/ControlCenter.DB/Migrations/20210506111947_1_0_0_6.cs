using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlCenter.DB.Migrations
{
    public partial class _1_0_0_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Repeat",
                table: "Notification",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DisbledDepartment",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisbledDepartment", x => new { x.UserId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_DisbledDepartment_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisbledDepartment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("10137b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2002, 4, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("11037b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1988, 7, 30, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("12937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1989, 8, 10, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("13937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1996, 5, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("14937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1995, 10, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("15937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1999, 12, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("16937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2001, 3, 21, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("17137b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1989, 8, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("17937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1998, 4, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("18937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1992, 6, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("19937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1998, 11, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("28937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1988, 12, 31, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("31937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2000, 3, 30, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("48937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2001, 4, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("58937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2004, 4, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("68937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1997, 5, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("71937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2003, 3, 11, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("88937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1992, 7, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac1"),
                column: "Birthday",
                value: new DateTime(1995, 3, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac2"),
                column: "Birthday",
                value: new DateTime(1996, 9, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac3"),
                column: "Birthday",
                value: new DateTime(1989, 3, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac4"),
                column: "Birthday",
                value: new DateTime(1991, 1, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac5"),
                column: "Birthday",
                value: new DateTime(1992, 10, 29, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("98937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1992, 1, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef2"),
                column: "Birthday",
                value: new DateTime(1990, 10, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef3"),
                column: "Birthday",
                value: new DateTime(1987, 6, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef4"),
                column: "Birthday",
                value: new DateTime(1999, 1, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585efd"),
                column: "Birthday",
                value: new DateTime(1998, 5, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef2"),
                column: "Birthday",
                value: new DateTime(1987, 8, 31, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef3"),
                column: "Birthday",
                value: new DateTime(1990, 8, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef4"),
                column: "Birthday",
                value: new DateTime(1989, 3, 30, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef5"),
                column: "Birthday",
                value: new DateTime(1996, 12, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef6"),
                column: "Birthday",
                value: new DateTime(2002, 3, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585efd"),
                column: "Birthday",
                value: new DateTime(1997, 11, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_DisbledDepartment_DepartmentId",
                table: "DisbledDepartment",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisbledDepartment");

            migrationBuilder.AlterColumn<int>(
                name: "Repeat",
                table: "Notification",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("10137b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2000, 1, 19, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("11037b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1997, 2, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("12937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2002, 3, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("13937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1990, 1, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("14937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1994, 6, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("15937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1990, 8, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("16937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1995, 8, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("17137b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1992, 4, 11, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("17937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1989, 6, 1, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("18937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2002, 9, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("19937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1989, 5, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("28937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2002, 3, 15, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("31937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2002, 9, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("48937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2000, 2, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("58937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1995, 5, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("68937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1987, 8, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("71937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1990, 2, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("88937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(2000, 3, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac1"),
                column: "Birthday",
                value: new DateTime(2000, 8, 23, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac2"),
                column: "Birthday",
                value: new DateTime(1989, 3, 19, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac3"),
                column: "Birthday",
                value: new DateTime(1997, 10, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac4"),
                column: "Birthday",
                value: new DateTime(1992, 8, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("8a64082d-6365-4cf4-816a-521bfaa84ac5"),
                column: "Birthday",
                value: new DateTime(1992, 11, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("98937b7a-ef15-4e14-a8c5-5f51552236a0"),
                column: "Birthday",
                value: new DateTime(1996, 5, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef2"),
                column: "Birthday",
                value: new DateTime(2001, 12, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef3"),
                column: "Birthday",
                value: new DateTime(1996, 1, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585ef4"),
                column: "Birthday",
                value: new DateTime(1998, 1, 31, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e886b336-8073-4004-befc-65f792585efd"),
                column: "Birthday",
                value: new DateTime(1994, 11, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef2"),
                column: "Birthday",
                value: new DateTime(1997, 10, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef3"),
                column: "Birthday",
                value: new DateTime(2000, 2, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef4"),
                column: "Birthday",
                value: new DateTime(2002, 3, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef5"),
                column: "Birthday",
                value: new DateTime(2001, 3, 18, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585ef6"),
                column: "Birthday",
                value: new DateTime(1988, 3, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f886b336-8073-4004-befc-65f792585efd"),
                column: "Birthday",
                value: new DateTime(1998, 1, 5, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
