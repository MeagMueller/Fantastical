using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantastical.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    isAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Creature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Lore = table.Column<string>(nullable: false),
                    Region = table.Column<string>(nullable: false),
                    ImagePath = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Creature_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isAdmin" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, "b4726041-3d36-466c-8e77-ad713d554537", "Admin@Admin.com", true, "Admin", "Admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAECskFUM/ffXTLvh3N9lKRWdnLnlIm9EZe5M6J0k7OH7YkRx/rkj7itymrZ9WvAmI9g==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", false, "Admin@Admin.com", true });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isAdmin" },
                values: new object[] { "12345678-wega-werw-jyjt-kepsfienqp", 0, "a67bdfa0-8fba-42b6-a0cb-240355ba1e03", "ThisGuy@ThisGuy.com", true, "This", "Guy", false, null, "THISGUY@THISGUY.COM", "THISGUY@THISGUY.COM", "AQAAAAEAACcQAAAAENOQe/zpoy5I3JY40r6MMBIwFzDW+k7O2czRsmbd6tqjjTT9KCvf49cN4T/c4+0njA==", null, false, "5r423999-f4g5-93i4-2rtt-255re563256", false, "ThisGuy@ThisGuy.com", false });

            migrationBuilder.InsertData(
                table: "Creature",
                columns: new[] { "Id", "ImagePath", "Lore", "Name", "Region", "UserId" },
                values: new object[,]
                {
                    { 1, "Anansi.jpg", "In West African lore, Anansi is a trickster character who often takes the shape of a spider and is considered the spirit of all knowledge of stories. Tales of Anansi were part of an exclusively oral tradition, which was fitting as he himself was seen as synonymous with skill and wisdom in speech.", "Anansi", "West Africa, Jamaica, United States", "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 2, "HuginnandMuninn.jpg", "Huginn and Muninn (Old Norse for 'thought' and 'memory' or 'mind', respectively) are a pair of ravens that fly all over Midgard (the world) in order to gather information and bring it to the god Odin. Scholars have linked the god's relation to Huginn and Muninn to the shamanic practice of going on a trance-like journey.", "Huginn and Muninn", "Scandinavia", "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 4, "Unicorn.jpg", "The Unicorn is a legendary creature, often described as a white horse-like animal with a long spiral horn and cloven hooves. The first known depictions are found in the areas of the Indus Valley Civilization, and are mentioned with some frequency in the annals of Greek history. Interestingly, they are mentioned in accounts of natural history rather than mythology because they were believed by the Greeks to have truly existed in faraway lands. In the Middle Ages and Renaissance, it was said that the unicorn could only be tamed by a virgin, and was emblematic of chaste love and faithful marriage.The horns were said to be made of a substance called alicorn, and it was believed they held magical, medicinal properties.", "Unicorn", "Europe", "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 5, "Wyvern.jpg", "A Wyvern is a legendary, bipedal dragon with a tail often ending in a diamond or arrow shaped tip. The creature frequently appears in heraldry and literature, video games, and modern fantasy. There is very little differentiation between Wyverns and Dragons, the key difference being the number of legs.", "Wyvern", "Europe", "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 6, "Sphinx.jpg", "A Sphinx is a mystical creature with the head of a human and the body of a lion and, sometimes, the wings of a bird. In Greek mythology, those who could not answer the Sphinx's riddles were eaten. In Egyptian, the Sphinx was regarded more as a benevolent creature, but both were often viewed as guardians of temples.", "Sphinx", "Persia, Greece, and Egypt", "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 7, "Kraken.jpg", "A Kraken is a giant cephalopod-like sea-monster in Scandinavian folklore, said to haunt the coasts of Greenland and Norway in order to terrorize unwary sailors.", "Kraken", "Scandinavia", "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 8, "BlackDog.jpg", "A Black Dog is a spectral entity found primarily in the folklore of the British Isles. It is a nocturnal apparition often described as a ghost or hellhound, and was said to be an enormous dog with glowing eyes. Its appearance was frequently regarded as a portent of death, and is associated with crossroads, places of execution, and ancient pathways. It is difficult to discern where exactly the tales of the Black Dog began, but throughout European mythology, dogs have been associated with death.", "Black Dog", "British Isles", "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 3, "Mothman.jpg", "Mothman is a Cryptid out of West Virginia in the United States. He was first spotted in November 1966 by five men digging a grave in a cemetery near Clendenin, and was described as a man-like figure flying low over their heads. Several days later, he was seen again, this time by two couples who reported a large, gray, flying man with ten-foot wings whose eyes glowed red and who followed their car for some time. A little over a year later in December 1967, the Silver Bridge, which spanned the Ohio river between Point Pleasant, West Virginia, and Gallipolis, Ohio, collapsed and Mothman was connected to the tragedy. Today, Mothman is one of the more well known Cryptids, thanks to books, movies, a statue and a museum dedicated to him in Point Pleasant.There is even a festival held in September every year by the museum and people flock to see speakers, cosplay, and fun activities for kids.", "Mothman", "West Virginia", "12345678-wega-werw-jyjt-kepsfienqp" },
                    { 9, "Thunderbird.jpg", "The Thunderbird is a legendary creature in certain North American Indigenous Peoples' culture and history. It is a being of power and strength, and is most frequently depicted in the art, songs, and oral history of the Pacific Northwest Coast cultures, but also can be found in others. In mythology, the Thunderbird controls the upper world while the underworld is controlled by the Underwater Panther or Great Horned Serpent. In other mythologies, the Thunderbirds reside on a great floating mountain and control the rain and hail and are regarded as warriors, and are the enemies of the Great Horned Snakes.", "Thunderbird", "Pacific Northwest Coast", "12345678-wega-werw-jyjt-kepsfienqp" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Creature_UserId",
                table: "Creature",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Creature");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
