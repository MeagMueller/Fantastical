using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantastical.Migrations
{
    public partial class TakeOutImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a340563f-1ecb-47c8-abff-ec39abc15546", "AQAAAAEAACcQAAAAEP9Wwh2UY3RPnEMDCtXAm9Di4NOOLxvmYmQYC2CxVXwU1D+PB6Od+5rQYMhB6pY4sg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12345678-wega-werw-jyjt-kepsfienqp",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b81d4d7a-3971-4cd9-9c2a-64ca98a6e61f", "AQAAAAEAACcQAAAAECqPOm3vC4zLDFBUZ3UW2ZdDuC12DuVCt6WFQ0kVPN7V0OD57gWRWRj9ImzA/gB/vg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2bea6894-b458-417e-964a-38e912ac6620", "AQAAAAEAACcQAAAAEBwKyVBdGWRfaPhOPa4G0BA3zewLqmZv5YvwoEo7h8GqJ77YVVAi7A1z+KYDupjGUg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12345678-wega-werw-jyjt-kepsfienqp",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2c80585d-eddd-4299-a61e-33c147e1b01d", "AQAAAAEAACcQAAAAEPYmWvw+33c6rte82mfAFyXGbZ63KFm0nlCiKeFD7exwAuW6HIOWC4OUKQSwBeaCAg==" });
        }
    }
}
