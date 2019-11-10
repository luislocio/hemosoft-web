using Domain.Enum;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Repository.DAL;
using System;

namespace HemosoftWeb.Controllers
{
    public class DoacaoController : Controller
    {
        private readonly DoacaoDAO _doacaoDAO;
        public DoacaoController(DoacaoDAO doacaoDAO)
        {
            _doacaoDAO = doacaoDAO;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Buscar()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Doacao d)
        {
            if (ModelState.IsValid)
            {
                d.DataDoacao = DateTime.Now;
                d.TriagemClinica.StatusTriagem = GetStatusTriagemClinica(d.ImpedimentosTemporarios);
                d.StatusDoacao = GetStatusDoacao(d.TriagemClinica, d.ImpedimentosDefinitivos);
                d.TriagemLaboratorial = new TriagemLaboratorial();
                int id = _doacaoDAO.CadastrarDoacao(d);

                // TODO: [FEEDBACK] - Mostrar mensagem de sucesso.
                return RedirectToAction("perfil", new RouteValueDictionary { { "id", id } });
            }
            return View(d);
        }

        public IActionResult Listar()
        {
            Doacao doacao = new Doacao();
            doacao.StatusDoacao = StatusDoacao.AguardandoAtendimento;

            // TODO: Listar apenas doações com status DISPONIVEL
            return View(_doacaoDAO.BuscarDoacaoPorStatus(doacao));
        }

        public IActionResult Perfil(int? id)
        {
            Doacao resultadoDaBusca = _doacaoDAO.BuscarDoacaoPorId(id);
            return View(resultadoDaBusca);
        }

        #region Validação de status e atributos
        private StatusDoacao GetStatusDoacao(TriagemClinica triagemClinica, ImpedimentosDefinitivos impedimentosDefinitivos)
        {
            if (triagemClinica.StatusTriagem == StatusTriagem.Aprovado &&
                impedimentosDefinitivos.AntecedenteAvc == false)
            {
                return StatusDoacao.AguardandoAtendimento;
            }

            return StatusDoacao.AguardandoResultados;
        }
        private StatusTriagem GetStatusTriagemClinica(ImpedimentosTemporarios impedimentosTemporarios)
        {
            if (impedimentosTemporarios.BebidaAlcoolica == false &&
                impedimentosTemporarios.Gravidez == Gravidez.Nenhuma &&
                impedimentosTemporarios.Gripe == false &&
                impedimentosTemporarios.Tatuagem == false)
            {
                return StatusTriagem.Aprovado;
            }

            return StatusTriagem.Reprovado;
        }
        #endregion
    }
}