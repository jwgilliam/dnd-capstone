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

using Capstone.Models.ViewModels;

namespace Capstone.Controllers
{
    public class EncounterController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public EncounterController(ApplicationDbContext context, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }
        // GET: Encounter
        public async  Task<ActionResult> Index()
        {
            
            var user = await getcurrentuserasync();
            var encounters = await _context.Encounter.Where(e => user.Id == e.ApplicationUserId)
                .Include(e => e.CharacterEncounters)
                .ThenInclude(ce => ce.Character)
                .Include(e => e.MonsterEncounters)
                .ThenInclude(ce => ce.Monster)
                .ToListAsync();
            
            
            return View(encounters);
        }

        // GET: Encounter/Details/5
        public async Task<ActionResult> Details(int id)
        {
            
                
            return View();
        }

        // GET: Encounter/Create
        public async Task<ActionResult> Create()
        {
            var viewModel = new EncounterViewModel();
            var characterOptions = await _context.Character.Select(ch => new SelectListItem()
            {
                Text = ch.CharacterName,
                Value = ch.Id.ToString()
            }).ToListAsync();
            var monsterOptions = await _context.Monster.Select(m => new SelectListItem()
            {
                Text = m.Name,
                Value = m.Id.ToString()
            }).ToListAsync();

            viewModel.CharacterOptions = characterOptions;
            viewModel.MonsterOptions = monsterOptions;
            return View(viewModel);
        }

        // POST: Encounter/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EncounterViewModel encounterView)
        {
            try
            {
                var user = await getcurrentuserasync();
                var encounter = new Encounter

                {
                    Name = encounterView.Encounter.Name,
                    Description = encounterView.Encounter.Description,
                    Location = encounterView.Encounter.Location,
                    MonsterId = encounterView.MonsterId,
                    CharacterId = encounterView.CharacterId

                };
                _context.Add(encounter);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Encounter/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Encounter/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Encounter/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Encounter/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

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