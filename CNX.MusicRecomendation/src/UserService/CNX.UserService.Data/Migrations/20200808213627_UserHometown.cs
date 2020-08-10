using Microsoft.EntityFrameworkCore.Migrations;

namespace CNX.UserService.Repository.Migrations
{
    public partial class UserHometown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "hometown_id",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hometown_id",
                table: "AspNetUsers");
        }
    }
}
