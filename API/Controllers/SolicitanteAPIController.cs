using Microsoft.AspNetCore.Mvc;
using Repository.DAL;

namespace API.Controllers
{
    [Route("api/solicitante")]
    [ApiController]
    public class SolicitanteAPIController : ControllerBase
    {
        private readonly SolicitanteDAO _solicitanteDAO;

        public SolicitanteAPIController(SolicitanteDAO solicitanteDAO)
        {
            _solicitanteDAO = solicitanteDAO;
        }

        // GET: /api/solicitante/all
        [HttpGet]
        [Route("all")]
        public IActionResult ListarTodos()
        {
            return Ok(_solicitanteDAO.ListarSolicitantes());
        }
    }
}