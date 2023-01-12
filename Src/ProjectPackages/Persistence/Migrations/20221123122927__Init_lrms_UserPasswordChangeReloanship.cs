using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class _Init_lrms_UserPasswordChangeReloanship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_passwords_users_user_id",
                table: "Passwords");

            migrationBuilder.DropIndex(
                name: "ix_passwords_user_id",
                table: "Passwords");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "Passwords");

            migrationBuilder.CreateIndex(
                name: "ix_users_password_id",
                table: "Users",
                column: "PasswordId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_users_passwords_password_id",
                table: "Users",
                column: "PasswordId",
                principalTable: "Passwords",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_users_passwords_password_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "ix_users_password_id",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "Passwords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_passwords_user_id",
                table: "Passwords",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_passwords_users_user_id",
                table: "Passwords",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
