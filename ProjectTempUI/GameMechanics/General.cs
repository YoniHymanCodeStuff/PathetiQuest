using MidtermProject.input_output;
using MidtermProject.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using System.IO;


namespace MidtermProject.GameMechanics
{
    static class General
    {
        static public async Task ExitGame()
        {

            IO_Global.io.ClearScreen();
            await IO_Global.io.DisplayText($"Quitting Game\nGoodbye");
            IO_Global.io.CloseForm();
            
            //Music.AllOff();

        
        }

        static public async Task LearnAbility(Hero hero)
        {
            var gs = GameState.CurrentGameState.GetInstance();



            HeroType htype = gs.uow.HeroClasses.EagerloadHeroType(hero.ClassName);

            List<Ability> LearnableAbilities = htype.Abilities.ToList();



            LearnableAbilities.RemoveAll(x => hero.Abilities.Contains(x));

            if (LearnableAbilities.Count == 0) { return; }

            IO_Global.io.ClearScreen();

            await IO_Global.io.DisplayText($"{hero.ProperName} can learn a new ability. Choose an ability to learn:\n");

            
            List<string> AbStrings = new List<string>();

            foreach (var ab in LearnableAbilities)
            {
                AbStrings.Add($"{ab.Name}: {ab.Description}");
            }
            
            

            int choice = await IO_Global.io.GetChoice(AbStrings, false);

            hero.Abilities.Add(LearnableAbilities[choice]);
            //don't thing i should save this data just yet... only the save function should actually commit this stuff to the sql memory... 
            //gs.uow.Heroes.Update(hero);
            //gs.uow.Complete();
            await IO_Global.io.DisplayText($"{hero.ProperName} learned {LearnableAbilities[choice].Name}.");
        }



        //not sure why I didn't just have this call the ui itself...
        //maybe I had a reason. who knows. 
        public static string DisplayHeroInfo(Hero hero)
        {
            IO_Global.io.ClearScreen();

            string retstr = $"{hero.ProperName} the {hero.ClassName}:\n";

            foreach (PropertyInfo prop in hero.GetType().GetProperties().Where(x=>(x.Name!="Id" && x.Name != "classIndex")))
            {
                
                if (typeof(IEnumerable).IsAssignableFrom(prop.PropertyType))
                {
                    continue;
                }

                retstr += $"\n{prop.Name}:\t{prop.GetValue(hero, null)}";
            }

            //this whole next part is to arrange the "tostring" display for the collections:

            string abilist ;
            string itemlist;

            if (hero.Abilities==null) { abilist = "None"; }
            else { abilist = string.Join(",", hero.Abilities);}

            if (hero.EquippedItem== null||hero.EquippedItem.Count<1) { itemlist = "None"; }
            else { itemlist = string.Join(",", hero.EquippedItem); }

            retstr += $"\nAbilities:\t\t\t{abilist}";
            retstr += $"\nItems equipped:\t\t\t{itemlist}";

            return retstr;
        }



    }
}
