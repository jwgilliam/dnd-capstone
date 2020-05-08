using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string CharacterName { get; set; }
        public string PlayerName { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }
        public int Level { get; set; }
        public double Experience { get; set; }
        public int MaxHp { get; set; }
        public int CurrentHp { get; set; }
        public string HitDice { get; set; }
        public int ArmorClass { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int ProficiencyBounus { get; set; }
        public string Spells { get; set; }
        public string Inventory { get; set; }
        public string Proficiencies { get; set; }
        public int Speed { get; set; }
        public string SavingThrows { get; set; }
        public string Skills { get; set; }
        public List<CharacterEncounter> CharacterEncounters { get; set; }






    }
}
