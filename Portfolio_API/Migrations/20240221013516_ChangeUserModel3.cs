using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserModel3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Jobs",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Jobs",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20541f48-a8ee-4a61-a2a5-b38336d31e8d", "AQAAAAIAAYagAAAAEEX19OMXCAJY05xsmmTkbt88EzdgYMkheq5kDGSh34ttTNBdhOpIDqSY4W5wMFYRgg==", "f2e67f98-c1a6-4e95-924c-48f215e48813" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "StartDate",
                table: "Jobs",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "EndDate",
                table: "Jobs",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bcaf7b08-8505-427f-9910-fc35e3591e14", "AQAAAAIAAYagAAAAEFwotEdftQ2S4vZ5susmLR74e9+REWoqJg+ecwmPdqccJtUHVd+CJqmkl3kSS9D+fw==", "d0445cb5-b30c-4a4c-bfa1-da8442fc1af2" });
        }
    }
}
