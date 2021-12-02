using MidtermProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject.GameState
{
    //A singleton class that holds current global game data. 
    class CurrentGameState
    {
        private static readonly object lockObj = new object();

        private static CurrentGameState instance;

        public Player CurrentPlayer;

        //(currently runs from TempIO Enterlistener )
        //this defines where the back command will take 
        //you from the current screen function: 

        public Action CurrentBack { get; set; } = () => { };

        private CurrentGameState()
        {

        }

        public static CurrentGameState GetInstance()
        {
            if (instance == null)
            {
                lock(lockObj)
                {
                    instance = new CurrentGameState();
                }
            }

            return instance;
        }
    }
}
