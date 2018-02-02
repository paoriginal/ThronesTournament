using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class CharacterDTO
    {
        public string Nom { get; set; }

        public string Prenom { get; set; }

        public int Pv { get; set; }

        public CharacterDTO()
        {
        }

        public CharacterDTO(string nom, string prenom, int pv)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Pv = pv;
        }
    }
}