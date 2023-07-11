using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Note_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAttributeNameToIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "steps",
                table: "Note",
                newName: "items");

            migrationBuilder.RenameColumn(
                name: "codes",
                table: "Code",
                newName: "items");
        }
    }
}
