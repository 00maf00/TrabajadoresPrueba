using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabajadoresPrueba.Data;
using TrabajadoresPrueba.Modelos;

namespace TrabajadoresPrueba.Controllers
{
    public class ProvinciasController : Controller
    {
        private readonly DataContext _context;

        public ProvinciasController(DataContext dataContext)
        {
            _context = dataContext;
        }

        //GET
        public async Task<IActionResult> Index(int id) //
        {
            var provincias = await _context.Provincia.Where(t => t.IdDepartamento.Equals(id)).ToListAsync(); //dentro de la vista departamentos
            var modelDepartamento = await _context.Departamento.FindAsync(id);
            ViewBag.Departamento = modelDepartamento;
            return View(provincias); //vista de provincias
        }

        //GET 
        public IActionResult Create(int idDepartamento)
        {
            var provincia = new Provincia { IdDepartamento = idDepartamento };
            return View(provincia);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Provincia model)
        {
            await _context.Provincia.AddAsync(model); //
            await _context.SaveChangesAsync(); //comit a la base de datos
            return RedirectToAction("Index", new { id = model.IdDepartamento });
        }

        //GET -> obtener el registro
        public async Task<IActionResult> Edit(int id) //abrir la pantalla
        {
            var provincia = await _context.Provincia.FindAsync(id); // select * from Provincia where PK = id
            return View(provincia); //retornar vista
        }

        [HttpPost] //-> hacer el cambio 
        public async Task<IActionResult> Edit(Provincia model)
        {
            var modelOld = await _context.Provincia.FindAsync(model.Id);
            modelOld.NombreProvincia = model.NombreProvincia;
            _context.Update(modelOld); // update en provincia 
            //await _context.Provincia.AddAsync(model); 
            await _context.SaveChangesAsync(); //comit a la base de datos
            return RedirectToAction("Index", new { id = model.IdDepartamento });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var provincia = await _context.Provincia.FindAsync(id);
            if (provincia != null)
            {
                _context.Remove(provincia);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
