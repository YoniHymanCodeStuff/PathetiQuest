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
    public class HeroTypeRepository : Repository<HeroType>, IHeroTypeRepository
    {


        public HeroTypeRepository(DBC context) : base(context)
        {
        }


        public DBC GameContext
        {
            get { return Context as DBC; }
        }


    }
}
