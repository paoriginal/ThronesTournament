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
    public class WarController : ApiController
    {
        public List<WarDTO> getEntities()
        {
            List<WarDTO> wars = new List<WarDTO>();

            foreach (War w in DalManagerWar.getInstance().getEntities())
                wars.Add(new WarDTO(w));

            return wars;
        }

        public WarDTO getEntity(int id)
        {
            return new WarDTO((War)DalManagerWar.getInstance().getEntity(id));
        }
        
        public void insert(WarDTO c)
        {
            DalManagerWar.getInstance().insert(new War(w.id));
        }
    }
}
