using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyBasket.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c2d01f9-c72a-4ba8-9777-ff47cc620cfd");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3f103a49-2018-472e-a73e-3c6c27b546f1", 0, "c3fb3561-d08a-4233-a1dc-8ce39a829d38", "johndoe@example.com", true, "John", "Doe", false, null, "JOHNDOE@EXAMPLE.COM", "JOHNDOE", "AQAAAAIAAYagAAAAEDr8pe0YLoF6NV65k22CMIafMYRvi5k4QJp4bDrlXGR/CFwt0vD/WDWTDmxyXiOSyw==", null, false, "03cca953-c015-4030-b938-6fd1c3fd821a", false, "johndoe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3f103a49-2018-472e-a73e-3c6c27b546f1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6c2d01f9-c72a-4ba8-9777-ff47cc620cfd", 0, "ad4840f4-fd0f-4e74-90e3-8d2eeb4295b6", "johndoe@example.com", false, "John", "Doe", false, null, null, null, "AQAAAAIAAYagAAAAEOZSIF6sHBWQituWyMhLBed+Gi6qovCJzXvSTiE8nhivJyMebUDDyqC8P8C5bhDIKQ==", null, false, "fcdd71dc-7496-4375-974d-81c50f558680", false, "johndoe" });
        }
    }
}
