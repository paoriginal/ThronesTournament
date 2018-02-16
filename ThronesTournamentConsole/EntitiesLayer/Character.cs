using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Character : EntityObject
    {
        public Statistics statistics { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Dictionary<int, Relationship> relationships { get; set; }

        public void addRelatives(int id, Relationship relationship)
        {
            this.relationships.Add(id, relationship);
        }
        public Character(Statistics stats, string firstName, string lastName /*addRelatives*/)
        {
            statistics = stats;
            this.firstName = firstName;
            this.lastName = lastName;
            relationships = new Dictionary<int, Relationship>();
        }
        public Character(int id, Statistics stats, string firstName, string lastName /*addRelatives*/)
        {
            this.id = id;
            statistics = stats;
            this.firstName = firstName;
            this.lastName = lastName;
            relationships = new Dictionary<int, Relationship>();
        }

        public double getValue()
        {
            return (statistics.bravoury * 7 - statistics.crazyness * 3) * (statistics.hp / statistics.hpMax);
        }

        public override string ToString() { return null; }

        public double getRelationValue(Character characD)
        {
            if (!relationships.Keys.Contains(characD.id)) return 50;
            switch (relationships[characD.id])
            {
                case Relationship.LOVE       : return 0;
                case Relationship.FRIENDSHIP : return 25;
                case Relationship.RIVALRY    : return 75;
                case Relationship.HATRED     : return 100;
                default                      : return 50;
            }
        }
    }

    public class Statistics
    {
        public int hp { get; set; }
        public int hpMax { get; set; }
        public int bravoury { get; set; }
        public int crazyness { get; set; }

        public Statistics() { }

        public Statistics(int hp, int bravoury, int crazyness)
        {
            this.hp = hp;
            this.hpMax = hp;
            this.bravoury = bravoury;
            this.crazyness = crazyness;
        }
    }

    public enum Relationship { FRIENDSHIP, LOVE, HATRED, RIVALRY }

    public enum CharacterType { WARRIOR, WITCH, TACTICIAN, LEADER, LOSER }
}
