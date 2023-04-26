using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabajadoresPrueba.Data;
using TrabajadoresPrueba.Modelos;

namespace TrabajadoresPrueba.Controllers
{
    public class DistritosController : Controller
    {
        private readonly DataContext _context;

        public DistritosController(DataContext dataContext)
        {
            _context = dataContext;
        }

        //GET
        public async Task<IActionResult> Index(int id) //
        {
            var distrito = await _context.Distrito.Where(x => x.IdProvincia.Equals(id)).ToListAsync();
            var modelProvincia = await _context.Provincia.FindAsync(id);
            ViewBag.Provincia = modelProvincia;
            var modelDepartamento = await _context.Departamento.FindAsync(modelProvincia.IdDepartamento);
            ViewBag.Departamento = modelDepartamento;
            return View(distrito);
        }

        public IActionResult Create(int idProvincia)
        {
            var distrito = new Distrito { IdProvincia = idProvincia };
            return View(distrito);
        }
    }
}
