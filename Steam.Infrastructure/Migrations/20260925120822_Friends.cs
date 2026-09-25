using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Steam.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Friends : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "token",
                table: "RefreshTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "game_id",
                table: "Medias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserFrends",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    friend_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFrends", x => new { x.user_id, x.friend_id });
                    table.CheckConstraint("CK_UserFrends_NoSelfFriendship", "[user_id] <> [friend_id]");
                    table.ForeignKey(
                        name: "FK_UserFrends_Users_friend_id",
                        column: x => x.friend_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserFrends_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_email",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_username",
                table: "Users",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_token",
                table: "RefreshTokens",
                column: "token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_game_id",
                table: "Medias",
                column: "game_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserFrends_friend_id",
                table: "UserFrends",
                column: "friend_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Games_game_id",
                table: "Medias",
                column: "game_id",
                principalTable: "Games",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Games_game_id",
                table: "Medias");

            migrationBuilder.DropTable(
                name: "UserFrends");

            migrationBuilder.DropIndex(
                name: "IX_Users_email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_username",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_RefreshTokens_token",
                table: "RefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_Medias_game_id",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "game_id",
                table: "Medias");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "token",
                table: "RefreshTokens",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
