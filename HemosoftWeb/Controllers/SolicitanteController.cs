using Domain.Models;
using Microsoft.AspNetCore.Mvc;
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
                    return RedirectToAction("perfil", resultadoDaBusca);
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

        public IActionResult Perfil(Solicitante solicitante)
        {
            if (solicitante.Solicitacoes == null)
            {
                solicitante.Solicitacoes = new List<Solicitacao>();
            }
            ViewBag.solicitacoes = solicitante.Solicitacoes;
            return View();
        }

        // GET: Solicitante
        public IActionResult Listar()
        {
            return View();
        }

        public IActionResult Alterar(Solicitante solicitante)
        {
            if (ModelState.IsValid)
            {
                // TODO: [INPUT] - Validar cpf.
                _solicitanteDAO.AlterarSolicitante(solicitante);

                // TODO: [FEEDBACK] - Mostrar mensagem de sucesso.
                Solicitante resultadoDaBusca = _solicitanteDAO.BuscarSolicitantePorCnpj(solicitante);
                return RedirectToAction("perfil", resultadoDaBusca);
            }
            // TODO: [FEEDBACK] - Mostrar mensagem de erro.
            return RedirectToAction("perfil", solicitante);
        }

    }
}