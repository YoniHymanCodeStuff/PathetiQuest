using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MidtermProject.GameMechanics;
using MidtermProject.input_output;

namespace ProjectTempUI
{
    static class Program
    {
       [STAThread]
        static void Main()
        {
            
            //UI stuff:
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var gs = MidtermProject.GameState.CurrentGameState.GetInstance();
            Application.Run(gs.TheForm = new Form1());
            

            //activating game:

            //Getting_Started.OpeningScreen();

            
            
        }


    }
}
