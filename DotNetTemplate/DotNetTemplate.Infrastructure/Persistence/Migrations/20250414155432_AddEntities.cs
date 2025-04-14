using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetTemplate.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleName = table.Column<string>(type: "text", nullable: false),
                    RoleDescription = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_roles", x => x.Id);
                });

            _ = migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    HashPassword = table.Column<string>(type: "text", nullable: false),
                    AvatarUrl = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RoleId1 = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    _ = table.PrimaryKey("PK_users", x => x.Id);
                    _ = table.UniqueConstraint("AK_users_RoleId", x => x.RoleId);
                    _ = table.ForeignKey(
                        name: "FK_users_roles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            _ = migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "CreatedAt", "RoleDescription", "RoleName", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("62d23b90-186d-49a4-b92b-ec7bf8a97106"), new DateTime(2025, 4, 14, 15, 54, 32, 451, DateTimeKind.Utc).AddTicks(6406), "User role", "User", new DateTime(2025, 4, 14, 15, 54, 32, 451, DateTimeKind.Utc).AddTicks(6407) },
                    { new Guid("77ff9040-f5b2-4706-8536-792dee21ba09"), new DateTime(2025, 4, 14, 15, 54, 32, 451, DateTimeKind.Utc).AddTicks(6371), "Admin role", "Admin", new DateTime(2025, 4, 14, 15, 54, 32, 451, DateTimeKind.Utc).AddTicks(6374) }
                });

            _ = migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email");

            _ = migrationBuilder.CreateIndex(
                name: "IX_users_RoleId1",
                table: "users",
                column: "RoleId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.DropTable(
                name: "users");

            _ = migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
