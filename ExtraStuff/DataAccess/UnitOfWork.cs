using MidtermProject.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectTempUI.EF.DataAccess.Repositories;
using ProjectTempUI.EF.DataAccess.RepositoryImplementation;

namespace ProjectTempUI.EF.DataAccess
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly DBC ctx;

        public UnitOfWork()
        {
            //ctx = new DBC();
            Abilities = new AbilityRepository(ctx);
            Enemies = new EnemyRepository(ctx);
            Heroes = new HeroRepository(ctx);
            HeroClasses = new HeroTypeRepository(ctx);
            HeroNames = new HeroNameRepository(ctx);
            IntroTexts = new IntroTextRepository(ctx);
            Items = new ItemRepository(ctx);
            Players = new PlayerRepository(ctx);
            
        }

        public IAbilityRepository Abilities { get; private set; }
        public IEnemyRepository Enemies { get; private set; }
        public IHeroRepository Heroes { get; private set; }
        public IHeroTypeRepository HeroClasses { get; private set; }
        public IHeroNameRepository HeroNames { get; private set; }
        public IIntroTextRepository IntroTexts { get; private set; }
        public IItemRepository Items { get; private set; }
        public IPlayerRepository Players { get; private set; }


        public void Complete()
        {
            ctx.SaveChanges();
            var gs = MidtermProject.GameState.CurrentGameState.GetInstance();
            //gs.uow = new UnitOfWork();

        }

        public void Dispose()
        {
            ctx.Dispose();
        }

    }
}
