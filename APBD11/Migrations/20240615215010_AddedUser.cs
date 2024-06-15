using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBD11.Migrations
{
    /// <inheritdoc />
    public partial class AddedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenExp = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPresctiprion",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 6, 15, 23, 50, 10, 344, DateTimeKind.Local).AddTicks(3272), new DateTime(2024, 7, 15, 23, 50, 10, 344, DateTimeKind.Local).AddTicks(3312) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPresctiprion",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 6, 15, 23, 50, 10, 344, DateTimeKind.Local).AddTicks(3316), new DateTime(2024, 7, 15, 23, 50, 10, 344, DateTimeKind.Local).AddTicks(3317) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPresctiprion",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 6, 15, 22, 34, 57, 0, DateTimeKind.Local).AddTicks(1195), new DateTime(2024, 7, 15, 22, 34, 57, 0, DateTimeKind.Local).AddTicks(1238) });

            migrationBuilder.UpdateData(
                table: "Prescriptions",
                keyColumn: "IdPresctiprion",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2024, 6, 15, 22, 34, 57, 0, DateTimeKind.Local).AddTicks(1242), new DateTime(2024, 7, 15, 22, 34, 57, 0, DateTimeKind.Local).AddTicks(1244) });
        }
    }
}
