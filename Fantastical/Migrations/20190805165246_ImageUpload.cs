using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantastical.Migrations
{
    public partial class ImageUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Creature",
                nullable: true,
                oldClrType: typeof(string));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Creature",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b4726041-3d36-466c-8e77-ad713d554537", "AQAAAAEAACcQAAAAECskFUM/ffXTLvh3N9lKRWdnLnlIm9EZe5M6J0k7OH7YkRx/rkj7itymrZ9WvAmI9g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12345678-wega-werw-jyjt-kepsfienqp",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a67bdfa0-8fba-42b6-a0cb-240355ba1e03", "AQAAAAEAACcQAAAAENOQe/zpoy5I3JY40r6MMBIwFzDW+k7O2czRsmbd6tqjjTT9KCvf49cN4T/c4+0njA==" });
        }
    }
}
