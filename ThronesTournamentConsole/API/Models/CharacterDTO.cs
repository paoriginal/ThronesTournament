using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class CharacterDTO
    {
        public int id { get; set; }
        public string firstName { get; set; }

        public string lastName { get; set; }

        public Statistics stats { get; set; }

        public CharacterDTO() { }

        public CharacterDTO(Character c)
        {
            id = c.id;
            firstName = c.firstName;
            lastName = c.lastName;
            stats = c.statistics;
        }

    }
}