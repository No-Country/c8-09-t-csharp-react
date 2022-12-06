using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CohorteApi.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Newsletters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Newsletters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSubscribed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrontPageImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Venue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsShowed = table.Column<bool>(type: "bit", nullable: false),
                    IsBanned = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Review_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Section",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableSeats = table.Column<int>(type: "int", nullable: false),
                    TotalSeats = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "100e66ac-ecf3-414f-aa2f-c342bedb0331", "2", "User", "USER" },
                    { "e0238212-ada9-40a9-bcf0-587347f6ad9a", "1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "07c2bb53-5e7f-498e-88e7-e6f42e9be447", 0, "4df1368e-39b0-4c55-bc5c-d2bf4b1037d8", "nadir@mailinator.com", false, false, null, "NADIR@MAILINATOR.COM", "NADIR", "AQAAAAEAACcQAAAAEKGnf/vao/BPqyRGaoO/o00AupzpO/1UMjNZTzpQsaeXBFCMg9lO2qxDrMOmddyA4g==", null, false, "ab7cd2ff-ab4d-4600-b364-1cc6b246615c", false, "nadir" },
                    { "1483b6b3-a5f0-42f6-b9a7-f3980c5a8dec", 0, "03f27db4-e59c-45ad-8250-f60d0793d80c", "alex@mailinator.com", false, false, null, "ALEX@MAILINATOR.COM", "ALEX", "AQAAAAEAACcQAAAAEHyrkhwIkVGQptGR5yStsnPWZY5G5HqiSQ6npOWm6AQ5e5uOlGYUPrPNDwKmntuNjQ==", null, false, "82d5c1ba-f8d4-4cd5-a84d-5a0d4aa9f347", false, "alex" },
                    { "213bcaca-8cd3-405a-8961-985b3d71b43b", 0, "e657f0ea-51f0-4266-ae14-12e7e7f9c191", "d@mailinator.com", false, false, null, "D@MAILINATOR.COM", "D", "AQAAAAEAACcQAAAAEL+lEUJEuqjUXGAbTYnlcgifZfrxJqW6iJmqRPyXLKetsz1x+9/BIf7eM+3ghT4U7w==", null, false, "b4d9f10b-626b-4659-9c0a-fc13650dcae4", false, "d" },
                    { "40867f0b-de28-470e-bace-eba0a7be5577", 0, "75a5a5eb-0f9a-4fda-999f-f7d69fb15469", "max@mailinator.com", false, false, null, "MAX@MAILINATOR.COM", "MAX", "AQAAAAEAACcQAAAAEBj12kMBxTchb/PoT1LJnXggj0xz7gEi5BsUTM1HxKPl9bZdqjNtEvtvCn/nrL6Agw==", null, false, "d59f18e9-32c0-45ee-ab0e-9586faf44b44", false, "max" },
                    { "76c1bcd6-35f6-475b-be0e-d99a6f1327aa", 0, "6e26f274-5855-49d0-9bfc-2552f2095acf", "bel@mailinator.com", false, false, null, "BEL@MAILINATOR.COM", "BEL", "AQAAAAEAACcQAAAAEGPHAFbJcYh0oZRpvDjecVXNYd4aLtt8nQ8e1danX7ud7PVzUiQDlkEyzQ75M/alCg==", null, false, "457b1718-e935-44ae-874e-5cb747871a1d", false, "bel" },
                    { "a00492b9-5aa8-422f-83c4-a87108183324", 0, "c8af0470-1482-407d-831e-b846fab01288", "diego@mailinator.com", false, false, null, "DIEGO@MAILINATOR.COM", "DIEGO", "AQAAAAEAACcQAAAAEKVvA9GtwjdbPs0H9KNZ/znhHVHTBKsHSQtezyQgGH5FbMQCteO8ytbBC5ryzSig8A==", null, false, "a7a9ed8d-52dc-49fa-8486-e1ecccc7bfe8", false, "diego" },
                    { "bcd0f007-ddf1-4e42-8788-4e1a05403681", 0, "624bb4c3-877a-4e5a-b9a7-d016d76f912f", "any@mailinator.com", false, false, null, "ANY@MAILINATOR.COM", "ANY", "AQAAAAEAACcQAAAAEJHqABcRNvYGpGA3qaahM/2GbEB5rVpyiaa8BmxwwSvYjmA7gtYPvKF8ExbdwGhhPQ==", null, false, "eda630c8-0037-4f68-8088-768613413403", false, "any" },
                    { "cb0ebf82-fe6d-4638-9b94-353f97239554", 0, "16723d32-06e9-4b34-a2b3-bbbb1710951d", "manuel@mailinator.com", false, false, null, "MANUEL@MAILINATOR.COM", "MANUEL", "AQAAAAEAACcQAAAAEFZIcLkxgXOra2gLBE/2KZM8ZgMUGM4kcLVjw9HCbzQSn/uWbj8ykVfRniD29X3gTg==", null, false, "8ac4fe76-6349-45df-a610-b342a1c84c68", false, "manuel" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Musica" },
                    { 2, null, null, "Familiar" },
                    { 3, null, null, "Deporte" },
                    { 4, null, null, "Seminarios" },
                    { 5, null, null, "Cursos y Talleres" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "DateSubscribed", "Email", "IsActive" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "test@mailinator.com", true },
                    { 2, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "test2@mailinator.com", true },
                    { 3, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "test3@mailinator.com", true },
                    { 4, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "test4@mailinator.com", true },
                    { 5, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "test5@mailinator.com", true },
                    { 6, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "test6@mailinator.com", true },
                    { 7, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "test7@mailinator.com", true },
                    { 8, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "test8@mailinator.com", true }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "100e66ac-ecf3-414f-aa2f-c342bedb0331", "07c2bb53-5e7f-498e-88e7-e6f42e9be447" },
                    { "100e66ac-ecf3-414f-aa2f-c342bedb0331", "1483b6b3-a5f0-42f6-b9a7-f3980c5a8dec" },
                    { "100e66ac-ecf3-414f-aa2f-c342bedb0331", "213bcaca-8cd3-405a-8961-985b3d71b43b" },
                    { "100e66ac-ecf3-414f-aa2f-c342bedb0331", "40867f0b-de28-470e-bace-eba0a7be5577" },
                    { "100e66ac-ecf3-414f-aa2f-c342bedb0331", "76c1bcd6-35f6-475b-be0e-d99a6f1327aa" },
                    { "100e66ac-ecf3-414f-aa2f-c342bedb0331", "a00492b9-5aa8-422f-83c4-a87108183324" },
                    { "100e66ac-ecf3-414f-aa2f-c342bedb0331", "bcd0f007-ddf1-4e42-8788-4e1a05403681" },
                    { "100e66ac-ecf3-414f-aa2f-c342bedb0331", "cb0ebf82-fe6d-4638-9b94-353f97239554" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_EventId",
                table: "Review",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserId",
                table: "Review",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Section_EventId",
                table: "Section",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Newsletters");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Section");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
