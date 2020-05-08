using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices.ComTypes;
using System.IO;

namespace Capstone.controllers
{
    [Authorize]
    public class CharacterController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public CharacterController(ApplicationDbContext context, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }

        // get: characters
        public async Task<ActionResult> Index()
        {
            var user = await getcurrentuserasync();
            var characters = await _context.Character
                .Where(ch => ch.ApplicationUserId == user.Id)
                .ToListAsync();
            return View(characters);
        }

        // get: character/details/5
        public async Task<ActionResult> Details(int id)
        {
            var character = await _context.Character
                .FirstOrDefaultAsync(c => c.Id == id);
            return View(character);
        }

        // get: Character/create
        public ActionResult Create()
        {
            return View();
        }

        // post: character/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Character character)
        {
            try
            {
                var user = await getcurrentuserasync();

                var characterinstance = new Character
                {
                    CharacterName = character.CharacterName,
                    PlayerName = character.PlayerName,
                    Class = character.Class,
                    Race = character.Race,
                    Level = character.Level,
                    Experience = character.Experience,
                    MaxHp = character.MaxHp,
                    CurrentHp = character.CurrentHp,
                    HitDice = character.HitDice,
                    ArmorClass = character.ArmorClass,
                    Strength = character.Strength,
                    Dexterity = character.Dexterity,
                    Constitution = character.Constitution,
                    Intelligence = character.Intelligence,
                    Wisdom = character.Wisdom,
                    Charisma = character.Charisma,
                    ProficiencyBounus = character.ProficiencyBounus,
                    Spells = character.Spells,
                    Inventory = character.Inventory,
                    Proficiencies = character.Proficiencies,
                    Speed = character.Speed,
                    SavingThrows = character.SavingThrows,
                    Skills = character.Skills
                };

                characterinstance.ApplicationUserId = user.Id;


                _context.Character.Add(characterinstance);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // get: character/edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var character = await _context.Character.FindAsync(id);
            return View(character);
        }

        // post: character/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Character character)
        {
            
            try
            {
                var user = await getcurrentuserasync();
                _context.Update(character);
                character.ApplicationUserId = user.Id;
                await _context.SaveChangesAsync();

               
            }
            catch(DbUpdateConcurrencyException)
            {
               
            }
            return RedirectToAction("Index", "Character");
        }

        // get: character/delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var character = await _context.Character.FirstOrDefaultAsync(ch => ch.Id == id);

            var loggedinuser = await getcurrentuserasync();

            if (character.ApplicationUserId != loggedinuser.Id)
            {
                return NotFound();
            }

            return View(character);
        }

        // post: character/delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Character character)
        {
            try
            {

                _context.Character.Remove(character);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private Task<ApplicationUser> getcurrentuserasync() => _usermanager.GetUserAsync(HttpContext.User);
    }
}