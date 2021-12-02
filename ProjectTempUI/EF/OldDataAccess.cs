using Microsoft.EntityFrameworkCore;
using MidtermProject.input_output;
using MidtermProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject.EF
{

 //this is the old way I was doing stuff prior to the repository.
        //currently shouldn't be in use. 

    public static class DataAccess
    {
       

        private static DBC dbc = new DBC();

        //I'm pretty sure I need to add more failsafe stuff to these crud ops... 
        //they are too simple in a bad way... 

        public static void Add<T>(T t)
        {
            dbc.Add(t);
            dbc.SaveChanges();
        }

        public static void Update<T>(T t)
        {
            dbc.Update(t);
            dbc.SaveChanges();

        }

        //not the fastest way to run this "code wise", but not 
        //enough data to justify making type specific addrange functions. 
        public static void AddMany<T>(IList<T> range)
        {
           
            foreach (var item in range)
            {
                dbc.Add(item);
            }
                        
            dbc.SaveChanges();
        }

        public static void Delete<T>(T t) /*where T : IhaveID*/
        {
            dbc.Remove(t);
            dbc.SaveChanges();
            
        }

        public static BindingList<Ability> BindAbilities()
        {
            return dbc.Abilities.Local.ToBindingList();
        }
        
        public static T GetEntryById<T>(int ID) where T : class, IhaveID
        {
            
            return dbc.Find<T>(ID); 
          
            //needs to return something anyways... need to deal 
            //with cases where this doesn't work on the recieving end. 
                        
        }

        //public static Hero_Name GetNewRandomName(List<string> notThese)
        //{
        //    Hero_Name
            
        //    Random rand = new Random();
        //    int toSkip = rand.Next(0, dbc.Hero_Names.Count());

        //    dbc.Hero_Names.Skip(toSkip).Take(1).First();


        //    return dbc.
        //}

#nullable enable
        public static Player? GetPlayerByName(string name)
        {
            
            
           if (dbc.Players.Any(e => e.UserName == name))
            {
                return  dbc.Players.Single(e => e.UserName == name);

            }

            return null;

        }
#nullable disable

        public struct GetAll
        {
            //here is the horrible code repeating as a result of 
            //me not finding a good generic way to do this:
            public static List<Player> GetAllPlayers()
            {
                return dbc.Players.ToList();
            }

            public static List<Ability> GetAllAbilities()
            {
                return dbc.Abilities.ToList();
            }

            public static List<Item> GetAllItems()
            {
                return dbc.Items.ToList();
            }

            public static List<Hero_Name> GetAllHeroNames()
            {
                return dbc.Hero_Names.ToList();
            }

            public static List<Encounter_Intro_Text> GetAllIntroTexts()
            {
                return dbc.Intro_Texts.ToList();
            }

            public static List<HeroType> GetAllHeroTypes()
            {
                return dbc.HeroTypes.ToList();
            }

            public static List<EnemyType> GetAllEnemyTypes()
            {
                return dbc.enemyTypes.ToList();
            }
            public static List<Hero> GetAllHeroes()
            {
                return dbc.Heroes.ToList();

            }
        }


        //public static List<T> GetTable<T>(TableIndex ti)
        //{
        //    switch (ti)
        //    {
        //        case TableIndex.players:
        //            return dbc.Players.Select(x => x).ToList<T>();
        //            break;
        //        case TableIndex.heroTypes:
        //            break;
        //        case TableIndex.enemytypes:
        //            break;
        //        case TableIndex.heroes:
        //            break;
        //        case TableIndex.abilities:
        //            break;
        //        case TableIndex.items:
        //            break;
        //        case TableIndex.heroNames:
        //            break;
        //        case TableIndex.encounterText:
        //            break;
        //    }


        //}






        //was not very successful making get tables generic... 



        //public static List<T> GetTable<T>(string TableName) where T : class, IhaveID
        //{
        //    List<T> s = dbc.Database.SqlQuery<T>($"{TableName}").ToList();
        //}


        //public static List<T> GetTable<T>(DbSet<T> TableName) where T : class, IhaveID
        //{
        //    return dbc.TableName.ToList();

        //}


        //public static List<T> GetTable<T>(string tablename)
        //{

        //    var entityNs = "PathetiQuest";
        //    //var table = "Model";
        //    var entityType = Type.GetType($"{entityNs}.{tablename}");
        //    var methodInfo = typeof(DBC).GetMethod("Set");
        //    var generic = methodInfo.MakeGenericMethod(entityType);
        //    dynamic dbSet = generic.Invoke(dbc, null);
        //    var list = dbSet.GetList();
        //    return list;

        //}


    }
}
