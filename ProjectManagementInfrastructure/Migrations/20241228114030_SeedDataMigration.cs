using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectManagementInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Domain = table.Column<string>(type: "text", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TentativeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TeamId = table.Column<int>(type: "integer", nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Country", "CreatedBy", "CreatedOn", "Email", "IsActive", "IsDeleted", "Location", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "USA", "Admin", new DateTime(2024, 12, 28, 11, 40, 29, 619, DateTimeKind.Utc).AddTicks(5470), "contact@abccorp.com", true, false, "New York", "ABC Corp", "123-456-7890" },
                    { 2, "UK", "Admin", new DateTime(2024, 12, 28, 11, 40, 29, 619, DateTimeKind.Utc).AddTicks(6021), "info@xyzltd.com", true, false, "London", "XYZ Pvt Ltd", "987-654-3210" },
                    { 3, "India", "Admin", new DateTime(2024, 12, 28, 11, 40, 29, 619, DateTimeKind.Utc).AddTicks(6024), "hello@techinnovators.in", true, false, "Mumbai", "Tech Innovators", "555-555-5555" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "CreatedBy", "CreatedOn", "IsActive", "IsDeleted", "LastUpdatedBy", "LastUpdatedOn", "Location", "Name", "Size" },
                values: new object[,]
                {
                    { 1, "Admin", new DateTime(2024, 12, 28, 11, 40, 29, 618, DateTimeKind.Utc).AddTicks(7489), true, false, "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hyderabad", "Development", 10 },
                    { 2, "Admin", new DateTime(2024, 12, 28, 11, 40, 29, 618, DateTimeKind.Utc).AddTicks(8009), true, false, "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bangalore", "Marketing", 6 },
                    { 3, "Admin", new DateTime(2024, 12, 28, 11, 40, 29, 618, DateTimeKind.Utc).AddTicks(8012), false, false, "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chennai", "Design", 5 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ClientId", "CreatedBy", "CreatedOn", "Domain", "IsActive", "IsDeleted", "LastUpdated", "LastUpdatedBy", "Name", "ReleaseDate", "TeamId", "TentativeDate" },
                values: new object[,]
                {
                    { 1, 1, "Admin", new DateTime(2024, 12, 28, 11, 40, 29, 620, DateTimeKind.Utc).AddTicks(7363), "Software Development", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "Project Zen", new DateTime(2025, 2, 28, 17, 10, 29, 619, DateTimeKind.Local).AddTicks(7249), 1, new DateTime(2025, 3, 28, 17, 10, 29, 620, DateTimeKind.Local).AddTicks(6263) },
                    { 2, 2, "Admin", new DateTime(2024, 12, 28, 11, 40, 29, 620, DateTimeKind.Utc).AddTicks(7873), "Marketing Campaign", true, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "Project Lamda", new DateTime(2025, 1, 28, 17, 10, 29, 620, DateTimeKind.Local).AddTicks(7866), 2, new DateTime(2025, 2, 28, 17, 10, 29, 620, DateTimeKind.Local).AddTicks(7870) },
                    { 3, 3, "Admin", new DateTime(2024, 12, 28, 11, 40, 29, 620, DateTimeKind.Utc).AddTicks(7877), "Product Design", false, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "Project CAT", new DateTime(2025, 4, 28, 17, 10, 29, 620, DateTimeKind.Local).AddTicks(7875), 3, new DateTime(2025, 5, 28, 17, 10, 29, 620, DateTimeKind.Local).AddTicks(7875) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TeamId",
                table: "Projects",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
