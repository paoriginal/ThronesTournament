using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Fight : EntityObject
    {
        public int challenger1 { get; set; }
        public int challenger2 { get; set; }
        public int winningHouse { get; set; }

        public Fight(int challenger1, int challenger2, int winningHouse)
        {
            this.challenger1 = challenger1;
            this.challenger2 = challenger2;
            this.winningHouse = winningHouse;
        }
        public Fight(int id, int challenger1, int challenger2, int winningHouse)
        {
            this.id = id;
            this.challenger1 = challenger1;
            this.challenger2 = challenger2;
            this.winningHouse = winningHouse;
        }
    }
}
