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
    public class MonsterController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public MonsterController(ApplicationDbContext context, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }

        // get: monsters
        public async Task<ActionResult> Index()
        {
            var user = await getcurrentuserasync();
            var monsters = await _context.Monster
                .Where(mo => mo.ApplicationUserId == user.Id)
                .ToListAsync();
            return View(monsters);
        }

        // get: monster/details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // get: monster/create
        public ActionResult Create()
        {
            return View();
        }

        // post: monster/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Monster monster)
        {
            try
            {
                var user = await getcurrentuserasync();

                var monsterinstance = new Monster
                {
                    Name = monster.Name,
                    HitPoints = monster.HitPoints,
                    ArmorClass = monster.ArmorClass,
                    SpeedWalk = monster.SpeedWalk,
                    SpeedFly = monster.SpeedFly,
                    SpeedSwim = monster.SpeedSwim,
                    Strength = monster.Strength,
                    Dexterity = monster.Dexterity,
                    Constitution = monster.Constitution,
                    Intelligence = monster.Intelligence,
                    Wisdom = monster.Wisdom,
                    Charisma = monster.Charisma,
                    SavingThrows = monster.SavingThrows,
                    ChallengeRating = monster.ChallengeRating
                };

                monsterinstance.ApplicationUserId = user.Id;


                _context.Monster.Add(monsterinstance);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // get: monster/edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // post: monster/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // todo: add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // get: monster/delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var monster = await _context.Monster.FirstOrDefaultAsync(mo => mo.Id == id);

            var loggedinuser = await getcurrentuserasync();

            if (monster.ApplicationUserId != loggedinuser.Id)
            {
                return NotFound();
            }

            return View(monster);
        }

        // post: monster/delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Monster monster)
        {
            try
            {

                _context.Monster.Remove(monster);
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