using Microsoft.AspNetCore.Mvc;
using Models.Data;
using Microsoft.AspNetCore.Hosting;

namespace ProyectoVentaMusical.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GenerosController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly ApplicationDbContext _context;

        public GenerosController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
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
        public IActionResult Create(Artistas artista)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;
                if (artista.CodigoArtista == 0 && archivos.Count() > 0)
                {
                    //Nuevo articulo
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\artistas");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    artista.FotoArtista = @"\imagenes\artistas\" + nombreArchivo + extension;

                    _context.Artistas.Add(artista);
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Imagen", "Debes seleccionar una imagen");
                }

            }
            return View(artista);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Artistas artista = new Artistas();
            artista = _context.Artistas.FirstOrDefault(a => a.CodigoArtista == id);
            if (artista == null)
            {
                return NotFound();
            }

            return View(artista);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Artistas artista)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var articuloDesdeBd = _context.Artistas.FirstOrDefault(a => a.CodigoArtista == artista.CodigoArtista);


                if (archivos.Count() > 0)
                {
                    //Nuevo imagen para el artículo
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\artistas");
                    var extension = Path.GetExtension(archivos[0].FileName);
                    var nuevaExtension = Path.GetExtension(archivos[0].FileName);

                    var rutaImagen = Path.Combine(rutaPrincipal, articuloDesdeBd.FotoArtista.TrimStart('\\'));

                    if (System.IO.File.Exists(rutaImagen))
                    {
                        System.IO.File.Delete(rutaImagen);
                    }

                    //Nuevamente subimos el archivo
                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    artista.FotoArtista = @"\imagenes\artistas\" + nombreArchivo + extension;

                    articuloDesdeBd.NombreReal = artista.NombreReal;
                    articuloDesdeBd.FechaNacimiento = artista.FechaNacimiento;
                    articuloDesdeBd.NombreArtistico = artista.NombreArtistico;
                    articuloDesdeBd.FotoArtista = artista.FotoArtista;
                    articuloDesdeBd.Nacionalidad = artista.Nacionalidad;
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //Aquí sería cuando la imagen ya existe y se conserva
                    artista.FotoArtista = articuloDesdeBd.FotoArtista;
                }

                articuloDesdeBd.NombreReal = artista.NombreReal;
                articuloDesdeBd.FechaNacimiento = artista.FechaNacimiento;
                articuloDesdeBd.NombreArtistico = artista.NombreArtistico;
                articuloDesdeBd.FotoArtista = artista.FotoArtista;
                articuloDesdeBd.Nacionalidad = artista.Nacionalidad;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));

            }
            return View();
        }

        #region Llamadas a la API
        [HttpGet]
        public IActionResult GetAll()
        {
            var artistas = _context.Artistas.ToList();
            return Json(new { data = artistas });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _context.Artistas.Find(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando artista" });
            }
            _context.Artistas.Remove(objFromDb);
            _context.SaveChanges();
            return Json(new { success = true, message = "Artista Borrada Correctamente" });
        }
        #endregion
    }
}
