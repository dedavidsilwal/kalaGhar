using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KalaGhar.Migrations
{
    public partial class senderDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "448d6d53-a262-461a-89af-19035f65a11c");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "8ee624a1-a204-4292-9d9d-bcfe88904c70");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "d844e8c9-c173-42a5-b4ef-e251a91527bc");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "dada550e-7d13-4686-93dc-f7014e4ff27a");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "df748029-f482-4938-97c0-308b5ae4bfa4");

            migrationBuilder.DropColumn(
                name: "ReceivedDate",
                table: "Messages");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "Messages",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Enabled", "Name" },
                values: new object[,]
                {
                    { "75128417-fafd-414e-acb9-d53cd40fa0f1", null, true, "Paintings" },
                    { "71d34338-9281-4b46-981d-c7a14f03340d", null, true, "Stone crafts" },
                    { "234f0e97-d082-4993-8f95-84d5d2bed4a1", null, true, "Ceramics" },
                    { "95fd7f7c-4564-4d27-8a11-2b57a69d5409", null, true, "Wooden crafts" },
                    { "3c083c33-39a5-40ff-b5c9-a0b64c4379bb", null, true, "Browse others" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "234f0e97-d082-4993-8f95-84d5d2bed4a1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3c083c33-39a5-40ff-b5c9-a0b64c4379bb");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "71d34338-9281-4b46-981d-c7a14f03340d");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "75128417-fafd-414e-acb9-d53cd40fa0f1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "95fd7f7c-4564-4d27-8a11-2b57a69d5409");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "Messages");

            migrationBuilder.AddColumn<string>(
                name: "ReceivedDate",
                table: "Messages",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Enabled", "Name" },
                values: new object[,]
                {
                    { "df748029-f482-4938-97c0-308b5ae4bfa4", null, true, "Paintings" },
                    { "d844e8c9-c173-42a5-b4ef-e251a91527bc", null, true, "Stone crafts" },
                    { "448d6d53-a262-461a-89af-19035f65a11c", null, true, "Ceramics" },
                    { "dada550e-7d13-4686-93dc-f7014e4ff27a", null, true, "Wooden crafts" },
                    { "8ee624a1-a204-4292-9d9d-bcfe88904c70", null, true, "Browse others" }
                });
        }
    }
}
