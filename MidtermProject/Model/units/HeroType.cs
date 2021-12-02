using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject.Model
{
    [Table("Hero Types")]
    public class HeroType : Unit
    {
        [MaxLength(50)]
        public string ClassName { get; set; }

        public HeroType(string className, double accuracy, double armor, double magicRes, double spellp, double strength, double speed, double hp, double mana, int level, List<Ability> abilities):
            base(accuracy,armor,magicRes,spellp,strength,speed,hp,mana,level,abilities)
        {
            ClassName = className;

        }

        public HeroType()
        {

        }


    }
}
