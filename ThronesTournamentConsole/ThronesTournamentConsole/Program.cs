using System;
using BusinessLayer;
using DataAccessLayer;

namespace ThronesTournamentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessManager bm = new BusinessManager();
            //bm.createCharacter("Jon", "Snow", 3, 2, 1);
            //bm.updateCharacters();
            DalManager.getInstance().getCharacters();
            Console.ReadLine();
            /*
            while (true)
            {
                Console.WriteLine("1. Afficher les Maisons");
                Console.WriteLine("2. Afficher les Personnages");
                Console.WriteLine("3. Afficher les Territoires");
                choix = Console.ReadLine();
                
                switch (choix)
                {
                    case "1": foreach (string house in ttm.getHouses()) Console.WriteLine(house); break;
                    case "2": foreach (string house in ttm.getCharacters()) Console.WriteLine(house); break;
                    case "3": foreach (string house in ttm.getTerritories()) Console.WriteLine(house); break;
                    default: return;
                }
            }*/
        }
    }
}
