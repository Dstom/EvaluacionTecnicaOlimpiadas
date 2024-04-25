using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Olimpiadas.Dominio.Entidades;
using Olimpiadas.Dominio.Repositorios;
using Olimpiadas.Infraestructura.Contextos;
using Olimpiadas.Models;

namespace Olimpiadas.Controllers
{
    [Authorize]
    public class SedeController : Controller
    {
        private readonly IRepositorioGenerico _repositorioGenerico;
        private readonly IMapper _mapper;

        public SedeController(IRepositorioGenerico repositorioGenerico, IMapper mapper)
        {
            _repositorioGenerico = repositorioGenerico;
            _mapper = mapper;
            
        }
        public ActionResult Index(string parametroBusqueda)
        {
            List<SedeOlimpica> sedesOlimpicas = new List<SedeOlimpica>();
            if (!string.IsNullOrEmpty(parametroBusqueda))
            {
                sedesOlimpicas = _repositorioGenerico.ObtenerPorExpresionLimite<SedeOlimpica>(
                    x => x.Nombre.Contains(parametroBusqueda)).ToList();
            }
            else
            {
                sedesOlimpicas = _repositorioGenerico.ObtenerPorExpresionLimite<SedeOlimpica>().ToList();
            }
            var sedeVM= new SedeViewModel
            {
                SedesOlimpicas = _mapper.Map<List<SedeModel>>(sedesOlimpicas)
                
            };
            return View(sedeVM);            
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sedeOlimpica = _repositorioGenerico.ObtenerPorCodigo<SedeOlimpica>((int)id);
            
            if (sedeOlimpica == null)
            {
                return NotFound();
            }

            var asd = _mapper.Map<SedeDetailsViewModel>(sedeOlimpica);

            return View(_mapper.Map<SedeDetailsViewModel>(sedeOlimpica));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SedeModel sedeModel)
        {
            if (ModelState.IsValid)
            {
                var sedeOlimpica = _mapper.Map<SedeOlimpica>(sedeModel);
                _repositorioGenerico.Adicionar(sedeOlimpica);
                _repositorioGenerico.GuardarCambios();
                return RedirectToAction(nameof(Index));
            }
            return View(sedeModel);
        }
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var sedeOlimpica = _repositorioGenerico.ObtenerPorCodigo<SedeOlimpica>((int)id);
            if (sedeOlimpica == null)
            {
                return NotFound();
            }            
            return View(_mapper.Map<SedeModel>(sedeOlimpica));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SedeModel sedeModel)
        {
            if (id != sedeModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var sedeOlimpica = _mapper.Map<SedeOlimpica>(sedeModel);
                    _repositorioGenerico.Actualizar(sedeOlimpica);
                    _repositorioGenerico.GuardarCambios();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var complejoDeportivo = _repositorioGenerico.ObtenerPorCodigo<ComplejoDeportivo>(sedeModel.ID);
                    if (complejoDeportivo == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sedeModel);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? ID)
        {
            var sedeOlimpica = _repositorioGenerico.ObtenerPorCodigo<SedeOlimpica>((int)ID);
            _repositorioGenerico.Eliminar(sedeOlimpica);
            _repositorioGenerico.GuardarCambios();
            return RedirectToAction(nameof(Index));
        }
    }
}
