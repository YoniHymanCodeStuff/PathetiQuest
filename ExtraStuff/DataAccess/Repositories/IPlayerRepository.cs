using MidtermProject.Model;
using ProjectTempUI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTempUI.EF.DataAccess.Repositories
{
    interface IPlayerRepository : IRepository<Player>
    {
#nullable enable
        public Player? GetPlayerByName(string name);
#nullable disable
    }
}
