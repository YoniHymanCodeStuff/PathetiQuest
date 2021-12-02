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
    public class IntroTextRepository : Repository<Encounter_Intro_Text>, IIntroTextRepository
    {


        public IntroTextRepository(DBC context) : base(context)
        {
        }


        public DBC GameContext
        {
            get { return Context as DBC; }
        }

        public String GetRandomText()
        {
            Random rnd = new Random();

            List<String> options =
               GameContext.Intro_Texts
               .Select(x=>x.Letext)
               .ToList();

            int randchoice = rnd.Next(options.Count());

            return options[randchoice];
        }

    }
}
