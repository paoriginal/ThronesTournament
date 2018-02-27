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
using System.Web.Script;
using System.Web.Script.Serialization;


namespace API.Controllers
{
    [RoutePrefix("api/fight")]
    public class FightController : ApiController
    {

        class jsonObject
        {
            public List<int> listIdHeroDefense { get; set; }
            public List<int> listIdHeroSoins { get; set; }
            public int IdHouseAttack { get; set; }
            public int IdHouseDefense { get; set; }
            public int NbUniteAttack { get; set; }
            public int IdHeroAttack { get; set; }
            public int NbUniteDefense { get; set; }

        }

        class jsonGlobalObject
        {
            public List<jsonObject> listObject { get; set; }
        }

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


        [Route("{getDataFromClient}")]
        public void  getDataFromClient (string jsonString)
        {
            BusinessManager bm = BusinessManager.getInstance();
            List<int> idHouses = new List<int>();
            var json = new JavaScriptSerializer().Deserialize<jsonGlobalObject>(jsonString);  //parse la string pour construire un object jsonObject

            foreach(jsonObject j in json.listObject)
            {
                bm.fight(j.IdHouseAttack, j.IdHeroAttack, j.NbUniteAttack, j.IdHouseDefense, j.listIdHeroDefense[0], j.NbUniteDefense);
                
                foreach(int id in j.listIdHeroSoins)
                {
                    bm.regenCharac(id);
                }
            }

            foreach(jsonObject j in json.listObject)
            {
                if (!idHouses.Contains(j.IdHouseAttack))
                    idHouses.Add(j.IdHouseAttack);

                if (!idHouses.Contains(j.IdHouseDefense))
                    idHouses.Add(j.IdHouseDefense);
            }

            foreach(int id in idHouses)
            {
                bm.regenUnits(id);
            }

        }

    }
}
