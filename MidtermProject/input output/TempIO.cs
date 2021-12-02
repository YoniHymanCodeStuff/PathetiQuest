using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MidtermProject.input_output
{
    class TempIO : IMakeIO
    {
        static public Task Advance { get; set ; }

        public void Back()
        {

            //var gs = GameState.CurrentGameState.GetInstance();
            //gs.CurrentBack();

            //right now this is running through the enter listener and
            //is held in the game state singleton. 
            //so currently this function  is not neccessary.
            //but new UI could possibly trigger this directly

        }

        public void DisplayTable(object o)
        {
            throw new NotImplementedException();
        }

        public void DisplayText(string text)
        {
            //set this int according to screensize. this part of 
            //func is really aimed at the parralel func when 
            //using better IO. just to simulate that and integrate 
            //pressing next. 
     
            int charsInScreen = 50;


            if (text.Count()>charsInScreen)
            {
                IEnumerable<string> chunks = IO_Global.ChunksUpto(text, charsInScreen);

                foreach (var c in chunks)
                {
                    IO_Global.SlowPrint(c);

                    Advance.Wait();

                }
            }
            else
            {
                IO_Global.SlowPrint(text);
            }
        }

        public int MultipleChoice(List<string> choices)
        {
            
            Console.WriteLine("Enter the number corresponding to your choice:\n");
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i+1}. {choices[i]}");
            }
            Console.Write("Hit Enter and then Enter your choice (thanks to a bug I didn' fix yet):");

          
            while (true)
            {


                string inp = Console.ReadLine();

                int res;

                bool success = int.TryParse(inp, out res);

                if (success && res > 0 && res < choices.Count + 1)
                {
                    
                    return res - 1;
                }
                else
                {
                    Console.WriteLine("invalid input, try again.");
                }
            }
            
        }

        public string TextInput()
        {
            return Console.ReadLine();
        }

        //this needs to be called in a separate task at the 
        //begiining of the program to make entering advance to next screen. 
        //(probably a dumb way to do this... but it works...)
        static public void Enterlistener()
        {

            while (true)
            {
                Advance = new Task(() => {
                    string x = Console.ReadLine(); 
                    if (x == "b")
                    {
                        var gs = GameState.CurrentGameState.GetInstance();
                        gs.CurrentBack();
                    }
                });
                

                Advance.RunSynchronously();

            }

        }

        //this is a way to pause the listener bc it interferes with some things.
        //I just set this to false to pause the listener and back to true when done. 

        //static bool ListenerNotPaused { get; set; } = true;  - this just made things worse

    }
}
