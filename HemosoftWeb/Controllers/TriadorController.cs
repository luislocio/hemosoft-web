using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.DAL;

namespace HemosoftWeb.Controllers
{
    public class TriadorController : Controller
    {
        private readonly TriadorDAO _triadorDAO;
        public TriadorController(TriadorDAO triadorDAO)
        {
            _triadorDAO = triadorDAO;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        public IActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Triador t)
        {
            if (ModelState.IsValid)
            {
                if (_triadorDAO.CadastrarTriador(t))
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

        [HttpPost]
        public IActionResult Buscar(string matricula)
        {

            if (matricula != null)
            {
                Triador parametroDaBusca = new Triador { Matricula = matricula };
                Triador resultadoDaBusca = _triadorDAO.BuscarTriadorPorMatricula(parametroDaBusca);

                if (resultadoDaBusca != null)
                {
                    return RedirectToAction("perfil", resultadoDaBusca);
                }
                else
                {
                    ModelState.AddModelError("", "Nenhum triador encontrado.");
                    return View();
                }
            }

            ModelState.AddModelError("", "Matricula inválida");
            return View();
        }
        public IActionResult Listar()
        {
            return View();
        }
        public IActionResult Perfil(Triador triador)
        {
            return View();
        }

        public IActionResult Alterar(Triador triador)
        {
            if (ModelState.IsValid)
            {
                // TODO: [INPUT] - Validar cpf.
                _triadorDAO.AlterarTriador(triador);

                // TODO: [FEEDBACK] - Mostrar mensagem de sucesso.
                Triador resultadoDaBusca = _triadorDAO.BuscarTriadorPorMatricula(triador);
                return RedirectToAction("perfil", resultadoDaBusca);
            }
            // TODO: [FEEDBACK] - Mostrar mensagem de erro.
            return RedirectToAction("perfil", triador);
        }
    }
}