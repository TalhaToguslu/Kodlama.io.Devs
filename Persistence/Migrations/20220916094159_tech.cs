using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class tech : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramingLanguageTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProgramingLanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramingLanguageTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramingLanguageTechnologies_ProgramingLanguages_ProgramingLanguageId",
                        column: x => x.ProgramingLanguageId,
                        principalTable: "ProgramingLanguages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProgramingLanguageTechnologies",
                columns: new[] { "Id", "Name", "ProgramingLanguageId" },
                values: new object[] { 1, ".Net Core", 3 });

            migrationBuilder.InsertData(
                table: "ProgramingLanguageTechnologies",
                columns: new[] { "Id", "Name", "ProgramingLanguageId" },
                values: new object[] { 2, ".Net MVC", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramingLanguageTechnologies_ProgramingLanguageId",
                table: "ProgramingLanguageTechnologies",
                column: "ProgramingLanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramingLanguageTechnologies");
        }
    }
}
