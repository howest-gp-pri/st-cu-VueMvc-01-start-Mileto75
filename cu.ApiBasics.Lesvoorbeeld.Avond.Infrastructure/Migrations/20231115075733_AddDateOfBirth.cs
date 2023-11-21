using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cu.ApiBasics.Lesvoorbeeld.Avond.Infrastructure.Migrations
{
    public partial class AddDateOfBirth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da98bb50-7ebd-4d35-9f1e-d8f1f2402586", new DateTime(1972, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEKa1qBTpcU3pjxdFAU72Z50bu8nVTS8XYirRsbCuWiUJZGzDhVYXQXlMWkcM/dzYGg==", "d6732b4a-97ed-462a-adff-f12e2ef4c163" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b12e8e95-3c56-4eb6-ba1e-9ca9e5580d91", new DateTime(2010, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEPc53UA9N6E/ETKl9lH8ETSzHg+J9rUgM1aQa+PjrJe0GS6ZRNozIIzZW0rhS7FGdg==", "548529b1-ebc0-4b48-b616-c45340f46b8f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

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
    }
}
