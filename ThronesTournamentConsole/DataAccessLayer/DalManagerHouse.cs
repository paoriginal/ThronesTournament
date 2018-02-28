using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DalManagerHouse : DalManager
    {
        private static DalManagerHouse INSTANCE = null;

        private DalManagerHouse() { }
        
        public override void insert(EntityObject e)
        {
            iDal dss = DalSqlServer.getInstance();

            dss.ExecRequest("INSERT INTO House VALUES(" + e.id + ", '" + ((House)e).name + "', " + ((House)e).nbUnits + ");");

            foreach (int id in ((House)e).housers)
                dss.ExecRequest("UPDATE Charac SET idHouse = " + e.id + " WHERE id = " + id + ";");

        }

        public override void update(EntityObject e)
        {
            iDal dss = DalSqlServer.getInstance();

            dss.ExecRequest("UPDATE House SET name = "     + ((House)e).name               + " WHERE id = " + e.id + ";");
            dss.ExecRequest("UPDATE House SET nbUnits = "  + ((House)e).nbUnits            + " WHERE id = " + e.id + ";");
        }

        public override List<int> getIds()
        {
            List<int> houses = new List<int>();
            iDal dss = DalSqlServer.getInstance();
            List<string> ids = dss.ExecSelectRequest("SELECT Id FROM House;");
            int charIntId;

            foreach (string charId in ids)
            {
                String temp = charId.Substring(0, charId.Length - 1);
                int.TryParse(temp, out charIntId);
                houses.Add(charIntId);
            }

            return houses;
        }
        
        public override EntityObject getEntity(int id)
        {
            iDal dss = DalSqlServer.getInstance();
            House house;
            string[] houseList;
            List<String> houserList, temp;
            int nbUnits, idHouser;
            
            temp = dss.ExecSelectRequest("SELECT * FROM House;");

            houseList = dss.ExecSelectRequest("SELECT * FROM House WHERE Id = " + id + ";")[0].Split(',');
            houserList = dss.ExecSelectRequest("SELECT * FROM Charac WHERE idHouse = " + id + ";");
            if (!int.TryParse(houseList[2], out nbUnits)) nbUnits = -1;
            
            house = new House(new List<int>(), houseList[1], nbUnits);

            foreach (string houser in houserList)
            {
                int.TryParse(houseList[2], out idHouser);
                house.addHousers(idHouser);
            }

            return house;
        }
        
        public override void remove(int id)
        {
            iDal dss = DalSqlServer.getInstance();

            dss.ExecRequest("DELETE FROM House WHERE Id = " + id + ";");
        }

        public static DalManagerHouse getInstance ()
        {
            if (INSTANCE == null)
                INSTANCE = new DalManagerHouse();

            return INSTANCE;
        }
    }
}
