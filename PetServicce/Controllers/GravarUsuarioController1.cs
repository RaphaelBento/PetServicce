using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetServicce.Controllers
{
    public class GravarUsuarioController1 : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
