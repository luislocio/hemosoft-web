using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HemosoftWeb.Models;

namespace HemosoftWeb.Controllers
{
    public class DoadorController : Controller
    {
        private readonly Context _context;

        public DoadorController(Context context)
        {
            _context = context;
        }

        // GET: Doador
        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
