using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Encounter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
       public List<CharacterEncounter> CharacterEncounters { get; set; }
       public List<MonsterEncounter> MonsterEncounters { get; set; }
        
    }
}
