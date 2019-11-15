using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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

        [HttpPost]
        public IActionResult Cadastrar(Triador triador)
        {
            if (ModelState.IsValid)
            {
                int idTriador = _triadorDAO.CadastrarTriador(triador);
                if (idTriador != 0)
                {
                    // TODO: [FEEDBACK] - Apresentar mensagem de sucesso.
                    ModelState.AddModelError("Success", "Triador cadastrado com sucesso.");
                }
                else
                {
                    // TODO: [FEEDBACK] - Apresentar mensagem de sucesso.
                    ModelState.AddModelError("Success", "Este triador já possui cadastro.");
                }
                return RedirectToAction("perfil", new RouteValueDictionary { { "id", idTriador } });
            }
            return View(triador);
        }

        public IActionResult Buscar()
        {
            return View();
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
                    return RedirectToAction("perfil", new RouteValueDictionary { { "id", resultadoDaBusca.IdTriador } });
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

        public IActionResult Perfil(int? id)
        {
            Triador resultadoDaBusca = _triadorDAO.BuscarTriadorPorId(id);

            return View(resultadoDaBusca);
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