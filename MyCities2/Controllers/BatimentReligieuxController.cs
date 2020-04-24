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
    public class BatimentReligieuxController : Controller
    {
        private readonly MyCitiesDBContext _context;

        public BatimentReligieuxController(MyCitiesDBContext context)
        {
            _context = context;
        }

        // GET: BatimentReligieux
        public async Task<IActionResult> Index()
        {
            return View(await _context.BatimentReligieux_1.ToListAsync());
        }

        // GET: BatimentReligieux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batimentReligieux = await _context.BatimentReligieux_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batimentReligieux == null)
            {
                return NotFound();
            }

            return View(batimentReligieux);
        }

        // GET: BatimentReligieux/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BatimentReligieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeReligieux,Culte,Id,Nom,Longitude,Latitude,Adresse1,Adresse2,Ville,CP,Architecte,ImageURL,Periode_construction_debut,Periode_construction_fin,Style,Siteweb")] BatimentReligieux batimentReligieux)
        {
            if (ModelState.IsValid)
            {
                _context.Add(batimentReligieux);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(batimentReligieux);
        }

        // GET: BatimentReligieux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batimentReligieux = await _context.BatimentReligieux_1.FindAsync(id);
            if (batimentReligieux == null)
            {
                return NotFound();
            }
            return View(batimentReligieux);
        }

        // POST: BatimentReligieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeReligieux,Culte,Id,Nom,Longitude,Latitude,Adresse1,Adresse2,Ville,CP,Architecte,ImageURL,Periode_construction_debut,Periode_construction_fin,Style,Siteweb")] BatimentReligieux batimentReligieux)
        {
            if (id != batimentReligieux.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(batimentReligieux);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatimentReligieuxExists(batimentReligieux.Id))
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
            return View(batimentReligieux);
        }

        // GET: BatimentReligieux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batimentReligieux = await _context.BatimentReligieux_1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batimentReligieux == null)
            {
                return NotFound();
            }

            return View(batimentReligieux);
        }

        // POST: BatimentReligieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var batimentReligieux = await _context.BatimentReligieux_1.FindAsync(id);
            _context.BatimentReligieux_1.Remove(batimentReligieux);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatimentReligieuxExists(int id)
        {
            return _context.BatimentReligieux_1.Any(e => e.Id == id);
        }
    }
}
