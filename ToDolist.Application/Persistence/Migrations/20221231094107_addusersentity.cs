using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addusersentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userTokens",
                schema: "identity",
                table: "userTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userClaims",
                schema: "identity",
                table: "userClaims");

            migrationBuilder.RenameTable(
                name: "userTokens",
                schema: "identity",
                newName: "UserTokens",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "userClaims",
                schema: "identity",
                newName: "UserClaims",
                newSchema: "identity");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                schema: "identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                schema: "identity",
                table: "UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserClaims",
                schema: "identity",
                table: "UserClaims",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                schema: "identity",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserClaims",
                schema: "identity",
                table: "UserClaims");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Lastname",
                schema: "identity",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "identity",
                newName: "userTokens",
                newSchema: "identity");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "identity",
                newName: "userClaims",
                newSchema: "identity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userTokens",
                schema: "identity",
                table: "userTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_userClaims",
                schema: "identity",
                table: "userClaims",
                column: "Id");
        }
    }
}
