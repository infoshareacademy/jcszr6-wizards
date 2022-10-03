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
                    table.PrimaryKey("PK_EnemiesAttributes", x => x.Id);
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
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DamageFactor = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    BaseHitChance = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ArmorPenetrationPercent = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    HealingFactor = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0)
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
                name: "Enemies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    AvatarImageNumber = table.Column<int>(type: "int", nullable: false),
                    EnemyStageName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    StageBackgroundImageNumber = table.Column<int>(type: "int", nullable: false),
                    TrainingEnemy = table.Column<bool>(type: "bit", nullable: false),
                    GoldReward = table.Column<int>(type: "int", nullable: false),
                    RankPointsReward = table.Column<int>(type: "int", nullable: false),
                    AttributesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enemies_EnemiesAttributes_AttributesId",
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
                    SequenceOfSkillsId = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    DamageFactor = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    BaseHitChance = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ArmorPenetrationPercent = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    HealingFactor = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
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
                    InUse = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    SlotNumber = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
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
                table: "EnemiesAttributes",
                columns: new[] { "Id", "Damage", "Defense", "MaxHealth", "Reflex", "Specialization" },
                values: new object[] { 1, 10, -10, 200, 20, 20 });

            migrationBuilder.InsertData(
                table: "EnemiesAttributes",
                columns: new[] { "Id", "Damage", "Defense", "MaxHealth", "Specialization" },
                values: new object[] { 2, 10, 20, 200, 20 });

            migrationBuilder.InsertData(
                table: "EnemiesAttributes",
                columns: new[] { "Id", "Damage", "Defense", "MaxHealth", "Precision", "Reflex" },
                values: new object[,]
                {
                    { 3, 15, 25, 250, 25, -7 },
                    { 4, 15, -10, 275, 25, 25 }
                });

            migrationBuilder.InsertData(
                table: "EnemiesAttributes",
                columns: new[] { "Id", "Damage", "Defense", "MaxHealth", "Precision", "Reflex", "Specialization" },
                values: new object[] { 5, 1, 50, 100, 500, -100, 500 });

            migrationBuilder.InsertData(
                table: "EnemiesAttributes",
                columns: new[] { "Id", "Damage", "Defense", "MaxHealth", "Reflex", "Specialization" },
                values: new object[] { 6, 20, 25, 400, -7, 32 });

            migrationBuilder.InsertData(
                table: "EnemiesAttributes",
                columns: new[] { "Id", "Damage", "Defense", "MaxHealth", "Precision", "Reflex" },
                values: new object[] { 7, 20, -10, 400, 32, 25 });

            migrationBuilder.InsertData(
                table: "EnemiesAttributes",
                columns: new[] { "Id", "Damage", "Defense", "MaxHealth", "Reflex", "Specialization" },
                values: new object[] { 8, 25, -15, 450, 28, 32 });

            migrationBuilder.InsertData(
                table: "EnemiesAttributes",
                columns: new[] { "Id", "Damage", "Defense", "MaxHealth", "Precision", "Reflex", "Specialization" },
                values: new object[,]
                {
                    { 9, 25, 28, 450, 32, -7, -10 },
                    { 10, 1, 50, 200, 500, -100, 500 }
                });

            migrationBuilder.InsertData(
                table: "EnemiesAttributes",
                columns: new[] { "Id", "Damage", "Defense", "MaxHealth", "Precision", "Reflex" },
                values: new object[,]
                {
                    { 11, 30, -15, 750, 38, 32 },
                    { 12, 30, 32, 750, 38, -5 }
                });

            migrationBuilder.InsertData(
                table: "EnemiesAttributes",
                columns: new[] { "Id", "Damage", "Defense", "MaxHealth", "Reflex", "Specialization" },
                values: new object[,]
                {
                    { 13, 35, 35, 1000, -7, 40 },
                    { 14, 35, -20, 1200, 37, 42 }
                });

            migrationBuilder.InsertData(
                table: "EnemiesAttributes",
                columns: new[] { "Id", "Damage", "Defense", "MaxHealth", "Precision", "Reflex", "Specialization" },
                values: new object[] { 15, 1, 50, 300, 500, -100, 500 });

            migrationBuilder.InsertData(
                table: "ItemAttributes",
                columns: new[] { "Id", "Damage", "Defense", "MaxHealth", "Precision", "Reflex", "Specialization" },
                values: new object[,]
                {
                    { 1, 10, 0, 0, 20, 0, 0 },
                    { 2, 20, 0, 0, 26, 0, -2 },
                    { 3, 30, 0, 0, 32, 0, -4 },
                    { 4, 40, 0, 0, 38, 0, -6 },
                    { 5, 50, 0, 0, 44, 0, -8 },
                    { 6, 10, 0, 0, 0, 0, 20 },
                    { 7, 20, 0, 0, -2, 0, 26 },
                    { 8, 30, 0, 0, -4, 0, 32 },
                    { 9, 40, 0, 0, -6, 0, 38 },
                    { 10, 50, 0, 0, -8, 0, 44 },
                    { 11, 9, 0, 0, 2, 0, 10 },
                    { 12, 18, 0, 0, 6, 0, 14 },
                    { 13, 27, 0, 0, 10, 0, 18 },
                    { 14, 36, 0, 0, 14, 0, 22 },
                    { 15, 45, 0, 0, 18, 0, 26 },
                    { 16, 0, 0, 25, 0, 26, 0 },
                    { 17, 0, -2, 75, 0, 32, 0 },
                    { 18, 0, -4, 125, 0, 38, 0 },
                    { 19, 0, -6, 175, 0, 44, 0 },
                    { 20, 0, -8, 225, 0, 50, 0 },
                    { 21, 0, 26, 25, 0, 0, 0 },
                    { 22, 0, 32, 75, 0, -2, 0 },
                    { 23, 0, 38, 125, 0, -4, 0 },
                    { 24, 0, 44, 175, 0, -6, 0 },
                    { 25, 0, 50, 225, 0, -8, 0 },
                    { 26, 0, 18, 20, 0, 16, 0 },
                    { 27, 0, 22, 60, 0, 20, 0 }
                });

            migrationBuilder.InsertData(
                table: "ItemAttributes",
                columns: new[] { "Id", "Damage", "Defense", "MaxHealth", "Precision", "Reflex", "Specialization" },
                values: new object[,]
                {
                    { 28, 0, 26, 100, 0, 24, 0 },
                    { 29, 0, 30, 140, 0, 28, 0 },
                    { 30, 0, 34, 180, 0, 32, 0 },
                    { 31, 10, 0, 0, 20, 0, 0 },
                    { 32, 20, 0, 0, 26, 0, -1 },
                    { 33, 30, 0, 0, 32, 0, -2 },
                    { 34, 40, 0, 0, 38, 0, -3 },
                    { 35, 50, 0, 0, 44, 0, -4 },
                    { 36, 10, 0, 0, 0, 0, 20 },
                    { 37, 20, 0, 0, -1, 0, 26 },
                    { 38, 30, 0, 0, -2, 0, 32 },
                    { 39, 40, 0, 0, -3, 0, 38 },
                    { 40, 50, 0, 0, -4, 0, 44 },
                    { 41, 10, 0, -10, 10, 0, 6 },
                    { 42, 20, 0, -20, 14, 0, 10 },
                    { 43, 30, 0, -30, 18, 0, 14 },
                    { 44, 40, 0, -40, 22, 0, 18 },
                    { 45, 50, 0, -50, 26, 0, 22 },
                    { 46, 0, 0, 75, 0, 26, 0 },
                    { 47, 0, -1, 125, 0, 32, 0 },
                    { 48, 0, -2, 175, 0, 38, 0 },
                    { 49, 0, -3, 225, 0, 44, 0 },
                    { 50, 0, -4, 275, 0, 50, 0 },
                    { 51, 0, 26, 75, 0, 0, 0 },
                    { 52, 0, 32, 125, 0, -1, 0 },
                    { 53, 0, 38, 175, 0, -2, 0 },
                    { 54, 0, 44, 225, 0, -3, 0 },
                    { 55, 0, 50, 275, 0, -4, 0 },
                    { 56, 0, 20, 60, 0, 16, 0 },
                    { 57, 0, 24, 100, 0, 20, 0 },
                    { 58, 0, 28, 140, 0, 24, 0 },
                    { 59, 0, 32, 180, 0, 28, 0 },
                    { 60, 0, 36, 220, 0, 32, 0 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "BaseHitChance", "DamageFactor", "Description", "Name", "ProfessionRestriction", "Type" },
                values: new object[,]
                {
                    { 1, 80, 1.0, "Hit enemy with sphere of fire", "Fireball", 1, 0 },
                    { 2, 105, 0.75, "Throw ice shard that deals damage and stops enemy movement", "Ice Shard", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "ArmorPenetrationPercent", "BaseHitChance", "DamageFactor", "Description", "Name", "ProfessionRestriction", "Type" },
                values: new object[] { 3, 10, 40, 1.3500000000000001, "Summon lighting strike that breaks enemy defense and deal lot of damage", "Lighting Strike", 1, 0 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "BaseHitChance", "DamageFactor", "Description", "Name", "ProfessionRestriction", "Type" },
                values: new object[] { 4, 20, 1.75, "Create fire field under enemy that deals him very high damage.", "Inferno", 1, 0 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "BaseHitChance", "Description", "HealingFactor", "Name", "ProfessionRestriction", "Type" },
                values: new object[] { 5, 200, "Create spring that recovers your health", 0.22500000000000001, "Renewal Fountain", 1, 3 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "BaseHitChance", "Description", "Name", "ProfessionRestriction", "Type" },
                values: new object[] { 6, 300, "Create magnetic barrier in front of you that protect you from enemy attacks", "Magnetic Shield", 1, 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "ArmorPenetrationPercent", "BaseHitChance", "DamageFactor", "Description", "Name", "ProfessionRestriction", "Type" },
                values: new object[] { 7, 10, 90, 1.0, "Corrupt air around your enemy to deal him damage", "Death Breath", 2, 0 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "BaseHitChance", "DamageFactor", "Description", "Name", "ProfessionRestriction", "Type" },
                values: new object[] { 8, 110, 0.5, "Fears your enemy, breaks his charge attack and deals damage", "Terror", 2, 1 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "ArmorPenetrationPercent", "BaseHitChance", "DamageFactor", "Description", "HealingFactor", "Name", "ProfessionRestriction", "Type" },
                values: new object[] { 9, 15, 45, 1.25, "Curse enemy's blood to deal damage", 0.050000000000000003, "Evil Blood", 2, 0 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "ArmorPenetrationPercent", "BaseHitChance", "DamageFactor", "Description", "Name", "ProfessionRestriction", "Type" },
                values: new object[] { 10, 20, 25, 1.55, "Summon Shroud of Death that deals a lot of damage to your foe.", "Deadly Shroud", 2, 0 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "ArmorPenetrationPercent", "BaseHitChance", "DamageFactor", "Description", "HealingFactor", "Name", "ProfessionRestriction", "Type" },
                values: new object[] { 11, 25, 200, 0.02, "Perform Ritual that steals some health from your enemy and recovers yours.", 0.19500000000000001, "Blood Ritual", 2, 3 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "BaseHitChance", "Description", "Name", "ProfessionRestriction", "Type" },
                values: new object[] { 12, 300, "Arise phantom shield that protects you.", "Phantom Shield", 2, 2 });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "Id", "AttributesId", "AvatarImageNumber", "Description", "EnemyStageName", "GoldReward", "Name", "RankPointsReward", "StageBackgroundImageNumber", "Tier", "TrainingEnemy", "Type" },
                values: new object[,]
                {
                    { 1, 1, 11, "Minotaur is great fighter. His attacks can easly overpass your armor, but are also very slow, so it will be easy to avoid them with some reflex. Minotaur also has some reflex so it is not easy to hit him. This enemy is vulnerable to damage because of his weak armor. Minotaur has dangerous Strong attacks so you should block them as often as you can.", "Great Forest of Anumer", 5, "Minotaur", 5, 11, 1, false, 0 },
                    { 2, 2, 12, "This enemy is very slow with his attacks, so with some reflex it will be easy to avoid them. His attacks can easly overpass your armor. Cyclopus is specialized in defense. If you want to deal him lot of damage, you have to maximize your specialization to oveprass his armor. This enemy also has Strong attacks; beware them if you want to keep your healt high.", "Lonely Island", 10, "Cyclopus", 5, 12, 1, false, 0 },
                    { 3, 3, 13, "Centarus are great archers. They can easly hit you with his attacks and deals you a lot of damage. The point is to maximize your defense instead of trying to avoid attacs. Utmar is very precise but has not good enough reflex. He has also high defense ability. To be more effective take some specialization for higher damage. You will need Blocking skill to protect yourself from his Strong Attacks", "Ruins of Verath", 15, "Utmar Sneaky Hoof", 10, 13, 1, false, 0 },
                    { 4, 4, 14, "Griffon is super precise enemy. It is quite impossible to avoid thiers attacks which are also dangerous. If you want to survive battle with him you need as much defense as you can take. Overis has good reflex so it is not easy to hit him. To be more effective fighter you should keep your precision high. That will help you defeat this enemy. Griffon has some Strong Attacks that will deal you very high damage, so good blocking will be the best strategy.", "Griffon Nest in Leven Highlands", 20, "Overis The Griffon Warrior", 15, 14, 1, false, 0 },
                    { 5, 5, 61, "This is Training Manequin that shows Strong Attacks and Attack Patterns. Attack Patterns are sequence of skill that boss is repeating. Patterns depends on Enemy's Health percent. Enemies can have up to four diffrent patterns (depends on enemy's tier). This Manequin demonstrate two sequences: First (100%-50%) - two simple attacks with 1 damage and one strong attack with 4 damage; Second (50% - 0%) - three simple attacks with 2 damage and one strong attack with 10 damage. When boss has prepared Strong Attack for round there will be orange icon above his card that signalizes this mechanic. Strong Attacks can be blocked by your Block skill. Start match with this manequin to get safely expirience about this basic Tier 1 mechanics.", "Training Grounds", 0, "Training Manequin T1 Mechanics", 0, 61, 1, true, 0 },
                    { 6, 6, 21, "Ettins are known for its strong attacks that crashes armor. Luckly most of Ettins Attacks are easy to avoid if you have enought reflex. Malaures is very slow enemy so it is not hard to succesfully hit him during combat. His thick skin protect him well so to be effective, you will bring Specialization to the fight. This enemy can stun you with one of its special attacks. Beware of it and block it because Ettins like to stun theirs enemies and than land Strong Attack on them without much effort.", "Old Temple in Caladhorn Wilds", 20, "Malaur - Ettin King", 20, 21, 2, false, 0 },
                    { 7, 7, 22, "Very quick and precise enemy. Its not so easy to avoid his attacks and succesfully hit him. Reflex would be useless during fight but defense will help to reduce damage. Cerberus is very vulnerable to damage so there is no need for specialization. Cerberus can prepare Terrifying Howl thats will stuns you. It would be better to perfectly Block this attack because Cerberus is much more dangerous when you are Stunned.", "Gallen-Tum Watchtower", 25, "Cerberus", 20, 22, 2, false, 0 },
                    { 8, 8, 23, "Volantur is the Ent King. He is very specialized warrior. His attacks are very dangerous because of high damage and high armor overpassing. To survive tha battle with him you will need reflex to avoid his attacks as often as you can. Volantur is also very quick enemy. to successfully hit him you will need a lot of precision. As a King of Trees and Vines he can Entangle you with one of his abilities that causes Stun. Make shure to Block this attack when its incomeing. Volantur is known for his cruel strategy. He likes Stuns enemies and then hit them with Strong attacks when they cannot move. Beware of it.", "Sorrow Wetlands", 30, "Volantur", 25, 23, 2, false, 0 },
                    { 9, 9, 24, "One of the most dangerous enemies. Its atacks are very precise and it is quite impossible to avoid them. Luckly damage of its atacks can be easily reduced by defense. Instead of avoiding attacks Chimera has high defense to protect itself. To conquer it effectively you should maximize your specialization. Chimeras tail is double dangerous, because it can hit very hard and also has sneak head that can bite you with Poisoned Teeth's. It would cause you to be Stunned for one round. You have to watch carefully its behavior and block this stunning attack, because after it chimera can easily hit you very strong.", "Forsaken Morath Caverns", 35, "Chimera", 30, 24, 2, false, 0 },
                    { 10, 10, 61, "This is Training Manequin that shows Stunning Attacks. Stunning Attacks, when hits, will make you unable to action in next round. This is dangerous mechanic because when you are stunned the damage you takes are much higher, and enemy cannot miss attack on you (no matter how high is your reflex). Thats why it is very important to use Block skill from your skill bar to block Stunning Attacks. This manequin has special Attacks Pattern as follows: 1x Simple Attack (4 dmg), 1x Strong Attack (8 dmg), 1x Stunning Attack (2 dmg and make you stunn), 1x Strong Attack (8 dmg - if you are not Stunned; 16 dmg if you are Stunned;). When boss has prepared Stunning Attack for round there will be violet icon with blac spiral above his card that signalizes this mechanic. Start match with this manequin to get safely expirience about this Tier 2 new mechanics.", "Training Grounds", 0, "Training Manequin T2 Mechanics", 0, 61, 2, true, 0 },
                    { 11, 11, 31, "Harpies are sneaky enemies with very high precision and perfect ability to avoid attacks. Besides theirs Strong Attacks she can Hypnotize you that makes you Stunned for next round. But the most dangerous is charge attack, because it also makes you Stunned for one round. Remember that when you are stunned you will take much more damage from enemy attacks. But if you counters she's charge, Harpy would be vulnerable to damage and there is no way to miss her so it is important to take chance of it and damage down her faster. ", "Old Mountain Grotto", 50, "Harpy", 45, 31, 3, false, 0 },
                    { 12, 12, 32, "Legendary Demon with high defense and super precised attacks. He has ability to Posses enemies what makes them stunned. Sevariaxen has many dangerous strong attacks and many of them occurs directly after his Stunning abilities. So beware of his Charge, but if you counter it that will make Deamon Stunned for one round and you will deal him much more damage and easily hit him. Dont underestimate his strong attacks and stunning skills because of high damage they deals. If you equipp yourself with proper gear and lern countering enemy charge, you will have chance to beat him. ", "Crimson Garden", 100, "Saveriaxen", 55, 32, 3, false, 0 },
                    { 13, 13, 33, "Great Champion of Werewolfs. His thick skin protects him very well from damage. His claws ar really hard and sharp so he can easily overpass your defense. Luperius is great warrior that fight till end, and when his healt is getting lower he will be much more dangerous. In his Fury he can rush on you and make you stunned. This is how he charges on theirs enemies. Luperius is dangerous enemy so you have to pay attention of his attacks and prepare yourself well before fight. If you take your opportunity to counter his charge attack he will be stunned and you will have one round to deal as much damage as you can without any risk that you miss attack. ", "Darken Woodlands", 150, "Luperius", 65, 33, 3, false, 0 },
                    { 14, 14, 34, "The great legendary spider queen is the most filthy incarnation of all fears. She is very quick so easily can avoid your attacks. Furthermore Arganthula's attacks are so strong that even high defense will not help to reduce them. The only chance you have is maximize your reflex to avoid them which is not so easy. She likes Spiderwebs which can stunn you as she's annother dangerous mechanic - Charge attack. To beat this abomination of nature you should prepare yourself really well with gear and tacticks. The fight will be long and will need your focus. One single mistake may be your last. Beware!", "Lair of Legendary Spider Queen", 150, "Arganthula", 75, 34, 3, false, 0 },
                    { 15, 15, 61, "This is Tier 3 Training Mannequin. He Shows how works new special mechanic on Tier 3 bosses - Charge attack. Charge attack is another boss attack that can stunn you. There is a difference between Stunning and Charge. Charge attack cannot be blocked by your Block Skill, it needs to be countered by you Counter Attack skill. Charge attacks are signalized by blue icon above enemy's card. If you don't counter Charge attack you will be Stunned fo next round and you will take a lot of damage from next Boss attack in his Pattern that will never misshits you. But if you counter Enemy Charge attack you will make the Boss Stunned! Stunned enemy also takes a lot of damage, you cannot misshits him and he will not able to perform his next skill. That's why countering Charge attack is so important. Many of Enemies has a lot of Health ant this is perfect chance to cast the most powerfull attacks on them to easily win fight!", "Training Grounds", 0, "Training Manequin T3 Mechanics", 0, 61, 3, true, 0 }
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
                    { 27, 27, 300, "Fine Overcoat", 1, 240, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "AttributesId", "BuyPrice", "Name", "Restriction", "SellPrice", "Tier", "Type" },
                values: new object[,]
                {
                    { 28, 28, 1500, "Great Overcoat", 1, 1200, 3, 1 },
                    { 29, 29, 6000, "Enchanted Overcoat", 1, 4800, 4, 1 },
                    { 30, 30, 18000, "Masterpiece Overcoat", 1, 14400, 5, 1 },
                    { 31, 31, 100, "Normal Scythe", 2, 80, 1, 0 },
                    { 32, 32, 600, "Fine Scythe", 2, 480, 2, 0 },
                    { 33, 33, 3000, "Great Scythe", 2, 2400, 3, 0 },
                    { 34, 34, 12000, "Enchanted Scythe", 2, 9600, 4, 0 },
                    { 35, 35, 36000, "Masterpiece Scythe", 2, 28800, 5, 0 },
                    { 36, 36, 100, "Normal Urn", 2, 80, 1, 0 },
                    { 37, 37, 600, "Fine Urn", 2, 480, 2, 0 },
                    { 38, 38, 3000, "Great Urn", 2, 2400, 3, 0 },
                    { 39, 39, 12000, "Enchanted Urn", 2, 9600, 4, 0 },
                    { 40, 40, 36000, "Masterpiece Urn", 2, 28800, 5, 0 },
                    { 41, 41, 100, "Normal Ritual Cup", 2, 80, 1, 0 },
                    { 42, 42, 600, "Fine Ritual Cup", 2, 480, 2, 0 },
                    { 43, 43, 3000, "Great Ritual Cup", 2, 2400, 3, 0 },
                    { 44, 44, 12000, "Enchanted Ritual Cup", 2, 9600, 4, 0 },
                    { 45, 45, 36000, "Masterpiece Ritual Cup", 2, 28800, 5, 0 },
                    { 46, 46, 50, "Normal Hood", 2, 40, 1, 1 },
                    { 47, 47, 300, "Fine Hood", 2, 240, 2, 1 },
                    { 48, 48, 1500, "Great Hood", 2, 1200, 3, 1 },
                    { 49, 49, 6000, "Enchanted Hood", 2, 4800, 4, 1 },
                    { 50, 50, 18000, "Masterpiece Hood", 2, 14400, 5, 1 },
                    { 51, 51, 50, "Normal Shroud", 2, 40, 1, 1 },
                    { 52, 52, 300, "Fine Shroud", 2, 240, 2, 1 },
                    { 53, 53, 1500, "Great Shroud", 2, 1200, 3, 1 },
                    { 54, 54, 6000, "Enchanted Shroud", 2, 4800, 4, 1 },
                    { 55, 55, 18000, "Masterpiece Shroud", 2, 14400, 5, 1 },
                    { 56, 56, 50, "Normal Ritual Livery", 2, 40, 1, 1 },
                    { 57, 57, 300, "Fine Ritual Livery", 2, 240, 2, 1 },
                    { 58, 58, 1500, "Great Ritual Livery", 2, 1200, 3, 1 },
                    { 59, 59, 6000, "Enchanted Ritual Livery", 2, 4800, 4, 1 },
                    { 60, 60, 18000, "Masterpiece Ritual Livery", 2, 14400, 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "BehaviorPatterns",
                columns: new[] { "Id", "EnemyId", "MaxHealthPercentToTrigger", "MinHealthPercentToTrigger", "SequenceOfSkillsId" },
                values: new object[,]
                {
                    { 1, 1, 100, 50, "[{\"SequenceStepId\":1,\"SkillId\":1},{\"SequenceStepId\":2,\"SkillId\":1},{\"SequenceStepId\":3,\"SkillId\":2}]" },
                    { 2, 1, 50, 0, "[{\"SequenceStepId\":1,\"SkillId\":3},{\"SequenceStepId\":2,\"SkillId\":3},{\"SequenceStepId\":3,\"SkillId\":4},{\"SequenceStepId\":4,\"SkillId\":3},{\"SequenceStepId\":5,\"SkillId\":4}]" },
                    { 3, 2, 100, 50, "[{\"SequenceStepId\":1,\"SkillId\":5},{\"SequenceStepId\":2,\"SkillId\":5},{\"SequenceStepId\":3,\"SkillId\":5},{\"SequenceStepId\":4,\"SkillId\":6}]" },
                    { 4, 2, 50, 0, "[{\"SequenceStepId\":1,\"SkillId\":7},{\"SequenceStepId\":2,\"SkillId\":7},{\"SequenceStepId\":3,\"SkillId\":8},{\"SequenceStepId\":4,\"SkillId\":7},{\"SequenceStepId\":5,\"SkillId\":8},{\"SequenceStepId\":6,\"SkillId\":7}]" },
                    { 5, 3, 100, 50, "[{\"SequenceStepId\":1,\"SkillId\":9},{\"SequenceStepId\":2,\"SkillId\":9},{\"SequenceStepId\":3,\"SkillId\":9},{\"SequenceStepId\":4,\"SkillId\":10},{\"SequenceStepId\":5,\"SkillId\":9},{\"SequenceStepId\":6,\"SkillId\":10}]" },
                    { 6, 3, 50, 0, "[{\"SequenceStepId\":1,\"SkillId\":11},{\"SequenceStepId\":2,\"SkillId\":12},{\"SequenceStepId\":3,\"SkillId\":11},{\"SequenceStepId\":4,\"SkillId\":11},{\"SequenceStepId\":5,\"SkillId\":12}]" },
                    { 7, 4, 100, 50, "[{\"SequenceStepId\":1,\"SkillId\":13},{\"SequenceStepId\":2,\"SkillId\":13},{\"SequenceStepId\":3,\"SkillId\":14},{\"SequenceStepId\":4,\"SkillId\":13},{\"SequenceStepId\":5,\"SkillId\":13},{\"SequenceStepId\":6,\"SkillId\":15}]" },
                    { 8, 4, 50, 0, "[{\"SequenceStepId\":1,\"SkillId\":16},{\"SequenceStepId\":2,\"SkillId\":16},{\"SequenceStepId\":3,\"SkillId\":17},{\"SequenceStepId\":4,\"SkillId\":16},{\"SequenceStepId\":5,\"SkillId\":18},{\"SequenceStepId\":6,\"SkillId\":16},{\"SequenceStepId\":7,\"SkillId\":18}]" },
                    { 9, 5, 100, 50, "[{\"SequenceStepId\":1,\"SkillId\":19},{\"SequenceStepId\":2,\"SkillId\":19},{\"SequenceStepId\":3,\"SkillId\":20}]" },
                    { 10, 5, 50, 0, "[{\"SequenceStepId\":1,\"SkillId\":21},{\"SequenceStepId\":2,\"SkillId\":21},{\"SequenceStepId\":3,\"SkillId\":21},{\"SequenceStepId\":4,\"SkillId\":22}]" },
                    { 11, 6, 100, 50, "[{\"SequenceStepId\":1,\"SkillId\":23},{\"SequenceStepId\":2,\"SkillId\":23},{\"SequenceStepId\":3,\"SkillId\":23},{\"SequenceStepId\":4,\"SkillId\":24},{\"SequenceStepId\":5,\"SkillId\":23},{\"SequenceStepId\":6,\"SkillId\":27},{\"SequenceStepId\":7,\"SkillId\":24}]" },
                    { 12, 6, 50, 0, "[{\"SequenceStepId\":1,\"SkillId\":25},{\"SequenceStepId\":2,\"SkillId\":25},{\"SequenceStepId\":3,\"SkillId\":26},{\"SequenceStepId\":4,\"SkillId\":25},{\"SequenceStepId\":5,\"SkillId\":25},{\"SequenceStepId\":6,\"SkillId\":25},{\"SequenceStepId\":7,\"SkillId\":27},{\"SequenceStepId\":8,\"SkillId\":26}]" },
                    { 13, 7, 100, 50, "[{\"SequenceStepId\":1,\"SkillId\":28},{\"SequenceStepId\":2,\"SkillId\":29},{\"SequenceStepId\":3,\"SkillId\":28},{\"SequenceStepId\":4,\"SkillId\":28},{\"SequenceStepId\":5,\"SkillId\":28},{\"SequenceStepId\":6,\"SkillId\":32},{\"SequenceStepId\":7,\"SkillId\":28}]" },
                    { 14, 7, 50, 0, "[{\"SequenceStepId\":1,\"SkillId\":30},{\"SequenceStepId\":2,\"SkillId\":30},{\"SequenceStepId\":3,\"SkillId\":30},{\"SequenceStepId\":4,\"SkillId\":31},{\"SequenceStepId\":5,\"SkillId\":30},{\"SequenceStepId\":6,\"SkillId\":30},{\"SequenceStepId\":7,\"SkillId\":32},{\"SequenceStepId\":8,\"SkillId\":31}]" },
                    { 15, 8, 100, 50, "[{\"SequenceStepId\":1,\"SkillId\":33},{\"SequenceStepId\":2,\"SkillId\":33},{\"SequenceStepId\":3,\"SkillId\":37},{\"SequenceStepId\":4,\"SkillId\":33},{\"SequenceStepId\":5,\"SkillId\":33},{\"SequenceStepId\":6,\"SkillId\":34},{\"SequenceStepId\":7,\"SkillId\":33}]" },
                    { 16, 8, 50, 0, "[{\"SequenceStepId\":1,\"SkillId\":35},{\"SequenceStepId\":2,\"SkillId\":35},{\"SequenceStepId\":3,\"SkillId\":35},{\"SequenceStepId\":4,\"SkillId\":37},{\"SequenceStepId\":5,\"SkillId\":36},{\"SequenceStepId\":6,\"SkillId\":35},{\"SequenceStepId\":7,\"SkillId\":37},{\"SequenceStepId\":8,\"SkillId\":35}]" },
                    { 17, 9, 100, 50, "[{\"SequenceStepId\":1,\"SkillId\":38},{\"SequenceStepId\":2,\"SkillId\":38},{\"SequenceStepId\":3,\"SkillId\":38},{\"SequenceStepId\":4,\"SkillId\":39},{\"SequenceStepId\":5,\"SkillId\":38},{\"SequenceStepId\":6,\"SkillId\":38},{\"SequenceStepId\":7,\"SkillId\":42},{\"SequenceStepId\":8,\"SkillId\":38},{\"SequenceStepId\":9,\"SkillId\":42},{\"SequenceStepId\":10,\"SkillId\":39}]" },
                    { 18, 9, 50, 0, "[{\"SequenceStepId\":1,\"SkillId\":40},{\"SequenceStepId\":2,\"SkillId\":40},{\"SequenceStepId\":3,\"SkillId\":40},{\"SequenceStepId\":4,\"SkillId\":42},{\"SequenceStepId\":5,\"SkillId\":41},{\"SequenceStepId\":6,\"SkillId\":40},{\"SequenceStepId\":7,\"SkillId\":40},{\"SequenceStepId\":8,\"SkillId\":42},{\"SequenceStepId\":9,\"SkillId\":40},{\"SequenceStepId\":10,\"SkillId\":42},{\"SequenceStepId\":11,\"SkillId\":41}]" },
                    { 19, 10, 100, 0, "[{\"SequenceStepId\":1,\"SkillId\":43},{\"SequenceStepId\":2,\"SkillId\":45},{\"SequenceStepId\":3,\"SkillId\":44},{\"SequenceStepId\":4,\"SkillId\":45}]" },
                    { 20, 11, 100, 66, "[{\"SequenceStepId\":1,\"SkillId\":46},{\"SequenceStepId\":2,\"SkillId\":46},{\"SequenceStepId\":3,\"SkillId\":47},{\"SequenceStepId\":4,\"SkillId\":46},{\"SequenceStepId\":5,\"SkillId\":52},{\"SequenceStepId\":6,\"SkillId\":47}]" },
                    { 21, 11, 66, 33, "[{\"SequenceStepId\":1,\"SkillId\":48},{\"SequenceStepId\":2,\"SkillId\":48},{\"SequenceStepId\":3,\"SkillId\":49},{\"SequenceStepId\":4,\"SkillId\":53},{\"SequenceStepId\":5,\"SkillId\":49},{\"SequenceStepId\":6,\"SkillId\":46},{\"SequenceStepId\":7,\"SkillId\":46}]" },
                    { 22, 11, 33, 0, "[{\"SequenceStepId\":1,\"SkillId\":50},{\"SequenceStepId\":2,\"SkillId\":48},{\"SequenceStepId\":3,\"SkillId\":48},{\"SequenceStepId\":4,\"SkillId\":53},{\"SequenceStepId\":5,\"SkillId\":51},{\"SequenceStepId\":6,\"SkillId\":50},{\"SequenceStepId\":7,\"SkillId\":48},{\"SequenceStepId\":8,\"SkillId\":49}]" },
                    { 23, 12, 100, 66, "[{\"SequenceStepId\":1,\"SkillId\":54},{\"SequenceStepId\":2,\"SkillId\":61},{\"SequenceStepId\":3,\"SkillId\":55},{\"SequenceStepId\":4,\"SkillId\":54},{\"SequenceStepId\":5,\"SkillId\":54},{\"SequenceStepId\":6,\"SkillId\":55}]" },
                    { 24, 12, 66, 33, "[{\"SequenceStepId\":1,\"SkillId\":56},{\"SequenceStepId\":2,\"SkillId\":56},{\"SequenceStepId\":3,\"SkillId\":57},{\"SequenceStepId\":4,\"SkillId\":54},{\"SequenceStepId\":5,\"SkillId\":56},{\"SequenceStepId\":6,\"SkillId\":60},{\"SequenceStepId\":7,\"SkillId\":57}]" },
                    { 25, 12, 33, 0, "[{\"SequenceStepId\":1,\"SkillId\":58},{\"SequenceStepId\":2,\"SkillId\":56},{\"SequenceStepId\":3,\"SkillId\":61},{\"SequenceStepId\":4,\"SkillId\":58},{\"SequenceStepId\":5,\"SkillId\":56},{\"SequenceStepId\":6,\"SkillId\":58},{\"SequenceStepId\":7,\"SkillId\":61},{\"SequenceStepId\":8,\"SkillId\":59}]" },
                    { 26, 13, 100, 66, "[{\"SequenceStepId\":1,\"SkillId\":62},{\"SequenceStepId\":2,\"SkillId\":62},{\"SequenceStepId\":3,\"SkillId\":63},{\"SequenceStepId\":4,\"SkillId\":62},{\"SequenceStepId\":5,\"SkillId\":62},{\"SequenceStepId\":6,\"SkillId\":69}]" },
                    { 27, 13, 66, 33, "[{\"SequenceStepId\":1,\"SkillId\":64},{\"SequenceStepId\":2,\"SkillId\":65},{\"SequenceStepId\":3,\"SkillId\":62},{\"SequenceStepId\":4,\"SkillId\":64},{\"SequenceStepId\":5,\"SkillId\":64},{\"SequenceStepId\":6,\"SkillId\":68},{\"SequenceStepId\":7,\"SkillId\":62}]" },
                    { 28, 13, 33, 0, "[{\"SequenceStepId\":1,\"SkillId\":66},{\"SequenceStepId\":2,\"SkillId\":69},{\"SequenceStepId\":3,\"SkillId\":67},{\"SequenceStepId\":4,\"SkillId\":64},{\"SequenceStepId\":5,\"SkillId\":66},{\"SequenceStepId\":6,\"SkillId\":69},{\"SequenceStepId\":7,\"SkillId\":68},{\"SequenceStepId\":8,\"SkillId\":67}]" },
                    { 29, 14, 100, 75, "[{\"SequenceStepId\":1,\"SkillId\":77},{\"SequenceStepId\":2,\"SkillId\":71},{\"SequenceStepId\":3,\"SkillId\":70},{\"SequenceStepId\":4,\"SkillId\":70},{\"SequenceStepId\":5,\"SkillId\":76},{\"SequenceStepId\":6,\"SkillId\":71}]" },
                    { 30, 14, 75, 50, "[{\"SequenceStepId\":1,\"SkillId\":72},{\"SequenceStepId\":2,\"SkillId\":72},{\"SequenceStepId\":3,\"SkillId\":73},{\"SequenceStepId\":4,\"SkillId\":72},{\"SequenceStepId\":5,\"SkillId\":70},{\"SequenceStepId\":6,\"SkillId\":76},{\"SequenceStepId\":7,\"SkillId\":73}]" },
                    { 31, 14, 50, 0, "[{\"SequenceStepId\":1,\"SkillId\":74},{\"SequenceStepId\":2,\"SkillId\":77},{\"SequenceStepId\":3,\"SkillId\":75},{\"SequenceStepId\":4,\"SkillId\":72},{\"SequenceStepId\":5,\"SkillId\":76},{\"SequenceStepId\":6,\"SkillId\":75},{\"SequenceStepId\":7,\"SkillId\":77},{\"SequenceStepId\":8,\"SkillId\":76},{\"SequenceStepId\":9,\"SkillId\":75},{\"SequenceStepId\":10,\"SkillId\":72},{\"SequenceStepId\":11,\"SkillId\":74}]" },
                    { 32, 15, 100, 0, "[{\"SequenceStepId\":1,\"SkillId\":78},{\"SequenceStepId\":2,\"SkillId\":78},{\"SequenceStepId\":3,\"SkillId\":79},{\"SequenceStepId\":4,\"SkillId\":78},{\"SequenceStepId\":5,\"SkillId\":80},{\"SequenceStepId\":6,\"SkillId\":79}]" }
                });

            migrationBuilder.InsertData(
                table: "EnemiesSkills",
                columns: new[] { "Id", "BaseHitChance", "DamageFactor", "EnemyId", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 80, 0.28000000000000003, 1, "Stroke", 0 },
                    { 2, 95, 0.47999999999999998, 1, "Cutting Axe", 1 },
                    { 3, 90, 0.38, 1, "Impact", 0 },
                    { 4, 100, 0.58999999999999997, 1, "Cruel Smash", 1 },
                    { 5, 70, 0.39000000000000001, 2, "Smash", 0 },
                    { 6, 85, 0.73999999999999999, 2, "Break Bones", 1 },
                    { 7, 75, 0.47999999999999998, 2, "Mace hit", 0 },
                    { 8, 90, 0.94999999999999996, 2, "Destructive lash", 1 },
                    { 9, 90, 0.29999999999999999, 3, "Quick Shot", 0 },
                    { 10, 100, 0.54000000000000004, 3, "Double Arrow", 1 }
                });

            migrationBuilder.InsertData(
                table: "EnemiesSkills",
                columns: new[] { "Id", "BaseHitChance", "DamageFactor", "EnemyId", "Name", "Type" },
                values: new object[,]
                {
                    { 11, 90, 0.40000000000000002, 3, "Sneaky Shot", 0 },
                    { 12, 100, 0.75, 3, "Perfect Arrow", 1 },
                    { 13, 95, 0.39000000000000001, 4, "Peck", 0 },
                    { 14, 85, 0.59999999999999998, 4, "Cutting Claw", 1 },
                    { 15, 100, 0.81999999999999995, 4, "Dangerous Beak", 1 },
                    { 16, 100, 0.46999999999999997, 4, "Scratch", 0 },
                    { 17, 90, 0.94999999999999996, 4, "Bloody Claws", 1 },
                    { 18, 105, 1.4099999999999999, 4, "Triple Scratch", 1 },
                    { 19, 100, 1.0, 5, "Simple Attack [pattern I]", 0 },
                    { 20, 100, 4.0, 5, "Strong Attack [pattern I]", 1 },
                    { 21, 100, 2.0, 5, "Simple Attack [pattern II]", 0 },
                    { 22, 100, 9.0, 5, "Strong Attack [pattern II]", 1 },
                    { 23, 80, 0.34000000000000002, 6, "Mace strike", 0 }
                });

            migrationBuilder.InsertData(
                table: "EnemiesSkills",
                columns: new[] { "Id", "ArmorPenetrationPercent", "BaseHitChance", "DamageFactor", "EnemyId", "Name", "Type" },
                values: new object[,]
                {
                    { 24, 12, 90, 0.71999999999999997, 6, "Cruel Hit", 1 },
                    { 25, 8, 85, 0.37, 6, "Simple Slug", 0 },
                    { 26, 12, 100, 0.87, 6, "Agonized Mace Strike", 1 }
                });

            migrationBuilder.InsertData(
                table: "EnemiesSkills",
                columns: new[] { "Id", "BaseHitChance", "DamageFactor", "EnemyId", "Name", "Type" },
                values: new object[,]
                {
                    { 27, 122, 0.20000000000000001, 6, "Shocking Strike", 4 },
                    { 28, 105, 0.41999999999999998, 7, "Quick Bite", 0 },
                    { 29, 99, 0.76000000000000001, 7, "Triple Bite", 1 }
                });

            migrationBuilder.InsertData(
                table: "EnemiesSkills",
                columns: new[] { "Id", "ArmorPenetrationPercent", "BaseHitChance", "DamageFactor", "EnemyId", "Name", "Type" },
                values: new object[,]
                {
                    { 30, -2, 109, 0.47999999999999998, 7, "Precise Scratch", 0 },
                    { 31, -1, 94, 0.92000000000000004, 7, "Harmful Fangs", 1 }
                });

            migrationBuilder.InsertData(
                table: "EnemiesSkills",
                columns: new[] { "Id", "BaseHitChance", "DamageFactor", "EnemyId", "Name", "Type" },
                values: new object[,]
                {
                    { 32, 120, 0.33000000000000002, 7, "Devouring Howl", 4 },
                    { 33, 95, 0.38, 8, "Branch Strike", 0 }
                });

            migrationBuilder.InsertData(
                table: "EnemiesSkills",
                columns: new[] { "Id", "ArmorPenetrationPercent", "BaseHitChance", "DamageFactor", "EnemyId", "Name", "Type" },
                values: new object[,]
                {
                    { 34, 10, 90, 0.68000000000000005, 8, "Fury Stalks", 1 },
                    { 35, 5, 90, 0.40999999999999998, 8, "Striking Vines", 0 },
                    { 36, 10, 85, 0.83999999999999997, 8, "Whirling Sprouts", 1 }
                });

            migrationBuilder.InsertData(
                table: "EnemiesSkills",
                columns: new[] { "Id", "BaseHitChance", "DamageFactor", "EnemyId", "Name", "Type" },
                values: new object[,]
                {
                    { 37, 130, 0.26000000000000001, 8, "Entangle", 4 },
                    { 38, 100, 0.41999999999999998, 9, "Smashing Tail", 0 },
                    { 39, 105, 0.90000000000000002, 9, "Lions Bite", 1 },
                    { 40, 95, 0.5, 9, "Sneaky Tail Bait", 0 },
                    { 41, 110, 1.1799999999999999, 9, "Flame Breath", 1 },
                    { 42, 130, 0.64000000000000001, 9, "Poisoned Teeth", 4 },
                    { 43, 100, 4.0, 10, "Simple Attack [pattern I]", 0 },
                    { 44, 100, 2.0, 10, "Stunning Attack [pattern I]", 4 },
                    { 45, 100, 7.0, 10, "Strong Attack [pattern I]", 1 },
                    { 46, 95, 0.51000000000000001, 11, "Scratch", 0 },
                    { 47, 100, 1.3700000000000001, 11, "Vampire Bait", 1 },
                    { 48, 90, 0.56999999999999995, 11, "Wing Slap", 0 },
                    { 49, 105, 1.46, 11, "Dangerous Claws", 1 },
                    { 50, 85, 0.60999999999999999, 11, "Cutting Clutches", 0 }
                });

            migrationBuilder.InsertData(
                table: "EnemiesSkills",
                columns: new[] { "Id", "ArmorPenetrationPercent", "BaseHitChance", "DamageFactor", "EnemyId", "Name", "Type" },
                values: new object[] { 51, 5, 120, 1.9199999999999999, 11, "Puncturing Sting", 1 });

            migrationBuilder.InsertData(
                table: "EnemiesSkills",
                columns: new[] { "Id", "BaseHitChance", "DamageFactor", "EnemyId", "Name", "Type" },
                values: new object[] { 52, 90, 0.45000000000000001, 11, "Hypnosis", 4 });

            migrationBuilder.InsertData(
                table: "EnemiesSkills",
                columns: new[] { "Id", "ArmorPenetrationPercent", "BaseHitChance", "DamageFactor", "EnemyId", "Name", "Type" },
                values: new object[] { 53, 5, 90, 1.1399999999999999, 11, "Whirling Wings", 2 });

            migrationBuilder.InsertData(
                table: "EnemiesSkills",
                columns: new[] { "Id", "BaseHitChance", "DamageFactor", "EnemyId", "Name", "Type" },
                values: new object[,]
                {
                    { 54, 90, 0.53000000000000003, 12, "Dark Blade", 0 },
                    { 55, 100, 1.46, 12, "Demonic Curse", 1 },
                    { 56, 95, 0.60999999999999999, 12, "Hunting Daggers", 0 },
                    { 57, 100, 1.8500000000000001, 12, "Mind Ripping ", 1 },
                    { 58, 100, 0.67000000000000004, 12, "Cutting Darkness", 0 },
                    { 59, 105, 2.1200000000000001, 12, "Soul Devastation", 1 },
                    { 60, 130, 0.51000000000000001, 12, "Possession", 4 },
                    { 61, 100, 1.2, 12, "Demon's Rush", 2 }
                });

            migrationBuilder.InsertData(
                table: "EnemiesSkills",
                columns: new[] { "Id", "ArmorPenetrationPercent", "BaseHitChance", "DamageFactor", "EnemyId", "Name", "Type" },
                values: new object[,]
                {
                    { 62, 5, 85, 0.48999999999999999, 13, "Spike", 0 },
                    { 63, 10, 90, 1.1799999999999999, 13, "Deep Stab", 1 },
                    { 64, 5, 80, 0.51000000000000001, 13, "Dark Knife", 0 },
                    { 65, 10, 85, 1.21, 13, "Clapper Claw", 1 },
                    { 66, 5, 78, 0.55000000000000004, 13, "Maul", 0 },
                    { 67, 10, 87, 1.3300000000000001, 13, "Cleaving Fangs", 1 },
                    { 68, -3, 100, 0.33000000000000002, 13, "Shivering Howl", 4 }
                });

            migrationBuilder.InsertData(
                table: "EnemiesSkills",
                columns: new[] { "Id", "BaseHitChance", "DamageFactor", "EnemyId", "Name", "Type" },
                values: new object[] { 69, 133, 0.91000000000000003, 13, "Rushing Fury", 2 });

            migrationBuilder.InsertData(
                table: "EnemiesSkills",
                columns: new[] { "Id", "ArmorPenetrationPercent", "BaseHitChance", "DamageFactor", "EnemyId", "Name", "Type" },
                values: new object[,]
                {
                    { 70, 10, 100, 0.51000000000000001, 14, "Bite", 0 },
                    { 71, 12, 120, 0.91000000000000003, 14, "Strong Jaws", 1 },
                    { 72, 10, 95, 0.55000000000000004, 14, "Legs Beating", 0 },
                    { 73, 12, 130, 0.98999999999999999, 14, "Deep Sting", 1 },
                    { 74, 10, 85, 0.56999999999999995, 14, "Wounding cut", 0 },
                    { 75, 12, 80, 1.05, 14, "Trample", 1 },
                    { 76, 12, 140, 0.33000000000000002, 14, "Spiderweb", 4 },
                    { 77, 15, 160, 0.77000000000000002, 14, "Spider Stomp", 2 }
                });

            migrationBuilder.InsertData(
                table: "EnemiesSkills",
                columns: new[] { "Id", "BaseHitChance", "DamageFactor", "EnemyId", "Name", "Type" },
                values: new object[,]
                {
                    { 78, 100, 9.0, 15, "Simple Attack", 0 },
                    { 79, 100, 27.0, 15, "Strong Attack", 1 },
                    { 80, 100, 18.0, 15, "Charge", 2 }
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
