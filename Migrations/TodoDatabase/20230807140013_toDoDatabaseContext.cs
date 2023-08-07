using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace My_Note_API.Migrations.TodoDatabase
{
    /// <inheritdoc />
    public partial class toDoDatabaseContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "archive_todo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    todo_id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    todo_goal = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    archive_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_archive_todo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "todo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    goal = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todo", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "create_todo_log",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ToDo_IdId = table.Column<int>(type: "integer", nullable: false),
                    date_id = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_create_todo_log", x => x.id);
                    table.ForeignKey(
                        name: "FK_create_todo_log_todo_ToDo_IdId",
                        column: x => x.ToDo_IdId,
                        principalTable: "todo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "update_logger",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ToDoId = table.Column<int>(type: "integer", nullable: false),
                    log = table.Column<string>(type: "text", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_update_logger", x => x.id);
                    table.ForeignKey(
                        name: "FK_update_logger_todo_ToDoId",
                        column: x => x.ToDoId,
                        principalTable: "todo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_create_todo_log_ToDo_IdId",
                table: "create_todo_log",
                column: "ToDo_IdId");

            migrationBuilder.CreateIndex(
                name: "IX_update_logger_ToDoId",
                table: "update_logger",
                column: "ToDoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "archive_todo");

            migrationBuilder.DropTable(
                name: "create_todo_log");

            migrationBuilder.DropTable(
                name: "update_logger");

            migrationBuilder.DropTable(
                name: "todo");
        }
    }
}
