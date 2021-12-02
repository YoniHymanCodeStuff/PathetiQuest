using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject.Model
{
    [Table("Enemy Types")]
    public class EnemyType : Unit
    {
        [MaxLength(50)]
        public string CreatureType { get; set; }
        [MaxLength(1000)]
        public string IntroText { get; set; }

        //will probably want to add a ctor here with all the bloody fields... 

        public EnemyType(string ctype, string introtext, double accuracy, double armor, double magicRes, double spellp, double strength, double speed, double hp, double mana, int level, List<Ability> abilities) :
        base(accuracy, armor, magicRes, spellp, strength, speed, hp, mana, level, abilities)
        {
            CreatureType = ctype;
            IntroText = introtext;

        }

        public EnemyType()
        {

        }
    }
}
