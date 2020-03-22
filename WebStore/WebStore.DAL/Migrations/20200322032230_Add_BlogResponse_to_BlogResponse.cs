using Microsoft.EntityFrameworkCore.Migrations;

namespace WebStore.DAL.Migrations
{
    public partial class Add_BlogResponse_to_BlogResponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BlogResponses_BlogResponseId",
                table: "BlogResponses",
                column: "BlogResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogResponses_BlogResponses_BlogResponseId",
                table: "BlogResponses",
                column: "BlogResponseId",
                principalTable: "BlogResponses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogResponses_BlogResponses_BlogResponseId",
                table: "BlogResponses");

            migrationBuilder.DropIndex(
                name: "IX_BlogResponses_BlogResponseId",
                table: "BlogResponses");
        }
    }
}
