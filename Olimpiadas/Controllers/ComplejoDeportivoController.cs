using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Olimpiadas.Dominio.Entidades;
using Olimpiadas.Dominio.Repositorios;
using Olimpiadas.Infraestructura.Contextos;
using Olimpiadas.Infraestructura.Repositorios;
using Olimpiadas.Models;

namespace Olimpiadas.Controllers
{
    [Authorize]
    public class ComplejoDeportivoController : Controller
    {
        private readonly IRepositorioGenerico _repositorioGenerico;
        private readonly IMapper _mapper;

        public ComplejoDeportivoController(IRepositorioGenerico repositorioGenerico, IMapper mapper)
        {
            _repositorioGenerico = repositorioGenerico;
            _mapper = mapper;
        }
        public ActionResult Index(string tipoComplejo,string parametroBusqueda)
        {
            List<ComplejoDeportivo> complejoDeportivos = _repositorioGenerico.ObtenerPorExpresionLimite<ComplejoDeportivo>().ToList();
            if (!string.IsNullOrEmpty(parametroBusqueda))
            {
                complejoDeportivos = complejoDeportivos.Where(x => x.Nombre.Contains(parametroBusqueda)).ToList();                
            }
            if (!string.IsNullOrEmpty(tipoComplejo))
            {
                complejoDeportivos = complejoDeportivos.Where(x => x.TipoComplejoId.Equals(Convert.ToInt32(tipoComplejo))).ToList();
            }           

            var complejoDeportivoVM = new ComplejoDeportivoViewModel
            {
                ComplejoDeportivos = _mapper.Map<List<ComplejoDeportivoModel>>(complejoDeportivos),
                TiposDeComplejos = ObtenerTiposDeComplejo()
            };

            return View(complejoDeportivoVM);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complejoDeportivo = _repositorioGenerico.ObtenerPorCodigo<ComplejoDeportivo>((int)id);
            if (complejoDeportivo == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ComplejoDeportivoModel>(complejoDeportivo));
        }
        public ActionResult Create()
        {            
            ViewBag.TiposDeComplejo = ObtenerTiposDeComplejo();
            ViewBag.SedesOlimpicas = ObtenerSedesOlimpicas();
            return View();
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComplejoDeportivoModel complejoDeportivoModel)
        {
            if (ModelState.IsValid)
            {
                var complejoDeportivo = _mapper.Map<ComplejoDeportivo>(complejoDeportivoModel);
                _repositorioGenerico.Adicionar(complejoDeportivo);
                _repositorioGenerico.GuardarCambios();
                return RedirectToAction(nameof(Index));
            }
            return View(complejoDeportivoModel);
        }
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var complejoDeportivo = _repositorioGenerico.ObtenerPorCodigo<ComplejoDeportivo>((int)id);
            if(complejoDeportivo == null)
            {
                return NotFound();
            }
            ViewBag.TiposDeComplejo = ObtenerTiposDeComplejo();
            ViewBag.SedesOlimpicas = ObtenerSedesOlimpicas();
            return View(_mapper.Map<ComplejoDeportivoModel>(complejoDeportivo));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ComplejoDeportivoModel complejoDeportivoModel)
        {
            if (id != complejoDeportivoModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var complejoDeportivo = _mapper.Map<ComplejoDeportivo>(complejoDeportivoModel);
                    _repositorioGenerico.Actualizar(complejoDeportivo);
                    _repositorioGenerico.GuardarCambios();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var complejoDeportivo = _repositorioGenerico.ObtenerPorCodigo<ComplejoDeportivo>(complejoDeportivoModel.ID);
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
            return View(complejoDeportivoModel);
        }        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? ID)
        {
            var complejoDeportivo = _repositorioGenerico.ObtenerPorCodigo<ComplejoDeportivo>((int)ID);
            _repositorioGenerico.Eliminar(complejoDeportivo);
            _repositorioGenerico.GuardarCambios();            
            return RedirectToAction(nameof(Index));
        }
        private List<SelectListItem> ObtenerTiposDeComplejo()
        {
            List<TipoComplejo> tipoComplejos = _repositorioGenerico.ObtenerPorExpresionLimite<TipoComplejo>().ToList();
            return tipoComplejos.Select(x => new SelectListItem {Value = x.ID.ToString(), Text= x.Tipo }).ToList();
        }

        private List<SelectListItem> ObtenerSedesOlimpicas()
        {
            List<SedeOlimpica> tipoComplejos = _repositorioGenerico.ObtenerPorExpresionLimite<SedeOlimpica>().ToList();
            return tipoComplejos.Select(x => new SelectListItem { Value = x.ID.ToString(), Text = x.Nombre }).ToList();
        }
    }
}
