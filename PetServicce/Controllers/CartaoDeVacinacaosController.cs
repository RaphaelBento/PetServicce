using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetServicce.Data;
using PetServicce.Model;

namespace PetServicce.Controllers
{
    public class CartaoDeVacinacaosController : Controller
    {
        private readonly PetServicceContext _context;

        public CartaoDeVacinacaosController(PetServicceContext context)
        {
            _context = context;
        }

        // GET: CartaoDeVacinacaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.CartaoDeVacinacaos.ToListAsync());
        }

        // GET: CartaoDeVacinacaos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartaoDeVacinacao = await _context.CartaoDeVacinacaos
                .FirstOrDefaultAsync(m => m.NomeDoPet == id);
            if (cartaoDeVacinacao == null)
            {
                return NotFound();
            }

            return View(cartaoDeVacinacao);
        }

        // GET: CartaoDeVacinacaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CartaoDeVacinacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeDoPet,Sexo,Especie,Raca,Peso,DataNascimento,Telefone,Vacina,DataVacina,MdeicoVeterinário")] CartaoDeVacinacao cartaoDeVacinacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartaoDeVacinacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cartaoDeVacinacao);
        }

        // GET: CartaoDeVacinacaos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartaoDeVacinacao = await _context.CartaoDeVacinacaos.FindAsync(id);
            if (cartaoDeVacinacao == null)
            {
                return NotFound();
            }
            return View(cartaoDeVacinacao);
        }

        // POST: CartaoDeVacinacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NomeDoPet,Sexo,Especie,Raca,Peso,DataNascimento,Telefone,Vacina,DataVacina,MdeicoVeterinário")] CartaoDeVacinacao cartaoDeVacinacao)
        {
            if (id != cartaoDeVacinacao.NomeDoPet)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartaoDeVacinacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartaoDeVacinacaoExists(cartaoDeVacinacao.NomeDoPet))
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
            return View(cartaoDeVacinacao);
        }

        // GET: CartaoDeVacinacaos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartaoDeVacinacao = await _context.CartaoDeVacinacaos
                .FirstOrDefaultAsync(m => m.NomeDoPet == id);
            if (cartaoDeVacinacao == null)
            {
                return NotFound();
            }

            return View(cartaoDeVacinacao);
        }

        // POST: CartaoDeVacinacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cartaoDeVacinacao = await _context.CartaoDeVacinacaos.FindAsync(id);
            _context.CartaoDeVacinacaos.Remove(cartaoDeVacinacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartaoDeVacinacaoExists(string id)
        {
            return _context.CartaoDeVacinacaos.Any(e => e.NomeDoPet == id);
        }
    }
}
