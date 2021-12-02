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
    public class HeroTypeRepository : Repository<HeroType>, IHeroTypeRepository
    {


        public HeroTypeRepository(DBC context) : base(context)
        {
        }


        public DBC GameContext
        {
            get { return Context as DBC; }
        }

        public HeroType EagerloadHeroType(string classname)
        {
            return GameContext.HeroTypes
               .Where(x => (x.ClassName == classname) && (x.classIndex > -1))
               .Include(x => x.Abilities)
               .FirstOrDefault();
        }
        public List<HeroType> GetOrderedHeroClasses()
        {
            
            //the classindex property helps with consistent order,
            //and filters out the children "Hero" enitities

            List<HeroType> retval =  
                GameContext.HeroTypes                
              .Where(x => x.classIndex>-1)
              .OrderBy(x => x.classIndex)
              .ToList();

            return retval;
        }
    }
}
