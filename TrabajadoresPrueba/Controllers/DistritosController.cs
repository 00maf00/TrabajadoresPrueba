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
        //GET
        public IActionResult Create(int idProvincia) //trae el id Provincia
        {

            var distrito = new Distrito { IdProvincia = idProvincia };
            return View(distrito);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Distrito model)
        {
            await _context.Distrito.AddAsync(model); //insert
            await _context.SaveChangesAsync();//commit
            return RedirectToAction("Index", new { id = model.IdProvincia });
        }

        //GET
        public async Task<IActionResult> Edit(int id) //abrir la pantalla
        {
            var distrito = await _context.Distrito.FindAsync(id); // select * from Distrito where PK = id
            return View(distrito); //retornar vista
        }

        [HttpPost] //-> hacer el cambio 
        public async Task<IActionResult> Edit(Distrito model)
        {
            var modelOld = await _context.Distrito.FindAsync(model.Id);
            modelOld.NombreDistrito = model.NombreDistrito;
            _context.Update(modelOld); // update en provincia  
            await _context.SaveChangesAsync(); //comit a la base de datos
            return RedirectToAction("Index", new { id = model.IdProvincia });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var idProvincia = 0;
            var distrito = await _context.Distrito.FindAsync(id);
            if (distrito != null)
            {
                idProvincia = distrito.IdProvincia;
                _context.Remove(distrito);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", new { id = idProvincia });
        }
    }
}
