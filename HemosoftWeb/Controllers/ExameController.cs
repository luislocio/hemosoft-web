using Domain.Enum;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Repository.DAL;

namespace HemosoftWeb.Controllers
{
    public class ExameController : Controller
    {
        private readonly DoacaoDAO _doacaoDAO;
        private readonly DoadorDAO _doadorDAO;

        public ExameController(DoacaoDAO doacaoDAO, DoadorDAO doadorDAO)
        {
            _doacaoDAO = doacaoDAO;
            _doadorDAO = doadorDAO;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Doador
        public IActionResult Cadastrar(int? id)
        {
            ViewBag.idDoacao = id;
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(TriagemLaboratorial triagemLaboratorial)
        {
            ModelState.Remove("Doacao.Doador.Cpf");
            ModelState.Remove("Doacao.Doador.NomeCompleto");
            ModelState.Remove("Doacao.Doador.Genero");
            ModelState.Remove("Doacao.Doador.EstadoCivil");

            if (ModelState.IsValid)
            {
                Doacao doacao = _doacaoDAO.BuscarDoacaoPorId(triagemLaboratorial.Doacao.IdDoacao);
                Doador doador = _doadorDAO.BuscarDoadorPorId(doacao.Doador.IdDoador);

                doacao.TriagemLaboratorial = AtualizarTriagemLaboratorial(doacao, triagemLaboratorial);
                doacao.ImpedimentosDefinitivos = AtualizarImpedimentosDefinitivos(doacao, triagemLaboratorial);
                doador = AtualizarDadosDoSangue(doacao.Doador, triagemLaboratorial.Doacao.Doador);
                doacao.StatusDoacao = GetStatusDoacao(doacao);

                _doacaoDAO.AlterarDoacao(doacao);
                //_doadorDAO.AlterarDoador(doador);

                // TODO: [FEEDBACK] - Mostrar mensagem de sucesso.
                return RedirectToAction("perfil", "doacao", new RouteValueDictionary { { "id", doacao.IdDoacao } });
            }
            ViewBag.idDoacao = triagemLaboratorial.Doacao.Doador.IdDoador;
            return View();
        }

        #region Atualização de atributos da doação

        private TriagemLaboratorial AtualizarTriagemLaboratorial(Doacao doacao, TriagemLaboratorial triagemLaboratorial)
        {
            TriagemLaboratorial retornoTriagemLaboratorial = doacao.TriagemLaboratorial;

            retornoTriagemLaboratorial.HepatiteB = triagemLaboratorial.HepatiteB;
            retornoTriagemLaboratorial.HepatiteC = triagemLaboratorial.HepatiteC;
            retornoTriagemLaboratorial.Hiv = triagemLaboratorial.Hiv;
            retornoTriagemLaboratorial.StatusTriagem = GetStatusExameLaboratorial(triagemLaboratorial, doacao.ImpedimentosDefinitivos);

            return retornoTriagemLaboratorial;
        }

        private ImpedimentosDefinitivos AtualizarImpedimentosDefinitivos(Doacao doacao, TriagemLaboratorial triagemLaboratorial)
        {
            ImpedimentosDefinitivos impedimentosDefinitivos = doacao.ImpedimentosDefinitivos;

            impedimentosDefinitivos.AntecedenteAvc = doacao.ImpedimentosDefinitivos.AntecedenteAvc;
            impedimentosDefinitivos.HepatiteB = triagemLaboratorial.HepatiteB;
            impedimentosDefinitivos.HepatiteC = triagemLaboratorial.HepatiteC;
            impedimentosDefinitivos.Hiv = triagemLaboratorial.Hiv;

            return impedimentosDefinitivos;
        }

        private Doador AtualizarDadosDoSangue(Doador doadorDoacao, Doador doadorFormulario)
        {
            Doador retornoDoador = doadorDoacao;

            retornoDoador.TipoSanguineo = doadorFormulario.TipoSanguineo;
            retornoDoador.FatorRh = doadorFormulario.FatorRh;

            return retornoDoador;
        }

        #endregion Atualização de atributos da doação

        #region Validação de status e atributos

        private StatusTriagem GetStatusExameLaboratorial(TriagemLaboratorial triagemLaboratorial, ImpedimentosDefinitivos impedimentosDefinitivos)
        {
            if (impedimentosDefinitivos.AntecedenteAvc == true ||
                triagemLaboratorial.HepatiteB == true ||
                triagemLaboratorial.HepatiteC == true ||
                triagemLaboratorial.Hiv == true)
            {
                return StatusTriagem.Reprovado;
            }
            return StatusTriagem.Aprovado;
        }

        private StatusDoacao GetStatusDoacao(Doacao doacao)
        {
            if (doacao.TriagemLaboratorial.StatusTriagem == StatusTriagem.Aprovado &&
                doacao.TriagemClinica.StatusTriagem == StatusTriagem.Aprovado)
            {
                return StatusDoacao.Disponivel;
            }

            return StatusDoacao.NaoDisponivel;
        }

        #endregion Validação de status e atributos
    }
}