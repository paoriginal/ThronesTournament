using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DalManagerWar : DalManager
    {
        private static DalManagerWar INSTANCE = null;

        private DalManagerWar() { }

        public override void insert(EntityObject e) { ((iDal) DalSqlServer.getInstance()).ExecRequest("INSERT INTO War VALUES(" + e.id + ");"); }

        public override void update(EntityObject e) { }

        public override List<int> getIds()
        {
            List<int> wars = new List<int>();
            int warIntId;

            foreach (string warId in ((iDal) DalSqlServer.getInstance()).ExecSelectRequest("SELECT Id FROM Charac;"))
            {
                int.TryParse(warId, out warIntId);
                wars.Add(warIntId);
            }

            return wars;
        }
        
        public override EntityObject getEntity(int id) { return new War(id); }
        
        public override void remove(int id) { ((iDal) DalSqlServer.getInstance()).ExecRequest("DELETE FROM War WHERE Id = " + id + ";"); }

        public static DalManagerWar getInstance ()
        {
            if (INSTANCE == null)
                INSTANCE = new DalManagerWar();

            return INSTANCE;
        }
    }
}
