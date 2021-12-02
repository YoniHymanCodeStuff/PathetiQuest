using Microsoft.EntityFrameworkCore.Migrations;

namespace MidtermProject.Migrations
{
    public partial class tableNamesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbilityUnit_Abilities_AbilitiesId",
                table: "AbilityUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_AbilityUnit_Unit_units_with_abilityId",
                table: "AbilityUnit");

            migrationBuilder.DropForeignKey(
                name: "FK_Hero_NamePlayer_Hero_Names_Names_UsedId",
                table: "Hero_NamePlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_Hero_NamePlayer_Players_PlayersId",
                table: "Hero_NamePlayer");

            migrationBuilder.DropForeignKey(
                name: "FK_HeroItem_Heroes_Owning_HeroesId",
                table: "HeroItem");

            migrationBuilder.DropForeignKey(
                name: "FK_HeroItem_Items_InventoryId",
                table: "HeroItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HeroItem",
                table: "HeroItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hero_NamePlayer",
                table: "Hero_NamePlayer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AbilityUnit",
                table: "AbilityUnit");

            migrationBuilder.RenameTable(
                name: "HeroItem",
                newName: "Hero <-> Item");

            migrationBuilder.RenameTable(
                name: "Hero_NamePlayer",
                newName: "HeroName <-> Player");

            migrationBuilder.RenameTable(
                name: "AbilityUnit",
                newName: "Ability <-> Unit");

            migrationBuilder.RenameColumn(
                name: "Owning_HeroesId",
                table: "Hero <-> Item",
                newName: "Owning_HeroId");

            migrationBuilder.RenameColumn(
                name: "InventoryId",
                table: "Hero <-> Item",
                newName: "InventoryItemId");

            migrationBuilder.RenameIndex(
                name: "IX_HeroItem_Owning_HeroesId",
                table: "Hero <-> Item",
                newName: "IX_Hero <-> Item_Owning_HeroId");

            migrationBuilder.RenameIndex(
                name: "IX_Hero_NamePlayer_PlayersId",
                table: "HeroName <-> Player",
                newName: "IX_HeroName <-> Player_PlayersId");

            migrationBuilder.RenameColumn(
                name: "units_with_abilityId",
                table: "Ability <-> Unit",
                newName: "unit_with_abilityId");

            migrationBuilder.RenameIndex(
                name: "IX_AbilityUnit_units_with_abilityId",
                table: "Ability <-> Unit",
                newName: "IX_Ability <-> Unit_unit_with_abilityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hero <-> Item",
                table: "Hero <-> Item",
                columns: new[] { "InventoryItemId", "Owning_HeroId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeroName <-> Player",
                table: "HeroName <-> Player",
                columns: new[] { "Names_UsedId", "PlayersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ability <-> Unit",
                table: "Ability <-> Unit",
                columns: new[] { "AbilitiesId", "unit_with_abilityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ability <-> Unit_Abilities_AbilitiesId",
                table: "Ability <-> Unit",
                column: "AbilitiesId",
                principalTable: "Abilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ability <-> Unit_Unit_unit_with_abilityId",
                table: "Ability <-> Unit",
                column: "unit_with_abilityId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hero <-> Item_Heroes_Owning_HeroId",
                table: "Hero <-> Item",
                column: "Owning_HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hero <-> Item_Items_InventoryItemId",
                table: "Hero <-> Item",
                column: "InventoryItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HeroName <-> Player_Hero_Names_Names_UsedId",
                table: "HeroName <-> Player",
                column: "Names_UsedId",
                principalTable: "Hero_Names",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HeroName <-> Player_Players_PlayersId",
                table: "HeroName <-> Player",
                column: "PlayersId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ability <-> Unit_Abilities_AbilitiesId",
                table: "Ability <-> Unit");

            migrationBuilder.DropForeignKey(
                name: "FK_Ability <-> Unit_Unit_unit_with_abilityId",
                table: "Ability <-> Unit");

            migrationBuilder.DropForeignKey(
                name: "FK_Hero <-> Item_Heroes_Owning_HeroId",
                table: "Hero <-> Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Hero <-> Item_Items_InventoryItemId",
                table: "Hero <-> Item");

            migrationBuilder.DropForeignKey(
                name: "FK_HeroName <-> Player_Hero_Names_Names_UsedId",
                table: "HeroName <-> Player");

            migrationBuilder.DropForeignKey(
                name: "FK_HeroName <-> Player_Players_PlayersId",
                table: "HeroName <-> Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HeroName <-> Player",
                table: "HeroName <-> Player");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hero <-> Item",
                table: "Hero <-> Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ability <-> Unit",
                table: "Ability <-> Unit");

            migrationBuilder.RenameTable(
                name: "HeroName <-> Player",
                newName: "Hero_NamePlayer");

            migrationBuilder.RenameTable(
                name: "Hero <-> Item",
                newName: "HeroItem");

            migrationBuilder.RenameTable(
                name: "Ability <-> Unit",
                newName: "AbilityUnit");

            migrationBuilder.RenameIndex(
                name: "IX_HeroName <-> Player_PlayersId",
                table: "Hero_NamePlayer",
                newName: "IX_Hero_NamePlayer_PlayersId");

            migrationBuilder.RenameColumn(
                name: "Owning_HeroId",
                table: "HeroItem",
                newName: "Owning_HeroesId");

            migrationBuilder.RenameColumn(
                name: "InventoryItemId",
                table: "HeroItem",
                newName: "InventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Hero <-> Item_Owning_HeroId",
                table: "HeroItem",
                newName: "IX_HeroItem_Owning_HeroesId");

            migrationBuilder.RenameColumn(
                name: "unit_with_abilityId",
                table: "AbilityUnit",
                newName: "units_with_abilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Ability <-> Unit_unit_with_abilityId",
                table: "AbilityUnit",
                newName: "IX_AbilityUnit_units_with_abilityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hero_NamePlayer",
                table: "Hero_NamePlayer",
                columns: new[] { "Names_UsedId", "PlayersId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeroItem",
                table: "HeroItem",
                columns: new[] { "InventoryId", "Owning_HeroesId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AbilityUnit",
                table: "AbilityUnit",
                columns: new[] { "AbilitiesId", "units_with_abilityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AbilityUnit_Abilities_AbilitiesId",
                table: "AbilityUnit",
                column: "AbilitiesId",
                principalTable: "Abilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbilityUnit_Unit_units_with_abilityId",
                table: "AbilityUnit",
                column: "units_with_abilityId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hero_NamePlayer_Hero_Names_Names_UsedId",
                table: "Hero_NamePlayer",
                column: "Names_UsedId",
                principalTable: "Hero_Names",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hero_NamePlayer_Players_PlayersId",
                table: "Hero_NamePlayer",
                column: "PlayersId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HeroItem_Heroes_Owning_HeroesId",
                table: "HeroItem",
                column: "Owning_HeroesId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HeroItem_Items_InventoryId",
                table: "HeroItem",
                column: "InventoryId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
