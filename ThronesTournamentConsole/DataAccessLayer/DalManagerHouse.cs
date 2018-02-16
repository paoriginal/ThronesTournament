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

            dss.ExecRequest("INSERT INTO House VALUES(" + ((House)e).id + ", '" + ((House)e).name + "', " + ((House)e).nbUnits + ");");

            foreach (int id in ((House)e).housers)
                dss.ExecRequest("UPDATE Charac SET idHouse = " + ((House)e).id + " WHERE id = " + id + ";");    //que se passe-t-il si le personnage n'existe pas dans la table ?
            //on suppose que les persos sont déjà sets ?

        }

        public override void update(EntityObject e)
        {
            iDal dss = DalSqlServer.getInstance();

            dss.ExecRequest("UPDATE House SET name = " + ((House)e).name            + " WHERE id = " + ((House)e).id + ";");
            dss.ExecRequest("UPDATE House SET nbUnits = "  + ((House)e).nbUnits             + " WHERE id = " + ((House)e).id + ";");
        }

        public override List<int> getIds()
        {
            List<int> houses = new List<int>();
            iDal dss = DalSqlServer.getInstance();
            List<string> ids = dss.ExecSelectRequest("SELECT Id FROM House;");
            int charIntId;

            foreach (string charId in ids)
            {
                int.TryParse(charId, out charIntId);
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
            bool isNotNull = true;


            
            temp = dss.ExecSelectRequest("SELECT * FROM House;");

            Console.WriteLine("temp     " + temp[0]+ "   id  " + id);

            houseList = dss.ExecSelectRequest("SELECT * FROM House WHERE Id = " + id + ";")[0].Split(',');

            Console.WriteLine("house" + houseList);

            houserList = dss.ExecSelectRequest("SELECT * FROM Charac WHERE idHouse = " + id + ";");
            isNotNull = int.TryParse(houseList[2], out nbUnits);
            if (!isNotNull) nbUnits = -1;


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
            //supprimer les affiliations ?
        }

        public static DalManagerHouse getInstance ()
        {
            if (INSTANCE == null)
                INSTANCE = new DalManagerHouse();

            return INSTANCE;
        }
    }
}
