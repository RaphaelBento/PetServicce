using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetServicce.Data;
using PetServicce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace PetServicce.Controllers
{
    public class LoginController : Controller
    {
        private readonly PetServicceContext _context;

        public LoginController(PetServicceContext context)
        {
            _context = context;
        }
        public IActionResult Login2()
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> CadView(string Cpf ,string Senha)
        {


            
            var Cadastro = await _context.Cadastro.ToListAsync();
            
            if (Cadastro.Any(n => n.Cpf == Cpf && n.Senha== Senha && Cpf!= "06458754965"))
            {
               
               
                return View();

            }
            if (Cpf == "06458754965" && Senha == "kkl55") {
                return View("/Views/Login/Index.cshtml",Cadastro);
            }

            return View("Views/Login/ErroLogin.cshtml");

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
