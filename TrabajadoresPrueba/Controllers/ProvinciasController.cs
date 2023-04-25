using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabajadoresPrueba.Data;

namespace TrabajadoresPrueba.Controllers
{
    public class ProvinciasController : Controller
    {
        private readonly DataContext _context;

        public ProvinciasController(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<IActionResult> Index(int id) 
        {
            var provincias = await _context.Provincia.Where(t=>t.IdDepartamento.Equals(id)).ToListAsync();
            return View(provincias);
        }
    }
}
