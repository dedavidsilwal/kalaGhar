using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KalaGhar.Migrations
{
    public partial class replies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

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

            migrationBuilder.AlterColumn<string>(
                name: "CraftOwnerUserId",
                table: "Messages",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CraftId",
                table: "Messages",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Messages",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Reply",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    MessageId = table.Column<string>(type: "text", nullable: false),
                    ReplyText = table.Column<string>(type: "text", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reply_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Enabled", "Name" },
                values: new object[,]
                {
                    { "61731259-c1cf-4742-a856-80376121343b", null, true, "Paintings" },
                    { "25959965-839f-464c-92c3-d6b698544015", null, true, "Stone crafts" },
                    { "032c97a0-7c87-447e-829c-ed4ecd9d5d85", null, true, "Ceramics" },
                    { "a6ca8e89-606c-477a-a6c2-7a917390a822", null, true, "Wooden crafts" },
                    { "6cef4cc6-341b-4cfa-88ba-4c6ee86d51f8", null, true, "Browse others" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CraftId",
                table: "Messages",
                column: "CraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_MessageId",
                table: "Reply",
                column: "MessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_CraftId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "032c97a0-7c87-447e-829c-ed4ecd9d5d85");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "25959965-839f-464c-92c3-d6b698544015");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "61731259-c1cf-4742-a856-80376121343b");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6cef4cc6-341b-4cfa-88ba-4c6ee86d51f8");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "a6ca8e89-606c-477a-a6c2-7a917390a822");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "CraftOwnerUserId",
                table: "Messages",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CraftId",
                table: "Messages",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                columns: new[] { "CraftId", "CraftOwnerUserId" });

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
    }
}
