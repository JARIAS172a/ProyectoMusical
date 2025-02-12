using Microsoft.AspNetCore.Mvc;
using Models.Data;
using NuGet.ProjectModel;

namespace ProyectoVentaMusical.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AlbumesController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly ApplicationDbContext _context;

        public AlbumesController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
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
        public IActionResult Create(Albumes album)
        {
            //if (ModelState.IsValid)
            //{
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;
                if (album.CodigoAlbum == 0 && archivos.Count() > 0)
                {
                    //Nuevo articulo
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\albumes");
                    var extension = Path.GetExtension(archivos[0].FileName);

                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    album.ImagenAlbum = @"\imagenes\albumes\" + nombreArchivo + extension;

                    _context.Albumes.Add(album);
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                //}
                //else
                //{
                //    ModelState.AddModelError("Imagen", "Debes seleccionar una imagen");
                //}

            }
            return View(album);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Albumes album = new Albumes();
            album = _context.Albumes.FirstOrDefault(a => a.CodigoAlbum == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Albumes album)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var articuloDesdeBd = _context.Albumes.FirstOrDefault(a => a.CodigoAlbum == album.CodigoAlbum);


                if (archivos.Count() > 0)
                {
                    //Nuevo imagen para el artículo
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\albumes");
                    var extension = Path.GetExtension(archivos[0].FileName);
                    var nuevaExtension = Path.GetExtension(archivos[0].FileName);

                    var rutaImagen = Path.Combine(rutaPrincipal, articuloDesdeBd.ImagenAlbum.TrimStart('\\'));

                    if (System.IO.File.Exists(rutaImagen))
                    {
                        System.IO.File.Delete(rutaImagen);
                    }

                    //Nuevamente subimos el archivo
                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }

                    album.ImagenAlbum = @"\imagenes\albumes\" + nombreArchivo + extension;

                    
                    articuloDesdeBd.CodigoArtista = album.CodigoArtista;
                    articuloDesdeBd.NombreAlbum = album.NombreAlbum;
                    articuloDesdeBd.AñoLanzamiento = album.AñoLanzamiento;
                    articuloDesdeBd.ImagenAlbum = album.ImagenAlbum;
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //Aquí sería cuando la imagen ya existe y se conserva
                    album.ImagenAlbum = articuloDesdeBd.ImagenAlbum;
                }

                articuloDesdeBd.CodigoArtista = album.CodigoArtista;
                articuloDesdeBd.NombreAlbum = album.NombreAlbum;
                articuloDesdeBd.AñoLanzamiento = album.AñoLanzamiento;
                articuloDesdeBd.ImagenAlbum = album.ImagenAlbum;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));

            }
            return View();
        }

        #region Llamadas a la API
        [HttpGet]
        public IActionResult GetAll()
        {
            var albumes = _context.Albumes.ToList();
            return Json(new { data = albumes });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _context.Albumes.Find(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando un album" });
            }
            _context.Albumes.Remove(objFromDb);
            _context.SaveChanges();
            return Json(new { success = true, message = "Album Borrado Correctamente" });
        }
        #endregion
    }
}
