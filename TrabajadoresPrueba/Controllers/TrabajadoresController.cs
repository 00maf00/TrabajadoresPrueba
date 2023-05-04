using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabajadoresPrueba.Data;
using TrabajadoresPrueba.Modelos;
using TrabajadoresPrueba.Models;

namespace TrabajadoresPrueba.Controllers
{
    public class TrabajadoresController : Controller
    {
        private readonly DataContext _context;

        public TrabajadoresController(DataContext dataContext)
        {
            _context = dataContext;
        }

        public IActionResult Index()
        {
            var listado = _context.Trabajadores.ToList();
            return View(listado);
        }

        //GET
        public async Task<IActionResult> Create()
        {
            var TiposDocumentos = new List<TiposDocumentos>();
            TiposDocumentos.Add(new TiposDocumentos { TipoDocumento = "DNI", NombreDocumento = "DNI" });
            TiposDocumentos.Add(new TiposDocumentos { TipoDocumento = "CXE", NombreDocumento = "Carnet Extranjeria" });
            TiposDocumentos.Add(new TiposDocumentos { TipoDocumento = "PAS", NombreDocumento = "Pasaporte" });
            
            ViewBag.TipoDocumento = new SelectList(TiposDocumentos, "TipoDocumento", "NombreDocumento");

            var Departamentos = await _context.Departamento.ToListAsync();
            ViewData["IdDepartamento"] = new SelectList(Departamentos, "Id", "NombreDepartamento");

            return View();
        }

        [HttpGet]
        public async Task<JsonResult> CargarProvincias(int id)
        {
            var listado = await _context.Provincia.Where( t=> t.IdDepartamento.Equals(id)).ToListAsync();
            return Json(listado);
        }

        [HttpGet]
        public async Task<JsonResult> CargarDistritos(int id)
        {
            var listado = await _context.Distrito.Where( t=> t.IdProvincia.Equals(id)).ToListAsync();    
            return Json(listado);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Trabajador model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
