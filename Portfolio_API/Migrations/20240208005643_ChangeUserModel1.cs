using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserModel1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70d74984-b04f-4630-aad2-9759eee05634", "AQAAAAIAAYagAAAAEBoWniaia6wl+KeY0V3719mX7SzB3q/5hZ3RMB+mEiNbTPnBz4MXq2l8FOYsP/ZBHQ==", "e3348c3b-3af4-4de9-8edb-fdd617771c0e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98c65a23-1017-441b-94ab-386eebc923ed", "AQAAAAIAAYagAAAAEJr5ojdEgsVFbIcyQhyDWIgzVPyODDbuPJBcac5XG4b3iMKp2a9pf8UDpOzcdc9rWw==", "fc2d3383-7de5-4e15-adca-04bec72ceb61" });
        }
    }
}
