using MidtermProject.EF;
using MidtermProject.Model;
using ProjectTempUI.EF.DataAccess.Repositories;
using ProjectTempUI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectTempUI.EF.DataAccess.RepositoryImplementation
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {


        public ItemRepository(DBC context) : base(context)
        {
        }


        public DBC GameContext
        {
            get { return Context as DBC; }
        }

        public Item GetRandomNewItem()
        {
            Random rnd = new Random();

            //Get all entries that are in range from 1 above and below level
            List<Item> allitems =
               GameContext.Items
              .Where(x => (x.IsArchetype == true))
              
              .ToList();

            int randchoice = rnd.Next(allitems.Count());

            Item chosentype =  allitems[randchoice];

            Item newI = new Item {
                Name = chosentype.Name,
                Description = chosentype.Description,
                HP_Bonus = chosentype.HP_Bonus,
                Active = chosentype.Active,
                IsArchetype = false
            };

            return newI;
        }

    }
}
