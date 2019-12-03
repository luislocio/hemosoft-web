using Domain.Enum;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.DAL;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HemosoftWeb.Controllers
{
    public class HomeController : Controller
    {
        private Usuario usuario;

        private readonly TriadorDAO _triadorDAO;
        private readonly SolicitanteDAO _solicitanteDAO;

        public HomeController(TriadorDAO triadorDAO, SolicitanteDAO solicitanteDAO)
        {
            _triadorDAO = triadorDAO;
            _solicitanteDAO = solicitanteDAO;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (username != null && password != null)
            {
                if (username.Length == 14)
                {
                    AutenticarSolicitante(username, password);
                }
                else
                {
                    AutenticarTriador(username, password);
                }
            }

            if (usuario.IdUsuario > 0)
            {
                return RedirectToAction("Home", "index");
            }
            else
            {
                ModelState.AddModelError("", "Falha no login!");
            }

            return View();
        }

        private void AutenticarTriador(string username, string password)
        {
            Triador triadorBusca = new Triador
            {
                Matricula = username
            };

            Triador triadorResultado = _triadorDAO.BuscarTriadorPorMatricula(triadorBusca);
            if (triadorResultado != null && triadorResultado.StatusUsuario != StatusUsuario.Inativo)
            {
                if (triadorResultado.Matricula.Equals(username) && triadorResultado.Senha.Equals(password))
                {
                    usuario.IdUsuario = triadorResultado.IdTriador;
                    usuario.NomeDeUsuario = triadorResultado.NomeCompleto;
                    usuario.TipoUsuario = TipoUsuario.Triador;
                }
            }
        }

        private void AutenticarSolicitante(string username, string password)
        {
            Solicitante solicitanteBusca = new Solicitante { Cnpj = username };
            Solicitante solicitanteResultado = _solicitanteDAO.BuscarSolicitantePorCnpj(solicitanteBusca);

            if (solicitanteResultado != null && solicitanteResultado.StatusUsuario != StatusUsuario.Inativo)
            {
                if (solicitanteResultado.Cnpj.Equals(username) && solicitanteResultado.Senha.Equals(password))
                {
                    usuario.IdUsuario = solicitanteResultado.IdSolicitante;
                    usuario.NomeDeUsuario = solicitanteResultado.RazaoSocial;
                    usuario.TipoUsuario = TipoUsuario.Solicitante;
                }
            }
        }
    }
}