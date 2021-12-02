using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject.Model
{
    public class Ability : IhaveID
    {

        public int Id { get; set; }
        [MaxLength(50),Required]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }

        //this can allow me to refer generically to the ability 
        //with code generated text:
        [MaxLength(200)]
        public string verb { get; set;}

        public ICollection<Unit> unit_with_ability { get; set; } = new List<Unit>();
        [Required]
        public bool AOE { get; set; }//if != than is single target
        [Required]
        public bool TargetEnemies { get; set; }//if != than target allies
        [Required]
        public bool IsPhysical { get; set; }//else is magical type
        public double Alter_Accuracy { get; set; }
        public double Alter_Speed { get; set; }
        public double Alter_Strength { get; set; }
        public double Alter_Spell_Power { get; set; }
        public double Alter_Armor { get; set; }
        public double Alter_Magic_Resistance { get; set; }
        public double Alter_HP { get; set; }
        public double Alter_Mana { get; set; }

        public double DamageDealt { get; set; }
        public double Manacost { get; set; }

        //protected Ability()
        //{

        //}

        public override string ToString()
        {
            return Name;
        }

    }
}
