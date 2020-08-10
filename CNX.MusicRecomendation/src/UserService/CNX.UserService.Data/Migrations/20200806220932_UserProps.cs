using Microsoft.EntityFrameworkCore.Migrations;

namespace CNX.UserService.Repository.Migrations
{
    public partial class UserProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "normalized_user_name",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "security_stamp",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_name",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "security_stamp",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "user_name",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "normalized_user_name",
                table: "AspNetUsers",
                type: "character varying",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
