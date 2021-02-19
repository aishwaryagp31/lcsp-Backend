using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectBackendAPI.Migrations
{
    public partial class TicketEntityModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentId",
                table: "Tickets",
                type: "nvarchar(5)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Tickets");
        }
    }
}
