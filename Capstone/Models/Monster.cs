using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Monster
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int HitPoints { get; set; }
        public int ArmorClass { get; set; }
        public int SpeedWalk { get; set; }
        public int SpeedSwim { get; set; }
        public int SpeedFly { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public string SavingThrows { get; set; }
        public int ChallengeRating { get; set; }
        public List<MonsterEncounter> MonsterEncounters { get; set; }

    }
}
