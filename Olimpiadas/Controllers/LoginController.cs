using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Olimpiadas.Dominio.Entidades;
using Olimpiadas.Dominio.Repositorios;
using Olimpiadas.Models;
using System.Security.Claims;

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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            var usuarioLogeado = _repositorioGenerico.ObtenerPorExpresionLimite<Usuario>(x =>
                                    x.Email.Equals(model.Email) &&
                                    x.Clave.Equals(model.Clave) &&
                                    x.Estado).FirstOrDefault();
            if (usuarioLogeado == null)
            {
                ModelState.AddModelError("", "Usuario o Contraseña Incorrectos");
                return View("Index");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuarioLogeado.Email),
                new Claim("FullName", usuarioLogeado.Nombre),
                new Claim(ClaimTypes.Role, "Administrador")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties { };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
