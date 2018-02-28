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
using System.Web.Http.Cors;
using Newtonsoft.Json;

namespace API.Controllers
{
    [RoutePrefix("api/fight")]
    public class FightController : ApiController
    {

        class jsonObject
        {
            public List<int> ListIdHeroDefense { get; set; }
            public List<int> ListIdHeroSoins { get; set; }
            public int IdHouseAttack { get; set; }
            public int IdHouseDefense { get; set; }
            public int NbUniteAttack { get; set; }
            public int IdHeroAttack { get; set; }
            public int NbUniteDefense { get; set; }

            public jsonObject(List<int> ListIdHeroDefense, List<int> ListHeroSoins, int IdHouseAttack, int IdHouseDefense, int NbUniteAttack, int IdHeroAttack, int NbUniteDefense)
            {
                this.ListIdHeroDefense = new List<int>();
                this.ListIdHeroSoins = new List<int>();
                this.ListIdHeroDefense = ListIdHeroDefense;
                this.ListIdHeroSoins = ListHeroSoins;
                this.IdHouseAttack = IdHouseAttack;
                this.IdHouseDefense = IdHouseDefense;
                this.NbUniteAttack = NbUniteAttack;
                this.IdHeroAttack = IdHeroAttack;
                this.NbUniteDefense = NbUniteDefense;
            }
        }

        //class jsonGlobalObject
        //{
        //    public List<jsonObject> listObject { get; set; }
        //}

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


        [Route("{getDataFromClient}"), HttpPost, HttpOptions, HttpGet]
        public void getDataFromClient([FromBody]dynamic jsonString)
        {
            BusinessManager bm = BusinessManager.getInstance();
            List<int> idHouses = new List<int>();

            List<jsonObject> json = JsonConvert.DeserializeObject<IEnumerable<jsonObject>>(jsonString); //parse la string pour construire un object jsonObject

            foreach(jsonObject j in json)
            {
                bm.fight(j.IdHouseAttack, j.IdHeroAttack, j.NbUniteAttack, j.IdHouseDefense, j.ListIdHeroDefense[0], j.NbUniteDefense);
                
                foreach(int id in j.ListIdHeroSoins)
                {
                    bm.regenCharac(id);
                }
            }

            foreach(jsonObject j in json)
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
