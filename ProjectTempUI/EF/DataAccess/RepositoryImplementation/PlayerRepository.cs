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
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {


        public PlayerRepository(DBC context) : base(context)
        {
        }


        public DBC GameContext
        {
            get { return Context as DBC; }
        }


        public Player EagerlyLoadPlayer(int id)
        {
            Player p = 
                            
                GameContext.Players
                .Where(x => x.Id == id)
                .Include(x => x.InventoryItem)
                .FirstOrDefault();

            p.Heroes =

                
                GameContext.Heroes
               .Where(x => x.player == p)
               .Include(x => x.EquippedItem)
               .Include(x => x.Abilities)
               .ToList();

            return p;

        }



        //#nullable enable
        //        public Player? GetPlayerByName(string name)
        //        {


        //            //if (GameContext.Players.Any(e => e.UserName == name))
        //            //{
        //            //    return GameContext.Players.Single(e => e.UserName == name);

        //            //}

        //            return null;

        //        }
        //#nullable disable

    }
}
