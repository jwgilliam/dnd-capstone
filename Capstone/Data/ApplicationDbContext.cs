using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Capstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<Monster> Monster { get; set; }
        public DbSet<Encounter> Encounter { get; set; }
        public DbSet<CharacterEncounter> CharacterEncounter { get; set; }
        public DbSet<MonsterEncounter> MonsterEncounter { get; set; }
        




    }

}