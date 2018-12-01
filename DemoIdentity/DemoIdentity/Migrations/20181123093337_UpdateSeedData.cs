using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoIdentity.Migrations
{
    public partial class UpdateSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0ba5c294-74b8-4ec3-961e-323fd2bfbf92", "9a842274-4114-4d53-a92f-73a73ec33606" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "4586aff5-64c7-486f-bba7-94a7171b5ce4", "ad3332c2-3d49-4471-8dc7-0c13a7f84633" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "455be11a-259d-45b1-a197-9f08316b935e", "4c9dbd41-8a22-4afc-9a4d-cab1cf3a43e1", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a33951cf-08c1-47ae-9038-686935a397d9", "f5f949ae-4b13-41a2-935d-29973d4637bd", "User", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "455be11a-259d-45b1-a197-9f08316b935e", "4c9dbd41-8a22-4afc-9a4d-cab1cf3a43e1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "a33951cf-08c1-47ae-9038-686935a397d9", "f5f949ae-4b13-41a2-935d-29973d4637bd" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ba5c294-74b8-4ec3-961e-323fd2bfbf92", "9a842274-4114-4d53-a92f-73a73ec33606", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4586aff5-64c7-486f-bba7-94a7171b5ce4", "ad3332c2-3d49-4471-8dc7-0c13a7f84633", "User", null });
        }
    }
}
