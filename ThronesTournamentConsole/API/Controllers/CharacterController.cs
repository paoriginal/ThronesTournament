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
    public class CharacterController : ApiController
    {
        public List<CharacterDTO> getEntities()
        {
            List<CharacterDTO> characters = new List<CharacterDTO>();

            foreach (Character c in BusinessManager.getInstance().characters)
                characters.Add(new CharacterDTO(c));

            return characters;
        }

        public CharacterDTO getEntity(int id)
        {
            return new CharacterDTO((Character)BusinessManager.getInstance().getCharac(id));
        }

        /*
        public void putEntity(string jsonString)
        {
            //foreach characterDTO
            BusinessManager.getInstance.
        }*/
        
    }
}
