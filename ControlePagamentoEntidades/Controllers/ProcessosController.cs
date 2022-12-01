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
    public class ProcessosController : Controller
    {
        private readonly SistemaCPEContext _context;

        public ProcessosController(SistemaCPEContext context)
        {
            _context = context;
        }

        // GET: Processos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Processos.ToListAsync());
        }

        // GET: Processos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Processos == null)
            {
                return NotFound();
            }

            var processoModel = await _context.Processos
                .FirstOrDefaultAsync(m => m.ProcessoID == id);
            if (processoModel == null)
            {
                return NotFound();
            }

            return View(processoModel);
        }

        // GET: Processos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Processos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProcessoID,ProcessoNumero,ProcessoValorTotal")] ProcessoModel processoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(processoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(processoModel);
        }

        // GET: Processos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Processos == null)
            {
                return NotFound();
            }

            var processoModel = await _context.Processos.FindAsync(id);
            if (processoModel == null)
            {
                return NotFound();
            }
            return View(processoModel);
        }

        // POST: Processos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProcessoID,ProcessoNumero,ProcessoValorTotal")] ProcessoModel processoModel)
        {
            if (id != processoModel.ProcessoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessoModelExists(processoModel.ProcessoID))
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
            return View(processoModel);
        }

        // GET: Processos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Processos == null)
            {
                return NotFound();
            }

            var processoModel = await _context.Processos
                .FirstOrDefaultAsync(m => m.ProcessoID == id);
            if (processoModel == null)
            {
                return NotFound();
            }

            return View(processoModel);
        }

        // POST: Processos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Processos == null)
            {
                return Problem("Entity set 'SistemaCPEContext.Processos'  is null.");
            }
            var processoModel = await _context.Processos.FindAsync(id);
            if (processoModel != null)
            {
                _context.Processos.Remove(processoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessoModelExists(int id)
        {
          return _context.Processos.Any(e => e.ProcessoID == id);
        }
    }
}
