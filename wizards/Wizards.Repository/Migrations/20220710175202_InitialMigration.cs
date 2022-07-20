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
                    CurrentHealth = table.Column<int>(type: "int", nullable: false),
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
                    ItemEndurance = table.Column<double>(type: "float", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Precision = table.Column<int>(type: "int", nullable: false),
                    Specialization = table.Column<int>(type: "int", nullable: false),
                    MaxHealth = table.Column<int>(type: "int", nullable: false),
                    CurrentHealth = table.Column<int>(type: "int", nullable: false),
                    Reflex = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankPoints = table.Column<int>(type: "int", nullable: false),
                    TotalMatchPlayed = table.Column<int>(type: "int", nullable: false),
                    TotalMatchWin = table.Column<int>(type: "int", nullable: false),
                    TotalMatchLoose = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Restriction = table.Column<int>(type: "int", nullable: false),
                    AttributesId = table.Column<int>(type: "int", nullable: false),
                    BuyPrice = table.Column<int>(type: "int", nullable: false),
                    SellPrice = table.Column<int>(type: "int", nullable: false)
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
                    AttributesId = table.Column<int>(type: "int", nullable: false),
                    Gold = table.Column<int>(type: "int", nullable: false),
                    StatisticsId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heroes_HeroAttributes_AttributesId",
                        column: x => x.AttributesId,
                        principalTable: "HeroAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Heroes_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
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
                name: "HeroItems",
                columns: table => new
                {
                    HeroId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroItems", x => new { x.HeroId, x.ItemId });
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
                name: "IX_HeroItems_ItemId",
                table: "HeroItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_AttributesId",
                table: "Items",
                column: "AttributesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_Email",
                table: "Players",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserName",
                table: "Players",
                column: "UserName",
                unique: true);

            migrationBuilder.Sql("INSERT INTO Players(UserName,Password,Email,DateOfBirth) VALUES ('admin','admin','admin@wizard.com','1992-02-17T00:00:00');" +
                                 "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Meroving', 'Meroving_123', 'meroving@wizard.com', '1992-02-17T00:00:00');" +
                                 "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Ectelion', 'Ectelion_123', 'ectelion@wizards.com', '1994-04-09T00:00:00');" +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Tirion', 'Tirion_123', 'tirion@wizards.com', '1994-09-01T00:00:00');" +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Maluszek', 'Maluszek_123', 'maluszek@wizards.com', '2005-10-07T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Krzychu11', 'Krzychu11_123', 'krzychu11@wizards.com', '1983-09-02T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Gandalf', 'Gandalf_123', 'gandalf@wizards.com', '1993-04-27T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Heros', 'Heros_123', 'heros@wizards.com', '2010-06-06T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('MonsterTrack', 'MonsterTrack_123', 'monstertrack@wizards.com', '1998-03-23T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Diablo', 'Diablo_123', 'diablo@wizards.com', '1996-10-10T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Hektor', 'Hektor_123', 'hektor@wizards.com', '1999-05-24T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Demokles', 'Demokles_123', 'demokles@wizards.com', '1988-07-09T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Adam17', 'Adam17_123', 'adam17@wizards.com', '2004-07-08T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Komandos99', 'Komandos99_123', 'komandos99@wizards.com', '1985-03-22T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Kajtek', 'Kajtek_123', 'kajtek@wizards.com', '1995-03-09T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('KrolArtur', 'KrolArtur_123', 'krolartur@wizards.com', '1983-02-17T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Lamusek', 'Lamusek_123', 'lamusek@wizards.com', '2001-10-24T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Mordeczka11', 'Mordeczka11_123', 'mordeczka11@wizards.com', '1984-01-25T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Bartosz28', 'Bartosz28_123', 'bartosz28@wizards.com', '1994-12-23T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Seba', 'Seba_123', 'seba@wizards.com', '1991-02-07T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Kobra17', 'Kobra17_123', 'kobra17@wizards.com', '1987-02-23T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('KapitanKlos', 'KapitanKlos_123', 'kapitanklos@wizards.com', '1980-09-11T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Frodo', 'Frodo_123', 'frodo@wizards.com', '2002-12-03T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Morfeusz', 'Morfeusz_123', 'morfeusz@wizards.com', '2009-02-21T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('JuliuszCezar', 'JuliuszCezar_123', 'juliuszcezar@wizards.com', '1989-07-27T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Praktykant', 'Praktykant_123', 'praktykant@wizards.com', '1997-02-10T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('MokraJolka99', 'MokraJolka99_123', 'mokrajolka99@wizards.com', '2003-07-01T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('FanGothicka', 'FanGothicka_123', 'fangothicka@wizards.com', '2000-09-12T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Aurene', 'Aurene_123', 'aurene@wizards.com', '1982-05-07T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Master', 'Master_123', 'master@wizards.com', '1993-06-17T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Palacz22', 'Palacz22_123', 'palacz22@wizards.com', '1986-05-28T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Krzychu27', 'Krzychu27_123', 'krzychu27@wizards.com', '1992-07-27T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Zeus', 'Zeus_123', 'zeus@wizards.com', '2008-04-19T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Katapulta', 'Katapulta_123', 'katapulta@wizards.com', '2010-02-15T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Vergiliusz', 'Vergiliusz_123', 'vergiliusz@wizards.com', '1992-02-11T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Mozart21', 'Mozart21_123', 'mozart21@wizards.com', '1997-10-17T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Kozak12', 'Kozak12_123', 'kozak12@wizards.com', '1999-05-09T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('LubiePlacki', 'LubiePlacki_123', 'lubieplacki@wizards.com', '1986-07-22T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Barbara', 'Barbara_123', 'barbara@wizards.com', '1989-05-09T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('ArianaGrande', 'ArianaGrande_123', 'arianagrande@wizards.com', '1980-02-19T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Polemik', 'Polemik_123', 'polemik@wizards.com', '1994-01-19T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Gruby', 'Gruby_123', 'gruby@wizards.com', '1981-05-13T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Komornik', 'Komornik_123', 'komornik@wizards.com', '1996-06-16T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('YakushiMamushi', 'YakushiMamushi_123', 'yakushimamushi@wizards.com', '1985-01-16T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Laleczka', 'Laleczka_123', 'laleczka@wizards.com', '2006-03-17T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Calineczka', 'Calineczka_123', 'calineczka@wizards.com', '2004-06-28T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('KubusPuchatek', 'KubusPuchatek_123', 'kubuspuchatek@wizards.com', '2001-01-21T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('LondynskiMagazynier', 'LondynskiMagazynier_123', 'londynskimagazynier@wizards.com', '1995-08-01T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Kopacz', 'Kopacz_123', 'kopacz@wizards.com', '1989-02-14T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('BialyKogut', 'Bia�yKogut_123', 'bialykogut@wizards.com', '1983-05-24T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Grabarz', 'Grabarz_123', 'grabarz@wizards.com', '2009-03-08T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Anastazja', 'Anastazja_123', 'anastazja@wizards.com', '2005-05-08T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Mareczek', 'Mareczek_123', 'mareczek@wizards.com', '1997-03-02T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Wariacik', 'Wariacik_123', 'wariacik@wizards.com', '2000-11-20T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Kobra', 'Kobra_123', 'kobra@wizards.com', '1999-11-28T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Waldek', 'Waldek_123', 'waldek@wizards.com', '2005-11-10T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Kubeusz', 'Kubeusz_123', 'kubeusz@wizards.com', '1992-06-13T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Koxiarz', 'Koxiarz_123', 'koxiarz@wizards.com', '1983-04-14T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Quarior', 'Quarior_123', 'quarior@wizards.com', '2010-09-17T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('ElrondZRivendell', 'ElrondZRivendell_123', 'elrondzrivendell@wizards.com', '1987-05-10T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Maciek', 'Maciek_123', 'maciek@wizards.com', '1993-05-08T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Aragorn', 'Aragorn_123', 'aragorn@wizards.com', '2001-12-18T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('SarumanMondry', 'SarumanMondry_123', 'sarumanmondry@wizards.com', '1989-04-15T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Luzak22', 'Luzak22_123', 'luzak22@wizards.com', '2007-10-16T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('TaniaBenzyna', 'TaniaBenzyna_123', 'taniabenzyna@wizards.com', '1982-04-16T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('SkrzypekNaDachu', 'SkrzypekNaDachu_123', 'skrzypeknadachu@wizards.com', '1999-08-03T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Szparka29', 'Szparka29_123', 'szparka29@wizards.com', '2000-09-01T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Lemur', 'Lemur_123', 'lemur@wizards.com', '2005-01-19T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('KrolJulian', 'KrolJulian_123', 'kroljulian@wizards.com', '1987-10-19T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Merlin', 'Merlin_123', 'merlin@wizards.com', '1997-05-11T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Merlin19', 'Merlin19_123', 'merlin19@wizards.com', '2008-09-28T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('PapiezLeonVI', 'PapiezLeonVI_123', 'papiezleonvi@wizards.com', '1986-01-21T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Dastan', 'Dastan_123', 'dastan@wizards.com', '2000-01-19T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Wolontariusz', 'Wolontariusz_123', 'wolontariusz@wizards.com', '2002-07-09T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Kabanosek77', 'Kabanosek77_123', 'kabanosek77@wizards.com', '2003-05-02T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('KalasznikXD', 'KalasznikXD_123', 'kalasznikxd@wizards.com', '1995-11-06T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Mistrzunio', 'Mistrzunio_123', 'mistrzunio@wizards.com', '2007-05-24T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('WielkiDrag19', 'WielkiDrag19_123', 'wielkidrag19@wizards.com', '1997-09-28T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Gargamel', 'Gargamel_123', 'gargamel@wizards.com', '1980-02-12T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('UrukHai', 'UrukHai_123', 'urukhai@wizards.com', '1984-06-11T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Artemida', 'Artemida_123', 'artemida@wizards.com', '1981-12-24T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Atena', 'Atena_123', 'atena@wizards.com', '2002-05-08T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Galadriela', 'Galadriela_123', 'galadriela@wizards.com', '1994-05-13T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Orfeusz', 'Orfeusz_123', 'orfeusz@wizards.com', '2010-10-01T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Persefona', 'Persefona_123', 'persefona@wizards.com', '1986-03-19T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Kijanka', 'Kijanka_123', 'kijanka@wizards.com', '1990-06-06T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Kruk', 'Kruk_123', 'kruk@wizards.com', '2001-12-24T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Witkacy', 'Witkacy_123', 'witkacy@wizards.com', '1994-07-10T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Wokulski', 'Wokulski_123', 'wokulski@wizards.com', '1991-11-08T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Maro', 'Maro_123', 'maro@wizards.com', '2010-04-05T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('JanPawelII', 'JanPawelII_123', 'janpawelii@wizards.com', '1983-03-19T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Szymonek', 'Szymonek_123', 'szymonek@wizards.com', '1986-03-20T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Cyklop', 'Cyklop_123', 'cyklop@wizards.com', '1988-11-20T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Krystian', 'Krystian_123', 'krystian@wizards.com', '2000-03-01T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('FryderykChopin', 'FryderykChopin_123', 'fryderykchopin@wizards.com', '1988-03-05T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('JadeUrsusem', 'JadeUrsusem_123', 'jadeursusem@wizards.com', '1990-05-21T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Niobe', 'Niobe_123', 'niobe@wizards.com', '1992-10-23T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Gagarin', 'Gagarin_123', 'gagarin@wizards.com', '1986-04-01T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Kurczaaaak', 'Kurczaaaak_123', 'kurczaaaak@wizards.com', '2003-06-07T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Wojownik', 'Wojownik_123', 'wojownik@wizards.com', '1995-01-16T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('JohnyWalker', 'JohnyWalker_123', 'johnywalker@wizards.com', '2002-08-21T00:00:00'); " +
                                "INSERT INTO Players(UserName, Password, Email, DateOfBirth) VALUES('Kanapka-17', 'Komornik_123', 'testowy.email@xd.pl', '1995-10-23T00:00:00');"
                                 );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroItems");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "HeroAttributes");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "ItemAttributes");
        }
    }
}
