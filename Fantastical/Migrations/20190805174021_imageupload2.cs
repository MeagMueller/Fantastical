using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantastical.Migrations
{
    public partial class imageupload2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c36279bc-bdfe-49ee-9e12-4d879db9e745", "AQAAAAEAACcQAAAAEDWuOFaWTmmA/xkw43z+1fQ/YhkS8bU1jeMnIOcXqYe9QmGvNCApJuToMkEUSNQupw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12345678-wega-werw-jyjt-kepsfienqp",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1b5bc282-ed4a-40bb-8687-1e8708b5ff83", "AQAAAAEAACcQAAAAEO/c4YZgsGwET1/wvC5LNaIX9FsNefOdQQOfif97C2M+s+9LE9mJNHcnGnKmyxagJA==" });
        }
    }
}
