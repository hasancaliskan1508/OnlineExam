using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineExam.Migrations
{
    /// <inheritdoc />
    public partial class newMig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_AspNetUsers_AppUserId",
                table: "ExamResults");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "ExamResults",
                newName: "AppUserID");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResults_AppUserId",
                table: "ExamResults",
                newName: "IX_ExamResults_AppUserID");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserID",
                table: "ExamResults",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_AspNetUsers_AppUserID",
                table: "ExamResults",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_AspNetUsers_AppUserID",
                table: "ExamResults");

            migrationBuilder.RenameColumn(
                name: "AppUserID",
                table: "ExamResults",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResults_AppUserID",
                table: "ExamResults",
                newName: "IX_ExamResults_AppUserId");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "ExamResults",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_AspNetUsers_AppUserId",
                table: "ExamResults",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
