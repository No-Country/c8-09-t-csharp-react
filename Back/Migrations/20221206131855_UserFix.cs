using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CohorteApi.Migrations
{
    public partial class UserFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_AspNetUsers_UserId1",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_UserId1",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Sales");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Sales",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e57fb63-fb07-43b6-b4de-08587879713e", "2", "User", "USER" },
                    { "9c751ded-c072-4e1d-bca5-2e348d57678b", "1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5cf8f0cb-f806-4c48-a3d1-6a00b6debdae", 0, "e8f5e15a-0e4c-404d-ab60-3251ade05cca", "diego@mailinator.com", false, false, null, "DIEGO@MAILINATOR.COM", "DIEGO", "AQAAAAEAACcQAAAAEFyjrybJ/eDOW/Hd9hSR1R43e2JbMZfUtq6JCd2U+p038Rks7xwRCKBYPZ3Zf7PJKg==", null, false, "b730d4ef-ae82-47d4-97de-374df745908b", false, "diego" },
                    { "7af2c5e3-f049-4dc8-b458-5d295276e791", 0, "16d55461-bc7b-48dd-ad07-e49461daa66e", "manuel@mailinator.com", false, false, null, "MANUEL@MAILINATOR.COM", "MANUEL", "AQAAAAEAACcQAAAAEPPHUnJLjx93t3tHNOiJmWs3nFYX03VdFMa9bzmP9rSFz9t/JY7vblKKuMiAjjkH8A==", null, false, "b75e9086-f21c-4f14-a3dd-1873796de082", false, "manuel" },
                    { "7b64ea7d-f893-4023-9b63-18cd10a00f81", 0, "d678e972-7c1d-44ff-9ede-43a659620a04", "d@mailinator.com", false, false, null, "D@MAILINATOR.COM", "D", "AQAAAAEAACcQAAAAEHpP0r6L5FlEAWS5avXT2CFtj6aj0Z4sDBDF6S5sTcEmrN/bTXddrPitD0L/fXaW3w==", null, false, "3d52be19-3e4b-47f8-8d38-083a6b41897d", false, "d" },
                    { "8a650eb8-3760-4151-b955-962b45b77c50", 0, "c00050ed-c5ed-4840-8737-ffac45792473", "nadir@mailinator.com", false, false, null, "NADIR@MAILINATOR.COM", "NADIR", "AQAAAAEAACcQAAAAEDcv6K4z7RKGrO9SKyQ1OCrtytsQaCXdEF8ai2Mez5W86/6/oYDbHLWMEkM/E/rB1w==", null, false, "09728ba5-ee9f-4ad9-86ba-2b2fc8efd21d", false, "nadir" },
                    { "8cdc3110-1229-4f5d-a603-8b49e7e18681", 0, "9707e5b2-9239-4cf2-9ed2-587478b68691", "bel@mailinator.com", false, false, null, "BEL@MAILINATOR.COM", "BEL", "AQAAAAEAACcQAAAAEGFU50RWyyWwSAAZ6u3i+o2aM7VOzinhYRSJHRfrTFCyIVhWlGR+lpuFJMi/S9CbZA==", null, false, "0ff2a92f-88d7-440e-b1e0-0edc642cd8fe", false, "bel" },
                    { "a729156f-f5dd-450b-8817-4ef2763b201e", 0, "20d91338-698c-4c3b-919b-534a7bbcca69", "max@mailinator.com", false, false, null, "MAX@MAILINATOR.COM", "MAX", "AQAAAAEAACcQAAAAEK/zD5O5GjEifG98Tx9LsOFtZxmbF8SPbdHnR2msBppGSaixjmqpZs13sFPjDCQmGw==", null, false, "eae8f57d-4cde-476e-8555-14e74f90f37e", false, "max" },
                    { "b630bcee-5405-41b5-8ad5-d9c97558f59f", 0, "c7016d8d-fb72-4f74-9fb4-8784f69089a9", "any@mailinator.com", false, false, null, "ANY@MAILINATOR.COM", "ANY", "AQAAAAEAACcQAAAAENQmy5JgqS35WWrkI2LNms8qU16t6mGyx6iEO0pPJz2/o2KgqabB1ZQSDGzi+I/+Mg==", null, false, "928e17e2-29e9-4fd6-9850-de6b8c4df6e3", false, "any" },
                    { "dfe1c928-9648-44b6-84a9-c2bd2ff75e25", 0, "dda1d50a-e730-4807-b662-841246307bf3", "alex@mailinator.com", false, false, null, "ALEX@MAILINATOR.COM", "ALEX", "AQAAAAEAACcQAAAAELUFb5JguP0HnUcyrCi+pqYGZGuPUqt4fq+8uVmQWUNZ2/GID7krycdjAndISPJblg==", null, false, "36effbae-67d9-4f21-b8e1-0de9b9db36fc", false, "alex" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "0e57fb63-fb07-43b6-b4de-08587879713e", "5cf8f0cb-f806-4c48-a3d1-6a00b6debdae" },
                    { "0e57fb63-fb07-43b6-b4de-08587879713e", "7af2c5e3-f049-4dc8-b458-5d295276e791" },
                    { "0e57fb63-fb07-43b6-b4de-08587879713e", "7b64ea7d-f893-4023-9b63-18cd10a00f81" },
                    { "0e57fb63-fb07-43b6-b4de-08587879713e", "8a650eb8-3760-4151-b955-962b45b77c50" },
                    { "0e57fb63-fb07-43b6-b4de-08587879713e", "8cdc3110-1229-4f5d-a603-8b49e7e18681" },
                    { "0e57fb63-fb07-43b6-b4de-08587879713e", "a729156f-f5dd-450b-8817-4ef2763b201e" },
                    { "0e57fb63-fb07-43b6-b4de-08587879713e", "b630bcee-5405-41b5-8ad5-d9c97558f59f" },
                    { "0e57fb63-fb07-43b6-b4de-08587879713e", "dfe1c928-9648-44b6-84a9-c2bd2ff75e25" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId",
                table: "Sales",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_AspNetUsers_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_AspNetUsers_UserId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_UserId",
                table: "Sales");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c751ded-c072-4e1d-bca5-2e348d57678b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0e57fb63-fb07-43b6-b4de-08587879713e", "5cf8f0cb-f806-4c48-a3d1-6a00b6debdae" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0e57fb63-fb07-43b6-b4de-08587879713e", "7af2c5e3-f049-4dc8-b458-5d295276e791" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0e57fb63-fb07-43b6-b4de-08587879713e", "7b64ea7d-f893-4023-9b63-18cd10a00f81" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0e57fb63-fb07-43b6-b4de-08587879713e", "8a650eb8-3760-4151-b955-962b45b77c50" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0e57fb63-fb07-43b6-b4de-08587879713e", "8cdc3110-1229-4f5d-a603-8b49e7e18681" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0e57fb63-fb07-43b6-b4de-08587879713e", "a729156f-f5dd-450b-8817-4ef2763b201e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0e57fb63-fb07-43b6-b4de-08587879713e", "b630bcee-5405-41b5-8ad5-d9c97558f59f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0e57fb63-fb07-43b6-b4de-08587879713e", "dfe1c928-9648-44b6-84a9-c2bd2ff75e25" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e57fb63-fb07-43b6-b4de-08587879713e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5cf8f0cb-f806-4c48-a3d1-6a00b6debdae");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7af2c5e3-f049-4dc8-b458-5d295276e791");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b64ea7d-f893-4023-9b63-18cd10a00f81");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a650eb8-3760-4151-b955-962b45b77c50");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8cdc3110-1229-4f5d-a603-8b49e7e18681");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a729156f-f5dd-450b-8817-4ef2763b201e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b630bcee-5405-41b5-8ad5-d9c97558f59f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dfe1c928-9648-44b6-84a9-c2bd2ff75e25");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Sales",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Sales",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId1",
                table: "Sales",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_AspNetUsers_UserId1",
                table: "Sales",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
