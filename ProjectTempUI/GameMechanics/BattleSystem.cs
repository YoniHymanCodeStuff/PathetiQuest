using MidtermProject.Model;
using MidtermProject.GameState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using io = MidtermProject.input_output.IO_Global;

namespace ProjectTempUI.GameMechanics
{
    class BattleSystem
    {
        private static Random rnd = new Random();
        private static List<EnemyType> Enemies;
        private static List<Hero> Heroes;
        private static List<EnemyType> DeadEnemies;
        private static List<Hero> DeadHeroes;
        private static BLoopInfo bl;

        public static async Task StartBattle()
        {
            var gs = CurrentGameState.GetInstance();
            io.io.ClearScreen();
            
            //generate intro text. 
            string introtext =  gs.uow.IntroTexts.GetRandomText();

            Heroes = gs.CurrentPlayer.Heroes.ToList();//is this clones or operating on the originals? 
            Enemies = GenerateEnemies();

            string pluralizer = "s";
            if (Enemies.Count == 1) { pluralizer = ""; }
            await io.io.DisplayText($"{introtext} {Enemies.Count} {Enemies[0].CreatureType}{pluralizer}.");

            int choice = await io.io.GetChoice(new List<string> { "Fight", "Retreat" }, false);

            //retreat :
            if (choice == 1)
            {
                //(has 25% chance to fail):
                if (rnd.NextDouble() > 0.25)
                {
                    await io.io.DisplayText($"You have successfully retreated.");
                    await io.io.GetNextCommand();
                    await InGameMenu.MainMenu();
                    return;
                }
                else
                {
                    await io.io.DisplayText($"You attempted to retreat, but the {Enemies[0].CreatureType}{pluralizer} chased you down.");
                }
            }
            //this might want to be its own function, but then it is more difficult to toggle stopping the flow of the main one, and - no time. 

            await io.io.DisplayText($"Chaaaarge!!!");
            await io.io.GetNextCommand();

            try
            {
                await BattleLoop();
            }

            catch (Exception e)
            {
                await io.io.DisplayText(e.ToString());
            }

        }

        class BLoopInfo // this contains the info for a battle loop. 
        {
            public Dictionary<Unit, Ability> FighterMovePairs = new Dictionary<Unit, Ability>();

            public Dictionary<Hero, List<Ability>> SingleTargets = new Dictionary<Hero, List<Ability>>();

            public double HeroGroupDamage { get; set; } = 0;

            public List<string> HeroGroupEffects { get; set; } = new List<string>();

            public double EnemyGroupDamage { get; set; } = 0;

            public List<string> EnemyGroupEffects { get; set; } = new List<string>();

            public List<Hero> HeroDiedThisRound { get; set; } = new List<Hero>();
            public int EnemyDiedThisRound { get; set; } = 0;

            public bool CurrentTargetisEnemy { get; set; }

        }

        private static async Task BattleLoop()
        {

            
            //var gs = CurrentGameState.GetInstance();

            DeadHeroes = new List<Hero>();
            DeadEnemies = new List<EnemyType>();


            int counter = 0;

            //the actual battle loop:
            while ((Enemies.Count > 0) && (Heroes.Count > 0))
            {

                //round of battle:
                io.io.ClearScreen();
                bl = new BLoopInfo();
                counter++;
                await io.io.DisplayText($"Round {counter}:");
                await io.io.GetNextCommand();

                //get all attack commands:
                foreach (Hero h in Heroes)
                {
                    if (h.HP > 0)
                    {
                        Ability attack = await GetHeroAttack(h);
                        bl.FighterMovePairs.Add(h, attack);
                    }
                }
                foreach (EnemyType e in Enemies)
                {
                    if (e.HP > 0)
                    {

                        Ability attack = GetEnemyAttack(e);
                        bl.FighterMovePairs.Add(e, attack);
                    }
                }



                //sort the attacks so fastest goes first:
                bl.FighterMovePairs.OrderByDescending(x => x.Key.Speed);




                //execute attacks: 
                foreach (var i in bl.FighterMovePairs)
                {

                    //checking that there are still live units on both sides... since that could happen during subloop...
                    if (i.Key.HP > 0 && Enemies.Where(x=>x.HP>0).ToList().Count > 0 && Heroes.Where(x => x.HP > 0).ToList().Count > 0)
                    {


                        List<Unit> targets = GetTargets(i.Key, i.Value);



                        ApplyEffects(i.Key, targets, i.Value);


                    }


                }
             
                
                await ShowRoundResults();

                RemoveDead();

            }

            
            if (Heroes.Count == 0)
            {
                await BattleAftermath.Defeat();
            }
            else
            {
                await Inheritance();
                await BattleAftermath.Victory(DeadEnemies);
            }
        }

        
        private static async Task Inheritance()
        {
            //this deals with removing dead heroes from the main collection after the battle and transfers their items. 
            var gs = CurrentGameState.GetInstance();

            foreach (var h in DeadHeroes)
            {
                await io.io.DisplayText($"We Avenge our fallen comrade {h.ProperName} the {h.ClassName}. The items that he was holding have been returned to your inventory, and his soul has been returned to the binary code from whence it came. ");
                foreach (var item in h.EquippedItem)
                {
                    gs.CurrentPlayer.InventoryItem.Add(item);
                }
                gs.CurrentPlayer.Heroes.Remove(h);

            }

            await io.io.GetNextCommand();
        }

        private static void RemoveDead()
        {
            //this removes dead heroes and enemies from the 
            //collection that the battle loop iterates through. 

            DeadHeroes.AddRange(Heroes.Where(x => x.HP <= 0).ToList());
            Heroes.RemoveAll(x => x.HP <= 0);


            DeadEnemies.AddRange(Enemies.Where(x => x.HP <= 0).ToList());
            Enemies.RemoveAll(x => x.HP <= 0);
            
        }

        private static async Task ShowRoundResults()
        {
            
            io.io.ClearScreen();
            string resultstr = "Round Results:\n\n";


            string singleTargets = "";
            //adding text for all single targeted heroes. 
                        

            foreach (var d in bl.SingleTargets)
            {
                //removing doubles from list. didn't work... 
                bl.SingleTargets[d.Key] = d.Value.Distinct().ToList();
                
                singleTargets += $"{d.Key.ProperName} ";

                //only if unit was damaged add health left. 
                bool wasdamaged = false;
                string healthleft = ".";

                List<string> vtexts = new List<string>();

                foreach (var ability in d.Value)
                {
                    vtexts.Add(ability.verb);
                    if (ability.DamageDealt > 0) { wasdamaged = true; }
                                     
                }

                vtexts = vtexts.Distinct().ToList();

                foreach (var v in vtexts)
                {
                    singleTargets += v;
                }

                if(wasdamaged && d.Key.HP>0)
                { healthleft = $" and was left with {Math.Round(d.Key.HP, 2)} Health."; }

                singleTargets += healthleft;

            }

            resultstr += singleTargets;

            //adding AOE damage and effects:
            if (bl.HeroGroupEffects.Count > 0 || bl.HeroGroupDamage > 0)
            {
                resultstr += $"\nParty members ";
                foreach (var str in bl.HeroGroupEffects)
                {
                    resultstr += str + ", ";

                }
                if (bl.HeroGroupEffects.Count > 0) { resultstr += "and"; }

                resultstr += $" lost a total of {Math.Round(bl.HeroGroupDamage,2)} health.";

            }

            //Adding Deaths:
            if (bl.HeroDiedThisRound.Count > 0)
            {
                foreach (var hero in bl.HeroDiedThisRound)
                {
                    resultstr += $"\n\nTragically, {hero.ProperName} the {hero.ClassName} was killed and shall haunt our souls for eternity.";
                }

            }

            //info for enemies:
            string pluralizer = "s";
            if (Enemies.Count == 1) { pluralizer = ""; }

            string effects = "";

            List<string> evtexts = bl.EnemyGroupEffects.Distinct().ToList();

            foreach (var str in evtexts)
            {
                effects += str + ", ";

            }

            resultstr += $"\n\nThe {Enemies[0].CreatureType}{pluralizer} have {effects}.They have lost a total of {bl.EnemyGroupDamage} health. {bl.EnemyDiedThisRound} of them have been vanquished.";

            await io.io.DisplayText(resultstr);
            await io.io.GetNextCommand();
        }

        private static void ApplyEffects(Unit caster, List<Unit> targets, Ability ability)
        {
            //var gs = CurrentGameState.GetInstance();

            double RelevantBuffer;
            double RelevantAttack;

                       
            //set up right type of attack: 
            if (ability.IsPhysical)
            { RelevantAttack = caster.Strength; }
            else
            { RelevantAttack = caster.Spell_Power; }


            double damageOutput = ability.DamageDealt * RelevantAttack;

            //the attack will do this-100% of it's potential dmg :
            int MinDamagePercent = 75;
            //multiply the attack by this: 
            double randomizer = (double)(rnd.Next(MinDamagePercent, 101)) / 100;

            //apply mana cost:
            caster.Mana -= ability.Manacost;

            

            //logging the data to use in message:
            if (bl.CurrentTargetisEnemy)
            {
                bl.EnemyGroupEffects.Add(ability.verb);

            }
            else
            {

                if (!ability.AOE)
                {
                    Hero targethero = ((Hero)targets[0]);
                    
                    if (bl.SingleTargets.ContainsKey(targethero))
                    {
                        bl.SingleTargets[targethero].Add(ability);
                    }
                    else
                    {
                        bl.SingleTargets.Add(targethero, new List<Ability> { ability });
                    }

                }
                else
                {

                    bl.HeroGroupEffects.Add(ability.verb);
                }

            }

            

            //applying to targets:
            foreach (var target in targets)
            {

                
                //do not apply to dead units: 
                if (target.HP <= 0)
                {
                    continue;
                }

                //should apply accuracy here... 

                //set up right type of defense: 
                if (ability.IsPhysical)
                { RelevantBuffer = target.Armor; }
                else
                { RelevantBuffer = caster.Magic_Resistance; }

                double totalDamage = (damageOutput * randomizer) - RelevantBuffer;

                target.HP -= totalDamage;
                target.Mana -= ability.Alter_Mana;
                target.Accuracy -= ability.Alter_Accuracy;
                target.Speed -= ability.Alter_Speed;
                target.Strength -= ability.Alter_Strength;
                target.Spell_Power -= ability.Alter_Spell_Power;
                target.Armor -= ability.Alter_Armor;
                target.Magic_Resistance -= ability.Alter_Magic_Resistance;

                
                //logging the damage done: 
                if (bl.CurrentTargetisEnemy)
                {
                    bl.EnemyGroupDamage += totalDamage;


                }
                else
                {
                    bl.HeroGroupDamage += totalDamage;
                }


                

                //taking care of deaths. not removing from list untill out of loop.. 
                if (target.HP <= 0)
                {
                    if (bl.CurrentTargetisEnemy)
                    {
                        bl.EnemyDiedThisRound++;

                    }

                    else
                    {
                        bl.HeroDiedThisRound.Add((Hero)target);

                    }
                }
                
            }

        }

        private static List<Unit> GetTargets(Unit caster, Ability ability)
        {
            //var gs = CurrentGameState.GetInstance();
            List<Unit> PotentialTargets;

            if (ability.TargetEnemies && Heroes.Contains(caster)
                || !ability.TargetEnemies && Enemies.Contains(caster))
            {
                PotentialTargets = Enemies.Cast<Unit>().ToList();
                bl.CurrentTargetisEnemy = true;

                //this might have worked, or it might have made a big mess... 
            }
            else
            {
                PotentialTargets = Heroes.Cast<Unit>().ToList();
                bl.CurrentTargetisEnemy = false;

            }

            //filter out dead things. (the lists get cleansed only at the end of each round) 
            PotentialTargets = PotentialTargets.Where(x => x.HP > 0).ToList();

            //pick single target with lowest health. yes, this is my whole AI logic... 
            if (!ability.AOE)
            {
                PotentialTargets.OrderBy(x => x.HP);
                Unit temp = PotentialTargets[0];
                PotentialTargets = new List<Unit> { temp };

            }

            return PotentialTargets;
        }
        private static Ability GetEnemyAttack(EnemyType e)
        {

            var Abils = e.Abilities.ToList();
            //if this is somehow just a pointer it will be bad... 
            //hopefully conversion deals with that... 

            int choice;

            //check for enough mana:
            while (true)
            {
                choice = rnd.Next(0, Abils.Count);

                if (Abils[choice].Manacost <= e.Mana)
                { break; }
                else
                { Abils.RemoveAt(choice); }
            }

            return Abils[choice];
        }
        private static async Task<Ability> GetHeroAttack(Hero h)
        {

            await io.io.DisplayText($"Choose an attack for {h.ProperName}:");

            int choice = await io.io.GetChoice(h.Abilities.Select(x => x.Name).ToList(), false);

            //filter out things you don't have the mana to use:
            while (h.Abilities.ToList()[choice].Manacost > h.Mana)
            {
                await io.io.DisplayText($"{h.ProperName} doesn't have enough mana left to use {h.Abilities.ToList()[choice].Name}. Please select a different choice:");
                choice = await io.io.GetChoice(h.Abilities.Select(x => x.Name).ToList(), false);
            }

            return h.Abilities.ToList()[choice];
        }

        private static List<EnemyType> GenerateEnemies()
        {
            var gs = CurrentGameState.GetInstance();
            double avglevel = gs.CurrentPlayer.Heroes.Select(x => x.Level).ToList().Average();

            //there are 20 hero levels for 10 enemy levels. this is so the range
            //enemies level can be is close to the parralel of the hero average. 

            int enemylevelbase = (int)Math.Ceiling(avglevel / 2);

            //this get a random enemy type in the range of one above and one beneath the input. 
            EnemyType currentET = gs.uow.Enemies.EagerloadRandomEnemyType(enemylevelbase);

            //determine the amount of enemies... goes down according to the level  
            int amount = (rnd.Next(1, 12- currentET.Level)) ;
            //I think this is too many... 
            
            

            List<EnemyType> enemies = new List<EnemyType>();
            for (int i = 0; i < amount; i++)
            {
                EnemyType e = new EnemyType
                {

                    Id = currentET.Id,
                    CreatureType = currentET.CreatureType,
                    IntroText = currentET.IntroText,
                    Accuracy = currentET.Accuracy,
                    Speed = currentET.Speed,
                    Strength = currentET.Strength,
                    Armor = currentET.Armor,
                    Spell_Power = currentET.Spell_Power,
                    Magic_Resistance = currentET.Magic_Resistance,
                    HP = currentET.HP,
                    Mana = currentET.Mana,
                    Level = currentET.Level,
                    Abilities = currentET.Abilities
                };
                //I think this should create actual copies of the value types and 
                //not just pointers... we'll see...

                e.Abilities.Add(gs.uow.Abilities.SingleOrDefault(x => x.Name == "Basic Attack"));

                enemies.Add(e);
            }

            return enemies;

        }
    }
}
