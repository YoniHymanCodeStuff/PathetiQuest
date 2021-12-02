using MidtermProject.Model;
using ProjectTempUI;
using ProjectTempUI.EF.DataAccess;
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

        public UnitOfWork uow = new UnitOfWork();

        //this is so that the program can access the running form:

        public Form1 TheForm;

       //public Action CurrentBack { get; set; } = () => { };

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
