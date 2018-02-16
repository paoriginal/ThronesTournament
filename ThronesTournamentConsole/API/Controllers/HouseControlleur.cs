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
    public class HouseController : ApiController
    {
        public List<HouseDTO> getEntities()
        {
            List<HouseDTO> houses = new List<HouseDTO>();

            foreach (House h in DalManagerHouse.getInstance().getEntities())
                houses.Add(new HouseDTO(h));

            return houses;
        }

        public HouseDTO getEntity(int id)
        {
            return new HouseDTO((House)DalManagerHouse.getInstance().getEntity(id));
        }
        
        public void insert(HouseDTO h)
        {
            DalManagerHouse.getInstance().insert(new House(h.id, h.housers, h.name, h.nbUnits));
        }
    }
}
