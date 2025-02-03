using Microsoft.AspNetCore.Mvc;
using Models.Data;

namespace ProyectoVentaMusical.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArtistasController : Controller
    {
        

        private readonly ApplicationDbContext _context;

        public ArtistasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Artistas artista)
        {
            if (ModelState.IsValid)
            {
                //Logica para guardar en BD
                _context.Artistas.Add(artista);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(artista);
        }

        //public IActionResult Edit(int id)
        //{
        //    Categoria categoria = new Categoria();
        //    categoria = _contenedorTrabajo.Categoria.Get(id);
        //    if (categoria == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(categoria);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Categoria categoria)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //Logica para actualizar en BD
        //        _contenedorTrabajo.Categoria.Update(categoria);
        //        _contenedorTrabajo.Save();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(categoria);
        //}

        #region Llamadas a la API
        [HttpGet]
        public IActionResult GetAll()
        {
            var artistas = _context.Artistas.ToList();
            return Json(new { data = artistas});
        }

        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    var objFromDb = _contenedorTrabajo.Categoria.Get(id);
        //    if (objFromDb == null)
        //    {
        //        return Json(new { success = false, message = "Error borrando categoria" });
        //    }
        //    _contenedorTrabajo.Categoria.Remove(objFromDb);
        //    _contenedorTrabajo.Save();
        //    return Json(new { success = true, message = "Categoria Borrada Correctamente" });
        //}
        #endregion
    }
}
