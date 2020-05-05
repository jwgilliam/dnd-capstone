using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class MonsterEncounter
    {
        public int Id { get; set; }
        public Monster Monster { get; set; }
        public int MonsterId { get; set; }
        public Encounter Encounter { get; set; }
        public int EncounterId { get; set; }
    }
}
