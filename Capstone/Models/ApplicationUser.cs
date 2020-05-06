using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ApplicationUser : IdentityUser
    {
     public List<Character>  Characters { get; set; }
     public List<Monster> Monsters { get; set; }

     public List<Encounter> Encounters { get; set; }
       
      
    }
}
