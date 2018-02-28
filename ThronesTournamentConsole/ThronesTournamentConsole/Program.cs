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


            Console.WriteLine("ThronesTournamentConsole");
            /*
            for (int i = 1; i<13; i++)
                DalManagerCharacter.getInstance().remove(i);
            for (int i = 1; i < 17; i++)
                DalManagerHouse.getInstance().remove(i);


            initiateDataBase();*/

            //BusinessManager bm = BusinessManager.getInstance();
            Console.WriteLine("Charac id");

            List<int> idList2 = DalManagerCharacter.getInstance().getIds();

            foreach (int id in idList2)
                Console.WriteLine(id);

            Console.WriteLine("House Id");

            List<int> idList3 = DalManagerHouse.getInstance().getIds();

            foreach (int id in idList3)
                Console.WriteLine(id);

            Console.WriteLine("Charac");

            List<EntityObject> charac = DalManagerCharacter.getInstance().getEntities();

            foreach (Character c in charac)
                Console.WriteLine(c.id + " " + c.firstName + " " + c.lastName + " " + c.statistics.hp + " " + c.statistics.bravoury + " " + c.statistics.crazyness);

            Console.WriteLine("Charac");

            List<EntityObject> house = DalManagerHouse.getInstance().getEntities();

            foreach (House h in house)
                Console.WriteLine(h.id + " " + h.name + " " + h.nbUnits);

            Console.WriteLine("ThronesTournamentConsole");

            Console.ReadLine();

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

        public static void initiateDataBase()
        {
            DalManagerCharacter dalCharac = DalManagerCharacter.getInstance();
            DalManagerHouse dalHouse = DalManagerHouse.getInstance();

            DalManagerCharacter.getInstance().empty();
            DalManagerFight.getInstance().empty();
            DalManagerHouse.getInstance().empty();
            DalManagerTerritory.getInstance().empty();
            DalManagerWar.getInstance().empty();


            Console.WriteLine("Table Vide");

            //Stark
            dalCharac.insert(new Character(1, new Statistics(50, 30, 5), "Jon", "Snow"));
            dalCharac.insert(new Character(2, new Statistics(30, 30, 10), "Arya", "Stark"));
            dalCharac.insert(new Character(3, new Statistics(15, 20, 15), "Bran", "Stark"));

            //Targaryen
            dalCharac.insert(new Character(4, new Statistics(30, 30, 5), "Daenerys", "Targaryen"));
            dalCharac.insert(new Character(5, new Statistics(50, 30, 5), "Ver", "Gris"));
            dalCharac.insert(new Character(6, new Statistics(50, 30, 5), "Jon", "Snow"));

            //Lannister
            dalCharac.insert(new Character(7, new Statistics(50, 30, 5), "Jamie", "Lannister"));
            dalCharac.insert(new Character(8, new Statistics(30, 15, 25), "Cersei", "Lannister"));
            dalCharac.insert(new Character(9, new Statistics(70, 30, 30), "Gregor", "Clegane"));

            //Greyjoy
            dalCharac.insert(new Character(10, new Statistics(30, 5, 5), "Theon", "Greyjoy"));
            dalCharac.insert(new Character(11, new Statistics(40, 30, 5), "Yara", "Greyjoy"));
            dalCharac.insert(new Character(12, new Statistics(30, 15, 25), "Euron", "Greyjoy"));

            //DalHouse.insert(new House(new List<int>(), name, nbUnits))
            dalHouse.insert(new House(13, new List<int> { 1, 2, 3 }, "Stark", 30000));
            dalHouse.insert(new House(14, new List<int> { 4, 5, 6 }, "Targaryen", 100000));
            dalHouse.insert(new House(15, new List<int> { 7, 8, 9 }, "Lannister", 80000));
            dalHouse.insert(new House(16, new List<int> { 10, 11, 12 }, "Greyjoy", 30000));
        }
    }
}
