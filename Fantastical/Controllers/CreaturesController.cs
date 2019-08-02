using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fantastical.Data;
using Fantastical.Models;
using Microsoft.AspNetCore.Identity;

namespace Fantastical.Controllers
{
    public class CreaturesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private object buttonSearch;

        public object AcceptButton { get; private set; }

        public CreaturesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Creatures
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Creature.Include(c => c.Name).Include(c => c.Region);
            return View(await _context.Creature.ToListAsync());
        }

        public async Task<IActionResult> Search(string searchCreatures)
        {
            var creatureSearch = from c in _context.Creature
                                 select c;

            if(!String.IsNullOrEmpty(searchCreatures))
            {
                creatureSearch = creatureSearch.Where(s => s.Name.Contains(searchCreatures));
            }

            this.AcceptButton = this.buttonSearch;

            return View(await creatureSearch.ToListAsync());
        }

        // GET: Creatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creature = await _context.Creature
                .FirstOrDefaultAsync(m => m.Id == id);
            if (creature == null)
            {
                return NotFound();
            }

            return View(creature);
        }

        // GET: Creatures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Creatures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Lore,Region,ImagePath")] Creature creature)
        {
            ModelState.Remove("User");
            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                var currentUser = await GetCurrentUserAsync();
                creature.UserId = currentUser.Id;
                _context.Add(creature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(creature);
        }

        // GET: Creatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creature = await _context.Creature.FindAsync(id);
            if (creature == null)
            {
                return NotFound();
            }

            var currentUser = await GetCurrentUserAsync();
            if (currentUser.Id != creature.UserId)
            {
                return NotFound();
            }

            return View(creature);
        }

        // POST: Creatures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Lore,Region,ImagePath")] Creature creature)
        {
            if (id != creature.Id)
            {
                return NotFound();
            }

            ModelState.Remove("UserId");
            ModelState.Remove("User");

            if (ModelState.IsValid)
            {
                try
                {
                    var currentUser = await GetCurrentUserAsync();
                    creature.User = currentUser;
                    creature.UserId = currentUser.Id;

                    _context.Update(creature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreatureExists(creature.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(creature);
        }

        // GET: Creatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creature = await _context.Creature
                .FirstOrDefaultAsync(m => m.Id == id);
            if (creature == null)
            {
                return NotFound();
            }

            return View(creature);
        }

        // POST: Creatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creature = await _context.Creature.FindAsync(id);
            _context.Creature.Remove(creature);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreatureExists(int id)
        {
            return _context.Creature.Any(e => e.Id == id);
        }
    }
}
