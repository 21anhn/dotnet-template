using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetTemplate.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeConfigEFCore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_users_roles_RoleId1",
                table: "users");

            _ = migrationBuilder.DropUniqueConstraint(
                name: "AK_users_RoleId",
                table: "users");

            _ = migrationBuilder.DropIndex(
                name: "IX_users_RoleId1",
                table: "users");

            _ = migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("62d23b90-186d-49a4-b92b-ec7bf8a97106"));

            _ = migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("77ff9040-f5b2-4706-8536-792dee21ba09"));

            _ = migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "users");

            _ = migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "CreatedAt", "RoleDescription", "RoleName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("cc213684-0691-4223-b9e9-2d776c6b8270"), new DateTime(2025, 4, 14, 16, 2, 35, 239, DateTimeKind.Utc).AddTicks(7791), "User role", "User", new DateTime(2025, 4, 14, 16, 2, 35, 239, DateTimeKind.Utc).AddTicks(7792) },
                    { new Guid("e80d3a9d-28b0-4ff3-8655-a9422c0efef0"), new DateTime(2025, 4, 14, 16, 2, 35, 239, DateTimeKind.Utc).AddTicks(7756), "Admin role", "Admin", new DateTime(2025, 4, 14, 16, 2, 35, 239, DateTimeKind.Utc).AddTicks(7759) }
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_users_RoleId",
                table: "users",
                column: "RoleId");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_users_roles_RoleId",
                table: "users",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropForeignKey(
                name: "FK_users_roles_RoleId",
                table: "users");

            _ = migrationBuilder.DropIndex(
                name: "IX_users_RoleId",
                table: "users");

            _ = migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("cc213684-0691-4223-b9e9-2d776c6b8270"));

            _ = migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "Id",
                keyValue: new Guid("e80d3a9d-28b0-4ff3-8655-a9422c0efef0"));

            _ = migrationBuilder.AddColumn<Guid>(
                name: "RoleId1",
                table: "users",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            _ = migrationBuilder.AddUniqueConstraint(
                name: "AK_users_RoleId",
                table: "users",
                column: "RoleId");

            _ = migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "CreatedAt", "RoleDescription", "RoleName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("62d23b90-186d-49a4-b92b-ec7bf8a97106"), new DateTime(2025, 4, 14, 15, 54, 32, 451, DateTimeKind.Utc).AddTicks(6406), "User role", "User", new DateTime(2025, 4, 14, 15, 54, 32, 451, DateTimeKind.Utc).AddTicks(6407) },
                    { new Guid("77ff9040-f5b2-4706-8536-792dee21ba09"), new DateTime(2025, 4, 14, 15, 54, 32, 451, DateTimeKind.Utc).AddTicks(6371), "Admin role", "Admin", new DateTime(2025, 4, 14, 15, 54, 32, 451, DateTimeKind.Utc).AddTicks(6374) }
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_users_RoleId1",
                table: "users",
                column: "RoleId1");

            _ = migrationBuilder.AddForeignKey(
                name: "FK_users_roles_RoleId1",
                table: "users",
                column: "RoleId1",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
