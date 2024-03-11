using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LightScience.Context;
using LightScience.Models;

namespace LightScience.Controllers
{
    public class CuturasController : Controller
    {
        private readonly AppDbContext _context;

        public CuturasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Cuturas
        public async Task<IActionResult> Index()
        {
              return View(await _context.Cuturas.ToListAsync());
        }

        // GET: Cuturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cuturas == null)
            {
                return NotFound();
            }

            var cutura = await _context.Cuturas
                .FirstOrDefaultAsync(m => m.CuturaId == id);
            if (cutura == null)
            {
                return NotFound();
            }

            return View(cutura);
        }

        // GET: Cuturas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cuturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("CuturaId,CodigoCutura,Categoria,Descricao,Nome")] Cutura cutura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cutura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cutura);
        }

        // GET: Cuturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cuturas == null)
            {
                return NotFound();
            }

            var cutura = await _context.Cuturas.FindAsync(id);
            if (cutura == null)
            {
                return NotFound();
            }
            return View(cutura);
        }

        // POST: Cuturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("CuturaId,CodigoCutura,Categoria,Descricao,Nome")] Cutura cutura)
        {
            if (id != cutura.CuturaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cutura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuturaExists(cutura.CuturaId))
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
            return View(cutura);
        }

        // GET: Cuturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cuturas == null)
            {
                return NotFound();
            }

            var cutura = await _context.Cuturas
                .FirstOrDefaultAsync(m => m.CuturaId == id);
            if (cutura == null)
            {
                return NotFound();
            }

            return View(cutura);
        }

        // POST: Cuturas/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cuturas == null)
            {
                return Problem("Entity set 'AppDbContext.Cuturas'  is null.");
            }
            var cutura = await _context.Cuturas.FindAsync(id);
            if (cutura != null)
            {
                _context.Cuturas.Remove(cutura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuturaExists(int id)
        {
          return _context.Cuturas.Any(e => e.CuturaId == id);
        }
    }
}
