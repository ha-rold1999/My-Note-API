using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Note_API.Migrations.TodoDatabase
{
    /// <inheritdoc />
    public partial class AddAttributeInUpdateLogTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToDoId",
                table: "UpDate_ToDo_Logs",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UpDate_ToDo_Logs_ToDoId",
                table: "UpDate_ToDo_Logs",
                column: "ToDoId");

            migrationBuilder.AddForeignKey(
                name: "FK_UpDate_ToDo_Logs_ToDos_ToDoId",
                table: "UpDate_ToDo_Logs",
                column: "ToDoId",
                principalTable: "ToDos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpDate_ToDo_Logs_ToDos_ToDoId",
                table: "UpDate_ToDo_Logs");

            migrationBuilder.DropIndex(
                name: "IX_UpDate_ToDo_Logs_ToDoId",
                table: "UpDate_ToDo_Logs");

            migrationBuilder.DropColumn(
                name: "ToDoId",
                table: "UpDate_ToDo_Logs");
        }
    }
}
