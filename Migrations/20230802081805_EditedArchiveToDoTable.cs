using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My_Note_API.Migrations
{
    /// <inheritdoc />
    public partial class EditedArchiveToDoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Archive_ToDos_ToDos_ToDoId",
                table: "Archive_ToDos");

            migrationBuilder.DropIndex(
                name: "IX_Archive_ToDos_ToDoId",
                table: "Archive_ToDos");

            migrationBuilder.RenameColumn(
                name: "ToDoId",
                table: "Archive_ToDos",
                newName: "ToDo_Status");

            migrationBuilder.AddColumn<string>(
                name: "ToDo_Description",
                table: "Archive_ToDos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDo_Goal",
                table: "Archive_ToDos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ToDo_Id",
                table: "Archive_ToDos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToDo_Priority",
                table: "Archive_ToDos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Todo_Title",
                table: "Archive_ToDos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToDo_Description",
                table: "Archive_ToDos");

            migrationBuilder.DropColumn(
                name: "ToDo_Goal",
                table: "Archive_ToDos");

            migrationBuilder.DropColumn(
                name: "ToDo_Id",
                table: "Archive_ToDos");

            migrationBuilder.DropColumn(
                name: "ToDo_Priority",
                table: "Archive_ToDos");

            migrationBuilder.DropColumn(
                name: "Todo_Title",
                table: "Archive_ToDos");

            migrationBuilder.RenameColumn(
                name: "ToDo_Status",
                table: "Archive_ToDos",
                newName: "ToDoId");

            migrationBuilder.CreateIndex(
                name: "IX_Archive_ToDos_ToDoId",
                table: "Archive_ToDos",
                column: "ToDoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Archive_ToDos_ToDos_ToDoId",
                table: "Archive_ToDos",
                column: "ToDoId",
                principalTable: "ToDos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
