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
using Fantastical.Models.ViewModel;

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
            var applicationDbContext = _context.Creature.Include(c => c.Name).Include(c => c.Lore).Include(c => c.Region).Include(c => c.ImagePath).Include(c => c.User);
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
            CreatureCreateViewModel viewModel = new CreatureCreateViewModel();
            return View(viewModel);
        }

        // POST: Creatures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatureCreateViewModel viewModel)
        {
            ModelState.Remove("User");
            ModelState.Remove("UserId");

            var creature = viewModel.Creature;

            if (ModelState.IsValid)
            {
                
                    string photoFileName = null;

                    if (viewModel.Image != null)
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                        photoFileName = Guid.NewGuid().ToString() + "_" + viewModel.Image.FileName;
                        string filePath = Path.Combine(uploadsFolder, photoFileName);
                        viewModel.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                    }

                

                    var currentUser = await GetCurrentUserAsync();
                    creature.UserId = currentUser.Id;
                    creature.ImagePath = photoFileName;
                    _context.Add(creature);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                
            }

            return View(viewModel);
        }

        // GET: Creatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (_userManager.GetUserAsync(User).Result.isAdmin)
            {

                var currentUser = await GetCurrentUserAsync();

                if (id == null)
                {
                    return NotFound();
                }

                var creature = await _context.Creature.FindAsync(id);

                CreatureEditViewModel viewModel = new CreatureEditViewModel
                {
                    Creature = creature
                };

                if (creature == null)
                {
                    return NotFound();
                }


                return View(viewModel);
            }
            else
            {
                var creature = await _context.Creature.FindAsync(id);
                var currentUser = await GetCurrentUserAsync();
                if (currentUser.Id != creature.UserId)
                {
                    return NotFound();
                }
                CreatureEditViewModel viewModel = new CreatureEditViewModel
                {
                    Creature = creature
                };

                return View(viewModel);
            }
        }

        // POST: Creatures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreatureEditViewModel viewModel)
        {
            if (id != viewModel.Creature.Id)
            {
                return NotFound();
            }

                var currentUser = await GetCurrentUserAsync();
                ModelState.Remove("Creature.UserId");
                ModelState.Remove("Creature.User");
                ModelState.Remove("Creature.Image");

            var creature = viewModel.Creature;


            if (ModelState.IsValid)
            {

                try
                {
                    var creatureFromDatabase = await _context.Creature.FindAsync(id);

                    string photoFileName = null;

                    if (viewModel.Image != null)
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                        photoFileName = Guid.NewGuid().ToString() + "_" + viewModel.Image.FileName;
                        string filePath = Path.Combine(uploadsFolder, photoFileName);
                        viewModel.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                        creature.ImagePath = photoFileName;
                    }


                    creatureFromDatabase.Name = creature.Name;
                    creatureFromDatabase.Lore = creature.Lore;
                    creatureFromDatabase.Region = creature.Region;
                    creatureFromDatabase.ImagePath = creature.ImagePath;

                    //creatureFromDatabase.UserId = viewModel.Creature.UserId;
                    //creatureFromDatabase.User = viewModel.Creature.User;

                    _context.Update(creatureFromDatabase);
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

            return View(viewModel);
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
