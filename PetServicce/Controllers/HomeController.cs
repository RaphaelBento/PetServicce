using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetServicce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetServicce.Data;
using PetServicce.Model;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PetServicce.Controllers
{
    public class HomeController : Controller
    {
        private readonly PetServicceContext _context;
        public IActionResult Login()
        {
            return View();
        }

        

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

