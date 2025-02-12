using Microsoft.AspNetCore.Mvc;
using Models.Data;

namespace ProyectoVentaMusical.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CancionesController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly ApplicationDbContext _context;

        public CancionesController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)

        {

            _context = context;

            _hostingEnvironment = hostingEnvironment;

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

        public IActionResult Create(Canciones cancion)
        {
            //if (ModelState.IsValid)
            //{
            _context.Canciones.Add(cancion);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            //}
            return View(cancion);
        }

        [HttpGet]

        public IActionResult Edit(int id)
        {
            Canciones cancion = new Canciones();

            cancion = _context.Canciones.FirstOrDefault(a => a.CodigoCancion == id);

            if (cancion == null)
            {
                return NotFound();
            }
            return View(cancion);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Canciones cancion)
        {
            //if (ModelState.IsValid)
            //{
            var articuloDesdeBd = _context.Canciones.FirstOrDefault(a => a.CodigoCancion == cancion.CodigoCancion);

            articuloDesdeBd.CodigoGenero = cancion.CodigoGenero;

            articuloDesdeBd.CodigoAlbum = cancion.CodigoAlbum;

            articuloDesdeBd.NombreCancion = cancion.NombreCancion;

            articuloDesdeBd.LinkVideo = cancion.LinkVideo;

            articuloDesdeBd.Precio = cancion.Precio;

            articuloDesdeBd.CantidadDisponible = cancion.CantidadDisponible;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
            //}
            //return View();
        }

        #region Llamadas a la API

        [HttpGet]

        public IActionResult GetAll()
        {
            var canciones = _context.Canciones.ToList();
            return Json(new { data = canciones });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _context.Canciones.Find(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando cancion" });
            }

            _context.Canciones.Remove(objFromDb);

            _context.SaveChanges();

            return Json(new { success = true, message = "Cancion Borrada Correctamente" });
        }
        #endregion
    }
}