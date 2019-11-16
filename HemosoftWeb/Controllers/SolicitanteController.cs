using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Repository.DAL;
using System.Collections;
using System.Collections.Generic;

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

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Solicitante solicitante)
        {
            if (ModelState.IsValid)
            {
                int idSolicitante = _solicitanteDAO.CadastrarSolicitante(solicitante);
                if (idSolicitante != 0)
                {
                    // TODO: [FEEDBACK] - Apresentar mensagem de sucesso.
                    ModelState.AddModelError("Success", "Solicitante cadastrado com sucesso.");
                }
                else
                {
                    // TODO: [FEEDBACK] - Apresentar mensagem de sucesso.
                    ModelState.AddModelError("Success", "Este solicitante já possui cadastro.");
                }
                return RedirectToAction("perfil", new RouteValueDictionary { { "id", idSolicitante } });
            }
            return View(solicitante);
        }

        public IActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buscar(string cnpj)
        {
            // TODO: [INPUT] - Validar cpf.
            if (cnpj != null)
            {
                Solicitante parametroDaBusca = new Solicitante { Cnpj = cnpj };
                Solicitante resultadoDaBusca = _solicitanteDAO.BuscarSolicitantePorCnpj(parametroDaBusca);

                if (resultadoDaBusca != null)
                {
                    return RedirectToAction("perfil", new RouteValueDictionary { { "id", resultadoDaBusca.IdSolicitante } });
                }
                else
                {
                    ModelState.AddModelError("", "Nenhum solicitante encontrado.");
                    return View();
                }
            }

            ModelState.AddModelError("", "CNPJ Inválido");
            return View();
        }

        public IActionResult Perfil(int? id)
        {
            Solicitante resultadoDaBusca = _solicitanteDAO.BuscarSolicitantePorId(id);

            if (resultadoDaBusca.Solicitacoes == null)
            {
                resultadoDaBusca.Solicitacoes = new List<Solicitacao>();
            }

            ViewBag.solicitacoes = resultadoDaBusca.Solicitacoes;
            return View(resultadoDaBusca);
        }

        // GET: Solicitante
        public IActionResult Listar()
        {
            return View(_solicitanteDAO.ListarSolicitantes());
        }

        public IActionResult Alterar(Solicitante solicitante)
        {
            if (ModelState.IsValid)
            {
                _solicitanteDAO.AlterarSolicitante(solicitante);
                Solicitante resultadoDaBusca = _solicitanteDAO.BuscarSolicitantePorCnpj(solicitante);

                // TODO: [FEEDBACK] - Mostrar mensagem de sucesso.
                return RedirectToAction("perfil", new RouteValueDictionary { { "id", resultadoDaBusca.IdSolicitante } });
            }
            // TODO: [FEEDBACK] - Mostrar mensagem de erro.
            return RedirectToAction("perfil", new RouteValueDictionary { { "id", solicitante.IdSolicitante } });
        }

    }
}