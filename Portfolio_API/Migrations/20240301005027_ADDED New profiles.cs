using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfolio_API.Migrations
{
    /// <inheritdoc />
    public partial class ADDEDNewprofiles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c643e81f-5f69-42bf-b30c-d470f4c6a590", "AQAAAAIAAYagAAAAEKFRtDHA1J4Id+LaRWZQcKmoPAW+Mqxm2P4oP/Vx99XZ+LkuJkazn/Qy7SfpAeruXQ==", "8a0b2edd-ae07-4329-b882-52ed887f6a17" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a928b533-83d1-4418-b07a-76e787d1738c", "AQAAAAIAAYagAAAAEMNoswaWKel3615K9eB+QKlUR50GwjDJUFzX1+yQnG/1JDyk8m2Y9waMtmkLKOEYSQ==", "e480f439-44a3-4b05-8983-e974d8aef093" });
        }
    }
}
