﻿using MidtermProject.EF;
using MidtermProject.GameMechanics;
using MidtermProject.Model;
//using ProjectTempUI.EF.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using io = MidtermProject.input_output.IO_Global;

namespace ProjectTempUI.GameMechanics
{
    class InGameMenu
    {

        public static async Task MainMenu()
        {
            io.io.ClearScreen();
            await io.io.DisplayText("\t\t== Main Menu ==\n\n");
            //io.io.DisplayTitle("Main menu");
            List<string> choices = new List<string> {
            "Carry on Questing","Manage Inventory","Manage Party","Rest","Help","Save game","Exit game"
            };
            int choice = await io.io.GetChoice(choices, false);
            io.io.ClearScreen();
            switch (choice)
            {
                case 0://continue
                    await BattleSystem.StartBattle();
                    break;

                case 1://inventory
                    await ViewInventory();
                    break;

                case 2://party
                    await ManageParty();
                    break;
                case 3: //rest

                    await Rest();
                    break;
                case 4://help
                    await HelpMenu();
                    break;
                case 5://save
                    await SaveAndBack();
                    break;
                case 6: //quit
                    await ExitGame();
                    break;
                default:
                    await io.io.DisplayText("ERROR!!!");
                    break;
            }
        }

        private static async Task SaveAndBack()
        {
            await SaveGame();
            await io.io.GetNextCommand();
            await MainMenu();

        }

        //saves the game, by syncing all current entities to the database. 
        //this way - if you shut the game in the middle -> all changes go 
        //back to the last time you saved:
        private static async Task SaveGame()
        {
            var gs = MidtermProject.GameState.CurrentGameState.GetInstance();
            var player = gs.CurrentPlayer;

            gs.uow.Players.Update(player);

            gs.uow.Heroes.UpdateRange(player.Heroes);

            gs.uow.Complete();

            //I think this is supposed to affect all related entities. need to test it. 
            await io.io.DisplayText("Game Saved Sucessfully");
        }

        private static async Task ExitGame()
        {
            int choice = await io.io.GetChoice(new List<string> { "Quit Game", "save and Quit" }, true);

            switch (choice)
            {
                case 0:
                    await General.ExitGame();
                    break;
                case 1:
                    await SaveGame();
                    await General.ExitGame();
                    break;
                case 2:
                    await MainMenu();
                    break;

            }
        }

        //this is a place to stick useful info for the players:
        //(Ideally, texts like this would also be stored and pulled from a sql table and be easy to modify without opening the code file...)
        private static async Task HelpMenu()
        {
            string helptext = "Hit next to return to main menu.\n\n" +
                "Rest - Resting restores your Heroes to full health and mana," +
                " but comes at the price of nullifying any experience they have gained since they last" +
                " leveled up." +
                "\n\nBattle - Death in battle is permanent. So try not to die."
                ;

            await io.io.DisplayText(helptext);

            await io.io.GetNextCommand();

            await MainMenu();
        }

        //heals heroes to full health and mana, at the cost of nullifying Exp. 
        private static async Task Rest()
        {
            var gs = MidtermProject.GameState.CurrentGameState.GetInstance();

            foreach (Hero h in gs.CurrentPlayer.Heroes)
            {
                h.HP = h.BaseHP;
                h.Mana = h.BaseMana;
                h.CurrentExp = 0;
            }

            await io.io.DisplayText("Your party is well rested and ready for battle.");
            await io.io.GetNextCommand();

            await MainMenu();
        }

        private static async Task ManageParty()
        {
            var gs = MidtermProject.GameState.CurrentGameState.GetInstance();
            var heroes = gs.CurrentPlayer.Heroes;
            await io.io.DisplayText("Select a Hero:");

            List<string> htitles = new List<string>();
            foreach (var h in heroes)
            {
                htitles.Add($"{h.ProperName} the {h.ClassName}");
            }

            int choice = await io.io.GetChoice(htitles, true);

            //back:
            if (choice == heroes.Count)
            {
                await MainMenu();
                return;
            }

            Hero selectedH = heroes.ToList()[choice];
            io.io.ClearScreen();
            await io.io.DisplayText($"Selected {selectedH.ProperName} the {selectedH.ClassName}");

            await ManageHero(selectedH);
        }

        private static async Task ManageHero(Hero hero)
        {
            int choice = await io.io.GetChoice(new List<string> { "View Hero", "Unequip Item" }, true);

            io.io.ClearScreen();
            switch (choice)
            {
                case 0://view
                    await io.io.DisplayText(General.DisplayHeroInfo(hero));
                    await io.io.GetNextCommand();
                    io.io.ClearScreen();
                    await ManageHero(hero);
                    break;
                case 1://uenqip
                    await Unequip(hero);
                    break;
                case 2://back
                    await ManageParty();
                    break;
                default:
                    await io.io.DisplayText("ERROR!!!");
                    break;
            }
        }

        //move item from hero back to player inventory: 
        private static async Task Unequip(Hero hero)
        {
            if (hero.EquippedItem.Count == 0)
            {
                await io.io.DisplayText($"{hero.ProperName} has no items equipped.");
                await io.io.GetNextCommand();
                await ManageHero(hero);
                return;
            }

            await io.io.DisplayText($"Choose an item to unequip from {hero.ProperName}:");

            List<string> itemNames = new List<string>();

            foreach (var item in hero.EquippedItem)
            {
                itemNames.Add($"{item.Name}.{item.Description}");
            }

            int choice = await io.io.GetChoice(itemNames, true);

            if (choice == itemNames.Count-1)
            {
                await ManageHero(hero);
                return;
            }

            Item chosenItem = hero.EquippedItem.ToList()[choice];

            //get rid of stats:
            hero.Accuracy -= chosenItem.Accuracy_Bonus;
            hero.Speed -= chosenItem.Speed_Bonus;
            hero.Strength -= chosenItem.Strength_Bonus;
            hero.Spell_Power -= chosenItem.Spell_Power_Bonus;
            hero.Armor -= chosenItem.Armor_Bonus;
            hero.Magic_Resistance -= chosenItem.Magic_Resistance_Bonus;
            hero.BaseMana -= chosenItem.Mana_Bonus;
            hero.BaseHP -= chosenItem.HP_Bonus;


            hero.EquippedItem.Remove(chosenItem);

            var gs = MidtermProject.GameState.CurrentGameState.GetInstance();

            gs.CurrentPlayer.InventoryItem.Add(chosenItem);

            io.io.ClearScreen();
            await io.io.DisplayText($"{hero.ProperName} has unequipped {chosenItem.Name}.");
            await io.io.GetNextCommand();
            await ManageHero(hero);
            return;
        }

        private static async Task ViewInventory()
        {
            var gs = MidtermProject.GameState.CurrentGameState.GetInstance();
            io.io.ClearScreen();

            if (gs.CurrentPlayer.InventoryItem.Count == 0)
            {
                await io.io.DisplayText($"Your inventory is empty.");
                await io.io.GetNextCommand();
                await MainMenu();
                return;
            }

            List<string> itemNames = new List<string>();

            foreach (var item in gs.CurrentPlayer.InventoryItem)
            {
                itemNames.Add($"{item.Name}. {item.Description}.");
            }

            await io.io.DisplayText("choose an Item to use/equip");
            int choice = await io.io.GetChoice(itemNames, true);
           

            //back:
            if (choice == gs.CurrentPlayer.InventoryItem.Count)
            {
                await MainMenu();
                return;
            }

            Item chosenItem = gs.CurrentPlayer.InventoryItem.ToList()[choice];

            await EquipItem(chosenItem);


        }

        //manages the users choice to use/equip the item:
        private static async Task EquipItem(Item item)
        {
            var gs = MidtermProject.GameState.CurrentGameState.GetInstance();

            await io.io.DisplayText($"Choose the hero you wish to equip/use the {item.Name} on.");

            int choice = await io.io.GetChoice(gs.CurrentPlayer.Heroes.Select(x => x.ProperName).ToList(), true);

            //back
            if (choice == gs.CurrentPlayer.Heroes.Count)
            {
                await ViewInventory();
                return;
            }

            Hero chosenhero = gs.CurrentPlayer.Heroes.ToList()[choice];

            //could lock the item transactions together to be fancy... 
            //although there isn't any realistic way to separate the two 
            //actions. 

            gs.CurrentPlayer.InventoryItem.Remove(item);
            if (!item.Active)
            {
                chosenhero.EquippedItem.Add(item);
                UseItem(item, chosenhero);
                await io.io.DisplayText($"Eqipped {item.Name} to {chosenhero.ProperName}.");
            }
            else
            {
                UseItem(item, chosenhero);
                await io.io.DisplayText($"Used {item.Name} on {chosenhero.ProperName}.");

            }

            await io.io.GetNextCommand();
            await ViewInventory();

        }

        //applies the effects of the item to the hero. 
        private static void UseItem(Item i, Hero h)
        {
            h.Accuracy += i.Accuracy_Bonus;
            h.Speed += i.Speed_Bonus;
            h.Strength += i.Strength_Bonus;
            h.Spell_Power += i.Spell_Power_Bonus;
            h.Armor += i.Armor_Bonus;
            h.Magic_Resistance += i.Magic_Resistance_Bonus;

            if (i.Active)
            {h.Mana += i.Mana_Bonus;
            h.HP += i.HP_Bonus; }
            else
            {
                h.BaseMana += i.Mana_Bonus;
                h.BaseMana += i.HP_Bonus;
            }

            

        }


    }
}
