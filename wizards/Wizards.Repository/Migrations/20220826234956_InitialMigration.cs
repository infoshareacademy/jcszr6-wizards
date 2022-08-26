using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wizards.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveHeroId = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ActiveItemId = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnemiesAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Damage = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Precision = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Specialization = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    MaxHealth = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Reflex = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Defense = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemiesAtribiutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyRewardEnergy = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Precision = table.Column<int>(type: "int", nullable: false),
                    Specialization = table.Column<int>(type: "int", nullable: false),
                    MaxHealth = table.Column<int>(type: "int", nullable: false),
                    Reflex = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Precision = table.Column<int>(type: "int", nullable: false),
                    Specialization = table.Column<int>(type: "int", nullable: false),
                    MaxHealth = table.Column<int>(type: "int", nullable: false),
                    Reflex = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ProfessionRestriction = table.Column<int>(type: "int", nullable: false),
                    DamageFactor = table.Column<double>(type: "float", nullable: false, defaultValue: 1.0),
                    BaseHitChance = table.Column<int>(type: "int", nullable: false, defaultValue: 80),
                    ArmorPenetrationPercent = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    HealingFactor = table.Column<double>(type: "float", nullable: false, defaultValue: 0.01)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankPoints = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalMatchPlayed = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalMatchWin = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalMatchLoose = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "CombatStages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InUse = table.Column<bool>(type: "bit", nullable: false),
                    HeroId = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsHeroStunned = table.Column<bool>(type: "bit", nullable: false),
                    CurrentHeroHealth = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    HeroSelectedSkillId = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    EnemyId = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsEnemyStunned = table.Column<bool>(type: "bit", nullable: false),
                    CurrentEnemyHealth = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    EnemySelectedSkillId = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    RoundLogs = table.Column<string>(type: "nvarchar(max)", maxLength: 30000, nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombatStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CombatStages_AspNetUsers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enemies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EnemyType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    AvatarImageEnemy = table.Column<int>(type: "int", nullable: false),
                    EnemysStageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GoldReward = table.Column<int>(type: "int", nullable: false),
                    AttributesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enemies_EnemiesAtribiutes_AttributesId",
                        column: x => x.AttributesId,
                        principalTable: "EnemiesAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Restriction = table.Column<int>(type: "int", nullable: false),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    BuyPrice = table.Column<int>(type: "int", nullable: false),
                    SellPrice = table.Column<int>(type: "int", nullable: false),
                    AttributesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemAttributes_AttributesId",
                        column: x => x.AttributesId,
                        principalTable: "ItemAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Profession = table.Column<int>(type: "int", nullable: false),
                    AvatarImageNumber = table.Column<int>(type: "int", nullable: false),
                    Gold = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    AttributesId = table.Column<int>(type: "int", nullable: false),
                    StatisticsId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heroes_AspNetUsers_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Heroes_HeroAttributes_AttributesId",
                        column: x => x.AttributesId,
                        principalTable: "HeroAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Heroes_Statistics_StatisticsId",
                        column: x => x.StatisticsId,
                        principalTable: "Statistics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BehaviorPatterns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinHealthPercentToTrigger = table.Column<int>(type: "int", nullable: false),
                    MaxHealthPercentToTrigger = table.Column<int>(type: "int", nullable: false),
                    SkillsIdPattern = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    EnemyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BehaviorPatterns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BehaviorPatterns_Enemies_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "Enemies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnemiesSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SkillType = table.Column<int>(type: "int", nullable: false),
                    DamageFactor = table.Column<double>(type: "float", nullable: false, defaultValue: 1.0),
                    BaseHitChance = table.Column<int>(type: "int", nullable: false, defaultValue: 80),
                    ArmorPenetrationPercent = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    HealingFactor = table.Column<double>(type: "float", nullable: false, defaultValue: 0.01),
                    Stunning = table.Column<bool>(type: "bit", nullable: false),
                    EnemyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemiesSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnemiesSkills_Enemies_EnemyId",
                        column: x => x.EnemyId,
                        principalTable: "Enemies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeroItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InUse = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ItemEndurance = table.Column<double>(type: "float", nullable: false, defaultValue: 100.0),
                    HeroId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeroItems_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeroSkills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeroSkills_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ItemAttributes",
                columns: new[] { "Id", "Damage", "Defense", "MaxHealth", "Precision", "Reflex", "Specialization" },
                values: new object[,]
                {
                    { 1, 7, 0, 0, 15, 0, -8 },
                    { 2, 14, 0, 0, 20, 0, -6 },
                    { 3, 21, 0, 0, 25, 0, -4 },
                    { 4, 28, 0, 0, 30, 0, -2 },
                    { 5, 35, 0, 0, 35, 0, 0 },
                    { 6, 8, 0, 0, -8, 0, 30 },
                    { 7, 16, 0, 0, -6, 0, 35 },
                    { 8, 24, 0, 0, -4, 0, 40 },
                    { 9, 32, 0, 0, -2, 0, 45 },
                    { 10, 40, 0, 0, 0, 0, 50 },
                    { 11, 9, 0, 0, 12, 0, 3 },
                    { 12, 18, 0, 0, 14, 0, 6 },
                    { 13, 27, 0, 0, 16, 0, 9 },
                    { 14, 36, 0, 0, 18, 0, 12 },
                    { 15, 45, 0, 0, 20, 0, 15 },
                    { 16, 0, -8, 25, 0, 15, 0 },
                    { 17, 0, -6, 75, 0, 20, 0 },
                    { 18, 0, -4, 125, 0, 25, 0 },
                    { 19, 0, -2, 175, 0, 30, 0 },
                    { 20, 0, 0, 225, 0, 35, 0 },
                    { 21, 0, 30, 25, 0, -8, 0 },
                    { 22, 0, 35, 75, 0, -6, 0 },
                    { 23, 0, 40, 125, 0, -4, 0 },
                    { 24, 0, 45, 175, 0, -2, 0 },
                    { 25, 0, 50, 225, 0, 0, 0 },
                    { 26, 0, 15, 25, 0, 4, 0 },
                    { 27, 0, 20, 75, 0, 8, 0 },
                    { 28, 0, 25, 125, 0, 12, 0 },
                    { 29, 0, 30, 175, 0, 16, 0 },
                    { 30, 0, 35, 225, 0, 20, 0 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "AttributesId", "BuyPrice", "Name", "Restriction", "SellPrice", "Tier", "Type" },
                values: new object[,]
                {
                    { 1, 1, 100, "Normal Staff", 1, 80, 1, 0 },
                    { 2, 2, 600, "Fine Staff", 1, 480, 2, 0 },
                    { 3, 3, 3000, "Great Staff", 1, 2400, 3, 0 },
                    { 4, 4, 12000, "Enchanted Staff", 1, 9600, 4, 0 },
                    { 5, 5, 36000, "Masterpiece Staff", 1, 28800, 5, 0 },
                    { 6, 6, 100, "Normal Spell-book", 1, 80, 1, 0 },
                    { 7, 7, 600, "Fine Spell-book", 1, 480, 2, 0 },
                    { 8, 8, 3000, "Great Spell-book", 1, 2400, 3, 0 },
                    { 9, 9, 12000, "Enchanted Spell-book", 1, 9600, 4, 0 },
                    { 10, 10, 36000, "Masterpiece Spell-book", 1, 28800, 5, 0 },
                    { 11, 11, 100, "Normal Scepter", 1, 80, 1, 0 },
                    { 12, 12, 600, "Fine Scepter", 1, 480, 2, 0 },
                    { 13, 13, 3000, "Great Scepter", 1, 2400, 3, 0 },
                    { 14, 14, 12000, "Enchanted Scepter", 1, 9600, 4, 0 },
                    { 15, 15, 36000, "Masterpiece Scepter", 1, 28800, 5, 0 },
                    { 16, 16, 50, "Normal Vestments", 1, 40, 1, 1 },
                    { 17, 17, 300, "Fine Vestments", 1, 240, 2, 1 },
                    { 18, 18, 1500, "Great Vestments", 1, 1200, 3, 1 },
                    { 19, 19, 6000, "Enchanted Vestments", 1, 4800, 4, 1 },
                    { 20, 20, 18000, "Masterpiece Vestments", 1, 14400, 5, 1 },
                    { 21, 21, 50, "Normal Mantle", 1, 40, 1, 1 },
                    { 22, 22, 300, "Fine Mantle", 1, 240, 2, 1 },
                    { 23, 23, 1500, "Great Mantle", 1, 1200, 3, 1 },
                    { 24, 24, 6000, "Enchanted Mantle", 1, 4800, 4, 1 },
                    { 25, 25, 18000, "Masterpiece Mantle", 1, 14400, 5, 1 },
                    { 26, 26, 50, "Normal Overcoat", 1, 40, 1, 1 },
                    { 27, 27, 300, "Fine Overcoat", 1, 240, 2, 1 },
                    { 28, 28, 1500, "Great Overcoat", 1, 1200, 3, 1 },
                    { 29, 29, 6000, "Enchanted Overcoat", 1, 4800, 4, 1 },
                    { 30, 30, 18000, "Masterpiece Overcoat", 1, 14400, 5, 1 }
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
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserName",
                table: "AspNetUsers",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BehaviorPatterns_EnemyId",
                table: "BehaviorPatterns",
                column: "EnemyId");

            migrationBuilder.CreateIndex(
                name: "IX_CombatStages_PlayerId",
                table: "CombatStages",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enemies_AttributesId",
                table: "Enemies",
                column: "AttributesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnemiesSkills_EnemyId",
                table: "EnemiesSkills",
                column: "EnemyId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_AttributesId",
                table: "Heroes",
                column: "AttributesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_NickName",
                table: "Heroes",
                column: "NickName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_PlayerId",
                table: "Heroes",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_StatisticsId",
                table: "Heroes",
                column: "StatisticsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HeroItems_HeroId",
                table: "HeroItems",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroItems_ItemId",
                table: "HeroItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_HeroSkills_HeroId_SkillId",
                table: "HeroSkills",
                columns: new[] { "HeroId", "SkillId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HeroSkills_SkillId",
                table: "HeroSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_AttributesId",
                table: "Items",
                column: "AttributesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Name",
                table: "Skills",
                column: "Name",
                unique: true);
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
                name: "BehaviorPatterns");

            migrationBuilder.DropTable(
                name: "CombatStages");

            migrationBuilder.DropTable(
                name: "EnemiesSkills");

            migrationBuilder.DropTable(
                name: "HeroItems");

            migrationBuilder.DropTable(
                name: "HeroSkills");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Enemies");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "EnemiesAttributes");

            migrationBuilder.DropTable(
                name: "ItemAttributes");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "HeroAttributes");

            migrationBuilder.DropTable(
                name: "Statistics");
        }
    }
}
