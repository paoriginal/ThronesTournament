using System;
using System.Collections.Generic;
using BusinessLayer;
using DataAccessLayer;
using EntitiesLayer;

namespace ThronesTournamentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*

            BusinessManager bm = new BusinessManager();
            DalManagerCharacter.getInstance().remove(0);
            DalManagerCharacter.getInstance().remove(1);
            bm.createCharacter("Jon", "Snow", 30, 20, 10);
            bm.createCharacter("Jon2", "Snow2", 30, 20, 10);

            bm.updateCharacters();
            foreach (Character c in DalManagerCharacter.getInstance().getEntities())
                Console.WriteLine(c.id + " " + c.firstName + " " + c.lastName + " " + c.statistics.hp + " " + c.statistics.bravoury + " " + c.statistics.crazyness);




            //
            DalManagerHouse.getInstance().remove(2);
            DalManagerHouse.getInstance().remove(3);

            bm.createHouse("Stark", 100);
            Console.WriteLine("count   " + bm.houses.Count + "   id " + bm.houses[0].id);
            bm.updateHouses();
            foreach (House h in DalManagerHouse.getInstance().getEntities())
                Console.WriteLine(h.id + " " + h.name + " " + h.nbUnits);
            Console.ReadLine();


            */



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
