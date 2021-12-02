﻿using MidtermProject.Model;
using ProjectTempUI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTempUI.EF.DataAccess.Repositories
{
    interface IHeroTypeRepository : IRepository<HeroType>
    {
        public List<HeroType> GetOrderedHeroClasses();
        public HeroType EagerloadHeroType(string classname);
    }
}
