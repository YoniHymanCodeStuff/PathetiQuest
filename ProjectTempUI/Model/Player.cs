using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject.Model
{
    public class Player : IhaveID
    {
        [Required]
        public bool IsMod { get; set; }
        public int Id { get; set; }
        
        //should probably make this string inherently unique :
        [MaxLength(50), Required] 
        public string UserName { get; set; }
        public bool FinishedSetup { get; set; }

        [MaxLength(50), Required]
        protected virtual string PasswordStored
        {
            get;
            set;
        }


        //[NotMapped] - need to add some witchcraft here so 
        //only the encrypted one will appear in db. now the encryption
        //is doing a lot of nothing. 
        public string Password
        {
            get { return Decrypt(PasswordStored); }
            set { PasswordStored = Encrypt(value); }
        }
        public virtual ICollection<Hero> Heroes { get; set; } = new List<Hero>();
        public virtual ICollection<Item> InventoryItem { get; set; } = new List<Item>();
        //items can be equipped to a hero, or just in storage

        public virtual ICollection<Hero_Name> Names_Used { get; set; } = new List<Hero_Name>();



        private static string Encrypt(string s)
        {
            //should add encryption code here...
            return s;
        }

        private static string Decrypt(string s)
        {
            return s;
        }

        public override string ToString()
        {
            return UserName;
        }
    }
}
