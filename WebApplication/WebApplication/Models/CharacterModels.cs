namespace WebApplication.Models
{
    public class CharacterModels
    {
        private int idCharacter;

        public int IdCharacter
        {
            get { return idCharacter; }
            set { idCharacter = value; }
        }

        private string nom;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private string prenom;

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        private Type profil;

        public Type Profil
        {
            get { return profil; }
            set { profil = value; }
        }

    }
}