using Domain.Enum;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.DAL;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/doacao")]
    [ApiController]
    public class DoacaoAPIController : ControllerBase
    {
        private readonly DoacaoDAO _doacaoDAO;

        public DoacaoAPIController(DoacaoDAO doacaoDAO)
        {
            _doacaoDAO = doacaoDAO;
        }

        // GET: /api/doacao/buscarPorStatus/naoDisponivel
        // GET: /api/doacao/buscarPorStatus/disponivel
        // GET: /api/doacao/buscarPorStatus/aguardandoAtendimento
        // GET: /api/doacao/buscarPorStatus/aguardandoResultados
        [HttpGet]
        [Route("buscarPorStatus/{status}")]
        public IActionResult BuscarPorStatus(string status)
        {
            Doacao doacao = new Doacao();
            List<Doacao> doacoes = new List<Doacao>();
            switch (status)
            {
                case "naoDisponivel":
                    doacao.StatusDoacao = StatusDoacao.NaoDisponivel;
                    break;

                case "disponivel":
                    doacao.StatusDoacao = StatusDoacao.Disponivel;
                    break;

                case "aguardandoAtendimento":
                    doacao.StatusDoacao = StatusDoacao.AguardandoAtendimento;
                    break;

                case "aguardandoResultados":
                    doacao.StatusDoacao = StatusDoacao.AguardandoResultados;
                    break;

                default:
                    return BadRequest(new { msg = "Status Inválido" });
            }

            doacoes = _doacaoDAO.BuscarDoacaoPorStatus(doacao);

            if (doacoes.Count > 0)
            {
                return Ok(doacoes);
            }
            else
            {
                return Ok(new { msg = "Não existem doações com este status" });
            }
        }
    }
}