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
        // TODO: REMOVER TRIADOR
        Triador triador;
        private readonly TriadorDAO _triadorDAO;


        private readonly DoacaoDAO _doacaoDAO;
        private readonly DoadorDAO _doadorDAO;
        public DoacaoController(DoacaoDAO doacaoDAO, DoadorDAO doadorDAO, TriadorDAO triadorDAO)
        {
            _doacaoDAO = doacaoDAO;
            _doadorDAO = doadorDAO;

            //TODO: REMOVER TRIADOR
            _triadorDAO = triadorDAO;
            this.triador = _triadorDAO.BuscarTriadorPorId(1);
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
                Doador doador = _doadorDAO.BuscarDoadorPorId(doacao.Doador.IdDoador);
                // Informações do formulário.
                ImpedimentosDefinitivos impedimentosDefinitivos = CriarImpedimentosDefinitivos(doacao);
                ImpedimentosTemporarios impedimentosTemporarios = CriarImpedimentosTemporarios(doacao);
                TriagemClinica triagemClinica = CriarTriagemClinica(doacao);

                // Informações que serão preenchidas após recebimento do exame laboratorial.
                TriagemLaboratorial triagemLaboratorial = new TriagemLaboratorial { };

                doacao = CriarDoacao(impedimentosTemporarios, triagemClinica, impedimentosDefinitivos, triagemLaboratorial, doador, triador);

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

        #region Criação de objetos para cadastro
        private Doacao CriarDoacao(ImpedimentosTemporarios impedimentosTemporarios, TriagemClinica triagemClinica, ImpedimentosDefinitivos impedimentosDefinitivos, TriagemLaboratorial triagemLaboratorial, Doador doador, Triador triador)
        {
            return new Doacao
            {
                DataDoacao = DateTime.Now,
                Doador = doador,
                Triador = triador,
                TriagemClinica = triagemClinica,
                TriagemLaboratorial = triagemLaboratorial,
                StatusDoacao = GetStatusDoacao(triagemClinica, impedimentosDefinitivos),
                ImpedimentosTemporarios = impedimentosTemporarios,
                ImpedimentosDefinitivos = impedimentosDefinitivos
            };
        }

        private ImpedimentosDefinitivos CriarImpedimentosDefinitivos(Doacao doacao)
        {
            return new ImpedimentosDefinitivos { AntecedenteAvc = doacao.ImpedimentosDefinitivos.AntecedenteAvc };
        }

        private ImpedimentosTemporarios CriarImpedimentosTemporarios(Doacao doacao)
        {
            return new ImpedimentosTemporarios
            {
                BebidaAlcoolica = doacao.ImpedimentosTemporarios.BebidaAlcoolica,
                BebidaAlcoolicaUltimaVez = doacao.ImpedimentosTemporarios.BebidaAlcoolicaUltimaVez,
                Gravidez = doacao.ImpedimentosTemporarios.Gravidez,
                GravidezUltimaVez = doacao.ImpedimentosTemporarios.GravidezUltimaVez,
                Gripe = doacao.ImpedimentosTemporarios.Gripe,
                GripeUltimaVez = doacao.ImpedimentosTemporarios.GripeUltimaVez,
                Tatuagem = doacao.ImpedimentosTemporarios.Tatuagem,
                TatuagemUltimaVez = doacao.ImpedimentosTemporarios.TatuagemUltimaVez
            };
        }

        private TriagemClinica CriarTriagemClinica(Doacao doacao)
        {
            return new TriagemClinica
            {
                Peso = doacao.TriagemClinica.Peso,
                Pulso = doacao.TriagemClinica.Pulso,
                Temperatura = doacao.TriagemClinica.Temperatura,
                StatusTriagem = GetStatusTriagemClinica(doacao.ImpedimentosTemporarios)
            };
        }

        #endregion
    }
}