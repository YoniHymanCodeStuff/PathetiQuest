using ProjectTempUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject.Model
{
    [Table("Heroes")]
    public class Hero : HeroType
    {
        [ForeignKey("Player")]
        public Player player { get; set; }

        [MaxLength(50)]
        public string ProperName { get; set; }
        public double CurrentExp { get; set; }

        public double BaseHP { get; set; }
        public double BaseMana { get; set; }

        public virtual ICollection<Item> EquippedItem { get; set; } = new List<Item>();


        //this horrific ctor makes me think there is probably a more elegant way to do this... 
        public Hero(Player player, string properName, double currentExp, ICollection<Item> inventory,
            string className, double accuracy, double armor, double magicRes, double spellp, double strength, double speed, double hp, double mana, int level, List<Ability> abilities)
            :base(className,accuracy, armor, magicRes, spellp, strength, speed, hp, mana, level, abilities)
        {
            this.player = player;
            ProperName = properName;
            CurrentExp = currentExp;
            EquippedItem = inventory;
        
        }

        public Hero()
        {

        }

        public override string ToString()
        {
            return ProperName;
        }

        //public object Clone()
        //{

        //    Hero other = new Hero();

        //    foreach (PropertyInfo prop in this.GetType().GetProperties())
        //    {

        //        other.GetType().GetProperties().Where(x => x.Name == prop.Name).FirstOrDefault().SetValue(this,other);

        //    }

        //    return other;
        //}
    }
}
