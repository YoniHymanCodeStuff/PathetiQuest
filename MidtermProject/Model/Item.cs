using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject.Model
{
    public class Item : IhaveID
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }

        public ICollection<Hero> Owning_Hero { get; set; } = new List<Hero>();

        [Required]
        public bool Active { get; set; } 
        public double Accuracy_Bonus { get; set; }
        public double Speed_Bonus { get; set; }
        public double Strength_Bonus { get; set; }
        public double Spell_Power_Bonus { get; set; }
        public double Armor_Bonus { get; set; }
        public double Magic_Resistance_Bonus { get; set; }
        public double HP_Bonus { get; set; }
        public double Mana_Bonus { get; set; }
        
    }
}
