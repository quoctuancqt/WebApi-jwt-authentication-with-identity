using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoIdentity.Migrations
{
    public partial class AddSeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0ba5c294-74b8-4ec3-961e-323fd2bfbf92", "9a842274-4114-4d53-a92f-73a73ec33606", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4586aff5-64c7-486f-bba7-94a7171b5ce4", "ad3332c2-3d49-4471-8dc7-0c13a7f84633", "User", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0ba5c294-74b8-4ec3-961e-323fd2bfbf92", "9a842274-4114-4d53-a92f-73a73ec33606" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "4586aff5-64c7-486f-bba7-94a7171b5ce4", "ad3332c2-3d49-4471-8dc7-0c13a7f84633" });
        }
    }
}
