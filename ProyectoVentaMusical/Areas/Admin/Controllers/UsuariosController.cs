using Microsoft.AspNetCore.Mvc;
using Models.Data;
using Microsoft.AspNetCore.Hosting;

namespace ProyectoVentaMusical.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsuariosController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
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
        public IActionResult Create(Usuario usuario)
        {
            //if (ModelState.IsValid)
            //{
                //Nuevo usuario
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            //}
            //return View(usuario);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Usuario usuario = new Usuario();
            usuario = _context.Usuario.FirstOrDefault(a => a.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Usuario usuario)
        {
            var articuloDesdeBd = _context.Usuario.FirstOrDefault(a => a.IdUsuario == usuario.IdUsuario);
            articuloDesdeBd.NumeroIdentificacion = usuario.NumeroIdentificacion;
            articuloDesdeBd.NombreCompleto = usuario.NombreCompleto;
            articuloDesdeBd.Genero = usuario.Genero;
            articuloDesdeBd.CorreoElectronico = usuario.CorreoElectronico;
            articuloDesdeBd.TipoTarjeta = usuario.TipoTarjeta;
            articuloDesdeBd.DineroDisponible = usuario.DineroDisponible;
            articuloDesdeBd.NumeroTarjeta = usuario.NumeroTarjeta;
            articuloDesdeBd.Contraseña = usuario.Contraseña;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #region Llamadas a la API
        [HttpGet]
        public IActionResult GetAll()
        {
            var usuarios = _context.Usuario.ToList();
            return Json(new { data = usuarios });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _context.Usuario.Find(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando Usuario" });
            }
            _context.Usuario.Remove(objFromDb);
            _context.SaveChanges();
            return Json(new { success = true, message = "Usuario Borrado Correctamente" });
        }
        #endregion
    }
}
