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
            iDal dss = DalSqlServer.getInstance();

            dss.ExecRequest("INSERT INTO Charac VALUES(" + e.id + ", '" + ((Character)e).firstName + "', '" + ((Character)e).lastName + "', NULL);");
            dss.ExecRequest("INSERT INTO Stats VALUES(" + e.id + ", " + ((Character)e).statistics.hpMax + ", " + ((Character)e).statistics.bravoury + ", " + ((Character)e).statistics.crazyness + ");");
            foreach (KeyValuePair<int, Relationship> relation in ((Character)e).relationships)
                dss.ExecRequest("INSERT INTO Relation VALUES(" + e.id + ", " + relation.Key + ", " + relation.Value + ");");
        }

        public override void update(EntityObject e)
        {
            iDal dss = DalSqlServer.getInstance();

            dss.ExecRequest("UPDATE Charac SET firstName = " + ((Character)e).firstName + " WHERE id = " + e.id + ";");
            dss.ExecRequest("UPDATE Charac SET lastName = " + ((Character)e).lastName + " WHERE id = " + e.id + ";");
            dss.ExecRequest("UPDATE Stats SET hp = " + ((Character)e).statistics.hpMax + " WHERE id = " + e.id + ";");
            dss.ExecRequest("UPDATE Stats SET bravoury = " + ((Character)e).statistics.bravoury + " WHERE id = " + e.id + ";");
            dss.ExecRequest("UPDATE Stats SET crazyness = " + ((Character)e).statistics.crazyness + " WHERE id = " + e.id + ";");

            dss.ExecRequest("DELETE FROM Relation WHERE Id1 = " + e.id + ";");
            foreach (KeyValuePair<int, Relationship> relation in ((Character)e).relationships)
                dss.ExecRequest("INSERT INTO Relation VALUES(" + e.id + ", " + relation.Key + ", " + relation.Value + ");");

        }

        public override List<int> getIds()
        {
            List<int> characters = new List<int>();
            int charIntId;

            foreach (string charId in ((iDal)DalSqlServer.getInstance()).ExecSelectRequest("SELECT Id FROM Charac;"))
            {
                String temp = charId.Substring(0, charId.Length - 1);
                int.TryParse(temp, out charIntId);
                characters.Add(charIntId);
            }

            return characters;
        }

        public override EntityObject getEntity(int id)
        {
            iDal dss = DalSqlServer.getInstance();
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
            iDal dss = DalSqlServer.getInstance();

            dss.ExecRequest("DELETE FROM Charac WHERE Id = " + id + ";");
            dss.ExecRequest("DELETE FROM Stats WHERE Id = " + id + ";");
            dss.ExecRequest("DELETE FROM Relation WHERE Id1 = " + id + " OR Id2 = " + id + ";");
        }

        public static DalManagerCharacter getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new DalManagerCharacter();

            return INSTANCE;
        }
    }
}