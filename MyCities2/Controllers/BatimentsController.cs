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
    public class BatimentsController : Controller
    {
        private readonly MyCitiesDBContext _context;

        public BatimentsController(MyCitiesDBContext context)
        {
            _context = context;
        }

        // GET: Batiments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Batiments.ToListAsync());
        }

        // GET: Batiments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batiment = await _context.Batiments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batiment == null)
            {
                return NotFound();
            }

            return View(batiment);
        }

        // GET: Batiments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Batiments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Longitude,Latitude,Adresse1,Adresse2,Ville,CP,Architecte,ImageURL,Periode_construction_debut,Periode_construction_fin,Style,Siteweb")] Batiment batiment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(batiment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(batiment);
        }

        // GET: Batiments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batiment = await _context.Batiments.FindAsync(id);
            if (batiment == null)
            {
                return NotFound();
            }
            return View(batiment);
        }

        // POST: Batiments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Longitude,Latitude,Adresse1,Adresse2,Ville,CP,Architecte,ImageURL,Periode_construction_debut,Periode_construction_fin,Style,Siteweb")] Batiment batiment)
        {
            if (id != batiment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(batiment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatimentExists(batiment.Id))
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
            return View(batiment);
        }

        // GET: Batiments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batiment = await _context.Batiments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (batiment == null)
            {
                return NotFound();
            }

            return View(batiment);
        }

        // POST: Batiments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var batiment = await _context.Batiments.FindAsync(id);
            _context.Batiments.Remove(batiment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatimentExists(int id)
        {
            return _context.Batiments.Any(e => e.Id == id);
        }
    }
}
