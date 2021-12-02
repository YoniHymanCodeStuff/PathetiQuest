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
    public class EnemyRepository : Repository<EnemyType>, IEnemyRepository
    {


        public EnemyRepository(DBC context) : base(context)
        {
        }


        public DBC GameContext
        {
            get { return Context as DBC; }
        }

        public EnemyType EagerloadRandomEnemyType(int level)
        {

            Random rnd = new Random();

            //Get all entries that are in range from 1 above and below level
            List<EnemyType> options = 
               GameContext.enemyTypes
              .Where(x => (x.Level > level-2 && x.Level < level + 2))
              .Include(x => x.Abilities)
              .ToList();

            int randchoice = rnd.Next(options.Count());

            return options[randchoice];

        }
    }
}
