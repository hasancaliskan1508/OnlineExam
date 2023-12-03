using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToDoTitle",
                table: "ToDoLists",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ToDoStatus",
                table: "ToDoLists",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ToDoId",
                table: "ToDoLists",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ToDoLists",
                newName: "ToDoTitle");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "ToDoLists",
                newName: "ToDoStatus");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ToDoLists",
                newName: "ToDoId");
        }
    }
}
