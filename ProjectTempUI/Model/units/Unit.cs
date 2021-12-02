using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject.Model
{
    public abstract class Unit : IhaveID
    {
        public int Id { get; set; }

        public virtual ICollection<Ability> Abilities { get; set; }

        //stats: I should really limit these with data annotation and 
        //maybe change them to smaller types. very inneficient. 

        public double Accuracy { get; set; }
        public double Speed { get; set; }
        public double Strength { get; set; }
        public double Spell_Power { get; set; }
        public double Armor { get; set; }
        public double Magic_Resistance { get; set; }
        public double HP { get; set; }
        public double Mana { get; set; }
        public int Level { get; set; }
        

        public Unit(double accuracy, double armor, double magicRes, double spellp,
            double strength, double speed, double hp, double mana, int level, List<Ability> abilities)
        {
            
            Accuracy = accuracy;
            Armor = armor;
            Magic_Resistance = magicRes;
            Spell_Power = spellp;
            Strength = strength;
            Speed = speed;
            HP = hp;
            Mana = mana;
            Level = level;
            Abilities = abilities;
        }

        public Unit()
        {

        }

    }
}
