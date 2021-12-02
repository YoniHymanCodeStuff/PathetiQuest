using MidtermProject.input_output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject.GameMechanics
{
    static class General
    {
        static public void ExitGame()
        {
            IO_Global.io.DisplayText($"Quitting Game\nGoodbye");
            //Music.AllOff();

            // I also need to add code here to detect other running tasks and 
            //cancel them, but so far that is only relevant for tempui stuff. 
        }
    }
}
