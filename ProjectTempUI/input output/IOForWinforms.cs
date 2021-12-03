using MidtermProject.GameState;
using MidtermProject.input_output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MidtermProject.EF;

namespace ProjectTempUI.input_output
{
    class IOForWinforms : IMakeIO
    {

        public async Task DisplayText(string text)
        {
            await WinformsUtils.ChangeScreenFeed(text);
        }

        public async Task<int> GetChoice(List<string> inpchoices,bool hasback)
        {
            List<string> choices = inpchoices;
            
            if (hasback && !choices.Contains("Back")) {choices.Add("Back"); }
                        

            string ChoStr = "Enter the number corresponding to one of the following choices:\n";
            for (int i = 0; i < choices.Count; i++)
            {
                ChoStr += $"{i+1}.{choices[i]}\n";
            }
            await WinformsUtils.ChangeScreenFeed(ChoStr);

            string inpstr;
                       

            while (true)
            {
                await Task.Run(IO_Global.SubmitPressed.Wait);

                inpstr = IO_Global.UiInput;
                int retval;

                bool success = int.TryParse(inpstr, out retval);

                if (success && retval > 0 && retval < choices.Count + 1)
                {

                    return retval - 1;
                }
                else
                {
                    await WinformsUtils.ChangeScreenFeed("\nInvalid input,try again.");
                }
            }

            
        }

        public void ClearScreen()
        {
            var gs = CurrentGameState.GetInstance();
            gs.TheForm.Clrscreen();

        }

        public void CloseForm()
        {
            var gs = CurrentGameState.GetInstance();
            gs.TheForm.Close();

        }

        //this just means - wait for the user to hit enter.  
        public async Task GetNextCommand()
        {
            var gs = CurrentGameState.GetInstance();
            
            await Task.Run(IO_Global.NextPressed.Wait);

        }

        public async Task<string> GetTextInput()
        {
            await Task.Run(IO_Global.SubmitPressed.Wait);
            return IO_Global.UiInput;
        }

        //this uses the same backwards method as all my other ui "get" stuff:
        //this returns the changed data after the user presses the button... 
        public async Task<List<T>> GetTableChanges<T>(List<T> table)
        {
            var gs = CurrentGameState.GetInstance();
            gs.TheForm.ShowTable(table);
            await Task.Run(IO_Global.NextPressed.Wait);
            return (List<T>)IO_Global.UiChangedCollection;
        }

    }


    //just a place to keep code to avoid repeating above: 
    public static class WinformsUtils
    {
     
        public static async Task ChangeScreenFeed(string str)
        {
                        
            var gs = CurrentGameState.GetInstance();

            //adding an obligatory newline. maybe I wont regret this... 
            str = "\n" + str;

            await gs.TheForm.SlowAddText(str);
                                   

        }

    }
}
