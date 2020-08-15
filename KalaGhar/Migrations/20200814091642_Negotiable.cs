using Microsoft.EntityFrameworkCore.Migrations;

namespace KalaGhar.Migrations
{
    public partial class Negotiable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "2a8c6070-a6c0-4348-981b-6eb66a9451a4");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3d7afe04-ca9d-4d0d-871f-24ccd8d713fe");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "4ed1e95a-e311-4a24-ac20-23ac2f5bebee");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "89635d54-931d-489f-a81e-76ce4cc4ded4");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "cacd8cdf-6257-432c-b627-bfbd8fe3d53f");

            migrationBuilder.RenameColumn(
                name: "CallForPrice",
                table: "Crafts",
                newName: "Negotiable");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Enabled", "Name" },
                values: new object[,]
                {
                    { "18a01994-40c3-498d-ac6d-1025d461ba80", null, true, "Paintings" },
                    { "668e5631-0a15-44d6-a8fe-7878558b0a2b", null, true, "Stone crafts" },
                    { "55a54a65-be4e-4f88-bd64-9cd68a60fa7f", null, true, "Ceramics" },
                    { "2b158281-81a0-49c5-9f01-c3409dfb4098", null, true, "Wooden crafts" },
                    { "3db5956b-9cbc-4216-81d8-ba75be948a59", null, true, "Browse others" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "18a01994-40c3-498d-ac6d-1025d461ba80");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "2b158281-81a0-49c5-9f01-c3409dfb4098");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3db5956b-9cbc-4216-81d8-ba75be948a59");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "55a54a65-be4e-4f88-bd64-9cd68a60fa7f");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "668e5631-0a15-44d6-a8fe-7878558b0a2b");

            migrationBuilder.RenameColumn(
                name: "Negotiable",
                table: "Crafts",
                newName: "CallForPrice");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Enabled", "Name" },
                values: new object[,]
                {
                    { "3d7afe04-ca9d-4d0d-871f-24ccd8d713fe", null, true, "Paintings" },
                    { "89635d54-931d-489f-a81e-76ce4cc4ded4", null, true, "Stone crafts" },
                    { "cacd8cdf-6257-432c-b627-bfbd8fe3d53f", null, true, "Ceramics" },
                    { "4ed1e95a-e311-4a24-ac20-23ac2f5bebee", null, true, "Wooden crafts" },
                    { "2a8c6070-a6c0-4348-981b-6eb66a9451a4", null, true, "Browse others" }
                });
        }
    }
}
