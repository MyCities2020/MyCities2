using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCities2.Models;

namespace MyCities2.Controllers
{
    public class DetailsArchitecturesController : Controller
    {
        private readonly MyCitiesDBContext _context;

        public DetailsArchitecturesController(MyCitiesDBContext context)
        {
            _context = context;
        }

        // GET: DetailsArchitectures
        public async Task<IActionResult> Index()
        {
            return View(await _context.DetailsArchitecture.ToListAsync());
        }

        // GET: DetailsArchitectures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailsArchitecture = await _context.DetailsArchitecture
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detailsArchitecture == null)
            {
                return NotFound();
            }

            return View(detailsArchitecture);
        }

        // GET: DetailsArchitectures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DetailsArchitectures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomDetail,Description")] DetailsArchitecture detailsArchitecture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detailsArchitecture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detailsArchitecture);
        }

        // GET: DetailsArchitectures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailsArchitecture = await _context.DetailsArchitecture.FindAsync(id);
            if (detailsArchitecture == null)
            {
                return NotFound();
            }
            return View(detailsArchitecture);
        }

        // POST: DetailsArchitectures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomDetail,Description")] DetailsArchitecture detailsArchitecture)
        {
            if (id != detailsArchitecture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detailsArchitecture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailsArchitectureExists(detailsArchitecture.Id))
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
            return View(detailsArchitecture);
        }

        // GET: DetailsArchitectures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailsArchitecture = await _context.DetailsArchitecture
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detailsArchitecture == null)
            {
                return NotFound();
            }

            return View(detailsArchitecture);
        }

        // POST: DetailsArchitectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detailsArchitecture = await _context.DetailsArchitecture.FindAsync(id);
            _context.DetailsArchitecture.Remove(detailsArchitecture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailsArchitectureExists(int id)
        {
            return _context.DetailsArchitecture.Any(e => e.Id == id);
        }
    }
}
