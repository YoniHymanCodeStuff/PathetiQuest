using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject.input_output
{
    //this creates a class the program can call to run the UI stuff. 
    //the interface is so I can switch UI without changing anything in the program. 
    
    interface IMakeIO
    {
        
        //these are functions that the program calls to 
        //send things directly to display on the UI
        public Task DisplayText(string text);

        public Task<List<T>> GetTableChanges<T>(List<T> table);

        //these are the functions that the program calls 
        //to wait for input from the UI:
        //(might make sens to move these somewhere independent of the changing
        //part of the interface...)
        public Task<string> GetTextInput();
        public Task<int> GetChoice(List<string> choices,bool HasBack);//hasback is true when there is a "back" option
        public Task GetNextCommand();


    }
}
