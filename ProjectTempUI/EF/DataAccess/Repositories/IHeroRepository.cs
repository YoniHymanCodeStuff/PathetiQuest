using MidtermProject.Model;
using ProjectTempUI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTempUI.EF.DataAccess.Repositories
{
    interface IHeroRepository : IRepository<Hero>
    {
        public Hero EagerloadHero(int Id);

        public List<Hero> EagerLoadHeroes(Player pl);

        
    }
}
