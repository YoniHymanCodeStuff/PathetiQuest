using Microsoft.EntityFrameworkCore;
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
    public class HeroRepository : Repository<Hero>, IHeroRepository
    {


        public HeroRepository(DBC context) : base(context)
        {
        }


        public DBC GameContext
        {
            get { return Context as DBC; }
        }

        public Hero EagerloadHero(int id)
        {
            return GameContext.Heroes
               .Where(x => x.Id == id)
               .Include(x => x.EquippedItem)
               .Include(x=>x.Abilities)
               .FirstOrDefault();
        }

        public List<Hero> EagerLoadHeroes(Player pl)
        {
            return GameContext.Heroes
              .Where(x => x.player == pl)
              .Include(x => x.EquippedItem)
              .Include(x => x.Abilities)
              .ToList();
        }
    }
}
