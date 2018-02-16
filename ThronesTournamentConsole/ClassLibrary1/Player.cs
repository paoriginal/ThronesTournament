using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Player
    {
        static int counter = 0;
        int id;
        public string name;
        public int house;

        public Player(string name, int house)
        {
            id = counter++;
            this.name = name;
            this.house = house;
        }
    }
}
