using ProjectTempUI.EF.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTempUI.EF.DataAccess
{
    interface IUnitOfWork : IDisposable
    {

        IAbilityRepository Abilities { get; }
        IEnemyRepository Enemies { get; }
        IHeroRepository Heroes { get; }
        IHeroTypeRepository HeroClasses { get; }
        IHeroNameRepository HeroNames { get; }
        IIntroTextRepository IntroTexts { get; }
        IItemRepository Items { get; }
        IPlayerRepository Players { get; }
        

        int Complete();

        public void LazyCreateDB();
    }
}
