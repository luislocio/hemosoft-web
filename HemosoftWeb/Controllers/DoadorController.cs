using Domain.Models;
using HemosoftWeb.Utils;
using Microsoft.AspNetCore.Mvc;
using Repository.DAL;
using System.Collections.Generic;

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
                if (Validacao.CpfEhValido(d.Cpf))
                {
                    if (_doadorDAO.CadastrarDoador(d))
                    {
                        // TODO: [FEEDBACK] - Apresentar mensagem de sucesso.
                        ModelState.AddModelError("Success", "Doador cadastrado com sucesso.");
                    }
                    else
                    {
                        // TODO: [FEEDBACK] - Apresentar mensagem de sucesso.
                        ModelState.AddModelError("Success", "Este doador já possui cadastro.");
                    }
                    return RedirectToAction("perfil", d);
                }
                // CPF inválido
                ModelState.AddModelError("", "CPF Inválido!");
                return View(d);
            }
            return View(d);
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
                    return RedirectToAction("perfil", resultadoDaBusca);
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

        [HttpPost]
        public IActionResult Perfil(Doador doador)
        {
            if (doador.Doacoes == null)
            {
                doador.Doacoes = new List<Doacao>();
            }
            ViewBag.doacoes = doador.Doacoes;
            return View();
        }

        public IActionResult Alterar(Doador doador)
        {
            if (ModelState.IsValid)
            {
                // TODO: [INPUT] - Validar cpf.
                _doadorDAO.AlterarDoador(doador);

                // TODO: [FEEDBACK] - Mostrar mensagem de sucesso.
                Doador resultadoDaBusca = _doadorDAO.BuscarDoadorPorCpf(doador);
                return RedirectToAction("perfil", resultadoDaBusca);
            }
            // TODO: [FEEDBACK] - Mostrar mensagem de erro.
            return RedirectToAction("perfil", doador);
        }
    }
}