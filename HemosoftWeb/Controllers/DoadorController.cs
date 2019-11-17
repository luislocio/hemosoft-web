using Domain.Models;
using HemosoftWeb.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Repository.DAL;
using System;
using System.Collections.Generic;

namespace HemosoftWeb.Controllers
{
    public class DoadorController : Controller
    {
        private readonly DoadorDAO _doadorDAO;
        private readonly DoacaoDAO _doacaoDAO;

        public DoadorController(DoadorDAO doadorDAO, DoacaoDAO doacaoDAO)
        {
            _doadorDAO = doadorDAO;
            _doacaoDAO = doacaoDAO;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Doador doador)
        {
            ModelState.Remove("TipoSanguineo");
            ModelState.Remove("FatorRh");
            if (ModelState.IsValid)
            {
                if (Validacao.CpfEhValido(doador.Cpf))
                {
                    int idDoador = _doadorDAO.CadastrarDoador(doador);
                    if (idDoador != 0)
                    {
                        // TODO: [FEEDBACK] - Apresentar mensagem de sucesso.
                        ModelState.AddModelError("Success", "Doador cadastrado com sucesso.");
                    }
                    else
                    {
                        // TODO: [FEEDBACK] - Apresentar mensagem de sucesso.
                        ModelState.AddModelError("Success", "Este doador já possui cadastro.");
                    }
                    return RedirectToAction("perfil", new RouteValueDictionary { { "id", idDoador } });
                }
                // CPF inválido
                ModelState.AddModelError("", "CPF Inválido!");
                return View(doador);
            }
            return View(doador);
        }

        public IActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buscar(string cpf)
        {
            if (Validacao.CpfEhValido(cpf))
            {
                Doador parametroDaBusca = new Doador { Cpf = cpf };
                Doador resultadoDaBusca = _doadorDAO.BuscarDoadorPorCpf(parametroDaBusca);

                if (resultadoDaBusca != null)
                {
                    return RedirectToAction("perfil", new RouteValueDictionary { { "id", resultadoDaBusca.IdDoador } });
                }
                else
                {
                    ModelState.AddModelError("", "Nenhum doador encontrado.");
                    return View();
                }
            }
            ModelState.AddModelError("", "CPF Inválido");
            return View();
        }

        public IActionResult Perfil(int? id)
        {
            Doador resultadoDaBusca = _doadorDAO.BuscarDoadorPorId(id);
            ViewBag.diasDesdeAUltimaDoacao = null;

            if (resultadoDaBusca.Doacoes == null)
            {
                resultadoDaBusca.Doacoes = new List<Doacao>();
            }

            if (resultadoDaBusca.UltimaDoacao != default(DateTime))
            {
                ViewBag.diasDesdeAUltimaDoacao = (int)DateTime.Now.Subtract(resultadoDaBusca.UltimaDoacao).TotalDays;
            }

            ViewBag.doacoes = resultadoDaBusca.Doacoes;
            return View(resultadoDaBusca);
        }

        public IActionResult Alterar(Doador doador)
        {
            if (ModelState.IsValid)
            {
                if (Validacao.CpfEhValido(doador.Cpf))
                {
                    _doadorDAO.AlterarDoador(doador);
                    Doador resultadoDaBusca = _doadorDAO.BuscarDoadorPorCpf(doador);

                    // TODO: [FEEDBACK] - Apresentar mensagem de sucesso.
                    return RedirectToAction("perfil", new RouteValueDictionary { { "id", resultadoDaBusca.IdDoador } });
                }
                ModelState.AddModelError("", "CPF Inválido");
            }
            return RedirectToAction("perfil", new RouteValueDictionary { { "id", doador.IdDoador } });
        }
    }
}