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

            Item chosentype = allitems[randchoice];

            Item newI = new Item
            {
                Name = chosentype.Name,
                Description = chosentype.Description,
                Active = chosentype.Active,
                IsArchetype = false,

                HP_Bonus = chosentype.HP_Bonus,
                Mana_Bonus = chosentype.Mana_Bonus,
                Magic_Resistance_Bonus = chosentype.Magic_Resistance_Bonus,
                Armor_Bonus = chosentype.Armor_Bonus,
                Spell_Power_Bonus = chosentype.Spell_Power_Bonus,
                Strength_Bonus = chosentype.Strength_Bonus,
                Speed_Bonus = chosentype.Speed_Bonus,
                Accuracy_Bonus = chosentype.Accuracy_Bonus,

            };

            return newI;
        }

    }
}
