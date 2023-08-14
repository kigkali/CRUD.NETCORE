using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba.Models;

namespace Prueba.Controllers
{
    public class GestoresBdsController : Controller
    {
        private readonly pruebaContext _context;

        public GestoresBdsController(pruebaContext context)
        {
            _context = context;
        }

        // GET: GestoresBds
        public async Task<IActionResult> Index()
        {
            return View(await _context.GestoresBds.ToListAsync());
        }

        // GET: GestoresBds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestoresBd = await _context.GestoresBds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gestoresBd == null)
            {
                return NotFound();
            }

            return View(gestoresBd);
        }

        // GET: GestoresBds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GestoresBds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Lanzamiento,Desarrollador")] GestoresBd gestoresBd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gestoresBd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gestoresBd);
        }

        // GET: GestoresBds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestoresBd = await _context.GestoresBds.FindAsync(id);
            if (gestoresBd == null)
            {
                return NotFound();
            }
            return View(gestoresBd);
        }

        // POST: GestoresBds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Lanzamiento,Desarrollador")] GestoresBd gestoresBd)
        {
            if (id != gestoresBd.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gestoresBd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GestoresBdExists(gestoresBd.Id))
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
            return View(gestoresBd);
        }

        // GET: GestoresBds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gestoresBd = await _context.GestoresBds
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gestoresBd == null)
            {
                return NotFound();
            }

            return View(gestoresBd);
        }

        // POST: GestoresBds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gestoresBd = await _context.GestoresBds.FindAsync(id);
            _context.GestoresBds.Remove(gestoresBd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GestoresBdExists(int id)
        {
            return _context.GestoresBds.Any(e => e.Id == id);
        }
    }
}
