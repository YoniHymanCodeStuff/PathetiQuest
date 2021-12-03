
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

        public Hero()
        {

        }

        public override string ToString()
        {
            return ProperName;
        }

    }
}
