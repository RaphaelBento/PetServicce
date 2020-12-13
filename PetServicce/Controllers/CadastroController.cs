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
    public class CadastroController : Controller
    {
        private readonly PetServicceContext _context;

        public CadastroController(PetServicceContext context)
        {
            _context = context;
        }
        //

        //

        //fazendo consulta no  banco de dados pelo nome do pet
        public IActionResult Cad() {

            var nomes = _context.CartaoDeVacinacaos.Include(m => m.NomeDoPet)
                    .Include(m => m.NomeDoPet).ToList();
            return View(nomes);

        }

        // GET: Cadastroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cadastro.ToListAsync());
        }


        // GET: Cadastroes/Details/5
        
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastro
                .FirstOrDefaultAsync(m => m.Cpf == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }
     
        // GET: Cadastroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cadastroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Cpf,NumeroContato,Endereco,Senha")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastro);
        }

        // GET: Cadastroes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastro.FindAsync(id);
            if (cadastro == null)
            {
                return NotFound();
            }
            return View(cadastro);
        }

        // POST: Cadastroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Nome,Cpf,NumeroContato,Endereco,Senha")] Cadastro cadastro)
        {
            if (id != cadastro.Cpf)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroExists(cadastro.Cpf))
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
            return View(cadastro);
        }

        // GET: Cadastroes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastro = await _context.Cadastro
                .FirstOrDefaultAsync(m => m.Cpf == id);
            if (cadastro == null)
            {
                return NotFound();
            }

            return View(cadastro);
        }

        // POST: Cadastroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cadastro = await _context.Cadastro.FindAsync(id);
            _context.Cadastro.Remove(cadastro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroExists(string id)
        {
            return _context.Cadastro.Any(e => e.Cpf == id);
        }
    }
}
