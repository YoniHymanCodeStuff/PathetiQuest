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
        
        //this does 2 things: helps order them to set up player choice, 
        //and helps differentiate between children and parents
        //(there is probably a better way to do that, but this was easy and right there...)... 
        public int classIndex { get; set; } 
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
