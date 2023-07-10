using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Note_API.Migrations
{
    /// <inheritdoc />
    public partial class EditAttributaNameToTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Code",
                newName: "Title");
        }
    }
}
