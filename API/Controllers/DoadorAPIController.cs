using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enum;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.DAL;

namespace API.Controllers
{
    [Route("api/doador")]
    [ApiController]
    public class DoadorAPIController : ControllerBase
    {
        private readonly DoadorDAO _doadorDAO;

        public DoadorAPIController(DoadorDAO doadorDAO)
        {
            _doadorDAO = doadorDAO;
        }

        // GET: /api/tipoSanguineo/
        // GET: /api/tipoSanguineo/
        // GET: /api/tipoSanguineo/
        // GET: /api/tipoSanguineo/
        [HttpGet]
        [Route("tipoSanguineo/{tipoSanguineo}/{fatorRh}")]
        public IActionResult BuscarPorTipoSanguineo(string tipoSanguineo, string fatorRh)
        {
            Doador doador = new Doador();
            List<Doador> doadores = new List<Doador>();

            switch (tipoSanguineo)
            {
                case "A":
                    doador.TipoSanguineo = TipoSanguineo.A;
                    break;
                case "B":
                    doador.TipoSanguineo = TipoSanguineo.B;
                    break;
                case "AB":
                    doador.TipoSanguineo = TipoSanguineo.AB;
                    break;
                case "O":
                    doador.TipoSanguineo = TipoSanguineo.O;
                    break;
                default:
                    return BadRequest(new { msg = "Tipo Sanguineo Inválido" });
            }

            switch (fatorRh)
            {
                case "negativo":
                    doador.FatorRh = FatorRh.Negativo;
                    break;
                case "positivo":
                    doador.FatorRh = FatorRh.Positivo;
                    break;
                default:
                    return BadRequest(new { msg = "Fator RH Inválido" });
            }

            if (doadores.Count > 0)
            {
                return Ok(doadores);
            }
            else
            {
                return Ok(new { msg = "Não existem doadores com este Tipo Sanguineo" });
            }
        }
    }
}