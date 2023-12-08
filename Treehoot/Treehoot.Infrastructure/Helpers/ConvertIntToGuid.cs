using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treehoot.Infrastructure.Helpers
{
    internal class ConvertIntToGuid
    {

        /// Todo: Move to Helpers ConvertIntToGuid properly
        /// There is a copy in th previous migration (switch-from-int-to-guid-for-id)
        public void Convert(MigrationBuilder migrationBuilder, bool toGuid, string parent, string[] children)
        {
            var newIdType = toGuid ? "uuid" : "int";
            var defaultValueSql = toGuid ? "uuid_generate_v4()" : null;

            // Step 1: Add a new column to the parent table
            migrationBuilder.AddColumn<Guid>(
                name: "NewId",
                table: parent,
                type: newIdType,
                nullable: false,
                defaultValueSql: defaultValueSql);

            // Step 2: Update child tables
            foreach (var child in children)
            {
                // 2.1: Drop foreign key constraints and indexes
                migrationBuilder.DropForeignKey(
                    name: $"FK_{child}_{parent}_{parent}Id",
                    table: child);
                migrationBuilder.DropIndex(
                    name: $"IX_{child}_{parent}Id",
                    table: child);

                // 2.2: Rename existing foreign key column
                migrationBuilder.RenameColumn(
                    name: $"{parent}Id",
                    table: child,
                    newName: $"old_{parent}Id");

                // 2.3: Add new foreign key column
                migrationBuilder.AddColumn<Guid>(
                    name: $"{parent}Id",
                    table: child,
                    type: newIdType,
                    //Initially nullable, but will be not nullable on 2.5 alter column
                    nullable: true);

                // 2.4: Update new foreign key column with values. I  need the many quotes, because the case sensitivity is shit 
                migrationBuilder.Sql(
                    $"UPDATE \"{child}\" SET \"{parent}Id\" = (SELECT \"NewId\" FROM \"{parent}\" WHERE \"{parent}\".\"Id\" = \"{child}\".\"old_{parent}Id\")");

                // 2.5: Make foreign key column nullable
                migrationBuilder.AlterColumn<Guid>(
                    name: $"{parent}Id",
                    table: $"{child}",
                    nullable: false);

                // 2.5: Drop the old foreign key column
                migrationBuilder.DropColumn(
                    name: $"old_{parent}Id",
                    table: child);
            }

            // Step 3: Update the parent table
            // 3.1: Drop the old primary key
            migrationBuilder.DropPrimaryKey(
                name: $"PK_{parent}",
                table: parent);

            // 3.2: Drop the old Id column
            migrationBuilder.DropColumn(
                name: "Id",
                table: parent);

            // 3.3: Rename new Id column
            migrationBuilder.RenameColumn(
                name: "NewId",
                table: parent,
                newName: "Id");

            // 3.4: Add new primary key
            migrationBuilder.AddPrimaryKey(
                name: $"PK_{parent}",
                table: parent,
                column: "Id");

            // Step 4: Re-create foreign key constraints and indexes in child tables
            foreach (var child in children)
            {
                migrationBuilder.CreateIndex(
                    name: $"IX_{child}_{parent}Id",
                    table: child,
                    column: $"{parent}Id");
                migrationBuilder.AddForeignKey(
                    name: $"FK_{child}_{parent}_{parent}Id",
                    table: child,
                    column: $"{parent}Id",
                    principalTable: parent,
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            }
        }

    }
}
