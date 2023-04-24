using Microsoft.AspNetCore.Mvc;
using TrabajadoresPrueba.Data;

namespace TrabajadoresPrueba.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly DataContext _context;

        public DepartamentosController(DataContext dataContext)
        {
            _context = dataContext;
        }
        public IActionResult Index()
        {
            var departamentos = _context.Departamento.ToList(); 
            return View(departamentos);
        }
    }
}
