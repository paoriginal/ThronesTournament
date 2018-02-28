using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DalManagerTerritory : DalManager
    {
        private static DalManagerTerritory INSTANCE = null;

        private DalManagerTerritory() { }
        
        public override void insert(EntityObject e) {  ((iDal) DalSqlServer.getInstance()).ExecRequest("INSERT INTO Territory VALUES(" + e.id + ", '" + ((Territory)e).territoryType + "', '" + ((Territory)e).owner + ");"); }

        public override void update(EntityObject e)
        {
            iDal dss = DalSqlServer.getInstance();

            dss.ExecRequest("UPDATE Territory SET territoryType = " + ((Territory)e).territoryType + " WHERE id = " + e.id + ";");
            dss.ExecRequest("UPDATE Territory SET idOwner = "       + ((Territory)e).owner         + " WHERE id = " + e.id + ";");
        }

        public override List<int> getIds()
        {
            List<int> characters = new List<int>();
            int charIntId;

            foreach (string charId in ((iDal)DalSqlServer.getInstance()).ExecSelectRequest("SELECT Id FROM Territory;"))
            {
                int.TryParse(charId.Split(',')[0], out charIntId);
                characters.Add(charIntId);
            }

            return characters;
        }
        
        public override EntityObject getEntity(int id)
        {
            string[] terriList;
            int tt, owner;
            bool isNotNull = true;
            
            terriList = ((iDal) DalSqlServer.getInstance()).ExecSelectRequest("SELECT * FROM Territory WHERE Id = " + id + ";")[0].Split(',');
            isNotNull = int.TryParse(terriList[1], out tt);
            if (isNotNull) isNotNull = int.TryParse(terriList[2], out owner);
            else owner = -1;
            
            return new Territory(id, (TerritoryType)(isNotNull ? tt : -1), owner);
        }

        public override void remove(int id) { ((iDal)DalSqlServer.getInstance()).ExecRequest("DELETE FROM Territory WHERE Id = " + id + ";"); }

        public static DalManagerTerritory getInstance ()
        {
            if (INSTANCE == null)
                INSTANCE = new DalManagerTerritory();

            return INSTANCE;
        }
    }
}
