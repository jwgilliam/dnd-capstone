using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class CharacterEncounter
    {
        public int Id { get; set; }
        public Character Character { get; set; }
        public int CharacterId { get; set; }
        public Encounter Encounter { get; set; }
        public int EncounterId { get; set; }
    }
}
