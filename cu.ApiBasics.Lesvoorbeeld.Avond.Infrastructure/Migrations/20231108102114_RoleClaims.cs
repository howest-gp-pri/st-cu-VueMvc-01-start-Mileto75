using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cu.ApiBasics.Lesvoorbeeld.Avond.Infrastructure.Migrations
{
    public partial class RoleClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin", "1" },
                    { 2, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User", "2" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "574a54e1-1911-4260-8f6e-dbb6e241a00b", "AQAAAAEAACcQAAAAEHclAZocVOwcCFid6nGsD3LeDKrzVaeug20NNqVhLHQDLMPPLt6SmPnZhzc8u/b6bw==", "713ca3f9-06e4-4ed2-9236-4d275c4b5afe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8492fe8f-7044-425e-aa09-60bc74fe0aef", "AQAAAAEAACcQAAAAEGZoj2MII0/PQZu3pDWFBaSOKo4EY6k/+kZgBq8l0bVAYuwa2ZuWOZ5Ak8SjL230kQ==", "2777972e-714c-4fa0-bdad-bc0b6b379fee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

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
    }
}
