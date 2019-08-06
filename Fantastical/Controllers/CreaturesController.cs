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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Fantastical.Controllers
{
    public class CreaturesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment hostingEnvironment;
        private object buttonSearch;


        public object AcceptButton { get; private set; }

        public CreaturesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHostingEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Creatures
        public async Task<IActionResult> Index()
        {
            var currentUser = await GetCurrentUserAsync();
            var applicationDbContext = _context.Creature.Include(c => c.Name).Include(c => c.Region).Include(c => c.User);
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

        // GET My Creatures
        public async Task<IActionResult> MyCreaturesIndex()
        {
            var currentUser = await GetCurrentUserAsync();

            var myCreatures = _context.Creature.Include(c => c.User).Where(c => c.UserId == currentUser.Id);

            return View(await myCreatures.ToListAsync());
            
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
        public async Task<IActionResult> Create([Bind("Id,Name,Lore,Region,Image,ImagePath")] Creature creature)
        {
            ModelState.Remove("User");
            ModelState.Remove("UserId");

            if (ModelState.IsValid)
            {
                string photoFileName = null;

                if (creature.Image != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    photoFileName = Guid.NewGuid().ToString() + "_" + creature.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, photoFileName);
                    creature.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                
                var currentUser = await GetCurrentUserAsync();
                creature.UserId = currentUser.Id;
                creature.ImagePath = photoFileName;
                _context.Add(creature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(creature);
        }

        // GET: Creatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (_userManager.GetUserAsync(User).Result.isAdmin)
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


                return View(creature);
            }
            else
            {
                var creature = await _context.Creature.FindAsync(id);
                var currentUser = await GetCurrentUserAsync();
                if (currentUser.Id != creature.UserId)
                {
                    return NotFound();
                }

                return View(creature);
            }
        }

        // POST: Creatures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Lore,Region,Image,ImagePath")] Creature creature)
        {
            if (id != creature.Id)
            {
                return NotFound();
            }
                ModelState.Remove("UserId");
                ModelState.Remove("User");
                var currentUser = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {

                try
                {

                    string photoFileName = null;

                    if (creature.Image != null)
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                        photoFileName = Guid.NewGuid().ToString() + "_" + creature.Image.FileName;
                        string filePath = Path.Combine(uploadsFolder, photoFileName);
                        creature.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                        creature.ImagePath = photoFileName;
                    }

                    
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
            if (_userManager.GetUserAsync(User).Result.isAdmin)
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
            else
            {
                return NotFound();
            }
        }

        // POST: Creatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SoftDeleteConfirmed(int id)
        {
            var creature = await _context.Creature.FindAsync(id);
            try
            {
                _context.Creature.Remove(creature);
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateException)
            {
                _context.Update(creature);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool CreatureExists(int id)
        {
            return _context.Creature.Any(e => e.Id == id);
        }
    }
}
