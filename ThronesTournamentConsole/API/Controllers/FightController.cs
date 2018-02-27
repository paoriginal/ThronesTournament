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
        

        public void  getDataFromClient (string jsonString)
        {
            BusinessManager bm = BusinessManager.getInstance();
            var json = new JavaScriptSerializer().Deserialize<jsonGlobalObject>(jsonString);  //parse la string pour construire un object jsonObject

            foreach(jsonObject j in json.listObject)
            {
                bm.fight(j.IdHouseAttack, j.IdHeroAttack, j.NbUniteAttack, j.IdHouseDefense, j.listIdHeroDefense[0], j.NbUniteDefense);
                
                //foreach(int id in )
            }
                
            //METTRE a jour les objets non dto du business manager en faisant la simu  -> méthode update dans BusinessManager + appel de fight


            //remettre à jour les objets dto dans les autres méthodes

        }

    }
}
