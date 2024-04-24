using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Olimpiadas.Dominio.Entidades;
using Olimpiadas.Dominio.Repositorios;
using Olimpiadas.Models;

namespace Olimpiadas.Controllers
{
    public class LoginController : Controller
    {
        private readonly IRepositorioGenerico _repositorioGenerico;
        public LoginController(IRepositorioGenerico repositorioGenerico)
        {
            _repositorioGenerico = repositorioGenerico;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuarioLogeado = _repositorioGenerico.ObtenerPorExpresionLimite<Usuario>(x =>
                x.Email.Equals(model.Email) &&
                x.Clave.Equals(model.Clave) &&
                x.Estado).FirstOrDefault();
                if (usuarioLogeado == null)
                {
                    ModelState.AddModelError("", "Inicio de Sesion Incorrecto");
                    return NotFound();
                }
                
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
