using HemosoftWeb.DAL;
using HemosoftWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HemosoftWeb.Controllers
{
    public class TriadorController : Controller
    {
        private readonly TriadorDAO _traidorDAO;
        public TriadorController(TriadorDAO triadorDAO)
        {
            _traidorDAO = triadorDAO;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Triador t)
        {
            if (ModelState.IsValid)
            {
                if (_traidorDAO.CadastrarTriador(t))
                {
                    // TODO: [FEEDBACK] - Mostrar mensagem de sucesso.
                    return RedirectToAction("Index", "Home", "Index");
                }
                // TODO: [REGRA] - Redirecionar para o perfil do doador. 
                ModelState.AddModelError("", "Esse triador já existe!");
                return View(t);
            }
            return View(t);
        }

        public IActionResult Listar()
        {
            return View();
        }

        public IActionResult Perfil()
        {
            return View();
        }
    }
}