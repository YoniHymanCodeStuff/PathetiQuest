using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject.Model
{
    public class Hero_Name : IhaveID
    {
        //this table is basically just a list of names to generate for 
        //the heroes.
        //It is linked many to many with players so I can tell who used it
        //and not offer them the same name twice. 

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>();

        public Hero_Name(string name)
        {
            Name = name;
        }
        public Hero_Name()
        {
            
        }

    }
}
