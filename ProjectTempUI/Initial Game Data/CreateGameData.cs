using MidtermProject.EF;
using MidtermProject.Model;
using ProjectTempUI.EF.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject.Create_Game_Data
{
    class CreateGameData
    {
        static IList<Ability> InitialAbilities;
        static List<HeroType> heroClasses;
        static List<Hero_Name> hero_Names;
        static List<EnemyType> enemyTypes;
        static List<Item> items;
        static List<Encounter_Intro_Text> intros;
        public static void init()
        {
            Abilities();
            HeroClasses();
            HeroNames();
            Enemies();
            Items();
            Intros();

            var gs = GameState.CurrentGameState.GetInstance();
            UnitOfWork uow = gs.uow;

            uow.Abilities.AddRange(InitialAbilities);
            uow.HeroClasses.AddRange(heroClasses);
            uow.HeroNames.AddRange(hero_Names);
            uow.Enemies.AddRange(enemyTypes);
            uow.Items.AddRange(items);
            uow.IntroTexts.AddRange(intros);
            uow.Players.Add(new Player { UserName = "default", Password = "default" });
            uow.Complete();


        }

        //Creating these classes made me question the idea of making this game... 

        static void Intros()
        {
            intros = new List<Encounter_Intro_Text>
            {
                new Encounter_Intro_Text("As your party reaches a bridge, you notice it is guarded by"),
                new Encounter_Intro_Text("You continue in the darkness for some time, when you suddenly notice that just meer feet away stands"),
                new Encounter_Intro_Text("you are traveling through a maze and hear loud noises coming from behind. You turn around and see"),
                new Encounter_Intro_Text("You sit down at the Cafe and look through the menu, but as the waiter comes to take your order you notice it is actually"),
                new Encounter_Intro_Text("just as you lay down to rest around the campfire, you hear a strange noise. It is your uncle Rahamim, and he is accompanied by"),
                new Encounter_Intro_Text("You reached the crack of doom and are about to cast in the ring, but then you get a phone call and its from"),
                new Encounter_Intro_Text("The water in the swamp around you starts to swirl, and out of the morass emerges"),
                new Encounter_Intro_Text("After your long and perilous journey you stand in front of the dark throne. Sitting on top of the throne is"),
                new Encounter_Intro_Text("After a long battle with wolves over a sandwich you are waiting for your bus. When the bus pulls up, it is actually"),
                new Encounter_Intro_Text("you hear a roar 'MORE COWBELL!!' and out of the darkness jumps"),
                new Encounter_Intro_Text("you are walking down the street and out of the blue you are ambushed by"),



            };
        }
        static void Abilities()
        {
            InitialAbilities = new List<Ability> {

                new Ability{

                Name = "Basic Attack",//0
                Description = "A physical attack targeting a single target.",
                verb = "Took damage",
                AOE = false,
                TargetEnemies = true,
                IsPhysical = true,
                DamageDealt = 10
                },
                new Ability{
                Name = "Lightning bolt",//1
                Description = "A Magic type attack targeting a single target.",
                verb = "Took damage",
                AOE = false,
                TargetEnemies = true,
                IsPhysical = false,
                DamageDealt = 10,
                Manacost = 150
                },
                new Ability{
                Name = "Pyromania",//2
                Description = "A Magic type attack targeting multiple enemies.",
                verb = "Took Damage",
                AOE = true,
                TargetEnemies = true,
                IsPhysical = false,
                DamageDealt = 6,
                Manacost = 150

                },
                new Ability{
                Name = "Cleaving Attack",//3
                Description = "A physical attack targeting multiple enemies.",
                verb = "Took Damage",
                AOE = true,
                TargetEnemies = true,
                IsPhysical = true,
                DamageDealt = 6,
                Manacost = 100
                },
                new Ability{
                Name = "Smoke Bomb",//4
                Description = "Deals a small amount of damage and lowers accuracy of all enemies.",
                verb = "Took Damage and Had their accuracy lowered",
                AOE = true,
                TargetEnemies = true,
                Alter_Accuracy = 2.5,
                IsPhysical = true,
                DamageDealt = 2,
                Manacost = 120

                },

                new Ability{
                Name = "Frost Bolt",//5
                Description = "A Magic attack that damages and slows a single enemy.",
                verb = "Took Damage and was slowed down",
                AOE = false,
                TargetEnemies = true,
                IsPhysical = false,
                Alter_Speed = 4,
                DamageDealt = 6,

                Manacost = 100

                },

            new Ability{
                Name = "Frost Nova",//6
                Description = "Slows multiple enemies with minor damage.",
                verb = "Took Damage and was slowed down",
                AOE = true,
                TargetEnemies = true,
                IsPhysical = false,
                Alter_Speed = 2.5,
                DamageDealt = 2.5,
                Manacost = 110
                },


                new Ability{
                Name = "Toxic Stab",//7
                Description = "Damage and decrease accuracy for 1 enemy.",
                verb = "Took Damage and Had their accuracy lowered",
                AOE = false,
                TargetEnemies = true,
                IsPhysical = true,
                Alter_Accuracy = 6,
                DamageDealt = 8,
                Manacost = 180

                },

            new Ability{
                Name = "Shield Slam",//8
                Description = "Lower strength for 1 enemy.",
                verb = "Took Damage and Had their strength lowered",
                AOE = false,
                TargetEnemies = true,
                IsPhysical = true,
                Alter_Strength = 5,
                DamageDealt = 1,
                Manacost = 180

                },

            new Ability{
                Name = "Magic Barrier",//9
                Description = "Decrease all enemy spell power.",
                verb = "Had their Spell Power lowered",
                AOE = true,
                TargetEnemies = true,
                IsPhysical = false,
                Alter_Spell_Power = 3,
                Manacost = 140

                },
            new Ability{
                Name = "Acid Rain",//10
                Description = "Lower armor for all enemies and lightly damage them.",
                verb = "Took Damage and Had their armor lowered",
                AOE = true,
                TargetEnemies = true,
                IsPhysical = false,
                Alter_Armor = 6,
                DamageDealt = 2,
                Manacost = 100

                },
            new Ability{
                Name = "Mana Burn",//11
                Description = "burn mana and damage one enemy.",
                verb = "Took Damage and Lost Mana",
                AOE = false,
                TargetEnemies = true,
                IsPhysical = false,
                Alter_Mana = 5,
                DamageDealt = 5,
                Manacost = 90

                },

            new Ability{
                Name = "Heal",//12
                Description = "Heal one ally.",
                verb = "Was healed",
                AOE = false,
                TargetEnemies = false,
                IsPhysical = false,

                Alter_HP = -10,
                Manacost = 100


                },
            new Ability{
                Name = "Healing Wave",//13
                Description = "Heal all allies.",
                verb = "Were healed",
                AOE = true,
                TargetEnemies = false,
                IsPhysical = false,

                Alter_HP = -4,
                Manacost = 130


                },

            new Ability{
                Name = "Defend",//14
                Description = "Raise the armor of one ally.",
                verb = "Gained armor",
                AOE = false,
                TargetEnemies = false,
                IsPhysical = true,

                Alter_Armor = -10,
                Manacost = 150

                },

                        new Ability{
                Name = "Beer Keg",//15
                Description = "Raise the Strength of all allies.",
                verb = "Gained Strength",
                AOE = true,
                TargetEnemies = false,
                IsPhysical = true,

                Alter_Strength = -5,
                Manacost = 110

                },
            new Ability{
                Name = "Arcane Contact lenses",//16
                Description = "Raise the accuracy of all allies.",
                verb = "Gained Accuracy",
                AOE = true,
                TargetEnemies = false,
                IsPhysical = false,

                Alter_Accuracy = -3,
                Manacost = 110

                },
                new Ability{
                Name = "Sugar Rush",//17
                Description = "Raise the speed of one ally.",
                verb = "Gained Speed",
                AOE = false,
                TargetEnemies = false,
                IsPhysical = false,

                Alter_Speed = - 10,
                Manacost = 120

                },

                new Ability{
                Name = "Force Field",//18
                Description = "Raise the magic resistaince of all allies.",
                verb = "Gained Magic Resistance",
                AOE = true,
                TargetEnemies = false,
                IsPhysical = false,

                Alter_Magic_Resistance = - 5,
                Manacost = 150

                },

                new Ability{
                Name = "Arcane Amplifier",//19
                Description = "Raise the spell power of one ally.",
                verb = "Gained Spell Power",
                AOE = false,
                TargetEnemies = false,
                IsPhysical = false,

                Alter_Spell_Power = - 10,
                Manacost = 180

                },
                new Ability{
                Name = "Mana Fountain",//20
                Description = "Restore mana for all allies.",
                verb = "Gained Mana",
                AOE = true,
                TargetEnemies = false,
                IsPhysical = false,

                Alter_Mana = -6,
                Manacost = 120

                },
                new Ability{
                Name = "Headshot",//21
                Description = "Deal Crazy damage to one target .",
                verb = "Took great damage",
                AOE = false,
                TargetEnemies = true,
                IsPhysical = true,

                DamageDealt = 15,
                Manacost = 180

                },

                new Ability{
                Name = "Poisoned Arrows",//22
                Description = "Deal damage to one enemy and greatly decrease its armor.",
                verb = "Took damage and lost armor",
                AOE = false,
                TargetEnemies = true,
                IsPhysical = true,

                Alter_Armor = 7,
                DamageDealt = 7,
                Manacost = 120

                },



            };

        }

        static void HeroNames()
        {
            hero_Names = new List<Hero_Name> {
           new Hero_Name("David ben Gurion"),
           new Hero_Name("Mickey Mouse"),
           new Hero_Name("Jerry Smith"),
           new Hero_Name("Martin Luther king"),
           new Hero_Name("Oded Katash"),
           new Hero_Name("Peregrin Took"),
           new Hero_Name("Golda Meir"),
           new Hero_Name("Bartholemew J. Simpson"),
           new Hero_Name("Ender Wiggin"),
           new Hero_Name("Roran Stronghammer"),
           new Hero_Name("Bolivar Trask"),
           new Hero_Name("Dwight Schrute"),
           new Hero_Name("Michael Scott"),
           new Hero_Name("Creed Bratton"),
           new Hero_Name("Andrew Bernard"),
           new Hero_Name("Jack Black"),
           new Hero_Name("Mike Piazza"),
           new Hero_Name("Daisy Duck"),
           new Hero_Name("Uzi Hitman"),
           new Hero_Name("Oren Zarrif"),
           new Hero_Name("Sir Paul MCcartney"),
           new Hero_Name("Davey Crockett"),
           new Hero_Name("Noam Chomsky"),
           new Hero_Name("Dewey Finn"),
           new Hero_Name("Hugh Campbell"),

            };

        }

        static void HeroClasses()
        {
            heroClasses = new List<HeroType> {

            new HeroType{
                classIndex = 0,
                ClassName = "Knight",
                Accuracy = 10,
                Speed = 20,
                Strength = 20,
                Armor = 30,
                Spell_Power = 5,
                Magic_Resistance = 10,
                HP = 500,
                Mana = 100,
                Level = 1,
                Abilities = new List<Ability>{ InitialAbilities[3], InitialAbilities[8], InitialAbilities[14] }
            },

            new HeroType{
                classIndex = 1,
                ClassName = "Cleric",
                Accuracy = 10,
                Speed = 10,
                Strength = 5,
                Armor = 10,
                Spell_Power = 15,
                Magic_Resistance = 15,
                HP = 350,
                Mana = 500,
                Level = 1,
                Abilities = new List<Ability>{ InitialAbilities[13], InitialAbilities[12], InitialAbilities[10] }
            },
            new HeroType{
                classIndex = 2,
                ClassName = "Rogue",
                Accuracy = 25,
                Speed = 30,
                Strength = 30,
                Armor = 5,
                Spell_Power = 20,
                Magic_Resistance = 5,
                HP = 300,
                Mana = 350,
                Level = 1,
                Abilities = new List<Ability>{ InitialAbilities[4], InitialAbilities[7], InitialAbilities[11] }
            },
            new HeroType{
                ClassName = "Mage",
                classIndex = 3,
                Accuracy = 20,
                Speed = 15,
                Strength = 5,
                Armor = 10,
                Spell_Power = 30,
                Magic_Resistance = 30,
                HP = 350,
                Mana = 500,
                Level = 1,
                Abilities = new List<Ability>{ InitialAbilities[1], InitialAbilities[2], InitialAbilities[18] }
            },
            new HeroType{
                ClassName = "Druid",
                classIndex = 4,
                Accuracy = 15,
                Speed = 15,
                Strength = 15,
                Armor = 15,
                Spell_Power = 15,
                Magic_Resistance = 15,
                HP = 400,
                Mana = 400,
                Level = 1,
                Abilities = new List<Ability>{ InitialAbilities[5], InitialAbilities[6], InitialAbilities[20] }
            },
            new HeroType{
                ClassName = "Ranger",
                classIndex = 5,
                Accuracy = 30,
                Speed = 20,
                Strength = 30,
                Armor = 10,
                Spell_Power = 5,
                Magic_Resistance = 10,
                HP = 300,
                Mana = 100,
                Level = 1,
                Abilities = new List<Ability>{ InitialAbilities[21], InitialAbilities[19], InitialAbilities[22] }
            },
            new HeroType{
                ClassName = "Bard",
                classIndex = 6,
                Accuracy = 10,
                Speed = 10,
                Strength = 10,
                Armor = 10,
                Spell_Power = 25,
                Magic_Resistance = 25,
                HP = 350,
                Mana = 450,
                Level = 1,
                Abilities = new List<Ability>{ InitialAbilities[16], InitialAbilities[15], InitialAbilities[17] }
            }

            };

        }

        static void Enemies()
        {
            enemyTypes = new List<EnemyType>
            {
            new EnemyType
                {
                    CreatureType = "Gremlin",
                    Level = 1,
                    Accuracy = 8,
                    Speed = 10,
                    Strength = 8,
                    Armor = 5,
                    Spell_Power = 5,
                    Magic_Resistance = 5,
                    HP = 100,
                    Mana = 200,
                    Abilities = new List<Ability>{InitialAbilities[22]}

                },
            new EnemyType
                {
                    CreatureType = "Kobold",
                    Level = 1,
                    Accuracy = 5,
                    Speed = 15,
                    Strength = 5,
                    Armor = 5,
                    Spell_Power = 10,
                    Magic_Resistance = 10,
                    HP = 120,
                    Mana = 100,
                    Abilities = new List<Ability>{InitialAbilities[15] }

                },
            new EnemyType
                {
                    CreatureType = "Imp",
                    Level = 1,
                    Accuracy = 10,
                    Speed = 10,
                    Strength = 10,
                    Armor = 10,
                    Spell_Power = 1,
                    Magic_Resistance = 1,
                    HP = 200,
                    Mana = 50,
                    Abilities = new List<Ability>{InitialAbilities[2] }

                },
            new EnemyType
                {
                    CreatureType = "Goblin",
                    Level = 2,
                    Accuracy = 15,
                    Speed = 20,
                    Strength = 20,
                    Armor = 20,
                    Spell_Power = 5,
                    Magic_Resistance = 5,
                    HP = 150,
                    Mana = 50,
                    Abilities = new List<Ability>{InitialAbilities[4]}

                },
            new EnemyType
                {
                    CreatureType = "Gargoyle",
                    Level = 2,
                    Accuracy = 10,
                    Speed = 20,
                    Strength = 20,
                    Armor = 20,
                    Spell_Power = 10,
                    Magic_Resistance = 10,
                    HP = 200,
                    Mana = 50,
                    Abilities = new List<Ability>{InitialAbilities[19] }

                },
            new EnemyType
                {
                    CreatureType = "Murloc",
                    Level = 2,
                    Accuracy = 10,
                    Speed = 15,
                    Strength = 10,
                    Armor = 10,
                    Spell_Power = 10,
                    Magic_Resistance = 10,
                    HP = 300,
                    Mana = 150,
                    Abilities = new List<Ability>{InitialAbilities[5] }

                },

            new EnemyType
                {
                    CreatureType = "Orc",
                    Level = 3,
                     Accuracy = 10,
                    Speed = 20,
                    Strength = 20,
                    Armor = 30,
                    Spell_Power = 5,
                    Magic_Resistance = 10,
                    HP = 400,
                    Mana = 100,
                    Abilities = new List<Ability>{InitialAbilities[8], InitialAbilities[15] }

                },
            new EnemyType
                {
                    CreatureType = "Ghoul",
                    Level = 3,
                    Accuracy = 10,
                    Speed = 10,
                    Strength = 30,
                    Armor = 30,
                    Spell_Power = 10,
                    Magic_Resistance = 30,
                    HP = 400,
                    Mana = 100,
                    Abilities = new List<Ability>{InitialAbilities[3], InitialAbilities[18] }

                },
            new EnemyType
                {
                    CreatureType = "Bandit",
                    Level = 3,
                    Accuracy = 25,
                    Speed = 25,
                    Strength = 30,
                    Armor = 15,
                    Spell_Power = 10,
                    Magic_Resistance = 10,
                    HP = 300,
                    Mana = 100,
                    Abilities = new List<Ability>{InitialAbilities[4], InitialAbilities[7] }

                },
            new EnemyType
                {
                    CreatureType = "Giant Rat",
                    Level = 4,
                    Accuracy = 30,
                    Speed = 30,
                    Strength = 30,
                    Armor = 30,
                    Spell_Power = 20,
                    Magic_Resistance = 20,
                    HP = 500,
                    Mana = 200,
                    Abilities = new List<Ability>{InitialAbilities[7]}

                },
            new EnemyType
                {
                    CreatureType = "Witch",
                    Level = 4,
                    Accuracy = 30,
                    Speed = 20,
                    Strength = 20,
                    Armor = 20,
                    Spell_Power = 40,
                    Magic_Resistance = 40,
                    HP = 380,
                    Mana = 500,
                    Abilities = new List<Ability>{InitialAbilities[6], InitialAbilities[1] }

                },
                        new EnemyType
                {
                    CreatureType = "Brigand",
                    Level = 4,
                    Accuracy = 35,
                    Speed = 40,
                    Strength = 30,
                    Armor = 25,
                    Spell_Power = 25,
                    Magic_Resistance = 25,
                    HP = 450,
                    Mana = 350,
                    Abilities = new List<Ability>{InitialAbilities[4], InitialAbilities[17] }

                },
            new EnemyType
                {
                    CreatureType = "Naga",
                    Level = 5,
                    Accuracy = 40,
                    Speed = 40,
                    Strength = 30,
                    Armor = 30,
                    Spell_Power = 45,
                    Magic_Resistance = 45,
                    HP = 450,
                    Mana = 500,
                    Abilities = new List<Ability>{InitialAbilities[5], InitialAbilities[6] }

                },
                new EnemyType
                {
                    CreatureType = "Wyvern",
                    Level = 5,
                    Accuracy = 35,
                    Speed = 50,
                    Strength = 40,
                    Armor = 25,
                    Spell_Power = 30,
                    Magic_Resistance = 25,
                    HP = 500,
                    Mana = 350,
                    Abilities = new List<Ability>{InitialAbilities[22], InitialAbilities[10] }

                },
            new EnemyType
                {
                    CreatureType = "Djinn",
                    Level = 5,
                    Accuracy = 45,
                    Speed = 50,
                    Strength = 20,
                    Armor = 20,
                    Spell_Power = 50,
                    Magic_Resistance = 50,
                    HP = 450,
                    Mana = 500,
                    Abilities = new List<Ability>{InitialAbilities[18], InitialAbilities[11],InitialAbilities[1] }

                },
            new EnemyType
                {
                    CreatureType = "Death Knight",
                    Level = 6,
                    Accuracy = 40,
                    Speed = 50,
                    Strength = 50,
                    Armor = 60,
                    Spell_Power = 35,
                    Magic_Resistance = 35,
                    HP = 600,
                    Mana = 400,
                    Abilities = new List<Ability>{InitialAbilities[11], InitialAbilities[14], InitialAbilities[8] }

                },
            new EnemyType
                {
                    CreatureType = "Lesser Demon",
                    Level = 6,
                    Accuracy = 55,
                    Speed = 55,
                    Strength = 50,
                    Armor = 40,
                    Spell_Power = 60,
                    Magic_Resistance = 55,
                    HP = 500,
                    Mana = 600,
                    Abilities = new List<Ability>{InitialAbilities[2], InitialAbilities[21], InitialAbilities[10] }

                },
            new EnemyType
                {
                    CreatureType = "Giant Bear",
                    Level = 6,
                    Accuracy = 35,
                    Speed = 55,
                    Strength = 60,
                    Armor = 60,
                    Spell_Power = 20,
                    Magic_Resistance = 20,
                    HP = 700,
                    Mana = 300,
                    Abilities = new List<Ability>{InitialAbilities[3], InitialAbilities[14], InitialAbilities[15] }

                },
            new EnemyType
                {
                    CreatureType = "Vampire",
                    Level = 7,
                    Accuracy = 65,
                    Speed = 70,
                    Strength = 70,
                    Armor = 50,
                    Spell_Power = 70,
                    Magic_Resistance = 50,
                    HP = 500,
                    Mana = 700,
                    Abilities = new List<Ability>{InitialAbilities[7], InitialAbilities[17], InitialAbilities[9] }

                },

            new EnemyType
                {
                    CreatureType = "Shadow Priest",
                    Level = 7,
                    Accuracy = 70,
                    Speed = 60,
                    Strength = 50,
                    Armor = 50,
                    Spell_Power = 70,
                    Magic_Resistance = 70,
                    HP = 550,
                    Mana = 700,
                    Abilities = new List<Ability>{InitialAbilities[13], InitialAbilities[12], InitialAbilities[11] }

                },
            new EnemyType
                {
                    CreatureType = "Cave Troll",
                    Level = 7,
                    Accuracy = 40,
                    Speed = 50,
                    Strength = 70,
                    Armor = 70,
                    Spell_Power = 60,
                    Magic_Resistance = 60,
                    HP = 700,
                    Mana = 400,
                    Abilities = new List<Ability>{InitialAbilities[15], InitialAbilities[3] }

                },

                        new EnemyType
                {
                    CreatureType = "Rock Giant",
                    Level = 8,
                    Accuracy = 40,
                    Speed = 50,
                    Strength = 80,
                    Armor = 80,
                    Spell_Power = 60,
                    Magic_Resistance = 80,
                    HP = 800,
                    Mana = 600,
                    Abilities = new List<Ability>{InitialAbilities[14], InitialAbilities[3], InitialAbilities[7] }

                },
                        new EnemyType
                {
                    CreatureType = "Warlock",
                    Level = 8,
                    Accuracy = 75,
                    Speed = 70,
                    Strength = 40,
                    Armor = 40,
                    Spell_Power = 80,
                    Magic_Resistance = 75,
                    HP = 600,
                    Mana = 800,
                    Abilities = new List<Ability>{InitialAbilities[19], InitialAbilities[1], InitialAbilities[2] }

                },
                        new EnemyType
                {
                    CreatureType = "Gorgon",
                    Level = 8,
                    Accuracy = 80,
                    Speed = 580,
                    Strength = 60,
                    Armor = 60,
                    Spell_Power = 80,
                    Magic_Resistance = 80,
                    HP = 650,
                    Mana = 750,
                    Abilities = new List<Ability>{InitialAbilities[5], InitialAbilities[6], InitialAbilities[16] }

                },
                        new EnemyType
                {
                    CreatureType = "Hydra",
                    Level = 9,
                    Accuracy = 75,
                    Speed = 75,
                    Strength = 90,
                    Armor = 90,
                    Spell_Power = 90,
                    Magic_Resistance = 90,
                    HP = 900,
                    Mana = 600,
                    Abilities = new List<Ability>{InitialAbilities[3], InitialAbilities[2], InitialAbilities[7] }

                },
                        new EnemyType
                {
                    CreatureType = "HellHound",
                    Level = 9,
                    Accuracy = 85,
                    Speed = 90,
                    Strength = 85,
                    Armor = 70,
                    Spell_Power = 70,
                    Magic_Resistance = 85,
                    HP = 750,
                    Mana = 500,
                    Abilities = new List<Ability>(){InitialAbilities[3], InitialAbilities[11]}

                },
                        new EnemyType
                {
                    CreatureType = "Necromancer",
                    Level = 9,
                    Accuracy = 90,
                    Speed = 85,
                    Strength = 65,
                    Armor = 65,
                    Spell_Power = 100,
                    Magic_Resistance = 100,
                    HP = 600,
                    Mana = 1000,
                    Abilities = new List<Ability>{InitialAbilities[18], InitialAbilities[9], InitialAbilities[21] }

                },
            new EnemyType
                {
                    CreatureType = "Chuck Norris",
                    Level = 10,
                    Accuracy = 100,
                    Speed = 100,
                    Strength = 100,
                    Armor = 100,
                    Spell_Power = 100,
                    Magic_Resistance = 100,
                    HP = 1000,
                    Mana = 1000,
                    Abilities = new List<Ability>{InitialAbilities[21], InitialAbilities[5], InitialAbilities[3] }

                },
            new EnemyType
                {
                    CreatureType = "Black Dragon",
                    Level = 10,
                    Accuracy = 80,
                    Speed = 80,
                    Strength = 120,
                    Armor = 120,
                    Spell_Power = 120,
                    Magic_Resistance = 120,
                    HP = 1200,
                    Mana = 1200,
                    Abilities = new List<Ability>{InitialAbilities[3], InitialAbilities[2], InitialAbilities[4] }

                },
            new EnemyType
                {
                    CreatureType = "Elder Demon",
                    Level = 10,
                    Accuracy = 100,
                    Speed = 95,
                    Strength = 95,
                    Armor = 95,
                    Spell_Power = 100,
                    Magic_Resistance = 100,
                    HP = 1000,
                    Mana = 1000,
                    Abilities = new List<Ability>{InitialAbilities[1], InitialAbilities[17], InitialAbilities[18] }

                },
            };


        }

        static void Items()
        {
            items = new List<Item>
            {
                new Item{
                Name = "Health potion",
                Description = "Heals 150 hp",
                HP_Bonus = 150,
                Active = true,
                IsArchetype = true

                },
                new Item{
                Name = "Mega Health potion",
                Description = "Heals 450 hp",
                HP_Bonus = 450,
                Active = true,
                IsArchetype = true

                },
                new Item{
                Name = "Mega Mana potion",
                Description = "Restores 450 mana",
                Mana_Bonus = 450,
                Active = true,

                IsArchetype = true
                },

                new Item{
                Name = "Mana potion",
                Description = "Restores 150 mana",
                Mana_Bonus = 150,
                Active = true,
                IsArchetype = true
                },

                new Item{
                Name = "Glasses",
                Description = "passive accuracy bonus",
                Accuracy_Bonus = 10,
                Active = false,
                IsArchetype = true
                },

                new Item{
                Name = "Adidas Sneakers",
                Description = "passive speed bonus",
                Speed_Bonus = 10,
                Active = false,
                IsArchetype = true
                },
                new Item{
                Name = "Anger issues",
                Description = "passive attack bonus",
                Strength_Bonus = 10,
                Active = false,
                IsArchetype = true
                },
                new Item{
                Name = "Bookmark",
                Description = "passive Spell Power bonus",
                Spell_Power_Bonus = 10,
                Active = false,
                IsArchetype = true
                },
                new Item{
                Name = "Wool sweater-Vest",
                Description = "passive armor bonus",
                Armor_Bonus = 10,
                Active = false,
                IsArchetype = true
                },
                new Item{
                Name = "Gym Membership",
                Description = "passive hp bonus",
                HP_Bonus = 10,
                Active = false,
                IsArchetype = true
                },
                new Item{
                Name = "Fountain Pen",
                Description = "passive mana bonus",
                Mana_Bonus = 10,
                Active = false,
                IsArchetype = true
                },
            };

        }
    }
}
