using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Unsalted.Models;

namespace Unsalted
{
    public class AllergiesController : Controller
    {
        private readonly ReviewContext _context;

        public AllergiesController(ReviewContext context)
        {
            _context = context;
        }

        // GET: Allergies
        [AllowAnonymous]
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            //return View(await _context.Allergy.ToListAsync());
            ViewData["CurrentSort"] = sortOrder;
            ViewData["IDSortParm"] = sortOrder == "ID" ? "ID_desc" : "ID";
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "allergen_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var allergies = from a in _context.Allergy select a;

            if (!String.IsNullOrEmpty(searchString))
            {
                allergies = allergies.Where(s => s.Allergen.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "ID_desc":
                    allergies = allergies.OrderByDescending(s => s.ID);
                    break;
                case "ID":
                    allergies = allergies.OrderBy(s => s.ID);
                    break;
                case "allergen_desc":
                    allergies = allergies.OrderByDescending(s => s.Allergen);
                    break;
                default:
                    allergies = allergies.OrderBy(s => s.Allergen);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Allergy>.CreateAsync(allergies.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Allergies/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergy = await _context.Allergy
                .FirstOrDefaultAsync(m => m.ID == id);
            if (allergy == null)
            {
                return NotFound();
            }

            return View(allergy);
        }

        // GET: Allergies/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Allergies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Allergen,Examples,Reactions")] Allergy allergy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allergy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allergy);
        }

        // GET: Allergies/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergy = await _context.Allergy.FindAsync(id);
            if (allergy == null)
            {
                return NotFound();
            }
            return View(allergy);
        }

        // POST: Allergies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Allergen,Examples,Reactions")] Allergy allergy)
        {
            if (id != allergy.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allergy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllergyExists(allergy.ID))
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
            return View(allergy);
        }

        // GET: Allergies/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allergy = await _context.Allergy
                .FirstOrDefaultAsync(m => m.ID == id);
            if (allergy == null)
            {
                return NotFound();
            }

            return View(allergy);
        }

        // POST: Allergies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allergy = await _context.Allergy.FindAsync(id);
            _context.Allergy.Remove(allergy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllergyExists(int id)
        {
            return _context.Allergy.Any(e => e.ID == id);
        }
    }
}
