using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject.Model
{
    public class Encounter_Intro_Text : IhaveID
    {
        //this stuff is just to add variety to the game text. 
        // just a list of text options. not linked to any other tables. 

        public int Id { get; set; }
        [MaxLength(1000)]
        string text { get; set; }
    }
}
