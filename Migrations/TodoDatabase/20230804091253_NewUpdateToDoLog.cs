using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace My_Note_API.Migrations.TodoDatabase
{
    /// <inheritdoc />
    public partial class NewUpdateToDoLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpDate_ToDo_Logs_ToDos_ToDoId",
                table: "UpDate_ToDo_Logs");

            migrationBuilder.AlterColumn<int>(
                name: "ToDoId",
                table: "UpDate_ToDo_Logs",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UpDate_ToDo_Logs_ToDos_ToDoId",
                table: "UpDate_ToDo_Logs",
                column: "ToDoId",
                principalTable: "ToDos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UpDate_ToDo_Logs_ToDos_ToDoId",
                table: "UpDate_ToDo_Logs");

            migrationBuilder.AlterColumn<int>(
                name: "ToDoId",
                table: "UpDate_ToDo_Logs",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_UpDate_ToDo_Logs_ToDos_ToDoId",
                table: "UpDate_ToDo_Logs",
                column: "ToDoId",
                principalTable: "ToDos",
                principalColumn: "Id");
        }
    }
}
