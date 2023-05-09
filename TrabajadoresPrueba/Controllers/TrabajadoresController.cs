using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TrabajadoresPrueba.Data;
using TrabajadoresPrueba.Modelos;
using TrabajadoresPrueba.Models;

namespace TrabajadoresPrueba.Controllers
{
    public class TrabajadoresController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TrabajadoresController(DataContext dataContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = dataContext;
            _webHostEnvironment = webHostEnvironment;
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
            var listado = await _context.Provincia.Where(t => t.IdDepartamento.Equals(id)).ToListAsync();
            return Json(listado);
        }

        [HttpGet]
        public async Task<JsonResult> CargarDistritos(int id)
        {
            var listado = await _context.Distrito.Where(t => t.IdProvincia.Equals(id)).ToListAsync();
            return Json(listado);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Trabajador model)
        {
            var prueba = model.FichaIFormFile;
            if (model.FichaIFormFile != null) //adjunto un archivo 
            {
                model.Ficha = await CargarDocumento(model.FichaIFormFile, "Ficha");
            }

            var prueba2 = model.FotoIFormFile;
            if (model.FotoIFormFile!= null) 
            {
                model.Foto = await CargarDocumento2(model.FotoIFormFile, "Foto");
            }

            _context.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<String> CargarDocumento(IFormFile fichaIformFile, string ruta)
        {
            var guid = Guid.NewGuid().ToString();
            var fileName = guid + Path.GetExtension(fichaIformFile.FileName);
            var carga1 = Path.Combine(_webHostEnvironment.WebRootPath, "images", ruta);
            //var carga = Path.Combine(_webHostEnvironment.WebRootPath, string.Format("Imagenes/{0}", ruta));
            using (var fileStream = new FileStream(Path.Combine(carga1, fileName), FileMode.Create))
            {
                     await fichaIformFile.CopyToAsync(fileStream);
            }
            return string.Format("/images/{0}/{1}", ruta, fileName);
        }

        private async Task<String> CargarDocumento2(IFormFile fotoIformFile, string ruta)
        {
            var guid = Guid.NewGuid().ToString();
            var fileName = guid + Path.GetExtension(fotoIformFile.FileName);
            var carga1 = Path.Combine(_webHostEnvironment.WebRootPath, "images", ruta);
            //var carga = Path.Combine(_webHostEnvironment.WebRootPath, string.Format("Imagenes/{0}", ruta));
            using (var fileStream = new FileStream(Path.Combine(carga1, fileName), FileMode.Create))
            {
                await fotoIformFile.CopyToAsync(fileStream);
            }
            return string.Format("/images/{0}/{1}", ruta, fileName);
        }
    }
}