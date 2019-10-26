using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HemosoftWeb.Controllers
{
    public class SolicitacaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // GET: Doador
        public IActionResult Listar()
        {
            return View();
        }

        // GET: Doador
        public IActionResult Perfil()
        {
            return View();
        }
    }
}