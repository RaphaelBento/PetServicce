using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetServicce.Controllers
{
    public class Cada_stroController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastro() {

            return View();
                }
    }
}
