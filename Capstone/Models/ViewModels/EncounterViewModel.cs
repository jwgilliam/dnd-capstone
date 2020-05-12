using Capstone.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models.ViewModels
{
    public class EncounterViewModel
    {
        public int Id { get; set; }
        public Character Character { get; set; }
        public Encounter Encounter { get; set; }
        public List<Character> Characters { get; set; }
        public Monster Monster { get; set; }
        public List<Monster> Monsters { get; set; }
        public ApplicationUser ApplicationUser {get; set;}
        public List<int> MonsterIds { get; set; }
        public int MonsterId { get; set; }
        public List<int> CharacterIds { get; set; }
        public int CharacterId { get; set; }
        public List<SelectListItem> MonsterOptions { get; set; }
        public List<SelectListItem> CharacterOptions { get; set; }
    }
}
