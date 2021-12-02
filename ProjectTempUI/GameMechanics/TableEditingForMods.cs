using MidtermProject.EF;
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
    class TableEditingForMods
    {
        private static readonly List<string> tablenames = new List<string> {"Players", "Items",
        "Heroes","Hero Names", "Hero Types", "Enemy Types", "Abilities","Encounter Intro texts" };
        
        public static async Task ModMenu()
        {
            var gs = MidtermProject.GameState.CurrentGameState.GetInstance();
            io.io.ClearScreen();
            int choice = await io.io.GetChoice(new List<string> {"Edit Data Tables","Add new Entries" }, true);

            switch(choice)
            {
                case 0:
                    await TableEditing();
                    break;
                case 1:
                    await NewEntries(); 
                    break;
                case 2:
                    //- it would probably ideal to not have to re-log in.
                    //currently the function isn't split at the right point. 
                    await Getting_Started.Login();
                    break;
            }
        }

        private static async Task NewEntries()
        {
            var gs = MidtermProject.GameState.CurrentGameState.GetInstance();

            io.io.ClearScreen();
            await io.io.DisplayText("\nEnter the number of new rows you would like to add:");

            int rownums = await SafeGetNum(50);


            await io.io.DisplayText("\nChoose the Data type you wish to create:");
            int choice = await io.io.GetChoice(tablenames, true);

            switch (choice)
            {
                case 0:
                    //players
                    for (int i = 0; i < rownums; i++)
                    {
                        gs.uow.Players.Add(new Player());
                    }
                    
                    break;
                case 1:
                    //items
                    for (int i = 0; i < rownums; i++)
                    {
                        gs.uow.Items.Add(new Item());
                    }
                    break;
                case 2:
                    //heroes
                    for (int i = 0; i < rownums; i++)
                    {
                        gs.uow.Heroes.Add(new Hero());
                    }
                    break;
                case 3:
                    //hero names
                    for (int i = 0; i < rownums; i++)
                    {
                        gs.uow.HeroNames.Add(new Hero_Name());
                    }
                    break;
                case 4:
                    //hero types
                    for (int i = 0; i < rownums; i++)
                    {
                        gs.uow.HeroClasses.Add(new HeroType());
                    }
                    break;
                case 5:
                    //enemy types
                    for (int i = 0; i < rownums; i++)
                    {
                        gs.uow.Enemies.Add(new EnemyType());
                    }
                    break;
                case 6:
                    //abilities
                    for (int i = 0; i < rownums; i++)
                    {
                        gs.uow.Abilities.Add(new Ability());
                    }

                    break;
                case 7:

                    //ncounter intros
                    for (int i = 0; i < rownums; i++)
                    {
                        gs.uow.IntroTexts.Add(new Encounter_Intro_Text());
                    }
                    break;
                case 8://back

                    await ModMenu();
                    return;
                    

            }

            gs.uow.Complete();
            await io.io.DisplayText("Rows have been successfully added.");
            await io.io.GetNextCommand();
            await ModMenu();
        }

        private static async Task TableEditing()
        {
            var gs = MidtermProject.GameState.CurrentGameState.GetInstance();
            io.io.ClearScreen();

            await io.io.DisplayText("\nChoose a table to Edit:");
            
            int choice = await io.io.GetChoice(tablenames, true);

            switch(choice)
            {
                case 0:
                    //players
                    await Warning("Players Must have unique usernames.");
                    List<Player> players = gs.uow.Players.GetAll().ToList();
                    await EditTable(players);
                    break;
                case 1:
                    //items
                    List<Item> items = gs.uow.Items.GetAll().ToList();
                    await EditTable(items);
                    break;
                case 2:
                    //heroes
                    List<Hero> heroes = gs.uow.Heroes.GetAll().ToList();
                    await EditTable(heroes);
                    break;
                case 3:
                    //hero names
                    List<Hero_Name> hnames = gs.uow.HeroNames.GetAll().ToList();
                    await EditTable(hnames);
                    break;
                case 4:
                    //hero types
                    await Warning("When creating a new Hero type make sure to give it a positive class index.");
                    List<HeroType> htypes = gs.uow.HeroClasses.GetAll().ToList();
                    await EditTable(htypes);
                    break;
                case 5:
                    //enemy types
                    List<EnemyType> enemies = gs.uow.Enemies.GetAll().ToList();
                    await EditTable(enemies);
                    break;
                case 6:
                    //abilities
                    List<Ability> abilities = gs.uow.Abilities.GetAll().ToList();
                    await EditTable(abilities);

                    break;
                case 7:

                    //ncounter intros
                    List<Encounter_Intro_Text> etext = gs.uow.IntroTexts.GetAll().ToList();
                    await EditTable(etext);
                    break;
                case 8://back
                                              
                    await ModMenu();
                    break;

            }



        }

        private static async Task EditTable<T>(List<T> table)
        {
            var gs = MidtermProject.GameState.CurrentGameState.GetInstance();
            var x = table;
            table = await io.io.GetTableChanges(table);
            gs.uow.Complete();
            io.io.ClearScreen();
            await io.io.DisplayText("update complete");
            await io.io.GetNextCommand();
            await TableEditing();
        }

        private static async Task<int> SafeGetNum(int max)
        {
            int retval;

            while (true)
            {
                string inp = await io.io.GetTextInput();

                bool success = int.TryParse(inp, out retval);

                if (success && retval > 0 && retval < max)
                {
                    return retval;
                    
                }

                await io.io.DisplayText($"Invalid input. Please enter a number between 1 and {max}");

            }               

        }

        private static async Task Warning(string warning)
        {
            await io.io.DisplayText(warning);
            await io.io.GetNextCommand();
        }

    }
}
