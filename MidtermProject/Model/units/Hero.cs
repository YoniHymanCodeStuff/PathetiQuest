using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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

        public ICollection<Item> InventoryItem { get; set; } = new List<Item>();


        //this horrific ctor makes me think there is probably a more elegant way to do this... 
        public Hero(Player player, string properName, double currentExp, ICollection<Item> inventory,
            string className, double accuracy, double armor, double magicRes, double spellp, double strength, double speed, double hp, double mana, int level, List<Ability> abilities)
            :base(className,accuracy, armor, magicRes, spellp, strength, speed, hp, mana, level, abilities)
        {
            this.player = player;
            ProperName = properName;
            CurrentExp = currentExp;
            InventoryItem = inventory;
        
        }

        public Hero()
        {

        }
    }
}
