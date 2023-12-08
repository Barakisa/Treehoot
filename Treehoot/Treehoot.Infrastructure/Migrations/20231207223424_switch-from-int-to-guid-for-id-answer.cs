using Microsoft.EntityFrameworkCore.Migrations;
using Treehoot.Infrastructure.Helpers;

#nullable disable

namespace Treehoot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class switchfrominttoguidforidanswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Converter method class. This is also used in the previous migration for the Quiz, Stage, Question tables
            var converter = new ConvertIntToGuid();

            // Convert Answer
            converter.Convert(migrationBuilder, true, "Answer", new string[] { });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Converter method class. This is also used in the previous migration for the Quiz, Stage, Question tables
            var converter = new ConvertIntToGuid();

            // Revert the conversion for Answer
            converter.Convert(migrationBuilder, true, "Answer", new string[] { });
        }

    }
}
