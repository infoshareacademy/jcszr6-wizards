using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wizards.Repository.Migrations
{
    public partial class CorrectCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemEndurance",
                table: "ItemAttributes");

            migrationBuilder.AlterColumn<int>(
                name: "TotalMatchWin",
                table: "Statistics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TotalMatchPlayed",
                table: "Statistics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TotalMatchLoose",
                table: "Statistics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RankPoints",
                table: "Statistics",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Tier",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "InUse",
                table: "HeroItems",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<double>(
                name: "ItemEndurance",
                table: "HeroItems",
                type: "float",
                nullable: false,
                defaultValue: 100.0);

            migrationBuilder.AlterColumn<int>(
                name: "Gold",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (125000, 2950, 2239, 711);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (25745, 1650, 227, 1423);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (1995, 814, 622, 192);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (47936, 4676, 3231, 1445);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (24791, 462, 188, 274);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (64539, 2900, 1882, 1018);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (55292, 2116, 566, 1550);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (86786, 3719, 2789, 930);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (118735, 4820, 1922, 2898);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (127271, 3379, 1137, 2242);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (142942, 2561, 1011, 1550);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (11675, 2005, 1014, 991);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (18768, 2146, 1056, 1090);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (105714, 1303, 443, 860);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (133075, 1353, 818, 535);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (96077, 2113, 1552, 561);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (149063, 1413, 650, 763);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (62495, 1612, 798, 814);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (70920, 598, 209, 389);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (72730, 1579, 969, 610);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (84335, 2200, 1129, 1071);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (67204, 1875, 870, 1005);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (35135, 2060, 1311, 749);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (45555, 3278, 2084, 1194);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (93396, 189, 107, 82);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (83764, 1541, 745, 796);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (58578, 1775, 1187, 588);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (57799, 2615, 1554, 1061);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (126876, 961, 717, 244);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (86335, 4095, 1556, 2539);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (118428, 1873, 992, 881);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (1340, 2794, 1431, 1363);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (10099, 107, 46, 61);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (56477, 3595, 1986, 1609);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (139476, 2815, 2012, 803);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (109927, 3889, 1745, 2144);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (91454, 4464, 3044, 1420);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (50742, 3235, 2283, 952);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (5603, 2811, 1021, 1790);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (142740, 132, 36, 96);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (133032, 1938, 1378, 560);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (118903, 3566, 2616, 950);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (130091, 1792, 797, 995);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (66637, 3209, 2053, 1156);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (18380, 203, 68, 135);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (99620, 820, 453, 367);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (137513, 1400, 933, 467);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (105505, 3360, 1454, 1906);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (133826, 3939, 2662, 1277);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (23050, 2834, 722, 2112);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (47705, 1954, 822, 1132);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (38397, 1589, 852, 737);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (104890, 3903, 2397, 1506);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (85613, 1625, 994, 631);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (37588, 2901, 1449, 1452);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (85981, 1518, 972, 546);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (32507, 1430, 593, 837);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (134652, 639, 356, 283);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (71604, 3155, 1680, 1475);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (13129, 1989, 980, 1009);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (109321, 3924, 2462, 1462);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (53440, 3109, 2023, 1086);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (149334, 3152, 2031, 1121);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (138183, 3746, 2476, 1270);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (98381, 3852, 1668, 2184);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (24787, 3718, 2632, 1086);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (65762, 358, 129, 229);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (108690, 3929, 2075, 1854);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (57499, 4010, 1598, 2412);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (1159, 963, 417, 546);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (67788, 4466, 2879, 1587);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (103542, 4478, 1537, 2941);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (102646, 4719, 2199, 2520);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (30437, 2760, 1808, 952);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (72429, 2517, 1615, 902);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (54540, 2210, 760, 1450);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (81957, 4173, 2078, 2095);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (2698, 1007, 510, 497);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (110251, 4917, 2429, 2488);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (50685, 3077, 2230, 847);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (122841, 4975, 2057, 2918);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (41832, 2916, 1321, 1595);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (78723, 1219, 860, 359);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (125851, 4297, 2587, 1710);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (23048, 1124, 453, 671);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (141841, 482, 195, 287);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (114175, 3987, 2155, 1832);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (75324, 4508, 1428, 3080);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (128265, 187, 62, 125);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (112651, 3272, 1245, 2027);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (145956, 3453, 2106, 1347);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (17629, 2116, 1373, 743);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (64690, 695, 295, 400);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (138534, 1576, 548, 1028);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (15383, 733, 467, 266);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (5827, 1813, 961, 852);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (108639, 4574, 2930, 1644);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (136247, 3862, 1984, 1878);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (38427, 2644, 1633, 1011);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (118859, 2813, 1893, 920);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (131863, 2408, 1157, 1251);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (18897, 884, 506, 378);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (25785, 1091, 363, 728);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (94067, 630, 206, 424);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (109684, 1971, 1377, 594);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (82759, 2492, 1345, 1147);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (62350, 654, 256, 398);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (87078, 897, 298, 599);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (52337, 3275, 1365, 1910);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (118325, 1649, 679, 970);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (93629, 364, 260, 104);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (98735, 4156, 2399, 1757);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (15526, 1167, 360, 807);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (124819, 3104, 2128, 976);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (114802, 3049, 1306, 1743);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (49859, 3338, 2198, 1140);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (46163, 507, 262, 245);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (55299, 4579, 1787, 2792);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (63210, 3225, 2255, 970);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (110129, 1412, 573, 839);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (119056, 1819, 880, 939);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (134779, 3738, 2777, 961);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (110183, 4198, 2352, 1846);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (100087, 380, 141, 239);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (132547, 2032, 1494, 538);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (22792, 4855, 1512, 3343);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (7133, 371, 120, 251);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (3859, 2278, 791, 1487);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (78399, 856, 526, 330);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (67703, 4154, 2795, 1359);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (48459, 1951, 1411, 540);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (90296, 3808, 1080, 2728);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (2397, 2383, 1625, 758);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (24990, 1012, 344, 668);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (3827, 3962, 1374, 2588);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (139421, 762, 526, 236);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (42031, 3706, 2131, 1575);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (99713, 1906, 825, 1081);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (56941, 4013, 1495, 2518);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (64268, 728, 224, 504);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (49863, 2761, 1842, 919);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (147505, 1242, 518, 724);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (4117, 4541, 1564, 2977);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (74134, 2933, 1450, 1483);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (57171, 1410, 434, 976);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (107273, 1178, 556, 622);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (65702, 4867, 3166, 1701);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (83093, 1180, 717, 463);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (127297, 1882, 693, 1189);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (71485, 4911, 2874, 2037);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (129044, 122, 46, 76);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (104723, 2958, 1369, 1589);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (7704, 3057, 1219, 1838);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (126814, 1394, 944, 450);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (127194, 1805, 1125, 680);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (51610, 2709, 1020, 1689);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (48710, 2080, 1477, 603);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (134141, 3797, 2821, 976);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (117207, 2774, 1459, 1315);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (10417, 885, 607, 278);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (63901, 645, 275, 370);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (27031, 4958, 2582, 2376);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (80817, 2331, 1084, 1247);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (146963, 3351, 1932, 1419);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (30452, 255, 164, 91);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (37823, 4012, 2839, 1173);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (118261, 213, 105, 108);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (115717, 2429, 758, 1671);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (44206, 4048, 2154, 1894);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (28132, 2118, 838, 1280);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (105029, 3530, 1519, 2011);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (24324, 2953, 1774, 1179);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (68363, 3593, 1649, 1944);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (55120, 1873, 699, 1174);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (62457, 1305, 734, 571);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (32217, 2546, 1842, 704);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (115637, 1316, 627, 689);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (137939, 3959, 1797, 2162);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (100752, 2574, 663, 1911);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (68929, 388, 278, 110);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (18483, 3831, 1002, 2829);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (18390, 991, 566, 425);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (24841, 4619, 3251, 1368);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (122131, 463, 250, 213);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (107981, 3474, 917, 2557);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (102537, 3633, 1603, 2030);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (128335, 3109, 2290, 819);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (69061, 4020, 2382, 1638);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (20710, 2950, 1555, 1395);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (33330, 1497, 817, 680);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (129957, 1038, 370, 668);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (115166, 4179, 2311, 1868);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (135192, 2006, 1161, 845);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (47541, 1052, 753, 299);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (90921, 4822, 3466, 1356);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (7989, 1866, 521, 1345);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (56031, 4076, 1590, 2486);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (47704, 2206, 837, 1369);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (87307, 142, 54, 88);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (23139, 1418, 737, 681);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (130976, 2188, 1504, 684);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (115464, 2537, 949, 1588);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (120263, 1891, 1188, 703);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (99872, 4244, 2198, 2046);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (84892, 4753, 1680, 3073);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (133874, 681, 505, 176);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (13564, 827, 242, 585);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (82518, 4902, 3533, 1369);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (25163, 4896, 2586, 2310);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (83435, 4696, 2437, 2259);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (27755, 389, 178, 211);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (15301, 692, 513, 179);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (123840, 4743, 3378, 1365);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (1841, 4787, 1686, 3101);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (57131, 4279, 1614, 2665);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (28224, 2271, 1659, 612);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (17443, 3428, 1580, 1848);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (99634, 4744, 2768, 1976);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (8250, 754, 340, 414);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (60150, 383, 275, 108);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (109277, 1856, 1153, 703);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (78515, 4680, 3205, 1475);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (25663, 4045, 1351, 2694);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (14565, 1711, 1150, 561);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (2974, 3396, 1925, 1471);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (115563, 1408, 859, 549);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (67365, 3972, 1856, 2116);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (124780, 4737, 2054, 2683);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (126986, 206, 122, 84);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (79357, 3156, 2155, 1001);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (49249, 1494, 647, 847);");
            migrationBuilder.Sql("INSERT INTO [Statistics](RankPoints, TotalMatchPlayed, TotalMatchWin, TotalMatchLoose) VALUES (57281, 4665, 3251, 1414);");

            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 5, 0, 25, 25, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 5, 0, 25, 25, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 5, 0, 10, 25, 25, 0, 5);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 7, 0, 50, 50, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 5, 0, 30, 30, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 6, 0, 47, 47, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 7, 0, 36, 36, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 5, 0, 26, 26, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 6, 0, 28, 28, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 6, 0, 41, 41, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 6, 0, 35, 35, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 7, 0, 46, 46, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 7, 0, 26, 26, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 5, 0, 30, 30, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 7, 0, 27, 27, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 6, 0, 26, 26, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 6, 0, 37, 37, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 6, 0, 39, 39, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 6, 0, 28, 28, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 7, 0, 47, 47, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 7, 0, 47, 47, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 5, 0, 26, 26, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 7, 0, 29, 29, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 5, 0, 33, 33, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 7, 0, 28, 28, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 5, 0, 25, 25, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 6, 0, 48, 48, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 7, 0, 27, 27, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 5, 0, 35, 35, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 5, 0, 46, 46, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 5, 0, 42, 42, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 5, 0, 27, 27, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 6, 0, 47, 47, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 5, 0, 25, 25, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 6, 0, 37, 37, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 5, 0, 39, 39, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 6, 0, 41, 41, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 7, 0, 37, 37, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 6, 0, 48, 48, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 7, 0, 49, 49, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 5, 0, 49, 49, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 6, 0, 31, 31, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 5, 0, 39, 39, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 6, 0, 46, 46, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 7, 0, 43, 43, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 7, 0, 35, 35, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 6, 0, 33, 33, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 7, 0, 40, 40, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 7, 0, 46, 46, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 6, 0, 25, 25, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 7, 0, 43, 43, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 5, 0, 43, 43, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 5, 0, 44, 44, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 6, 0, 43, 43, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 6, 0, 31, 31, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 5, 0, 25, 25, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 5, 0, 46, 46, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 5, 0, 32, 32, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 6, 0, 34, 34, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 6, 0, 34, 34, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 5, 0, 42, 42, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 7, 0, 39, 39, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 5, 0, 32, 32, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 5, 0, 46, 46, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 6, 0, 36, 36, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 5, 0, 39, 39, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 6, 0, 50, 50, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 7, 0, 31, 31, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 6, 0, 32, 32, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 6, 0, 30, 30, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 7, 0, 38, 38, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 5, 0, 33, 33, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 6, 0, 39, 39, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 5, 0, 38, 38, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 6, 0, 31, 31, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 7, 0, 25, 25, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 7, 0, 37, 37, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 7, 0, 47, 47, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 6, 0, 29, 29, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 5, 0, 45, 45, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 5, 0, 35, 35, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 7, 0, 49, 49, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 5, 0, 48, 48, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 7, 0, 44, 44, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 5, 0, 43, 43, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 5, 0, 46, 46, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 5, 0, 50, 50, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 5, 0, 29, 29, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 5, 0, 25, 25, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 5, 0, 40, 40, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 7, 0, 49, 49, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 6, 0, 39, 39, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 6, 0, 46, 46, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 5, 0, 25, 25, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 6, 0, 37, 37, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 7, 0, 30, 30, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 7, 0, 33, 33, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 5, 0, 34, 34, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 7, 0, 37, 37, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 6, 0, 33, 33, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 7, 0, 43, 43, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 6, 0, 47, 47, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 7, 0, 38, 38, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 6, 0, 35, 35, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 7, 0, 26, 26, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 5, 0, 38, 38, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 7, 0, 50, 50, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 7, 0, 50, 50, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 7, 0, 28, 28, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 5, 0, 39, 39, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 6, 0, 42, 42, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 5, 0, 50, 50, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 5, 0, 34, 34, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 7, 0, 36, 36, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 7, 0, 44, 44, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 5, 0, 39, 39, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 7, 0, 46, 46, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 6, 0, 41, 41, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 6, 0, 43, 43, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 7, 0, 47, 47, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 5, 0, 41, 41, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 6, 0, 31, 31, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 5, 0, 41, 41, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 7, 0, 37, 37, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 5, 0, 48, 48, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 5, 0, 40, 40, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 6, 0, 29, 29, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 7, 0, 48, 48, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 6, 0, 37, 37, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 5, 0, 36, 36, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 7, 0, 45, 45, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 6, 0, 49, 49, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 6, 0, 30, 30, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 7, 0, 41, 41, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 7, 0, 47, 47, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 7, 0, 47, 47, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 5, 0, 26, 26, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 5, 0, 29, 29, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 7, 0, 38, 38, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 6, 0, 34, 34, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 7, 0, 47, 47, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 5, 0, 31, 31, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 6, 0, 35, 35, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 5, 0, 25, 25, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 5, 0, 31, 31, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 6, 0, 27, 27, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 6, 0, 45, 45, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 7, 0, 37, 37, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 6, 0, 46, 46, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 5, 0, 39, 39, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 5, 0, 36, 36, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 5, 0, 43, 43, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 7, 0, 27, 27, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 7, 0, 33, 33, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 5, 0, 49, 49, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 5, 0, 39, 39, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 6, 0, 34, 34, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 6, 0, 30, 30, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 5, 0, 42, 42, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 6, 0, 43, 43, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 7, 0, 38, 38, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 7, 0, 29, 29, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 7, 0, 33, 33, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 5, 0, 48, 48, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 6, 0, 42, 42, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 5, 0, 42, 42, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 7, 0, 49, 49, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 6, 0, 31, 31, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 6, 0, 37, 37, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 7, 0, 35, 35, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 7, 0, 39, 39, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 5, 0, 36, 36, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 6, 0, 47, 47, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 6, 0, 36, 36, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 7, 0, 41, 41, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 5, 0, 31, 31, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 7, 0, 42, 42, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 7, 0, 36, 36, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 5, 0, 33, 33, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 6, 0, 33, 33, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 5, 0, 25, 25, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 7, 0, 37, 37, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 7, 0, 48, 48, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 6, 0, 45, 45, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 5, 0, 32, 32, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 6, 0, 33, 33, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 6, 0, 41, 41, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 5, 0, 49, 49, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 7, 0, 34, 34, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 6, 0, 46, 46, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 6, 0, 41, 41, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 7, 0, 31, 31, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 6, 0, 41, 41, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 5, 0, 43, 43, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 5, 0, 47, 47, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 7, 0, 46, 46, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 6, 0, 43, 43, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 6, 0, 34, 34, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 7, 0, 35, 35, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 7, 0, 45, 45, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 13, 7, 0, 40, 40, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 6, 0, 25, 25, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 5, 0, 32, 32, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 6, 0, 38, 38, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 5, 0, 31, 31, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 6, 0, 28, 28, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 7, 0, 43, 43, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 5, 0, 43, 43, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 5, 0, 40, 40, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 7, 0, 28, 28, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 6, 0, 37, 37, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 6, 0, 35, 35, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 6, 0, 26, 26, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 7, 0, 34, 34, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 6, 0, 49, 49, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 7, 0, 36, 36, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 6, 0, 25, 25, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 6, 0, 34, 34, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 10, 5, 0, 41, 41, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 6, 0, 49, 49, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 6, 0, 40, 40, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 6, 0, 30, 30, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 11, 7, 0, 33, 33, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 5, 0, 44, 44, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 5, 0, 32, 32, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 7, 0, 36, 36, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 6, 0, 43, 43, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 7, 0, 30, 30, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 5, 0, 48, 48, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 12, 6, 0, 47, 47, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 15, 5, 0, 27, 27, 0, 0);");
            migrationBuilder.Sql("INSERT INTO HeroAttributes(DailyRewardEnergy, Damage, Precision, Specialization, MaxHealth, CurrentHealth, Reflex, Defense) VALUES (10, 14, 6, 0, 34, 34, 0, 0);");

            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Meriadon', 0, 7, 1, 250000, 1, 1);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Iberion', 0, 3, 2, 50000, 2, 1);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Diablo Pablo', 1, 4, 3, 500, 3, 1);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Gelantres', 0, 7, 4, 38536, 4, 2);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Morion', 0, 3, 5, 11347, 5, 3);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Durian Twardy', 0, 2, 6, 13544, 6, 4);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Lathron', 0, 4, 7, 28194, 7, 5);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Gajard', 0, 3, 8, 4326, 8, 6);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Leris', 0, 2, 9, 14377, 9, 7);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Onion', 0, 6, 10, 14842, 10, 8);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Mordka', 0, 4, 11, 38520, 11, 9);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Kosmoter Mix', 0, 6, 12, 33591, 12, 10);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Kruuk', 0, 4, 13, 26553, 13, 11);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Qmag', 0, 6, 14, 43398, 14, 12);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Nartus', 0, 4, 15, 4143, 15, 13);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Berion', 0, 1, 16, 9404, 16, 14);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Leopold Staff', 0, 7, 17, 21823, 17, 15);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Mimosa', 0, 4, 18, 16040, 18, 16);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Grand Master', 0, 2, 19, 34495, 19, 17);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Gandalf', 0, 4, 20, 11425, 20, 18);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Priam', 0, 5, 21, 5329, 21, 19);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Mefisto', 0, 2, 22, 38207, 22, 20);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('NEO', 0, 5, 23, 18908, 23, 21);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Morpheus', 0, 2, 24, 47686, 24, 22);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Gadzina', 0, 3, 25, 3241, 25, 23);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Rankorn', 0, 5, 26, 4892, 26, 24);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Harry Potter', 0, 2, 27, 1514, 27, 25);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Twoja Stara', 0, 7, 28, 31703, 28, 26);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Filius', 0, 2, 29, 39806, 29, 27);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Kamron', 0, 6, 30, 12048, 30, 28);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Domenor', 0, 4, 31, 45804, 31, 29);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Voldemort', 0, 5, 32, 47856, 32, 30);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Karakal', 0, 4, 33, 13416, 33, 31);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Linkoln', 0, 4, 34, 6472, 34, 32);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Peroso Walzor', 0, 7, 35, 26043, 35, 33);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Qu Scalzus', 0, 6, 36, 44649, 36, 34);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Rhodan Horto', 0, 7, 37, 47095, 37, 35);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Haqus Gax', 0, 1, 38, 5593, 38, 36);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Zopium Xaxum', 0, 3, 39, 5288, 39, 37);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Ogondo Arqinzo', 0, 5, 40, 13951, 40, 38);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Gunnar', 0, 7, 41, 27593, 41, 39);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Lunar', 0, 3, 42, 7547, 42, 40);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Ereus', 0, 2, 43, 47916, 43, 41);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Meriedon', 0, 4, 44, 37699, 44, 42);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Kolendra', 0, 6, 45, 12833, 45, 43);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Brutus', 0, 7, 46, 11419, 46, 44);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Korneliusz', 0, 6, 47, 32486, 47, 45);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Albus Dumbledore', 0, 6, 48, 27588, 48, 46);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Levenstine', 0, 6, 49, 7844, 49, 47);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Markus', 0, 2, 50, 5095, 50, 48);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Kopernik', 0, 1, 51, 29493, 51, 49);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Lewandowski', 0, 7, 52, 8955, 52, 50);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Qwapos Platinah', 0, 7, 53, 499, 53, 51);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Horgellion Zuana', 0, 1, 54, 27666, 54, 52);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Zaedicus', 0, 1, 55, 47684, 55, 53);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Zulion', 0, 2, 56, 37530, 56, 54);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Celebrimbor', 0, 5, 57, 35306, 57, 55);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Maelstan Wuarto', 0, 4, 58, 6622, 58, 56);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Soren Anfarqo', 0, 6, 59, 39792, 59, 57);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Praxtoner Mzanga', 0, 5, 60, 35348, 60, 58);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Oren Noor', 0, 5, 61, 12672, 61, 59);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Jael Azim', 0, 3, 62, 16447, 62, 60);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Nusair Zev', 0, 7, 63, 32707, 63, 61);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Segel Kivi', 0, 1, 64, 39563, 64, 62);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Zarif Akim', 0, 1, 65, 43568, 65, 63);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Anas Mazhar', 0, 6, 66, 14075, 66, 64);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Azhar Miksa', 0, 1, 67, 46078, 67, 65);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Amadi Jarib', 0, 1, 68, 39867, 68, 66);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Glum Redpike', 0, 6, 69, 34189, 69, 67);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Ulf Froghead', 0, 7, 70, 28184, 70, 68);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Musa Khurram', 0, 4, 71, 6695, 71, 69);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Fox Yrresson', 0, 5, 72, 36346, 72, 70);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Uni the Pike', 0, 6, 73, 17338, 73, 71);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Sahir Nailah', 0, 1, 74, 9217, 74, 72);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Oxa the Rogue', 0, 1, 75, 30599, 75, 73);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Jaleel Haroun', 0, 2, 76, 34141, 76, 74);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Pyotr Yurikov', 0, 6, 77, 152, 77, 75);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Jasha Yashaov', 0, 1, 78, 24013, 78, 76);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Lar Haligsson', 0, 4, 79, 22529, 79, 77);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Mahmood Tibon', 0, 7, 80, 18503, 80, 78);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Oxa Redhammer', 0, 1, 81, 16015, 81, 79);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Boris the Rat', 0, 6, 82, 15658, 82, 80);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Yael Jamshaid', 0, 3, 83, 13232, 83, 81);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Lar Cedarwood', 0, 4, 84, 889, 84, 82);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Tellan Elmhome', 0, 3, 85, 12305, 85, 83);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Svein Grayring', 0, 3, 86, 37890, 86, 84);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Tosya of Livny', 0, 7, 87, 34349, 87, 85);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Arman Vladikov', 0, 7, 88, 46115, 88, 86);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Synn Goldwater', 0, 2, 89, 20799, 89, 87);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Scur Alderhome', 0, 3, 90, 20024, 90, 88);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Ketil the Pike', 0, 7, 91, 29393, 91, 89);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Odd the Dagger', 0, 4, 92, 4945, 92, 90);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Osric Oakgrove', 0, 6, 93, 7296, 93, 91);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Zivon the Bear', 0, 3, 94, 24310, 94, 92);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Ofeig Bluehelm', 0, 1, 95, 43330, 95, 93);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Ozur Bluearrow', 0, 3, 96, 46450, 96, 94);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Ivar the Knife', 0, 5, 97, 47267, 97, 95);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Isen Elderleaf', 0, 2, 98, 23858, 98, 96);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Hroald Pighead', 0, 5, 99, 21033, 99, 97);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Borya the Hare', 0, 4, 100, 5724, 100, 98);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Modig Greenmark', 0, 1, 101, 2100, 101, 99);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Gerhard Darkeye', 0, 1, 102, 15490, 102, 100);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Anhaga Birchson', 0, 1, 103, 20631, 103, 101);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Edlin Fireblade', 0, 1, 104, 46370, 104, 102);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Motya the Snake', 0, 3, 105, 3522, 105, 80);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Reule Wilyhands', 0, 6, 106, 47033, 106, 99);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Wregan Ormodson', 0, 7, 107, 44751, 107, 77);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Soren Greenseed', 0, 7, 108, 33472, 108, 42);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Geir Strongpike', 0, 6, 109, 19842, 109, 13);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Tellan Crocfoot', 0, 7, 110, 19471, 110, 8);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Modig Bluestaff', 0, 4, 111, 34711, 111, 72);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Valerik Levkaov', 0, 2, 112, 32400, 112, 45);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Warian Oakgrove', 0, 3, 113, 44436, 113, 25);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Yngvar Oaklance', 0, 3, 114, 43395, 114, 98);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Attor Eldergold', 0, 7, 115, 21851, 115, 24);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Thorir Jadehelm', 0, 1, 116, 36945, 116, 66);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Illugi the Deer', 0, 1, 117, 26164, 117, 72);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Modig Moonstone', 0, 5, 118, 33583, 118, 25);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Botolf Oaksaber', 0, 7, 119, 35611, 119, 62);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Vladik of Ozhsk', 0, 3, 120, 20469, 120, 35);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Stefan the Rock', 0, 7, 121, 20553, 121, 21);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Egor the Lizard', 0, 5, 122, 47452, 122, 78);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Lukyan the Tall', 0, 3, 123, 15140, 123, 81);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Hogni Dinohunter', 0, 1, 124, 27270, 124, 43);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Edlin Maccussson', 0, 5, 125, 36152, 125, 55);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Ivar Crowtrapper', 0, 5, 126, 9681, 126, 60);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Yakov the Badger', 0, 6, 127, 17892, 127, 61);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Rheged Galansson', 0, 2, 128, 40766, 128, 68);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Halvard Moonfish', 0, 3, 129, 35337, 129, 40);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Oxa Diamondstaff', 0, 2, 130, 37777, 130, 56);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Snorri Graylance', 0, 7, 131, 30075, 131, 47);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Mikhail the Deer', 0, 6, 132, 15304, 132, 38);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Karolek of Duben', 0, 1, 133, 8664, 133, 36);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Strang Firelance', 0, 1, 134, 692, 134, 44);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Deogol Cedarleaf', 0, 4, 135, 13151, 135, 84);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Kiril Valerikski', 0, 6, 136, 10762, 136, 91);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Finn Macewielder', 0, 5, 137, 30243, 137, 27);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Ormod Brogansson', 0, 1, 138, 22531, 138, 14);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Kenric Bloodclub', 0, 2, 139, 25866, 139, 41);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Lar Bronzedagger', 0, 1, 140, 20117, 140, 52);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Lizard Tellanson', 0, 3, 141, 37430, 141, 90);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Thorgils the Axe', 0, 4, 142, 25720, 142, 17);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Thorhall Oakmark', 0, 1, 143, 12369, 143, 16);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Soren Yellowbird', 0, 1, 144, 1151, 144, 96);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Lar Lancebreaker', 0, 5, 145, 126, 145, 14);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Runolf Ofeigssen', 0, 7, 146, 2075, 146, 30);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Gaderian Oxasson', 0, 5, 147, 14472, 147, 39);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Sighvat the Goat', 0, 3, 148, 27565, 148, 89);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Onund the Monkey', 0, 7, 149, 17327, 149, 9);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Stefan Dimitriov', 0, 2, 150, 46369, 150, 64);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Solvi the Monkey', 0, 7, 151, 36284, 151, 9);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Eyjolf Goatherder', 0, 3, 152, 15680, 152, 11);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Michel Slightcuts', 0, 4, 153, 20879, 153, 87);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Hjalti Goldshield', 0, 5, 154, 7529, 154, 24);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Fredek the Hermit', 0, 7, 155, 29328, 155, 97);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Hardouin Silkcuts', 0, 3, 156, 29732, 156, 45);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Torr Staffthrower', 0, 7, 157, 17360, 157, 62);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Odon the Torturer', 0, 5, 158, 4715, 158, 98);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Penrith Aldredson', 0, 1, 159, 49285, 159, 94);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Valerik the Tiger', 0, 4, 160, 22276, 160, 7);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Demon Awierganson', 0, 4, 161, 41446, 161, 6);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Konrad Whitestone', 0, 4, 162, 46598, 162, 4);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Sigmund Bronzeaxe', 0, 7, 163, 36691, 163, 54);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Ketil Pikewielder', 0, 2, 164, 27913, 164, 89);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Aldhelm Starblade', 0, 1, 165, 2100, 165, 88);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Tamar Diamondmace', 0, 2, 166, 19202, 166, 76);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Vasilii the Shark', 0, 2, 167, 48398, 167, 50);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Besyrwan Jadehelm', 0, 2, 168, 642, 168, 65);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Adrik the Bastard', 0, 4, 169, 12605, 169, 90);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Edlin Snakerunner', 0, 5, 170, 23356, 170, 5);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Zivon the Grizzly', 0, 6, 171, 20828, 171, 16);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Thorgeir the Mace', 0, 1, 172, 38426, 172, 3);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Deogol Wyrmseeker', 0, 1, 173, 13762, 173, 95);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Yakov the Bastard', 0, 3, 174, 35343, 174, 80);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Ivan of Verkhovsk', 0, 7, 175, 6686, 175, 78);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Eldgrim the Saber', 0, 6, 176, 5227, 176, 55);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Eystein Ironknife', 0, 6, 177, 959, 177, 75);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Snorri Greenarrow', 0, 3, 178, 9794, 178, 51);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Botolf the Cougar', 0, 6, 179, 23599, 179, 62);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Jasha the Panther', 0, 1, 180, 30542, 180, 70);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Sarlic Dinokiller', 0, 7, 181, 28982, 181, 28);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Fadeyka the Blind', 0, 3, 182, 11128, 182, 55);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Eyjolf Wyrmrunner', 0, 4, 183, 37876, 183, 43);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Finnbogi the Wyrm', 0, 4, 184, 15668, 184, 78);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Acennan Hardstone', 0, 2, 185, 41351, 185, 30);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Yngve Littleearth', 0, 3, 186, 828, 186, 34);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Tosya the Wayfarer', 0, 6, 187, 1813, 187, 89);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Avenal Nimblemover', 0, 4, 188, 27381, 188, 85);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Thorgils Dinotooth', 0, 4, 189, 49142, 189, 5);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Sergei Lukyanovich', 0, 2, 190, 24884, 190, 16);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Aart Arrowthruster', 0, 7, 191, 10659, 191, 34);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Ottar Gunnlaugsson', 0, 4, 192, 37523, 192, 12);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Egil Spearthrasher', 0, 6, 193, 6908, 193, 95);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Bardi Spearwielder', 0, 4, 194, 5, 194, 75);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Lodin Staffthrower', 0, 4, 195, 45642, 195, 42);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Vladik Stefanovich', 0, 4, 196, 8485, 196, 58);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Ingjald Isleifsson', 0, 1, 197, 41333, 197, 88);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Aldred Eagleherder', 0, 3, 198, 28398, 198, 53);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Illugi Goatcatcher', 0, 3, 199, 35420, 199, 31);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Hallfred Hoghunter', 0, 2, 200, 32624, 200, 55);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Geirstein Blueclub', 0, 6, 201, 19570, 201, 37);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Rodor the Torturer', 0, 4, 202, 14355, 202, 24);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Agramant Silkmover', 0, 7, 203, 30579, 203, 37);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Mikhail Vanechkaov', 0, 3, 204, 30564, 204, 40);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Bergthor the Staff', 0, 5, 205, 30762, 205, 25);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Grindan Yellowworm', 0, 2, 206, 4443, 206, 19);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Yngvar the Panther', 0, 6, 207, 45029, 207, 8);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Levka the Poisoner', 0, 5, 208, 25534, 208, 20);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Wregan Clubwielder', 0, 7, 209, 4912, 209, 32);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Cadmon Banningsson', 0, 1, 210, 29736, 210, 38);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Hafgrim Styrkarsen', 0, 6, 211, 8887, 211, 18);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Ormod Govannonsson', 0, 4, 212, 36445, 212, 11);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Prasutagus Haligson', 0, 2, 213, 35951, 213, 32);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Thorgrim Otryggssen', 0, 4, 214, 741, 214, 54);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Bertrand Tracehands', 0, 2, 215, 18056, 215, 61);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Yrre the Millwright', 0, 6, 216, 24103, 216, 14);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Arnfinn Beavertooth', 0, 4, 217, 7363, 217, 60);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Aart the Millwright', 0, 1, 218, 40497, 218, 31);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Geraint the Juggler', 0, 2, 219, 28867, 219, 44);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Sturla Saberbreaker', 0, 6, 220, 42083, 220, 66);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Geirstein the Staff', 0, 7, 221, 25939, 221, 90);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Gunnar Possumseeker', 0, 6, 222, 12153, 222, 98);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Hedin Thorbjornsson', 0, 4, 223, 11657, 223, 48);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Tamar the Fisherman', 0, 6, 224, 1478, 224, 92);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Rheged Whitemorning', 0, 3, 225, 26583, 225, 72);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Antinko Semyonovich', 0, 7, 226, 40029, 226, 48);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Thorfinn Whitesword', 0, 6, 227, 35288, 227, 56);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Athelstan Foxslayer', 0, 2, 228, 35553, 228, 53);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Mikhail the Leopard', 0, 6, 229, 11507, 229, 60);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Arnfinn Finnbogisen', 0, 3, 230, 39345, 230, 91);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Athelstan Faransson', 0, 1, 231, 40663, 231, 98);");
            migrationBuilder.Sql("INSERT INTO [Heroes](NickName, Profession, AvatarImageNumber, AttributesId, Gold, [StatisticsId], PlayerId) VALUES ('Lucan the Mercenary', 0, 6, 232, 47122, 232, 49);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tier",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemEndurance",
                table: "HeroItems");

            migrationBuilder.AlterColumn<int>(
                name: "TotalMatchWin",
                table: "Statistics",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TotalMatchPlayed",
                table: "Statistics",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TotalMatchLoose",
                table: "Statistics",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RankPoints",
                table: "Statistics",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ItemEndurance",
                table: "ItemAttributes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<bool>(
                name: "InUse",
                table: "HeroItems",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "Gold",
                table: "Heroes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);
        }
    }
}
