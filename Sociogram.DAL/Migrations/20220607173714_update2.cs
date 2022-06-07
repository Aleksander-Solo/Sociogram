using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sociogram.DAL.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizStudentConst");

            migrationBuilder.DropColumn(
                name: "ClassName",
                table: "Quizzes");

            migrationBuilder.AddColumn<int>(
                name: "ClassSId",
                table: "StudentConst",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClassSId",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ClassS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassS_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_StudentConst_ClassSId",
                table: "StudentConst",
                column: "ClassSId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_ClassSId",
                table: "Quizzes",
                column: "ClassSId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassS_TeacherId",
                table: "ClassS",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_ClassS_ClassSId",
                table: "Quizzes",
                column: "ClassSId",
                principalTable: "ClassS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentConst_ClassS_ClassSId",
                table: "StudentConst",
                column: "ClassSId",
                principalTable: "ClassS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_ClassS_ClassSId",
                table: "Quizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentConst_ClassS_ClassSId",
                table: "StudentConst");

            migrationBuilder.DropTable(
                name: "ClassS");

            migrationBuilder.DropIndex(
                name: "IX_StudentConst_ClassSId",
                table: "StudentConst");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_ClassSId",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "ClassSId",
                table: "StudentConst");

            migrationBuilder.DropColumn(
                name: "ClassSId",
                table: "Quizzes");

            migrationBuilder.AddColumn<string>(
                name: "ClassName",
                table: "Quizzes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "QuizStudentConst",
                columns: table => new
                {
                    QuizzesId = table.Column<int>(type: "int", nullable: false),
                    StudentsConstId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizStudentConst", x => new { x.QuizzesId, x.StudentsConstId });
                    table.ForeignKey(
                        name: "FK_QuizStudentConst_Quizzes_QuizzesId",
                        column: x => x.QuizzesId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizStudentConst_StudentConst_StudentsConstId",
                        column: x => x.StudentsConstId,
                        principalTable: "StudentConst",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_QuizStudentConst_StudentsConstId",
                table: "QuizStudentConst",
                column: "StudentsConstId");
        }
    }
}
