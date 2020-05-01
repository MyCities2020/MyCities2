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
    public class BatimentCulturelsController : Controller
    {
        private readonly MyCitiesDBContext _context;

        public BatimentCulturelsController(MyCitiesDBContext context)
        {
            _context = context;
        }

        // GET: BatimentCulturels
        public async Task<IActionResult> Index()
        {
            return View(await _context.BatimentsCulturel.ToListAsync());
        }

        // GET: BatimentCulturels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batimentCulturel = await _context.BatimentsCulturel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batimentCulturel == null)
            {
                return NotFound();
            }

            return View(batimentCulturel);
        }

        // GET: BatimentCulturels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BatimentCulturels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeCulturel,Id,Nom,Longitude,Latitude,Adresse1,Adresse2,Ville,CP,Architecte,ImageURL,Periode_construction_debut,Periode_construction_fin,Style,Siteweb")] BatimentCulturel batimentCulturel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(batimentCulturel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(batimentCulturel);
        }

        // GET: BatimentCulturels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batimentCulturel = await _context.BatimentsCulturel.FindAsync(id);
            if (batimentCulturel == null)
            {
                return NotFound();
            }
            return View(batimentCulturel);
        }

        // POST: BatimentCulturels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeCulturel,Id,Nom,Longitude,Latitude,Adresse1,Adresse2,Ville,CP,Architecte,ImageURL,Periode_construction_debut,Periode_construction_fin,Style,Siteweb")] BatimentCulturel batimentCulturel)
        {
            if (id != batimentCulturel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(batimentCulturel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatimentCulturelExists(batimentCulturel.Id))
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
            return View(batimentCulturel);
        }

        // GET: BatimentCulturels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batimentCulturel = await _context.BatimentsCulturel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batimentCulturel == null)
            {
                return NotFound();
            }

            return View(batimentCulturel);
        }

        // POST: BatimentCulturels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var batimentCulturel = await _context.BatimentsCulturel.FindAsync(id);
            _context.BatimentsCulturel.Remove(batimentCulturel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatimentCulturelExists(int id)
        {
            return _context.BatimentsCulturel.Any(e => e.Id == id);
        }
    }
}
