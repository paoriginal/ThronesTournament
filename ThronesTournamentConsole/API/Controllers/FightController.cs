using API.Models;
using DataAccessLayer;
using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class FightController : ApiController
    {
        public List<FightDTO> getEntities()
        {
            List<FightDTO> fights = new List<FightDTO>();

            foreach (Fight f in DalManagerFight.getInstance().getEntities())
                fights.Add(new FightDTO(f));

            return fights;
        }

        public FightDTO getEntity(int id)
        {
            return new FightDTO((Fight)DalManagerFight.getInstance().getEntity(id));
        }
        
        public void insert(FightDTO f)
        {
            DalManagerFight.getInstance().insert(new Fight(f.id, f.challenger1, f.challenger2, f.winningHouse));
        }
    }
}
