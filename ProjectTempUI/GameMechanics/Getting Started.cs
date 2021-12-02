using MidtermProject.EF;
using MidtermProject.input_output;
using MidtermProject.Model;
using ProjectTempUI.EF.DataAccess;
using ProjectTempUI.GameMechanics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using io = MidtermProject.input_output.IO_Global;


namespace MidtermProject.GameMechanics
{
    static class Getting_Started
    {

        public static async Task init()
        {
            try
            {

                //await TestingStuff();
                await StartingPoint();
            }

            catch (Exception e)
            {
                await io.io.DisplayText(e.ToString());
            }

        }
        public static async Task TestingStuff()
        {

            var gs = GameState.CurrentGameState.GetInstance();
            gs.uow.LazyCreateDB();



            var items = gs.uow.Items.GetAll().ToList();

            items = await io.io.GetTableChanges(items);
            
;           gs.uow.Items.UpdateRange(items);
            gs.uow.Complete();

            

            
            //Hero h = gs.uow.Heroes.EagerloadHero(78);
            //Hero clone = (Hero)h.Clone();
            //Hero clone = General.DeepClone<Hero>(h);

            //foreach (var a in h.Abilities)
            //{
            //    a.Manacost += 5;
            //    await io.io.DisplayText($"{a.Manacost}");
            //}

            // gs.CurrentPlayer = gs.uow.Players.EagerlyLoadPlayer(1);

            //await BattleSystem.StartBattle();
            //await io.io.GetNextCommand();







            //Player pl = gs.uow.Players.EagerlyLoadPlayer(58);

            //foreach (var hero in pl.Heroes)
            //{
            //    await io.io.DisplayText($"{hero.ProperName}:{hero.Id}");
            //}

            ////await io.io.DisplayText($"{pl.InventoryItem.Count}");
            //await io.io.DisplayText($"{pl.Heroes.ToList()[0].ProperName}");

            //await io.io.DisplayText($"{pl.Heroes.ToList()[0].Abilities.Count}");



            await io.io.DisplayText("Done");




            //await Task.Factory.StartNew(()=> { });
            //this is just so the warnings leave me be. 
            //io.io.BindTable();
            //io.io.DisplayTable(EF.DataAccess.GetAll.GetAllAbilities());


            //create db: 
            //Create_Game_Data.CreateGameData.init();
            //await io.io.DisplayText("complete");
            //await io.io.GetNextCommand();
            //await General.ExitGame();
        }

        public static async Task StartingPoint()
        {
            //creates db if doesn't already exist. 
            var gs = GameState.CurrentGameState.GetInstance();
            gs.uow.LazyCreateDB();


            //Music.playOuterMenuLoop

            //intro text/header... mostly UI stuff
            await io.io.DisplayText("Welcome to Pathetiquest, the text based adventure you never knew " +
                "you wanted to play!\n");


            var options = new List<string> { "log in", "create new account", "Exit Game" };

            int choice = await IO_Global.io.GetChoice(options, false);

            io.io.ClearScreen();


            switch (choice)
            {


                case 0:
                    await Login();
                    break;
                case 1:
                    await CreateAccount();
                    break;
                case 2:
                    await General.ExitGame();
                    break;

            }

        }


        public static async Task Login()
        {

            var gs = GameState.CurrentGameState.GetInstance();


            await io.io.DisplayText("\nEnter Username:");
            Player user;


            while (true)
            {
                string username = await io.io.GetTextInput();


                //user = DataAccess.GetPlayerByName(username);
                user = gs.uow.Players.SingleOrDefault(x => x.UserName == username);

                if (user != null) { break; }

                await io.io.DisplayText("\nthe name you entered does not exist in database. please try again.");

            }


            await io.io.DisplayText(user.UserName);
            await io.io.DisplayText("\nEnter Password:");

            while (true)
            {
                string pwd = await io.io.GetTextInput();
                if (pwd == user.Password) { break; }
                await io.io.DisplayText("\nIncorrect Password, please try again.");
            }


            string pwddisplay = PasswordDisplay(user.Password);

            await io.io.DisplayText(pwddisplay);

            await io.io.DisplayText($"\nWelcome Back, {user.UserName}");

            //here we load the rest of the data for the player:(and yes, it should probably all just be in one place.. ) 
            user = gs.uow.Players.EagerlyLoadPlayer(user.Id);

            gs.CurrentPlayer = user;

            if (user.IsMod)
            {
                int choice = await io.io.GetChoice(new List<string> { "Play", "Edit Game Data" }, false);
                switch (choice)
                {
                    case 0:
                        await SetupCompleteChecker();
                        break;
                    case 1:
                        await TableEditingForMods.ModMenu();
                        break;

                }
            }
            else
            {
                await SetupCompleteChecker();

            }

        }


        public static async Task CreateAccount()
        {

            var gs = GameState.CurrentGameState.GetInstance();
            UnitOfWork uow = gs.uow;

            await io.io.DisplayText("\n\nPlease Enter a Username");

            string username;
            string pwd;

            while (true)
            {

                username = await io.io.GetTextInput();
                await io.io.DisplayText(username);
                if (uow.Players.SingleOrDefault(x => username == x.UserName) == null) { break; }

                await io.io.DisplayText("\nSorry, that name is already taken. Enter a different " +
                    "Username");
            }

            while (true)
            {
                await io.io.DisplayText("\nEnter a Password:");
                string pwd_A = await io.io.GetTextInput();
                await io.io.DisplayText(PasswordDisplay(pwd_A));


                await io.io.DisplayText("\nVerify your Password:");
                string pwd_B = await io.io.GetTextInput();
                await io.io.DisplayText(PasswordDisplay(pwd_B));

                if (pwd_A == pwd_B) { pwd = pwd_A; break; }

                await io.io.DisplayText("\nYour Entries Didn't Match. Try again.");

            }

            Player pl = new Player
            {
                UserName = username,
                Password = pwd,
                IsMod = false
            };

            gs.CurrentPlayer = pl;
            uow.Players.Add(pl);
            uow.Complete();

            await io.io.DisplayText($"{pl.UserName}'s user profile has been successfully created.");
            await io.io.GetNextCommand();
            io.io.ClearScreen();



            await ChooseParty();
        }

        public static async Task ChooseParty()
        {

            var gs = GameState.CurrentGameState.GetInstance();
            var cplayer = gs.CurrentPlayer;
            UnitOfWork uow = gs.uow;

            //(this shows even if you have 3 heroes already..)  
            await io.io.DisplayText("Now you need to choose your party. You get to choose 3 heroes. choose wisely.");
            await io.io.GetNextCommand();
            List<HeroType> herotypes = uow.HeroClasses.GetOrderedHeroClasses();

            List<String> heroTypeStrings = herotypes.Select(x => x.ClassName).ToList();

            List<Hero_Name> Hnames = uow.HeroNames.GetAll().ToList();

            Random rnd = new Random();



            //creating 3 heroes for player:
            for (int i = 0; cplayer.Heroes.Count < 3; i++)
            {
                io.io.ClearScreen();
                await io.io.DisplayText($"Select the class for Hero #{i + 1}:");

                int choice = await io.io.GetChoice(heroTypeStrings, false);

                HeroType ht = herotypes[choice];

                //copying all attributes from the herotype object:

                Hero NewGuy = new Hero
                {

                    classIndex = -2,
                    ClassName = ht.ClassName,
                    Accuracy = ht.Accuracy,
                    Speed = ht.Speed,
                    Strength = ht.Strength,
                    Armor = ht.Armor,
                    Spell_Power = ht.Spell_Power,
                    Magic_Resistance = ht.Magic_Resistance,
                    HP = ht.HP,
                    BaseHP = ht.HP,
                    Mana = ht.Mana,
                    BaseMana = ht.Mana,
                    Level = 1,
                    Abilities = new List<Ability>(),

                    //linking the hero to the player: 
                    player = cplayer
                    //is this a mistake? now it will be linked two ways... ??? 
                };

                //a really bad way to add the initial attack to everyone... I should index the abilities ad not use the stupid string...
                NewGuy.Abilities.Add(gs.uow.Abilities.SingleOrDefault(x => x.Name == "Basic Attack"));


                //picking a random name for the hero, that player hasn't used yet.
                //(all this name stuff should prob be encapsulated in a separate place)
                List<Hero_Name> Filterednames = Hnames.Except(cplayer.Names_Used).ToList();

                //if the player used all names, resetting his name list. 
                if (Filterednames.Count == 0)
                {
                    cplayer.Names_Used = null;
                    Filterednames = Hnames;
                    await io.io.DisplayText("Congrats mate, you have used all possible hero names. Names have been reset, and you will now repeat names you have used before. Maybe stop playing and go take a walk, or a shower.");

                }

                //assigning the random name to the hero and adding it to the players list to track and avoid repeating:
                Hero_Name pickedName = Filterednames[rnd.Next(0, Filterednames.Count())];
                cplayer.Names_Used.Add(pickedName);
                NewGuy.ProperName = pickedName.Name;

                //giving the hero to the player. 
                cplayer.Heroes.Add(NewGuy);

                uow.Heroes.Add(NewGuy);
                uow.Complete();

                await io.io.DisplayText($"{NewGuy.ProperName} the {NewGuy.ClassName} has joined your party.");
                await io.io.GetNextCommand();

                await General.LearnAbility(NewGuy);
                await io.io.GetNextCommand();
                await io.io.DisplayText(General.DisplayHeroInfo(NewGuy));
                await io.io.GetNextCommand();
            }



            cplayer.FinishedSetup = true;
            uow.Players.Update(cplayer);
            uow.Complete();

            await IntroMessage();
            await InGameMenu.MainMenu();

        }

        public static async Task SetupCompleteChecker()
        {
            var gs = GameState.CurrentGameState.GetInstance();
            var cplayer = gs.CurrentPlayer;

            if (cplayer.FinishedSetup)
            {
                await InGameMenu.MainMenu();
            }
            else
            {
                await ChooseParty();
            }

        }

        public static async Task IntroMessage()
        {
            var gs = GameState.CurrentGameState.GetInstance();
            var cplayer = gs.CurrentPlayer;

            io.io.ClearScreen();
            string wm = $"Your party is ready, and now your adventure begins." +
                $"\nYour heroes have entered some generic dark place. will you succeed in battling" +
                $"through all of the things and reach the main boss thing at the end?! \nmaybe.";

            await io.io.DisplayText(wm);
            await io.io.GetNextCommand();
        }

        private static string PasswordDisplay(string inp)
        {
            string pwddisplay = "";

            foreach (var i in inp)
            {
                pwddisplay += "*";
            }

            return pwddisplay;
        }
    }
}
