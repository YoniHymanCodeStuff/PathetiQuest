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

        public void DisplayTable<T>(List<T> table)
        {
            var gs = CurrentGameState.GetInstance();
            gs.TheForm.ShowTable(table);
        }

        public async Task DisplayText(string text)
        {
            await WinformsUtils.ChangeScreenFeed(text);
        }

        public void BindTable()
        {
            //var gs = CurrentGameState.GetInstance();
            //gs.TheForm.BindTable(DataAccess.BindAbilities());
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

            

            //this is not good...
            //might actually be easier with a dropdown....
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

        public async Task GetNextCommand()
        {
            var gs = CurrentGameState.GetInstance();
            gs.TheForm.NextButtonreadyIndicator();
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


    public static class WinformsUtils
    {
        //I have two of these so I can slowprint the new stuff while
        //having the old stuff static. 
        private static int CharCount { get; set; } = 0;
       



        ////this is for the winform to get the active screenfeed
        //public static string GetScreenFeed()
        //{
        //    return ScreenFeed;
        //}

        //this is the function the interface member calls. 
        public static async Task ChangeScreenFeed(string str)
        {
            
            //int maxchars = 500;
            var gs = CurrentGameState.GetInstance();

            //adding an obligatory newline. maybe I wont regret this... 
            str = "\n" + str;

            await gs.TheForm.SlowAddText(str);


            //this whole thing is suppsed to clear screen after x
            //chars. but it makes more sense to just clear screen when relevant. 
            //if (CharCount + str.Length < maxchars)
            //{
            //    await gs.TheForm.SlowAddText(str);
            //    CharCount += str.Length;
            //    //AddtoSF(str);
            //}
            //else
            //{
            //    gs.TheForm.Clrscreen();
            //    await gs.TheForm.SlowAddText(str);
            //    CharCount = str.Length;
            //}

        }

        //private static void AddtoSF(string s)
        //{
        //    var gs = CurrentGameState.GetInstance();

        //    foreach (var ch in s)
        //    {
        //        ScreenFeed += ch;
        //        gs.TheForm.SyncScreen();
        //        //Thread.Sleep(10);
        //    }
            
        //}

        //public static void ClearScreenFeed()
        //{
        //    ScreenFeed = "";

        //}
    }
}
