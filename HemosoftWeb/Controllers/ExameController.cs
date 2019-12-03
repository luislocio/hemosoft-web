using Domain.Enum;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.DAL;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;

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
            Doacao doacao = _doacaoDAO.BuscarDoacaoPorId(id);
            ViewBag.idDoacao = id;
            ViewBag.tipoSanguineo = doacao.Doador.TipoSanguineo;
            ViewBag.fatorRh = doacao.Doador.FatorRh;
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

                FileStreamResult stream = contruirPdf(doacao);
                return stream;
                // TODO: [FEEDBACK] - Mostrar mensagem de sucesso.
                //return RedirectToAction("perfil", "doacao", new RouteValueDictionary { { "id", doacao.IdDoacao } });
            }
            ViewBag.idDoacao = triagemLaboratorial.Doacao.Doador.IdDoador;
            return View();
        }

        private FileStreamResult contruirPdf(Doacao doacao)
        {
            string apiKey = "2c7b70e8-4f26-407d-89cb-b20be62a9148";
            string value =
              "<h1>" + doacao.Doador.NomeCompleto + " - " + doacao.DataDoacao + "</h1>" +
              "<h3>Tipo Sanguineo</h3>" +
              "<p>" + doacao.Doador.TipoSanguineo + " " + doacao.Doador.FatorRh + "</p>" +
              "<h3>Status</h3>" +
              "<p>" + doacao.StatusDoacao + "</p>" +
              "<h3>Peso</h3>" +
              "<p>" + doacao.TriagemClinica.Peso + " kg</p>" +
              "<h3>Pulso</h3>" +
              "<p>" + doacao.TriagemClinica.Pulso + " bpm</p>" +
              "<h3>Temperatura</h3>" +
              "<p>" + doacao.TriagemClinica.Temperatura + " °C</p>" +
              "<h3>Bebida Alcoolica Recente</h3>" +
              "<p>" + doacao.ImpedimentosTemporarios.BebidaAlcoolica + "</p>" +
              "<h3>Gravidez Recente</h3>" +
              "<p>" + doacao.ImpedimentosTemporarios.Gravidez + "</p>" +
              "<h3>Gripe Recente</h3>" +
              "<p>" + doacao.ImpedimentosTemporarios.Gripe + "</p>" +
              "<h3>Tatuagem</h3>" +
              "<p>" + doacao.ImpedimentosTemporarios.Tatuagem +
              "<h3>Antecedente de AVC</h3>" +
              "<p>" + doacao.ImpedimentosDefinitivos.AntecedenteAvc + "</p>" +
              "<h3>Hepatite B</h3>" +
              "<p>" + doacao.ImpedimentosDefinitivos.HepatiteB + "</p>" +
              "<h3>Hepatite C</h3>" +
              "<p>" + doacao.ImpedimentosDefinitivos.HepatiteC + "</p>" +
              "<h3>HIV</h3>" +
              "<p>" + doacao.ImpedimentosDefinitivos.Hiv + "</p>";

            using (var client = new WebClient())
            {
                // Build the conversion options
                NameValueCollection options = new NameValueCollection();
                options.Add("apikey", apiKey);
                options.Add("value", value);

                // Call the API convert to a PDF
                MemoryStream ms = new MemoryStream(client.UploadValues("http://api.html2pdfrocket.com/pdf", options));

                // Make the file a downloadable attachment - comment this out to show it directly inside
                HttpContext.Response.Headers["content-disposition"] = "attachment; filename=" + Guid.NewGuid() + ".pdf";

                // Return the file as a PDF
                return new FileStreamResult(ms, "application/pdf");
            }
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