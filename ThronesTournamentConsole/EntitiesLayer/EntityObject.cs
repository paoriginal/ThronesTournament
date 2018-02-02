namespace EntitiesLayer
{
    public abstract class EntityObject
    {

        private static int nbObjects=0;
        //auto-incrémentation
        public int id { get; set; }

        public EntityObject () {  id = nbObjects++; }

        public static void resetNbObject() { nbObjects = 0; }
    }
}
