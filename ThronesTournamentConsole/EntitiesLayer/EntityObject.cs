namespace EntitiesLayer
{
    public abstract class EntityObject
    {

        private int nbObjects=0;
        //auto-incrémentation
        public int id { get; set; }

        public EntityObject ()
        {
            id = nbObjects++;
        }
    }
}
