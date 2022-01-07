using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Webapplicaties.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BitHeroes");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "BitHeroes",
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
                schema: "BitHeroes",
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
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaseStatTotal",
                schema: "BitHeroes",
                columns: table => new
                {
                    BaseStatTotalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Base = table.Column<int>(nullable: false),
                    Upgrade1 = table.Column<int>(nullable: false),
                    Upgrade2 = table.Column<int>(nullable: true),
                    Upgrade3 = table.Column<int>(nullable: true),
                    Upgrade4 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseStatTotal", x => x.BaseStatTotalID);
                });

            migrationBuilder.CreateTable(
                name: "Bonus",
                schema: "BitHeroes",
                columns: table => new
                {
                    BonusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Explanation = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonus", x => x.BonusID);
                });

            migrationBuilder.CreateTable(
                name: "Element",
                schema: "BitHeroes",
                columns: table => new
                {
                    ElementID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    WeakTo = table.Column<string>(nullable: false),
                    StrongTo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Element", x => x.ElementID);
                });

            migrationBuilder.CreateTable(
                name: "Geartype",
                schema: "BitHeroes",
                columns: table => new
                {
                    GeartypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geartype", x => x.GeartypeID);
                });

            migrationBuilder.CreateTable(
                name: "Rank",
                schema: "BitHeroes",
                columns: table => new
                {
                    RankID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rank", x => x.RankID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "BitHeroes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        principalSchema: "BitHeroes",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "BitHeroes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        principalSchema: "BitHeroes",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "BitHeroes",
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
                        principalSchema: "BitHeroes",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "BitHeroes",
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
                        principalSchema: "BitHeroes",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "BitHeroes",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "BitHeroes",
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
                        principalSchema: "BitHeroes",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gear",
                schema: "BitHeroes",
                columns: table => new
                {
                    GearID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Tier = table.Column<int>(nullable: true),
                    BaseAttack = table.Column<int>(nullable: true),
                    BaseHealth = table.Column<int>(nullable: true),
                    BaseSpeed = table.Column<int>(nullable: true),
                    SpecAccPetBonus = table.Column<string>(nullable: true),
                    GeartypeID = table.Column<int>(nullable: false),
                    RankID = table.Column<int>(nullable: false),
                    ElementID = table.Column<int>(nullable: false),
                    BaseStatTotalID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gear", x => x.GearID);
                    table.ForeignKey(
                        name: "FK_Gear_BaseStatTotal_BaseStatTotalID",
                        column: x => x.BaseStatTotalID,
                        principalSchema: "BitHeroes",
                        principalTable: "BaseStatTotal",
                        principalColumn: "BaseStatTotalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gear_Element_ElementID",
                        column: x => x.ElementID,
                        principalSchema: "BitHeroes",
                        principalTable: "Element",
                        principalColumn: "ElementID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gear_Geartype_GeartypeID",
                        column: x => x.GeartypeID,
                        principalSchema: "BitHeroes",
                        principalTable: "Geartype",
                        principalColumn: "GeartypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gear_Rank_RankID",
                        column: x => x.RankID,
                        principalSchema: "BitHeroes",
                        principalTable: "Rank",
                        principalColumn: "RankID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gear_Bonus",
                schema: "BitHeroes",
                columns: table => new
                {
                    Gear_BonusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GearID = table.Column<int>(nullable: false),
                    BonusID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gear_Bonus", x => x.Gear_BonusID);
                    table.ForeignKey(
                        name: "FK_Gear_Bonus_Bonus_BonusID",
                        column: x => x.BonusID,
                        principalSchema: "BitHeroes",
                        principalTable: "Bonus",
                        principalColumn: "BonusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Gear_Bonus_Gear_GearID",
                        column: x => x.GearID,
                        principalSchema: "BitHeroes",
                        principalTable: "Gear",
                        principalColumn: "GearID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "BitHeroes",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "BitHeroes",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "BitHeroes",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "BitHeroes",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "BitHeroes",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "BitHeroes",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "BitHeroes",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Gear_BaseStatTotalID",
                schema: "BitHeroes",
                table: "Gear",
                column: "BaseStatTotalID");

            migrationBuilder.CreateIndex(
                name: "IX_Gear_ElementID",
                schema: "BitHeroes",
                table: "Gear",
                column: "ElementID");

            migrationBuilder.CreateIndex(
                name: "IX_Gear_GeartypeID",
                schema: "BitHeroes",
                table: "Gear",
                column: "GeartypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Gear_RankID",
                schema: "BitHeroes",
                table: "Gear",
                column: "RankID");

            migrationBuilder.CreateIndex(
                name: "IX_Gear_Bonus_BonusID",
                schema: "BitHeroes",
                table: "Gear_Bonus",
                column: "BonusID");

            migrationBuilder.CreateIndex(
                name: "IX_Gear_Bonus_GearID",
                schema: "BitHeroes",
                table: "Gear_Bonus",
                column: "GearID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "BitHeroes");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "BitHeroes");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "BitHeroes");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "BitHeroes");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "BitHeroes");

            migrationBuilder.DropTable(
                name: "Gear_Bonus",
                schema: "BitHeroes");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "BitHeroes");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "BitHeroes");

            migrationBuilder.DropTable(
                name: "Bonus",
                schema: "BitHeroes");

            migrationBuilder.DropTable(
                name: "Gear",
                schema: "BitHeroes");

            migrationBuilder.DropTable(
                name: "BaseStatTotal",
                schema: "BitHeroes");

            migrationBuilder.DropTable(
                name: "Element",
                schema: "BitHeroes");

            migrationBuilder.DropTable(
                name: "Geartype",
                schema: "BitHeroes");

            migrationBuilder.DropTable(
                name: "Rank",
                schema: "BitHeroes");
        }
    }
}
