using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CohorteApi.Migrations
{
    public partial class SaleFirstPass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "460cad28-5d69-461f-bc6d-c6ab79efe7ab");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "233efe61-93e9-4428-a60e-e8355c338e8b", "00fb242a-8289-491c-bc80-dbebc94746fb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "233efe61-93e9-4428-a60e-e8355c338e8b", "0c5a8f1c-cdef-4b26-b4c9-d251127b7130" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "233efe61-93e9-4428-a60e-e8355c338e8b", "3f4d842f-7629-4183-848d-27d394168e43" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "233efe61-93e9-4428-a60e-e8355c338e8b", "4b07b3da-c5d4-49da-852b-8c3ce8082390" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "233efe61-93e9-4428-a60e-e8355c338e8b", "5140f1d9-b80a-4fc4-87a6-86ecd759e191" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "233efe61-93e9-4428-a60e-e8355c338e8b", "b402dac2-bbfd-4ccb-bee0-174732561647" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "233efe61-93e9-4428-a60e-e8355c338e8b", "da726c41-2151-49bc-9b41-aa5a6ef32963" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "233efe61-93e9-4428-a60e-e8355c338e8b", "ebff4eed-5138-4ff8-bd7b-b47bca53a0e0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "233efe61-93e9-4428-a60e-e8355c338e8b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00fb242a-8289-491c-bc80-dbebc94746fb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c5a8f1c-cdef-4b26-b4c9-d251127b7130");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f4d842f-7629-4183-848d-27d394168e43");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b07b3da-c5d4-49da-852b-8c3ce8082390");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5140f1d9-b80a-4fc4-87a6-86ecd759e191");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b402dac2-bbfd-4ccb-bee0-174732561647");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da726c41-2151-49bc-9b41-aa5a6ef32963");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebff4eed-5138-4ff8-bd7b-b47bca53a0e0");

            migrationBuilder.AddColumn<string>(
                name: "VenueImage",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Section = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sales_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_EventId",
                table: "Sales",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId1",
                table: "Sales",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropColumn(
                name: "VenueImage",
                table: "Events");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "233efe61-93e9-4428-a60e-e8355c338e8b", "2", "User", "USER" },
                    { "460cad28-5d69-461f-bc6d-c6ab79efe7ab", "1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00fb242a-8289-491c-bc80-dbebc94746fb", 0, "6474a095-3747-42fe-bcb1-5ed4e426615f", "alex@mailinator.com", false, false, null, "ALEX@MAILINATOR.COM", "ALEX", "AQAAAAEAACcQAAAAEDOtvA49oC2Rmyif8D4v8YAH/Zkl1uydNJFO/nPP8/IZdD2Ib7WephvRP+5pQD80zA==", null, false, "f08d5f9b-b4fa-45ac-b31d-81d0104cfe95", false, "alex" },
                    { "0c5a8f1c-cdef-4b26-b4c9-d251127b7130", 0, "5521f23d-3644-461d-a975-e652d0415ae2", "bel@mailinator.com", false, false, null, "BEL@MAILINATOR.COM", "BEL", "AQAAAAEAACcQAAAAEJRCNP8TK8FqP9Env8KQ4xqoDFkgBqNaLkN76ioo/hliw9ZP9qMs0nRjPQtsNvNQWw==", null, false, "0168ddf3-4258-4b7c-a67e-5c2bc20f95d6", false, "bel" },
                    { "3f4d842f-7629-4183-848d-27d394168e43", 0, "afb200f1-abac-435f-8d27-b8f4d58974a6", "d@mailinator.com", false, false, null, "D@MAILINATOR.COM", "D", "AQAAAAEAACcQAAAAEOrLrFRz1x97WDjPQBIcnQdkTwyAZ6swcZRFGnzMyxkXr+agCJkCQSCZ88LipnYwnQ==", null, false, "e55192f5-71f9-43e4-b385-199edde8bf29", false, "d" },
                    { "4b07b3da-c5d4-49da-852b-8c3ce8082390", 0, "e0e400a4-ef3d-4fb0-be3a-7ee31375de4b", "max@mailinator.com", false, false, null, "MAX@MAILINATOR.COM", "MAX", "AQAAAAEAACcQAAAAEESm26RdWKAhB54WXeQN5R5ATE1hJDQhoTsf+5QG+QkHEiqnt52NwoaBcYUEdK0EJQ==", null, false, "315e1226-e90b-47d2-b2c7-180fd606c013", false, "max" },
                    { "5140f1d9-b80a-4fc4-87a6-86ecd759e191", 0, "50c349d0-79cd-497a-b573-1431b26a0668", "nadir@mailinator.com", false, false, null, "NADIR@MAILINATOR.COM", "NADIR", "AQAAAAEAACcQAAAAEPgskpgXja2jjbcaJpBund8l10jpDdrPOTHxRuEukoPFMqa25ZcfJRsozaguoapE1g==", null, false, "8bf3e57b-f9a7-451e-a835-fd3b020bd91f", false, "nadir" },
                    { "b402dac2-bbfd-4ccb-bee0-174732561647", 0, "551dc9eb-737d-4ef4-80d3-682e50dfc8b3", "manuel@mailinator.com", false, false, null, "MANUEL@MAILINATOR.COM", "MANUEL", "AQAAAAEAACcQAAAAEN3qBvvPYSwt9uOQeHmmnu+j4t0+KHrzd305o7wtnr4d9TvJe0OIV6uzIYLjJHlnfQ==", null, false, "d17e2cf6-5237-465d-a666-eef22fcbb38b", false, "manuel" },
                    { "da726c41-2151-49bc-9b41-aa5a6ef32963", 0, "1548814c-333d-4e17-933d-0c632c57e9b6", "diego@mailinator.com", false, false, null, "DIEGO@MAILINATOR.COM", "DIEGO", "AQAAAAEAACcQAAAAEN/Bzw/4+Wq4nuqsXWH4EzqizE+G3EXMa1DmZGUrVlMlMW9i86lXOD3DfC/GqvYS7Q==", null, false, "df138583-e7e8-48db-a59a-bd1a648f200c", false, "diego" },
                    { "ebff4eed-5138-4ff8-bd7b-b47bca53a0e0", 0, "1d218995-4860-45ef-bf31-d218b4097f87", "any@mailinator.com", false, false, null, "ANY@MAILINATOR.COM", "ANY", "AQAAAAEAACcQAAAAEMQI26nnbBhG41J+gOrJwtGfu8nbfB5KGKRPi2flPTpUAHzVcE2chIVV3AUSH4U1FA==", null, false, "58137fa0-7489-437e-a191-2a4ec230201f", false, "any" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "233efe61-93e9-4428-a60e-e8355c338e8b", "00fb242a-8289-491c-bc80-dbebc94746fb" },
                    { "233efe61-93e9-4428-a60e-e8355c338e8b", "0c5a8f1c-cdef-4b26-b4c9-d251127b7130" },
                    { "233efe61-93e9-4428-a60e-e8355c338e8b", "3f4d842f-7629-4183-848d-27d394168e43" },
                    { "233efe61-93e9-4428-a60e-e8355c338e8b", "4b07b3da-c5d4-49da-852b-8c3ce8082390" },
                    { "233efe61-93e9-4428-a60e-e8355c338e8b", "5140f1d9-b80a-4fc4-87a6-86ecd759e191" },
                    { "233efe61-93e9-4428-a60e-e8355c338e8b", "b402dac2-bbfd-4ccb-bee0-174732561647" },
                    { "233efe61-93e9-4428-a60e-e8355c338e8b", "da726c41-2151-49bc-9b41-aa5a6ef32963" },
                    { "233efe61-93e9-4428-a60e-e8355c338e8b", "ebff4eed-5138-4ff8-bd7b-b47bca53a0e0" }
                });
        }
    }
}
