using API.Models;
using DataAccessLayer;
using EntitiesLayer;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class TerritoryController : ApiController
    {
        public List<TerritoryDTO> getEntities()
        {
            List<TerritoryDTO> territories = new List<TerritoryDTO>();

            foreach (Territory t in BusinessManager.getInstance().territories)
                territories.Add(new TerritoryDTO(t));

            return territories;
        }

        /*
        public TerritoryDTO getEntity(int id)
        {
            return new TerritoryDTO((Territory)DalManagerTerritory.getInstance().getEntity(id));
        }*/
        
    }
}
