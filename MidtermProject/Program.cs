using MidtermProject.EF;
using MidtermProject.input_output;
using MidtermProject.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MidtermProject
{
    class Program
    {
        
        static void Main(string[] args)
        {
            IO_Global.InitIO();

            GameMechanics.Getting_Started.OpeningScreen();



            //List<string> strings = new List<string> { "potato", "gummy bears", "brittle cake", "managerie" };

            //int res =  IO_Global.io.MultipleChoice(strings);

            //Console.WriteLine($"\n\nthe number fed back to the system was {res}");


            //HeroType Rogue = new HeroType()
            //{
            //    ClassName = "Rogue",
            //    Speed = 50
            //};

            //DataAccess.Add(Rogue);

            //Item FountainPen = new Item()
            //{
            //    Name = "FountainPen",
            //    Description = "A pen that writes smoothly. and you can stab people in the eye with it."
            //};

            //DataAccess.Add(FountainPen);


            //EnemyType Ogre = new EnemyType()
            //{
            //    CreatureType = "Ogre",
            //    Speed = 30
            //};

            //DataAccess.Add<EnemyType>(Ogre);

            //EnemyType o = DataAccess.GetEntryById<EnemyType>(4);

            //if (o!=null)
            //{
            //    IO_Global.io.DisplayText(o.CreatureType);
            //}
            //else
            //{
            //    IO_Global.io.DisplayText("There was no entry there");
            //}

            //List<EnemyType> ene = DataAccess.GetTable<EnemyType>("Enemy Types");

            //foreach (var e in ene)
            //{
            //    Console.WriteLine($"{e.Id}:{e.CreatureType}");
            //}

            //Console.ReadLine();

            //Create_Game_Data.CreateGameData.init();

        }
    }
}
