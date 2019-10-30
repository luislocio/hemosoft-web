using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.DAL;

namespace HemosoftWeb.Controllers
{
    public class DoadorController : Controller
    {
        private readonly DoadorDAO _doadorDAO;
        public DoadorController(DoadorDAO doadorDAO)
        {
            _doadorDAO = doadorDAO;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Doador d)
        {
            if (ModelState.IsValid)
            {
                // TODO: [INPUT] - Validar cpf.
                if (_doadorDAO.CadastrarDoador(d))
                {
                    // TODO: [FEEDBACK] - Mostrar mensagem de sucesso.
                    return RedirectToAction("Index", "Home", "Index");
                }
                // TODO: [REGRA] - Redirecionar para o perfil do doador. 
                ModelState.AddModelError("", "Esse doador já existe!");
                return View(d);
            }
            return View(d);
        }

        public IActionResult Buscar()
        {
            return View();
        }

        public IActionResult Perfil()
        {
            return View();
        }
    }
}
