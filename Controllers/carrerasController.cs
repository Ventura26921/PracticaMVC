using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaMVC.Models;

namespace PracticaMVC.Controllers
{
    public class carrerasController : Controller
    {
        private readonly equiposDbContext _context;

        public carrerasController(equiposDbContext context)
        {
            _context = context;
        }

        // GET: carreras
        public async Task<IActionResult> Index()
        {
              return _context.Carreras != null ? 
                          View(await _context.Carreras.ToListAsync()) :
                          Problem("Entity set 'equiposDbContext.Carreras'  is null.");
        }

        // GET: carreras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carreras == null)
            {
                return NotFound();
            }

            var carreras = await _context.Carreras
                .FirstOrDefaultAsync(m => m.carrera_id == id);
            if (carreras == null)
            {
                return NotFound();
            }

            return View(carreras);
        }

        // GET: carreras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: carreras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("carrera_id,nombre_carrera,facultad_id,estado")] carreras carreras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carreras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carreras);
        }

        // GET: carreras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carreras == null)
            {
                return NotFound();
            }

            var carreras = await _context.Carreras.FindAsync(id);
            if (carreras == null)
            {
                return NotFound();
            }
            return View(carreras);
        }

        // POST: carreras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("carrera_id,nombre_carrera,facultad_id,estado")] carreras carreras)
        {
            if (id != carreras.carrera_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carreras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!carrerasExists(carreras.carrera_id))
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
            return View(carreras);
        }

        // GET: carreras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carreras == null)
            {
                return NotFound();
            }

            var carreras = await _context.Carreras
                .FirstOrDefaultAsync(m => m.carrera_id == id);
            if (carreras == null)
            {
                return NotFound();
            }

            return View(carreras);
        }

        // POST: carreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carreras == null)
            {
                return Problem("Entity set 'equiposDbContext.Carreras'  is null.");
            }
            var carreras = await _context.Carreras.FindAsync(id);
            if (carreras != null)
            {
                _context.Carreras.Remove(carreras);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool carrerasExists(int id)
        {
          return (_context.Carreras?.Any(e => e.carrera_id == id)).GetValueOrDefault();
        }
    }
}
