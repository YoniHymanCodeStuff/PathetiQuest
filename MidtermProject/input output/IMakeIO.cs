using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject.input_output
{
    interface IMakeIO
    {
        static public Task Advance { get; set; }
        public void DisplayText(string text);
        public void DisplayTable(object o);//not sure what this should take... 
        public string TextInput();
        public int MultipleChoice(List<string> choices);
        
        public void Back();

    }
}
