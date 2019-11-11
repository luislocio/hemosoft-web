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
        private readonly DoadorDAO _doadorDAO;
        public DoacaoController(DoacaoDAO doacaoDAO, DoadorDAO doadorDAO)
        {
            _doacaoDAO = doacaoDAO;
            _doadorDAO = doadorDAO;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Buscar()
        {
            return View();
        }

        public IActionResult Cadastrar(int? id)
        {
            ViewBag.idDoador = id;
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Doacao doacao)
        {
            ModelState.Remove("Doador.Cpf");
            ModelState.Remove("Doador.NomeCompleto");

            if (ModelState.IsValid)
            {
                doacao.DataDoacao = DateTime.Now;
                doacao.Doador = _doadorDAO.BuscarDoadorPorId(doacao.Doador.IdDoador);
                doacao.TriagemClinica.StatusTriagem = GetStatusTriagemClinica(doacao.ImpedimentosTemporarios);
                doacao.StatusDoacao = GetStatusDoacao(doacao.TriagemClinica, doacao.ImpedimentosDefinitivos);
                doacao.TriagemLaboratorial = new TriagemLaboratorial();
                int idDoacao = _doacaoDAO.CadastrarDoacao(doacao);

                // TODO: [FEEDBACK] - Mostrar mensagem de sucesso.
                return RedirectToAction("perfil", new RouteValueDictionary { { "id", idDoacao } });
            }
            return View(doacao);
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

        public IActionResult ConfirmarColeta(Doacao doacao)
        {
            doacao.StatusDoacao = StatusDoacao.AguardandoResultados;
            _doacaoDAO.AlterarDoacao(doacao);

            return RedirectToAction("perfil", new RouteValueDictionary { { "id", doacao.IdDoacao } });
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