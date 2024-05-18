﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LightScience.Context;
using LightScience.Models;
using Microsoft.AspNetCore.SignalR;
using LightScience.Hubs;

namespace LightScience.Controllers
{
    public class LuxController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<DataHub> _hubContext;

        public LuxController(AppDbContext context, IHubContext<DataHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }
        [HttpPost("ldr")]
        [HttpGet("ldr")]
        public async Task <IActionResult> ReceiveLdrValue([FromQuery] List <int> values, [FromQuery] int cuturaId)
        {
            if (values == null || values.Count == 0)
            {
                return BadRequest("No values provided");
            }
            var cuturaExists = await _context.Cuturas.AnyAsync(c => c.CuturaId == cuturaId);
            if (!cuturaExists)
            {
                return BadRequest("Invalid CuturaId");
            }
            var luxs = new List<Lux>(); 
            foreach (var value in values)
            {
                var lux = new Lux
                {
                    QuantidadeLux = value,
                    DataLeitura = DateTime.Now,
                    CuturaId = cuturaId
                };
                _context.Luxs.Add(lux);
                luxs.Add(lux);
                await _hubContext.Clients.All.SendAsync("ReceiveData", lux);
            }
            await _context.SaveChangesAsync();
            return Ok(luxs);
        }

        // GET: Lux
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Luxs.Include(l => l.Cutura);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Lux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lux = await _context.Luxs
                .Include(l => l.Cutura)
                .FirstOrDefaultAsync(m => m.LuxId == id);
            if (lux == null)
            {
                return NotFound();
            }

            return View(lux);
        }

        // GET: Lux/Create
        public IActionResult Create()
        {
            ViewData["CuturaId"] = new SelectList(_context.Cuturas, "CuturaId", "Categoria");
            return View();
        }

        // POST: Lux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LuxId,QuantidadeLux,DataLeitura,CuturaId")] Lux lux)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lux);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CuturaId"] = new SelectList(_context.Cuturas, "CuturaId", "Categoria", lux.CuturaId);
            return View(lux);
        }

        // GET: Lux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lux = await _context.Luxs.FindAsync(id);
            if (lux == null)
            {
                return NotFound();
            }
            ViewData["CuturaId"] = new SelectList(_context.Cuturas, "CuturaId", "Categoria", lux.CuturaId);
            return View(lux);
        }

        // POST: Lux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LuxId,QuantidadeLux,DataLeitura,CuturaId")] Lux lux)
        {
            if (id != lux.LuxId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lux);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LuxExists(lux.LuxId))
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
            ViewData["CuturaId"] = new SelectList(_context.Cuturas, "CuturaId", "Categoria", lux.CuturaId);
            return View(lux);
        }

        // GET: Lux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lux = await _context.Luxs
                .Include(l => l.Cutura)
                .FirstOrDefaultAsync(m => m.LuxId == id);
            if (lux == null)
            {
                return NotFound();
            }

            return View(lux);
        }

        // POST: Lux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lux = await _context.Luxs.FindAsync(id);
            if (lux != null)
            {
                _context.Luxs.Remove(lux);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LuxExists(int id)
        {
            return _context.Luxs.Any(e => e.LuxId == id);
        }
    }
}
