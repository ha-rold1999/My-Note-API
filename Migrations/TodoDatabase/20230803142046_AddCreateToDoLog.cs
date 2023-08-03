using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace My_Note_API.Migrations.TodoDatabase
{
    /// <inheritdoc />
    public partial class AddCreateToDoLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Create_ToDo_Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ToDo_IdId = table.Column<int>(type: "integer", nullable: false),
                    Date_Id = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Create_ToDo_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Create_ToDo_Logs_ToDos_ToDo_IdId",
                        column: x => x.ToDo_IdId,
                        principalTable: "ToDos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Create_ToDo_Logs_ToDo_IdId",
                table: "Create_ToDo_Logs",
                column: "ToDo_IdId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Create_ToDo_Logs");
        }
    }
}
