using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cu.ApiBasics.Lesvoorbeeld.Avond.Infrastructure.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "80721dd3-e3a5-4916-a734-2c27196340cf", "Admin", "ADMIN" },
                    { "2", "e70f66f3-a4cf-48b6-b025-a6d7f378e52f", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9b96fb7-6e1f-4f79-8e0a-9c03b1bae333", "AQAAAAEAACcQAAAAEKZTs3jCOPjO9phY6JnnUXdCbhuayiOjxo6G5cXsQ8aCM86eTVAekBHzzXUxLYMOIQ==", "3697f028-fe90-493d-a0b5-59e6dd24e434" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0069b92f-fb4a-42ec-8735-c64fa31055fc", "AQAAAAEAACcQAAAAEApHjzZP7ezYb2S915Pj9u+zcCpO5so9PaygplzedK2HqIcIwVXVaiNMoGrbsiI6Wg==", "c94b630e-2b77-4246-8f48-1d646a37e606" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2", "2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26d7e6aa-5ec3-4abf-b748-6db9ebe2c442", "AQAAAAEAACcQAAAAEH3ufbtYNwtiJPhLvL8ATLGHrzR5x22X2aecVq2DIemkU9JiV3t3/fKXn4+EJftdng==", "e9233b00-bb0f-4aae-bb86-1a2e29366225" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1099466-152c-46e9-b103-80c256d8bedf", "AQAAAAEAACcQAAAAEFmFJezuXN4gkNsRYYWx2EThurJ9bTyWSSzfy/X8DmiqZqqePAQSC7w/EuHGuM0zdg==", "7f1151dd-f565-42e6-9b83-a161dd9f89ae" });
        }
    }
}
