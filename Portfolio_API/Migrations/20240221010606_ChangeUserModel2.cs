using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "bcaf7b08-8505-427f-9910-fc35e3591e14", "igormarcucci1@gmail.com", true, false, null, "IGORMARCUCCI1@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEFwotEdftQ2S4vZ5susmLR74e9+REWoqJg+ecwmPdqccJtUHVd+CJqmkl3kSS9D+fw==", null, false, "d0445cb5-b30c-4a4c-bfa1-da8442fc1af2", false, "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "36c6fcaa-b4bc-44c7-a062-0b6db419cb70", "igormarcucci1@gmail.com", true, false, null, "IGORMARCUCCI1@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEOwNFnOeA3b0suL1hyfem/zhobtQ4xHRQnO92WEHV68Sl8OyVVrEx8XZnsabVLf16w==", null, false, "667b6dee-f0e0-43ae-b852-9fca0ad53cc1", false, "admin" });
        }
    }
}
