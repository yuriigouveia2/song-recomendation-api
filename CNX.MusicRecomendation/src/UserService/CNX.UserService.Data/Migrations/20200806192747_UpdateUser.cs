using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CNX.UserService.Repository.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalNotes_AspNetUsers_UserId",
                table: "PersonalNotes");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "PersonalNotes",
                newName: "note");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "PersonalNotes",
                newName: "deleted");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PersonalNotes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PersonalNotes",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "PersonalNotes",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "PersonalNotes",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "PersonalNotes",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_PersonalNotes_UserId",
                table: "PersonalNotes",
                newName: "IX_PersonalNotes_user_id");

            migrationBuilder.AlterColumn<string>(
                name: "note",
                table: "PersonalNotes",
                type: "character varying",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "deleted",
                table: "PersonalNotes",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<Guid>(
                name: "user_id",
                table: "PersonalNotes",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "PersonalNotes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                table: "PersonalNotes",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "PersonalNotes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalNotes_AspNetUsers_user_id",
                table: "PersonalNotes",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalNotes_AspNetUsers_user_id",
                table: "PersonalNotes");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "note",
                table: "PersonalNotes",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "deleted",
                table: "PersonalNotes",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "PersonalNotes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "PersonalNotes",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "PersonalNotes",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                table: "PersonalNotes",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "PersonalNotes",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_PersonalNotes_user_id",
                table: "PersonalNotes",
                newName: "IX_PersonalNotes_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "PersonalNotes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying");

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "PersonalNotes",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "PersonalNotes",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "PersonalNotes",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedAt",
                table: "PersonalNotes",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "PersonalNotes",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalNotes_AspNetUsers_UserId",
                table: "PersonalNotes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
