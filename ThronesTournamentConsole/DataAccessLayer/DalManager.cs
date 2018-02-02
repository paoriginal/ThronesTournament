using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public abstract class DalManager
    {
        public abstract void insert(EntityObject c);
        public abstract void update(EntityObject c);
        public abstract List<int> getIds();
        public abstract List<EntityObject> getEntities();
        public abstract EntityObject getEntity(int id);
        public abstract void remove(int id);
    }
}
