using MidtermProject.GameMechanics;
using MidtermProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using io = MidtermProject.input_output.IO_Global;



namespace ProjectTempUI.GameMechanics
{
    class BattleAftermath
    {
        public static async Task Defeat()
        {
            var gs = MidtermProject.GameState.CurrentGameState.GetInstance();

            io.io.ClearScreen();
            await io.io.DisplayText("DEFEAT.\n\nAll of Your heroes have died. You lose. Game Over. Ciao");


            int choice = await io.io.GetChoice(new List<string> { "Exit Game", "Load game from Last save", "Start new Adventure" ,"Main Menu"}, false);


            switch (choice)
            {
                case 0://exit
                    
                    await General.ExitGame();
                    break;
                case 1: //load
     
                    foreach (var h in gs.CurrentPlayer.Heroes)
                    {
                        gs.uow.Heroes.Reload(h);
                    }

                    //List<int> ids = gs.CurrentPlayer.Heroes.Select(x => x.Id).ToList();

                    gs.uow.Players.Reload(gs.CurrentPlayer);
                                                            
                    await InGameMenu.MainMenu();
                    break;

                case 2://startnew
                    gs.CurrentPlayer.Heroes = new List<Hero>();
                    gs.CurrentPlayer.InventoryItem = new List<Item>();
                    gs.CurrentPlayer.FinishedSetup = false;
                    gs.uow.Players.Update(gs.CurrentPlayer);
                    gs.uow.Complete();
                    await Getting_Started.SetupCompleteChecker();

                    break;

                case 3://main menu
                    await Getting_Started.StartingPoint();
                    break;
                default:
                    break;
            }
        }

        public static async Task Victory(List<EnemyType> defeatedEn)
        {

            var gs = MidtermProject.GameState.CurrentGameState.GetInstance();

            io.io.ClearScreen();
            await io.io.DisplayText("Victory!");

            await ManageExp(defeatedEn);

            await GetLoot(defeatedEn[0].Level);

            await io.io.GetNextCommand();
            await InGameMenu.MainMenu();
        }

        private static async Task GetLoot(int EnemyLevel)
        {
            var gs = MidtermProject.GameState.CurrentGameState.GetInstance();

            Random rnd = new Random();

            //the higher the level the larger the chance of getting loot
            if(EnemyLevel*0.09>rnd.NextDouble())
            {
                Item item =  gs.uow.Items.GetRandomNewItem();

                item.Owning_Player.Add(gs.CurrentPlayer);
                gs.CurrentPlayer.InventoryItem.Add(item);


                await io.io.GetNextCommand();
                io.io.ClearScreen();
                await io.io.DisplayText($"You have looted a {item.Name} from the battle. It has been put in your inventory.");

            }
           

        }

        private static async Task ManageExp(List<EnemyType> defeatedEn)
        {
            var gs = MidtermProject.GameState.CurrentGameState.GetInstance();

            double ExpGainFactor = 60; //you multiply this by badguy level. 
            double ExpPerlevel = 150; //this * hero level = amount to gain level. 

            double totalExpgained = defeatedEn.Count * defeatedEn[0].Level * ExpGainFactor;

            double ExpPerHero = totalExpgained / gs.CurrentPlayer.Heroes.Count();

            foreach (var hero in gs.CurrentPlayer.Heroes)
            {
                hero.CurrentExp += ExpPerHero;
                await io.io.DisplayText($"\n{hero.ProperName} gained {ExpPerHero} Experience points.");

                while(hero.CurrentExp>ExpPerlevel*hero.Level)
                {
                    await LevelUp(hero);
                    hero.CurrentExp -= ExpPerlevel * hero.Level;
                }
            }
        }

        private static async Task LevelUp(Hero h)
        {
            h.Level++;
            await io.io.DisplayText($"{h.ProperName} the {h.ClassName} leveled up to level {h.Level}!");

            double g = 5;//this is currently the amount of stats they gain per level... 

            h.Accuracy += g;
            h.Speed += g;
            h.Strength += g;
            h.Spell_Power += g;
            h.Armor += g;
            h.Magic_Resistance += g;
            h.BaseHP += g*10;
            h.BaseMana += g * 10;

            //you learn a new ability every 5th level. 
            if (h.Level%5==0)
            {
                await General.LearnAbility(h);
            }

            //I didn't add the stuff for winning the game here... 
            //in essence the game ends at level 20 with a boss fight thing.
            //currently it might just crash.  
        }
    }
}
