using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Steam.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Providers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFrends_Users_friend_id",
                table: "UserFrends");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFrends_Users_user_id",
                table: "UserFrends");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFrends",
                table: "UserFrends");

            migrationBuilder.RenameTable(
                name: "UserFrends",
                newName: "UserFriends");

            migrationBuilder.RenameIndex(
                name: "IX_UserFrends_friend_id",
                table: "UserFriends",
                newName: "IX_UserFriends_friend_id");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Tags",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Genres",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFriends",
                table: "UserFriends",
                columns: new[] { "user_id", "friend_id" });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserProviders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    provider_id = table.Column<int>(type: "int", nullable: false),
                    number_provider = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProviders", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserProviders_Provider_provider_id",
                        column: x => x.provider_id,
                        principalTable: "Provider",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProviders_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "RPG" },
                    { 4, "Strategy" },
                    { 5, "Simulation" },
                    { 6, "Sports" },
                    { 7, "Puzzle" },
                    { 8, "Racing" }
                });

            migrationBuilder.InsertData(
                table: "Provider",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Google" },
                    { 2, "Facebook" },
                    { 3, "Apple" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Multiplayer" },
                    { 2, "Singleplayer" },
                    { 3, "Co-op" },
                    { 4, "Open World" },
                    { 5, "Story Rich" },
                    { 6, "Indie" },
                    { 7, "VR" },
                    { 8, "Early Access" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_name",
                table: "Tags",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_name",
                table: "Genres",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Provider_name",
                table: "Provider",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProviders_provider_id_number_provider",
                table: "UserProviders",
                columns: new[] { "provider_id", "number_provider" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProviders_user_id_provider_id",
                table: "UserProviders",
                columns: new[] { "user_id", "provider_id" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_Users_friend_id",
                table: "UserFriends",
                column: "friend_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFriends_Users_user_id",
                table: "UserFriends",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_Users_friend_id",
                table: "UserFriends");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFriends_Users_user_id",
                table: "UserFriends");

            migrationBuilder.DropTable(
                name: "UserProviders");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropIndex(
                name: "IX_Tags_name",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Genres_name",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFriends",
                table: "UserFriends");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.RenameTable(
                name: "UserFriends",
                newName: "UserFrends");

            migrationBuilder.RenameIndex(
                name: "IX_UserFriends_friend_id",
                table: "UserFrends",
                newName: "IX_UserFrends_friend_id");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFrends",
                table: "UserFrends",
                columns: new[] { "user_id", "friend_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFrends_Users_friend_id",
                table: "UserFrends",
                column: "friend_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFrends_Users_user_id",
                table: "UserFrends",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
