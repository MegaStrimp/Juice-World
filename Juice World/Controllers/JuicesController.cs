using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Juice_World.Data;
using Juice_World.Models;

namespace Juice_World.Controllers
{
    public class JuicesController : Controller
    {
        private readonly Juice_WorldContext _context;

        public JuicesController(Juice_WorldContext context)
        {
            _context = context;
        }

        // GET: Juices
        public async Task<IActionResult> Index(string juiceType, string searchString)
        {
            if (_context.Juice == null)
            {
                return Problem("Entity set 'Juice_WorldContext.Juice' is null.");
            }

            // Use LINQ to get list of types.
            IQueryable<string> typeQuery = from m in _context.Juice
                                            orderby m.Type
                                            select m.Type;
            var juices = from m in _context.Juice
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                juices = juices.Where(s => s.Title!.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!string.IsNullOrEmpty(juiceType))
            {
                juices = juices.Where(x => x.Type == juiceType);
            }

            var juiceTypeVM = new JuiceTypeViewModel
            {
                Types = new SelectList(await typeQuery.Distinct().ToListAsync()),
                Juices = await juices.ToListAsync(),
                JuicesReverse = await juices.ToListAsync()
            };

            return View(juiceTypeVM);
        }

        // GET: Juices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juice = await _context.Juice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (juice == null)
            {
                return NotFound();
            }

            return View(juice);
        }

        // GET: Juices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Juices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ReleaseDate,Type,Price,ImageUrl")] Juice juice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(juice);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(juice);
        }

        // GET: Juices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juice = await _context.Juice.FindAsync(id);
            if (juice == null)
            {
                return NotFound();
            }
            return View(juice);
        }

        // POST: Juices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ReleaseDate,Type,Price,ImageUrl")] Juice juice)
        {
            if (id != juice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(juice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JuiceExists(juice.Id))
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
            return View(juice);
        }

        // GET: Juices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var juice = await _context.Juice.FirstOrDefaultAsync(m => m.Id == id);

            if (juice == null)
            {
                return NotFound();
            }

            return View(juice);
        }

        // POST: Juices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var juice = await _context.Juice.FindAsync(id);
            if (juice != null)
            {
				System.IO.File.Delete("wwwroot/images/items/" + juice.ImageUrl);
				_context.Juice.Remove(juice);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JuiceExists(int id)
        {
            return _context.Juice.Any(e => e.Id == id);
        }
    }
}