using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Habitat.DataAccess.Migrations
{
    public partial class AddedTodosToDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "todo",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    event_date_time = table.Column<DateTime>(nullable: false),
                    done = table.Column<bool>(nullable: false),
                    note_text = table.Column<string>(nullable: true),
                    user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todo", x => x.id);
                    table.ForeignKey(
                        name: "FK_todo_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_todo_user_id",
                table: "todo",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "todo");
        }
    }
}
