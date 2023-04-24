using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JM_Examen_P1.Data;
using JM_Examen_P1.Models;

namespace JM_Examen_P1.Controllers
{
    public class MonteroesController : Controller
    {
        private readonly JM_Examen_P1Context _context;

        public MonteroesController(JM_Examen_P1Context context)
        {
            _context = context;
        }

        // GET: Monteroes
        public async Task<IActionResult> Index()
        {
              return _context.Montero != null ? 
                          View(await _context.Montero.ToListAsync()) :
                          Problem("Entity set 'JM_Examen_P1Context.Montero'  is null.");
        }

        // GET: Monteroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Montero == null)
            {
                return NotFound();
            }

            var montero = await _context.Montero
                .FirstOrDefaultAsync(m => m.Id == id);
            if (montero == null)
            {
                return NotFound();
            }

            return View(montero);
        }

        // GET: Monteroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monteroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JM_SemestreId,JM_Nota,JM_Nombre,JM_Estudiante,JM_Fecha")] Montero montero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(montero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(montero);
        }

        // GET: Monteroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Montero == null)
            {
                return NotFound();
            }

            var montero = await _context.Montero.FindAsync(id);
            if (montero == null)
            {
                return NotFound();
            }
            return View(montero);
        }

        // POST: Monteroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JM_SemestreId,JM_Nota,JM_Nombre,JM_Estudiante,JM_Fecha")] Montero montero)
        {
            if (id != montero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(montero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonteroExists(montero.Id))
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
            return View(montero);
        }

        // GET: Monteroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Montero == null)
            {
                return NotFound();
            }

            var montero = await _context.Montero
                .FirstOrDefaultAsync(m => m.Id == id);
            if (montero == null)
            {
                return NotFound();
            }

            return View(montero);
        }

        // POST: Monteroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Montero == null)
            {
                return Problem("Entity set 'JM_Examen_P1Context.Montero'  is null.");
            }
            var montero = await _context.Montero.FindAsync(id);
            if (montero != null)
            {
                _context.Montero.Remove(montero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonteroExists(int id)
        {
          return (_context.Montero?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
