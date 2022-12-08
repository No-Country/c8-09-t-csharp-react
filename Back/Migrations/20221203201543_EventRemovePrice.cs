using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CohorteApi.Migrations
{
    public partial class EventRemovePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0238212-ada9-40a9-bcf0-587347f6ad9a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "100e66ac-ecf3-414f-aa2f-c342bedb0331", "07c2bb53-5e7f-498e-88e7-e6f42e9be447" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "100e66ac-ecf3-414f-aa2f-c342bedb0331", "1483b6b3-a5f0-42f6-b9a7-f3980c5a8dec" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "100e66ac-ecf3-414f-aa2f-c342bedb0331", "213bcaca-8cd3-405a-8961-985b3d71b43b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "100e66ac-ecf3-414f-aa2f-c342bedb0331", "40867f0b-de28-470e-bace-eba0a7be5577" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "100e66ac-ecf3-414f-aa2f-c342bedb0331", "76c1bcd6-35f6-475b-be0e-d99a6f1327aa" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "100e66ac-ecf3-414f-aa2f-c342bedb0331", "a00492b9-5aa8-422f-83c4-a87108183324" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "100e66ac-ecf3-414f-aa2f-c342bedb0331", "bcd0f007-ddf1-4e42-8788-4e1a05403681" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "100e66ac-ecf3-414f-aa2f-c342bedb0331", "cb0ebf82-fe6d-4638-9b94-353f97239554" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "100e66ac-ecf3-414f-aa2f-c342bedb0331");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "07c2bb53-5e7f-498e-88e7-e6f42e9be447");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1483b6b3-a5f0-42f6-b9a7-f3980c5a8dec");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "213bcaca-8cd3-405a-8961-985b3d71b43b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40867f0b-de28-470e-bace-eba0a7be5577");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76c1bcd6-35f6-475b-be0e-d99a6f1327aa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a00492b9-5aa8-422f-83c4-a87108183324");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcd0f007-ddf1-4e42-8788-4e1a05403681");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb0ebf82-fe6d-4638-9b94-353f97239554");

            migrationBuilder.DropColumn(
                name: "Price",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Events",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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
        }
    }
}
