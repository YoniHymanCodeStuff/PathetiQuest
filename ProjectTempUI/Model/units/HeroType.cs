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
        //these are hero archetypes. all heroes created have their base
        //stats copied from their respective hero "class", which is just
        ///1 row in this table. 

        [MaxLength(50)]
        public string ClassName { get; set; }
        
        //this does 2 things: helps order them to set up player choice, 
        //and helps differentiate between children and parents
        //(there is probably a better way to do that, but this was easy and right there...)... 
        public int classIndex { get; set; } 

        public HeroType()
        {

        }


    }
}
