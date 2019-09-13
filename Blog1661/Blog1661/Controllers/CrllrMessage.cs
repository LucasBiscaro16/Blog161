using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class CrllrMenssage : Controller
    {
        private readonly WaContext _context;

        public CrllrMenssage(WaContext context)
        {
            _context = context;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,Data,CategoriaId,ComentarioId")] Mensagem mensagem)
        {
            if (id != mensagem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mensagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensagemExists(mensagem.Id))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId", mensagem.CategoriaId);
            ViewData["ComentarioId"] = new SelectList(_context.Comentario, "ComentarioId", "ComentarioId", mensagem.ComentarioId);
            return View(mensagem);
        }

        public async Task<IActionResult> Index()
        {
            var webApplication3Context = _context.Mensagem.Include(m => m.Categorias).Include(m => m.Comentarios);
            return View(await webApplication3Context.ToListAsync());
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mensagem = await _context.Mensagem.FindAsync(id);
            _context.Mensagem.Remove(mensagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensagemExists(int id)
        {
            return _context.Mensagem.Any(e => e.Id == id);
        }
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId");
            ViewData["ComentarioId"] = new SelectList(_context.Comentario, "ComentarioId", "ComentarioId");
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagem.FindAsync(id);
            if (mensagem == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId", mensagem.CategoriaId);
            ViewData["ComentarioId"] = new SelectList(_context.Comentario, "ComentarioId", "ComentarioId", mensagem.ComentarioId);
            return View(mensagem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,Data,CategoriaId,ComentarioId")] Mensagem mensagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categoria, "CategoriaId", "CategoriaId", mensagem.CategoriaId);
            ViewData["ComentarioId"] = new SelectList(_context.Comentario, "ComentarioId", "ComentarioId", mensagem.ComentarioId);
            return View(mensagem);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagem
                .Include(m => m.Categorias)
                .Include(m => m.Comentarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mensagem == null)
            {
                return NotFound();
            }

            return View(mensagem);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensagem = await _context.Mensagem
                .Include(m => m.Categorias)
                .Include(m => m.Comentarios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mensagem == null)
            {
                return NotFound();
            }

            return View(mensagem);
        }




    }
}
