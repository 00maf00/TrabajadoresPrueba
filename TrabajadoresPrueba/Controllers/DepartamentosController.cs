using Microsoft.AspNetCore.Mvc;
using TrabajadoresPrueba.Data;
using TrabajadoresPrueba.Modelos;

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

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Create(Departamento model)
        {
            await _context.AddAsync(model); //(Insert into Departamento values 'Prueba 123'
            await _context.SaveChangesAsync(); //Commit a la base de datos 
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var departamento = await _context.Departamento.FindAsync(id);
            return View(departamento);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Departamento model)
        {
            var modelOld = await _context.Departamento.FindAsync(model.Id);
            modelOld.NombreDepartamento = model.NombreDepartamento;
            _context.Update(modelOld);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Delete(int id)
        {
            var departamento = await _context.Departamento.FindAsync(id);
            _context.Remove(departamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
