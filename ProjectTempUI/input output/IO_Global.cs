using ProjectTempUI.input_output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MidtermProject.input_output
{
    static class IO_Global
    {
        //this class is for general UI things that multiple other
        //methods need and for initializing the global IO components. 
        //probably should just merge this with the singleton... 

        //these tasks are for transforming the form events into tasks that 
        //can be waited for. I create a new time and destroy the old one every time
        //it is called to reset it. 

        public static Task NextPressed { get; set; } = new Task(() => { });
        public static Task SubmitPressed { get; set; } = new Task(() => { });

        public static  string UiInput { get; set; }
        public static object UiChangedCollection { get; set; } // a very bad idea... 
        
        //this should be an object of the current IO type: 
        public static IOForWinforms io { get; set; } = new IOForWinforms();

    }
}
