using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantastical.Migrations
{
    public partial class imageupload3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "91a33b65-9aeb-4b4a-bf47-7444a57f3e4a", "AQAAAAEAACcQAAAAEDrW50WY//qobtbtXRkF7dX3kYtIyEWmw/anxtsjIJRzoXVo9y6QYcLVZQv9NBAGHQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12345678-wega-werw-jyjt-kepsfienqp",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c17767d1-5f6b-4fb2-bdfd-ca90c537fced", "AQAAAAEAACcQAAAAEFIbGQNQRLoihfIuVoHuINUUJtWUe+wU8YuQWIletoi5Wuc8NkT40PuZ271yugmKog==" });
        }
    }
}
