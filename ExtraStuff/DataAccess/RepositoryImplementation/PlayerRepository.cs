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
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {


        public PlayerRepository(DBC context) : base(context)
        {
        }


        public DBC GameContext
        {
            get { return Context as DBC; }
        }

#nullable enable
        public Player? GetPlayerByName(string name)
        {


            //if (GameContext.Players.Any(e => e.UserName == name))
            //{
            //    return GameContext.Players.Single(e => e.UserName == name);

            //}

            return null;

        }
#nullable disable

    }
}
