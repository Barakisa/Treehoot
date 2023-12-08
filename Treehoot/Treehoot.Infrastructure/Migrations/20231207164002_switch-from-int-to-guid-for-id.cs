using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Treehoot.Infrastructure.Helpers;

#nullable disable

namespace Treehoot.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class switchfrominttoguidforid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Converter method class. This is also used in the following migration for the Answer table
            var converter = new ConvertIntToGuid();

            // Add extention for "uuid_generate_v4()" default uuid generator
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS \"uuid-ossp\";");

            // Convert Quiz and its children (Stage)
            converter.Convert(migrationBuilder, true, "Quiz", new string[] { "Stage" });

            // Convert Stage and its children (Question)
            converter.Convert(migrationBuilder, true, "Stage", new string[] { "Question" });

            // Convert Question and its children (Answer)
            converter.Convert(migrationBuilder, true, "Question", new string[] { "Answer" });
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Converter method class. This is also used in the following migration for the Answer table
            var converter = new ConvertIntToGuid();

            // Revert the conversion for Question and its children (Answer)
            converter.Convert(migrationBuilder, false, "Question", new string[] { "Answer" });

            // Revert the conversion for Stage and its children (Question)
            converter.Convert(migrationBuilder, false, "Stage", new string[] { "Question" });

            // Revert the conversion for Quiz and its children (Stage)
            converter.Convert(migrationBuilder, false, "Quiz", new string[] { "Stage" });

            // Remove extention for "uuid_generate_v4()" default uuid generator
            migrationBuilder.Sql("DROP EXTENSION IF EXISTS \"uuid-ossp\";");

            // Note: The order is reversed compared to the Up method

            
        }

    }
}
