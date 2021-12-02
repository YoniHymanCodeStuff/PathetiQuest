using MidtermProject.EF;
using MidtermProject.input_output;
using MidtermProject.Model;
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
        public static void OpeningScreen()
        {
            //Music.playOuterMenuLoop

            //intro text/header... mostly UI stuff

            var options = new List<string> { "log in", "create new account","Exit Game" };

            int choice = IO_Global.io.MultipleChoice(options);

            switch(choice)
            {
                case 0:
                    Login();
                    break;
                case 1:
                    CreateAccount();
                    break;
                case 2:
                    General.ExitGame();
                    break;
            }
                           
        }


        public static void Login()
        {
            //this is not as loose as it should be.
            //this will have to be somewhat redone for a normal login ui...
            //
            var gs = GameState.CurrentGameState.GetInstance();
            gs.CurrentBack = OpeningScreen;

            io.io.DisplayText("Enter Username:");
            Player user;

            while (true)
            {
                string username = io.io.TextInput();

                user = EF.DataAccess.GetPlayerByName(username);


                if (user != null) {break;}

                io.io.DisplayText("the name you entered does not exist in database. please try again.");

            }


            io.io.DisplayText("Enter Password:");

            while(true)
            {
                string pwd = io.io.TextInput();
                if (pwd == user.Password) { break; }
                io.io.DisplayText("Incorrect Password, please try again.");
            }

            gs.CurrentPlayer = user;
            io.io.DisplayText($"Welcome Back, {user.UserName}");

            if(user.IsMod)
            {
                int choice = io.io.MultipleChoice(new List<string> { "Play", "Edit Game Data" });
                switch(choice)
                {
                    case 0:
                        //PlayGame();
                        break;
                    case 1:
                        //ModMenu();
                        break;
                }
            }
            else
            {
                //PlayGame();
            }

        }

        public static void CreateAccount()
        {
            var gs = GameState.CurrentGameState.GetInstance();
            gs.CurrentBack = OpeningScreen;

            io.io.DisplayText("Welcome to Pathetiquest, the text based adventure you never knew " +
                "you wanted to play.");
            io.io.DisplayText("Please Enter a Username:");
            string username;
            string pwd;

            while(true)
            {
                username = io.io.TextInput();
                if (EF.DataAccess.GetPlayerByName(username) == null) { break; }

                io.io.DisplayText("Sorry, that name is already taken. Enter a different " +
                    "Username");
            }

            while(true)
            {
                io.io.DisplayText("Enter a Password:");
                string pwd_A = io.io.TextInput();

                io.io.DisplayText("Verify your Password:");
                string pwd_B = io.io.TextInput();

                if (pwd_A == pwd_B) { pwd = pwd_A; break; }

                io.io.DisplayText("Your Entries Didn't Match. Try again.");

            }

            Player pl = new Player{
            UserName = username,
            Password = pwd,
            IsMod = false
            };

            gs.CurrentPlayer = pl;
            DataAccess.Add<Player>(pl);

            io.io.DisplayText($"{pl.UserName}'s user profile has been succeffully created.");

            //ChooseParty();

        }

    }
}
