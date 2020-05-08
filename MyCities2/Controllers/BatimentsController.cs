using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCities2.Models;
using MyCities2.ViewModels;

namespace MyCities2.Controllers
{
    public class BatimentsController : Controller
    {
        private readonly MyCitiesDBContext _context;

        public BatimentsController(MyCitiesDBContext context)
        {
            _context = context;
        }

        //private mycitiesdbcontext db = new mycitiesdbcontext();
        //// get batiments dto
        //public iqueryable<batimentdto> getbatiments()
        //{
        //    var batiments = from b in db.batiments
        //                    select new batimentdto()
        //                    {
        //                        id = b.id,
        //                        nom = b.nom,
        //                        categorie = b.categorie,
        //                        imageurl = b.imageurl,
        //                        ville = b.ville
        //                    };

        //    return batiments;
        //}

        // GET BatimentDetailDTO/5
        //[ResponseType(typeof(BatimentDetailsDTO))]
        //public async Task<IHttpActionResult> GetBook(int id)
        //{
        //    var batiment = await db.Batiments.Include(b => b.Nom).Select(b =>
        //        new BatimentDetailsDTO()
        //        {
        //            Id = b.Id,
        //            Description = b.Description,


        //        }).SingleOrDefaultAsync(b => b.Id == id);
        //    if (batiment == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(batiment);
        //}
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
            BatimentViewModel vm = new BatimentViewModel(new Batiment());
            return View(vm);
        }



        // POST: Batiments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Longitude,Latitude,Adresse1,Adresse2,Ville,CP,Architecte,ImageURL,Periode_construction_debut,Periode_construction_fin,Style,Siteweb")] Batiment batiment)
        //public async Task<IActionResult> Create(BatimentViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(batiment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(batiment);
            //return RedirectToAction("Index");

        }

        // GET: Batiments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var batiment = await _context.Batiments.FindAsync(id);
            //if (batiment == null)
            //{
            //    return NotFound();
            //}
            //return View(batiment);
            BatimentViewModel vm = new BatimentViewModel(new Batiment());
            return View(vm);
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
