using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Treehoot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Stage_QuizId",
                table: "Stage",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_StageId",
                table: "Question",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_QuestionId",
                table: "Answer",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Stage_StageId",
                table: "Question",
                column: "StageId",
                principalTable: "Stage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stage_Quiz_QuizId",
                table: "Stage",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Stage_StageId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Stage_Quiz_QuizId",
                table: "Stage");

            migrationBuilder.DropIndex(
                name: "IX_Stage_QuizId",
                table: "Stage");

            migrationBuilder.DropIndex(
                name: "IX_Question_StageId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer");
        }
    }
}
