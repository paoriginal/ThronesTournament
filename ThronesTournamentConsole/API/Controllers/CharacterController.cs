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
    public class CharacterController : ApiController
    {
        public List<CharacterDTO> getEntities()
        {
            List<CharacterDTO> characters = new List<CharacterDTO>();

            foreach (Character c in DalManagerCharacter.getInstance().getEntities())
                characters.Add(new CharacterDTO(c));

            return characters;
        }

        public CharacterDTO getEntity(int id)
        {
            return new CharacterDTO((Character)DalManagerCharacter.getInstance().getEntity(id));
        }
        
        public void insert(CharacterDTO c)
        {
            DalManagerCharacter.getInstance().insert(new Character(c.id, c.stats, c.firstName, c.lastName));
        }
    }
}
