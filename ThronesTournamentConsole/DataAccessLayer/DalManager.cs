using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DalManager
    {
        private static DalManager INSTANCE = null;

        private DalManager() { }

        public void insertCharacter(Character c)
        {
            iDal dss = new DalSqlServer();

            dss.ExecRequest("INSERT INTO Charac VALUES(" + c.id + ", '" + c.firstName + "', '" + c.lastName + "', NULL);");
            dss.ExecRequest("INSERT INTO Stats VALUES("  + c.id + ", " + c.statistics.hp + ", " + c.statistics.bravoury + ", " + c.statistics.crazyness + ");");
        }

        public void updateCharacter(Character c)
        {
            iDal dss = new DalSqlServer();

            dss.ExecRequest("UPDATE Charac SET firstName = " + c.firstName            + " WHERE id = " + c.id + ";");
            dss.ExecRequest("UPDATE Charac SET lastName = "  + c.lastName             + " WHERE id = " + c.id + ";");
            dss.ExecRequest("UPDATE Stats SET hp = "         + c.statistics.hp        + " WHERE id = " + c.id + ";");
            dss.ExecRequest("UPDATE Stats SET bravoury = "   + c.statistics.bravoury  + " WHERE id = " + c.id + ";");
            dss.ExecRequest("UPDATE Stats SET crazyness = "  + c.statistics.crazyness + " WHERE id = " + c.id + ";");
        }

        public List<Character> getCharacters()
        {

            List<Character> results = new List<Character>();
            iDal dss = new DalSqlServer();
            List<string> resultsCharac = dss.ExecSelectRequest("SELECT * FROM Charac;");
            List<string> resultsStats  = dss.ExecSelectRequest("SELECT * FROM Stats;");
            /*
            for(int i=0; i < resultsCharac.Capacity; i++)
            {

            }*/



            return null;
        }
        public Character getCharacter() { return null; }

        public static DalManager getInstance ()
        {
            if (INSTANCE == null)
                INSTANCE = new DalManager();

            return INSTANCE;
        }
    }
}
