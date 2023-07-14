using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Filmes.Data;
using MVC_Filmes.Models;

namespace MVC_Filmes.Controllers
{
    public class FilmesController : Controller
    {
        private readonly MVC_FilmesContext _context;

        public FilmesController(MVC_FilmesContext context)
        {
            _context = context;
        }

        // GET: Filmes
        public async Task<IActionResult> Index(string FilmeDigitado, string GeneroEscolhido)
        {
            var filme = from f in _context.Filme
                        select f;
            IQueryable<string> generos = from g in _context.Filme
                                        orderby g.Genero
                                        select g.Genero;


            if (!string.IsNullOrEmpty(FilmeDigitado))
            {
                filme = filme.Where(f => f.Titulo.Contains(FilmeDigitado));
            }

            if (!string.IsNullOrEmpty(GeneroEscolhido))
            {
                filme = filme.Where(f => f.Genero == GeneroEscolhido);
            }

            FilmeViewModel filmeViewModel = new FilmeViewModel()
            {
                Filmes = await filme.ToListAsync(),
                Generos = new SelectList(await generos.Distinct().ToListAsync())
            };

              return _context.Filme != null ? 
                          View(filmeViewModel) :
                          Problem("Entity set 'MVC_FilmesContext.Filme'  is null.");
        }

        // GET: Filmes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Filme == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // GET: Filmes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Genero,DataDeLancamento,Preco,Ponto")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filme);
        }

        // GET: Filmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Filme == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme.FindAsync(id);
            if (filme == null)
            {
                return NotFound();
            }
            return View(filme);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Genero,DataDeLancamento,Preco,Ponto")] Filme filme)
        {
            if (id != filme.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeExists(filme.Id))
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
            return View(filme);
        }

        // GET: Filmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Filme == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Filme == null)
            {
                return Problem("Entity set 'MVC_FilmesContext.Filme'  is null.");
            }
            var filme = await _context.Filme.FindAsync(id);
            if (filme != null)
            {
                _context.Filme.Remove(filme);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmeExists(int id)
        {
          return (_context.Filme?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
