using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Portfolio_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeModelsandaddservices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Users_UserId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Langs_Jobs_JobModelId",
                table: "Langs");

            migrationBuilder.RenameColumn(
                name: "JobModelId",
                table: "Langs",
                newName: "ProjectModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Langs_JobModelId",
                table: "Langs",
                newName: "IX_Langs_ProjectModelId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Jobs",
                newName: "LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_UserId",
                table: "Jobs",
                newName: "IX_Jobs_LanguageId");

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    JobId = table.Column<int>(type: "integer", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Link = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Projects_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LanguageId = table.Column<int>(type: "integer", nullable: true),
                    LangId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Topics_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Techs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    TopicId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Techs_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7940b9db-4a45-45d5-ac1f-422aace9deb6", "AQAAAAIAAYagAAAAECEJaPZw1yxqChojEC9p210aE7G8lXePJRKb/ABLDzsmEuQHq1weVuFKjs3QqKsUaQ==", "f619319e-f563-47a4-9eac-ed0a221688bf" });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_JobId",
                table: "Projects",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_LanguageId",
                table: "Projects",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Techs_TopicId",
                table: "Techs",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_LangId",
                table: "Topics",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_LanguageId",
                table: "Topics",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Languages_LanguageId",
                table: "Jobs",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Langs_Projects_ProjectModelId",
                table: "Langs",
                column: "ProjectModelId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Languages_LanguageId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Langs_Projects_ProjectModelId",
                table: "Langs");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Techs");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.RenameColumn(
                name: "ProjectModelId",
                table: "Langs",
                newName: "JobModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Langs_ProjectModelId",
                table: "Langs",
                newName: "IX_Langs_JobModelId");

            migrationBuilder.RenameColumn(
                name: "LanguageId",
                table: "Jobs",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_LanguageId",
                table: "Jobs",
                newName: "IX_Jobs_UserId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20541f48-a8ee-4a61-a2a5-b38336d31e8d", "AQAAAAIAAYagAAAAEEX19OMXCAJY05xsmmTkbt88EzdgYMkheq5kDGSh34ttTNBdhOpIDqSY4W5wMFYRgg==", "f2e67f98-c1a6-4e95-924c-48f215e48813" });

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Users_UserId",
                table: "Jobs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Langs_Jobs_JobModelId",
                table: "Langs",
                column: "JobModelId",
                principalTable: "Jobs",
                principalColumn: "Id");
        }
    }
}
