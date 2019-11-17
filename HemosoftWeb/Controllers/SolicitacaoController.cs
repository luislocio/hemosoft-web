using Domain.Enum;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Repository.DAL;
using System;
using System.Collections.Generic;

namespace HemosoftWeb.Controllers
{
    public class SolicitacaoController : Controller
    {
        private readonly SolicitacaoDAO _solicitacaoDAO;
        private readonly DoacaoDAO _doacaoDAO;
        private readonly SolicitanteDAO _solicitanteDAO;

        // TODO: PASSAR USUARIO LOGADO
        //// TRIADOR
        //Usuario usuario = new Usuario()
        //{
        //    IdUsuario = 1,
        //    NomeDeUsuario = "Triador",
        //    TipoUsuario = Domain.Enum.TipoUsuario.Triador
        //};

        // SOLICITANTE
        private Usuario usuario = new Usuario()
        {
            IdUsuario = 1,
            NomeDeUsuario = "Solicitante",
            TipoUsuario = Domain.Enum.TipoUsuario.Solicitante
        };

        public SolicitacaoController(SolicitacaoDAO solicitacaoDAO, DoacaoDAO doacaoDAO, SolicitanteDAO solicitanteDAO)
        {
            _solicitacaoDAO = solicitacaoDAO;
            _doacaoDAO = doacaoDAO;
            _solicitanteDAO = solicitanteDAO;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listar()
        {
            List<Solicitacao> solicitacoes = _solicitacaoDAO.ListarSolicitacoes();

            return View(solicitacoes);
        }

        public IActionResult Cadastrar(int? id)
        {
            Doacao doacao = _doacaoDAO.BuscarDoacaoPorId(id);
            // TODO: Buscar solicitante através do ID do usuário logado.
            Solicitante solicitante = _solicitanteDAO.BuscarSolicitantePorId(1);
            Solicitacao solicitacao = CriarSolicitacao(doacao, solicitante);

            _solicitacaoDAO.CadastrarSolicitacao(solicitacao);

            return RedirectToAction("perfil", "doacao", new RouteValueDictionary { { "id", doacao.IdDoacao } });
        }

        private static Solicitacao CriarSolicitacao(Doacao doacao, Solicitante solicitante)
        {
            Solicitacao solicitacao = new Solicitacao
            {
                DataSolicitacao = DateTime.Now,
                Solicitante = solicitante,
                Doacoes = new List<Doacao>()
            };

            doacao.StatusDoacao = StatusDoacao.NaoDisponivel;
            solicitacao.Doacoes.Add(doacao);

            return solicitacao;
        }
    }
}