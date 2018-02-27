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
    [RoutePrefix("api/house")]
    public class HouseController : ApiController
    {
        [Route("{getEntities}")]
        public List<HouseDTO> getEntities()
        {
            List<HouseDTO> houses = new List<HouseDTO>();

            foreach (House h in BusinessManager.getInstance().houses)
                houses.Add(new HouseDTO(h));

            return houses;
        }

        [Route("{getEntity}")]
        public HouseDTO getEntity(int id)
        {
            return new HouseDTO((House)BusinessManager.getInstance().getHouse(id));
        }
        
    }
}
