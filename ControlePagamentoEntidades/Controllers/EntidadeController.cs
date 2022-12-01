using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlePagamentoEntidades.Data;
using ControlePagamentoEntidades.Models;

namespace ControlePagamentoEntidades.Controllers
{
    public class EntidadeController : Controller
    {
        private readonly SistemaCPEContext _context;

        public EntidadeController(SistemaCPEContext context)
        {
            _context = context;
        }

        // GET: Entidade
        public async Task<IActionResult> Index()
        {
              return View(await _context.Endidades.ToListAsync());
        }

        // GET: Entidade/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Endidades == null)
            {
                return NotFound();
            }

            var entidadeModel = await _context.Endidades
                .FirstOrDefaultAsync(m => m.EntidadeID == id);
            if (entidadeModel == null)
            {
                return NotFound();
            }

            return View(entidadeModel);
        }

        // GET: Entidade/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entidade/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntidadeID,EntidadeNome,EntidadeCNPJ")] EntidadeModel entidadeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entidadeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entidadeModel);
        }

        // GET: Entidade/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Endidades == null)
            {
                return NotFound();
            }

            var entidadeModel = await _context.Endidades.FindAsync(id);
            if (entidadeModel == null)
            {
                return NotFound();
            }
            return View(entidadeModel);
        }

        // POST: Entidade/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntidadeID,EntidadeNome,EntidadeCNPJ")] EntidadeModel entidadeModel)
        {
            if (id != entidadeModel.EntidadeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entidadeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntidadeModelExists(entidadeModel.EntidadeID))
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
            return View(entidadeModel);
        }

        // GET: Entidade/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Endidades == null)
            {
                return NotFound();
            }

            var entidadeModel = await _context.Endidades
                .FirstOrDefaultAsync(m => m.EntidadeID == id);
            if (entidadeModel == null)
            {
                return NotFound();
            }

            return View(entidadeModel);
        }

        // POST: Entidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Endidades == null)
            {
                return Problem("Entity set 'SistemaCPEContext.Endidades'  is null.");
            }
            var entidadeModel = await _context.Endidades.FindAsync(id);
            if (entidadeModel != null)
            {
                _context.Endidades.Remove(entidadeModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntidadeModelExists(int id)
        {
          return _context.Endidades.Any(e => e.EntidadeID == id);
        }
    }
}
