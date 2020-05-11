using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Views.ViewModels
{
    public class EncounterViewModel
    {
        public int Id { get; set; }
        public Character Character { get; set; }
        public List<Character> Characters { get; set; }
        public Monster Monster { get; set; }
        public List<Monster> Monsters { get; set; }
        public ApplicationUser ApplicationUser {get; set;}
    }
}
