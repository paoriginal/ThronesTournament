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
    [RoutePrefix("api/war")]
    public class WarController : ApiController
    {
        [Route("{getEntities}")]
        public List<WarDTO> getEntities()
        {
            List<WarDTO> wars = new List<WarDTO>();

            foreach (War w in BusinessManager.getInstance().wars)
                wars.Add(new WarDTO(w));

            return wars;
        }

        /*
        public WarDTO getEntity(int id)
        {
            return new WarDTO((War)DalManagerWar.getInstance().getEntity(id));
        }
        */
    }
}
