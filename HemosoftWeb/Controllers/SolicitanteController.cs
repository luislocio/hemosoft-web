using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HemosoftWeb.DAL;
using HemosoftWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HemosoftWeb.Controllers
{
    public class SolicitanteController : Controller
    {
        private readonly SolicitanteDAO _solicitanteDAO;
        public SolicitanteController(SolicitanteDAO solicitanteDAO)
        {
            _solicitanteDAO = solicitanteDAO;
        }


        public IActionResult Index()
        {
            return View();
        }

        // GET: Solicitante
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Solicitante s)
        {
            if (ModelState.IsValid)
            {
                if (_solicitanteDAO.CadastrarSolicitante(s))
                {
                    // TODO: [FEEDBACK] - Mostrar mensagem de sucesso.
                    return RedirectToAction("Index", "Home", "Index");
                }
                // TODO: [REGRA] - Redirecionar para o perfil do doador. 
                ModelState.AddModelError("", "Esse solicitante já existe!");
                return View(s);
            }
            return View(s);
        }




        // GET: Solicitante
        public IActionResult Listar()
        {
            return View();
        }

        // GET: Solicitante
        public IActionResult Perfil()
        {
            return View();
        }
    }
}