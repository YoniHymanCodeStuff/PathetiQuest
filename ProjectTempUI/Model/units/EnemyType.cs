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
        //these are enemy types. the actual enemies are created before the
        //battle and just use these as cookie cutters that they copy the 
        //data from. but the entities here are just the enemy archetypes. 

        [MaxLength(50)]
        public string CreatureType { get; set; }
        [MaxLength(1000)]
        public string IntroText { get; set; }

       
        public EnemyType()
        {

        }

        public override string ToString()
        {
            return CreatureType;
        }
    }
}
