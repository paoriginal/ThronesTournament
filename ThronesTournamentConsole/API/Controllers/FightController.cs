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
            List<int> listIdHeroDefense;
            List<int> listIdHeroSoins;
            int IdHouseAttack;
            int IdHouseDefense;
            int NbUniteAtack;
            int IdHeroAttack;
            int NbUniteDefense;

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

            var jsonObject = new JavaScriptSerializer().Deserialize<jsonObject>(jsonString);  //parse la string pour construire un object jsonObject



            //METTRE a jour les objets non dto du business manager en faisant la simu  -> méthode update dans BusinessManager + appel de fight


            //remettre à jour les objets dto dans les autres méthodes

        }

    }
}
