using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DalManagerCharacter : DalManager
    {
        private static DalManagerCharacter INSTANCE = null;

        private DalManagerCharacter() { }
        
        public override void insert(EntityObject e)
        {
            iDal dss = new DalSqlServer();

            dss.ExecRequest("INSERT INTO Charac VALUES(" + ((Character)e).id + ", '" + ((Character)e).firstName + "', '" + ((Character)e).lastName + "', NULL);");
            dss.ExecRequest("INSERT INTO Stats VALUES("  + ((Character)e).id + ", " + ((Character)e).statistics.hp + ", " + ((Character)e).statistics.bravoury + ", " + ((Character)e).statistics.crazyness + ");");
            foreach (KeyValuePair<int, Relationship> relation in ((Character)e).relationships)
                dss.ExecRequest("INSERT INTO Relation VALUES(" + ((Character)e).id + ", " + relation.Key + ", " + relation.Value + ");");
        }

        public override void update(EntityObject e)
        {
            iDal dss = new DalSqlServer();

            dss.ExecRequest("UPDATE Charac SET firstName = " + ((Character)e).firstName            + " WHERE id = " + ((Character)e).id + ";");
            dss.ExecRequest("UPDATE Charac SET lastName = "  + ((Character)e).lastName             + " WHERE id = " + ((Character)e).id + ";");
            dss.ExecRequest("UPDATE Stats SET hp = "         + ((Character)e).statistics.hp        + " WHERE id = " + ((Character)e).id + ";");
            dss.ExecRequest("UPDATE Stats SET bravoury = "   + ((Character)e).statistics.bravoury  + " WHERE id = " + ((Character)e).id + ";");
            dss.ExecRequest("UPDATE Stats SET crazyness = "  + ((Character)e).statistics.crazyness + " WHERE id = " + ((Character)e).id + ";");

            dss.ExecRequest("DELETE FROM Relation WHERE Id1 = " + ((Character)e).id + ";");
            foreach (KeyValuePair<int, Relationship> relation in ((Character)e).relationships)
                dss.ExecRequest("INSERT INTO Relation VALUES(" + ((Character)e).id + ", " + relation.Key + ", " + relation.Value + ");");

        }

        public override List<int> getIds()
        {
            List<int> characters = new List<int>();
            iDal dss = new DalSqlServer();
            List<string> ids = dss.ExecSelectRequest("SELECT Id FROM Charac;");
            int charIntId;

            foreach (string charId in ids)
            {
                int.TryParse(charId, out charIntId);
                characters.Add(charIntId);
            }

            return characters;
        }
        
        public override List<EntityObject> getEntities()
        {
            List<EntityObject> characters = new List<EntityObject>();
            iDal dss = new DalSqlServer();
            List<string> ids = dss.ExecSelectRequest("SELECT Id FROM Charac;");
            int charIntId;
            
            foreach (string charId in ids)
            {
                int.TryParse(charId, out charIntId);
                characters.Add(getEntity(charIntId));
            }
            
            return characters;
        }
        
        public override EntityObject getEntity(int id)
        {
            iDal dss = new DalSqlServer();
            Character charac;
            string[] characList, statsList, relationList;
            int hp, bravoury, crazyness, idChar, relationType;
            bool isNotNull = true;
            
            characList = dss.ExecSelectRequest("SELECT * FROM Charac WHERE Id = " + id + ";")[0].Split(',');
            statsList = dss.ExecSelectRequest("SELECT * FROM Stats WHERE Id = " + id + ";")[0].Split(',');
            isNotNull = int.TryParse(statsList[1], out hp);
            if (isNotNull) isNotNull = int.TryParse(statsList[2], out bravoury);
            else bravoury = -1;
            if (isNotNull) isNotNull = int.TryParse(statsList[3], out crazyness);
            else crazyness = -1;

            charac = new Character(id, isNotNull ? new Statistics(hp, bravoury, crazyness) : new Statistics(), characList[1], characList[2]);

            foreach (string relation in dss.ExecSelectRequest("SELECT * FROM Relation WHERE Id1 = " + id + ";"))
            {
                relationList = relation.Split(',');
                int.TryParse(relationList[1], out idChar);
                int.TryParse(relationList[2], out relationType);
                charac.addRelatives(idChar, (Relationship)relationType);
            }

            return charac;
        }
        
        public override void remove(int id)
        {
            iDal dss = new DalSqlServer();

            dss.ExecRequest("DELETE FROM Charac WHERE Id = " + id + ";");
            dss.ExecRequest("DELETE FROM Stats WHERE Id = " + id + ";");
            dss.ExecRequest("DELETE FROM Relation WHERE Id1 = " + id + " OR Id2 = " + id + ";");
        }

        public static DalManagerCharacter getInstance ()
        {
            if (INSTANCE == null)
                INSTANCE = new DalManagerCharacter();

            return INSTANCE;
        }
    }
}
