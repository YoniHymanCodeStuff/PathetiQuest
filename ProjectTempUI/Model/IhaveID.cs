using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject.Model
{
    public interface IhaveID
    {
        public int Id { get; set; }

        //this interface will be a generic constraint to allow
        //me to have generic crud operations that can pull id. 


        //pretty sure I wont be needing this anymore... 
    }
}
