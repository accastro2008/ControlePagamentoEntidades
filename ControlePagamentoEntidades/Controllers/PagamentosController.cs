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
    public class PagamentosController : Controller
    {
        private readonly SistemaCPEContext _context;

        public PagamentosController(SistemaCPEContext context)
        {
            _context = context;
        }

        // GET: Pagamentos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Pagamentos.ToListAsync());
        }

        // GET: Pagamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pagamentos == null)
            {
                return NotFound();
            }

            var pagamentoModel = await _context.Pagamentos
                .FirstOrDefaultAsync(m => m.PagamentoID == id);
            if (pagamentoModel == null)
            {
                return NotFound();
            }

            return View(pagamentoModel);
        }

        // GET: Pagamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pagamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PagamentoID,PagamentoSeq,PagamentoData,PagamentoValor")] PagamentoModel pagamentoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamentoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagamentoModel);
        }

        // GET: Pagamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pagamentos == null)
            {
                return NotFound();
            }

            var pagamentoModel = await _context.Pagamentos.FindAsync(id);
            if (pagamentoModel == null)
            {
                return NotFound();
            }
            return View(pagamentoModel);
        }

        // POST: Pagamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PagamentoID,PagamentoSeq,PagamentoData,PagamentoValor")] PagamentoModel pagamentoModel)
        {
            if (id != pagamentoModel.PagamentoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamentoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoModelExists(pagamentoModel.PagamentoID))
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
            return View(pagamentoModel);
        }

        // GET: Pagamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pagamentos == null)
            {
                return NotFound();
            }

            var pagamentoModel = await _context.Pagamentos
                .FirstOrDefaultAsync(m => m.PagamentoID == id);
            if (pagamentoModel == null)
            {
                return NotFound();
            }

            return View(pagamentoModel);
        }

        // POST: Pagamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pagamentos == null)
            {
                return Problem("Entity set 'SistemaCPEContext.Pagamentos'  is null.");
            }
            var pagamentoModel = await _context.Pagamentos.FindAsync(id);
            if (pagamentoModel != null)
            {
                _context.Pagamentos.Remove(pagamentoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoModelExists(int id)
        {
          return _context.Pagamentos.Any(e => e.PagamentoID == id);
        }
    }
}
