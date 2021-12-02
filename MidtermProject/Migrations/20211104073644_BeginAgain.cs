using Microsoft.EntityFrameworkCore.Migrations;

namespace MidtermProject.Migrations
{
    public partial class BeginAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    verb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AOE = table.Column<bool>(type: "bit", nullable: false),
                    TargetEnemies = table.Column<bool>(type: "bit", nullable: false),
                    Alter_Accuracy = table.Column<double>(type: "float", nullable: false),
                    Alter_Speed = table.Column<double>(type: "float", nullable: false),
                    Alter_Strength = table.Column<double>(type: "float", nullable: false),
                    Alter_Spell_Power = table.Column<double>(type: "float", nullable: false),
                    Alter_Armor = table.Column<double>(type: "float", nullable: false),
                    Alter_Magic_Resistance = table.Column<double>(type: "float", nullable: false),
                    Alter_HP = table.Column<double>(type: "float", nullable: false),
                    Alter_Mana = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hero_Names",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hero_Names", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Intro_Texts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intro_Texts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accuracy_Bonus = table.Column<double>(type: "float", nullable: false),
                    Speed_Bonus = table.Column<double>(type: "float", nullable: false),
                    Strength_Bonus = table.Column<double>(type: "float", nullable: false),
                    Spell_Power_Bonus = table.Column<double>(type: "float", nullable: false),
                    Armor_Bonus = table.Column<double>(type: "float", nullable: false),
                    Magic_Resistance_Bonus = table.Column<double>(type: "float", nullable: false),
                    HP_Bonus = table.Column<double>(type: "float", nullable: false),
                    Mana_Bonus = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accuracy = table.Column<double>(type: "float", nullable: false),
                    Speed = table.Column<double>(type: "float", nullable: false),
                    Strength = table.Column<double>(type: "float", nullable: false),
                    Spell_Power = table.Column<double>(type: "float", nullable: false),
                    Armor = table.Column<double>(type: "float", nullable: false),
                    Magic_Resistance = table.Column<double>(type: "float", nullable: false),
                    HP = table.Column<double>(type: "float", nullable: false),
                    Mana = table.Column<double>(type: "float", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hero_NamePlayer",
                columns: table => new
                {
                    Names_UsedId = table.Column<int>(type: "int", nullable: false),
                    PlayersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hero_NamePlayer", x => new { x.Names_UsedId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_Hero_NamePlayer_Hero_Names_Names_UsedId",
                        column: x => x.Names_UsedId,
                        principalTable: "Hero_Names",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hero_NamePlayer_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbilityUnit",
                columns: table => new
                {
                    AbilitiesId = table.Column<int>(type: "int", nullable: false),
                    units_with_abilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityUnit", x => new { x.AbilitiesId, x.units_with_abilityId });
                    table.ForeignKey(
                        name: "FK_AbilityUnit_Abilities_AbilitiesId",
                        column: x => x.AbilitiesId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbilityUnit_Unit_units_with_abilityId",
                        column: x => x.units_with_abilityId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enemy Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatureType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enemy Types", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enemy Types_Unit_Id",
                        column: x => x.Id,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hero Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hero Types", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hero Types_Unit_Id",
                        column: x => x.Id,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Player = table.Column<int>(type: "int", nullable: true),
                    ProperName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentExp = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heroes_Hero Types_Id",
                        column: x => x.Id,
                        principalTable: "Hero Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Heroes_Players_Player",
                        column: x => x.Player,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HeroItem",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    Owning_HeroesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroItem", x => new { x.InventoryId, x.Owning_HeroesId });
                    table.ForeignKey(
                        name: "FK_HeroItem_Heroes_Owning_HeroesId",
                        column: x => x.Owning_HeroesId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroItem_Items_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbilityUnit_units_with_abilityId",
                table: "AbilityUnit",
                column: "units_with_abilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Hero_NamePlayer_PlayersId",
                table: "Hero_NamePlayer",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_Player",
                table: "Heroes",
                column: "Player");

            migrationBuilder.CreateIndex(
                name: "IX_HeroItem_Owning_HeroesId",
                table: "HeroItem",
                column: "Owning_HeroesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilityUnit");

            migrationBuilder.DropTable(
                name: "Enemy Types");

            migrationBuilder.DropTable(
                name: "Hero_NamePlayer");

            migrationBuilder.DropTable(
                name: "HeroItem");

            migrationBuilder.DropTable(
                name: "Intro_Texts");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Hero_Names");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Hero Types");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Unit");
        }
    }
}
