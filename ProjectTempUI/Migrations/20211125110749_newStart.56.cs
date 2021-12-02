using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTempUI.Migrations
{
    public partial class newStart56 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    verb = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AOE = table.Column<bool>(type: "bit", nullable: false),
                    TargetEnemies = table.Column<bool>(type: "bit", nullable: false),
                    IsPhysical = table.Column<bool>(type: "bit", nullable: false),
                    Alter_Accuracy = table.Column<double>(type: "float", nullable: false),
                    Alter_Speed = table.Column<double>(type: "float", nullable: false),
                    Alter_Strength = table.Column<double>(type: "float", nullable: false),
                    Alter_Spell_Power = table.Column<double>(type: "float", nullable: false),
                    Alter_Armor = table.Column<double>(type: "float", nullable: false),
                    Alter_Magic_Resistance = table.Column<double>(type: "float", nullable: false),
                    Alter_HP = table.Column<double>(type: "float", nullable: false),
                    Alter_Mana = table.Column<double>(type: "float", nullable: false),
                    DamageDealt = table.Column<double>(type: "float", nullable: false),
                    Manacost = table.Column<double>(type: "float", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IsArchetype = table.Column<bool>(type: "bit", nullable: false),
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
                    IsMod = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FinishedSetup = table.Column<bool>(type: "bit", nullable: false),
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
                name: "HeroName <-> Player",
                columns: table => new
                {
                    Names_UsedId = table.Column<int>(type: "int", nullable: false),
                    PlayersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroName <-> Player", x => new { x.Names_UsedId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_HeroName <-> Player_Hero_Names_Names_UsedId",
                        column: x => x.Names_UsedId,
                        principalTable: "Hero_Names",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroName <-> Player_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player <-> Inventory Item",
                columns: table => new
                {
                    InventoryItemId = table.Column<int>(type: "int", nullable: false),
                    Owning_PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player <-> Inventory Item", x => new { x.InventoryItemId, x.Owning_PlayerId });
                    table.ForeignKey(
                        name: "FK_Player <-> Inventory Item_Items_InventoryItemId",
                        column: x => x.InventoryItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Player <-> Inventory Item_Players_Owning_PlayerId",
                        column: x => x.Owning_PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ability <-> Unit",
                columns: table => new
                {
                    AbilitiesId = table.Column<int>(type: "int", nullable: false),
                    unit_with_abilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ability <-> Unit", x => new { x.AbilitiesId, x.unit_with_abilityId });
                    table.ForeignKey(
                        name: "FK_Ability <-> Unit_Abilities_AbilitiesId",
                        column: x => x.AbilitiesId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ability <-> Unit_Unit_unit_with_abilityId",
                        column: x => x.unit_with_abilityId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enemy Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CreatureType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IntroText = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
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
                    ClassName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    classIndex = table.Column<int>(type: "int", nullable: false)
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
                    ProperName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CurrentExp = table.Column<double>(type: "float", nullable: false),
                    BaseHP = table.Column<double>(type: "float", nullable: false),
                    BaseMana = table.Column<double>(type: "float", nullable: false)
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
                name: "Hero <-> Item",
                columns: table => new
                {
                    EquippedItemId = table.Column<int>(type: "int", nullable: false),
                    Owning_HeroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hero <-> Item", x => new { x.EquippedItemId, x.Owning_HeroId });
                    table.ForeignKey(
                        name: "FK_Hero <-> Item_Heroes_Owning_HeroId",
                        column: x => x.Owning_HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hero <-> Item_Items_EquippedItemId",
                        column: x => x.EquippedItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ability <-> Unit_unit_with_abilityId",
                table: "Ability <-> Unit",
                column: "unit_with_abilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Hero <-> Item_Owning_HeroId",
                table: "Hero <-> Item",
                column: "Owning_HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_Player",
                table: "Heroes",
                column: "Player");

            migrationBuilder.CreateIndex(
                name: "IX_HeroName <-> Player_PlayersId",
                table: "HeroName <-> Player",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_Player <-> Inventory Item_Owning_PlayerId",
                table: "Player <-> Inventory Item",
                column: "Owning_PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ability <-> Unit");

            migrationBuilder.DropTable(
                name: "Enemy Types");

            migrationBuilder.DropTable(
                name: "Hero <-> Item");

            migrationBuilder.DropTable(
                name: "HeroName <-> Player");

            migrationBuilder.DropTable(
                name: "Intro_Texts");

            migrationBuilder.DropTable(
                name: "Player <-> Inventory Item");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Hero_Names");

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
