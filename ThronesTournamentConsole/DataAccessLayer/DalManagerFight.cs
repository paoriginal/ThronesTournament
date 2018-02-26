using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DalManagerFight : DalManager
    {
        private static DalManagerFight INSTANCE = null;

        private DalManagerFight() { }
        
        public override void insert(EntityObject e)
        {
            ((iDal) DalSqlServer.getInstance()).ExecRequest("INSERT INTO Fight VALUES(" + e.id + ", '" + ((Fight)e).challenger1 + "', '" + ((Fight)e).challenger2 + "', NULL);");
        }

        public override void update(EntityObject e)
        {
            iDal dss = DalSqlServer.getInstance();

            dss.ExecRequest("UPDATE Fight SET id1 = "      + ((Fight)e).challenger1  + " WHERE id = " + e.id + ";");
            dss.ExecRequest("UPDATE Fight SET id2 = "      + ((Fight)e).challenger2  + " WHERE id = " + e.id + ";");
            dss.ExecRequest("UPDATE Fight SET idWinner = " + ((Fight)e).winningHouse + " WHERE id = " + e.id + ";");
        }

        public override List<int> getIds()
        {
            List<int> fights = new List<int>();
            int fightIntId;

            foreach (string fightId in ((iDal) DalSqlServer.getInstance()).ExecSelectRequest("SELECT Id FROM Fight;"))
            {
                int.TryParse(fightId, out fightIntId);
                fights.Add(fightIntId);
            }

            return fights;
        }


        public override EntityObject getEntity(int id)
        {
            string[] fightList;
            int idHouse1, idHouse2, idWinningHouse;
            bool isNotNull;
            
            fightList = ((iDal) DalSqlServer.getInstance()).ExecSelectRequest("SELECT * FROM Fight WHERE Id = " + id + ";")[0].Split(',');
            int.TryParse(fightList[1], out idHouse1);
            int.TryParse(fightList[2], out idHouse2);
            isNotNull = int.TryParse(fightList[3], out idWinningHouse);
            
            return new Fight(id, idHouse1, idHouse2, isNotNull ? idWinningHouse : -1);
        }
        
        public override void remove(int id)
        {
            ((iDal) DalSqlServer.getInstance()).ExecRequest("DELETE FROM Fight WHERE Id = " + id + ";");
        }

        public static DalManagerFight getInstance ()
        {
            if (INSTANCE == null)
                INSTANCE = new DalManagerFight();

            return INSTANCE;
        }
    }
}
